using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES.AutoExe
{
    public partial class frmSysForms : Common.frmBaseEdit
    {
        public frmSysForms()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.AutoExe _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.AutoExe BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new LuoLiuMES.BLLDAL.AutoExe();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        private bool Perinit()
        {
            this.dgvForms.AutoGenerateColumns = false;
            return true;
        }
        private bool BindForm(string sSelectedCodes)
        {
            string strGroup = string.Empty;
            if (this.tvGroup.SelectedNode!=null)
            {
                strGroup = this.tvGroup.SelectedNode.Tag == null ? string.Empty : this.tvGroup.SelectedNode.Tag.ToString();
            }
            if (sSelectedCodes != string.Empty)
                sSelectedCodes = "|" + sSelectedCodes + "|";
            string strSql = "SELECT * FROM V_AutoExe_Sys_Forms WHERE 1=1";
            if (strGroup != string.Empty)
                strSql += string.Format(" AND GroupCode='{0}'", strGroup.Replace("'", "''"));
            if (this.tstSearchValue.Text != string.Empty)
                strSql += string.Format(" AND FormName LIKE '%{0}%'", this.tstSearchValue.Text.Replace("'", "''"));
            strSql += " order by SortID asc";
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvForms.DataSource = dt;
            //设置选中行
            for (int i = 0; i < dt.DefaultView.Count; i++)
            {
                if (sSelectedCodes.IndexOf("|" + dt.DefaultView[i].Row["Code"].ToString() + "|") >= 0)
                    this.dgvForms.Rows[i].Selected = true;
                else
                    this.dgvForms.Rows[i].Selected = false;
            }
            return true;
        }
        private bool BindGroup(string sSelectedCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM AutoExe_Sys_Group"));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataRow[] drs = dt.Select("isnull(PCode,'')=''", "SortID ASC");
            this.tvGroup.Nodes.Clear();
            TreeNode tnRoot = new TreeNode();
            tnRoot.Tag = "";
            tnRoot.Text = "所有窗口组";
            this.tvGroup.Nodes.Add(tnRoot);
            TreeNode tn;
            foreach (DataRow dr in drs)
            {
                tn = new TreeNode();
                tn.Tag = dr["Code"].ToString();
                tn.Text = dr["GroupName"].ToString();
                tnRoot.Nodes.Add(tn);
                if (string.Compare(sSelectedCode, tn.Tag.ToString(), true) == 0)
                    this.tvGroup.SelectedNode = tn;
                BindGroup(dt, tn, sSelectedCode);
            }
            if (this.tvGroup.SelectedNode == null)
                this.tvGroup.SelectedNode = tnRoot;
            this.tvGroup.ExpandAll();
            return true;
        }
        private void BindGroup(DataTable dt, TreeNode tn, string sSelectedCode)
        {
            DataRow[] drs = dt.Select("isnull(PCode,'')='" + tn.Tag.ToString() + "'", "SortID ASC");
            TreeNode tnChild;
            foreach (DataRow dr in drs)
            {
                tnChild = new TreeNode();
                tnChild.Tag = dr["Code"].ToString();
                tnChild.Text = dr["GroupName"].ToString();
                tn.Nodes.Add(tnChild);
                if (string.Compare(sSelectedCode, tnChild.Tag.ToString(), true) == 0)
                    this.tvGroup.SelectedNode = tnChild;
                BindGroup(dt, tnChild, sSelectedCode);
            }
        }
        #endregion
        #region 模块组操作
        //private bool OpenGroupForm(string sCode, string sPCode, bool rebind)
        //{
        //    frmSysGroup frm = new frmSysGroup();
        //    frm._PCode = sPCode;
        //    frm.PrimaryValue = sCode;
        //    if (DialogResult.OK != frm.ShowDialog(this))
        //        return false;
        //    if (rebind)
        //        return this.BindGroup(sCode);
        //    return true;
        //}
        private void tsb1Add_Click(object sender, EventArgs e)
        {
            string strPCode = string.Empty;
            TreeNode tn = this.tvGroup.SelectedNode;
            if (tn != null && tn.Tag != null)
                strPCode = tn.Tag.ToString();
            frmSysGroup frm = new frmSysGroup();
            frm._PCode = strPCode;
            frm.PrimaryValue = string.Empty;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            TreeNode tnNew = new TreeNode();
            tnNew.Tag = frm.GroupCode;
            tnNew.Text = frm.GroupName;
            tn.Nodes.Add(tnNew);
        }

        private void tsb1Edit_Click(object sender, EventArgs e)
        {
            string strCode = string.Empty;
            TreeNode tn = this.tvGroup.SelectedNode;
            if (tn != null && tn.Tag != null)
                strCode = tn.Tag.ToString();
            if (strCode == string.Empty)
            {
                this.ShowMsg("请选中您要编辑的节点。");
                return;
            }
            frmSysGroup frm = new frmSysGroup();
            frm._PCode = string.Empty;//编辑不需要传入父级代码
            frm.PrimaryValue = strCode;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            tn.Tag = frm.GroupCode;
            tn.Text = frm.GroupName;
            //OpenGroupForm(strCode, string.Empty);
        }

        private void tsb1Remove_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.tvGroup.SelectedNode;
            if (tn == null) return;
            string strGroup = tn.Tag == null ? string.Empty : tn.Tag.ToString();
            if (strGroup == string.Empty) return;
            if (!this.IsUserConfirm("您确定要移除选中的组吗？")) return;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.DelSysGroup(strGroup, out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg == string.Empty)
                    strMsg = "操作失败，原因未知！";
                this.ShowMsg(strMsg);
                return;
            }
            //移除选中节点
            TreeNode tnP = tn.Parent;
            if (tnP != null)
                tnP.Nodes.Remove(tn);
            else this.tvGroup.Nodes.Remove(tn);
            //this.BindGroup(string.Empty);
        }

        private void tsb1Up_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.tvGroup.SelectedNode;
            if (tn == null) return;
            string strGroup = tn.Tag == null ? string.Empty : tn.Tag.ToString();
            if (strGroup == string.Empty) return;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.SysGroupMove(strGroup, (short)1, out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg == string.Empty)
                    strMsg = "操作失败，原因未知！";
                this.ShowMsg(strMsg);
                return;
            }
            this.BindGroup(strGroup);
        }

        private void tsb1Down_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.tvGroup.SelectedNode;
            if (tn == null) return;
            string strGroup = tn.Tag == null ? string.Empty : tn.Tag.ToString();
            if (strGroup == string.Empty) return;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.SysGroupMove(strGroup, (short)2, out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg == string.Empty)
                    strMsg = "操作失败，原因未知！";
                this.ShowMsg(strMsg);
                return;
            }
            this.BindGroup(strGroup);
        }
        #endregion
        #region 窗体工具条操作
        private void tsb2Add_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.tvGroup.SelectedNode;
            string strGroup = string.Empty;
            if (tn != null)
                strGroup = tn.Tag == null ? string.Empty : tn.Tag.ToString();
            if (strGroup == string.Empty)
            {
                this.ShowMsg("请选择组！");
                return;
            }
            frmSysFormEdit frm = new frmSysFormEdit();
            frm.FormState = Common.MyEnums.FormStates.New;
            frm._GroupCode = strGroup;
            frm.PrimaryValue = string.Empty;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            this.BindForm(frm.FormCode);
        }
        #endregion

        private void tsb2Edit_Click(object sender, EventArgs e)
        {
            if (this.dgvForms.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中一行数据。");
                return;
            }
            if (this.dgvForms.SelectedRows.Count >1)
            {
                this.ShowMsg("一次只能编辑一行数据。");
                return;
            }
            DataTable dt = this.dgvForms.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[this.dgvForms.SelectedRows[0].Index].Row;
            frmSysFormEdit frm = new frmSysFormEdit();
            frm.FormState = Common.MyEnums.FormStates.Edit;
            frm.PrimaryValue = dr["Code"].ToString();
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            this.BindForm(dr["Code"].ToString());

        }

        private void tsb2Remove_Click(object sender, EventArgs e)
        {
            if (this.dgvForms.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中一行数据。");
                return;
            }
            DataTable dt = this.dgvForms.DataSource as DataTable;
            if (dt == null) return;
            if (!this.IsUserConfirm("您确定要移除选中的行吗？"))
                return;
            string strCode;
            int iReturnValue;
            string strMsg;
            DataTable dttemp;
            for (int i = 0; i < this.dgvForms.SelectedRows.Count; i++)
            {
                strCode = dt.DefaultView[this.dgvForms.SelectedRows[i].Index].Row["Code"].ToString();
                try
                {
                    dttemp = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT COUNT(*) FROM AutoExe_User_Forms WHERE FormCode='{0}'"
                        , strCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if ((int)dttemp.Rows[0][0] > 0)
                {
                    if (!this.IsUserConfirm("模块\"" + dt.DefaultView[this.dgvForms.SelectedRows[i].Index].Row["FormName"].ToString() + "\"已经被用户引用过，您确定要移除吗？\r\n如果移除，用户方案中也将同步移除此模块。")) return;
                }
                try
                {
                    this.BllDAL.DelSysForm(strCode, out strMsg, out iReturnValue);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    continue;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg == "") strMsg = "窗体\"" + strCode + "\"移除失败，原因未知。";
                    this.ShowMsg(strMsg);
                    continue;
                }
            }
            this.BindForm(string.Empty);
        }

        private void tsb2Up_Click(object sender, EventArgs e)
        {
            if (this.dgvForms.SelectedRows.Count == 0)
            {
                this.ShowMsg("请至少选中一行数据。");
                return;
            }
            DataTable dt = this.dgvForms.DataSource as DataTable;
            if (dt == null) return;
            string strCode;
            int iReturnValue;
            string strMsg;
            string strCodes = string.Empty;
            for (int i = 0; i < this.dgvForms.SelectedRows.Count; i++)
            {
                strCode = dt.DefaultView[this.dgvForms.SelectedRows[i].Index].Row["Code"].ToString();
                try
                {
                    this.BllDAL.SysFormMove(strCode,(short)1, out strMsg, out iReturnValue);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg == "") strMsg = "窗体\"" + strCode + "\"上移失败，原因未知。";
                    this.ShowMsg(strMsg);
                    return;
                }
                strCodes += strCode + "|";
            }
            this.BindForm(strCodes);
        }

        private void tsb2Down_Click(object sender, EventArgs e)
        {
            if (this.dgvForms.SelectedRows.Count == 0)
            {
                this.ShowMsg("请至少选中一行数据。");
                return;
            }
            DataTable dt = this.dgvForms.DataSource as DataTable;
            if (dt == null) return;
            string strCode;
            string strCodes = string.Empty;
            int iReturnValue;
            string strMsg;
            for (int i = 0; i < this.dgvForms.SelectedRows.Count; i++)
            {
                strCode = dt.DefaultView[this.dgvForms.SelectedRows[i].Index].Row["Code"].ToString();
                try
                {
                    this.BllDAL.SysFormMove(strCode, (short)2, out strMsg, out iReturnValue);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg == "") strMsg = "窗体\"" + strCode + "\"下移失败，原因未知。";
                    this.ShowMsg(strMsg);
                    return;
                }
                strCodes += strCode + "|";
            }
            this.BindForm(strCodes);
        }

        private void frmSysForms_Load(object sender, EventArgs e)
        {
            Perinit();
            BindGroup(string.Empty);
            BindForm(string.Empty);
        }

        private void dgvForms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataTable dt = this.dgvForms.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[e.RowIndex].Row;
            frmSysFormEdit frm = new frmSysFormEdit();
            frm.FormState = Common.MyEnums.FormStates.Edit;
            frm.PrimaryValue = dr["Code"].ToString();
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            this.BindForm(dr["Code"].ToString());
        }

        private void 移至其他组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvForms.DataSource as DataTable;
            if (dt == null) return;
            string strCodes = string.Empty;
            for (int i = 0; i < this.dgvForms.Rows.Count; i++)
            {
                if (this.dgvForms.Rows[i].Selected)
                    strCodes += dt.DefaultView[i].Row["Code"].ToString() + "|";
            }
            if (strCodes == string.Empty)
            {
                this.ShowMsg("请至少选中一行！");
                return;
            }
            frmSelSysGroup frm = new frmSelSysGroup();
            frm._ShowButtonSetRoot = false;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            string strMsg;
            int iReturnValue;
            try
            {
                this.BllDAL.SysFormModifyGroup(strCodes, frm._GroupCode, out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg == string.Empty)
                    strMsg = "操作失败，原因未知。";
                this.ShowMsg(strMsg);
                return;
            }
            this.BindForm(string.Empty);
        }

        private void tvGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            BindForm(string.Empty);
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            this.BindForm(string.Empty);
        }

        private void tstSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            tsbSearch_Click(null, null);
        }
    }
}