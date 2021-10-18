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

namespace AutoAssign.DataM
{
    public partial class frmSendMsgList : Common.frmBase
    {
        long _StartID = 0;
        public frmSendMsgList(string sOrderNo)
        {
            InitializeComponent();
            this.ucRecordPage1.SetParentForm(this);
            this.dgvList.AutoGenerateColumns = true;
            if (sOrderNo.Length > 0)
                this.tbTestCode.Text = sOrderNo;
        }
        string _SqlFormat = "";
        private bool BindData()
        {
            string strWhere = "";
            if (this.tbTestCode.Text.Length > 0)
                strWhere += string.Format(" and Order_No='{0}'", this.tbTestCode.Text.Replace("'", "''"));
            if (this.tbTuoCode.Text.Length > 0)
                strWhere += string.Format(" and BoxBarCode='{0}'", this.tbTuoCode.Text.Replace("'", "''"));
            if (this.tbSnCode.Text.Length > 0)
                strWhere += string.Format(" and SFC like '%{0}%'", this.tbSnCode.Text.Replace("'", "''"));
            string strSql = "SELECT count(*) FROM IFDB.dbo.FST_PACK WHERE 1=1" + strWhere;
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
            this._SqlFormat = "SELECT T.* FROM(SELECT *,(ROW_NUMBER() over(order by Input_Time)) AS RowIndex FROM IFDB.dbo.FST_PACK WHERE 1=1 " + strWhere + " ) AS T WHERE T.RowIndex>={0} AND T.RowIndex<{1}";
            int iRecordCount = int.Parse(dt.Rows[0][0].ToString());
            
            this._StartID = 1;
            this.ucRecordPage1.InitPage(iRecordCount);//登记总行数
            if (iRecordCount == 0)
            {
                this.dgvList.DataSource = null;
                return true;
            }
            string strMsg;
            if (!this.ucRecordPage1.NextPage(out strMsg))
            {
                this.ShowMsg(strMsg);
                return false;
            }
            return true;
        }
        private void ucRecordPage1_GoToPage_Going(int iMinRowsIndex, int MaxRowsIndex)
        {
            //this._Sql4ReadRealData = "SELECT " + strCols + " FROM " + strT1 + " WHERE ID>={0} AND ID<{1} ORDER BY ID ASC";
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format(this._SqlFormat, this._StartID+iMinRowsIndex, this._StartID + MaxRowsIndex));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.dgvList.DataSource = dt;
        }

        private void frmSendMsgList_Load(object sender, EventArgs e)
        {
            //this.BindData();
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void toolStrip1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tbTuoCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13)
                tsbSearch_Click(null, null);
        }

        private void tbTestCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13)
                tsbSearch_Click(null, null);

        }

        private void tbSnCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13)
                tsbSearch_Click(null, null);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
