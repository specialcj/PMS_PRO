using com.itac.easyworks.api.client.mii;
using com.itac.mes.imsapi.domain.container;
using PMS.ITAC;
using PMS.COMMON.Helper;
using ExApi;
using com.itac.easyworks.api.client.mii;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMS.MODELS.DModels;
using com.itac.easyworks.api.idl;
using System.Threading;
using System.IO;

namespace WinPMS.Tools
{
    public partial class FrmiTacCheck : Form
    {
        //private IMSApiSessionValidationStruct _imsApiSessionValidationStruct;
        //public InitItac initITac = new InitItac();

        private static ItacMII _itacMII;
        private static ApiSessionValidationStruct _apiSessionValidationStruct;
        public static int iTacSessionID = -1;
        //public static string staffNo = "";

        public StationSetupModel stationSetupModel = new StationSetupModel();

        public string[] sArrAttribut1;
        public List<string> lstFilesPLM = new List<string>();
        public List<string> lstFilesITacDiff = new List<string>();

        private string _sIniPathPMSUsed = "";
        private string _sRadar1STStation = "";
        private string _sRadar1SELStation = "";
        private string _sRadar2STStation = "";
        private string _sRadar2SELStation = "";
        private string _sRadar4STStation = "";
        private string _sRadar4SELStation = "";
        private string _sRadar5STStation = "";
        private string _sRadar5SELStation = "";


        Dictionary<string, string> _kvStation = new Dictionary<string, string>(); //站位信息，key -> 站位名称，value -> 站位号
        //Dictionary<string, string> _kvITacGetStationSetup = new Dictionary<string, string>(); //iTac站位配置信息

        public FrmiTacCheck()
        {
            InitializeComponent();
        }


