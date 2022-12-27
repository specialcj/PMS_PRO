using System;
using System.Collections.Generic;
using System.Diagnostics;
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


            foreach (string s in sList)
            {
                bool res = dllCheck.AlvCanCommsDllCheckForRadar("680927600K", s, out string dllSwitchPro, out bool dllSwitch);
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
        #endregion

        #region 方法
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




        #endregion

        private void btn_Debug_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\jason.cai\Desktop\test2";
            //string path = @"C:\Users\jason.cai\Desktop\lei da shua jian";

            List<string> sFileList1 = new List<string>();
            List<string> sFileList2 = new List<string>();

            Task.Run(()=> {
                RecursionDir(sFileList1, new DirectoryInfo(path), true);
                RecursionDir(sFileList2, new DirectoryInfo(path), false);

                Console.WriteLine(sFileList1.Count);
                Console.WriteLine(sFileList2.Count);
            });
            
        }






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

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"A:\ALV_CAN_COMMS_0.0.71.2");
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.CloseForm();
        }
    }
}
