using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using PMS.COMMON.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Action = System.Action;
using DataTable = System.Data.DataTable;

namespace WinPMS.Debug
{
    public partial class FrmDebugRadar2SELRecipe : Form
    {
        public FrmDebugRadar2SELRecipe()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public readonly IntPtr HFILE_ERROR = new IntPtr(-1);

        private string _sTestFilesVehNoFolder;//Veh号所在文件夹
        private string _sVehNo;//Veh号
        private string _sMasterFilePath;//MasterFile文件
        private string _sMasterFilePathOpen;//MasterFile文件，用于C#程序读的路径
        private string _sTempIniFile = Path.Combine(FileHelper.sExeFolderPath, @"Config\RecipeTemplate\Temp.ini");//临时生成的Recipe文件

        private List<string> _listFileInVehNoFolder = new List<string>();//Veh号所在文件夹下的所有文件
        private List<RDRSELRecipeKeyValue> _listRecipeKeyValveDgv = new List<RDRSELRecipeKeyValue>();
        private List<RDRSELRecipeKeyValue> _listRecipeKeyValueWriteIni = new List<RDRSELRecipeKeyValue>();
        private List<string> _listTabKeyCount = new List<string>();
        //private List<string> listSpaceKeyCount = new List<string>();

        private RDRSELRecipeMasterFile _rdrSELRecipeMasterFile = new RDRSELRecipeMasterFile();
        private RDRSELRecipePLM _rdrSELRecipePLM = new RDRSELRecipePLM();



        #region 事件
        private void FrmDebugRadar2SELRecipe_Load(object sender, EventArgs e)
        {
            Action act = new Action(() =>
            {
                InitInfo();
            });
            act.TryCatchInvoke("Exception on Init FrmDebugRadar2SELRecipe");
        }


        /// <summary>
        /// 加载Veh号所在的文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoadVehNoFolder_Click(object sender, EventArgs e)
        {
            string sFileName;

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select TestFiles folder of Veh No...";

            dialog.SelectedPath = txt_TestFilesFolderVehNo.Text;

            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }

            //通过文件选择框，获取项目对应的Veh号所在文件夹
            //A:\TesterFiles\Chery\681923300B
            _sTestFilesVehNoFolder = dialog.SelectedPath.Trim();

            //获取对应的Veh号
            //681923300B
            _sVehNo = _sTestFilesVehNoFolder.Substring(_sTestFilesVehNoFolder.LastIndexOf("\\") + 1);

            //获取Veh号文件下的所有文件
            _listFileInVehNoFolder.Clear();
            UtilityHelper.RecursionDir(_listFileInVehNoFolder, new DirectoryInfo(_sTestFilesVehNoFolder), false);

            txt_TestFilesFolderVehNo.Text = _sTestFilesVehNoFolder;
            txt_VehNo.Text = _sVehNo;


