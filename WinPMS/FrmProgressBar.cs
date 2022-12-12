using PMS.COMMON.Helper;
using PMS.MODELS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using WinPMS.FModels;

namespace WinPMS
{
    public partial class FrmProgressBar : Form
    {
        public FrmProgressBar()
        {
            InitializeComponent();
        }

        private FrmMain _frmMain = null;
        private RDRAlvCanComms _RdrAlvCanComms = new RDRAlvCanComms();

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar_Load(object sender, EventArgs e)
        {
            this.progressBar1.Style = ProgressBarStyle.Marquee;
            bw.RunWorkerAsync();
        }


        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadIni();

            Thread.Sleep(new Random().Next(1000, 2000));
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (null != this.Tag)
            {
                _frmMain = new FrmMain
                {
                    Tag = new FrmProgressBarModel
                    {
                        FrmProgressBar = this,
                        FrmLoginModel = this.Tag as FrmLoginModel,
                        //PMSVersion = FileHelper.sIniPMSVersion,
                        PMSVersion = Application.ProductVersion,
                        RdrAlvCanComms = _RdrAlvCanComms,
                        LoadIni = LoadIni,
                    }
                };
            }

            _frmMain.Show();
        }


        /// <summary>
        /// 加载ini配置文件
        /// </summary>
        public void LoadIni()
        {
            //从ini配置文件中获取ALV_CAN_COMMS目录所在的盘符
            switch (FileHelper.sIniPMSUsage)
            {
                case "Debug":
                    //从ini配置文件中获取ALV_CAN_COMMS目录所在的盘符(大写)
                    _RdrAlvCanComms.FolderPath = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "ALV_CAN_COMMS_FolderPath", "NULL", FileHelper.sIniFilePathDebug);

                    //从ini配置文件中获取ALV_CAN_COMMS文件夹名称的前缀
                    _RdrAlvCanComms.FolderNamePrefix = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "ALV_CAN_COMMS_FolderNamePrefix", "NULL", FileHelper.sIniFilePathDebug);

                    //从ini配置文件中获取ALV_CAN_COMMS文件夹下dll文件的名称
                    _RdrAlvCanComms.DllFileName = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "ALV_CAN_COMMS_DllFileName", "NULL", FileHelper.sIniFilePathDebug);

                    //从ini配置文件中获取ALV_CAN_COMMS文件夹名称的前缀 (该文件夹是固定的)
                    _RdrAlvCanComms.DllFolderNamePrefixFixed = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "ALV_CAN_COMMS_FolderNamePrefix_Fixed", "NULL", FileHelper.sIniFilePathDebug);

                    //从ini配置文件中获取ALV_CAN_COMMS文件夹下.dll文件的名称 (该.dll是固定的)
                    _RdrAlvCanComms.DllFileNameFixed = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "ALV_CAN_COMMS_DllFileName_Fixed", "NULL", FileHelper.sIniFilePathDebug);

                    break;
                case "CFM":
                    //从ini配置文件中获取ALV_CAN_COMMS目录所在的盘符(大写)
                    _RdrAlvCanComms.FolderPath = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "ALV_CAN_COMMS_FolderPath", "NULL", FileHelper.sIniFilePathCFM);

                    //从ini配置文件中获取ALV_CAN_COMMS文件夹名称的前缀
                    _RdrAlvCanComms.FolderNamePrefix = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "ALV_CAN_COMMS_FolderNamePrefix", "NULL", FileHelper.sIniFilePathCFM);

                    //从ini配置文件中获取ALV_CAN_COMMS文件夹下dll文件的名称
                    _RdrAlvCanComms.DllFileName = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "ALV_CAN_COMMS_DllFileName", "NULL", FileHelper.sIniFilePathCFM);

                    //从ini配置文件中获取ALV_CAN_COMMS文件夹名称的前缀 (该文件夹是固定的)
                    _RdrAlvCanComms.DllFolderNamePrefixFixed = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "ALV_CAN_COMMS_FolderNamePrefix_Fixed", "NULL", FileHelper.sIniFilePathCFM);

                    //从ini配置文件中获取ALV_CAN_COMMS文件夹下.dll文件的名称 (该.dll是固定的)
                    _RdrAlvCanComms.DllFileNameFixed = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "ALV_CAN_COMMS_DllFileName_Fixed", "NULL", FileHelper.sIniFilePathCFM);

                    break;
                default:
                    break;
            }
        }
    }
}
