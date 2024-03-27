using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS.ITAC
{
    public class ITacCheck
    {
        public void switchSerialNumberCheck(int ret, string stationNr, string serialNumberOld, string serialNumberNew)
        {
            //Output values
            //0     -> OK
            //-1    -> Error: SerialNumberOld not found
            //-2    -> Error: SerialNumberNew is already active
            //-3    -> Error: station not found
            //-5    -> Error: Error during database prcessing
            //         Advice: This value is retuned e.g. if an empty string is passed for SerialNumberNew!
            //-50   -> Error: no user registered at station
            //         Advice: Value is only returned, if the station parameter code no. 8300 is active!
            //-78   -> Error: no TR license for this station
            //-99   -> Error: Server error
            //-100  -> Error: Corba no Service
            //-101  -> Error: Corba Exception
            //-506  -> Error: Site is not ewMII-licensed

            string str = "API -> switchSerialNumber, " + "返回值 -> " + ret + "\n\n" +
                         "序列号转换不成功！" + "\n\n" +
                         "站位号（stationNr）" + stationNr + "\n\n" +
                         "序列号旧（工厂序列号）（serialNumberOld） -> " + serialNumberOld + "\n\n" +
                         "序列号新（客户序列号）（serialNumberNew） -> " + serialNumberNew + "\n\n";

            if (-1 == ret)
            {
                MessageBox.Show(
                    str +
                    "故障分析：" + "\n" +
                    "-> 工厂序列号不存在！",
                    "iTAC错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
            }
            else if (-2 == ret)
            {
                MessageBox.Show(
                    str +
                    "故障分析：" + "\n" +
                    "-> 客户序列号已存在！",
                    "iTAC错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
            }
            else if (-3 == ret)
            {
                MessageBox.Show(
                    str +
                    "故障分析：" + "\n" +
                    "-> 站位号（StationNr）不存在！",
                    "iTAC错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
            }
            else if (-5 == ret)
            {
                MessageBox.Show(
                    str +
                    "故障分析：" + "\n" +
                    "-> 工厂序列号 和 客户序列号 相同 -> " + "客户序列号未生成" + "\n\n" +
                    "-> 工厂序列号 和 客户序列号 不相同 -> " + "客户序列号已生成，转换不成功（联系IT工程师！）",
                    "iTAC错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
            }
            else
            {
                MessageBox.Show(
                    str +
                    "故障分析：" + "\n" +
                    "-> 联系IT工程师！",
                    "iTAC错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
            }
        }
    }
}
