using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LuoLiuMES.StoreM
{
    public partial class frmRemoveList : Common.frmBaseList
    {
        public frmRemoveList()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.SFGRemove _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.SFGRemove BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new LuoLiuMES.BLLDAL.SFGRemove();
                return _dal;
            }
        }
        #endregion 
        #region 处理函数
        private bool PerInit()
        {
            #region 设置工具栏日期控件
            DateTime detSer;
            if (!Common.CommonFuns.GetSysCurrentDateTime(out detSer)) return false;
            this.BarSearchDateTimeStart.ShowCheckBox = false;
            this.BarSearchTimeStart.ShowCheckBox = false;
            this.BarSearchTimeEnd.ShowCheckBox = false;
            //设置起始时间
            this.BarSearchDateTimeStart.Checked = true;
            this.BarSearchDateTimeStart.Value = detSer.AddMonths(-1);
            this.BarSearchTimeStart.Value = detSer;
            // 设置结束时间
            this.BarSearchDateTimeEnd.Value = detSer;
            this.BarSearchTimeEnd.Value = detSer;
            this.BarSearchDateTimeEnd.Checked = false;
            //设置控件宽度
            BarSearchDateTimeStart.Width = 87;
            BarSearchTimeStart.Width = 55;
            BarSearchDateTimeEnd.Width = 97;
            BarSearchTimeEnd.Width = 55;
            this.InsertLongDateTimePicker(this.toolStrip1, this.tslFinishedTime.Name, false);//插入日期控件
            #endregion
            #region 设置工具栏combox搜索标题
            //加载搜索项
            List<Common.MyEntity.SearchLabelItem> listSearchItem = new List<Common.MyEntity.SearchLabelItem>();
            Common.MyEntity.SearchLabelItem item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "报废单号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "Code LIKE '%{0}%'";
            item.Value = 2;
            listSearchItem.Add(item);
            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "产品编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = false;
            item.Value = 3;
            listSearchItem.Add(item);
            ToolBarDropdownTitles_Bind(this.tsDropTitle, listSearchItem);
            #endregion
            #region 设置更多操作按钮
            List<Common.MyEntity.SearchButtonItem> listBarbuts = new List<Common.MyEntity.SearchButtonItem>();
            Common.MyEntity.SearchButtonItem barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "高级搜索";
            barbut.Value = 1;
            listBarbuts.Add(barbut);
            barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "列表显示设置";
            barbut.Value = 2;
            listBarbuts.Add(barbut);
            this.InsertMyButtons(this.toolStrip1, this.tsbSearch.Name, listBarbuts, true, true);//插入到搜索按钮后面
            this.BarSearchMyButtons.TitleChanged += new MyControl.MyLabelExChageTitleEventHandler(BarSearchMyButtons_TitleChanged);
            #endregion
            #region 设置combox回车事件
            this.SetBarSearchEnterKey(this.tsCombox);
            #endregion
            #region 绑定列表字段
            this.ShowDataGridViewSetting_BindColumn(this.dgvList, Common.MyEnums.Modules.Remove);
            #endregion
            this.dgvList.AutoGenerateColumns = false;
            return true;
        }
        private bool BindData()
        {
            string strSql;
            strSql = "SELECT * FROM V_PM_RemoveSFG WHERE 1=1";
            //设置生产机台号搜索
            //设置时间搜索
            strSql += string.Format(" AND CreateTime>='{0} {1}'", this.BarSearchDateTimeStart.Value.ToString("yyyy-MM-dd"), this.BarSearchTimeStart.Value.ToString("HH:mm"));
            if (this.BarSearchDateTimeEnd.Checked)
            {
                strSql += string.Format(" AND CreateTime<='{0} {1}'", this.BarSearchDateTimeEnd.Value.ToString("yyyy-MM-dd"), this.BarSearchTimeEnd.Value.ToString("HH:mm"));
            }
            //设置commbox搜索条件
            if (this.tsCombox.Text.Length > 0)
            {
                Common.MyEntity.SearchLabelItem shItem = this.ToolBarDropdownTitles_GetSearchLabelItem(this.tsDropTitle);
                if (shItem != null && shItem.StringFormat.Length > 0)
                {
                    strSql += string.Format(" AND " + shItem.StringFormat, this.tsCombox.Text.Replace("'", "''"));
                }
                else if (shItem != null && shItem.Value == 3)
                {
                    #region 加载编号
                    DataTable dttemp;
                    try
                    {
                        dttemp = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT OCode FROM PM_RemoveSFGDetail WHERE SFGCode='{0}'"
                            , tsCombox.Text.Replace("'", "''")));
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return false;
                    }
                    if (dttemp.Rows.Count > 0)
                        strSql += string.Format(" AND code='{0}'", dttemp.Rows[0]["OCode"].ToString().Replace("'", "''"));
                    else strSql += " AND 1=2";
                    #endregion
                }
            }
            strSql += " ORDER BY CreateTime ASC ";
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
        /// <summary>
        /// 刷新当前窗口
        /// </summary>
        /// <returns></returns>
        public override bool RefreshParetForm(object objArg)
        {
            return this.BindData();
        }
        #endregion
        private void frmInputList_Load(object sender, EventArgs e)
        {
            //先判断权限，用户只要有只读权限就可以打开
            // 先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Remove);
            if (listPower.Count == 0)
            {
                this.ShowMsg("你没有权限查看此模块，窗口将自动关闭。");
                this.FormColse();
                return;
            }
            if (!this.PerInit()) return;
            if (!this.BindData()) return;
        }
        #region  重写父类函数
        //重写搜索时间
        public override void DoBarSearch()
        {
            this.tsbSearch_Click(null, null);
        }
        public override void ToolBarDropdownTitlesClick_Pro(object objOrginal, object objNew)
        {
        }
        #endregion

        private void tsbNew_Click(object sender, EventArgs e)
        {
            //校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Remove);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("您没有权限报废记录。");
                return;
            }
            frmRemove frm = new frmRemove();
            frm.FormState = Common.MyEnums.FormStates.New;
            frm.FormParent = this;
            frm.Text = "新增报废单";
            this.ShowChildForm(frm.Text, frm);
        }
        protected void BarSearchMyButtons_TitleChanged(MyControl.MyLabelEx.MyLabelItem originalItem, MyControl.MyLabelEx.MyLabelItem newItem)
        {
            Common.MyEntity.SearchButtonItem item = newItem.Tag as Common.MyEntity.SearchButtonItem;
            if (item == null) return;
            //根据value值，执行不同的功能
            if (item.Value == 2)
            {
                this.DataGridViewSetting(Common.MyEnums.Modules.Remove, this.dgvList);
            }
        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Remove);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("您没有权限报废记录。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            //打开所有选中的行
            if (this.dgvList.SelectedRows.Count > _MaxOpenRows)
            {
                this.ShowMsg(string.Format("对不起，一次性最多只能打开{0}行数据。", _MaxOpenRows));
                return;
            }
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                this.OpenEditForm(this.dgvList.SelectedRows[i].Index, dt);
            }
        }
        private void OpenEditForm(int iRowIndex, DataTable dtList)
        {
            if (dtList == null) dtList = this.dgvList.DataSource as DataTable;
            if (dtList == null) return;
            if (iRowIndex >= dtList.DefaultView.Count) return;
            string strCode = dtList.DefaultView[iRowIndex].Row["Code"].ToString();
            frmRemove frm = new frmRemove();
            frm.FormParent = this;
            frm.PrimaryValue = strCode;
            //校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Remove);
            if (listPower.Count == 0)
            {
                this.ShowMsg("您没有权限打开报废单记录。");
                return;
            }
            if (listPower.Contains(Common.MyEnums.OperatePower.Eidt) || listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                frm.FormState = Common.MyEnums.FormStates.Edit;
            }
            else frm.FormState = Common.MyEnums.FormStates.Readonly;
            if (frm.FormState == Common.MyEnums.FormStates.Readonly)
                frm.Text = "报废单" + strCode + "（只读）";
            else frm.Text = "报废单" + strCode;
            this.ShowChildForm(frm.Text, frm);
        }
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            //校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Remove);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("您没有权限删除报废单记录。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0) return;
            if (!this.IsUserConfirm("您确定要删除选中的" + this.dgvList.SelectedRows.Count.ToString() + "行数据吗？")) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            int iIndex;
            string strMsg;
            int iReturnValue;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                iIndex = this.dgvList.SelectedRows[i].Index;
                try
                {
                    this.BllDAL.Delete(dt.DefaultView[iIndex].Row["Code"].ToString(), out strMsg, out iReturnValue);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg == string.Empty)
                        strMsg = "报废单\"" + dt.DefaultView[iIndex].Row["Code"].ToString() + "\"删除失败，原因未知。";
                    this.ShowMsg(strMsg);
                    continue;
                }
            }
            this.BindData();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Remove);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("您没有权限编辑报废记录。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            //打开所有选中的行
            if (this.dgvList.SelectedRows.Count > _MaxOpenRows)
            {
                this.ShowMsg(string.Format("对不起，一次性最多只能打开{0}行数据。", _MaxOpenRows));
                return;
            }
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                this.OpenEditForm(this.dgvList.SelectedRows[i].Index, dt);
            }
        }
    }
}
