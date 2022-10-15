using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS.COMMON.Helper
{
    /// <summary>
    /// 通用工具帮助类
    /// </summary>
    public class UtilityHelper
    {
        /// <summary>
        /// 将ListBox控件中的内容写入到指定的txt中
        /// </summary>
        /// <param name="listBox">窗体中的ListBox控件</param>
        /// <param name="txtPath">txt文件的路径</param>
        public static void SaveListBoxToTxt(ListBox listBox, string txtPath)
        {
            FileStream fs = new FileStream(txtPath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            int iCount = listBox.Items.Count - 1;
            for (int i = 0; i <= iCount; i++)
            {
                sw.WriteLine(listBox.Items[i].ToString());
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }


        /// <summary>
        /// 递归目录，添加目录下所有文件的FullName到List<string>中
        /// </summary>
        /// <param name="list">List中存储文件的FullName</param>
        /// <param name="fsi">目录 new DirectoryInfo(path)</param>
        /// <param name="isRecursionSubDir">是否递归子目录 true: 递归子目录, false: 不递归子目录</param>
        public static void RecursionDir(List<string> list, FileSystemInfo fsi, bool isRecursionSubDir)
        {
            if (!fsi.Exists)
            {
                return;
            }

            DirectoryInfo dir = fsi as DirectoryInfo;

            //不是目录
            if (null == dir)
            {
                return;
            }

            FileSystemInfo[] files = dir.GetFileSystemInfos();

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i] as FileInfo;

                //是文件
                if (null != file)
                {
                    //Console.WriteLine(file.FullName + "\t" + file.Length);
                    list.Add(file.FullName);
                }
                else//对于子目录，进行递归调用
                {
                    if (isRecursionSubDir)
                    {
                        RecursionDir(list, files[i], isRecursionSubDir);
                    }
                }
            }
        }


        /// <summary>
        /// 在源字符串中统计被查找字符串的个数
        /// </summary>
        /// <param name="originalString"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static int CountBySearch(string originalString, string search)
        {
            if (string.IsNullOrEmpty(search))
                throw new ArgumentNullException("search");

            int counter = 0;
            int index = originalString.IndexOf(search, 0);
            while (index >= 0 && index < originalString.Length)
            {
                counter++;
                index = originalString.IndexOf(search, index + search.Length);
            }

            return counter;
        }
    }
}
