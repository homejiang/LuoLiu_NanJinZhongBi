using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuDianHan.DataM
{
    public partial class frmDianHanHistory : Common.frmBaseList
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
        public frmDianHanHistory(string sMacCode)
        {
            InitializeComponent();
            this._MacCode = sMacCode;
        }
        public frmDianHanHistory()
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
            item.TitleName = "模块编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "PName like '%{0}%'";
            item.Value = 1;
            listSearchItem.Add(item);

            if (this._MacCode.Length == 0)
            {
                item = new Common.MyEntity.SearchLabelItem();
                item.TitleName = "作业机台";
                item.CanInput = true;
                item.DropdownItemsLoaded = false;
                item.UseLike = true;
                item.StringFormat = "MacName='{0}'";
                item.Value = 2;
                listSearchItem.Add(item);
            }
            ToolBarDropdownTitles_Bind(this.tslTitle, listSearchItem);
            #endregion
            if (this._MacCode.Length > 0)
            {
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select MacName from JC_ProcessMacs where Code='{0}'"
                        , this._MacCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                }
                if(dt!=null && dt.Rows.Count>0)
                {
                    this.labMacName.Text = string.Format("关联机台：{0}", dt.Rows[0]["MacName"]);
                }
            }
            else
            {
                this.labMacName.Visible = false;
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
            string strSql = "SELECT * FROM [V_Produce_SFG1_Process_DianHanHistory] WHERE 1=1";
            if (this._MacCode.Length > 0)
                strSql += string.Format(" AND MacCode='{0}'", this._MacCode.Replace("'", "''"));
            if (this.BarSearchDateTimeStart.Checked)
                strSql += string.Format(" AND StartTime>='{0}'", this.BarSearchDateTimeStart.Value.ToString("yyyy-MM-dd"));
            if (this.BarSearchDateTimeEnd.Checked)
                strSql += string.Format(" AND StartTime<'{0}'", this.BarSearchDateTimeEnd.Value.AddDays(1).ToString("yyyy-MM-dd"));
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
            strSql += " ORDER BY StartTime ASC ";
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
            frmDianHanPoints frm = new frmDianHanPoints(dt.DefaultView[e.RowIndex].Row["GUID"].ToString());
            frm.Show();
        }

        private void tsCombox_KeyDown(object sender, KeyEventArgs e)
        {
            this.BindData();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要打开的数据。");
                return;
            }
            if(list.Count>1)
            {
                this.ShowMsg("您只能选中一行数据。");
                return;
            }
            string strCode = dt.DefaultView[list[0]].Row["GUID"].ToString();
            frmDianHanPoints frm = new frmDianHanPoints(strCode);
            frm.Show();
        }
    }
}