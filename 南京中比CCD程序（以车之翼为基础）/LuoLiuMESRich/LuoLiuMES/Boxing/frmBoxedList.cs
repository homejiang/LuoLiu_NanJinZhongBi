using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES.Boxing
{
    public partial class frmBoxedList : Common.frmBaseList
    {
        #region 窗体数据连接实例
        private BLLDAL.Boxing _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Boxing BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Boxing();
                return _dal;
            }
        }
        #endregion 
        LuoLiuMES.Boxing.BoxPrinter _Printer = null;
        public frmBoxedList()
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
            item.TitleName = "托盘编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "Code like '{0}'";
            item.Value = 1;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "电池包编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "Code in (SELECT Code FROM Boxing_Detail where ItemCode='{0}')";
            item.Value = 2;
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
            item.TitleName = "托盘类型";
            item.CanInput = true;
            item.DropdownItemsLoaded = false;
            item.UseLike = true;
            item.StringFormat = "TypeName like '{0}'";
            item.Value = 5;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "对应客户";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "ClientVirCode='{0}'";
            item.Value = 6;
            listSearchItem.Add(item);

            ToolBarDropdownTitles_Bind(this.tslTitle, listSearchItem);
            #endregion
            return true;
        }
        private bool IsCompeleted(string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT State FROM Boxing_Box where Code='{0}'", sCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("托盘\"" + sCode + "\"不存在或已经被删除。");
                return false;
            }
            if (dt.Rows[0]["State"].ToString() != "1")
            {
                this.ShowMsg("托盘\"" + sCode + "\"还未结束装托，不能导出数据。");
                return false;
            }
            return true;
        }
        public override void ToolBarDropdownTitlesClick_Pro(object objOrginal, object objNew)
        {
            Common.MyEntity.SearchLabelItem item = objNew as Common.MyEntity.SearchLabelItem;
            if (item == null) return;
            this.tsCombox.Items.Clear();
            if (!item.DropdownItemsLoaded)
            {
                if (item.Value == 5)
                {
                    #region 加载测试模式
                    DataTable dt;
                    try
                    {
                        dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT TypeName FROM JC_BoxType ORDER BY TypeName asc");
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return;
                    }
                    List<string> list = new List<string>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(dr["TypeName"].ToString());   
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
            string strSql = "SELECT * FROM [V_Boxing_BoxedList] WHERE 1=1";
            if (this.BarSearchDateTimeStart.Checked)
                strSql += string.Format(" AND Times>='{0}'", this.BarSearchDateTimeStart.Value.ToString("yyyy-MM-dd"));
            if (this.BarSearchDateTimeEnd.Checked)
                strSql += string.Format(" AND Times<'{0}'", this.BarSearchDateTimeEnd.Value.AddDays(1).ToString("yyyy-MM-dd"));
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
            strSql += " ORDER BY Times ASC ";
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
            this._Printer = new BoxPrinter();
            this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
            this.Perinit();
            BindData();
        }
        private void _Printer_PrintFinishedNotice(string sTuoPanCode, bool blSucessful, string sErr, string sArg)
        {
            BoxPrinter.PrintFinishedCallback call = new BoxPrinter.PrintFinishedCallback(PrinterNotice);
            try
            {
                this.Invoke(call, new object[] { sTuoPanCode, blSucessful, sErr, sArg });
            }
            catch (Exception ex)
            {

            }
        }
        private void PrinterNotice(string sTuoPanCode, bool blSucessful, string sErr,string sArg)
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
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.Boxing);
            bool blPower = listPower.Contains(Common.MyEnums.OperatePower.New) || listPower.Contains(Common.MyEnums.OperatePower.Eidt) || listPower.Contains(Common.MyEnums.OperatePower.Delete);
            foreach (int row in list)
            {
                DataRow dr = dt.DefaultView[row].Row;
                frmBoxedData frm = new frmBoxedData();
                frm.FormParent = this;
                frm._Code = dr["Code"].ToString();
                if (blPower)
                    frm.FormState = Common.MyEnums.FormStates.Edit;
                else frm.FormState = Common.MyEnums.FormStates.Readonly;
                if (blPower)
                    frm.Text = string.Format("托盘{0}数据", dr["Code"]);
                else frm.Text = string.Format("托盘{0}数据(只读)", dr["Code"]);
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
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.Boxing);
                if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
                {
                    this.ShowMsg("您没有删除托盘的权限！");
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
                    this.BllDAL.DelteBox(strCode, out iReturnValue, out strMsg);
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
            frmBoxing frm = new frmBoxing();
            frm._Code = dt.DefaultView[e.RowIndex].Row["Code"].ToString();
            frm.Show();
        }

        private void tsCombox_KeyDown(object sender, KeyEventArgs e)
        {
            this.BindData();
        }
        
        private void tsbPrinter_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要打印的托盘。");
                return;
            }
            foreach (int row in list)
            {
                string strCode = dt.DefaultView[row].Row["Code"].ToString();
                this._Printer.Printing(strCode);
            }
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.Boxing);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有安装托盘的权限！");
                return;
            }
            frmBoxing frm = new frmBoxing();
            frm._Code = string.Empty;
            frm.Show();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要打开的托盘。");
                return;
            }
            if(list.Count>1)
            {
                this.ShowMsg("您只能选中一个托盘。");
                return;
            }
            string strCode = dt.DefaultView[list[0]].Row["Code"].ToString();
            frmBoxing frm = new frmBoxing();
            frm._Code = strCode;
            frm.Show();
        }

        private void tsbOutputExcel_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要导出数据的托盘。");
                return;
            }
            string strArg, strExcel;
            if(!Common.OutputExcel.frmOutputExcel.GetExcelInfo(MESConfig.BoxingConfig.OuptutTypeName, string.Empty, out strArg, out strExcel))
            {
                return;
            }
            foreach (int row in list)
            {
                string strCode = dt.DefaultView[row].Row["Code"].ToString();
                if (!this.IsCompeleted(strCode)) continue;
                Common.OutputExcel.frmOutputExcel.SetExcelInfo(strArg, strCode, string.Format("{0}_{1}.xls", strExcel, strCode), null);
            }
        }
    }
}