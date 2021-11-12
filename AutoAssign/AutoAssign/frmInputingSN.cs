using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoAssign.JPSEntity;
using static AutoAssign.JPSEntity.ReadSNListen;

namespace AutoAssign
{
    public partial class frmInputingSN : Common.frmBase
    {
        const string BTText_Stop= "终止导入";
        const string BTText_Close= "关闭";
        ReadSNListen _ReadSNListen = null;
        bool _AllowClose = false;
        public frmInputingSN(List<RemoteSNEntity> datas)
        {
            InitializeComponent();
            this.button1.Text = BTText_Stop;
            _ReadSNListen = new ReadSNListen(this);
            _ReadSNListen.InputSNNotice += _ReadSNListen_InputSNNotice;
            _ReadSNListen.StopedListenNotice += _ReadSNListen_StopedListenNotice;
            string sErr;
            if(!_ReadSNListen.StartListenning(datas,out sErr))
            {
                this.ShowErr(sErr);
                return;
            }
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = datas.Count;
            this.progressBar1.Value = 0;
        }

        private void _ReadSNListen_StopedListenNotice(int iStopCase)
        {
            this.button1.Text = BTText_Close;
        }

        private void _ReadSNListen_InputSNNotice(bool blCompelted, bool blSucessful, string sErr, int iTotalCnt, int iInputedCnt)
        {
            ShowJinDu(iTotalCnt, iInputedCnt);
            if (iInputedCnt > this.progressBar1.Maximum)
                iInputedCnt = this.progressBar1.Maximum;
            if (this.progressBar1.Value != iInputedCnt)
                this.progressBar1.Value = iInputedCnt;
            if (blCompelted)
            {
                if (blSucessful)
                {
                    this.button1.Text = BTText_Close;
                }
                else
                {
                    this.ShowErr(sErr);
                }
            }
        }
        private void ShowJinDu(int iTotalCnt, int iInputedCnt)
        {
            this.labJinDu.Text = $"{iInputedCnt}/{iTotalCnt}";
        }

        private void ShowErr(string sErr)
        {
            this.labJinDu.Text = sErr;
            this.labJinDu.ForeColor = Color.Red;
            this.button1.Text = BTText_Close;
        }

        private void frmInputingSN_Load(object sender, EventArgs e)
        {

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!this._AllowClose)
                e.Cancel = true;
            base.OnClosing(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.button1.Text==BTText_Stop)
            {
                //终止线程
                if (this._ReadSNListen == null) return;
                this._ReadSNListen.StopListenning(0);
            }
            else
            {
                this._AllowClose = true;
                this.Close();
            }
        }
    }
}
