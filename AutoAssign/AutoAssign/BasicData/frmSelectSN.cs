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
    public partial class frmSelectSN : Common.frmSelectBase
    {
        public frmSelectSN()
        {
            InitializeComponent();
        }
        #region 处理函数
        private bool Perinit()
        {
            
            this.dtpStart.Value = DateTime.Now.AddDays(-14);
            this.dtpEnd.Value = DateTime.Now;
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
            
            this.tbPici.KeyDown += SearchText_KeyDown;
            return true;
        }

        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
            {
                this.btSearch_Click(null, null);
            }
        }

        private bool BindData()
        {
            DataTable dt = null;
            string strSql = "SELECT * FROM DianXin_ListData WHERE isnull(Inputed,0)=0";
            if(this.tbPici.Text.Length>0)
            {
                strSql += string.Format(" and PatchCode like '{0}'", this.tbPici.Text.Replace("'", "''"));
            }
            strSql += string.Format(" and InsertTimes>='{0}'", this.dtpStart.Value.ToString("yyyy-MM-dd"));
            if (this.dtpEnd.Checked)
                strSql += string.Format(" and InsertTimes<'{0} 00:00:01'", this.dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd"));
            strSql += "order by PatchCode asc,InsertTimes asc";
            try
            {
                dt = Common.CommonDAL.DoSqlCommandRemoteMES.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (this.MultiSelected)
            {
                dt.Columns.Add(this.GetDataGridViewCheckBoxColumn());
            }
            this.dgvDetail.DataSource = dt;
            return true;
        }
        #endregion
        #region 公共属性
        private List<SelectedSNData> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedSNData> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        #endregion
        #region 窗体OnLoad事件
        private void frmBsFWithAllocateInfo_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            //if (!this.BindData()) return;
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
                this.SelectedData = new List<SelectedSNData>();
                SelectedSNData info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedSNData();
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
                SelectedSNData info = new SelectedSNData();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedSNData>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectedSNData
        {
            public SelectedSNData()
            {
            }
            public SelectedSNData(DataRow dr)
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
            private object _strPatchCode;
            /// <summary>
            ///
            /// </summary>
            public object PatchCode
            {
                get { return this._strPatchCode; }
                set { this._strPatchCode = value; }
            }
            private object _strCode;
            /// <summary>
            ///
            /// </summary>
            public object Code
            {
                get { return this._strCode; }
                set { this._strCode = value; }
            }
            private object _strItemCode;
            /// <summary>
            ///
            /// </summary>
            public object ItemCode
            {
                get { return this._strItemCode; }
                set { this._strItemCode = value; }
            }
            private object _decCapacity;
            /// <summary>
            ///
            /// </summary>
            public object Capacity
            {
                get { return this._decCapacity; }
                set { this._decCapacity = value; }
            }
            private object _decResistance;
            /// <summary>
            ///
            /// </summary>
            public object Resistance
            {
                get { return this._decResistance; }
                set { this._decResistance = value; }
            }
            private object _decVoltage;
            /// <summary>
            ///
            /// </summary>
            public object Voltage
            {
                get { return this._decVoltage; }
                set { this._decVoltage = value; }
            }
            private object _strTimes;
            /// <summary>
            ///
            /// </summary>
            public object Times
            {
                get { return this._strTimes; }
                set { this._strTimes = value; }
            }
            private object _detInsertTimes;
            /// <summary>
            ///
            /// </summary>
            public object InsertTimes
            {
                get { return this._detInsertTimes; }
                set { this._detInsertTimes = value; }
            }
            private object _blInputed;
            /// <summary>
            ///
            /// </summary>
            public object Inputed
            {
                get { return this._blInputed; }
                set { this._blInputed = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.GUID = dr["GUID"];
                this.PatchCode = dr["PatchCode"];
                this.Code = dr["Code"];
                this.ItemCode = dr["ItemCode"];
                this.Capacity = dr["Capacity"];
                this.Resistance = dr["Resistance"];
                this.Voltage = dr["Voltage"];
                this.Times = dr["Times"];
                this.InsertTimes = dr["InsertTimes"];
                this.Inputed = dr["Inputed"];
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

        private void comPactState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.BindData();
        }

        private void btSeled_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvDetail);
            if (list.Count == 0) return;
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            foreach(int row in list)
            {
                DataRow dr = dt.DefaultView[row].Row;
                if (dr[this.DataGridViewCheckColumnName].Equals(DBNull.Value) || !(bool)dr[this.DataGridViewCheckColumnName])
                    dr[this.DataGridViewCheckColumnName] = true;
            }
        }

        private void btUnSel_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvDetail);
            if (list.Count == 0) return;
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            foreach (int row in list)
            {
                DataRow dr = dt.DefaultView[row].Row;
                if (!dr[this.DataGridViewCheckColumnName].Equals(DBNull.Value) && (bool)dr[this.DataGridViewCheckColumnName])
                    dr[this.DataGridViewCheckColumnName] = false;
            }
        }
    }
}