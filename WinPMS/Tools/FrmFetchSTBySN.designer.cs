namespace WinPMS.Tools
{
    partial class FrmFetchSTBySN
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
            System.Windows.Forms.Panel panel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFetchSTBySN));
            this.label1 = new System.Windows.Forms.Label();
            this.txtbox_LoadSN = new System.Windows.Forms.TextBox();
            this.btn_LoadSN = new System.Windows.Forms.Button();
            this.tsMenus = new System.Windows.Forms.ToolStrip();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHelp = new System.Windows.Forms.ToolStripButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Load_Log_Folder = new System.Windows.Forms.Button();
            this.btn_Fetching = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtbox_Log = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtbox_LogFind = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_OpenLogFind = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtbox_LogNotFind = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_OpenLogNotFind = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            this.tsMenus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(this.label1);
            panel1.Controls.Add(this.txtbox_LoadSN);
            panel1.Controls.Add(this.btn_LoadSN);
            panel1.Dock = System.Windows.Forms.DockStyle.Right;
            panel1.Location = new System.Drawing.Point(1748, 22);
            panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(147, 165);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "SN / PCBA:";
            // 
            // txtbox_LoadSN
            // 
            this.txtbox_LoadSN.Enabled = false;
            this.txtbox_LoadSN.Location = new System.Drawing.Point(6, 88);
            this.txtbox_LoadSN.Name = "txtbox_LoadSN";
            this.txtbox_LoadSN.Size = new System.Drawing.Size(138, 26);
            this.txtbox_LoadSN.TabIndex = 1;
            // 
            // btn_LoadSN
            // 
            this.btn_LoadSN.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_LoadSN.Location = new System.Drawing.Point(0, 0);
            this.btn_LoadSN.Name = "btn_LoadSN";
            this.btn_LoadSN.Size = new System.Drawing.Size(147, 45);
            this.btn_LoadSN.TabIndex = 0;
            this.btn_LoadSN.Text = "Load *.txt";
            this.btn_LoadSN.UseVisualStyleBackColor = true;
            this.btn_LoadSN.Click += new System.EventHandler(this.btn_LoadSN_Click);
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
            this.tsbtnDelete.Image = global::WinPMS.Properties.Resources.delete;
            this.tsbtnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(47, 61);
            this.tsbtnDelete.Text = " Del";
            this.tsbtnDelete.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 67);
            // 
            // tsbtnInfo
            // 
            this.tsbtnInfo.Enabled = false;
            this.tsbtnInfo.Image = global::WinPMS.Properties.Resources.search;
            this.tsbtnInfo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnInfo.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnInfo.Name = "tsbtnInfo";
            this.tsbtnInfo.Size = new System.Drawing.Size(61, 61);
            this.tsbtnInfo.Text = "Detail";
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
            this.tsbtnRefresh.Image = global::WinPMS.Properties.Resources.refresh;
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
            this.tsbtnClose.Image = global::WinPMS.Properties.Resources.close0;
            this.tsbtnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClose.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnClose.Name = "tsbtnClose";
            this.tsbtnClose.Size = new System.Drawing.Size(64, 61);
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
            this.tsBtnHelp.Size = new System.Drawing.Size(53, 61);
            this.tsBtnHelp.Text = "Help";
            this.tsBtnHelp.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsBtnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnHelp.Click += new System.EventHandler(this.tsBtnHelp_Click);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(3, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(1745, 165);
            this.listBox1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1898, 190);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = ".txt Source";
            // 
            // btn_Load_Log_Folder
            // 
            this.btn_Load_Log_Folder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Load_Log_Folder.Location = new System.Drawing.Point(0, 0);
            this.btn_Load_Log_Folder.Name = "btn_Load_Log_Folder";
            this.btn_Load_Log_Folder.Size = new System.Drawing.Size(147, 45);
            this.btn_Load_Log_Folder.TabIndex = 6;
            this.btn_Load_Log_Folder.Text = "Load Log Folder";
            this.btn_Load_Log_Folder.UseVisualStyleBackColor = true;
            this.btn_Load_Log_Folder.Click += new System.EventHandler(this.btn_Load_Log_Folder_Click);
            // 
            // btn_Fetching
            // 
            this.btn_Fetching.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Fetching.Location = new System.Drawing.Point(0, 0);
            this.btn_Fetching.Name = "btn_Fetching";
            this.btn_Fetching.Size = new System.Drawing.Size(147, 45);
            this.btn_Fetching.TabIndex = 7;
            this.btn_Fetching.Text = "Fetching";
            this.btn_Fetching.UseVisualStyleBackColor = true;
            this.btn_Fetching.Click += new System.EventHandler(this.btn_Fetching_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox2);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(0, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1898, 190);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log Dest";
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(3, 22);
            this.listBox2.Name = "listBox2";
            this.listBox2.ScrollAlwaysVisible = true;
            this.listBox2.Size = new System.Drawing.Size(1745, 165);
            this.listBox2.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtbox_Log);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btn_Load_Log_Folder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1748, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(147, 165);
            this.panel2.TabIndex = 11;
            // 
            // txtbox_Log
            // 
            this.txtbox_Log.Enabled = false;
            this.txtbox_Log.Location = new System.Drawing.Point(6, 89);
            this.txtbox_Log.Name = "txtbox_Log";
            this.txtbox_Log.Size = new System.Drawing.Size(138, 26);
            this.txtbox_Log.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Log:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox3);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(0, 450);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1898, 190);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log Find";
            // 
            // listBox3
            // 
            this.listBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.HorizontalScrollbar = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Location = new System.Drawing.Point(3, 22);
            this.listBox3.Name = "listBox3";
            this.listBox3.ScrollAlwaysVisible = true;
            this.listBox3.Size = new System.Drawing.Size(1745, 165);
            this.listBox3.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtbox_LogFind);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btn_OpenLogFind);
            this.panel3.Controls.Add(this.btn_Fetching);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1748, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(147, 165);
            this.panel3.TabIndex = 13;
            // 
            // txtbox_LogFind
            // 
            this.txtbox_LogFind.Enabled = false;
            this.txtbox_LogFind.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtbox_LogFind.Location = new System.Drawing.Point(6, 116);
            this.txtbox_LogFind.Name = "txtbox_LogFind";
            this.txtbox_LogFind.Size = new System.Drawing.Size(138, 26);
            this.txtbox_LogFind.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(3, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Log Find:";
            // 
            // btn_OpenLogFind
            // 
            this.btn_OpenLogFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_OpenLogFind.Location = new System.Drawing.Point(0, 45);
            this.btn_OpenLogFind.Name = "btn_OpenLogFind";
            this.btn_OpenLogFind.Size = new System.Drawing.Size(147, 45);
            this.btn_OpenLogFind.TabIndex = 8;
            this.btn_OpenLogFind.Text = "Open Result";
            this.btn_OpenLogFind.UseVisualStyleBackColor = true;
            this.btn_OpenLogFind.Click += new System.EventHandler(this.btn_OpenResultLogFind_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox4);
            this.groupBox4.Controls.Add(this.panel4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(0, 640);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1898, 410);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Log Not Find";
            // 
            // listBox4
            // 
            this.listBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox4.ForeColor = System.Drawing.Color.Red;
            this.listBox4.FormattingEnabled = true;
            this.listBox4.HorizontalScrollbar = true;
            this.listBox4.ItemHeight = 20;
            this.listBox4.Location = new System.Drawing.Point(3, 22);
            this.listBox4.Name = "listBox4";
            this.listBox4.ScrollAlwaysVisible = true;
            this.listBox4.Size = new System.Drawing.Size(1745, 385);
            this.listBox4.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtbox_LogNotFind);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.btn_OpenLogNotFind);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1748, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(147, 385);
            this.panel4.TabIndex = 1;
            // 
            // txtbox_LogNotFind
            // 
            this.txtbox_LogNotFind.Enabled = false;
            this.txtbox_LogNotFind.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtbox_LogNotFind.Location = new System.Drawing.Point(6, 89);
            this.txtbox_LogNotFind.Name = "txtbox_LogNotFind";
            this.txtbox_LogNotFind.Size = new System.Drawing.Size(138, 26);
            this.txtbox_LogNotFind.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(3, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Log Not Find:";
            // 
            // btn_OpenLogNotFind
            // 
            this.btn_OpenLogNotFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_OpenLogNotFind.Location = new System.Drawing.Point(0, 0);
            this.btn_OpenLogNotFind.Name = "btn_OpenLogNotFind";
            this.btn_OpenLogNotFind.Size = new System.Drawing.Size(147, 45);
            this.btn_OpenLogNotFind.TabIndex = 0;
            this.btn_OpenLogNotFind.Text = "Open Result";
            this.btn_OpenLogNotFind.UseVisualStyleBackColor = true;
            this.btn_OpenLogNotFind.Click += new System.EventHandler(this.btn_OpenLogNotFind_Click);
            // 
            // FrmFetchSTBySN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1050);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsMenus);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmFetchSTBySN";
            this.ShowIcon = false;
            this.Text = "Fetch ST Log By SN / PCBA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmFileZilla_Load);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            this.tsMenus.ResumeLayout(false);
            this.tsMenus.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_LoadSN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Load_Log_Folder;
        private System.Windows.Forms.Button btn_Fetching;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_OpenLogNotFind;
        private System.Windows.Forms.Button btn_OpenLogFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox_LoadSN;
        private System.Windows.Forms.TextBox txtbox_Log;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtbox_LogFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbox_LogNotFind;
        private System.Windows.Forms.Label label4;
    }
}