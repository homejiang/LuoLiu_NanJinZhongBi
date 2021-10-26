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

namespace BasicData.Country
{
    public partial class frmProvince : frmBase
    {
        public frmProvince()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.Country _dal = null;
        /// <summary>
        /// 窗体国家数据连接实例
        /// </summary>
        private BLLDAL.Country BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.Country();
                return _dal;
            }
        }

        private BLLDAL.Province _dal1 = null;
        /// <summary>
        /// 窗体省份数据连接实例
        /// </summary>
        private BLLDAL.Province BllDAL1
        {
            get
            {
                if (_dal1 == null)
                    _dal1 = new BasicData.BLLDAL.Province();
                return _dal1;
            }
        }
        #endregion
        #region 国家操作
        //加载信息
        private bool BindCountry()
        {
            DataTable dt = null;
            try
            {
                dt = CommonDAL.DoSqlCommand.GetDateTable("SELECT Code AS CountryCode,ISNULL(CNName,ENName) AS Country FROM JC_Country order by ISNULL(CNName,ENName)");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //加载根节点
            TreeNode tnParent = new TreeNode();
            tnParent.Text = "所有国家";
            tnParent.Tag = string.Empty;
            this.tvCountry.Nodes.Clear();
            this.tvCountry.Nodes.Add(tnParent);
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tnNew = new TreeNode();
                tnNew.Text = dr["Country"].ToString();
                tnNew.Tag = dr["CountryCode"].ToString();
                tnParent.Nodes.Add(tnNew);
            }
            tnParent.ExpandAll();

            return true;
        }
        #region 按钮事件
        private void NvbtCountryAdd_Click(object sender, EventArgs e)
        {
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Province);
            if (listPower.Count == 0)
            {
                this.ShowMsg("您没有国家模块的任何权限！");
                return;
            }
            if (!listPower.Contains(OperatePower.New))
            {
                this.ShowMsg("您没有新增国家的权限！");
                return;
            }
            frmCountryEdit frm = new frmCountryEdit();
            frm.FormState = FormStates.New;
            if (DialogResult.OK == frm.ShowDialog(this))
            {
                //重新加载国家信息
                this.BindCountry();
            }
        }

        private void nvbtCountryEdit_Click(object sender, EventArgs e)
        {
            if (this.tvCountry.SelectedNode == null) return;
            TreeNode tn = this.tvCountry.SelectedNode;
            if (tn.Tag == null || tn.Tag.ToString().Length == 0) return;
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Province);
            if (listPower.Count == 0)
            {
                this.ShowMsg("您没有国家模块的任何权限！");
                return;
            }
            frmCountryEdit frm = new frmCountryEdit();
            if (!listPower.Contains(OperatePower.Eidt))
                frm.FormState = FormStates.Readonly;
            else
                frm.FormState = FormStates.Edit;
            frm.PrimaryValue = tn.Tag.ToString();
            if (DialogResult.OK == frm.ShowDialog(this))
            {
                //重新加载国家信息
                this.BindCountry();
            }
        }

        private void NvbtCountryRemove_Click(object sender, EventArgs e)
        {
            if (this.tvCountry.SelectedNode == null) return;
            TreeNode tn = this.tvCountry.SelectedNode;
            if (tn.Tag == null || tn.Tag.ToString().Length == 0) return;
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Province, tn.Tag.ToString());
            if (!listPower.Contains(OperatePower.Delete))
            {
                this.ShowMsg("您没有国家模块的删除权限！");
                return;
            }
            try
            {
                this.BllDAL.Detele(tn.Tag.ToString());
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindCountry();
        }
        private void tvCountry_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.BindProvince();
        }
        #endregion
        #endregion
        #region 省份操作
        //加载省份
        private bool BindProvince()
        {
            this.tbCode.Text = this.GetAutoCode(Modules.Province);
            DataSet ds = null;
            List<CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            string strSql;
            if (this.tvCountry.SelectedNode == null || this.tvCountry.SelectedNode.Tag == null || this.tvCountry.SelectedNode.Tag.ToString().Length == 0)
                strSql = "SELECT * FROM V_JC_ProvinceCountry ORDER BY CNName ASC";
            else
                strSql = "SELECT * FROM V_JC_ProvinceCountry WHERE CountryCode='" + this.tvCountry.SelectedNode.Tag.ToString().Replace("'", "''") + "' ORDER BY CNName ASC";
            listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "V_JC_ProvinceCountry", false));


            try
            {
                ds = CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }

            this.DataSource = ds;
            this.dgvList.DataSource = ds.Tables["V_JC_ProvinceCountry"];
            return true;
        }
        private bool SaveCheck()
        {
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Province);
            if (!listPower.Contains(OperatePower.New))
            {
                this.ShowMsg("您没有新增省份的权限！");
                return false;
            }
            if (this.tvCountry.SelectedNode == null || this.tvCountry.SelectedNode.Tag == null || this.tvCountry.SelectedNode.Tag.ToString().Length == 0)
            {
                this.ShowMsg("请在左边国家信息框内选择指定的国家！");
                return false;
            }
            if (this.tbCNName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入中文名称！");
                this.tbCNName.Focus();
                return false;
            }
            //判断是否系统中已经存在编码
            DataTable dt = null;
            if (this.tbCode.Text.Trim().Length > 0)
            {
                try
                {
                    dt = CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_Province WHERE Code='{0}'", this.tbCode.Text.Trim().Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.DefaultView.Count > 0)
                {
                    this.ShowMsg("省份编码“" + this.tbCode.Text.Trim() + "”在系统中已经存在，请更换！");
                    return false;
                }
            }
            //判断是否系统中已经存在中文名称
            try
            {
                dt = CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_Province WHERE CNName='{0}'", this.tbCNName.Text.Trim().Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.DefaultView.Count > 0)
            {
                this.ShowMsg("省份中文名“" + this.tbCNName.Text.Trim() + "”在系统中已经存在，请检查！");
                return false;
            }
            return true;
        }
        private bool Save()
        {
            DataRow drNew = this.DataSource.Tables["V_JC_ProvinceCountry"].NewRow();
            if (this.tbCode.Text.Trim().Length == 0)
                drNew["Code"] = this.GetAutoCode(Common.MyEnums.Modules.Province);
            else
                drNew["Code"] = this.tbCode.Text.Trim();
            drNew["CNName"] = this.tbCNName.Text.Trim();
            drNew["ENName"] = this.tbENName.Text.Trim();
            drNew["CountryCode"] = this.tvCountry.SelectedNode.Tag.ToString();
            this.DataSource.Tables["V_JC_ProvinceCountry"].Rows.Add(drNew);
            try
            {
                this.BllDAL1.Save(this.DataSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            return true;
        }
        #region 控件事件
        private void frmProvince_Load(object sender, EventArgs e)
        {
            this.dgvList.AutoGenerateColumns = false;
            this.BindCountry();
            this.BindProvince();
        }
        private void nvbtEdit_Click(object sender, EventArgs e)
        {
            //检查权限
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Province);
            if (!listPower.Contains(OperatePower.Eidt))
            {
                this.ShowMsg("您没有省份模块的编辑权限！");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                frmProvinceEdit frm = new frmProvinceEdit();
                frm.PrimaryValue = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                frm.FormState = FormStates.Edit;
                if (DialogResult.OK == frm.ShowDialog(this))
                    this.BindProvince();
            }
        }
        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 && e.ColumnIndex < 0) return;
            //检查权限
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Province);
            if (!listPower.Contains(OperatePower.Eidt))
            {
                this.ShowMsg("您没有省份模块的编辑权限！");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            frmProvinceEdit frm = new frmProvinceEdit();
            frm.PrimaryValue = dt.DefaultView[e.RowIndex].Row["Code"].ToString();
            frm.FormState = FormStates.Edit;
            if (DialogResult.OK == frm.ShowDialog(this))
                this.BindProvince();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck()) return;
            if (this.Save())
            {
                this.tbCode.Text = string.Empty;
                this.tbCNName.Text = string.Empty;
                this.tbENName.Text = string.Empty;
                this.BindProvince();
            }
        }
        #endregion

        private void nvbtRemove_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Province);
            if (!listPower.Contains(OperatePower.Delete))
            {
                this.ShowMsg("您没有删除国家省份模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            try
            {
                for (int i = this.dgvList.SelectedRows.Count; i > 0; i--)
                {
                    this.BllDAL1.Detele(dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["Code"].ToString());
                }
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindProvince();
        }


        #endregion
    }
}
