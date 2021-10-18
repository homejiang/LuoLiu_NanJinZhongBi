using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.ExpFuns
{
    public partial class frmClearSN : Common.frmBase
    {
        #region 常量
        const string BTText_Start="开始清理";
        const string BTText_Stop="终止";
        const string BTText_Restart = "重新开始";
        #endregion
        JPSEntity.SNClear _SNClear = null;
        public frmClearSN()
        {
            InitializeComponent();
            this.panContainer.Visible = false;
            _SNClear = new JPSEntity.SNClear(this, JPSConfig.MacNo, false);
            _SNClear.RemoteSNCopyFinishedNotice += _SNClear_RemoteSNCopyFinishedNotice;
        }
        int _MaxValue = 0;
        int _Value = 0;
        public void Init(int iMaxValue)
        {
            this._MaxValue = iMaxValue;
            this.labProgress.Width = 0;
            this.labProgress.Text = string.Empty;
            this._Value = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Text != BTText_Stop)
            {
                DateTime det = DateTime.Now.AddDays(0 - (int)numericUpDown1.Value);
                string sEndTime = det.ToString("yyyy-MM-dd 00:00:01");
                string strErr;
                int iTotalCount;
                if (!JPSEntity.SNClear.GetDataCount(sEndTime, out iTotalCount, out strErr))
                {
                    this.ShowMsg(strErr);
                    return;
                }
                if (!_SNClear.StartListenning(sEndTime, out strErr))
                {
                    this.ShowMsg(strErr);
                    return;
                }
                this.Init(iTotalCount);
                this.panContainer.Visible = true;
                this.button1.Text = BTText_Stop;
            }
            else
            {
                //终止
                if (_SNClear != null)
                    _SNClear.Running = false;
            }
        }

        private void _SNClear_RemoteSNCopyFinishedNotice(bool blStop, bool blSucessfully, int iCount)
        {
            //更新当前进度
            if (blSucessfully)
            {
                this.AddValue(iCount);
                if (blStop)
                {
                    SetStatus(ClearStates.Compeleted);
                }
                else
                {
                    SetStatus(ClearStates.Clearing);
                }
            }
            else
            {
                if (blStop)
                    SetStatus(ClearStates.Error);
            }
        }
        public void SetStatus(ClearStates state)
        {
            string strStatuText;
            if (state == ClearStates.Error)
            {
                strStatuText = BTText_Restart;
            }
            else if (state == ClearStates.Clearing)
            {
                strStatuText = BTText_Stop;
                
            }
            else if (state == ClearStates.Compeleted)
            {
                strStatuText = BTText_Start;
            }
            else
            {
                //此时为.Compeleted
                strStatuText = "？？";
            }
            if (this.button1.Text != strStatuText)
                this.button1.Text = strStatuText;
        }
        public void AddValue(int iAddValue)
        {
            this._Value += iAddValue;
            if (_MaxValue == 0)
            {
                this.labProgress.Width = this.panContainer.Width;
                this.labProgress.Text = "100%";
                return;
            }
            string strText;
            int iWidth;
            if (this._Value >= this._MaxValue)
            {
                strText = "100%";
                iWidth = this.panContainer.Width;
            }
            else
            {
                decimal dec = (decimal)this._Value / (decimal)this._MaxValue;
                strText = dec.ToString("#########0%");
                dec = dec * (decimal)this.panContainer.Width;
                iWidth = (int)dec;
                if (iWidth > this.panContainer.Width)
                    iWidth = this.panContainer.Width;
            }
            //计算进度条长度
            this.labProgress.Width = iWidth;
            if (iWidth > 10)
                this.labProgress.Text = strText;
        }

        private void SetNotice()
        {
            DateTime det = DateTime.Now.AddDays(0 - (int)numericUpDown1.Value);
            this.labNotice.Text = string.Format("{0}前的都清除掉",det.ToString("yyyy年MM月dd日00点00分01秒"));
        }
        private void frmClearSN_Load(object sender, EventArgs e)
        {
            this.button1.Text = BTText_Start;
        }
        public enum ClearStates
        {
            Error=0,
            Compeleted=1,
            Clearing=2
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SetNotice();
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            SetNotice();
        }
    }
}
