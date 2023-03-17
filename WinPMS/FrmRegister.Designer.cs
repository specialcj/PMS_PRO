
namespace WinPMS
{
    partial class FrmRegisterPMS
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_RegisterKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_DeviceName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_UserAcount = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(47, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Acount : ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.textBox_RegisterKey);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_DeviceName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox_UserAcount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 99);
            this.panel1.TabIndex = 2;
            // 
            // textBox_RegisterKey
            // 
            this.textBox_RegisterKey.Location = new System.Drawing.Point(163, 64);
            this.textBox_RegisterKey.Name = "textBox_RegisterKey";
            this.textBox_RegisterKey.ReadOnly = true;
            this.textBox_RegisterKey.Size = new System.Drawing.Size(389, 20);
            this.textBox_RegisterKey.TabIndex = 6;
            this.textBox_RegisterKey.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(46, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Register Key : ";
            // 
            // textBox_DeviceName
            // 
            this.textBox_DeviceName.Enabled = false;
            this.textBox_DeviceName.Location = new System.Drawing.Point(163, 38);
            this.textBox_DeviceName.Name = "textBox_DeviceName";
            this.textBox_DeviceName.Size = new System.Drawing.Size(243, 20);
            this.textBox_DeviceName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(42, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Device Name : ";
            // 
            // textBox_UserAcount
            // 
            this.textBox_UserAcount.Enabled = false;
            this.textBox_UserAcount.Location = new System.Drawing.Point(163, 12);
            this.textBox_UserAcount.Name = "textBox_UserAcount";
            this.textBox_UserAcount.Size = new System.Drawing.Size(114, 20);
            this.textBox_UserAcount.TabIndex = 3;
            // 
            // FrmRegisterPMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 99);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegisterPMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register PMS";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmRegisterPMS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_UserAcount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_DeviceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_RegisterKey;
    }
}