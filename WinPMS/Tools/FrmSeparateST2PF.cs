using PMS.COMMON;
using PMS.COMMON.Helper;
using PMS.MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinPMS.FModels;

namespace WinPMS.Tools
{
    public partial class FrmSeparateST2PF : Form
    {
        public FrmSeparateST2PF()
        {
            InitializeComponent();
        }

        private string _sLogFolderPath = "";
        private string _sLogPassFolderPath = "";
        private string _sLogFailFolderPath = "";
        private string _sLogPassFormat = "_P_";
        private string _sLogFailFormat = "_F_";
        private string _sLogFileFilter = ".txt";
        private List<string> _sLogTarget = new List<string>();//Log目标源
        private List<string> _sLogPassList = new List<string>();
        private List<string> _sLogFailList = new List<string>();


        #region 事件
        private void FrmFileZilla_Load(object sender, EventArgs e)
        {
            btn_Fetching.Enabled = false;
        }


        /// <summary>
        /// 加载Log文件的目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Load_Log_Folder_Click(object sender, EventArgs e)
        {
            MsgBoxHelper.MsgBoxShow("Make sure the log format should match as: " + "\n\n" + "xxxx_P_xxxx.txt" + "\n\n" + "xxxx_F_xxxx.txt", "Info");

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择S/T Log文件的目录...";

            //DialogResult dialogResult = dialog.ShowDialog();
            //if (dialogResult == DialogResult.Cancel)
            //{
            //    return;
            //}

            if (groupBox2.Text == "Log Dest")
            {
                DialogResult dialogResult = dialog.ShowDialog();
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            else
            {
                dialog.SelectedPath = groupBox2.Text.Substring("Log Dest - ".Length);

                DialogResult dialogResult = dialog.ShowDialog();
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            txtbox_Log.Text = "";
            txtbox_LogPass.Text = "";
            txtbox_LogFail.Text = "";
            btn_Load_Log_Folder.Enabled = false;
            btn_Fetching.Enabled = false;

            _sLogFolderPath = dialog.SelectedPath.Trim();//Log目标源的目录
            //_sLogFolderPath = @"D:\_VNE_Work\CSharp\_Test_Seperate_To_PF";
            _sLogPassFolderPath = _sLogFolderPath + @"\" + "log_pass";
            _sLogFailFolderPath = _sLogFolderPath + @"\" + "log_fail";

            List<string> sFileAllList = new List<string>();

            groupBox2.Text = "Log Dest";
            groupBox2.Text += " - " + _sLogFolderPath;

            //删除已存在的log pass目录
            if (Directory.Exists(_sLogPassFolderPath))
            {
                Directory.Delete(_sLogPassFolderPath, true);
            }

            //删除已存在的log fail目录
            if (Directory.Exists(_sLogFailFolderPath))
            {
                Directory.Delete(_sLogFailFolderPath, true);
            }

            await Task.Run(() =>
            {
                _sLogTarget.Clear();

                try
                {
                    //递归循环遍历指定目录下的所有文件，并添加到Listbox
                    UtilityHelper.RecursionDir(sFileAllList, new DirectoryInfo(_sLogFolderPath), true);

                    bool bScroll = false;
                    string sFileExtension = "";
                    //将List中的所有文件添加到ListBox
                    foreach (string fileFullName in sFileAllList)
                    {
                        sFileExtension = Path.GetExtension(fileFullName);//获取文件的后缀

                        if (listBox1.InvokeRequired)
                        {
                            listBox1.Invoke(new Action(() =>
                            {
                                if (!string.IsNullOrEmpty(sFileExtension) && _sLogFileFilter.ToUpper().Contains(sFileExtension.ToUpper()))
                                {
                                    listBox1.Items.Add(fileFullName);
                                }
                                
                                //ListBox滚动条定位到最后一条
                                if (listBox1.TopIndex == listBox1.Items.Count - (listBox1.Height / listBox1.ItemHeight))
                                    bScroll = true;
                                if (bScroll)
                                    listBox1.TopIndex = listBox1.Items.Count - (listBox1.Height / listBox1.ItemHeight);
                            }));
                        }

                        if (txtbox_Log.InvokeRequired)
                        {
                            txtbox_Log.Invoke(new Action(() =>
                            {
                                txtbox_Log.Text = listBox1.Items.Count.ToString();
                            }));
                        }
                        _sLogTarget.Add(fileFullName);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return true;
            });

            txtbox_Log.BackColor = Color.GreenYellow;
            btn_Load_Log_Folder.Enabled = true;
            btn_Fetching.Enabled = true;

            //MessageBox.Show("Log: " + listBox2.Items.Count.ToString());
        }


        /// <summary>
        /// 从Log目录中抓取匹配到的对应SN的Log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Fetching_Click(object sender, EventArgs e)
        {
            try
            {
                //创建Log Pass目录
                if (!Directory.Exists(_sLogPassFolderPath))
                {
                    Directory.CreateDirectory(_sLogPassFolderPath);
                }
                else
                {
                    Directory.Delete(_sLogPassFolderPath, true);
                    Directory.CreateDirectory(_sLogPassFolderPath);
                }

                //创建Log Fail目录
                if (!Directory.Exists(_sLogFailFolderPath))
                {
                    Directory.CreateDirectory(_sLogFailFolderPath);
                }
                else
                {
                    Directory.Delete(_sLogFailFolderPath, true);
                    Directory.CreateDirectory(_sLogFailFolderPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            listBox2.Items.Clear();
            listBox3.Items.Clear();
            txtbox_LogPass.Text = "";
            txtbox_LogFail.Text = "";
            btn_Fetching.Enabled = false;
            groupBox3.Text = "Log Pass";
            groupBox3.Text += " - " + _sLogPassFolderPath;
            groupBox4.Text = "Log Fail";
            groupBox4.Text += " - " + _sLogFailFolderPath;

            await Task.Run(() =>
            {
                DoFetching2();
            });

            txtbox_LogPass.BackColor = Color.GreenYellow;
            txtbox_LogFail.BackColor = Color.GreenYellow;
            btn_Fetching.Enabled = true;
            btn_OpenLogPass.Enabled = true;
            btn_OpenLogFail.Enabled = true;
        }


        /// <summary>
        /// 打开Log Pass文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenResultLogPass_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_sLogPassFolderPath))
                {
                    MessageBox.Show("请先做Fetching！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //判断Log Pass目录是否存在，如果不存在，提示先做Fetching
                if (!Directory.Exists(_sLogPassFolderPath))
                {
                    MessageBox.Show("Result目录不存在，请先做Fetching！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btn_OpenLogPass.Enabled = false;
                    btn_Fetching.Focus();
                    return;
                }
                else
                {
                    Process.Start("Explorer.exe", _sLogPassFolderPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 打开Log Fail文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenResultLogFail_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_sLogFailFolderPath))
                {
                    MessageBox.Show("请先做Fetching！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //判断Log Fail目录是否存在，如果不存在，提示先做Fetching
                if (!Directory.Exists(_sLogFailFolderPath))
                {
                    MessageBox.Show("Result目录不存在，请先做Fetching！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btn_OpenLogFail.Enabled = false;
                    btn_Fetching.Focus();
                    return;
                }
                else
                {
                    Process.Start("Explorer.exe", _sLogFailFolderPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void tsBtnHelp_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Close" + " ？", "Info", 2))
            {
                this.CloseForm();
            }
        }
        #endregion



        #region 方法
        /// <summary>
        /// Fetching Log
        /// </summary>
        private void DoFetching2()
        {
            bool bScroll_1 = false;
            bool bScroll_2 = false;

            _sLogPassList.Clear();//做Fetching前，清空LogPass列表
            _sLogPassList.Clear();//做Fetching前，清空LogFail列表

            for (int i = 0; i < _sLogTarget.Count; i++)
            {
                string sLog = _sLogTarget[i];//C:\..\6815323000000014960000_2021_09_24_17_49_57_P_measData.csv.txt
                string sLogName = sLog.Substring(sLog.LastIndexOf('\\') + 1);//6815323000000014960000_2021_09_24_17_49_57_P_measData.csv.txt

                if (sLog.Contains(_sLogPassFormat))
                {
                    _sLogPassList.Add(sLog);

                    if (listBox2.InvokeRequired)
                    {
                        listBox2.Invoke(new Action(() =>
                        {
                            listBox2.Items.Add(_sLogTarget[i]);

                            if (listBox2.TopIndex == listBox2.Items.Count - (listBox2.Height / listBox2.ItemHeight))
                                bScroll_1 = true;
                            if (bScroll_1)
                                listBox2.TopIndex = listBox2.Items.Count - (listBox2.Height / listBox2.ItemHeight);
                        }));
                    }

                    if (txtbox_LogPass.InvokeRequired)
                    {
                        txtbox_LogPass.Invoke(new Action(() =>
                        {
                            txtbox_LogPass.Text = listBox2.Items.Count.ToString();
                        }));
                    }

                    File.Copy(_sLogTarget[i], Path.Combine(_sLogPassFolderPath, sLogName), true);
                }
                else if(sLog.Contains(_sLogFailFormat))
                {
                    _sLogFailList.Add(sLog);

                    if (listBox3.InvokeRequired)
                    {
                        listBox3.Invoke(new Action(() =>
                        {
                            listBox3.Items.Add(_sLogTarget[i]);

                            if (listBox3.TopIndex == listBox3.Items.Count - (listBox3.Height / listBox3.ItemHeight))
                                bScroll_2 = true;
                            if (bScroll_2)
                                listBox3.TopIndex = listBox3.Items.Count - (listBox3.Height / listBox3.ItemHeight);
                        }));
                    }

                    if (txtbox_LogFail.InvokeRequired)
                    {
                        txtbox_LogFail.Invoke(new Action(() =>
                        {
                            txtbox_LogFail.Text = listBox3.Items.Count.ToString();
                        }));
                    }

                    File.Copy(_sLogTarget[i], Path.Combine(_sLogFailFolderPath, sLogName), true);
                }
                else
                {

                }
            }
        }
    }
    #endregion
}
