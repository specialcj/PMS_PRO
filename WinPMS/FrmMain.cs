using PMS.COMMON.Helper;
using PMS.COMMON.Util;
using PMS.MODELS.DModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinPMS.Debug;
using WinPMS.FModels;
using static PMS.COMMON.Util.EncryptionHelper;

namespace WinPMS
{
    public partial class FrmMain : Form
    {
        private const int INTERNET_CONNECTION_MODEM = 1;
        private const int INTERNET_CONNECTION_LAN = 2;
        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);

        //屏蔽右上角的X关闭按钮
        [DllImport("USER32.DLL")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, UInt32 bRevert);

        [DllImport("USER32.DLL")]
        private static extern UInt32 RemoveMenu(IntPtr hMenu, UInt32 nPosition, UInt32 wFlags);
        private const UInt32 SC_CLOSE = 0x0000F060;
        private const UInt32 MF_BYCOMMAND = 0x00000000;

        private FrmLogin _frmLogin = null;
        private FrmProgressBar _frmProgressBar = null;
        private FrmProgressBarModel _frmProgressBarModel = null;

        private string _sUserName = "";//当前登录用户信息
        private int _iIsFrmFirstLoad = 0;//是否是第一次加载

        private string encryptComputer = "";
        private bool _bIsRegister = false;
        private const int PMS_TIME_COUNT = 10 * 60;

        private string _sAuthorityFile = FileHelper.sExeFolderPath + @"\dll\" + FileHelper.PMS_AUTHORITY;
        private string _sDate1Read = "";
        private string _sDate2Read = "";
        private string _sExpiredDays = "";

        private static string _sDate2Init = "date2-0000-00-00";
        private char[] _chDate2Init = _sDate2Init.ToCharArray();

        private static string _sDate2Set = "date2-0000-00-00";
        private char[] _chDate2Set = _sDate2Set.ToCharArray();

        private List<string> _lstAuthorityInfos = new List<string>();//授权文件信息列表

        public FrmMain()
        {
            InitializeComponent();

            //禁用关闭按钮
            //IntPtr hMenu = GetSystemMenu(this.Handle, 0);
            //RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND);

            //Control.CheckForIllegalCrossThreadCalls = false;
        }

        #region 事件
        /// <summary>
        /// 主页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                _iIsFrmFirstLoad = 1;

