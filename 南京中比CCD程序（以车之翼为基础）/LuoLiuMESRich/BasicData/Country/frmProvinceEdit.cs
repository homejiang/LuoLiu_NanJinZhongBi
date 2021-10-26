using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

using Common;
using Common.MyEntity;

namespace BasicData.Country
{
    public partial class frmProvinceEdit : frmBase
    {
        public frmProvinceEdit()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.Province _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Province BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.Province();
                return _dal;
            }
        }

        #endregion
        #region 处理函数
        /// <summary>
        /// 设置系统默认数据
        /// </summary>
        /// <returns></returns>
        private bool SetDefaultData()
        {
            //添加
            DataSet ds = null;
            List<CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            listSql.Add(new CommonDAL.SqlSearchEntiy("SELECT Code as CountryCode,ISNULL(CNName,ENName) as country FROM JC_Country ORDER BY ISNULL(CNName,ENName) asc", "JC_Country", false));
            try
            {
                ds = CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comContry.DisplayMember = "Text";
            this.comContry.ValueMember = "Value";
            this.comContry.DataSource = Common.CommonFuns.FormatData.GetComboBoxItemList(ds.Tables["JC_Country"], "country", "CountryCode");
            return true;
        }
        private bool PerInit()
        {
            return true;
        }
        private bool BindData(string strCode)
        {
            DataSet ds=null;
            List<CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM V_JC_ProvinceCountry WHERE Code='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "V_JC_ProvinceCountry", true));
            try
            {
                ds = CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (ds.Tables["V_JC_ProvinceCountry"].DefaultView.Count == 0)
            {
                this.ShowMsg("当前省份不存在或已经被删除，请检查！");
                return false;
            }
            this.tbCNName.Text = ds.Tables["V_JC_ProvinceCountry"].DefaultView[0].Row["CNName"].ToString();
            this.tbENName.Text = ds.Tables["V_JC_ProvinceCountry"].DefaultView[0].Row["ENName"].ToString();
            this.tbCode.Text = ds.Tables["V_JC_ProvinceCountry"].DefaultView[0].Row["Code"].ToString();
            Common.CommonFuns.FormatData.SetComboBoxText(this.comContry, new Common.MyEntity.ComboBoxItem("", ds.Tables["V_JC_ProvinceCountry"].DefaultView[0].Row["CountryCode"].ToString()), 0);
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
                return false;
            }
            ComboBoxItem item=this.comContry.SelectedItem as ComboBoxItem;
            if (item==null || item.Value==null || item.Value.ToString().Length==0)
            {
                this.ShowMsg("请选择国家！");
                return false;
            }
            if (this.DataSource == null || this.DataSource.Tables["V_JC_ProvinceCountry"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据源不正确，请重新加载窗体！");
                return false;
            }
            //判断同一国家内是否省份中文名称已经存在
            if (!this.DataSource.Tables["V_JC_ProvinceCountry"].DefaultView[0].Row["CNName"].Equals(this.tbCNName.Text.Trim())
                || this.DataSource.Tables["V_JC_ProvinceCountry"].DefaultView[0].Row["CountryCode"].Equals(item.Value.ToString()))
            {
                DataTable dt = null;
                try
                {
                    dt = CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM V_JC_ProvinceCountry WHERE CountryCode='{0}' AND CNName='{1}'", item.Value.ToString().Replace("'", "''"), this.tbCNName.Text.Trim().Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("国家“" + item.Text + "”中省份中文名称“" + this.tbCNName.Text.Trim() + "”已经存在，请检查！");
                    return false;
                }
            }
            return true;
        }
        private bool Save()
        {
            DataRow dr = this.DataSource.Tables["V_JC_ProvinceCountry"].DefaultView[0].Row;
            if (!dr["CNName"].Equals(this.tbCNName.Text.Trim()))
                dr["CNName"] = this.tbCNName.Text.Trim();
            if (!dr["ENName"].Equals(this.tbENName.Text.Trim()))
                dr["ENName"] = this.tbENName.Text.Trim();
            if (this.tbCode.Text.Trim().Length == 0)
                dr["Code"] = this.GetAutoCode(Common.MyEnums.Modules.Province);
            else
                dr["Code"] = this.tbCode.Text.Trim();
            ComboBoxItem item = this.comContry.SelectedItem as ComboBoxItem;
            if (item == null || item.Value == null)
                dr["CountryCode"] = DBNull.Value;
            else
                dr["CountryCode"] = item.Value;
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
        #region 窗体事件
        private void frmUnitEdit_Load(object sender, EventArgs e)
        {
            this.SetDefaultData();
            if (!this.PerInit()) return;
            this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString());
        }
        #endregion
    }
}