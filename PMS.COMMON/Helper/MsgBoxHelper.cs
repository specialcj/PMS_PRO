using System.Windows.Forms;

namespace PMS.COMMON.Helper
{
    public class MsgBoxHelper
    {
        /// <summary>
        /// 消息提示框
        /// </summary>
        /// <param name="msg">内容</param>
        /// <param name="titile">标题</param>
        /// <returns></returns>
        public static DialogResult MsgBoxShow(string msg, string titile)
        {
            return MessageBox.Show(msg, titile, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }

        public static DialogResult MsgBoxShowOnTop(string msg, string titile)
        {
            return MessageBox.Show(msg, titile, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }

        /// <summary>
        /// Confirm问题询问框
        /// </summary>
        /// <param name="msg">内容</param>
        /// <param name="title">标题</param>
        /// <param name="defaultButton">默认按钮选择1 or 2</param>
        /// <returns></returns>
        public static DialogResult MsgBoxConfirm(string msg, string title, int defaultButton)
        {
            switch (defaultButton)
            {
                case 1:
                    return MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                case 2:
                    return MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);
                default:
                    return MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }

        }


        /// <summary>
        /// Error错误提示框
        /// </summary>
        /// <param name="msg">内容</param>
        public static void MsgBoxError(string msg)
        {
            MessageBox.Show(msg, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }

    }
}
