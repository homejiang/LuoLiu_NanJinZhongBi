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
    public partial class frmMKBuildingDetail : Common.frmBase
    {
        /// <summary>
        /// 获取正在插装的模块信息
        /// </summary>
        public static bool OpenMKBuildingData()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM Assemble_RealMK");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(null, ex, "数据加载");
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有正在插装的数据！");
                return false;
            }
            frmMKBuildingDetail frm = new frmMKBuildingDetail();
            frm.BindData(dt.Rows[0]);
            frm.ShowDialog();
            return true;
        }
        public frmMKBuildingDetail()
        {
            InitializeComponent();
            this.dgvList.AutoGenerateColumns = false;
        }
        public bool BindData(DataRow dr)
        {
            
            this.tbMKCode.Text = dr["Code"].ToString();
            this.tbBatCnt.Text = dr["BatCnt"].ToString();
            this.tbAsbcnt.Text = dr["AsbCnt"].ToString();
            this.tbTestCode.Text = dr["TestCode"].ToString();
            return this.BindDetail( dr["ResultTable"].ToString(), dr["BatterysTable"].ToString());
        }
        private bool BindDetail(string sResultTable,string sBatterysTable)
        {
            string strSql = string.Format(@"SELECT A.AsbSort,A.SortID,A.Times, B.CaoIndex,C.SN,A.MyCode,dbo.GetQualityView(B.Quality) as QualityView,b.DianZu,b.TestIndex,b.V,b.NGCase,b.Times as times1
                    FROM Assemble_RealMkBatterys A LEFT JOIN {0} B ON B.MyCode=A.MyCode
                    LEFT JOIN {1} C ON C.Code=A.MyCode
                    order by a.AsbSort asc,a.SortID asc", sResultTable, sBatterysTable);
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
        }
    }
}
