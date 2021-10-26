using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace BasicData.ProcessMacs
{
    public partial class frmSelectBdownCase : Common.frmSelectBase
    {
        public frmSelectBdownCase()
        {
            InitializeComponent();
        }
        #region 处理函数
        private bool Perinit()
        {
            #region 设置更多按钮
            List<Common.MyEntity.SearchButtonItem> listBarbuts = new List<Common.MyEntity.SearchButtonItem>();
            Common.MyEntity.SearchButtonItem barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "高级搜索";
            barbut.Value = 1;
            listBarbuts.Add(barbut);
            barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "列表排列";
            barbut.Value = 2;
            listBarbuts.Add(barbut);
            barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "反选";
            barbut.Value = 3;
            listBarbuts.Add(barbut);
            this.labExButtons.BackColor = Color.Transparent;
            this.labExButtons.ForeColor = Color.Black;
            this.labExButtons.TextAlign = ContentAlignment.MiddleCenter;
            this.labExButtons.IsTextChange = false;//不需要切换文本
            this.BindMyButtons(this.labExButtons, listBarbuts, true);
            #endregion
            #region 绑定工序名称
            DataTable dtProcess = null;
            try
            {
                dtProcess = Common.CommonDAL.DoSqlCommand.GetDateTable("select Code,ProcessName from JC_Process where isnull(Terminated,0)=0 order by Sortid asc");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comProcess.DisplayMember = "Text";
            this.comProcess.ValueMember = "Value";
            int iSelIndex = -1;
            foreach (DataRow dr in dtProcess.Rows)
            {
                if (string.Compare(this.DefaultProcess, dr["Code"].ToString(), true) == 0)
                    iSelIndex = this.comProcess.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ProcessName"].ToString(), dr["Code"].ToString()));
                else this.comProcess.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ProcessName"].ToString(), dr["Code"].ToString()));
            }
            this.comProcess.SelectedIndex = iSelIndex;
            this.comProcess.Enabled = !this.FixProcess;
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
            string strSql = "SELECT * FROM V_JC_MacBreakdownCase " + this.GetSqlWhere();
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
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
        /// <summary>
        /// 获取搜索条件
        /// </summary>
        /// <returns></returns>
        private string GetSqlWhere()
        {
            string strWhere = "WHERE ISNULL(Terminated,0)=0 ";//不显示已经停用的
            Common.MyEntity.ComboBoxItem item = this.comProcess.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString().Length == 0)
                return strWhere;
            return strWhere + string.Format(" AND (ISNULL(ProcessCode,'')='' OR ProcessCode='{0}')", item.Value.ToString().Replace("'", "''"));
        }
        #endregion
        #region 公共属性
        private List<SelectedMBdownCase> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedMBdownCase> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        private string _strDefaultProcess = string.Empty;
        /// <summary>
        /// 默认工序代码
        /// </summary>
        public string DefaultProcess
        {
            get { return this._strDefaultProcess; }
            set { this._strDefaultProcess = value; }
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
        private void frmSelect_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            if (!this.BindData()) return;
        }
        #endregion
        #region 工具栏控件事件
        private void labExButtons_TitleChanged(MyControl.MyLabelEx.MyLabelItem originalItem, MyControl.MyLabelEx.MyLabelItem newItem)
        {
            Common.MyEntity.SearchLabelItem item = newItem.Tag as Common.MyEntity.SearchLabelItem;
            if (item.Value == 2)
            {
                this.DataGridViewSetting(Common.MyEnums.Modules.None, this.dgvDetail);
            }
            else if (item.Value == 3)
            {
                if (!this.MultiSelected)
                {
                    this.ShowMsg("当前列表只能选择一条数据，该功能不能使用。");
                    return;
                }
                DataTable dt = this.dgvDetail.DataSource as DataTable;
                if (dt == null) return;
                foreach (DataRowView drv in dt.DefaultView)
                {
                    drv.Row[this.DataGridViewCheckColumnName] = drv.Row[this.DataGridViewCheckColumnName].Equals(DBNull.Value) ? true : !(bool)drv.Row[this.DataGridViewCheckColumnName];
                }
            }
        }
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
                this.SelectedData = new List<SelectedMBdownCase>();
                SelectedMBdownCase info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedMBdownCase();
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
                SelectedMBdownCase info = new SelectedMBdownCase();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedMBdownCase>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectedMBdownCase
        {
            public SelectedMBdownCase()
            {
            }
            public SelectedMBdownCase(DataRow dr)
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
            private object _strCaseDesc;
            /// <summary>
            ///
            /// </summary>
            public object CaseDesc
            {
                get { return this._strCaseDesc; }
                set { this._strCaseDesc = value; }
            }
            private object _strLevelCode;
            /// <summary>
            ///
            /// </summary>
            public object LevelCode
            {
                get { return this._strLevelCode; }
                set { this._strLevelCode = value; }
            }
            private object _strProcessCode;
            /// <summary>
            ///
            /// </summary>
            public object ProcessCode
            {
                get { return this._strProcessCode; }
                set { this._strProcessCode = value; }
            }
            private object _strClassCode;
            /// <summary>
            ///
            /// </summary>
            public object ClassCode
            {
                get { return this._strClassCode; }
                set { this._strClassCode = value; }
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
            private object _blIsSys;
            /// <summary>
            ///
            /// </summary>
            public object IsSys
            {
                get { return this._blIsSys; }
                set { this._blIsSys = value; }
            }
            private object _strProcessName;
            /// <summary>
            ///
            /// </summary>
            public object ProcessName
            {
                get { return this._strProcessName; }
                set { this._strProcessName = value; }
            }
            private object _strLevelDesc;
            /// <summary>
            ///
            /// </summary>
            public object LevelDesc
            {
                get { return this._strLevelDesc; }
                set { this._strLevelDesc = value; }
            }
            private object _strTerminatedView;
            /// <summary>
            ///
            /// </summary>
            public object TerminatedView
            {
                get { return this._strTerminatedView; }
                set { this._strTerminatedView = value; }
            }
            private object _strIsSysView;
            /// <summary>
            ///
            /// </summary>
            public object IsSysView
            {
                get { return this._strIsSysView; }
                set { this._strIsSysView = value; }
            }
            private object _strClassName;
            /// <summary>
            ///
            /// </summary>
            public object ClassName
            {
                get { return this._strClassName; }
                set { this._strClassName = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.Code = dr["Code"];
                this.SortID = dr["SortID"];
                this.CaseDesc = dr["CaseDesc"];
                this.LevelCode = dr["LevelCode"];
                this.ProcessCode = dr["ProcessCode"];
                this.ClassCode = dr["ClassCode"];
                this.Terminated = dr["Terminated"];
                this.IsSys = dr["IsSys"];
                this.ProcessName = dr["ProcessName"];
                this.LevelDesc = dr["LevelDesc"];
                this.TerminatedView = dr["TerminatedView"];
                this.IsSysView = dr["IsSysView"];
                this.ClassName = dr["ClassName"];
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