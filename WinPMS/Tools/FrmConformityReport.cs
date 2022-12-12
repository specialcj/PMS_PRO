using PMS.COMMON.Helper;
using System;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Xls;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace WinPMS.Tools
{
    public partial class FrmConformityReport : Form
    {
        public FrmConformityReport()
        {
            InitializeComponent();
        }

        private const string CONFORMITY_REPORT_RADAR_SENSOR_TEST = "CFM-File-Num Acceptance Conformity for Radar XXX Sensor Test.docx";
        private const string CONFORMITY_CRITERIA_RADAR_SENSOR_TEST = "List of the Acceptance Criteria for Radar XXX Sensor Test.xlsx";
        private const string CONFORMITY_TEMPLATE_COPY = @"C:\PMS_ConformityReportGen";

        private string _sConformityReportTemplateFolderPath = Path.Combine(FileHelper.sExeFolderPath, @"Config\ConformityReportTemplate");//定义Conformity Report Template目录的路径

        private string _sConformityReportTemplateFilePath = "";//定义Conformity Report Template文件的路径
        private string _sConformityReportTemplateFileCopyPath = "";//定义Conformity Report Template文件复制的路径

        private string _sConformityCriteriaTemplateFilePath = "";//定义Conformity Criteria Template文件的路径
        private string _sConformityCriteriaTemplateFileCopyPath = "";//定义Conformity Criteria Template文件复制的路径


        private string _sSelectedStation = "";//定义所选择的站别

        private string _sFileNum = "";//文件编号
        private string _sEquFixtureNum = "";//设备/夹具编号
        private string _sLine = "";//线体
        private string _sValidationDate = "";//验证日期
        private string _sOwner = "";

        #region 事件

        private void FrmConformityReport_Load(object sender, EventArgs e)
        {
            //隐藏TabControl控件的标签
            tabControl1.Region = new Region(new RectangleF(Radar.Left, Radar.Top, Radar.Width, Radar.Height));

            //默认Station站别选择是Radar
            //comboBox_Station.SelectedItem = "Radar";
        }

        /// <summary>
        /// 捕捉按键消息屏蔽Tab+Ctrl组合键，用于防止切换TabControl页
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Tab | Keys.Control):
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        /// <summary>
        /// Station选择项更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_Station_SelectedIndexChanged(object sender, EventArgs e)
        {
            _sSelectedStation = comboBox_Station.GetItemText(comboBox_Station.SelectedItem);

            //根据不同的Station，切换不同的TabControl页
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                if (tabPage.Text == _sSelectedStation)
                {
                    tabControl1.SelectedTab = tabPage;
                    break;
                }
            }
        }



        /// <summary>
        /// 生成Conformity Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_GenConformityReport_Click(object sender, EventArgs e)
        {
            #region 输入参数合法性检查，以及参数获取
            //Station空检查
            if (_sSelectedStation == "")
            {
                MsgBoxHelper.MsgBoxError("please select Station first!");
                comboBox_Station.Focus();
                return;
            }

            //Station -> Radar检查
            if (_sSelectedStation == "Radar")
            {
                if (!radioBtn_SensorTest.Checked && !radioBtn_SEL.Checked)
                {
                    MsgBoxHelper.MsgBoxError("please select Test Station for Radar Station first!");
                    //tabControl1.Focus();
                    return;
                }
            }

            //文件编号检查
            if (string.IsNullOrEmpty(textBox_FileNum.Text.Trim()))
            {
                MsgBoxHelper.MsgBoxError("please input File Num first!");
                textBox_FileNum.Focus();
                return;
            }
            else
            {
                _sFileNum = textBox_FileNum.Text.Trim();
            }

            //设备/夹具编号检查
            if (string.IsNullOrEmpty(textBox_Equ_FixtureNum.Text.Trim()))
            {
                MsgBoxHelper.MsgBoxError("please input Equipment/Fixture Num first!");
                textBox_Equ_FixtureNum.Focus();
                return;
            }
            else
            {
                _sEquFixtureNum = textBox_Equ_FixtureNum.Text.Trim();
            }

            //线体检查
            if (string.IsNullOrEmpty(textBox_Line.Text.Trim()))
            {
                MsgBoxHelper.MsgBoxError("please input Line first!");
                textBox_Line.Focus();
                return;
            }
            else
            {
                _sLine = textBox_Line.Text.Trim();
            }

            //Validation Date检查
            if (dateTimePicker_ValidationDate.Value < DateTime.Now)
            {
                MsgBoxHelper.MsgBoxError("selected date should not before the current date!");
                dateTimePicker_ValidationDate.Focus();
                return;
            }
            else
            {
                _sValidationDate = dateTimePicker_ValidationDate.Value.ToString("yyyy/MM/dd");
            }
            
            //Owner检查
            if (string.IsNullOrEmpty(textBox_Owner.Text.Trim()))
            {
                MsgBoxHelper.MsgBoxError("please input Owner first!");
                textBox_Owner.Focus();
                return;
            }
            else
            {
                _sOwner = textBox_Owner.Text.Trim();
            }

            #endregion

            


            //根据Station站别和TS的选择，获取Conformity报告的路径
            if (_sSelectedStation == "Radar")
            {
                if (radioBtn_SensorTest.Checked)
                {
                    _sConformityReportTemplateFilePath = Path.Combine(Path.Combine(_sConformityReportTemplateFolderPath, @"Radar\SensorTest"), CONFORMITY_REPORT_RADAR_SENSOR_TEST);
                    _sConformityCriteriaTemplateFilePath = Path.Combine(Path.Combine(_sConformityReportTemplateFolderPath, @"Radar\SensorTest"), CONFORMITY_CRITERIA_RADAR_SENSOR_TEST);
                }
                else if (radioBtn_SEL.Checked)
                {
                    //TODO
                    //获取SEL Conformity Report File的路径 和 Conformity Criteria File的路径
                }
            }
            //TODO
            //其他Station站别
            if (_sSelectedStation == "Radar_PDI_VS412")
            {
                MsgBoxHelper.MsgBoxError("NA");
                return;
            }
            else if (_sSelectedStation == "Radar_Packing")
            {
                MsgBoxHelper.MsgBoxError("NA");
                return;
            }

            //TODO 以下定义一个方法来获取
            //根据Conformity Report Template文件的路径，获取文件名和文件后缀
            string sConformityReportTemplateFilePathFullName = _sConformityReportTemplateFilePath.Substring(_sConformityReportTemplateFilePath.LastIndexOf(@"\") + 1);//FileName.docx
            string sConformityReportTemplateFilePathName = sConformityReportTemplateFilePathFullName.Substring(0, sConformityReportTemplateFilePathFullName.Length - sConformityReportTemplateFilePathFullName.Substring(sConformityReportTemplateFilePathFullName.LastIndexOf(".")).Length);//FileName
            string sConformityReportTemplateFilePathExtension = sConformityReportTemplateFilePathFullName.Substring(sConformityReportTemplateFilePathFullName.LastIndexOf("."));//.docx

            //根据Conformity Criteria Template文件的路径，获取文件名和文件后缀
            string sConformityCriteriaFilePathFullName = _sConformityCriteriaTemplateFilePath.Substring(_sConformityCriteriaTemplateFilePath.LastIndexOf(@"\") + 1);//FileName.xlsx
            string sConformityCriteriaFilePathName = sConformityCriteriaFilePathFullName.Substring(0, sConformityCriteriaFilePathFullName.Length - sConformityCriteriaFilePathFullName.Substring(sConformityCriteriaFilePathFullName.LastIndexOf(".")).Length);//FileName
            string sConformityCriteriaFilePathExtension = sConformityCriteriaFilePathFullName.Substring(sConformityCriteriaFilePathFullName.LastIndexOf("."));//.xlsx


            //创建Conformity报告文件复制的指定路径
            if (!Directory.Exists(CONFORMITY_TEMPLATE_COPY))
            {
                Directory.CreateDirectory(CONFORMITY_TEMPLATE_COPY);
            }


            //生成Conformity Report Template文件复制的路径
            //_sConformityReportTemplateFileCopyPath = Path.Combine(CONFORMITY_TEMPLATE_COPY, sConformityReportTemplateFilePathName + " - Copy" + sConformityReportTemplateFilePathExtension);
            _sConformityReportTemplateFileCopyPath = Path.Combine(CONFORMITY_TEMPLATE_COPY, sConformityReportTemplateFilePathFullName);

            //生成Conformity Criteria Template文件复制的路径
            //_sConformityCriteriaTemplateFileCopyPath = Path.Combine(CONFORMITY_TEMPLATE_COPY, sConformityCriteriaFilePathName + " - Copy" + sConformityCriteriaFilePathExtension);
            _sConformityCriteriaTemplateFileCopyPath = Path.Combine(CONFORMITY_TEMPLATE_COPY, sConformityCriteriaFilePathFullName);


            //复制Conformity Report Template到指定路径下
            File.Copy(_sConformityReportTemplateFilePath, _sConformityReportTemplateFileCopyPath, true);

            //复制Conformity Criteria Template到指定路径下
            File.Copy(_sConformityCriteriaTemplateFilePath, _sConformityCriteriaTemplateFileCopyPath, true);


            #region 重命名Conformity Report Template文件复制的名称，重命名Conformity Criteria Template文件复制的名称
            //TODO 需要根据不同的Station和TS来重命名

            //重命名Conformity Report Template文件复制的名称
            string sConformityReportTemplateFilePathFullNameRename = sConformityReportTemplateFilePathFullName.Replace("CFM-File-Num", _sFileNum).Replace("Radar XXX", _sLine) + sConformityReportTemplateFilePathExtension;
            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(_sConformityReportTemplateFileCopyPath, sConformityReportTemplateFilePathFullNameRename);

            //重命名Conformity Criteria Template文件复制的名称
            string sConformityCriteriaFilePathFullNameRename = sConformityCriteriaFilePathFullName.Replace("Radar XXX", _sLine) + sConformityCriteriaFilePathExtension;
            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(_sConformityCriteriaTemplateFileCopyPath, sConformityCriteriaFilePathFullNameRename);
            #endregion



            //Modify Conformity Criteria
            await Task.Run(() =>
            {
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(Path.Combine(CONFORMITY_TEMPLATE_COPY, sConformityCriteriaFilePathFullNameRename));

                Worksheet sheet = workbook.Worksheets[0];
                CellRange[] ranges = sheet.FindAllString("Radar LineNum", false, false);
                foreach (CellRange range in ranges)
                {
                    range.Text = textBox_Line.Text.Trim();
                    //range.Style.Color = Color.LawnGreen;
                }

                ranges = sheet.FindAllString("yyyy/mm/dd", false, false);
                foreach (CellRange range in ranges)
                {
                    range.Text = _sValidationDate;
                }

                ranges = sheet.FindAllString("Owner", false, false);
                foreach (CellRange range in ranges)
                {
                    range.Text = textBox_Owner.Text.Trim();
                }

                workbook.SaveToFile(_sConformityCriteriaTemplateFileCopyPath);
                Process.Start(_sConformityCriteriaTemplateFileCopyPath);

            });




            //创建一个Document类实例
            Document document = new Document();

            //加载word
            document.LoadFromFile("");

            //获取文档的第一个节
            Section section = document.Sections[0];

            //replace FirstPageHeader
            Paragraph headerParagraph = (Paragraph)section.HeadersFooters.FirstPageHeader.Tables[0].FirstRow.Cells[2].FirstParagraph;
            //MessageBox.Show(headerParagraph.Text);
            headerParagraph.Replace("CFM-File-Num-FPHeader", "FirstPageHeader", true, true);

            //replace Header
            headerParagraph = (Paragraph)section.HeadersFooters.Header.FirstParagraph;
            //MessageBox.Show(headerParagraph.Text);
            headerParagraph.Replace("CFM-File-Num-Header", "Header", true, true);

            //replace text
            document.Replace("Radar 5", "Radar 7", true, true);
            //document.Replace("Acceptance Conformity for Radar 5 Sensor Test Equipment", "Acceptance Conformity for Radar 7 Sensor Test Equipment", true, true);
            //document.Replace("Applicable for Radar 5 Sensor Test Equipment", "Applicable for Radar 7 Sensor Test Equipment", true, true);
            //document.Replace("with 77 G1.3 Corner Fixture", "", true, true);
            document.Replace("EPT-RDR05G1.3-01-01/EPT-RDR05G1.3-01-02", "EPT-TEST01/EPT-TEST02", true, true);
            document.Replace("Jason Cai", "Spire.DOC-1", true, true);
            document.Replace("Cecilia Xia", "Spire.DOC-2", true, true);
            document.Replace("Daniel Wang", "Spire.DOC-3", true, true);
            document.Replace("Steven Wu", "Spire.DOC-4", true, true);
            document.Replace("2022-11-29", "2022-12-08", true, true);
            document.Replace("2022/11/29", "2022/12/08", true, true);


            //insert OLE Object
            headerParagraph = section.AddParagraph();
            DocPicture picture = new DocPicture(document);
            //Image image = GetExcelImage(@"C:\Users\jason.cai\Desktop\123.xlsx");//Get Image Source
            //picture.LoadImage(image);//Load Image
            //DocOleObject obj = headerParagraph.AppendOleObject(@"C:\Users\jason.cai\Desktop\123.xlsx", picture, Spire.Doc.Documents.OleObjectType.ExcelWorksheet);


            //document.SaveToFile(fileNameSave);

            //MessageBox.Show("ok");
            //Process.Start(fileNameSave);

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




        #endregion

    }

}


