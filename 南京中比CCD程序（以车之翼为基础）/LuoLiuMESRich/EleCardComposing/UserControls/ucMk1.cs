using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorService;

namespace EleCardComposing.UserControls
{
    public partial class ucMk1 : UserControl
    {
        #region 窗体数据连接实例
        private BLLDAL.Composing _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Composing BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Composing();
                return _dal;
            }
        }
        #endregion 
        public frmMain _MainForm = null;
        public ucMk1()
        {
            InitializeComponent();
        }
        #region 公共属性及函数
        public void Clear()
        {
            this._MkCode = string.Empty;
            this.tbMkCode.Clear();
            this.tbInfo.Clear();
            this._PactCode = string.Empty;
            this._PlanGuid = string.Empty;
            this._MKCount = 0;
        }
        public void SetFocus()
        {
            this.timer1.Interval = 200;
            this.timer1.Enabled = true;
        }
        public bool Check(out string sErr)
        {
            if (this.tbMkCode.Text.Length > 0)
            {
                if (string.Compare(this.tbMkCode.Text, this._MkCode, true) != 0)
                {
                    sErr = "模块" + this.tbMkCode.Text + "还未加载，请先点击加载按钮。";
                    return false;
                }
            }
            sErr = string.Empty;
            return true;
        }
        public string GetMKCode()
        {
            return this.tbMkCode.Text;
        }
        public string _PactCode = string.Empty;
        public string _PlanGuid = string.Empty;
        string _MkCode = string.Empty;
        public int _MKCount = 0;
        #endregion
        
        private bool BindData(string sMkCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC EleCardComposing_GetMkCountByMkCode '{0}'", sMkCode.Replace("'", "''")));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Columns.Contains("ErrMsg"))
            {
                this.ShowMsg(dt.Rows[0]["ErrMsg"].ToString());
                return false;
            }
            //此时要校验数据是是否可以
            DataRow dr = dt.Rows[0];
            string strPact = dr["PactCode"].ToString();
            if (this._MainForm != null)
            {
                if (!this._MainForm.CheckIsPactSame(strPact, this)) return false;
            }
            //显示数据
            this.tbInfo.Text = dr["Info"].ToString();
            this._PactCode = strPact;
            this._PlanGuid = dr["PlanGuid"].ToString();
            this._MKCount = dr["MKCnt"].Equals(DBNull.Value) ? 0 : int.Parse(dr["MKCnt"].ToString());
            return true;
        }
        private void btBindDxDetail_Click(object sender, EventArgs e)
        {
            if (this.tbMkCode.Text.Length == 0) return;
            if (!Common.CurrentUserInfo.CheckLogin()) return;
            if (!BindData())
            {
                this.timer1.Interval = 200;
                this.timer1.Enabled = true;
            }
        }
        private bool BindData()
        {
            if (this._MainForm != null)
            {
                if (!this._MainForm.CheckIsReInputMKCode(this.tbMkCode.Text, this)) return false;
            }
            //显示领用，因为这里有可能还未领用了，因为现在还不清楚点焊机是否正常导入MES，待正常导入点焊机的话，该存储过程可以去除
            if (!this.TakeTuoPan(this.tbMkCode.Text)) return false;
            if (this.BindData(this.tbMkCode.Text))
            {
                this._MkCode = this.tbMkCode.Text;
                if (this._MainForm != null)
                    this._MainForm.MkInfoBindSucessful(this, this._MKCount, this._PlanGuid, this._PactCode);
                return true;
            }
            return false;
        }
        private bool TakeTuoPan(string sTuoPan)
        {
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.TakeTuoPan(sTuoPan, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0) strMsg = "托盘领用失败，原因未知！";
                this.ShowMsg(strMsg);
                return false;
            }
            return true;
        }
        public void ShowMsg(string sMsg)
        {
            MessageBox.Show(sMsg, "模块扫描信息提示");
        }

        private void btDxDetail_Click(object sender, EventArgs e)
        {

        }

        private void tbMkCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
            {
                this.btBindDxDetail_Click(sender, null);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.tbMkCode.Focus();
            this.tbMkCode.SelectAll();
        }
    }
    public delegate void CheckOtherMK(out bool blSucessful); 
}
