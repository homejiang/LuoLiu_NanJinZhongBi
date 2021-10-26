using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LuoLiuMES.PactM
{
    public partial class frmPactDetail : Common.frmBase
    {
        public PactDetailEntity _Data = null;
        #region  窗口隐藏信息
        #endregion
        public frmPactDetail()
        {
            InitializeComponent();
        }
        #region  窗口变量
        #endregion
        #region 数据加载
        private bool Perint()
        {
            //绑定下拉列表
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "select GUID,Spec from V_BOM_Product_Cgy where isnull(Terminated,0)=0 ORDER BY Spec asc";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "bom_product", true));
            strSql = "select Code,CodeName from JC_FenXjShouLiao where isnull(Terminated,0)=0 ORDER BY Code asc";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_FenXjShouLiao", true));
            
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //厂商代号
            this.comBom.DisplayMember = "Text";
            this.comBom.ValueMember = "Value";
            foreach (DataRow dr in ds.Tables["bom_product"].Rows)
            {
                this.comBom.Items.Add(new Common.MyEntity.ComboBoxItem(dr["Spec"].ToString(), dr["GUID"].ToString()));
            }
            this.comBom.SelectedIndex = -1;
            //厂商代号
            this.ComFenXj.DisplayMember = "Text";
            this.ComFenXj.ValueMember = "Value";
            foreach (DataRow dr in ds.Tables["JC_FenXjShouLiao"].Rows)
            {
                this.ComFenXj.Items.Add(new Common.MyEntity.ComboBoxItem(dr["CodeName"].ToString(), dr["Code"].ToString()));
            }
            this.ComFenXj.SelectedIndex = -1;

            return true;
        }
        private bool BindData()
        {
            if (this._Data != null)
            {
                Common.CommonFuns.FormatData.SetComboBoxText(this.comBom, this._Data.BOMGuid.ToString(), 0);
               
                this.tbQty.Text = this._Data.Qty.ToString();
                if (!this._Data.DeliveryDate.Equals(DBNull.Value))
                    this.dptDeliveryDate.Value = DateTime.Parse(this._Data.DeliveryDate.ToString());
                this.tbRemark.Text = this._Data.Remark.ToString();
            }
            else
            {
                
                this.tbQty.Clear();
                this.tbRemark.Clear();
            }
            return true;
        }
        #endregion
        #region 数据选择类
        public class PactDetailEntity
        {
            public PactDetailEntity()
            {
            }
            public PactDetailEntity(string sGuid)
            {
                this.GUID = sGuid;
            }
            public PactDetailEntity(DataRow dr)
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
            private object _iSortID;
            /// <summary>
            ///
            /// </summary>
            public object SortID
            {
                get { return this._iSortID; }
                set { this._iSortID = value; }
            }
            private object _strPactCode;
            /// <summary>
            ///
            /// </summary>
            public object PactCode
            {
                get { return this._strPactCode; }
                set { this._strPactCode = value; }
            }
            private object _strBOMGuid;
            /// <summary>
            ///
            /// </summary>
            public object BOMGuid
            {
                get { return this._strBOMGuid; }
                set { this._strBOMGuid = value; }
            }
            
            private object _iQty;
            /// <summary>
            ///
            /// </summary>
            public object Qty
            {
                get { return this._iQty; }
                set { this._iQty = value; }
            }
            
            private object _iCompeletedQty;
            /// <summary>
            ///
            /// </summary>
            public object CompeletedQty
            {
                get { return this._iCompeletedQty; }
                set { this._iCompeletedQty = value; }
            }
            
            
            private object _iCompeletedState;
            /// <summary>
            ///
            /// </summary>
            public object CompeletedState
            {
                get { return this._iCompeletedState; }
                set { this._iCompeletedState = value; }
            }
            private object _detDeliveryDate;
            /// <summary>
            ///
            /// </summary>
            public object DeliveryDate
            {
                get { return this._detDeliveryDate; }
                set { this._detDeliveryDate = value; }
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
            
            private object _strBomSpec;
            /// <summary>
            ///
            /// </summary>
            public object BomSpec
            {
                get { return this._strBomSpec; }
                set { this._strBomSpec = value; }
            }
            
            private object _strCompeletedStateView;
            /// <summary>
            ///
            /// </summary>
            public object CompeletedStateView
            {
                get { return this._strCompeletedStateView; }
                set { this._strCompeletedStateView = value; }
            }

            private object _strVersionDesc;
            /// <summary>
            ///
            /// </summary>
            public object VersionDesc
            {
                get { return this._strVersionDesc; }
                set { this._strVersionDesc = value; }
            }
            private object _strFenCode;
            /// <summary>
            ///
            /// </summary>
            public object FenCode
            {
                get { return this._strFenCode; }
                set { this._strFenCode = value; }
            }
            private object _strFenCodeName;
            /// <summary>
            ///
            /// </summary>
            public object FenCodeName
            {
                get { return this._strFenCodeName; }
                set { this._strFenCodeName = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.GUID = dr["GUID"];
                this.SortID = dr["SortID"];
                this.PactCode = dr["PactCode"];
                this.BOMGuid = dr["BOMGuid"];
                this.Qty = dr["Qty"];
                this.CompeletedQty = dr["CompeletedQty"];
                this.CompeletedState = dr["CompeletedState"];
                this.DeliveryDate = dr["DeliveryDate"];
                this.Remark = dr["Remark"];
                this.BomSpec = dr["BomSpec"];
                this.CompeletedStateView = dr["CompeletedStateView"];
                this.VersionDesc = dr["VersionDesc"];
                this.FenCode = dr["FenCode"];
                this.FenCodeName = dr["FenCodeName"];
            }
        }
        #endregion
        #region 保存数据
        private bool ReadForm()
        {
            if (this._Data == null)
                this._Data = new PactDetailEntity(this.GetGUID());

            Common.MyEntity.ComboBoxItem item;
           
            int iQty;
            if(!int.TryParse(this.tbQty.Text,out iQty))
            {
                this.ShowMsg("请正确填写数量！");
                return false;
            }
            this._Data.Qty = iQty;
            this._Data.VersionDesc = this.tbVersionDesc.Text;
            this._Data.DeliveryDate = DateTime.Parse(this.dptDeliveryDate.Value.ToString("yyyy-MM-dd")) ;
            this._Data.Remark = this.tbRemark.Text;
            item = this.comBom.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString().Length == 0)
            {
                this.ShowMsg("请选择BOM结构！");
                return false;
            }
            this._Data.BOMGuid = item.Value.ToString();
            this._Data.BomSpec = item.Text;
            item = this.ComFenXj.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString().Length == 0)
            {
                this.ShowMsg("请选择分选机收料盒比例！");
                return false;
            }
            this._Data.FenCode = item.Value.ToString();
            this._Data.FenCodeName = item.Text;
            return true;
        }
        #endregion
        private void frmPactDetail_Load(object sender, EventArgs e)
        {
            this.btTrue.Enabled = this.Perint() && this.BindData();
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if (!this.ReadForm()) return;
            this.DialogResult = DialogResult.OK;
            this.Close();   
        }

        private void comBom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.MyEntity.ComboBoxItem item;
            item = this.comBom.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString().Length == 0)
            {
                this.tbBomDesc.Clear();
                return;
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC BOM_GetStructDesc_Cgy '{0}'", item.Value.ToString().Replace("'", "''")));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "GetBOMDesc");
                return;
            }
            this.tbBomDesc.Text = dt.Rows[0]["PackDesc"].ToString();
            this.tbVersionDesc.Text= dt.Rows[0]["VersionDesc"].ToString();
        }
        
        
    }
}
