using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace EleCardComposing.DataM
{
    public partial class frmComposedList : Common.frmBaseList
    {
        #region 窗体数据连接实例
        private BLLDAL.Composing _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Composing BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Composing();
                return _dal;
            }
        }
        #endregion 
        public frmComposedList()
        {
            InitializeComponent();
        }
        private bool Perinit()
        {
            this.dgvList.AutoGenerateColumns = false;
            #region 设置工具栏日期控件
            this.BarSearchDateTimeStart.Value = DateTime.Now.AddDays(-1);
            this.BarSearchDateTimeStart.Checked = true;
            this.BarSearchDateTimeEnd.Value = DateTime.Now;
            this.BarSearchDateTimeEnd.Checked = false;
            this.InsertDateTimePicker(this.toolStrip1, this.tlsTesteTime.Name, false);//插入日期控件
            #endregion
            #region 设置工具栏combox搜索标题
            //加载搜索项
            List<Common.MyEntity.SearchLabelItem> listSearchItem = new List<Common.MyEntity.SearchLabelItem>();
            Common.MyEntity.SearchLabelItem item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "成品编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "Code like '%{0}%'";
            item.Value = 1;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "保护板编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "PcbCode like '%{0}%'";
            item.Value = 2;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "模块编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "Code IN (SELECT Code from Produce_SFG2Children where ChildCode='{0}')";
            item.Value = 3;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "任务单编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "PactCode='{0}'";
            item.Value = 4;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "作业人员";
            item.CanInput = true;
            item.DropdownItemsLoaded = false;
            item.UseLike = true;
            item.StringFormat = "UserName='{0}'";
            item.Value = 5;
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
                if (item.Value == 4)
                {
                    #region 加载测试模式
                    DataTable dt;
                    try
                    {
                        dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT DISTINCT OperatorName FROM V_Temp_Printer WHERE ISNULL(OperatorName,'')<>''");
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return;
                    }
                    List<string> list = new List<string>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(dr["OperatorName"].ToString());   
                    }
                    item.DropdownItems = list;
                    item.DropdownItemsLoaded = true;
                    #endregion
                }
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
            string strSql = "SELECT * FROM [V_ComposedList] WHERE 1=1";
            if (this.BarSearchDateTimeStart.Checked)
                strSql += string.Format(" AND EndTime>='{0}'", this.BarSearchDateTimeStart.Value.ToString("yyyy-MM-dd"));
            if (this.BarSearchDateTimeEnd.Checked)
                strSql += string.Format(" AND EndTime<'{0}'", this.BarSearchDateTimeEnd.Value.AddDays(1).ToString("yyyy-MM-dd"));
            //设置commbox搜索条件
            if (this.tsCombox.Text.Length > 0)
            {
                Common.MyEntity.SearchLabelItem shItem = this.ToolBarDropdownTitles_GetSearchLabelItem(this.tslTitle);
                if (shItem != null)
                {
                    if (shItem.StringFormat.Length > 0)
                    {
                        strSql += string.Format(" AND " + shItem.StringFormat, this.tsCombox.Text.Replace("'", "''"));
                    }
                }
            }
            strSql += " ORDER BY EndTime ASC ";
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
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.EleCardComposing);
            bool blPower = listPower.Contains(Common.MyEnums.OperatePower.Delete);
            foreach (int row in list)
            {
                DataRow dr = dt.DefaultView[row].Row;
                frmComposedData frm = new frmComposedData();
                frm._MzCode = dr["Code"].ToString();
                frm.FormParent = this;
                if (blPower)
                    frm.FormState = Common.MyEnums.FormStates.Edit;
                else frm.FormState = Common.MyEnums.FormStates.Readonly;
                if (blPower)
                    frm.Text = string.Format("模组{0}锁装记录", dr["Code"]);
                else frm.Text = string.Format("模组{0}锁装记录(只读)", dr["Code"]);
                this.ShowChildForm(frm.Text, frm);
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (list.Count > 0)
            {
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.EleCardComposing);
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
            int iReturnValue=-1;
            string strMsg = string.Empty;
            bool blUpdted = false;
            foreach (int row in list)
            {
                strCode = dt.DefaultView[row].Row["Code"].ToString();
                try
                {
                    this.BllDAL.EleCardComposingDelete(strCode, out iReturnValue, out strMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "解除锁装");
                    break;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg.Length == 0)
                        strMsg = "操作失败，原因未知。";
                    this.ShowMsg(strMsg);
                }
                blUpdted = true;
            }
            if (blUpdted)
                this.BindData();
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
            frmComposedData frm = new frmComposedData();
            frm._MzCode = dr["Code"].ToString();
            frm.FormParent = this;
            if (blPower)
                frm.FormState = Common.MyEnums.FormStates.Edit;
            else frm.FormState = Common.MyEnums.FormStates.Readonly;
            if (blPower)
                frm.Text = string.Format("模组{0}锁装记录", dr["Code"]);
            else frm.Text = string.Format("模组{0}锁装记录(只读)", dr["Code"]);
            this.ShowChildForm(frm.Text, frm);
        }

        private void tsCombox_KeyDown(object sender, KeyEventArgs e)
        {
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
            if (!Common.OutputExcel.frmOutputExcel.GetExcelInfo(Config.ComposingOutputName, string.Empty, out strArg, out strExcel))
            {
                return;
            }
            foreach (int row in list)
            {
                string strCode = dt.DefaultView[row].Row["Code"].ToString();
                Common.OutputExcel.frmOutputExcel.SetExcelInfo(strArg, strCode, string.Format("{0}_{1}.xls", strExcel, strCode), null);
            }
        }
    }
}