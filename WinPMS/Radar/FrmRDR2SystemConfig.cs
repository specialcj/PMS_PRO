using Microsoft.VisualBasic;
using PMS.COMMON.Helper;
using PMS.MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Text;
using System.Windows.Forms;
using WinPMS.FModels;

namespace WinPMS.Radar
{
    public partial class FrmRDR2SystemConfig : Form
    {
        public FrmRDR2SystemConfig()
        {
            InitializeComponent();
        }

        private string _sSystemConfigMaster = "C:\\Users\\jason.cai\\Desktop\\StationConfig-Az-CN01-MA-WD4121.txt";
        private string _sITACEnable = "TraceType";

        private static string TemplateVBSCommand = @"
command = ""COMMAND""
computer = "".""
Set wmi = GetObject(""winmgmts:{impersonationLevel=impersonate}!\\"" _
        & computer & ""\root\cimv2"")
Set startup = wmi.Get(""Win32_ProcessStartup"")
Set conf = startup.SpawnInstance_
conf.ShowWindow = 12
Set proc = GetObject(""winmgmts:root\cimv2:Win32_Process"")
proc.Create command, Null, conf, intProcessID
";

        #region 事件
        private void FrmRDR2SystemConfig_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                //禁用删除按钮
                tsbtnDelete.Enabled = false;

                //获取当前窗体的Tag值
                if (null != this.Tag)
                {
                    InitInfo();
                }
            };
            act.TryCatchInvoke("Radar2 SystemConfig页面加载异常");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string sTxtFilePath = "C:\\Users\\jason.cai\\Desktop\\StationConfig-Az-CN01-MA-WD4121.txt";
            string sLaserEnable = "LaserEtchEnable";
            string sLaserCheckEnable = "LsrEtchCheckEnable";

