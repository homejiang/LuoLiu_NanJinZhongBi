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

namespace AutoAssign.DataM
{
    public partial class frmMKDetail : Common.frmBase
    {
        string _MKCode = string.Empty;
        public frmMKDetail(string sCode)
        {
            InitializeComponent();
            this.dgvList.AutoGenerateColumns = false;
            this._MKCode = sCode;
        }
        private bool BindData()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM Assemble_MK WHERE Code='{0}'", this._MKCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "数据加载");
                return false;
            }
            if(dt.Rows.Count==0)
            {
                return false;
            }
            DataRow dr = dt.Rows[0];
            this.tbMKCode.Text = dr["Code"].ToString();
            this.tbBatCnt.Text = dr["BatCnt"].ToString();
            this.tbAsbcnt.Text = dr["AsbCnt"].ToString();
            this.tbTestCode.Text = dr["TestCode"].ToString();
            return this.BindDetail(dr["MKBatterysTable"].ToString(), dr["ResultTable"].ToString(), dr["BatterysTable"].ToString());
        }
        private bool BindDetail(string sMKBatterysTable,string sResultTable,string sBatterysTable)
        {
            string strSql = string.Format(@"SELECT A.AsbSort,A.SortID,A.Times, B.CaoIndex,C.SN,A.MyCode,dbo.GetQualityView(B.Quality) as QualityView,b.DianZu,b.TestIndex,b.V,b.NGCase,b.Times as times1
                    FROM {0} A LEFT JOIN {1} B ON B.MyCode=A.MyCode
                    LEFT JOIN {2} C ON C.Code=A.MyCode
                    WHERE A.Code='{3}' order by a.AsbSort asc,a.SortID asc", sMKBatterysTable, sResultTable, sBatterysTable, this._MKCode.Replace("'", "''"));
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "数据加载");
                return false;
            }
            this.dgvList.DataSource = dt;
            return true;
        }

        private void frmMKDetail_Load(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
