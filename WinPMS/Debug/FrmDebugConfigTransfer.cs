using PMS.COMMON.Helper;
using System;
using System.Windows.Forms;

namespace WinPMS.Debug
{
    public partial class FrmDebugConfigTransfer : Form
    {
        public FrmDebugConfigTransfer()
        {
            InitializeComponent();
        }







        #region 事件






        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Close" + " ？", "Info", 2))
            {
                this.CloseForm();
            }
        }






        #endregion


        #region 方法



        #endregion


    }
}
