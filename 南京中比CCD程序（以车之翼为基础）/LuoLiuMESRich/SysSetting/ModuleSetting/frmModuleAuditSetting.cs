using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using SysSetting.UserControl;
using Common;
namespace SysSetting.ModuleSetting
{
    public partial class frmModuleAuditSetting :frmBase
    {
        public frmModuleAuditSetting()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.ModuleAuditSetting _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.ModuleAuditSetting BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new SysSetting.BLLDAL.ModuleAuditSetting();
                return _dal;
            }
        }
        #endregion
        #region 窗体属性
        private bool IsDataSourceChanged
        {
            get 
            {
                if (this.DataSource == null) return false;
                return this.DataSource.Tables["Sys_ModuleAuditSetting"].GetChanges() != null;
            }
        }
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            //先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.ModuleAuditSetting);
            if (listPower.Count == 0)
            {
                this.ShowMsg("你没有该模块的任何权限，如有需要请联系管理员开放相应权限。");
                this.FormColse();
                return false;
            }
            this.ucModuleAudit1.EditPower = listPower.Contains(Common.MyEnums.OperatePower.Eidt);
            return true;
        }
        private bool BindModules()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSqls = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM Sys_ModuleGroup ORDER BY SortID";
            listSqls.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_ModuleGroup"));
            strSql = "SELECT * FROM Sys_Module WHERE ISNULL(NeedAudit,0)=1 ORDER BY GroupCode,SortID";
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
            //绑定模块权限
            TreeNode tnGroup = null;
            TreeNode tnMod = null;
            DataRow[] drs;
            foreach (DataRow drGroup in ds.Tables["Sys_ModuleGroup"].Rows)
            {
                tnGroup = new TreeNode();
                tnGroup.Text = drGroup["GroupName"].ToString();
                this.tvModule.Nodes.Add(tnGroup);
                //添加字模块
                drs = ds.Tables["Sys_Module"].Select("GroupCode='" + drGroup["GroupCode"].ToString() + "'");
                foreach (DataRow drMod in drs)
                {
                    tnMod = new TreeNode();
                    tnMod.Text = drMod["ModuleName"].ToString();
                    tnMod.Tag = drMod["ModuleCode"].ToString();
                    tnGroup.Nodes.Add(tnMod);
                }
            }
            //展开所有
            this.tvModule.ExpandAll();
            return true;
        }   
        /// <summary>
        ///绑定审批流程
        /// </summary>
        /// <param name="strModuleCode"></param>
        /// <returns></returns>
        private bool BindAuditItems(string strModuleCode)
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSqls = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = string.Format("SELECT *,dbo.Common_GetWaitAuditerNames(WaitAuditer) AS WaitAuditerNames FROM Sys_ModuleAuditSetting WHERE ModuleCode='{0}' ORDER BY SortID", strModuleCode.Replace("'", "''"));
            listSqls.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_ModuleAuditSetting"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSqls);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            List<Common.MyEntity.ModuleAuditItem> listItems = new List<Common.MyEntity.ModuleAuditItem>();
            foreach (DataRow dr in ds.Tables["Sys_ModuleAuditSetting"].Rows)
            {
                Common.MyEntity.ModuleAuditItem itemNew = new Common.MyEntity.ModuleAuditItem();
                itemNew.SortID = dr["SortID"].Equals(DBNull.Value) ? 0 : (int)dr["SortID"];
                itemNew.FlowName = dr["FlowName"].ToString();
                itemNew.WaitAuditers = dr["WaitAuditer"].ToString();
                itemNew.WaitAuditerNames = dr["WaitAuditerNames"].ToString();
                listItems.Add(itemNew);
            }
            this.ucModuleAudit1.AuditItems = listItems;
            this.DataSource = ds;
            return true;
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.tvModule.SelectedNode == null
                || this.tvModule.SelectedNode.Tag == null
                || this.tvModule.SelectedNode.Tag.ToString().Length == 0)
                return false;
            return true;
        }
        private void ReadFormData(DataSet dsSource,string strModuleCode)
        {
            List<Common.MyEntity.ModuleAuditItem> listItems= this.ucModuleAudit1.AuditItems;
            if (listItems == null)
                listItems = new List<Common.MyEntity.ModuleAuditItem>();
            //编辑新增或修改的数据
            DataRow[] drs;
            DataRow drEdit;
            string strSortIDs = string.Empty;
            foreach (Common.MyEntity.ModuleAuditItem item in listItems)
            {
                drs = dsSource.Tables["Sys_ModuleAuditSetting"].Select("SortID=" + item.SortID.ToString());
                if (drs.Length == 0)
                {
                    drEdit = dsSource.Tables["Sys_ModuleAuditSetting"].NewRow();
                    drEdit["ModuleCode"] = strModuleCode;
                    drEdit["SortID"] = item.SortID;
                    drEdit["FlowName"] = item.FlowName;
                    drEdit["WaitAuditer"] = item.WaitAuditers;
                    dsSource.Tables["Sys_ModuleAuditSetting"].Rows.Add(drEdit);
                }
                else
                {
                    drEdit = drs[0];
                    if (!drEdit["FlowName"].Equals(item.FlowName))
                        drEdit["FlowName"] = item.FlowName;
                    if (!drEdit["WaitAuditer"].Equals(item.WaitAuditers))
                        drEdit["WaitAuditer"] = item.WaitAuditers;
                }
                strSortIDs += item.SortID.ToString() + ",";
            }
            //查找删除掉的流程
            if (strSortIDs.EndsWith(","))
                strSortIDs = strSortIDs.Substring(0, strSortIDs.Length - 1);
            if (strSortIDs.Length > 0)
            {
                drs = dsSource.Tables["Sys_ModuleAuditSetting"].Select("SortID not in(" + strSortIDs + ")");
            }
            else
            {
                //此时表示所有都已经删除
                drs = dsSource.Tables["Sys_ModuleAuditSetting"].Select("1=1");
            }
            for (int i = drs.Length; i > 0; i--)
                drs[i - 1].Delete();
        }
        private bool Save()
        {
            this.ReadFormData(this.DataSource, this.tvModule.SelectedNode.Tag.ToString());
            if (this.DataSource.Tables["Sys_ModuleAuditSetting"].GetChanges() == null) return true;
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
        #region 控件事件
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck())
                return;
            if (this.Save())
            {
                this.BindAuditItems(this.tvModule.SelectedNode.Tag.ToString());
                this.ShowMsg("保存成功。");
            }
        }
        private void btAddAuditItem_Click(object sender, EventArgs e)
        {
            if (this.tvModule.SelectedNode == null || this.tvModule.SelectedNode.Tag == null
                || this.tvModule.SelectedNode.Tag.ToString().Length == 0)
            {
                this.ShowMsg("请选择具体模块，然后添加数据");
                return;
            }
            this.ucModuleAudit1.AddItem();
        }
        private void tvModule_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.IsDataSourceChanged && DialogResult.Yes != MessageBox.Show(this, "数据已经改变，但尚未保存，您确定不保存数据吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            if (e.Node.Tag == null || e.Node.Tag.ToString().Length == 0)
                this.BindAuditItems(string.Empty);
            else
                this.BindAuditItems(e.Node.Tag.ToString());
        }
        #endregion   
        #region 窗体加载
        private void frmModuleAuditSetting_Load(object sender, EventArgs e)
        {
            this.PerInit();
            this.BindModules();
        }
        #endregion
    }
}