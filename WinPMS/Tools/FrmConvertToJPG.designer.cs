namespace WinPMS.Tools
{
    partial class FrmConvertToJPG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConvertToJPG));
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
            this.btn_ConvertToJPG = new System.Windows.Forms.Button();
            this.chkBox_DelOriFile = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_BrowseJpgOutputPath = new System.Windows.Forms.Button();
            this.txtBox_OutputPath = new System.Windows.Forms.TextBox();
            this.btn_ClearListBox = new System.Windows.Forms.Button();
            this.btn_RemoveItem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_OpenJpgOutputPath = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBox_InputPath = new System.Windows.Forms.TextBox();
            this.btnLoadSrcFolderFromIni = new System.Windows.Forms.Button();
            this.btn_BrowseSrcFile = new System.Windows.Forms.Button();
            this.btn_BrowseSrcFolder = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            panelWhere = new System.Windows.Forms.Panel();
            panelWhere.SuspendLayout();
            this.tsMenus.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWhere
            // 
            panelWhere.Controls.Add(this.groupBox1);
            panelWhere.Dock = System.Windows.Forms.DockStyle.Top;
            panelWhere.Location = new System.Drawing.Point(0, 70);
            panelWhere.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panelWhere.Name = "panelWhere";
            panelWhere.Size = new System.Drawing.Size(1898, 67);
            panelWhere.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1898, 67);
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
            this.tsbtnRefresh.Image = global::WinPMS.Properties.Resources.refresh;
            this.tsbtnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(77, 61);
            this.tsbtnRefresh.Text = " Reflash";
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
            // 
            // btn_ConvertToJPG
            // 
            this.btn_ConvertToJPG.Location = new System.Drawing.Point(6, 517);
            this.btn_ConvertToJPG.Name = "btn_ConvertToJPG";
            this.btn_ConvertToJPG.Size = new System.Drawing.Size(225, 46);
            this.btn_ConvertToJPG.TabIndex = 3;
            this.btn_ConvertToJPG.Text = "Convert To .jpg";
            this.btn_ConvertToJPG.UseVisualStyleBackColor = true;
            this.btn_ConvertToJPG.Click += new System.EventHandler(this.btn_ConvertToJPG_Click);
            // 
            // chkBox_DelOriFile
            // 
            this.chkBox_DelOriFile.AutoSize = true;
            this.chkBox_DelOriFile.Location = new System.Drawing.Point(6, 569);
            this.chkBox_DelOriFile.Name = "chkBox_DelOriFile";
            this.chkBox_DelOriFile.Size = new System.Drawing.Size(168, 24);
            this.chkBox_DelOriFile.TabIndex = 4;
            this.chkBox_DelOriFile.Text = "Delete Original File";
            this.chkBox_DelOriFile.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(0, 137);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(816, 913);
            this.listBox1.TabIndex = 5;
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "1. Browse / Drag Source Folder / File to the ListBox \r\n(support .HEIC)";
            // 
            // btn_BrowseJpgOutputPath
            // 
            this.btn_BrowseJpgOutputPath.Location = new System.Drawing.Point(6, 370);
            this.btn_BrowseJpgOutputPath.Name = "btn_BrowseJpgOutputPath";
            this.btn_BrowseJpgOutputPath.Size = new System.Drawing.Size(225, 46);
            this.btn_BrowseJpgOutputPath.TabIndex = 7;
            this.btn_BrowseJpgOutputPath.Text = "Browse .jpg Output Path";
            this.btn_BrowseJpgOutputPath.UseVisualStyleBackColor = true;
            this.btn_BrowseJpgOutputPath.Click += new System.EventHandler(this.btn_BrowseOutputPath_Click);
            // 
            // txtBox_OutputPath
            // 
            this.txtBox_OutputPath.Enabled = false;
            this.txtBox_OutputPath.Location = new System.Drawing.Point(6, 338);
            this.txtBox_OutputPath.Name = "txtBox_OutputPath";
            this.txtBox_OutputPath.Size = new System.Drawing.Size(676, 26);
            this.txtBox_OutputPath.TabIndex = 8;
            // 
            // btn_ClearListBox
            // 
            this.btn_ClearListBox.Location = new System.Drawing.Point(292, 175);
            this.btn_ClearListBox.Name = "btn_ClearListBox";
            this.btn_ClearListBox.Size = new System.Drawing.Size(225, 46);
            this.btn_ClearListBox.TabIndex = 10;
            this.btn_ClearListBox.Text = "Clear ListBox";
            this.btn_ClearListBox.UseVisualStyleBackColor = true;
            this.btn_ClearListBox.Click += new System.EventHandler(this.btn_ClearListBox_Click);
            // 
            // btn_RemoveItem
            // 
            this.btn_RemoveItem.Location = new System.Drawing.Point(292, 118);
            this.btn_RemoveItem.Name = "btn_RemoveItem";
            this.btn_RemoveItem.Size = new System.Drawing.Size(225, 46);
            this.btn_RemoveItem.TabIndex = 11;
            this.btn_RemoveItem.Text = "Remove Item";
            this.btn_RemoveItem.UseVisualStyleBackColor = true;
            this.btn_RemoveItem.Click += new System.EventHandler(this.btn_RemoveItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(6, 596);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(581, 40);
            this.label3.TabIndex = 12;
            this.label3.Text = "Note:\r\n1. Enable CheckBox \"Delete Original File\", it means the original file will" +
    " be deleted!";
            // 
            // btn_OpenJpgOutputPath
            // 
            this.btn_OpenJpgOutputPath.Location = new System.Drawing.Point(292, 517);
            this.btn_OpenJpgOutputPath.Name = "btn_OpenJpgOutputPath";
            this.btn_OpenJpgOutputPath.Size = new System.Drawing.Size(225, 46);
            this.btn_OpenJpgOutputPath.TabIndex = 13;
            this.btn_OpenJpgOutputPath.Text = "Open .jpg Output Path";
            this.btn_OpenJpgOutputPath.UseVisualStyleBackColor = true;
            this.btn_OpenJpgOutputPath.Click += new System.EventHandler(this.btn_OpenJpgOutputPath_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBox_InputPath);
            this.groupBox2.Controls.Add(this.btnLoadSrcFolderFromIni);
            this.groupBox2.Controls.Add(this.btn_BrowseSrcFile);
            this.groupBox2.Controls.Add(this.btn_BrowseSrcFolder);
            this.groupBox2.Controls.Add(this.btn_RemoveItem);
            this.groupBox2.Controls.Add(this.btn_ClearListBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btn_OpenJpgOutputPath);
            this.groupBox2.Controls.Add(this.chkBox_DelOriFile);
            this.groupBox2.Controls.Add(this.txtBox_OutputPath);
            this.groupBox2.Controls.Add(this.btn_BrowseJpgOutputPath);
            this.groupBox2.Controls.Add(this.btn_ConvertToJPG);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(816, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(688, 913);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Act";
            // 
            // txtBox_InputPath
            // 
            this.txtBox_InputPath.Enabled = false;
            this.txtBox_InputPath.Location = new System.Drawing.Point(10, 77);
            this.txtBox_InputPath.Name = "txtBox_InputPath";
            this.txtBox_InputPath.Size = new System.Drawing.Size(672, 26);
            this.txtBox_InputPath.TabIndex = 17;
            // 
            // btnLoadSrcFolderFromIni
            // 
            this.btnLoadSrcFolderFromIni.Location = new System.Drawing.Point(10, 25);
            this.btnLoadSrcFolderFromIni.Name = "btnLoadSrcFolderFromIni";
            this.btnLoadSrcFolderFromIni.Size = new System.Drawing.Size(225, 46);
            this.btnLoadSrcFolderFromIni.TabIndex = 16;
            this.btnLoadSrcFolderFromIni.Text = "Load Source Folder From .ini";
            this.btnLoadSrcFolderFromIni.UseVisualStyleBackColor = true;
            this.btnLoadSrcFolderFromIni.Click += new System.EventHandler(this.btnLoadSrcFolderFromIni_Click);
            // 
            // btn_BrowseSrcFile
            // 
            this.btn_BrowseSrcFile.Location = new System.Drawing.Point(10, 175);
            this.btn_BrowseSrcFile.Name = "btn_BrowseSrcFile";
            this.btn_BrowseSrcFile.Size = new System.Drawing.Size(225, 46);
            this.btn_BrowseSrcFile.TabIndex = 15;
            this.btn_BrowseSrcFile.Text = "Browse Source File";
            this.btn_BrowseSrcFile.UseVisualStyleBackColor = true;
            this.btn_BrowseSrcFile.Click += new System.EventHandler(this.btn_BrowseSrcFile_Click);
            // 
            // btn_BrowseSrcFolder
            // 
            this.btn_BrowseSrcFolder.Location = new System.Drawing.Point(10, 118);
            this.btn_BrowseSrcFolder.Name = "btn_BrowseSrcFolder";
            this.btn_BrowseSrcFolder.Size = new System.Drawing.Size(225, 46);
            this.btn_BrowseSrcFolder.TabIndex = 14;
            this.btn_BrowseSrcFolder.Text = "Browse Source Folder";
            this.btn_BrowseSrcFolder.UseVisualStyleBackColor = true;
            this.btn_BrowseSrcFolder.Click += new System.EventHandler(this.btn_BrowseSrcFolder_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(1504, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(394, 913);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Step";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(6, 517);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "3. Click \"Convert To .jpg\" button";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(6, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "2. Browse the .jpg Output Path";
            // 
            // FrmConvertToJPG
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1898, 1050);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(panelWhere);
            this.Controls.Add(this.tsMenus);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmConvertToJPG";
            this.ShowIcon = false;
            this.Text = "Convert To .jpg";
            this.Load += new System.EventHandler(this.FrmConvertToJPG_Load);
            panelWhere.ResumeLayout(false);
            this.tsMenus.ResumeLayout(false);
            this.tsMenus.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.Button btn_ConvertToJPG;
        private System.Windows.Forms.CheckBox chkBox_DelOriFile;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_BrowseJpgOutputPath;
        private System.Windows.Forms.TextBox txtBox_OutputPath;
        private System.Windows.Forms.Button btn_ClearListBox;
        private System.Windows.Forms.Button btn_RemoveItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_OpenJpgOutputPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_BrowseSrcFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_BrowseSrcFile;
        private System.Windows.Forms.Button btnLoadSrcFolderFromIni;
        private System.Windows.Forms.TextBox txtBox_InputPath;
    }
}