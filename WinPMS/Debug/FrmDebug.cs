using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using PMS.DLL;

namespace WinPMS.Debug
{
    public partial class FrmDebug : Form
    {
        public FrmDebug()
        {
            InitializeComponent();
        }


        #region 事件
        private void btn_DllCheckForRadar2_Click(object sender, EventArgs e)
        {
            DllCheck dllCheck = new DllCheck();

            List<string> sList = new List<string>();

            //ALV_CAN_COMMS - gm#DLL_X_X_71_2
            //sList.Add("Radar 77GHz G1.2 GM Global B LRR L233 MY23 FLR");

            //DLL_X_X_71_17
            //sList.Add("Radar 77GHz G1.2 Geea2.0 KX11 CR");

            //DLL_X_X_80_5
            //sList.Add("Radar 77GHz G1.2 Geea2.0 KX11 FLR");

            //DLL_X_X_71_20
            //sList.Add("Radar 77GHz G1.2 GAC A60 FLR");

            //DLL_X_X_71_29
            //sList.Add("Radar 77GHz G1.3 GWM ES13 RCR");

            //DLL_X_X_80_3
            //sList.Add("Radar 77GHz G1.3 GWM EC24 RCR");

            //DLL_X_X_77_11
            //sList.Add("Radar 77GHz G1.2 Chery T26 FLR");
            //sList.Add("Radar 77GHz G1.2 BTET 290D FLR");
            //sList.Add("Radar 77GHz G1.3 BTET 290D RCR");

            //DLL_X_X_67_0
            //sList.Add("Radar 77GHz G1.2 VCC FLR");

            //ALV_CAN_COMMS - fft ghost v4#DLL_X_X_68_0
            //sList.Add("Radar 77GHz G1.3 Nissan J32V E Power Rear Corner CR WithCS");

            //0.0.71.2
            //sList.Add("Radar 77GHz G1.2 BYD SC2E FLR");
            //sList.Add("Radar 77GHz G1.3 GAC A55 RCR");

            //Veh
            sList.Add("6819808AAA");
            //sList.Add("6819808CCC");
            foreach (string sDescCompare in sList)
            {
                bool res = dllCheck.AlvCanCommsDllCheckForRadar("Veh No", sDescCompare, "Description Show", out string dllSwitchPro, out bool dllSwitch);
            }
        }


        private void btn_HEIC2jpg_Click(object sender, EventArgs e)
        {
            FileInfo info = new FileInfo(@"D:\_VNE_Work\_SendAnywhere\IMG_7432.HEIC");
            using (MagickImage image = new MagickImage(info.FullName))
            {
                // Save frame as jpg
                //image.Write(@"{info.Name}.jpg");
                image.Write(@"D:\_VNE_Work\_SendAnywhere\IMG_7432.jpg");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Process.Start(@"A:\ALV_CAN_COMMS_0.0.71.2");

            //string s2 = PaddingAsStrByLen("C:\\ALV_CAN_COMMS - fft ghost v4", 50, " ", true);
            //string s3 = PaddingAsStrByLen("C:\\ALV_CAN_Comms - gm", 50, " ", true);

            //listBox1.Items.Add(s2);
            //listBox1.Items.Add(s3);

            string s1 = "C:\\ALV_CAN_COMMS - fft ghost v4>>> ALV_CAN_Comms_fft.dll >>> 1.1.71.0 >>> Release Build - 2022-02-22 at 11:39:37 >>> G1.3 Nissan fft ghost";
            listBox1.Items.Add(s1);

            string s2 = "C:\\ALV_CAN_COMMS - gm          >>> ALV_CAN_Comms_gm.dll >>> 1.1.73.0 >>> Release Build - 2022-03-10 at 12:04:05 >>> G1.2 GM";
            listBox1.Items.Add(s2);
        }


        private void btn_Debug_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\jason.cai\Desktop\test2";
            //string path = @"C:\Users\jason.cai\Desktop\lei da shua jian";

            List<string> sFileList1 = new List<string>();
            List<string> sFileList2 = new List<string>();

            Task.Run(() =>
            {
                RecursionDir(sFileList1, new DirectoryInfo(path), true);
                RecursionDir(sFileList2, new DirectoryInfo(path), false);

                Console.WriteLine(sFileList1.Count);
                Console.WriteLine(sFileList2.Count);
            });

        }


        private void btn_SendMail_Click(object sender, EventArgs e)
        {

        }


        private void btn_ImgToPDF_Click(object sender, EventArgs e)
        {

        }


        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.CloseForm();
        }
        #endregion



        #region 方法
        /// <summary>
        /// 递归目录，添加目录下所有文件的FullName到List<string>中
        /// </summary>
        /// <param name="list">List中存储文件的FullName</param>
        /// <param name="fsi">目录 new DirectoryInfo(path)</param>
        /// <param name="isRecursionSubDir">是否递归子目录 true: 递归子目录, false: 不递归子目录</param>
        private void RecursionDir(List<string> list, FileSystemInfo fsi, bool isRecursionSubDir)
        {
            if (!fsi.Exists)
            {
                return;
            }

            DirectoryInfo dir = fsi as DirectoryInfo;

            //不是目录
            if (null == dir)
            {
                return;
            }

            FileSystemInfo[] files = dir.GetFileSystemInfos();

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i] as FileInfo;

                //是文件
                if (null != file)
                {
                    //Console.WriteLine(file.FullName + "\t" + file.Length);
                    list.Add(file.FullName);
                }
                else//对于子目录，进行递归调用
                {
                    if (isRecursionSubDir)
                    {
                        RecursionDir(list, files[i], isRecursionSubDir);
                    }
                }
            }
        }


        public List<string> AddSource()
        {
            List<string> sSource = new List<string>();
            {
                sSource.Add("681532300000001496");
                sSource.Add("681532300000001495");
                sSource.Add("681532300000001494");
                sSource.Add("681532300000001497");
                sSource.Add("681532300000001498");
                sSource.Add("681532300000001499");
                sSource.Add("681532300000001502");
                sSource.Add("681532300000001501");
                sSource.Add("681532300000001500");
                sSource.Add("681532300000001469");
            }

            return sSource;
        }


        /// <summary>
        /// 根据期望长度，以特定的字符串填充源字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="len">期望字符串的长度</param>
        /// <param name="padding">待填充的字符串</param>
        /// <param name="isAppend">是否在源字符串后追加，true->追加，false->不追加</param>
        private string PaddingAsStrByLen(string source, int len, string padding, bool isAppend)
        {
            int iSrcLen = source.Length;    //获取源字符串的长度
            int iLenDiff = len - iSrcLen;   //获取期望字符串的长度和源字符串长度之间的差
            string temp = isAppend ? source : "";

            if (iLenDiff > 0)
            {
                for (int i = 0; i < iLenDiff; i++)
                {
                    temp += padding;
                }
            }

            return temp;
        }
        #endregion


    }
}
