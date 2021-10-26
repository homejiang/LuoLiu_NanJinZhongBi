using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ErrorService;
using Common;
using Common.MyEnums;
using Common.MyEntity;

namespace BasicData.Material
{
    public partial class frmMaterialList : frmBaseList
    {
        public frmMaterialList()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.MaterialClass _dal = null;
        /// <summary>
        /// 窗体数据连接大类物料实例
        /// </summary>
        private BLLDAL.MaterialClass BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.MaterialClass();
                return _dal;
            }
        }

        private BLLDAL.Material _dal1 = null;
        /// <summary>
        /// 窗体数据连接物料实例
        /// </summary>
        private BLLDAL.Material BllDAL1 
        {
            get
            {
                if (_dal1 == null)
                    _dal1 = new BasicData.BLLDAL.Material();
                return _dal1;
            }
        }
        #endregion
        #region 处理函数
        private bool BindMaterialClass()
        {
            string strSql = "SELECT * FROM JC_MaterialClass ORDER BY SortID";
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
            this.tvClass.Nodes.Clear();
            TreeNode tnParent=new TreeNode();
            tnParent.Text="所有原材料";
            tnParent.Tag = null;
            this.tvClass.Nodes.Add(tnParent);
            foreach (DataRow dr in dt.Select("ISNULL(ParentCode,'')=''"))
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["ClassName"].ToString();
                tn.Tag = dr["Code"].ToString();
                tnParent.Nodes.Add(tn);
                BindMaterialClass(tn, dr["Code"].ToString(), dt);
            }
            tnParent.ExpandAll();
            return true;
        }
        private void BindMaterialClass(TreeNode tn, string sCode, DataTable dtSource)
        {
            DataRow[] drs = dtSource.Select("ParentCode='" + sCode + "'");
            foreach (DataRow dr in drs)
            {
                TreeNode tnNew = new TreeNode();
                tnNew.Text = dr["ClassName"].ToString();
                tnNew.Tag = dr["Code"].ToString();
                tn.Nodes.Add(tnNew);
                this.BindMaterialClass(tnNew, dr["Code"].ToString(), dtSource);
            }
        }
        private bool BindMaterial()
        {
            string strSql = "SELECT * FROM [V_JC_Materia_List] WHERE 1=1";
            TreeNode tn = this.tvClass.SelectedNode;
            if (tn != null && tn.Tag != null && tn.Tag.ToString().Length > 0)
            {
                //选中了节点，需要过滤类别
                StringBuilder sbCodes = new StringBuilder();
                sbCodes.Append("|");
                sbCodes.Append(tn.Tag.ToString());
                sbCodes.Append("|");
                this.GetClaCodes(sbCodes, tn);
                string strClaCodes = sbCodes.ToString();
                if (!strClaCodes.EndsWith("|"))
                    strClaCodes += "|";
                strSql += string.Format(" AND CHARINDEX('|'+ClassCode+'|','{0}')>0", strClaCodes.Replace("'", "''"));
            }
            if (this.tstName.Text != string.Empty)
                strSql += string.Format(" AND ( CNName like '%{0}%' or ENName like '%{0}%')", this.tstName.Text.Replace("'", "''"));
            if (this.tstSpec.Text != string.Empty)
                strSql += string.Format(" AND Specs like '%{0}%'", this.tstSpec.Text.Replace("'", "''"));
            strSql += " ORDER BY ClassName ASC";//以倒序排列
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
        private void GetClaCodes(StringBuilder sbCodes,TreeNode tn)
        {
            foreach (TreeNode tnChild in tn.Nodes)
            {
                if (tnChild.Tag != null && tnChild.Tag.ToString().Length > 0)
                {
                    sbCodes.Append(tnChild.Tag.ToString());
                    sbCodes.Append("|");
                }
                GetClaCodes(sbCodes, tnChild);
            }
        }
        private bool PerInit()
        {
            this.dgvList.AutoGenerateColumns = false;
            #region 设置combox回车事件
            this.SetBarSearchEnterKey(this.tstName);
            this.SetBarSearchEnterKey(this.tstSpec);
            #endregion
            return true;
        }
        #endregion
        #region  重写父类函数
        public override bool RefreshParetForm(object objArg)
        {
            return this.BindMaterial();
        }
        public override void DoBarSearch()
        {
            this.tsbSearch_Click(null, null);
        }
        #endregion
        #region 窗体控件事件
        
        //新建
        private void btNew_Click(object sender, EventArgs e)
        {
            //先校验权限
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Material);
            if (!listPower.Contains(OperatePower.New))
            {
                this.ShowMsg("你没有新建原材料的权限，如有需要请联系管理员开放该权限！");
                return;
            }
            frmMaterial frm = new frmMaterial();
            frm.FormParent = this;
            frm.FormState = FormStates.New;
            //获取选中的类别
            if (this.tvClass.SelectedNode != null && this.tvClass.SelectedNode.Tag != null && this.tvClass.SelectedNode.Tag.ToString().Length > 0)
            {
                frm.DefaultClassCode = this.tvClass.SelectedNode.Tag.ToString();
            }
            this.ShowChildForm(frm.Text, frm);
        }
        //打开
        private void btOpen_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Material);
            if (listPower.Count == 0)
            {
                this.ShowMsg(string.Format("您没有权限打开，因为你没有此模块的任何权限！"));
                return;
            }
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                OpenEditForm(this.dgvList.SelectedRows[i].Index, listPower);
            }
        }
        private void OpenEditForm(int iRow, List<OperatePower> listPower)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strCode = dt.DefaultView[iRow].Row["MaterialCode"].ToString();
            if (strCode == string.Empty) return;
            frmMaterial frm = new frmMaterial();
            frm.FormParent = this;
            //校验权限
            if (listPower.Contains(OperatePower.Eidt) || listPower.Contains(OperatePower.New))
            {
                frm.FormState = FormStates.Edit;
            }
            else
            {
                frm.FormState = FormStates.Readonly;
            }
            frm.PrimaryValue = strCode;
            this.ShowChildForm(frm.Text, frm);
        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0 || DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的" + this.dgvList.SelectedRows.Count.ToString() + "条数据吗？此操作数据将不可恢复，确定要继续吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strMaterialCode;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strMaterialCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["MaterialCode"].ToString();
                List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Material, strMaterialCode);
                if (!listPower.Contains(OperatePower.Delete))
                {
                    this.ShowMsg(string.Format("您没有权限删除原材料“{0}”！", strMaterialCode));
                    continue;
                }
                //删除物料信息
                int iReturn;
                string sMsg;
                try
                {
                    this.BllDAL1.Detele(strMaterialCode, out sMsg, out iReturn);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturn != 1)
                {
                    if (sMsg.Length == 0)
                        sMsg = "删除不成功，但原因未明确，您可以联系管理员查明原因。";
                    this.ShowMsg(sMsg);
                    return;
                }
            }
            this.BindMaterial();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            BindMaterial();
        }
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strMaterialCode;
            //校验权限
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Material);
            if (listPower.Count == 0)
            {
                this.ShowMsg(string.Format("您没有权限打开，因为你没有此模块的任何权限！"));
                return;
            }
            this.OpenEditForm(e.RowIndex, listPower);
        }
        #endregion
        #region 物料类别按钮事件

        private void NvbtClassRemove_Click(object sender, EventArgs e)
        {
            //判断权限
            List<OperatePower> listPower = this.GetOperatePower( Common.MyEnums.Modules.MaterialClass);
            if (!listPower.Contains(OperatePower.Delete))
            {
                this.ShowMsg("你没有删除类别的权限，如有需要请联系管理员开放该权限！");
                return;
            }
            TreeNode tn = this.tvClass.SelectedNode;
            if (tn == null || tn.Tag == null || tn.Tag.ToString().Length == 0) return;
            if (tn.Nodes.Count > 0)
            {
                this.ShowMsg("该类别下还包含子类别，请先移除这些子类别后再删除该类别。");
                return;
            }
            DataTable dtMaterial = null;
            try
            {
                dtMaterial = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT COUNT(*) FROM JC_Material WHERE ClassCode='{0}'", tn.Tag.ToString().Replace("'", "''")));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this,ex);
                return;
            }
            if ((int)dtMaterial.Rows[0][0] > 0)
            {
                this.ShowMsg("您选中的类别下还包含原材料，不能删除此类别。");
                return;
            }
            if (!this.IsUserConfirm("您确定要移除选中的物料类别")) return;
            try
            {
                this.BllDAL.Detele(tn.Tag.ToString());
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindMaterialClass();
        }

        private void NvbtClassAdd_Click(object sender, EventArgs e)
        {
            //判断权限
            List<OperatePower> listPower = this.GetOperatePower( Common.MyEnums.Modules.MaterialClass);
            if (!listPower.Contains(OperatePower.New))
            {
                this.ShowMsg("你没有新类别的权限，如有需要请联系管理员开放该权限！");
                return;
            }
            frmMaterialClass frm = new frmMaterialClass();
            
            TreeNode tn = this.tvClass.SelectedNode;
            if (tn != null && tn.Tag != null && tn.Tag.ToString().Length > 0)
                frm.ParentClassCode = tn.Tag.ToString();
            frm.FormState = FormStates.New;
            if (DialogResult.OK == frm.ShowDialog(this) || frm.IsUpdated)
            {
                //此时需要更新列表
                this.BindMaterialClass();
            }
        }

        private void nvbtClassEdit_Click(object sender, EventArgs e)
        {
            //判断权限
            List<OperatePower> listPower = this.GetOperatePower( Common.MyEnums.Modules.MaterialClass);
            if (!listPower.Contains(OperatePower.Eidt))
            {
                this.ShowMsg("你没有编辑类别的权限，如有需要请联系管理员开放该权限！");
                return;
            }
            TreeNode tn = this.tvClass.SelectedNode;
            if (tn == null || tn.Tag == null || tn.Tag.ToString().Length == 0) return;
            string strCode;
            strCode = tn.Tag.ToString();
            frmMaterialClass frm = new frmMaterialClass();
            frm.PrimaryValue = strCode;
            frm.FormState = FormStates.Edit;
            if (DialogResult.OK == frm.ShowDialog(this) || frm.IsUpdated)
            {
                //此时需要更新列表
                this.BindMaterialClass();
            }
        }

        private void NvbtClassDown_Click(object sender, EventArgs e)
        {
            //判断权限
            List<OperatePower> listPower = this.GetOperatePower( Common.MyEnums.Modules.MaterialClass);
            if (!listPower.Contains(OperatePower.Eidt))
            {
                this.ShowMsg("你没有编辑类别的权限，如有需要请联系管理员开放该权限！");
                return;
            }
            TreeNode tnSel = this.tvClass.SelectedNode;
            if (tnSel == null || tnSel.Tag == null || tnSel.Tag.ToString().Length == 0) return;
            string strCode = tnSel.Tag.ToString();
            int iReturnValue;
            string strError;
            try
            {
               this.BllDAL.MoveDownOrUp(strCode, 1, out iReturnValue, out strError);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (String.IsNullOrEmpty(strError))
                    strError = "操作失败！";
                this.ShowMsg(strError);
                return;
            }
            this.BindMaterialClass();
            
        }
        private void NvbtClassUp_Click(object sender, EventArgs e)
        {
            //判断权限
            List<OperatePower> listPower = this.GetOperatePower( Common.MyEnums.Modules.MaterialClass);
            if (!listPower.Contains(OperatePower.Eidt))
            {
                this.ShowMsg("你没有编辑类别的权限，如有需要请联系管理员开放该权限！");
                return;
            }
            TreeNode tn = this.tvClass.SelectedNode;
            if (tn == null || tn.Tag == null || tn.Tag.ToString().Length == 0) return;
            string strCode;
            strCode = this.tvClass.SelectedNode.Tag.ToString();
            int iReturnValue;
            string strError;
            try
            {
                this.BllDAL.MoveDownOrUp(strCode, -1, out iReturnValue, out strError);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (String.IsNullOrEmpty(strError))
                    strError = "操作失败！";
                this.ShowMsg(strError);
                return;
            }
            this.BindMaterialClass();
        }

        private void tvClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.BindMaterial();
        }

        #endregion
        #region 窗体事件
        private void frmMaterialList_Load(object sender, EventArgs e)
        {
            if (!this.PerInit())
                return;
            if (this.BindMaterialClass())
                return;
            if (this.BindMaterial()) return;
        }
        #endregion
    }
}