namespace WinPMS.Radar
{
    partial class FrmRadarPackingInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRadarPackingInfo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadPackingWI = new System.Windows.Forms.Button();
            this.btnOpenRadarPackingBackupFolder = new System.Windows.Forms.Button();
            this.btnTestInputPackingInfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ShippingPN = new System.Windows.Forms.TextBox();
            this.textBox_CustomerPN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_SupplierCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Qty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_BoxNr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_BoxNrLen = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tsMenus = new System.Windows.Forms.ToolStrip();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHelp = new System.Windows.Forms.ToolStripButton();
            this.btnAddPackingInfo = new System.Windows.Forms.Button();
            this.textBox_VehiclePN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_Template = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_SNl = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_FixtureNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDebug = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewWI = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBoxConfigFromWI = new System.Windows.Forms.ToolStripTextBox();
            panelWhere = new System.Windows.Forms.Panel();
            panelWhere.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tsMenus.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWI)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWhere
            // 
            panelWhere.Controls.Add(this.groupBox1);
            panelWhere.Dock = System.Windows.Forms.DockStyle.Top;
            panelWhere.Location = new System.Drawing.Point(0, 45);
            panelWhere.Name = "panelWhere";
            panelWhere.Size = new System.Drawing.Size(1242, 55);
            panelWhere.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoadPackingWI);
            this.groupBox1.Controls.Add(this.btnOpenRadarPackingBackupFolder);
            this.groupBox1.Controls.Add(this.btnTestInputPackingInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1242, 55);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reserved Area";
            // 
            // btnLoadPackingWI
            // 
            this.btnLoadPackingWI.Location = new System.Drawing.Point(5, 15);
            this.btnLoadPackingWI.Name = "btnLoadPackingWI";
            this.btnLoadPackingWI.Size = new System.Drawing.Size(109, 34);
            this.btnLoadPackingWI.TabIndex = 29;
            this.btnLoadPackingWI.Text = "加载雷达包装WI";
            this.btnLoadPackingWI.UseVisualStyleBackColor = true;
            this.btnLoadPackingWI.Click += new System.EventHandler(this.btnLoadPackingWI_Click);
            // 
            // btnOpenRadarPackingBackupFolder
            // 
            this.btnOpenRadarPackingBackupFolder.Location = new System.Drawing.Point(160, 15);
            this.btnOpenRadarPackingBackupFolder.Name = "btnOpenRadarPackingBackupFolder";
            this.btnOpenRadarPackingBackupFolder.Size = new System.Drawing.Size(109, 34);
            this.btnOpenRadarPackingBackupFolder.TabIndex = 28;
            this.btnOpenRadarPackingBackupFolder.Text = "打开备份文件";
            this.btnOpenRadarPackingBackupFolder.UseVisualStyleBackColor = true;
            this.btnOpenRadarPackingBackupFolder.Click += new System.EventHandler(this.btnOpenRadarPackingBackupFolder_Click);
            // 
            // btnTestInputPackingInfo
            // 
            this.btnTestInputPackingInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTestInputPackingInfo.Location = new System.Drawing.Point(1136, 15);
            this.btnTestInputPackingInfo.Name = "btnTestInputPackingInfo";
            this.btnTestInputPackingInfo.Size = new System.Drawing.Size(104, 38);
            this.btnTestInputPackingInfo.TabIndex = 28;
            this.btnTestInputPackingInfo.Text = "测试输入\r\nPacking Info";
            this.btnTestInputPackingInfo.UseVisualStyleBackColor = true;
            this.btnTestInputPackingInfo.Click += new System.EventHandler(this.btnTestInputPackingInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Shipping PN (Shipping号)";
            // 
            // textBox_ShippingPN
            // 
            this.textBox_ShippingPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_ShippingPN.Location = new System.Drawing.Point(219, 23);
            this.textBox_ShippingPN.Name = "textBox_ShippingPN";
            this.textBox_ShippingPN.Size = new System.Drawing.Size(249, 20);
            this.textBox_ShippingPN.TabIndex = 4;
            // 
            // textBox_CustomerPN
            // 
            this.textBox_CustomerPN.Location = new System.Drawing.Point(219, 93);
            this.textBox_CustomerPN.Name = "textBox_CustomerPN";
            this.textBox_CustomerPN.Size = new System.Drawing.Size(249, 20);
            this.textBox_CustomerPN.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Customer PN (客户料号)";
            // 
            // textBox_SupplierCode
            // 
            this.textBox_SupplierCode.Location = new System.Drawing.Point(219, 128);
            this.textBox_SupplierCode.Name = "textBox_SupplierCode";
            this.textBox_SupplierCode.Size = new System.Drawing.Size(249, 20);
            this.textBox_SupplierCode.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Supplier Code (供应商代码)";
            // 
            // textBox_Description
            // 
            this.textBox_Description.Location = new System.Drawing.Point(219, 198);
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(249, 20);
            this.textBox_Description.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Description (描述)";
            // 
            // textBox_Qty
            // 
            this.textBox_Qty.Location = new System.Drawing.Point(219, 163);
            this.textBox_Qty.Name = "textBox_Qty";
            this.textBox_Qty.Size = new System.Drawing.Size(249, 20);
            this.textBox_Qty.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Qty (数量)";
            // 
            // textBox_BoxNr
            // 
            this.textBox_BoxNr.Location = new System.Drawing.Point(219, 233);
            this.textBox_BoxNr.Name = "textBox_BoxNr";
            this.textBox_BoxNr.Size = new System.Drawing.Size(249, 20);
            this.textBox_BoxNr.TabIndex = 14;
            this.textBox_BoxNr.TextChanged += new System.EventHandler(this.textBox_BoxNr_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "BoxNr (包装箱条码)";
            // 
            // textBox_BoxNrLen
            // 
            this.textBox_BoxNrLen.Location = new System.Drawing.Point(219, 268);
            this.textBox_BoxNrLen.Name = "textBox_BoxNrLen";
            this.textBox_BoxNrLen.ReadOnly = true;
            this.textBox_BoxNrLen.Size = new System.Drawing.Size(249, 20);
            this.textBox_BoxNrLen.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "BoxNrLen (包装箱条码长度)";
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
            this.tsMenus.Size = new System.Drawing.Size(1242, 45);
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
            this.tsBtnHelp.Click += new System.EventHandler(this.tsBtnHelp_Click);
            // 
            // btnAddPackingInfo
            // 
            this.btnAddPackingInfo.Location = new System.Drawing.Point(639, 23);
            this.btnAddPackingInfo.Name = "btnAddPackingInfo";
            this.btnAddPackingInfo.Size = new System.Drawing.Size(123, 51);
            this.btnAddPackingInfo.TabIndex = 17;
            this.btnAddPackingInfo.Text = "新加 / 修改 / 删除";
            this.btnAddPackingInfo.UseVisualStyleBackColor = true;
            this.btnAddPackingInfo.Click += new System.EventHandler(this.btnAddPackingInfo_Click);
            // 
            // textBox_VehiclePN
            // 
            this.textBox_VehiclePN.Location = new System.Drawing.Point(219, 58);
            this.textBox_VehiclePN.Name = "textBox_VehiclePN";
            this.textBox_VehiclePN.Size = new System.Drawing.Size(249, 20);
            this.textBox_VehiclePN.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Vehicle PN (Veh号)";
            // 
            // comboBox_Template
            // 
            this.comboBox_Template.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Template.FormattingEnabled = true;
            this.comboBox_Template.Location = new System.Drawing.Point(219, 373);
            this.comboBox_Template.Name = "comboBox_Template";
            this.comboBox_Template.Size = new System.Drawing.Size(249, 21);
            this.comboBox_Template.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Template (包装标签模板)";
            // 
            // textBox_SNl
            // 
            this.textBox_SNl.Location = new System.Drawing.Point(219, 303);
            this.textBox_SNl.Name = "textBox_SNl";
            this.textBox_SNl.Size = new System.Drawing.Size(529, 20);
            this.textBox_SNl.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(72, 306);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "SNl (产品标签二维码长度)";
            // 
            // textBox_FixtureNo
            // 
            this.textBox_FixtureNo.Location = new System.Drawing.Point(219, 338);
            this.textBox_FixtureNo.Name = "textBox_FixtureNo";
            this.textBox_FixtureNo.Size = new System.Drawing.Size(249, 20);
            this.textBox_FixtureNo.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 341);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(205, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "FixtureNo (KeyWay tool的二维码字符串)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Yellow;
            this.label12.Location = new System.Drawing.Point(474, 341);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "(可为空)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Yellow;
            this.label13.Location = new System.Drawing.Point(474, 376);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(260, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "(一般情况下选Radar77_S.xls；GM选China CV7.xls)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDebug);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnAddPackingInfo);
            this.groupBox2.Controls.Add(this.textBox_ShippingPN);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_FixtureNo);
            this.groupBox2.Controls.Add(this.textBox_CustomerPN);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_SNl);
            this.groupBox2.Controls.Add(this.textBox_SupplierCode);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox_Description);
            this.groupBox2.Controls.Add(this.comboBox_Template);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_VehiclePN);
            this.groupBox2.Controls.Add(this.textBox_Qty);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_BoxNrLen);
            this.groupBox2.Controls.Add(this.textBox_BoxNr);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 426);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1242, 415);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Radar Packing Config";
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(1113, 24);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(123, 48);
            this.btnDebug.TabIndex = 28;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewWI);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1242, 326);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Radar Packing WI";
            // 
            // dataGridViewWI
            // 
            this.dataGridViewWI.AllowUserToAddRows = false;
            this.dataGridViewWI.AllowUserToDeleteRows = false;
            this.dataGridViewWI.AllowUserToResizeColumns = false;
            this.dataGridViewWI.AllowUserToResizeRows = false;
            this.dataGridViewWI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewWI.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewWI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWI.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewWI.MultiSelect = false;
            this.dataGridViewWI.Name = "dataGridViewWI";
            this.dataGridViewWI.ReadOnly = true;
            this.dataGridViewWI.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridViewWI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWI.Size = new System.Drawing.Size(1236, 307);
            this.dataGridViewWI.TabIndex = 0;
            this.dataGridViewWI.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewWI_CellMouseDown);
            this.dataGridViewWI.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridViewWI_RowStateChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxConfigFromWI});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(136, 29);
            // 
            // toolStripTextBoxConfigFromWI
            // 
            this.toolStripTextBoxConfigFromWI.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxConfigFromWI.Name = "toolStripTextBoxConfigFromWI";
            this.toolStripTextBoxConfigFromWI.ReadOnly = true;
            this.toolStripTextBoxConfigFromWI.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxConfigFromWI.Text = "配置";
            this.toolStripTextBoxConfigFromWI.Click += new System.EventHandler(this.toolStripTextBoxConfigFromWI_Click);
            // 
            // FrmRadarPackingInfo
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1242, 841);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(panelWhere);
            this.Controls.Add(this.tsMenus);
            this.Name = "FrmRadarPackingInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRadarPackingInfo";
            this.Load += new System.EventHandler(this.FrmRadarPackingInfo_Load);
            panelWhere.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tsMenus.ResumeLayout(false);
            this.tsMenus.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWI)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripButton tsBtnHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ShippingPN;
        private System.Windows.Forms.TextBox textBox_CustomerPN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_SupplierCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Qty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_BoxNr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_BoxNrLen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddPackingInfo;
        private System.Windows.Forms.TextBox textBox_VehiclePN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_Template;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_SNl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_FixtureNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnTestInputPackingInfo;
        private System.Windows.Forms.Button btnOpenRadarPackingBackupFolder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewWI;
        private System.Windows.Forms.Button btnLoadPackingWI;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxConfigFromWI;
        private System.Windows.Forms.Button btnDebug;
    }
}