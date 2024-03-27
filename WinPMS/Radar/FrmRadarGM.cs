using PMS.COMMON;
using PMS.COMMON.Helper;
using PMS.MODELS;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinPMS.FModels;

namespace WinPMS.Radar
{
    public partial class FrmRadarGM : Form
    {
        private IniHelper2 _iniHelper2 = null;

        private int _iTestCaseIndex = 0;

        private string _sTestCaseIndex = "";
        private string _sGMUIDIniPath = "";
        private string _sGMUIDIniPathOutput = "";
        private string _sGMUIDIniPathOutputHasRepeat = "";

        private List<string> _lstGMUIDIniRead = new List<string>();//定义UID_INI文件的列表
        private List<string> _lstGMUIDIniReadHasRepeat = new List<string>();//定义UID_INI文件列表，包含重复项

        public Action ActLoadIniPath;

        public FrmRadarGM()
        {
            InitializeComponent();
        }



        #region 事件

        private void FrmRadarGM_Load(object sender, EventArgs e)
        {
            ActLoadIniPath = LoadIniPath;
            ActLoadIniPath?.Invoke();
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            ActLoadIniPath?.Invoke();
        }

        private void textBoxUIDIni_TextChanged(object sender, EventArgs e)
        {
            _sGMUIDIniPath = textBoxUIDIni.Text.Trim();
            _sGMUIDIniPathOutput = Path.Combine(_sGMUIDIniPath, "KeyGen_Output.ini");
            textBoxUINIniOutput.Text = _sGMUIDIniPathOutput;

            _sGMUIDIniPathOutputHasRepeat = _sGMUIDIniPathOutput.Replace(".ini", "_Has_Repeat.ini");
        }


        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(_sGMUIDIniPath))
            {
                MsgBoxHelper.MsgBoxError("Path: " + _sGMUIDIniPath + " 不存在！");
                return;
            }

