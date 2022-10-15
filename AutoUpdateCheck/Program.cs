using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace AutoUpdateCheckPMS
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Process[] p = Process.GetProcessesByName("WinPMS");
                if (p != null)
                {
                    if (p.Length > 0)
                    {
                        foreach (Process pr in p)
                        {
                            pr.Kill();
                        }
                    }
                }
                Console.WriteLine("Start to Download Files");

                string filePath = System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
                Console.WriteLine("filePath: " + filePath);

                string _appDir = Path.GetDirectoryName(filePath);
                Console.WriteLine("_appDir: " + _appDir);

                //string _appDir2 = Path.Combine(new DirectoryInfo(_appDir).Parent.Parent.Parent.FullName, @"WinPMS\bin\Debug");
                //Console.WriteLine("_appDir2: " + _appDir2);

                //FtpParameters mo = WebAPI.GetFtpParameters();
                //FtpClient ftp = new FtpClient(mo.FtpUser, mo.FtpPsw, mo.FtpServer, mo.FtpPort);
                FtpClient ftp = new FtpClient("CORP\\jason.cai", "hmEBsHve624125", "10.124.15.47", 72);
                //FtpClient ftp = new FtpClient("CORP\\G-CN01.OPERATOR", "CN01operator", "10.124.15.47", 25);

                //List<UpgradeFiles> uFiles = WebAPI.getUpgradeFiles();
                //if (uFiles == null)
                //{
                //    Console.WriteLine("Not Connect to Server!");
                //    Console.ReadKey();
                //    return;
                //}

                List<string> uFilesPMSConfig = new List<string>();
                uFilesPMSConfig.Add("PMS.ini");
                uFilesPMSConfig.Add("PMS_CFM.ini");
                uFilesPMSConfig.Add("PMS_Debug.ini");
                uFilesPMSConfig.Add("PMS_FTP.ini");
                uFilesPMSConfig.Add("PMS_Local.ini");
                uFilesPMSConfig.Add("readme!!!.txt");

                List<string> uFilesPMS = new List<string>();
                uFilesPMS.Add("WinPMS.exe");
                uFilesPMS.Add("App.config");
                uFilesPMS.Add("WinPMS.exe.config");


                for (int i = 0; i < uFilesPMSConfig.Count; i++)
                {
                    Console.WriteLine("Downloading file: " + uFilesPMSConfig[i] + " to Folder " + Path.Combine(_appDir, "Config"));
                    ftp.Download(Path.Combine(Path.Combine(_appDir, "Config"), uFilesPMSConfig[i]), Path.Combine("ftp://10.124.15.47:72/PMS/WinPMS/bin/Debug/Config", uFilesPMSConfig[i]));
                }

                for (int i = 0; i < uFilesPMS.Count; i++)
                {
                    Console.WriteLine("Downloading file: " + uFilesPMS[i] + " to Folder " + _appDir);
                    ftp.Download(Path.Combine(_appDir, uFilesPMS[i]), Path.Combine("ftp://10.124.15.47:72/PMS/WinPMS/bin/Debug", uFilesPMS[i]));
                }


                Console.WriteLine("Complete to Download Files");
                Console.WriteLine("Try to Start PMS Tool!" + "\n" + Path.Combine(_appDir, "WinPMS.exe"));
                string StartProgram = Path.Combine(_appDir, "WinPMS.exe");
                try
                {
                    if (File.Exists(StartProgram))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = StartProgram;
                        process.Start();
                    }
                    Console.WriteLine("Please wait seconds...");
                    int iTry = 0;
                    while (true)
                    {
                        iTry++; Console.Write(".");
                        if (iTry > 35)
                        {
                            Process[] ptool = Process.GetProcessesByName("WinPMS");
                            if (ptool != null)
                            {
                                if (ptool.Length > 0)
                                {
                                    Console.WriteLine("PMS Tool Started");
                                    break;
                                }
                            }
                        }
                        if (iTry > 150)
                        {
                            Console.WriteLine("Failed to Start PMS Tool");
                            break;
                        }
                        Thread.Sleep(200);
                    }
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("StartProgram Exception: " + ex2.Message);
                }

                Console.WriteLine("Press any key to exit!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Download Exception: " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
