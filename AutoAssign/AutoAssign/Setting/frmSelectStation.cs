using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace AutoAssign.Setting
{
    public partial class frmSelectStation : Common.frmSelectBase
    {
        public frmSelectStation()
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
            string strSql = "SELECT * FROM V_JC_Station WHERE ISNULL(Terminated,0)=0 ORDER BY SortID ASC";
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
                dt.Columns.Add(this.GetDataGridViewCheckBoxColumn());
            this.dgvDetail.DataSource = dt;
            return true;
        }
        #endregion
        #region 公共属性
        private List<SelectedStation> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedStation> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        #endregion
        #region 窗体OnLoad事件
        private void frmSelect_Load(object sender, EventArgs e)
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
                if (drs.Length == 0)
                {
                    this.ShowMsg("请至少选中一行数据。");
                    return;
                }
                this.SelectedData = new List<SelectedStation>();
                SelectedStation info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedStation();
                    info.ReadFromDataRow(dr);
                    this.SelectedData.Add(info);
                }
            }
            else
            {
                if (this.dgvDetail.SelectedRows.Count == 0)
                {
                    this.ShowMsg("请选中一行数据。");
                    return;
                }
                if (dt.DefaultView.Count <= this.dgvDetail.SelectedRows[0].Index)
                    return;
                SelectedStation info = new SelectedStation();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedStation>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectedStation
        {
            public SelectedStation()
            {
            }
            public SelectedStation(DataRow dr)
            {
                this.ReadFromDataRow(dr);
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
            private object _iSortID;
            /// <summary>
            ///
            /// </summary>
            public object SortID
            {
                get { return this._iSortID; }
                set { this._iSortID = value; }
            }
            private object _strStationName;
            /// <summary>
            ///
            /// </summary>
            public object StationName
            {
                get { return this._strStationName; }
                set { this._strStationName = value; }
            }
            private object _strRemark;
            /// <summary>
            ///
            /// </summary>
            public object Remark
            {
                get { return this._strRemark; }
                set { this._strRemark = value; }
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
                this.Code = dr["Code"];
                this.SortID = dr["SortID"];
                this.StationName = dr["StationName"];
                this.Remark = dr["Remark"];
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