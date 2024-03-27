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
    public partial class FrmRDR2DllConfig : Form
    {
        public FrmRDR2DllConfig()
        {
            InitializeComponent();
        }

        private FrmProgressBarModel _frmProgressBarModel = null;
        private string _sIniPathPMSUsed = "";


        #region 事件
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRDR2DllConfig_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                //禁用删除按钮
                tsbtnDelete.Enabled = false;

                //获取当前窗体的Tag值
                if (null != this.Tag)
                {
                    _frmProgressBarModel = this.Tag as FrmProgressBarModel;
                    InitInfo();
                    LoadAlvCanCommsDll();
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



        #endregion

        private void btnTest1_Click(object sender, EventArgs e)
        {



        }

        private void dgvDll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sDllSwitchPro = "G1.2 GM, G1.2 AAA#G1.2 BBB#G1.2 CCC, G1.2 Geea2.0#G1.3 Geea2.0#{CR-FCR-RCR}, G1.2 Geea2.0#G1.3 Geea2.0#{FLR}, G1.2 GAC#{FLR}, G1.3 GWM ES13 RCR, G1.3 GWM EC24 RCR, G1.2 Chery#G1.2 BTET#G1.3 BTET#{FLR-CR-FCR-RCR}, G1.2 VCC#{FLR}, G1.3 Nissan";
            List<string> lstDllSwitchPro = new List<string>();
            lstDllSwitchPro.AddRange(sDllSwitchPro.Split(','));


            string sDllSwitchSpecial = "ALV_CAN_Comms - gm#DLL_X_X_71_2, DLL_X_X_71_2, DLL_X_X_71_17, DLL_X_X_80_5, DLL_X_X_71_20, DLL_X_X_71_29, DLL_X_X_80_3, DLL_X_X_77_11, DLL_X_X_67_0, ALV_CAN_Comms - fft ghost v4#123#DLL_X_X_68_0";
            List<string> lstDllSwitchSpecial = new List<string>();
            lstDllSwitchSpecial.AddRange(sDllSwitchSpecial.Split(','));

            DataGridViewRow row = dgvDll.SelectedRows[0];//获取选中的行
            RDR2AlvCanCommsDll alvCanCommsDllInfo = row.DataBoundItem as RDR2AlvCanCommsDll;//将当前行绑定的数据转换为实体类

            //获取dll的版本，将dll版本转换为DLL_X_X_X_X的格式
            string sDllVersion = alvCanCommsDllInfo.DllVersion;
            string sDllVersionTemp1 = sDllVersion.Substring(sDllVersion.IndexOf('.') + 1);
            string sDllVersionTemp2 = sDllVersionTemp1.Substring(sDllVersion.IndexOf('.') + 1);
            string sDllVersionTemp3 = "DLL_" + "X_X_" + sDllVersionTemp2.Replace(".", "_");


            string sDllSwitchSpecialSubstr;
            int iDllSwitchSpecialMatch = 0;

            List<string> lstDllSwitchSpecialFind = new List<string>();//定义对应找到的dll
            List<string> lstDllSwitchProFind = new List<string>();//定义对应找到的项目

            //循环遍历表格中所有的dll，根据选中的dll和配置文件中的dll匹配，找到对应的dll和对应的项目
            for (int i = 0; i < lstDllSwitchSpecial.Count; i++)
            {
                sDllSwitchSpecialSubstr = lstDllSwitchSpecial[i];
                if (lstDllSwitchSpecial[i].Contains("#"))
                {
                    sDllSwitchSpecialSubstr = lstDllSwitchSpecial[i].Substring(lstDllSwitchSpecial[i].LastIndexOf("#") + 1);
                }

                sDllSwitchSpecialSubstr = sDllSwitchSpecialSubstr.Trim();
                if (sDllSwitchSpecialSubstr == sDllVersionTemp3)
                {
                    MessageBox.Show(lstDllSwitchSpecial[i] + ", " + lstDllSwitchPro[i]);
                    lstDllSwitchSpecialFind.Add(lstDllSwitchSpecial[i]);
                    lstDllSwitchProFind.Add(lstDllSwitchPro[i]);
                    iDllSwitchSpecialMatch++;
                }
            }


            List<AppliedDll> lstAppliedDll = new List<AppliedDll>();

            for (int i = 0; i < lstDllSwitchSpecialFind.Count; i++)
            {
                AppliedDll appliedDll = new AppliedDll();

                appliedDll.AppliedProject = lstDllSwitchProFind[i];
                appliedDll.AppliedFolder = lstDllSwitchSpecialFind[i];

                lstAppliedDll.Add(appliedDll);
            }

            dataGridView1.DataSource = lstAppliedDll;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            AppliedDll appliedDllSelected = row.DataBoundItem as AppliedDll;



        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }

    class AppliedDll
    {
        public string AppliedProject { get; set; }
        public string AppliedFolder { get; set; }
    }
}