            try
            {
                List<string> lines = new List<string>(File.ReadAllLines(sTxtFilePath));
                string sLine = "";
                string sLineKey = "";
                string sLineValue = "";
                string sLineReplace = "";

                bool bModify = false;
                for (int i = 0; i < lines.Count; i++)
                {
                    sLine = lines[i];
                    sLineKey = sLine.Substring(0, sLine.IndexOf("="));
                    sLineValue = sLine.Substring(sLine.IndexOf("="));

                    if (sLineKey.Trim() == sLaserEnable && sLineValue.Replace("=", "").Trim() == "Y")
                    {
                        lines.RemoveAt(i);
                        sLineReplace = sLineKey + sLineValue.Replace("Y", "N");
                        lines.Insert(i, sLineReplace);
                        bModify = true;
                    }
                }

                if (bModify)
                {
                    File.WriteAllLines(sTxtFilePath, lines.ToArray());
                    MsgBoxHelper.MsgBoxShow("修改成功！", "提示");
                }
                else
                {
                    MsgBoxHelper.MsgBoxShow("没有改动，不需要修改！", "提示");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// RDR2 ITAC Enable / Disable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRDR2iTACEnable_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lines = new List<string>(File.ReadAllLines(_sSystemConfigMaster));
                string sLine = "";
                string sLineKey = "";
                string sLineValue = "";
                string sLineValueTemp1 = "";
                string sLineValueTemp2 = "";
                string sLineReplace = "";


                bool bModify = false;
                for (int i = 29; i < lines.Count; i++)
                {
                    sLine = lines[i];
                    if (string.IsNullOrEmpty(sLine))
                    {
                        continue;
                    }
                    sLineKey = sLine.Substring(0, sLine.IndexOf(":"));
                    sLineValue = sLine.Substring(sLine.IndexOf(":"));

                    if (sLineKey.Trim() == _sITACEnable && sLineValue.Substring(2, 1) == "1")
                    {
                        lines.RemoveAt(i);
                        sLineValueTemp1 = sLineValue.Substring(0, 3).Replace("1", "0");
                        sLineValueTemp2 = sLineValue.Substring(3);
                        sLineReplace = sLineKey + sLineValueTemp1 + sLineValueTemp2;
                        lines.Insert(i, sLineReplace);
                        bModify = true;
                    }

                    if (sLineKey.Trim() == _sITACEnable && sLineValue.Substring(2, 1) == "0")
                    {
                        lines.RemoveAt(i);
                        sLineReplace = sLineKey + sLineValue.Replace("0", "1");
                        lines.Insert(i, sLineReplace);
                        bModify = true;
                    }
                }

                if (bModify)
                {
                    File.WriteAllLines(_sSystemConfigMaster, lines.ToArray());
                    MsgBoxHelper.MsgBoxShow("修改成功！", "提示");
                    GetiTACEnableState();
                }
                else
                {
                    MsgBoxHelper.MsgBoxShow("没有改动，不需要修改！", "提示");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnConnPC1_Click(object sender, EventArgs e)
        {

            ConnectionOptions connOpt = new ConnectionOptions();
            //connOpt.Username = "xsd";//TE&ME Lab
            //connOpt.Username = "corp\\g-cn01.operator";//RDR2 SEL MASTER
            connOpt.Username = "corp\\shaloc.zhang";//RDR2 SEL MASTER
            //connOpt.Password = "CN01operator";//登入远端电脑的密码
            connOpt.Password = "Qwert7758521trewq";//登入远端电脑的密码

            ManagementPath managementPath = new ManagementPath();
            //managementPath.Path = @"\\10.124.20.7\root\cimv2";//TE&ME Lab   
            //managementPath.Path = @"\\10.124.92.134\root\cimv2";//RDR2 SEL MASTER
            managementPath.Path = @"\\10.124.50.173\root\cimv2";//RDR2 SEL MASTER

            ManagementClass managementClass = new ManagementClass(managementPath + ":Win32_Service");

            ManagementScope managementScope = new ManagementScope(managementPath, connOpt);
            managementClass.Scope = managementScope;

            try
            {
                managementScope.Connect();
                Console.WriteLine("Connect: " + managementScope.IsConnected);

                //ManagementObject managementObj = managementClass.CreateInstance();

                //这里的例子读取文件的最后修改日期
                ObjectQuery query = new ObjectQuery("SELECT * FROM CIM_DataFile WHERE Name = 'D:\\\\1.txt'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(managementScope, query);
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject oReturn in collection)
                {

                    oReturn.InvokeMethod("Copy", new object[] { oReturn["Name"], "D:\\1_COPY.txt" });
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw ex;
            }


            /*
            string command = "mstsc /v: " + "10.124.20.7" + " /console";
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c" + command;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            */
        }


        private void button2_Click(object sender, EventArgs e)
        {
            /*
            var scope = new ManagementScope();
            string r = ConnectToWMI(ref scope, computerName, username, password, "root\\cimv2");
            if (r.Length > 0)
            {
                throw new Exception(r);
            }

            try
            {
                ObjectQuery query;
                int pid = 0;
                if (Int32.TryParse(Process, out pid))
                {
                    query = new ObjectQuery(string.Format("select * from Win32_Process where ProcessId = {0}", pid));
                }
                else
                {
                    query = new ObjectQuery(string.Format("select * from Win32_Process where Name like '%{0}%'", process));
                }

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                foreach (ManagementObject proc in searcher.Get())
                {
                    object ret = proc.InvokeMethod("Terminate", null);
                    Console.WriteLine(string.Format("[+] Attempted to terminate remote process ({0}). Returned: {1}", process, ret));
                }

                Console.WriteLine(string.Format("[x] Process {0} not found", process));
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("[!] Could not retrieve remote processes to terminate! Exception: {0}", ex.ToString()));
            }

            ConnectionOptions options = new ConnectionOptions();
            //options.Username = "corp\\shaloc.zhang";
            options.Username = "corp\\pu";
            //options.Password = "Qwert7758521trewq";
            options.Password = "pu";
            //ManagementScope scope = new ManagementScope("\\\\" + "10.124.50.173" + "\\root\\cimv2", options);
            ManagementScope scope = new ManagementScope("\\\\" + "10.124.99.197" + "\\root\\cimv2", options);
            //用给定管理者用户名和口令连接远程的计算机 
            scope.Connect();


            //ObjectQuery oq = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ObjectQuery oq = new ObjectQuery("SELECT * FROM Win32_Process");
            ManagementObjectSearcher query1 = new ManagementObjectSearcher(scope, oq);
            //得到WMI控制 
            ManagementObjectCollection queryCollection1 = query1.Get();

            GetObject("winmgmts:root\cimv2:Win32_Process");

            foreach (ManagementObject mo in queryCollection1)
            {
                string[] ss = { "" };

                //重启远程计算机 
                //mo.InvokeMethod("Explorer", ss);
                mo.InvokeMethod("start \"\" \"C:\\Users\\pu\\Desktop\\1.txt\"", ss);

            }
            */
            
            /*
            var objWMIService = Interaction.GetObject("winmgmts:" + @"{impersonationLevel=impersonate}!\" + Environment.UserDomainName + @"\root\cimv2");
            var colProcess = objWMIService.ExecQuery("Select * from Win32_Process");
            string wmiQuery = string.Format("select CommandLine from Win32_Process where Name='{0}'", "explorer.exe");
            System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(wmiQuery);
            System.Management.ManagementObjectCollection retObjectCollection = searcher.Get;
            foreach (object retObject in colProcess)
            {
                if (retObject.CommandLine.ToString().Contains("--CMD="))
                    retObject.Terminate();
            }
            */
        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.CloseForm();
        }
        #endregion


        #region 方法
        /// <summary>
        /// 初始化信息
        /// </summary>
        private void InitInfo()
        {
            txtSystemConfigMaster.Text = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "SystemConfig_Master", "NULL", FileHelper.sIniFilePathPMS);

            _sSystemConfigMaster = txtSystemConfigMaster.Text;

            GetiTACEnableState();
        }

        private void GetiTACEnableState()
        {
            try
            {
                List<string> lines = new List<string>(File.ReadAllLines(_sSystemConfigMaster));
                string sLine = "";
                string sLineKey = "";
                string sLineValue = "";
                string sITACState = "";

                for (int i = 0; i < lines.Count; i++)
                {
                    sLine = lines[i];
                    sLineKey = sLine.Substring(0, sLine.IndexOf("="));
                    sLineValue = sLine.Substring(sLine.IndexOf("="));

                    if (sLineKey.Trim() == _sITACEnable)
                    {
                        sITACState = sLineValue.Replace("=", "").Trim();
                        switch (sITACState)
                        {
                            case "Y":
                                btnRDR2iTACEnableStateMaster.BackColor = Color.LightGreen;
                                break;
                            case "N":
                                btnRDR2iTACEnableStateMaster.BackColor = Color.Red;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void btnRDR2iTACEnableStateMaster_Click(object sender, EventArgs e)
        {

        }


    }
}
