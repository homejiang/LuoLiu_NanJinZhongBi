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

namespace BasicData.UserControls
{
    public partial class ucMateiralItem : UserControl
    {
        public string _UnitCode = string.Empty;
        public ucMateiralItem()
        {
            InitializeComponent();
            this.comMaterial.DisplayMember = "MaterialName";
            this.comSpec.DisplayMember = "Text";
        }
        public void BindMaterial(List<MaterialEntity> listMaterial)
        {
            foreach(MaterialEntity entity in listMaterial)
            {
                this.comMaterial.Items.Add(entity);
            }
            //this.comMaterial.DataSource = listMaterial;
        }
        #region 相关类
        public class MaterialEntity
        {
            public string MaterialCode = string.Empty;
            string mMaterialName = "";
            public string MaterialName
            {
                get
                {
                    return mMaterialName;
                }
                set
                {
                    mMaterialName = value;
                }
            }
            public string UnitCode = string.Empty;
            public string UnitName = string.Empty;
            public MaterialEntity()
            {

            }
            public MaterialEntity(string sCode,string sName,string sUnitCode,string sUnitName)
            {
                this.MaterialCode = sCode;
                this.MaterialName = sName;
                this.UnitCode = sUnitCode;
                this.UnitName = sUnitName;
            }
        }
        public class MateiralItemResult
        {
            public string MaterialCode = string.Empty;
            public string SpecGuid = string.Empty;
            public decimal Quantity = 0M;
            public string UnitCode = string.Empty;
        }
        #endregion
        private void comMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            //加载选中物料的规格
            MaterialEntity item = this.comMaterial.SelectedItem as MaterialEntity;
            if(item==null || item.MaterialCode.Length==0)
            {
                this.comSpec.Items.Clear();
            }
            else
            {
                this._UnitCode = item.UnitCode;
                this.tbUnitName.Text = item.UnitName;
                DataTable dt;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format(@"SELECT GUID,Spec FROM JC_MaterialSpecs WHERE MaterialCode='{0}' AND ISNULL(Terminated,0)=0 ORDER BY Spec", item.MaterialCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                this.comSpec.Items.Clear();
                Common.MyEntity.ComboBoxItem specItem;
                foreach (DataRow dr in dt.Rows)
                {
                    specItem = new Common.MyEntity.ComboBoxItem();
                    specItem.Value = dr["GUID"].ToString();
                    specItem.Text = dr["Spec"].ToString();
                    this.comSpec.Items.Add(specItem);
                }
                specItem = new Common.MyEntity.ComboBoxItem();
                specItem.Value = string.Empty;
                specItem.Text = "不指定规格";
                this.comSpec.Items.Add(specItem);
            }
        }
        public MateiralItemResult GetValues(out string sErr)
        {
            sErr = string.Empty;
            if (this.comMaterial.SelectedIndex == -1) return new MateiralItemResult();
            MaterialEntity material = this.comMaterial.SelectedItem as MaterialEntity;
            if (material == null || material.MaterialCode.Length == 0)
            {
                return new MateiralItemResult();
            }
            if (this.comSpec.SelectedIndex == -1)
            {
                sErr = "请选中物料规格！";
                return null;
            }
            Common.MyEntity.ComboBoxItem spec = this.comSpec.SelectedItem as Common.MyEntity.ComboBoxItem;
            string strSpecGuid;
            if (spec == null || spec.Value == null || spec.Value.ToString().Length == 0)
            {
                strSpecGuid = string.Empty;
            }
            else strSpecGuid = spec.Value.ToString();
            //获取数量
            decimal decQuality;
            if(this.tbQuantity.Text.Length==0)
            {
                sErr = "请输入数量！";
            }
            if (!decimal.TryParse(this.tbQuantity.Text, out decQuality))
            {
                sErr = string.Format("请正确填写数量，\"{0}\"不是有效的数值！", this.tbQuantity.Text);
                return null;
            }
            MateiralItemResult result = new MateiralItemResult();
            result.MaterialCode = material.MaterialCode;
            result.SpecGuid = strSpecGuid;
            result.Quantity = decQuality;
            result.UnitCode = material.UnitCode;
            return result;
        }
        
    }
}
