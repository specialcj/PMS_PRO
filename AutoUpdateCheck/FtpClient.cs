using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdateCheckPMS
{
    public class FtpClient
    {
        private string _ftpServerIP;
        private string _ftpUserID;
        private string _ftpPassword;
        private int _ftpPort = 72;
        private string ftpURL = "ftp://{0}:72";//:{1}
        private NetworkCredential certificate;

        public int ftpPort { get; set; }
        public string ftpServerIP { get; set; }
        public string ftpUserID { get; set; }
        public string ftpPassword { get; set; }

        public FtpClient()
        {

        }


        public FtpClient(string FtpUserName, string FtpPassword, string FtpServer, int FtpPort = 72)
        {
            if (string.IsNullOrEmpty(FtpUserName) || string.IsNullOrEmpty(FtpUserName) || string.IsNullOrEmpty(FtpUserName))
                throw new Exception("Parameter is empty!");
            ftpPort = FtpPort;
            ftpServerIP = FtpServer;
            ftpUserID = FtpUserName;
            ftpPassword = FtpPassword;
            certificate = new NetworkCredential(FtpUserName, FtpPassword);
        }


        /// <summary>
        /// 下载FTP文件
        /// </summary>
        /// <param name="LocalFileName">本地保存的文件名(含完整路径)</param>
        /// <param name="FtpFileName">FTP的文件名(含相对路径)</param>
        public void Download(string LocalFileName, string FtpFileName)
        {
            FtpWebRequest reqFTP;

            try
            {
                //string uri = string.Format(ftpURL, ftpServerIP) + "/" + FtpFileName;
                string uri = FtpFileName;
                //filePath = <<The full path where the file is to be created.>>, 
                //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                FileStream outputStream = new FileStream(LocalFileName, FileMode.Create);

                reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(uri));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();


                //LogHelper.Info("Download file from FTP[" + FtpFileName + "] to Local[" + LocalFileName + "]");
            }
            catch (Exception ex)
            {
                //LogHelper.Error("Download Exception: " + ex.Message);
                throw ex;
            }
        }

    }
}
