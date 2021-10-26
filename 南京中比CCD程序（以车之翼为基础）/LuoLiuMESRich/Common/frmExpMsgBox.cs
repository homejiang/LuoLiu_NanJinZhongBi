using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace Common
{
    public partial class frmExpMsgBox : Form
    {
        public frmExpMsgBox()
        {
            InitializeComponent();
        }
        public string _Msg = string.Empty;
        public Color _FontColor = Color.Black;
        public string _Type = string.Empty;
        private int WaitSecond = 0;
        private int InitWaitSecond = 0;
        /// <summary>
        /// 是否自动关闭窗体
        /// </summary>
        public bool AutoClose = true;
        private void frmExpMsgBox_Load(object sender, EventArgs e)
        {
            this.label1.Text = _Msg;
            this.label1.ForeColor = _FontColor;
            if (AutoClose)
            {
                //加载自动关闭设置
                string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                if (!strFile.EndsWith("\\"))
                    strFile += "\\";
                strFile += "Server.ini";
                if (!System.IO.File.Exists(strFile))
                {
                    return;
                }
                Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
                string strTemp = Common.CommonFuns.ConfigINI.GetString("BigMsgConfig", "WaitSecond", string.Empty);
                int iSecond;
                if (int.TryParse(strTemp, out iSecond) && iSecond > 0)
                {
                    this.numAutoCloseSecond.Text = iSecond.ToString();
                    InitWaitSecond = WaitSecond = iSecond;
                    this.timer1.Interval = 1000;
                    this.timer1.Enabled = true;
                }
            }
            lab.Visible = numAutoCloseSecond.Visible = AutoClose;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_Type.Length > 0)
            {
                //将此数据插入数据库
                string strSql = string.Format("INSERT INTO JC_BigMsgInfo (MsgType,MsgContent,UserCode,HeppenTime) VALUES('{0}','{1}','{2}',getdate())"
                    , this._Type, _Msg, Common.CurrentUserInfo.UserCode);
                try
                {
                    Common.CommonDAL.DoSqlCommand.DoSql(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
            }
            WriteWaitSecond();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            WaitSecond--;
            if (WaitSecond == 0)
            {
                button1_Click(null, null);
            }
            else
            {
                this.button1.Text = string.Format("知道了({0})", WaitSecond);
            }
        }
        private void WriteWaitSecond()
        {
            //保存设置
            int iSecond;
            if (!int.TryParse(this.numAutoCloseSecond.Text, out iSecond))
                iSecond = 0;
            if (InitWaitSecond != iSecond)
            {
                string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                if (!strFile.EndsWith("\\"))
                    strFile += "\\";
                strFile += "Server.ini";
                if (System.IO.File.Exists(strFile))
                {
                    Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
                    try
                    {
                        Common.CommonFuns.ConfigINI.SetValue("BigMsgConfig", "WaitSecond", iSecond.ToString());
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return;
                    }
                }
            }
        }
    }
}