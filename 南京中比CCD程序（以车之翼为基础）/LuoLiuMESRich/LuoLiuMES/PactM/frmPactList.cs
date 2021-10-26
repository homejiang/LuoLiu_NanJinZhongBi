using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES.PactM
{
    public partial class frmPactList : Common.frmBaseList
    {
        public frmPactList()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.PactM _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.PactM BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.PactM();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            #region 设置工具栏日期控件
            this.BarSearchDateTimeStart.Value = DateTime.Now.AddMonths(-1);
            this.BarSearchDateTimeStart.Checked = true;
            this.BarSearchDateTimeEnd.Value = DateTime.Now;
            this.BarSearchDateTimeEnd.Checked = false;
            this.InsertDateTimePicker(this.toolStrip1, this.tslCreateTime.Name, false);//插入日期控件
            #endregion
            #region 设置更多操作按钮
            List<Common.MyEntity.SearchButtonItem> listBarbuts = new List<Common.MyEntity.SearchButtonItem>();
            Common.MyEntity.SearchButtonItem barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "高级搜索";
            barbut.Value = 1;
            listBarbuts.Add(barbut);
            barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "列表字段显示";
            barbut.Value = 2;
            listBarbuts.Add(barbut);
            this.InsertMyButtons(this.toolStrip1, this.tsbSearch.Name, listBarbuts,true,true);//插入到搜索按钮后面
            this.BarSearchMyButtons.TitleChanged+=new MyControl.MyLabelExChageTitleEventHandler(BarSearchMyButtons_TitleChanged);
            #endregion
            #region 绑定列表字段
            this.ShowDataGridViewSetting_BindColumn(this.dgvList, Common.MyEnums.Modules.None);
            #endregion
            #region 设置工具栏combox搜索标题
            //加载搜索项
            List<Common.MyEntity.SearchLabelItem> listSearchItem = new List<Common.MyEntity.SearchLabelItem>();
            Common.MyEntity.SearchLabelItem item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "订单编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "PatCode LIKE '{0}'";
            item.Value = 1;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "客户";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "ClientCNName LIKE '%{0}%'";
            item.Value = 2;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "备注";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "Remark LIKE '%{0}%'";
            item.Value = 3;
            listSearchItem.Add(item);
            ToolBarDropdownTitles_Bind(this.tsDropTitle, listSearchItem);
            #endregion
            #region 设置combox回车事件
            this.SetBarSearchEnterKey(this.tsCombox);
            #endregion
            this.dgvList.AutoGenerateColumns = false;
            return true;
        }
        private bool BindData()
        {
            string strSql;
            strSql = "SELECT * FROM V_Pact_Main_List WHERE 1=1";
            //设置commbox搜索条件
            if (this.tsCombox.Text.Length > 0)
            {
                Common.MyEntity.SearchLabelItem shItem = this.ToolBarDropdownTitles_GetSearchLabelItem(this.tsDropTitle);
                if (shItem != null && shItem.StringFormat.Length > 0)
                {
                    strSql += string.Format(" AND " + shItem.StringFormat, this.tsCombox.Text.Replace("'", "''"));
                }
            }
            strSql += " ORDER BY CreateTime DESC";//以倒序排列
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = dt;
            return true;
        }
        #endregion
        #region 工具栏事件
        //combox标题切换事件
        protected void BarSearchMyButtons_TitleChanged(MyControl.MyLabelEx.MyLabelItem originalItem, MyControl.MyLabelEx.MyLabelItem newItem)
        {
            Common.MyEntity.SearchButtonItem item = newItem.Tag as Common.MyEntity.SearchButtonItem;
            if (item == null) return;
            //根据value值，执行不同的功能
            if (item.Value == 2)
            {
                this.DataGridViewSetting(Common.MyEnums.Modules.PactManager, this.dgvList);
            }
        }
        //新增按钮
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            //先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("你没有新建权限，如有需要请联系管理员开放该权限。");
                return;
            }
            frmPact frm = new frmPact(this.BllDAL);
            frm.FormParent = this;
            frm.FormState = Common.MyEnums.FormStates.New;
            frm.Text = this.BllDAL.PFuns_GetEditFromName(string.Empty, Common.MyEnums.FormStates.New);
            this.ShowChildForm(frm.Text, frm);
        }
        //打开按钮
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strPactCode;
            //打开所有选中的行
            if (this.dgvList.SelectedRows.Count > _MaxOpenRows)
            {
                this.ShowMsg(string.Format("对不起，一次性最多只能打开{0}行数据。", _MaxOpenRows));
                return;
            }
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strPactCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["PactCode"].ToString();
                if (strPactCode == string.Empty) continue;
                this.OpenEditForm(strPactCode);
            }
        }
        private void OpenEditForm(string sPactCode)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strPactCode;
            //打开所有选中的行
            if (this.dgvList.SelectedRows.Count > _MaxOpenRows)
            {
                this.ShowMsg(string.Format("对不起，一次性最多只能打开{0}行数据。", _MaxOpenRows));
                return;
            }
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strPactCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["PactCode"].ToString();
                if (strPactCode == string.Empty) continue;
                frmPact frm = new frmPact(this.BllDAL);
                frm.FormParent = this;
                frm._PactCode = strPactCode;
                //校验权限
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager, strPactCode);
                if (listPower.Count == 0)
                {
                    this.ShowMsg(string.Format("您没有权限打开，因为你没有它的任何权限。", strPactCode));
                    continue;
                }
                if (listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                {
                    frm.FormState = Common.MyEnums.FormStates.Edit;
                    frm.Text = this.BllDAL.PFuns_GetEditFromName(sPactCode, Common.MyEnums.FormStates.Edit);
                    
                    this.ShowChildForm(frm.Text, frm);
                }
                else
                {
                    frm.FormState = Common.MyEnums.FormStates.Readonly;
                    frm.Text = this.BllDAL.PFuns_GetEditFromName(sPactCode, Common.MyEnums.FormStates.Readonly);
                    this.ShowChildForm(frm.Text, frm);
                }
            }
        }
        //删除按钮
        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0 || DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的" + this.dgvList.SelectedRows.Count.ToString() + "条数据吗？此操作数据将不可恢复，确定要继续吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strPactCode;
            bool isDeleted = false;
            int iReturn;
            string sMsg;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strPactCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["PactCode"].ToString();
                try
                {
                    this.BllDAL.PactDelete(strPactCode, out iReturn, out sMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturn != 1)
                {
                    if (sMsg.Length == 0)
                        sMsg = "删除订单“" + dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["PactCode"].ToString() + "”失败，原因未知。";
                    this.ShowMsg(sMsg);
                    continue;
                }
                else if (!isDeleted)
                    isDeleted = true;
            }
            if (isDeleted)
                this.BindData();
        }
        //关闭窗体
        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }
        //搜索按钮
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
        #endregion
        #region 窗体事件
        private void frmGPactList_Load(object sender, EventArgs e)
        {
            //先判断权限，用户只要有只读权限就可以打开
            // 先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PactManager);
            if (listPower.Count == 0)
            {
                this.ShowMsg("你没有权限查看此模块，窗口将自动关闭。");
                this.FormColse();
                return;
            }
            if (!this.PerInit()) return;
            if (!this.BindData()) return;
        }
        #endregion
        #region  重写父类函数
        /// <summary>
        /// 刷新当前窗口
        /// </summary>
        /// <returns></returns>
        public override bool RefreshParetForm(object objArg)
        {
            return this.BindData();
        }
        //重写搜索时间
        public override void DoBarSearch()
        {
            this.tsbSearch_Click(null, null);
        }
        #endregion
        #region 主列表事件
        //双击事件
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            string strPactCode = dt.DefaultView[e.RowIndex].Row["PactCode"].ToString();
            if (strPactCode.Length == 0) return;
            this.OpenEditForm(strPactCode);
        }
        #endregion

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            //先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("你没有新建权限，如有需要请联系管理员开放该权限。");
                return;
            }
            if (this.dgvList.SelectedRows.Count > 1)
            {
                this.ShowMsg("复制操作一次性只能复制一条任务单。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            string strPactCode = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row["PactCode"].ToString();
            frmPact frm = new frmPact(this.BllDAL);
            frm.FormParent = this;
            frm._PactCode = strPactCode;
            frm.FormState = Common.MyEnums.FormStates.Copy;
            frm.Text = this.BllDAL.PFuns_GetEditFromName(strPactCode, Common.MyEnums.FormStates.Copy);
            this.ShowChildForm(frm.Text, frm);
        }
    }
}