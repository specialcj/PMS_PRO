namespace WinPMS.Tools
{
    partial class FrmConformityReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Panel panelWhere;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConformityReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Station = new System.Windows.Forms.ComboBox();
            this.btn_GenConformityReport = new System.Windows.Forms.Button();
            this.tsMenus = new System.Windows.Forms.ToolStrip();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHelp = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_FileNum = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox_EquipOrFixtureNum = new System.Windows.Forms.TextBox();
            this.label_Equip_Fixture = new System.Windows.Forms.Label();
            this.textBox_Line = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker_ValidationDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox_Info1 = new System.Windows.Forms.GroupBox();
            this.comboBox_PlantQualityManager = new System.Windows.Forms.ComboBox();
            this.comboBox_TestManager = new System.Windows.Forms.ComboBox();
            this.comboBox_TestEngineer = new System.Windows.Forms.ComboBox();
            this.textBox_FixtureName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox_PME = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Equ_FixtureNum_Example = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Null = new System.Windows.Forms.TabPage();
            this.Radar = new System.Windows.Forms.TabPage();
            this.radioBtn_SEL = new System.Windows.Forms.RadioButton();
            this.radioBtn_SensorTest = new System.Windows.Forms.RadioButton();
            this.Radar_PDI_VS412 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.Radar_Packing = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox_TS = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_LoadPic = new System.Windows.Forms.Button();
            this.textBox_LoadPic = new System.Windows.Forms.TextBox();
            panelWhere = new System.Windows.Forms.Panel();
            panelWhere.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tsMenus.SuspendLayout();
            this.groupBox_Info1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Radar.SuspendLayout();
            this.Radar_PDI_VS412.SuspendLayout();
            this.Radar_Packing.SuspendLayout();
            this.groupBox_TS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWhere
            // 
            panelWhere.Controls.Add(this.groupBox1);
            panelWhere.Dock = System.Windows.Forms.DockStyle.Top;
            panelWhere.Location = new System.Drawing.Point(0, 45);
            panelWhere.Name = "panelWhere";
            panelWhere.Size = new System.Drawing.Size(1383, 75);
            panelWhere.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_Station);
            this.groupBox1.Controls.Add(this.btn_GenConformityReport);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1383, 75);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Station";
            // 
            // comboBox_Station
            // 
            this.comboBox_Station.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Station.FormattingEnabled = true;
            this.comboBox_Station.Items.AddRange(new object[] {
            "Radar",
            "Radar_PDI_VS412",
            "Radar_Packing"});
            this.comboBox_Station.Location = new System.Drawing.Point(12, 30);
            this.comboBox_Station.Name = "comboBox_Station";
            this.comboBox_Station.Size = new System.Drawing.Size(143, 21);
            this.comboBox_Station.TabIndex = 15;
            this.comboBox_Station.SelectedIndexChanged += new System.EventHandler(this.comboBox_Station_SelectedIndexChanged);
            // 
            // btn_GenConformityReport
            // 
            this.btn_GenConformityReport.Location = new System.Drawing.Point(172, 29);
            this.btn_GenConformityReport.Name = "btn_GenConformityReport";
            this.btn_GenConformityReport.Size = new System.Drawing.Size(160, 21);
            this.btn_GenConformityReport.TabIndex = 3;
            this.btn_GenConformityReport.Text = "Generate Conformity Report";
            this.btn_GenConformityReport.UseVisualStyleBackColor = true;
            this.btn_GenConformityReport.Click += new System.EventHandler(this.btn_GenConformityReport_Click);
            // 
            // tsMenus
            // 
            this.tsMenus.AutoSize = false;
            this.tsMenus.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tsMenus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsMenus.BackgroundImage")));
            this.tsMenus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsMenus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMenus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnDelete,
            this.toolStripSeparator1,
            this.tsbtnInfo,
            this.toolStripSeparator2,
            this.tsbtnRefresh,
            this.toolStripSeparator3,
            this.tsbtnClose,
            this.tsBtnHelp});
            this.tsMenus.Location = new System.Drawing.Point(0, 0);
            this.tsMenus.Name = "tsMenus";
            this.tsMenus.Padding = new System.Windows.Forms.Padding(0, 0, 1, 2);
            this.tsMenus.Size = new System.Drawing.Size(1383, 45);
            this.tsMenus.TabIndex = 1;
            this.tsMenus.Text = "toolStrip1";
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.Enabled = false;
            this.tsbtnDelete.Image = global::WinPMS.Properties.Resources.delete;
            this.tsbtnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(31, 37);
            this.tsbtnDelete.Text = " Del";
            this.tsbtnDelete.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // tsbtnInfo
            // 
            this.tsbtnInfo.Enabled = false;
            this.tsbtnInfo.Image = global::WinPMS.Properties.Resources.search;
            this.tsbtnInfo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnInfo.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnInfo.Name = "tsbtnInfo";
            this.tsbtnInfo.Size = new System.Drawing.Size(44, 37);
            this.tsbtnInfo.Text = " Detail";
            this.tsbtnInfo.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.Enabled = false;
            this.tsbtnRefresh.Image = global::WinPMS.Properties.Resources.refresh;
            this.tsbtnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(49, 37);
            this.tsbtnRefresh.Text = "Reflash";
            this.tsbtnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
            // 
            // tsbtnClose
            // 
            this.tsbtnClose.Image = global::WinPMS.Properties.Resources.close0;
            this.tsbtnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClose.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnClose.Name = "tsbtnClose";
            this.tsbtnClose.Size = new System.Drawing.Size(40, 37);
            this.tsbtnClose.Text = "Close";
            this.tsbtnClose.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
            // 
            // tsBtnHelp
            // 
            this.tsBtnHelp.Image = global::WinPMS.Properties.Resources.help;
            this.tsBtnHelp.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsBtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnHelp.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsBtnHelp.Name = "tsBtnHelp";
            this.tsBtnHelp.Size = new System.Drawing.Size(36, 37);
            this.tsBtnHelp.Text = "Help";
            this.tsBtnHelp.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsBtnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File Num：";
            // 
            // textBox_FileNum
            // 
            this.textBox_FileNum.Location = new System.Drawing.Point(144, 17);
            this.textBox_FileNum.Name = "textBox_FileNum";
            this.textBox_FileNum.Size = new System.Drawing.Size(227, 20);
            this.textBox_FileNum.TabIndex = 5;
            this.textBox_FileNum.Text = "CFM-PE-XXXXXX-XX";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "word -> .docx format",
            "excel -> .xlsx format"});
            this.listBox1.Location = new System.Drawing.Point(404, 427);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(179, 56);
            this.listBox1.TabIndex = 7;
            // 
            // textBox_EquipOrFixtureNum
            // 
            this.textBox_EquipOrFixtureNum.Location = new System.Drawing.Point(144, 57);
            this.textBox_EquipOrFixtureNum.Multiline = true;
            this.textBox_EquipOrFixtureNum.Name = "textBox_EquipOrFixtureNum";
            this.textBox_EquipOrFixtureNum.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_EquipOrFixtureNum.Size = new System.Drawing.Size(227, 130);
            this.textBox_EquipOrFixtureNum.TabIndex = 10;
            this.textBox_EquipOrFixtureNum.Text = "EPT-RDR07G1.3-01-02\r\nEPT-RDR07G1.3-01-02";
            // 
            // label_Equip_Fixture
            // 
            this.label_Equip_Fixture.AutoSize = true;
            this.label_Equip_Fixture.Location = new System.Drawing.Point(25, 57);
            this.label_Equip_Fixture.Name = "label_Equip_Fixture";
            this.label_Equip_Fixture.Size = new System.Drawing.Size(113, 13);
            this.label_Equip_Fixture.TabIndex = 9;
            this.label_Equip_Fixture.Text = "Equip / Fixture Num：";
            // 
            // textBox_Line
            // 
            this.textBox_Line.Location = new System.Drawing.Point(144, 294);
            this.textBox_Line.Name = "textBox_Line";
            this.textBox_Line.Size = new System.Drawing.Size(134, 20);
            this.textBox_Line.TabIndex = 12;
            this.textBox_Line.Text = "Radar 7";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Line：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Validation Date：";
            // 
            // dateTimePicker_ValidationDate
            // 
            this.dateTimePicker_ValidationDate.Location = new System.Drawing.Point(144, 334);
            this.dateTimePicker_ValidationDate.Name = "dateTimePicker_ValidationDate";
            this.dateTimePicker_ValidationDate.Size = new System.Drawing.Size(134, 20);
            this.dateTimePicker_ValidationDate.TabIndex = 14;
            // 
            // groupBox_Info1
            // 
            this.groupBox_Info1.Controls.Add(this.comboBox_PlantQualityManager);
            this.groupBox_Info1.Controls.Add(this.comboBox_TestManager);
            this.groupBox_Info1.Controls.Add(this.comboBox_TestEngineer);
            this.groupBox_Info1.Controls.Add(this.textBox_FixtureName);
            this.groupBox_Info1.Controls.Add(this.label13);
            this.groupBox_Info1.Controls.Add(this.comboBox_PME);
            this.groupBox_Info1.Controls.Add(this.label12);
            this.groupBox_Info1.Controls.Add(this.label11);
            this.groupBox_Info1.Controls.Add(this.label10);
            this.groupBox_Info1.Controls.Add(this.listBox1);
            this.groupBox_Info1.Controls.Add(this.label9);
            this.groupBox_Info1.Controls.Add(this.label8);
            this.groupBox_Info1.Controls.Add(this.textBox_Equ_FixtureNum_Example);
            this.groupBox_Info1.Controls.Add(this.label7);
            this.groupBox_Info1.Controls.Add(this.label6);
            this.groupBox_Info1.Controls.Add(this.label5);
            this.groupBox_Info1.Controls.Add(this.label1);
            this.groupBox_Info1.Controls.Add(this.textBox_FileNum);
            this.groupBox_Info1.Controls.Add(this.label_Equip_Fixture);
            this.groupBox_Info1.Controls.Add(this.dateTimePicker_ValidationDate);
            this.groupBox_Info1.Controls.Add(this.label4);
            this.groupBox_Info1.Controls.Add(this.textBox_EquipOrFixtureNum);
            this.groupBox_Info1.Controls.Add(this.textBox_Line);
            this.groupBox_Info1.Controls.Add(this.label3);
            this.groupBox_Info1.Location = new System.Drawing.Point(172, 131);
            this.groupBox_Info1.Name = "groupBox_Info1";
            this.groupBox_Info1.Size = new System.Drawing.Size(655, 554);
            this.groupBox_Info1.TabIndex = 19;
            this.groupBox_Info1.TabStop = false;
            this.groupBox_Info1.Text = "Info1";
            // 
            // comboBox_PlantQualityManager
            // 
            this.comboBox_PlantQualityManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PlantQualityManager.FormattingEnabled = true;
            this.comboBox_PlantQualityManager.Location = new System.Drawing.Point(144, 462);
            this.comboBox_PlantQualityManager.Name = "comboBox_PlantQualityManager";
            this.comboBox_PlantQualityManager.Size = new System.Drawing.Size(134, 21);
            this.comboBox_PlantQualityManager.TabIndex = 33;
            // 
            // comboBox_TestManager
            // 
            this.comboBox_TestManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TestManager.FormattingEnabled = true;
            this.comboBox_TestManager.Location = new System.Drawing.Point(144, 436);
            this.comboBox_TestManager.Name = "comboBox_TestManager";
            this.comboBox_TestManager.Size = new System.Drawing.Size(134, 21);
            this.comboBox_TestManager.TabIndex = 32;
            // 
            // comboBox_TestEngineer
            // 
            this.comboBox_TestEngineer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TestEngineer.FormattingEnabled = true;
            this.comboBox_TestEngineer.Location = new System.Drawing.Point(144, 381);
            this.comboBox_TestEngineer.Name = "comboBox_TestEngineer";
            this.comboBox_TestEngineer.Size = new System.Drawing.Size(134, 21);
            this.comboBox_TestEngineer.TabIndex = 31;
            // 
            // textBox_FixtureName
            // 
            this.textBox_FixtureName.Location = new System.Drawing.Point(144, 219);
            this.textBox_FixtureName.Name = "textBox_FixtureName";
            this.textBox_FixtureName.Size = new System.Drawing.Size(227, 20);
            this.textBox_FixtureName.TabIndex = 30;
            this.textBox_FixtureName.Text = "77 G1.3 Corner Fixture";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(57, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Fixture Name：";
            // 
            // comboBox_PME
            // 
            this.comboBox_PME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PME.FormattingEnabled = true;
            this.comboBox_PME.Location = new System.Drawing.Point(144, 410);
            this.comboBox_PME.Name = "comboBox_PME";
            this.comboBox_PME.Size = new System.Drawing.Size(134, 21);
            this.comboBox_PME.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 465);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Plant Quality Manager：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(53, 439);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Test Manager：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(96, 413);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "PME：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 384);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Test Engineer：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(378, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "(Enter single line one by one)";
            // 
            // textBox_Equ_FixtureNum_Example
            // 
            this.textBox_Equ_FixtureNum_Example.Enabled = false;
            this.textBox_Equ_FixtureNum_Example.Location = new System.Drawing.Point(382, 95);
            this.textBox_Equ_FixtureNum_Example.Multiline = true;
            this.textBox_Equ_FixtureNum_Example.Name = "textBox_Equ_FixtureNum_Example";
            this.textBox_Equ_FixtureNum_Example.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Equ_FixtureNum_Example.Size = new System.Drawing.Size(261, 92);
            this.textBox_Equ_FixtureNum_Example.TabIndex = 18;
            this.textBox_Equ_FixtureNum_Example.Text = "EPT-RDR05G1.3-01-01\r\nEPT-RDR05G1.3-01-02";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(378, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(265, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "(e.g: EPT-RDR05G1.3-01-01/EPT-RDR05G1.3-01-02)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(377, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "(e.g: CFM-PE-VRRD0502-08-04)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(284, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "(e.g: Radar 5)";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Null);
            this.tabControl1.Controls.Add(this.Radar);
            this.tabControl1.Controls.Add(this.Radar_PDI_VS412);
            this.tabControl1.Controls.Add(this.Radar_Packing);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(143, 426);
            this.tabControl1.TabIndex = 20;
            // 
            // Null
            // 
            this.Null.Location = new System.Drawing.Point(4, 22);
            this.Null.Name = "Null";
            this.Null.Padding = new System.Windows.Forms.Padding(3);
            this.Null.Size = new System.Drawing.Size(135, 400);
            this.Null.TabIndex = 3;
            this.Null.Text = "Null";
            this.Null.UseVisualStyleBackColor = true;
            // 
            // Radar
            // 
            this.Radar.Controls.Add(this.radioBtn_SEL);
            this.Radar.Controls.Add(this.radioBtn_SensorTest);
            this.Radar.Location = new System.Drawing.Point(4, 22);
            this.Radar.Name = "Radar";
            this.Radar.Padding = new System.Windows.Forms.Padding(3);
            this.Radar.Size = new System.Drawing.Size(135, 400);
            this.Radar.TabIndex = 0;
            this.Radar.Text = "Radar";
            this.Radar.UseVisualStyleBackColor = true;
            // 
            // radioBtn_SEL
            // 
            this.radioBtn_SEL.AutoSize = true;
            this.radioBtn_SEL.Location = new System.Drawing.Point(6, 52);
            this.radioBtn_SEL.Name = "radioBtn_SEL";
            this.radioBtn_SEL.Size = new System.Drawing.Size(45, 17);
            this.radioBtn_SEL.TabIndex = 1;
            this.radioBtn_SEL.Text = "SEL";
            this.radioBtn_SEL.UseVisualStyleBackColor = true;
            // 
            // radioBtn_SensorTest
            // 
            this.radioBtn_SensorTest.AutoSize = true;
            this.radioBtn_SensorTest.Checked = true;
            this.radioBtn_SensorTest.Location = new System.Drawing.Point(6, 18);
            this.radioBtn_SensorTest.Name = "radioBtn_SensorTest";
            this.radioBtn_SensorTest.Size = new System.Drawing.Size(79, 17);
            this.radioBtn_SensorTest.TabIndex = 0;
            this.radioBtn_SensorTest.TabStop = true;
            this.radioBtn_SensorTest.Text = "SensorTest";
            this.radioBtn_SensorTest.UseVisualStyleBackColor = true;
            // 
            // Radar_PDI_VS412
            // 
            this.Radar_PDI_VS412.Controls.Add(this.button2);
            this.Radar_PDI_VS412.Location = new System.Drawing.Point(4, 22);
            this.Radar_PDI_VS412.Name = "Radar_PDI_VS412";
            this.Radar_PDI_VS412.Padding = new System.Windows.Forms.Padding(3);
            this.Radar_PDI_VS412.Size = new System.Drawing.Size(135, 400);
            this.Radar_PDI_VS412.TabIndex = 1;
            this.Radar_PDI_VS412.Text = "Radar_PDI_VS412";
            this.Radar_PDI_VS412.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 29);
            this.button2.TabIndex = 0;
            this.button2.Text = "PDI";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Radar_Packing
            // 
            this.Radar_Packing.Controls.Add(this.button3);
            this.Radar_Packing.Location = new System.Drawing.Point(4, 22);
            this.Radar_Packing.Name = "Radar_Packing";
            this.Radar_Packing.Padding = new System.Windows.Forms.Padding(3);
            this.Radar_Packing.Size = new System.Drawing.Size(135, 400);
            this.Radar_Packing.TabIndex = 2;
            this.Radar_Packing.Text = "Radar_Packing";
            this.Radar_Packing.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 29);
            this.button3.TabIndex = 22;
            this.button3.Text = "Packing";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox_TS
            // 
            this.groupBox_TS.Controls.Add(this.tabControl1);
            this.groupBox_TS.Location = new System.Drawing.Point(12, 126);
            this.groupBox_TS.Name = "groupBox_TS";
            this.groupBox_TS.Size = new System.Drawing.Size(143, 426);
            this.groupBox_TS.TabIndex = 21;
            this.groupBox_TS.TabStop = false;
            this.groupBox_TS.Text = "TS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(851, 184);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 501);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btn_LoadPic
            // 
            this.btn_LoadPic.Location = new System.Drawing.Point(851, 131);
            this.btn_LoadPic.Name = "btn_LoadPic";
            this.btn_LoadPic.Size = new System.Drawing.Size(92, 21);
            this.btn_LoadPic.TabIndex = 16;
            this.btn_LoadPic.Text = "Load pic";
            this.btn_LoadPic.UseVisualStyleBackColor = true;
            this.btn_LoadPic.Click += new System.EventHandler(this.btn_LoadPic_Click);
            // 
            // textBox_LoadPic
            // 
            this.textBox_LoadPic.Enabled = false;
            this.textBox_LoadPic.Location = new System.Drawing.Point(851, 158);
            this.textBox_LoadPic.Name = "textBox_LoadPic";
            this.textBox_LoadPic.Size = new System.Drawing.Size(402, 20);
            this.textBox_LoadPic.TabIndex = 23;
            // 
            // FrmConformityReport
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1383, 775);
            this.Controls.Add(this.textBox_LoadPic);
            this.Controls.Add(this.btn_LoadPic);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox_TS);
            this.Controls.Add(this.groupBox_Info1);
            this.Controls.Add(panelWhere);
            this.Controls.Add(this.tsMenus);
            this.Name = "FrmConformityReport";
            this.ShowIcon = false;
            this.Text = "Conformity Report";
            this.Load += new System.EventHandler(this.FrmConformityReport_Load);
            panelWhere.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tsMenus.ResumeLayout(false);
            this.tsMenus.PerformLayout();
            this.groupBox_Info1.ResumeLayout(false);
            this.groupBox_Info1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Radar.ResumeLayout(false);
            this.Radar.PerformLayout();
            this.Radar_PDI_VS412.ResumeLayout(false);
            this.Radar_Packing.ResumeLayout(false);
            this.groupBox_TS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenus;
        private System.Windows.Forms.ToolStripButton tsbtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripButton tsBtnHelp;
        private System.Windows.Forms.Button btn_GenConformityReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_FileNum;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox_EquipOrFixtureNum;
        private System.Windows.Forms.Label label_Equip_Fixture;
        private System.Windows.Forms.TextBox textBox_Line;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ValidationDate;
        private System.Windows.Forms.ComboBox comboBox_Station;
        private System.Windows.Forms.GroupBox groupBox_Info1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Radar;
        private System.Windows.Forms.TabPage Radar_PDI_VS412;
        private System.Windows.Forms.TabPage Radar_Packing;
        private System.Windows.Forms.RadioButton radioBtn_SEL;
        private System.Windows.Forms.RadioButton radioBtn_SensorTest;
        private System.Windows.Forms.GroupBox groupBox_TS;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage Null;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Equ_FixtureNum_Example;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_LoadPic;
        private System.Windows.Forms.TextBox textBox_LoadPic;
        private System.Windows.Forms.ComboBox comboBox_PME;
        private System.Windows.Forms.TextBox textBox_FixtureName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox_PlantQualityManager;
        private System.Windows.Forms.ComboBox comboBox_TestManager;
        private System.Windows.Forms.ComboBox comboBox_TestEngineer;
    }
}