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
    public partial class frmSelYdy : Common.frmBaseList
    {
        public frmSelYdy()
        {
            InitializeComponent();
        }
        public string _DesignGuid = string.Empty;
        #region 处理函数
        private bool BindData()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM AutoExe_User_Designs WHERE isnull(UserCode,'')='' AND GUID<>'{0}' ORDER BY DesignName asc"
                    , _DesignGuid.Replace("'", "''")));
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
    }
}