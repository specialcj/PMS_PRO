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
            else if(_bChangeLanguage == false)
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