            Process.Start(_sGMUIDIniPath);
        }

        /// <summary>
        /// 检查UID_INI文件(eg：UID_240130_09h14m20s760ms.ini)的Section是否超过999
        /// 如果.ini文件中的Section数量超过999，则需要将该.ini拆分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUIDIniFilesCheck_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(_sGMUIDIniPath))
            {
                MsgBoxHelper.MsgBoxError("Path: " + _sGMUIDIniPath + " 不存在！");
                return;
            }

            //检查UID_INI文件的Section是否超过999
            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.Filter = "All|*.*|Excel(*.xlsm)|*.xlsm|Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
            openFile.Filter = "ini(*.ini)|*.ini";
            //openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile.InitialDirectory = _sGMUIDIniPath;
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == DialogResult.Cancel)
                return;
            string[] filePath = openFile.FileNames;

            listBoxUIDIniFilesCheck.Items.Clear();
            listBoxUIDIniFilesCheckOver.Items.Clear();
            StringCollection iniFileLst = new StringCollection();
            foreach (string file in filePath)
            {
                //初始化ini文件
                _iniHelper2 = new IniHelper2(file);

                //获取ini文件中所有的section

                iniFileLst.Clear();
                _iniHelper2.ReadSections(iniFileLst);

                //判断UID_INI文件中的Section是否超过999
                if (iniFileLst.Count >= 999)
                {
                    listBoxUIDIniFilesCheckOver.Items.Add(file);
                }
                else
                {
                    listBoxUIDIniFilesCheck.Items.Add(file);
                }
            }

            //循环遍历超过999个Section的ListBox，提示需要将文件进行分割
            if (listBoxUIDIniFilesCheckOver.Items.Count > 0)
            {
                string file = "";
                for (int i = 0; i < listBoxUIDIniFilesCheckOver.Items.Count; i++)
                {
                    file += listBoxUIDIniFilesCheckOver.Items[i].ToString() + "\n";
                }
                MsgBoxHelper.MsgBoxError(file + "\n\n" + "以上.ini文件的Section超过999，需要先将文件进行分割！\n\n功能未实现，需要手动分割！");

            }
        }


        /// <summary>
        /// 将多个xxx_KeyGen_Output.ini合并成一个总的KeyGen_Output.ini，并依次编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKeyGenOutputCombine_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(_sGMUIDIniPath))
            {
                MsgBoxHelper.MsgBoxError("Path: " + _sGMUIDIniPath + " 不存在！");
                return;
            }


            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.Filter = "All|*.*|Excel(*.xlsm)|*.xlsm|Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
            openFile.Filter = "ini(*.ini)|*.ini";
            //openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile.InitialDirectory = _sGMUIDIniPath;
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == DialogResult.Cancel)
                return;
            string[] filePath = openFile.FileNames;

            //将选取的多个xxx_KeyGen_Output.ini文件添加到ListBox中
            listBoxUIDIniFilesKeyGenOutput.Items.Clear();
            foreach (string file in filePath)
            {
                listBoxUIDIniFilesKeyGenOutput.Items.Add(file);
            }

            btnKeyGenOutputCombine.Enabled = false;

            try
            {
                //循环遍历多个xxx_KeyGen_Output.ini文件，读取到List中
                _lstGMUIDIniRead.Clear();
                for (int i = 0; i < filePath.Length; i++)
                {
                    StreamReader sr = new StreamReader(filePath[i], Encoding.Default);
                    string line;
                    while (null != (line = sr.ReadLine()))
                    {
                        _lstGMUIDIniRead.Add(line);
                    }

                    sr.Close();
                }

                //将读取到的多个xxx_KeyGen_Output.ini文件，根据"[TEST_CASE_"进行重新编号
                _iTestCaseIndex = 0;
                _sTestCaseIndex = "";
                for (int i = 0; i < _lstGMUIDIniRead.Count; i++)
                {
                    if (_lstGMUIDIniRead[i].StartsWith("[TEST_CASE_"))
                    {
                        _iTestCaseIndex++;
                        if (_iTestCaseIndex.ToString().Length == 1)
                        {
                            _sTestCaseIndex = "00" + _iTestCaseIndex;
                        }
                        else if (_iTestCaseIndex.ToString().Length == 2)
                        {
                            _sTestCaseIndex = "0" + _iTestCaseIndex;
                        }
                        else if (_iTestCaseIndex.ToString().Length == 3)
                        {
                            _sTestCaseIndex = "" + _iTestCaseIndex;
                        }
                        _lstGMUIDIniRead[i] = "[TEST_CASE_" + _sTestCaseIndex + "_START]";
                    }
                }

                //判断"KeyGen_Output.ini"文件是否已存在，如果存在，则先删除
                if (File.Exists(_sGMUIDIniPathOutput))
                {
                    File.Delete(_sGMUIDIniPathOutput);
                }

                //将编号完成的List，重新写入到ini文件中
                try
                {
                    FileStream fs = new FileStream(_sGMUIDIniPathOutput, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                    sw.Flush();
                    sw.BaseStream.Seek(0, SeekOrigin.Begin);
                    for (int i = 0; i < _lstGMUIDIniRead.Count; i++)
                    {
                        sw.WriteLine(_lstGMUIDIniRead[i]);
                    }
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                //初始化ini文件
                _iniHelper2 = new IniHelper2(_sGMUIDIniPathOutput);

                //获取ini文件中所有的Section
                StringCollection iniFileSectionList = new StringCollection();
                iniFileSectionList.Clear();
                _iniHelper2.ReadSections(iniFileSectionList);

                StringCollection iniFileKeysValueList = new StringCollection();
                iniFileKeysValueList.Clear();

                //循环遍历所有的Section，根据Key获取每一个Section的Value值，并且将所有的Value值拼接后存入List
                for (int i = 0; i < iniFileSectionList.Count; i++)
                {
                    iniFileKeysValueList.Add(
                        _iniHelper2.ReadString(iniFileSectionList[i], "ECU_SERIAL_NO", "NA") +
                        _iniHelper2.ReadString(iniFileSectionList[i], "ECU_ID", "NA") +
                        _iniHelper2.ReadString(iniFileSectionList[i], "UID", "NA") +
                        _iniHelper2.ReadString(iniFileSectionList[i], "MK2", "NA") +
                        _iniHelper2.ReadString(iniFileSectionList[i], "UMK2", "NA") +
                        _iniHelper2.ReadString(iniFileSectionList[i], "MK4", "NA") +
                        _iniHelper2.ReadString(iniFileSectionList[i], "MK5", "NA") +
                        _iniHelper2.ReadString(iniFileSectionList[i], "UMK4", "NA") +
                        _iniHelper2.ReadString(iniFileSectionList[i], "UMK5", "NA")
                        );
                }

                //检查ini文件中是否有重复项？如果含有重复项的话，将ini文件重命名
                List<string> iniFileRepeatIndex = new List<string>();
                iniFileRepeatIndex.Clear();
                iniFileRepeatIndex = GetRepeatIni(iniFileKeysValueList);
                if (iniFileRepeatIndex.Count > 0)
                {
                    if (File.Exists(_sGMUIDIniPathOutputHasRepeat))
                    {
                        File.Delete(_sGMUIDIniPathOutputHasRepeat);
                    }

                    File.Move(_sGMUIDIniPathOutput, _sGMUIDIniPathOutputHasRepeat);

                    _iniHelper2 = new IniHelper2(_sGMUIDIniPathOutputHasRepeat);

                    //获取包含重复Section的ini文件中所有的Section
                    StringCollection iniFileSectionRepeatList = new StringCollection();
                    iniFileSectionRepeatList.Clear();
                    _iniHelper2.ReadSections(iniFileSectionRepeatList);

                    List<string> iniFileSectionRepeatOutList = new List<string>();
                    iniFileSectionRepeatOutList.Clear();

                    string sTestCaseNum = "";
                    for (int i = 0; i < iniFileRepeatIndex.Count; i++)
                    {
                        for (int j = 0; j < iniFileSectionRepeatList.Count; j++)
                        {
                            //[TEST_CASE_XXX_START]
                            sTestCaseNum = iniFileSectionRepeatList[j].Substring("TEST_CASE_".Length, 3);//获取TEST_CASE中间的编号XXX
                            if (int.Parse(sTestCaseNum) == int.Parse(iniFileRepeatIndex[i]))
                            {
                                iniFileSectionRepeatOutList.Add(iniFileSectionRepeatList[j]);
                            }
                        }
                    }

                    //await Task.Run(() =>
                    //{
                    //    for (int i = 0; i < iniFileSectionRepeatList.Count; i++)
                    //    {
                    //        for (int j = i + 1; j < iniFileSectionRepeatList.Count; j++)
                    //        {
                    //            if
                    //            (
                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[i], "ECU_SERIAL_NO", "NA") ==
                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[j], "ECU_SERIAL_NO", "NA") &&

                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[i], "ECU_ID", "NA") ==
                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[j], "ECU_ID", "NA") &&

                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[i], "UID", "NA") ==
                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[j], "UID", "NA") &&

                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[i], "MK2", "NA") ==
                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[j], "MK2", "NA") &&

                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[i], "UMK2", "NA") ==
                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[j], "UMK2", "NA") &&

                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[i], "MK4", "NA") ==
                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[j], "MK4", "NA") &&

                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[i], "MK5", "NA") ==
                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[j], "MK5", "NA") &&

                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[i], "UMK4", "NA") ==
                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[j], "UMK4", "NA") &&

                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[i], "UMK5", "NA") ==
                    //                _iniHelper2.ReadString(iniFileSectionRepeatList[j], "UMK5", "NA")
                    //            )
                    //            {
                    //                iniFileSectionRepeatOutList.Add(iniFileSectionRepeatList[i]);
                    //            }
                    //        }
                    //    }
                    //});

                    //读取含有重复Section的ini文件
                    _lstGMUIDIniReadHasRepeat.Clear();
                    try
                    {
                        StreamReader sr = new StreamReader(_sGMUIDIniPathOutputHasRepeat, Encoding.Default);
                        string line;
                        while (null != (line = sr.ReadLine()))
                        {
                            _lstGMUIDIniReadHasRepeat.Add(line);
                        }

                        sr.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                    //将ini文件中重复的Section加上_Repeat后缀的标记
                    for (int i = 0; i < iniFileSectionRepeatOutList.Count; i++)
                    {
                        for (int j = 0; j < _lstGMUIDIniReadHasRepeat.Count; j++)
                        {
                            if ("[" + iniFileSectionRepeatOutList[i] + "]" == _lstGMUIDIniReadHasRepeat[j])
                            {
                                _lstGMUIDIniReadHasRepeat[j] = _lstGMUIDIniReadHasRepeat[j].Replace("_START]", "_START_Repeat]");
                                break;
                            }

                        }
                    }

                    //将加上_Repeat标记的ini文件重新写入
                    try
                    {
                        FileStream fs = new FileStream(_sGMUIDIniPathOutputHasRepeat, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                        sw.Flush();
                        sw.BaseStream.Seek(0, SeekOrigin.Begin);
                        for (int i = 0; i < _lstGMUIDIniReadHasRepeat.Count; i++)
                        {
                            sw.WriteLine(_lstGMUIDIniReadHasRepeat[i]);
                        }
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    //根据_Repeat标记，删除ini文件中重复的Section
                    for (int i = 0; i < iniFileSectionRepeatOutList.Count; i++)
                    {
                        _iniHelper2.EraseSection(iniFileSectionRepeatOutList[i] + "_Repeat");
                    }


                    //读取已删除重复Section的ini文件
                    try
                    {
                        _lstGMUIDIniReadHasRepeat.Clear();
                        StreamReader sr = new StreamReader(_sGMUIDIniPathOutputHasRepeat, Encoding.Default);
                        string line;
                        while (null != (line = sr.ReadLine()))
                        {
                            _lstGMUIDIniReadHasRepeat.Add(line);
                        }

                        sr.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    _iTestCaseIndex = 0;
                    _sTestCaseIndex = "";
                    //将已删除重复Section的ini文件重新排序，并写入文件
                    for (int i = 0; i < _lstGMUIDIniReadHasRepeat.Count; i++)
                    {
                        if (_lstGMUIDIniReadHasRepeat[i].StartsWith("[TEST_CASE_"))
                        {
                            _iTestCaseIndex++;
                            if (_iTestCaseIndex.ToString().Length == 1)
                            {
                                _sTestCaseIndex = "00" + _iTestCaseIndex;
                            }
                            else if (_iTestCaseIndex.ToString().Length == 2)
                            {
                                _sTestCaseIndex = "0" + _iTestCaseIndex;
                            }
                            else if (_iTestCaseIndex.ToString().Length == 3)
                            {
                                _sTestCaseIndex = "" + _iTestCaseIndex;
                            }
                            _lstGMUIDIniReadHasRepeat[i] = "[TEST_CASE_" + _sTestCaseIndex + "_START]";
                        }
                    }

                    //已排序，写入文件
                    try
                    {
                        FileStream fs = new FileStream(_sGMUIDIniPathOutputHasRepeat, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                        sw.Flush();
                        sw.BaseStream.Seek(0, SeekOrigin.Begin);
                        for (int i = 0; i < _lstGMUIDIniReadHasRepeat.Count; i++)
                        {
                            sw.WriteLine(_lstGMUIDIniReadHasRepeat[i]);
                        }
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    File.Move(_sGMUIDIniPathOutputHasRepeat, _sGMUIDIniPathOutput);

                    MsgBoxHelper.MsgBoxShowOnTop("Combine Succeed！\n\nRepeat Section has been deleted！", "KeyGen_Output");
                }
                else
                {
                    MsgBoxHelper.MsgBoxShowOnTop("Combine Succeed！\n\nNo Repeat Section！", "KeyGen_Output");
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgBoxError("Exception:" + "\n" + ex.Message);
                throw ex;
            }

            btnKeyGenOutputCombine.Enabled = true;
        }


        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.CloseForm();
        }

        #endregion



        #region 方法
        private void LoadIniPath()
        {
            //TODO 可以优化
            _sGMUIDIniPath = IniHelper.ReadIni(FileHelper.INI_PMS_LOCAL_SECTION, "Path_GM_UID_INI", "NULL", FileHelper.sIniFilePathLocal);
            textBoxUIDIni.Text = _sGMUIDIniPath;

            _sGMUIDIniPathOutput = Path.Combine(_sGMUIDIniPath, "KeyGen_Output.ini");
            textBoxUINIniOutput.Text = _sGMUIDIniPathOutput;

            _sGMUIDIniPathOutputHasRepeat = _sGMUIDIniPathOutput.Replace(".ini", "_Has_Repeat.ini");
        }


        private List<string> GetRepeatIni(StringCollection list)
        {
            List<string> listSrc = new List<string>();
            List<string> listSrcRepeat1 = new List<string>();
            List<string> listSrcRepeat2 = new List<string>();

            string sRepeat1 = "";
            string sRepeat2 = "";

            //获取所有的号
            for (int i = 0; i < list.Count; i++)
            {
                listSrc.Add(list[i]);
            }

            //判断是否有重复的号
            for (int m = 0; m < listSrc.Count; m++)
            {
                for (int n = m + 1; n < listSrc.Count; n++)
                {
                    if (listSrc[m] == listSrc[n])
                    {
                        listSrcRepeat1.Add((m + 1).ToString());
                        listSrcRepeat2.Add((n + 1).ToString());
                    }
                }
            }

            //for (int i = 0; i < listSrcRepeat1.Count; i++)
            //{
            //    if (i == listSrcRepeat1.Count - 1)
            //    {
            //        sRepeat1 += "[ " + listSrcRepeat1[i] + " ]";
            //    }
            //    else
            //    {
            //        sRepeat1 += "[ " + listSrcRepeat1[i] + " ], ";
            //    }
            //}

            //for (int i = 0; i < listSrcRepeat2.Count; i++)
            //{
            //    if (i == listSrcRepeat2.Count - 1)
            //    {
            //        sRepeat2 += "[ " + listSrcRepeat2[i] + " ]";
            //    }
            //    else
            //    {
            //        sRepeat2 += "[ " + listSrcRepeat2[i] + " ], ";
            //    }
            //}

            //if (listSrcRepeat1.Count > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return listSrcRepeat1;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.Filter = "All|*.*|Excel(*.xlsm)|*.xlsm|Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
            openFile.Filter = "ini(*.ini)|*.ini";
            //openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile.InitialDirectory = _sGMUIDIniPath;
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == DialogResult.Cancel)
                return;
            string[] filePath = openFile.FileNames;

            //将选取的多个xxx_KeyGen_Output.ini文件添加到ListBox中
            listBoxUIDIniFilesKeyGenOutput.Items.Clear();
            foreach (string file in filePath)
            {
                listBoxUIDIniFilesKeyGenOutput.Items.Add(file);
            }
        }
    }
}
