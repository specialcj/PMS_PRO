namespace WinPMS.Radar
{
    partial class FrmRDR2DllConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRDR2DllConfig));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTest1 = new System.Windows.Forms.Button();
            this.chk_ShowDllBuildDate = new System.Windows.Forms.CheckBox();
            this.btnLoadDll = new System.Windows.Forms.Button();
            this.dgvDll = new System.Windows.Forms.DataGridView();
            this.FolderPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DllExist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DllName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DllVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DllBuildDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DllUsePro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DllActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DllOpen = new System.Windows.Forms.DataGridViewButtonColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tsMenus = new System.Windows.Forms.ToolStrip();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnReflash = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnLogDir = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLogFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnHelp = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnModify = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            panelWhere = new System.Windows.Forms.Panel();
            panelWhere.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDll)).BeginInit();
            this.tsMenus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWhere
            // 
            panelWhere.Controls.Add(this.groupBox1);
            panelWhere.Dock = System.Windows.Forms.DockStyle.Top;
            panelWhere.Location = new System.Drawing.Point(0, 45);
            panelWhere.Name = "panelWhere";
            panelWhere.Size = new System.Drawing.Size(1265, 60);
            panelWhere.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTest1);
            this.groupBox1.Controls.Add(this.chk_ShowDllBuildDate);
            this.groupBox1.Controls.Add(this.btnLoadDll);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1265, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ini Configuration";
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(491, 17);
            this.btnTest1.Margin = new System.Windows.Forms.Padding(2);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(77, 30);
            this.btnTest1.TabIndex = 9;
            this.btnTest1.Text = "Test1";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // chk_ShowDllBuildDate
            // 
            this.chk_ShowDllBuildDate.AutoSize = true;
            this.chk_ShowDllBuildDate.Location = new System.Drawing.Point(672, 17);
            this.chk_ShowDllBuildDate.Margin = new System.Windows.Forms.Padding(2);
            this.chk_ShowDllBuildDate.Name = "chk_ShowDllBuildDate";
            this.chk_ShowDllBuildDate.Size = new System.Drawing.Size(90, 17);
            this.chk_ShowDllBuildDate.TabIndex = 8;
            this.chk_ShowDllBuildDate.Text = "Dll Build Date";
            this.chk_ShowDllBuildDate.UseVisualStyleBackColor = true;
            this.chk_ShowDllBuildDate.CheckedChanged += new System.EventHandler(this.chk_ShowDllBuildDate_CheckedChanged);
            // 
            // btnLoadDll
            // 
            this.btnLoadDll.Location = new System.Drawing.Point(343, 17);
            this.btnLoadDll.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadDll.Name = "btnLoadDll";
            this.btnLoadDll.Size = new System.Drawing.Size(77, 30);
            this.btnLoadDll.TabIndex = 4;
            this.btnLoadDll.Text = "Load .dll";
            this.btnLoadDll.UseVisualStyleBackColor = true;
            this.btnLoadDll.Click += new System.EventHandler(this.btnLoadDll_Click);
            // 
            // dgvDll
            // 
            this.dgvDll.AllowUserToResizeColumns = false;
            this.dgvDll.AllowUserToResizeRows = false;
            this.dgvDll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDll.BackgroundColor = System.Drawing.Color.White;
            this.dgvDll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FolderPath,
            this.DllExist,
            this.DllName,
            this.DllVersion,
            this.DllBuildDate,
            this.DllUsePro,
            this.DllActive,
            this.DllOpen});
            this.dgvDll.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDll.Location = new System.Drawing.Point(0, 105);
            this.dgvDll.MultiSelect = false;
            this.dgvDll.Name = "dgvDll";
            this.dgvDll.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDll.RowHeadersWidth = 51;
            this.dgvDll.RowTemplate.Height = 23;
            this.dgvDll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDll.Size = new System.Drawing.Size(1265, 161);
            this.dgvDll.TabIndex = 3;
            this.dgvDll.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDll_CellClick);
            this.dgvDll.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDll_CellContentClick);
            // 
            // FolderPath
            // 
            this.FolderPath.DataPropertyName = "FolderPath";
            this.FolderPath.FillWeight = 80F;
            this.FolderPath.HeaderText = "ALV_CAN_Comms Folder";
            this.FolderPath.MinimumWidth = 6;
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.ReadOnly = true;
            this.FolderPath.Width = 155;
            // 
            // DllExist
            // 
            this.DllExist.DataPropertyName = "DllExist";
            this.DllExist.FillWeight = 50F;
            this.DllExist.HeaderText = "dll Exist";
            this.DllExist.MinimumWidth = 6;
            this.DllExist.Name = "DllExist";
            this.DllExist.Visible = false;
            this.DllExist.Width = 86;
            // 
            // DllName
            // 
            this.DllName.DataPropertyName = "DllName";
            this.DllName.FillWeight = 48.44789F;
            this.DllName.HeaderText = "dll Name";
            this.DllName.MinimumWidth = 6;
            this.DllName.Name = "DllName";
            this.DllName.Visible = false;
            this.DllName.Width = 79;
            // 
            // DllVersion
            // 
            this.DllVersion.DataPropertyName = "DllVersion";
            this.DllVersion.FillWeight = 48.44789F;
            this.DllVersion.HeaderText = "dll Version";
            this.DllVersion.MinimumWidth = 6;
            this.DllVersion.Name = "DllVersion";
            this.DllVersion.ReadOnly = true;
            this.DllVersion.Width = 98;
            // 
            // DllBuildDate
            // 
            this.DllBuildDate.DataPropertyName = "DllBuildDate";
            this.DllBuildDate.HeaderText = "dll Build Date";
            this.DllBuildDate.MinimumWidth = 8;
            this.DllBuildDate.Name = "DllBuildDate";
            this.DllBuildDate.Visible = false;
            this.DllBuildDate.Width = 117;
            // 
            // DllUsePro
            // 
            this.DllUsePro.DataPropertyName = "DllUsePro";
            this.DllUsePro.FillWeight = 48.44789F;
            this.DllUsePro.HeaderText = "dll Project";
            this.DllUsePro.MinimumWidth = 6;
            this.DllUsePro.Name = "DllUsePro";
            this.DllUsePro.Width = 98;
            // 
            // DllActive
            // 
            this.DllActive.DataPropertyName = "DllActive";
            this.DllActive.FalseValue = "false";
            this.DllActive.FillWeight = 110F;
            this.DllActive.HeaderText = "Current Use";
            this.DllActive.MinimumWidth = 8;
            this.DllActive.Name = "DllActive";
            this.DllActive.TrueValue = "true";
            this.DllActive.Visible = false;
            this.DllActive.Width = 60;
            // 
            // DllOpen
            // 
            this.DllOpen.DataPropertyName = "DllOpen";
            this.DllOpen.HeaderText = "Open";
            this.DllOpen.MinimumWidth = 8;
            this.DllOpen.Name = "DllOpen";
            this.DllOpen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DllOpen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DllOpen.Text = "Open";
            this.DllOpen.UseColumnTextForButtonValue = true;
            this.DllOpen.Visible = false;
            this.DllOpen.Width = 58;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.tsbtnReflash,
            this.toolStripSeparator4,
            this.tsbtnLogDir,
            this.tsbtnLogFile,
            this.toolStripSeparator3,
            this.tsbtnClose,
            this.toolStripSeparator5,
            this.tsBtnHelp});
            this.tsMenus.Location = new System.Drawing.Point(0, 0);
            this.tsMenus.Name = "tsMenus";
            this.tsMenus.Padding = new System.Windows.Forms.Padding(0, 0, 1, 2);
            this.tsMenus.Size = new System.Drawing.Size(1265, 45);
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
            this.tsbtnInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInfo.Image")));
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
            // tsbtnReflash
            // 
            this.tsbtnReflash.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnReflash.Image")));
            this.tsbtnReflash.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnReflash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnReflash.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnReflash.Name = "tsbtnReflash";
            this.tsbtnReflash.Size = new System.Drawing.Size(52, 37);
            this.tsbtnReflash.Text = " Reflash";
            this.tsbtnReflash.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnReflash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnReflash.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 43);
            // 
            // tsbtnLogDir
            // 
            this.tsbtnLogDir.Image = global::WinPMS.Properties.Resources.log_dir;
            this.tsbtnLogDir.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnLogDir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLogDir.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnLogDir.Name = "tsbtnLogDir";
            this.tsbtnLogDir.Size = new System.Drawing.Size(52, 37);
            this.tsbtnLogDir.Text = " Log Dir";
            this.tsbtnLogDir.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnLogDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnLogDir.Click += new System.EventHandler(this.tsbtnLogDir_Click);
            // 
            // tsbtnLogFile
            // 
            this.tsbtnLogFile.Image = global::WinPMS.Properties.Resources.log_file;
            this.tsbtnLogFile.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnLogFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLogFile.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnLogFile.Name = "tsbtnLogFile";
            this.tsbtnLogFile.Size = new System.Drawing.Size(55, 37);
            this.tsbtnLogFile.Text = " Log File";
            this.tsbtnLogFile.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnLogFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnLogFile.Click += new System.EventHandler(this.tsbtnLogFile_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
            // 
            // tsbtnClose
            // 
            this.tsbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClose.Image")));
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 43);
            // 
            // tsBtnHelp
            // 
            this.tsBtnHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnHelp.Image")));
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView1.Location = new System.Drawing.Point(26, 384);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(551, 145);
            this.dataGridView1.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AppliedProject";
            this.dataGridViewTextBoxColumn1.FillWeight = 80F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Applied Project";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 79;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AppliedFolder";
            this.dataGridViewTextBoxColumn2.FillWeight = 50F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Applied Folder";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 79;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(604, 384);
            this.btnModify.Margin = new System.Windows.Forms.Padding(2);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(77, 30);
            this.btnModify.TabIndex = 10;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(604, 499);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 30);
            this.button2.TabIndex = 11;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(604, 445);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 30);
            this.button3.TabIndex = 12;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmRDR2DllConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 682);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgvDll);
            this.Controls.Add(panelWhere);
            this.Controls.Add(this.tsMenus);
            this.Name = "FrmRDR2DllConfig";
            this.ShowIcon = false;
            this.Text = "RDR ALV CAN Comms DLL [SEL]";
            this.Load += new System.EventHandler(this.FrmRDR2DllConfig_Load);
            panelWhere.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDll)).EndInit();
            this.tsMenus.ResumeLayout(false);
            this.tsMenus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.ToolStripButton tsbtnLogFile;
        private System.Windows.Forms.DataGridView dgvDll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoadDll;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton tsBtnHelp;
        private System.Windows.Forms.CheckBox chk_ShowDllBuildDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnReflash;
        private System.Windows.Forms.ToolStripButton tsbtnLogDir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolderPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn DllExist;
        private System.Windows.Forms.DataGridViewTextBoxColumn DllName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DllVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DllBuildDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DllUsePro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DllActive;
        private System.Windows.Forms.DataGridViewButtonColumn DllOpen;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}