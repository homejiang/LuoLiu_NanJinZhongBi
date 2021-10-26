using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuDianHan.PeiFang
{
    public partial class frmPfList : Common.frmBaseList
    {
        #region 窗体数据连接实例
        private BLLDAL.HanJie _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.HanJie BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.HanJie();
                return _dal;
            }
        }
        #endregion 
        private string _MacCode = string.Empty;
        public frmPfList(string sMacCode)
        {
            InitializeComponent();
            this._MacCode = sMacCode;
            this.labMacName.Text = string.Format("关联机台:{0}", Config.MacName);
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
            item.TitleName = "配方名称";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "PName like '%{0}%'";
            item.Value = 1;
            listSearchItem.Add(item);

            if (this._MacCode.Length == 0)
            {
                item = new Common.MyEntity.SearchLabelItem();
                item.TitleName = "关联机台";
                item.CanInput = true;
                item.DropdownItemsLoaded = false;
                item.UseLike = true;
                item.StringFormat = "MacName='{0}'";
                item.Value = 2;
                listSearchItem.Add(item);
            }
            ToolBarDropdownTitles_Bind(this.tslTitle, listSearchItem);
            #endregion
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
                        dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select * from JC_ProcessMacs where ProcessCode='{0}' and isnull(Terminated,0)=0 order by SortID"
                            , BasicData.BasicEntitys.SysDefaultValues.SysProcesses.HanJie_A));
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return;
                    }
                    List<string> list = new List<string>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(dr["MacName"].ToString());
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
            string strSql = "SELECT * FROM [V_Mac_DianHan_PeiFang_List] WHERE 1=1";
            if (this._MacCode.Length > 0)
                strSql += string.Format(" AND MacCode='{0}'", this._MacCode.Replace("'", "''"));
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
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.Boxing);
            bool blPower = listPower.Contains(Common.MyEnums.OperatePower.New) || listPower.Contains(Common.MyEnums.OperatePower.Eidt) || listPower.Contains(Common.MyEnums.OperatePower.Delete);
            foreach (int row in list)
            {
                //DataRow dr = dt.DefaultView[row].Row;
                //frmBoxedData frm = new frmBoxedData();
                //frm.FormParent = this;
                //frm._Code = dr["Code"].ToString();
                //if (blPower)
                //    frm.FormState = Common.MyEnums.FormStates.Edit;
                //else frm.FormState = Common.MyEnums.FormStates.Readonly;
                //if (blPower)
                //    frm.Text = string.Format("托盘{0}数据", dr["Code"]);
                //else frm.Text = string.Format("托盘{0}数据(只读)", dr["Code"]);
                //this.ShowChildForm(frm.Text, frm);
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (list.Count > 0)
            {
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.DianHanPeiFang);
                if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
                {
                    this.ShowMsg("您没有删除点焊机配方的权限！");
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
            bool blUpdted = false;
            string strSql;
            foreach (int row in list)
            {
                strCode = dt.DefaultView[row].Row["GUID"].ToString();
                strSql = string.Format("delete from Mac_DianHan_PeiFang where guid='{0}';delete from Mac_DianHan_PeiFangPoints where guid = '{0}'", strCode.Replace("'", "''"));
                try
                {
                    Common.CommonDAL.DoSqlCommand.DoSql(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "DeleteData");
                    break;
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
            frmPfSendPLC frm = new frmPfSendPLC(dt.DefaultView[e.RowIndex].Row["GUID"].ToString());
            frm.Show();
        }

        private void tsCombox_KeyDown(object sender, KeyEventArgs e)
        {
            this.BindData();
        }
        
        private void tsbPrinter_Click(object sender, EventArgs e)
        {

        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.Boxing);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有安装托盘的权限！");
                return;
            }
            frmAddPf frm = new frmAddPf();
            //frm.Show();
            if (frm.ShowDialog(this) != DialogResult.OK) return;
            this.BindData();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要打开的配方。");
                return;
            }
            if(list.Count>1)
            {
                this.ShowMsg("您只能选中一个配方。");
                return;
            }
            string strCode = dt.DefaultView[list[0]].Row["GUID"].ToString();
            frmPfSendPLC frm = new frmPfSendPLC(strCode);
            frm.Show();
        }

        private void tsbOutputExcel_Click(object sender, EventArgs e)
        {
           
        }
    }
}