using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace LuoLiuMES.PactM
{
    public partial class frmModifyRemark : Common.frmBaseEdit
    {
        public frmModifyRemark()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.PactM _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.PactM BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new LuoLiuMES.BLLDAL.PactM();
                return _dal;
            }
        }
        #endregion
        #region 公共属性
        public string PactDetailGuid = string.Empty;
        #endregion
        #region 处理函数
        private bool Perinit()
        {
            return true;
        }
        private bool BindData(string sDetailGuid)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM V_Pact_Detail WHERE GUID='{0}'"
                    , sDetailGuid));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.DefaultView.Count == 0)
            {
                this.ShowMsg("您选中的明细不存在或已经被删除。");
                return false;
            }
            DataRow dr = dt.Rows[0];
            this.tbInfo.Text = string.Format("[订单号：{0}][数量：{1}][BOM规格:{2}][交货期：{3}][备注：{4}]"
                , dr["PactCode"]
                , Common.CommonFuns.FormatData.GetStringByDecimal(dr["Qty"], "#########0"), dr["BomSpec"]
                , Common.CommonFuns.FormatData.GetStringByDateTime(dr["DeliveryDate"], "yyyy-MM-dd"), dr["Remark"]);
            this.tbOrgRemark.Text = dr["Remark"].ToString();
            return true;
        }
        #endregion

        private void frmDetailAdd_Load(object sender, EventArgs e)
        {
            if (this.PactDetailGuid == string.Empty) return;
            if (!Perinit()) return;
            this.BindData(this.PactDetailGuid);
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            string strMark = this.tbNewRemark.Text;
            string strSql = string.Format(" EXEC [Update_Pact_Detail_Remark] '{0}','{1}','{2}','{3}','{4}'"
               , strMark.Replace("'", "''"), this.tbOrgRemark.Text.ToString(), PactDetailGuid.Replace("'", "''"), Common.CurrentUserInfo.UserCode, Common.CurrentUserInfo.UserName);
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.ShowMsg("操作成功。");
            this.DialogResult = DialogResult.OK;
        }

        private void linkNewMark_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //PactsManage.GroupPacts.frmSelPDRemark frm = new PactsManage.GroupPacts.frmSelPDRemark();
            //frm.MultiSelected = false;
            //if (DialogResult.OK != frm.ShowDialog(this))
            //    return;
            //if (frm.SelectedData.Count == 0) return;
            //this.tbNewRemark.Text = frm.SelectedData[0].Remark.ToString();
        }
    }
}