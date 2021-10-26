using Common;
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

namespace BasicData.Company
{
    public partial class frmCompanyEdit : frmBase
    {
        public frmCompanyEdit()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.MyCompany _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.MyCompany BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.MyCompany();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            return true;
        }
        private bool BindData(string strCode)
        {
            DataSet ds = null;
            List<CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM JC_Company WHERE Code='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "JC_Company", true));
            try
            {
                ds = CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (ds.Tables["JC_Company"].DefaultView.Count == 0)
            {
                this.ShowMsg("当前公司抬头不存在或已经被删除，请检查！");
                return false;
            }
            this.tbCode.Text = ds.Tables["JC_Company"].DefaultView[0].Row["Code"].ToString();
            this.tbCNName.Text = ds.Tables["JC_Company"].DefaultView[0].Row["CNName"].ToString();
            this.tbENName.Text = ds.Tables["JC_Company"].DefaultView[0].Row["ENName"].ToString();
            this.tbVirCode.Text = ds.Tables["JC_Company"].DefaultView[0].Row["VirCode"].ToString();
            this.tbShortName.Text = ds.Tables["JC_Company"].DefaultView[0].Row["ShortName"].ToString();
            this.tbFaxs.Text = ds.Tables["JC_Company"].DefaultView[0].Row["Faxs"].ToString();
            this.tbTels.Text = ds.Tables["JC_Company"].DefaultView[0].Row["Tels"].ToString();
            this.tbAddress.Text = ds.Tables["JC_Company"].DefaultView[0].Row["Address"].ToString();
            this.tbPostal.Text = ds.Tables["JC_Company"].DefaultView[0].Row["Postal"].ToString();
            this.tbRemark.Text = ds.Tables["JC_Company"].DefaultView[0].Row["Remark"].ToString();
            this.chkIsDefault.Checked = !ds.Tables["JC_Company"].DefaultView[0].Row["IsDefault"].Equals(DBNull.Value) &&
                (bool)ds.Tables["JC_Company"].DefaultView[0].Row["IsDefault"];
            this.DataSource = ds;
            return true;
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.tbCNName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入中文名称！");
                this.tbCNName.Focus();
                return false;
            }
            if (this.DataSource == null || this.DataSource.Tables["JC_Company"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据源不正确，请重新加载窗体！");
                return false;
            }
            return true;
        }
        private bool Save()
        {
            DataRow dr = this.DataSource.Tables["JC_Company"].DefaultView[0].Row;
            if (!dr["Code"].Equals(this.tbCode.Text.Trim()))
                dr["Code"] = this.tbCode.Text.Trim();
            if (!dr["VirCode"].Equals(this.tbVirCode.Text.Trim()))
                dr["VirCode"] = this.tbVirCode.Text.Trim();
            if (!dr["CNName"].Equals(this.tbCNName.Text.Trim()))
                dr["CNName"] = this.tbCNName.Text.Trim();
            if (!dr["ENName"].Equals(this.tbENName.Text.Trim()))
                dr["ENName"] = this.tbENName.Text.Trim();
            if (!dr["ShortName"].Equals(this.tbShortName.Text.Trim()))
                dr["ShortName"] = this.tbShortName.Text.Trim();
            if (!dr["Faxs"].Equals(this.tbFaxs.Text.Trim()))
                dr["Faxs"] = this.tbFaxs.Text.Trim();
            if (!dr["Tels"].Equals(this.tbTels.Text.Trim()))
                dr["Tels"] = this.tbTels.Text.Trim();
            if (!dr["Address"].Equals(this.tbAddress.Text.Trim()))
                dr["Address"] = this.tbAddress.Text.Trim();
            if (!dr["Postal"].Equals(this.tbPostal.Text.Trim()))
                dr["Postal"] = this.tbPostal.Text.Trim();
            if (!dr["Remark"].Equals(this.tbRemark.Text.Trim()))
                dr["Remark"] = this.tbRemark.Text.Trim();
            if ((!dr["IsDefault"].Equals(DBNull.Value) && (bool)dr["IsDefault"]) ^ this.chkIsDefault.Checked)
                dr["IsDefault"] = this.chkIsDefault.Checked;
            if (this.DataSource.GetChanges() == null)
                return true;
            try
            {
                this.BllDAL.Save(this.DataSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            return true;
        }
        #endregion
        #region 窗体加载
        private void frmCompanyEdit_Load(object sender, EventArgs e)
        {
            if (!this.PerInit()) return;

            this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString());
        }
        #endregion
        #region 窗体按钮事件
        private void btTrue_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck()) return;
            if (this.Save())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
