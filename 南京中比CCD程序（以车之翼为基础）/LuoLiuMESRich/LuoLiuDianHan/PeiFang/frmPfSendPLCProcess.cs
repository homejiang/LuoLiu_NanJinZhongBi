using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoLiuDianHan.PeiFang
{
    public partial class frmPfSendPLCProcess : Common.frmBase
    {
        public frmPfSendPLCProcess(DataTable dtPoints, HanJieOPC.OPCHelperPointSetting opchelper)
        {
            InitializeComponent();
            this.labProcessText.Text = "---";
            this._Points = dtPoints;
            _ReadControler = new Communication.ReadPeiFangSend2PLc(this, opchelper);
            _ReadControler.DataSendPlcNotce += _ReadControler_DataSendPlcNotce;
            _ReadControler.SendFinishedNotice += _ReadControler_SendFinishedNotice;
            this._OpcHelper = opchelper;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
        }
        #region 窗口变量
        DataTable _Points = null;
        Communication.ReadPeiFangSend2PLc _ReadControler = null;
        HanJieOPC.OPCHelperPointSetting _OpcHelper = null;
        private bool _Stoped = false;
        #endregion
        #region 消息处理
        frmErrMsg merrForm = null;
        public frmErrMsg _ErrForm
        {
            get
            {
                if (this.merrForm == null || this.merrForm.IsDisposed)
                    this.merrForm = new frmErrMsg();
                return this.merrForm;
            }
        }
        public void ShowErr(string sMsg)
        {
            if (this._ErrForm.ErrMsg != sMsg)
                this._ErrForm.ErrMsg = sMsg;
            if (!this._ErrForm.Visible)
                this._ErrForm.Show();
        }
        private void ShowLog(string sLog)
        {

        }
        #endregion
        #region 线程事件
        private void _ReadControler_SendFinishedNotice(bool blCompeleted, int RowCnt)
        {
            this.labProcessText.Text = "写入完毕！";
            this.button1.Text = "关闭";
            this._Stoped = true;
        }

        private void _ReadControler_DataSendPlcNotce(int iStart, int iSendCnt)
        {
            if (this._Points == null) return;
            decimal iTotal = this._Points.DefaultView.Count;
            decimal dec = (decimal)iStart / iTotal;
            this.labProcessText.Text = dec.ToString("#########0%");
            dec = dec * 100M;
            if (dec > 100M) dec = 100M;
            this.progressBar1.Value = (int)dec;
            //int iPIndex ;
            //if (iStart > 10000 && iStart <= 20000)
            //    iPIndex = iStart - 10000;
            //else if (iStart > 20000)
            //    iPIndex = iStart - 20000;
            //else iPIndex = iStart;
            //decimal iTotal = this._Points.DefaultView.Count;
            //int iSent = iPIndex + iSendCnt - 1;
            //if (iTotal == 0M) return;
            //decimal dec = (decimal)iSent / iTotal;
            //this.labProcessText.Text = dec.ToString("#########0%");
            //this.progressBar1.Value = int.Parse((dec * 100M).ToString("#########0"));
        }
        #endregion
        #region 重写函数
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!this._Stoped)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }
        #endregion

        private void frmPfSendPLCProcess_Load(object sender, EventArgs e)
        {
            linkLabel1_LinkClicked(null, null);
            this.timer1.Interval = 200;
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            string strErr;
            if (!this._ReadControler.StartListenning(this._Points, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
        }

        private void linkLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMyLogB.ShowMyLog(string.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this._Stoped)
            {
                this.Close();
            }
            else
            {
                this._ReadControler.StopListenning();
                string strErr;
                if(!this._OpcHelper.SetWriteDoing(2,out strErr))
                {
                    this.ShowMsg(strErr);
                    return;
                }
                this.ShowMsgRich("终止成功");
                this._Stoped = true;
                this.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int iMax;
            if (!int.TryParse(this.tbMaxrow.Text, out iMax))
            {
                this.ShowMsg("请输入整数！");
                return;
            }
            this._ReadControler.MaxRowIndex = iMax;
        }
    }
}
