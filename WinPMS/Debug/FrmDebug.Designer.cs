
namespace WinPMS.Debug
{
    partial class FrmDebug
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
            this.btn_DllCheckForRadar2 = new System.Windows.Forms.Button();
            this.btn_HEIC2jpg = new System.Windows.Forms.Button();
            this.btn_Debug = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_SendMail = new System.Windows.Forms.Button();
            this.btn_ImgToPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_DllCheckForRadar2
            // 
            this.btn_DllCheckForRadar2.Location = new System.Drawing.Point(12, 11);
            this.btn_DllCheckForRadar2.Margin = new System.Windows.Forms.Padding(2);
            this.btn_DllCheckForRadar2.Name = "btn_DllCheckForRadar2";
            this.btn_DllCheckForRadar2.Size = new System.Drawing.Size(111, 40);
            this.btn_DllCheckForRadar2.TabIndex = 0;
            this.btn_DllCheckForRadar2.Text = "DllCheckForRadar";
            this.btn_DllCheckForRadar2.UseVisualStyleBackColor = true;
            this.btn_DllCheckForRadar2.Click += new System.EventHandler(this.btn_DllCheckForRadar2_Click);
            // 
            // btn_HEIC2jpg
            // 
            this.btn_HEIC2jpg.Location = new System.Drawing.Point(12, 103);
            this.btn_HEIC2jpg.Margin = new System.Windows.Forms.Padding(2);
            this.btn_HEIC2jpg.Name = "btn_HEIC2jpg";
            this.btn_HEIC2jpg.Size = new System.Drawing.Size(111, 40);
            this.btn_HEIC2jpg.TabIndex = 1;
            this.btn_HEIC2jpg.Text = ".HEIC to .jpg";
            this.btn_HEIC2jpg.UseVisualStyleBackColor = true;
            this.btn_HEIC2jpg.Click += new System.EventHandler(this.btn_HEIC2jpg_Click);
            // 
            // btn_Debug
            // 
            this.btn_Debug.Location = new System.Drawing.Point(218, 11);
            this.btn_Debug.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Debug.Name = "btn_Debug";
            this.btn_Debug.Size = new System.Drawing.Size(111, 40);
            this.btn_Debug.TabIndex = 2;
            this.btn_Debug.Text = "Debug";
            this.btn_Debug.UseVisualStyleBackColor = true;
            this.btn_Debug.Click += new System.EventHandler(this.btn_Debug_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Red;
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Close.Location = new System.Drawing.Point(738, 11);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(91, 38);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 241);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 20);
            this.textBox1.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 267);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(817, 160);
            this.listBox1.TabIndex = 6;
            // 
            // btn_SendMail
            // 
            this.btn_SendMail.Location = new System.Drawing.Point(218, 103);
            this.btn_SendMail.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SendMail.Name = "btn_SendMail";
            this.btn_SendMail.Size = new System.Drawing.Size(111, 40);
            this.btn_SendMail.TabIndex = 7;
            this.btn_SendMail.Text = "Send Mail";
            this.btn_SendMail.UseVisualStyleBackColor = true;
            this.btn_SendMail.Click += new System.EventHandler(this.btn_SendMail_Click);
            // 
            // btn_ImgToPDF
            // 
            this.btn_ImgToPDF.Location = new System.Drawing.Point(218, 195);
            this.btn_ImgToPDF.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ImgToPDF.Name = "btn_ImgToPDF";
            this.btn_ImgToPDF.Size = new System.Drawing.Size(111, 40);
            this.btn_ImgToPDF.TabIndex = 8;
            this.btn_ImgToPDF.Text = "ImgToPDF";
            this.btn_ImgToPDF.UseVisualStyleBackColor = true;
            this.btn_ImgToPDF.Click += new System.EventHandler(this.btn_ImgToPDF_Click);
            // 
            // FrmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 581);
            this.Controls.Add(this.btn_ImgToPDF);
            this.Controls.Add(this.btn_SendMail);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Debug);
            this.Controls.Add(this.btn_HEIC2jpg);
            this.Controls.Add(this.btn_DllCheckForRadar2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDebug";
            this.Text = "FrmDebug";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_DllCheckForRadar2;
        private System.Windows.Forms.Button btn_HEIC2jpg;
        private System.Windows.Forms.Button btn_Debug;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_SendMail;
        private System.Windows.Forms.Button btn_ImgToPDF;
    }
}