using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;
namespace AutoAssign.AutoCode
{
    public partial class frmAutoCode : frmBase
    {
        public frmAutoCode()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.AutoCode _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.AutoCode BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new AutoAssign.BLLDAL.AutoCode();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            this.dgvList.AutoGenerateColumns = false;
            return true;
        }
        private bool BindData()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSqls = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT ModuleCode,ModuleName FROM Sys_Module WHERE isnull(IsAutoCode,0)=1 ORDER BY ModuleCode";
            listSqls.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_Module"));
            strSql = "SELECT A.*,B.ModuleName FROM Sys_AutoCode A LEFT JOIN Sys_Module B ON A.ModuleCode=B.ModuleCode ORDER BY A.ModuleCode";
            listSqls.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_AutoCode"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSqls);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataRow[] drs;
            foreach (DataRow dr in ds.Tables["Sys_Module"].Rows)
            {
                drs = ds.Tables["Sys_AutoCode"].Select("ModuleCode='" + dr["ModuleCode"].ToString() + "'");
                if (drs.Length == 0)
                {
                    DataRow drNew = ds.Tables["Sys_AutoCode"].NewRow();
                    drNew["ModuleCode"] = dr["ModuleCode"];
                    drNew["ModuleName"] = dr["ModuleName"];
                    ds.Tables["Sys_AutoCode"].Rows.Add(drNew);
                }
            }
            this.dgvList.DataSource = ds.Tables["Sys_AutoCode"];
            this.DataSource = ds;
            return true;
        }
        private void RowAddText(string strAddText)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            string strTmp = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row["CodeRule"].ToString();
            strTmp += strAddText;
            dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row["CodeRule"] = strTmp;
        }
        #endregion
        #region 窗体事件
        private void frmAutoCode_Load(object sender, EventArgs e)
        {
            //判断权限
            //如果当前窗体未设置状态，则校验权限
            
            this.PerInit();
            this.BindData();
        }
        public override bool CheckClose()
        {
            if (this.DataSource == null) return true;
            if (this.DataSource.Tables["Sys_AutoCode"].GetChanges() != null && DialogResult.Yes != MessageBox.Show(this, "数据尚未保存，请问要离开吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return false;
            return base.CheckClose();
        }
        #endregion
        #region 窗体控件事件
        private void btyyyy_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            this.RowAddText("[yyyy]");
        }

        private void btyy_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            this.RowAddText("[yy]");
        }

        private void btmm_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            this.RowAddText("[MM]");
        }

        private void btdd_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            this.RowAddText("[dd]");
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (this.DataSource.Tables["Sys_AutoCode"].GetChanges() == null)
                return;
            try
            {
                this.BllDAL.Save(this.DataSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.ShowMsgRich("保存成功。");
            this.BindData();
        }
        private void btClear_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row["CodeRule"] = string.Empty;
        }
        #endregion
    }
}