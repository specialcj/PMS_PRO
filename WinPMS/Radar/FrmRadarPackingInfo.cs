using PMS.COMMON.Helper;
using PMS.MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WinPMS.FModels;
using ImageMagick;
using System.Threading.Tasks;
using System.Text;
using AForge.Video.DirectShow;
using System.Drawing;
using AForge.Video;
using ZXing;
using System.Collections.Specialized;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

namespace WinPMS.Radar
{
    public partial class FrmRadarPackingInfo : Form
    {
        private IniHelper2 _iniHelper2 = null;

        private string _sRadarPackingIniKeyCounts = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_PACKING, "RDR_PACKING_INI_KEY_COUNTS", "NULL", FileHelper.sIniFilePathCFM);
        private string _sRadarPackingTemplate = IniHelper.ReadIni(FileHelper.INI_SECTION_RDR_PACKING, "RDR_PACKING_INI_TEMPLATE", "NULL", FileHelper.sIniFilePathCFM);
        private string _sPackingBackupPathLocal = @"C:\PMS_RadarPackingBackup";

        private string _sCurrentDate = "";
        private string _sBackupSrcFileNameTemp1 = "";
        private string _sBackupSrcFileName = "";
        private string _sBackupDestFileName = "";

        private List<string> _lstPackingIniRead = new List<string>();
        private List<RadarPackingWIModel> _lstRadarPackingWIModel
            = new List<RadarPackingWIModel>();

        private RadarPackingInfoModel _radarPackingInfoModel = null;


        public FrmRadarPackingInfo()
        {
            InitializeComponent();
        }


        #region 事件
        private void FrmRadarPackingInfo_Load(object sender, EventArgs e)
        {
            ////执行任何操作前，将原来的配置文件保存到本地路径下作为备份
            //_sCurrentDate = DateTime.Now.ToString("yyyyMMdd");
            //_sBackupSrcFileNameTemp1 = _radarPackingInfoModel.RadarPackingIniFile.Substring(_radarPackingInfoModel.RadarPackingIniFile.LastIndexOf("\\") + 1);
            //_sBackupSrcFileName = _sBackupSrcFileNameTemp1.Substring(0, _sBackupSrcFileNameTemp1.Length - ".ini".Length);
            //_sBackupDestFileName = _sPackingBackupPathLocal + @"\" + _sBackupSrcFileName + "_" + "backup" + "_" + "temp" + ".ini";

            //try
            //{
            //    //创建不存在的Backup文件夹
            //    if (!Directory.Exists(_sPackingBackupPathLocal))
            //    {
            //        Directory.CreateDirectory(_sPackingBackupPathLocal);
            //    }
            //    File.Copy(_radarPackingInfoModel.RadarPackingIniFile, _sBackupDestFileName, true);
            //    //MsgBoxHelper.MsgBoxShow("Radar Packing配置文件: " + _radarPackingInfoModel.RadarPackingIniFile + "\n\n" + "备份成功，继续操作！","Packing");
            //    //btnOpenRadarPackingBackupFolder.Visible = true;
            //}
            //catch (Exception ex)
            //{
            //    MsgBoxHelper.MsgBoxError("Radar Packing配置文件: " + _radarPackingInfoModel.RadarPackingIniFile + "\n\n" + "备份失败，不能继续操作！" + "\n\n" + ex.Message);
            //    return;
            //    //throw ex;
            //}

            Action act = () =>
            {
                //获取当前窗体的Tag值
                if (null != this.Tag)
                {
                    _radarPackingInfoModel = this.Tag as RadarPackingInfoModel;

                    if (null != _radarPackingInfoModel.RadarPackingIniModel)
                    {
                        //初始化Template（包装标签模板）
                        comboBox_Template.Items.AddRange(_sRadarPackingTemplate.Split(','));

                        //根据ActType，窗口标题栏显示对应的操作
                        switch (_radarPackingInfoModel.ActType)
                        {
                            case 1:
                                this.Text += " - " + "<在上一行新加>";
                                break;
                            case 2:
                                this.Text += " - " + "<在下一行新加>";
                                break;
                            case 3:
                                this.Text += " - " + "<复制>";
                                break;
                            case 4:
                                this.Text += " - " + "<复制 / 在下一行粘贴>";
                                break;
                            case 5:
                                this.Text += " - " + "<复制 / 在下一行粘贴>";
                                break;
                            case 6:
                                this.Text += " - " + "<修改>";

                                //将从DataGridView中获取的Packing Info设置到窗体
                                SetPackingInfoToForm(_radarPackingInfoModel.RadarPackingIniModel);
                                break;
                            case 7:
                                this.Text += " - " + "<删除>";

                                //将从DataGridView中获取的Packing Info设置到窗体
                                SetPackingInfoToForm(_radarPackingInfoModel.RadarPackingIniModel);

                                textBox_ShippingPN.Enabled = false;
                                textBox_VehiclePN.Enabled = false;
                                textBox_CustomerPN.Enabled = false;
                                textBox_SupplierCode.Enabled = false;
                                textBox_Qty.Enabled = false;
                                textBox_Description.Enabled = false;
                                textBox_BoxNr.Enabled = false;
                                textBox_SNl.Enabled = false;
                                textBox_FixtureNo.Enabled = false;
                                comboBox_Template.Enabled = false;
                                break;
                            default:
                                break;
                        }
                    }
                }
            };

            act.TryCatchInvoke("Loading Form error!\n\n页面加载异常！");
        }

