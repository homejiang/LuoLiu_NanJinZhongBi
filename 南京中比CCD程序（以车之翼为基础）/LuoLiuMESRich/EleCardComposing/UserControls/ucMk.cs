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
    public partial class ucMk : UserControl
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
        frmMain _MainForm = null;
        public ucMk()
        {
            InitializeComponent();
        }
        #region 公共函数
        public void Clear()
        {
            this._MkCode = string.Empty;
            this.tbMkCode.Clear();
            this.tbRangeR.Clear();
            this.tbRangeV.Clear();
            this.tbDxCnt.Clear();
        }
        #endregion
        private bool BindDx(string sMkCode)
        {
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = string.Format("SELECT * FROM Produce_SFG1 WHERE Code='{0}'",
                    sMkCode.Replace("'", "''"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Produce_Assign_TuoPan"));
            strSql = string.Format("SELECT Min(DianZu) AS DianZuMin,MAX(DianZu) AS DianZuMax,MIN(V) AS VMin,MAX(V) AS VMax FROM Produce_Assign_Dx WHERE TuoPan='{0}'",
                    sMkCode.Replace("'", "''"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "tongJi"));
            DataSet ds;
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = ds.Tables["Produce_Assign_TuoPan"];
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("模块条码不存在！");
                return false;
            }
            DataRow dr = ds.Tables["tongJi"].Rows[0];
            string sMin = dr["DianZuMin"].Equals(DBNull.Value) ? "NULL" : Common.CommonFuns.FormatData.GetStringByDecimal(dr["DianZuMin"], "#########0.#####");
            string sMax = dr["DianZuMax"].Equals(DBNull.Value) ? "NULL" : Common.CommonFuns.FormatData.GetStringByDecimal(dr["DianZuMax"], "#########0.#####");
            this.tbRangeR.Text = string.Format("{0}~{1}", sMin, sMax);
            sMin = dr["VMin"].Equals(DBNull.Value) ? "NULL" : Common.CommonFuns.FormatData.GetStringByDecimal(dr["VMin"], "#########0.#####");
            sMax = dr["VMax"].Equals(DBNull.Value) ? "NULL" : Common.CommonFuns.FormatData.GetStringByDecimal(dr["VMax"], "#########0.#####");
            this.tbRangeV.Text = string.Format("{0}~{1}", sMin, sMax);
            this.tbDxCnt.Text = ds.Tables["Produce_Assign_Dx"].DefaultView.Count.ToString();
            return true;
        }
        public string _MkCode = string.Empty;
        private void btBindDxDetail_Click(object sender, EventArgs e)
        {
            if (this.tbMkCode.Text.Length == 0) return;
            if (!Common.CurrentUserInfo.CheckLogin()) return;
            if(this._MainForm!=null)
            {
               // if (!this._MainForm.CheckMKInputCode(this.tbMkCode.Text, this)) return;
            }
            //显示领用，因为这里有可能还未领用了，因为现在还不清楚点焊机是否正常导入MES，待正常导入点焊机的话，该存储过程可以去除
            if (!this.TakeTuoPan(this.tbMkCode.Text)) return;
            if (this.BindDx(this.tbMkCode.Text))
            {
                this._MkCode = this.tbMkCode.Text;
            }
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
            if (e.KeyValue != 13) return;
            btBindDxDetail_Click(null, null);
        }
    }
}
