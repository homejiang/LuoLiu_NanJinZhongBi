using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES.Boxing
{
    public partial class frmItemDetail : Common.frmBase
    {
        string _Code = string.Empty;
        public frmItemDetail(string sCode)
        {
            InitializeComponent();
            this._Code = sCode;
            this.myDataGridView1.AutoGenerateColumns = false;
        }
        private bool BindData()
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
            foreach(DataRowView drv in dt.DefaultView)
            {
                if(!drv.Row["StructValue"].Equals(DBNull.Value))
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
        private void frmItemDetail_Load(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}
