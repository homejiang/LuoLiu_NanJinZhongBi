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
    public partial class frmYdyDesignList : Common.frmBaseList
    {
        public frmYdyDesignList()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.AutoExe _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.AutoExe BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new LuoLiuMES.BLLDAL.AutoExe();
                return _dal;
            }
        }
        #endregion
        public string _DesignGuid = string.Empty;
        #region 处理函数
        private bool BindData()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM AutoExe_User_Designs WHERE isnull(UserCode,'')='' ORDER BY DesignName asc");
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
            this.FormColse();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            AutoExe.frmUserForms frm = new LuoLiuMES.AutoExe.frmUserForms();
            frm._UserCode = Common.CurrentUserInfo.UserCode;
            frm._YuDingYi = true;
            frm.ShowDialog(this);
            this.BindData();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中一行数据。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row;
            frmUserForms frm = new frmUserForms();
            frm._UserCode = Common.CurrentUserInfo.UserCode;
            frm.PrimaryValue = dr["GUID"].ToString();
            frm._YuDingYi = true;
            frm.ShowDialog(this);
            this.BindData();
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中一行数据。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (!this.IsUserConfirm("您确定要移除选中的数据吗？")) return;
            DataRow dr = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.DelUserDesign(dr["GUID"].ToString(), out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindData();
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[e.RowIndex].Row;
            frmUserForms frm = new frmUserForms();
            frm.PrimaryValue = dr["GUID"].ToString();
            frm._YuDingYi = true;
            frm.ShowDialog(this);
            this.BindData();
        }
    }
}