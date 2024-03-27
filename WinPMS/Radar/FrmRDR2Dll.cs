using PMS.COMMON.Helper;
using PMS.MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinPMS.FModels;


namespace WinPMS.Radar
{
    public partial class FrmRDR2Dll : Form
    {
        public FrmRDR2Dll()
        {
            InitializeComponent();
        }

        private FrmProgressBarModel _frmProgressBarModel = null;
        private FrmRadarBypassSetting _frmRadarBypassSetting = null;

        private string _sIniPathPMSUsed = "";
        private string _sBypassConfigFile = "";//定义Bypass的配置文件
        private string _sBypassLineRead = "";//定义读取到的Bypass行，默认为：SWL_Bypass = N; EOL_Bypass = N; LBL_Bypass = N

        private int _iPMSOpenTestStepsCVI = 0;
        private int _iBypassTimeerTick = 0;

        #region 事件
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRDR2SelDll_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                //禁用删除按钮
                tsbtnDelete.Enabled = false;

                //获取Bypass的配置文件
                _sBypassConfigFile = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "Radar_Bypass_Config_File_Path", "NULL", FileHelper.sIniFilePathCFM);

                //获取当前窗体的Tag值
                if (null != this.Tag)
                {
                    _frmProgressBarModel = this.Tag as FrmProgressBarModel;
                    InitInfo();
                    LoadAlvCanCommsDll();
                    CheckRadarSelBypass();
                }
            };
            act.TryCatchInvoke("Loading Form error!\n\n页面加载异常！");
        }


        /// <summary>
        /// Load DLL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadDll_Click(object sender, EventArgs e)
        {
            LoadAlvCanCommsDll();

            if (dgvDll.RowCount == 0)
            {
                MsgBoxHelper.MsgBoxShow("No Data!\nPlease conform the .ini file and then Reflash!\n\n请确认.ini配置文件是否正确，然后刷新并重新加载dll！", "Info");
            }
        }

        /// <summary>
        /// 切换DLL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwitchDll_Click(object sender, EventArgs e)
        {
            bool bAdminAuthorityFlag = true;

            if (null == dgvDll.DataSource || dgvDll.RowCount == 0)
            {
                MessageBox.Show("No Data！\nPlease Load dll first!\n\n请先加载Dll信息！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //将RebuildTestStepsCVI的标志设为0
            IniHelper.WriteIni(FileHelper.INI_SECTION_PMS, "PMS_RebuildTestStepsCVI", " " + "0", FileHelper.sIniFilePathPMS);
            //读RebuildTestStepsCVI的标志
            string sRebuildTestStepsCVIFlag = IniHelper.ReadIni(FileHelper.INI_SECTION_PMS, "PMS_RebuildTestStepsCVI", "NULL", FileHelper.sIniFilePathPMS);
            //判断RebuildTestStepsCVI的标志是否为0
            if (!sRebuildTestStepsCVIFlag.Equals("0"))
            {
                MsgBoxHelper.MsgBoxShowOnTop("PMS_RebuildTestStepsCVI is not 0.", "Info");
            }

            DataGridViewRow row = dgvDll.SelectedRows[0];//获取选中的行
            RDR2AlvCanCommsDll alvCanCommsDllInfo = row.DataBoundItem as RDR2AlvCanCommsDll;//将当前行绑定的数据转换为实体类

            if (alvCanCommsDllInfo.FolderPath.ToUpper().Substring(alvCanCommsDllInfo.FolderPath.ToUpper().LastIndexOf(@"\") + 1) == _frmProgressBarModel.RdrAlvCanComms.FolderNamePrefix.ToUpper())
            {
                MessageBox.Show("Current dll is Active, can't switch! \n\n当前dll为激活状态，不能切换！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (alvCanCommsDllInfo.DllExist != "Yes")
            {
                string sDrive = alvCanCommsDllInfo.FolderPath.Substring(0, alvCanCommsDllInfo.FolderPath.IndexOf("\\"));
                string sPath = alvCanCommsDllInfo.FolderPath.Substring(alvCanCommsDllInfo.FolderPath.IndexOf("\\") + 1);
                MsgBoxHelper.MsgBoxError(sDrive + "\\" + "\n" + sPath + "\n" + "dll不存在，不能切换!");
                return;
            }

            if (alvCanCommsDllInfo.DllUsePro == "NULL")
            {
                FrmAdminAuthority f = new FrmAdminAuthority();

                f.FuncFormLabel = new Func<string>(() =>
                {
                    return "dll适用项目为NULL，请输入管理员账号继续操作!";
                });

                f.FuncMsgShowAccountEmpty = new Func<string>(() =>
                {
                    return "账号不能为空!";
                });

                f.FuncMsgShowAccountNotValid = new Func<string>(() =>
                {
                    return "账号无效，切换失败!";
                });

                f.ActAccountValid += new Action(() =>
                {

                });

                f.ActAccountNotValid += new Action(() =>
                {
                    bAdminAuthorityFlag = false;
                    return;
                });

                f.ActFormClosing += new Action(() =>
                {
                    bAdminAuthorityFlag = false;
                    return;
                });

                f.ShowDialog();
            }

            if (bAdminAuthorityFlag)
            {
                if (DialogResult.Yes == MessageBox.Show("确定要切换dll吗？\n\nNote：切换dll前请先关闭相关文件夹&文件！", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        string sFolderPathNew = "";
                        string sFolderPathCurrent = "";
                        string sDllExist = "";
                        string sDllVersion = "";
                        string sDllUsePro = "";
                        for (int i = 0; i < dgvDll.Rows.Count; i++)
                        {
                            sFolderPathCurrent = dgvDll.Rows[i].Cells["FolderPath"].FormattedValue.ToString();
                            sDllExist = dgvDll.Rows[i].Cells["DllExist"].FormattedValue.ToString();
                            sDllVersion = dgvDll.Rows[i].Cells["DllVersion"].FormattedValue.ToString();
                            sDllUsePro = dgvDll.Rows[i].Cells["DllUsePro"].FormattedValue.ToString();

                            if (sFolderPathCurrent == alvCanCommsDllInfo.FolderPath)
                            {
                                //sFolderPathNew = folderPath.Substring(0, folderPath.Length - (dllVersion.Length + 1));

                                //sFolderPathNew = sFolderPathCurrent.Substring(0, sFolderPathCurrent.LastIndexOf(_frmProgressBarModel.RdrAlvCanComms.FolderNamePrefix) + _frmProgressBarModel.RdrAlvCanComms.FolderNamePrefix.Length);

                                //sFolderPathNew = sFolderPathCurrent.Substring(0, sFolderPathCurrent.LastIndexOf("\\") + _frmProgressBarModel.RdrAlvCanComms.FolderNamePrefix.Length + 1);

                                sFolderPathNew = sFolderPathCurrent.Substring(0, sFolderPathCurrent.LastIndexOf("\\")) + "\\" + _frmProgressBarModel.RdrAlvCanComms.FolderNamePrefix;

                                Directory.Move(sFolderPathCurrent, sFolderPathNew);
                            }
                            else
                            {
                                if (sDllExist.Equals("Yes"))
                                {
                                    //sFolderPathNew = sFolderPathCurrent.Substring(0, sFolderPathCurrent.LastIndexOf("\\") + _frmProgressBarModel.RdrAlvCanComms.FolderNamePrefix.Length + 1) + "_" + sDllVersion;

                                    sFolderPathNew = sFolderPathCurrent.Substring(0, sFolderPathCurrent.LastIndexOf("\\")) + "\\" + _frmProgressBarModel.RdrAlvCanComms.FolderNamePrefix + "_" + sDllVersion;

                                    if (sFolderPathCurrent.ToUpper() != sFolderPathNew.ToUpper())
                                    {
                                        Directory.Move(sFolderPathCurrent, sFolderPathNew);
                                    }
                                }
                            }
                        }

                        LoadAlvCanCommsDll();

                        //MessageBox.Show(alvCanCommsDllInfo.DllVersion);

                        bool dllActive = false;
                        for (int i = 0; i < dgvDll.Rows.Count; i++)
                        {
                            string folder = dgvDll.Rows[i].Cells["FolderPath"].FormattedValue.ToString();
                            string dllVersion = dgvDll.Rows[i].Cells["DllVersion"].FormattedValue.ToString();

                            if (folder.Substring(folder.LastIndexOf("\\")).ToUpper().EndsWith(_frmProgressBarModel.RdrAlvCanComms.FolderNamePrefix.ToUpper()) && dllVersion == alvCanCommsDllInfo.DllVersion)
                            {
                                dllActive = true;
                            }
                        }

                        if (dllActive)
                        {
                            //MessageBox.Show("dll切换成功！\n\n请打开TestSteps CVI并编译！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MessageBox.Show("dll切换成功！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if ("NULL" == alvCanCommsDllInfo.DllUsePro)
                            {
                                MsgBoxHelper.MsgBoxError("当前dll无适用项目，请注意！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("dll切换失败！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.StartsWith("Access to the path"))
                        {
                            MessageBox.Show("dll切换失败！\n\n" + ex.Message + "\n\n目录中有文件在打开，请关闭后重试！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            throw ex;
                        }
                    }

                    //btnSwitchDll.Enabled = false;
                }
            }

        }


        /// <summary>
        /// 打开CVI工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenTestStepsCVI_Click(object sender, EventArgs e)
        {
            btnSwitchDll.Enabled = true;

            //将RebuildTestStepsCVI的标志设为1，表示已经重新编译过了
            IniHelper.WriteIni(FileHelper.INI_SECTION_PMS, "PMS_RebuildTestStepsCVI", " " + "1", FileHelper.sIniFilePathPMS);
            //读RebuildTestStepsCVI的标志
            string sRebuildTestStepsCVIFlag = IniHelper.ReadIni(FileHelper.INI_SECTION_PMS, "PMS_RebuildTestStepsCVI", "NULL", FileHelper.sIniFilePathPMS);
            //判断RebuildTestStepsCVI的标志是否为1
            if (!sRebuildTestStepsCVIFlag.Equals("1"))
            {
                MsgBoxHelper.MsgBoxShowOnTop("PMS_RebuildTestStepsCVI is not 1.", "Info");
            }

            try
            {
                if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Open\n" + txtTestStepsCVI.Text + " ？", "Info", 2))
                {
                    Process.Start(txtTestStepsCVI.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());

                switch (ex.Message)
                {
                    case "The system cannot find the drive specified":
                    case "The system cannot find the file specified":
                        MsgBoxHelper.MsgBoxError("指定的路径不存在！\n\n1. 请确认配置文件是否正确！\n2. 修改配置文件并刷新！");
                        break;
                    default:
                        break;
                }
            }

        }

        /// <summary>
        /// 显示DLL的编译日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_ShowDllBuildDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ShowDllBuildDate.Checked)
            {
                dgvDll.Columns["DllBuildDate"].Visible = true;
                //dgvDll.Columns["DllOpen"].Visible = true;
            }
            else
            {
                dgvDll.Columns["DllBuildDate"].Visible = false;
                //dgvDll.Columns["DllOpen"].Visible = false;
            }
        }


        /// <summary>
        /// 设置Bypass
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBypassSet_Click(object sender, EventArgs e)
        {
            MessageBox.Show("设置Bypass之前请先关闭所有测试程序！");

            _frmRadarBypassSetting = new FrmRadarBypassSetting();
            _frmRadarBypassSetting.Show();
        }


        /// <summary>
        /// 定时更新dll激活状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dgvDll.DataSource != null && dgvDll.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvDll.Rows)
                {
                    string sFolderPath = row.Cells["FolderPath"].FormattedValue.ToString();
                    sFolderPath = sFolderPath.Substring(sFolderPath.LastIndexOf("\\") + 1);

                    if (sFolderPath.ToUpper() == _frmProgressBarModel.RdrAlvCanComms.FolderNamePrefix.ToUpper())
                    {
                        row.Cells["DllActive"].Value = "true";
                    }
                }

                if ((string)dgvDll.Rows[0].Cells["DllActive"].Value == "true" && (string)dgvDll.Rows[0].Cells["DllUsePro"].Value == "NULL")
                {
                    btnSwitchDll.BackColor = Color.Red;
                }
                else
                {
                    btnSwitchDll.BackColor = default;
                }
            }
        }


        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            InitInfo();
        }


        /// <summary>
        /// 打开PMS Log目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnLogDir_Click(object sender, EventArgs e)
        {
            string sDrive = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_ALV_CAN_COMMS_DLL, "DLL_SWITCH_LOG", "NULL", _sIniPathPMSUsed);

            try
            {
                if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Open\n" + sDrive + " ？", "Info", 2))
                {
                    Process.Start(sDrive);
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                MsgBoxHelper.MsgBoxError(ex.Message);
            }
        }


        /// <summary>
        /// 打开PMS Log文件
        /// 默认打开的是当前日期的文件，如果当前Log文件没有则提示用户文件不存在
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnLogFile_Click(object sender, EventArgs e)
        {
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = string.Format("{0:D2}", DateTime.Now.Month);
            string sDay = string.Format("{0:D2}", DateTime.Now.Day);
            string sDate = sYear + "_" + sMonth + "_" + sDay;

            string sDrive = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_ALV_CAN_COMMS_DLL, "DLL_SWITCH_LOG", "NULL", _sIniPathPMSUsed);
            string sPath = sDrive + Path.DirectorySeparatorChar + sYear + Path.DirectorySeparatorChar + sMonth + Path.DirectorySeparatorChar + sDate + ".txt";

            try
            {
                if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Open\n" + sPath + " ？", "Info", 2))
                {
                    Process.Start(sPath);
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                MsgBoxHelper.MsgBoxError(ex.Message);
            }
        }


        private void dgvDll_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            string sButtonText = dgvDll.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();

            if (sButtonText == "Open")
            {
                MsgBoxHelper.MsgBoxShow("Not support", "NA");

                //DataGridViewRow row = dgvDll.SelectedRows[0];//获取选中的行
                //RDR2AlvCanCommsDll alvCanCommsDllInfo = row.DataBoundItem as RDR2AlvCanCommsDll;//将当前行绑定的数据转换为实体类

                ////string sDrive = alvCanCommsDllInfo.FolderPath.Substring(0, alvCanCommsDllInfo.FolderPath.IndexOf("\\"));
                //string sDrive = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "ALV_CAN_COMMS_FolderPath", "NULL", _sIniPathPMSUsed);

                //string sPath = alvCanCommsDllInfo.FolderPath.Substring(alvCanCommsDllInfo.FolderPath.LastIndexOf("\\") + 1);
                //if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Open\n" + sDrive + "\\" + sPath + " ？", "Info", 2))
                //{
                //    Process.Start(alvCanCommsDllInfo.FolderPath);
                //}
            }
        }


        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Close" + " ？", "Info", 2))
            {
                this.CloseForm();
            }
        }


        /// <summary>
        /// 帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnHelp_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("1. 加载Dll信息\n\n2. 切换对应的dll版本，提示切换成功/失败！（此时禁用切换dll按钮）\n\n3. 打开TestSteps CVI并重新编译！（此时会重新启用切换dll按钮）", "帮助", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MessageBox.Show("1. Load dll\n\n2. Switch dll", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion




        #region 方法
        /// <summary>
        /// 初始化信息
        /// 从窗体Tag值获取参数
        /// </summary>
        private void InitInfo()
        {
            _frmProgressBarModel.LoadAction?.Invoke();

            txtAlvCanCommsFolderPath.Text = _frmProgressBarModel.RdrAlvCanComms.FolderPath;
            txtAlvCanCommsFolderNamePrefix.Text = _frmProgressBarModel.RdrAlvCanComms.FolderNamePrefix;
            txtAlvCanCommsDllFileName.Text = _frmProgressBarModel.RdrAlvCanComms.DllFileName;

            switch (FileHelper.sIniPMSUsage)
            {
                case "Debug":
                    //txtTestStepsCVI.Text = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "TestSteps_CVI", "NULL", FileHelper.sIniFilePathDebug);
                    _sIniPathPMSUsed = FileHelper.sIniFilePathDebug;
                    break;
                case "CFM":
                    //txtTestStepsCVI.Text = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "TestSteps_CVI", "NULL", FileHelper.sIniFilePathCFM);
                    _sIniPathPMSUsed = FileHelper.sIniFilePathCFM;
                    break;
                default:
                    break;
            }

            txtTestStepsCVI.Text = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "TestSteps_CVI", "NULL", _sIniPathPMSUsed);

            //根据PMS.ini中的配置，是否显示"Open TestSteps CVI"按钮
            _iPMSOpenTestStepsCVI = int.Parse(FileHelper.sIniPMSOpenTestStepsCVI);
            if (_iPMSOpenTestStepsCVI == 1)
            {
                btnOpenTestStepsCVI.Visible = true;
            }
            else
            {
                btnOpenTestStepsCVI.Visible = false;
            }
        }


        /// <summary>
        /// 加载ALV_CAN_COMMS目录及其目录下的dll信息
        /// </summary>
        private void LoadAlvCanCommsDll()
        {
            List<RDR2AlvCanCommsDll> alvCanCommsDllList = new List<RDR2AlvCanCommsDll>();

            string subDirName;
            string sDllVersion;
            string sDllUseProFromIni;

            textBox1.Text = "";
            chk_ShowDllBuildDate.Checked = true;

            try
            {
                //获取指定磁盘下所有目录的路径
                //string[] subDirsPath = Directory.GetDirectories(@"C:\");
                string[] subDirsPath = Directory.GetDirectories(PathHelper.GetUNCPath(@_frmProgressBarModel.RdrAlvCanComms.FolderPath));

                //将ALV_CAN_COMMS固定的文件夹名称转为List
                List<string> AlvCanFolderNamePrefixFixedList = new List<string>(_frmProgressBarModel.RdrAlvCanComms.DllFolderNamePrefixFixed.ToUpper().Split(','));

                //将ALV_CAN_COMMS固定的文件夹下的.dll名称转为List
                List<string> AlvCanDllFileNameFixedList = new List<string>(_frmProgressBarModel.RdrAlvCanComms.DllFileNameFixed.Split(','));


                //循环遍历所有目录的路径，找出以ALV_CAN_COMMS开头的目录的路径
                //判断ALV_CAN_COMMS目录下是否存在ALV_CAN_Comms.dll
                //获取ALV_CAN_Comms.dll的版本信息
                //加载到List
                //绑定List到DataGridView
                string subDirPath;
                bool bDllFixedFlag = false;
                bool bDllFixedInfoError = false;//标志DllFixed信息是否完整
                for (int i = 0; i < subDirsPath.Length; i++)
                {
                    //截取并获取目录的名称，eg: C:\ALV_CAN_Comms，即ALV_CAN_Comms
                    subDirPath = subDirsPath[i];
                    subDirName = subDirPath.Substring(subDirPath.LastIndexOf(@"\") + 1);
                    sDllVersion = "";
                    sDllUseProFromIni = "";

                    bDllFixedFlag = false;
                    for (int j = 0; j < AlvCanFolderNamePrefixFixedList.Count; j++)
                    {
                        if (AlvCanFolderNamePrefixFixedList[j].Trim().Equals(subDirName.ToUpper()))
                        {
                            //实例化AlvCanComms类
                            RDR2AlvCanCommsDll alvCanCommsDll = new RDR2AlvCanCommsDll();

                            alvCanCommsDll.FolderPath = subDirPath;

                            //查询该目录下是否存在ALV_CAN dll
                            if (File.Exists(subDirPath + @"\" + AlvCanDllFileNameFixedList[j].Trim()) == true)
                            {
                                //获取dll版本信息
                                FileVersionInfo fviDll = FileVersionInfo.GetVersionInfo(subDirPath + @"\" + AlvCanDllFileNameFixedList[j].Trim());
                                alvCanCommsDll.DllExist = "Yes";
                                alvCanCommsDll.DllName = AlvCanDllFileNameFixedList[j].Trim();
                                alvCanCommsDll.DllVersion = fviDll.FileMajorPart + "." + fviDll.FileMinorPart + "." + fviDll.FileBuildPart + "." + fviDll.FilePrivatePart;
                                alvCanCommsDll.DllBuildDate = fviDll.Comments;
                            }
                            else//该目录下不存在ALV_CAN dll
                            {
                                alvCanCommsDll.DllExist = "No";
                                alvCanCommsDll.DllName = "-";
                                alvCanCommsDll.DllVersion = "-";
                                alvCanCommsDll.DllBuildDate = "-";
                                alvCanCommsDll.DllUsePro = "-";
                            }

                            //转换dll文件的版本信息为x_x_x_x
                            sDllVersion = alvCanCommsDll.DllVersion.Replace(".", "_");
                            sDllUseProFromIni = "";

                            //从ini配置文件中获取dll适用项目的信息
                            switch (FileHelper.sIniPMSUsage)
                            {
                                case "Debug":
                                    sDllUseProFromIni = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, sDllVersion.Equals("-") ? "DLL_" + sDllVersion : "DLL_" + "X_X_" + sDllVersion.Substring(4), "NULL", FileHelper.sIniFilePathDebug);
                                    break;
                                case "CFM":
                                    sDllUseProFromIni = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, sDllVersion.Equals("-") ? "DLL_" + sDllVersion : "DLL_" + "X_X_" + sDllVersion.Substring(4), "NULL", FileHelper.sIniFilePathCFM);
                                    break;
                                default:
                                    break;
                            }

                            alvCanCommsDll.DllUsePro = sDllUseProFromIni;

                            textBox1.AppendText(alvCanCommsDll.FolderPath + " >>> " + alvCanCommsDll.DllName + " >>> " + alvCanCommsDll.DllVersion + " >>> " + alvCanCommsDll.DllBuildDate + " >>> " + alvCanCommsDll.DllUsePro + Environment.NewLine);
                            //textBox1.AppendText(alvCanCommsDll.FolderPath + UtilityHelper.PaddingAsStrByLen(alvCanCommsDll.FolderPath, 50, " ", false) + " >>> " + alvCanCommsDll.DllName + " >>> " + alvCanCommsDll.DllVersion + " >>> " + alvCanCommsDll.DllBuildDate + " >>> " + alvCanCommsDll.DllUsePro + Environment.NewLine);
                            textBox1.AppendText("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);

                            //string s = alvCanCommsDll.FolderPath + UtilityHelper.PaddingAsStrByLen(alvCanCommsDll.FolderPath, 50, "-", false) + " >>> " + alvCanCommsDll.DllName + " >>> " + alvCanCommsDll.DllVersion + " >>> " + alvCanCommsDll.DllBuildDate + " >>> " + alvCanCommsDll.DllUsePro;
                            //listBox1.Items.Add(s);

                            if
                            (
                                ("NULL" == alvCanCommsDll.FolderPath || "" == alvCanCommsDll.FolderPath) ||
                                ("NULL" == alvCanCommsDll.DllName || "" == alvCanCommsDll.DllName) ||
                                ("NULL" == alvCanCommsDll.DllVersion || "" == alvCanCommsDll.DllVersion) ||
                                ("NULL" == alvCanCommsDll.DllUsePro || "" == alvCanCommsDll.DllUsePro)
                            )
                            {
                                bDllFixedInfoError = true;
                            }

                            bDllFixedFlag = true;
                        }
                    }

                    if (bDllFixedInfoError)
                    {
                        textBox1.BackColor = Color.Red;
                    }
                    else
                    {
                        textBox1.BackColor = Color.LightGreen;
                        //listBox1.BackColor = Color.LightGreen;
                    }

                    if (!bDllFixedFlag)
                    {
                        //判断该目录是否是以ALV_CAN_COMMS开头的目录
                        if (subDirName.ToUpper().StartsWith(@_frmProgressBarModel.RdrAlvCanComms.FolderNamePrefix.ToUpper()))
                        {
                            //实例化AlvCanComms类
                            RDR2AlvCanCommsDll alvCanCommsDll = new RDR2AlvCanCommsDll();

                            alvCanCommsDll.FolderPath = subDirPath;

                            //查询该目录下是否存在ALV_CAN_Comms.dll
                            if (File.Exists(subDirPath + @"\" + @_frmProgressBarModel.RdrAlvCanComms.DllFileName) == true)
                            {
                                //获取dll版本信息
                                FileVersionInfo fviDll = FileVersionInfo.GetVersionInfo(subDirPath + @"\" + _frmProgressBarModel.RdrAlvCanComms.DllFileName);
                                //Console.WriteLine(fviDll.FileVersion + "." + fviDll.FileBuildPart + "." + fviDll.FilePrivatePart);

                                alvCanCommsDll.DllExist = "Yes";
                                alvCanCommsDll.DllName = _frmProgressBarModel.RdrAlvCanComms.DllFileName;
                                //lvCanCommsDll.DllVersion = fviDll.FileVersion + "." + fviDll.FileBuildPart + "." + fviDll.FilePrivatePart;
                                alvCanCommsDll.DllVersion = fviDll.FileMajorPart + "." + fviDll.FileMinorPart + "." + fviDll.FileBuildPart + "." + fviDll.FilePrivatePart;
                                alvCanCommsDll.DllBuildDate = fviDll.Comments;
                            }
                            else//该目录下不存在ALV_CAN_Comms.dll
                            {
                                alvCanCommsDll.DllExist = "No";
                                alvCanCommsDll.DllName = "-";
                                alvCanCommsDll.DllVersion = "-";
                                alvCanCommsDll.DllBuildDate = "-";
                                alvCanCommsDll.DllUsePro = "-";
                            }

                            //转换dll文件的版本信息为x_x_x_x
                            sDllVersion = alvCanCommsDll.DllVersion.Replace(".", "_");
                            sDllUseProFromIni = "";

                            //从ini配置文件中获取dll适用项目的信息
                            switch (FileHelper.sIniPMSUsage)
                            {
                                case "Debug":
                                    sDllUseProFromIni = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, sDllVersion.Equals("-") ? "DLL_" + sDllVersion : "DLL_" + "X_X_" + sDllVersion.Substring(4), "NULL", FileHelper.sIniFilePathDebug);
                                    break;
                                case "CFM":
                                    sDllUseProFromIni = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, sDllVersion.Equals("-") ? "DLL_" + sDllVersion : "DLL_" + "X_X_" + sDllVersion.Substring(4), "NULL", FileHelper.sIniFilePathCFM);
                                    break;
                                default:
                                    break;
                            }

                            alvCanCommsDll.DllUsePro = sDllUseProFromIni;

                            alvCanCommsDllList.Add(alvCanCommsDll);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                //throw ex;
                MsgBoxHelper.MsgBoxError(_frmProgressBarModel.RdrAlvCanComms.FolderPath + "\n" + ex.Message);
            }

            //dgvDll.Columns["DllBuildDate"].Visible = false;
            dgvDll.DataSource = alvCanCommsDllList;
        }


        private void CheckRadarSelBypass()
        {
            try
            {
                StreamReader sr = new StreamReader(_sBypassConfigFile);
                //读取Bypass配置文件的第一行
                _sBypassLineRead = sr.ReadLine();//SWL_Bypass = N; EOL_Bypass = N; LBL_Bypass = N
                //while (!sr.EndOfStream)
                //{
                //    _sBypassLine = sr.ReadLine();
                //}

                sr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void timerIsBypass_Tick(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(_sBypassConfigFile);
                //读取Bypass配置文件的第一行
                _sBypassLineRead = sr.ReadLine();//SWL_Bypass = N; EOL_Bypass = N; LBL_Bypass = N
                //while (!sr.EndOfStream)
                //{
                //    _sBypassLine = sr.ReadLine();
                //}

                sr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //if ((null != _frmRadarBypassSetting && _frmRadarBypassSetting.IsBypass) || _sBypassLineRead != FileHelper.RADAR_SEL_BYPASS_SETTING_DEFAULT) 
            if (_sBypassLineRead != FileHelper.RADAR_SEL_BYPASS_SETTING_DEFAULT)
            {
                _iBypassTimeerTick++;
                if (_iBypassTimeerTick % 2 == 0)
                {
                    btnBypassSet.BackColor = Color.Red;
                }
                else
                {
                    btnBypassSet.BackColor = default;
                }
            }
            else
            {
                btnBypassSet.BackColor = default;
            }
        }
        #endregion



    }
}
