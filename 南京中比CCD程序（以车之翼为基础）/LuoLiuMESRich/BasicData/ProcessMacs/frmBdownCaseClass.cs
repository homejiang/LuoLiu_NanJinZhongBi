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
    public partial class frmBdownCaseClass : frmBase
    {
        public frmBdownCaseClass()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.MacBreakdownCaseClass _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.MacBreakdownCaseClass BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.MacBreakdownCaseClass();
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
            this.dgvList.AutoGenerateColumns = false;
            return true;
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <returns></returns>
        private bool BindData()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql="SELECT * FROM JC_MacBreakdownCaseClass Order by SortID ASC";
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
            DataColumn dc = new DataColumn("TerminatedView", typeof(string));
            dc.Expression = "IIF(isnull(Terminated,0)=1,'停用','启用')";
            ds.Tables["JC_MacBreakdownCaseClass"].Columns.Add(dc);
            this.dgvList.DataSource = ds.Tables["JC_MacBreakdownCaseClass"];
            this.DataSource = ds;
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
                this.ShowMsg("您没有新增异常内容编辑模块权限，如果需要请联系管理员开放该权限。");
                return false;
            }
            if (this.tbCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入类别编码！");
                return false;
            }
            //判断单位是否已经存在
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_MacBreakdownCaseClass WHERE Code='{0}'", this.tbCode.Text.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count > 0)
            {
                this.ShowMsg("类别代码“" + this.tbCode.Text + "”已经存在，请更换");
                return false;
            }
            if (this.tbDesc.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入类别描述");
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
            return true;
        }
        #endregion
        #region 新增异常内容编辑
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck())
                return;
            DataTable dt = this.DataSource.Tables["JC_MacBreakdownCaseClass"];
            DataRow dr;
            dr = dt.NewRow();
            if (!dr["Code"].Equals(this.tbCode.Text.Trim()))
                dr["Code"] = this.tbCode.Text.Trim();
            if (!dr["ClassName"].Equals(this.tbDesc.Text.Trim()))
                dr["ClassName"] = this.tbDesc.Text.Trim();
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
            dt.Rows.Add(dr);
            try
            {
                this.BllDAL.Save(this.DataSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.tbDesc.Text = string.Empty;
            this.tbCode.Text = string.Empty;
            this.BindData();
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
            frmBdownCaseClassEdit frm = new frmBdownCaseClassEdit();
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
                this.ShowMsg("你没有异常内容编辑模块的任何权限，如有需要请联系管理员开放相应权限！");
                this.FormColse();
                return;
            }
            if (!this.PerInit())
                return;
            this.BindData();
        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdownCase);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有编辑异常内容编辑模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            bool blUpdate = false;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                if (this.DataSource.Tables["JC_MacBreakdownCaseClass"].DefaultView[this.dgvList.SelectedRows[i].Index].Row["IsSys"].ToString() == "1"
                    && !Common.CurrentUserInfo.IsSuper)
                {
                    this.ShowMsg("系统必须项目只有超级管理员才能编辑。");
                    continue;
                }
                frmBdownCaseClassEdit frm = new frmBdownCaseClassEdit();
                frm.PrimaryValue = this.DataSource.Tables["JC_MacBreakdownCaseClass"].DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
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
                this.ShowMsg("您没有编辑异常内容编辑模块权限，如果需要请联系管理员开放该权限。");
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
                this.ShowMsg("您没有编辑异常内容编辑模块权限，如果需要请联系管理员开放该权限。");
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
                this.ShowMsg("您没有删除异常内容编辑模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的异常内容编辑吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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