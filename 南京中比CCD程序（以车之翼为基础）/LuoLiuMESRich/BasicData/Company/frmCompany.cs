using Common;
using Common.MyEnums;
using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicData.Company
{
    public partial class frmCompany : frmBase
    {
        public frmCompany()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.MyCompany _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.MyCompany BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.MyCompany();
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
            List<CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM V_JC_Company Order by IsDefault DESC,CNName ASC";
            listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "JC_Company", true));
            try
            {
                ds = CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = ds.Tables["JC_Company"];
            DataRow dr;
            dr = dt.NewRow();
            this.dgvList.DataSource = ds.Tables["JC_Company"];
            this.tbCode.Text = this.GetAutoCode(Common.MyEnums.Modules.MyCompany);
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
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MyCompany);
            if (!listPower.Contains(OperatePower.New))
            {
                this.ShowMsg("您没有新增公司抬头模块权限，如果需要请联系管理员开放该权限。");
                return false;
            }
            if (this.tbCNName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入中文名称");
                this.tbCNName.Focus();
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
        #region 新增公司抬头
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck())
                return;
            DataTable dt = this.DataSource.Tables["JC_Company"];
            DataRow dr;
            dr = dt.NewRow();
            if (!dr["Code"].Equals(this.tbCode.Text.Trim()))
                dr["Code"] = this.tbCode.Text.Trim();
            if (!dr["CNName"].Equals(this.tbCNName.Text.Trim()))
                dr["CNName"] = this.tbCNName.Text.Trim();
            if (!dr["VirCode"].Equals(this.tbVirCode.Text.Trim()))
                dr["VirCode"] = this.tbVirCode.Text.Trim();
            if (!dr["ENName"].Equals(this.tbENName.Text.Trim()))
                dr["ENName"] = this.tbENName.Text.Trim();
            if (!dr["ShortName"].Equals(this.tbShortName.Text.Trim()))
                dr["ShortName"] = this.tbShortName.Text.Trim();
            if (!dr["Faxs"].Equals(this.tbFaxs.Text.Trim()))
                dr["Faxs"] = this.tbFaxs.Text.Trim();
            if (!dr["Tels"].Equals(this.tbTels.Text.Trim()))
                dr["Tels"] = this.tbTels.Text.Trim();
            if (!dr["Address"].Equals(this.tbAddress.Text.Trim()))
                dr["Address"] = this.tbAddress.Text.Trim();
            if (!dr["Postal"].Equals(this.tbPostal.Text.Trim()))
                dr["Postal"] = this.tbPostal.Text.Trim();
            if (!dr["Remark"].Equals(this.tbRemark.Text.Trim()))
                dr["Remark"] = this.tbRemark.Text.Trim();
            if ((!dr["IsDefault"].Equals(DBNull.Value) && (bool)dr["IsDefault"]) ^ this.ChkIsDefault.Checked)
                dr["IsDefault"] = this.ChkIsDefault.Checked;
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
            this.tbShortName.Text = string.Empty;
            this.tbFaxs.Text = string.Empty;
            this.tbTels.Text = string.Empty;
            this.tbPostal.Text = string.Empty;
            this.tbRemark.Text = string.Empty;
            this.tbAddress.Text = string.Empty;
            this.tbVirCode.Text = string.Empty;
            this.BindData();
        }
        #endregion
        #region 窗体工具按钮
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.None);
            if (!listPower.Contains(OperatePower.Eidt))
            {
                this.ShowMsg("您没有编辑公司抬头模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            string iID;
            bool blUpdate = false;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                iID = this.DataSource.Tables["JC_Company"].DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                if (iID == null || iID.Length < 0) continue;
                frmCompanyEdit frm = new frmCompanyEdit();
                frm.PrimaryValue = iID;
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
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.None);
            if (!listPower.Contains(OperatePower.Delete))
            {
                this.ShowMsg("您没有删除公司抬头模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要移除选中的公司抬头吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            string iID = dt.DefaultView[e.RowIndex].Row["Code"].ToString();
            if (iID.Length < 0) return;
            frmCompanyEdit frm = new frmCompanyEdit();
            frm.PrimaryValue = iID;
            if (DialogResult.OK == frm.ShowDialog(this))
                this.BindData();

        }
        #endregion
        #region 窗体加载事件
        private void frmCompany_Load(object sender, EventArgs e)
        {
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.None);
            if (listPower.Count == 0)
            {
                this.ShowMsg("你没有公司抬头模块的任何权限，如有需要请联系管理员开放相应权限！");
                this.FormColse();
                return;
            }
            if (!this.PerInit())
                return;
            this.BindData();
        }
        #endregion

        
    }
}
