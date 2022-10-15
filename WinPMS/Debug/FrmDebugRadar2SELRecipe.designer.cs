namespace WinPMS.Debug
{
    partial class FrmDebugRadar2SELRecipe
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Panel panelWhere;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDebugRadar2SELRecipe));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bu = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Sensor_ID_OEM = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Sensor_ID_Manu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_PCBA = new System.Windows.Forms.TextBox();
            this.btn_SameAsVeh = new System.Windows.Forms.Button();
            this.txt_Model = new System.Windows.Forms.TextBox();
            this.btn_LoadVehNoFolder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_VehNo = new System.Windows.Forms.TextBox();
            this.txt_TestFilesFolderVehNo = new System.Windows.Forms.TextBox();
            this.btn_ReadXML = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_HousingPN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ShippingBom = new System.Windows.Forms.TextBox();
            this.btn_ReadExcel = new System.Windows.Forms.Button();
            this.btn_GenRecipe = new System.Windows.Forms.Button();
            this.txt_RecipeDescPrefix = new System.Windows.Forms.TextBox();
            this.combox_RadarType = new System.Windows.Forms.ComboBox();
            this.combox_Customer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.combox_Gen = new System.Windows.Forms.ComboBox();
            this.dgvRecipe = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenus = new System.Windows.Forms.ToolStrip();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHelp = new System.Windows.Forms.ToolStripButton();
            this.btn_Test = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btn_OpenRecipe = new System.Windows.Forms.Button();
            panelWhere = new System.Windows.Forms.Panel();
            panelWhere.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tsMenus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWhere
            // 
            panelWhere.Controls.Add(this.groupBox1);
            panelWhere.Dock = System.Windows.Forms.DockStyle.Top;
            panelWhere.Location = new System.Drawing.Point(0, 70);
            panelWhere.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelWhere.Name = "panelWhere";
            panelWhere.Size = new System.Drawing.Size(1898, 229);
            panelWhere.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_OpenRecipe);
            this.groupBox1.Controls.Add(this.bu);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_Sensor_ID_OEM);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_Sensor_ID_Manu);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_PCBA);
            this.groupBox1.Controls.Add(this.btn_SameAsVeh);
            this.groupBox1.Controls.Add(this.txt_Model);
            this.groupBox1.Controls.Add(this.btn_LoadVehNoFolder);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_VehNo);
            this.groupBox1.Controls.Add(this.txt_TestFilesFolderVehNo);
            this.groupBox1.Controls.Add(this.btn_ReadXML);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_HousingPN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_ShippingBom);
            this.groupBox1.Controls.Add(this.btn_ReadExcel);
            this.groupBox1.Controls.Add(this.btn_GenRecipe);
            this.groupBox1.Controls.Add(this.txt_RecipeDescPrefix);
            this.groupBox1.Controls.Add(this.combox_RadarType);
            this.groupBox1.Controls.Add(this.combox_Customer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.combox_Gen);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1898, 229);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // bu
            // 
            this.bu.Location = new System.Drawing.Point(1265, 86);
            this.bu.Name = "bu";
            this.bu.Size = new System.Drawing.Size(111, 43);
            this.bu.TabIndex = 37;
            this.bu.Text = "Test";
            this.bu.UseVisualStyleBackColor = true;
            this.bu.Visible = false;
            this.bu.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(835, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 20);
            this.label8.TabIndex = 36;
            this.label8.Text = "Sensor ID (OEM):";
            // 
            // txt_Sensor_ID_OEM
            // 
            this.txt_Sensor_ID_OEM.Location = new System.Drawing.Point(980, 133);
            this.txt_Sensor_ID_OEM.Name = "txt_Sensor_ID_OEM";
            this.txt_Sensor_ID_OEM.Size = new System.Drawing.Size(144, 26);
            this.txt_Sensor_ID_OEM.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(835, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 20);
            this.label7.TabIndex = 34;
            this.label7.Text = "Sensor ID (Manu):";
            // 
            // txt_Sensor_ID_Manu
            // 
            this.txt_Sensor_ID_Manu.Location = new System.Drawing.Point(980, 94);
            this.txt_Sensor_ID_Manu.Name = "txt_Sensor_ID_Manu";
            this.txt_Sensor_ID_Manu.Size = new System.Drawing.Size(144, 26);
            this.txt_Sensor_ID_Manu.TabIndex = 33;
            this.txt_Sensor_ID_Manu.Text = "4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(831, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "PCBA (SNFormat):";
            // 
            // txt_PCBA
            // 
            this.txt_PCBA.Location = new System.Drawing.Point(980, 57);
            this.txt_PCBA.Name = "txt_PCBA";
            this.txt_PCBA.Size = new System.Drawing.Size(144, 26);
            this.txt_PCBA.TabIndex = 31;
            // 
            // btn_SameAsVeh
            // 
            this.btn_SameAsVeh.Location = new System.Drawing.Point(1130, 164);
            this.btn_SameAsVeh.Name = "btn_SameAsVeh";
            this.btn_SameAsVeh.Size = new System.Drawing.Size(136, 29);
            this.btn_SameAsVeh.TabIndex = 30;
            this.btn_SameAsVeh.Text = "Same as Veh";
            this.btn_SameAsVeh.UseVisualStyleBackColor = true;
            this.btn_SameAsVeh.Click += new System.EventHandler(this.btn_SameAsVeh_Click);
            // 
            // txt_Model
            // 
            this.txt_Model.Location = new System.Drawing.Point(1382, 20);
            this.txt_Model.Name = "txt_Model";
            this.txt_Model.Size = new System.Drawing.Size(144, 26);
            this.txt_Model.TabIndex = 29;
            this.txt_Model.Text = "Model";
            // 
            // btn_LoadVehNoFolder
            // 
            this.btn_LoadVehNoFolder.Location = new System.Drawing.Point(138, 86);
            this.btn_LoadVehNoFolder.Name = "btn_LoadVehNoFolder";
            this.btn_LoadVehNoFolder.Size = new System.Drawing.Size(185, 43);
            this.btn_LoadVehNoFolder.TabIndex = 28;
            this.btn_LoadVehNoFolder.Text = "Load Veh No Folder";
            this.btn_LoadVehNoFolder.UseVisualStyleBackColor = true;
            this.btn_LoadVehNoFolder.Click += new System.EventHandler(this.btn_LoadVehNoFolder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "TestFiles Folder:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Veh No:";
            // 
            // txt_VehNo
            // 
            this.txt_VehNo.Enabled = false;
            this.txt_VehNo.Location = new System.Drawing.Point(138, 54);
            this.txt_VehNo.Name = "txt_VehNo";
            this.txt_VehNo.Size = new System.Drawing.Size(185, 26);
            this.txt_VehNo.TabIndex = 25;
            // 
            // txt_TestFilesFolderVehNo
            // 
            this.txt_TestFilesFolderVehNo.Enabled = false;
            this.txt_TestFilesFolderVehNo.Location = new System.Drawing.Point(138, 22);
            this.txt_TestFilesFolderVehNo.Name = "txt_TestFilesFolderVehNo";
            this.txt_TestFilesFolderVehNo.Size = new System.Drawing.Size(664, 26);
            this.txt_TestFilesFolderVehNo.TabIndex = 24;
            // 
            // btn_ReadXML
            // 
            this.btn_ReadXML.Location = new System.Drawing.Point(1382, 135);
            this.btn_ReadXML.Name = "btn_ReadXML";
            this.btn_ReadXML.Size = new System.Drawing.Size(149, 43);
            this.btn_ReadXML.TabIndex = 23;
            this.btn_ReadXML.Text = "Read XML";
            this.btn_ReadXML.UseVisualStyleBackColor = true;
            this.btn_ReadXML.Click += new System.EventHandler(this.btn_ReadXML_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(881, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "HousingPN:";
            // 
            // txt_HousingPN
            // 
            this.txt_HousingPN.Location = new System.Drawing.Point(980, 197);
            this.txt_HousingPN.Name = "txt_HousingPN";
            this.txt_HousingPN.Size = new System.Drawing.Size(144, 26);
            this.txt_HousingPN.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(866, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "ShippingBom:";
            // 
            // txt_ShippingBom
            // 
            this.txt_ShippingBom.Location = new System.Drawing.Point(980, 165);
            this.txt_ShippingBom.Name = "txt_ShippingBom";
            this.txt_ShippingBom.Size = new System.Drawing.Size(144, 26);
            this.txt_ShippingBom.TabIndex = 19;
            // 
            // btn_ReadExcel
            // 
            this.btn_ReadExcel.Location = new System.Drawing.Point(1382, 86);
            this.btn_ReadExcel.Name = "btn_ReadExcel";
            this.btn_ReadExcel.Size = new System.Drawing.Size(149, 43);
            this.btn_ReadExcel.TabIndex = 18;
            this.btn_ReadExcel.Text = "Read Excel";
            this.btn_ReadExcel.UseVisualStyleBackColor = true;
            this.btn_ReadExcel.Visible = false;
            this.btn_ReadExcel.Click += new System.EventHandler(this.btn_ReadExcel_Click);
            // 
            // btn_GenRecipe
            // 
            this.btn_GenRecipe.Location = new System.Drawing.Point(1662, 18);
            this.btn_GenRecipe.Name = "btn_GenRecipe";
            this.btn_GenRecipe.Size = new System.Drawing.Size(149, 43);
            this.btn_GenRecipe.TabIndex = 17;
            this.btn_GenRecipe.Text = "Gen Recipe";
            this.btn_GenRecipe.UseVisualStyleBackColor = true;
            this.btn_GenRecipe.Click += new System.EventHandler(this.btn_Gen_Recipe_Click);
            // 
            // txt_RecipeDescPrefix
            // 
            this.txt_RecipeDescPrefix.Enabled = false;
            this.txt_RecipeDescPrefix.Location = new System.Drawing.Point(980, 20);
            this.txt_RecipeDescPrefix.Name = "txt_RecipeDescPrefix";
            this.txt_RecipeDescPrefix.Size = new System.Drawing.Size(144, 26);
            this.txt_RecipeDescPrefix.TabIndex = 16;
            this.txt_RecipeDescPrefix.Text = "Radar 77GHz";
            // 
            // combox_RadarType
            // 
            this.combox_RadarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combox_RadarType.FormattingEnabled = true;
            this.combox_RadarType.Items.AddRange(new object[] {
            "FLR",
            "RCR"});
            this.combox_RadarType.Location = new System.Drawing.Point(1532, 18);
            this.combox_RadarType.Name = "combox_RadarType";
            this.combox_RadarType.Size = new System.Drawing.Size(113, 28);
            this.combox_RadarType.TabIndex = 15;
            // 
            // combox_Customer
            // 
            this.combox_Customer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combox_Customer.FormattingEnabled = true;
            this.combox_Customer.Location = new System.Drawing.Point(1272, 20);
            this.combox_Customer.Name = "combox_Customer";
            this.combox_Customer.Size = new System.Drawing.Size(104, 28);
            this.combox_Customer.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(881, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Description:";
            // 
            // combox_Gen
            // 
            this.combox_Gen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combox_Gen.FormattingEnabled = true;
            this.combox_Gen.Items.AddRange(new object[] {
            "G1.2",
            "G1.3"});
            this.combox_Gen.Location = new System.Drawing.Point(1130, 20);
            this.combox_Gen.Name = "combox_Gen";
            this.combox_Gen.Size = new System.Drawing.Size(136, 28);
            this.combox_Gen.TabIndex = 12;
            // 
            // dgvRecipe
            // 
            this.dgvRecipe.AllowUserToResizeColumns = false;
            this.dgvRecipe.AllowUserToResizeRows = false;
            this.dgvRecipe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRecipe.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecipe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecipe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipe.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecipe.Location = new System.Drawing.Point(0, 0);
            this.dgvRecipe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvRecipe.MultiSelect = false;
            this.dgvRecipe.Name = "dgvRecipe";
            this.dgvRecipe.ReadOnly = true;
            this.dgvRecipe.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRecipe.RowHeadersWidth = 51;
            this.dgvRecipe.RowTemplate.Height = 23;
            this.dgvRecipe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecipe.Size = new System.Drawing.Size(1447, 751);
            this.dgvRecipe.TabIndex = 3;
            this.dgvRecipe.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRecipe_CellMouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 36);
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(141, 32);
            this.modifyToolStripMenuItem.Text = "Modify";
            this.modifyToolStripMenuItem.Click += new System.EventHandler(this.modifyToolStripMenuItem_Click);
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
            this.tsMenus.Padding = new System.Windows.Forms.Padding(0, 0, 1, 3);
            this.tsMenus.Size = new System.Drawing.Size(1898, 70);
            this.tsMenus.TabIndex = 1;
            this.tsMenus.Text = "toolStrip1";
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.Enabled = false;
            this.tsbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDelete.Image")));
            this.tsbtnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(47, 61);
            this.tsbtnDelete.Text = " Del";
            this.tsbtnDelete.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnDelete.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 67);
            // 
            // tsbtnInfo
            // 
            this.tsbtnInfo.Enabled = false;
            this.tsbtnInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInfo.Image")));
            this.tsbtnInfo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnInfo.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnInfo.Name = "tsbtnInfo";
            this.tsbtnInfo.Size = new System.Drawing.Size(66, 61);
            this.tsbtnInfo.Text = " Detail";
            this.tsbtnInfo.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 67);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.Enabled = false;
            this.tsbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefresh.Image")));
            this.tsbtnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(72, 61);
            this.tsbtnRefresh.Text = "Reflash";
            this.tsbtnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 67);
            // 
            // tsbtnClose
            // 
            this.tsbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClose.Image")));
            this.tsbtnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClose.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnClose.Name = "tsbtnClose";
            this.tsbtnClose.Size = new System.Drawing.Size(59, 61);
            this.tsbtnClose.Text = "Close";
            this.tsbtnClose.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
            // 
            // tsBtnHelp
            // 
            this.tsBtnHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnHelp.Image")));
            this.tsBtnHelp.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsBtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnHelp.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsBtnHelp.Name = "tsBtnHelp";
            this.tsBtnHelp.Size = new System.Drawing.Size(53, 61);
            this.tsBtnHelp.Text = "Help";
            this.tsBtnHelp.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsBtnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnHelp.Click += new System.EventHandler(this.tsBtnHelp_Click);
            // 
            // btn_Test
            // 
            this.btn_Test.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Test.FormattingEnabled = true;
            this.btn_Test.ItemHeight = 20;
            this.btn_Test.Location = new System.Drawing.Point(0, 0);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(447, 244);
            this.btn_Test.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 299);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox2);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Test);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvRecipe);
            this.splitContainer1.Size = new System.Drawing.Size(1898, 751);
            this.splitContainer1.SplitterDistance = 447;
            this.splitContainer1.TabIndex = 3;
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(0, 244);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(447, 507);
            this.listBox2.TabIndex = 5;
            // 
            // btn_OpenRecipe
            // 
            this.btn_OpenRecipe.Location = new System.Drawing.Point(1662, 86);
            this.btn_OpenRecipe.Name = "btn_OpenRecipe";
            this.btn_OpenRecipe.Size = new System.Drawing.Size(149, 43);
            this.btn_OpenRecipe.TabIndex = 38;
            this.btn_OpenRecipe.Text = "Open Recipe";
            this.btn_OpenRecipe.UseVisualStyleBackColor = true;
            this.btn_OpenRecipe.Click += new System.EventHandler(this.btn_OpenRecipe_Click);
            // 
            // FrmDebugRadar2SELRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1050);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(panelWhere);
            this.Controls.Add(this.tsMenus);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmDebugRadar2SELRecipe";
            this.ShowIcon = false;
            this.Text = "FrmDebugRadar2SELRecipe";
            this.Load += new System.EventHandler(this.FrmDebugRadar2SELRecipe_Load);
            panelWhere.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tsMenus.ResumeLayout(false);
            this.tsMenus.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DataGridView dgvRecipe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripButton tsBtnHelp;
        private System.Windows.Forms.TextBox txt_RecipeDescPrefix;
        private System.Windows.Forms.ComboBox combox_RadarType;
        private System.Windows.Forms.ComboBox combox_Customer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combox_Gen;
        private System.Windows.Forms.Button btn_GenRecipe;
        private System.Windows.Forms.Button btn_ReadExcel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_HousingPN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ShippingBom;
        private System.Windows.Forms.Button btn_ReadXML;
        private System.Windows.Forms.TextBox txt_TestFilesFolderVehNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_VehNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_LoadVehNoFolder;
        private System.Windows.Forms.TextBox txt_Model;
        private System.Windows.Forms.ListBox btn_Test;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_SameAsVeh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_PCBA;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Sensor_ID_OEM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Sensor_ID_Manu;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.Button bu;
        private System.Windows.Forms.Button btn_OpenRecipe;
    }
}