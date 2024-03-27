namespace WinPMS.Radar
{
    partial class FrmRadarGM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRadarGM));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxUINIniOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUIDIni = new System.Windows.Forms.TextBox();
            this.tsMenus = new System.Windows.Forms.ToolStrip();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHelp = new System.Windows.Forms.ToolStripButton();
            this.btnKeyGenOutputCombine = new System.Windows.Forms.Button();
            this.listBoxUIDIniFilesCheck = new System.Windows.Forms.ListBox();
            this.listBoxUIDIniFilesKeyGenOutput = new System.Windows.Forms.ListBox();
            this.gbUIDIniFiles1 = new System.Windows.Forms.GroupBox();
            this.listBoxUIDIniFilesCheckOver = new System.Windows.Forms.ListBox();
            this.gbUIDIniFiles2 = new System.Windows.Forms.GroupBox();
            this.btnUIDIniFilesCheck = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            panelWhere = new System.Windows.Forms.Panel();
            panelWhere.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tsMenus.SuspendLayout();
            this.gbUIDIniFiles1.SuspendLayout();
            this.gbUIDIniFiles2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWhere
            // 
            panelWhere.Controls.Add(this.groupBox1);
            panelWhere.Dock = System.Windows.Forms.DockStyle.Top;
            panelWhere.Location = new System.Drawing.Point(0, 45);
            panelWhere.Name = "panelWhere";
            panelWhere.Size = new System.Drawing.Size(1117, 100);
            panelWhere.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.textBoxUINIniOutput);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxUIDIni);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1117, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // textBoxUINIniOutput
            // 
            this.textBoxUINIniOutput.Location = new System.Drawing.Point(15, 57);
            this.textBoxUINIniOutput.Name = "textBoxUINIniOutput";
            this.textBoxUINIniOutput.ReadOnly = true;
            this.textBoxUINIniOutput.Size = new System.Drawing.Size(904, 20);
            this.textBoxUINIniOutput.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(922, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "UID KeyGen_Output.ini";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(922, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "UID INI Path";
            // 
            // textBoxUIDIni
            // 
            this.textBoxUIDIni.Location = new System.Drawing.Point(15, 25);
            this.textBoxUIDIni.Name = "textBoxUIDIni";
            this.textBoxUIDIni.Size = new System.Drawing.Size(904, 20);
            this.textBoxUIDIni.TabIndex = 0;
            this.textBoxUIDIni.TextChanged += new System.EventHandler(this.textBoxUIDIni_TextChanged);
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
            this.tsMenus.Size = new System.Drawing.Size(1117, 45);
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
            this.tsbtnRefresh.Image = global::WinPMS.Properties.Resources.refresh;
            this.tsbtnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(52, 37);
            this.tsbtnRefresh.Text = " Reflash";
            this.tsbtnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
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
            // btnKeyGenOutputCombine
            // 
            this.btnKeyGenOutputCombine.Location = new System.Drawing.Point(945, 462);
            this.btnKeyGenOutputCombine.Name = "btnKeyGenOutputCombine";
            this.btnKeyGenOutputCombine.Size = new System.Drawing.Size(147, 49);
            this.btnKeyGenOutputCombine.TabIndex = 3;
            this.btnKeyGenOutputCombine.Text = "Combine KeyGen_Output.ini";
            this.btnKeyGenOutputCombine.UseVisualStyleBackColor = true;
            this.btnKeyGenOutputCombine.Click += new System.EventHandler(this.btnKeyGenOutputCombine_Click);
            // 
            // listBoxUIDIniFilesCheck
            // 
            this.listBoxUIDIniFilesCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxUIDIniFilesCheck.FormattingEnabled = true;
            this.listBoxUIDIniFilesCheck.Location = new System.Drawing.Point(3, 16);
            this.listBoxUIDIniFilesCheck.Name = "listBoxUIDIniFilesCheck";
            this.listBoxUIDIniFilesCheck.Size = new System.Drawing.Size(904, 134);
            this.listBoxUIDIniFilesCheck.TabIndex = 4;
            // 
            // listBoxUIDIniFilesKeyGenOutput
            // 
            this.listBoxUIDIniFilesKeyGenOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxUIDIniFilesKeyGenOutput.FormattingEnabled = true;
            this.listBoxUIDIniFilesKeyGenOutput.Location = new System.Drawing.Point(3, 16);
            this.listBoxUIDIniFilesKeyGenOutput.Name = "listBoxUIDIniFilesKeyGenOutput";
            this.listBoxUIDIniFilesKeyGenOutput.Size = new System.Drawing.Size(901, 256);
            this.listBoxUIDIniFilesKeyGenOutput.TabIndex = 5;
            // 
            // gbUIDIniFiles1
            // 
            this.gbUIDIniFiles1.Controls.Add(this.listBoxUIDIniFilesCheckOver);
            this.gbUIDIniFiles1.Controls.Add(this.listBoxUIDIniFilesCheck);
            this.gbUIDIniFiles1.Location = new System.Drawing.Point(12, 151);
            this.gbUIDIniFiles1.Name = "gbUIDIniFiles1";
            this.gbUIDIniFiles1.Size = new System.Drawing.Size(910, 271);
            this.gbUIDIniFiles1.TabIndex = 6;
            this.gbUIDIniFiles1.TabStop = false;
            this.gbUIDIniFiles1.Text = "UID_INI Files Check";
            // 
            // listBoxUIDIniFilesCheckOver
            // 
            this.listBoxUIDIniFilesCheckOver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxUIDIniFilesCheckOver.ForeColor = System.Drawing.Color.Red;
            this.listBoxUIDIniFilesCheckOver.FormattingEnabled = true;
            this.listBoxUIDIniFilesCheckOver.Location = new System.Drawing.Point(3, 150);
            this.listBoxUIDIniFilesCheckOver.Name = "listBoxUIDIniFilesCheckOver";
            this.listBoxUIDIniFilesCheckOver.Size = new System.Drawing.Size(904, 118);
            this.listBoxUIDIniFilesCheckOver.TabIndex = 5;
            // 
            // gbUIDIniFiles2
            // 
            this.gbUIDIniFiles2.Controls.Add(this.listBoxUIDIniFilesKeyGenOutput);
            this.gbUIDIniFiles2.Location = new System.Drawing.Point(15, 446);
            this.gbUIDIniFiles2.Name = "gbUIDIniFiles2";
            this.gbUIDIniFiles2.Size = new System.Drawing.Size(907, 275);
            this.gbUIDIniFiles2.TabIndex = 7;
            this.gbUIDIniFiles2.TabStop = false;
            this.gbUIDIniFiles2.Text = "Combine KeyGen_Output.ini";
            // 
            // btnUIDIniFilesCheck
            // 
            this.btnUIDIniFilesCheck.Location = new System.Drawing.Point(945, 167);
            this.btnUIDIniFilesCheck.Name = "btnUIDIniFilesCheck";
            this.btnUIDIniFilesCheck.Size = new System.Drawing.Size(147, 49);
            this.btnUIDIniFilesCheck.TabIndex = 8;
            this.btnUIDIniFilesCheck.Text = "Check UID ini files";
            this.btnUIDIniFilesCheck.UseVisualStyleBackColor = true;
            this.btnUIDIniFilesCheck.Click += new System.EventHandler(this.btnUIDIniFilesCheck_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(945, 599);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 49);
            this.button1.TabIndex = 9;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(1044, 53);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(68, 27);
            this.btnOpen.TabIndex = 10;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // FrmRadarGM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 733);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUIDIniFilesCheck);
            this.Controls.Add(this.gbUIDIniFiles2);
            this.Controls.Add(this.gbUIDIniFiles1);
            this.Controls.Add(this.btnKeyGenOutputCombine);
            this.Controls.Add(panelWhere);
            this.Controls.Add(this.tsMenus);
            this.Name = "FrmRadarGM";
            this.ShowIcon = false;
            this.Text = "RDR GM";
            this.Load += new System.EventHandler(this.FrmRadarGM_Load);
            panelWhere.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tsMenus.ResumeLayout(false);
            this.tsMenus.PerformLayout();
            this.gbUIDIniFiles1.ResumeLayout(false);
            this.gbUIDIniFiles2.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnKeyGenOutputCombine;
        private System.Windows.Forms.ListBox listBoxUIDIniFilesCheck;
        private System.Windows.Forms.TextBox textBoxUINIniOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUIDIni;
        private System.Windows.Forms.ListBox listBoxUIDIniFilesKeyGenOutput;
        private System.Windows.Forms.GroupBox gbUIDIniFiles1;
        private System.Windows.Forms.GroupBox gbUIDIniFiles2;
        private System.Windows.Forms.Button btnUIDIniFilesCheck;
        private System.Windows.Forms.ListBox listBoxUIDIniFilesCheckOver;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button button1;
    }
}