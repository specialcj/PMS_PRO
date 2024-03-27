using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using PMS.COMMON;
using PMS.COMMON.Helper;
using PMS.MODELS;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinPMS.FModels;

namespace WinPMS.Radar
{
    public partial class FrmRadarPacking : Form
    {
        private FrmProgressBarModel _frmProgressBarModel = null;

        private IniHelper2 _iniHelper2 = null;

        private string _sRadarPackingDriveIP = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_PACKING, "RDR_PACKING_DRIVE_IP", "NULL", FileHelper.sIniFilePathCFM);
        private string _sRadarPackingDrivePath = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_PACKING, "RDR_PACKING_DRIVE_PATH", "NULL", FileHelper.sIniFilePathCFM);
        private string _sRadarPackingLine1IniFile = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_PACKING, "RDR_PACKING_LINE1_INI_FILE", "NULL", FileHelper.sIniFilePathCFM);
        private string _sRadarPackingLine2IniFile = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_PACKING, "RDR_PACKING_LINE2_INI_FILE", "NULL", FileHelper.sIniFilePathCFM);
        private string _sRadarPackingLine4IniFile = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_PACKING, "RDR_PACKING_LINE4_INI_FILE", "NULL", FileHelper.sIniFilePathCFM);
        private string _sRadarPackingLine5IniFile = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_PACKING, "RDR_PACKING_LINE5_INI_FILE", "NULL", FileHelper.sIniFilePathCFM);
        private string _sRadarPackingLine7IniFile = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_PACKING, "RDR_PACKING_LINE7_INI_FILE", "NULL", FileHelper.sIniFilePathCFM);

        private string _sRadarPackingIniFile = "";
        private string _sRadarPackingIniDeleteSection = "";//记录删除的Section

        private int _iCurrentPackingInfoIndex = -1;//记录当前的包装配置的index
        private int _iNewPackingInfoIndex = -1;//记录新的包装配置的index
        private int _iPackingActionFlag = -1;//包装的操作标识
        private bool _bPackingInfoIsDoFlag = false;//记录新的包装配置的falg，true表示在RadarPackingInfo页面操作过，false表示没有操作过

        private List<RadarPackingIniModel> _lstRadarPackingIniModules = new List<RadarPackingIniModel>();
        private List<string> _lstPackingShippingRepeat = new List<string>();
        private List<string> _lstPackingIniRead = new List<string>();

        public FrmRadarPacking()
        {
            //1. 设置窗体的双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            InitializeComponent();

            //2. 利用反射设置DataGridView的双缓冲
            Type dgvType = this.dataGridView1.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dataGridView1, true, null);
        }

        #region 事件
        private void FrmRadarPacking_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                textBoxRadarDriveIP.Text = _sRadarPackingDriveIP;

                #region dateGridView初始化设置
                //标题栏字体加粗
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);

                //隔行变色
                dataGridView1.RowsDefaultCellStyle.BackColor = default;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

                //行，列自适应
                //dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                #endregion

                //获取当前窗体的Tag值
                if (null != this.Tag)
                {
                    _frmProgressBarModel = this.Tag as FrmProgressBarModel;
                }
            };

            act.TryCatchInvoke("Radar Packing页面加载异常！");
        }

        /// <summary>
        /// 连接测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnTest_Click(object sender, EventArgs e)
        {
            if (PingDrive(_sRadarPackingDriveIP))
            {
                MsgBoxHelper.MsgBoxShow(_sRadarPackingDriveIP + "\n" + "连接成功！", "Ping");
            }
            else
            {
                MsgBoxHelper.MsgBoxError(_sRadarPackingDriveIP + "\n" + "连接失败！");
            }
        }

        /// <summary>
        /// 读取Packing配置异步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnReadPackingINI_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = null;

            //连接测试
            if (!PingDrive(_sRadarPackingDriveIP))
            {
                MsgBoxHelper.MsgBoxError(_sRadarPackingDriveIP + "\n" + "连接失败！");
                return;
            }

            btnReadPackingINI.Enabled = false;

            //await LoadPackingIniSectionAsync();
            await LoadPackingIniSectionByLineAsync();

            btnReadPackingINI.Enabled = true;

            //判断是否包含重复的Shipping号
            HasShippingRepeat();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[e.RowIndex].Selected = true;
                    }

                    //只选中一行时设置活动单元格
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }

                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        /// <summary>
        /// DataGridView显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        /// <summary>
        /// 包装线体选择改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPackingLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据不同的包装线体，加载不同的Packing文件
            switch (comboBoxPackingLine.SelectedIndex)
            {
                case 0://Radar 1
                    _sRadarPackingIniFile = @"\\" + _sRadarPackingDriveIP + @_sRadarPackingDrivePath + _sRadarPackingLine1IniFile;
                    break;
                case 1://Radar 2
                    _sRadarPackingIniFile = @"\\" + _sRadarPackingDriveIP + @_sRadarPackingDrivePath + _sRadarPackingLine2IniFile;
                    break;
                case 2://Radar 4
                    _sRadarPackingIniFile = @"\\" + _sRadarPackingDriveIP + @_sRadarPackingDrivePath + _sRadarPackingLine4IniFile;
                    break;
                case 3://Radar 5
                    _sRadarPackingIniFile = @"\\" + _sRadarPackingDriveIP + @_sRadarPackingDrivePath + _sRadarPackingLine5IniFile;
                    break;
                case 4://Radar 7
                    _sRadarPackingIniFile = @"\\" + _sRadarPackingDriveIP + @_sRadarPackingDrivePath + _sRadarPackingLine7IniFile;
                    break;
            }

            //TODO 测试：加载本地的Packing ini文件，需要删除
            //_sRadarPackingIniFile = @"D:\Radar02_77GHz_PackingProduct_test.ini";
            _sRadarPackingIniFile = @"D:\Radar02_77GHz_PDI.ini";

            label_PackingIniFile.Text = _sRadarPackingIniFile;
        }

        /// <summary>
        /// 跳转到新的包装信息索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwitchToNewPackingInfo_Click(object sender, EventArgs e)
        {
            if (!lbl_NewPackingInfoIndex.Text.Trim().StartsWith("{"))
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[_iCurrentPackingInfoIndex].Cells[1];
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MsgBoxHelper.MsgBoxError("NA");
        }

        /// <summary>
        /// 在上一行新加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBoxAddAboveByNew_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MsgBoxHelper.MsgBoxShow("请先读取Packing配置！", "Packing");
                return;
            }

            //判断是否有重复的Shipping号？
            //如果包含，则不能执行操作，需要先解决重复Shipping号的问题
            if (HasShippingRepeat())
            {
                MsgBoxHelper.MsgBoxError("请先解决重复Shipping号的冲突！");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];//获取选中的行
            RadarPackingIniModel radarPackingIniModel = row.DataBoundItem as RadarPackingIniModel;//将当前行绑定的数据转换为实体类

            if (!CheckIsNormalPackingSection(radarPackingIniModel))
            {
                MsgBoxHelper.MsgBoxError("这不是一个正确的包装配置！\n\n请选择其它的配置再操作！");
                return;
            }

            //记录当前包装信息的索引
            _iCurrentPackingInfoIndex = row.Index;
            //_iNewPackingInfoIndex = row.Index + 1;

            _iPackingActionFlag = 1;
            ShowRadarPackingInfo(_iPackingActionFlag, radarPackingIniModel);
        }

        /// <summary>
        /// 在下一行新加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBoxAddBelowByNew_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MsgBoxHelper.MsgBoxShow("请先读取Packing配置！", "Packing");
                return;
            }

            //判断是否有重复的Shipping号？
            //如果包含，则不能执行操作，需要先解决重复Shipping号的问题
            if (HasShippingRepeat())
            {
                MsgBoxHelper.MsgBoxError("请先解决重复Shipping号的冲突！");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];//获取选中的行
            RadarPackingIniModel radarPackingIniModel = row.DataBoundItem as RadarPackingIniModel;//将当前行绑定的数据转换为实体类

            if (!CheckIsNormalPackingSection(radarPackingIniModel))
            {
                MsgBoxHelper.MsgBoxError("这不是一个正确的包装配置！\n\n请选择其它的配置再操作！");
                return;
            }

            //记录当前包装信息的索引
            _iCurrentPackingInfoIndex = row.Index;
            //_iNewPackingInfoIndex = row.Index + 1;

            _iPackingActionFlag = 2;
            ShowRadarPackingInfo(_iPackingActionFlag, radarPackingIniModel);
        }


        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBoxAddByCopy_Click(object sender, EventArgs e)
        {
            MsgBoxHelper.MsgBoxError("功能未实现！");
        }

        /// <summary>
        /// 复制 / 在上一行粘贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBoxAddAboveByCopy_Click(object sender, EventArgs e)
        {
            MsgBoxHelper.MsgBoxError("功能未实现！");
        }

        /// <summary>
        /// 复制 / 在下一行粘贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBoxAddBelowByCopy_Click(object sender, EventArgs e)
        {
            MsgBoxHelper.MsgBoxError("功能未实现！");
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBoxModify_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MsgBoxHelper.MsgBoxShow("请先读取Packing配置！", "Packing");
                return;
            }

            //判断是否有重复的Shipping号？
            //如果包含，则不能执行操作，需要先解决重复Shipping号的问题
            //if (HasShippingRepeat())
            //{
            //    MsgBoxHelper.MsgBoxError("请先解决重复Shipping号的冲突！");
            //    return;
            //}

            DataGridViewRow row = dataGridView1.SelectedRows[0];//获取选中的行
            RadarPackingIniModel radarPackingIniModel = row.DataBoundItem as RadarPackingIniModel;//将当前行绑定的数据转换为实体类

            if (!CheckIsNormalPackingSection(radarPackingIniModel))
            {
                MsgBoxHelper.MsgBoxError("这不是一个正确的包装配置！\n\n请选择其它的配置再操作！");
                return;
            }

            //记录当前包装信息的索引
            _iCurrentPackingInfoIndex = row.Index;
            //_iNewPackingInfoIndex = row.Index;

            _iPackingActionFlag = 6;
            ShowRadarPackingInfo(_iPackingActionFlag, radarPackingIniModel);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBoxDeletePacking_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MsgBoxHelper.MsgBoxShow("请先读取Packing配置！", "Packing");
                return;
            }

            //判断是否有重复的Shipping号？
            //如果包含，则不能执行操作，需要先解决重复Shipping号的问题
            //if (HasShippingRepeat())
            //{
            //    MsgBoxHelper.MsgBoxError("请先解决重复Shipping号的冲突！");
            //    return;
            //}

            DataGridViewRow row = dataGridView1.SelectedRows[0];//获取选中的行
            RadarPackingIniModel radarPackingIniModel = row.DataBoundItem as RadarPackingIniModel;//将当前行绑定的数据转换为实体类

            _sRadarPackingIniDeleteSection = radarPackingIniModel.SectionName;

            if (!CheckIsNormalPackingSection(radarPackingIniModel))
            {
                MsgBoxHelper.MsgBoxError("这不是一个正确的包装配置！\n\n请选择其它的配置再操作！");
                return;
            }

            _iCurrentPackingInfoIndex = row.Index;
            //_iNewPackingInfoIndex = row.Index;

            _iPackingActionFlag = 7;
            ShowRadarPackingInfo(_iPackingActionFlag, radarPackingIniModel);
        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.CloseForm();
        }

        #endregion




        #region 方法
        /// <summary>
        /// Ping Drive
        /// </summary>
        /// <param name="driveIP"></param>
        /// <returns></returns>
        private bool PingDrive(string driveIP)
        {
            bool bPackingDriveOnline = false;
            Ping ping = new Ping();
            try
            {
                PingReply pingReply = ping.Send(driveIP);
                if (pingReply.Status == IPStatus.Success)
                {
                    bPackingDriveOnline = true;
                }
                else
                {
                    bPackingDriveOnline = false;
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError(_sRadarPackingDriveIP + " " + "异常！" + "\n\n" + ex.Message);
                //throw ex;
            }

            return bPackingDriveOnline;
        }

        /// <summary>
        /// 显示雷达包装操作页面
        /// </summary>
        /// <param name="actType">
        /// 1 > 在上一行新加
        /// 2 > 在下一行新加
        /// 3 > 复制
        /// 4 > 复制 / 在上一行新加
        /// 5 > 复制 / 在下一行新加
        /// 6 > 修改
        /// 7 > 删除
        /// </param>
        private void ShowRadarPackingInfo(int actType, RadarPackingIniModel radarPackingIniModel)
        {
            //读取当前选中的Section下的所有key
            NameValueCollection nameValueCollection = new NameValueCollection();
            _iniHelper2.ReadSectionValues(radarPackingIniModel.SectionName, nameValueCollection);

            FrmRadarPackingInfo frmRadarPackingInfo = new FrmRadarPackingInfo
            {
                Tag = new RadarPackingInfoModel
                {
                    ActType = actType,//操作标识
                    RadarPackingIniModel = radarPackingIniModel,
                    RadarPackingIniFile = _sRadarPackingIniFile,//包装的ini文件
                    RadarPackingSelectedSectionNum = _iCurrentPackingInfoIndex,//当前选中Section的序号
                    RadarPackingSelectedKeyCounts = nameValueCollection.Count,//当前选中Section下的所有key的数量
                    CheckRadarPackingInfoIsDo = SetRadarPackingInfoFlag,
                    ReLoadTask = LoadPackingIniSectionByLineAsync
                }
            };

            frmRadarPackingInfo.ShowDialog();
        }

        /// <summary>
        /// 加载Packing INI Section异步
        /// </summary>
        /// <returns></returns>
        private async Task LoadPackingIniSectionAsync()
        {
            string strValueRead = "";
            string strValueDefault = "EmptyValue";

            dataGridView1.DataSource = null;
            _lstRadarPackingIniModules.Clear();
            //_lstPackingIniRead.Clear();

            //判断包装线体是否已选择？
            if (comboBoxPackingLine.SelectedIndex == -1)
            {
                MsgBoxHelper.MsgBoxError("请选择包装线体！");
                return;
            }

            //初始化ini文件
            _iniHelper2 = new IniHelper2(_sRadarPackingIniFile);

            //获取Packing ini文件中所有的section
            StringCollection rdrPackingSectionList = new StringCollection();
            _iniHelper2.ReadSections(rdrPackingSectionList);

            //try
            //{
            //    StreamReader sr = new StreamReader(_sRadarPackingIniFile, Encoding.Default);
            //    string line;
            //    while (null != (line = sr.ReadLine()))
            //    {
            //        _lstPackingIniRead.Add(line);
            //    }

            //    sr.Close();
            //}
            //catch (Exception ex)
            //{
            //    MsgBoxHelper.MsgBoxError("Exception:" + "\n" + "FrmRadarPackingInfo - ModifyPacking()读取Packing配置文件错误！");
            //    throw ex;
            //}

            //for (int i = 0; i < _lstPackingIniRead.Count; i++)
            //{
            //    if (_lstPackingIniRead[i].StartsWith("[") && _lstPackingIniRead[i].EndsWith("]"))//判断这是一个Section
            //    {
            //        rdrPackingSectionList.Add(_lstPackingIniRead[i]);
            //    }

            //}

            //读取当前section下的所有key
            //NameValueCollection nameValueCollection = new NameValueCollection();
            //_iniHelper2.ReadSectionValues("644128200A", nameValueCollection);

            try
            {
                await Task.Run(() =>
                {
                    for (int i = 0; i < rdrPackingSectionList.Count; i++)
                    {
                        RadarPackingIniModel radarPackingIniModule = new RadarPackingIniModel();

                        //strValueRead = _iniHelper2.ReadString(rdrPackingSectionList[i], "Supplier", strValueDefault);

                        //读取当前的section name
                        radarPackingIniModule.SectionName = rdrPackingSectionList[i];

                        //读取当前的Shipping，即Section name
                        radarPackingIniModule.Shipping = "[" + rdrPackingSectionList[i] + "]";

                        //读取当前的Section name下的value
                        radarPackingIniModule.Supplier = _iniHelper2.ReadString(rdrPackingSectionList[i], "Supplier", strValueDefault);
                        if (radarPackingIniModule.Supplier == strValueDefault)
                        {
                            radarPackingIniModule.Supplier = "-";
                        }

                        radarPackingIniModule.CustomerPN = _iniHelper2.ReadString(rdrPackingSectionList[i], "CustomerPN", strValueDefault);
                        if (radarPackingIniModule.CustomerPN == strValueDefault)
                        {
                            radarPackingIniModule.CustomerPN = "-";
                        }

                        radarPackingIniModule.Description = _iniHelper2.ReadString(rdrPackingSectionList[i], "Description", strValueDefault);
                        if (radarPackingIniModule.Description == strValueDefault)
                        {
                            radarPackingIniModule.Description = "-";
                        }

                        radarPackingIniModule.Qty = _iniHelper2.ReadString(rdrPackingSectionList[i], "Qty", strValueDefault);
                        if (radarPackingIniModule.Qty == strValueDefault)
                        {
                            radarPackingIniModule.Qty = "-";
                        }

                        radarPackingIniModule.BoxNr = _iniHelper2.ReadString(rdrPackingSectionList[i], "BoxNr", strValueDefault);
                        if (radarPackingIniModule.BoxNr == strValueDefault)
                        {
                            radarPackingIniModule.BoxNr = "-";
                        }

                        radarPackingIniModule.BoxNrlen = _iniHelper2.ReadString(rdrPackingSectionList[i], "BoxNrlen", strValueDefault);
                        if (radarPackingIniModule.BoxNrlen == strValueDefault)
                        {
                            radarPackingIniModule.BoxNrlen = "-";
                        }

                        radarPackingIniModule.Lbtype = _iniHelper2.ReadString(rdrPackingSectionList[i], "Lbtype", strValueDefault);
                        if (radarPackingIniModule.Lbtype == strValueDefault)
                        {
                            radarPackingIniModule.Lbtype = "-";
                        }

                        radarPackingIniModule.SNl = _iniHelper2.ReadString(rdrPackingSectionList[i], "SNl", strValueDefault);
                        if (radarPackingIniModule.SNl == strValueDefault)
                        {
                            radarPackingIniModule.SNl = "-";
                        }

                        radarPackingIniModule.Template = _iniHelper2.ReadString(rdrPackingSectionList[i], "Template", strValueDefault);
                        if (radarPackingIniModule.Template == strValueDefault)
                        {
                            radarPackingIniModule.Template = "-";
                        }

                        radarPackingIniModule.VehiclePN = _iniHelper2.ReadString(rdrPackingSectionList[i], "VehiclePN", strValueDefault);
                        if (radarPackingIniModule.VehiclePN == strValueDefault)
                        {
                            radarPackingIniModule.VehiclePN = "-";
                        }

                        radarPackingIniModule.Weight = _iniHelper2.ReadString(rdrPackingSectionList[i], "Weight", strValueDefault);
                        if (radarPackingIniModule.Weight == strValueDefault)
                        {
                            radarPackingIniModule.Weight = "-";
                        }

                        radarPackingIniModule.BoxPosition = _iniHelper2.ReadString(rdrPackingSectionList[i], "BoxPosition", strValueDefault);
                        if (radarPackingIniModule.BoxPosition == strValueDefault)
                        {
                            radarPackingIniModule.BoxPosition = "-";
                        }

                        radarPackingIniModule.BoxRequire = _iniHelper2.ReadString(rdrPackingSectionList[i], "BoxRequire", strValueDefault);
                        if (radarPackingIniModule.BoxRequire == strValueDefault)
                        {
                            radarPackingIniModule.BoxRequire = "-";
                        }

                        radarPackingIniModule.PartCode = _iniHelper2.ReadString(rdrPackingSectionList[i], "PartCode", strValueDefault);
                        if (radarPackingIniModule.PartCode == strValueDefault)
                        {
                            radarPackingIniModule.PartCode = "-";
                        }

                        radarPackingIniModule.FixtureNo = _iniHelper2.ReadString(rdrPackingSectionList[i], "FixtureNo", strValueDefault);
                        if (radarPackingIniModule.FixtureNo == strValueDefault)
                        {
                            radarPackingIniModule.FixtureNo = "-";
                        }

                        _lstRadarPackingIniModules.Add(radarPackingIniModule);
                    }

                    //dataGridView1.DataSource = radarPackingINIs;
                    if (dataGridView1.InvokeRequired)
                    {
                        dataGridView1.Invoke(new Action(() =>
                        {
                            dataGridView1.DataSource = _lstRadarPackingIniModules;

                            if (dataGridView1.Rows.Count > 0)
                            {
                                //列隐藏
                                dataGridView1.Columns["SectionName"].Visible = false;
                                dataGridView1.Columns["Weight"].Visible = false;
                                dataGridView1.Columns["BoxPosition"].Visible = false;
                                dataGridView1.Columns["BoxRequire"].Visible = false;
                                dataGridView1.Columns["PartCode"].Visible = false;

                                //标题栏字体加粗
                                dataGridView1.EnableHeadersVisualStyles = false;
                                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);

                                //隔行变色
                                dataGridView1.RowsDefaultCellStyle.BackColor = default;
                                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

                                //行，列自适应
                                dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                            }
                        }));
                    }

                    //定位到新的包装信息
                    if (_bPackingInfoIsDoFlag)
                    {
                        if (lbl_NewPackingInfoIndex.InvokeRequired)
                        {
                            lbl_NewPackingInfoIndex.Invoke(new Action(() =>
                            {
                                lbl_NewPackingInfoIndex.Text = (_iCurrentPackingInfoIndex + 1).ToString();
                            }));
                        }

                        if (dataGridView1.InvokeRequired)
                        {
                            dataGridView1.Invoke(new Action(() =>
                            {
                                dataGridView1.CurrentCell = dataGridView1.Rows[_iCurrentPackingInfoIndex].Cells[1];
                            }));
                        }

                        switch (_iPackingActionFlag)
                        {
                            case 1://在上一行新加

                                break;
                            case 2://在下一行新加
                                //MsgBoxHelper.MsgBoxShowOnTop("在下一行新加成功！", "Packing");
                                this.Invoke(new Func<string, string, DialogResult>(MsgBoxHelper.MsgBoxShowOnTop), new object[] { "在下一行新加成功！", "Packing" });
                                break;
                            case 3://复制
                                   //功能未实现
                                break;
                            case 4://复制 / 在上一行粘贴
                                   //功能未实现
                                break;
                            case 5://复制 / 在下一行粘贴
                                   //功能未实现
                                break;
                            case 6://修改
                                //MsgBoxHelper.MsgBoxShowOnTop("修改成功！", "Packing");
                                /*
                                this.Invoke(new Func<string, string, DialogResult>((string s1, string s2) =>
                                {
                                    DialogResult ret = MsgBoxHelper.MsgBoxShowOnTop(s1, s2);
                                    return ret;
                                }), new object[] { "修改成功！", "Packing" });
                                */
                                //简化
                                this.Invoke(new Func<string, string, DialogResult>(MsgBoxHelper.MsgBoxShowOnTop), new object[] { "修改成功！", "Packing" });
                                break;
                            default:
                                break;
                        }

                        _bPackingInfoIsDoFlag = false;
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private async Task LoadPackingIniSectionByLineAsync()
        {
            string sKeyRead = "";
            string sValueRead = "";
            string sValueDefault = "EmptyValue";

            StringCollection lstIniAfterDelete = new StringCollection();

            dataGridView1.DataSource = null;
            _lstRadarPackingIniModules.Clear();
            _lstPackingIniRead.Clear();

            //判断包装线体是否已选择？
            if (comboBoxPackingLine.SelectedIndex == -1)
            {
                MsgBoxHelper.MsgBoxError("请选择包装线体！");
                return;
            }

            //初始化ini文件
            _iniHelper2 = new IniHelper2(_sRadarPackingIniFile);

            //获取Packing ini文件中所有的section
            //StringCollection rdrPackingSectionList = new StringCollection();
            //_iniHelper2.ReadSections(rdrPackingSectionList);

            try
            {
                StreamReader sr = new StreamReader(_sRadarPackingIniFile, Encoding.Default);
                string line;
                while (null != (line = sr.ReadLine()))
                {
                    _lstPackingIniRead.Add(line);
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError("Exception:" + "\n" + "FrmRadarPackingInfo - ModifyPacking()读取Packing配置文件错误！");
                throw ex;
            }

            //for (int i = 0; i < _lstPackingIniRead.Count; i++)
            //{
            //    if (_lstPackingIniRead[i].StartsWith("[") && _lstPackingIniRead[i].EndsWith("]"))//判断这是一个Section
            //    {
            //        rdrPackingSectionList.Add(_lstPackingIniRead[i]);
            //    }
            //}

            //读取当前section下的所有key
            //NameValueCollection nameValueCollection = new NameValueCollection();
            //_iniHelper2.ReadSectionValues("644128200A", nameValueCollection);

            try
            {
                await Task.Run(() =>
                {
                    for (int i = 0; i < _lstPackingIniRead.Count; i++)
                    {
                        int iCurrentSectionIndex = -1;
                        int iNextSectionIndex = -1;

                        //判断这是当前的Section
                        if (_lstPackingIniRead[i].StartsWith("[") && _lstPackingIniRead[i].EndsWith("]"))//判断这是一个Section的标志
                        {
                            RadarPackingIniModel radarPackingIniModule = new RadarPackingIniModel();

                            iCurrentSectionIndex = i;

                            //读取当前的Section name
                            radarPackingIniModule.SectionName = _lstPackingIniRead[i].Substring(1, _lstPackingIniRead[i].Length - 2);

                            //读取当前的Shipping
                            radarPackingIniModule.Shipping = _lstPackingIniRead[i];

                            //判断这是下一个Section
                            for (int j = iCurrentSectionIndex + 1; j < _lstPackingIniRead.Count; j++)
                            {
                                if (_lstPackingIniRead[j].StartsWith("[") && _lstPackingIniRead[j].EndsWith("]"))//判断这是一个Section标志
                                {
                                    iNextSectionIndex = j;
                                    break;
                                }
                            }

                            radarPackingIniModule.Supplier = "-";
                            radarPackingIniModule.CustomerPN = "-";
                            radarPackingIniModule.Description = "-";
                            radarPackingIniModule.Qty = "-";
                            radarPackingIniModule.BoxNr = "-";
                            radarPackingIniModule.BoxNrlen = "-";
                            radarPackingIniModule.Lbtype = "-";
                            radarPackingIniModule.SNl = "-";
                            radarPackingIniModule.Template = "-";
                            radarPackingIniModule.VehiclePN = "-";
                            radarPackingIniModule.Weight = "-";
                            radarPackingIniModule.BoxPosition = "-";
                            radarPackingIniModule.BoxRequire = "-";
                            radarPackingIniModule.PartCode = "-";
                            radarPackingIniModule.FixtureNo = "-";

                            //当已经是最后一个Section时，iNextSectionIndex的值是-1，此时将iNextSectionIndex的值赋值为Ini的行数
                            if (iNextSectionIndex == -1)
                            {
                                iNextSectionIndex = _lstPackingIniRead.Count;
                            }

                            for (int k = i + 1; k < iNextSectionIndex; k++)
                            {
                                if (_lstPackingIniRead[k].Contains("="))
                                {
                                    sKeyRead = _lstPackingIniRead[k].Substring(0, _lstPackingIniRead[k].Trim().Length - _lstPackingIniRead[k].Substring(_lstPackingIniRead[k].IndexOf("=")).Trim().Length);
                                    sValueRead = _lstPackingIniRead[k].Substring(_lstPackingIniRead[k].IndexOf("=") + 1).Trim();

                                    if (sKeyRead.Equals("Supplier"))
                                    {
                                        radarPackingIniModule.Supplier = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("CustomerPN"))
                                    {
                                        radarPackingIniModule.CustomerPN = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("Description"))
                                    {
                                        radarPackingIniModule.Description = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("Qty"))
                                    {
                                        radarPackingIniModule.Qty = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("BoxNr"))
                                    {
                                        radarPackingIniModule.BoxNr = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("BoxNrlen"))
                                    {
                                        radarPackingIniModule.BoxNrlen = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("Lbtype"))
                                    {
                                        radarPackingIniModule.Lbtype = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("SNl"))
                                    {
                                        radarPackingIniModule.SNl = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("Template"))
                                    {
                                        radarPackingIniModule.Template = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("VehiclePN"))
                                    {
                                        radarPackingIniModule.VehiclePN = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("Weight"))
                                    {
                                        radarPackingIniModule.Weight = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("BoxPosition"))
                                    {
                                        radarPackingIniModule.BoxPosition = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("BoxRequire"))
                                    {
                                        radarPackingIniModule.BoxRequire = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("PartCode"))
                                    {
                                        radarPackingIniModule.PartCode = sValueRead;
                                    }
                                    else if (sKeyRead.Equals("FixtureNo"))
                                    {
                                        radarPackingIniModule.FixtureNo = sValueRead;
                                    }
                                }
                            }

                            _lstRadarPackingIniModules.Add(radarPackingIniModule);
                        }
                    }

                    //dataGridView1.DataSource = radarPackingINIs;
                    if (dataGridView1.InvokeRequired)
                    {
                        dataGridView1.Invoke(new Action(() =>
                        {
                            dataGridView1.DataSource = _lstRadarPackingIniModules;

                            if (dataGridView1.Rows.Count > 0)
                            {
                                //列隐藏
                                dataGridView1.Columns["SectionName"].Visible = false;
                                dataGridView1.Columns["Weight"].Visible = false;
                                dataGridView1.Columns["BoxPosition"].Visible = false;
                                dataGridView1.Columns["BoxRequire"].Visible = false;
                                dataGridView1.Columns["PartCode"].Visible = false;

                                //标题栏字体加粗
                                dataGridView1.EnableHeadersVisualStyles = false;
                                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);

                                //隔行变色
                                dataGridView1.RowsDefaultCellStyle.BackColor = default;
                                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

                                //行，列自适应
                                dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                            }
                        }));
                    }

                    //定位到新的包装信息
                    if (_bPackingInfoIsDoFlag)
                    {
                        if (lbl_NewPackingInfoIndex.InvokeRequired)
                        {
                            lbl_NewPackingInfoIndex.Invoke(new Action(() =>
                            {
                                if (_iPackingActionFlag == 7)//如果是删除操作，不设置index
                                {
                                    lbl_NewPackingInfoIndex.Text = "{ - }";
                                }
                                else
                                {
                                    lbl_NewPackingInfoIndex.Text = (_iCurrentPackingInfoIndex + 1).ToString();
                                }
                            }));
                        }

                        if (dataGridView1.InvokeRequired)
                        {
                            dataGridView1.Invoke(new Action(() =>
                            {
                                if (_iPackingActionFlag == 7)//如果是删除操作，光标定位到第一行
                                {
                                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1];
                                }
                                else
                                {
                                    dataGridView1.CurrentCell = dataGridView1.Rows[_iCurrentPackingInfoIndex].Cells[1];
                                }
                            }));
                        }

                        switch (_iPackingActionFlag)
                        {
                            case 1://在上一行新加

                                break;
                            case 2://在下一行新加
                                //MsgBoxHelper.MsgBoxShowOnTop("在下一行新加成功！", "Packing");
                                this.Invoke(new Func<string, string, DialogResult>(MsgBoxHelper.MsgBoxShowOnTop), new object[] { "在下一行新加成功！", "Packing" });
                                break;
                            case 3://复制
                                   //功能未实现
                                break;
                            case 4://复制 / 在上一行粘贴
                                   //功能未实现
                                break;
                            case 5://复制 / 在下一行粘贴
                                   //功能未实现
                                break;
                            case 6://修改
                                //MsgBoxHelper.MsgBoxShowOnTop("修改成功！", "Packing");
                                /*
                                this.Invoke(new Func<string, string, DialogResult>((string s1, string s2) =>
                                {
                                    DialogResult ret = MsgBoxHelper.MsgBoxShowOnTop(s1, s2);
                                    return ret;
                                }), new object[] { "修改成功！", "Packing" });
                                */
                                //简化
                                this.Invoke(new Func<string, string, DialogResult>(MsgBoxHelper.MsgBoxShowOnTop), new object[] { "修改成功！", "Packing" });
                                break;
                            case 7://删除
                                   //删除之后再次读取该Section，如果返回list的count大于0，则表示该Section还存在，提示删除失败
                                _iniHelper2.ReadSection(_sRadarPackingIniDeleteSection + "_delete", lstIniAfterDelete);
                                if (lstIniAfterDelete.Count == 0)
                                {
                                    this.Invoke(new Func<string, string, DialogResult>(MsgBoxHelper.MsgBoxShowOnTop), new object[] { "删除成功！", "Packing" });
                                }
                                else
                                {
                                    this.Invoke(new Action<string>(MsgBoxHelper.MsgBoxError), new object[] { "删除失败！" });
                                }
                                break;
                            default:
                                break;
                        }

                        _bPackingInfoIsDoFlag = false;
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 检查是否是一个正常的Packing Section
        /// </summary>
        private bool CheckIsNormalPackingSection(RadarPackingIniModel radarPackingIniModule)
        {
            bool bIsPackingSection = true;

            if
            (
                radarPackingIniModule.Supplier == "-" ||
                radarPackingIniModule.CustomerPN == "-" ||
                radarPackingIniModule.Description == "-" ||
                radarPackingIniModule.VehiclePN == "-"
            )
            {
                bIsPackingSection = false;
            }

            return bIsPackingSection;
        }

        /// <summary>
        /// 设置新的包装信息标志位
        /// </summary>
        private void SetRadarPackingInfoFlag()
        {
            //根据包装的操作类型，改变包装信息的索引
            switch (_iPackingActionFlag)
            {
                case 1://在上一行新加
                    _iCurrentPackingInfoIndex = _iCurrentPackingInfoIndex - 1;
                    break;
                case 2://在下一行新加
                    _iCurrentPackingInfoIndex = _iCurrentPackingInfoIndex + 1;
                    break;
                case 3://复制
                    //功能未实现
                    break;
                case 4://复制 / 在上一行粘贴
                    //功能未实现
                    break;
                case 5://复制 / 在下一行粘贴
                    //功能未实现
                    break;
                case 6://修改
                    //当前包装信息的索引不变
                    break;
                case 7://删除
                    //不显示包装信息的索引
                    break;
                default:
                    break;
            }

            _bPackingInfoIsDoFlag = true;
        }

        /// <summary>
        /// 判断包装配置ini中是否有重复的Shipping号
        /// </summary>
        /// <returns></returns>
        private bool HasShippingRepeat()
        {
            List<string> lstShipping = new List<string>();
            List<string> lstShppingRepeat1 = new List<string>();
            List<string> lstShppingRepeat2 = new List<string>();

            string sRepeat1 = "";
            string sRepeat2 = "";

            //获取所有的Shipping号
            for (int i = 0; i < _lstRadarPackingIniModules.Count; i++)
            {
                lstShipping.Add(_lstRadarPackingIniModules[i].Shipping);
            }

            //判断是否有重复的Shipping号
            for (int m = 0; m < lstShipping.Count; m++)
            {
                for (int n = m + 1; n < lstShipping.Count; n++)
                {
                    if (lstShipping[m] == lstShipping[n])
                    {
                        lstShppingRepeat1.Add((m + 1).ToString());
                        lstShppingRepeat2.Add((n + 1).ToString());
                    }
                }
            }

            for (int i = 0; i < lstShppingRepeat1.Count; i++)
            {
                if (i == lstShppingRepeat1.Count - 1)
                {
                    sRepeat1 += "[ " + lstShppingRepeat1[i] + " ]";
                }
                else
                {
                    sRepeat1 += "[ " + lstShppingRepeat1[i] + " ], ";
                }
            }

            for (int i = 0; i < lstShppingRepeat2.Count; i++)
            {
                if (i == lstShppingRepeat2.Count - 1)
                {
                    sRepeat2 += "[ " + lstShppingRepeat2[i] + " ]";
                }
                else
                {
                    sRepeat2 += "[ " + lstShppingRepeat2[i] + " ], ";
                }
            }

            if (lstShppingRepeat1.Count > 0)
            {
                //MsgBoxHelper.MsgBoxShow("包含重复的Shipping号！\n重复行必须先删除才能执行新加或者修改操作！\n\n" + "行：" + sRepeat1 + "\n" + "行：" + sRepeat2, "Packing");
                MsgBoxHelper.MsgBoxShow("包含重复的Shipping号！\n新加功能将受到限制！\n\n" + "行：" + sRepeat1 + "\n" + "行：" + sRepeat2, "Packing");

                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        
    }
}