            btn_Test.Items.Clear();
            foreach (string fileFullPath in _listFileInVehNoFolder)
            {
                sFileName = fileFullPath.Substring(fileFullPath.LastIndexOf("\\") + 1);
                btn_Test.Items.Add(sFileName);

                //获取Revision_.txt
                if
                (
                    (Path.GetExtension(fileFullPath).ToLower() == ".txt") &&
                    sFileName.StartsWith("Revision_") &&
                    string.IsNullOrEmpty(_rdrSELRecipePLM.RevisionFile)
                )
                {
                    _rdrSELRecipePLM.RevisionFile = fileFullPath;
                }

                //获取NVM_.xtf
                if
                (
                    (Path.GetExtension(fileFullPath).ToLower() == ".xtf") &&
                    sFileName.StartsWith("NVM_") &&
                    string.IsNullOrEmpty(_rdrSELRecipePLM.NvmFile)
                )
                {
                    _rdrSELRecipePLM.NvmFile = fileFullPath;
                }

                //获取Exclued NVM File.txt
                if
                (
                    (Path.GetExtension(fileFullPath).ToLower() == ".txt") &&
                    sFileName.StartsWith("Exclude NVM File") &&
                    string.IsNullOrEmpty(_rdrSELRecipePLM.NvmExcludeFile)
                )
                {
                    _rdrSELRecipePLM.NvmExcludeFile = fileFullPath;
                }

                //获取Core_PPAR_.xtf
                if
                (
                    (Path.GetExtension(fileFullPath).ToLower() == ".xtf") &&
                    sFileName.Substring(0, 9) == _sVehNo.Substring(0, 9) &&
                    string.IsNullOrEmpty(_rdrSELRecipePLM.CorePparFile)
                )
                {
                    _rdrSELRecipePLM.CorePparFile = fileFullPath;
                }

                //获取Exclued Core File.txt
                if
                (
                    (Path.GetExtension(fileFullPath).ToLower() == ".txt") &&
                    sFileName.StartsWith("Exclude Core File") &&
                    string.IsNullOrEmpty(_rdrSELRecipePLM.CorePparExcludeFile)
                )
                {
                    _rdrSELRecipePLM.CorePparExcludeFile = fileFullPath;
                }

                //获取AFT_.xtf
                if
                (
                    (Path.GetExtension(fileFullPath).ToLower() == ".xtf") &&
                    sFileName.StartsWith("AFT_PPAR_") &&
                    string.IsNullOrEmpty(_rdrSELRecipePLM.AftPparFile)
                )
                {
                    _rdrSELRecipePLM.AftPparFile = fileFullPath;
                }

                //获取Exclued Core File.txt
                if
                (
                    (Path.GetExtension(fileFullPath).ToLower() == ".txt") &&
                    sFileName.StartsWith("Exclude AFT File") &&
                    string.IsNullOrEmpty(_rdrSELRecipePLM.AftPparExcludeFile)
                )
                {
                    _rdrSELRecipePLM.AftPparExcludeFile = fileFullPath;
                }

                //获取_Fault_Mask.txt
                if
                (
                    (Path.GetExtension(fileFullPath).ToLower() == ".txt") &&
                    sFileName.Contains("_Fault_Mask") &&
                    string.IsNullOrEmpty(_rdrSELRecipePLM.FaultMaskFile)
                )
                {
                    _rdrSELRecipePLM.FaultMaskFile = fileFullPath;
                }

                //获取OEM File.cbt
                if
                (
                    (Path.GetExtension(fileFullPath).ToLower() == ".cbt") &&
                    //sFileName.Contains("") &&
                    string.IsNullOrEmpty(_rdrSELRecipePLM.OemFile)
                )
                {
                    _rdrSELRecipePLM.OemFile = fileFullPath;
                }

                //获取MasterFile文件
                if
                (
                    (
                        Path.GetExtension(fileFullPath).ToLower() == ".xls" ||
                        Path.GetExtension(fileFullPath).ToLower() == ".xlsx" ||
                        Path.GetExtension(fileFullPath).ToLower() == ".xlsm"
                    ) &&
                    (
                        sFileName.StartsWith("MasterFile") ||
                        sFileName.StartsWith("Master_File")
                    ) &&
                    string.IsNullOrEmpty(_sMasterFilePath)
                )
                {
                    _sMasterFilePath = fileFullPath;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SameAsVeh_Click(object sender, EventArgs e)
        {
            txt_ShippingBom.Text = txt_VehNo.Text;
        }


        /// <summary>
        /// 生成Recipe.ini
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Gen_Recipe_Click(object sender, EventArgs e)
        {
            string sLine;
            string sLineKey;
            string sLineValue;
            string sCustomer;
            string sRadarType;

            int iTabKeyCount = 0;
            //int iSpaceKeyCount = 0;

            #region 输入控件的合法性检查
            if (string.IsNullOrEmpty(txt_VehNo.Text))
            {
                MsgBoxHelper.MsgBoxError("Veh No is empty!");
                btn_LoadVehNoFolder.Focus();
                return;
            }

            if (combox_Gen.SelectedIndex < 0)
            {
                MsgBoxHelper.MsgBoxError("Select Gen!");
                combox_Gen.Focus();
                return;
            }

            if (combox_Customer.SelectedIndex < 0)
            {
                MsgBoxHelper.MsgBoxError("Select Customer!");
                combox_Customer.Focus();
                return;
            }

            if (txt_Model.Text == "Model")
            {
                MsgBoxHelper.MsgBoxError("Please input Model!");
                txt_Model.Focus();
                return;
            }

            if (combox_RadarType.SelectedIndex < 0)
            {
                MsgBoxHelper.MsgBoxError("Select RadarType!");
                combox_RadarType.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txt_PCBA.Text))
            {
                MsgBoxHelper.MsgBoxError("PCBA is empty!");
                txt_PCBA.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txt_Sensor_ID_Manu.Text))
            {
                MsgBoxHelper.MsgBoxError("SensorID Manu is empty!");
                txt_Sensor_ID_Manu.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txt_Sensor_ID_OEM.Text))
            {
                MsgBoxHelper.MsgBoxError("SensorID OEM is empty!");
                txt_Sensor_ID_OEM.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txt_ShippingBom.Text))
            {
                MsgBoxHelper.MsgBoxError("ShippingBom is empty!");
                txt_ShippingBom.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txt_HousingPN.Text))
            {
                MsgBoxHelper.MsgBoxError("HoustingPN is empty!");
                txt_HousingPN.Focus();
                return;
            }
            #endregion

            btn_GenRecipe.Enabled = false;

            try
            {
                //判断MasterFile (Excel文件)是否已打开？
                /*
                IntPtr vHandle = _lopen(_sMasterFilePath, OF_READWRITE | OF_SHARE_DENY_NONE);

                //Excel文件已打开，文件名前面会加"~$"前缀
                if (vHandle == HFILE_ERROR)
                {
                    //MsgBoxHelper.MsgBoxError(_sMasterFilePath + "\n" + "is open!");
                    //return;
                }
                else//Excel文件未打开
                {

                }
                CloseHandle(vHandle);     //判断之后一定要关闭！！！
                */

                _listRecipeKeyValveDgv.Clear();

                //读取Radar2_SEL_Recipe模板
                List<string> listRecipeTemplate = new List<string>(File.ReadAllLines(Path.Combine(FileHelper.sExeFolderPath, @"Config\RecipeTemplate\Radar2_SEL_Recipe_Temp_1.ini")));

                sCustomer = combox_Customer.Text;
                sRadarType = combox_RadarType.Text;
                await Task.Run(() =>
                {
                    //获取MasterFile值
                    GetMasterFileValueByCustomer(sCustomer, sRadarType);
                });

                //await Task.Run(() =>
                //{
                for (int i = 0; i < listRecipeTemplate.Count; i++)
                {
                    RDRSELRecipeKeyValue rdrSELRecipeKeyValue = new RDRSELRecipeKeyValue();

                    //[680404902N]
                    //Name = 680404902N
                    //Number = 0001
                    //Description = Radar 77GHZ G1.2 BYD HC FLR
                    sLine = listRecipeTemplate[i];

                    if (sLine.StartsWith("["))
                    {
                        rdrSELRecipeKeyValue.Key = sLine.Replace(sLine.Substring(1, sLine.Length - 2), _sVehNo);
                        rdrSELRecipeKeyValue.Value = "";
                    }
                    else
                    {
                        sLineKey = sLine.Substring(0, sLine.IndexOf("="));//Name
                        sLineValue = sLine.Substring(sLine.IndexOf("=") + 1);//					680404902N
                        iTabKeyCount = UtilityHelper.CountBySearch(sLineValue, "\t");//计算Value中的Tab键个数
                                                                                     //iSpaceKeyCount = UtilityHelper.CountBySearch(sLineValue, " ");//计算Value中的空格键个数

                        rdrSELRecipeKeyValue.Key = sLineKey.Trim();

                        switch (sLineKey)
                        {
                            case "Name":
                                rdrSELRecipeKeyValue.Value = _sVehNo;
                                break;
                            case "Description":
                                rdrSELRecipeKeyValue.Value = txt_RecipeDescPrefix.Text + " " + combox_Gen.Text + " " + combox_Customer.Text + " " + txt_Model.Text + " " + combox_RadarType.Text;
                                break;
                            case "Customer":
                                rdrSELRecipeKeyValue.Value = combox_Customer.Text;
                                break;
                            case "VeoneerPartNumber":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipeMasterFile.VeoneerPartNumber;
                                break;
                            case "CustomerPartNumber":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipeMasterFile.CustomerPartNumber;
                                break;
                            case "SNFormat":
                                rdrSELRecipeKeyValue.Value = txt_PCBA.Text.Trim();
                                break;
                            case "PROGRAMNAME":
                                if ("G1.2" == combox_Gen.Text)
                                {
                                    rdrSELRecipeKeyValue.Value = "Gen1.2";
                                }
                                else if ("G1.3" == combox_Gen.Text)
                                {
                                    rdrSELRecipeKeyValue.Value = "Gen1.3";
                                }
                                break;
                            case "SWLFIXTUREID":
                                if ("G1.2" == combox_Gen.Text)
                                {
                                    rdrSELRecipeKeyValue.Value = "3";
                                }
                                else if ("G1.3" == combox_Gen.Text)
                                {
                                    rdrSELRecipeKeyValue.Value = "2";
                                }
                                break;
                            case "EOLFIXTUREID":
                                if ("G1.2" == combox_Gen.Text)
                                {
                                    rdrSELRecipeKeyValue.Value = "3";
                                }
                                else if ("G1.3" == combox_Gen.Text)
                                {
                                    rdrSELRecipeKeyValue.Value = "2";
                                }
                                break;
                            case "SWLSENSORID":
                                rdrSELRecipeKeyValue.Value = txt_Sensor_ID_Manu.Text.Trim();
                                break;
                            case "EOLSENSORID":
                                rdrSELRecipeKeyValue.Value = txt_Sensor_ID_OEM.Text.Trim();
                                break;
                            case "SWLCONFIGFILE":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipePLM.RevisionFile;
                                break;
                            case "EOLCONFIGFILE":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipePLM.RevisionFile;
                                break;
                            case "NVMFILE":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipePLM.NvmFile;
                                break;
                            case "NVMCOMBOFILE":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipePLM.NvmExcludeFile;
                                break;
                            case "COREPPARADRFILE":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipePLM.CorePparFile;
                                break;
                            case "COREPPAREXCLUDEFILE":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipePLM.CorePparExcludeFile;
                                break;
                            case "AFTPPARADRFILE":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipePLM.AftPparFile;
                                break;
                            case "AFTPPAREXCLUDEFILE":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipePLM.AftPparExcludeFile;
                                break;
                            case "FAULTMASKFILE":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipePLM.FaultMaskFile;
                                break;
                            case "SWLOEMAPPFILE":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipePLM.OemFile;
                                break;
                            case "HardwarePN":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipeMasterFile.HardwareVersion;
                                break;
                            case "SoftwarePN":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipeMasterFile.SoftwareVersion;
                                break;
                            case "EEPROMFile":
                                rdrSELRecipeKeyValue.Value = _rdrSELRecipePLM.NvmFile;
                                break;
                            case "ShippingBOM":
                                rdrSELRecipeKeyValue.Value = txt_ShippingBom.Text.Trim();
                                break;
                            case "HousingPN":
                                rdrSELRecipeKeyValue.Value = txt_HousingPN.Text.Trim();
                                break;
                            default:
                                rdrSELRecipeKeyValue.Value = sLineValue.Trim();
                                break;
                        }
                    }

                    StringBuilder sb = new StringBuilder();
                    _listTabKeyCount.Add(sb.Append('\t', iTabKeyCount).ToString());//往List中添加Tab键个数
                                                                                   //listSpaceKeyCount.Add(sb.Append(' ', iTabKeyCount).ToString());//往List中添加空格键个数

                    _listRecipeKeyValveDgv.Add(rdrSELRecipeKeyValue);
                }
                //});
                //this.dgvRecipe.DataSource = null;
                this.dgvRecipe.DataSource = _listRecipeKeyValveDgv;

                WriteRecipeTempIni();

                btn_GenRecipe.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error！" + "\n" + ex.Message);
            }
        }


        /// <summary>
        /// 打开临时生成的Recipe -> Temp.ini
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenRecipe_Click(object sender, EventArgs e)
        {
            Process.Start(_sTempIniFile);
        }


        private void dgvRecipe_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dgvRecipe.ClearSelection();
                    dgvRecipe.Rows[e.RowIndex].Selected = true;
                    dgvRecipe.CurrentCell = dgvRecipe.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }


        /// <summary>
        /// dgvRecipe -> 右键功能 -> Modify
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvRecipe.SelectedRows[0];//获取选中的行
            RDRSELRecipeKeyValue rdrSELRecipeKeyValue = row.DataBoundItem as RDRSELRecipeKeyValue;//将当前行绑定的数据转换为实体类

            string sModifyValue = Interaction.InputBox(rdrSELRecipeKeyValue.Key, "Modify", rdrSELRecipeKeyValue.Value, -1, -1);

            if (!string.IsNullOrEmpty(sModifyValue))
            {
                rdrSELRecipeKeyValue.Value = sModifyValue;
            }

            _listRecipeKeyValveDgv[row.Index].Value = rdrSELRecipeKeyValue.Value;
            WriteRecipeTempIni();
        }


        /// <summary>
        /// Read Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ReadExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "All|*.*|Excel(*.xlsm)|*.xlsm|Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.Cancel)
                return;
            string sExcelFilePath = openFile.FileName;

            Microsoft.Office.Interop.Excel.Application xApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook xWorkbook = null;
            Sheets xSheets = null;
            Worksheet xWorkSheet = null;
            object oMissiong = System.Reflection.Missing.Value;
            DataTable dt = new DataTable();

            try
            {
                if (xApp == null)
                    return;
                xWorkbook = xApp.Workbooks.Open(sExcelFilePath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                  oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                xSheets = xWorkbook.Worksheets;

                //将数据读入到DataTable中
                xWorkSheet = (Worksheet)xSheets[4];//读取sheet
                if (xWorkSheet == null)
                    return;

                string txt = ((Range)xWorkSheet.Cells[78, 2]).Text.ToString();
                MessageBox.Show(txt);
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError(ex.Message);
            }
            finally
            {
                xWorkbook.Close(sExcelFilePath);
                xApp.Workbooks.Close();
                xApp.Quit();
                Marshal.ReleaseComObject(xWorkSheet);
                Marshal.ReleaseComObject(xWorkbook);
                Marshal.ReleaseComObject(xApp);
                xWorkSheet = null;
                xWorkbook = null;
                xApp = null;
                GC.Collect();
            }
        }


        /// <summary>
        /// Read XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ReadXML_Click(object sender, EventArgs e)
        {

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
        /// </summary>
        private void InitInfo()
        {
            string sVeoneerCustomer;
            string[] sVeoneerCustomerArr;

            //根据ini中的配置路径，初始化TestFiles Folder
            switch (FileHelper.sIniPMSUsage)
            {
                case "Debug":
                    txt_TestFilesFolderVehNo.Text = IniHelper.ReadIni(FileHelper.sIniRDRSELSection, "TestFiles_Folder_ADrive", "NULL", FileHelper.sIniFilePathDebug);

                    //TODO 是否可以用委托？
                    sVeoneerCustomer = IniHelper.ReadIni(FileHelper.sIniVeoneerSection, "Veoneer_Customer", "NULL", FileHelper.sIniFilePathDebug);
                    sVeoneerCustomerArr = sVeoneerCustomer.Split(',');
                    for (int i = 0; i < sVeoneerCustomerArr.Length; i++)
                    {
                        combox_Customer.Items.Add(sVeoneerCustomerArr[i].Trim());
                    }
                    break;
                case "CFM":
                    txt_TestFilesFolderVehNo.Text = IniHelper.ReadIni(FileHelper.sIniRDRSELSection, "TestFiles_Folder_ADrive", "NULL", FileHelper.sIniFilePathCFM);

                    sVeoneerCustomer = IniHelper.ReadIni(FileHelper.sIniVeoneerSection, "Veoneer_Customer", "NULL", FileHelper.sIniFilePathDebug);
                    sVeoneerCustomerArr = sVeoneerCustomer.Split(',');
                    for (int i = 0; i < sVeoneerCustomerArr.Length; i++)
                    {
                        combox_Customer.Items.Add(sVeoneerCustomerArr[i].Trim());
                    }
                    break;
                default:
                    break;
            }

            //combox_Gen.SelectedIndex = 0;
            //combox_Customer.SelectedIndex = 0;
            //combox_RadarType.SelectedIndex = 0;
        }


        /// <summary>
        /// 根据Customer，从MasterFile中获取值
        /// </summary>
        /// <param name="customer"></param>
        private void GetMasterFileValueByCustomer(string customer, string radarType)
        {
            Microsoft.Office.Interop.Excel.Application xApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook xWorkbook = null;
            Sheets xSheets = null;
            Worksheet xWorkSheet = null;
            object oMissiong = System.Reflection.Missing.Value;
            DataTable dt = new DataTable();

            try
            {
                //判断Excel文件是否已经打开？
                //Excel文件已打开，文件名前会加~$前缀
                if (_sMasterFilePath.Contains("~$"))
                {
                    _sMasterFilePathOpen = _sMasterFilePath.Replace("~$", "");
                }
                else//Excel文件未打开
                {
                    _sMasterFilePathOpen = _sMasterFilePath;
                }


                if (xApp == null)
                    return;
                xWorkbook = xApp.Workbooks.Open(_sMasterFilePathOpen, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                  oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                xSheets = xWorkbook.Worksheets;

                //将数据读入到DataTable中
                xWorkSheet = (Worksheet)xSheets["VEHICLE LINE"];//读取sheet
                if (xWorkSheet == null)
                    return;

                if ("BTET" == customer && "FLR" == radarType)
                {
                    //TODO Cells的值应该从XML动态获取
                    _rdrSELRecipeMasterFile.VeoneerPartNumber = ((Range)xWorkSheet.Cells[72, 2]).Text.ToString();
                    _rdrSELRecipeMasterFile.CustomerPartNumber = ((Range)xWorkSheet.Cells[73, 2]).Text.ToString();
                    _rdrSELRecipeMasterFile.HardwareVersion = ((Range)xWorkSheet.Cells[78, 2]).Text.ToString();
                    _rdrSELRecipeMasterFile.SoftwareVersion = ((Range)xWorkSheet.Cells[79, 2]).Text.ToString();
                    _rdrSELRecipeMasterFile.CMIIT = ((Range)xWorkSheet.Cells[81, 2]).Text.ToString();
                }
                else if ("CHERY" == customer && "FLR" == radarType)
                {
                    //TODO Cells的值应该从XML动态获取
                    _rdrSELRecipeMasterFile.VeoneerPartNumber = ((Range)xWorkSheet.Cells[78, 2]).Text.ToString();
                    _rdrSELRecipeMasterFile.CustomerPartNumber = ((Range)xWorkSheet.Cells[79, 2]).Text.ToString();
                    _rdrSELRecipeMasterFile.HardwareVersion = ((Range)xWorkSheet.Cells[80, 2]).Text.ToString();
                    _rdrSELRecipeMasterFile.SoftwareVersion = ((Range)xWorkSheet.Cells[81, 2]).Text.ToString();
                    _rdrSELRecipeMasterFile.CMIIT = ((Range)xWorkSheet.Cells[83, 2]).Text.ToString();
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError(ex.Message);
            }
            finally
            {
                xWorkbook.Close(_sMasterFilePathOpen);
                xApp.Workbooks.Close();
                xApp.Quit();
                Marshal.ReleaseComObject(xWorkSheet);
                Marshal.ReleaseComObject(xWorkbook);
                Marshal.ReleaseComObject(xApp);
                xWorkSheet = null;
                xWorkbook = null;
                xApp = null;
                GC.Collect();
            }
        }


        /// <summary>
        /// 将生成的Recipe写入Temp.ini
        /// </summary>
        private void WriteRecipeTempIni()
        {
            _listRecipeKeyValueWriteIni.Clear();

            try
            {
                for (int i = 0; i < _listRecipeKeyValveDgv.Count; i++)
                {
                    RDRSELRecipeKeyValue rdrSELRecipe = new RDRSELRecipeKeyValue();

                    if (_listRecipeKeyValveDgv[i].Key.StartsWith("["))
                    {
                        rdrSELRecipe.Key = _listRecipeKeyValveDgv[i].Key;
                        rdrSELRecipe.Value = _listTabKeyCount[i];
                    }
                    else
                    {
                        rdrSELRecipe.Key = _listRecipeKeyValveDgv[i].Key + "=";
                        rdrSELRecipe.Value = _listTabKeyCount[i] + _listRecipeKeyValveDgv[i].Value;
                    }

                    _listRecipeKeyValueWriteIni.Add(rdrSELRecipe);
                }

                FileStream fs = new FileStream(_sTempIniFile, FileMode.Create, FileAccess.ReadWrite);
                fs.Seek(0, SeekOrigin.Begin);
                fs.SetLength(0);

                StreamWriter sw = new StreamWriter(fs);
                //sw.Flush();

                //适用StreamWriter往文件中写入内容
                //sw.BaseStream.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < _listRecipeKeyValueWriteIni.Count; i++)
                {
                    sw.WriteLine(_listRecipeKeyValueWriteIni[i].Key + _listRecipeKeyValueWriteIni[i].Value);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError(ex.Message);
            }
        }



        private void btn_Test_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(_sTempIniFile, FileMode.Create, FileAccess.ReadWrite);
            fs.Seek(0, SeekOrigin.Begin);
            fs.SetLength(0);
            fs.Close();
        }
        #endregion


    }



    public class RDRSELRecipeKeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class RDRSELRecipeMasterFile
    {
        public string VeoneerPartNumber { get; set; }
        public string CustomerPartNumber { get; set; }
        public string HardwareVersion { get; set; }
        public string SoftwareVersion { get; set; }
        public string CMIIT { get; set; }
    }

    public class RDRSELRecipePLM
    {
        //SWLCONFIGFILE=			A:\TesterFiles\Chery\681923300B\681923300A_Rev3.txt
        //EOLCONFIGFILE=			A:\TesterFiles\Chery\681923300B\681923300A_Rev3.txt
        public string RevisionFile { get; set; } = "";

        //NVMFILE=	            A:\TesterFiles\Chery\681923300B\CHERY_NVM.xtf
        public string NvmFile { get; set; } = "";

        //NVMFILE=				A:\TesterFiles\BTET\681919100C\AFT_NvM_R30_31_80D62_01.etf
        public string NvmEtfFile { get; set; } = "";

        //NVMCOMBOFILE=		    A:\TesterFiles\Chery\681923300B\NVMExcludeFile.txt
        public string NvmExcludeFile { get; set; } = "";

        //COREPPARADRFILE=	    A:\TesterFiles\Chery\681923300B\681923300A.xtf
        public string CorePparFile { get; set; } = "";

        //COREPPAREXCLUDEFILE=	A:\TesterFiles\Chery\681923300B\Exclude Core File.txt
        public string CorePparExcludeFile { get; set; } = "";

        //AFTPPARADRFILE=		    A:\TesterFiles\Chery\681923300B\AFT_PPAR_XCP_Enable.xtf
        public string AftPparFile { get; set; } = "";

        //AFTPPAREXCLUDEFILE=	    A:\TesterFiles\Chery\681923300B\Exclude AFT File.txt
        public string AftPparExcludeFile { get; set; } = "";

        //FAULTMASKFILE=		    A:\TesterFiles\Chery\681923300B\77GHz_1.2Core_Fault_Mask.txt
        public string FaultMaskFile { get; set; } = "";

        //SWLOEMAPPFILE=			A:\TesterFiles\Chery\681923300B\Combined_PblAppSWP_CHERY_T26_FLR_A00.cbt
        public string OemFile { get; set; } = "";
    }
}
