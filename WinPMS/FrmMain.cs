using PMS.COMMON.Helper;
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
using System.Windows.Forms;
using WinPMS.Debug;
using WinPMS.FModels;

namespace WinPMS
{
    public partial class FrmMain : Form
    {
        //屏蔽右上角的X关闭按钮
        [DllImport("USER32.DLL")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, UInt32 bRevert);

        [DllImport("USER32.DLL")]
        private static extern UInt32 RemoveMenu(IntPtr hMenu, UInt32 nPosition, UInt32 wFlags);
        private const UInt32 SC_CLOSE = 0x0000F060;
        private const UInt32 MF_BYCOMMAND = 0x00000000;

        public FrmMain()
        {
            InitializeComponent();

            //禁用关闭按钮
            //IntPtr hMenu = GetSystemMenu(this.Handle, 0);
            //RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND);
        }

        private FrmLogin _frmLogin = null;
        private FrmProgressBar _frmProgressBar = null;
        private FrmProgressBarModel _frmProgressBarModel = null;

        private string _sUserName = "";//当前登录用户信息

        private int _iIsFrmFirstLoad = 0;//是否是第一次加载


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
            if (_sUserName == "admin" || Environment.UserName.ToUpper() == "JASON.CAI")
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
        #endregion



        #region 方法
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

        private void btn_Test_Click(object sender, EventArgs e)
        {
            ShowFrm(0, new FrmDebugModeWarning());
        }
    }
}
