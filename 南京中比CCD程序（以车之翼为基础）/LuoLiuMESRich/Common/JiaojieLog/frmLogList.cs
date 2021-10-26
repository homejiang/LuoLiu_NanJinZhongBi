using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace Common.JiaojieLog
{
    public partial class frmLogList : Common.frmBaseList
    {
        public frmLogList()
        {
            InitializeComponent();
        }
        public string _TypeCode = string.Empty;
        public string _MacCode = string.Empty;
        private bool PerInit()
        {
            #region 设置工具栏日期控件
            this.BarSearchDateTimeStart.Value = DateTime.Now.AddMonths(-1);
            this.BarSearchDateTimeStart.Checked = true;
            this.BarSearchDateTimeEnd.Value = DateTime.Now;
            this.BarSearchDateTimeEnd.Checked = false;
            this.InsertDateTimePicker(this.toolStrip1, this.tslTime.Name, false);//插入日期控件
            #endregion
            #region 设置combox回车事件
            this.SetBarSearchEnterKey(this.tscMac);
            this.SetBarSearchEnterKey(this);
            this.SetBarSearchEnterKey(this.BarSearchDateTimeStart);
            this.SetBarSearchEnterKey(this.BarSearchDateTimeEnd);
            #endregion
            this.dgvList.AutoGenerateColumns = false;
            #region 绑定机台
            DataTable dtMac;
            try
            {
                dtMac = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC ERPGenius_JJieLog_List_GetMacs '{0}','{1}'"
                    , _TypeCode.Replace("'", "''"), _MacCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dtMac != null && dtMac.Columns.Contains("MacCode"))
            {
                if (_MacCode == string.Empty)
                    this.tscMac.Items.Add(new Common.MyEntity.ComboBoxItem("所有机台", ""));
                this.tscMac.ComboBox.DisplayMember = "Text";
                this.tscMac.ComboBox.ValueMember = "Value";
                foreach (DataRow dr in dtMac.Rows)
                {
                    Common.MyEntity.ComboBoxItem item = new Common.MyEntity.ComboBoxItem();
                    item.Text = dr["MacName"].ToString();
                    item.Value = dr["MacCode"].ToString();
                    this.tscMac.Items.Add(item);
                }
                this.tscMac.SelectedIndex = 0;//默认选中第一行
            }
            else
            {
                this.tslMac.Visible = false;
                this.tscMac.Visible = false;
            }
            #endregion
            return true;
        }
        private bool BindData()
        {
            Common.MyEntity.ComboBoxItem itemMac = this.tscMac.SelectedItem as Common.MyEntity.ComboBoxItem;
            string strMac = itemMac == null ? string.Empty : itemMac.Value.ToString();
            string strSql = string.Format("EXEC ERPGenius_JJieLog_GetList '{0}','{1}'"
                , this._TypeCode.Replace("'", "''"), strMac.Replace("'", "''"));
            if (this.BarSearchDateTimeStart.Checked)
                strSql += string.Format(",'{0}'", this.BarSearchDateTimeStart.Value.ToString("yyyy-MM-dd"));
            else strSql += ",null";
            if (this.BarSearchDateTimeEnd.Checked)
                strSql += string.Format(",'{0}'", this.BarSearchDateTimeEnd.Value.AddDays(1).ToString("yyyy-MM-dd"));
            else strSql += ",null";
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = dt;
            return true;
        }
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
        #region 重写父函数
        public override void DoBarSearch()
        {
            this.tsbSearch_Click(null, null);
        }
        public override void InitParameters(string[] arrs)
        {
            this._TypeCode = arrs[0];
        }
        #endregion
        private void frmLogList_Load(object sender, EventArgs e)
        {
            this.PerInit();
            this.BindData();
        }
        private void OpenView(string sGuid,string sTypeCode)
        {
            Common.JiaojieLog.frmLog frm = new frmLog();
            frm.PrimaryValue = sGuid;
            frm._TypeCode = sTypeCode;
            frm.FormState = Common.MyEnums.FormStates.Readonly;
            frm.Show();
        }

        private void tscView_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            foreach (int index in list)
            {
                this.OpenView(dt.DefaultView[index].Row["GUID"].ToString(), dt.DefaultView[index].Row["TypeCode"].ToString());
            }
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            this.OpenView(dt.DefaultView[e.RowIndex].Row["GUID"].ToString(), dt.DefaultView[e.RowIndex].Row["TypeCode"].ToString());
        }
    }
}