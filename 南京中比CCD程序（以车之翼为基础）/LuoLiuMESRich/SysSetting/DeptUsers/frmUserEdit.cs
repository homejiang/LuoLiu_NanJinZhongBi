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

namespace SysSetting.DeptUsers
{
    public partial class frmUserEdit : frmBase
    {
        public frmUserEdit()
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
        #region 处理函数
        /// <summary>
        /// 设置系统默认数据
        /// </summary>
        /// <returns></returns>
        private bool SetDefaultData()
        {
            //添加
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT DeptCode,DeptName FROM Sys_Department ORDER BY DeptName ASC", "Sys_Department", false));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM Sys_PowerGroup ORDER BY PowerGroupCode ASC", "Sys_PowerGroup", false));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comDept.DisplayMember = "Text";
            this.comDept.ValueMember = "Value";
            this.comDept.DataSource = Common.CommonFuns.FormatData.GetComboBoxItemList(ds.Tables["Sys_Department"], "DeptName", "DeptCode");
            //绑定权限组
            this.comPowerGroup.DisplayMember = "Text";
            this.comPowerGroup.ValueMember = "Value";
            this.comPowerGroup.Items.Add(new ComboBoxItem("自定义权限", ""));
            foreach (DataRow dr in ds.Tables["Sys_PowerGroup"].Rows)
                this.comPowerGroup.Items.Add(new ComboBoxItem(dr["PowerGroupName"].ToString(), dr["PowerGroupCode"].ToString()));
            return true;
        }
        private bool PerInit()
        {
            return true;
        }
        private bool BindData(string strCode)
        {
            DataSet ds=null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM Sys_Users WHERE UserCode='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_Users", true));
            strSql = "SELECT * FROM Sys_UsersPowers WHERE UserCode='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_UsersPowers", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (ds.Tables["Sys_Users"].DefaultView.Count == 0)
            {
                this.ShowMsg("当前员工不存在或已经被删除，请检查。");
                return false;
            }
            this.tbCNName.Text = ds.Tables["Sys_Users"].DefaultView[0].Row["UserName"].ToString();
            this.tbENName.Text = ds.Tables["Sys_Users"].DefaultView[0].Row["UserENName"].ToString();
            this.tbPwd.Text = Common.CommonFuns.EncryptDecryptService.Base64Decrypt(ds.Tables["Sys_Users"].DefaultView[0].Row["Pwd"].ToString());
            this.tbCode.Text = ds.Tables["Sys_Users"].DefaultView[0].Row["UserCode"].ToString();
            this.tbEmail.Text = ds.Tables["Sys_Users"].DefaultView[0].Row["Email"].ToString();
            this.tbMobileTel.Text = ds.Tables["Sys_Users"].DefaultView[0].Row["MobileTel"].ToString();
            this.tbTel.Text = ds.Tables["Sys_Users"].DefaultView[0].Row["Tel"].ToString();
            this.tbHomeAddress.Text = ds.Tables["Sys_Users"].DefaultView[0].Row["HomeAddress"].ToString();
            Common.CommonFuns.FormatData.SetComboBoxText(this.comDept, new Common.MyEntity.ComboBoxItem("", ds.Tables["Sys_Users"].DefaultView[0].Row["DeptCode"].ToString()), 0);
            this.chkTerminated.Checked = !ds.Tables["Sys_Users"].DefaultView[0].Row["Terminated"].Equals(DBNull.Value) && (bool)ds.Tables["Sys_Users"].DefaultView[0].Row["Terminated"];
            //绑定权限
            this.chkAdmin.Checked = !ds.Tables["Sys_Users"].DefaultView[0].Row["IsAdmin"].Equals(DBNull.Value) && (bool)ds.Tables["Sys_Users"].DefaultView[0].Row["IsAdmin"];
            Common.CommonFuns.FormatData.SetComboBoxText(this.comPowerGroup, new ComboBoxItem("", ds.Tables["Sys_Users"].DefaultView[0].Row["PowerGroupCode"].ToString()), 0);
            if (this.comPowerGroup.SelectedIndex < 1)
            {
                #region 绑定自定义模块权限设置
                bool blNewPower, blEditPower, blDeletePower, blReadonlyPower;
                DataRow[] drPowers;
                foreach (TreeNode tn1 in this.tvModulePowers.Nodes)
                {
                    //此为模块组
                    tn1.Checked = false;
                    foreach (TreeNode tn2 in tn1.Nodes)
                    {
                        //此为模块
                        tn2.Checked = false;
                        if (tn2.Tag == null || tn2.Tag.ToString().Length == 0) continue;
                        //如果权威false则要删除员数据行
                        drPowers = ds.Tables["Sys_UsersPowers"].Select("ModuleCode='" + tn2.Tag.ToString() + "'");
                        blNewPower = drPowers.Length > 0 && !drPowers[0]["NewPower"].Equals(DBNull.Value) && (bool)drPowers[0]["NewPower"];
                        blEditPower = drPowers.Length > 0 && !drPowers[0]["EditPower"].Equals(DBNull.Value) && (bool)drPowers[0]["EditPower"];
                        blDeletePower = drPowers.Length > 0 && !drPowers[0]["DeletePower"].Equals(DBNull.Value) && (bool)drPowers[0]["DeletePower"];
                        blReadonlyPower = drPowers.Length > 0 && !drPowers[0]["ReadonlyPower"].Equals(DBNull.Value) && (bool)drPowers[0]["ReadonlyPower"];
                        foreach (TreeNode tn3 in tn2.Nodes)
                        {
                            if (tn3.Tag == null) continue;
                            if (tn3.Tag.ToString() == "1")
                                tn3.Checked = blNewPower;
                            else if (tn3.Tag.ToString() == "2")
                                tn3.Checked = blEditPower;
                            else if (tn3.Tag.ToString() == "3")
                                tn3.Checked = blDeletePower;
                            else if (tn3.Tag.ToString() == "4")
                                tn3.Checked = blReadonlyPower;
                        }
                    }
                }
                #endregion
            }
            this.DataSource = ds;
            return true;
        }
        /// <summary>
        /// 绑定模块权限设置
        /// </summary>
        /// <returns></returns>
        private bool BindMoudlePowers()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSqls = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM Sys_ModuleGroup ORDER BY SortID";
            listSqls.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_ModuleGroup"));
            strSql = "SELECT * FROM Sys_Module ORDER BY GroupCode,SortID";
            listSqls.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_Module"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSqls);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            TreeNode tnGroup = null;
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
                    tnMod = new TreeNode();
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
            this.tvModulePowers.CollapseAll();
            return true;
        }
        /// <summary>
        /// 设置树节点及其全部子节点的选中状态
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="isChecked"></param>
        private void SetCheckedTreeModule(TreeNode tn, bool isChecked)
        {
            if (tn.Checked ^ isChecked)
                tn.Checked = isChecked;
            foreach (TreeNode tnChild in tn.Nodes)
                this.SetCheckedTreeModule(tnChild, isChecked);
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.tbCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入用户编码。");
                this.tbCode.Focus();
                return false;
            }
            if (this.tbCNName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入中文名称。");
                this.tbCNName.Focus();
                return false;
            }
            if (this.tbPwd.Text.Trim().Length == 0)
            {
                this.ShowMsg("登陆密码不能为空。");
                this.tbPwd.Focus();
                return false;
            }
            ComboBoxItem item=this.comDept.SelectedItem as ComboBoxItem;
            if (item==null || item.Value==null || item.Value.ToString().Length==0)
            {
                this.ShowMsg("请选择所在部门。");
                this.comDept.Focus();
                return false;
            }
            if (this.DataSource == null || this.DataSource.Tables["Sys_Users"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据源不正确，请重新加载窗体。");
                return false;
            }
            if (!this.DataSource.Tables["Sys_Users"].DefaultView[0].Row["UserCode"].Equals(this.tbCode.Text.Trim()))
            {
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
                    this.tbCode.Focus();
                    return false;
                }
            }
            //判断同一部门内是否员工中文名称已经存在
            if (!this.DataSource.Tables["Sys_Users"].DefaultView[0].Row["UserName"].Equals(this.tbCNName.Text.Trim())
                || !this.DataSource.Tables["Sys_Users"].DefaultView[0].Row["DeptCode"].Equals(item.Value.ToString()))
            {
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT UserCode FROM Sys_Users WHERE UserName='{0}' AND DeptCode='{1}'",this.tbCNName.Text.Trim().Replace("'","''"), item.Value.ToString().Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("部门“" + item.Text + "”中员工中文名称“" + this.tbCNName.Text.Trim() + "”已经存在，请检查。");
                    this.tbCNName.Focus();
                    return false;
                }
            }
            return true;
        }
        private bool Save()
        {
            DataRow dr = this.DataSource.Tables["Sys_Users"].DefaultView[0].Row;
            if (!dr["UserName"].Equals(this.tbCNName.Text.Trim()))
                dr["UserName"] = this.tbCNName.Text.Trim();
            if (!dr["UserENName"].Equals(this.tbENName.Text.Trim()))
                dr["UserENName"] = this.tbENName.Text.Trim();
            string strPwd = Common.CommonFuns.EncryptDecryptService.Base64Encrypt(this.tbPwd.Text.Trim());
            if (!dr["Pwd"].Equals(strPwd))
                dr["Pwd"] = strPwd;
            if (!dr["UserCode"].Equals(this.tbCode.Text.Trim()))
                dr["UserCode"] = this.tbCode.Text.Trim();
            if (!dr["MobileTel"].Equals(this.tbMobileTel.Text.Trim()))
                dr["MobileTel"] = this.tbMobileTel.Text.Trim();
            if (!dr["Tel"].Equals(this.tbTel.Text.Trim()))
                dr["Tel"] = this.tbTel.Text.Trim();
            if (!dr["Email"].Equals(this.tbEmail.Text.Trim()))
                dr["Email"] = this.tbEmail.Text.Trim();
            if (!dr["HomeAddress"].Equals(this.tbHomeAddress.Text.Trim()))
                dr["HomeAddress"] = this.tbHomeAddress.Text.Trim();
            ComboBoxItem item = this.comDept.SelectedItem as ComboBoxItem;
            if (item == null || item.Value == null)
                dr["DeptCode"] = DBNull.Value;
            else
                dr["DeptCode"] = item.Value;
            if (this.chkTerminated.Checked ^ (!dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"]))
                dr["Terminated"] = this.chkTerminated.Checked;
            //读取权限设置
            if (this.chkAdmin.Checked ^ (!dr["IsAdmin"].Equals(DBNull.Value) && (bool)dr["IsAdmin"]))
                dr["IsAdmin"] = this.chkAdmin.Checked;
            if (this.comPowerGroup.SelectedIndex == -1 || this.comPowerGroup.SelectedIndex == 0)
            {
                //此时设置为自定义权限
                if (!dr["PowerGroupCode"].Equals(DBNull.Value))
                    dr["PowerGroupCode"] = DBNull.Value;
                #region 读取自定义模块权限设置
                bool blNewPower, blEditPower, blDeletePower, blReadonlyPower;
                DataRow[] drPowers;
                DataRow drPowersNew;
                foreach (TreeNode tn1 in this.tvModulePowers.Nodes)
                {
                    //此为模块组
                    foreach (TreeNode tn2 in tn1.Nodes)
                    {
                        //此为模块组
                        if (tn2.Tag == null || tn2.Tag.ToString().Length == 0) continue;
                        blNewPower = false;
                        blEditPower = false;
                        blDeletePower = false;
                        blReadonlyPower = false;
                        foreach (TreeNode tn3 in tn2.Nodes)
                        {
                            if (tn3.Tag == null  || !tn3.Checked) continue;
                            if (tn3.Tag.ToString() == "1")
                                blNewPower = true;
                            else if (tn3.Tag.ToString() == "2")
                                blEditPower = true;
                            else if (tn3.Tag.ToString() == "3")
                                blDeletePower = true;
                            else if (tn3.Tag.ToString() == "4")
                                blReadonlyPower = true;
                        }
                        //如果权威false则要删除员数据行
                        drPowers = this.DataSource.Tables["Sys_UsersPowers"].Select("ModuleCode='" + tn2.Tag.ToString() + "'");
                        if (blNewPower || blEditPower || blDeletePower || blReadonlyPower)
                        {
                            //此时有一项已经选择
                            if (drPowers.Length == 0)
                            {
                                drPowersNew = this.DataSource.Tables["Sys_UsersPowers"].NewRow();
                                drPowersNew["ModuleCode"] = tn2.Tag.ToString();
                                drPowersNew["UserCode"] = this.PrimaryValue.ToString();
                            }
                            else
                                drPowersNew = drPowers[0];
                            drPowersNew["NewPower"] = blNewPower;
                            drPowersNew["EditPower"] = blEditPower;
                            drPowersNew["DeletePower"] = blDeletePower;
                            drPowersNew["ReadonlyPower"] = blReadonlyPower;
                            if (drPowers.Length == 0)
                                this.DataSource.Tables["Sys_UsersPowers"].Rows.Add(drPowersNew);
                        }
                        else
                        {
                            //此时没有该模块的任何权限，则要删除该数据
                            for (int i = drPowers.Length; i > 0; i--)
                                drPowers[i - 1].Delete();
                        }
                    }
                }
                #endregion
            }
            else
            {
                ComboBoxItem itemSel = this.comPowerGroup.SelectedItem as ComboBoxItem;
                if (itemSel != null)
                {
                    if (!dr["PowerGroupCode"].Equals(itemSel.Value.ToString()))
                        dr["PowerGroupCode"] = itemSel.Value.ToString();
                }
            }
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
        #region 窗体控件事件
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
        //权限组改变事件
        private void comPowerGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comPowerGroup.SelectedIndex == -1 || this.comPowerGroup.SelectedIndex == 0)
                return;
            ComboBoxItem comItem = this.comPowerGroup.SelectedItem as ComboBoxItem;
            if (comItem == null || comItem.Value.ToString().Length == 0) return;
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

        private void btPowerGroupSetting_Click(object sender, EventArgs e)
        {
            //先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PowerGroup);
            if (listPower.Count == 0)
            {
                this.ShowMsg("你没有权限组管理的任何权限，如有需要请联系管理员开放相应权限。");
                return;
            }
            SysSetting.DeptUsers.frmPowerGroup frm = new SysSetting.DeptUsers.frmPowerGroup();
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
            }
        }
        #endregion
        #region 窗体事件
        private void frmUnitEdit_Load(object sender, EventArgs e)
        {
            this.SetDefaultData();
            if (!this.PerInit()) return; 
            this.BindMoudlePowers();
            this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString());
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSelectDeptSample frm = new frmSelectDeptSample();
            if (frm.ShowDialog(this) != DialogResult.OK) return;
            string str = frm.SelectedDept;
            if (str.Length == 0) return;
            Common.MyEntity.ComboBoxItem item;
            for(int i=0;i<this.comDept.Items.Count;i++)
            {
                item = this.comDept.Items[i] as Common.MyEntity.ComboBoxItem;
                if (item == null) continue;
                if (string.Compare(str, item.Value.ToString(), true) == 0)
                {
                    this.comDept.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}