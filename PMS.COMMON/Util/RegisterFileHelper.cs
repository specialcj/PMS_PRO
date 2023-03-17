using System;
using System.IO;

namespace PMS.COMMON.Util
{
    public class RegisterFileHelper
    {
        public static string ComputerInfofile = "ComputerInfo.key";
        public static string RegisterInfofile = "RegisterInfo.key";
        public static void WriteRegisterInfoFile(string info)
        {
            WriteFile(info, RegisterInfofile);
        }
        public static void WriteComputerInfoFile(string info)
        {
            WriteFile(info, ComputerInfofile);
        }
        public static string ReadRegisterInfoFile()
        {
            return ReadFile(RegisterInfofile);
        }
        public static string ReadComputerInfoFile()
        {
            return ReadFile(ComputerInfofile);
        }
        public static bool ExistComputerInfofile()
        {
            return File.Exists(ComputerInfofile);
        }
        public static bool ExistRegisterInfofile()
        {
            return File.Exists(RegisterInfofile);
        }
        private static void WriteFile(string info, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(info);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private static string ReadFile(string fileName)
        {
            string info = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    info = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return info;
        }
    }
}
