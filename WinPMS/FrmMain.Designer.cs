namespace WinPMS
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.gboxMenus = new System.Windows.Forms.GroupBox();
            this.btn_Test = new System.Windows.Forms.Button();
            this.PMSMenus = new System.Windows.Forms.MenuStrip();
            this.gboxTools = new System.Windows.Forms.GroupBox();
            this.PMSTools = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcPages = new System.Windows.Forms.TabControl();
            this.PMSStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLoginTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel11 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRegisterTimeRemaining = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrFrmPrompt = new System.Windows.Forms.Timer(this.components);
            this.tmrCurrTime = new System.Windows.Forms.Timer(this.components);
            this.tmrAuthority = new System.Windows.Forms.Timer(this.components);
            this.gboxMenus.SuspendLayout();
            this.gboxTools.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PMSStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxMenus
            // 
            this.gboxMenus.Controls.Add(this.btn_Test);
            this.gboxMenus.Controls.Add(this.PMSMenus);
            this.gboxMenus.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxMenus.Location = new System.Drawing.Point(0, 0);
            this.gboxMenus.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.gboxMenus.Name = "gboxMenus";
            this.gboxMenus.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.gboxMenus.Size = new System.Drawing.Size(1444, 35);
            this.gboxMenus.TabIndex = 0;
            this.gboxMenus.TabStop = false;
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(573, 9);
            this.btn_Test.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(133, 25);
            this.btn_Test.TabIndex = 1;
            this.btn_Test.Text = "Test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Visible = false;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // PMSMenus
            // 
            this.PMSMenus.BackColor = System.Drawing.SystemColors.Control;
            this.PMSMenus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PMSMenus.Location = new System.Drawing.Point(3, 13);
            this.PMSMenus.Name = "PMSMenus";
            this.PMSMenus.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.PMSMenus.Size = new System.Drawing.Size(1438, 24);
            this.PMSMenus.TabIndex = 0;
            this.PMSMenus.Text = "menuStrip1";
            // 
            // gboxTools
            // 
            this.gboxTools.Controls.Add(this.PMSTools);
            this.gboxTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxTools.Location = new System.Drawing.Point(0, 35);
            this.gboxTools.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.gboxTools.Name = "gboxTools";
            this.gboxTools.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.gboxTools.Size = new System.Drawing.Size(1444, 42);
            this.gboxTools.TabIndex = 1;
            this.gboxTools.TabStop = false;
            // 
            // PMSTools
            // 
            this.PMSTools.AutoSize = false;
            this.PMSTools.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PMSTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PMSTools.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PMSTools.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.PMSTools.Location = new System.Drawing.Point(3, 13);
            this.PMSTools.Name = "PMSTools";
            this.PMSTools.Size = new System.Drawing.Size(1438, 26);
            this.PMSTools.TabIndex = 0;
            this.PMSTools.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tcPages);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1444, 778);
            this.panel1.TabIndex = 2;
            // 
            // tcPages
            // 
            this.tcPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPages.Location = new System.Drawing.Point(0, 0);
            this.tcPages.Name = "tcPages";
            this.tcPages.Padding = new System.Drawing.Point(8, 4);
            this.tcPages.SelectedIndex = 0;
            this.tcPages.ShowToolTips = true;
            this.tcPages.Size = new System.Drawing.Size(1444, 778);
            this.tcPages.TabIndex = 0;
            // 
            // PMSStatus
            // 
            this.PMSStatus.AutoSize = false;
            this.PMSStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PMSStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblUName,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel8,
            this.lblUserName,
            this.toolStripStatusLabel9,
            this.toolStripStatusLabel4,
            this.lblLoginTime,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel5,
            this.lblCurrTime,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel11,
            this.lblRegisterTimeRemaining,
            this.toolStripStatusLabel10});
            this.PMSStatus.Location = new System.Drawing.Point(0, 855);
            this.PMSStatus.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.PMSStatus.Name = "PMSStatus";
            this.PMSStatus.Size = new System.Drawing.Size(1444, 27);
            this.PMSStatus.TabIndex = 7;
            this.PMSStatus.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 22);
            this.toolStripStatusLabel1.Text = "Account：";
            // 
            // lblUName
            // 
            this.lblUName.Name = "lblUName";
            this.lblUName.Size = new System.Drawing.Size(37, 22);
            this.lblUName.Text = "xxxxx";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(50, 22);
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(101, 22);
            this.toolStripStatusLabel8.Text = "UserName (PC)：";
            // 
            // lblUserName
            // 
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(37, 22);
            this.lblUserName.Text = "xxxxx";
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.AutoSize = false;
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(50, 22);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(79, 22);
            this.toolStripStatusLabel4.Text = "Login Time：";
            // 
            // lblLoginTime
            // 
            this.lblLoginTime.Name = "lblLoginTime";
            this.lblLoginTime.Size = new System.Drawing.Size(110, 22);
            this.lblLoginTime.Text = "xxxx-xx-xx xx:xx:xx";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.AutoSize = false;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(50, 22);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(89, 22);
            this.toolStripStatusLabel5.Text = "Current Time：";
            // 
            // lblCurrTime
            // 
            this.lblCurrTime.Name = "lblCurrTime";
            this.lblCurrTime.Size = new System.Drawing.Size(110, 22);
            this.lblCurrTime.Text = "xxxx-xx-xx xx:xx:xx";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.AutoSize = false;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(50, 22);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(62, 22);
            this.toolStripStatusLabel6.Text = "Register：";
            // 
            // toolStripStatusLabel11
            // 
            this.toolStripStatusLabel11.Name = "toolStripStatusLabel11";
            this.toolStripStatusLabel11.Size = new System.Drawing.Size(11, 22);
            this.toolStripStatusLabel11.Text = "{";
            // 
            // lblRegisterTimeRemaining
            // 
            this.lblRegisterTimeRemaining.Name = "lblRegisterTimeRemaining";
            this.lblRegisterTimeRemaining.Size = new System.Drawing.Size(17, 22);
            this.lblRegisterTimeRemaining.Text = "--";
            // 
            // toolStripStatusLabel10
            // 
            this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
            this.toolStripStatusLabel10.Size = new System.Drawing.Size(11, 22);
            this.toolStripStatusLabel10.Text = "}";
            // 
            // tmrFrmPrompt
            // 
            this.tmrFrmPrompt.Enabled = true;
            this.tmrFrmPrompt.Interval = 1000;
            // 
            // tmrCurrTime
            // 
            this.tmrCurrTime.Enabled = true;
            this.tmrCurrTime.Interval = 1000;
            this.tmrCurrTime.Tick += new System.EventHandler(this.tmrCurrTime_Tick);
            // 
            // tmrAuthority
            // 
            this.tmrAuthority.Interval = 10000;
            this.tmrAuthority.Tick += new System.EventHandler(this.tmrAuthority_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1444, 882);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gboxTools);
            this.Controls.Add(this.gboxMenus);
            this.Controls.Add(this.PMSStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.PMSMenus;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PMS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.VisibleChanged += new System.EventHandler(this.FrmMain_VisibleChanged);
            this.gboxMenus.ResumeLayout(false);
            this.gboxMenus.PerformLayout();
            this.gboxTools.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.PMSStatus.ResumeLayout(false);
            this.PMSStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxMenus;
        private System.Windows.Forms.MenuStrip PMSMenus;
        private System.Windows.Forms.GroupBox gboxTools;
        private System.Windows.Forms.ToolStrip PMSTools;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip PMSStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblUName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblLoginTime;
        private System.Windows.Forms.Timer tmrFrmPrompt;
        private System.Windows.Forms.Timer tmrCurrTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrTime;
        private System.Windows.Forms.TabControl tcPages;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel lblUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel11;
        private System.Windows.Forms.ToolStripStatusLabel lblRegisterTimeRemaining;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel10;
        private System.Windows.Forms.Timer tmrAuthority;
    }
}