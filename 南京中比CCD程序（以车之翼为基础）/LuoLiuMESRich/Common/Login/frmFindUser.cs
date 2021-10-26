using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace Common.Login
{
    public partial class frmFindUser : Common.frmBaseEdit
    {
        public frmFindUser()
        {
            InitializeComponent();
        }
        public string _SelUserCode = string.Empty;
        private void frmFindUser_Load(object sender, EventArgs e)
        {
            this.dgvList.AutoGenerateColumns = false;
            BindData();
        }
        #region ´¦Àíº¯Êý
        private bool BindData()
        {
            string strSql = "SELECT UserCode,UserName FROM sys_users where isnull(Terminated,0)=0";
            if (this.textBox1.Text != string.Empty)
            {
                strSql += string.Format(" AND UserName like '%{0}%'", this.textBox1.Text.Replace("'", "''"));
            }
            strSql += " order by username asc";
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
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

        private void button1_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                this.BindData();
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            _SelUserCode = dt.DefaultView[e.RowIndex]["UserCode"].ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}