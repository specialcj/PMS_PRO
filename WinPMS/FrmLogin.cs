using PMS.COMMON.Helper;
using PMS.COMMON.Encrypt;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WinPMS.FModels;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Text;

namespace WinPMS
{
    public partial class FrmLogin : Form
    {
        private bool _bChangeLanguage;
        private string _sLanguageConfigPath = Path.Combine(FileHelper.sExeFolderPath, @"Config\LanguageConfig.txt");//定义LanguageConfig目录的路径
        private string _sAuthorityFile = FileHelper.sExeFolderPath + @"\dll\" + FileHelper.PMS_AUTHORITY;

        public static LanguageType Language { get; set; }

        public static string LanguageName
        {
            get
            {
                switch (Language)
                {
                    case LanguageType.ZH_HANS:
                        return "zh-Hans";
                    case LanguageType.EN_US:
                        return "en-US";
                    default:
                        return "zh-Hans";
                }
            }
        }

        public FrmLogin()
        {
            if (!File.Exists(_sLanguageConfigPath))
            {
                Language = LanguageType.ZH_HANS;
            }
            else
            {
                StreamReader sr = new StreamReader(_sLanguageConfigPath, Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.ToString();
                    if (line == "zh-Hans")
                    {
                        Language = LanguageType.ZH_HANS;
                    }
                    else if (line == "en-US")
                    {
                        Language = LanguageType.EN_US;
                    }
                    else
                    {
                        Language = LanguageType.ZH_HANS;
                    }
                }

                sr.Close();
            }

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageName);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;

            InitializeComponent();
        }

        private bool _bIsLogin = false;//是否已登录
        private int _iIsFrmFirstLoad = 0;//是否是第一次加载
        private string _sUPwdOpr = "opr";

