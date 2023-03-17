using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.COMMON.Helper
{
    public class EmailHelper
    {
        /// <summary>
        /// 收件人，多个收件人用分号";"隔开
        /// </summary>
        public string MailTo { get; set; }

        /// <summary>
        /// 抄送，多个收件人用分号";"隔开
        /// </summary>
        public string MailCC { get; set; }

        /// <summary>
        /// 密送，多个收件人用分号";"隔开
        /// </summary>
        public string MailBCC { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public string MailSubject { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string MailHTMLBody { get; set; }

        /// <summary>
        /// 多个附加用分号";"隔开
        /// </summary>
        public string MailAttachments { get; set; }

        public bool Send()
        {
            try
            {
                /*
                Outlook.Application olApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)olApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.To = MailTo;
                mailItem.CC = MailCC;
                mailItem.BCC = MailBCC;
                mailItem.Subject = MailSubject;
                mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;//内容格式
                mailItem.HTMLBody = MailHTMLBody;
                foreach (var item in MailAttachments.Split(';'))
                {
                    mailItem.Attachments.Add(item);
                }
                mailItem.Send();
                mailItem = null;
                olApp = null;
                return true;
                */
            }
            catch (System.Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
