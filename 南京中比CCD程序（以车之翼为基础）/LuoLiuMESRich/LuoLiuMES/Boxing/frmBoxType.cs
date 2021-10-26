using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;


namespace LuoLiuMES.Boxing
{
    public partial class frmBoxType : frmBase
    {
        public frmBoxType()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.BoxType _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.BoxType BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.BoxType();
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
            ClearFormData();
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
            string strSql= "SELECT * FROM JC_BoxType";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_BoxType", true));
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
            ds.Tables["JC_BoxType"].Columns.Add(dc);
            this.tbCode.Text = this.GetAutoCode(Common.MyEnums.Modules.BoxType);
            this.dgvList.DataSource = ds.Tables["JC_BoxType"];
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
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.BoxType);
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
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_BoxType WHERE Code='{0}'", this.tbCode.Text.Replace("'", "''")));
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
            DataTable dt = dsSource.Tables["JC_BoxType"];
            DataRow dr;
            dr = dt.NewRow();
            if (dr["Code"].ToString() != this.tbCode.Text)
                dr["Code"] = this.tbCode.Text;
            if (dr["TypeName"].ToString() != this.tbTypeName.Text)
                dr["TypeName"] = this.tbTypeName.Text;
            if(this.tbQty.Text.Length>0)
            {
                int iQty;
                if (!int.TryParse(this.tbQty.Text, out iQty))
                {
                    this.ShowMsg("请正确输入成品数量。");
                    return ;
                }
                if (dr["Qty"].ToString() != iQty.ToString())
                    dr["Qty"] = iQty;
            }
            if (this.tbMyWeight.Text.Length > 0)
            {
                decimal decMyWeight;
                if (!decimal.TryParse(this.tbMyWeight.Text, out decMyWeight))
                {
                    this.ShowMsg("请正确输入托盘的重量。");
                    return;
                }
                if (!dr["MyWeight"].Equals(decMyWeight))
                    dr["MyWeight"] = decMyWeight;
            }
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
            ClearFormData();
            this.BindData();
        }
        private void ClearFormData()
        {
            this.tbCode.Text = this.GetAutoCode(Common.MyEnums.Modules.BoxType);
            this.tbTypeName.Clear();
            this.tbQty.Clear();
            this.tbMyWeight.Clear();
        }
        #endregion
        #region 工具条按钮事件
        //编辑按钮
        private void nvbtEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void nvbtRemove_Click(object sender, EventArgs e)
        {
           
        }
        //列表双击事件
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.BoxType);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有此模块的新增或编辑权限，如果需要请联系管理员开放该权限。");
                return;
            }
            frmBoxTypeEdit frm = new frmBoxTypeEdit();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.BoxType);
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
                frmBoxTypeEdit frm = new frmBoxTypeEdit();
                frm.FormState = Common.MyEnums.FormStates.Edit;
                frm.PrimaryValue = this.DataSource.Tables["JC_BoxType"].DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
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
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.BoxType);
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
                            strMsg = "托盘\"" + strCode + "\"删除失败，原因未知。";
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