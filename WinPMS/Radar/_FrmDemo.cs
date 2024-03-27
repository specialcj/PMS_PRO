using PMS.COMMON.Helper;
using PMS.MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WinPMS.FModels;
using ImageMagick;
using System.Threading.Tasks;
using System.Text;
using AForge.Video.DirectShow;
using System.Drawing;
using AForge.Video;
using ZXing;

namespace WinPMS.Radar
{
    public partial class _FrmDemo : Form
    {

        public _FrmDemo()
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
