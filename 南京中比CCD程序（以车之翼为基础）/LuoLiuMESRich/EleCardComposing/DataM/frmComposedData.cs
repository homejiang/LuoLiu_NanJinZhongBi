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

namespace EleCardComposing.DataM
{
    public partial class frmComposedData : Common.frmBase
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
        #region 窗口字段
        public string _MzCode = string.Empty;
        /// <summary>
        /// 指定的任务单号
        /// </summary>
        private string _PactDetailGuid = string.Empty;
        /// <summary>
        /// 保护板编号
        /// </summary>
        private string _PcbCode = string.Empty;
        #endregion
        public frmComposedData()
        {
            InitializeComponent();
            this.dgvList.AutoGenerateColumns = false;
            this._Printer = new MyPrinter();
            this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
        }
        #region 加载数据
        private bool BindData()
        {
            if (this.Binding())
            {
                this.BindPactInfo(this._PactDetailGuid);
                this.BindPCBData(this._PcbCode);
                this.BindItems();
                
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
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC EleCardComposing_DataM_GetDataInfo '{0}'", this._MzCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                this.ShowErr(ex.Message);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowErr("传入的托盘编号\"" + this._MzCode + "\"不存在或已经被删除了。");
                return false;
            }
            DataRow dr = dt.Rows[0];
            this.tbCode.Text = dr["MzCode"].ToString();
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
            this._PcbCode = dr["PcbCode"].ToString();
            this._MzCode = dr["MzCode"].ToString();
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
        private bool BindPCBData(string sPcbCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC EleCardComposing_GetPCBInfo'{0}'", sPcbCode.Replace("'", "''")));
            }
            catch (Exception ex)
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
            this.tbPCBCode.Text = sPcbCode;
            this.tbPcbInfo.Text = dr["Info"].ToString();
            if (dr["Quality"].ToString() == "1")
            {
                SetPCBResultStyle(1);
            }
            else if (dr["Quality"].ToString() == "2")
            {
                SetPCBResultStyle(2);
            }
            else
            {
                SetPCBResultStyle(0);
            }
            return true;
        }
        private void SetPCBResultStyle(int iQuality)
        {
            //设置监听状态
            string strText;
            Color cBk;
            Color cFore;
            if (iQuality==1)
            {
                strText = "检测合格";
                cBk = Color.Lime;
                cFore = Color.Black;
            }
            else if (iQuality==2)
            {
                strText = "不合格";
                cBk = Color.Maroon;
                cFore = Color.White;
            }
            else
            {
                strText = "------";
                cBk = Color.White;
                cFore = Color.Black;
            }
            if (this.labOfcListenStatus.Text != strText)
                this.labOfcListenStatus.Text = strText;
            if (this.labOfcListenStatus.BackColor != cBk)
                this.labOfcListenStatus.BackColor = cBk;
            if (this.labOfcListenStatus.ForeColor != cFore)
                this.labOfcListenStatus.ForeColor = cFore;
        }
        #endregion
        #region 电池包数据
        private bool BindItems()
        {
            string strSql = string.Format("SELECT * FROM V_EleCardComposing_DataM_Mks WHERE Code='{0}'", this._MzCode.Replace("'", "''"));
            
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
        #endregion
        #region 打印相关
        #region 打印
        MyPrinter _Printer = null;
        private void _Printer_PrintFinishedNotice(string sTuoPanCode, bool blSucessful, string sErr)
        {
            MyPrinter.PrintFinishedCallback call = new MyPrinter.PrintFinishedCallback(PrinterNotice);
            try
            {
                this.Invoke(call, new object[] { sTuoPanCode, blSucessful, sErr });
            }
            catch (Exception ex)
            {

            }
        }
        private void PrinterNotice(string sTuoPanCode, bool blSucessful, string sErr)
        {
            if (blSucessful)
            {
                
            }
            else
            {
                //此时要弹出重新打印的对话框
                frmPrintFaild frm = new frmPrintFaild(sTuoPanCode, sErr);
                frm.ShowDialog(this);
            }
        }
        #endregion
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
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.EleCardComposing);
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
                this.BllDAL.EleCardComposingDelete(this._MzCode, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "解除锁装");
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "操作失败，原因未知。";
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
            Common.OutputExcel.frmOutputExcel.OutputExcel(EleCardComposing.Config.ComposingOutputName, this._MzCode);
        }

        private void tsbdGradeView_Click(object sender, EventArgs e)
        {

        }

        private void tsbMkView_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbPrinting_Click(object sender, EventArgs e)
        {

            if (this._Printer == null)
            {
                this.ShowMsg("打印机对象为空！");
                return;
            }
            this._Printer.Printing(this._MzCode);
        }

        private void tsbPrinterSet_Click(object sender, EventArgs e)
        {
            MySetting.frmPrinterSetting frm = new MySetting.frmPrinterSetting();
            frm.ShowDialog(this);
        }
    }
}
