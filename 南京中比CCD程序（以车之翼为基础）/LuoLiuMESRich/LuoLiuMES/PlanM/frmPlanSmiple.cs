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
    public partial class frmPlanSmiple : Common.frmBase
    {
        #region 窗口常量
        Color PlanGrideUnSelectedBackColor = Color.White;
        Color PlanGrideSelectedBackColor = Color.Yellow;
        #endregion
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
                    _dal = new BLLDAL.PlanM();
                return _dal;
            }
        }
        #endregion
        public frmPlanSmiple()
        {
            InitializeComponent();
        }
        #region 处理函数
        private bool Perinit()
        {
            this.dgvDetail.AutoGenerateColumns = false;
            this.dgvPactDetail.AutoGenerateColumns = false;
            return true;
        }
        private void ShowLog(string sLog)
        {
            if (this.labMsg.ForeColor != Color.Blue)
                this.labMsg.ForeColor = Color.Blue;
            this.labMsg.Text = sLog;
        }
        #endregion
        #region 计划信息
        /// <summary>
        /// 加载未完成的计划明细
        /// </summary>
        /// <param name="sPlanGuid">选中行的GUID</param>
        /// <returns></returns>
        private bool BindPlan(string sPlanGuid)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("EXEC Plan_GetActivePlanDetail");
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "BindPlans");
                return false;
            }
            this.dgvDetail.DataSource = dt;
            for (int i = 0; i < dt.DefaultView.Count; i++)
            {
                if (sPlanGuid.Length == 0 || string.Compare(dt.DefaultView[i].Row["GUID"].ToString(), sPlanGuid, true) != 0)
                {
                    //此时要价格列表底色设置成正常颜色
                    if (this.dgvDetail.Rows[i].DefaultCellStyle != null && this.dgvDetail.Rows[i].DefaultCellStyle.BackColor != PlanGrideUnSelectedBackColor)
                        this.dgvDetail.Rows[i].DefaultCellStyle.BackColor = PlanGrideUnSelectedBackColor;
                }
                else
                {
                    //此时要价格列表底色设置成黄颜色
                    if (this.dgvDetail.Rows[i].DefaultCellStyle != null && this.dgvDetail.Rows[i].DefaultCellStyle.BackColor != PlanGrideSelectedBackColor)
                        this.dgvDetail.Rows[i].DefaultCellStyle.BackColor = PlanGrideSelectedBackColor;
                }
            }
            return true;
        }
        #endregion
        #region 生产订单信息
        private bool BindPact(string sPactCode, string sPactDetailGuid)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM V_Plan_PactDetail WHERE PactCode='{0}'", sPactCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "BindPact");
                return false;
            }
            this.dgvPactDetail.DataSource = dt;
            for (int i = 0; i < dt.DefaultView.Count; i++)
            {
                if (sPactDetailGuid.Length == 0 || string.Compare(dt.DefaultView[i].Row["GUID"].ToString(), sPactDetailGuid, true) != 0)
                {
                    //设置为非选中
                    if (this.dgvPactDetail.Rows[i].Selected)
                        this.dgvPactDetail.Rows[i].Selected = false;
                }
                else
                {
                    //设置为选中
                    if (!this.dgvPactDetail.Rows[i].Selected)
                        this.dgvPactDetail.Rows[i].Selected = true;
                }
            }
            this._PactCode = sPactCode;
            return true;
        }
        public bool AddPlan()
        {
            if (this.dgvPactDetail.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中任务单明细！");
                return false;
            }
            DataTable dt = this.dgvPactDetail.DataSource as DataTable;
            DataRow dr = dt.DefaultView[this.dgvPactDetail.SelectedRows[0].Index].Row;
            string strGuid = dr["GUID"].ToString();
            object objQty;
          
                //此时是按盘统计的，则总长度不用上传，直接会在后台计算
                int iQty;
                if (!int.TryParse(this.tbPlanQty.Text, out iQty))
                {
                    this.ShowMsg("请输入计划盘数！");
                    return false;
                }
                if (iQty <= 0)
                {
                    this.ShowMsg("计划盘数必须是大于0的整数！");
                    return false;
                }
                objQty = iQty;
            DateTime strDate = DateTime.Parse(string.Format("{0}", this.dtpDate.Value.ToString("yyyy-MM-dd")));

            string strNewPlanGuid;
            string strLog;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.AddPlan(strGuid, objQty, strDate, out strNewPlanGuid, out strLog, out iReturnValue, out strMsg);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "BllDALAddPlan");
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0) strMsg = "计划添加失败，原因未知！";
                this.ShowMsg(strMsg);
                return false;
            }
            //此时添加成功，则显示日志
            this.ShowLog(strLog);
            this.BindPlan(strNewPlanGuid);
            this.BindPact(this._PactCode, dr["GUID"].ToString());
            return true;
        }
        private void btPactBind_Click(object sender, EventArgs e)
        {
            if (this.tbPactCode.Text.Length == 0)
            {
                this.ShowMsg("请输入订单编号！");
                return;
            }
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.CheckAllowPlan(this.tbPactCode.Text, out iReturnValue, out strMsg);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "If Allow be planed");
                return;
            }
            if(iReturnValue!=1)
            {
                if (strMsg.Length == 0) strMsg = "任务单号校验失败，原因未知！";
                this.ShowMsg(strMsg);
                return;
            }
            this.btTrue.Enabled = this.BindPact(this.tbPactCode.Text, string.Empty);
            _SelectedPactDetailRowIndex = -1;
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("你没有新建权限，如有需要请联系管理员开放该权限。");
                return;
            }
            if (this.AddPlan())
            {
                this.tbPlanQty.Clear();

            }
        }
        /// <summary>
        /// 当前已加载的订单编号
        /// </summary>
        string _PactCode = string.Empty;
        int _SelectedPactDetailRowIndex = -1;
        private void dgvPactDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvPactDetail.SelectedRows.Count == 0) return;
            if (this.dgvPactDetail.SelectedRows[0].Index == this._SelectedPactDetailRowIndex) return;
            DataTable dt = this.dgvPactDetail.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[this.dgvPactDetail.SelectedRows[0].Index].Row;
            if (this.tbPlanQty.ReadOnly)
                this.tbPlanQty.ReadOnly = false;
          
            
            this._SelectedPactDetailRowIndex = this.dgvPactDetail.SelectedRows[0].Index;
        }
        #endregion
        private void frmPlanSmiple_Load(object sender, EventArgs e)
        {
            if (!this.Perinit() || !this.BindPlan(string.Empty))
            {
                this.FormState = Common.MyEnums.FormStates.None;
            }
            else
            {
                this.FormState = Common.MyEnums.FormStates.Edit;
            }

        }

        private void tbPactCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            this.btPactBind_Click(null, null);
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            //刷新数据，读取当前选中的行的数据
            string sPlanGuid = string.Empty;
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt != null)
            {
                for(int i = 0; i < this.dgvDetail.Rows.Count; i++)
                {
                    if(this.dgvDetail.Rows[i].DefaultCellStyle!=null && this.dgvDetail.Rows[i].DefaultCellStyle.BackColor==PlanGrideSelectedBackColor)
                    {
                        sPlanGuid = dt.DefaultView[i].Row["GUID"].ToString();
                        break;
                    }
                }
            }
            if (this.BindPlan(sPlanGuid))
            {
                this.ShowMsgRich("刷新成功！");
            }
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            //移除选中计划
            string sSelectedPlanGuid = string.Empty;
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt != null)
            {
                for (int i = 0; i < this.dgvDetail.Rows.Count; i++)
                {
                    if (this.dgvDetail.Rows[i].DefaultCellStyle != null && this.dgvDetail.Rows[i].DefaultCellStyle.BackColor == PlanGrideSelectedBackColor)
                    {
                        sSelectedPlanGuid = dt.DefaultView[i].Row["GUID"].ToString();
                        break;
                    }
                }
            }
            //移除计划
            List<int> listRows = Common.CommonFuns.GetSelectedRows(this.dgvDetail);
            if (listRows.Count == 0)
            {
                this.ShowMsg("请选中要删除的行！");
                return;
            }
            if (!this.IsUserConfirm("您确定要删除选中的" + listRows.Count.ToString() + "行数据吗？")) return;
            int iReturnValue;
            string strMsg;
            bool blUpdated = false;
            foreach(int row in listRows)
            {
                try
                {
                    this.BllDAL.RemovePlan(dt.DefaultView[row].Row["GUID"].ToString(), out iReturnValue, out strMsg);
                }
                catch(Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "Removeplan");
                    continue;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg.Length == 0) strMsg = "计划明细移除失败，原因未知！";
                    this.ShowMsg(strMsg);
                    continue;
                }
                if (!blUpdated) blUpdated = true;
            }
            if (blUpdated)
                this.BindPlan(sSelectedPlanGuid);
        }

        private void tsbModifyQty_Click(object sender, EventArgs e)
        {//修改计划数
            if (this.dgvDetail.SelectedRows.Count == 0) return;
            if (this.dgvDetail.SelectedRows.Count > 1)
            {
                this.ShowMsg("此操作每次只限一行。");
                return;
            }
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            string strGuid = dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row["GUID"].ToString();
            frmModifyPlanDetail frm = new frmModifyPlanDetail();
            frm.PlanGuid = strGuid;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            //加载数据
            this.BindPlan(strGuid);
            return;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.dgvDetail.SelectedRows.Count == 0) return;
            if (this.dgvDetail.SelectedRows.Count > 1)
            {
                this.ShowMsg("此操作每次只限一行。");
                return;
            }
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            string strGuid = dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row["GUID"].ToString();
            frmModifyPlanTime frm = new frmModifyPlanTime();
            frm.PlanGuid = strGuid;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            //加载数据
            this.BindPlan(strGuid);
            return;
        }
    }
}
