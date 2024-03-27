using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace PMS.COMMON.Helper
{
    public class EmailHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailAddressTo"></param>
        /// <param name="mailSubject"></param>
        /// <param name="mailContent"></param>
        public static void OutlookSend(string mailAddressTo, string mailSubject, string mailContent)
        {
            try
            {
                Outlook.Application olApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)olApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.To = mailAddressTo;
                mailItem.Subject = mailSubject;
                mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                mailItem.HTMLBody = mailContent;
                ((Outlook._MailItem)mailItem).Send();

                mailItem = null;
                olApp = null;
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
    }
}
