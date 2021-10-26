using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.UserControls
{
    public partial class ucMaterial : UserControl
    {
        public event RefreshMaterialItemDataCallBack RefreshMaterialItemDataNotice = null;
        List<ucMaterialItem> _Items = null;
        public ucMaterial()
        {
            InitializeComponent();
        }
        public void InitMaterial(List<MaterialEntity> materials)
        {
            //移除已经不需要的控件
            if (_Items != null && _Items.Count > 0)
            {
                for (int i = _Items.Count; i > 0; i--)
                {
                    ucMaterialItem uc;
                    if (_Items[i - 1]._Material == null)
                    {
                        uc = _Items[i - 1];
                        this.panContainer.Controls.Remove(uc);
                        this._Items.Remove(uc);
                        uc.Dispose();
                    }
                    else
                    {
                        MaterialEntity entity = materials.Find(delegate (MaterialEntity entityTemp)
                        {
                            return string.Compare(entityTemp.BOMMaterialGuid.ToString(), _Items[i - 1]._Material.BOMMaterialGuid.ToString(), true) == 0;
                        });
                        if (entity == null)
                        {
                            uc = _Items[i - 1];
                            this.panContainer.Controls.Remove(uc);
                            this._Items.Remove(uc);
                            uc.Dispose();
                        }
                    }
                }
            }
            //客户端如果已经加载了，不用再加载了
            if (this._Items != null && this._Items.Count > 0)
            {
                for (int i = materials.Count; i > 0; i--)
                {
                    MaterialEntity bindm = materials[i - 1];
                    
                    ucMaterialItem uc = _Items.Find(delegate (ucMaterialItem ucTemp)
                      {
                          if (ucTemp._Material == null) return false;
                          return string.Compare(ucTemp._Material.BOMMaterialGuid.ToString(), bindm.BOMMaterialGuid.ToString(), true) == 0;
                      });
                    if (uc != null)
                    {
                        materials.Remove(bindm);
                    }
                }
                
            }
            //此时要添加新的了
            foreach(MaterialEntity entity in materials)
            {
                ucMaterialItem ucNew = new ucMaterialItem();
                ucNew.SetMaterialEntity(entity);
                ucNew.Name = entity.BOMMaterialGuid.ToString();
                this.panContainer.Controls.Add(ucNew);
                ucNew.Dock = DockStyle.Top;
                if (this._Items == null)
                    this._Items = new List<ucMaterialItem>();
                this._Items.Add(ucNew);
            }
        }
        public bool Check(out string sErr)
        {
            if(_Items!=null)
            {
                foreach(ucMaterialItem uc in _Items)
                {
                    if (!uc.Check(out sErr)) return false;
                }
            }
            sErr = string.Empty;
            return true;
        }
        public List<MaterialEntity> GetMaterils(out string sErr)
        {
            List<MaterialEntity> list = new List<MaterialEntity>();
            if (this._Items != null)
            {
                foreach (ucMaterialItem uc in _Items)
                {
                    MaterialEntity entity = uc.GetMaterialEntity(out sErr);
                    if (entity == null) return null;
                    list.Add(entity);
                }
            }
            sErr = string.Empty;
            return list;
        }

        private void labRefreshSpec_Click(object sender, EventArgs e)
        {
            if (this._Items == null)
            {
                if (this.RefreshMaterialItemDataNotice == null)
                    this.RefreshMaterialItemDataNotice(1, false, "无明细需要刷新。");
            }
            foreach(ucMaterialItem item in this._Items)
            {
                item.BindMaterialSpecs(item._Material);
            }
            if (this.RefreshMaterialItemDataNotice != null)
                this.RefreshMaterialItemDataNotice(1, true, string.Empty);
        }
        private void labRefreshSupplier_Click(object sender, EventArgs e)
        {
            if (this._Items == null)
            {
                if (this.RefreshMaterialItemDataNotice == null)
                    this.RefreshMaterialItemDataNotice(2, false, "无明细需要刷新。");
            }
            foreach (ucMaterialItem item in this._Items)
            {
                item.BindSupplier(item._Material);
            }
            if (this.RefreshMaterialItemDataNotice != null)
                this.RefreshMaterialItemDataNotice(2, true, string.Empty);
        }
    }
    #region 相关类
    public class MaterialEntity
    {
        public MaterialEntity()
        {
        }
        public MaterialEntity(DataRow dr)
        {
            this.ReadFromDataRow(dr);
        }
        private object _iID;
        /// <summary>
        ///
        /// </summary>
        public object ID
        {
            get { return this._iID; }
            set { this._iID = value; }
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
        private object _strBOMMaterialGuid;
        /// <summary>
        ///
        /// </summary>
        public object BOMMaterialGuid
        {
            get { return this._strBOMMaterialGuid; }
            set { this._strBOMMaterialGuid = value; }
        }
        private object _strMaterialCode;
        /// <summary>
        ///
        /// </summary>
        public object MaterialCode
        {
            get { return this._strMaterialCode; }
            set { this._strMaterialCode = value; }
        }
        private object _strSpecGuid;
        /// <summary>
        ///
        /// </summary>
        public object SpecGuid
        {
            get { return this._strSpecGuid; }
            set { this._strSpecGuid = value; }
        }
        private object _strSupplierCode;
        /// <summary>
        ///
        /// </summary>
        public object SupplierCode
        {
            get { return this._strSupplierCode; }
            set { this._strSupplierCode = value; }
        }
        private object _decQuantity;
        /// <summary>
        ///
        /// </summary>
        public object Quantity
        {
            get { return this._decQuantity; }
            set { this._decQuantity = value; }
        }
        private object _strUnitCode;
        /// <summary>
        ///
        /// </summary>
        public object UnitCode
        {
            get { return this._strUnitCode; }
            set { this._strUnitCode = value; }
        }
        private object _strMaterialBatchNum;
        /// <summary>
        ///
        /// </summary>
        public object MaterialBatchNum
        {
            get { return this._strMaterialBatchNum; }
            set { this._strMaterialBatchNum = value; }
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
        private short _iSavedType;
        /// <summary>
        ///
        /// </summary>
        public short SavedType
        {
            get { return this._iSavedType; }
            set { this._iSavedType = value; }
        }
        private object _strMaterialName;
        /// <summary>
        ///
        /// </summary>
        public object MaterialName
        {
            get { return this._strMaterialName; }
            set { this._strMaterialName = value; }
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
        private object _strSupplierName;
        /// <summary>
        ///
        /// </summary>
        public object SupplierName
        {
            get { return this._strSupplierName; }
            set { this._strSupplierName = value; }
        }
        private object _strUnitName;
        /// <summary>
        ///
        /// </summary>
        public object UnitName
        {
            get { return this._strUnitName; }
            set { this._strUnitName = value; }
        }
        public void ReadFromDataRow(DataRow dr)
        {
            this.ID = dr["ID"].Equals(DBNull.Value) ? (long)0 : long.Parse(dr["ID"].ToString());
            this.GUID = dr["GUID"];
            this.BOMMaterialGuid = dr["BOMMaterialGuid"];
            this.MaterialCode = dr["MaterialCode"];
            this.SpecGuid = dr["SpecGuid"];
            this.SupplierCode = dr["SupplierCode"];
            this.Quantity = dr["Quantity"];
            this.UnitCode = dr["UnitCode"];
            this.MaterialBatchNum = dr["MaterialBatchNum"];
            this.Remark = dr["Remark"];
            this.SavedType = dr["SavedType"].Equals(DBNull.Value) ? (short)0 : short.Parse(dr["SavedType"].ToString());
            this.MaterialName = dr["MaterialName"];
            this.Spec = dr["Spec"];
            this.SupplierName = dr["SupplierName"];
            this.UnitName = dr["UnitName"];
        }

    }
    public delegate void RefreshMaterialItemDataCallBack(short RefrehsType, bool blSucesful, string sMsg);
    #endregion

}
