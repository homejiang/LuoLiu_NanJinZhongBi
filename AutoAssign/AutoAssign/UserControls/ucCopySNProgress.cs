using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.UserControls
{
    public partial class ucCopySNProgress : UserControl
    {
        public JPSEntity.RemoteSNCopy _RemoteSNCopy = null;
        const string BTText_Stop = "终止";
        const string BTText_Start = "开始";
        const string BTText_ReCopy = "重新复制";
        short _MacNo = 0;
        public CopyStates _State = CopyStates.Free;
        public string Title
        {
            get
            {
                return this.labMac.Text;
            }
            set
            {
                if (this.labMac.Text != value)
                    this.labMac.Text = value;
            }
        }
        public ucCopySNProgress()
        {
            InitializeComponent();
            this.Init(0);
        }
        public void SetIP(Form mainForm, string sIP,short iMacNo)
        {
            Common.SqlServerCommand sqlCmd = new Common.SqlServerCommand(string.Format(@"Server={0}\JPS2008;Database=LuoLiuAssigner;User=sa;Password=zxp;Connect Timeout=120;", sIP));
            _RemoteSNCopy = new JPSEntity.RemoteSNCopy(mainForm, sqlCmd, iMacNo, false);
            _RemoteSNCopy.RemoteSNCopyFinishedNotice += _RemoteSNCopy_RemoteSNCopyFinishedNotice;
            this._MacNo = iMacNo;
            this.Title = string.Format("设备 {0}", iMacNo);
        }

        private void _RemoteSNCopy_RemoteSNCopyFinishedNotice(bool blStop, bool blSucessfully, int iCount)
        {
            //更新当前进度
            if(blSucessfully)
            {
                this.AddValue(iCount);
                if (blStop)
                {
                    SetStatus(CopyStates.Compeleted);
                }
                else
                {
                    SetStatus(CopyStates.Copying);
                }
            }
            else
            {
                SetStatus(CopyStates.Error);
            }
        }

        int _MaxValue = 0;
        int _Value = 0;
        public void Init(int iMaxValue)
        {
            this._MaxValue = iMaxValue;
            this.labProgress.Width = 0;
            this.labProgress.Text = string.Empty;
            this._Value = 0;
            SetStatus(CopyStates.Free);
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
                decimal dec =  (decimal)this._Value / (decimal)this._MaxValue;
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
        public void SetStatus(CopyStates state)
        {
            string strStatuText;
            string strBtText;
            Color cFore;
            bool blEnabled;
            if(state==CopyStates.Free)
            {
                strStatuText = "准备中";
                cFore = Color.Blue;
                strBtText = BTText_Start;
                blEnabled = true;
            }
            else if (state == CopyStates.Copying)
            {
                strStatuText = "复制中...";
                cFore = Color.Blue;
                strBtText = BTText_Stop;
                blEnabled = true;
            }
            else if (state == CopyStates.Error)
            {
                strStatuText = "出错";
                cFore = Color.Red;
                strBtText =BTText_ReCopy;
                blEnabled = true;
            }
            else if (state == CopyStates.UnConnected)
            {
                strStatuText = "网络不通";
                cFore = Color.Red;
                strBtText = BTText_Start;
                blEnabled = false;
            }
            else if (state == CopyStates.UnDefinitional)
            {
                strStatuText = "未定义";
                cFore = Color.Blue;
                strBtText = BTText_Start;
                blEnabled = false;
            }
            else if (state == CopyStates.Connnecting)
            {
                strStatuText = "连接中...";
                cFore = Color.Black;
                strBtText = BTText_Start;
                blEnabled = false;
            }
            else
            {
                //此时为.Compeleted
                strStatuText = "已完成";
                cFore = Color.Blue;
                strBtText = BTText_ReCopy;
                blEnabled = true;
            }
            if (this.button.Text != strBtText)
                this.button.Text = strBtText;
            if (this.button.Enabled != blEnabled)
                this.button.Enabled = blEnabled;
            if (this.labStatus.ForeColor != cFore)
                this.labStatus.ForeColor = cFore;
            if (this.labStatus.Text != strStatuText)
                this.labStatus.Text = strStatuText;
        }
        public void StartCopy()
        {
            if (!this.button.Enabled) return;
            if (this.button.Text != BTText_Start && this.button.Text != BTText_ReCopy) return;
            button_Click(null, null);
        }
        private void button_Click(object sender, EventArgs e)
        {
            if(this.button.Text== BTText_Start || this.button.Text==BTText_ReCopy)
            {
                //此时为开始
                if (_RemoteSNCopy == null) return;
                //读取当前最大ID值
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MAX(LocalID) AS ID FROM SN1 WHERE MacNo={0}",this._MacNo));
                }
                catch(Exception ex)
                {
                    this.ShowMsg(ex.Message);
                    return;
                }
                long lID;
                if (dt.Rows.Count == 0 || dt.Rows[0]["ID"].Equals(DBNull.Value))
                    lID = 0;
                else lID = long.Parse(dt.Rows[0]["ID"].ToString());

                DataTable dtCount = null;
                try
                {
                    dtCount = this._RemoteSNCopy._SqlCmd.GetDateTable(string.Format("SELECT COUNT(*) FROM SN WHERE ID>{0}", lID));
                }
                catch (Exception ex)
                {
                    this.ShowMsg(ex.Message);
                    return;
                }
                int iCnt = int.Parse(dtCount.Rows[0][0].ToString());
                this.Init(iCnt);
                string strErr;
                if(!_RemoteSNCopy.StartListenning(lID,out strErr))
                {
                    this.ShowMsg(strErr);
                    return;
                }
                //此时已经成功开启拷贝了
                this.SetStatus(CopyStates.Copying);
            }
            else
            {
                if(this._RemoteSNCopy!=null && this._RemoteSNCopy.Running)
                {
                    string strErr;
                    if(!this._RemoteSNCopy.StopListenning(out strErr))
                    {
                        this.ShowMsg(strErr);
                        return;
                    }
                    this.SetStatus(CopyStates.Compeleted);
                }
            }
        }
        public void ShowMsg(string sMsg)
        {
            MessageBox.Show(sMsg);
        }

        private void labStatus_DoubleClick(object sender, EventArgs e)
        {
            if(this._RemoteSNCopy!=null && this._RemoteSNCopy._ErrMsg.Length>0)
            {
                frmErrMsg frm = new frmErrMsg();
                frm.ErrMsg = this._RemoteSNCopy._ErrMsg;
                frm.Show();
            }
        }
    }
    public enum CopyStates
    {
        /// <summary>
        /// 空闲中
        /// </summary>
        Free = 0,
        /// <summary>
        /// 拷贝中
        /// </summary>
        Copying = 1,
        /// <summary>
        /// 出错
        /// </summary>
        Error = 2,
        /// <summary>
        /// 已完成
        /// </summary>
        Compeleted = 3,
        /// <summary>
        /// 网络不同
        /// </summary>
        UnConnected = 4,
        /// <summary>
        /// 未定义
        /// </summary>
        UnDefinitional = 5,
        /// <summary>
        /// 联网中
        /// </summary>
        Connnecting=6
    }
}
