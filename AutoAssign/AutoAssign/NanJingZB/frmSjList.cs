using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.NanJingZB
{
    public partial class frmSjList : Common.frmBase
    {
        public frmSjList()
        {
            InitializeComponent();
            this.dtpStart.Value = DateTime.Now.AddMonths(-1);
            this.dgvSet.AutoGenerateColumns = false;
            this.myDataGridView1.AutoGenerateColumns = false;
        }
        private bool BindList()
        {
            string strSql = $"SELECT * FROM NanJingZB_SjRecord WHERE StartTime>='{this.dtpStart.Value.ToString("yyyy-MM-dd 00:00:00")}' and EndTime<'{this.dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd 00:00:00")}' order by StartTime desc";
            try
            {
                this.dgvSet.DataSource = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch(Exception ex)
            {
                this.ShowMsg(ex.Message);
                return false;
            }
            return true;
        }
        private bool BindResult()
        {
            string sGuid = string.Empty;
            if(this.dgvSet.SelectedRows.Count>0)
            {
                DataTable dtList = this.dgvSet.DataSource as DataTable;
                if(dtList!=null)
                {
                    sGuid = dtList.DefaultView[this.dgvSet.SelectedRows[0].Index].Row["GUID"].ToString();
                }
            }
            string strSql = $"SELECT * FROM V_NanJingZB_SJRecordResult WHERE guid='{sGuid.Replace("'", "''")}'";
            try
            {
                this.myDataGridView1.DataSource = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return false;
            }
            return true;
        }
        private void dgvSet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSet_SelectionChanged(object sender, EventArgs e)
        {
            BindResult();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (BindList())
                this.ShowMsgRich("刷新成功");
        }

        private void frmSjList_Load(object sender, EventArgs e)
        {
            BindList();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            string sGuid = string.Empty;
            if (this.dgvSet.SelectedRows.Count > 0)
            {
                DataTable dtList = this.dgvSet.DataSource as DataTable;
                if (dtList != null)
                {
                    sGuid = dtList.DefaultView[this.dgvSet.SelectedRows[0].Index].Row["GUID"].ToString();
                }
            }
            if(sGuid.Length>0)
            {
                if (this.dgvSet.SelectedRows.Count == 0) return;
                if (!this.IsUserConfirm("您确定要删除选中行吗？")) return;
                List<string> listSql = new List<string>();
                listSql.Add($"DELETE FROM NanJingZB_SJRecordResult WHERE GUID='{sGuid}'");
                listSql.Add($"DELETE FROM NanJingZB_SJRecordSet WHERE GUID='{sGuid}'");
                listSql.Add($"DELETE FROM NanJingZB_SjRecord WHERE GUID='{sGuid}'");
                try
                {
                    Common.CommonDAL.DoSqlCommand.DoSql(listSql);
                }
                catch (Exception ex)
                {
                    this.ShowMsg(ex.Message);
                    return;
                }
                this.BindList();
                dgvSet_SelectionChanged(null, null);
            }
        }
    }
}
