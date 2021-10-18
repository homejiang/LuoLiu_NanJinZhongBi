using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.Scanner
{
    public partial class frmScannerDebug : Common.frmBase
    {
        #region 常量
        const string CONST_OpenText = "打开";
        const string CONST_CloseText = "关闭";
        #endregion
        JPSEntity.ScannControler _ScannerControler = null;
        frmMain1 _MainForm = null;
        public frmScannerDebug(JPSEntity.ScannControler controler,frmMain1 mainForm)
        {
            InitializeComponent();
            this._ScannerControler = controler;
            _MainForm = mainForm;
        }
        private void BindScannerStyle()
        {
            string strBtText;
            bool btEnabled;
            //实时刷新状态
            Color cBack, cFore;
            string strText;
            //扫描枪1
            if(JPSConfig.Scaner1_Terminated)
            {
                cBack = Color.White;
                cFore = Color.Gray;
                strText = "已停用";
                btEnabled = false;
                strBtText = "无效";
            }
            else if (_ScannerControler == null || _ScannerControler._Scanner1 == null)
            {
                cBack = Color.White;
                cFore = Color.Gray;
                strText = "未初始化";
                btEnabled = true;
                strBtText = CONST_OpenText;
            }
            else if(JPSConfig.Scaner1_Terminated)
            {
                //此时停用
                cBack = Color.White;
                cFore = Color.Gray;
                strText = "停用";
                btEnabled = false;
                strBtText = CONST_OpenText;
            }
            else
            {
                if (_ScannerControler._Scanner1.Running)
                {
                    if (_ScannerControler._Scanner1.Interrupt)
                    {
                        cBack = Color.Yellow;
                        cFore = Color.Black;
                        strText = "通讯中断";
                        btEnabled = true;
                        strBtText = CONST_CloseText;
                    }
                    else
                    {
                        cBack = Color.Lime;
                        cFore = Color.Black;
                        strText = "打开";
                        btEnabled = true;
                        strBtText = CONST_CloseText;
                    }
                }
                else
                {
                    cBack = Color.Maroon;
                    cFore = Color.White;
                    strText = "关闭";
                    btEnabled = true;
                    strBtText = CONST_OpenText;
                }
            }
            if (labScanner1Status.BackColor != cBack)
                this.labScanner1Status.BackColor = cBack;
            if (labScanner1Status.ForeColor != cFore)
                this.labScanner1Status.ForeColor = cFore;
            if (this.labScanner1Status.Text != strText)
                this.labScanner1Status.Text = strText;
            if (this.btOpen1.Text != strBtText)
                this.btOpen1.Text = strBtText;
            if (this.btOpen1.Enabled != btEnabled)
                this.btOpen1.Enabled = btEnabled;
            //扫描枪2
            if (JPSConfig.Scaner2_Terminated)
            {
                cBack = Color.White;
                cFore = Color.Gray;
                strText = "已停用";
                btEnabled = false;
                strBtText = "无效";
            }
            else if (_ScannerControler == null || _ScannerControler._Scanner2 == null)
            {
                cBack = Color.White;
                cFore = Color.Gray;
                strText = "未初始化";
                btEnabled = true;
                strBtText = CONST_OpenText;
            }
            else
            {
                if (_ScannerControler._Scanner2.Running)
                {
                    if (_ScannerControler._Scanner2.Interrupt)
                    {
                        cBack = Color.Yellow;
                        cFore = Color.Black;
                        strText = "通讯中断";
                        btEnabled = true;
                        strBtText = CONST_CloseText;
                    }
                    else
                    {
                        cBack = Color.Lime;
                        cFore = Color.Black;
                        strText = "打开";
                        btEnabled = true;
                        strBtText = CONST_CloseText;
                    }
                }
                else
                {
                    cBack = Color.Maroon;
                    cFore = Color.White;
                    strText = "关闭";
                    btEnabled = true;
                    strBtText = CONST_OpenText;
                }
            }
            if (labScanner2Status.BackColor != cBack)
                this.labScanner2Status.BackColor = cBack;
            if (labScanner2Status.ForeColor != cFore)
                this.labScanner2Status.ForeColor = cFore;
            if (this.labScanner2Status.Text != strText)
                this.labScanner2Status.Text = strText;
            if (this.btOpen2.Text != strBtText)
                this.btOpen2.Text = strBtText;
            if (this.btOpen2.Enabled != btEnabled)
                this.btOpen2.Enabled = btEnabled;
        }

        private void frmScannerDebug_Load(object sender, EventArgs e)
        {
            this.BindScannerStyle();
            this.timer1.Interval = 500;
            this.timer1.Enabled = true;
            this._MainForm.IsFormScannerDebugOpened = true;
        }

        private void btOpen1_Click(object sender, EventArgs e)
        {
            if(this.btOpen1.Text==CONST_OpenText)
            {
                //打开扫描枪
                if (this._ScannerControler == null)
                {
                    this.ShowMsg("扫码枪控制对象尚未创建。");
                    return;
                }
                if (this._ScannerControler._Scanner1 != null && this._ScannerControler._Scanner1.Running)
                {
                    this.ShowMsg("扫描枪1已经开启。");
                    return;
                }
                string sErr;
                if(!this._ScannerControler.StartListenning1(out sErr))
                {
                    this.ShowMsg(sErr);
                    return;
                }
                this.btOpen1.Text = CONST_CloseText;
            }
            else
            {
                //关闭扫描枪
                if (this._MainForm == null)
                {
                    this.ShowMsg("窗口对象为空！");
                    return;
                }
                string strErr;
                if (!this._MainForm.IsScanner1AllowStop(out strErr)) return;
                if (this._ScannerControler == null || this._ScannerControler._Scanner1 == null) return;
                if (this._ScannerControler._Scanner1.Running)
                {
                    if (!this._ScannerControler._Scanner1.StopListenning(out strErr)) return;
                }
                this.btOpen1.Text = CONST_OpenText;
            }
            BindScannerStyle();
        }
        
        private void btOpen2_Click(object sender, EventArgs e)
        {
            if (this.btOpen2.Text == CONST_OpenText)
            {
                //打开扫描枪
                if (this._ScannerControler == null)
                {
                    this.ShowMsg("扫码枪控制对象尚未创建。");
                    return;
                }
                if (this._ScannerControler._Scanner2 != null && this._ScannerControler._Scanner2.Running)
                {
                    this.ShowMsg("扫描枪2已经开启。");
                    return;
                }
                string sErr;
                if (!this._ScannerControler.StartListenning2(out sErr))
                {
                    this.ShowMsg(sErr);
                    return;
                }
                this.btOpen2.Text = CONST_CloseText;
            }
            else
            {
                //关闭扫描枪
                if (this._MainForm == null)
                {
                    this.ShowMsg("窗口对象为空！");
                    return;
                }
                string strErr;
                if (!this._MainForm.IsScanner2AllowStop(out strErr)) return;
                if (this._ScannerControler == null || this._ScannerControler._Scanner2 == null) return;
                if (this._ScannerControler._Scanner2.Running)
                {
                    if (!this._ScannerControler._Scanner2.StopListenning(out strErr)) return;
                }
                this.btOpen2.Text = CONST_OpenText;
            }
            BindScannerStyle();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BindScannerStyle();
        }
        public void RereshReceivedScanner1Data(string sData)
        {
            this.richTextBox1.AppendText(sData + "\r\n");
        }
        public void RereshReceivedScanner2Data(string sData)
        {
            this.richTextBox2.AppendText(sData + "\r\n");
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this._MainForm.IsFormScannerDebugOpened = false;
            base.OnClosing(e);
        }

        private void btSend1_Click(object sender, EventArgs e)
        {
            if (this._ScannerControler == null || this._ScannerControler._Scanner1 == null)
            {
                this.ShowMsg("扫描枪对象尚未初始化。");
                return;
            }
            frmSendText frm = new frmSendText();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (this._ScannerControler._Scanner1.SendText(frm._SelectedText))
                RereshReceivedScanner1Data("发送数据:" + frm._SelectedText);
        }

        private void btSend2_Click(object sender, EventArgs e)
        {
            if (this._ScannerControler == null || this._ScannerControler._Scanner2 == null)
            {
                this.ShowMsg("扫描枪对象尚未初始化。");
                return;
            }
            frmSendText frm = new frmSendText();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (this._ScannerControler._Scanner2.SendText(frm._SelectedText))
                RereshReceivedScanner2Data("发送数据:" + frm._SelectedText);
        }
    }
}
