using PMS.COMMON.Helper;
using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;


namespace PMS.DLL
{
    public class DllCheck
    {
        //public string _sIniPath = "";
        //public string _sIniPath = ConfigurationManager.AppSettings["PMSIniPath"].ToString();//ini配置文件
        //public string _sIniPath = new DirectoryInfo("../../../").FullName + @"WinPMS\Config\PMS.ini";

        private string _sPMSUsage = "";
        private string _sRDR2AlvCanCommsFolderPath = "";
        private string _sRDR2AlvCanCommsFolderNamePrefix = "";
        //private string _sRDR2AlvCanCommsFolderNamePrefixGM = "";
        private string _sRDR2AlvCanCommsDllFileName = "";

        private string _sPMSSection = FileHelper.INI_SECTION_PMS;
        private string _sRDRSELSection = FileHelper.INI_RDR_SEL_SECTION;
        private string _sRDRAlvCanCommsDllSection = FileHelper.INI_SECTION_RDR_ALV_CAN_COMMS_DLL;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">recipe中的Veh号</param>
        /// <param name="recipeDescription">recipe中的项目描述</param>
        /// <param name="dllSwitchPro">切换dll的项目信息</param>
        /// <param name="dllSwitch">是否切换dll的标识, Ture: 需要切换, False: 不需要切换</param>
        /// <returns></returns>
        public bool AlvCanCommsDllCheckForRadar(string name, string recipeDescription, out string dllSwitchPro, out bool dllSwitch)
        {
            /*
            FileHelper.sExeFilePath = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;//..\..\.dll, 获取该文件的路径
            FileHelper.sExeFolderPath = Path.GetDirectoryName(FileHelper.sExeFilePath);//获取该文件所在的目录


            //获取Ini配置文件的路径
            //string dir = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            string dir = FileHelper.sExeFolderPath;
            //MessageBox.Show("dir:" + "\n" + dir);//获取PMS.DLL的目录

            //获取ini的路径
            //string _sIniPathPMS = new DirectoryInfo(dir).Parent.FullName + @"\Config\PMS.ini";//ini的路径
            string _sIniPathPMS = Path.Combine(FileHelper.sExeFolderPath, @"Config\PMS.ini");
            */

            //通过TestStand调用获取Ini配置文件的路径
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string dir = Path.GetDirectoryName(path);
            string _sIniPathPMS = new DirectoryInfo(string.Format(@"{0}..\..\", dir)).FullName + @"Config\PMS.ini";
      

            //从ini配置文件中获取PMS的使用场景
            _sPMSUsage = IniHelper.ReadIni(_sPMSSection, "PMS_Usage", "NULL", _sIniPathPMS);

            string _sIniPathPMSUsed = _sIniPathPMS.Replace("PMS.ini", "PMS_" + _sPMSUsage + ".ini");

            /*
            if (recipeDescription.Contains("G1.3 GWM ES13 RCR"))
            {
                dllSwitchTemp = true;
            }
            else if (recipeDescription.Contains("G1.2 GAC A60 FLR"))
            {
                dllSwitchTemp = true;
            }
            */


            //根据PMS的使用场景, 加载对应的ini文件
            switch (_sPMSUsage)
            {
                case "CFM":
                    break;
                case "Debug":
                    MessageBox.Show("dir:" + "\n" + dir);
                    MessageBox.Show("_sIniPathPMS:" + "\n" + _sIniPathPMS);
                    MessageBox.Show("_sIniPathPMSUsed:" + "\n" + _sIniPathPMSUsed);
                    break;
                default:
                    break;
            }
            //MessageBox.Show("_sIniPath:" + "\n" + _sIniPathPMSUsed);

            //从ini配置文件中获取ALV_CAN_COMMS目录所在的盘符
            _sRDR2AlvCanCommsFolderPath = IniHelper.ReadIni(_sRDRSELSection, "ALV_CAN_COMMS_FolderPath", "NULL", _sIniPathPMSUsed);

            //从ini配置文件中获取ALV_CAN_COMMS文件夹名称的前缀
            _sRDR2AlvCanCommsFolderNamePrefix = IniHelper.ReadIni(_sRDRSELSection, "ALV_CAN_COMMS_FolderNamePrefix", "NULL", _sIniPathPMSUsed);

            //从ini配置文件中获取ALV_CAN_COMMS - GM文件夹名称的前缀
            //_sRDR2AlvCanCommsFolderNamePrefixGM = IniHelper.ReadIni(_sRDRSELSection, "ALV_CAN_COMMS_FolderNamePrefix_GM", "NULL", _sIniPathPMSUsed);

            //从ini配置文件中获取ALV_CAN_COMMS文件夹下dll文件的名称
            _sRDR2AlvCanCommsDllFileName = IniHelper.ReadIni(_sRDRSELSection, "ALV_CAN_COMMS_DllFileName", "NULL", _sIniPathPMSUsed);

            //拼接ALV_CAN_COMMS.dll的完整目录
            string sAlvCanCommsDllPath = Path.Combine(_sRDR2AlvCanCommsFolderPath, Path.Combine(_sRDR2AlvCanCommsFolderNamePrefix, _sRDR2AlvCanCommsDllFileName));


            //从ini配置文件中获取需要切换dll的信息
            string sDllSwitchProIni = IniHelper.ReadIni(_sRDRAlvCanCommsDllSection, "DLL_SWITCH_PRO", "NULL", _sIniPathPMSUsed);
            string sDllDllSwitchSpecialIni = IniHelper.ReadIni(_sRDRAlvCanCommsDllSection, "DLL_SWITCH_SPECIAL", "NULL", _sIniPathPMSUsed);
            string sDllSwitchNormalIni = IniHelper.ReadIni(_sRDRAlvCanCommsDllSection, "DLL_SWITCH_NORMAL", "NULL", _sIniPathPMSUsed);

            string[] sDllSwitchProIniList = sDllSwitchProIni.Split(',');//G1.2 GM Global B LRR, G1.2 Geea2.0#G1.3 Geea2.0, G1.2 GAC A60 FLR#G1.2 GAC A6V FLR, G1.3 GWM ES13 RCR
            string[] sDllSwitchSpecialIniList = sDllDllSwitchSpecialIni.Split(',');//0_0_71_14, 0_0_71_17, 0_0_71_20, 0_0_71_29
            
            string sDllExpected = ""; //期望使用的ALV_CAN_COMMS.dll

            List<string> dllExpectedFolderListForFixed = new List<string>();//期望的dll固定文件夹目录
            string sDllExpectedFolderForFixed;


            List<string> dllExpectedFolderListForFixedNotExist = new List<string>();//期望的dll固定文件夹目录不存在

            //循环遍历Ini中定义的需要dll切换的项目，判断当前项目的名称是否包含该项目
            //如果包含，则获取对应的dll版本
            int i;
            for (i = 0; i < sDllSwitchProIniList.Length; i++)
            {
                string sDllSwitchPro = sDllSwitchProIniList[i].Trim();

                if (sDllSwitchPro.Contains('#'))
                {
                    string[] sDllSwitchProIniListSub = sDllSwitchPro.Split('#');

                    for (int j = 0; j < sDllSwitchProIniListSub.Length; j++)
                    {
                        string sDllSwithcProSub = sDllSwitchProIniListSub[j].Trim();

                        if (recipeDescription.Contains(sDllSwithcProSub))
                        {
                            //Console.WriteLine(recipeDescription + "," + "期望dll" + "," + sDllSwitchSpecialIniList[iDllSwitchIndex].Trim());
                            sDllExpected = sDllSwitchSpecialIniList[i].Trim();
                        }
                    }
                }
                else
                {
                    if (recipeDescription.Contains(sDllSwitchPro))
                    {
                        //Console.WriteLine(recipeDescription + "," + "期望dll" + "," + sDllSwitchSpecialIniList[iDllSwitchIndex].Trim());
                        sDllExpected = sDllSwitchSpecialIniList[i].Trim();
                    }
                }
            }

            if (string.IsNullOrEmpty(sDllExpected))
            {
                //Console.WriteLine(recipeDescription + "," + "期望dll" + "," + sDllSwitchNormalIni);
                sDllExpected = sDllSwitchNormalIni;
            }

            //获取Log根目录文件夹, eg: C:\PMS_LOG\ALV_CAN_COMMS_DLL_LOG_RDR
            string sDllSwitchLogPathRoot = IniHelper.ReadIni(_sRDRAlvCanCommsDllSection, "DLL_SWITCH_LOG", "NULL", _sIniPathPMSUsed);

            //创建Log文件夹, eg: sDllSwitchLogPathRoot\2022\05
            //string sYear = "2022";
            string sYear = DateTime.Now.Year.ToString();
            //string sMonth = "06";
            string sMonth = string.Format("{0:D2}", DateTime.Now.Month);
            string sDay = string.Format("{0:D2}", DateTime.Now.Day);
            string sDate = sYear + "_" + sMonth + "_" + sDay;
            string sDllSwitchLogPath = sDllSwitchLogPathRoot + @"\" + sYear + @"\" + sMonth;
            string sSeparator = "--------------------------------------------";
            bool dllSwitchTemp = true;
            bool dllSwitchTemp1 = true;
            bool dllSwitchTemp2 = true;
            string sWriteLog;

            //sAlvCanCommsFolderNamePrefixFixed:
            //ALV_CAN_COMMS - gm, ALV_CAN_Comms - sweet400, ALV_CAN_COMMS - fft ghost v4
            string sAlvCanCommsFolderNamePrefixFixed = IniHelper.ReadIni(_sRDRSELSection, "ALV_CAN_COMMS_FolderNamePrefix_Fixed", "NULL", _sIniPathPMSUsed);

            //如果是固定的ALV_CAN DLL路径，判断提示文件夹路径是否存在
            if (sAlvCanCommsFolderNamePrefixFixed.Contains(sDllExpected))
            {
                //判断是否存在固定的ALV_CAN DLL文件夹
                if (!Directory.Exists(Path.Combine(_sRDR2AlvCanCommsFolderPath, sDllExpected)))
                {
                    dllSwitchTemp = true;//不存在

                    //dllSwitchPro = "Veh: " + name + "\n\n" + "Des: " + recipeDescription + "\n\n" + "Expected dll folder: " + Path.Combine(_sRDR2AlvCanCommsFolderPath, sDllExpected) + "\n\n" + "Current dll folder: folder not exist";

                    dllSwitchPro = "Veh号: " + name + "\n\n" + "描述: " + recipeDescription + "\n\n" + "期望dll目录: " + Path.Combine(_sRDR2AlvCanCommsFolderPath, sDllExpected) + "\n\n" + "当前dll目录: 目录不存在" + "\n";
                }
                else
                {
                    dllSwitchTemp = false;

                    //dllSwitchPro = "Veh: " + name + "\n\n" + "Des: " + recipeDescription + "\n\n" + "Expected dll folder: " + Path.Combine(_sRDR2AlvCanCommsFolderPath, sDllExpected) + "\n\n" + "Current dll folder: folder exist";

                    dllSwitchPro = "Veh号: " + name + "\n\n" + "描述: " + recipeDescription + "\n\n" + "期望dll目录: " + Path.Combine(_sRDR2AlvCanCommsFolderPath, sDllExpected) + "\n\n" + "当前dll目录: 目录存在" + "\n";
                }

                //Console.WriteLine(dllSwitchPro);

                sWriteLog = DateTime.Now + "\n\n" + dllSwitchPro + "\n\n" + dllSwitchTemp + (dllSwitchTemp ? "[folder not exist]" : "[folder exist]") + "\n\n" + sSeparator;
            }
            //else if (sDllExpected.Contains("#") && sAlvCanCommsFolderNamePrefixFixed.Contains(sDllExpected.Replace("#", ", ")))
            else if (sDllExpected.Contains("#") || !sDllExpected.StartsWith("DLL_"))
            {
                //sDllExpected as below:
                //ALV_CAN_COMMS - gm#DLL_0_0_71_2
                //ALV_CAN_Comms - sweet400#ALV_CAN_COMMS - fft ghost v4

                string sDllExpectedSpecial = ""; //期望使用的特殊的ALV_CAN_COMMS.dll
                string sDllExpectedFolder;
                string sDllExpectedFolderReplaceCurrent;

                if (sDllExpected.Contains("DLL_"))
                {
                    //原始字符串 -> ALV_CAN_COMMS - gm#DLL_0_0_71_2
                    /* 
                     * 处理后
                     * sDllExpectedSpecial -> DLL_0_0_71_2
                     * sDllExpectedReplace -> ALV_CAN_COMMS - gm
                     */
                    sDllExpectedSpecial = sDllExpected.Substring(sDllExpected.LastIndexOf("#") + 1); //DLL_0_0_71_2
                    sDllExpectedFolder = sDllExpected.Substring(0, sDllExpected.Length - sDllExpectedSpecial.Length - 1).Replace("#", ", "); //ALV_CAN_COMMS - gm
                }
                else
                {
                    //原始字符串 -> ALV_CAN_Comms - sweet400#ALV_CAN_COMMS - fft ghost v4
                    //处理后 -> sDllExpectedReplace -> ALV_CAN_Comms - sweet400, ALV_CAN_COMMS - fft ghost v4
                    sDllExpectedFolder = sDllExpected.Replace("#", ", ");
                }

                //sArrDllExpectedReplace as below:
                //[0]"ALV_CAN_Comms - sweet400"
                //[1]" ALV_CAN_COMMS - fft ghost v4"
                string[] sArrDllExpectedFolderReplace = sDllExpectedFolder.Split(',');

                //dllSwitchPro = "Veh: " + name + "\n\n" + "Des: " + recipeDescription + "\n\n";
                dllSwitchPro = "Veh号: " + name + "\n\n" + "描述: " + recipeDescription + "\n\n";


                //获取期望的文件夹目录: C:\ALV_CAN_Comms - sweet400, C:\ALV_CAN_COMMS - fft ghost v4
                for (int j = 0; j < sArrDllExpectedFolderReplace.Length; j++)
                {
                    sDllExpectedFolderReplaceCurrent = sArrDllExpectedFolderReplace[j].Trim();

                    dllExpectedFolderListForFixed.Add(Path.Combine(_sRDR2AlvCanCommsFolderPath, sDllExpectedFolderReplaceCurrent));
                }
                sDllExpectedFolderForFixed = string.Join(", ", dllExpectedFolderListForFixed.ToArray());

                
                if (string.IsNullOrEmpty(sDllExpectedSpecial))
                {
                    dllSwitchTemp1 = false;
                }
                else
                {
                    //判断当前目录下的dll是否正确？
                    //获取dll版本信息
                    //MessageBox.Show("sAlvCanCommsDllPath: " + sAlvCanCommsDllPath);
                    FileVersionInfo fviDll = FileVersionInfo.GetVersionInfo(sAlvCanCommsDllPath);
                    //Console.WriteLine(fviDll.FileVersion + "." + fviDll.FileBuildPart + "." + fviDll.FilePrivatePart);

                    //string sDllVersionCurrent = (fviDll.FileVersion + "." + fviDll.FileBuildPart + "." + fviDll.FilePrivatePart).Replace('.', '_');
                    string sDllVersionCurrent = (fviDll.FileMajorPart + "." + fviDll.FileMinorPart + "." + fviDll.FileBuildPart + "." + fviDll.FilePrivatePart).Replace(".", "_");

                    //Console.WriteLine("当前dll" + "," + sDllVersionCurrent);

                    string sDllExpectedTemp = sDllExpectedSpecial.Substring("DLL_".Length); //X_X_71_2
                    if (sDllExpectedTemp != sDllVersionCurrent)
                    {
                        //Console.WriteLine("需要切换dll");
                        dllSwitchTemp1 = true;
                    }
                    else
                    {
                        //Console.WriteLine("不需要切换dll");
                        dllSwitchTemp1 = false;
                    }

                    //dllSwitchPro += "Expected dll: " + sDllExpectedTemp + "\n\n" + "Current dll: " + sDllVersionCurrent + "\n\n";

                    dllSwitchPro += "期望dll: " + sDllExpectedTemp + "\n\n" + "当前dll: " + sDllVersionCurrent + "\n\n" + "dll匹配结果：" + (dllSwitchTemp1 ? "dll匹配错误" : "dll匹配正确") + "\n\n";
                    //Console.WriteLine(dllSwitchPro);

                    //sWriteLog = DateTime.Now + "\n\n" + dllSwitchPro + "\n\n" + dllSwitchTemp + (dllSwitchTemp ? "[need switch dll]" : "[no need to switch dll]") + "\n\n" + sSeparator;
                }

                //判断是否存在固定的ALV_CAN DLL文件夹
                for (int j = 0; j < sArrDllExpectedFolderReplace.Length; j++)
                {
                    if (!Directory.Exists(Path.Combine(_sRDR2AlvCanCommsFolderPath, sArrDllExpectedFolderReplace[j].Trim())))
                    {
                        dllSwitchTemp2 = true;//不存在

                        //将不存在的folder保存
                        dllExpectedFolderListForFixedNotExist.Add(Path.Combine(_sRDR2AlvCanCommsFolderPath, sArrDllExpectedFolderReplace[j].Trim()));
                    }
                    else
                    {
                        dllSwitchTemp2 = false;
                    }
                }

                if (dllSwitchTemp2)//不存在
                {
                    //dllSwitchPro += "Expected dll folder: " + sDllExpectedFolderForFixed + "\n\n" + "Current dll folder: folder not exist" + " [" + string.Join(", ", dllExpectedFolderListForFixedNotExist) + "]";

                    dllSwitchPro += "期望dll目录: " + sDllExpectedFolderForFixed + "\n\n" + "当前dll目录: 目录不存在" + " [" + string.Join(", ", dllExpectedFolderListForFixedNotExist) + "]" + "\n";
                }
                else//存在
                {
                    //dllSwitchPro += "Expected dll folder: " + sDllExpectedFolderForFixed + "\n\n" + "Current dll folder: folder exist";

                    dllSwitchPro += "期望dll目录: " + sDllExpectedFolderForFixed + "\n\n" + "当前dll目录: 目录存在" + "\n";
                }

                //Console.WriteLine(dllSwitchPro);

                dllSwitchTemp = dllSwitchTemp1 || dllSwitchTemp2;

                sWriteLog = DateTime.Now + "\n\n" + dllSwitchPro + "\n\n" + dllSwitchTemp1 + (dllSwitchTemp1 ? "[need switch dll]" : "[no need to switch dll]") + "\n\n" + dllSwitchTemp2 + (dllSwitchTemp2 ? "[folder not exist]" : "[folder exist]") + "\n\n" + sSeparator;
            }
            else
            {
                //判断当前目录下的dll是否正确？
                //获取dll版本信息
                //MessageBox.Show("sAlvCanCommsDllPath: " + sAlvCanCommsDllPath);
                FileVersionInfo fviDll = FileVersionInfo.GetVersionInfo(sAlvCanCommsDllPath);
                //Console.WriteLine(fviDll.FileVersion + "." + fviDll.FileBuildPart + "." + fviDll.FilePrivatePart);

                //string sDllVersionCurrent = (fviDll.FileVersion + "." + fviDll.FileBuildPart + "." + fviDll.FilePrivatePart).Replace('.', '_');
                string sDllVersionCurrent = (fviDll.FileMajorPart + "." + fviDll.FileMinorPart + "." + fviDll.FileBuildPart + "." + fviDll.FilePrivatePart).Replace(".", "_");

                //Console.WriteLine("当前dll" + "," + sDllVersionCurrent);

                if (sDllExpected.StartsWith("DLL_"))
                {
                    sDllExpected = sDllExpected.Substring("DLL_".Length); //0_0_71_2
                }

                if (sDllExpected != sDllVersionCurrent)
                {
                    //Console.WriteLine("需要切换dll");
                    dllSwitchTemp = true;
                }
                else
                {
                    //Console.WriteLine("不需要切换dll");
                    dllSwitchTemp = false;
                }

                //dllSwitchPro = "Veh: " + name + "\n\n" + "Des: " + recipeDescription + "\n\n" + "Expected dll: " + sDllExpected + "\n\n" + "Current dll: " + sDllVersionCurrent;

                dllSwitchPro = "Veh号: " + name + "\n\n" + "描述: " + recipeDescription + "\n\n" + "期望dll: " + sDllExpected + "\n\n" + "当前dll: " + sDllVersionCurrent + "\n\n" + "dll匹配结果：" + (dllSwitchTemp ? "dll匹配错误" : "dll匹配正确") + "\n";


                //Console.WriteLine(dllSwitchPro);

                sWriteLog = DateTime.Now + "\n\n" + dllSwitchPro + "\n\n" + dllSwitchTemp + (dllSwitchTemp ? "[need switch dll]" : "[no need to switch dll]") + "\n\n" + sSeparator;
            }


            //写Log
            try
            {
                
                //创建不存在的Log文件夹
                if (!Directory.Exists(sDllSwitchLogPathRoot))
                {
                    Directory.CreateDirectory(sDllSwitchLogPathRoot);
                }

                //创建不存在的Log文件夹
                if (!Directory.Exists(sDllSwitchLogPath))
                {
                    Directory.CreateDirectory(sDllSwitchLogPath);
                }

                //创建写入的.txt文件
                StreamWriter sw = File.AppendText(Path.Combine(sDllSwitchLogPath, sDate + ".txt"));
                sw.WriteLine(sWriteLog);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            dllSwitch = dllSwitchTemp; //dll是否需要切换

            if (dllSwitch)
            {
                dllSwitchPro += "\n\n" + "请联系线长 / 技术员切换正确的dll";
                //MsgBoxHelper.MsgBoxError(dllSwitchPro);
                MessageBox.Show(dllSwitchPro, "dll错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }

            return true;
        }
    }
}
