using PMS.COMMON.Helper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinPMS
{
    public static class FrmUtility
    {
        /// <summary>
        /// Action的try catch异常处理扩展方法
        /// </summary>
        /// <param name="act"></param>
        /// <param name="message"></param>
        public static void TryCatchInvoke(this Action act, string message)
        {
            try
            {
                act.Invoke();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError(ex.Message);
            }
        }

        /// <summary>
        /// 关闭显示在选项卡中的窗体
        /// </summary>
        /// <param name="form"></param>
        public static void CloseForm(this Form form)
        {
            if (!form.TopLevel)
            {
                TabPage tp = form.Parent as TabPage;
                TabControl tc = tp.Parent as TabControl;
                tc.TabPages.Remove(tp);
            }
            form.Close();

        }

        /// <summary>
        /// 判断Form是否已打开
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static bool CheckOpenForm(string formName)
        {
            bool bResult = false;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == formName)
                {
                    bResult = true;
                    break;
                }
            }
            return bResult;
        }

        /// <summary>
        /// 关闭指定的窗体
        /// </summary>
        /// <param name="formName"></param>
        public static void CloseOpenForm(string formName)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == formName)
                {
                    frm.Close();
                    break;
                }
            }
        }


        /// <summary>
        /// 显示已经打开的窗体
        /// </summary>
        /// <param name="formName"></param>
        public static void ShowOpenForm(string formName)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == formName)
                {
                    if (!frm.Visible)
                    {
                        frm.Show();
                    }

                    frm.Activate();
                    break;
                }
            }
        }

        /// <summary>
        /// 添加窗体页面到选项卡中
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="form"></param>
        public static void AddTabFormPage(this TabControl tab, Form form)
        {
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.WindowState = FormWindowState.Normal;
            TabPage page = new TabPage();
            page.Controls.Add(form);
            page.Name = form.Name;
            page.Text = form.Text;
            page.Width = form.Width;
            page.Height = form.Height;
            tab.TabPages.Add(page);
            tab.SelectedTab = page;
            form.Show();
        }

        /// <summary>
        /// 移除已删除的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dgv"></param>
        /// <param name="delList"></param>
        public static void RefreshDgv<T>(this DataGridView dgv, List<T> delList) where T : class
        {
            List<T> list = dgv.DataSource as List<T>;
            dgv.DataSource = null;
            foreach (var r in delList)
            {
                list.Remove(r);
            }
            dgv.DataSource = list;
        }

        /// <summary>
        /// 创建TreeView节点
        /// </summary>
        /// <param name="tName"></param>
        /// <param name="nText"></param>
        /// <returns></returns>
        public static TreeNode CreateNode(string tName, string nText)
        {
            TreeNode tn = new TreeNode
            {
                Name = tName,
                Text = nText
            };
            return tn;
        }

    }
}
