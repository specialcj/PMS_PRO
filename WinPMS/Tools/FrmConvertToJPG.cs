using PMS.COMMON.Helper;
using PMS.MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WinPMS.FModels;
using ImageMagick;
using System.Threading.Tasks;
using System.Text;
using System.Threading;

namespace WinPMS.Tools
{
    public partial class FrmConvertToJPG : Form
    {
        public FrmConvertToJPG()
        {
            InitializeComponent();
        }

        private List<string> _fileAlreadyAdded = new List<string>();
        private List<string> _fileNotExist = new List<string>();
        private List<string> _fileExtensionNotSupport = new List<string>();
        private List<string> _fileNeedDeleteAfterConvert = new List<string>();

        private string _sJpgOutputPath = "";
        //private string _sFileFilterByBrowse = "All|*.*|.HEIC|*.HEIC|.txt|*.txt";
        private string _sFileFilterByBrowse = ".HEIC|*.HEIC";
        //private string _sFileFilter = ".HEIC|.PNG";
        private string _sFileFilter = ".HEIC";


        #region 事件
        private void FrmConvertToJPG_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            chkBox_DelOriFile.Checked = false;
            txtBox_InputPath.Text = FileHelper.sIniPMSLocalPath1;
            txtBox_OutputPath.Text = FileHelper.sIniPMSLocalPath2;
            _sJpgOutputPath = txtBox_OutputPath.Text;
        }


        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }


        /// <summary>
        /// ListBox拖拽事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                LoadSrcFiles(new List<string>(files));
            }
        }


        /// <summary>
        /// 选择源目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BrowseSrcFolder_Click(object sender, EventArgs e)
        {
            List<string> sSrcFolder = new List<string>();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (DialogResult.OK == fbd.ShowDialog())
            {
                sSrcFolder.Add(fbd.SelectedPath);
            }

            LoadSrcFiles(sSrcFolder);
        }


        /// <summary>
        /// 选择源文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BrowseSrcFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = _sFileFilterByBrowse;

            if (DialogResult.OK == ofd.ShowDialog())
            {
                List<string> sSrcFile = new List<string>(ofd.FileNames);
                LoadSrcFiles(sSrcFile);
            }
        }

        /// <summary>
        /// 从ini文件中加载源目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadSrcFolderFromIni_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FileHelper.sIniPMSLocalPath1))
            {
                MsgBoxHelper.MsgBoxError("The input path not defined int the .ini!");
                return;
            }

            if (!Directory.Exists(FileHelper.sIniPMSLocalPath1))
            {
                MsgBoxHelper.MsgBoxError("The input path not exist!" + "\n" + "Please check the configuration int the .ini!");
                return;
            }

            List<string> sSrcFolder = new List<string>();
            sSrcFolder.Add(FileHelper.sIniPMSLocalPath1);

            LoadSrcFiles(sSrcFolder);
        }

        /// <summary>
        /// 移除ListBox中的某一项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_RemoveItem_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MsgBoxHelper.MsgBoxError("No Items!");
                return;
            }

            if (-1 == listBox1.SelectedIndex)
            {
                MsgBoxHelper.MsgBoxError("No Items Selected!");
                return;
            }

            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }


        /// <summary>
        /// 清空ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearListBox_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MsgBoxHelper.MsgBoxError("No Items!");
                return;
            }
            listBox1.Items.Clear();
        }


        /// <summary>
        /// 选择JPG输出目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BrowseOutputPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择Output Path目录 ...";

            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }

            _sJpgOutputPath = dialog.SelectedPath.Trim();//获取Output Path的目录
            txtBox_OutputPath.Text = _sJpgOutputPath;
        }


        /// <summary>
        /// 打开JPG输出目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenJpgOutputPath_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_sJpgOutputPath))
            {
                MsgBoxHelper.MsgBoxError(".jpg Ouptput Path not defined!");
                btn_BrowseJpgOutputPath.Focus();
                return;
            }

            if (!Directory.Exists(_sJpgOutputPath))
            {
                MsgBoxHelper.MsgBoxError(".jpg Ouptput Path not exist!");
                btn_BrowseJpgOutputPath.Focus();
                return;
            }

            Process.Start("Explorer.exe", _sJpgOutputPath);
        }


        /// <summary>
        /// 转.jpg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_ConvertToJPG_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MsgBoxHelper.MsgBoxError("No Items!");
                return;
            }

            if (string.IsNullOrEmpty(_sJpgOutputPath))
            {
                MsgBoxHelper.MsgBoxError(".jpg Output Path not defined!");
                btn_BrowseJpgOutputPath.Focus();
                return;
            }

            string sFileFullName;//xxx.HEIC
            string sFileExtension;//.HEIC
            string sFileName;//xxx

            btn_ConvertToJPG.Enabled = false;

            //转.jpg
            await Task.Run(() =>
            {
                foreach (string item in listBox1.Items)
                {
                    try
                    {
                        FileInfo info = new FileInfo(item);
                        using (MagickImage image = new MagickImage(info.FullName))
                        {
                            sFileFullName = item.Substring(item.LastIndexOf('\\') + 1);//xxx.HEIC
                            sFileExtension = Path.GetExtension(item);//.HEIC
                            sFileName = sFileFullName.Substring(0, sFileFullName.Length - sFileExtension.Length);//xxx
                            image.Write(Path.Combine(_sJpgOutputPath, sFileName + ".jpg"));

                            //删除源文件
                            if (chkBox_DelOriFile.Checked == true)
                            {
                                File.Delete(item);
                                _fileNeedDeleteAfterConvert.Add(item);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string sExceptionMsg = ex.Message;

                        if (sExceptionMsg.Contains("unable to open image"))
                        {
                            _fileNotExist.Add(item);
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                }

                //提示不存在的File
                if (_fileNotExist.Count != 0)
                {
                    StringBuilder sbFileNotExist = new StringBuilder();

                    foreach (string file in _fileNotExist)
                    {
                        sbFileNotExist.Append(file + "\n");
                    }
                    MsgBoxHelper.MsgBoxShow("files Not Exist!" + "\n" + sbFileNotExist.ToString(), "Info");
                }
            });

            await Task.Run(() =>
            {
                //移除列表框中的源文件
                foreach (string item in _fileNeedDeleteAfterConvert)
                {
                    if (chkBox_DelOriFile.Checked == true && _fileNeedDeleteAfterConvert.Count > 0)
                    {
                        if (listBox1.InvokeRequired)
                        {
                            listBox1.Invoke(new Action(() =>
                            {
                                listBox1.Items.Remove(item);
                            }));
                        }

                        //listBox1.Items.Remove(item);
                    }

                }
            });

            if (DialogResult.OK == MessageBox.Show("OK!" + "\n" + "Open .jpg Output Path?", "Convert To .jpg", MessageBoxButtons.OKCancel))
            {
                Process.Start("Explorer.exe", _sJpgOutputPath);
            }

            btn_ConvertToJPG.Enabled = true;
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
        private void LoadSrcFiles(List<string> files)
        {
            _fileAlreadyAdded.Clear();
            _fileExtensionNotSupport.Clear();

            List<string> fileAllList = new List<string>();

            //Task.Run(() =>
            //{
            foreach (string file in files)
            {
                //Console.WriteLine(file + " is a folder");

                //判断拖入的是目录还是文件
                if ((File.GetAttributes(file) & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    //循环遍历目录，获取目录下的所有文件，添加到List
                    //fileAllList.AddRange(UtilityHelper.RecursionDirReturnList(file));
                    UtilityHelper.RecursionDir(fileAllList, new DirectoryInfo(file), true);
                }
                else
                {
                    //Console.WriteLine(file + " is a file");

                    //判断ListBox中是否已添加该文件
                    if (listBox1.Items.Contains(file))
                    {
                        _fileAlreadyAdded.Add(file);
                    }
                    else//判断拖入的文件后缀格式是否符合
                    {
                        if (listBox1.InvokeRequired)
                        {
                            listBox1.Invoke(new Action(() =>
                            {
                                if (_sFileFilter.Contains(Path.GetExtension(file).ToUpper()))
                                {
                                    listBox1.Items.Add(file);
                                }
                                else
                                {
                                    _fileExtensionNotSupport.Add(file);
                                }
                            }));
                        }
                        else
                        {
                            if (_sFileFilter.Contains(Path.GetExtension(file).ToUpper()))
                            {
                                listBox1.Items.Add(file);
                            }
                            else
                            {
                                _fileExtensionNotSupport.Add(file);
                            }
                        }
                    }
                }
            }

            //Console.WriteLine(listFileAll.Count);

            string fileExtension = "";

            //循环遍历List中的文件，添加到ListBox
            if (fileAllList.Count > 0)
            {
                foreach (string file in fileAllList)
                {
                    fileExtension = Path.GetExtension(file).ToUpper();//获取文件的扩展名 .xxx

                    //将符合扩展名要求的文件加入到ListBox
                    if (!string.IsNullOrEmpty(fileExtension) && _sFileFilter.Contains(fileExtension))
                    {
                        //过滤Folder中已添加的File
                        if (listBox1.Items.Contains(file))
                        {
                            _fileAlreadyAdded.Add(file);
                        }
                        else
                        {
                            listBox1.Items.Add(file);
                        }
                    }
                    else
                    {
                        _fileExtensionNotSupport.Add(file);
                    }
                }
            }

            //提示已添加的File
            if (_fileAlreadyAdded.Count != 0)
            {
                StringBuilder sbFile = new StringBuilder();

                foreach (string file in _fileAlreadyAdded)
                {
                    sbFile.Append(file + "\n");
                }
                MsgBoxHelper.MsgBoxShow("files has already been added!" + "\n\n" + sbFile.ToString(), "Info");
            }

            //提示不符合后缀的文件
            /*
            if (_fileExtensionNotSupport.Count != 0)
            {
                StringBuilder sbFile = new StringBuilder();

                foreach (string file in _fileExtensionNotSupport)
                {
                    sbFile.Append(file + "\n");
                }
                MsgBoxHelper.MsgBoxShow("files extension not support!" + "\n" + "please load the file with extension (" + _sFileFilter + ")" + "\n\n" + sbFile.ToString(), "Info");
            }
            */
            //});
        }

        #endregion


    }
}
