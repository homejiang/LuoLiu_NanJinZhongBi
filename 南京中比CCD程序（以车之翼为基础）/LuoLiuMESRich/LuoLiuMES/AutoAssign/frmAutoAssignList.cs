using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES.AutoAssign
{
    public partial class frmAutoAssignList : Common.frmBaseList
    {
        #region 窗体数据连接实例
        private BLLDAL.AutoAssign _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.AutoAssign BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.AutoAssign();
                return _dal;
            }
        }
        #endregion 
        public frmAutoAssignList()
        {
            InitializeComponent();
        }
        private bool Perinit()
        {
            this.dgvList.AutoGenerateColumns = false;
            #region 设置工具栏日期控件
            DateTime detNow = Common.CommonFuns.FormatData.GetCurBanciStartTime();//获取当前班次起始时间
            this.BarSearchDateTimeStart.ShowCheckBox = false;
            this.BarSearchTimeStart.ShowCheckBox = false;
            this.BarSearchTimeEnd.ShowCheckBox = false;
            //设置起始时间
            this.BarSearchDateTimeStart.Checked = true;
            this.BarSearchDateTimeStart.Value = detNow;
            this.BarSearchTimeStart.Value = detNow;
            //设置结束时间
            detNow = detNow.AddHours(12);
            this.BarSearchDateTimeEnd.Value = detNow;
            this.BarSearchTimeEnd.Value = detNow;
            this.BarSearchDateTimeEnd.Checked = false;
            //设置控件宽度
            BarSearchDateTimeStart.Width = 85;
            BarSearchTimeStart.Width = 55;
            BarSearchDateTimeEnd.Width = 97;
            BarSearchTimeEnd.Width = 55;
            this.InsertLongDateTimePicker(this.toolStrip1, this.tslFinishedTime.Name, false);//插入日期控件
            #endregion
            #region 设置工具栏combox搜索标题
            //加载搜索项
            List<Common.MyEntity.SearchLabelItem> listSearchItem = new List<Common.MyEntity.SearchLabelItem>();
            Common.MyEntity.SearchLabelItem item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "模块编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "MkCode like '{0}'";
            item.Value = 1;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "托盘编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "TuoPan like '{0}'";
            item.Value = 2;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "任务单";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "PactCode like '{0}'";
            item.Value = 3;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "客户代码";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "ClientVirCode='{0}'";
            item.Value = 4;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "电芯编号(深度查找)";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "";
            item.Value = 6;
            listSearchItem.Add(item);

            ToolBarDropdownTitles_Bind(this.tslTitle, listSearchItem);
            #endregion
            return true;
        }
        private bool CheckUserPower()
        {
            
            return true;
        }
        public override void ToolBarDropdownTitlesClick_Pro(object objOrginal, object objNew)
        {
            Common.MyEntity.SearchLabelItem item = objNew as Common.MyEntity.SearchLabelItem;
            if (item == null) return;
            this.tsCombox.Items.Clear();
            if (!item.DropdownItemsLoaded)
            {
                
            }
            if (item.DropdownItems != null)
            {
                foreach (string str in item.DropdownItems)
                    this.tsCombox.Items.Add(str);
            }
            if (item.CanInput)
            {
                if (this.tsCombox.DropDownStyle != ComboBoxStyle.DropDown)
                    this.tsCombox.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                if (this.tsCombox.DropDownStyle != ComboBoxStyle.DropDownList)
                    this.tsCombox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        private bool BindData()
        {
            string strSql = "SELECT * FROM [V_Produce_Assign_Mk_List] WHERE 1=1";
            if (this.BarSearchDateTimeStart.Checked)
                strSql += string.Format(" AND FinishedTime>='{0}'", this.BarSearchDateTimeStart.Value.ToString("yyyy-MM-dd"));
            if (this.BarSearchDateTimeEnd.Checked)
                strSql += string.Format(" AND FinishedTime<'{0}'", this.BarSearchDateTimeEnd.Value.AddDays(1).ToString("yyyy-MM-dd"));
            //设置commbox搜索条件
            if (this.tsCombox.Text.Length > 0)
            {
                Common.MyEntity.SearchLabelItem shItem = this.ToolBarDropdownTitles_GetSearchLabelItem(this.tslTitle);
                if (shItem != null)
                {
                    if (shItem.Value == 6)
                    {
                        if(this.tsCombox.Text.Length==0)
                        {
                            this.ShowMsg("请输入电芯编号！");
                            return false;
                        }
                        frmFindTuoPanBySN frm = new frmFindTuoPanBySN(this.tsCombox.Text);
                        if (frm.ShowDialog(this) != DialogResult.OK)
                        {
                            return false;
                        }
                        //此时找到了，此时仅根托盘号有关系，其他无关
                        strSql = string.Format("SELECT * FROM [V_Produce_Assign_Mk_List] WHERE TuoPan='{0}'", frm._TuoPan.Replace("'", "''"));
                    }
                    else
                    {
                        if (shItem.StringFormat.Length > 0)
                        {
                            strSql += string.Format(" AND " + shItem.StringFormat, this.tsCombox.Text.Replace("'", "''"));
                        }
                    }
                }
            }
            strSql += " ORDER BY FinishedTime ASC ";
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
        private void frmPfList_Load(object sender, EventArgs e)
        {
           
            this.Perinit();
            BindData();
        }
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.Boxing);
            bool blPower = listPower.Contains(Common.MyEnums.OperatePower.Delete);
            foreach (int row in list)
            {
                DataRow dr = dt.DefaultView[row].Row;
                frmAutoAssignData frm = new frmAutoAssignData();
                frm._MKCode = dr["MkCode"].ToString();
                frm.FormParent = this;
                if (blPower)
                    frm.FormState = Common.MyEnums.FormStates.Edit;
                else frm.FormState = Common.MyEnums.FormStates.Readonly;
                if (blPower)
                    frm.Text = string.Format("模块{0}数据", dr["MkCode"]);
                else frm.Text = string.Format("模块{0}数据(只读)", dr["MkCode"]);
                this.ShowChildForm(frm.Text, frm);
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {

        }
        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void myDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;
            bool blPower = Common.CurrentUserInfo.IsAdmin;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[e.RowIndex].Row;
            frmAutoAssignData frm = new frmAutoAssignData();
            frm._MKCode = dr["MkCode"].ToString();
            frm.FormParent = this;
            if (blPower)
                frm.FormState = Common.MyEnums.FormStates.Edit;
            else frm.FormState = Common.MyEnums.FormStates.Readonly;
            if (blPower)
                frm.Text = string.Format("模块{0}数据", dr["MkCode"]);
            else frm.Text = string.Format("模块{0}数据(只读)", dr["MkCode"]);
            this.ShowChildForm(frm.Text, frm);
        }

        private void tsCombox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            this.BindData();
        }

        private void 导出批次下电芯明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void tsbPrinter_Click(object sender, EventArgs e)
        {
            
        }

        private void tslFinishedTime_Click(object sender, EventArgs e)
        {
            Common.Report.frmReportTime frm = new Common.Report.frmReportTime();
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            this.BarSearchDateTimeStart.Value = frm.StartTime;
            this.BarSearchTimeStart.Value = frm.StartTime;
            this.BarSearchDateTimeEnd.Value = frm.EndTime;
            this.BarSearchTimeEnd.Value = frm.EndTime;
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (list.Count > 0)
            {
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.MkManager);
                if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
                {
                    this.ShowMsg("您没有删除模块的权限！");
                    return;
                }
                if (!this.IsUserConfirm("您确定要删除选中数据吗？")) return;
            }
            else
            {
                this.ShowMsg("请选中要删除的数据。");
                return;
            }
            List<string> listSql = new List<string>();
            string strCode;
            int iReturnValue;
            string strMsg;
            bool blUpdted = false;
            foreach (int row in list)
            {
                strCode = dt.DefaultView[row].Row["TuoPan"].ToString();
                try
                {
                    this.BllDAL.DelteTuoPan(strCode, out iReturnValue, out strMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "DeleteMk");
                    break;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg.Length == 0)
                        strMsg = "删除失败，原因未知。";
                    this.ShowMsg(strMsg);
                }
                blUpdted = true;
            }
            if (blUpdted)
                this.BindData();
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要导出数据的模块。");
                return;
            }
            string strArg, strExcel;
            if (!Common.OutputExcel.frmOutputExcel.GetExcelInfo(LuoLiuMES.MESConfig.MkConfig.MkOuptutTypeName, string.Empty, out strArg, out strExcel))
            {
                return;
            }
            foreach (int row in list)
            {
                string strCode = dt.DefaultView[row].Row["TuoPan"].ToString();
                Common.OutputExcel.frmOutputExcel.SetExcelInfo(strArg, strCode, string.Format("{0}_{1}.xls", strExcel, strCode), null);
            }
        }
    }
}