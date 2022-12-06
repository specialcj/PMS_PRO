namespace WinPMS.Radar
{
    partial class FrmRDR2Dll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRDR2Dll));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_ShowDllBuildDate = new System.Windows.Forms.CheckBox();
            this.btnOpenCVI = new System.Windows.Forms.Button();
            this.txtTestStepsCVI = new System.Windows.Forms.TextBox();
            this.btnSwitchDll = new System.Windows.Forms.Button();
            this.btnLoadDll = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAlvCanCommsDllFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAlvCanCommsFolderNamePrefix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAlvCanCommsFolderPath = new System.Windows.Forms.TextBox();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            panelWhere = new System.Windows.Forms.Panel();
            panelWhere.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDll)).BeginInit();
            this.tsMenus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWhere
            // 
            panelWhere.Controls.Add(this.groupBox1);
            panelWhere.Dock = System.Windows.Forms.DockStyle.Top;
            panelWhere.Location = new System.Drawing.Point(0, 45);
            panelWhere.Name = "panelWhere";
            panelWhere.Size = new System.Drawing.Size(1265, 100);
            panelWhere.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_ShowDllBuildDate);
            this.groupBox1.Controls.Add(this.btnOpenCVI);
            this.groupBox1.Controls.Add(this.txtTestStepsCVI);
            this.groupBox1.Controls.Add(this.btnSwitchDll);
            this.groupBox1.Controls.Add(this.btnLoadDll);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAlvCanCommsDllFileName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAlvCanCommsFolderNamePrefix);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAlvCanCommsFolderPath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1265, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ini Configuration";
            // 
            // chk_ShowDllBuildDate
            // 
            this.chk_ShowDllBuildDate.AutoSize = true;
            this.chk_ShowDllBuildDate.Location = new System.Drawing.Point(676, 68);
            this.chk_ShowDllBuildDate.Margin = new System.Windows.Forms.Padding(2);
            this.chk_ShowDllBuildDate.Name = "chk_ShowDllBuildDate";
            this.chk_ShowDllBuildDate.Size = new System.Drawing.Size(90, 17);
            this.chk_ShowDllBuildDate.TabIndex = 8;
            this.chk_ShowDllBuildDate.Text = "Dll Build Date";
            this.chk_ShowDllBuildDate.UseVisualStyleBackColor = true;
            this.chk_ShowDllBuildDate.CheckedChanged += new System.EventHandler(this.chk_ShowDllBuildDate_CheckedChanged);
            // 
            // btnOpenCVI
            // 
            this.btnOpenCVI.Location = new System.Drawing.Point(534, 55);
            this.btnOpenCVI.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenCVI.Name = "btnOpenCVI";
            this.btnOpenCVI.Size = new System.Drawing.Size(111, 30);
            this.btnOpenCVI.TabIndex = 6;
            this.btnOpenCVI.Text = "打开TestSteps CVI";
            this.btnOpenCVI.UseVisualStyleBackColor = true;
            this.btnOpenCVI.Click += new System.EventHandler(this.btnOpenTestStepsCVI_Click);
            // 
            // txtTestStepsCVI
            // 
            this.txtTestStepsCVI.Enabled = false;
            this.txtTestStepsCVI.Location = new System.Drawing.Point(435, 19);
            this.txtTestStepsCVI.Margin = new System.Windows.Forms.Padding(2);
            this.txtTestStepsCVI.Name = "txtTestStepsCVI";
            this.txtTestStepsCVI.Size = new System.Drawing.Size(590, 20);
            this.txtTestStepsCVI.TabIndex = 7;
            // 
            // btnSwitchDll
            // 
            this.btnSwitchDll.Location = new System.Drawing.Point(437, 55);
            this.btnSwitchDll.Margin = new System.Windows.Forms.Padding(2);
            this.btnSwitchDll.Name = "btnSwitchDll";
            this.btnSwitchDll.Size = new System.Drawing.Size(77, 30);
            this.btnSwitchDll.TabIndex = 5;
            this.btnSwitchDll.Text = "切换dll";
            this.btnSwitchDll.UseVisualStyleBackColor = true;
            this.btnSwitchDll.Click += new System.EventHandler(this.btnSwitchDll_Click);
            // 
            // btnLoadDll
            // 
            this.btnLoadDll.Location = new System.Drawing.Point(340, 55);
            this.btnLoadDll.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadDll.Name = "btnLoadDll";
            this.btnLoadDll.Size = new System.Drawing.Size(77, 30);
            this.btnLoadDll.TabIndex = 4;
            this.btnLoadDll.Text = "加载dll信息";
            this.btnLoadDll.UseVisualStyleBackColor = true;
            this.btnLoadDll.Click += new System.EventHandler(this.btnLoadDll_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "TestSteps_CVI：";
            // 
            // txtAlvCanCommsDllFileName
            // 
            this.txtAlvCanCommsDllFileName.Enabled = false;
            this.txtAlvCanCommsDllFileName.Location = new System.Drawing.Point(204, 68);
            this.txtAlvCanCommsDllFileName.Margin = new System.Windows.Forms.Padding(2);
            this.txtAlvCanCommsDllFileName.Name = "txtAlvCanCommsDllFileName";
            this.txtAlvCanCommsDllFileName.Size = new System.Drawing.Size(122, 20);
            this.txtAlvCanCommsDllFileName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ALV_CAN_COMMS目录dll文件的名称：";
            // 
            // txtAlvCanCommsFolderNamePrefix
            // 
            this.txtAlvCanCommsFolderNamePrefix.Enabled = false;
            this.txtAlvCanCommsFolderNamePrefix.Location = new System.Drawing.Point(204, 44);
            this.txtAlvCanCommsFolderNamePrefix.Margin = new System.Windows.Forms.Padding(2);
            this.txtAlvCanCommsFolderNamePrefix.Name = "txtAlvCanCommsFolderNamePrefix";
            this.txtAlvCanCommsFolderNamePrefix.Size = new System.Drawing.Size(122, 20);
            this.txtAlvCanCommsFolderNamePrefix.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ALV_CAN_COMMS目录前缀：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "ALV_CAN_COMMS目录所在的盘符：";
            // 
            // txtAlvCanCommsFolderPath
            // 
            this.txtAlvCanCommsFolderPath.Enabled = false;
            this.txtAlvCanCommsFolderPath.Location = new System.Drawing.Point(204, 19);
            this.txtAlvCanCommsFolderPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtAlvCanCommsFolderPath.Name = "txtAlvCanCommsFolderPath";
            this.txtAlvCanCommsFolderPath.Size = new System.Drawing.Size(122, 20);
            this.txtAlvCanCommsFolderPath.TabIndex = 0;
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
            this.dgvDll.Location = new System.Drawing.Point(0, 145);
            this.dgvDll.MultiSelect = false;
            this.dgvDll.Name = "dgvDll";
            this.dgvDll.ReadOnly = true;
            this.dgvDll.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDll.RowHeadersWidth = 51;
            this.dgvDll.RowTemplate.Height = 23;
            this.dgvDll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDll.Size = new System.Drawing.Size(1265, 320);
            this.dgvDll.TabIndex = 3;
            this.dgvDll.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDll_CellClick);
            // 
            // FolderPath
            // 
            this.FolderPath.DataPropertyName = "FolderPath";
            this.FolderPath.FillWeight = 80F;
            this.FolderPath.HeaderText = "ALV_CAN_COMMS目录";
            this.FolderPath.MinimumWidth = 6;
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.ReadOnly = true;
            this.FolderPath.Width = 123;
            // 
            // DllExist
            // 
            this.DllExist.DataPropertyName = "DllExist";
            this.DllExist.FillWeight = 48.44789F;
            this.DllExist.HeaderText = "dll是否存在";
            this.DllExist.MinimumWidth = 6;
            this.DllExist.Name = "DllExist";
            this.DllExist.ReadOnly = true;
            this.DllExist.Width = 71;
            // 
            // DllName
            // 
            this.DllName.DataPropertyName = "DllName";
            this.DllName.FillWeight = 48.44789F;
            this.DllName.HeaderText = "dll名称";
            this.DllName.MinimumWidth = 6;
            this.DllName.Name = "DllName";
            this.DllName.ReadOnly = true;
            this.DllName.Width = 60;
            // 
            // DllVersion
            // 
            this.DllVersion.DataPropertyName = "DllVersion";
            this.DllVersion.FillWeight = 48.44789F;
            this.DllVersion.HeaderText = "dll版本";
            this.DllVersion.MinimumWidth = 6;
            this.DllVersion.Name = "DllVersion";
            this.DllVersion.ReadOnly = true;
            this.DllVersion.Width = 60;
            // 
            // DllBuildDate
            // 
            this.DllBuildDate.DataPropertyName = "DllBuildDate";
            this.DllBuildDate.HeaderText = "dll编译日期";
            this.DllBuildDate.MinimumWidth = 8;
            this.DllBuildDate.Name = "DllBuildDate";
            this.DllBuildDate.ReadOnly = true;
            this.DllBuildDate.Width = 71;
            // 
            // DllUsePro
            // 
            this.DllUsePro.DataPropertyName = "DllUsePro";
            this.DllUsePro.FillWeight = 48.44789F;
            this.DllUsePro.HeaderText = "dll适用项目";
            this.DllUsePro.MinimumWidth = 6;
            this.DllUsePro.Name = "DllUsePro";
            this.DllUsePro.ReadOnly = true;
            this.DllUsePro.Width = 71;
            // 
            // DllActive
            // 
            this.DllActive.DataPropertyName = "DllActive";
            this.DllActive.FalseValue = "false";
            this.DllActive.FillWeight = 110F;
            this.DllActive.HeaderText = "当前使用";
            this.DllActive.MinimumWidth = 8;
            this.DllActive.Name = "DllActive";
            this.DllActive.ReadOnly = true;
            this.DllActive.TrueValue = "true";
            this.DllActive.Width = 45;
            // 
            // DllOpen
            // 
            this.DllOpen.DataPropertyName = "DllOpen";
            this.DllOpen.HeaderText = "打开";
            this.DllOpen.MinimumWidth = 8;
            this.DllOpen.Name = "DllOpen";
            this.DllOpen.ReadOnly = true;
            this.DllOpen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DllOpen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DllOpen.Text = "打开";
            this.DllOpen.UseColumnTextForButtonValue = true;
            this.DllOpen.Visible = false;
            this.DllOpen.Width = 52;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(0, 465);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1265, 217);
            this.textBox1.TabIndex = 4;
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
            // FrmRDR2Dll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 682);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvDll);
            this.Controls.Add(panelWhere);
            this.Controls.Add(this.tsMenus);
            this.Name = "FrmRDR2Dll";
            this.ShowIcon = false;
            this.Text = "RDR ALV CAN Comms DLL [SEL]";
            this.Load += new System.EventHandler(this.FrmRDR2SelDll_Load);
            panelWhere.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDll)).EndInit();
            this.tsMenus.ResumeLayout(false);
            this.tsMenus.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton tsbtnLogFile;
        private System.Windows.Forms.DataGridView dgvDll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAlvCanCommsFolderNamePrefix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAlvCanCommsFolderPath;
        private System.Windows.Forms.Button btnLoadDll;
        private System.Windows.Forms.TextBox txtAlvCanCommsDllFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSwitchDll;
        private System.Windows.Forms.Button btnOpenCVI;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtTestStepsCVI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripButton tsBtnHelp;
        private System.Windows.Forms.CheckBox chk_ShowDllBuildDate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnReflash;
        private System.Windows.Forms.ToolStripButton tsbtnLogDir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolderPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn DllExist;
        private System.Windows.Forms.DataGridViewTextBoxColumn DllName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DllVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DllBuildDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DllUsePro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DllActive;
        private System.Windows.Forms.DataGridViewButtonColumn DllOpen;
    }
}