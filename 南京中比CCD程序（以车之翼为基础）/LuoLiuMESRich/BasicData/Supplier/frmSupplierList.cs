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

namespace BasicData.Supplier
{
    public partial class frmSupplierList : frmBaseList
    {
        public frmSupplierList()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.Supplier _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Supplier BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.Supplier();
                return _dal;
            }
        }
        #endregion
        #region 窗体事件
        private void frmSupplierList_Load(object sender, EventArgs e)
        {
            // 先校验权限
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Supplier);
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
        #region 处理函数
        private bool BindData()
        {
            string strSql = "SELECT * FROM V_JC_Supplier WHERE 1=1";
            if (this.tscSearch.Text != string.Empty)
            {
                Common.MyEntity.SearchLabelItem shItem = this.ToolBarDropdownTitles_GetSearchLabelItem(this.tsbTitle);
                if (shItem != null && shItem.StringFormat.Length > 0)
                {
                    strSql += string.Format(" AND " + shItem.StringFormat, this.tscSearch.Text.Replace("'", "''"));
                }
            }
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
        private bool PerInit()
        {
            this.dgvList.AutoGenerateColumns = false;
            #region 绑定查询标题下拉菜单
            List<Common.MyEntity.SearchLabelItem> listSearchItem = new List<Common.MyEntity.SearchLabelItem>();
            Common.MyEntity.SearchLabelItem item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "供应商名称";
            item.Value = 1;
            item.DropdownItemsLoaded = true;
            item.StringFormat = " (CNName LIKE '%{0}%' OR ENName LIKE '%{0}%' or ShortName LIKE '%{0}%')";
            listSearchItem.Add(item);
            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "供货商编码";
            item.Value = 2;
            item.DropdownItemsLoaded = true;
            item.StringFormat = " Code LIKE '%{0}%'";
            listSearchItem.Add(item);
            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "供货类型";
            item.Value = 3;
            item.DropdownItemsLoaded = false;
            item.StringFormat = " SupplyTypeView='{0}'";
            listSearchItem.Add(item);
            ToolBarDropdownTitles_Bind(this.tsbTitle, listSearchItem);
            #endregion
            #region 设置combox回车事件
            this.SetBarSearchEnterKey(this.tscSearch);
            #endregion
            return true;
        }
        public override bool RefreshParetForm(object objArg)
        {
            return this.BindData();
        }
        #endregion
        #region 重写父函数
        public override void ToolBarDropdownTitlesClick_Pro(object objOrginal, object objNew)
        {
            Common.MyEntity.SearchLabelItem item = objNew as Common.MyEntity.SearchLabelItem;
            if (item == null) return;
            this.tscSearch.Items.Clear();
            if (!item.DropdownItemsLoaded)
            {
                if (item.Value == 3)
                {
                    #region 加载供货方式描述
                    //注意，需要将数据进行排序，可能包含“未知”，此选项必须放在最后，1、2被指定为正常采购和调拨
                    DataTable dtSptype;
                    try
                    {
                        dtSptype = Common.CommonDAL.DoSqlCommand.GetDateTable("select SupplyType,SupplyTypeView from V_JC_Supplier group by SupplyType,SupplyTypeView order by (CASE WHEN ISNULL(SupplyType,0)<>1 AND ISNULL(SupplyType,0)<>2 THEN 9999 ELSE SupplyType END) ASC,SupplyTypeView asc");
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return;
                    }
                    List<string> listSptype = new List<string>();
                    foreach (DataRow dr in dtSptype.Rows)
                    {
                        listSptype.Add(dr["SupplyTypeView"].ToString());
                    }
                    item.DropdownItems = listSptype;
                    item.DropdownItemsLoaded = true;
                    #endregion
                }
            }
            if (item.DropdownItems != null)
            {
                foreach (string str in item.DropdownItems)
                    this.tscSearch.Items.Add(str);
            }
            if (item.CanInput)
            {
                if (this.tscSearch.DropDownStyle != ComboBoxStyle.DropDown)
                    this.tscSearch.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                if (this.tscSearch.DropDownStyle != ComboBoxStyle.DropDownList)
                    this.tscSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        #endregion
        #region 窗体控件事件
        //搜索
        private void btSearch_Click(object sender, EventArgs e)
        {
            //开始加载数据
            if (!this.BindData())
                return;
        }
        //打开
        private void btOpen_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strCode;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                if (strCode == string.Empty) continue;
                frmSupplier frm = new frmSupplier();
                frm.FormParent = this;
                //校验权限
                List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Supplier, strCode);
                if (listPower.Count == 0)
                {
                    this.ShowMsg(string.Format("您没有权限打开供应商“{0}”，因为你没有它的任何权限！", strCode));
                    continue;
                }
                if (listPower.Contains(OperatePower.Eidt))
                {
                    frm.FormState = FormStates.Edit;
                    frm.Text = "供应商" + strCode;
                    frm.PrimaryValue = strCode;
                    this.ShowChildForm(frm.Text, frm);
                }
                else
                {
                    frm.FormState = FormStates.Readonly;
                    frm.Text = string.Format("供应商{0}（只读）", strCode);
                    frm.PrimaryValue = strCode;
                    this.ShowChildForm(frm.Text, frm);
                }
            }
        }
        //删除
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
                List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Supplier, strCode);
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
        //列表双击事件
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strPlanCode;
            DataTable dt = this.dgvList.DataSource as DataTable;
            strPlanCode = dt.DefaultView[e.RowIndex].Row["Code"].ToString();
            frmSupplier frm = new frmSupplier();
            frm.FormParent = this;
            //校验权限
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Supplier, strPlanCode);
            if (listPower.Count == 0)
            {
                this.ShowMsg(string.Format("您没有权限打开供应商“{0}”，因为你没有它的任何权限！", strPlanCode));
                return;
            }
            if (listPower.Contains(OperatePower.Eidt))
            {
                frm.FormState = FormStates.Edit;
                frm.Text = "供应商" + strPlanCode;
                frm.PrimaryValue = strPlanCode;
                this.ShowChildForm(frm.Text, frm);
            }
            else
            {
                frm.FormState = FormStates.Readonly;
                frm.Text = string.Format("供应商{0}（只读）", strPlanCode);
                frm.PrimaryValue = strPlanCode;
                this.ShowChildForm(frm.Text, frm);
            }
        }
        //关闭窗体
        private void btClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }

        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 && e.ColumnIndex < 0) return;
            //检查权限
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (dt.DefaultView[e.RowIndex].Row["Code"].ToString() == string.Empty) return;
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Supplier, dt.DefaultView[e.RowIndex].Row["Code"].ToString());
            if (listPower.Count == 0)
            {
                this.ShowMsg("您没有供应商模块的任何权限！");
                return;
            }
            frmSupplier frm = new frmSupplier();
            frm.FormParent = this;
            if (!listPower.Contains(OperatePower.Eidt))
            {
                frm.FormState = FormStates.Readonly;
                frm.Text = "供应商" + dt.DefaultView[e.RowIndex].Row["Code"].ToString() + "（只读）";
            }
            else
            {
                frm.FormState = FormStates.Edit;
                frm.Text = "供应商" + dt.DefaultView[e.RowIndex].Row["Code"].ToString();
            }
            frm.PrimaryValue = dt.DefaultView[e.RowIndex].Row["Code"].ToString();
            this.ShowChildForm(frm.Text, frm);
        }
        #endregion

        private void tbSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                this.btSearch_Click(null, null);
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有超级管理员才能新增！");
                return;
            }
            frmSupplier frm = new frmSupplier();
            frm.FormParent = this;
            frm.FormState = FormStates.New;
            this.ShowChildForm(frm.Text, frm);
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Supplier);
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
            string strCode = dt.DefaultView[iRow].Row["Code"].ToString();
            if (strCode == string.Empty) return;
            frmSupplier frm = new frmSupplier();
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

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有超级管理员才能操作！");
                return;
            }
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要删除的供应商。");
                return;
            }
            if (!this.IsUserConfirm("您确定要删除选中行吗？"))
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strCode;
            int iReturn;
            string sMsg;
            bool blUpdated = false;
            foreach (int row in list)
            {
                strCode = dt.DefaultView[row].Row["Code"].ToString();
                try
                {
                    this.BllDAL.Delete(strCode, out iReturn, out sMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturn != 1)
                {
                    if (sMsg.Length == 0)
                        sMsg = "操作失败，原因未知。";
                    this.ShowMsg(sMsg);
                    return;
                }
                else
                {
                    if (!blUpdated)
                        blUpdated = true;
                }
            }
            if (blUpdated)
                this.BindData();
        }
    }
}