namespace WinPMS.Tools
{
    partial class FrmSeparateST2PF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeparateST2PF));
            this.tsMenus = new System.Windows.Forms.ToolStrip();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHelp = new System.Windows.Forms.ToolStripButton();
            this.btn_Load_Log_Folder = new System.Windows.Forms.Button();
            this.btn_Fetching = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtbox_Log = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtbox_LogPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_OpenLogPass = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtbox_LogFail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_OpenLogFail = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tsMenus.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
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
            this.tsMenus.Size = new System.Drawing.Size(1265, 45);
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
            this.tsBtnHelp.Click += new System.EventHandler(this.tsBtnHelp_Click);
            // 
            // btn_Load_Log_Folder
            // 
            this.btn_Load_Log_Folder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Load_Log_Folder.Location = new System.Drawing.Point(0, 0);
            this.btn_Load_Log_Folder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Load_Log_Folder.Name = "btn_Load_Log_Folder";
            this.btn_Load_Log_Folder.Size = new System.Drawing.Size(98, 37);
            this.btn_Load_Log_Folder.TabIndex = 6;
            this.btn_Load_Log_Folder.Text = "Load Log Folder";
            this.btn_Load_Log_Folder.UseVisualStyleBackColor = true;
            this.btn_Load_Log_Folder.Click += new System.EventHandler(this.btn_Load_Log_Folder_Click);
            // 
            // btn_Fetching
            // 
            this.btn_Fetching.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Fetching.Location = new System.Drawing.Point(0, 0);
            this.btn_Fetching.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Fetching.Name = "btn_Fetching";
            this.btn_Fetching.Size = new System.Drawing.Size(98, 38);
            this.btn_Fetching.TabIndex = 7;
            this.btn_Fetching.Text = "Fetching";
            this.btn_Fetching.UseVisualStyleBackColor = true;
            this.btn_Fetching.Click += new System.EventHandler(this.btn_Fetching_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(0, 45);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(1265, 162);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log Dest";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(2, 15);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(1163, 145);
            this.listBox1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtbox_Log);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btn_Load_Log_Folder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1165, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(98, 145);
            this.panel2.TabIndex = 11;
            // 
            // txtbox_Log
            // 
            this.txtbox_Log.Enabled = false;
            this.txtbox_Log.Location = new System.Drawing.Point(4, 58);
            this.txtbox_Log.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtbox_Log.Name = "txtbox_Log";
            this.txtbox_Log.Size = new System.Drawing.Size(93, 20);
            this.txtbox_Log.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Log:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox2);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(0, 207);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(1265, 162);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log Pass";
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.Location = new System.Drawing.Point(2, 15);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox2.Name = "listBox2";
            this.listBox2.ScrollAlwaysVisible = true;
            this.listBox2.Size = new System.Drawing.Size(1163, 145);
            this.listBox2.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtbox_LogPass);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btn_OpenLogPass);
            this.panel3.Controls.Add(this.btn_Fetching);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1165, 15);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(98, 145);
            this.panel3.TabIndex = 13;
            // 
            // txtbox_LogPass
            // 
            this.txtbox_LogPass.Enabled = false;
            this.txtbox_LogPass.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtbox_LogPass.Location = new System.Drawing.Point(4, 92);
            this.txtbox_LogPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtbox_LogPass.Name = "txtbox_LogPass";
            this.txtbox_LogPass.Size = new System.Drawing.Size(93, 20);
            this.txtbox_LogPass.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(2, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Log Pass:";
            // 
            // btn_OpenLogPass
            // 
            this.btn_OpenLogPass.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_OpenLogPass.Location = new System.Drawing.Point(0, 38);
            this.btn_OpenLogPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_OpenLogPass.Name = "btn_OpenLogPass";
            this.btn_OpenLogPass.Size = new System.Drawing.Size(98, 37);
            this.btn_OpenLogPass.TabIndex = 8;
            this.btn_OpenLogPass.Text = "Open Result";
            this.btn_OpenLogPass.UseVisualStyleBackColor = true;
            this.btn_OpenLogPass.Click += new System.EventHandler(this.btn_OpenResultLogPass_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox3);
            this.groupBox4.Controls.Add(this.panel4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(0, 369);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(1265, 313);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Log Fail";
            // 
            // listBox3
            // 
            this.listBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox3.ForeColor = System.Drawing.Color.Red;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.HorizontalScrollbar = true;
            this.listBox3.Location = new System.Drawing.Point(2, 15);
            this.listBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox3.Name = "listBox3";
            this.listBox3.ScrollAlwaysVisible = true;
            this.listBox3.Size = new System.Drawing.Size(1163, 296);
            this.listBox3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtbox_LogFail);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.btn_OpenLogFail);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1165, 15);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(98, 296);
            this.panel4.TabIndex = 1;
            // 
            // txtbox_LogFail
            // 
            this.txtbox_LogFail.Enabled = false;
            this.txtbox_LogFail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtbox_LogFail.Location = new System.Drawing.Point(4, 58);
            this.txtbox_LogFail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtbox_LogFail.Name = "txtbox_LogFail";
            this.txtbox_LogFail.Size = new System.Drawing.Size(93, 20);
            this.txtbox_LogFail.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(2, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Log Fail:";
            // 
            // btn_OpenLogFail
            // 
            this.btn_OpenLogFail.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_OpenLogFail.Location = new System.Drawing.Point(0, 0);
            this.btn_OpenLogFail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_OpenLogFail.Name = "btn_OpenLogFail";
            this.btn_OpenLogFail.Size = new System.Drawing.Size(98, 37);
            this.btn_OpenLogFail.TabIndex = 0;
            this.btn_OpenLogFail.Text = "Open Result";
            this.btn_OpenLogFail.UseVisualStyleBackColor = true;
            this.btn_OpenLogFail.Click += new System.EventHandler(this.btn_OpenResultLogFail_Click);
            // 
            // FrmSeparateST2PF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 682);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tsMenus);
            this.Name = "FrmSeparateST2PF";
            this.ShowIcon = false;
            this.Text = "Separate ST Log to PF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmFileZilla_Load);
            this.tsMenus.ResumeLayout(false);
            this.tsMenus.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton tsBtnHelp;
        private System.Windows.Forms.Button btn_Load_Log_Folder;
        private System.Windows.Forms.Button btn_Fetching;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_OpenLogFail;
        private System.Windows.Forms.Button btn_OpenLogPass;
        private System.Windows.Forms.TextBox txtbox_Log;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtbox_LogPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbox_LogFail;
        private System.Windows.Forms.Label label4;
    }
}