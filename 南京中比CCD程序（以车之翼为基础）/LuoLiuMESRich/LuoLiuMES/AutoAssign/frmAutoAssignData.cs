using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoLiuMES.AutoAssign
{
    public partial class frmAutoAssignData : Common.frmBase
    {

        #region 窗体数据连接实例
        private BLLDAL.AutoAssign _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.AutoAssign BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.AutoAssign();
                return _dal;
            }
        }
        #endregion
        #region 窗口字段
        public string _MKCode = string.Empty;
        /// <summary>
        /// 指定的任务单号
        /// </summary>
        private string _PactDetailGuid = string.Empty;
        private string _DxTable = string.Empty;
        private string _TuoPanCode = string.Empty;
        #endregion
        public frmAutoAssignData()
        {
            InitializeComponent();
            this.dgvList.AutoGenerateColumns = false;
            this.dgvOtherMk.AutoGenerateColumns = false;
        }
        #region 加载数据
        private bool BindData()
        {
            if (this.Binding())
            {
                this.BindPactInfo(this._PactDetailGuid);
                this.BindItems();
                this.BindOtherMks();
                return true;
            }
            else
            {
                this.FormState = Common.MyEnums.FormStates.None;
                return false;
            }
        }
        private bool Binding()
        {
            //记载已创建的箱号
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Assign_GetDataInfo '{0}'", this._MKCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                this.ShowErr(ex.Message);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowErr("传入的托盘编号\"" + this._MKCode + "\"不存在或已经被删除了。");
                return false;
            }
            DataRow dr = dt.Rows[0];
            this.tbCode.Text = this._MKCode;
            this.tbFinishTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["FinishedTime"], "yyyy-MM-dd HH:mm");
            this.tbOperator.Text = dr["OperatorName"].ToString();
            this.tbMac.Text = dr["MacName"].ToString();
            this.tbStation.Text = dr["StationName"].ToString();
            this.tbRangeV.Text = dr["RangeV"].ToString();
            this.tbRangeR.Text = dr["RangeR"].ToString();
            this.tbCnt.Text = dr["DxCnt"].ToString();
            this.tbBOMSpec.Text = dr["BOMDesc"].ToString();
            this.tbStateView.Text = dr["StateView"].ToString();
            this._PactDetailGuid = dr["PactDetailGuid"].ToString();
            this._DxTable = dr["DxTable"].ToString();
            this._TuoPanCode = dr["TuoPan"].ToString();
            return true;
        }
        private bool BindPactInfo(string sPactDetail)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT dbo.Assign_GetPactInfo('{0}')", sPactDetail.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                this.ShowErr(ex.Message);
                return false;
            }
            this.tbPactInfo.Text = dt.Rows[0][0].ToString();
            if (this._PactDetailGuid != sPactDetail)
                this._PactDetailGuid = sPactDetail;
            return true;
        }
        #endregion
        #region 电芯数据
        private bool BindItems()
        {
            string strSql;
            if(this._DxTable.Length==0)
            {
                strSql = string.Format("SELECT * FROM Produce_Assign_Dx WHERE TuoPan='{0}' ORDER BY DxSn ASC", this._MKCode.Replace("'", "''"));
            }
            else
            {
                strSql = string.Format("SELECT * FROM LuoLiuMESDynamicTable.dbo.{0} WHERE TuoPan='{1}' ORDER BY ID ASC", this._DxTable, this._TuoPanCode.Replace("'", "''"));
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = dt;
            return true;
        }
        private bool BindOtherMks()
        {
            string strSql;
            strSql = string.Format("exec Assign_GetDataInfo_OtherMKs '{0}'", this._MKCode.Replace("'", "''"));
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvOtherMk.DataSource = dt;
            return true;
        }
        #endregion

        private void ShowErr(string sMsg)
        {
            this.ShowMsg(sMsg);
        }

        private void frmBoxedData_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (this.FormState == Common.MyEnums.FormStates.None)
            {
                this.ShowMsg("当前窗口状态不能执行操作。");
                return;
            }
            if (this.FormState == Common.MyEnums.FormStates.Readonly)
            {
                this.ShowMsg("当前窗口状态为只读，不能执行该操作。");
                return;
            }
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.MkManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("您没有删除模块的权限！");
                return;
            }
            if (!this.IsUserConfirm("您确定要删除当前模块吗？")) return;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.DelteTuoPan(this._MKCode, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "DeleteMK");
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "删除失败，原因未知。";
                this.ShowMsg(strMsg);
            }
            //删除成功，则要关闭
            this.FormColse();
        }
        
        private void tsbdRefresh_Click(object sender, EventArgs e)
        {
            if(this.BindItems())
            {
                this.ShowMsgRich("刷新成功");
                return;
            }
        }

        private void tsbOutputExcel_Click(object sender, EventArgs e)
        {
            Common.OutputExcel.frmOutputExcel.OutputExcel(MESConfig.MkConfig.MkOuptutTypeName, this._MKCode);
        }

        private void tsbdGradeView_Click(object sender, EventArgs e)
        {

        }
    }
}
