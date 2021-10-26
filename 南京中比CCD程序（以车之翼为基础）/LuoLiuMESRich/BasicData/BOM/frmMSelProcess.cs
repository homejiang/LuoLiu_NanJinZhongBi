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
    public partial class frmMSelProcess : BOM.frmBOM
    {
        string _BomGuid = string.Empty;
        long _GuidBehind = -1;
        public frmMSelProcess(string sBOMGuid, long lGuidBehind)
        {
            InitializeComponent();
            this._BomGuid = sBOMGuid;
            this._GuidBehind = lGuidBehind;
            this.comProcess.DisplayMember = "Text";
            if (this._GuidBehind > 0)
                this.labNowPan.Text = "请选择要插入的工序";
            else
                this.labNowPan.Text = "请选择要添加的工序";
        }
        private bool BindData()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format(@"select code,ProcessName from JC_Process A LEFT JOIN BOM_Product_Process B ON B.ProcessCode=A.Code
                WHERE B.ProGuid='{0}' AND B.ID IS NULL ORDER BY A.SortID ASC", _BomGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comProcess.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                Common.MyEntity.ComboBoxItem item = new Common.MyEntity.ComboBoxItem();
                item.Value = dr["code"].ToString();
                item.Text = dr["ProcessName"].ToString();
                this.comProcess.Items.Add(item);
            }
            return true;
        }

        private void frmProcessAdd_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if(this.comProcess.SelectedIndex==-1)
            {
                this.ShowMsg("请选中一个工序！");
                return;
            }
            Common.MyEntity.ComboBoxItem item = this.comProcess.SelectedItem as Common.MyEntity.ComboBoxItem;
            if(item==null)
            {
                this.ShowMsg("请选中工序。");
                return;
            }
            if (item.Value==null || item.Value.ToString().Length==0)
            {
                this.ShowMsg("选中的工序代码为空！");
                return;
            }
            //添加工序
            int iReturnValue;
            string strMsg;
            object objBehind;
            if (this._GuidBehind < 0) objBehind = DBNull.Value;
            else objBehind = this._GuidBehind;
            try
            {
                this.BllDAL.ProcessAdd(_BomGuid, objBehind, item.Value.ToString(), out strMsg, out iReturnValue);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if(iReturnValue!=1)
            {
                if (strMsg.Length == 0) strMsg = "操作失败，原因未知。";
                this.ShowMsg(strMsg);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
