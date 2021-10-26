using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;

namespace Common.ProcessJobs
{
    public partial class frmJobs : frmBase
    {
        public frmJobs()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.ProcessJobs _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.ProcessJobs BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new Common.BLLDAL.ProcessJobs();
                return _dal;
            }
        }
        #endregion
        #region 公共属性
        /// <summary>
        /// 工序编码
        /// </summary>
        public string _ProcessCode = string.Empty;
        #endregion
        #region 私有属性
        private string _ArgStr = string.Empty;
        private string _ProcessName = string.Empty;
        #endregion
        #region 处理函数
        /// <summary>
        /// 窗体初始化加载信息
        /// </summary>
        /// <returns></returns>
        private bool PerInit()
        {
            if (this._ProcessCode == string.Empty)
            {
                this.ShowMsg("请传入工序代码");
                this.FormColse();
                return false;
            }
            this.dgvList.AutoGenerateColumns = false;
            DataTable dtArg;
            try
            {
                dtArg = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT dbo.JC_Jobs_GetAutoCodeArg('{0}')"
                    , this._ProcessCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            _ArgStr = dtArg.Rows[0][0].ToString();
            DataTable dtProcess;
            try
            {
                dtProcess = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT ProcessName FROM jc_process WHERE Code='{0}'"
                    , this._ProcessCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            _ProcessName = dtProcess.Rows.Count == 0 ? string.Empty : dtProcess.Rows[0]["ProcessName"].ToString();
            if (this._ProcessName != string.Empty)
            {
                this.gp1.Text = _ProcessName + "新增岗位";
            }
            BindNewCode();//自动编码
            return true;
        }
        private void BindNewCode()
        {
            this.tbCode.Text = this.GetAutoCode(Common.MyEnums.Modules.Jobs, _ArgStr);
        }
        private bool BindData()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM JC_Jobs WHERE 1=1";
            if (this._ProcessCode != string.Empty)
                strSql += string.Format(" AND ProcessCode='{0}'", this._ProcessCode.Replace("'", "''"));
            strSql += " Order by SortID ASC";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_Jobs", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataColumn dc = new DataColumn("IsDefaultView", typeof(string));
            dc.Expression = "IIF(IsDefault=1,'是','否')";
            ds.Tables["JC_Jobs"].Columns.Add(dc);
            dc = new DataColumn("TerminatedView", typeof(string));
            dc.Expression = "IIF(Terminated=1,'已停用','启用')";
            ds.Tables["JC_Jobs"].Columns.Add(dc);
            this.dgvList.DataSource = ds.Tables["JC_Jobs"];
            this.DataSource = ds;
            return true;
        }
        #endregion
        #region 重写函数
        public override void InitParameters(string[] arrs)
        {
            this._ProcessCode = arrs[0];
        }
        #endregion
        #region 保存数据
        /// <summary>
        /// 保存前校验
        /// </summary>
        /// <returns></returns>
        private bool SaveCheck()
        {
            this.tbCode.Text = this.tbCode.Text.Trim();
            if (this.tbCode.Text.Length == 0)
            {
                this.ShowMsg("请输入编码！");
                return false;
            }
            //判断单位是否已经存在
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT Code FROM JC_Jobs WHERE Code='{0}'", this.tbCode.Text.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count > 0)
            {
                this.ShowMsg("岗位编码“" + this.tbCode.Text + "”已经存在，请更换");
                return false;
            }
            if (this.tbJobName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入岗位名称");
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
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Jobs);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt) && !listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("您没有此模块的新增或编辑权限，如果需要请联系管理员开放该权限。");
                return ;
            }
            if (!this.SaveCheck())
                return;
            DataTable dt = this.DataSource.Tables["JC_Jobs"];
            DataRow dr;
            dr = dt.NewRow();
            dr["ProcessCode"] = this._ProcessCode;
            string strSql = "SELECT MAX(SortID) FROM JC_Jobs WHERE 1=1";
            if (this._ProcessCode != string.Empty)
                strSql += string.Format(" AND ProcessCode='{0}'", this._ProcessCode.Replace("'", "''"));
            DataTable dtSortID;
            try
            {
                dtSortID = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            int iSortID = dtSortID.Rows[0][0].Equals(DBNull.Value) ? 0 : (int)dtSortID.Rows[0][0];
            iSortID++;
            if (!dr["Code"].Equals(this.tbCode.Text.Trim()))
                dr["Code"] = this.tbCode.Text.Trim();
            if (!dr["JobName"].Equals(this.tbJobName.Text.Trim()))
                dr["JobName"] = this.tbJobName.Text.Trim();
            if (!dr["JobDesc"].Equals(this.tbJobdesc.Text.Trim()))
                dr["JobDesc"] = this.tbJobdesc.Text.Trim();
            if (!dr["IsDefault"].Equals(this.chkDefault.Checked))
                dr["IsDefault"] = this.chkDefault.Checked;
            if (!dr["SortID"].Equals(iSortID))
                dr["SortID"] = iSortID;
            if (!dr["SFGLenRate"].Equals(numSFGLenRate.BindValue))
                dr["SFGLenRate"] = numSFGLenRate.BindValue;
            dt.Rows.Add(dr);
            try
            {
                this.BllDAL.SaveJobs(dt);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.tbCode.Text = string.Empty;
            this.tbJobName.Text = string.Empty;
            this.tbJobdesc.Text = string.Empty;
            this.numSFGLenRate.Clear();
            this.BindData();
            BindNewCode();
        }
        #endregion
        #region 工具条按钮事件

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Jobs);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt) && !listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("您没有此模块的新增或编辑权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            bool blUpdate = false;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                frmJobEdit frm = new frmJobEdit();
                if (this._ProcessName != string.Empty)
                    frm.Text = this._ProcessName + "岗位编辑";
                frm.PrimaryValue = this.DataSource.Tables["JC_Jobs"].DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                if (DialogResult.OK == frm.ShowDialog(this))
                    blUpdate = true;
            }
            //如果用户修改过数据，则需要重新加载
            if (blUpdate)
                this.BindData();
        }

        private void tsbUp_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Jobs);
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
                this.BllDAL.SaveJobs(dt);
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

        private void tsbDown_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Jobs);
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
                this.BllDAL.SaveJobs(dt);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindData();
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Jobs);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("您没有删除计量单位模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的岗位吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            string strMsg;
            int iReturnValue;
            string strCode;
            try
            {
                for (int i = this.dgvList.SelectedRows.Count; i > 0; i--)
                {
                    strCode = dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["Code"].ToString();
                    this.BllDAL.DelJob(strCode, out strMsg, out iReturnValue);
                    if (iReturnValue != 1)
                    {
                        if (strMsg == "") strMsg = "岗位" + strCode + "删除失败。";
                        this.ShowMsg(strMsg);
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindData();
        }
        //列表双击事件
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            frmJobEdit frm = new frmJobEdit();
            if (this._ProcessName != string.Empty)
                frm.Text = this._ProcessName + "岗位编辑";
            frm.PrimaryValue = dt.DefaultView[e.RowIndex].Row["Code"].ToString();
            if (DialogResult.OK == frm.ShowDialog(this))
                this.BindData();
        }
        #endregion
        #region 窗体加载事件
        private void frmUnits_Load(object sender, EventArgs e)
        {
            if (!this.PerInit())
                return;
            this.BindData();
        }
        #endregion

    }
}