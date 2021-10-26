using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicData.BOM
{
    public partial class frmMaterialAdd : BOM.frmBOM
    {
        string _BOMGuid = string.Empty;
        public frmMaterialAdd(string sBomGuid)
        {
            InitializeComponent();
            this._BOMGuid = sBomGuid;
            this.comProcess.DisplayMember = "Text";
        }
        private bool BindProcess()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format(@"SELECT ProcessCode,ProcessName FROM V_BOM_Product_Process WHERE ProGuid='{0}' ORDER BY SortID", this._BOMGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comProcess.Items.Clear();
            Common.MyEntity.ComboBoxItem item;
            foreach (DataRow dr in dt.Rows)
            {
                item = new Common.MyEntity.ComboBoxItem();
                item.Value = dr["ProcessCode"].ToString();
                item.Text = dr["ProcessName"].ToString();
                this.comProcess.Items.Add(item);
            }
            //读取原材料
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT MaterialCode,DefaultName,UnitCode,UnitName FROM [V_JC_Material] WHERE ISNULL(Terminated,0)=0 ORDER BY DefaultName");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            List<BasicData.UserControls.ucMateiralItem.MaterialEntity> list = new List<UserControls.ucMateiralItem.MaterialEntity>();
            BasicData.UserControls.ucMateiralItem.MaterialEntity entity;
            foreach (DataRow dr in dt.Rows)
            {
                entity = new UserControls.ucMateiralItem.MaterialEntity();
                entity.MaterialCode = dr["MaterialCode"].ToString();
                entity.MaterialName = dr["DefaultName"].ToString();
                entity.UnitCode = dr["UnitCode"].ToString();
                entity.UnitName = dr["UnitName"].ToString();
                list.Add(entity);
            }
            entity = new UserControls.ucMateiralItem.MaterialEntity();
            entity.MaterialCode = "";
            entity.MaterialName = "无";
            entity.UnitCode = "";
            entity.UnitName = "";
            list.Add(entity);
            this.uc1.BindMaterial(list);
            this.uc2.BindMaterial(list);
            this.uc3.BindMaterial(list);
            return true;
        }

        private void frmMaterialAdd_Load(object sender, EventArgs e)
        {
            this.btTrue.Enabled = this.BindProcess();
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            if(this.comProcess.SelectedIndex==-1)
            {
                this.ShowMsg("请选中工序！");
                return;
            }
            Common.MyEntity.ComboBoxItem process = this.comProcess.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (process == null || process.Value==null || process.Value.ToString().Length==0)
            {
                this.ShowMsg("请选中要添加物料的工序！");
                return;
            }
            BasicData.UserControls.ucMateiralItem.MateiralItemResult result1, result2, result3;
            string strErr;
            result1 = this.uc1.GetValues(out strErr);
            if (result1 == null)
            {
                if (strErr.Length == 0) strErr = "物料1或失败，原因未知！";
                this.ShowMsg(strErr);
                return;
            }
            result2 = this.uc2.GetValues(out strErr);
            if (result2 == null)
            {
                if (strErr.Length == 0) strErr = "物料2或失败，原因未知！";
                this.ShowMsg(strErr);
                return;
            }
            result3 = this.uc3.GetValues(out strErr);
            if (result3 == null)
            {
                if (strErr.Length == 0) strErr = "物料3或失败，原因未知！";
                this.ShowMsg(strErr);
                return;
            }
            List<BasicData.UserControls.ucMateiralItem.MateiralItemResult> listResult = new List<UserControls.ucMateiralItem.MateiralItemResult>();
            if (result1.MaterialCode.Length > 0)
                listResult.Add(result1);
            if (result2.MaterialCode.Length > 0)
                listResult.Add(result2);
            if (result3.MaterialCode.Length > 0)
                listResult.Add(result3);
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.MaterialAdd(this._BOMGuid, process.Value.ToString(), listResult, out strMsg, out iReturnValue);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if(iReturnValue!=1)
            {
                if (strMsg.Length == 0)
                    strMsg = "操作失败，原因未知！";
                this.ShowMsg(strMsg);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
