using PMS.COMMON.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPMS
{
    public partial class FrmAdminAuthority : Form
    {
        public FrmAdminAuthority()
        {
            InitializeComponent();
        }

        public event Action ActAccountValid;
        public event Action ActAccountNotValid;
        public event Action ActFormClosing;

        public Func<string> FuncFormLabel;
        public Func<string> FuncMsgShowAccountEmpty;
        public Func<string> FuncMsgShowAccountNotValid;

        private void FrmAdminAuthority_Load(object sender, EventArgs e)
        {
            label1.Text = FuncFormLabel.Invoke();
        }

        
        private void btn_OK_Click(object sender, EventArgs e)
        {
            if ("jason".Equals(txt_AdminAccount.Text.Trim()))
            {
                ActAccountValid.Invoke();
            }
            else if (string.IsNullOrEmpty(txt_AdminAccount.Text.Trim()))
            {
                string sMsg = FuncMsgShowAccountEmpty.Invoke();
                MsgBoxHelper.MsgBoxError(sMsg);
                ActAccountNotValid.Invoke();
            }
            else
            {
                string sMsg = FuncMsgShowAccountNotValid.Invoke();
                MsgBoxHelper.MsgBoxError(sMsg);
                ActAccountNotValid.Invoke();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ActFormClosing.Invoke();
        }

        
    }
}
