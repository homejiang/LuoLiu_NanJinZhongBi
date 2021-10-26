using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common.DataGridSetting
{
    public partial class frmEdit : frmBase
    {
        public frmEdit()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.DataGridSetting _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.DataGridSetting BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.DataGridSetting();
                return _dal;
            }
        }
        #endregion
        #region 窗体属性
        public DataTable _dtDataSource = null;
        /// <summary>
        /// 窗体数据源
        /// </summary>
        public DataTable DataTableSource
        {
            get { return this._dtDataSource; }
            set { this._dtDataSource = value; }
        }
        private bool _IsUpdated = false;
        /// <summary>
        /// 数据是否修改
        /// </summary>
        public bool IsUpdated
        {
            get { return this._IsUpdated; }
            set { this._IsUpdated = value; }
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
            if (this.DataTableSource != null)
                this.DataTableSource.DefaultView.Sort = "SortID ASC";
            //添加背景色显示列
            this.dgvList.DataSource = this.DataTableSource;
            return true;
        }
        private bool SetForeBackColor()
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return false;
            string strFore, strBack;
            for (int i = 0; i < dt.DefaultView.Count; i++)
            {
                strFore = dt.DefaultView[i].Row["ForeColor"].ToString();
                strBack = dt.DefaultView[i].Row["BackColor"].ToString();
                if (Common.CommonFuns.StringRegexCheck.CheckIsColorHexString(strFore))
                {
                    this.dgvList.Rows[i].Cells[4].Style.BackColor = ColorTranslator.FromHtml(strFore);
                }
                if (Common.CommonFuns.StringRegexCheck.CheckIsColorHexString(strBack))
                {
                    this.dgvList.Rows[i].Cells[5].Style.BackColor = ColorTranslator.FromHtml(strBack);
                }
            }
            return true;
        }
        
        #endregion
        #region 窗体及控件事件
        private void frmEdit_Load(object sender, EventArgs e)
        {
            this.PerInit();
            this.BindData();
            this.SetForeBackColor();
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 4 && e.ColumnIndex != 5) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (DialogResult.OK != this.colorDialog1.ShowDialog())
                return;
            if (e.ColumnIndex == 4)
                dt.DefaultView[e.RowIndex].Row["ForeColor"] = ColorTranslator.ToHtml(this.colorDialog1.Color);
            else
                dt.DefaultView[e.RowIndex].Row["BackColor"] = ColorTranslator.ToHtml(this.colorDialog1.Color);
            this.dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = this.colorDialog1.Color;//设置单元格背景色
            this.dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
        }
        #endregion

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (this.DataTableSource.GetChanges() == null)
                return;
            try
            {
                this.BllDAL.Save(this.DataTableSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.DataTableSource.AcceptChanges();
            this.SetForeBackColor();
            this.ShowMsg("保存成功。");
            this.IsUpdated = true;
        }

        private void tsbDown_Click(object sender, EventArgs e)
        {

            if (this.DataTableSource == null) return;
            if (this.dgvList.SelectedRows.Count == 0) return;
            int iSelectIndex = this.dgvList.SelectedRows[0].Index;
            DataTable dt = this.DataTableSource;
            if (iSelectIndex >= dt.DefaultView.Count - 1) return;
            object objTemp = dt.DefaultView[iSelectIndex].Row["SortID"];
            dt.DefaultView[iSelectIndex].Row["SortID"] = dt.DefaultView[iSelectIndex + 1].Row["SortID"];
            dt.DefaultView[iSelectIndex + 1].Row["SortID"] = objTemp;
            dt.DefaultView.Sort = "SortID";
        }

        private void tsbUp_Click(object sender, EventArgs e)
        {
            if (this.DataTableSource == null) return;
            if (this.dgvList.SelectedRows.Count == 0) return;
            int iSelectIndex = this.dgvList.SelectedRows[0].Index;
            if (iSelectIndex <= 0) return;
            DataTable dt = this.DataTableSource;
            object objTemp = dt.DefaultView[iSelectIndex].Row["SortID"];
            dt.DefaultView[iSelectIndex].Row["SortID"] = dt.DefaultView[iSelectIndex - 1].Row["SortID"];
            dt.DefaultView[iSelectIndex - 1].Row["SortID"] = objTemp;
            dt.DefaultView.Sort = "SortID";
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }
    }
}