using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PMS.COMMON.Helper
{
    /// <summary>
    /// Ini文件帮助类
    /// </summary>
    public class IniHelper
    {
        //读写ini文件的API
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpAppName"></param>
        /// <param name="lpKeyName"></param>
        /// <param name="lpDefault"></param>
        /// <param name="lpReturnedString"></param>
        /// <param name="nSize"></param>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileStringA(string lpAppName, string lpKeyName, string lpDefault, Byte[] retVal, int nSize, string lpFileName);

        //private static extern int GetPrivateProfileStringB(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        //private static extern int GetPrivateProfileSectionNamesA(byte[] buffer, int iLen, string fileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool WritePrivateProfileSection(string lpAppName, string lpString, string lpFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpApplicationName"></param>
        /// <param name="lpKeyName"></param>
        /// <param name="lpString"></param>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);


        /// <summary>
        /// 读取ini文件
        /// </summary>
        /// <param name="section">表示ini文件中的节点名</param>
        /// <param name="key">表示键名</param>
        /// <param name="def">没有查到的话返回的默认值</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static string ReadIni(string section, string key, string def, string filePath)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, sb, 1024, filePath);
            return sb.ToString();
        }

        /// <summary>
        /// 写入ini文件
        /// </summary>
        /// <param name="section">表示ini文件中的节点名</param>
        /// <param name="key">表示键名</param>
        /// <param name="value">value写入的值</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static int WriteIni(string section, string key, string value, string filePath)
        {
            return WritePrivateProfileString(section, key, value, filePath);
        }

        public static List<string> ReadSections(string iniFileName)
        {
            List<string> sections = new List<string>();
            Byte[] buf = new byte[65535];
            uint len = GetPrivateProfileStringA(null, null, null, buf, buf.Length, iniFileName);
            int j = 0;
            for (int i = 0; i < len; i++)
            {
                if (buf[i] == 0)
                {
                    sections.Add(Encoding.Default.GetString(buf, j, i-j));
                    j = i + 1;
                }
            }
            return sections;
        }

        public static List<string> ReadSectionsEx(string iniFileName)
        {
            byte[] buffer = new byte[65535];
            int rel = 0;//GetPrivateProfileSectionNamesA(buffer, buffer.GetUpperBound(0), iniFileName);
            int iCnt, iPos;
            List<string> sections = new List<string>();
            string tmp;
            if (rel > 0)
            {
                iCnt = 0;
                iPos = 0;
                for (iCnt = 0;  iCnt < rel; iCnt++)
                {
                    if (buffer[iCnt] == 0x00)
                    {
                        tmp = ASCIIEncoding.Default.GetString(buffer, iPos, iCnt - iPos).Trim();
                        iPos = iCnt + 1;
                        if (tmp != "")
                        {
                            sections.Add(tmp);
                        }
                    }
                }
            }

            return sections;
        }

        public static List<string> ReadKeys(string sectionName, string iniFileName)
        {
            List<string> keys = new List<string>();
            Byte[] buf = new byte[65535];
            uint len = GetPrivateProfileStringA(sectionName, null, null, buf, buf.Length, iniFileName);
            int j = 0;
            for (int i = 0; i < len; i++)
            {
                if (buf[i] == 0)
                {
                    keys.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            }
            return keys;
        }

        public static bool WriteSectionAndItems(string iniFile, string section, string items)
        {
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }

            if (string.IsNullOrEmpty(items))
            {
                throw new ArgumentException("必须指定键值对", "items");
            }

            return WritePrivateProfileSection(section, items, iniFile);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="section"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int DeleteIniSection(string section, string filePath)
        {
            return WriteIni(section, null, null, filePath);
        }

        /// <summary>
        /// 删除键
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int DeleteIniKey(string section, string key, string filePath)
        {
            return WriteIni(section, key, null, filePath);
        }
    }
}
