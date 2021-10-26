using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;

namespace BasicData.PackTypeCode
{
    public partial class frmPackTypeCode : frmBase
    {
        public frmPackTypeCode()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.PackTypeCode _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.PackTypeCode BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.PackTypeCode();
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
            this.tbCode.Text = this.GetAutoCode(Common.MyEnums.Modules.PackTypeCode);
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
            string strSql="SELECT * FROM JC_PackTypeCode Order by Code ASC";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_PackTypeCode", true));
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
            ds.Tables["JC_PackTypeCode"].Columns.Add(dc);
            this.dgvList.DataSource = ds.Tables["JC_PackTypeCode"];
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
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PackTypeCode);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("您没有此模块新增权限，如果需要请联系管理员开放该权限。");
                return false;
            }
            if (this.tbCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入系统编码！");
                return false;
            }
            //判断单位是否已经存在
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_PackTypeCode WHERE Code='{0}'", this.tbCode.Text.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count > 0)
            {
                this.ShowMsg("系统编码“" + this.tbCode.Text + "”已经存在，请更换");
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
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，请重新打开窗体。");
                return;
            }
            if (!this.SaveCheck())
                return;
            DataSet dsSource = this.DataSource.Copy();
            DataTable dt = dsSource.Tables["JC_PackTypeCode"];
            DataRow dr;
            dr = dt.NewRow();
            if (dr["Code"].ToString() != this.tbCode.Text)
                dr["Code"] = this.tbCode.Text;
            if (dr["CodeName"].ToString() != this.tbCodeName.Text)
                dr["CodeName"] = this.tbCodeName.Text;
            if (dr["AnotherName"].ToString() != this.tbAnother.Text)
                dr["AnotherName"] = this.tbAnother.Text;
            if (dr["Remark"].ToString() != this.tbRemark.Text)
                dr["Remark"] = this.tbRemark.Text;
            dt.Rows.Add(dr);
            try
            {
                this.BllDAL.Save(dsSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            //清除数据
            this.tbCode.Text = this.GetAutoCode(Common.MyEnums.Modules.PackTypeCode);
            this.tbCodeName.Clear();
            this.tbAnother.Clear();
            this.tbRemark.Clear();
            this.BindData();
        }
        #endregion
        #region 工具条按钮事件
        //编辑按钮
        private void nvbtEdit_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PackTypeCode);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有此模块的新增或编辑权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            bool blUpdate = false;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                frmPackTypeCodeEdit frm = new frmPackTypeCodeEdit();
                frm.FormState = Common.MyEnums.FormStates.Edit;
                frm.PrimaryValue = this.DataSource.Tables["JC_PackTypeCode"].DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                if (DialogResult.OK == frm.ShowDialog(this))
                    blUpdate = true;
            }
            //如果用户修改过数据，则需要重新加载
            if (blUpdate)
                this.BindData();
        }

        private void nvbtRemove_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PackTypeCode);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("您没有此模块的删除权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的数据吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            int iReturnValue;
            string strMsg;
            string strCode;
            try
            {
                for (int i = this.dgvList.SelectedRows.Count; i > 0; i--)
                {
                    strCode=dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["Code"].ToString();
                    this.BllDAL.Delete(strCode, out iReturnValue,out strMsg);
                    if (iReturnValue != 1)
                    {
                        if (strMsg == string.Empty)
                            strMsg = "系统编码\"" + strCode + "\"删除失败，原因未知。";
                        this.ShowMsg(strMsg);
                        break;
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
            if (e.ColumnIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PackTypeCode);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有此模块的新增或编辑权限，如果需要请联系管理员开放该权限。");
                return;
            }
            frmPackTypeCodeEdit frm = new frmPackTypeCodeEdit();
            frm.PrimaryValue = dt.DefaultView[e.RowIndex].Row["Code"].ToString();
            frm.FormState = Common.MyEnums.FormStates.Edit;
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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PackTypeCode);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有此模块的新增或编辑权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            bool blUpdate = false;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                frmPackTypeCodeEdit frm = new frmPackTypeCodeEdit();
                frm.FormState = Common.MyEnums.FormStates.Edit;
                frm.PrimaryValue = this.DataSource.Tables["JC_PackTypeCode"].DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
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
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PackTypeCode);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("您没有此模块的删除权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的数据吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            int iReturnValue;
            string strMsg;
            string strCode;
            try
            {
                for (int i = this.dgvList.SelectedRows.Count; i > 0; i--)
                {
                    strCode = dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["Code"].ToString();
                    this.BllDAL.Delete(strCode, out iReturnValue, out strMsg);
                    if (iReturnValue != 1)
                    {
                        if (strMsg == string.Empty)
                            strMsg = "系统编码\"" + strCode + "\"删除失败，原因未知。";
                        this.ShowMsg(strMsg);
                        break;
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
    }
}