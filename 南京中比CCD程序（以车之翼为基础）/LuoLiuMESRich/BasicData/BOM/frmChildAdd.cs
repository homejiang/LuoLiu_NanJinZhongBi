using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorService;

namespace BasicData.BOM
{
    public partial class frmChildAdd : BOM.frmBOM
    {
        string _DefaultClassCode = "";
        string _BOMGuid = "";
        public frmChildAdd(string sDefaultClass,string sBOMGuid)
        {
            InitializeComponent();
            this.comChildSpec.DisplayMember = "Text";
            this.comChildClass.DisplayMember = "Text";
            _DefaultClassCode = sDefaultClass;
            _BOMGuid = sBOMGuid;
        }
        private void BindClass()
        {
            string strClass;
            Common.MyEntity.ComboBoxItem item = this.comChildClass.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item != null && item.Value != null)
                strClass = item.Value.ToString();
            else strClass = string.Empty;
            //加载选中BOM类型的基础信息
            string strSql = "select Code,ClassName from BOM_Sys_ProductClass where isnull(Terminated,0)=0 order by SortID";
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.comChildClass.Items.Clear();
            int iSeledIndex = -1;
            foreach(DataRow dr in dt.Rows)
            {
                Common.MyEntity.ComboBoxItem classData = new Common.MyEntity.ComboBoxItem();
                classData.Value = dr["Code"].ToString();
                classData.Text = dr["ClassName"].ToString();
                if (string.Compare(this._DefaultClassCode, dr["Code"].ToString(), true) == 0)
                    iSeledIndex = this.comChildClass.Items.Add(classData);
                else
                    this.comChildClass.Items.Add(classData);
            }
            if (iSeledIndex != -1)
                this.comChildClass.SelectedIndex = iSeledIndex;
        }
        private void BindSpecs()
        {
            string strClass;
            Common.MyEntity.ComboBoxItem item = this.comChildClass.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item != null && item.Value != null)
                strClass = item.Value.ToString();
            else strClass = string.Empty;
            //加载选中BOM类型的基础信息
            string strSql = string.Format("SELECT Spec,GUID FROM BOM_Product WHERE ClassCode='{0}' AND ISNULL(Terminated,0)=0 ORDER BY Spec", strClass.Replace("'", "''"));
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.comChildSpec.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                Common.MyEntity.ComboBoxItem specData = new Common.MyEntity.ComboBoxItem();
                specData.Value = dr["GUID"].ToString();
                specData.Text = dr["Spec"].ToString();
                this.comChildSpec.Items.Add(specData);
            }
        }

        private void frmChildAdd_Load(object sender, EventArgs e)
        {
            BindClass();
        }

        private void comChildClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSpecs();
        }

        private void comChildSpec_SelectedValueChanged(object sender, EventArgs e)
        {
            string strGUID;
            Common.MyEntity.ComboBoxItem item = this.comChildSpec.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item != null && item.Value != null)
                strGUID = item.Value.ToString();
            else strGUID = string.Empty;
            if (strGUID.Length == 0)
            {
                this.tbUnitName.Text = string.Empty;
                return;
            }
            //仅加载计量单位
            string strSql = string.Format("SELECT B.DefaultName FROM BOM_Product A LEFT JOIN JC_Unit B ON B.Code=A.UnitCode WHERE A.GUID='{0}'", strGUID.Replace("'", "''"));
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.DefaultView.Count == 0)
                this.tbUnitName.Clear();
            else
            {
                this.tbUnitName.Text = dt.DefaultView[0].Row["DefaultName"].ToString();
            }
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            string strGUID;
            Common.MyEntity.ComboBoxItem item = this.comChildSpec.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item != null && item.Value != null)
                strGUID = item.Value.ToString();
            else strGUID = string.Empty;
            if (strGUID.Length == 0)
            {
                this.ShowMsg("请选择自检规格！");
                return;
            }
            decimal decQuantity;
            if(this.tbQuantity.Text.Length==0)
            {
                this.ShowMsg("请输入数量。");
                return; 
            }
            if(!decimal.TryParse(this.tbQuantity.Text,out decQuantity))
            {
                this.ShowMsg("请正确输入数量。");
                return;
            }
            //提交数据库
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.ChildAdd(this._BOMGuid, strGUID, decQuantity, out strMsg, out iReturnValue);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if(iReturnValue!=1)
            {
                if (strMsg.Length == 0) strMsg = "操作失败，原因失败！";
                this.ShowMsg(strMsg);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
