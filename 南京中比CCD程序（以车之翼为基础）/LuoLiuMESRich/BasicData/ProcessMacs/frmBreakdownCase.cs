using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;

namespace BasicData.ProcessMacs
{
    public partial class frmBreakdownCase : frmBase
    {
        public frmBreakdownCase()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.MacBreakdownCase _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.MacBreakdownCase BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.MacBreakdownCase();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        /// <summary>
        /// 窗体初始化加载信息
        /// </summary>
        /// <returns></returns>
        private bool PerInit()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql;
            strSql = "SELECT Code,LevelDesc FROM JC_MacBreakdownCaseLevel WHERE ISNULL(Terminated,0)=0 ORDER BY SortID";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_MacBreakdownCaseLevel", true));
            strSql = "SELECT Code,ClassName FROM JC_MacBreakdownCaseClass WHERE ISNULL(Terminated,0)=0 ORDER BY SortID";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_MacBreakdownCaseClass", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comLevel.DisplayMember = "Text";
            this.comLevel.ValueMember = "Value";
            foreach (DataRow dr in ds.Tables["JC_MacBreakdownCaseLevel"].Rows)
            {
                comLevel.Items.Add(new Common.MyEntity.ComboBoxItem(dr["LevelDesc"].ToString(), dr["Code"].ToString()));
            }
            this.comClass.DisplayMember = "Text";
            this.comClass.ValueMember = "Value";
            foreach (DataRow dr in ds.Tables["JC_MacBreakdownCaseClass"].Rows)
            {
                comClass.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ClassName"].ToString(), dr["Code"].ToString()));
            }
            this.dgvList.AutoGenerateColumns = false;
            this.tbCode.Text = this.GetAutoCode(Common.MyEnums.Modules.MacBreakdownCase);
            return true;
        }
        private bool BindDataProcess()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT Code,ProcessName FROM JC_Process WHERE ISNULL(Terminated,0)=0 ORDER BY SortID");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comProcess.DisplayMember = "Text";
            this.comProcess.ValueMember = "Value";
            this.comProcess.Items.Clear();
            this.comProcess.Items.Add(new Common.MyEntity.ComboBoxItem("-----公共异常-----", ""));
            this.tvProcess.Nodes.Clear();
            TreeNode tnRoot = new TreeNode("所有工序");
            this.tvProcess.Nodes.Add(tnRoot);
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tnNew = new TreeNode(dr["ProcessName"].ToString());
                tnNew.Tag = dr["Code"].ToString();
                tnRoot.Nodes.Add(tnNew);
                this.comProcess.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ProcessName"].ToString(), dr["Code"].ToString()));
            }
            tnRoot.ExpandAll();
            return true;
        }
        private bool BindData(string sProcessCode)
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql;
            if (sProcessCode.Length > 0)
                strSql = string.Format("SELECT * FROM V_JC_MacBreakdownCase WHERE ProcessCode='{0}' Order by SortID ASC",sProcessCode.Replace("'","''"));
            else strSql = "SELECT * FROM V_JC_MacBreakdownCase Order by SortID ASC";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_MacBreakdownCase", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = ds.Tables["JC_MacBreakdownCase"];
            this.DataSource = ds;
            return true;
        }
        private bool BindData()
        {
            string strProcessCode;
            TreeNode tn = this.tvProcess.SelectedNode;
            if (tn == null || tn.Tag == null || tn.Tag.ToString().Length == 0)
                strProcessCode = string.Empty;
            else strProcessCode = tn.Tag.ToString();
            return this.BindData(strProcessCode);
        }
        private bool ReBindLevel()
        {
            DataTable dt;
            string strSql;
            strSql = "SELECT Code,LevelDesc FROM JC_MacBreakdownCaseLevel WHERE ISNULL(Terminated,0)=0 ORDER BY SortID";
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comLevel.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                comLevel.Items.Add(new Common.MyEntity.ComboBoxItem(dr["LevelDesc"].ToString(), dr["Code"].ToString()));
            }
            return true;
        }
        private bool ReBindClass()
        {
            DataTable dt;
            string strSql;
            strSql = "SELECT Code,ClassName FROM JC_MacBreakdownCaseClass WHERE ISNULL(Terminated,0)=0 ORDER BY SortID";
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comClass.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                comClass.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ClassName"].ToString(), dr["Code"].ToString()));
            }
            return true;
        }
        #endregion
        #region 保存数据
        /// <summary>
        /// 保存前校验
        /// </summary>
        /// <returns></returns>
        private bool SaveCheck()
        {
            //先判断权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdownCase);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("您没有模块新增权限，如果需要请联系管理员开放该权限。");
                return false;
            }
            if (this.tbCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入异常代码！");
                return false;
            }
            if (this.tbRemark.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入异常描述！");
                return false;
            }
            object objValue = this.GetComboBoxValue(this.comLevel);
            if (objValue.ToString().Length == 0)
            {
                this.ShowMsg("请选择异常等级");
                return false;
            }
            //判断异常是否已经存在
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_MacBreakdownCase WHERE Code='{0}'", this.tbCode.Text.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count > 0)
            {
                this.ShowMsg("异常代码“" + this.tbCode.Text + "”已经存在，请更换");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            //读取数据
            DataTable dt = this.DataSource.Tables["JC_MacBreakdownCase"];
            DataRow dr;
            dr = dt.NewRow();
            dr["Code"] = this.tbCode.Text.Trim();
            int iSortID = 0;
            #region 获取最大排序值
            int iTempSort;
            foreach (DataRowView drv in dt.DefaultView)
            {
                if (drv.Row["SortID"].Equals(DBNull.Value)) continue;
                iTempSort = (int)drv.Row["SortID"];
                if (iTempSort > iSortID)
                    iSortID = iTempSort;
            }
            iSortID++;
            #endregion
            dr["SortID"] = iSortID;
            dr["CaseDesc"] = this.tbRemark.Text;
            dr["LevelCode"] = this.GetComboBoxValue(this.comLevel);
            dr["ProcessCode"] = this.GetComboBoxValue(this.comProcess);
            dr["ClassCode"] = this.GetComboBoxValue(this.comClass);
            dt.Rows.Add(dr);
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

        private object GetComboBoxValue(ComboBox combox)
        {
            if (combox.SelectedItem == null) return DBNull.Value;
            Common.MyEntity.ComboBoxItem item = combox.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null) return DBNull.Value;
            return item.Value;
        }
        #endregion
        #region 新增计量异常
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck())
                return;
            if (this.Save())
            {
                this.tbCode.Text = this.GetAutoCode(Common.MyEnums.Modules.MacBreakdownCase);
                this.tbRemark.Clear();
                //this.comLevel.SelectedIndex = -1;
                this.BindData();
            }
        }
        #endregion
        #region 工具条按钮事件
        //编辑按钮
        private void nvbtEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void nvbtUp_Click(object sender, EventArgs e)
        {
            
        }

        private void nvbtDown_Click(object sender, EventArgs e)
        {
            
        }

        private void nvbtRemove_Click(object sender, EventArgs e)
        {
            
        }
        //列表双击事件
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            frmBreakdownCaseEdit frm = new frmBreakdownCaseEdit();
            frm.PrimaryValue = dt.DefaultView[e.RowIndex].Row["Code"].ToString();
            if (DialogResult.OK == frm.ShowDialog(this))
                this.BindData();
        }
        #endregion
        #region 窗体加载事件
        private void frmUnits_Load(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdownCase);
            if (listPower.Count == 0)
            {
                this.ShowMsg("你没有计量异常模块的任何权限，如有需要请联系管理员开放相应权限！");
                this.FormColse();
                return;
            }
            if (!this.PerInit())
                return;
            this.BindDataProcess();
        }
        #endregion
        private void tvProcess_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string sCode;
            if (e.Node == null || e.Node.Tag == null || e.Node.Tag.ToString().Length == 0)
                sCode = string.Empty;
            else sCode = e.Node.Tag.ToString();
            if (this.BindData(sCode))
                Common.CommonFuns.FormatData.SetComboBoxText(this.comProcess, new Common.MyEntity.ComboBoxItem("", sCode), 0);
        }

        private void picLevelAdd_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdownCase);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有编辑计量异常模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            frmBdownCaseLevel frm = new frmBdownCaseLevel();
            frm.ShowDialog(this);
            this.ReBindLevel();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdownCase);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有编辑计量异常模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            frmBdownCaseClass frm = new frmBdownCaseClass();
            frm.ShowDialog(this);
            this.ReBindClass();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdownCase);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有编辑计量异常模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;

            bool blUpdate = false;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                if (this.DataSource.Tables["JC_MacBreakdownCase"].DefaultView[this.dgvList.SelectedRows[i].Index].Row["IsSys"].ToString() == "1"
                    && !Common.CurrentUserInfo.IsSuper)
                {
                    this.ShowMsg("系统必须项目只有超级管理员才能编辑。");
                    continue;
                }
                frmBreakdownCaseEdit frm = new frmBreakdownCaseEdit();
                frm.PrimaryValue = this.DataSource.Tables["JC_MacBreakdownCase"].DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                if (DialogResult.OK == frm.ShowDialog(this))
                    blUpdate = true;
            }
            //如果用户修改过数据，则需要重新加载
            if (blUpdate)
                this.BindData();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdownCase);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有编辑异常内容模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            int iIndex = this.dgvList.SelectedRows[0].Index;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow drNext, drCur;
            drNext = null;
            drCur = null;
            for (int i = 0; i < dt.DefaultView.Count; i++)
            {
                if (i == iIndex)
                {
                    drCur = dt.DefaultView[i].Row;
                    break;
                }
                drNext = dt.DefaultView[i].Row;
            }
            if (drNext == null || drCur == null) return;
            object objSortID = drNext["SortID"];
            drNext["SortID"] = drCur["SortID"];
            drCur["SortID"] = objSortID;
            try
            {
                this.BllDAL.Save(this.DataSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindData();
            iIndex--;
            if (iIndex >= 0)
                this.dgvList.Rows[iIndex].Selected = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdownCase);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有编辑异常内容模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            int iIndex = this.dgvList.SelectedRows[0].Index;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow drNext, drCur;
            drNext = null;
            drCur = null;
            for (int i = dt.DefaultView.Count; i > 0; i--)
            {
                if ((i - 1) == iIndex)
                {
                    drCur = dt.DefaultView[i - 1].Row;
                    break;
                }
                drNext = dt.DefaultView[i - 1].Row;
            }
            if (drNext == null || drCur == null) return;
            object objSortID = drNext["SortID"];
            drNext["SortID"] = drCur["SortID"];
            drCur["SortID"] = objSortID;
            try
            {
                this.BllDAL.Save(this.DataSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindData();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdownCase);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("您没有删除异常内容模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的异常内容吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            try
            {
                for (int i = this.dgvList.SelectedRows.Count; i > 0; i--)
                {
                    if (!dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["IsSys"].Equals(DBNull.Value)
                    && (bool)dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["IsSys"]
                      && !Common.CurrentUserInfo.IsSuper)
                    {
                        this.ShowMsg("系统必须项目只有超级管理员才能移除。");
                        continue;
                    }
                    this.BllDAL.Detele(dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["Code"].ToString());
                }
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindData();
        }
    }
}