using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMESPrinter.DataM
{
    public partial class frmPrintedList1 : Common.frmBaseList
    {
        #region 窗体数据连接实例
        private BLLDAL.Binding _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Binding BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Binding();
                return _dal;
            }
        }
        #endregion 
        LuoLiuMESPrinter.MyPrinter _Printer = null;
        public frmPrintedList1()
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
            item.StringFormat = "Code like '{0}'";
            item.Value = 1;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "保护板编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "PcbCode like '{0}'";
            item.Value = 2;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "模块编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "MzCode IN (SELECT Code from Produce_SFG2Children where ChildCode='{0}')";
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
            string strSql = "SELECT * FROM [V_LuoLiuMESPrinter_List] WHERE 1=1";
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
            this._Printer = new MyPrinter();
            this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
            this.Perinit();
            BindData();
        }
        private void _Printer_PrintFinishedNotice(string sTuoPanCode, bool blSucessful, string sErr)
        {
            MyPrinter.PrintFinishedCallback call = new MyPrinter.PrintFinishedCallback(PrinterNotice);
            try
            {
                this.Invoke(call, new object[] { sTuoPanCode, blSucessful, sErr });
            }
            catch (Exception ex)
            {

            }
        }
        private void PrinterNotice(string sTuoPanCode, bool blSucessful, string sErr)
        {
            if (blSucessful)
            {
                this.ShowMsgRich("标签已打印");
            }
            else
            {
                if (sErr.Length == 0) sErr = "打印失败，原因未知！";
                this.ShowMsg(sErr);
            }
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
            foreach (int row in list)
            {
                //frmTestedData frm = new frmTestedData(dt.DefaultView[row].Row["Code"].ToString());
                //frm.FormParent = this;
                //frm.ShowDialog(this);
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (list.Count > 0)
            {
                if(!Common.CurrentUserInfo.IsAdmin && !Common.CurrentUserInfo.IsSuper)
                {
                    this.ShowMsg("只有管理员才能删除。");
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
                strCode = dt.DefaultView[row].Row["Code"].ToString();
                try
                {
                    this.BllDAL.LuoLiuMESPrinterDelete(strCode, out iReturnValue, out strMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "DeleteData");
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
            //frmTestedData frm = new frmTestedData(dt.DefaultView[e.RowIndex].Row["Code"].ToString());
            //frm.FormParent = this;
            //frm.ShowDialog(this);
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
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要打印的数据。");
                return;
            }
            foreach (int row in list)
            {
                string strCode = dt.DefaultView[row].Row["Code"].ToString();
                this._Printer.Printing(strCode);
            }
        }
    }
}