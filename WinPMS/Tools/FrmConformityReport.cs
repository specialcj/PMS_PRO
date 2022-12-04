using PMS.COMMON.Helper;
using System;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Drawing;

namespace WinPMS.Tools
{
    public partial class FrmConformityReport : Form
    {
        public FrmConformityReport()
        {
            InitializeComponent();
        }







        #region 事件

        private void button1_Click(object sender, EventArgs e)
        {
            //创建一个Document类实例
            Document document = new Document();
            
            //加载word
            document.LoadFromFile(@"D:\_VNE_Work\CSharp\PMS\WinPMS\Config\ConformityReportTemplate\CFM-PE-VR2G166 77 G1.3 Radar Burn In Tooling Fixture Conformity Report.doc");

            /*
            Section sec = document.AddSection();
            //Paragraph para = sec.AddParagraph();

            //声明一个HeaderFooter类对象，添加页眉、页脚
            HeaderFooter header = sec.HeadersFooters.Header;
            //Paragraph headerPara = header.AddParagraph();

            HeaderFooter footer = sec.HeadersFooters.Footer;
            //Paragraph footerPara = footer.AddParagraph();
            */


            //获取文档的第一个节
            Section section = document.Sections[0];

            //string s = section.HeadersFooters.FirstPageHeader.Tables[0].FirstRow.Cells[2].FirstParagraph.Text;
            //MessageBox.Show(s);

            Paragraph headerParagraph = (Paragraph)section.HeadersFooters.FirstPageHeader.Tables[0].FirstRow.Cells[2].FirstParagraph;

            MessageBox.Show(headerParagraph.Text);


            //headerParagraph.Replace("Demo", "CFM-PE-VR0C48123", true, true);
            headerParagraph.Replace("CFM-PE-VR0C48123", "Demo", true, true);

            document.SaveToFile("Doc.doc");


            /*
            //Section section = document.AddSection();

            //add a header
            HeaderFooter header = section.HeadersFooters.Header;
            Paragraph headerParagraph = header.AddParagraph();
            TextRange text = headerParagraph.AppendText("Demo of Spire.Doc");
            text.CharacterFormat.TextColor = Color.Blue;
            document.SaveToFile("DocWithHeader.doc");
            


            
            //replace the header
            headerParagraph.Replace("Demo", "replaceText", true, true);
            document.SaveToFile("DocHeaderReplace.doc");
            document.LoadFromFile("DocWithHeader.doc");

            //delete the heater
            document.Sections[0].HeadersFooters.Header.Paragraphs.Clear();
            document.SaveToFile("DocHeaderDelete.doc");
            */

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
