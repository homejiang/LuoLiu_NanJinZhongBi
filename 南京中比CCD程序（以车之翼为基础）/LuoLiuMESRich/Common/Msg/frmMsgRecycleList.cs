using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace Common.Msg
{
    public partial class frmMsgRecycleList : Common.frmBaseEdit
    {
        public frmMsgRecycleList()
        {
            InitializeComponent();
        }
        #region 处理函数
        private bool BindData()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandLog.GetDateTable(string.Format("EXEC [Msg_GetUserRecycleMsgList] '{0}','{1}'"
                    , Common.CurrentUserInfo.UserCode.Replace("'", "''"), this.tstSearchValue.Text.Replace("'", "''")));
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

        private void frmMsgList_Load(object sender, EventArgs e)
        {
            this.dgvList.AutoGenerateColumns = false;
            BindData();
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void tstSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                tsbSearch_Click(null, null);
        }
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            long lTemp;
            if (!long.TryParse(dt.DefaultView[e.RowIndex]["MsgID"].ToString(), out lTemp))
                return;
            Msg.frmMsgInfo frm = new frmMsgInfo();
            frm._ID = lTemp;
            frm.Show();
        }
    }
}