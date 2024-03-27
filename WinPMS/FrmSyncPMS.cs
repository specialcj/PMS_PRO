using PMS.COMMON.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WinPMS
{
    public partial class FrmSyncPMS : Form
    {
        public FrmSyncPMS()
        {
            InitializeComponent();
        }


        #region 事件

        private void btn_LoadPMS_Click(object sender, EventArgs e)
        {
            string[] sArrPMSProjet = Directory.GetDirectories(txt_PMSProjectPath.Text.Trim());

            List<string> lstPMSProject = new List<string>(sArrPMSProjet);

            dgv_PMSProject.Rows.Clear();
            for (int i = 0, j = 0; i < lstPMSProject.Count; i++)
            {
                if (lstPMSProject[i].Contains("PMS_V"))
                {
                    dgv_PMSProject.Rows.Add();
                    dgv_PMSProject.Rows[j].Cells[0].Value = lstPMSProject[i];
                    j++;
                }
            }
        }


        private void dgv_PMSProject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取选中的单元格
            DataGridViewCell curCell = dgv_PMSProject.CurrentCell;

            //获取选中单元格的值
            string strCurCell = curCell.FormattedValue.ToString();

            //获取当前行的数据绑定对象
            

            //判断值
            switch (strCurCell)
            {
                case "启用":
                    
                    break;
                case "停用":
                    break;
            }
        }


        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Close" + " ？", "Info", 2))
            {
                this.CloseForm();
            }
        }


        private void btn_Debug_Click(object sender, EventArgs e)
        {
            
        }


        #endregion

        #region 方法



        #endregion

        
    }
}



