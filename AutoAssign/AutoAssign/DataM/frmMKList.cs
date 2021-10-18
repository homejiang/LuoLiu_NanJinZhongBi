using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace AutoAssign.DataM
{
    public partial class frmMKList : Common.frmBaseList
    {
        #region 窗体数据连接实例
        private BLLDAL.Testing _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Testing BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Testing();
                return _dal;
            }
        }
        #endregion 
        public frmMKList()
        {
            InitializeComponent();
        }
        private bool Perinit()
        {
            this.dgvList.AutoGenerateColumns = false;
            #region 设置工具栏日期控件
            this.BarSearchDateTimeStart.Value = DateTime.Now.AddDays(-7);
            this.BarSearchDateTimeStart.Checked = true;
            this.BarSearchDateTimeEnd.Value = DateTime.Now;
            this.BarSearchDateTimeEnd.Checked = false;
            this.InsertDateTimePicker(this.toolStrip1, this.tlsTesteTime.Name, false);//插入日期控件
            #endregion
            #region 设置工具栏combox搜索标题
            //加载搜索项
            List<Common.MyEntity.SearchLabelItem> listSearchItem = new List<Common.MyEntity.SearchLabelItem>();
            Common.MyEntity.SearchLabelItem item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "模块编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "MKCode='{0}'";
            item.Value = 1;
            listSearchItem.Add(item);
            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "电芯条码";
            item.CanInput = true;
            item.DropdownItemsLoaded = false;
            item.UseLike = true;
            item.StringFormat = "OrderNo like '{0}'";
            item.Value = 2;
            listSearchItem.Add(item);
            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "测试批次";
            item.CanInput = true;
            item.DropdownItemsLoaded = false;
            item.UseLike = true;
            item.StringFormat = "TestCode like '{0}'";
            item.Value = 3;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "测试模式";
            item.CanInput = true;
            item.DropdownItemsLoaded = false;
            item.UseLike = true;
            item.StringFormat = "ModeView = '{0}'";
            item.Value = 4;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "电芯规格";
            item.CanInput = true;
            item.DropdownItemsLoaded = false;
            item.UseLike = true;
            item.StringFormat = "Spec LIKE '%{0}%'";
            item.Value = 5;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "工艺类型";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.DropdownItems = new List<string>();
            item.DropdownItems.Add("同工艺");
            item.DropdownItems.Add("多工艺");
            item.UseLike = true;
            item.StringFormat = "GongYiTypeName LIKE '{0}'";
            item.Value = 6;
            listSearchItem.Add(item);
            
            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "电芯系统自编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.Value = 7;
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
                if (item.Value == 2)
                {
                    #region 加载测试模式
                    DataTable dt;
                    try
                    {
                        dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("SELECT dbo.GetModeView(1,0) as ModeView1,dbo.GetModeView(1,1) as ModeView2,dbo.GetModeView(0,0) as ModeView3,dbo.GetModeView(0,1) as ModeView4");
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return;
                    }
                    if (dt.Rows.Count > 0)
                    {
                        List<string> list = new List<string>();
                        list.Add(dt.Rows[0]["ModeView1"].ToString());
                        list.Add(dt.Rows[0]["ModeView2"].ToString());
                        list.Add(dt.Rows[0]["ModeView3"].ToString());
                        list.Add(dt.Rows[0]["ModeView4"].ToString());
                        item.DropdownItems = list;
                        item.DropdownItemsLoaded = true;
                    }
                    #endregion
                }
                else if (item.Value == 3)
                {
                    #region 加载规格
                    DataTable dt;
                    try
                    {
                        dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("select spec from JC_ProductSpec order by spec");
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return;
                    }
                    List<string> listMac = new List<string>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["spec"].ToString().Length == 0) continue;
                        listMac.Add(dr["spec"].ToString());
                    }
                    item.DropdownItems = listMac;
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
            string strSql = "SELECT * FROM [V_Tested_MK_List] WHERE 1=1";
            if (this.BarSearchDateTimeStart.Checked)
                strSql += string.Format(" AND CreateTime>='{0}'", this.BarSearchDateTimeStart.Value.ToString("yyyy-MM-dd"));
            if (this.BarSearchDateTimeEnd.Checked)
                strSql += string.Format(" AND CreateTime<='{0}'", this.BarSearchDateTimeEnd.Value.ToString("yyyy-MM-dd"));
            //设置commbox搜索条件
            if (this.tsCombox.Text.Length > 0)
            {
                Common.MyEntity.SearchLabelItem shItem = this.ToolBarDropdownTitles_GetSearchLabelItem(this.tslTitle);
                if (shItem != null)
                {
                    if (shItem.Value == 6)
                    {
                        //读取电芯条码

                    }
                    else if (shItem.Value == 7)
                    {
                        //读取电芯条码

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
            foreach (int row in list)
            {
                frmMKDetail frm = new frmMKDetail(dt.DefaultView[row].Row["MKCode"].ToString());
                frm.ShowDialog(this);
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
                strCode = dt.DefaultView[row].Row["MKCode"].ToString();
                try
                {
                    this.BllDAL.MKDelete(strCode, out iReturnValue, out strMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "MKDelete");
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
            frmMKDetail frm = new frmMKDetail(dt.DefaultView[e.RowIndex].Row["MKCode"].ToString());
            frm.ShowDialog(this);
        }

        private void tsCombox_KeyDown(object sender, KeyEventArgs e)
        {
            this.BindData();
        }

        private void tsbCompeleted_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (list.Count > 0)
            {
                if (!Common.CurrentUserInfo.IsAdmin && !Common.CurrentUserInfo.IsSuper)
                {
                    this.ShowMsg("只有管理员才能执行该操作。");
                    return;
                }
                if (!this.IsUserConfirm("您确定要处理选中数据吗？")) return;
            }
            else
            {
                this.ShowMsg("请选中要处理的数据。");
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
                    this.BllDAL.CompeletedTest(strCode, out iReturnValue, out strMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "CompeletedTesting");
                    break;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg.Length == 0)
                        strMsg = "处理失败，原因未知。";
                    this.ShowMsg(strMsg);
                }
                blUpdted = true;
            }
            if (blUpdted)
                this.BindData();
        }

        private void tsbOutputExcel_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if(list.Count==0)
            {
                this.ShowMsg("请选中要导出的批次。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            foreach (int row in list)
            {
                DataRow dr = dt.DefaultView[row].Row;
                ExpFuns.frmCSVTestResult frm = new ExpFuns.frmCSVTestResult(dr["Code"].ToString(), dr["BatterysTable"].ToString(), dr["ResultTable"].ToString());
                frm.ShowDialog(this);
            }
        }
    }
}