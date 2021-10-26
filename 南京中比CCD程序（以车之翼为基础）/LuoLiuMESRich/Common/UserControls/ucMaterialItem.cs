using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorService;

namespace Common.UserControls
{
    public partial class ucMaterialItem : UserControl
    {
        public MaterialEntity _Material = null;
        public ucMaterialItem()
        {
            InitializeComponent();
            this.comSpec.DisplayMember = "Text";
            this.comSupplier.DisplayMember = "Text";
        }
        public void SetMaterialEntity(MaterialEntity entity)
        {
            this.tbMaterialName.Text = entity.MaterialName.ToString();
            this.tbBatchNum.Text = entity.MaterialBatchNum.ToString();
            this.tbQuantity.Text = Common.CommonFuns.FormatData.GetStringByDecimal(entity.Quantity, "#########0");
            this.tbUnitName.Text = entity.UnitName.ToString();
            this._Material = entity;
            this.BindMaterialSpecs(entity);
            this.BindSupplier(entity);
        }
        public void BindMaterialSpecs(MaterialEntity entity)
        {
            DataTable dt;
            string strSql = string.Format("SELECT GUID,Spec FROM JC_MaterialSpecs WHERE MaterialCode='{0}' AND ISNULL(Terminated,0)=0 ORDER BY Spec ASC", entity.MaterialCode.ToString().Replace("'", "''"));
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            Common.MyEntity.ComboBoxItem item;
            this.comSpec.Items.Clear();
            int iSelIndex = -1;
            foreach (DataRow dr in dt.Rows)
            {
                item = new Common.MyEntity.ComboBoxItem();
                item.Text = dr["Spec"].ToString();
                item.Value = dr["GUID"].ToString();
                if (string.Compare(dr["GUID"].ToString(), entity.SpecGuid.ToString(), true) == 0)
                    iSelIndex = this.comSpec.Items.Add(item);
                else this.comSpec.Items.Add(item);
            }
            if (iSelIndex >= 0)
                this.comSpec.SelectedIndex = iSelIndex;
        }
        public void BindSupplier(MaterialEntity entity)
        {
            DataTable dt;
            string strSql = string.Format(@"SELECT A.SupplierCode,B.DefaultName AS SupplierName
                    FROM JC_MaterialSuppliers A LEFT JOIN JC_Supplier B ON B.Code=A.SupplierCode
                    WHERE A.MaterialCode='{0}'", entity.MaterialCode.ToString().Replace("'", "''"));
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            Common.MyEntity.ComboBoxItem item;
            this.comSupplier.Items.Clear();
            int iSelIndex = -1;
            foreach (DataRow dr in dt.Rows)
            {
                item = new Common.MyEntity.ComboBoxItem();
                item.Text = dr["SupplierName"].ToString();
                item.Value = dr["SupplierCode"].ToString();
                if (string.Compare(dr["SupplierCode"].ToString(), entity.SupplierCode.ToString(), true) == 0)
                    iSelIndex = this.comSupplier.Items.Add(item);
                else this.comSupplier.Items.Add(item);
            }
            if (iSelIndex >= 0)
                this.comSupplier.SelectedIndex = iSelIndex;
        }
        public bool Check(out string sErr)
        {
            if(this.comSpec.SelectedIndex==-1)
            {
                sErr = string.Format("请选择原材料{0}的规格！", this.tbMaterialName.Text);
                return false;
            }
            if (this.comSupplier.SelectedIndex == -1)
            {
                sErr = string.Format("请选择原材料{0}的供应商！", this.tbMaterialName.Text);
                return false;
            }
            if(this.tbBatchNum.Text.Trim().Length==0)
            {
                sErr = string.Format("请填写原材料{0}的批次号！", this.tbMaterialName.Text);
                return false;
            }
            if (this.tbQuantity.Text.Length==0)
            {
                sErr = string.Format("请填写原材料{0}的数量！", this.tbMaterialName.Text);
                return false;
            }
            else
            {
                decimal  decQuantity;
                if(!decimal.TryParse(this.tbQuantity.Text,out decQuantity))
                {
                    sErr = string.Format("请正确填写原材料{0}的数量，它需要一个数值！", this.tbMaterialName.Text);
                    return false;
                }
            }
            sErr = string.Empty;
            return true;
        }
        public MaterialEntity GetMaterialEntity(out string sErr)
        {
            if (_Material == null) _Material = new MaterialEntity();
            Common.MyEntity.ComboBoxItem itemSpec = this.comSpec.SelectedItem as Common.MyEntity.ComboBoxItem;
            if(itemSpec==null || itemSpec.Value==null || itemSpec.Value.ToString().Length==0)
            {
                sErr = string.Format("原材料{0}还未选择规格！", this.tbMaterialName.Text);
                return null;
            }
            Common.MyEntity.ComboBoxItem itemSupplier = this.comSpec.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (itemSupplier == null || itemSupplier.Value == null || itemSupplier.Value.ToString().Length == 0)
            {
                sErr = string.Format("原材料{0}还未选择供应商！", this.tbMaterialName.Text);
                return null;
            }
            if(this.tbBatchNum.Text.Length==0)
            {
                sErr = string.Format("原材料{0}还未填写批次！", this.tbMaterialName.Text);
                return null;
            }
            if (this.tbQuantity.Text.Length == 0)
            {
                sErr = string.Format("请填写原材料{0}的数量！", this.tbMaterialName.Text);
                return null;
            }
            else
            {
                decimal decQuantity;
                if (!decimal.TryParse(this.tbQuantity.Text, out decQuantity))
                {
                    sErr = string.Format("请正确填写原材料{0}的数量，它需要一个数值！", this.tbMaterialName.Text);
                    return null;
                }
                this._Material.Quantity = decQuantity;
            }
            this._Material.Spec = itemSpec.Text;
            this._Material.SpecGuid = itemSpec.Value.ToString();
            this._Material.SupplierName = itemSupplier.Text;
            this._Material.SupplierCode = itemSupplier.Value.ToString();
            this._Material.MaterialBatchNum = this.tbBatchNum.Text;
            sErr = string.Empty;
            return this._Material;
        }
    }
}
