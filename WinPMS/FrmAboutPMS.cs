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
    public partial class FrmAboutPMS : Form
    {
        public FrmAboutPMS()
        {
            InitializeComponent();
        }


        #region 事件

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