        #region 事件
        private void FrmiTacCheck_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                InitAct(); //初始化操作
                LoadRadarLineStationFromIni(); //加载Radar站位信息
            };
            act.TryCatchInvoke("Loading Form error!\n\n页面加载异常！");
        }


        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            LoadRadarLineStationFromIni(); //加载Radar站位信息
        }


        #region 使用DataGridView的RowPostPaint事件在RowHeaderCell中绘制行号
        private void dgv_iTAC_StationSetup_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            dgv_iTAC_StationSetup.RowHeadersWidth - 4,
            e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dgv_iTAC_StationSetup.RowHeadersDefaultCellStyle.Font,
            rectangle,
            dgv_iTAC_StationSetup.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgv_PLM_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            dgv_iTAC_StationSetup.RowHeadersWidth - 4,
            e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dgv_iTAC_StationSetup.RowHeadersDefaultCellStyle.Font,
            rectangle,
            dgv_iTAC_StationSetup.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        #endregion


        private async void button1_Click(object sender, EventArgs e)
        {
            #region 合法性检查
            if (cbBox_RadarLineStation.SelectedIndex == -1)
            {
                MsgBoxHelper.MsgBoxError("Please select the station!");
                return;
            }
            #endregion


            button1.Enabled = false;

            //获取下拉框的站位名称
            string sStationName = cbBox_RadarLineStation.GetItemText(cbBox_RadarLineStation.SelectedItem);
            _kvStation.TryGetValue(sStationName, out string sStationNumber);

            #region 初始化iTac，获取getStationSetup
            //apiInit apiInit;
            //apiLogin apiLogin;
            //apiLogout apiLogout;
            //getStationSetup getStationSetup;

            await Task.Run(() =>
            {
                try
                {
                    //_imsApiSessionValidationStruct = new IMSApiSessionValidationStruct();
                    //_imsApiSessionValidationStruct.stationNumber = sStationNumber;
                    //_imsApiSessionValidationStruct.stationPassword = "";
                    //_imsApiSessionValidationStruct.user = "";
                    //_imsApiSessionValidationStruct.password = "";
                    //_imsApiSessionValidationStruct.client = "";
                    //_imsApiSessionValidationStruct.registrationType = "";
                    //_imsApiSessionValidationStruct.systemIdentifier = "";
                    //initITac.sessionValidationStruct = _imsApiSessionValidationStruct;

                    //int rtn = initITac.Login();
                    //if (rtn != 0)
                    //{
                    //    string errorMsg = initITac.errorString(rtn);
                    //    //MessageBox.Show("ITAC Initial Fail!\nITAC初始化失败!\n" + errorMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    //Environment.Exit(0);
                    //}

                    /*
                    apiInit = new apiInit();
                    apiInit.run();
                    if (apiInit.Initialized != true)
                    {
                        MessageBox.Show("iTac not initialized! Error String: " + apiInit.ErrorString);
                        //Application.Exit();
                        return;
                    }

                    apiLogin = new apiLogin(sStationNumber, sStationNumber, sStationNumber, false, true, sStationNumber);
                    apiLogin.run();
                    if (apiLogin.SessionId == -1)
                    {
                        MessageBox.Show("Login stationNr: " + sStationNumber + " failed");
                        //Application.Exit();
                        return;
                    }
                    sessionId = apiLogin.SessionId;

                    getStationSetup = new getStationSetup(sessionId, sStationNumber);
                    getStationSetup.run();
                    if (getStationSetup.SessionId == -1)
                    {
                        MessageBox.Show("getStationSetup: " + sStationNumber + " failed");
                        //Application.Exit();
                        return;
                    }
                    */

                    /*
                    _kvITacGetStationSetup.Add("Attribut1", getStationSetup.Attribut1);
                    _kvITacGetStationSetup.Add("BomIndex", getStationSetup.BomIndex);
                    _kvITacGetStationSetup.Add("BomVersion", getStationSetup.BomVersion.ToString());
                    _kvITacGetStationSetup.Add("CadPartNr", getStationSetup.CadPartNr);
                    _kvITacGetStationSetup.Add("CustomerName", getStationSetup.CustomerName);
                    _kvITacGetStationSetup.Add("CustomerPartNr", getStationSetup.CustomerPartNr);
                    _kvITacGetStationSetup.Add("ErrorString", getStationSetup.ErrorString);
                    _kvITacGetStationSetup.Add("PartDesc", getStationSetup.PartDesc);
                    _kvITacGetStationSetup.Add("PartNr", getStationSetup.PartNr);
                    _kvITacGetStationSetup.Add("ProcessLayer", getStationSetup.ProcessLayer.ToString());
                    _kvITacGetStationSetup.Add("Quantity", getStationSetup.Quantity.ToString());
                    _kvITacGetStationSetup.Add("Result", getStationSetup.Result.ToString());
                    _kvITacGetStationSetup.Add("SessionId", getStationSetup.SessionId.ToString());
                    _kvITacGetStationSetup.Add("State", getStationSetup.State);
                    _kvITacGetStationSetup.Add("StationNr", getStationSetup.StationNr);
                    _kvITacGetStationSetup.Add("WorkOrder", getStationSetup.WorkOrder);
                    */

                    _apiSessionValidationStruct = new ApiSessionValidationStruct();
                    _apiSessionValidationStruct.user = sStationNumber;
                    _apiSessionValidationStruct.password = sStationNumber;
                    _apiSessionValidationStruct.client = sStationNumber;
                    _apiSessionValidationStruct.isVip = false;
                    _apiSessionValidationStruct.isStation = true;
                    _apiSessionValidationStruct.systemIdentifier = sStationNumber;

                    _itacMII = new ItacMII();
                    int iItacApiInit = _itacMII.apiInit(out string errItacApiInit);

                    if (iItacApiInit == 0)
                    {
                        //登陆iTac，返回iTac Session ID
                        iTacSessionID = _itacMII.apiLogin(_apiSessionValidationStruct, out string errItacApiLogin);
                    }
                    else
                    {
                        MsgBoxHelper.MsgBoxError("iTAC Api Login failed!" + "\n" +
                            "iTAC Session ID -> " + iTacSessionID + "\n" +
                            "IacMII -> " + iItacApiInit);
                        return;
                    }

                    if (iTacSessionID >= 0)
                    {
                        _itacMII.getStationSetup(iTacSessionID, sStationNumber, out string sPartNr, out int iBomVersion, out string sBomIndex, out string sPartDesc, out string sWorkOrder, out int iQuantity, out string sState, out string sCadPartNr, out int iProcessLayer, out string sCustomerName, out string sCustomerPartNr, out string sAttribut1, out string sErrorString);

                        stationSetupModel.PartNr = sPartNr;
                        stationSetupModel.BomVersion = iBomVersion.ToString();
                        stationSetupModel.BomIndex = sBomIndex;
                        stationSetupModel.PartDesc = sPartDesc;
                        stationSetupModel.WorkOrder = sWorkOrder;
                        stationSetupModel.Quantity = iQuantity.ToString();
                        stationSetupModel.State = sState;
                        stationSetupModel.CadPartNr = sCadPartNr;
                        stationSetupModel.ProcessLayer = iProcessLayer.ToString();
                        stationSetupModel.CustomerName = sCustomerName;
                        stationSetupModel.CustomerPartNr = sCustomerPartNr;
                        stationSetupModel.Attribut1 = sAttribut1;
                        stationSetupModel.ErrorString = sErrorString;
                    }

                    //_itacMII.apiLogout(iTacSessionID, out string errItacApiLogout);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    //Application.Exit();
                    return;
                }
            });

            int iItacApiShutdown = _itacMII.apiShutdown(out string errItacApiShutdown);
            if (iItacApiShutdown == 0)
            {
                _itacMII.apiLogout(iTacSessionID, out string errItacApiLogout);
            }
            else
            {
                MsgBoxHelper.MsgBoxError("iTAC Api Shutdown failed!\n" + "iTAC Session ID -> " + iTacSessionID);
                return;
            }

            #region 解析stationSetupModel，加载到DataGridView
            dgv_iTAC_StationSetup.Rows.Clear();

            dgv_iTAC_StationSetup.Rows.Add();
            dgv_iTAC_StationSetup.Rows[0].Cells[0].Value = "PartNr";
            dgv_iTAC_StationSetup.Rows[0].Cells[1].Value = stationSetupModel.PartNr;

            dgv_iTAC_StationSetup.Rows.Add();
            dgv_iTAC_StationSetup.Rows[1].Cells[0].Value = "BomVersion";
            dgv_iTAC_StationSetup.Rows[1].Cells[1].Value = stationSetupModel.BomVersion;

            dgv_iTAC_StationSetup.Rows.Add();
            dgv_iTAC_StationSetup.Rows[2].Cells[0].Value = "BomIndex";
            dgv_iTAC_StationSetup.Rows[2].Cells[1].Value = stationSetupModel.BomIndex;

            dgv_iTAC_StationSetup.Rows.Add();
            dgv_iTAC_StationSetup.Rows[3].Cells[0].Value = "PartDesc";
            dgv_iTAC_StationSetup.Rows[3].Cells[1].Value = stationSetupModel.PartDesc;

            dgv_iTAC_StationSetup.Rows.Add();
            dgv_iTAC_StationSetup.Rows[4].Cells[0].Value = "WorkOrder";
            dgv_iTAC_StationSetup.Rows[4].Cells[1].Value = stationSetupModel.WorkOrder;

            dgv_iTAC_StationSetup.Rows.Add();
            dgv_iTAC_StationSetup.Rows[5].Cells[0].Value = "Quantity";
            dgv_iTAC_StationSetup.Rows[5].Cells[1].Value = stationSetupModel.Quantity;

            dgv_iTAC_StationSetup.Rows.Add();
            dgv_iTAC_StationSetup.Rows[6].Cells[0].Value = "State";
            dgv_iTAC_StationSetup.Rows[6].Cells[1].Value = stationSetupModel.State;

            dgv_iTAC_StationSetup.Rows.Add();
            dgv_iTAC_StationSetup.Rows[7].Cells[0].Value = "CadPartNr";
            dgv_iTAC_StationSetup.Rows[7].Cells[1].Value = stationSetupModel.CadPartNr;

            dgv_iTAC_StationSetup.Rows.Add();
            dgv_iTAC_StationSetup.Rows[8].Cells[0].Value = "ProcessLayer";
            dgv_iTAC_StationSetup.Rows[8].Cells[1].Value = stationSetupModel.ProcessLayer;

            dgv_iTAC_StationSetup.Rows.Add();
            dgv_iTAC_StationSetup.Rows[9].Cells[0].Value = "CustomerName";
            dgv_iTAC_StationSetup.Rows[9].Cells[1].Value = stationSetupModel.CustomerName;

            dgv_iTAC_StationSetup.Rows.Add();
            dgv_iTAC_StationSetup.Rows[10].Cells[0].Value = "CustomerPartNr";
            dgv_iTAC_StationSetup.Rows[10].Cells[1].Value = stationSetupModel.CustomerPartNr;

            int i = 0;
            //string[] sArrAttribut1;
            dgv_iTAC_StationSetup.Rows.Add();
            dgv_iTAC_StationSetup.Rows[11].Cells[0].Value = "Attribut1";
            if (!string.IsNullOrEmpty(stationSetupModel.Attribut1))
            {
                //去除Attribut1最后的分号
                if (stationSetupModel.Attribut1.EndsWith(";"))
                {

                    sArrAttribut1 = stationSetupModel.Attribut1.Substring(0, stationSetupModel.Attribut1.Length - 1).Split(',');
                }
                else
                {
                    sArrAttribut1 = stationSetupModel.Attribut1.Split(',');
                }

                for (i = 0; i < sArrAttribut1.Length; i++)
                {
                    if (i > 0)
                    {
                        dgv_iTAC_StationSetup.Rows.Add();
                    }
                    dgv_iTAC_StationSetup.Rows[11 + i].Cells[1].Value = sArrAttribut1[i];
                }
            }

            //dgv_iTAC_StationSetup.Rows.Add();
            //dgv_iTAC_StationSetup.Rows[12].Cells[0].Value = "ErrorString";
            //dgv_iTAC_StationSetup.Rows[12].Cells[1].Value = stationSetupModel.ErrorString;

            //int i = 0;
            //string[] sArrAttribut1;
            //if (!string.IsNullOrEmpty(stationSetupModel.Attribut1))
            //{
            //    dgv_iTAC_StationSetup.Rows.Add();
            //    dgv_iTAC_StationSetup.Rows[0].Cells[0].Value = "Attribut1";

            //    sArrAttribut1 = stationSetupModel.Attribut1.Split(',');
            //    for (i = 0; i < sArrAttribut1.Length; i++)
            //    {
            //        dgv_iTAC_StationSetup.Rows.Add();
            //        dgv_iTAC_StationSetup.Rows[i].Cells[1].Value = sArrAttribut1[i];
            //    }
            //}

            #endregion


            //#region 将从iTac获取的getStationSetup加载到DataGridView
            //int j = 0;
            //string[] sArrAttribut1;
            ////遍历StationSetup的键值对，加载到dgv
            //for (int i = 0; i < _kvITacGetStationSetup.Keys.ToList().Count; i++)
            //{
            //    //获取Attribut1的属性
            //    if (_kvITacGetStationSetup.ElementAt(i).Key == "Attribut1")
            //    {
            //        _kvITacGetStationSetup.TryGetValue("Attribut1", out string sAttribut1);

            //        dgv_iTAC_StationSetup.Rows.Add();
            //        dgv_iTAC_StationSetup.Rows[0].Cells[0].Value = "Attribut1";

            //        sArrAttribut1 = sAttribut1.Split(',');
            //        for (j = 0; j < sArrAttribut1.Length; j++)
            //        {
            //            dgv_iTAC_StationSetup.Rows.Add();
            //            dgv_iTAC_StationSetup.Rows[j].Cells[1].Value = sArrAttribut1[j];
            //        }

            //    }
            //    else
            //    {
            //        dgv_iTAC_StationSetup.Rows.Add();
            //        dgv_iTAC_StationSetup.Rows[i + j].Cells[0].Value = "BomIndex";
            //        dgv_iTAC_StationSetup.Rows[i + j].Cells[1].Value = getStationSetup.BomIndex;
            //    }
            //}

            ////BindingSource _bindingSource = new BindingSource();
            ////dgv_iTAC_StationSetup.DataSource = _bindingSource;
            ////_bindingSource.DataSource = _kvITacGetStationSetup;
            ////#endregion
            ///

            for (int u = 0; u < dgv_iTAC_StationSetup.Columns.Count; u++)
            {
                dgv_iTAC_StationSetup.Columns[u].SortMode = DataGridViewColumnSortMode.NotSortable; //禁用列排序
                dgv_iTAC_StationSetup.Columns[u].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            //initITac.Logout();
            //apiLogout = new apiLogout(sessionId);
            //apiLogout.run();
            button1.Enabled = true;

            #endregion
        }



        private void btn_Debug_Click(object sender, EventArgs e)
        {
            /*
            string sStationNumber = "RA02311010";

            _apiSessionValidationStruct = new ApiSessionValidationStruct();
            _apiSessionValidationStruct.user = sStationNumber;
            _apiSessionValidationStruct.password = sStationNumber;
            _apiSessionValidationStruct.client = sStationNumber;
            _apiSessionValidationStruct.isVip = false;
            _apiSessionValidationStruct.isStation = true;
            _apiSessionValidationStruct.systemIdentifier = sStationNumber;

            _itacMII = new ItacMII();

            int iItacApiInit = _itacMII.apiInit(out string errItacApiInit);

            int iSessionID = _itacMII.apiLogin(_apiSessionValidationStruct, out string errItacApiLogin);


            _itacMII.getStationSetup(iSessionID, sStationNumber, out string s2, out int j0, out string s4, out string s5, out string s6, out int j1, out string s7, out string s8, out int j2, out string s9, out string s10, out string s11, out string s12);

            int iItacApiShutdown = _itacMII.apiShutdown(out string errItacApiShutdown);
            _itacMII.apiLogout(iSessionID, out string errItacApiLogout);
            */

            if (dgv_iTAC_StationSetup.Rows.Count == 0 || dgv_PLM.Rows.Count == 0)
            {
                MsgBoxHelper.MsgBoxError("It's loading...");
                return;
            }

            List<string> lstFileNamePLM = lstFilesPLM.Select(s => s.Substring(s.LastIndexOf('\\') + 1)).ToList();

            lstFilesITacDiff.Clear();

            for (int i = 0; i < sArrAttribut1.Length; i++)
            {
                string file = sArrAttribut1[i];

                if (!lstFileNamePLM.Contains(file))
                {
                    lstFilesITacDiff.Add(file);
                }
            }

            //清空背景色
            for (int j = 0; j < dgv_iTAC_StationSetup.Rows.Count; j++)
            {
                dgv_iTAC_StationSetup.Rows[j].Cells[1].Style.BackColor = default;
            }


            for (int j = 0; j < dgv_iTAC_StationSetup.Rows.Count; j++)
            {

                string file = (string)dgv_iTAC_StationSetup.Rows[j].Cells[1].Value;

                for (int k = 0; k < lstFilesITacDiff.Count; k++)
                {
                    if (file == lstFilesITacDiff[k])
                    {
                        dgv_iTAC_StationSetup.Rows[j].Cells[1].Style.BackColor = Color.Yellow;
                        break;
                    }
                }
            }
        }


        private void dgv_PLM_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }


        private void dgv_PLM_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                lstFilesPLM.Clear();

                //Task.Run(() =>
                //{
                foreach (string file in files)
                {
                    //判断拖入的是目录还是文件
                    if ((File.GetAttributes(file) & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        //循环遍历目录，获取目录下的所有文件，添加到List
                        //fileAllList.AddRange(UtilityHelper.RecursionDirReturnList(file));
                        UtilityHelper.RecursionDir(lstFilesPLM, new DirectoryInfo(file), true);
                    }

                }

                dgv_PLM.Rows.Clear();

                for (int i = 0; i < lstFilesPLM.Count; i++)
                {
                    dgv_PLM.Rows.Add();
                    dgv_PLM.Rows[i].Cells[0].Value = lstFilesPLM[i].Substring(lstFilesPLM[i].LastIndexOf('\\') + 1);
                }

                for (int u = 0; u < dgv_PLM.Columns.Count; u++)
                {
                    dgv_PLM.Columns[u].SortMode = DataGridViewColumnSortMode.NotSortable; //禁用列排序
                    dgv_PLM.Columns[u].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }
        }


        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Close" + " ？", "Info", 2))
            {
                //_itacMII.apiLogout(iTacSessionID, out string errItacApiLogout);
                this.CloseForm();
            }
        }

        #endregion


        #region 方法
        /// <summary>
        /// 初始化操作
        /// </summary>
        private void InitAct()
        {
            //
        }


        /// <summary>
        /// 从ini文件中读取Radar站位信息，并加载到下拉框
        /// </summary>
        private void LoadRadarLineStationFromIni()
        {
            switch (FileHelper.sIniPMSUsage)
            {
                case "Debug":
                    _sIniPathPMSUsed = FileHelper.sIniFilePathDebug;
                    break;
                case "CFM":
                    _sIniPathPMSUsed = FileHelper.sIniFilePathCFM;
                    break;
                default:
                    break;
            }

            _kvStation.Clear();

            _sRadar2SELStation = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_LINE_STATION, "RDR2_SEL_Station", "NULL", _sIniPathPMSUsed);
            if (!"NULL".Equals(_sRadar2SELStation))
            {
                _kvStation.Add(_sRadar2SELStation.Substring(0, _sRadar2SELStation.IndexOf("_")), _sRadar2SELStation.Substring(_sRadar2SELStation.IndexOf("_") + 1));
            }

            _sRadar4SELStation = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_LINE_STATION, "RDR4_SEL_Station", "NULL", _sIniPathPMSUsed);
            if (!"NULL".Equals(_sRadar4SELStation))
            {
                _kvStation.Add(_sRadar4SELStation.Substring(0, _sRadar4SELStation.IndexOf("_")), _sRadar4SELStation.Substring(_sRadar4SELStation.IndexOf("_") + 1));
            }

            _sRadar5SELStation = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_LINE_STATION, "RDR5_SEL_Station", "NULL", _sIniPathPMSUsed);
            if (!"NULL".Equals(_sRadar5SELStation))
            {
                _kvStation.Add(_sRadar5SELStation.Substring(0, _sRadar5SELStation.IndexOf("_")), _sRadar5SELStation.Substring(_sRadar5SELStation.IndexOf("_") + 1));
            }

            //加载站位名称到下拉框
            cbBox_RadarLineStation.Items.Clear();
            cbBox_RadarLineStation.Items.AddRange(_kvStation.Keys.ToList().ToArray());
        }
        #endregion
    }


    public class StringFileFullname
    {
        public StringFileFullname(string s)
        {
            _file = s;
        }

        string _file;
        public string Value
        {
            get { return _file; }
            set { _file = value; }
        }
    }




}
