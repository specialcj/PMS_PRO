﻿using PMS.COMMON;
using PMS.MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WinPMS.FModels;

namespace WinPMS.Radar
{
    public partial class FrmRDR2Packing : Form
    {
        public FrmRDR2Packing()
        {
            InitializeComponent();
        }

        #region 事件
        private void FrmRDR2Packing_Load(object sender, EventArgs e)
        {

        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.CloseForm();
        }
        #endregion

    }
}
