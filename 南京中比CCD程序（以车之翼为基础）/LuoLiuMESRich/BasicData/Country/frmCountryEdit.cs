using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

using Common;
using Common.MyEnums;

namespace BasicData.Country
{
    public partial class frmCountryEdit : frmBase
    {
        public frmCountryEdit()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.Country _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Country BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.Country();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            //根据窗体状态限制操作
            bool isReadOnly = true;
            if (this.FormState == FormStates.New || this.FormState == FormStates.Copy)
            {
                isReadOnly = false;
                this.ChangeWinTitle("新建国家");
            }
            else if (this.FormState == FormStates.Edit)
            {
                isReadOnly = false;
                this.ChangeWinTitle(string.Format("国家{0}", this.PrimaryValue));
            }
            else if (this.FormState == FormStates.Readonly)
            {
                isReadOnly = true;
                this.ChangeWinTitle(string.Format("国家{0}（只读）", this.PrimaryValue));
            }
            this.btTrue.Enabled = !isReadOnly;
            this.btSaveAndNew.Enabled = !isReadOnly;
            return true;
        }
        private bool BindData(string strCode)
        {
            DataSet ds = null;
            List<CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM JC_Country WHERE Code='" + strCode + "'";
            listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "JC_Country", true));
            try
            {
                ds = CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = ds.Tables["JC_Country"];
            DataRow dr;
            if (dt.DefaultView.Count == 0)
            {
                if (this.PrimaryValue != null && this.PrimaryValue.ToString().Length > 0)
                {
                    this.ShowMsg("国家“" + this.PrimaryValue.ToString() + "”不存在或已被删除！");
                    return false;
                }
                dr = dt.NewRow();
                dr["Code"] = this.GetAutoCode(Common.MyEnums.Modules.CountryAndProvince);
                dt.Rows.Add(dr);
            }
            else
                dr = dt.DefaultView[0].Row;
            this.tbCode.Text = dr["Code"].ToString();
            this.tbCNName.Text = dr["CNName"].ToString();
            this.tbENName.Text = dr["ENName"].ToString();
            this.DataSource = ds;
            return true;
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.tbCNName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请至少输入国家中文名！");
                return false;
            }
            if (this.DataSource == null || this.DataSource.Tables["JC_Country"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据源不正确，请重新加载窗体！");
                return false;
            }
            //判断编码是否重复
            if (this.tbCode.Text.Trim().Length > 0)
            {
                if (this.FormState == FormStates.New
                    || (this.FormState == FormStates.Edit && !this.DataSource.Tables["JC_Country"].DefaultView[0].Row["Code"].Equals(this.tbCode.Text.Trim())))
                {
                    DataTable dt = null;
                    try
                    {
                        dt = CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_Country WHERE Code='{0}'", this.tbCode.Text.Trim().Replace("'", "''")));
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return false;
                    }
                    if (dt.Rows.Count > 0)
                    {
                        this.ShowMsg("国家编码“" + this.tbCode.Text.Trim() + "”已经存在，请更换!");
                        return false;
                    }
                }
            }
            if (this.FormState == FormStates.New
                    || (this.FormState == FormStates.Edit && !this.DataSource.Tables["JC_Country"].DefaultView[0].Row["CNName"].Equals(this.tbCNName.Text.Trim())))
            {
                DataTable dt = null;
                try
                {
                    dt = CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_Country WHERE CNName='{0}'", this.tbCNName.Text.Trim().Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("国家中文名“" + this.tbCNName.Text.Trim() + "”已经存在，请检查!");
                    return false;
                }
            }
            return true;
        }
        private bool Save()
        {
            this.ReadForm(this.DataSource);
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
        private void ReadForm(DataSet dsSource)
        {
            DataRow dr = dsSource.Tables["JC_Country"].DefaultView[0].Row;
            if (!dr["CNName"].Equals(this.tbCNName.Text.Trim()))
                dr["CNName"] = this.tbCNName.Text.Trim();
            if (!dr["ENName"].Equals(this.tbENName.Text.Trim()))
                dr["ENName"] = this.tbENName.Text.Trim();
            if (this.tbCode.Text.Trim().Length == 0)
                dr["Code"] = this.GetAutoCode(Common.MyEnums.Modules.CountryAndProvince);
            else if (!dr["Code"].Equals(this.tbCode.Text.Trim()))
                dr["Code"] = this.tbCode.Text.Trim();
        }
        #endregion
        #region 窗体按钮事件
        private void btTrue_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck())
                return;
            if (this.Save())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void btSaveAndNew_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck())
                return;
            if (this.Save())
            {
                this.DialogResult = DialogResult.OK;
                if (this.FormState == FormStates.New || this.FormState == FormStates.Copy)
                    this.FormState = FormStates.Edit;
                this.PrimaryValue = string.Empty;
                this.frmCountryEdit_Load(null, null);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            //此处不做校验，是否有修改过
            this.Close();
        }
        #endregion
        #region 窗体事件
        private void frmCountryEdit_Load(object sender, EventArgs e)
        {
            //先判断权限
            if (this.FormState == FormStates.None)
            {
                //如果当前窗体未设置状态，则校验权限
                List<OperatePower> listPower = this.GetOperatePower(Common.CurrentUserInfo.UserCode, Common.MyEnums.Modules.CountryAndProvince, this.PrimaryValue);
                if (listPower.Count == 0)
                {
                    //此时用户无任何权限，则关闭当前窗体
                    this.FormColse();
                    return;
                }
                if (this.PrimaryValue == null || this.PrimaryValue.ToString().Length == 0)
                {
                    //此时表示新建
                    if (!listPower.Contains(OperatePower.New))
                    {
                        this.ShowMsg("对不起，您拥有的权限无法新建国家,如有需要，您可以与管理联系，开放此权限。");
                        return;
                    }
                    this.FormState = FormStates.New;
                }
                else
                {
                    //此时表示编辑状态暂不用考虑删除权限，删除权限会在执行删除操作时进行判断
                    if (listPower.Contains(OperatePower.Eidt))
                    {
                        //有编辑权限
                        this.FormState = FormStates.Edit;
                    }
                    else
                    {
                        //删除权限，也当只读处理
                        this.FormState = FormStates.Readonly;
                    }
                }
            }
            if (this.FormState == FormStates.None)
            {
                this.ShowMsg("窗体状态不明，无法加载数据！");
                return;
            }
            //窗体预加载数据
            if (!this.PerInit())
                return;
            this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString());
        }
        #endregion
    }
}