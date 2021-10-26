using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common.MyEntity;
using Common.MyEnums;
using Common;

namespace SysSetting.DeptUsers
{
    public partial class frmDeptEdit : frmBase
    {
        public frmDeptEdit()
        {
            InitializeComponent();
        }
        #region 窗体属性
        private string _strParentDept = string.Empty;
        /// <summary>
        /// 上级部门代码
        /// </summary>
        public string ParentDeptCode
        {
            get { return this._strParentDept; }
            set { this._strParentDept = value; }
        }
        /// <summary>
        /// 上级部门名称
        /// </summary>
        public string ParentDeptName
        {
            get { return this.tbParentDeptName.Text; }
            set { this.tbParentDeptName.Text = value; }
        }
        #endregion
        #region 窗体数据连接实例
        private BLLDAL.DeptUsers _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.DeptUsers BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new SysSetting.BLLDAL.DeptUsers();
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
                this.ChangeWinTitle("新建部门");
            }
            else if (this.FormState == FormStates.Edit)
            {
                isReadOnly = false;
                this.ChangeWinTitle(string.Format("部门{0}", this.PrimaryValue));
            }
            else if (this.FormState == FormStates.Readonly)
            {
                isReadOnly = true;
                this.ChangeWinTitle(string.Format("部门{0}（只读）", this.PrimaryValue));
            }
            this.btTrue.Enabled = !isReadOnly;
            this.btSaveAndNew.Enabled = !isReadOnly;
            return true;
        }
        private bool BindData(string strDeptCode)
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "select * from V_Sys_Department WHERE DeptCode='" + strDeptCode + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_Department", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = ds.Tables["Sys_Department"];
            dt.Columns["ParentDeptName"].ReadOnly = false;
            DataRow dr;
            if (dt.DefaultView.Count == 0)
            {
                if (this.PrimaryValue != null && this.PrimaryValue.ToString().Length > 0)
                {
                    this.ShowMsg("部门“" + this.PrimaryValue.ToString() + "”不存在或已被删除。");
                    return false;
                }
                dr = dt.NewRow();
                dr["DeptCode"] = this.GetAutoCode(Modules.DeptAndUser, 1);
                dr["ParentDetpCode"] = this.ParentDeptCode;
                dr["ParentDeptName"] = this.ParentDeptName;
                dt.Rows.Add(dr);
            }
            else
                dr = dt.DefaultView[0].Row;
            this.tbDeptCode.Text = dr["DeptCode"].ToString();
            this.tbDeptName.Text = dr["DeptName"].ToString();
            this.tbShortName.Text = dr["DeptShortName"].ToString();
            this.tbDescript.Text = dr["Description"].ToString();
            this.ParentDeptCode = dr["ParentDetpCode"].ToString();
            this.ParentDeptName = dr["ParentDeptName"].ToString();
            this.DataSource = ds;
            return true;
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.tbDeptCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入部门编码。");
                return false;
            }
            if (this.tbDeptName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入部门名称。");
                return false;
            }
            if (this.DataSource == null || this.DataSource.Tables["Sys_Department"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据源不正确，请重新加载窗体。");
                return false;
            }
            //判断编码是否重复
            if (this.tbDeptCode.Text.Trim().Length > 0)
            {
                if (this.FormState == FormStates.New
                    || (this.FormState == FormStates.Edit && !this.DataSource.Tables["Sys_Department"].DefaultView[0].Row["DeptCode"].Equals(this.tbDeptCode.Text.Trim())))
                {
                    DataTable dt = null;
                    try
                    {
                        dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT DeptCode FROM Sys_Department WHERE DeptCode='{0}'", this.tbDeptCode.Text.Trim().Replace("'", "''")));
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return false;
                    }
                    if (dt.Rows.Count > 0)
                    {
                        this.ShowMsg("部门编码“" + this.tbDeptName.Text.Trim() + "”已经存在，请更换!");
                        return false;
                    }
                }
            }
            //判断编码是否重复
            if (this.tbDeptName.Text.Trim().Length > 0)
            {
                if (this.FormState == FormStates.New
                    || (this.FormState == FormStates.Edit && !this.DataSource.Tables["Sys_Department"].DefaultView[0].Row["DeptName"].Equals(this.tbDeptName.Text.Trim())))
                {
                    DataTable dt = null;
                    try
                    {
                        dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT DeptCode FROM Sys_Department WHERE DeptName='{0}'", this.tbDeptName.Text.Trim().Replace("'", "''")));
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return false;
                    }
                    if (dt.Rows.Count > 0)
                    {
                        this.ShowMsg("部门名称“" + this.tbDeptName.Text.Trim() + "”已经存在，请更换!");
                        return false;
                    }
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
                this.BllDAL.SaveGroup(this.DataSource);
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
            DataRow dr = dsSource.Tables["Sys_Department"].DefaultView[0].Row;
            if (!dr["DeptCode"].Equals(this.tbDeptCode.Text.Trim()))
                dr["DeptCode"] = this.tbDeptCode.Text.Trim();
            if (!dr["DeptName"].Equals(this.tbDeptName.Text.Trim()))
                dr["DeptName"] = this.tbDeptName.Text.Trim();
            if (!dr["DeptShortName"].Equals(this.tbShortName.Text.Trim()))
                dr["DeptShortName"] = this.tbShortName.Text.Trim();
            if (!dr["Description"].Equals(this.tbDescript.Text.Trim()))
                dr["Description"] = this.tbDescript.Text.Trim();
            if (!dr["ParentDetpCode"].Equals(this.ParentDeptCode))
                dr["ParentDetpCode"] = this.ParentDeptCode;
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
                this.frmDeptEdit_Load(null, null);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            //此处不做校验，是否有修改过
            this.Close();
        }
        #endregion
        #region 窗体事件
        private void frmDeptEdit_Load(object sender, EventArgs e)
        {
            //先判断权限
            if (this.FormState ==Common.MyEnums.FormStates.None)
            {
                //如果当前窗体未设置状态，则校验权限
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.CurrentUserInfo.UserCode, Common.MyEnums.Modules.DeptAndUser, this.PrimaryValue);
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
                        this.ShowMsg("对不起，您拥有的权限无法新建部门,如有需要，您可以与管理联系，开放此权限。");
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
                this.ShowMsg("窗体状态不明，无法加载数据。");
                return;
            }
            //窗体预加载数据
            if (!this.PerInit())
                return;
            this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString());
        }
        #endregion

        private void linkParentDeptName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSelectDeptSample frm = new frmSelectDeptSample();
            frm.SelectedDept = this.ParentDeptCode;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            this.ParentDeptCode = frm.SelectedDept;
            this.ParentDeptName = frm.SelectedDeptName;
        }
    }
}