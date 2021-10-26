using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES.AutoExe
{
    public partial class frmSelUsers : Common.frmBaseList
    {
        public frmSelUsers()
        {
            InitializeComponent();
        }
        public string _DesignGuid = string.Empty;
        #region 处理函数
        private bool Perinit()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT distinct B.UserName FROM AutoExe_User_Designs A LEFT JOIN Sys_Users B ON B.UserCode=A.UserCode WHERE isnull(a.UserCode,'')<>'' order by B.UserName");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            foreach (DataRow dr in dt.Rows)
            {
                this.comUser.Items.Add(dr["UserName"].ToString());
            }
            return true;
        }
        private bool BindData()
        {
            DataTable dt;
            string strSql;
            if (this.comUser.Text != string.Empty)
                strSql = string.Format("SELECT A.GUID,A.DesignName,B.UserName FROM AutoExe_User_Designs A LEFT JOIN Sys_Users B ON B.UserCode=A.UserCode WHERE isnull(B.UserName,'') like '%{0}%' AND a.GUID<>'{1}' ORDER BY b.UserName asc,A.DesignName asc"
                    , this.comUser.Text.Replace("'", "''"), _DesignGuid.Replace("'", "''"));
            else strSql = string.Format("SELECT A.GUID,A.DesignName,B.UserName FROM AutoExe_User_Designs A LEFT JOIN Sys_Users B ON B.UserCode=A.UserCode WHERE isnull(A.UserCode,'')<>'' AND a.GUID<>'{0}' ORDER BY b.UserName asc,A.DesignName asc"
                    , _DesignGuid.Replace("'", "''"));
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

        private void frmUserDesignList_Load(object sender, EventArgs e)
        {
            this.dgvList.AutoGenerateColumns = false;
            this.Perinit();
            this.BindData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选择一行数据。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            _DesignGuid = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row["GUID"].ToString();
            this.DialogResult = DialogResult.OK;
        }
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            _DesignGuid = dt.DefaultView[e.RowIndex].Row["GUID"].ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void comUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                this.BindData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}