        #region 无边框时，拖动改变窗体位置
        private Point fPoint;
        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            fPoint = new Point(e.X, e.Y);
        }

        private void FrmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - fPoint.X, this.Location.Y + e.Y - fPoint.Y);
            }
        }
        #endregion


        #region 事件
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            btnCN.Enabled = false;
            btnEN.Enabled = false;

            //获取已启动进程名
            string sProcessName = Process.GetCurrentProcess().ProcessName;

            //获取版本号
            //string sProductVersion = Application.ProductVersion;

            //检查进程是否已经启动，已经启动则显示报错信息退出程序。
            if (Process.GetProcessesByName(sProcessName).Length > 1)
            {

                MessageBox.Show("PMS客户端已经运行！\n请勿重复打开！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                //Application.Exit();
                Application.ExitThread();
                return;
            }

            _iIsFrmFirstLoad = 1;

            cbUName.SelectedIndex = 0;
            if (cbUName.SelectedIndex == 0)
            {
                txtUPwd.Text = _sUPwdOpr;
            }
        }


        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //接收信息
            string sUserName = cbUName.Text;
            string sUserPwd = txtUPwd.Text.Trim();

            //判断是否为空
            if (string.IsNullOrEmpty(sUserName))
            {
                MsgBoxHelper.MsgBoxError("Account can't be empty！");
                cbUName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(sUserPwd))
            {
                MsgBoxHelper.MsgBoxError("Password can't be empty！");
                txtUPwd.Focus();
                return;
            }

            Action act = () =>
            {
                //首次打开软件时，写入时间
                
                try
                {
                    string[] lines = File.ReadAllLines(_sAuthorityFile);
                    string sDate1Read =
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

                    string sDate2Read =
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

                    /*
                    int iLineIndex = -1;
                    int iSubStrIndex = -1;
                    string sSearch = "0";

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains(sSearch))
                        {
                            iLineIndex = i;

                            for (int j = 0; j < lines[i].Length; j++)
                            {
                                string s = lines[i].Substring(j, 1);
                                if (s == sSearch)
                                {
                                    iSubStrIndex = j;
                                }
                            }
                            MessageBox.Show(iLineIndex + ", " + iSubStrIndex);
                        }
                    }
                    */

                    char[] chDate1Init = "x0001-y001-m1-d1".ToCharArray();
                    char[] chDate1Set = "date1-yyyy-mm-dd".ToCharArray();
                    string sDateNow = DateTime.Now.ToString("yyyy-MM-dd");
                    char[] chDateNowYear = sDateNow.Substring(0, 4).ToCharArray();
                    char[] chDateNowMonth = sDateNow.Substring(5, 2).ToCharArray();
                    char[] chDateNowDay = sDateNow.Substring(8, 2).ToCharArray();
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (!sDate1Read.StartsWith("date1"))
                        {
                            //设置Date1
                            lines[3019] = lines[3019].Replace(chDate1Init[0], chDate1Set[0]);
                            lines[131] = lines[131].Replace(chDate1Init[1], chDate1Set[1]);
                            lines[85] = lines[85].Replace(chDate1Init[2], chDate1Set[2]);
                            lines[1358] = lines[1358].Replace(chDate1Init[3], chDate1Set[3]);
                            lines[29] = lines[29].Replace(chDate1Init[4], chDate1Set[4]);
                            lines[287] = lines[287].Replace(chDate1Init[5], chDate1Set[5]);
                            lines[110] = lines[110].Replace(chDate1Init[6], chDateNowYear[0]);//y
                            lines[4] = lines[4].Replace(chDate1Init[7], chDateNowYear[1]);
                            lines[119] = lines[119].Replace(chDate1Init[8], chDateNowYear[2]);
                            lines[7] = lines[7].Replace(chDate1Init[9], chDateNowYear[3]);
                            lines[299] = lines[299].Replace(chDate1Init[10], chDate1Set[10]);
                            lines[6] = lines[6].Replace(chDate1Init[11], chDateNowMonth[0]);//m
                            lines[2020] = lines[2020].Replace(chDate1Init[12], chDateNowMonth[1]);
                            lines[308] = lines[308].Replace(chDate1Init[13], chDate1Set[13]);
                            lines[8] = lines[8].Replace(chDate1Init[14], chDateNowDay[0]);//d
                            lines[2035] = lines[2035].Replace(chDate1Init[15], chDateNowDay[1]);
                            break;
                        }
                    }
                    File.WriteAllLines(_sAuthorityFile, lines);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                //MD5加密的密码
                string sEncryptPwd = "";

                //ini中的密码
                string sIniPwd = "";

                if (cbUName.SelectedIndex == 0)//opr
                {
                    sEncryptPwd = sUserPwd;
                    //sIniPwd = FileHelper.sIniPwdOpr;
                    sIniPwd = "opr";
                }
                else if (cbUName.SelectedIndex == 1)//admin
                {
                    sEncryptPwd = MD5Encrypt.Encrypt(sUserPwd);
                    //sIniPwd = FileHelper.sIniPwdEncrypt;
                    sIniPwd = "21232f297a57a5a743894a0e4a801fc3";
                }

                //判断结果
                if (sEncryptPwd != sIniPwd)
                {
                    MsgBoxHelper.MsgBoxError("Account or Password is wrong！");
                    txtUPwd.Clear();
                    return;
                }
                else
                {
                    //转到主页面
                    if (!FrmUtility.CheckOpenForm("FrmMain"))//主页面不存在(首次登录用户时)
                    {
                        FrmProgressBar frmProgressBar = new FrmProgressBar
                        {
                            Tag = new FrmLoginModel()
                            {
                                FrmLogin = this,
                                UserName = sUserName,
                            }
                        };
                        frmProgressBar.Show();
                    }
                    else//主页面已存在(更换登录用户时)
                    {
                        //FormUtility.ShowOpenForm("FrmMain");
                        foreach (Form frm in Application.OpenForms)
                        {
                            if (frm.Name == "FrmMain")
                            {
                                frm.Tag = new FrmLoginModel()
                                {
                                    FrmLogin = this,
                                    UserName = sUserName,
                                };

                                frm.Show();
                                break;
                            }
                        }
                    }
                    _iIsFrmFirstLoad = 2;
                    _bIsLogin = true;
                    this.Hide();
                }
            };
            act.TryCatchInvoke("Exception in Login！");
        }


        private void cbUName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUName.SelectedIndex == 0)//opr
            {
                txtUPwd.Text = _sUPwdOpr;
            }
            else
            {
                txtUPwd.Text = "";
            }
        }

        /// <summary>
        /// 窗体Visible属性改变时触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_VisibleChanged(object sender, EventArgs e)
        {
            if (_iIsFrmFirstLoad == 2)//登录/切换用户登录时
            {
                if (cbUName.SelectedIndex != 0)//opr
                {
                    txtUPwd.Clear();
                }

                _iIsFrmFirstLoad = 1;
            }
        }


        /// <summary>
        /// 中文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCN_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("你确定要切换成中文吗？\n\n点击确定，应用程序会自动重启！", "提示", 2))
            {
                _bChangeLanguage = true;

                Language = LanguageType.ZH_HANS;
                byte[] data = Encoding.Default.GetBytes(LanguageName);

                FileStream fs = new FileStream(_sLanguageConfigPath, FileMode.Create);
                fs.Write(data, 0, data.Length);

                //清空缓冲区，关闭流
                fs.Flush();
                fs.Close();
                Application.Restart();
            }
        }


        /// <summary>
        /// 英语
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEN_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Are you sure to change the language？\n\nClick ok and the application will restart!", "Info", 2))
            {
                _bChangeLanguage = true;

                Language = LanguageType.EN_US;
                byte[] data = Encoding.Default.GetBytes(LanguageName);

                FileStream fs = new FileStream(_sLanguageConfigPath, FileMode.Create);
                fs.Write(data, 0, data.Length);

                //清空缓冲区，关闭流
                fs.Flush();
                fs.Close();
                Application.Restart();
            }
        }


        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            //MsgBoxHelper.MsgBoxShow("_bIsLogin", _bIsLogin.ToString());

            //if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("退出系统", "确定退出系统吗？", 2))
            //{
            //    Application.ExitThread();
            //}


            if (_bIsLogin)
            {
                MsgBoxHelper.MsgBoxError("Exit not allowed！\nPlease login as admin！");
            }
            else if (_bChangeLanguage == false)
            {
                if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Are you sure to exit？", "Exit", 2))
                {
                    Application.ExitThread();
                }
                else
                {
                    return;
                }
            }
            else if (_bChangeLanguage == true)
            {
                if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Change Language？", "Exit", 2))
                {
                    Application.ExitThread();
                }
                else
                {
                    return;
                }
            }
        }


        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bIsLogin)
            {
                MsgBoxHelper.MsgBoxError("Exit not allowed！\nPlease login as admin！");
                e.Cancel = true;
            }
            else
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
        }


        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        #endregion
    }


    /// <summary>
    /// 各种语言的枚举
    /// </summary>
    public enum LanguageType : int
    {
        /// <summary>
        /// 中文-简体
        /// </summary>
        ZH_HANS = 0,

        /// <summary>
        /// 英语-美国
        /// </summary>
        EN_US = 1
    }
}
