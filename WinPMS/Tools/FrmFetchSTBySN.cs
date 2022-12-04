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
    public partial class FrmFetchSTBySN : Form
    {
        public FrmFetchSTBySN()
        {
            InitializeComponent();
        }

        private string _sLogFolderPath = "";
        private string _sLogFindFolderPath = "";
        private string _sLogNotFindFolderPath = "";
        private List<string> _sSNSource = new List<string>();//SN数据源
        private List<string> _sLogTarget = new List<string>();//Log目标源

        #region 事件
        private void FrmFileZilla_Load(object sender, EventArgs e)
        {
            btn_Load_Log_Folder.Enabled = false;
            btn_Fetching.Enabled = false;
        }


        /// <summary>
        /// 加载SN.txt数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_LoadSN_Click(object sender, EventArgs e)
        {
            string sFileName = "";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.Title = "Load SN";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != "")
                {
                    sFileName = openFileDialog1.FileName;
                }
            }
            else
            {
                return;
            }

            listBox1.Items.Clear();
            txtbox_LoadSN.Text = "";
            txtbox_LoadSN.BackColor = default;
            btn_LoadSN.Enabled = false;
            btn_Load_Log_Folder.Enabled = false;
            groupBox1.Text = ".txt Source";
            groupBox1.Text += " - " + sFileName;

            await Task.Run(() =>
            {
                DoLoadTxt(sFileName);
            });

            txtbox_LoadSN.BackColor = Color.GreenYellow;
            btn_LoadSN.Enabled = true;
            btn_Load_Log_Folder.Enabled = true;
            //MessageBox.Show("SN: " + listBox1.Items.Count.ToString());
        }


        /// <summary>
        /// Right Click -> Open .txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSMenuOpenTxt_Click(object sender, EventArgs e)
        {
            if (groupBox1.Text == ".txt Source")
            {
                MsgBoxHelper.MsgBoxError("please load .txt first!");
                btn_LoadSN.Focus();
                return;
            }

            string sTxt = groupBox1.Text.Substring(".txt Source - ".Length);

            Process.Start(sTxt);
        }


        /// <summary>
        /// Right Click -> Reload .txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void tSMenuReloadTxt_Click(object sender, EventArgs e)
        {
            if (groupBox1.Text == ".txt Source")
            {
                MsgBoxHelper.MsgBoxError("please load .txt first!");
                btn_LoadSN.Focus();
                return;
            }

            string sTxt = groupBox1.Text.Substring(".txt Source - ".Length);

            listBox1.Items.Clear();
            txtbox_LoadSN.Text = "";
            txtbox_LoadSN.BackColor = default;
            btn_LoadSN.Enabled = false;
            btn_Load_Log_Folder.Enabled = false;

            await Task.Run(() =>
            {
                DoLoadTxt(sTxt);
            });

            txtbox_LoadSN.BackColor = Color.GreenYellow;
            btn_LoadSN.Enabled = true;
            btn_Load_Log_Folder.Enabled = true;
            //MessageBox.Show("SN: " + listBox1.Items.Count.ToString());
        }


        /// <summary>
        /// 加载Log文件的目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Load_Log_Folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "please select the folder of ST Log...";

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

            //_sLogFolderPath = @"C:\_VNE_Work\_Log\RDR2\ST\GAC A11 conffin_Delete_1";
            _sLogFolderPath = dialog.SelectedPath.Trim();//Log目标源的目录

            _sLogFindFolderPath = _sLogFolderPath + @"\" + "log_find";
            _sLogNotFindFolderPath = _sLogFolderPath + @"\" + "log_not_find_SN";

            groupBox2.Text = "Log Dest";
            groupBox2.Text += " - " + _sLogFolderPath;

            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            txtbox_Log.Text = "";
            txtbox_LogFind.Text = "";
            txtbox_LogNotFind.Text = "";
            btn_Load_Log_Folder.Enabled = false;
            btn_Fetching.Enabled = false;

            List<string> sFileAllList = new List<string>();

            //删除已存在的log find目录
            if (Directory.Exists(_sLogFindFolderPath))
            {
                Directory.Delete(_sLogFindFolderPath, true);
            }

            //删除已存在的log not find目录
            if (Directory.Exists(_sLogNotFindFolderPath))
            {
                Directory.Delete(_sLogNotFindFolderPath, true);
            }

            await Task.Run(() =>
            {
                _sLogTarget.Clear();

                try
                {
                    //递归循环遍历指定目录下的所有文件，并添加到Listbox
                    UtilityHelper.RecursionDir(sFileAllList, new DirectoryInfo(_sLogFolderPath), true);

                    bool bScroll = false;
                    //将List中的所有文件添加到ListBox
                    foreach (string fileFullName in sFileAllList)
                    {
                        if (listBox2.InvokeRequired)
                        {
                            listBox2.Invoke(new Action(() =>
                            {
                                listBox2.Items.Add(fileFullName);

                                //ListBox滚动条定位到最后一条
                                if (listBox2.TopIndex == listBox2.Items.Count - (listBox2.Height / listBox2.ItemHeight))
                                    bScroll = true;
                                if (bScroll)
                                    listBox2.TopIndex = listBox2.Items.Count - (listBox2.Height / listBox2.ItemHeight);
                            }));
                        }

                        if (txtbox_Log.InvokeRequired)
                        {
                            txtbox_Log.Invoke(new Action(() =>
                            {
                                txtbox_Log.Text = listBox2.Items.Count.ToString();
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
                //创建不存在的log find目录
                if (!Directory.Exists(_sLogFindFolderPath))
                {
                    Directory.CreateDirectory(_sLogFindFolderPath);
                }
                else
                {
                    Directory.Delete(_sLogFindFolderPath, true);
                    Directory.CreateDirectory(_sLogFindFolderPath);
                }

                //创建不存在的log not find目录
                if (!Directory.Exists(_sLogNotFindFolderPath))
                {
                    Directory.CreateDirectory(_sLogNotFindFolderPath);
                }
                else
                {
                    Directory.Delete(_sLogNotFindFolderPath, true);
                    Directory.CreateDirectory(_sLogNotFindFolderPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            listBox3.Items.Clear();
            listBox4.Items.Clear();
            txtbox_LogFind.Text = "";
            txtbox_LogNotFind.Text = "";
            btn_Fetching.Enabled = false;
            groupBox3.Text = "Log Find";
            groupBox3.Text += " - " + _sLogFindFolderPath;
            groupBox4.Text = "Log Not Find";
            groupBox4.Text += " - " + _sLogNotFindFolderPath;

            await Task.Run(() =>
            {
                DoFetching();
            });

            txtbox_LogFind.BackColor = Color.GreenYellow;
            txtbox_LogNotFind.BackColor = Color.GreenYellow;
            btn_Fetching.Enabled = true;
            btn_OpenLogFind.Enabled = true;
            btn_OpenLogNotFind.Enabled = true;
        }


        /// <summary>
        /// 打开Log Find文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenResultLogFind_Click(object sender, EventArgs e)
        {
            //if (listBox3.Items.Count == 0)
            //{
            //    MessageBox.Show("No Data！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            try
            {
                if (string.IsNullOrEmpty(_sLogFindFolderPath))
                {
                    MessageBox.Show("please load .txt first！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //btn_OpenLogFind.Enabled = false;
                    btn_LoadSN.Focus();
                    return;
                }

                //判断Log Find目录是否存在，如果不存在，提示先做Fetching
                if (!Directory.Exists(_sLogFindFolderPath))
                {
                    MessageBox.Show("Result folder not exist, do Fetching！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btn_OpenLogFind.Enabled = false;
                    btn_Fetching.Focus();
                    return;
                }
                else
                {
                    Process.Start("Explorer.exe", _sLogFindFolderPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 打开Log Not Find文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenLogNotFind_Click(object sender, EventArgs e)
        {
            //if (listBox4.Items.Count == 0)
            //{
            //    MessageBox.Show("No Data！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            try
            {
                if (string.IsNullOrEmpty(_sLogNotFindFolderPath))
                {
                    MessageBox.Show("please load .txt first！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //btn_OpenLogNotFind.Enabled = false;
                    btn_LoadSN.Focus();
                    return;
                }

                //判断Log Not Find目录是否存在，如果不存在，提示先做Fetching
                if (!Directory.Exists(_sLogNotFindFolderPath))
                {
                    MessageBox.Show("Result folder not exist, do Fetching！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btn_OpenLogNotFind.Enabled = false;
                    btn_Fetching.Focus();
                    return;
                }
                else
                {
                    Process.Start("Explorer.exe", _sLogNotFindFolderPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void tsBtnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. 将序列号拷贝到.txt文本中，点击Load SN.txt按钮，程序自动加载.txt中的所有序列号\n\n2. 点击Load Log Folder按钮，选择从FileZilla上download下来的Log目录，程序将自动加载该目录下的所有Log文件\n\n3. 点击Fetching按钮，程序将自动匹配从FileZilla上download下来的ST站数据与源文件.txt中的SN号比对，找出与源文件中匹配的Log以及未找到的SN", "帮助", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Close" + " ？", "Info", 2))
            {
                this.CloseForm();
            }
        }


        private void btn_Debug_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(new List<string>() {
                "1",
                "2"
            }.ToArray());
        }
        #endregion



        #region 方法
        private void DoLoadTxt(string fileName)
        {
            bool bScroll = false;

            string sLine = "";

            List<string> lstTxt = new List<string>();

            StreamReader sr = new StreamReader(fileName, Encoding.UTF8);

            _sSNSource.Clear();

            while (null != (sLine = sr.ReadLine()))
            {
                if (string.IsNullOrEmpty(sLine.Trim()))
                {
                    continue;
                }

                if (!lstTxt.Contains(sLine))
                {
                    lstTxt.Add(sLine);

                    //listBox1.Items.Add(sLine);
                    if (listBox1.InvokeRequired)
                    {
                        listBox1.Invoke(new Action(() =>
                        {
                            //listBox1.Items.AddRange(lstTxt.ToArray());
                            listBox1.Items.Add(sLine);

                            if (listBox1.TopIndex == listBox1.Items.Count - (listBox1.Height / listBox1.ItemHeight))
                                bScroll = true;
                            if (bScroll)
                                listBox1.TopIndex = listBox1.Items.Count - (listBox1.Height / listBox1.ItemHeight);
                        }));
                    }

                    if (txtbox_LoadSN.InvokeRequired)
                    {
                        txtbox_LoadSN.Invoke(new Action(() =>
                        {
                            txtbox_LoadSN.Text = listBox1.Items.Count.ToString();
                        }));
                    }
                    _sSNSource.Add(sLine);
                }
            }

        }

        /// <summary>
        /// Fetching Log
        /// </summary>
        private void DoFetching()
        {
            bool bScroll_1 = false;
            bool bScroll_2 = false;

            List<string> notFindList = new List<string>();
            notFindList.Clear();//做Fetching前，清空Not Find列表

            for (int i = 0; i < _sSNSource.Count; i++)
            {
                bool bNotFind = true;

                for (int j = 0; j < _sLogTarget.Count; j++)
                {
                    string s1 = _sSNSource[i];//数据源: 681532300000001496(SN) / 681532300(PCBA)
                    string s2Ori = _sLogTarget[j];//C:\..\6815323000000014960000_2021_09_24_17_49_57_P_measData.csv.txt
                    string s2OriTemp = s2Ori.Substring(s2Ori.LastIndexOf('\\') + 1);//6815323000000014960000_2021_09_24_17_49_57_P_measData.csv.txt
                    if (s2OriTemp.Length >= s1.Length)
                    {
                        string sLogFind = s2OriTemp.Substring(0, s1.Length);//6815323000000014960000

                        if (s1.Contains(sLogFind))
                        {
                            //listBox3.Items.Add(_sLogTarget[j]);
                            if (listBox3.InvokeRequired)
                            {
                                listBox3.Invoke(new Action(() =>
                                {
                                    listBox3.Items.Add(_sLogTarget[j]);

                                    if (listBox3.TopIndex == listBox3.Items.Count - (listBox3.Height / listBox3.ItemHeight))
                                        bScroll_1 = true;
                                    if (bScroll_1)
                                        listBox3.TopIndex = listBox3.Items.Count - (listBox3.Height / listBox3.ItemHeight);
                                }));
                            }

                            if (txtbox_LogFind.InvokeRequired)
                            {
                                txtbox_LogFind.Invoke(new Action(() =>
                                {
                                    txtbox_LogFind.Text = listBox3.Items.Count.ToString();
                                }));
                            }

                            File.Copy(_sLogTarget[j], _sLogFindFolderPath + @"\" + s2OriTemp, true);

                            bNotFind = false;
                        }
                    }
                }

                if (bNotFind)
                {
                    if (!notFindList.Contains(_sSNSource[i]))//Not Find列表中没有包含当前SN
                    {
                        notFindList.Add(_sSNSource[i]);//将SN添加到Not Find列表

                        //listBox4.Items.Add(_sSNSource[i] + ", " + "not find log");
                        if (listBox4.InvokeRequired)
                        {
                            listBox4.Invoke(new Action(() =>
                            {
                                listBox4.Items.Add(_sSNSource[i] + ", " + "not find log");

                                if (listBox4.TopIndex == listBox4.Items.Count - (listBox4.Height / listBox4.ItemHeight))
                                    bScroll_2 = true;
                                if (bScroll_2)
                                    listBox4.TopIndex = listBox4.Items.Count - (listBox4.Height / listBox4.ItemHeight);
                            }));
                        }

                        if (txtbox_LogNotFind.InvokeRequired)
                        {
                            txtbox_LogNotFind.Invoke(new Action(() =>
                            {
                                txtbox_LogNotFind.Text = listBox4.Items.Count.ToString();
                            }));
                        }
                    }
                }
            }

            UtilityHelper.SaveListBoxToTxt(listBox4, Path.Combine(_sLogNotFindFolderPath, "log_not_find_SN.txt"));
        }
        #endregion

 
    }
}