                if (null != this.Tag)
                {
                    _frmProgressBarModel = this.Tag as FrmProgressBarModel;

                    #region 检查注册信息
                    encryptComputer = new EncryptionHelper().EncryptString(FileHelper.sComputerInfo);
                    if (CheckRegister() == true)
                    {
                        lblRegisterTimeRemaining.Text = "OK";
                    }
                    else//Not Registed
                    {
                        //软件未注册，提示
                        //MsgBoxHelper.MsgBoxShow("PMS Not Registed!\n\n" + "PMS will be aborted after: " + (TIME_COUNT / 60) + "mins", "Register");
                        //_lstAuthorityInfos = ReadInfosFromAuthorityFile(_sAuthorityFile);
                        //_sDate1Read = _lstAuthorityInfos[0];
                        //_sDate2Read = _lstAuthorityInfos[1];
                        //_sExpiredDays = _lstAuthorityInfos[2];

                        /*
                        string[] lines = File.ReadAllLines(_sAuthorityFile);

                        //date1-yyyy-mm-dd
                        _sDate1Read =
                            lines[3019].Substring(4, 1) +
                            lines[131].Substring(64, 1) +
                            lines[85].Substring(14, 1) +
                            lines[1358].Substring(10, 1) +
                            lines[29].Substring(69, 1) +
                            lines[287].Substring(63, 1) +
                            lines[110].Substring(35, 1) +
                            lines[4].Substring(80, 1) +
                            lines[119].Substring(37, 1) +
                            lines[7].Substring(73, 1) +
                            lines[299].Substring(53, 1) +
                            lines[6].Substring(12, 1) +
                            lines[2020].Substring(30, 1) +
                            lines[308].Substring(36, 1) +
                            lines[8].Substring(48, 1) +
                            lines[2035].Substring(41, 1);

                        //date2-yyyy-mm-dd
                        _sDate2Read =
                            lines[335].Substring(88, 1) +
                            lines[386].Substring(3, 1) +
                            lines[155].Substring(14, 1) +
                            lines[1641].Substring(3, 1) +
                            lines[147].Substring(57, 1) +
                            lines[331].Substring(67, 1) +
                            lines[214].Substring(41, 1) +
                            lines[11].Substring(14, 1) +
                            lines[266].Substring(5, 1) +
                            lines[30].Substring(61, 1) +
                            lines[342].Substring(85, 1) +
                            lines[12].Substring(34, 1) +
                            lines[2036].Substring(7, 1) +
                            lines[424].Substring(67, 1) +
                            lines[671].Substring(87, 1) +
                            lines[2039].Substring(51, 1);
                        */

                        //if date2 is the initial value，it means the PMS has not been used，so write the date2 immediately
                        //if (_sDate2Read == _sDate2Init)
                        //{
                        WriteDate2ToAuthorityFile(_sAuthorityFile);

                        //读取Authority Date
                        _lstAuthorityInfos = ReadInfosFromAuthorityFile(_sAuthorityFile);
                        _sDate1Read = _lstAuthorityInfos[0];
                        _sDate2Read = _lstAuthorityInfos[1];
                        _sExpiredDays = _lstAuthorityInfos[2];
                        //}

                        DateTime dt1 = Convert.ToDateTime(_sDate1Read.Substring(6));
                        DateTime dt2 = Convert.ToDateTime(_sDate2Read.Substring(6));

                        //Authority Date invalide, K PMS
                        if ((dt2 - dt1).Days < 0)
                        {
                            MessageBox.Show("PMS Not Registed!\n\nPMS date invalid!\n\nPMS will be exited immediately!", "PMS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                            Process[] p = Process.GetProcessesByName("WinPMS");
                            p[0].Kill();
                        }

                        if (CheckIsExpire(_sDate1Read, _sDate2Read))
                        {
                            MessageBox.Show("PMS Not Registed!\n\nPMS has been expired!\n\nPMS will be exited immediately!", "PMS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                            Process[] p = Process.GetProcessesByName("WinPMS");
                            p[0].Kill();

                            //Task.Run(new Action(() =>
                            //{
                            //    ClosePMSWithoutRegister();
                            //}));
                        }
                        else
                        {
                            tmrAuthority.Enabled = true;
                            MessageBox.Show("PMS Not Registed!\n\nPMS will expired on" + " " + dt1.AddDays(int.Parse(_sExpiredDays)).ToString("yyyy-MM-dd") + ".", "PMS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        }

                        RegisterFileHelper.WriteComputerInfoFile(encryptComputer);
                    }
                    #endregion

                    //如果联网的情况下，调用Outlook发送登录PMS通知
                    System.Int32 dwFlag = new int();
                    if (InternetGetConnectedState(ref dwFlag, 0))//已联网
                    {
                        string sMailContent =
                            Environment.UserName + " login PMS at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " +
                            "Register: " + lblRegisterTimeRemaining.Text + " | " +
                            "dateCurrent: " + DateTime.Now.ToString("yyyy-MM-dd") + " | " +
                            _sDate1Read + " | " +
                            _sDate2Read + " | " +
                            "Remaining Days: " + (Convert.ToDateTime(_sDate2Read.Substring(6)) - Convert.ToDateTime(_sDate1Read.Substring(6))).Days;
                        EmailHelper.OutlookSend("specialcj@163.com", "PMS Login Notification", sMailContent);
                    }

                    InitMainInfo();
                }
            };
            act.TryCatchInvoke("Exception on Init FrmMain！");
        }


        /// <summary>
        /// 窗体Visible属性改变时触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_VisibleChanged(object sender, EventArgs e)
        {
            if (_iIsFrmFirstLoad == 2)
            {
                InitMainInfo();
                _iIsFrmFirstLoad = 1;
            }
        }


        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_sUserName == "admin")
            {
                if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Are you sure to exit？", "Exit", 2))
                {
                    Application.ExitThread();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                MsgBoxHelper.MsgBoxError("Exit not allowed！\nPlease login as admin！");
                e.Cancel = true;
            }
        }


        /// <summary>
        /// 当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrCurrTime_Tick(object sender, EventArgs e)
        {
            lblCurrTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 周期写入软件使用的时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrAuthority_Tick(object sender, EventArgs e)
        {
            WriteDate2ToAuthorityFile(_sAuthorityFile);

            /*
            string[] lines = File.ReadAllLines(_sAuthorityFile);
            for (int i = 0; i < lines.Length; i++)
            {
                string sDateNow = DateTime.Now.ToString("yyyy-MM-dd");
                char[] chDateNowYear = sDateNow.Substring(0, 4).ToCharArray();
                char[] chDateNowMonth = sDateNow.Substring(5, 2).ToCharArray();
                char[] chDateNowDay = sDateNow.Substring(8, 2).ToCharArray();

                //设置Date2
                //lines[335] = lines[335].Replace(_chDate2Init[0], _chDate2Set[0]);
                //lines[386] = lines[386].Replace(_chDate2Init[1], _chDate2Set[1]);
                //lines[155] = lines[155].Replace(_chDate2Init[2], _chDate2Set[2]);
                //lines[1641] = lines[1641].Replace(_chDate2Init[3], _chDate2Set[3]);
                //lines[147] = lines[147].Replace(_chDate2Init[4], _chDate2Set[4]);
                //lines[331] = lines[331].Replace(_chDate2Init[5], _chDate2Set[5]);

                lines[214] = lines[214].Replace('0', chDateNowYear[0]);//y
                lines[214] = lines[214].Replace('1', chDateNowYear[0]);
                lines[214] = lines[214].Replace('2', chDateNowYear[0]);
                lines[214] = lines[214].Replace('3', chDateNowYear[0]);
                lines[214] = lines[214].Replace('4', chDateNowYear[0]);
                lines[214] = lines[214].Replace('5', chDateNowYear[0]);
                lines[214] = lines[214].Replace('6', chDateNowYear[0]);
                lines[214] = lines[214].Replace('7', chDateNowYear[0]);
                lines[214] = lines[214].Replace('8', chDateNowYear[0]);
                lines[214] = lines[214].Replace('9', chDateNowYear[0]);

                lines[11] = lines[11].Replace('0', chDateNowYear[1]);
                lines[11] = lines[11].Replace('1', chDateNowYear[1]);
                lines[11] = lines[11].Replace('2', chDateNowYear[1]);
                lines[11] = lines[11].Replace('3', chDateNowYear[1]);
                lines[11] = lines[11].Replace('4', chDateNowYear[1]);
                lines[11] = lines[11].Replace('5', chDateNowYear[1]);
                lines[11] = lines[11].Replace('6', chDateNowYear[1]);
                lines[11] = lines[11].Replace('7', chDateNowYear[1]);
                lines[11] = lines[11].Replace('8', chDateNowYear[1]);
                lines[11] = lines[11].Replace('9', chDateNowYear[1]);

                lines[266] = lines[266].Replace('0', chDateNowYear[2]);
                lines[266] = lines[266].Replace('1', chDateNowYear[2]);
                lines[266] = lines[266].Replace('2', chDateNowYear[2]);
                lines[266] = lines[266].Replace('3', chDateNowYear[2]);
                lines[266] = lines[266].Replace('4', chDateNowYear[2]);
                lines[266] = lines[266].Replace('5', chDateNowYear[2]);
                lines[266] = lines[266].Replace('6', chDateNowYear[2]);
                lines[266] = lines[266].Replace('7', chDateNowYear[2]);
                lines[266] = lines[266].Replace('8', chDateNowYear[2]);
                lines[266] = lines[266].Replace('9', chDateNowYear[2]);

                lines[30] = lines[30].Replace('0', chDateNowYear[3]);
                lines[30] = lines[30].Replace('1', chDateNowYear[3]);
                lines[30] = lines[30].Replace('2', chDateNowYear[3]);
                lines[30] = lines[30].Replace('3', chDateNowYear[3]);
                lines[30] = lines[30].Replace('4', chDateNowYear[3]);
                lines[30] = lines[30].Replace('5', chDateNowYear[3]);
                lines[30] = lines[30].Replace('6', chDateNowYear[3]);
                lines[30] = lines[30].Replace('7', chDateNowYear[3]);
                lines[30] = lines[30].Replace('8', chDateNowYear[3]);
                lines[30] = lines[30].Replace('9', chDateNowYear[3]);

                //lines[342] = lines[342].Replace(_chDate2Init[10], _chDate2Set[10]);

                lines[12] = lines[12].Replace('0', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('1', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('2', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('3', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('4', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('5', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('6', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('7', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('8', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('9', chDateNowMonth[0]);//m

                lines[2036] = lines[2036].Replace('0', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('1', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('2', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('3', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('4', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('5', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('6', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('7', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('8', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('9', chDateNowMonth[1]);

                //lines[424] = lines[424].Replace(_chDate2Init[13], _chDate2Set[13]);

                lines[671] = lines[671].Replace('0', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('1', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('2', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('3', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('4', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('5', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('6', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('7', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('8', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('9', chDateNowDay[0]);//d

                lines[2039] = lines[2039].Replace('0', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('1', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('2', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('3', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('4', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('5', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('6', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('7', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('8', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('9', chDateNowDay[1]);
            }
            File.WriteAllLines(_sAuthorityFile, lines);
            */

            string[] lines = File.ReadAllLines(_sAuthorityFile);

            //date1-yyyy-mm-dd
            _sDate1Read =
                lines[3019].Substring(4, 1) +
                lines[131].Substring(64, 1) +
                lines[85].Substring(14, 1) +
                lines[1358].Substring(10, 1) +
                lines[29].Substring(69, 1) +
                lines[287].Substring(63, 1) +
                lines[110].Substring(35, 1) +
                lines[4].Substring(80, 1) +
                lines[119].Substring(37, 1) +
                lines[7].Substring(73, 1) +
                lines[299].Substring(53, 1) +
                lines[6].Substring(12, 1) +
                lines[2020].Substring(30, 1) +
                lines[308].Substring(36, 1) +
                lines[8].Substring(48, 1) +
                lines[2035].Substring(41, 1);

            //date2-yyyy-mm-dd
            _sDate2Read =
                lines[335].Substring(88, 1) +
                lines[386].Substring(3, 1) +
                lines[155].Substring(14, 1) +
                lines[1641].Substring(3, 1) +
                lines[147].Substring(57, 1) +
                lines[331].Substring(67, 1) +
                lines[214].Substring(41, 1) +
                lines[11].Substring(14, 1) +
                lines[266].Substring(5, 1) +
                lines[30].Substring(61, 1) +
                lines[342].Substring(85, 1) +
                lines[12].Substring(34, 1) +
                lines[2036].Substring(7, 1) +
                lines[424].Substring(67, 1) +
                lines[671].Substring(87, 1) +
                lines[2039].Substring(51, 1);

            if (CheckIsExpire(_sDate1Read, _sDate2Read))
            {
                //MsgBoxHelper.MsgBoxError("PMS has been expired！");
                Task.Run(new Action(() =>
                {
                    ClosePMSWithoutRegister();
                }));
            }
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            ShowFrm(0, new FrmDebugModeWarning());
        }

        #endregion



        #region 方法
        /// <summary>
        /// 从授权文件中读取日期
        /// </summary>
        /// <param name="authorityFile"></param>
        /// <returns></returns>
        private List<string> ReadInfosFromAuthorityFile(string authorityFile)
        {
            List<string> lstAuthorityInfosRead = new List<string>();
            lstAuthorityInfosRead.Clear();

            string[] lines = File.ReadAllLines(authorityFile);

            //date1-yyyy-mm-dd
            _sDate1Read =
                lines[3019].Substring(4, 1) +
                lines[131].Substring(64, 1) +
                lines[85].Substring(14, 1) +
                lines[1358].Substring(10, 1) +
                lines[29].Substring(69, 1) +
                lines[287].Substring(63, 1) +
                lines[110].Substring(35, 1) +
                lines[4].Substring(80, 1) +
                lines[119].Substring(37, 1) +
                lines[7].Substring(73, 1) +
                lines[299].Substring(53, 1) +
                lines[6].Substring(12, 1) +
                lines[2020].Substring(30, 1) +
                lines[308].Substring(36, 1) +
                lines[8].Substring(48, 1) +
                lines[2035].Substring(41, 1);
            lstAuthorityInfosRead.Add(_sDate1Read);

            //date2-yyyy-mm-dd
            _sDate2Read =
                lines[335].Substring(88, 1) +
                lines[386].Substring(3, 1) +
                lines[155].Substring(14, 1) +
                lines[1641].Substring(3, 1) +
                lines[147].Substring(57, 1) +
                lines[331].Substring(67, 1) +
                lines[214].Substring(41, 1) +
                lines[11].Substring(14, 1) +
                lines[266].Substring(5, 1) +
                lines[30].Substring(61, 1) +
                lines[342].Substring(85, 1) +
                lines[12].Substring(34, 1) +
                lines[2036].Substring(7, 1) +
                lines[424].Substring(67, 1) +
                lines[671].Substring(87, 1) +
                lines[2039].Substring(51, 1);
            lstAuthorityInfosRead.Add(_sDate2Read);

            _sExpiredDays =
                lines[163].Substring(49, 1) +
                lines[775].Substring(72, 1) +
                lines[817].Substring(53, 1) +
                lines[1147].Substring(19, 1);
            lstAuthorityInfosRead.Add(_sExpiredDays);

            return lstAuthorityInfosRead;
        }


        /// <summary>
        /// 将date2写入Authority文件
        /// </summary>
        /// <param name="authorityFile"></param>
        private void WriteDate2ToAuthorityFile(string authorityFile)
        {
            string[] lines = File.ReadAllLines(authorityFile);

            for (int i = 0; i < lines.Length; i++)
            {
                string sDateNow = DateTime.Now.ToString("yyyy-MM-dd");
                char[] chDateNowYear = sDateNow.Substring(0, 4).ToCharArray();
                char[] chDateNowMonth = sDateNow.Substring(5, 2).ToCharArray();
                char[] chDateNowDay = sDateNow.Substring(8, 2).ToCharArray();

                //设置Date2
                //lines[335] = lines[335].Replace(_chDate2Init[0], _chDate2Set[0]);
                //lines[386] = lines[386].Replace(_chDate2Init[1], _chDate2Set[1]);
                //lines[155] = lines[155].Replace(_chDate2Init[2], _chDate2Set[2]);
                //lines[1641] = lines[1641].Replace(_chDate2Init[3], _chDate2Set[3]);
                //lines[147] = lines[147].Replace(_chDate2Init[4], _chDate2Set[4]);
                //lines[331] = lines[331].Replace(_chDate2Init[5], _chDate2Set[5]);

                lines[214] = lines[214].Replace('0', chDateNowYear[0]);//y
                lines[214] = lines[214].Replace('1', chDateNowYear[0]);
                lines[214] = lines[214].Replace('2', chDateNowYear[0]);
                lines[214] = lines[214].Replace('3', chDateNowYear[0]);
                lines[214] = lines[214].Replace('4', chDateNowYear[0]);
                lines[214] = lines[214].Replace('5', chDateNowYear[0]);
                lines[214] = lines[214].Replace('6', chDateNowYear[0]);
                lines[214] = lines[214].Replace('7', chDateNowYear[0]);
                lines[214] = lines[214].Replace('8', chDateNowYear[0]);
                lines[214] = lines[214].Replace('9', chDateNowYear[0]);

                lines[11] = lines[11].Replace('0', chDateNowYear[1]);
                lines[11] = lines[11].Replace('1', chDateNowYear[1]);
                lines[11] = lines[11].Replace('2', chDateNowYear[1]);
                lines[11] = lines[11].Replace('3', chDateNowYear[1]);
                lines[11] = lines[11].Replace('4', chDateNowYear[1]);
                lines[11] = lines[11].Replace('5', chDateNowYear[1]);
                lines[11] = lines[11].Replace('6', chDateNowYear[1]);
                lines[11] = lines[11].Replace('7', chDateNowYear[1]);
                lines[11] = lines[11].Replace('8', chDateNowYear[1]);
                lines[11] = lines[11].Replace('9', chDateNowYear[1]);

                lines[266] = lines[266].Replace('0', chDateNowYear[2]);
                lines[266] = lines[266].Replace('1', chDateNowYear[2]);
                lines[266] = lines[266].Replace('2', chDateNowYear[2]);
                lines[266] = lines[266].Replace('3', chDateNowYear[2]);
                lines[266] = lines[266].Replace('4', chDateNowYear[2]);
                lines[266] = lines[266].Replace('5', chDateNowYear[2]);
                lines[266] = lines[266].Replace('6', chDateNowYear[2]);
                lines[266] = lines[266].Replace('7', chDateNowYear[2]);
                lines[266] = lines[266].Replace('8', chDateNowYear[2]);
                lines[266] = lines[266].Replace('9', chDateNowYear[2]);

                lines[30] = lines[30].Replace('0', chDateNowYear[3]);
                lines[30] = lines[30].Replace('1', chDateNowYear[3]);
                lines[30] = lines[30].Replace('2', chDateNowYear[3]);
                lines[30] = lines[30].Replace('3', chDateNowYear[3]);
                lines[30] = lines[30].Replace('4', chDateNowYear[3]);
                lines[30] = lines[30].Replace('5', chDateNowYear[3]);
                lines[30] = lines[30].Replace('6', chDateNowYear[3]);
                lines[30] = lines[30].Replace('7', chDateNowYear[3]);
                lines[30] = lines[30].Replace('8', chDateNowYear[3]);
                lines[30] = lines[30].Replace('9', chDateNowYear[3]);

                //lines[342] = lines[342].Replace(_chDate2Init[10], _chDate2Set[10]);

                lines[12] = lines[12].Replace('0', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('1', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('2', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('3', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('4', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('5', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('6', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('7', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('8', chDateNowMonth[0]);//m
                lines[12] = lines[12].Replace('9', chDateNowMonth[0]);//m

                lines[2036] = lines[2036].Replace('0', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('1', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('2', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('3', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('4', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('5', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('6', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('7', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('8', chDateNowMonth[1]);
                lines[2036] = lines[2036].Replace('9', chDateNowMonth[1]);

                //lines[424] = lines[424].Replace(_chDate2Init[13], _chDate2Set[13]);

                lines[671] = lines[671].Replace('0', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('1', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('2', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('3', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('4', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('5', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('6', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('7', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('8', chDateNowDay[0]);//d
                lines[671] = lines[671].Replace('9', chDateNowDay[0]);//d

                lines[2039] = lines[2039].Replace('0', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('1', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('2', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('3', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('4', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('5', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('6', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('7', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('8', chDateNowDay[1]);
                lines[2039] = lines[2039].Replace('9', chDateNowDay[1]);
            }
            File.WriteAllLines(_sAuthorityFile, lines);
        }


        /// <summary>
        /// 检查PMS是否已过期
        /// </summary>
        /// <param name="sDatetime1">date1-2023-11-23</param>
        /// <param name="sDatetime2">date2-2023-11-25</param>
        /// <returns></returns>
        private bool CheckIsExpire(string sDatetime1, string sDatetime2)
        {
            DateTime d1 = Convert.ToDateTime(sDatetime1.Substring(6));
            DateTime d2 = Convert.ToDateTime(sDatetime2.Substring(6));
            DateTime d3 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d1.Year, d1.Month, d1.Day));
            DateTime d4 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d2.Year, d2.Month, d2.Day));

            //检查PMS是否已过期的逻辑
            if ((d4 - d3).Days >= int.Parse(_sExpiredDays))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckRegister()
        {
            EncryptionHelper helper = new EncryptionHelper();
            string md5String = helper.GetMD5String(encryptComputer);
            return CheckRegisterData(md5String);

            //return false;
        }

        private bool CheckRegisterData(string key)
        {
            if (RegisterFileHelper.ExistRegisterInfofile() == false)//不存在RegisterInfo.key文件
            {
                _bIsRegister = false;
                return false;
            }
            else//存在RegisterInfo.key文件
            {
                //return false;

                string registerInfo = RegisterFileHelper.ReadRegisterInfoFile();
                EncryptionHelper help = new EncryptionHelper(EncryptionKeyEnum.KeyB);
                string registerData = help.DecryptString(registerInfo);
                if (key == registerData)
                {
                    _bIsRegister = true;
                    return true;
                }
                else
                {
                    _bIsRegister = false;
                    return false;
                }
            }
        }

        private void ClosePMSWithoutRegister()
        {
            //int count = 0;
            //while (count > TIME_COUNT && isRegist == false)
            //{
            //    if (isRegist == true)
            //    {
            //        return;
            //    }
            //    Thread.Sleep(1 * 1000);
            //    count--;
            //    lblRegistTimeRemaining.Text = count.ToString();
            //}

            //int count = TIME_COUNT;
            int count = 3;
            do
            {
                if (_bIsRegister == true)
                {
                    return;
                }
                Thread.Sleep(1 * 1000);
                count--;
                lblRegisterTimeRemaining.Text = count.ToString();
            } while (count > 0 && _bIsRegister == false);

            if (_bIsRegister == true)
            {
                return;
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        //this.Close();
                        Process[] p = Process.GetProcessesByName("WinPMS");
                        p[0].Kill();
                    }));
                }
            }
        }

        /// <summary>
        /// 初始化信息
        /// </summary>
        private void InitMainInfo()
        {
            FileHelper.sIniPMSDev = IniHelper.ReadIni("PMS", "PMS_Dev", "NULL", FileHelper.sIniFilePathPMS);

            FileHelper.sIniPMSUsage = IniHelper.ReadIni("PMS", "PMS_Usage", "NULL", FileHelper.sIniFilePathPMS);

            FileHelper.sIniPMSFtpUpdate = IniHelper.ReadIni("PMS", "PMS_FtpUpdate", "NULL", FileHelper.sIniFilePathPMS);

            FileHelper.sIniPwdOpr = IniHelper.ReadIni("PMS", "PMS_Opr", "NULL", FileHelper.sIniFilePathPMS);

            FileHelper.sIniPwdEncrypt = IniHelper.ReadIni("PMS", "PMS_Encrypt", "NULL", FileHelper.sIniFilePathPMS);

            FileHelper.sIniFormStartup = IniHelper.ReadIni("PMS", "Form_Startup", "NULL", FileHelper.sIniFilePathPMS);

            this.Text = "PMS";
            //获取软件版本
            if ("Debug" == FileHelper.sIniPMSUsage)
            {
                this.Text += " - V" + _frmProgressBarModel.PMSVersion + " (" + FileHelper.sIniPMSUsage + " Mode >>>> Not available for production line 不可应用于产线 >>>> config .ini first" + ")";
                this.BackColor = Color.Yellow;
            }
            else if ("CFM" == FileHelper.sIniPMSUsage)
            {
                this.Text += " - V" + _frmProgressBarModel.PMSVersion + " (" + FileHelper.sIniPMSUsage + " Mode" + ")";
                //this.BackColor = Color.Lime;
                this.BackColor = default;
            }

            if (this.Tag is FrmProgressBarModel)
            {
                _frmProgressBar = _frmProgressBarModel.FrmProgressBar;
                _frmProgressBar.Close();

                //获取登录窗体的实例
                _frmLogin = _frmProgressBarModel.FrmLoginModel.FrmLogin;

                //获取当前用户名称
                _sUserName = _frmProgressBarModel.FrmLoginModel.UserName;
            }
            else if (this.Tag is FrmLoginModel frmLoginModel)//切换操作用户登录
            {
                //获取登录窗体的实例
                _frmLogin = frmLoginModel.FrmLogin;

                //获取当前用户名称
                _sUserName = frmLoginModel.UserName;
            }

            lblUserName.Text = Environment.UserName;
            lblUName.Text = _sUserName;
            lblLoginTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //创建菜单项和工具菜单项，并添加到菜单控件和工具栏控件
            AddMenusAndToolMenus();

            //加载页面
            //CreateForm("Radar.FrmRDR2Dll", 0);
            //CreateForm("Radar.FrmRDR2SystemConfig", 0);
            string sFormStartup = FileHelper.sIniFormStartup;

            foreach (string form in sFormStartup.Split(','))
            {
                CreateForm(form.Trim(), 0);
            }

            //仅当首次启动PMS时弹出
            if (_iIsFrmFirstLoad == 1)
            {
                CreateForm("FrmAboutPMS", 1);
            }
        }


        /// <summary>
        /// 创建菜单项和工具菜单项
        /// </summary>
        private void AddMenusAndToolMenus()
        {
            //获取所有菜单和工具栏菜单
            List<MenuInfosModel> MenuInfosList = MenuInfosList = ReadMenuInfosTxt();
            //List<ToolMenuInfosModel> ToolMenuInfosList = new List<ToolMenuInfosModel>();

            PMSMenus.Items.Clear();
            PMSTools.Items.Clear();

            //添加菜单项
            AddMenuItem(MenuInfosList, null, 0);

            //添加工具菜单项
            //AddToolMenuItem(ToolMenuInfosList);
        }


        /// <summary>
        /// 读取菜单工具栏信息
        /// </summary>
        /// <returns></returns>
        private List<MenuInfosModel> ReadMenuInfosTxt()
        {
            List<MenuInfosModel> menuInfosModelList = new List<MenuInfosModel>();

            try
            {
                // 创建一个 StreamReader 的实例来读取文件 
                // using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader(@FileHelper.sMenuInfosTxtPath))
                {
                    string line;

                    // 从文件读取并显示行，直到文件的末尾 
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        if (line.StartsWith("MId") || string.IsNullOrEmpty(line))
                        {
                            continue;
                        }
                        string[] lineArr = line.Trim().Split(',');

                        MenuInfosModel menuInfosModel = new MenuInfosModel();
                        for (int i = 0; i < lineArr.Length; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    menuInfosModel.MId = int.Parse(lineArr[i].Trim());
                                    break;
                                case 1:
                                    menuInfosModel.MName = lineArr[i].Trim();
                                    break;
                                case 2:
                                    menuInfosModel.ParentId = int.Parse(lineArr[i].Trim());
                                    break;
                                case 3:
                                    menuInfosModel.ParentName = lineArr[i].Trim();
                                    break;
                                case 4:
                                    menuInfosModel.MKey = lineArr[i].Trim();
                                    break;
                                case 5:
                                    menuInfosModel.MUrl = lineArr[i].Trim();
                                    break;
                                case 6:
                                    menuInfosModel.IsTop = int.Parse(lineArr[i].Trim());
                                    break;
                                case 7:
                                    menuInfosModel.MOrder = int.Parse(lineArr[i].Trim());
                                    break;
                                case 8:
                                    menuInfosModel.IsDeleted = int.Parse(lineArr[i].Trim());
                                    break;
                                case 9:
                                    menuInfosModel.Creator = lineArr[i].Trim();
                                    break;
                                case 10:
                                    menuInfosModel.CreateTime = DateTime.Parse(lineArr[i].Trim());
                                    break;
                                case 11:
                                    menuInfosModel.MDesp = lineArr[i].Trim();
                                    break;
                                case 12:
                                    menuInfosModel.MPic = lineArr[i].Trim();
                                    break;
                                default:
                                    break;
                            }
                        }
                        menuInfosModelList.Add(menuInfosModel);

                    }
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError(ex.Message);
            }

            return menuInfosModelList;
        }


        /// <summary>
        /// 递归添加菜单项
        /// </summary>
        /// <param name="menuInfosList"></param>
        /// <param name="pMenu"></param>
        /// <param name="pId"></param>
        private void AddMenuItem(List<MenuInfosModel> menuInfosList, ToolStripMenuItem pMenu, int pId)
        {
            //获取所有子菜单列表
            var childList = menuInfosList.Where(m => m.ParentId == pId);

            foreach (var child in childList)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem
                {
                    Name = child.MId.ToString(),
                    Text = child.MName
                };//实例化一个菜单项

                //快捷键处理
                /*
                if (!string.IsNullOrEmpty(child.MKey))
                {
                    string sKey = child.MKey.ToString().Trim();//获取快捷键

                    //Alt快捷键
                    if (sKey.Length > 1 && sKey.Substring(0, 3).ToLower() == "alt")
                    {
                        mi.Text += $"(&{sKey.Substring(4)})";
                        Enum.TryParse<Keys>(sKey.Substring(4), out Keys k);
                        mi.ShortcutKeys = (Keys)(Keys.Alt | k);
                    }
                    //Ctrl快捷键
                    else if (sKey.Length > 1 && sKey.Substring(0, 4).ToLower() == "ctrl")
                    {
                        Enum.TryParse<Keys>(sKey.Substring(5), out Keys k);
                        mi.ShortcutKeys = (Keys)(Keys.Control | k);
                    }
                    //Shift快捷键
                    else if (sKey.Length > 1 && sKey.Substring(0, 5).ToLower() == "shift")
                    {
                        Enum.TryParse<Keys>(sKey.Substring(6), out Keys k);
                        mi.ShortcutKeys = (Keys)(Keys.Shift | k);
                    }
                }
                */

                //设置菜单栏图片
                if (!string.IsNullOrEmpty(child.MPic) && "NULL" != child.MPic)
                {
                    mi.Image = Image.FromFile(Application.StartupPath + "\\" + child.MPic);
                }

                //菜单项关联页面
                //if (!string.IsNullOrEmpty(child.MUrl))
                //{
                mi.Tag = child;
                //}

                //菜单响应事件注册(先考虑有关联页面的，没有子菜单的)
                if (menuInfosList.Where(m => m.ParentId == child.MId).ToList().Count == 0)
                {
                    mi.Click += Mi_Click;
                }

                if (null != pMenu)
                {
                    pMenu.DropDownItems.Add(mi);
                }
                else
                {
                    PMSMenus.Items.Add(mi);
                }

                AddMenuItem(menuInfosList, mi, child.MId);//为当前菜单项添加它的子菜单
            }
        }


        /// <summary>
        /// 菜单项的响应处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mi_Click(object sender, EventArgs e)
        {
            //获取单击的菜单项，mi.Tag是一条菜单项数据
            ToolStripMenuItem mi = sender as ToolStripMenuItem;

            if (null != mi.Tag)
            {
                MenuInfosModel menuInfosModel = mi.Tag as MenuInfosModel;
                string mUrl = menuInfosModel.MUrl;//获取菜单的关联页面
                string mDesp = menuInfosModel.MDesp;//获取菜单的描述信息

                if (mUrl.StartsWith("Debug.Frm"))
                {
                    if (FrmUtility.CheckOpenForm(mUrl))
                    {
                        MsgBoxHelper.MsgBoxError(mUrl + "\n" + "Already Opened!");
                        //FrmUtility.ShowOpenForm(mUrl);
                        int iTabPageIndex = -1;
                        foreach (TabPage tabPage in tcPages.TabPages)
                        {
                            iTabPageIndex++;
                            if (tabPage.Text == mUrl)
                            {
                                tcPages.SelectedTab = tabPage;
                                break;
                            }
                        }
                        return;
                    }
                    FrmAdminAuthority f = new FrmAdminAuthority();

                    f.FuncFormLabel = new Func<string>(() =>
                    {
                        return "Please input the admin account!";
                    });

                    f.ActAccountValid += new Action(() =>
                    {
                        CreateForm(mUrl, menuInfosModel.IsTop);
                    });

                    f.FuncMsgShowAccountEmpty = new Func<string>(() =>
                    {
                        return "Account can't be empty!";
                    });

                    f.FuncMsgShowAccountNotValid = new Func<string>(() =>
                    {
                        return "Account not valid!";
                    });

                    f.ActAccountNotValid += new Action(() =>
                    {
                        return;
                    });

                    f.ActFormClosing += new Action(() =>
                    {
                        return;
                    });

                    f.ShowDialog();
                }
                else if (!string.IsNullOrEmpty(mUrl) && "NULL" != mUrl && "NULL" == mDesp)
                {
                    CreateForm(mUrl, menuInfosModel.IsTop);
                }
                else
                {
                    //特殊响应处理
                    if (menuInfosModel.MDesp == MenuInfosDesp.SwitchUser.ToString())
                    {
                        if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Are you sure to switch user？", "Switch user", 2))
                        {
                            //更换操作员
                            this.Hide();
                            _iIsFrmFirstLoad = 2;
                            _frmLogin.Show();
                        }
                    }
                    else if (menuInfosModel.MDesp == MenuInfosDesp.IniConfiguration.ToString())
                    {
                        if ("admin" == _sUserName)
                        {
                            //string sIniDir = Path.GetFullPath(@"..\..");
                            //sIniDir = string.Format(@"{0}\Config\PMS.ini", sIniDir);

                            //string sIniDir = Path.Combine(FileHelper.sAppStartPath, @"Config\PMS.ini");
                            string sIniDir = "";
                            switch (FileHelper.sIniPMSUsage)
                            {
                                case "Debug":
                                    //Process.Start("Explorer.exe", FileHelper.sIniFilePathDebug);
                                    sIniDir = FileHelper.sIniFilePathDebug;
                                    break;
                                case "CFM":
                                    //Process.Start("Explorer.exe", FileHelper.sIniFilePathCFM);
                                    sIniDir = FileHelper.sIniFilePathCFM;
                                    break;
                                default:
                                    break;
                            }

                            MsgBoxHelper.MsgBoxShow(".ini file should be edited under ANSI Encoding!!!", "ini configuration");
                            Process.Start("Explorer.exe", sIniDir);
                        }
                        else if ("opr" == _sUserName)
                        {
                            FrmAdminAuthority f = new FrmAdminAuthority();

                            f.FuncFormLabel = new Func<string>(() =>
                            {
                                return "Please input the admin account!";
                            });

                            f.ActAccountValid += new Action(() =>
                            {
                                //string sIniDir = Path.Combine(FileHelper.sAppStartPath, @"Config\PMS.ini");
                                //MsgBoxHelper.MsgBoxShow(".ini file should be edited under ANSI Encoding!!!", "ini configuration");
                                //Process.Start("Explorer.exe", sIniDir);

                                //MessageBox.Show(FileHelper.sIniPMSUsage);
                                //MessageBox.Show(FileHelper.sIniFilePathDebug);
                                //MessageBox.Show(FileHelper.sIniFilePathCFM);

                                string sIniDir = "";
                                switch (FileHelper.sIniPMSUsage)
                                {
                                    case "Debug":
                                        //Process.Start("Explorer.exe", FileHelper.sIniFilePathDebug);
                                        sIniDir = FileHelper.sIniFilePathDebug;
                                        break;
                                    case "CFM":
                                        //Process.Start("Explorer.exe", FileHelper.sIniFilePathCFM);
                                        sIniDir = FileHelper.sIniFilePathCFM;
                                        break;
                                    default:
                                        break;
                                }

                                MsgBoxHelper.MsgBoxShow(".ini file should be edited under ANSI Encoding!!!", "ini configuration");
                                Process.Start("Explorer.exe", sIniDir);
                            });

                            f.FuncMsgShowAccountEmpty = new Func<string>(() =>
                            {
                                return "Account can't be empty!";
                            });

                            f.FuncMsgShowAccountNotValid = new Func<string>(() =>
                            {
                                return "Account not valid!";
                            });

                            f.ActAccountNotValid += new Action(() =>
                            {
                                return;
                            });

                            f.ActFormClosing += new Action(() =>
                            {
                                return;
                            });

                            f.ShowDialog();
                        }
                        else
                        {
                            MsgBoxHelper.MsgBoxError("Config not allowed！\nPlease login as Admin account！");
                            return;
                        }
                    }
                    else if (menuInfosModel.MDesp == MenuInfosDesp.Debug.ToString())
                    {
                        MsgBoxHelper.MsgBoxError("NA!");
                    }
                    else if (menuInfosModel.MDesp == MenuInfosDesp.Internal.ToString())
                    {
                        FrmAdminAuthority f = new FrmAdminAuthority();

                        f.FuncFormLabel = new Func<string>(() =>
                        {
                            return "Please input the admin account!";
                        });

                        f.ActAccountValidBySAdmin += new Action(() =>
                        {
                            CreateForm(mUrl, menuInfosModel.IsTop);
                        });

                        f.FuncMsgShowAccountEmpty = new Func<string>(() =>
                        {
                            return "Account can't be empty!";
                        });

                        f.FuncMsgShowAccountNotValid = new Func<string>(() =>
                        {
                            return "Account not valid!";
                        });

                        f.ActAccountNotValid += new Action(() =>
                        {
                            return;
                        });

                        f.ActFormClosing += new Action(() =>
                        {
                            return;
                        });

                        f.ShowDialog();
                    }
                }
            }
        }


        /// <summary>
        /// 实例化窗体页面
        /// </summary>
        /// <param name="url"></param>
        /// <param name="isTop"></param>
        private void CreateForm(string url, int isTop)
        {
            //url一般存储为: Xxx.FrmXxx，url.Substring(url.LastIndexOf(".") + 1)表示获取url中的窗体名称
            string strFrmName = url.Substring(url.LastIndexOf(".") + 1);
            //bool blnIsFrmInTabPage = false;//定义窗体是否在选项卡中的标识值

            //判断窗体是否已经打开?
            //如果窗体已经打开
            //  1. 循环遍历选项卡中的所有页，判断如果页名称等于窗体名称，则设置当前窗体为当前页
            //  2. 如果选项卡中没有当前窗体，说明当前这个窗体是从选项卡中被移除了，则重新添加到选项卡中
            //否则创建新的窗体并打开
            if (FrmUtility.CheckOpenForm(strFrmName))
            {
                foreach (TabPage tabPage in tcPages.TabPages)
                {
                    if (tabPage.Name == strFrmName)
                    {
                        tcPages.SelectedTab = tabPage;
                        //blnIsFrmInTabPage = true;//窗体在选项卡中
                        break;
                    }
                }

                //如果窗体不在选项卡中，则重新添加到选项卡中

            }
            else
            {
                if (!string.IsNullOrEmpty(url) && "NULL" != url)
                {
                    //获取程序集名称
                    string assemblyName = this.GetType().Assembly.GetName().Name;
                    ObjectHandle objHandle = Activator.CreateInstance(assemblyName, assemblyName + "." + url);
                    Form frm = (Form)objHandle.Unwrap();

                    //窗体页面传值
                    frm.Tag = _frmProgressBarModel;

                    ShowFrm(isTop, frm);
                }
            }
        }


        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="intIsTop"></param>
        /// <param name="f"></param>
        private void ShowFrm(int intIsTop, Form f)
        {
            if (intIsTop == 0)
            {
                //内嵌到选项卡
                tcPages.AddTabFormPage(f);
            }
            else
            {
                f.StartPosition = FormStartPosition.CenterScreen;
                f.WindowState = FormWindowState.Normal;
                f.ShowDialog();//窗体顶级显示
            }
        }


        /// <summary>
        /// 特殊菜单项说明
        /// </summary>
        private enum MenuInfosDesp
        {
            ExitSystem = 1,
            SwitchUser = 2,
            ModifyPwd = 3,
            RefreshMenu = 4,
            IniConfiguration = 5,
            Debug = 6,
            Internal = 7
        }


        #endregion

    }
}