        /// <summary>
        /// DataGridView显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewWI_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dataGridViewWI_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridViewWI.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridViewWI.ClearSelection();
                        dataGridViewWI.Rows[e.RowIndex].Selected = true;
                    }

                    //只选中一行时设置活动单元格
                    if (dataGridViewWI.SelectedRows.Count == 1)
                    {
                        dataGridViewWI.CurrentCell = dataGridViewWI.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }

                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        /// <summary>
        /// 新加/修改/删除Packing信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPackingInfo_Click(object sender, EventArgs e)
        {
            //Packing信息输入合法性检查
            if (!CheckPackingInfoInputValid())
            {
                return;
            }

            //执行任何操作前，将原来的配置文件保存到本地路径下作为备份
            _sCurrentDate = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            _sBackupSrcFileNameTemp1 = _radarPackingInfoModel.RadarPackingIniFile.Substring(_radarPackingInfoModel.RadarPackingIniFile.LastIndexOf("\\") + 1);
            _sBackupSrcFileName = _sBackupSrcFileNameTemp1.Substring(0, _sBackupSrcFileNameTemp1.Length - ".ini".Length);
            _sBackupDestFileName = _sPackingBackupPathLocal + @"\" + _sBackupSrcFileName + "_" + "backup" + "_" + _sCurrentDate + ".ini";

            try
            {
                //创建不存在的Backup文件夹
                if (!Directory.Exists(_sPackingBackupPathLocal))
                {
                    Directory.CreateDirectory(_sPackingBackupPathLocal);
                }
                File.Copy(_radarPackingInfoModel.RadarPackingIniFile, _sBackupDestFileName, true);
                //MsgBoxHelper.MsgBoxShow("Radar Packing配置文件: " + _radarPackingInfoModel.RadarPackingIniFile + "\n\n" + "备份成功，继续操作！","Packing");
                //btnOpenRadarPackingBackupFolder.Visible = true;
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError("Radar Packing配置文件: " + _radarPackingInfoModel.RadarPackingIniFile + "\n\n" + "备份失败，不能继续操作！" + "\n\n" + ex.Message);
                return;
                //throw ex;
            }

            _lstPackingIniRead.Clear();
            switch (_radarPackingInfoModel.ActType)
            {
                case 1://在上一行新加

                    //TODO 功能未实现
                    //AddPackingAboveByNew();
                    MsgBoxHelper.MsgBoxError("功能未实现");
                    break;
                case 2://在下一行新加
                    AddPackingBelowByNew();
                    break;
                case 3://复制

                    break;
                case 4://复制 / 在上一行新加

                    break;
                case 5://复制 / 在下一行新加

                    break;
                case 6://修改
                    ModifyPacking();
                    break;
                case 7://删除
                    DeletePacking();
                    break;
            }
        }

        /// <summary>
        /// 打开Packing备份文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenRadarPackingBackupFolder_Click(object sender, EventArgs e)
        {
            Process.Start(_sPackingBackupPathLocal);
        }


        /// <summary>
        /// 加载Packing WI文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLoadPackingWI_Click(object sender, EventArgs e)
        {
            //使用浏览文件对话框，加载包装WI
            labelSelectPackingWI:
                OpenFileDialog openFile = new OpenFileDialog();
                //openFile.Filter = "All|*.*|Excel(*.xlsm)|*.xlsm|Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
                openFile.Filter = "Excel(*.xls,*.xlsx)|*.xls;*.xlsx";
                openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFile.Multiselect = false;
                if (openFile.ShowDialog() == DialogResult.Cancel)
                    return;
                string filePath = openFile.FileName;

            //string filePath = @"D:\TEST.xlsx";

            /*
             CFM-LT-SP2G16 GEELY BX11 KX11 HX11 CS11 V216 Radar Package WI - AB 三份.xlsx
             包装WI的名称中通常包含Package WI字样，通过判断选取的文件名称，确定该文件是否一个包装WI
            */
            if (!filePath.Contains("Package WI") && !filePath.Contains("PackageWI"))
            {
                if (DialogResult.No == MessageBox.Show(filePath + "\n\n确定该文件是一份包装WI吗?\n\n" + "Yes: 继续执行\n" + "No: 重新选择", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    //MsgBoxHelper.MsgBoxShow("请重新选择！", "Packing");
                    goto labelSelectPackingWI;
                    //return;
                }
            }

            btnLoadPackingWI.Enabled = false;

            await Task.Run(() =>
            {
                _lstRadarPackingWIModel = ReadRadarPackingWIFile(filePath);
            });

            btnLoadPackingWI.Enabled = true;

            if (null != _lstRadarPackingWIModel)
            {
                //将读取出来的包装信息绑定到DataGridView
                dataGridViewWI.DataSource = _lstRadarPackingWIModel;

                //隔行变色
                dataGridViewWI.RowsDefaultCellStyle.BackColor = default;
                dataGridViewWI.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

                //标题栏字体加粗
                dataGridViewWI.EnableHeadersVisualStyles = false;
                dataGridViewWI.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);

                //指定行字体加粗
                dataGridViewWI.Rows[0].DefaultCellStyle.Font = new Font(dataGridViewWI.Font, FontStyle.Bold);
                dataGridViewWI.Rows[1].DefaultCellStyle.Font = new Font(dataGridViewWI.Font, FontStyle.Bold);

                // 固定行
                dataGridViewWI.Rows[1].Frozen = true;

                dataGridViewWI.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);//行自适应
                dataGridViewWI.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);//列自适应
            }
            else
            {
                MsgBoxHelper.MsgBoxError("获取包装WI信息出错！");
            }
        }


        /// <summary>
        /// 右键菜单 - 从WI中配置包装信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBoxConfigFromWI_Click(object sender, EventArgs e)
        {
            if (dataGridViewWI.Rows.Count == 0)
            {
                MsgBoxHelper.MsgBoxShow("请先加载包装WI！", "Packing WI");
                return;
            }

            //根据包装WI的配置操作只适用于：在上一行新加 / 在下一行新加
            if (_radarPackingInfoModel.ActType != 1 && _radarPackingInfoModel.ActType != 2)
            {
                MsgBoxHelper.MsgBoxShow("配置只适用于新加操作！", "Packing WI");
                return;
            }

            DataGridViewRow row = dataGridViewWI.SelectedRows[0];//获取选中的行
            RadarPackingWIModel radarPackingIniModel = row.DataBoundItem as RadarPackingWIModel;//将当前行绑定的数据转换为实体类

            //将包装WI的信息加载到控件
            textBox_ShippingPN.Text = radarPackingIniModel.ColAShippingPN;
            textBox_CustomerPN.Text = radarPackingIniModel.ColBCustomerPN;
            textBox_SupplierCode.Text = radarPackingIniModel.ColCSupplierCode;
            textBox_Qty.Text = radarPackingIniModel.ColDQty;
            textBox_Description.Text = radarPackingIniModel.ColEDescription;
            textBox_BoxNr.Text = radarPackingIniModel.ColFPackingBox;
        }


        /// <summary>
        /// 测试输入Packing Info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestInputPackingInfo_Click(object sender, EventArgs e)
        {
            textBox_ShippingPN.Text = "1234567890";
            textBox_VehiclePN.Text = "680404902F";
            textBox_CustomerPN.Text = "12612886-00";
            textBox_SupplierCode.Text = "142857";
            textBox_Qty.Text = "98";
            textBox_Description.Text = "Description";
            textBox_BoxNr.Text = "P680619100A";
            textBox_BoxNrLen.Text = textBox_BoxNr.Text.Trim().Length.ToString();
            textBox_SNl.Text = "19";
            textBox_FixtureNo.Text = "0";
            comboBox_Template.SelectedIndex = 0;
        }

        /// <summary>
        /// 包装箱条码改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_BoxNr_TextChanged(object sender, EventArgs e)
        {
            //当包装箱条码改变了，需要重新计算并设置包装箱条码长度的值
            textBox_BoxNrLen.Text = textBox_BoxNr.Text.Trim().Length.ToString();
        }

        private void tsBtnHelp_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Close" + " ？", "Info", 2))
            {
                this.CloseForm();
            }
        }

        #endregion





        #region 方法
        /// <summary>
        /// 检查Packing输入信息框是否有效
        /// </summary>
        private bool CheckPackingInfoInputValid()
        {
            if (string.IsNullOrEmpty(textBox_ShippingPN.Text.Trim()))
            {
                MsgBoxHelper.MsgBoxError("请输入Shipping号！");
                return false;
            }

            if (string.IsNullOrEmpty(textBox_VehiclePN.Text.Trim()))
            {
                MsgBoxHelper.MsgBoxError("请输入Veh号！");
                return false;
            }

            if (string.IsNullOrEmpty(textBox_CustomerPN.Text.Trim()))
            {
                MsgBoxHelper.MsgBoxError("请输入客户料号！");
                return false;
            }

            if (string.IsNullOrEmpty(textBox_SupplierCode.Text.Trim()))
            {
                MsgBoxHelper.MsgBoxError("请输入供应商代码！");
                return false;
            }

            if (string.IsNullOrEmpty(textBox_Qty.Text.Trim()))
            {
                MsgBoxHelper.MsgBoxError("请输入数量！");
                return false;
            }

            if (string.IsNullOrEmpty(textBox_Description.Text.Trim()))
            {
                MsgBoxHelper.MsgBoxError("请输入描述！");
                return false;
            }

            if (string.IsNullOrEmpty(textBox_BoxNr.Text.Trim()))
            {
                MsgBoxHelper.MsgBoxError("请输入包装箱条码！");
                return false;
            }

            if (string.IsNullOrEmpty(textBox_SNl.Text.Trim()))
            {
                MsgBoxHelper.MsgBoxError("请输入产品标签二维码长度！");
                return false;
            }

            if (comboBox_Template.SelectedIndex == -1)
            {
                MsgBoxHelper.MsgBoxError("请输入包装标签模板！");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 在上一行新加
        /// </summary>
        private void AddPackingAboveByNew()
        {
            List<string> lstPackingIniInsert = new List<string>();

            int iPackingIniSelectedIndex = 0;//从DataGridView中选中的包装配置的index
            int iPackingIniSelectedNextIndex = -1;//从DataGridView中选中的包装配置的下一个配置的index
            int iPackingIniInsertIndex = 0;//待插入Packing ini文件中的该包装的index

            try
            {
                StreamReader sr = new StreamReader(_radarPackingInfoModel.RadarPackingIniFile, Encoding.Default);
                string line;
                while (null != (line = sr.ReadLine()))
                {
                    _lstPackingIniRead.Add(line);
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError("Exception:" + "\n" + "FrmRadarPackingInfo - AddPackingBelowByNew()读取Packing配置文件错误！");
                throw ex;
            }

            //检查新添加的Shipping号是否在当前配置文件中已存在？
            if (_lstPackingIniRead.Contains("[" + textBox_ShippingPN.Text.Trim() + "]"))
            {
                MsgBoxHelper.MsgBoxError("Shipping号: " + textBox_ShippingPN.Text.Trim() + " " + "已存在，不能重复添加！");
                return;
            }

            //从DataGridView中选中的包装配置的index
            iPackingIniSelectedIndex = _lstPackingIniRead.FindIndex(s => s.Contains(_radarPackingInfoModel.RadarPackingIniModel.Shipping));

            //从DataGridView中选中的包装配置的下一个配置的index
            for (int i = iPackingIniSelectedIndex + 1; i < _lstPackingIniRead.Count; i++)
            {
                if (_lstPackingIniRead[i].StartsWith("[") && _lstPackingIniRead[i].EndsWith("]"))
                {
                    iPackingIniSelectedNextIndex = i;
                    break;
                }
            }
            //如果当前选中的是最后一个Section，那么下一个Section的index = 选中的Section的index + 它的key数量
            if (iPackingIniSelectedNextIndex == -1)
            {
                iPackingIniSelectedNextIndex = iPackingIniSelectedIndex + _radarPackingInfoModel.RadarPackingSelectedKeyCounts;
            }

            //待插入Packing ini文件中的该包装的index = 选中的Section的index + 它的key数量 + 1
            iPackingIniInsertIndex = iPackingIniSelectedIndex + _radarPackingInfoModel.RadarPackingSelectedKeyCounts + 1;

            //构建待插入的包装配置
            lstPackingIniInsert.Add("");
            lstPackingIniInsert.Add("[" + textBox_ShippingPN.Text.Trim() + "]");
            lstPackingIniInsert.Add("Supplier=" + textBox_SupplierCode.Text.Trim());
            lstPackingIniInsert.Add("CustomerPN=" + textBox_CustomerPN.Text.Trim());
            lstPackingIniInsert.Add("Description=" + textBox_Description.Text.Trim());
            lstPackingIniInsert.Add("Qty=" + textBox_Qty.Text.Trim());
            lstPackingIniInsert.Add("BoxNr=" + textBox_BoxNr.Text.Trim());
            lstPackingIniInsert.Add("BoxNrlen=" + textBox_BoxNr.Text.Length);
            lstPackingIniInsert.Add("Lbtype=0");
            lstPackingIniInsert.Add("SNl=" + textBox_SNl.Text.Trim());
            lstPackingIniInsert.Add("Template=" + comboBox_Template.Text);
            lstPackingIniInsert.Add("VehiclePN=" + textBox_VehiclePN.Text.Trim());
            lstPackingIniInsert.Add("Weight=0");
            lstPackingIniInsert.Add("BoxPosition=0");
            lstPackingIniInsert.Add("BoxRequire=0");
            lstPackingIniInsert.Add("PartCode=0");
            lstPackingIniInsert.Add("FixtureNo=" + textBox_FixtureNo.Text.Trim());
            //判断当前选中的Section和下一个Section中间是否有空行，以此来判断插入的末尾是否需要空行
            if (iPackingIniSelectedNextIndex == iPackingIniInsertIndex)
            {
                //两个Section中间没有空行
                lstPackingIniInsert.Add("");
            }

            //新包装配置插入List
            _lstPackingIniRead.InsertRange(iPackingIniInsertIndex, lstPackingIniInsert);

            try
            {
                FileStream fs = new FileStream(_radarPackingInfoModel.RadarPackingIniFile, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.Flush();
                sw.BaseStream.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < _lstPackingIniRead.Count; i++)
                {
                    sw.WriteLine(_lstPackingIniRead[i]);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError("Exception:" + "\n" + "FrmRadarPackingInfo - AddPackingBelowByNew()写入Packing配置文件错误！");
                throw ex;
            }

            _radarPackingInfoModel.CheckRadarPackingInfoIsDo?.Invoke();
            _radarPackingInfoModel.ReLoadTask?.Invoke();
            this.Close();
        }


        /// <summary>
        /// 在下一行新加
        /// </summary>
        private void AddPackingBelowByNew()
        {
            List<string> lstPackingIniInsert = new List<string>();

            int iPackingIniSelectedIndex = 0;//从DataGridView中选中的包装配置的index
            int iPackingIniSelectedNextIndex = -1;//从DataGridView中选中的包装配置的下一个配置的index
            int iPackingIniInsertIndex = 0;//待插入Packing ini文件中的该包装的index

            try
            {
                StreamReader sr = new StreamReader(_radarPackingInfoModel.RadarPackingIniFile, Encoding.Default);
                string line;
                while (null != (line = sr.ReadLine()))
                {
                    _lstPackingIniRead.Add(line);
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError("Exception:" + "\n" + "FrmRadarPackingInfo - AddPackingBelowByNew()读取Packing配置文件错误！");
                throw ex;
            }

            //检查新添加的Shipping号是否在当前配置文件中已存在？
            if (_lstPackingIniRead.Contains("[" + textBox_ShippingPN.Text.Trim() + "]"))
            {
                MsgBoxHelper.MsgBoxError("Shipping号: " + textBox_ShippingPN.Text.Trim() + " " + "已存在，不能重复添加！");
                return;
            }

            //从DataGridView中选中的包装配置的index
            iPackingIniSelectedIndex = _lstPackingIniRead.FindIndex(s => s.Contains(_radarPackingInfoModel.RadarPackingIniModel.Shipping));

            //从DataGridView中选中的包装配置的下一个配置的index
            for (int i = iPackingIniSelectedIndex + 1; i < _lstPackingIniRead.Count; i++)
            {
                if (_lstPackingIniRead[i].StartsWith("[") && _lstPackingIniRead[i].EndsWith("]"))
                {
                    iPackingIniSelectedNextIndex = i;
                    break;
                }
            }
            //如果当前选中的是最后一个Section，那么下一个Section的index = 选中的Section的index + 它的key数量
            if (iPackingIniSelectedNextIndex == -1)
            {
                iPackingIniSelectedNextIndex = iPackingIniSelectedIndex + _radarPackingInfoModel.RadarPackingSelectedKeyCounts;
            }

            //待插入Packing ini文件中的该包装的index = 选中的Section的index + 它的key数量 + 1
            iPackingIniInsertIndex = iPackingIniSelectedIndex + _radarPackingInfoModel.RadarPackingSelectedKeyCounts + 1;

            //构建待插入的包装配置
            lstPackingIniInsert.Add("");
            lstPackingIniInsert.Add("[" + textBox_ShippingPN.Text.Trim() + "]");
            lstPackingIniInsert.Add("Supplier=" + textBox_SupplierCode.Text.Trim());
            lstPackingIniInsert.Add("CustomerPN=" + textBox_CustomerPN.Text.Trim());
            lstPackingIniInsert.Add("Description=" + textBox_Description.Text.Trim());
            lstPackingIniInsert.Add("Qty=" + textBox_Qty.Text.Trim());
            lstPackingIniInsert.Add("BoxNr=" + textBox_BoxNr.Text.Trim());
            lstPackingIniInsert.Add("BoxNrlen=" + textBox_BoxNr.Text.Length);
            lstPackingIniInsert.Add("Lbtype=0");
            lstPackingIniInsert.Add("SNl=" + textBox_SNl.Text.Trim());
            lstPackingIniInsert.Add("Template=" + comboBox_Template.Text);
            lstPackingIniInsert.Add("VehiclePN=" + textBox_VehiclePN.Text.Trim());
            lstPackingIniInsert.Add("Weight=0");
            lstPackingIniInsert.Add("BoxPosition=0");
            lstPackingIniInsert.Add("BoxRequire=0");
            lstPackingIniInsert.Add("PartCode=0");
            lstPackingIniInsert.Add("FixtureNo=" + textBox_FixtureNo.Text.Trim());
            //判断当前选中的Section和下一个Section中间是否有空行，以此来判断插入的末尾是否需要空行
            if (iPackingIniSelectedNextIndex == iPackingIniInsertIndex)
            {
                //两个Section中间没有空行
                lstPackingIniInsert.Add("");
            }

            //新包装配置插入List
            _lstPackingIniRead.InsertRange(iPackingIniInsertIndex, lstPackingIniInsert);

            try
            {
                FileStream fs = new FileStream(_radarPackingInfoModel.RadarPackingIniFile, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.Flush();
                sw.BaseStream.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < _lstPackingIniRead.Count; i++)
                {
                    sw.WriteLine(_lstPackingIniRead[i]);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError("Exception:" + "\n" + "FrmRadarPackingInfo - AddPackingBelowByNew()写入Packing配置文件错误！");
                throw ex;
            }

            _radarPackingInfoModel.CheckRadarPackingInfoIsDo?.Invoke();
            _radarPackingInfoModel.ReLoadTask?.Invoke();
            this.Close();
        }


        /// <summary>
        /// 修改包装信息
        /// </summary>
        private void ModifyPacking()
        {
            int iPackingIniSelectedIndex = 0;//从DataGridView中选中的包装配置的index
            int iPackingIniSectionMultiple = 0;

            try
            {
                StreamReader sr = new StreamReader(_radarPackingInfoModel.RadarPackingIniFile, Encoding.Default);
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

            //检查新添加的Shipping号是否在当前配置文件中已存在？
            for (int i = 0; i < _lstPackingIniRead.Count; i++)
            {
                if (_lstPackingIniRead[i].Contains("[" + textBox_ShippingPN.Text.Trim() + "]"))
                {
                    iPackingIniSectionMultiple++;
                }
            }

            if (iPackingIniSectionMultiple > 1)
            {
                MsgBoxHelper.MsgBoxError("Shipping号: " + textBox_ShippingPN.Text.Trim() + " " + "已存在，不能重复定义！");
                return;
            }

            //从DataGridView中选中的包装配置的index
            //iPackingIniSelectedIndex = _lstPackingIniRead.FindIndex(s => s.Contains(_radarPackingInfoModel.RadarPackingIniModel.Shipping));
            for (int i = 0, j = -1; i < _lstPackingIniRead.Count; i++)
            {
                if (_lstPackingIniRead[i].StartsWith("[") && _lstPackingIniRead[i].EndsWith("]"))//判断这是一个Section
                {
                    j++;
                }
                if (j == _radarPackingInfoModel.RadarPackingSelectedSectionNum)
                {
                    iPackingIniSelectedIndex = i;
                    break;
                }
            }

            //根据窗体上新的Packing信息，替换List中原来的信息，然后重新写入到文件中
            //iPackingIniSelectedIndex，这个index指向的位置是当前选中的Shipping号
            //lstPackingIniRead[iPackingIniSelectedIndex] = textBox_ShippingPN.Text.Trim();//Shipping号
            for (int i = iPackingIniSelectedIndex; i <= iPackingIniSelectedIndex + _radarPackingInfoModel.RadarPackingSelectedKeyCounts; i++)
            {
                if (_lstPackingIniRead[i].StartsWith("[") && _lstPackingIniRead[i].EndsWith("]"))
                {
                    _lstPackingIniRead[i] = "[" + textBox_ShippingPN.Text.Trim() + "]";
                }
                else if (_lstPackingIniRead[i].StartsWith("Supplier"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_SupplierCode.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("CustomerPN"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_CustomerPN.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("Description"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_Description.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("Qty"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_Qty.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("BoxNr"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_BoxNr.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("SNl"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_SNl.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("Template"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + comboBox_Template.Text;
                }
                else if (_lstPackingIniRead[i].StartsWith("VehiclePN"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_VehiclePN.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("FixtureNo"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_FixtureNo.Text.Trim();
                }
            }

            //将新配置重新写入到文件中
            try
            {
                FileStream fs = new FileStream(_radarPackingInfoModel.RadarPackingIniFile, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.Flush();
                sw.BaseStream.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < _lstPackingIniRead.Count; i++)
                {
                    sw.WriteLine(_lstPackingIniRead[i]);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError("Exception:" + "\n" + "FrmRadarPackingInfo - ModifyPacking()写入Packing配置文件错误！");
                throw ex;
            }

            _radarPackingInfoModel.CheckRadarPackingInfoIsDo?.Invoke();
            _radarPackingInfoModel.ReLoadTask?.Invoke();
            this.Close();
        }


        /// <summary>
        /// 删除包装信息
        /// </summary>
        private void DeletePacking()
        {
            int iPackingIniSelectedIndex = 0;//从DataGridView中选中的包装配置的index
            int iPackingIniSectionMultiple = 0;

            StringCollection lstIniAfterDelete = new StringCollection();

            try
            {
                StreamReader sr = new StreamReader(_radarPackingInfoModel.RadarPackingIniFile, Encoding.Default);
                string line;
                while (null != (line = sr.ReadLine()))
                {
                    _lstPackingIniRead.Add(line);
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError("Exception:" + "\n" + ex.Message);
                throw ex;
            }

            //检查新添加的Shipping号是否在当前配置文件中已存在？
            //for (int i = 0; i < _lstPackingIniRead.Count; i++)
            //{
            //    if (_lstPackingIniRead[i].Contains("[" + textBox_ShippingPN.Text.Trim() + "]"))
            //    {
            //        iPackingIniSectionMultiple++;
            //    }
            //}

            //if (iPackingIniSectionMultiple > 1)
            //{
            //    MsgBoxHelper.MsgBoxError("Shipping号: " + textBox_ShippingPN.Text.Trim() + " " + "已存在，请修改！");
            //    return;
            //}

            //从DataGridView中选中的包装配置的index
            //iPackingIniSelectedIndex = _lstPackingIniRead.FindIndex(s => s.Contains(_radarPackingInfoModel.RadarPackingIniModel.Shipping));
            for (int i = 0, j = -1; i < _lstPackingIniRead.Count; i++)
            {
                if (_lstPackingIniRead[i].StartsWith("[") && _lstPackingIniRead[i].EndsWith("]"))//判断这是一个Section
                {
                    j++;
                }
                if (j == _radarPackingInfoModel.RadarPackingSelectedSectionNum)
                {
                    iPackingIniSelectedIndex = i;
                    break;
                }
            }

            //根据窗体上新的Packing信息，替换List中原来的信息，然后重新写入到文件中
            //iPackingIniSelectedIndex，这个index指向的位置是当前选中的Shipping号
            //lstPackingIniRead[iPackingIniSelectedIndex] = textBox_ShippingPN.Text.Trim();//Shipping号
            for (int i = iPackingIniSelectedIndex; i <= iPackingIniSelectedIndex + _radarPackingInfoModel.RadarPackingSelectedKeyCounts; i++)
            {
                if (_lstPackingIniRead[i].StartsWith("[") && _lstPackingIniRead[i].EndsWith("]"))
                {
                    //_lstPackingIniRead[i] = "[" + textBox_ShippingPN.Text.Trim() + "]";
                    _lstPackingIniRead[i] = "[" + textBox_ShippingPN.Text.Trim() + "_delete" + "]";
                }
                else if (_lstPackingIniRead[i].StartsWith("Supplier"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_SupplierCode.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("CustomerPN"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_CustomerPN.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("Description"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_Description.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("Qty"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_Qty.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("BoxNr"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_BoxNr.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("SNl"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_SNl.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("Template"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + comboBox_Template.Text;
                }
                else if (_lstPackingIniRead[i].StartsWith("VehiclePN"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_VehiclePN.Text.Trim();
                }
                else if (_lstPackingIniRead[i].StartsWith("FixtureNo"))
                {
                    _lstPackingIniRead[i] = _lstPackingIniRead[i].Substring(0, _lstPackingIniRead[i].IndexOf("=") + 1) + textBox_FixtureNo.Text.Trim();
                }
            }

            //将新配置重新写入到文件中
            try
            {
                FileStream fs = new FileStream(_radarPackingInfoModel.RadarPackingIniFile, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.Flush();
                sw.BaseStream.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < _lstPackingIniRead.Count; i++)
                {
                    sw.WriteLine(_lstPackingIniRead[i]);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError("Exception:" + "\n" + ex.Message);
                throw ex;
            }

            _iniHelper2 = new IniHelper2(_radarPackingInfoModel.RadarPackingIniFile);
            _iniHelper2.EraseSection(textBox_ShippingPN.Text.Trim() + "_delete");

            //删除之后再次读取该Section，如果返回list的count大于0，则表示该Section还存在，提示删除失败
            //_iniHelper2.ReadSection(textBox_ShippingPN.Text.Trim() + "_delete", lstIniAfterDelete);
            //if (lstIniAfterDelete.Count == 0)
            //{
            //    _radarPackingInfoModel.CheckRadarPackingInfoIsDo?.Invoke();
            //    MsgBoxHelper.MsgBoxError("Section: " + textBox_ShippingPN.Text.Trim() + "删除失败！");
            //}

            _radarPackingInfoModel.CheckRadarPackingInfoIsDo?.Invoke();
            _radarPackingInfoModel.ReLoadTask?.Invoke();
            this.Close();
        }


        /// <summary>
        /// 根据RadarPackingIniModel，设置Packing Info到窗体上
        /// </summary>
        /// <param name="radarPackingIniModel"></param>
        private void SetPackingInfoToForm(RadarPackingIniModel radarPackingIniModel)
        {
            textBox_ShippingPN.Text = radarPackingIniModel.SectionName.Trim();
            textBox_VehiclePN.Text = radarPackingIniModel.VehiclePN.Trim();
            textBox_CustomerPN.Text = radarPackingIniModel.CustomerPN.Trim();
            textBox_SupplierCode.Text = radarPackingIniModel.Supplier.Trim();
            textBox_Qty.Text = radarPackingIniModel.Qty.Trim();
            textBox_Description.Text = radarPackingIniModel.Description.Trim();
            textBox_BoxNr.Text = radarPackingIniModel.BoxNr.Trim();
            textBox_SNl.Text = radarPackingIniModel.SNl.Trim();
            textBox_FixtureNo.Text = radarPackingIniModel.FixtureNo.Trim();

            string[] sArrRadarPackingTemplate = _sRadarPackingTemplate.Split(',');
            for (int i = 0; i < sArrRadarPackingTemplate.Length; i++)
            {
                if (sArrRadarPackingTemplate[i] == radarPackingIniModel.Template.Trim())
                {
                    comboBox_Template.SelectedIndex = i;
                }
            }

            if (comboBox_Template.SelectedIndex == -1)
            {
                MsgBoxHelper.MsgBoxError("Template: " + radarPackingIniModel.Template + " 不存在！\n\n不允许修改！");
                comboBox_Template.Enabled = false;
                btnAddPackingInfo.Enabled = false;
            }
            else
            {
                comboBox_Template.Enabled = true;
                btnAddPackingInfo.Enabled = true;
            }

            //switch (radarPackingIniModel.Template.Trim())
            //{
            //    case "Radar77_S.xls":
            //        comboBox_Template.SelectedIndex = 0;
            //        break;
            //    case "China CV7.xls":
            //        comboBox_Template.SelectedIndex = 1;
            //        break;
            //    default:
            //        MsgBoxHelper.MsgBoxError("Template: " + radarPackingIniModel.Template + " 不存在！");
            //        break;
            //}
        }


        /// <summary>
        /// 读取Packing WI文件
        /// </summary>
        /// <param name="filePath"></param>
        public List<RadarPackingWIModel> ReadRadarPackingWIFile(string filePath)
        {
            IWorkbook wk = null;
            string extension = System.IO.Path.GetExtension(filePath);
            List<RadarPackingWIModel> radarPackingWIModels = null;

            try
            {
                FileStream fs = File.OpenRead(filePath);
                if (extension.Equals(".xls"))
                {
                    //把xls文件中的数据写入wk中
                    wk = new HSSFWorkbook(fs);
                }
                else
                {
                    //把xlsx文件中的数据写入wk中
                    wk = new XSSFWorkbook(fs);
                }

                fs.Close();

                //读取当前表数据
                ISheet sheet = wk.GetSheetAt(wk.GetSheetIndex("Sheet1"));//WI中的包装配置信息始终写在Sheet1表中

                IRow row = sheet.GetRow(2);  //读取当前行数据: 包装信息页中的标题数据
                                             //LastRowNum 是当前表的总行数-1（注意）
                                             //int offset = 0;

                //根据包装信息页中的标题数据，判断包装信息的列是否符合程序的定义
                if
                (
                    !row.GetCell(1).ToString().Contains("Shipping号") ||
                    !row.GetCell(2).ToString().Contains("客户料号") ||
                    !row.GetCell(3).ToString().Contains("供应商代码") ||
                    !row.GetCell(4).ToString().Contains("数量") ||
                    !row.GetCell(5).ToString().Contains("描述") ||
                    !row.GetCell(6).ToString().Contains("包装箱")
                )
                {
                    MsgBoxHelper.MsgBoxError(
                        "请确认WI中包装信息页的标题定义是否正确?\n\n" +
                        "3行2列：Shipping号\n" +
                        "3行3列：客户料号\n" +
                        "3行4列：供应商代码\n" +
                        "3行5列：数量\n" +
                        "3行6列：描述\n" +
                        "3行7列：包装箱\n"
                        );
                    return null;
                }

                radarPackingWIModels = new List<RadarPackingWIModel>();

                //读取包装信息
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    RadarPackingWIModel radarPackingWIModel = new RadarPackingWIModel();
                    row = sheet.GetRow(i);  //读取当前行数据
                    if (row != null)
                    {
                        //LastCellNum 是当前行的总列数
                        for (int j = 1; j < row.LastCellNum; j++)
                        {
                            //读取该行的第j列数据
                            string value = row.GetCell(j).ToString();

                            switch (j)
                            {
                                case 1:
                                    radarPackingWIModel.ColAShippingPN = value;
                                    break;
                                case 2:
                                    radarPackingWIModel.ColBCustomerPN = value;
                                    break;
                                case 3:
                                    radarPackingWIModel.ColCSupplierCode = value;
                                    break;
                                case 4:
                                    radarPackingWIModel.ColDQty = value;
                                    break;
                                case 5:
                                    radarPackingWIModel.ColEDescription = value;
                                    break;
                                case 6:
                                    radarPackingWIModel.ColFPackingBox = value;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    radarPackingWIModels.Add(radarPackingWIModel);
                }
            }
            catch (Exception ex)
            {
                //只在Debug模式下才输出
                //Console.WriteLine(ex.Message);

                if (ex.Message.Contains("Sheet index (-1) is out of range"))
                {
                    MsgBoxHelper.MsgBoxError("请确认WI中包装信息页的名称是否是Sheet1?");
                }
                else
                {
                    MsgBoxHelper.MsgBoxError(ex.Message);
                }
            }

            return radarPackingWIModels;
        }

        #endregion




        private void btnDebug_Click(object sender, EventArgs e)
        {
            MsgBoxHelper.MsgBoxError("NA");
            //comboBox_Template.SelectedIndex = -1;
        }
    }
}
