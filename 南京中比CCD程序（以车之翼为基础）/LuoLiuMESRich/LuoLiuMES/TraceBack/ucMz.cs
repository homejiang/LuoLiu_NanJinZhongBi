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

namespace LuoLiuMES.TraceBack
{
    public partial class ucMz : UserControl
    {
        public frmTraceBackRich _MainForm = null;
        public ucMz()
        {
            InitializeComponent();
            this.dgvList.AutoGenerateColumns = false;
        }
        public string _Code = string.Empty;
        private string _PactDetailGuid = string.Empty;
        private void ShowErr(string sMsg)
        {

        }
        public bool BindData(string sCode)
        {
            this._Code = string.Empty;
            if (!this.Binding(sCode))
            {
                this.SetEmpty();
                return false;
            }
            else
            {
                this.BindPactInfo();
                this.BindProcess();
                return true;
            }
        }
        private bool Binding(string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format(@"SELECT A.Code,B.Spec,C.VersionNo,D.DetailGuid,a.PcbCode
                    FROM Produce_SFG2 A LEFT JOIN BOM_Product B ON B.GUID=A.BOMGuid
                    LEFT JOIN BOM_Sys_Version C ON C.ID=B.VersionID
                    LEFT JOIN Pact_ProducePlan D ON D.GUID=A.PlanGuid
                    WHERE A.Code='{0}'", sCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowErr(string.Format("电池包\"{0}\"数据不存在或已经被删除。", sCode));
                return false;
            }
            DataRow dr = dt.Rows[0];
            this._Code = dr["Code"].ToString();
            this._PactDetailGuid = dr["DetailGuid"].ToString();
            this.tbCode.Text = this._Code;
            this.tbBOMSpec.Text = string.Format("{0}，版本号:{1}", dr["Spec"], dr["VersionNo"]);
            this.tbPcbCode.Text = dr["PcbCode"].ToString();
            return true;
        }
        private bool BindProcess()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format(@"SELECT * FROM V_Produce_SFG2_Process_4Track WHERE Code='{0}' order by EndTime", this._Code.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = dt;
            return true;
        }
        private bool BindPactInfo()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT dbo.Assign_GetPactInfo('{0}')", this._PactDetailGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                this.ShowErr(ex.Message);
                SetErrText_PactInfo();
                return false;
            }
            this.tbPactInfo.Text = dt.Rows[0][0].ToString();
            return true;
        }
        private void SetErrText_PactInfo()
        {
            this.tbPactInfo.Text = "error";
        }
        private void SetEmpty()
        {
            string sText = "?";
            this.tbCode.Text = sText;
            this.tbBOMSpec.Text = sText;
            this.tbPactInfo.Text = sText;
            this.tbPcbCode.Text = sText;
            this.dgvList.DataSource = null;
        }
        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (this.dgvList.Columns[e.ColumnIndex].Name == this.dgvcolLink.Name)
            {
                if (this._MainForm == null) return;
                DataTable dt = this.dgvList.DataSource as DataTable;
                if (dt == null) return;
                DataRow dr = dt.DefaultView[e.RowIndex].Row;
                this._MainForm.OpenProcessData(2, dr["ProcessCode"].ToString(), dr["Code"].ToString(), dr["GUID"].ToString());
            }
        }
    }
}
