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

namespace LuoLiuMES.Boxing
{
    public partial class frmBoxedData : Common.frmBase
    {

        #region 窗体数据连接实例
        private BLLDAL.Boxing _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Boxing BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Boxing();
                return _dal;
            }
        }
        #endregion
        #region 窗口字段
        public string _Code = string.Empty;
        /// <summary>
        /// 可以装托数量
        /// </summary>
        private int _PlanQty = 0;
        /// <summary>
        /// 已经装托数量
        /// </summary>
        private int _BoxedQty = 0;
        /// <summary>
        /// 已装托的电池包净重，单位：kg
        /// </summary>
        private decimal _NetWeight = 0M;
        /// <summary>
        /// 纸箱类型代码
        /// </summary>
        private string _BoxType = string.Empty;
        /// <summary>
        /// 纸箱重量，单位：kg
        /// </summary>
        private decimal _BoxWeight = 0M;
        private string _BOMGuid = string.Empty;
        private string _MyType = string.Empty;
        private int _MyYear = 0;
        /// <summary>
        /// 指定的任务单号
        /// </summary>
        private string _PactDetailGuid = string.Empty;
        private int _State = 0;
        private string _Client = string.Empty;
        #endregion
        public frmBoxedData()
        {
            InitializeComponent();
            this.myDataGridView1.AutoGenerateColumns = false;
            this._Printer = new BoxPrinter();
            this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
        }
        #region 加载数据
        private bool BindData()
        {
            if (this.Binding())
            {
                this.BindPactInfo(this._PactDetailGuid);
                this.BindBoxType(this._BoxType);
                this.BindMyTypes(this._BOMGuid, this._MyType, this._MyYear);
                this.BindClient(this._Client);
                this.BindItems();
                this.SetBoxedStyle();
                this.SetFormStyle();
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
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM V_Boxing_Box WHERE Code='{0}'", this._Code.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                this.ShowErr(ex.Message);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowErr("传入的托盘编号\"" + this._Code + "\"不存在或已经被删除了。");
                return false;
            }
            DataRow dr = dt.Rows[0];
            this.tbCode.Text = dr["Code"].ToString();
            this.tbBoxType.Text = dr["TypeName"].ToString();
            this.tbOperator.Text = dr["UserName"].ToString();
            #region 读取已经装托的电池包
            DataTable dtCnt;
            try
            {
                dtCnt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format(@"SELECT  COUNT(*) AS CNT,SUM(C.StructValue) AS TotalWeight
                FROM Boxing_Detail A LEFT JOIN Produce_SFG3 B ON B.Code = A.ItemCode
                LEFT JOIN BOM_Product_Structure C ON C.ProGuid = B.BOMGuid AND C.StructGuid = 'PerKg'
                WHERE A.Code = '{0}'", this._Code.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                this.ShowErr(ex.Message);
                return false;
            }
            this._BoxedQty = int.Parse(dtCnt.Rows[0]["CNT"].ToString());
            this._NetWeight = dtCnt.Rows[0]["TotalWeight"].Equals(DBNull.Value) ? 0M : decimal.Parse(dtCnt.Rows[0]["TotalWeight"].ToString());
            #endregion
            this._BoxType = dr["BoxType"].ToString();
            this._PlanQty = dr["Qty"].Equals(DBNull.Value) ? 0 : int.Parse(dr["Qty"].ToString());
            this._BOMGuid = dr["BOMGuid"].ToString();
            this._MyType = dr["MyType"].ToString();
            this._MyYear = dr["MyYear"].Equals(DBNull.Value) ? 0 : int.Parse(dr["MyYear"].ToString());
            this._PactDetailGuid = dr["PactDetail"].ToString();
            this._Client = dr["Client"].ToString();
            int iState = dr["State"].Equals(DBNull.Value) ? 0 : int.Parse(dr["State"].ToString());
            if(iState==0)
            {
                this.tbStateView.Text = "装托中......";
            }
            else if (iState == 1)
            {
                this.tbStateView.Text = string.Format("已于{0}结束装托。", Common.CommonFuns.FormatData.GetStringByDateTime(dr["StateTime"], "yyyy-MM-dd HH:mm"));
            }
            else
            {
                this.tbStateView.Text = string.Format("未知状态(Status:{0})", iState);
            }
            this._State = iState;
            return true;
        }
        private bool BindPactInfo(string sPactDetail)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT dbo.Boxing_GetPactInfo('{0}')", sPactDetail.Replace("'", "''")));
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
        private bool BindBoxType(string sBoxType)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM JC_BoxType WHERE Code='{0}'", sBoxType.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                this.ShowErr(ex.Message);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowErr("传入的托盘类型\"" + sBoxType + "\"无效。");
                return false;
            }
            DataRow dr = dt.Rows[0];
            int iQty;
            if (!int.TryParse(dr["Qty"].ToString(), out iQty))
            {
                this.ShowMsg("当前托盘允许安装数量未定义！");
                return false;
            }
            this._PlanQty = iQty;
            this._BoxType = dr["Code"].ToString();
            this._BoxWeight = dr["MyWeight"].Equals(DBNull.Value) ? 0M : decimal.Parse(dr["MyWeight"].ToString());
            this.tbBoxType.Text = dr["TypeName"].ToString();
            return true;
        }
        private bool BindMyTypes(string sBom, string sMyType, int iMyYear)
        {
            DataTable dt;
            string sSpec = string.Empty;
            string sVersion = string.Empty;
            string sMyTypeName = string.Empty;
            if (sBom.Length > 0)
            {
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT A.Spec,B.VersionNo FROM BOM_Product A LEFT JOIN BOM_Sys_Version B ON B.ID=A.VersionID WHERE A.GUID='{0}'", sBom.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    this.ShowErr(ex.Message);
                    return false;
                }
                if (dt.Rows.Count == 0)
                {
                    this.ShowErr("传入的BOM结构标识不存在或已经被删除！");
                    return false;
                }
                DataRow dr = dt.Rows[0];
                sSpec = dr["Spec"].ToString();
                sVersion = dr["VersionNo"].ToString();
            }
            if (sMyType.Length > 0)
            {
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT CodeName FROM JC_PackTypeCode where Code='{0}'", sMyType.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    this.ShowErr(ex.Message);
                    return false;
                }
                if (dt.Rows.Count == 0)
                {
                    this.ShowErr("传入的产品类型不存在或已经被删除！");
                    return false;
                }
                DataRow dr = dt.Rows[0];
                sMyTypeName = dr["CodeName"].ToString();
            }
            string strText = string.Empty;
            if (sMyTypeName.Length > 0 || iMyYear > 0)
            {
                strText = "电池组类型：" + (sMyTypeName.Length == 0 ? "?" : sMyTypeName) + (iMyYear > 0 ? iMyYear.ToString() : "?");
            }
            if (sSpec.Length > 0)
            {
                if (strText.Length > 0) strText += "，";
                strText += string.Format("{0}，版本号:{1}", sSpec, sVersion);
            }
            //组合起来
            this.tbBOMSpec.Text = strText;
            this._BOMGuid = sBom;
            this._MyType = sMyType;
            this._MyYear = iMyYear;
            return true;
        }
        private bool BindClient(string sClient)
        {
            if (sClient.Length > 0)
            {
                DataTable dt;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select Code,VirCode from JC_Client WHERE Code='{0}'", sClient.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    this.ShowErr(ex.Message);
                    return false;
                }
                if (dt.Rows.Count == 0)
                {
                    this.ShowErr("传入的客户代码\"" + sClient + "\"无效。");
                    return false;
                }
                DataRow dr = dt.Rows[0];

                this._Client = dr["Code"].ToString();
                this.tbClient.Text = dr["VirCode"].ToString();
            }
            else
            {
                this._Client = string.Empty;
                this.tbClient.Clear();
            }
            return true;
        }
        private void SetBoxedStyle()
        {
            //int iBoxed;
            //if (this._Code.Length == 0)
            //    iBoxed = 0;
            //else iBoxed = this._BoxedQty;
            //设置样式
            this.labQty.Text = string.Format("{0}/{1}", this._BoxedQty, this._PlanQty);
            this.labMyWeight.Text = string.Format("净重:{0}kg，毛重:{1}kg", this._NetWeight.ToString("#########0.###"), (this._NetWeight + this._BoxWeight).ToString("#########0.###"));
        }
        private void SetFormStyle()
        {
            if(this._State==0)
            {
                this.tsbAudit.Text = "结束装托";
                this.tsbAudit.Image = global::LuoLiuMES.Properties.Resources.completed;
                this.tsbOutputExcel.Enabled = false;
            }
            else
            {
                this.tsbAudit.Text = "撤销[结束装托]";
                this.tsbAudit.Image = global::LuoLiuMES.Properties.Resources.Audited;
                this.tsbOutputExcel.Enabled = true;
            }
        }

        #endregion
        #region 电池包数据
        private bool BindItems()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * from V_Boxing_ItemDetail where Code='{0}'", _Code.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.myDataGridView1.DataSource = dt;
            Statistic(dt);
            return true;
        }
        private void Statistic(DataTable dt)
        {
            decimal deckg = 0M;
            int iDxCnt = 0;
            foreach (DataRowView drv in dt.DefaultView)
            {
                if (!drv.Row["StructValue"].Equals(DBNull.Value))
                {
                    deckg += decimal.Parse(drv.Row["StructValue"].ToString());
                }
                if (!drv.Row["DxCnt"].Equals(DBNull.Value))
                {
                    iDxCnt += int.Parse(drv.Row["DxCnt"].ToString());
                }
            }
            this.labStatistic.Text = string.Format("电池包 {0}个，电芯总数 {1}节，总净重 {2}kg"
                , dt.DefaultView.Count, iDxCnt, deckg.ToString("#########0.###"));
            //
        }
        #endregion
        #region 打印
        BoxPrinter _Printer = null;
        private void _Printer_PrintFinishedNotice(string sTuoPanCode, bool blSucessful, string sErr, string sArg)
        {
            BoxPrinter.PrintFinishedCallback call = new BoxPrinter.PrintFinishedCallback(PrinterNotice);
            try
            {
                this.Invoke(call, new object[] { sTuoPanCode, blSucessful, sErr, sArg });
            }
            catch (Exception ex)
            {

            }
        }
        private void PrinterNotice(string sTuoPanCode, bool blSucessful, string sErr, string sArg)
        {
            if (blSucessful)
            {
                this.ShowMsgRich("标签已打印");
            }
            else
            {
                //此时要弹出重新打印的对话框
                frmPrintFaild frm = new frmPrintFaild(sTuoPanCode, sErr);
                frm.ShowDialog(this);
            }
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

            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.Boxing);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("您没有删除托盘的权限！");
                return;
            }
            if (!this.IsUserConfirm("您确定要删除当前托盘吗？")) return;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.DelteBox(this._Code, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "DeleteData");
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

        private void tsbAudit_Click(object sender, EventArgs e)
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

            if (this._State==0)
            {
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.Boxing);
                if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                {
                    this.ShowMsg("您没有该操作的权限！");
                    return;
                }
                if (this._BoxedQty < this._PlanQty)
                {
                    if (!this.IsUserConfirm("当前托盘还未装托完成，您确定结束本次装托吗？")) return;
                }
                int iReturnValue;
                string strMsg;
                try
                {
                    this.BllDAL.Compeleted(this._Code, out iReturnValue, out strMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg.Length == 0)
                        strMsg = "操作失败，原因未知！";
                    this.ShowMsg(strMsg);
                    return;
                }
                this.BindData();
            }
            else
            {
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.BoxingCancelCompeleted);
                if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                {
                    this.ShowMsg("您没有该操作的权限！");
                    return;
                }
                if (!this.IsUserConfirm("您确定要撤销吗？")) return;
                int iReturnValue;
                string strMsg;
                try
                {
                    this.BllDAL.CancelCompeleted(this._Code, out iReturnValue, out strMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg.Length == 0)
                        strMsg = "操作失败，原因未知！";
                    this.ShowMsg(strMsg);
                    return;
                }
                this.BindData();
            }
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
            if (!IsCompeleted(this._Code)) return;
            Common.OutputExcel.frmOutputExcel.OutputExcel(MESConfig.BoxingConfig.OuptutTypeName, this._Code);
        }
        private bool IsCompeleted(string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT State FROM Boxing_Box where Code='{0}'", sCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("托盘\"" + sCode + "\"不存在或已经被删除。");
                return false;
            }
            if (dt.Rows[0]["State"].ToString() != "1")
            {
                this.ShowMsg("托盘\"" + sCode + "\"还未结束装托，不能导出数据。");
                return false;
            }
            return true;
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (this._Code.Length == 0)
            {
                this.ShowMsg("托盘编号为空");
                return;
            }
            this._Printer.Printing(this._Code);
        }
    }
}
