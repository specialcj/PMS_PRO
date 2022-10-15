using PMS.COMMON.Helper;
using PMS.MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WinPMS.FModels;
using ImageMagick;
using System.Threading.Tasks;
using System.Text;
using AForge.Video.DirectShow;
using System.Drawing;
using AForge.Video;
using ZXing;

namespace WinPMS.Tools
{
    public partial class FrmQRCodeScan : Form
    {
        public FrmQRCodeScan()
        {
            InitializeComponent();
        }

        FilterInfoCollection videoDevices; //所有摄像头
        VideoCaptureDevice videoSource; //当前摄像头 
        public int selectedDeviceIndex = 0;

        /// <summary>
        /// 全局变量，标示设备摄像头设备是否存在
        /// </summary>
        bool DeviceExist;

        /// <summary>
        /// 全局变量，记录扫描线距离顶端的距离
        /// </summary>
        int top = 0;

        /// <summary>
        /// 全局变量，保存每一次捕获的图像
        /// </summary>
        Bitmap img = null;





        #region 事件
        private void FrmQRCodeScan_Load(object sender, EventArgs e)
        {
            //获取摄像头列表
            getCamList();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "开始")
            {
                if (DeviceExist)
                {
                    //视频捕获设备
                    videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
                    //捕获到新画面时触发
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    //先关一下，下面再打开。避免重复打开的错误
                    CloseVideoSource();
                    //设置画面大小
                    //videoSource.DesiredFrameSize = new Size(160, 120);
                    videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];

                    //启动视频组件
                    videoSource.Start();
                    btnStart.Text = "结束";
                    //启动定时解析二维码
                    timer1.Enabled = true;
                    //启动绘制视频中的扫描线
                    timer2.Enabled = true;
                }
            }
            else
            {
                if (videoSource.IsRunning)
                {
                    timer2.Enabled = false;
                    timer1.Enabled = false;
                    CloseVideoSource();
                    btnStart.Text = "开始";
                }
            }
        }


        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Close" + " ？", "Info", 2))
            {
                this.CloseForm();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (img == null)
            {
                return;
            }
            #region 将图片转换成byte数组
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bt = ms.GetBuffer();
            ms.Close();
            #endregion

            #region 不稳定的二维码解析端口
            LuminanceSource source = new RGBLuminanceSource(bt, img.Width, img.Height);
            BinaryBitmap bitmap = new BinaryBitmap(new ZXing.Common.HybridBinarizer(source));

            Result result;

            MultiFormatReader multiFormatReader = new MultiFormatReader();

            try
            {
                //开始解码
                result = multiFormatReader.decode(bitmap);//（不定期暴毙）
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                multiFormatReader.reset();

            }

            if (result != null)
            {
                textBox1.Text = result.Text;
            }
            #endregion
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (img == null)
            {
                return;
            }
            Bitmap img2 = (Bitmap)img.Clone();
            Pen p = new Pen(Color.Red);
            Graphics g = Graphics.FromImage(img2);
            Point p1 = new Point(0, top);
            Point p2 = new Point(pictureBox1.Width, top);
            g.DrawLine(p, p1, p2);
            g.Dispose();
            top += 5;

            top %= pictureBox1.Height;
            pictureBox1.Image = img2;
        }

        #endregion


        #region 方法
        /// <summary>
        /// 获取摄像头列表
        /// </summary>
        private void getCamList()
        {
            try
            {
                //AForge.Video.DirectShow.FilterInfoCollection 设备枚举类
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                //清空列表框
                comboBox1.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();
                DeviceExist = true;
                //加入设备
                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);
                }
                //默认选择第一项
                comboBox1.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                comboBox1.Items.Add("未找到可用设备");
            }
        }


        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            img = (Bitmap)eventArgs.Frame.Clone();

        }

        /// <summary>
        /// 关闭摄像头
        /// </summary>
        private void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
        }

        #endregion

        
    }
}
