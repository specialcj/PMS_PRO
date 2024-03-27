using PMS.COMMON.Helper;
using PMS.COMMON.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinPMS.Debug;
using WinPMS.Radar;
using WinPMS.Tools;

namespace WinPMS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region 加载各文件的路径
            //..\bin\Debug
            //FileHelper.sAppStartPath = Application.StartupPath;

            //..\bin\Debug\xxx.exe
            FileHelper.sExeFilePath = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;

            //..\bin\Debug
            FileHelper.sExeFolderPath = Path.GetDirectoryName(FileHelper.sExeFilePath);

            //..\..\bin\Debug\Config\PMS.ini
            FileHelper.sIniFilePathPMS = Path.Combine(FileHelper.sExeFolderPath, @"Config\PMS.ini");

            //..\..\bin\Debug\Config\PMS_CFM.ini
            FileHelper.sIniFilePathCFM = Path.Combine(FileHelper.sExeFolderPath, @"Config\PMS_CFM.ini");

            //..\..\bin\Debug\Config\PMS_Debug.ini
            FileHelper.sIniFilePathDebug = Path.Combine(FileHelper.sExeFolderPath, @"Config\PMS_Debug.ini");

            //..\..\bin\Debug\Config\PMS_Local.ini
            FileHelper.sIniFilePathLocal = Path.Combine(FileHelper.sExeFolderPath, @"Config\PMS_Local.ini");

            //..\..\bin\Debug\DModels\MenuInfos.txt
            FileHelper.sMenuInfosTxtPath = Path.Combine(FileHelper.sExeFolderPath, @"DModels\MenuInfos.txt");
            #endregion


            #region 加载Ini中的配置参数
            FileHelper.sIniPMSDev = IniHelper.ReadIni(FileHelper.INI_SECTION_PMS, "PMS_Dev", "NULL", FileHelper.sIniFilePathPMS);

            FileHelper.sIniPMSUsage = IniHelper.ReadIni(FileHelper.INI_SECTION_PMS, "PMS_Usage", "NULL", FileHelper.sIniFilePathPMS);

            FileHelper.sIniPMSFtpUpdate = IniHelper.ReadIni(FileHelper.INI_SECTION_PMS, "PMS_FtpUpdate", "NULL", FileHelper.sIniFilePathPMS);

            //FileHelper.sIniPMSDllCheckOnOff = IniHelper.ReadIni(FileHelper.INI_SECTION_PMS, "PMS_DllCheckOnOff", "NULL", FileHelper.sIniFilePathPMS);

            FileHelper.sIniPMSOpenTestStepsCVI = IniHelper.ReadIni(FileHelper.INI_SECTION_PMS, "PMS_OpenTestStepsCVI", "NULL", FileHelper.sIniFilePathPMS);

            FileHelper.sIniPMSRebuildTestStepsCVI = IniHelper.ReadIni(FileHelper.INI_SECTION_PMS, "PMS_RebuildTestStepsCVI", "NULL", FileHelper.sIniFilePathPMS);

            FileHelper.sIniPwdOpr = IniHelper.ReadIni(FileHelper.INI_SECTION_PMS, "PMS_Opr", "NULL", FileHelper.sIniFilePathPMS);

            FileHelper.sIniPwdEncrypt = IniHelper.ReadIni(FileHelper.INI_SECTION_PMS, "PMS_Encrypt", "NULL", FileHelper.sIniFilePathPMS);

            FileHelper.sIniFormStartup = IniHelper.ReadIni(FileHelper.INI_SECTION_PMS, "Form_Startup", "NULL", FileHelper.sIniFilePathPMS);


            //define the input path of.HEIC file
            FileHelper.sIniPMSLocalPath1 = IniHelper.ReadIni(FileHelper.INI_PMS_LOCAL_SECTION, "Path1", "NULL", FileHelper.sIniFilePathLocal);

            //define the output path of .jpg file
            FileHelper.sIniPMSLocalPath2 = IniHelper.ReadIni(FileHelper.INI_PMS_LOCAL_SECTION, "Path2", "NULL", FileHelper.sIniFilePathLocal);


            //define the parameters of the Conformity Report
            FileHelper.sIniPMS_Conformity_Report_TestEngineer = IniHelper.ReadIni(FileHelper.INI_PMS_CONFORMITY_REPORT_SECTION, "TestEngineer", "NULL", FileHelper.sIniFilePathLocal);
            FileHelper.sIniPMS_Conformity_Report_PME = IniHelper.ReadIni(FileHelper.INI_PMS_CONFORMITY_REPORT_SECTION, "PME", "NULL", FileHelper.sIniFilePathLocal);
            FileHelper.sIniPMS_Conformity_Report_TestManager = IniHelper.ReadIni(FileHelper.INI_PMS_CONFORMITY_REPORT_SECTION, "TestManager", "NULL", FileHelper.sIniFilePathLocal);
            FileHelper.sIniPMS_Conformity_Report_PlantQualityManager = IniHelper.ReadIni(FileHelper.INI_PMS_CONFORMITY_REPORT_SECTION, "PlantQualityManager", "NULL", FileHelper.sIniFilePathLocal);
            #endregion


            #region 加载注册信息参数
            FileHelper.sComputerInfo = ComputerInfo.GetComputerInfo();
            for (int i = FileHelper.sComputerInfo.Length - 1; i >= 0; i--)
            {
                FileHelper.sComputerInfoDisplay += FileHelper.sComputerInfo[i];
            }
            #endregion

            #region 是否在本机C盘启动程序
            string user = Environment.UserName;
            string path = Application.StartupPath;
            //MessageBox.Show(path);

            //if (!path.StartsWith(@"C:\") && Environment.UserName.ToUpper() != "JASON.CAI")
            /*
            if (path != @"C:\PMS" && Environment.UserName.ToUpper() != "JASON.CAI")
            {
                MessageBox.Show("Please copy PMS to [C:\\] to start [" + Application.ProductName + ".exe" + "]!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //Environment.Exit(0);
                return;
            }
            */
            #endregion


            //获取已启动进程名
            string sProcessName = Process.GetCurrentProcess().ProcessName;

            //检查进程是否已经启动，已经启动则显示报错信息退出程序。
            if (Process.GetProcessesByName(sProcessName).Length > 1)
            {
                MessageBox.Show("PMS has already been started！\nDon't re-start！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                //Application.Exit();
                Application.ExitThread();
                return;
            }

            if (FileHelper.sIniPMSFtpUpdate == "Enable")
            {
                #region FTP
                string filePath = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
                string _appDir = Path.GetDirectoryName(filePath);
                string autoUpdateExe = _appDir + "\\AutoUpdateCheckPMS.exe";
                string autoUpdatePdb = _appDir + "\\AutoUpdateCheckPMS.pdb";
                string autoUpdateConfig = _appDir + "\\AutoUpdateCheckPMS.exe.config";
                try
                {
                    Process[] p = Process.GetProcessesByName("AutoUpdateCheckPMS");
                    if (p != null)
                    {
                        if (p.Length > 0)
                        {
                            foreach (Process pr in p)
                            {
                                pr.Kill();
                            }
                        }
                    }

                    //FtpParameters mo = WebAPI.GetFtpParameters();
                    //FtpClient ftp = new FtpClient(mo.FtpUser, mo.FtpPsw, mo.FtpServer, mo.FtpPort);
                    FtpClient ftp = new FtpClient("CORP\\jason.cai", "hmEBsHve624125", "10.124.15.47", 72);
                    //if (!File.Exists(autoUpdateExe))
                    ftp.Download(autoUpdateExe, "ftp://10.124.15.47:72/PMS/AutoUpdateCheck/bin/Debug/AutoUpdateCheckPMS.exe");
                    //if (!File.Exists(autoUpdatePdb))
                    ftp.Download(autoUpdatePdb, "ftp://10.124.15.47:72/PMS/AutoUpdateCheck/bin/Debug/AutoUpdateCheckPMS.pdb");
                    //if (!File.Exists(autoUpdateConfig))
                    ftp.Download(autoUpdateConfig, "ftp://10.124.15.47:72/PMS/AutoUpdateCheck/bin/Debug/AutoUpdateCheckPMS.exe.config");

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                #endregion



                #region WebAPI Version

                FileVersionInfo fviAutoUpdateCheck = FileVersionInfo.GetVersionInfo(autoUpdateExe);

                //string remoteVersion = WebAPI.getVersion("iTacGeneralUtilityTools.exe");
                //string localVersion = Application.ProductVersion;

                string remoteVersion = fviAutoUpdateCheck.FileVersion;
                string localVersion = Application.ProductVersion;

                MessageBox.Show("Local Version: " + localVersion + "\n\n" + "Remote Version: " + remoteVersion, "PMS Version Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                if (string.IsNullOrEmpty(remoteVersion))
                {
                    MessageBox.Show("Not Connect to Server!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    Environment.Exit(0);

                    Process.Start(_appDir + "\\WinPMS.exe");
                }
                if (localVersion != remoteVersion)
                {
                    int.TryParse(remoteVersion.Replace(".", ""), out int iNew);
                    int.TryParse(localVersion.Replace(".", ""), out int iOld);
                    if (iNew > iOld)
                    {
                        //LogHelper.Info("Find New version[" + remoteVersion + "] to instead of current version[" + localVersion + "]");
                        Process.Start(autoUpdateExe);
                        Environment.Exit(0);
                    }
                }
                #endregion
            }



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());

            //Application.Run(new FrmConformityReport());

            //Application.Run(new FrmDebug());
            //Application.Run(new FrmDebugRadar2SELRecipe());

            //Application.Run(new FrmFileZilla());

            //Application.Run(new FrmRDR2DllConfig());
            //Application.Run(new FrmRDR2SystemConfig());

            //Application.Run(new FrmQRCodeScan());

            //Application.Run(new FrmRadarRecipeConvert());
            //Application.Run(new FrmRadarBypassSetting());
            //Application.Run(new FrmRadarPacking());

            //Application.Run(new FrmTaskDemo());

            //Application.Run(new FrmRadarGM());
        }
    }
}
