namespace WinPMS.Radar
{
    partial class FrmRadarPacking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRadarPacking));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxPackingLine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_PackingIniFile = new System.Windows.Forms.Label();
            this.textBoxRadarDriveIP = new System.Windows.Forms.TextBox();
            this.lbl_NewPackingInfoIndex = new System.Windows.Forms.Label();
            this.btnReadPackingINI = new System.Windows.Forms.Button();
            this.btnSwitchToNewPackingInfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBoxAddAboveByNew = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxAddBelowByNew = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxAddByCopy = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxAddAboveByCopy = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxAddBelowByCopy = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxModifyPacking = new System.Windows.Forms.ToolStripTextBox();
            this.tsMenus = new System.Windows.Forms.ToolStrip();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxDeletePacking = new System.Windows.Forms.ToolStripTextBox();
            panelWhere = new System.Windows.Forms.Panel();
            panelWhere.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tsMenus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWhere
            // 
            panelWhere.Controls.Add(this.groupBox1);
            panelWhere.Dock = System.Windows.Forms.DockStyle.Top;
            panelWhere.Location = new System.Drawing.Point(0, 45);
            panelWhere.Name = "panelWhere";
            panelWhere.Size = new System.Drawing.Size(1564, 97);
            panelWhere.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.btnConnTest);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1564, 97);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
            // 
            // btnConnTest
            // 
            this.btnConnTest.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConnTest.Location = new System.Drawing.Point(1435, 15);
            this.btnConnTest.Name = "btnConnTest";
            this.btnConnTest.Size = new System.Drawing.Size(72, 80);
            this.btnConnTest.TabIndex = 3;
            this.btnConnTest.Text = "测试连接";
            this.btnConnTest.UseVisualStyleBackColor = true;
            this.btnConnTest.Click += new System.EventHandler(this.btnConnTest_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(1507, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 80);
            this.button1.TabIndex = 6;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxPackingLine);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label_PackingIniFile);
            this.groupBox2.Controls.Add(this.textBoxRadarDriveIP);
            this.groupBox2.Controls.Add(this.lbl_NewPackingInfoIndex);
            this.groupBox2.Controls.Add(this.btnReadPackingINI);
            this.groupBox2.Controls.Add(this.btnSwitchToNewPackingInfo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(2, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 80);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "gB2";
            // 
            // comboBoxPackingLine
            // 
            this.comboBoxPackingLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPackingLine.FormattingEnabled = true;
            this.comboBoxPackingLine.Items.AddRange(new object[] {
            "Radar 1",
            "Radar 2",
            "Radar 4",
            "Radar 5",
            "Radar 7"});
            this.comboBoxPackingLine.Location = new System.Drawing.Point(81, 38);
            this.comboBoxPackingLine.Name = "comboBoxPackingLine";
            this.comboBoxPackingLine.Size = new System.Drawing.Size(150, 21);
            this.comboBoxPackingLine.TabIndex = 7;
            this.comboBoxPackingLine.SelectedIndexChanged += new System.EventHandler(this.comboBoxPackingLine_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(462, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "包装信息索引";
            // 
            // label_PackingIniFile
            // 
            this.label_PackingIniFile.AutoSize = true;
            this.label_PackingIniFile.Location = new System.Drawing.Point(11, 61);
            this.label_PackingIniFile.Name = "label_PackingIniFile";
            this.label_PackingIniFile.Size = new System.Drawing.Size(24, 13);
            this.label_PackingIniFile.TabIndex = 13;
            this.label_PackingIniFile.Text = "{ - }";
            // 
            // textBoxRadarDriveIP
            // 
            this.textBoxRadarDriveIP.Enabled = false;
            this.textBoxRadarDriveIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRadarDriveIP.Location = new System.Drawing.Point(81, 10);
            this.textBoxRadarDriveIP.Name = "textBoxRadarDriveIP";
            this.textBoxRadarDriveIP.Size = new System.Drawing.Size(150, 22);
            this.textBoxRadarDriveIP.TabIndex = 4;
            // 
            // lbl_NewPackingInfoIndex
            // 
            this.lbl_NewPackingInfoIndex.AutoSize = true;
            this.lbl_NewPackingInfoIndex.Location = new System.Drawing.Point(462, 41);
            this.lbl_NewPackingInfoIndex.Name = "lbl_NewPackingInfoIndex";
            this.lbl_NewPackingInfoIndex.Size = new System.Drawing.Size(24, 13);
            this.lbl_NewPackingInfoIndex.TabIndex = 12;
            this.lbl_NewPackingInfoIndex.Text = "{ - }";
            // 
            // btnReadPackingINI
            // 
            this.btnReadPackingINI.Location = new System.Drawing.Point(249, 10);
            this.btnReadPackingINI.Name = "btnReadPackingINI";
            this.btnReadPackingINI.Size = new System.Drawing.Size(115, 49);
            this.btnReadPackingINI.TabIndex = 5;
            this.btnReadPackingINI.Text = "读取Packing配置";
            this.btnReadPackingINI.UseVisualStyleBackColor = true;
            this.btnReadPackingINI.Click += new System.EventHandler(this.btnReadPackingINI_Click);
            // 
            // btnSwitchToNewPackingInfo
            // 
            this.btnSwitchToNewPackingInfo.Image = global::WinPMS.Properties.Resources.lefthand_1;
            this.btnSwitchToNewPackingInfo.Location = new System.Drawing.Point(399, 10);
            this.btnSwitchToNewPackingInfo.Name = "btnSwitchToNewPackingInfo";
            this.btnSwitchToNewPackingInfo.Size = new System.Drawing.Size(57, 49);
            this.btnSwitchToNewPackingInfo.TabIndex = 11;
            this.btnSwitchToNewPackingInfo.UseVisualStyleBackColor = true;
            this.btnSwitchToNewPackingInfo.Click += new System.EventHandler(this.btnSwitchToNewPackingInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "包装服务器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "包 装 线 体";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 142);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1564, 540);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxAddAboveByNew,
            this.toolStripTextBoxAddBelowByNew,
            this.toolStripSeparator4,
            this.toolStripTextBoxAddByCopy,
            this.toolStripTextBoxAddAboveByCopy,
            this.toolStripTextBoxAddBelowByCopy,
            this.toolStripSeparator5,
            this.toolStripTextBoxModifyPacking,
            this.toolStripSeparator6,
            this.toolStripTextBoxDeletePacking});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(216, 219);
            // 
            // toolStripTextBoxAddAboveByNew
            // 
            this.toolStripTextBoxAddAboveByNew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxAddAboveByNew.Name = "toolStripTextBoxAddAboveByNew";
            this.toolStripTextBoxAddAboveByNew.ReadOnly = true;
            this.toolStripTextBoxAddAboveByNew.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxAddAboveByNew.Text = "在上一行新加";
            this.toolStripTextBoxAddAboveByNew.Click += new System.EventHandler(this.toolStripTextBoxAddAboveByNew_Click);
            // 
            // toolStripTextBoxAddBelowByNew
            // 
            this.toolStripTextBoxAddBelowByNew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxAddBelowByNew.Name = "toolStripTextBoxAddBelowByNew";
            this.toolStripTextBoxAddBelowByNew.ReadOnly = true;
            this.toolStripTextBoxAddBelowByNew.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxAddBelowByNew.Text = "在下一行新加";
            this.toolStripTextBoxAddBelowByNew.Click += new System.EventHandler(this.toolStripTextBoxAddBelowByNew_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(212, 6);
            // 
            // toolStripTextBoxAddByCopy
            // 
            this.toolStripTextBoxAddByCopy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxAddByCopy.Name = "toolStripTextBoxAddByCopy";
            this.toolStripTextBoxAddByCopy.ReadOnly = true;
            this.toolStripTextBoxAddByCopy.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxAddByCopy.Text = "复制";
            this.toolStripTextBoxAddByCopy.Click += new System.EventHandler(this.toolStripTextBoxAddByCopy_Click);
            // 
            // toolStripTextBoxAddAboveByCopy
            // 
            this.toolStripTextBoxAddAboveByCopy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxAddAboveByCopy.Name = "toolStripTextBoxAddAboveByCopy";
            this.toolStripTextBoxAddAboveByCopy.ReadOnly = true;
            this.toolStripTextBoxAddAboveByCopy.Size = new System.Drawing.Size(180, 23);
            this.toolStripTextBoxAddAboveByCopy.Text = "在上一行粘贴（需要先复制）";
            this.toolStripTextBoxAddAboveByCopy.Click += new System.EventHandler(this.toolStripTextBoxAddAboveByCopy_Click);
            // 
            // toolStripTextBoxAddBelowByCopy
            // 
            this.toolStripTextBoxAddBelowByCopy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxAddBelowByCopy.Name = "toolStripTextBoxAddBelowByCopy";
            this.toolStripTextBoxAddBelowByCopy.ReadOnly = true;
            this.toolStripTextBoxAddBelowByCopy.Size = new System.Drawing.Size(180, 23);
            this.toolStripTextBoxAddBelowByCopy.Text = "在下一行粘贴（需要先复制）";
            this.toolStripTextBoxAddBelowByCopy.Click += new System.EventHandler(this.toolStripTextBoxAddBelowByCopy_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(212, 6);
            // 
            // toolStripTextBoxModifyPacking
            // 
            this.toolStripTextBoxModifyPacking.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxModifyPacking.Name = "toolStripTextBoxModifyPacking";
            this.toolStripTextBoxModifyPacking.ReadOnly = true;
            this.toolStripTextBoxModifyPacking.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxModifyPacking.Text = "修改";
            this.toolStripTextBoxModifyPacking.Click += new System.EventHandler(this.toolStripTextBoxModify_Click);
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
            this.tsMenus.Size = new System.Drawing.Size(1564, 45);
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
            this.tsbtnDelete.Size = new System.Drawing.Size(28, 37);
            this.tsbtnDelete.Text = "Del";
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
            this.tsbtnRefresh.Image = global::WinPMS.Properties.Resources.refresh;
            this.tsbtnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(52, 37);
            this.tsbtnRefresh.Text = " Reflash";
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
            this.tsbtnClose.Size = new System.Drawing.Size(43, 37);
            this.tsbtnClose.Text = " Close";
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
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(212, 6);
            // 
            // toolStripTextBoxDeletePacking
            // 
            this.toolStripTextBoxDeletePacking.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxDeletePacking.Name = "toolStripTextBoxDeletePacking";
            this.toolStripTextBoxDeletePacking.ReadOnly = true;
            this.toolStripTextBoxDeletePacking.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxDeletePacking.Text = "删除";
            this.toolStripTextBoxDeletePacking.Click += new System.EventHandler(this.toolStripTextBoxDeletePacking_Click);
            // 
            // FrmRadarPacking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 682);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(panelWhere);
            this.Controls.Add(this.tsMenus);
            this.Name = "FrmRadarPacking";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRadarPacking";
            this.Load += new System.EventHandler(this.FrmRadarPacking_Load);
            panelWhere.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            this.tsMenus.ResumeLayout(false);
            this.tsMenus.PerformLayout();
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
        private System.Windows.Forms.Button btnConnTest;
        private System.Windows.Forms.TextBox textBoxRadarDriveIP;
        private System.Windows.Forms.Button btnReadPackingINI;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxPackingLine;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxAddBelowByNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxAddAboveByCopy;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxAddByCopy;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxAddAboveByNew;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxAddBelowByCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxModifyPacking;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_NewPackingInfoIndex;
        private System.Windows.Forms.Button btnSwitchToNewPackingInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_PackingIniFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxDeletePacking;
    }
}