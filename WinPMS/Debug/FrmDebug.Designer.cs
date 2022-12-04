
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
            this.SuspendLayout();
            // 
            // btn_DllCheckForRadar2
            // 
            this.btn_DllCheckForRadar2.Location = new System.Drawing.Point(8, 8);
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
            this.btn_HEIC2jpg.Location = new System.Drawing.Point(8, 90);
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
            this.btn_Debug.Location = new System.Drawing.Point(283, 8);
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
            this.button1.Location = new System.Drawing.Point(8, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(738, 8);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(91, 38);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // FrmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 547);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Debug);
            this.Controls.Add(this.btn_HEIC2jpg);
            this.Controls.Add(this.btn_DllCheckForRadar2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDebug";
            this.Text = "FrmDebug";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_DllCheckForRadar2;
        private System.Windows.Forms.Button btn_HEIC2jpg;
        private System.Windows.Forms.Button btn_Debug;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Close;
    }
}