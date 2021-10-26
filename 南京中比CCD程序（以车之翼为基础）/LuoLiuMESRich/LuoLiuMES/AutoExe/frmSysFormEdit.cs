using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES.AutoExe
{
    public partial class frmSysFormEdit : Common.frmBaseEdit
    {
        public frmSysFormEdit()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.AutoExe _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.AutoExe BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new LuoLiuMES.BLLDAL.AutoExe();
                return _dal;
            }
        }
        #endregion
        #region 公共属性
        public string _GroupCode = string.Empty;
        public string FormCode
        {
            get { return this.tbCode.Text; }
        }
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            this.htmlRemark.ShowExpButton("全屏显示");
            this.htmlRemark.OnExpButton+=new Common.HTMLTextBox.HtmlEditorSaveHandler(htmlRemark_OnExpButton);
            this.listParameters.DisplayMember = "Text";
            this.listParameters.ValueMember="Value";
            this.listPowerList.DisplayMember = "Text";
            this.listPowerList.ValueMember = "Value";
            return true;
        }
        private bool BindData(string sCode)
        {
            DataSet ds;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM [V_AutoExe_Sys_Forms] WHERE Code='{0}'"
                , sCode.Replace("'", "''")), "AutoExe_Sys_Forms", true));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM [AutoExe_Sys_Parameters] WHERE FormCode='{0}' ORDER BY [ID] ASC"
                , sCode.Replace("'", "''")), "AutoExe_Sys_Parameters", true));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM [V_AutoExe_Sys_PowerList] WHERE FormCode='{0}' ORDER BY [ID] ASC"
                , sCode.Replace("'", "''")), "AutoExe_Sys_PowerList", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            ds.Tables["AutoExe_Sys_Parameters"].Columns["ID"].AutoIncrement = true;
            ds.Tables["AutoExe_Sys_PowerList"].Columns["ID"].AutoIncrement = true;
            if (ds.Tables["AutoExe_Sys_Forms"].Rows.Count == 0)
            {
                DataRow drNew = ds.Tables["AutoExe_Sys_Forms"].NewRow();
                drNew["Code"] = this.GetAutoCode(Common.MyEnums.Modules.AutoExe_SysForms);
                DataTable dtSort;
                try
                {
                    dtSort = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MAX(SortID) FROM AutoExe_Sys_Forms WHERE GroupCode='{0}'"
                        , _GroupCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                int iSortID;
                if (dtSort.Rows[0][0].Equals(DBNull.Value))
                    iSortID = 1;
                else iSortID = int.Parse(dtSort.Rows[0][0].ToString()) + 1;
                drNew["SortID"] = iSortID;
                drNew["UserLevel"] = 0;
                drNew["IsMulti"] = false;
                drNew["DialogType"] = 0;
                //添加组名
                DataTable dtGroup;
                try
                {
                    dtGroup = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code,GroupName,dbo.[AutoExe_GetGroupFullName](Code) AS FullGroupName FROM AutoExe_Sys_Group WHERE Code='{0}'"
                        , this._GroupCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dtGroup.Rows.Count == 0)
                {
                    this.ShowMsg("传入的组编码不存在。(Code:" + this._GroupCode + ")");
                    return false;
                }
                drNew["GroupCode"] = dtGroup.Rows[0]["Code"];
                drNew["GroupName"] = dtGroup.Rows[0]["FullGroupName"];
                ds.Tables["AutoExe_Sys_Forms"].Rows.Add(drNew);
            }
            this.DataSource = ds;
            DataRow dr = ds.Tables["AutoExe_Sys_Forms"].DefaultView[0].Row;
            this.tbCode.Text = dr["Code"].ToString();
            this.tbGroupName.Text = dr["GroupName"].ToString();
            this.tbSortID.Text = dr["SortID"].ToString();
            this.tbOpenedName.Text = dr["OpenedName"].ToString();
            this.tbFormName.Text = dr["FormName"].ToString();
            this.tbClassName.Text = dr["ClassName"].ToString();
            this.tbProjectName.Text = dr["ProjectName"].ToString();
            this.radioLevel0.Checked = dr["UserLevel"].ToString() == "0";
            this.radioLevel1.Checked = dr["UserLevel"].ToString() == "1";
            this.radioLevel2.Checked = dr["UserLevel"].ToString() == "2";
            this.radioType0.Checked = dr["DialogType"].ToString() == "0";
            this.radioType1.Checked = dr["DialogType"].ToString() == "1";
            this.radioType2.Checked = dr["DialogType"].ToString() == "2";
            this.chkIsMulti.Checked = !dr["IsMulti"].Equals(DBNull.Value) && (bool)dr["IsMulti"];
            this.chkCheckPower.Checked = !dr["CheckPower"].Equals(DBNull.Value) && (bool)dr["CheckPower"];
            this.htmlRemark.BodyHTML = dr["Remark"].ToString();
            BindParameters(ds.Tables["AutoExe_Sys_Parameters"]);
            BindPowerList(ds.Tables["AutoExe_Sys_PowerList"]);
            SetFormState();
            return true;
        }
        private void BindParameters(DataTable dt)
        {
            if (string.Compare(dt.DefaultView.Sort, "ID ASC", true) != 0)
                dt.DefaultView.Sort = "ID ASC";
            this.listParameters.Items.Clear();
            Common.MyEntity.ComboBoxItem item;
            foreach (DataRowView drv in dt.DefaultView)
            {
                item = new Common.MyEntity.ComboBoxItem();
                item.Text = drv.Row["PValue"].ToString();
                item.Value = drv.Row["ID"].ToString();
                this.listParameters.Items.Add(item);
            }
        }
        private void BindPowerList(DataTable dt)
        {
            if (string.Compare(dt.DefaultView.Sort, "ID ASC", true) != 0)
                dt.DefaultView.Sort = "ID ASC";
            this.listPowerList.Items.Clear();
            Common.MyEntity.ComboBoxItem item;
            foreach (DataRowView drv in dt.DefaultView)
            {
                item = new Common.MyEntity.ComboBoxItem();
                item.Text = string.Format("{0}{1}({2})", drv.Row["EnumNo"].ToString(), drv.Row["ModuleName"].ToString(), drv.Row["Powers"].ToString());
                item.Value = drv.Row["ID"].ToString();
                this.listPowerList.Items.Add(item);
            }
        }
        private void SetFormState()
        {
            this.linkPowerAdd.Enabled = this.chkCheckPower.Checked;
            this.linkPowerEdit.Enabled = this.chkCheckPower.Checked;
            this.linkPowerRemove.Enabled = this.chkCheckPower.Checked;
            this.listPowerList.Enabled = this.chkCheckPower.Checked;
        }
        #endregion
        #region 保存函数
        private bool SaveCheck()
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空，请重新打开窗体。");
                return false;
            }
            if (this.FormState != Common.MyEnums.FormStates.New && this.FormState != Common.MyEnums.FormStates.Edit)
            {
                this.ShowMsg("当前窗体状态不能编辑。");
                return false;
            }
            if (this.tbCode.Text.Trim() == string.Empty)
            {
                this.ShowMsg("请输入窗体编码。");
                return false;
            }
            if (this.tbClassName.Text.Trim() == string.Empty)
            {
                this.ShowMsg("请输入\"详细类名（包含命名空间）\"。");
                return false;
            }
            if (this.tbProjectName.Text.Trim() == string.Empty)
            {
                this.ShowMsg("请输入\"所在项目名称\"。");
                return false;
            }
            if (!this.radioLevel0.Checked && !this.radioLevel1.Checked && !this.radioLevel2.Checked)
            {
                this.ShowMsg("请选择\"用户类型\"。");
                return false;
            }
            if (!this.radioType0.Checked && !this.radioType1.Checked && !this.radioType2.Checked)
            {
                this.ShowMsg("请选择\"打开方式\"。");
                return false;
            }
            if (this.chkCheckPower.Checked)
            {
                if (listPowerList.Items.Count == 0)
                {
                    this.ShowMsg("请指定权限校验模块。");
                    return false;
                }
            }
            return true;
        }
        private bool ReadForm(DataSet dsSource)
        {
            DataRow dr = dsSource.Tables["AutoExe_Sys_Forms"].DefaultView[0].Row;
            if (dr["Code"].ToString() != this.tbCode.Text)
                dr["Code"] = this.tbCode.Text;
            if (dr["FormName"].ToString() != this.tbFormName.Text)
                dr["FormName"] = this.tbFormName.Text;
            if (dr["OpenedName"].ToString() != this.tbOpenedName.Text)
                dr["OpenedName"] = this.tbOpenedName.Text;
            if (dr["ClassName"].ToString() != this.tbClassName.Text)
                dr["ClassName"] = this.tbClassName.Text;
            if (dr["ProjectName"].ToString() != this.tbProjectName.Text)
                dr["ProjectName"] = this.tbProjectName.Text;
            short iDialogType, iUserLevel;
            if (this.radioLevel0.Checked)
                iUserLevel = 0;
            else if (this.radioLevel1.Checked)
                iUserLevel = 1;
            else if (this.radioLevel2.Checked)
                iUserLevel = 2;
            else iUserLevel = -1;
            if (!dr["UserLevel"].Equals(iUserLevel))
                dr["UserLevel"] = iUserLevel;
            if (this.radioType0.Checked)
                iDialogType = 0;
            else if (this.radioType1.Checked)
                iDialogType = 1;
            else if (this.radioType2.Checked)
                iDialogType = 2;
            else iDialogType = -1;
            if (!dr["DialogType"].Equals(iDialogType))
                dr["DialogType"] = iDialogType;

            if ((!dr["IsMulti"].Equals(DBNull.Value) && (bool)dr["IsMulti"]) ^ this.chkIsMulti.Checked)
                dr["IsMulti"] = this.chkIsMulti.Checked;
            if ((!dr["CheckPower"].Equals(DBNull.Value) && (bool)dr["CheckPower"]) ^ this.chkCheckPower.Checked)
                dr["CheckPower"] = this.chkCheckPower.Checked;
            string strRemark = this.htmlRemark.GetBodyHTML();
            if (dr["Remark"].ToString() != strRemark)
                dr["Remark"] = strRemark;
            //读取明细信息
            if (!this.chkCheckPower.Checked)
            {
                //不需要校验权限时，需要移除权限表明细
                for (int i = dsSource.Tables["AutoExe_Sys_PowerList"].DefaultView.Count; i > 0; i--)
                {
                    dsSource.Tables["AutoExe_Sys_PowerList"].DefaultView[i - 1].Row.Delete();
                }
            }
            //校验明细表中的父表字段值
            foreach (DataRowView drv in dsSource.Tables["AutoExe_Sys_Parameters"].DefaultView)
            {
                if (drv.Row["FormCode"].ToString() != dr["Code"].ToString())
                    drv.Row["FormCode"] = dr["Code"];
            }
            foreach (DataRowView drv in dsSource.Tables["AutoExe_Sys_PowerList"].DefaultView)
            {
                if (drv.Row["FormCode"].ToString() != dr["Code"].ToString())
                    drv.Row["FormCode"] = dr["Code"];
            }
            return true;
        }
        private bool Save(DataSet dsSource)
        {
            if (!this.ReadForm(dsSource)) return false;
            if (dsSource.GetChanges() == null) return true;
            try
            {
                this.BllDAL.SaveSysForm(dsSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (this.PrimaryValue == null || this.PrimaryValue.ToString() != this.tbCode.Text)
                this.PrimaryValue = this.tbCode.Text;
            if (this.FormState == Common.MyEnums.FormStates.New)
                this.FormState = Common.MyEnums.FormStates.Edit;
            return true;
        }
        #endregion
        #region 窗体事件
        protected void htmlRemark_OnExpButton(HtmlElement element)
        {
            frmSysFormEditRemark frm = new frmSysFormEditRemark();
            frm._BodyHtml = this.htmlRemark.GetBodyHTML();
            frm.ShowDialog(this);
            if (!frm._Saved)
                return;
            this.htmlRemark.BodyHTML = frm._BodyHtml;
            this.htmlRemark.BodyHTMLRefresh();
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck()) return;
            DataSet dsSource = this.DataSource.Copy();
            if (this.Save(dsSource))
            {
                this.ShowMsg("保存成功！");
                //this.BindData(this.PrimaryValue.ToString());
                this.DialogResult = DialogResult.OK;
            }
        }
        
        private void chkCheckPower_CheckedChanged(object sender, EventArgs e)
        {
            this.listPowerList.Enabled = this.chkCheckPower.Checked;
            this.linkPowerAdd.Enabled = this.chkCheckPower.Checked;
            this.linkPowerEdit.Enabled = this.chkCheckPower.Checked;
            this.linkPowerRemove.Enabled = this.chkCheckPower.Checked;
        }
        #endregion
        #region 参数明细操作
        private void linkParaAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.New && this.FormState != Common.MyEnums.FormStates.Edit)
            {
                this.ShowMsg("当前窗体状态不能编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空，请重新打开窗体。");
                return;
            }
            frmSysFormEditPara frm = new frmSysFormEditPara();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            DataTable dt = this.DataSource.Tables["AutoExe_Sys_Parameters"];
            DataRow drNew = dt.NewRow();
            drNew["PValue"] = frm.Parameter;
            dt.Rows.Add(drNew);
            this.BindParameters(this.DataSource.Tables["AutoExe_Sys_Parameters"]);
        }

        private void linkParaEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.New && this.FormState != Common.MyEnums.FormStates.Edit)
            {
                this.ShowMsg("当前窗体状态不能编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空，请重新打开窗体。");
                return;
            }
            if (this.listParameters.SelectedItems.Count == 0)
            {
                this.ShowMsg("请至少选择一行。");
                return;
            }
            if (this.listParameters.SelectedItems.Count > 1)
            {
                this.ShowMsg("每次只能编辑一行参数。");
                return;
            }
            Common.MyEntity.ComboBoxItem item = this.listParameters.SelectedItems[0] as Common.MyEntity.ComboBoxItem;
            DataRow[] drs = this.DataSource.Tables["AutoExe_Sys_Parameters"].Select("ID=" + item.Value.ToString() + "");
            if (drs.Length > 0)
            {
                frmSysFormEditPara frm = new frmSysFormEditPara();
                frm.Parameter = drs[0]["PValue"].ToString();
                if (DialogResult.OK != frm.ShowDialog(this)) return;
                if (frm.Parameter != drs[0]["PValue"].ToString())
                    drs[0]["PValue"] = frm.Parameter;
                this.BindParameters(this.DataSource.Tables["AutoExe_Sys_Parameters"]);
            }
        }

        private void linkParaRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.New && this.FormState != Common.MyEnums.FormStates.Edit)
            {
                this.ShowMsg("当前窗体状态不能编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空，请重新打开窗体。");
                return;
            }
            if (this.listParameters.SelectedItems.Count > 0)
            {
                if (!this.IsUserConfirm("您确定要移除选中的参数吗？")) return;
            }
            Common.MyEntity.ComboBoxItem item;
            foreach (object obj in this.listParameters.SelectedItems)
            {
                item = obj as Common.MyEntity.ComboBoxItem;
                if (item != null && item.Value != null)
                {
                    foreach (DataRow dr in this.DataSource.Tables["AutoExe_Sys_Parameters"].Select("ID=" + item.Value.ToString() + ""))
                        dr.Delete();
                }
            }
            this.BindParameters(this.DataSource.Tables["AutoExe_Sys_Parameters"]);
        }
        #endregion
        #region 权限明细操作
        private void linkPowerAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.New && this.FormState != Common.MyEnums.FormStates.Edit)
            {
                this.ShowMsg("当前窗体状态不能编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空，请重新打开窗体。");
                return;
            }
            frmSysFormEditPower frm = new frmSysFormEditPower();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            DataTable dt = this.DataSource.Tables["AutoExe_Sys_PowerList"];
            DataRow drNew = dt.NewRow();
            drNew["EnumNo"] = frm._EnumNo;
            drNew["Powers"] = frm._Powers;
            drNew["ModuleName"] = frm._MoudleName;
            dt.Rows.Add(drNew);
            this.BindPowerList(this.DataSource.Tables["AutoExe_Sys_PowerList"]);
        }

        private void linkPowerEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.New && this.FormState != Common.MyEnums.FormStates.Edit)
            {
                this.ShowMsg("当前窗体状态不能编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空，请重新打开窗体。");
                return;
            }
            if (this.listPowerList.SelectedItems.Count == 0)
            {
                this.ShowMsg("请至少选择一行。");
                return;
            }
            if (this.listPowerList.SelectedItems.Count > 1)
            {
                this.ShowMsg("每次只能编辑一行。");
                return;
            }
            Common.MyEntity.ComboBoxItem item = this.listPowerList.SelectedItems[0] as Common.MyEntity.ComboBoxItem;
            DataRow[] drs = this.DataSource.Tables["AutoExe_Sys_PowerList"].Select("ID=" + item.Value.ToString() + "");
            if (drs.Length > 0)
            {
                frmSysFormEditPower frm = new frmSysFormEditPower();
                frm._EnumNo = int.Parse(drs[0]["EnumNo"].ToString());
                frm._Powers = drs[0]["Powers"].ToString();
                if (DialogResult.OK != frm.ShowDialog(this)) return;
                if (frm._EnumNo.ToString() != drs[0]["EnumNo"].ToString())
                    drs[0]["EnumNo"] = frm._EnumNo;
                if (frm._Powers != drs[0]["Powers"].ToString())
                    drs[0]["Powers"] = frm._Powers;
                this.BindPowerList(this.DataSource.Tables["AutoExe_Sys_PowerList"]);
            }
        }
        private void linkPowerRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.New && this.FormState != Common.MyEnums.FormStates.Edit)
            {
                this.ShowMsg("当前窗体状态不能编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空，请重新打开窗体。");
                return;
            }
            if (this.listPowerList.SelectedItems.Count > 0)
            {
                if (!this.IsUserConfirm("您确定要移除选中的权限过滤吗？")) return;
            }
            Common.MyEntity.ComboBoxItem item;
            foreach (object obj in this.listPowerList.SelectedItems)
            {
                item = obj as Common.MyEntity.ComboBoxItem;
                if (item != null && item.Value != null)
                {
                    foreach (DataRow dr in this.DataSource.Tables["AutoExe_Sys_PowerList"].Select("ID=" + item.Value.ToString() + ""))
                        dr.Delete();
                }
            }
            this.BindPowerList(this.DataSource.Tables["AutoExe_Sys_PowerList"]);
        }
        #endregion

        private void frmSysFormEdit_Load(object sender, EventArgs e)
        {
            if (!this.PerInit()) return;
            this.btSave.Enabled = this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString());
        }
    }
}