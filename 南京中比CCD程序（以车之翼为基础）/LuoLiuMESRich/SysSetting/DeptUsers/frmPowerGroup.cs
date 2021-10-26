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

namespace SysSetting.DeptUsers
{
    public partial class frmPowerGroup : frmBase
    {
        public frmPowerGroup()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.UserPowers _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.UserPowers BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new SysSetting.BLLDAL.UserPowers();
                return _dal;
            }
        }
        #endregion
        #region 窗体属性
        /// <summary>
        /// 当前窗体数据是否改变
        /// </summary>
        private bool IsDataSourceChanged
        {
            get
            {
                DataSet dsTemp= this.DataSource.Copy();
                this.ReadFormData(dsTemp);
                if (dsTemp == null) return false;
                if (dsTemp.Tables["Sys_PowerGroupDetail"].GetChanges() != null) return true;
                if (dsTemp.Tables["Sys_PowerGroup"].GetChanges() == null) return false;
                if (dsTemp.Tables["Sys_PowerGroup"].DefaultView[0].Row.RowState != DataRowState.Added) return true;
                if (dsTemp.Tables["Sys_PowerGroup"].DefaultView[0].Row["PowerGroupCode"].ToString().Length == 0
                    && dsTemp.Tables["Sys_PowerGroup"].DefaultView[0].Row["PowerGroupName"].ToString().Length == 0
                    && dsTemp.Tables["Sys_PowerGroup"].DefaultView[0].Row["Description"].ToString().Length == 0)
                    return false;
                return true;
            }
        }
        /// <summary>
        /// 当前权限组列表数据
        /// </summary>
        public DataTable PowerGroupList
        {
            get
            {
                return this.dgvList.DataSource as DataTable;
            }
        }
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM Sys_ModuleGroup ORDER BY SortID ASC", "Sys_ModuleGroup", false));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM Sys_Module ORDER BY SortID ASC", "Sys_Module", false));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //加载模块树结构
            TreeNode tnGroup = null;
            TreeNode tnChild = null;
            TreeNode tnMod = null;
            DataRow[] drs;
            foreach (DataRow drGroup in ds.Tables["Sys_ModuleGroup"].Rows)
            {
                tnGroup = new TreeNode();
                tnGroup.Text = drGroup["GroupName"].ToString();
                tnGroup.Tag = drGroup["GroupCode"].ToString();
                tnGroup.ImageIndex = -1;
                this.tvDetails.Nodes.Add(tnGroup);
                //添加字模块
                drs = ds.Tables["Sys_Module"].Select("GroupCode='" + drGroup["GroupCode"].ToString() + "'");
                foreach (DataRow drMod in drs)
                {
                    tnMod = new TreeNode();
                    tnMod.Text = drMod["ModuleName"].ToString();
                    tnMod.Tag = drMod["ModuleCode"].ToString();
                    tnMod.ImageIndex = -1;
                    //添加新增
                    if (!drMod["CanNew"].Equals(DBNull.Value) && (bool)drMod["CanNew"])
                    {
                        tnChild = new TreeNode();
                        tnChild.Text = "新增";
                        tnChild.Tag = 1;
                        tnChild.ImageIndex = 0;
                        tnMod.Nodes.Add(tnChild);
                    }
                    if (!drMod["CanEdit"].Equals(DBNull.Value) && (bool)drMod["CanEdit"])
                    {
                        tnChild = new TreeNode();
                        tnChild.Text = "编辑";
                        tnChild.Tag = 2;
                        tnChild.ImageIndex = 1;
                        tnMod.Nodes.Add(tnChild);
                    }
                    if (!drMod["CanDelete"].Equals(DBNull.Value) && (bool)drMod["CanDelete"])
                    {
                        tnChild = new TreeNode();
                        tnChild.Text = "删除";
                        tnChild.Tag = 3;
                        tnChild.ImageIndex = 2;
                        tnMod.Nodes.Add(tnChild);
                    }
                    tnChild = new TreeNode();
                    tnChild.Text = "查看";
                    tnChild.Tag = 4;
                    tnChild.ImageIndex = 3;
                    tnMod.Nodes.Add(tnChild);
                    tnGroup.Nodes.Add(tnMod);
                }
            }
            this.tvDetails.ExpandAll();
            return true;
        }
        private bool BindPowerGroupList()
        {
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("SELECT * FROM Sys_PowerGroup order by PowerGroupCode");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = dt;
            return true;
        }
        private bool BindPowerGroupInfo(string strCode)
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM Sys_PowerGroup WHERE PowerGroupCode='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_PowerGroup", true));
            strSql = "SELECT * FROM Sys_PowerGroupDetail WHERE PowerGroupCode='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_PowerGroupDetail", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (strCode.Length > 0 && ds.Tables["Sys_PowerGroup"].DefaultView.Count == 0)
            {
                this.ShowMsg("权限组编码“" + strCode + "”不存在或已被删除，请检查。");
                return false;
            }
            if (ds.Tables["Sys_PowerGroup"].DefaultView.Count == 0)
            {
                DataRow drNew = ds.Tables["Sys_PowerGroup"].NewRow();
                drNew["PowerGroupCode"] = string.Empty;
                ds.Tables["Sys_PowerGroup"].Rows.Add(drNew);
            }
            //绑定主信息
            this.tbCode.Text = strCode;
            this.tbName.Text = ds.Tables["Sys_PowerGroup"].DefaultView[0].Row["PowerGroupName"].ToString();
            this.tbRemark.Text = ds.Tables["Sys_PowerGroup"].DefaultView[0].Row["Description"].ToString();
            #region 绑定自定义模块权限设置
            bool blNewPower, blEditPower, blDeletePower, blReadonlyPower;
            DataRow[] drPowers;
            foreach (TreeNode tn1 in this.tvDetails.Nodes)
            {
                //此为模块组
                tn1.Checked = false;
                foreach (TreeNode tn2 in tn1.Nodes)
                {
                    //此为模块
                    tn2.Checked = false;
                    if (tn2.Tag == null || tn2.Tag.ToString().Length == 0) continue;
                    drPowers = ds.Tables["Sys_PowerGroupDetail"].Select("ModuleCode='" + tn2.Tag.ToString() + "'");
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
            this.DataSource = ds;
            return true;
        }
        private void SetFormState()
        {
            if (this.FormState == FormStates.New || this.FormState == FormStates.Copy)
                this.labStateView.Text = "新增";
            else if (this.FormState == FormStates.Edit)
            {
                this.labStateView.Text = "编辑";
            }
            else if (this.FormState == FormStates.Readonly || this.FormState==FormStates.None)
            {
                this.labStateView.Text = "只读";
            }
        }
        private void ReadFormData(DataSet dsSource)
        {
            DataRow dr = dsSource.Tables["Sys_PowerGroup"].DefaultView[0].Row;
            if (!dr["PowerGroupCode"].Equals(this.tbCode.Text.Trim()))
                dr["PowerGroupCode"] = this.tbCode.Text.Trim();
            if (!dr["PowerGroupName"].Equals(this.tbName.Text.Trim()))
                dr["PowerGroupName"] = this.tbName.Text.Trim();
            if (!dr["Description"].Equals(this.tbRemark.Text.Trim()))
                dr["Description"] = this.tbRemark.Text.Trim();
            #region 读取模块权限设置
            bool blNewPower, blEditPower, blDeletePower, blReadonlyPower;
            DataRow[] drPowers;
            DataRow drPowersNew;
            foreach (TreeNode tn1 in this.tvDetails.Nodes)
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
                        if (tn3.Tag == null || !tn3.Checked) continue;
                        if (tn3.Tag.ToString() == "1")
                            blNewPower = true;
                        else if (tn3.Tag.ToString() == "2")
                            blEditPower = true;
                        else if (tn3.Tag.ToString() == "3")
                            blDeletePower = true;
                        else if (tn3.Tag.ToString() == "4")
                            blReadonlyPower = true;
                    }
                    //如果全为false则要删除数据行
                    drPowers = this.DataSource.Tables["Sys_PowerGroupDetail"].Select("ModuleCode='" + tn2.Tag.ToString() + "'");
                    if (blNewPower || blEditPower || blDeletePower || blReadonlyPower)
                    {
                        //此时有一项已经选择
                        if (drPowers.Length == 0)
                        {
                            drPowersNew = this.DataSource.Tables["Sys_PowerGroupDetail"].NewRow();
                            drPowersNew["ModuleCode"] = tn2.Tag.ToString();
                        }
                        else
                            drPowersNew = drPowers[0];
                        drPowersNew["NewPower"] = blNewPower;
                        drPowersNew["EditPower"] = blEditPower;
                        drPowersNew["DeletePower"] = blDeletePower;
                        drPowersNew["ReadonlyPower"] = blReadonlyPower;
                        if (drPowers.Length == 0)
                            this.DataSource.Tables["Sys_PowerGroupDetail"].Rows.Add(drPowersNew);
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
            foreach (DataRowView drv in dsSource.Tables["Sys_PowerGroupDetail"].DefaultView)
            {
                if (!drv.Row["PowerGroupCode"].Equals(this.tbCode.Text.Trim()))
                    drv.Row["PowerGroupCode"] = this.tbCode.Text.Trim();
            }
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
            if (this.FormState == FormStates.Readonly || this.FormState == FormStates.None || this.DataSource == null)
            {
                this.ShowMsg("只读状态下不能保存数据。");
                return false;
            }
            if (this.tbCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("权限组编码不能为空。");
                this.tbCode.Focus();
                return false;
            }
            if (this.tbCode.Text.Trim().ToLower() == "powergroup")
            {
                this.ShowMsg("您输入的权限组编码为非法编码，请更换。");
                this.tbCode.Focus();
                return false;
            }
            if (this.tbName.Text.Trim().Length == 0)
            {
                this.ShowMsg("权限组名称不能为空。");
                this.tbName.Focus();
                return false;
            }
            DataTable dt = null;
            //判断是否编码重复
            if (this.FormState == FormStates.New || this.FormState == FormStates.Copy
                || (this.FormState == FormStates.Edit && !this.DataSource.Tables["Sys_PowerGroup"].DefaultView[0].Row["PowerGroupCode"].Equals(this.tbCode.Text.Trim())))
            {
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT PowerGroupCode FROM Sys_PowerGroup WHERE PowerGroupCode='{0}'", this.tbCode.Text.Trim().Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("权限组编码“"+this.tbCode.Text+"”已经存在请更换。");
                    this.tbCode.Focus();
                    return false;
                }
            }
            if (this.FormState == FormStates.New || this.FormState == FormStates.Copy
                || (this.FormState == FormStates.Edit && !this.DataSource.Tables["Sys_PowerGroup"].DefaultView[0].Row["PowerGroupName"].Equals(this.tbName.Text.Trim())))
            {
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT PowerGroupCode FROM Sys_PowerGroup WHERE PowerGroupName='{0}'", this.tbName.Text.Trim().Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("权限组名称“" + this.tbName.Text + "”已经存在请更换。");
                    this.tbName.Focus();
                    return false;
                }
            }
            return true;
        }
        private bool Save()
        {
            if (!this.SaveCheck())
                return false;
            this.ReadFormData(this.DataSource);
            if (this.DataSource.GetChanges() == null) return true;
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
        #region 窗体事件
        private void frmPowerGroup_Load(object sender, EventArgs e)
        {
            if (!this.PerInit()) return;
            this.BindPowerGroupList();
            //初始状态应设置为新增
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PowerGroup);
            if (listPower.Count == 0)
            {
                //此时用户无任何权限，则关闭当前窗体
                this.FormColse();
                return;
            }
            //设置窗体状态
            if (!listPower.Contains(OperatePower.New))
                this.FormState = FormStates.Readonly;
            else if (this.BindPowerGroupInfo(string.Empty))
                this.FormState = FormStates.New;
            this.SetFormState();
        }
        #endregion
        #region 窗体控件事件
        /// <summary>
        /// 双击权限组列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            string strCode = dt.DefaultView[e.RowIndex].Row["PowerGroupCode"].ToString();
            if (strCode.Length == 0) return;
            //初始状态应设置为新增
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PowerGroup);
            if (listPower.Count == 0)
            {
                //此时用户无任何权限，则关闭当前窗体
                this.FormColse();
                return;
            }
            if (this.IsDataSourceChanged && DialogResult.Yes != MessageBox.Show(this, "当前数据已经修改，您确定不保存吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            //设置窗体状态
            if (!listPower.Contains(OperatePower.Eidt))
                this.FormState = FormStates.Readonly;
            else if (this.BindPowerGroupInfo(strCode))
                this.FormState = FormStates.Edit;
            this.SetFormState();
        }
        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nvbtEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            DataGridViewCellEventArgs arg = new DataGridViewCellEventArgs(0, this.dgvList.SelectedRows[0].Index);
            this.dgvList_CellDoubleClick(sender, arg);
        }
        /// <summary>
        /// 新增权限组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NvbtAdd_Click(object sender, EventArgs e)
        {
            //初始状态应设置为新增
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PowerGroup);
            if (listPower.Count == 0)
            {
                //此时用户无任何权限，则关闭当前窗体
                this.FormColse();
                return;
            }
            if(this.IsDataSourceChanged && DialogResult.Yes!=MessageBox.Show(this,"当前数据已经修改，您确定不保存吗？","操作提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                    return;
            //设置窗体状态
            if (!listPower.Contains(OperatePower.New))
                this.FormState = FormStates.Readonly;
            else if (this.BindPowerGroupInfo(string.Empty))
                this.FormState = FormStates.New;
            this.SetFormState();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                if (this.FormState != FormStates.Edit)
                {
                    //初始状态应设置为新增
                    List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PowerGroup);
                    //设置窗体状态
                    if (listPower.Contains(OperatePower.Eidt) && this.BindPowerGroupInfo(this.tbCode.Text.Trim()))
                        this.FormState = FormStates.Edit;
                    else
                        this.FormState = FormStates.Readonly;
                    this.SetFormState();
                }
                this.ShowMsg("保存成功");
                this.BindPowerGroupList();
            }
        }
        /// <summary>
        /// 保存并新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSaveAndNew_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                //初始状态应设置为新增
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PowerGroup);
                //设置窗体状态
                if (!listPower.Contains(OperatePower.New))
                {
                    this.ShowMsg("您没有新增权限组的权限。");
                }
                else if (this.BindPowerGroupInfo(string.Empty))
                    this.FormState = FormStates.New;
                this.SetFormState();
                this.ShowMsg("保存成功");
                this.BindPowerGroupList();
            }
        }
        /// <summary>
        /// 树节点checkbox改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDetails_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                foreach (TreeNode tn in e.Node.Nodes)
                    this.SetCheckedTreeModule(tn, e.Node.Checked);
            }
        }
        #endregion   

        private void NvbtDeptRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            //初始状态应设置为新增
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PowerGroup);
            if (!listPower.Contains(OperatePower.Delete))
            {
                this.ShowMsg("您没有权限组的删除权限。");
                return;
            }
            if ( DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的数据吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            DataTable dt=this.dgvList.DataSource as DataTable;
            if(dt==null)return;
            for (int i = this.dgvList.SelectedRows.Count; i > 0; i--)
            {
                this.BllDAL.Detele(dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["PowerGroupCode"].ToString());
            }
            this.BindPowerGroupList();
        }
    }
}