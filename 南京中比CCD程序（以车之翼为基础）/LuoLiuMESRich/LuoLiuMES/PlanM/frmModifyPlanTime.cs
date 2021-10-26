using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace LuoLiuMES.PlanM
{
    public partial class frmModifyPlanTime : Common.frmBaseEdit
    {
        public frmModifyPlanTime()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.PlanM _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.PlanM BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new LuoLiuMES.BLLDAL.PlanM();
                return _dal;
            }
        }
        #endregion
        #region 公共属性
        public string PlanGuid = string.Empty;
        #endregion
        #region 处理函数
        private bool BindData(string sPlanGuid)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM [V_Plan_PlanDetail] WHERE GUID='{0}'"
                    , sPlanGuid));
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
            this.tbInfo.Text = string.Format("[订单号：{0}][订单数量：{1}][计划数量:{2}][剩余量:{3}][BOM规格:{4}][交货期：{5}][备注：{6}][计划完成时间:{7}]"
                , dr["PactCode"]
                , Common.CommonFuns.FormatData.GetStringByDecimal(dr["Qty"], "#########0")
                , Common.CommonFuns.FormatData.GetStringByDecimal(dr["PlanProduceQty"], "#########0")
                , dr["RemainDesc"]
                , dr["BomSpec"]
                , Common.CommonFuns.FormatData.GetStringByDateTime(dr["DeliveryDate"], "yyyy-MM-dd")
                ,dr["Remark"]
                ,Common.CommonFuns.FormatData.GetStringByDateTime(dr["PlanTime"], "yyyy-MM-dd"));
            this.tbOrgDate.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["PlanTime"], "yyyy-MM-dd");
            this.dtpDate.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["PlanTime"], "yyyy-MM-dd");
            return true;
        }
        #endregion

        private void frmDetailAdd_Load(object sender, EventArgs e)
        {
            if (this.PlanGuid == string.Empty) return;
            this.BindData(this.PlanGuid);
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime strDate = DateTime.Parse(string.Format("{0}", this.dtpDate.Value.ToString("yyyy-MM-dd"))); ;
            string strSql = string.Format(" EXEC [Update_Plan_Detail_Date] '{0}','{1}','{2}','{3}','{4}'"
               , strDate.ToString(), this.tbOrgDate.Text.ToString(), this.PlanGuid.Replace("'", "''"), Common.CurrentUserInfo.UserCode, Common.CurrentUserInfo.UserName);

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
    }
}