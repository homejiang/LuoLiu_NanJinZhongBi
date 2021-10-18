using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace AutoAssign.BasicData
{
    public partial class frmSelectProductClass : Common.frmSelectBase
    {
        public frmSelectProductClass()
        {
            InitializeComponent();
        }
        #region 处理函数
        private bool Perinit()
        {
            
            this.dgvDetail.AutoGenerateColumns = false;
            this.dgvDetail.MultiSelect = this.MultiSelected;//是否允许多选
            if (this.MultiSelected)
                this.BindDataGridViewCheckBox(this.dgvDetail, this.colCheckBox);
            else
            {
                //单选无需添加复选框
                this.colCheckBox.Visible = false;
                this.dgvDetail.CellDoubleClick+=new DataGridViewCellEventHandler(dgvDetail_CellDoubleClick);
            }
            return true;
        }
        

        private bool BindData()
        {
            DataTable dt = null;
            string strSql = "SELECT * FROM JC_ProductSpec where isnull(Terminated,0)=0";
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (this.MultiSelected)
            {
                dt.Columns.Add(this.GetDataGridViewCheckBoxColumn());
                if (this.SelectedData != null && this.SelectedData.Count > 0)
                {
                    DataRow[] drsMac;
                    foreach (SelectedProductSpec mac in this.SelectedData)
                    {
                        drsMac = dt.Select(string.Format("GUID='{0}'"
                            , mac.GUID.ToString()));
                        if (drsMac.Length > 0)
                            drsMac[0][this.DataGridViewCheckColumnName] = true;
                    }
                }
            }
            this.dgvDetail.DataSource = dt;
            return true;
        }
        #endregion
        #region 公共属性
        private List<SelectedProductSpec> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedProductSpec> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        #endregion
        #region 窗体OnLoad事件
        private void frmBsFWithAllocateInfo_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            if (!this.BindData()) return;
        }
        #endregion
        #region 工具栏控件事件
        
        //搜索按钮接收键盘事件
        private void SaarchValues_KeyDown(object sender, KeyEventArgs e)
        {
            //目前只触发回车事件
            if (e.KeyValue == 13)
                this.btSearch_Click(sender, null);
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            if (!this.BindData()) return;
        }
        #endregion
        #region 底部按钮事件
        private void btClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源丢失，请重新加载窗体。");
                return;
            }
            if (this.MultiSelected)
            {
                DataRow[] drs = dt.Select(this.DataGridViewCheckColumnName + "=1");
                if (drs.Length == 0 && !this.AllowNoneSelected)
                {
                    this.ShowMsg("请至少选中一行数据。");
                    return;
                }
                this.SelectedData = new List<SelectedProductSpec>();
                SelectedProductSpec info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedProductSpec();
                    info.ReadFromDataRow(dr);
                    this.SelectedData.Add(info);
                }
            }
            else
            {
                if (this.dgvDetail.SelectedRows.Count == 0 && !this.AllowNoneSelected)
                {
                    this.ShowMsg("请选中一行数据。");
                    return;
                }
                if (dt.DefaultView.Count <= this.dgvDetail.SelectedRows[0].Index)
                    return;
                SelectedProductSpec info = new SelectedProductSpec();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedProductSpec>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectedProductSpec
        {
            public SelectedProductSpec()
            {
            }
            public SelectedProductSpec(DataRow dr)
            {
                this.ReadFromDataRow(dr);
            }
            private object _strGUID;
            /// <summary>
            ///
            /// </summary>
            public object GUID
            {
                get { return this._strGUID; }
                set { this._strGUID = value; }
            }
            private object _strSpec;
            /// <summary>
            ///
            /// </summary>
            public object Spec
            {
                get { return this._strSpec; }
                set { this._strSpec = value; }
            }
            private object _blTerminated;
            /// <summary>
            ///
            /// </summary>
            public object Terminated
            {
                get { return this._blTerminated; }
                set { this._blTerminated = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.GUID = dr["GUID"];
                this.Spec = dr["Spec"];
                this.Terminated = dr["Terminated"];
            }

        }
        #endregion
        #region 列表框事件
        //行双击事件
        protected void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btTrue_Click(null, null);
        }
        #endregion
    }
}