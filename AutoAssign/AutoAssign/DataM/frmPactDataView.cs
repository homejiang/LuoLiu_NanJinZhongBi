using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.DataM
{
    public partial class frmPactDataView : Common.frmBase
    {
        string _Guid = string.Empty;
        public frmPactDataView(string sGuid)
        {
            InitializeComponent();
            this._Guid = sGuid;
        }
        private bool BindPactInfo(string sGuid)
        {
            if (sGuid.Length == 0)
            {
                this.richTextBox1.Clear();
                return true;
            }
            int iQty;
            string strErr;
            
            if (!JPSEntity.SendMesControler.GetCompeletedMKQty(sGuid, out iQty, out strErr))
            {
                this.ShowMsg(strErr);
                return false;
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandRemoteMES.GetDateTable(string.Format("SELECT * FROM V_Pact_Detail_4AutoAssign WHERE GUID='{0}'", sGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.richTextBox1.Clear();
            }
            else
            {
                DataRow dr = dt.Rows[0];
                decimal decPlan = dr["PlanQty"].Equals(DBNull.Value) ? 0M : decimal.Parse(dr["PlanQty"].ToString());
                if (string.Compare(dr["FxRatioCode"].ToString(), "sys002", true) == 0)
                {
                    decPlan = decPlan * 2M / 3M;
                }
                int iPlanQty = (int)decPlan;
                if ((decPlan - (decimal)iPlanQty) > 0M)
                    iPlanQty++;
                this.richTextBox1.Text = string.Format("任务单:{0}，下单时间:{1}，交货期:{2}，生产计划:{3}；\r\n成品BOM:{4}，版本号:{5}；\r\n模块BOM:{6}，版本号:{7},计划总量:{8}，已完成量:{9}，剩余量:{10}；\r\n电芯型号:{11}，电芯规格：{12}；", 
                    dr["PactCode"],Common.CommonFuns.FormatData.GetStringByDateTime(dr["CreateTime"],"yyyy-MM-dd HH:mm")
                    , Common.CommonFuns.FormatData.GetStringByDateTime(dr["DeliveryDate"], "yyyy-MM-dd"), dr["GUID"]
                    , dr["ChengPinBOMSpec"], dr["ChengPinBOMVersion"]
                    , dr["MkBOMSpec"], dr["MkBOMVersion"], iPlanQty, iQty, (iPlanQty- iQty)
                    , dr["DianXinVirCode"], dr["DianXinBzq"]);
            }
            return true;
        }
        
        private void frmPactDataView_Load(object sender, EventArgs e)
        {
            this.BindPactInfo(this._Guid);
        }
    }
}
