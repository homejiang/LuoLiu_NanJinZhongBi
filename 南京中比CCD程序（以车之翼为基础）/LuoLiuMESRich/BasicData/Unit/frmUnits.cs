using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;

namespace BasicData.Unit
{
    public partial class frmUnits : frmBase
    {
        public frmUnits()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.Unit _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Unit BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.Unit();
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
            string strSql="SELECT * FROM JC_Unit Order by SortID ASC";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_Unit", true));
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
            dc.Expression = "IIF(Terminated=1,'是','否')";
            ds.Tables["JC_Unit"].Columns.Add(dc);
            this.dgvList.DataSource = ds.Tables["JC_Unit"];
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
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Unit);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("您没有新增计量单位模块权限，如果需要请联系管理员开放该权限。");
                return false;
            }
            if (this.tbUnitCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入单位编码！");
                return false;
            }
            //判断单位是否已经存在
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_Unit WHERE Code='{0}'", this.tbUnitCode.Text.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count > 0)
            {
                this.ShowMsg("单位编码“" + this.tbUnitCode.Text + "”已经存在，请更换");
                return false;
            }
            if (this.tbCNName.Text.Trim().Length == 0 && this.tbENName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入至少一个名称");
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
        #region 新增计量单位
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck())
                return;
            DataTable dt = this.DataSource.Tables["JC_Unit"];
            DataRow dr;
            dr = dt.NewRow();
            if (!dr["Code"].Equals(this.tbUnitCode.Text.Trim()))
                dr["Code"] = this.tbUnitCode.Text.Trim();
            if (!dr["CNName"].Equals(this.tbCNName.Text.Trim()))
                dr["CNName"] = this.tbCNName.Text.Trim();
            if (!dr["ENName"].Equals(this.tbENName.Text.Trim()))
                dr["ENName"] = this.tbENName.Text.Trim();
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
            this.tbCNName.Text = string.Empty;
            this.tbENName.Text = string.Empty;
            this.BindData();
        }
        #endregion
        #region 工具条按钮事件
        //编辑按钮
        private void nvbtEdit_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Unit);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有编辑计量单位模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            bool blUpdate = false;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                frmUnitEdit frm = new frmUnitEdit();
                frm.PrimaryValue = this.DataSource.Tables["JC_Unit"].DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                if (DialogResult.OK == frm.ShowDialog(this))
                    blUpdate = true;
            }
            //如果用户修改过数据，则需要重新加载
            if (blUpdate)
                this.BindData();
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
            frmUnitEdit frm = new frmUnitEdit();
            frm.PrimaryValue = dt.DefaultView[e.RowIndex].Row["Code"].ToString();
            if (DialogResult.OK == frm.ShowDialog(this))
                this.BindData();
        }
        #endregion
        #region 窗体加载事件
        private void frmUnits_Load(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Unit);
            if (listPower.Count == 0)
            {
                this.ShowMsg("你没有计量单位模块的任何权限，如有需要请联系管理员开放相应权限！");
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
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Unit);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有编辑计量单位模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            bool blUpdate = false;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                frmUnitEdit frm = new frmUnitEdit();
                frm.PrimaryValue = this.DataSource.Tables["JC_Unit"].DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                if (DialogResult.OK == frm.ShowDialog(this))
                    blUpdate = true;
            }
            //如果用户修改过数据，则需要重新加载
            if (blUpdate)
                this.BindData();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Unit);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有编辑计量单位模块权限，如果需要请联系管理员开放该权限。");
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Unit);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有编辑计量单位模块权限，如果需要请联系管理员开放该权限。");
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
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Unit);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("您没有删除计量单位模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的计量单位吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            try
            {
                for (int i = this.dgvList.SelectedRows.Count; i > 0; i--)
                {
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