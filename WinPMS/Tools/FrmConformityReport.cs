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

        private string _sConformityReportTemplateFilePath = "";                 //定义Conformity Report Template文件的路径
        private string _sConformityReportTemplateFileCopyPath = "";             //定义Conformity Report Template文件复制的路径
        private string _sConformityReportTemplateFileCopyPathRename = "";       //定义Conformity Report Template文件复制的重命名的路径

        private string _sConformityCriteriaTemplateFilePath = "";               //定义Conformity Criteria Template文件的路径
        private string _sConformityCriteriaTemplateFileCopyPath = "";           //定义Conformity Criteria Template文件复制的路径
        private string _sConformityCriteriaTemplateFileCopyPathRename = "";     //定义Conformity Criteria Template文件复制的重命名路径


        private string _sSelectedStation = "";//定义所选择的站别

        private string _sFileNum = "";//文件编号
        private string _sEquFixtureNum = "";//设备/夹具编号
        private string _sLine = "";//线体
        private string _sValidationDate = "";//验证日期
        private string _sTestEngineer = "";
        private string _sPME = "";
        private string _sTestManager = "";
        private string _sPlantQualityManager = "";
        private string _sLoadPic = "";

        #region 事件

        private void FrmConformityReport_Load(object sender, EventArgs e)
        {
            //隐藏TabControl控件的标签
            tabControl1.Region = new Region(new RectangleF(Radar.Left, Radar.Top, Radar.Width, Radar.Height));

            //默认Station站别选择是Radar
            //comboBox_Station.SelectedItem = "Radar";

            //加载TestEngineer
            foreach (var item in FileHelper.sIniPMS_Conformity_Report_TestEngineer.Split(','))
            {
                comboBox_TestEngineer.Items.Add(item.Trim());
            }

            //加载PME
            foreach (var item in FileHelper.sIniPMS_Conformity_Report_PME.Split(','))
            {
                comboBox_PME.Items.Add(item.Trim());
            }

            //加载TestManager
            foreach (var item in FileHelper.sIniPMS_Conformity_Report_TestManager.Split(','))
            {
                comboBox_TestManager.Items.Add(item.Trim());
            }
            comboBox_TestManager.SelectedIndex = 0;

            //加载PlantQualityManager
            foreach (var item in FileHelper.sIniPMS_Conformity_Report_PlantQualityManager.Split(','))
            {
                comboBox_PlantQualityManager.Items.Add(item.Trim());
            }
            comboBox_PlantQualityManager.SelectedIndex = 0;
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

            //TODO 通过Action调用
            //if (_sSelectedStation == "Radar")
            //{
            //    if (radioBtn_SensorTest.Checked)
            //    {
            //        label_Equip_Fixture.Text = "Fixture Num：";
            //    }
            //    else if (radioBtn_SEL.Checked)
            //    {
            //        label_Equip_Fixture.Text = "Fixture Num：";
            //    }
            //}
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

            //Station -> Radar
            if (_sSelectedStation == "Radar")
            {
                if (!radioBtn_SensorTest.Checked && !radioBtn_SEL.Checked)
                {
                    MsgBoxHelper.MsgBoxError("please select Test Station for Radar Station first!");
                    //tabControl1.Focus();
                    return;
                }
            }

            //文件编号
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

            //设备/夹具编号
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

            //线体
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


            //Validation Date
            string sDT1 = dateTimePicker_ValidationDate.Value.ToString("yyyy-MM-dd");
            string sDT2 = DateTime.Now.ToString("yyyy-MM-dd");
            int iDateCompare = DateTime.Compare(Convert.ToDateTime(sDT1), Convert.ToDateTime(sDT2));
            if (iDateCompare < 0)
            {
                MsgBoxHelper.MsgBoxError("selected date should not before the current date!");
                dateTimePicker_ValidationDate.Focus();
                return;
            }
            else
            {
                _sValidationDate = dateTimePicker_ValidationDate.Value.ToString("yyyy/MM/dd");
            }

            //TestEngineer
            if (comboBox_TestEngineer.SelectedIndex < 0)
            {
                MsgBoxHelper.MsgBoxError("please select TestEngineer first!");
                comboBox_TestEngineer.Focus();
                return;
            }
            else
            {
                _sTestEngineer = comboBox_TestEngineer.Text.Trim();
            }

            //PME
            if (comboBox_PME.SelectedIndex < 0)
            {
                MsgBoxHelper.MsgBoxError("please select PME first!");
                comboBox_PME.Focus();
                return;
            }
            else
            {
                _sPME = comboBox_PME.Text.Trim();
            }

            //TestManager
            if (comboBox_TestManager.SelectedIndex < 0)
            {
                MsgBoxHelper.MsgBoxError("please select TestManager first!");
                comboBox_TestManager.Focus();
                return;
            }
            else
            {
                _sTestManager = comboBox_TestManager.Text.Trim();
            }


            //PlantQualityManager
            if (comboBox_PlantQualityManager.SelectedIndex < 0)
            {
                MsgBoxHelper.MsgBoxError("please select PlantQualityManager first!");
                comboBox_PlantQualityManager.Focus();
                return;
            }
            else
            {
                _sPlantQualityManager = comboBox_PlantQualityManager.Text.Trim();
            }
            
            //Pic
            if (string.IsNullOrEmpty(_sLoadPic))
            {
                MsgBoxHelper.MsgBoxError("please load pic first!");
                textBox_LoadPic.Focus();
                return;
            }

            #endregion


            //需要根据不同的Station站别和TS站选择来获取Conformity报告的路径
            //TODO 通过Action调用
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
            //TODO 其他Station站别
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
            _sConformityReportTemplateFileCopyPath = Path.Combine(CONFORMITY_TEMPLATE_COPY, sConformityReportTemplateFilePathFullName);

            //生成Conformity Criteria Template文件复制的路径
            _sConformityCriteriaTemplateFileCopyPath = Path.Combine(CONFORMITY_TEMPLATE_COPY, sConformityCriteriaFilePathFullName);


            //重命名Conformity Report Template文件复制的名称
            string sConformityReportTemplateFilePathFullNameRename = sConformityReportTemplateFilePathFullName.Replace("CFM-File-Num", _sFileNum).Replace("Radar XXX", _sLine);
            //生成Conformity Report Template文件复制的重命名路径
            _sConformityReportTemplateFileCopyPathRename = Path.Combine(CONFORMITY_TEMPLATE_COPY, sConformityReportTemplateFilePathFullNameRename);
            //如果文件存在，则删除
            if (File.Exists(_sConformityReportTemplateFileCopyPathRename))
            {
                File.Delete(_sConformityReportTemplateFileCopyPathRename);
            }

            //重命名Conformity Criteria Template文件复制的名称
            string sConformityCriteriaFilePathFullNameRename = sConformityCriteriaFilePathFullName.Replace("Radar XXX", _sLine);
            //生成Conformity Criteria Template文件复制的重命名路径
            _sConformityCriteriaTemplateFileCopyPathRename = Path.Combine(CONFORMITY_TEMPLATE_COPY, sConformityCriteriaFilePathFullNameRename);
            if (File.Exists(_sConformityCriteriaTemplateFileCopyPathRename))
            {
                File.Delete(_sConformityCriteriaTemplateFileCopyPathRename);
            }


            //复制Conformity Report Template到指定路径下
            File.Copy(_sConformityReportTemplateFilePath, _sConformityReportTemplateFileCopyPath, true);

            //复制Conformity Criteria Template到指定路径下
            File.Copy(_sConformityCriteriaTemplateFilePath, _sConformityCriteriaTemplateFileCopyPath, true);


            //重命名Conformity Report
            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(_sConformityReportTemplateFileCopyPath, sConformityReportTemplateFilePathFullNameRename);

            //重命名Conformity Criteria
            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(_sConformityCriteriaTemplateFileCopyPath, sConformityCriteriaFilePathFullNameRename);



            //Generate Conformity Criteria
            await Task.Run(() =>
            {
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(_sConformityCriteriaTemplateFileCopyPathRename);

                Worksheet sheet = workbook.Worksheets[0];
                CellRange[] ranges = sheet.FindAllString("Radar LineNum", false, false);
                foreach (CellRange range in ranges)
                {
                    range.Text = _sLine;
                    //range.Style.Color = Color.LawnGreen;
                }

                ranges = sheet.FindAllString("yyyy/mm/dd", false, false);
                foreach (CellRange range in ranges)
                {
                    range.Text = _sValidationDate;
                }

                ranges = sheet.FindAllString("TestEngineer", false, false);
                foreach (CellRange range in ranges)
                {
                    range.Text = _sTestEngineer;
                }

                workbook.SaveToFile(_sConformityCriteriaTemplateFileCopyPathRename);
                //Process.Start(_sConformityCriteriaTemplateFileCopyPathRename);
            });


            //Generate Conformity Report
            await Task.Run(() =>
            {
                //创建一个Document类实例
                Document doc = new Document();

                //加载Word
                doc.LoadFromFile(_sConformityReportTemplateFileCopyPathRename);

                //获取文档的第一个节
                Section sec = doc.Sections[0];

                //replace FirstPageHeader
                Paragraph headerParagraph = (Paragraph)sec.HeadersFooters.FirstPageHeader.Tables[0].FirstRow.Cells[2].FirstParagraph;
                //MessageBox.Show(headerParagraph.Text);
                headerParagraph.Replace("CFM-File-Num-FPHeader", _sFileNum, true, true);

                //replace Header
                headerParagraph = (Paragraph)sec.HeadersFooters.Header.FirstParagraph;
                //MessageBox.Show(headerParagraph.Text);
                headerParagraph.Replace("CFM-File-Num-Header", _sFileNum, true, true);

                //replace text
                doc.Replace("Radar XXX", _sLine, true, true);
                //document.Replace("with 77 G1.3 Corner Fixture", "", true, true);
                doc.Replace("EPT-RDR05G1.3-01-01/EPT-RDR05G1.3-01-02", _sEquFixtureNum, true, true);
                doc.Replace("Name1", _sTestEngineer, true, true);
                doc.Replace("Name2", _sPME, true, true);
                doc.Replace("Name3", _sTestManager, true, true);
                doc.Replace("Name4", _sPlantQualityManager, true, true);
                doc.Replace("2022-11-29", dateTimePicker_ValidationDate.Value.ToString("yyyy-MM-dd"), true, true);
                doc.Replace("2022/11/29", dateTimePicker_ValidationDate.Value.ToString("yyyy/MM/dd"), true, true);

                Paragraph paragraph;
                DocPicture docPicReplace;
                DocPicture docPicAppend;

                //遍历这个Section中的所有子元素
                for (int i = 0, j = 0, k = 0; i < sec.Body.ChildObjects.Count; i++)
                {
                    DocumentObject docObj = sec.Body.ChildObjects[i];

                    //找到Section下的段落对象
                    if (docObj is Paragraph)
                    {
                        paragraph = docObj as Paragraph;

                        //找到该段落下的Picture对象，替换图片
                        /*
                        for (int k = 0; k < p.ChildObjects.Count; k++)
                        {
                            DocumentObject docObj2 = p.ChildObjects[k];

                            if (docObj2 is DocPicture)
                            {
                                docPicReplace = docObj2 as DocPicture;
                                docPicReplace.ReplaceImage(File.ReadAllBytes(_sLoadPic), false);
                            }
                        }
                        */

                        //找到段落下的对应插入图片的文本位置
                        if (paragraph.Text.ToUpper().Trim() == "OBJECTIVE")
                        {
                            j++;
                        }
                        else if (j != 0)
                        {
                            j++;
                        }

                        if (j == 3)
                        {
                            docPicAppend = paragraph.AppendPicture(Image.FromFile(_sLoadPic));

                            //resize the image
                            docPicAppend.Height = docPicAppend.Height * 0.5f;
                            docPicAppend.Width = docPicAppend.Width * 0.5f;
                        }


                        //找到段落下的对应插入附件的文本位置
                        if (paragraph.Text.Trim() == "See the attached file.")
                        {
                            k++;
                        }
                        else if (k != 0)
                        {
                            k++;
                        }

                        if (k == 6)
                        {
                            //实例化一个DocPicture类对象，加载图片
                            DocPicture docPicExcelAdd = new DocPicture(doc);
                            Image image = Image.FromFile(Path.Combine(new DirectoryInfo(FileHelper.sExeFolderPath).Parent.Parent.FullName, @"Imgs\excel1.png"));
                            docPicExcelAdd.LoadImage(image);
                            docPicExcelAdd.Width = 77.25f;
                            docPicExcelAdd.Height = 55.5f;

                            //在文档中插入一个工作表，OleLinkType 枚举值控制该OLE是链接还是嵌入         
                            DocOleObject docOldObj = paragraph.AppendOleObject(_sConformityCriteriaTemplateFileCopyPathRename, docPicExcelAdd, Spire.Doc.Documents.OleLinkType.Embed);

                            //docOldObj.DisplayAsIcon = true;
                            //break;
                        }
                    }
                }

                //保存并打开文档
                doc.SaveToFile(_sConformityReportTemplateFileCopyPathRename);
                Process.Start(_sConformityReportTemplateFileCopyPathRename);
            });
        }


        /// <summary>
        /// 加载图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdPic = new OpenFileDialog();
            ofdPic.Filter = "jpg(*.jpg;*.jpeg);png(*.png)|*.jpg;*.jpeg;*.png";
            ofdPic.FilterIndex = 1;
            ofdPic.FileName = "";
            if (ofdPic.ShowDialog() == DialogResult.OK)
            {
                _sLoadPic = textBox_LoadPic.Text = ofdPic.FileName.ToString();
                Bitmap bmPic = new Bitmap(_sLoadPic);
                Point ptLoction = new Point(bmPic.Size);
                if (ptLoction.X > pictureBox1.Size.Width || ptLoction.Y > pictureBox1.Size.Height)
                {
                    //图像框的停靠方式  
                    //pcbPic.Dock = DockStyle.Fill;  

                    //图像充满图像框，并且图像维持比例  
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    //图像在图像框置中  
                    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                }

                //LoadAsync：非同步载入图像  
                pictureBox1.LoadAsync(_sLoadPic);
            }
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


