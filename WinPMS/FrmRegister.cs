using PMS.COMMON.Util;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPMS
{
    public partial class FrmRegisterPMS : Form
    {
        public FrmRegisterPMS()
        {
            InitializeComponent();
        }

        private async void FrmRegisterPMS_Load(object sender, EventArgs e)
        {
            textBox_UserAcount.Text = Environment.UserName;
            textBox_DeviceName.Text = Environment.MachineName;
            await Task.Run(new Action(()=> {
                if (textBox_RegisterKey.InvokeRequired)
                {
                    textBox_RegisterKey.Invoke(new Action(() =>
                    {
                        textBox_RegisterKey.Text = ComputerInfo.GetComputerInfo();
                    }));
                }
            }));
        }

    }
}
