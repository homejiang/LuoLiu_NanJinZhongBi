using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.MyEntity;
using Common.MyEnums;
using Common;
using ErrorService;

namespace SysSetting.DeptUsers
{
    public partial class frmDeptUser : frmBase
    {
        public frmDeptUser()
        {
            InitializeComponent();
        }
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
        #region 部门操作
        //加载信息
        private bool BindDept()
        {
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("SELECT * FROM Sys_Department ORDER BY DeptName");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //加载根节点
            this.tvDept.Nodes.Clear();
            TreeNode tnParent = new TreeNode();
            tnParent.Tag = string.Empty;
            tnParent.Text = "所有部门";
            this.tvDept.Nodes.Add(tnParent);
            DataRow[] drs = dt.Select("ISNULL(ParentDetpCode,'')=''", "DeptName asc");
            foreach (DataRow dr in drs)
            {
                TreeNode tnRoot = new TreeNode();
                tnRoot.Text = dr["DeptName"].ToString();
                tnRoot.Tag = dr["DeptCode"].ToString();
                tnParent.Nodes.Add(tnRoot);
                //绑定子节点
                this.BindDept(tnRoot, dt);
            }
            this.tvDept.ExpandAll();
            return true;
        }
        private void BindDept(TreeNode tn, DataTable dtDetp)
        {
            //绑定子节点
            if (tn.Tag == null) return;
            DataRow[] drs = dtDetp.Select(string.Format("ParentDetpCode='{0}'", tn.Tag.ToString()), "DeptName asc");
            foreach (DataRow dr in drs)
            {
                TreeNode tnchild = new TreeNode();
                tnchild.Text = dr["DeptName"].ToString();
                tnchild.Tag = dr["DeptCode"].ToString();
                if (dr["Description"].ToString().Length > 0)
                    tnchild.ToolTipText = dr["Description"].ToString();
                tn.Nodes.Add(tnchild);
                this.BindDept(tnchild, dtDetp);
            }
        }
        #region 按钮事件
        private void NvbtDeptAdd_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.DeptAndUser);
            if (listPower.Count == 0)
            {
                this.ShowMsg("您没有部门及用户模块的任何权限。");
                return;
            }
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("您没有新增部门及用户的权限。");
                return;
            }
            frmDeptEdit frm = new frmDeptEdit();
            frm.FormState = Common.MyEnums.FormStates.New;

            if (DialogResult.OK == frm.ShowDialog(this))
            {
                //重新加载部门及用户信息
                this.BindDept();
            }
        }

        private void nvbtDeptEdit_Click(object sender, EventArgs e)
        {
            if (this.tvDept.SelectedNode == null) return;
            TreeNode tn = this.tvDept.SelectedNode;
            if (tn == null || tn.Tag == null || tn.Tag.ToString().Length == 0) return;
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.DeptAndUser);
            if (listPower.Count == 0)
            {
                this.ShowMsg("您没有部门及用户模块的任何权限。");
                return;
            }
            frmDeptEdit frm = new frmDeptEdit();
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                frm.FormState = FormStates.Readonly;
            else
                frm.FormState = FormStates.Edit;
            frm.PrimaryValue = tn.Tag.ToString();
            if (DialogResult.OK == frm.ShowDialog(this))
            {
                //重新加载部门及用户信息
                this.BindDept();
            }
        }

        private void NvbtDeptRemove_Click(object sender, EventArgs e)
        {
            if (this.tvDept.SelectedNode == null) return;
            TreeNode tn = this.tvDept.SelectedNode;
            if (tn == null || tn.Tag == null || tn.Tag.ToString().Length == 0) return;
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.DeptAndUser, tn.Tag.ToString());
            if (!listPower.Contains(OperatePower.Delete))
            {
                this.ShowMsg("您没有部门及用户模块的删除权限。");
                return;
            }
            try
            {
                this.BllDAL.DeteleGroup(tn.Tag.ToString());
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindDept();
        }
        private void tvDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.BindUser();
        }
        #endregion
        #endregion
        #region 获取选中部门及其子部门
        /// <summary>
        /// 获取当前部门树控件选中的部门及其子部门，并以“|”分割
        /// </summary>
        /// <returns></returns>
        private string GetSelectedDeptsCode()
        {
            if (this.tvDept.SelectedNode == null || this.tvDept.SelectedNode.Tag == null || this.tvDept.SelectedNode.Tag.ToString().Length == 0) return string.Empty;
            StringBuilder sb = new StringBuilder();
            this.GetSelectedDeptsCode(this.tvDept.SelectedNode, sb);
            return sb.ToString();
        }
        private void GetSelectedDeptsCode(TreeNode tnSelected,StringBuilder sbDepts)
        {
            sbDepts.Append("|");
            sbDepts.Append(tnSelected.Tag.ToString());
            sbDepts.Append("|");
            foreach (TreeNode tnchild in tnSelected.Nodes)
            {
                this.GetSelectedDeptsCode(tnchild, sbDepts);
            }
        }
        #endregion
        #region 部门及用户操作
        //加载部门及用户
        private bool BindUser()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql;
            string strDepts = this.GetSelectedDeptsCode();
            if (strDepts.Length > 0)
                strSql = string.Format("SELECT * FROM V_Sys_Users WHERE CHARINDEX('|'+ISNULL(DeptCode,'')+'|','{0}')>=1 ORDER BY UserName ASC", strDepts.Replace("'","''"));
            else
                strSql = "SELECT * FROM V_Sys_Users ORDER BY DeptCode ASC,UserName ASC";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_Users", false));
            strSql = "SELECT * FROM Sys_UsersPowers WHERE 1=2";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_UsersPowers"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.DataSource = ds;
            this.dgvList.DataSource = ds.Tables["Sys_Users"];
            return true;
        }
        private bool SaveCheck()
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.DeptAndUser);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("您没有新增部门及用户的权限。");
                return false;
            }
            if (this.tvDept.SelectedNode == null || this.tvDept.SelectedNode.Tag == null || this.tvDept.SelectedNode.Tag.ToString().Length == 0 )
            {
                this.ShowMsg("请在左边部门及用户信息框内选择指定的部门。");
                return false;
            }
            if (this.tbCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入用户代码。");
                this.tbCode.Focus();
                return false;
            }
            if (this.tbCNName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入中文名。");
                this.tbCNName.Focus();
                return false;
            }
            if (this.tbPwd.Text.Trim().Length == 0)
            {
                this.ShowMsg("密码不能为空。");
                this.tbPwd.Focus();
                return false;
            }
            //判断是否系统中已经存在编码
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT UserCode FROM Sys_Users WHERE UserCode='{0}'", this.tbCode.Text.Trim().Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.DefaultView.Count > 0)
            {
                this.ShowMsg("用户编码“" + this.tbCode.Text.Trim() + "”在系统中已经存在，请更换。");
                return false;
            }
            return true;
        }
        private bool Save()
        {
            DataRow drNew = this.DataSource.Tables["Sys_Users"].NewRow();
            drNew["UserCode"] = this.tbCode.Text.Trim();
            drNew["UserName"] = this.tbCNName.Text.Trim();
            drNew["UserENName"] = this.tbENName.Text.Trim();
            drNew["Pwd"] = Common.CommonFuns.EncryptDecryptService.Base64Encrypt(this.tbPwd.Text.Trim());
            drNew["MobileTel"] = this.tbMobileTel.Text.Trim();
            drNew["Tel"] = this.tbTel.Text.Trim();
            drNew["Email"] = this.tbEmail.Text.Trim();
            drNew["HomeAddress"] = this.tbHomeAddress.Text.Trim();
            drNew["DeptCode"] = this.tvDept.SelectedNode.Tag.ToString();
            drNew["IsAdmin"] = this.chkAdmin.Checked;
            //读取权限
            //权限组下拉框第一行数据为自定义,Index为0
            if (this.comPowerGroup.SelectedIndex < 1)
            {
                foreach (TreeNode tn1 in this.tvModulePowers.Nodes)
                {
                    //此为模块组
                    foreach (TreeNode tn2 in tn1.Nodes)
                    {
                        //此为模块
                        if (tn2.Tag == null || tn2.Tag.ToString().Length == 0 || tn2.Nodes.Count == 0)
                            continue;
                        DataRow drNewUserPower = this.DataSource.Tables["Sys_UsersPowers"].NewRow();
                        foreach (TreeNode tn3 in tn2.Nodes)
                        {
                            if (tn3.Checked && tn3.Tag != null)
                            {
                                if (tn3.Tag.ToString() == "1")
                                    drNewUserPower["NewPower"] = true;
                                else if (tn3.Tag.ToString() == "2")
                                    drNewUserPower["EditPower"] = true;
                                else if (tn3.Tag.ToString() == "3")
                                    drNewUserPower["DeletePower"] = true;
                                else if (tn3.Tag.ToString() == "4")
                                    drNewUserPower["ReadonlyPower"] = true;
                            }
                        }
                        if (!drNewUserPower["NewPower"].Equals(DBNull.Value)
                            || !drNewUserPower["EditPower"].Equals(DBNull.Value)
                            || !drNewUserPower["DeletePower"].Equals(DBNull.Value)
                            || !drNewUserPower["ReadonlyPower"].Equals(DBNull.Value))
                        {
                            drNewUserPower["UserCode"] = this.tbCode.Text.Trim();
                            drNewUserPower["ModuleCode"] = tn2.Tag.ToString();
                            this.DataSource.Tables["Sys_UsersPowers"].Rows.Add(drNewUserPower);
                        }
                    }
                }
            }
            else
            {
                ComboBoxItem item = this.comPowerGroup.SelectedItem as ComboBoxItem;
                drNew["PowerGroupCode"] = item.Value.ToString();
            }
            this.DataSource.Tables["Sys_Users"].Rows.Add(drNew);
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
        #region 控件事件
        private void frmDeptUser_Load(object sender, EventArgs e)
        {
            this.dgvList.AutoGenerateColumns = false;
            this.chkAdmin.Enabled =Common.CurrentUserInfo.IsSuper;//是否是管理员需要由超级用户来分配
            this.BindDept();
            this.BindUser();
            this.BindMoudlePowers();
            this.tbCode.Text = this.GetAutoCode(Modules.DeptAndUser, 2);
        }
        private void nvbtEdit_Click(object sender, EventArgs e)
        {
            //检查权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.DeptAndUser);
            if (!listPower.Contains(OperatePower.Eidt))
            {
                this.ShowMsg("您没有部门及用户模块的编辑权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                frmUserEdit frm = new frmUserEdit();
                if (!dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["IsSuper"].Equals(DBNull.Value)
                    && (bool)dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["IsSuper"] && !Common.CurrentUserInfo.IsSuper)
                {
                    this.ShowMsg("用户编码“" + dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["UserCode"].ToString() + "”为超级用户只允许由超级用户自己修改。");
                    continue;
                }
                frm.PrimaryValue = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["UserCode"].ToString();
                frm.FormState = FormStates.Edit;
                if (DialogResult.OK == frm.ShowDialog(this))
                    this.BindUser();
            }
        }
        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.RowIndex < 0 && e.ColumnIndex < 0) return;
            //检查权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.DeptAndUser);
            if (!listPower.Contains(OperatePower.Eidt))
            {
                this.ShowMsg("您没有部门及用户模块的编辑权限。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            frmUserEdit frm = new frmUserEdit();
            frm.PrimaryValue = dt.DefaultView[e.RowIndex].Row["UserCode"].ToString();
            frm.FormState = FormStates.Edit;
            if (DialogResult.OK == frm.ShowDialog(this))
                this.BindUser();
        }
        //新增用户
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck()) return;
            if (this.Save())
            {
                //this.tbCode.Text = string.Empty;
                this.tbCNName.Text = string.Empty;
                this.tbENName.Text = string.Empty;
                this.tbEmail.Text = string.Empty;
                this.tbMobileTel.Text = string.Empty;
                this.tbTel.Text = string.Empty;
                this.tbHomeAddress.Text = string.Empty;
                this.ClearPowerSetting();
                this.BindUser();
                this.tbCode.Text = this.GetAutoCode(Modules.DeptAndUser, 2);
                this.tbPwd.Text = string.Empty;
            }
        }

        private void nvbtRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的用户吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            for (int i = this.dgvList.SelectedRows.Count; i > 0; i--)
            {
                if (!dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["IsSuper"].Equals(DBNull.Value)
                    && (bool)dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["IsSuper"])
                {
                    this.ShowMsg("用户编码“" + dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["UserCode"].ToString() + "”为超级用户，不允许删除。");
                    continue;
                }
                this.BllDAL.Detele(dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["UserCode"].ToString());
            }
            this.BindUser();
        }
        #endregion
        #endregion
        #region 权限操作
        private bool BindMoudlePowers()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSqls = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM Sys_ModuleGroup ORDER BY SortID";
            listSqls.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_ModuleGroup"));
            strSql = "SELECT * FROM Sys_Module ORDER BY GroupCode,SortID";
            listSqls.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_Module"));
            strSql = "SELECT * FROM Sys_PowerGroup ORDER BY PowerGroupCode";
            listSqls.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_PowerGroup"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSqls);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //绑定权限组
            this.comPowerGroup.DisplayMember = "Text";
            this.comPowerGroup.ValueMember = "Value";
            this.comPowerGroup.Items.Add(new ComboBoxItem("自定义权限", "powergroup"));
            foreach (DataRow dr in ds.Tables["Sys_PowerGroup"].Rows)
                this.comPowerGroup.Items.Add(new ComboBoxItem(dr["PowerGroupName"].ToString(), dr["PowerGroupCode"].ToString()));
            //绑定模块权限
            TreeNode tnGroup=null;
            TreeNode tnChild = null;
            TreeNode tnMod = null;
            DataRow[] drs;
            foreach (DataRow drGroup in ds.Tables["Sys_ModuleGroup"].Rows)
            {
                tnGroup = new TreeNode();
                tnGroup.Text = drGroup["GroupName"].ToString();
                tnGroup.Tag = drGroup["GroupCode"].ToString();
                this.tvModulePowers.Nodes.Add(tnGroup);
                //添加字模块
                drs = ds.Tables["Sys_Module"].Select("GroupCode='" + drGroup["GroupCode"].ToString() + "'");
                foreach (DataRow drMod in drs)
                {
                    tnMod= new TreeNode();
                    tnMod.Text = drMod["ModuleName"].ToString();
                    tnMod.Tag = drMod["ModuleCode"].ToString();
                    //添加新增
                    if (!drMod["CanNew"].Equals(DBNull.Value) && (bool)drMod["CanNew"])
                    {
                        tnChild = new TreeNode();
                        tnChild.Text = "新增";
                        tnChild.Tag = 1;
                        tnMod.Nodes.Add(tnChild);
                    }
                    if (!drMod["CanEdit"].Equals(DBNull.Value) && (bool)drMod["CanEdit"])
                    {
                        tnChild = new TreeNode();
                        tnChild.Text = "编辑";
                        tnChild.Tag = 2;
                        tnMod.Nodes.Add(tnChild);
                    }
                    if (!drMod["CanDelete"].Equals(DBNull.Value) && (bool)drMod["CanDelete"])
                    {
                        tnChild = new TreeNode();
                        tnChild.Text = "删除";
                        tnChild.Tag = 3;
                        tnMod.Nodes.Add(tnChild);
                    }
                    tnChild = new TreeNode();
                    tnChild.Text = "查看";
                    tnChild.Tag = 4;
                    tnMod.Nodes.Add(tnChild);
                    tnGroup.Nodes.Add(tnMod);
                }
            }
            //展开所有
            this.tvModulePowers.ExpandAll();
            
            return true;
        }
        private void btPowerSetting_Click(object sender, EventArgs e)
        {
            //无法显式设置 SplitterPanel 的高度。改在 SplitContainer 上设置 SplitterDistance。
            if (this.btPowerSetting.Text.IndexOf("详细") >= 0)
            {
                this.splitContainer2.SplitterDistance = 420;
                this.panUserPower.Visible = true;
                this.btPowerSetting.Text = "简介模式";
            }
            else
            {
                this.panUserPower.Visible = false;
                this.splitContainer2.SplitterDistance = 58;
                this.btPowerSetting.Text = "详细信息";
            }
        }
        private void ClearPowerSetting()
        {
            this.chkAdmin.Checked = false;
            this.comPowerGroup.SelectedIndex = -1;
            this.tvModulePowers.Enabled = false;
            foreach (TreeNode tn in this.tvModulePowers.Nodes)
                this.SetCheckedTreeModule(tn, false);
        }
        private void SetCheckedTreeModule(TreeNode tn,bool isChecked)
        {
            if (tn.Checked ^ isChecked)
                tn.Checked = isChecked;
            foreach (TreeNode tnChild in tn.Nodes)
                this.SetCheckedTreeModule(tnChild, isChecked);
        }
        //选择权限
        private void tvModulePowers_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                foreach (TreeNode tn in e.Node.Nodes)
                    this.SetCheckedTreeModule(tn, e.Node.Checked);
            }
        }
        //权限组选择改变事件
        private void comPowerGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem comItem = this.comPowerGroup.SelectedItem as ComboBoxItem;
            this.tvModulePowers.Enabled = comItem != null && comItem.Value != null && comItem.Value.ToString().ToLower() == "powergroup";
            if (comItem == null) return;
            //加载当前权限组权限
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("SELECT * FROM Sys_PowerGroupDetail WHERE PowerGroupCode='" + comItem.Value.ToString().Replace("'", "''") + "'");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            DataRow[] drs;
            //加载选择项目
            foreach (TreeNode tn1 in this.tvModulePowers.Nodes)
            {
                this.SetCheckedTreeModule(tn1, false);//先要将其设置为不选择状态
                foreach (TreeNode tn2 in tn1.Nodes)
                {
                    //此为模块名
                    if (tn2.Tag == null || tn2.Tag.ToString().Length == 0) continue;
                    drs = dt.Select("ModuleCode='" + tn2.Tag.ToString() + "'");
                    if (drs.Length == 0) continue;
                    foreach (TreeNode tn3 in tn2.Nodes)
                    {
                        if (tn3.Tag == null || tn3.Tag.ToString().Length == 0) continue;
                        if (tn3.Tag.ToString() == "1")
                            tn3.Checked = !drs[0]["NewPower"].Equals(DBNull.Value) && (bool)drs[0]["NewPower"];
                        else if (tn3.Tag.ToString() == "2")
                            tn3.Checked = !drs[0]["EditPower"].Equals(DBNull.Value) && (bool)drs[0]["EditPower"];
                        else if (tn3.Tag.ToString() == "3")
                            tn3.Checked = !drs[0]["DeletePower"].Equals(DBNull.Value) && (bool)drs[0]["DeletePower"];
                        else if (tn3.Tag.ToString() == "4")
                            tn3.Checked = !drs[0]["ReadonlyPower"].Equals(DBNull.Value) && (bool)drs[0]["ReadonlyPower"];
                    }
                }
            }
            this.tvModulePowers.ExpandAll();
        }
        /// <summary>
        /// 编辑权限组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPowerGroupSetting_Click(object sender, EventArgs e)
        {
            //先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PowerGroup);
            if (listPower.Count == 0)
            {
                this.ShowMsg("你没有权限组管理的任何权限，如有需要请联系管理员开放相应权限。");
                return;
            }
            //JPS waitting
           /* StorageManage.SysSetting.frmPowerGroup frm = new StorageManage.SysSetting.frmPowerGroup();
            frm.ShowDialog(this);
            //更新权限组下拉框
            DataTable dt = frm.PowerGroupList;
            string strCodeSel;
            if (this.comPowerGroup.SelectedIndex < 1)
                strCodeSel = string.Empty;
            else
            {
                ComboBoxItem itemSel = this.comPowerGroup.SelectedItem as ComboBoxItem;
                strCodeSel = itemSel == null ? string.Empty : itemSel.Value.ToString();
            }
            this.comPowerGroup.Items.Clear();//先清空原数据
            this.comPowerGroup.Items.Add(new ComboBoxItem("自定义权限", ""));
            int iIndexSel;
            foreach (DataRow dr in dt.Rows)
            {
                iIndexSel = this.comPowerGroup.Items.Add(new ComboBoxItem(dr["PowerGroupName"].ToString(), dr["PowerGroupCode"].ToString()));
                if (dr["PowerGroupCode"].ToString() == strCodeSel && this.comPowerGroup.SelectedIndex != iIndexSel)
                    this.comPowerGroup.SelectedIndex = iIndexSel;
            }*/
        }
        #endregion
    }
}