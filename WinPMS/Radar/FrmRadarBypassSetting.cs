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
using AForge.Video.DirectShow;
using System.Drawing;
using AForge.Video;
using ZXing;

namespace WinPMS.Radar
{
    public partial class FrmRadarBypassSetting : Form
    {
        private string _sBypassConfigFile = "";//定义Bypass的配置文件
        private string _sBypassLineRead = "";//定义读取到的Bypass行

        public bool IsBypass { get; set; }

        public FrmRadarBypassSetting()
        {
            InitializeComponent();

            //获取Bypass的配置文件
            _sBypassConfigFile = IniHelper.ReadIni(FileHelper.INI_RDR_SEL_SECTION, "Radar_Bypass_Config_File_Path", "NULL", FileHelper.sIniFilePathCFM);
            
            GetBypassSettingFromConfigFile();

            textBoxConfigFile.Text = _sBypassConfigFile;
            //textBoxBypassLine.Text = _sBypassLineRead;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                return;
            }
            base.WndProc(ref m);
        }


        #region 事件
        private void chkBoxSWLBypass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxSWLBypass.Checked)
            {
                _sBypassLineRead = _sBypassLineRead.Replace("SWL_Bypass = N", "SWL_Bypass = Y");
            }
            else
            {
                _sBypassLineRead = _sBypassLineRead.Replace("SWL_Bypass = Y", "SWL_Bypass = N");
            }
        }

        private void chkBoxEOLBypass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxEOLBypass.Checked)
            {
                _sBypassLineRead = _sBypassLineRead.Replace("EOL_Bypass = N", "EOL_Bypass = Y");
            }
            else
            {
                _sBypassLineRead = _sBypassLineRead.Replace("EOL_Bypass = Y", "EOL_Bypass = N");
            }
        }

        private void chkBoxLBLBypass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxLBLBypass.Checked)
            {
                _sBypassLineRead = _sBypassLineRead.Replace("LBL_Bypass = N", "LBL_Bypass = Y");
            }
            else
            {
                _sBypassLineRead = _sBypassLineRead.Replace("LBL_Bypass = Y", "LBL_Bypass = N");
            }
        }


        /// <summary>
        /// 设置Bypass并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetBypass_Click(object sender, EventArgs e)
        {
            //写入Bypass的配置
            try
            {
                if (_sBypassLineRead == FileHelper.RADAR_SEL_BYPASS_SETTING_DEFAULT)
                {
                    MsgBoxHelper.MsgBoxShow("未设置Bypass\n你想做什么？", "Set Bypass");
                    return;
                }

                StreamWriter sw = new StreamWriter(_sBypassConfigFile, false);
                sw.Write(_sBypassLineRead);
                sw.Close();
                MessageBox.Show("设置Bypass成功！");
                this.IsBypass = true;
                this.CloseForm();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 复位Bypass并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetBypass_Click(object sender, EventArgs e)
        {
            //写入Bypass的配置
            try
            {
                if (_sBypassLineRead == FileHelper.RADAR_SEL_BYPASS_SETTING_DEFAULT)
                {
                    MsgBoxHelper.MsgBoxShow("当前Bypass已经复位！\n你想做什么？", "Reset Bypass");
                    return;
                }

                StreamWriter sw = new StreamWriter(_sBypassConfigFile, false);
                _sBypassLineRead = FileHelper.RADAR_SEL_BYPASS_SETTING_DEFAULT;
                sw.Write(_sBypassLineRead);
                sw.Close();
                chkBoxSWLBypass.Checked = false;
                chkBoxEOLBypass.Checked = false;
                chkBoxLBLBypass.Checked = false;
                MsgBoxHelper.MsgBoxShow("复位Bypass成功", "Reset Bypass");
                this.IsBypass = false;
                this.CloseForm();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBoxBypassLine.Text = _sBypassLineRead;
        }

        /// <summary>
        /// 直接关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_sBypassLineRead == FileHelper.RADAR_SEL_BYPASS_SETTING_DEFAULT)
            {
                this.IsBypass = false;
            }
            else
            {
                this.IsBypass = true;
            }

            this.CloseForm();
        }



        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MsgBoxHelper.MsgBoxConfirm("Close" + " ？", "Info", 2))
            {
                if (_sBypassLineRead == FileHelper.RADAR_SEL_BYPASS_SETTING_DEFAULT)
                {
                    this.IsBypass = false;
                }
                else
                {
                    this.IsBypass = true;
                }

                this.CloseForm();
            }
        }
        #endregion


        #region 方法
        /// <summary>
        /// 从Bypass配置文件中获取Bypass的设置
        /// </summary>
        private void GetBypassSettingFromConfigFile()
        {
            //读取Bypass的配置文件
            try
            {
                StreamReader sr = new StreamReader(_sBypassConfigFile);
                //读取Bypass配置文件的第一行
                _sBypassLineRead = sr.ReadLine();//SWL_Bypass = N; EOL_Bypass = N; LBL_Bypass = N
                //while (!sr.EndOfStream)
                //{
                //    _sBypassLine = sr.ReadLine();
                //}

                sr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //设置SWL_Bypass Checkbox
            if (_sBypassLineRead.Contains("SWL_Bypass = Y"))
            {
                chkBoxSWLBypass.Checked = true;
            }
            else
            {
                chkBoxSWLBypass.Checked = false;
            }

            //设置EOL_Bypass Checkbox
            if (_sBypassLineRead.Contains("EOL_Bypass = Y"))
            {
                chkBoxEOLBypass.Checked = true;
            }
            else
            {
                chkBoxEOLBypass.Checked = false;
            }

            //设置LBL_Bypass Checkbox
            if (_sBypassLineRead.Contains("LBL_Bypass = Y"))
            {
                chkBoxLBLBypass.Checked = true;
            }
            else
            {
                chkBoxLBLBypass.Checked = false;
            }
        }

        #endregion


    }
}
