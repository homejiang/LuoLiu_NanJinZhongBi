using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common.MyEnums;

namespace SysSetting.ModuleSetting
{
    public partial class frmModuleSetting : Common.frmBase
    {
        public frmModuleSetting()
        {
            InitializeComponent();
        }
        #region 窗体属性
        #region 窗体数据连接实例
        private BLLDAL.ModuleSetting _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.ModuleSetting BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new SysSetting.BLLDAL.ModuleSetting();
                return _dal;
            }
        }
        #endregion
        #endregion
        #region 模块组操作
        /// <summary>
        /// 加载模块组信息
        /// </summary>
        /// <returns></returns>
        private bool BindModuleGroup()
        {
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("SELECT * FROM Sys_ModuleGroup order by SortID");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //加载根节点
            TreeNode tnParent = new TreeNode();
            tnParent.Text = "所有模块";
            tnParent.Tag = string.Empty;
            this.tvModules.Nodes.Clear();
            this.tvModules.Nodes.Add(tnParent);
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tnNew = new TreeNode();
                tnNew.Text = dr["GroupName"].ToString();
                tnNew.Tag = dr["GroupCode"].ToString();
                tnParent.Nodes.Add(tnNew);
            }
            tnParent.ExpandAll();
            return true;
        }
        #region 按钮事件
        private void NvbtGroupAdd_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.ModuleSetting);
            if (listPower.Count == 0)
            {
                this.ShowMsg("您没有模块组模块的任何权限。");
                return;
            }
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("您没有新增模块组的权限。");
                return;
            }
            frmModuleGroupEdit frm = new frmModuleGroupEdit();
            frm.FormState = Common.MyEnums.FormStates.New;
            if (DialogResult.OK == frm.ShowDialog(this))
            {
                //重新加载模块组信息
                this.BindModuleGroup();
            }
        }

        private void nvbtGroupEdit_Click(object sender, EventArgs e)
        {
            if (this.tvModules.SelectedNode == null) return;
            TreeNode tn = this.tvModules.SelectedNode;
            if (tn.Tag == null || tn.Tag.ToString().Length == 0) return;
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.ModuleSetting);
            if (listPower.Count == 0)
            {
                this.ShowMsg("您没有模块组模块的任何权限。");
                return;
            }
            frmModuleGroupEdit frm = new frmModuleGroupEdit();
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                frm.FormState = FormStates.Readonly;
            else
                frm.FormState = FormStates.Edit;
            frm.PrimaryValue = tn.Tag.ToString();
            if (DialogResult.OK == frm.ShowDialog(this))
            {
                //重新加载模块组信息
                this.BindModuleGroup();
            }
        }

        private void NvbtGroupRemove_Click(object sender, EventArgs e)
        {
            if (this.tvModules.SelectedNode == null) return;
            TreeNode tn = this.tvModules.SelectedNode;
            if (tn.Tag == null || tn.Tag.ToString().Length == 0) return;
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.ModuleSetting, tn.Tag.ToString());
            if (!listPower.Contains(OperatePower.Delete))
            {
                this.ShowMsg("您没有模块组模块的删除权限。");
                return;
            }
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的模块组吗？这样也会删除其包含的所有模块", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            string strErr;
            int iReturn;
            try
            {
                this.BllDAL.DeteleGroup(tn.Tag.ToString(), out strErr, out iReturn);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturn != 1)
            {
                if (strErr.Length == 0)
                    strErr = "操作失败。";
                this.ShowMsg(strErr);
                return;
            }
            this.BindModuleGroup();
        }
        private void tvGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.BindModules();
        }
        #endregion
        #endregion
        #region 模块操作
        //加载模块
        private bool BindModules()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql;
            if (this.tvModules.SelectedNode == null || this.tvModules.SelectedNode.Tag == null || this.tvModules.SelectedNode.Tag.ToString().Length == 0)
                strSql = "SELECT * FROM V_Sys_Module ORDER BY SortID ASC";
            else
                strSql = "SELECT * FROM V_Sys_Module WHERE GroupCode='" + this.tvModules.SelectedNode.Tag.ToString().Replace("'", "''") + "' ORDER BY SortID ASC";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_Module", false));
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
            this.dgvList.DataSource = ds.Tables["Sys_Module"];
            return true;
        }
        private bool SaveCheck()
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.ModuleSetting);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("您没有新增模块的权限。");
                return false;
            }
            if (this.tvModules.SelectedNode == null || this.tvModules.SelectedNode.Tag == null || this.tvModules.SelectedNode.Tag.ToString().Length == 0)
            {
                this.ShowMsg("请在左边模块组信息框内选择指定的模块组。");
                return false;
            }
            if (this.tbCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入中文名称。");
                this.tbModuleName.Focus();
                return false;
            }
            if (this.tbModuleName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入中文名称。");
                this.tbModuleName.Focus();
                return false;
            }
            int iEnumNo;
            if (this.numEnumNo.BindValue.Equals(DBNull.Value) || !int.TryParse(this.numEnumNo.Text, out iEnumNo) || iEnumNo < 0)
            {
                this.ShowMsg("请输入正确的模块标识符号。");
                this.numEnumNo.Focus();
                return false;
            }
            //判断是否系统中已经存在编码
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT ModuleCode FROM Sys_Module WHERE ModuleCode='{0}'", this.tbCode.Text.Trim().Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.DefaultView.Count > 0)
            {
                this.ShowMsg("模块编码“" + this.tbCode.Text.Trim() + "”在系统中已经存在，请更换。");
                return false;
            }
            //判断是否系统中已经存在中文名称
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT ModuleCode FROM Sys_Module WHERE GroupCode='{0}' AND ModuleName='{1}'", this.tvModules.SelectedNode.Tag.ToString().Replace("'", "''"), this.tbModuleName.Text.Trim().Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.DefaultView.Count > 0)
            {
                this.ShowMsg("在模块组“" + this.tvModules.SelectedNode.Text + "”内已经存在模块名“" + this.tbModuleName.Text.Trim() + "”，请检查。");
                return false;
            }
            return true;
        }
        private bool Save()
        {
            DataRow drNew = this.DataSource.Tables["Sys_Module"].NewRow();
            drNew["ModuleCode"] = this.tbCode.Text.Trim();
            drNew["ModuleName"] = this.tbModuleName.Text.Trim();
            drNew["EnumNo"] = Convert.ToInt32(this.numEnumNo.BindValue);
            drNew["SortID"] = this.numSortID.BindValue;
            drNew["GroupCode"] = this.tvModules.SelectedNode.Tag.ToString();
            drNew["CanNew"] = this.chkCanNew.Checked;
            drNew["CanEdit"] = this.chkCanEdit.Checked;
            drNew["CanDelete"] = this.chkCanDelete.Checked;
            drNew["NeedAudit"] = this.chkNeedAudit.Checked;
            drNew["IsAutoCode"] = this.chkIsAutoCode.Checked;
            this.DataSource.Tables["Sys_Module"].Rows.Add(drNew);
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
        #region 窗体控件事件
        private void frmModuleSetting_Load(object sender, EventArgs e)
        {
            this.dgvList.AutoGenerateColumns = false;
            this.BindModuleGroup();
            this.BindModules();
            this.tbCode.Text = this.GetAutoCode(Modules.ModuleSetting);
        }
        private void nvbtEdit_Click(object sender, EventArgs e)
        {
            //检查权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.ModuleSetting);
            if (!listPower.Contains(OperatePower.Eidt))
            {
                this.ShowMsg("您没有此模块的编辑权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                frmModuleEdit frm = new frmModuleEdit();
                frm.PrimaryValue = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["ModuleCode"].ToString();
                frm.FormState = FormStates.Edit;
                if (DialogResult.OK == frm.ShowDialog(this))
                    this.BindModules();
            }
        }
        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 && e.ColumnIndex < 0) return;
            //检查权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.ModuleSetting);
            if (!listPower.Contains(OperatePower.Eidt))
            {
                this.ShowMsg("您没有模块的编辑权限。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            frmModuleEdit frm = new frmModuleEdit();
            frm.PrimaryValue = dt.DefaultView[e.RowIndex].Row["ModuleCode"].ToString();
            frm.FormState = FormStates.Edit;
            if (DialogResult.OK == frm.ShowDialog(this))
                this.BindModules();
        }
        private void nvbtRemove_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的模块吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            for (int i = this.dgvList.SelectedRows.Count; i > 0; i--)
            {
                try
                {
                    this.BllDAL.Detele(dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["ModuleCode"].ToString());
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
            }
            this.BindModules();
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck()) return;
            if (this.Save())
            {
                this.tbCode.Text = this.GetAutoCode(Modules.ModuleSetting);
                this.tbModuleName.Text = string.Empty;
                this.numEnumNo.BindValue = DBNull.Value;
                this.numSortID.BindValue = DBNull.Value;
                this.chkCanNew.Checked = false;
                this.chkCanEdit.Checked = false;
                this.chkCanDelete.Checked = false;
                this.chkNeedAudit.Checked = false;
                this.chkIsAutoCode.Checked = false;
                this.BindModules();
            }
        }
        #endregion
        #endregion
    }
}