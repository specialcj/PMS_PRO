﻿namespace WinPMS
{
    partial class FrmSyncPMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSyncPMS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tsMenus = new System.Windows.Forms.ToolStrip();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHelp = new System.Windows.Forms.ToolStripButton();
            this.btn_LoadPMS = new System.Windows.Forms.Button();
            this.dgv_PMSProject = new System.Windows.Forms.DataGridView();
            this.txt_PMSProjectPath = new System.Windows.Forms.TextBox();
            this.btn_Debug = new System.Windows.Forms.Button();
            this.dgv_PMSProjectConfig = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewLinkColumn();
            panelWhere = new System.Windows.Forms.Panel();
            panelWhere.SuspendLayout();
            this.tsMenus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PMSProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PMSProjectConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWhere
            // 
            panelWhere.Controls.Add(this.groupBox1);
            panelWhere.Dock = System.Windows.Forms.DockStyle.Top;
            panelWhere.Location = new System.Drawing.Point(0, 45);
            panelWhere.Name = "panelWhere";
            panelWhere.Size = new System.Drawing.Size(1265, 47);
            panelWhere.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1265, 47);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reserved Area";
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
            // btn_LoadPMS
            // 
            this.btn_LoadPMS.Location = new System.Drawing.Point(12, 137);
            this.btn_LoadPMS.Name = "btn_LoadPMS";
            this.btn_LoadPMS.Size = new System.Drawing.Size(126, 46);
            this.btn_LoadPMS.TabIndex = 3;
            this.btn_LoadPMS.Text = "Load PMS";
            this.btn_LoadPMS.UseVisualStyleBackColor = true;
            this.btn_LoadPMS.Click += new System.EventHandler(this.btn_LoadPMS_Click);
            // 
            // dgv_PMSProject
            // 
            this.dgv_PMSProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PMSProject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgv_PMSProject.Location = new System.Drawing.Point(12, 190);
            this.dgv_PMSProject.Name = "dgv_PMSProject";
            this.dgv_PMSProject.Size = new System.Drawing.Size(373, 272);
            this.dgv_PMSProject.TabIndex = 4;
            this.dgv_PMSProject.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PMSProject_CellContentClick);
            // 
            // txt_PMSProjectPath
            // 
            this.txt_PMSProjectPath.Enabled = false;
            this.txt_PMSProjectPath.Location = new System.Drawing.Point(12, 111);
            this.txt_PMSProjectPath.Name = "txt_PMSProjectPath";
            this.txt_PMSProjectPath.Size = new System.Drawing.Size(196, 20);
            this.txt_PMSProjectPath.TabIndex = 5;
            this.txt_PMSProjectPath.Text = "C:\\";
            // 
            // btn_Debug
            // 
            this.btn_Debug.Location = new System.Drawing.Point(259, 111);
            this.btn_Debug.Name = "btn_Debug";
            this.btn_Debug.Size = new System.Drawing.Size(126, 46);
            this.btn_Debug.TabIndex = 6;
            this.btn_Debug.Text = "Debug";
            this.btn_Debug.UseVisualStyleBackColor = true;
            this.btn_Debug.Click += new System.EventHandler(this.btn_Debug_Click);
            // 
            // dgv_PMSProjectConfig
            // 
            this.dgv_PMSProjectConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PMSProjectConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgv_PMSProjectConfig.Location = new System.Drawing.Point(447, 190);
            this.dgv_PMSProjectConfig.Name = "dgv_PMSProjectConfig";
            this.dgv_PMSProjectConfig.Size = new System.Drawing.Size(373, 272);
            this.dgv_PMSProjectConfig.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "PMS";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "PMS";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            dataGridViewCellStyle1.NullValue = "启用";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "启用";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FrmSyncPMS
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1265, 682);
            this.Controls.Add(this.dgv_PMSProjectConfig);
            this.Controls.Add(this.btn_Debug);
            this.Controls.Add(this.txt_PMSProjectPath);
            this.Controls.Add(this.dgv_PMSProject);
            this.Controls.Add(this.btn_LoadPMS);
            this.Controls.Add(panelWhere);
            this.Controls.Add(this.tsMenus);
            this.Name = "FrmSyncPMS";
            this.ShowIcon = false;
            this.Text = "FrmSyncPMS";
            panelWhere.ResumeLayout(false);
            this.tsMenus.ResumeLayout(false);
            this.tsMenus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PMSProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PMSProjectConfig)).EndInit();
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
        private System.Windows.Forms.Button btn_LoadPMS;
        private System.Windows.Forms.DataGridView dgv_PMSProject;
        private System.Windows.Forms.TextBox txt_PMSProjectPath;
        private System.Windows.Forms.Button btn_Debug;
        private System.Windows.Forms.DataGridView dgv_PMSProjectConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewLinkColumn Column2;
    }
}