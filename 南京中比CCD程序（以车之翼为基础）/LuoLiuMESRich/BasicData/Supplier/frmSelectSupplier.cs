using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace BasicData.Supplier
{
    public partial class frmSelectSupplier : Common.frmSelectBase
    {
        public frmSelectSupplier()
        {
            InitializeComponent();
        }
        #region  公共属性
        public string _MaterialCode = string.Empty;
        #endregion
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
            #region 绑定原材料
            this.comM.DisplayMember = "Text";
            this.comM.ValueMember = "Value";
            this.comM.Items.Add(new Common.MyEntity.ComboBoxItem("所有原材料", ""));
            DataTable dtSupplier ;
            try
            {
                dtSupplier = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT DefaultName,Materialcode FROM JC_Material order by DefaultName asc");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            int iSeled = -1;
            int iSeled1;
            foreach (DataRow drSp in dtSupplier.Rows)
            {
                iSeled1 = this.comM.Items.Add(new Common.MyEntity.ComboBoxItem(drSp["defaultname"].ToString(), drSp["Materialcode"].ToString()));
                if (this._MaterialCode != string.Empty && string.Compare(drSp["Materialcode"].ToString(), this._MaterialCode) == 0)
                {
                    iSeled = iSeled1;
                }
            }
            this.comM.SelectedIndex = iSeled;
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
            string strSql = "SELECT * FROM V_JC_Supplier_ForSelect WHERE 1=1";
            if (this.tbSearchValue.Text.Length > 0)
            {
                //过滤工序
                strSql += string.Format(" AND (CNName like '%{0}%' OR ENName like '%{0}%' OR ShortName like '%{0}%')", this.tbSearchValue.Text.Replace("'", "''"));
            }
            #region 过滤原材料
            string strMCode = string.Empty;
            Common.MyEntity.ComboBoxItem item = this.comM.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item != null)
            {
                strMCode = item.Value == null ? string.Empty : item.Value.ToString();
            }
            if (strMCode != string.Empty)
            {
                DataTable dtDetail;
                try
                {
                    dtDetail = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select SupplierCode from JC_MaterialSuppliers where MaterialCode='{0}' group by suppliercode"
                        , strMCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dtDetail.Rows.Count == 1)
                {
                    strSql += string.Format(" AND Code='{0}'", dtDetail.Rows[0]["SupplierCode"].ToString().Replace("'", "''"));
                }
                else if (dtDetail.Rows.Count > 1)
                {
                    string strDetailSqlIns = string.Empty;
                    foreach (DataRow drd in dtDetail.Rows)
                    {
                        strDetailSqlIns += string.Format("'{0}',", drd["SupplierCode"].ToString().Replace("'", "''"));
                    }
                    if (strDetailSqlIns != string.Empty)
                        strDetailSqlIns = strDetailSqlIns.Substring(0, strDetailSqlIns.Length - 1);
                    strSql += string.Format(" AND Code IN ({0})", strDetailSqlIns);
                }
                else strSql += " AND 1=2";
            }
            #endregion
            strSql += " ORDER BY DefaultName ASC";
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
            if (this.SelectedData != null && this.SelectedData.Count > 0 && dt.Columns.Contains(this.DataGridViewCheckColumnName))
            {
                //设置选中行
                DataRow[] drSels;
                foreach (SelectedSupplierInfo info in this.SelectedData)
                {
                    drSels = dt.Select(string.Format("Code='{0}'", info.Code));
                    if (drSels.Length > 0)
                        drSels[0][this.DataGridViewCheckColumnName] = true;
                }
            }
            this.dgvDetail.DataSource = dt;
            return true;
        }
        #endregion
        #region 公共属性
        private List<SelectedSupplierInfo> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedSupplierInfo> SelectedData
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
            this.comM.SelectedIndexChanged += new System.EventHandler(this.comM_SelectedIndexChanged);
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
                if (drs.Length == 0 && !this.AllowNoneSelected)
                {
                    this.ShowMsg("请至少选中一行数据。");
                    return;
                }
                this.SelectedData = new List<SelectedSupplierInfo>();
                SelectedSupplierInfo info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedSupplierInfo();
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
                this.SelectedData = new List<SelectedSupplierInfo>();
                if (dt.DefaultView.Count <= this.dgvDetail.SelectedRows[0].Index)
                    return;
                SelectedSupplierInfo info = new SelectedSupplierInfo();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectedSupplierInfo
        {
            public SelectedSupplierInfo()
            {
            }
            public SelectedSupplierInfo(DataRow dr)
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
            private object _strCNName;
            /// <summary>
            ///
            /// </summary>
            public object CNName
            {
                get { return this._strCNName; }
                set { this._strCNName = value; }
            }
            private object _strENName;
            /// <summary>
            ///
            /// </summary>
            public object ENName
            {
                get { return this._strENName; }
                set { this._strENName = value; }
            }
            private object _strShortName;
            /// <summary>
            ///
            /// </summary>
            public object ShortName
            {
                get { return this._strShortName; }
                set { this._strShortName = value; }
            }
            private object _strAddress;
            /// <summary>
            ///
            /// </summary>
            public object Address
            {
                get { return this._strAddress; }
                set { this._strAddress = value; }
            }
            private object _strTels;
            /// <summary>
            ///
            /// </summary>
            public object Tels
            {
                get { return this._strTels; }
                set { this._strTels = value; }
            }
            private object _strFaxs;
            /// <summary>
            ///
            /// </summary>
            public object Faxs
            {
                get { return this._strFaxs; }
                set { this._strFaxs = value; }
            }
            private object _strPosalcode;
            /// <summary>
            ///
            /// </summary>
            public object Posalcode
            {
                get { return this._strPosalcode; }
                set { this._strPosalcode = value; }
            }
            private object _strCountryCode;
            /// <summary>
            ///
            /// </summary>
            public object CountryCode
            {
                get { return this._strCountryCode; }
                set { this._strCountryCode = value; }
            }
            private object _strProvinceCode;
            /// <summary>
            ///
            /// </summary>
            public object ProvinceCode
            {
                get { return this._strProvinceCode; }
                set { this._strProvinceCode = value; }
            }
            private object _strCreater;
            /// <summary>
            ///
            /// </summary>
            public object Creater
            {
                get { return this._strCreater; }
                set { this._strCreater = value; }
            }
            private object _strCreaterName;
            /// <summary>
            ///
            /// </summary>
            public object CreaterName
            {
                get { return this._strCreaterName; }
                set { this._strCreaterName = value; }
            }
            private object _detCreateDate;
            /// <summary>
            ///
            /// </summary>
            public object CreateDate
            {
                get { return this._detCreateDate; }
                set { this._detCreateDate = value; }
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
            private object _iSupplyType;
            /// <summary>
            ///
            /// </summary>
            public object SupplyType
            {
                get { return this._iSupplyType; }
                set { this._iSupplyType = value; }
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
            private object _strDefaultName;
            /// <summary>
            ///
            /// </summary>
            public object DefaultName
            {
                get { return this._strDefaultName; }
                set { this._strDefaultName = value; }
            }
            private object _strCountryName;
            /// <summary>
            ///
            /// </summary>
            public object CountryName
            {
                get { return this._strCountryName; }
                set { this._strCountryName = value; }
            }
            private object _strProvinceName;
            /// <summary>
            ///
            /// </summary>
            public object ProvinceName
            {
                get { return this._strProvinceName; }
                set { this._strProvinceName = value; }
            }
            private object _strSupplyTypeView;
            /// <summary>
            ///
            /// </summary>
            public object SupplyTypeView
            {
                get { return this._strSupplyTypeView; }
                set { this._strSupplyTypeView = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.Code = dr["Code"];
                this.CNName = dr["CNName"];
                this.ENName = dr["ENName"];
                this.ShortName = dr["ShortName"];
                this.Address = dr["Address"];
                this.Tels = dr["Tels"];
                this.Faxs = dr["Faxs"];
                this.Posalcode = dr["Posalcode"];
                this.CountryCode = dr["CountryCode"];
                this.ProvinceCode = dr["ProvinceCode"];
                this.Creater = dr["Creater"];
                this.CreaterName = dr["CreaterName"];
                this.CreateDate = dr["CreateDate"];
                this.Remark = dr["Remark"];
                this.SupplyType = dr["SupplyType"];
                this.Terminated = dr["Terminated"];
                this.DefaultName = dr["DefaultName"];
                this.CountryName = dr["CountryName"];
                this.ProvinceName = dr["ProvinceName"];
                this.SupplyTypeView = dr["SupplyTypeView"];
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

        private void comM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                BindData();
        }

        private void comM_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}