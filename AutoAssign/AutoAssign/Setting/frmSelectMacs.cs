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
    public partial class frmSelectMacs : Common.frmSelectBase
    {
        public frmSelectMacs()
        {
            InitializeComponent();
        }
        #region 处理函数
        private bool Perinit()
        {
            
            #region 绑定工序名称
            DataTable dtProcess = null;
            try
            {
                dtProcess = Common.CommonDAL.DoSqlCommandRemoteMES.GetDateTable("SELECT Code,ProcessName FROM JC_Process ORDER BY SortID ASC,ProcessName ASC");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            foreach (DataRow dr in dtProcess.Rows)
            {
                if (this.DefaultProcessCode.Length > 0)
                {
                    if (string.Compare(this.DefaultProcessCode, dr["Code"].ToString(), true) == 0)
                        this.DefaultProcessName = dr["ProcessName"].ToString();
                }
                this.comSearchValue.Items.Add(dr["ProcessName"].ToString());
            }
            #endregion
            #region 加载默认值
            this.comSearchValue.Text = this.DefaultProcessName;
            this.comSearchValue.Enabled = !this.FixProcess;
            #endregion
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
            string strSql = "SELECT * FROM V_JC_ProcessMacs " + this.GetSqlWhere();
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
                if (this.SelectedData != null && this.SelectedData.Count > 0)
                {
                    DataRow[] drsMac;
                    foreach (SelectMacInfo mac in this.SelectedData)
                    {
                        drsMac = dt.Select(string.Format("Code='{0}'"
                            , mac.Code.ToString()));
                        if (drsMac.Length > 0)
                            drsMac[0][this.DataGridViewCheckColumnName] = true;
                    }
                }
            }
            this.dgvDetail.DataSource = dt;
            return true;
        }
        /// <summary>
        /// 获取搜索条件
        /// </summary>
        /// <returns></returns>
        private string GetSqlWhere()
        {
            string strWhere = "WHERE ISNULL(Terminated,0)=0 ";//不显示已经停用的
            if (this.comSearchValue.Text.Length == 0) return strWhere;
            return strWhere + string.Format(" AND ProcessName LIKE '{0}'", this.comSearchValue.Text.Replace("'", "''"));
        }
        #endregion
        #region 公共属性
        private List<SelectMacInfo> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectMacInfo> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        private string _strDefaultProcessName = string.Empty;
        /// <summary>
        /// 默认工序名称
        /// </summary>
        public string DefaultProcessName
        {
            get { return this._strDefaultProcessName; }
            set { this._strDefaultProcessName = value; }
        }
        private string _strDefaultProcessCode = string.Empty;
        /// <summary>
        /// 默认工序代码
        /// </summary>
        public string DefaultProcessCode
        {
            get { return this._strDefaultProcessCode; }
            set { this._strDefaultProcessCode = value; }
        }
        private bool _blFixProcess = false;
        /// <summary>
        /// 固定工序
        /// </summary>
        public bool FixProcess
        {
            get { return this._blFixProcess; }
            set { this._blFixProcess = value; }
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
                if (drs.Length == 0)
                {
                    this.ShowMsg("请至少选中一行数据。");
                    return;
                }
                this.SelectedData = new List<SelectMacInfo>();
                SelectMacInfo info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectMacInfo();
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
                SelectMacInfo info = new SelectMacInfo();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectMacInfo>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectMacInfo
        {
            private object _strCode;
            /// <summary>
            ///设备编码
            /// </summary>
            public object Code
            {
                get { return this._strCode; }
                set { this._strCode = value; }
            }
            private object _iSortID;
            /// <summary>
            ///排序字段
            /// </summary>
            public object SortID
            {
                get { return this._iSortID; }
                set { this._iSortID = value; }
            }
            private object _strProcessCode;
            /// <summary>
            ///工序代码
            /// </summary>
            public object ProcessCode
            {
                get { return this._strProcessCode; }
                set { this._strProcessCode = value; }
            }
            private object _strProcessName;
            /// <summary>
            ///工序名称
            /// </summary>
            public object ProcessName
            {
                get { return this._strProcessName; }
                set { this._strProcessName = value; }
            }
            private object _strMacName;
            /// <summary>
            ///设备名称
            /// </summary>
            public object MacName
            {
                get { return this._strMacName; }
                set { this._strMacName = value; }
            }
            private object _strAddress;
            /// <summary>
            ///设备存放位置描述
            /// </summary>
            public object Address
            {
                get { return this._strAddress; }
                set { this._strAddress = value; }
            }
            private object _strRemark;
            /// <summary>
            ///设备备注信息
            /// </summary>
            public object Remark
            {
                get { return this._strRemark; }
                set { this._strRemark = value; }
            }
            /// <summary>
            /// 从DataRow中读取各个属性值
            /// </summary>
            /// <param name="dr"></param>
            public void ReadFromDataRow(DataRow dr)
            {
                this.Code = dr["Code"];
                this.SortID = dr["SortID"];
                this.ProcessCode = dr["ProcessCode"];
                this.MacName = dr["MacName"];
                this.Address = dr["Address"];
                this.Remark = dr["Remark"];
                this.ProcessName = dr["ProcessName"];
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