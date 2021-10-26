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

namespace SysSetting.ModuleSetting
{
    public partial class frmModuleEdit : frmBase
    {
        public frmModuleEdit()
        {
            InitializeComponent();
        }
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
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT GroupCode,GroupName FROM Sys_ModuleGroup Order By SortID", "Sys_ModuleGroup", false));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comGroup.DisplayMember = "Text";
            this.comGroup.ValueMember = "Value";
            this.comGroup.DataSource =Common.CommonFuns.FormatData.GetComboBoxItemList(ds.Tables["Sys_ModuleGroup"], "GroupName", "GroupCode");
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
            string strSql = "SELECT * FROM Sys_Module WHERE ModuleCode='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Sys_Module", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (ds.Tables["Sys_Module"].DefaultView.Count == 0)
            {
                this.ShowMsg("当前模块不存在或已经被删除，请检查。");
                return false;
            }
            this.tbCode.Text = ds.Tables["Sys_Module"].DefaultView[0].Row["ModuleCode"].ToString();
            this.tbModuleName.Text = ds.Tables["Sys_Module"].DefaultView[0].Row["ModuleName"].ToString();
            this.numModuleSign.BindValue = ds.Tables["Sys_Module"].DefaultView[0].Row["EnumNo"];
            this.numSortID.BindValue=ds.Tables["Sys_Module"].DefaultView[0].Row["SortID"];
            this.chkCanNew.Checked = !ds.Tables["Sys_Module"].DefaultView[0].Row["CanNew"].Equals(DBNull.Value) && (bool)ds.Tables["Sys_Module"].DefaultView[0].Row["CanNew"];
            this.chkCanEdit.Checked = !ds.Tables["Sys_Module"].DefaultView[0].Row["CanEdit"].Equals(DBNull.Value) && (bool)ds.Tables["Sys_Module"].DefaultView[0].Row["CanEdit"];
            this.chkCanDelete.Checked = !ds.Tables["Sys_Module"].DefaultView[0].Row["CanDelete"].Equals(DBNull.Value) && (bool)ds.Tables["Sys_Module"].DefaultView[0].Row["CanDelete"];
            this.chkNeedAudit.Checked = !ds.Tables["Sys_Module"].DefaultView[0].Row["NeedAudit"].Equals(DBNull.Value) && (bool)ds.Tables["Sys_Module"].DefaultView[0].Row["NeedAudit"];
            this.chkIsAutoCode.Checked = !ds.Tables["Sys_Module"].DefaultView[0].Row["IsAutoCode"].Equals(DBNull.Value) && (bool)ds.Tables["Sys_Module"].DefaultView[0].Row["IsAutoCode"];
            Common.CommonFuns.FormatData.SetComboBoxText(this.comGroup, new Common.MyEntity.ComboBoxItem("", ds.Tables["Sys_Module"].DefaultView[0].Row["GroupCode"].ToString()), 0);
            this.DataSource = ds;
            return true;
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.tbCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输模块编码。");
                return false;
            }
            if (this.tbModuleName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入模块名称。");
                return false;
            }
            if (this.numModuleSign.BindValue.Equals(DBNull.Value))
            {
                this.ShowMsg("请输入模块标识。");
                return false;
            }
            ComboBoxItem item=this.comGroup.SelectedItem as ComboBoxItem;
            if (item==null || item.Value==null || item.Value.ToString().Length==0)
            {
                this.ShowMsg("请选择所属模块组。");
                return false;
            }
            if (this.DataSource == null || this.DataSource.Tables["Sys_Module"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据源不正确，请重新加载窗体。");
                return false;
            }
            //是否编码重复
            if (!this.DataSource.Tables["Sys_Module"].DefaultView[0].Row["ModuleCode"].Equals(this.tbCode.Text.Trim()))
            {
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT ModuleCode FROM Sys_Module WHERE ModuleCode='{0}'",this.tbCode.Text.Trim().Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("模块编码“"+ this.tbCode.Text.Trim() + "”已经存在，请检查。");
                    return false;
                }
            }
            //判断同一组内是否有同名模块
            if (!this.DataSource.Tables["Sys_Module"].DefaultView[0].Row["ModuleName"].Equals(this.tbModuleName.Text.Trim())
                || !this.DataSource.Tables["Sys_Module"].DefaultView[0].Row["GroupCode"].Equals(item.Value.ToString()))
            {
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT ModuleCode FROM Sys_Module WHERE GroupCode='{0}' AND ModuleName='{1}'", item.Value.ToString().Replace("'", "''"), this.tbModuleName.Text.Trim().Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("模块名“" + this.tbModuleName.Text + "”已经存在于模块组“" + item.Text + "”中，请检查。");
                    return false;
                }
            }
            return true;
        }
        private bool Save()
        {
            DataRow dr = this.DataSource.Tables["Sys_Module"].DefaultView[0].Row;
            if (!dr["ModuleCode"].Equals(this.tbCode.Text.Trim()))
                dr["ModuleCode"] = this.tbCode.Text.Trim();
            if (!dr["ModuleName"].Equals(this.tbModuleName.Text.Trim()))
                dr["ModuleName"] = this.tbModuleName.Text.Trim();
            if (!dr["SortID"].Equals(this.numSortID.BindValue))
                dr["SortID"] = this.numSortID.BindValue;
            if (!dr["EnumNo"].Equals(this.numModuleSign.BindValue))
                dr["EnumNo"] = this.numModuleSign.BindValue;
            if(this.chkCanNew.Checked ^ (!dr["CanNew"].Equals(DBNull.Value) && (bool)dr["CanNew"]))
                dr["CanNew"]=this.chkCanNew.Checked;

            if(this.chkCanEdit.Checked ^ (!dr["CanEdit"].Equals(DBNull.Value) && (bool)dr["CanEdit"]))
                dr["CanEdit"]=this.chkCanEdit.Checked;

            if(this.chkCanDelete.Checked ^ (!dr["CanDelete"].Equals(DBNull.Value) && (bool)dr["CanDelete"]))
                dr["CanDelete"]=this.chkCanDelete.Checked;

            if(this.chkNeedAudit.Checked ^ (!dr["NeedAudit"].Equals(DBNull.Value) && (bool)dr["NeedAudit"]))
                dr["NeedAudit"]=this.chkNeedAudit.Checked;

            if(this.chkIsAutoCode.Checked ^ (!dr["IsAutoCode"].Equals(DBNull.Value) && (bool)dr["IsAutoCode"]))
                dr["IsAutoCode"]=this.chkIsAutoCode.Checked;
            ComboBoxItem item = this.comGroup.SelectedItem as ComboBoxItem;
            if (item == null || item.Value == null && !dr["GroupCode"].Equals(DBNull.Value))
                dr["GroupCode"] = DBNull.Value;
            else if (!dr["GroupCode"].Equals(item.Value.ToString()))
                dr["GroupCode"] = item.Value;
            if (this.DataSource.Tables["Sys_Module"].GetChanges() == null)
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
        private void frmModuleEdit_Load(object sender, EventArgs e)
        {
            this.SetDefaultData();
            if (!this.PerInit()) return;
            this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString());
        }
        #endregion
    }
}