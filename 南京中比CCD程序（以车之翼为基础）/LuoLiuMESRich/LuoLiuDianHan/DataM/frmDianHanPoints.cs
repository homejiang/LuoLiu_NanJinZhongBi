using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuDianHan.DataM
{
    public partial class frmDianHanPoints : Common.frmBaseList
    {
        private string _Guid = string.Empty;
        public frmDianHanPoints(string sGuid)
        {
            InitializeComponent();
            this._Guid = sGuid;
        }
        private bool Perinit()
        {
            this.dgvList.AutoGenerateColumns = false;
            return true;
        }
        
        private bool BindData()
        {
            //获取表名
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select N from Mac_DianHan_ParameterTable where GUID='{0}'", this._Guid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if(dt.Rows.Count==0)
            {
                this.ShowMsg("传入的记录标识不存在！ID=[" + this._Guid + "]");
                return false;
            }
            string strSql = string.Format("SELECT * FROM LuoLiuMESDynamicTable.dbo.Mac_DianHan_Parameters_{0} where GUID='{1}' order by Times ASC",
                dt.Rows[0]["N"].ToString(), this._Guid.Replace("'", "''"));
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
        private void frmPfList_Load(object sender, EventArgs e)
        {
            this.Perinit();
            BindData();
        }
        
        
    }
}