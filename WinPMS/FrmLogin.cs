using PMS.COMMON.Helper;
using PMS.COMMON.Encrypt;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WinPMS.FModels;

namespace WinPMS
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
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
            if(cbUName.SelectedIndex == 0)
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
                    sIniPwd = FileHelper.sIniPwdOpr;
                }
                else if(cbUName.SelectedIndex == 1)//admin
                {
                    sEncryptPwd = MD5Encrypt.Encrypt(sUserPwd);
                    sIniPwd = FileHelper.sIniPwdEncrypt;
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
            else
            {
                if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Are you sure to exit？", "Exit", 2))
                {
                    Application.ExitThread();
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
        #endregion

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
