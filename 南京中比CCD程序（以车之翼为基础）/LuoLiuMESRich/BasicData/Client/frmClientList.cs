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

namespace BasicData.Client
{
    public partial class frmClientList : frmBase
    {
        public frmClientList()
        {
            InitializeComponent();
        }
        #region 处理函数
        private bool BindData()
        {
            string strSql = "SELECT * FROM V_JC_Client WHERE 1=1";
            //模糊搜索
            string strFilter = this.GetFiterSql();
            if (!String.IsNullOrEmpty(strFilter))
                strSql += " AND " + strFilter;
            strSql += " ORDER BY CNName ASC";//以倒序排列
            DataTable dt = null;
            try
            {
                dt = CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = dt;
            return true;
        }
        private string GetFiterSql()
        {
            if (this.tbSearchValue.Text.Trim().Length == 0)
                return string.Empty;
            if (this.btSchBy_0.Text == "客户简称")
                return " ShortName LIKE '%" + this.tbSearchValue.Text.Trim().Replace("'", "''") + "%'";
            else if (this.btSchBy_0.Text == "客户全称")
                return " CNName LIKE '%" + this.tbSearchValue.Text.Trim().Replace("'", "''") + "%'";
            else if (this.btSchBy_0.Text == "客户英文名")
                return " ENName LIKE '%" + this.tbSearchValue.Text.Trim().Replace("'", "''") + "%'";
            else if (this.btSchBy_0.Text == "所属国家")
                return " Country LIKE '%" + this.tbSearchValue.Text.Trim().Replace("'", "''") + "%'";
            else if (this.btSchBy_0.Text == "所在省份")
                return " Province LIKE '%" + this.tbSearchValue.Text.Trim().Replace("'", "''") + "%'";
            else if (this.btSchBy_0.Text == "详细地址")
                return " Address LIKE '%" + this.tbSearchValue.Text.Trim().Replace("'", "''") + "%'";
            else if (this.btSchBy_0.Text == "联系电话")
                return " Tels LIKE '%" + this.tbSearchValue.Text.Trim().Replace("'", "''") + "%'";
            else if (this.btSchBy_0.Text == "联系人")
                return " Contacters LIKE '%" + this.tbSearchValue.Text.Trim().Replace("'", "''") + "%'";
            else if (this.btSchBy_0.Text == "传真")
                return " Fax LIKE '%" + this.tbSearchValue.Text.Trim().Replace("'", "''") + "%'";
            else if (this.btSchBy_0.Text == "备注")
                return " Remark LIKE '%" + this.tbSearchValue.Text.Trim().Replace("'", "''") + "%'";
            return string.Empty;
        }
        private bool PerInit()
        {
            //设置搜索条件
            this.btSchBy_0.Text = "客户全称";
            this.btSchBy_0.Items.Clear();
            this.btSchBy_0.Items.Add("客户简称");
            this.btSchBy_0.Items.Add("客户英文名");
            this.btSchBy_0.Items.Add("所属国家");
            this.btSchBy_0.Items.Add("所在省份");
            this.btSchBy_0.Items.Add("详细地址");
            this.btSchBy_0.Items.Add("联系电话");
            this.btSchBy_0.Items.Add("联系人");
            this.btSchBy_0.Items.Add("传真");
            this.btSchBy_0.Items.Add("备注");
            this.dgvList.AutoGenerateColumns = false;
            return true;
        }
        public override bool RefreshParetForm(object objArg)
        {
            return this.BindData();
        }
        #endregion
        #region 窗体加载
        private void frmClientList_Load(object sender, EventArgs e)
        {
            // 先校验权限
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Client);
            if (listPower.Count == 0)
            {
                this.ShowMsg("你没有权限查看此模块，窗口将自动关闭！");
                this.FormColse();
                return;
            }
            //预加载项
            if (!this.PerInit())
                return;
            //开始加载数据
            if (!this.BindData())
                return;
        }
        #endregion
        #region 工具栏
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //开始加载数据
            if (!this.BindData())
                return;
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            //先校验权限
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Client);
            if (!listPower.Contains(OperatePower.New))
            {
                this.ShowMsg("你没有新建供应商的权限，如有需要请联系管理员开放该权限！");
                return;
            }
            frmClient frm = new frmClient();
            frm.FormParent = this;
            frm.FormState = FormStates.New;
            frm.Text = "新建供应商";
            this.ShowChildForm("新建供应商", frm);
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strCode;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                if (strCode == string.Empty) continue;
                frmClient frm = new frmClient();
                frm.FormParent = this;
                //校验权限
                List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Client, strCode);
                if (listPower.Count == 0)
                {
                    this.ShowMsg(string.Format("您没有权限打开客户“{0}”，因为你没有它的任何权限！", strCode));
                    continue;
                }
                if (listPower.Contains(OperatePower.Eidt))
                {
                    frm.FormState = FormStates.Edit;
                    frm.Text = "客户" + strCode;
                    frm.PrimaryValue = strCode;
                    this.ShowChildForm(frm.Text, frm);
                }
                else
                {
                    frm.FormState = FormStates.Readonly;
                    frm.Text = string.Format("客户{0}（只读）", strCode);
                    frm.PrimaryValue = strCode;
                    this.ShowChildForm(frm.Text, frm);
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (this.dgvList.SelectedRows.Count == 0 || DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的" + this.dgvList.SelectedRows.Count.ToString() + "条数据吗？此操作数据将不可恢复，确定要继续吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            string strCode;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Client, strCode);
                if (!listPower.Contains(OperatePower.Delete))
                {
                    this.ShowMsg(string.Format("您没有权限删除供应商“{0}”！", strCode));
                    continue;
                }
                /* try
                 {
                     BasicData.BLLDAL.Supplier.Delete(strCode);
                 }
                 catch (Exception ex)
                 {
                     wErrorMessage.ShowErrorDialog(this, ex);
                     return;
                 }*/
            }
            this.BindData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strPlanCode;
            DataTable dt = this.dgvList.DataSource as DataTable;
            strPlanCode = dt.DefaultView[e.RowIndex].Row["Code"].ToString();
            frmClient frm = new frmClient();
            frm.FormParent = this;
            //校验权限
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Client, strPlanCode);
            if (listPower.Count == 0)
            {
                this.ShowMsg(string.Format("您没有权限打开客户“{0}”，因为你没有它的任何权限！", strPlanCode));
                return;
            }
            if (listPower.Contains(OperatePower.Eidt))
            {
                frm.FormState = FormStates.Edit;
                frm.Text = "客户" + strPlanCode;
                frm.PrimaryValue = strPlanCode;
                this.ShowChildForm(frm.Text, frm);
            }
            else
            {
                frm.FormState = FormStates.Readonly;
                frm.Text = string.Format("客户{0}（只读）", strPlanCode);
                frm.PrimaryValue = strPlanCode;
                this.ShowChildForm(frm.Text, frm);
            }
        }
        #endregion
    }
}
