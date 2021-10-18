using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace AutoAssign.PeiFang
{
    public partial class frmPfList : Common.frmBaseList
    {
        #region 窗体数据连接实例
        private BLLDAL.PeiFang _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.PeiFang BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.PeiFang();
                return _dal;
            }
        }
        #endregion 
        public frmPfList()
        {
            InitializeComponent();
        }
        private bool Perinit()
        {
            this.dgvList.AutoGenerateColumns = false;
            #region 绑定过滤项目的下拉
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT dbo.GetModeView(1,1) as Mode1,dbo.GetModeView(1,1) as Mode2,dbo.GetModeView(0,1) as Mode3,dbo.GetModeView(0,0) as Mode4", "GetModeView"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT dbo.GetGongYiTypeName(1) as GongYiType1,dbo.GetGongYiTypeName(2) as GongYiType2", "GetGongYiTypeName"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM JC_Process where ISNULL(Terminated,0)=0", "JC_Process"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "过滤数据基础信息");
                return false;
            }
            foreach (DataRow dr in ds.Tables["JC_Process"].Rows)
            {
                this.tscProcessCode.Items.Add(dr["Code"].ToString());
            }
            if (ds.Tables["GetModeView"].Rows.Count > 0)
            {
                foreach (DataColumn dc in ds.Tables["GetModeView"].Columns)
                {
                    this.tscModeView.Items.Add(ds.Tables["GetModeView"].Rows[0][dc].ToString());
                }
            }
            if (ds.Tables["GetGongYiTypeName"].Rows.Count > 0)
            {
                foreach (DataColumn dc in ds.Tables["GetGongYiTypeName"].Columns)
                {
                    this.tscGongYi.Items.Add(ds.Tables["GetGongYiTypeName"].Rows[0][dc].ToString());
                }
            }
            #endregion
            #region 设置工具栏combox搜索标题
            //加载搜索项
            List<Common.MyEntity.SearchLabelItem> listSearchItem = new List<Common.MyEntity.SearchLabelItem>();
            Common.MyEntity.SearchLabelItem item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "配方名称";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "PeiFangName LIKE '%{0}%'";
            item.Value = 1;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "电芯规格";
            item.CanInput = true;
            item.DropdownItemsLoaded = false;
            item.UseLike = true;
            item.StringFormat = "ProductSpec LIKE '%{0}%'";
            item.Value = 2;
            listSearchItem.Add(item);
            ToolBarDropdownTitles_Bind(this.tslTitle, listSearchItem);
            #endregion
            return true;
        }
        private bool CheckUserPower()
        {
            if (!Common.CurrentUserInfo.IsAdmin)
            {
                this.ShowMsg("您不是管理员，不能操作。");
                return false;
            }
            return true;
        }
        public override void ToolBarDropdownTitlesClick_Pro(object objOrginal, object objNew)
        {
            Common.MyEntity.SearchLabelItem item = objNew as Common.MyEntity.SearchLabelItem;
            if (item == null) return;
            this.tscValue.Items.Clear();
            if (!item.DropdownItemsLoaded)
            {
                if (item.Value == 2)
                {
                    #region 加载产品规格
                    DataTable dtSpec;
                    try
                    {
                        dtSpec = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("SELECT Spec FROM JC_ProductSpec WHERE ISNULL(Terminated,0)=0");
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return;
                    }
                    List<string> listSpec = new List<string>();
                    foreach (DataRow dr in dtSpec.Rows)
                    {
                        if (dr["Spec"].ToString() == string.Empty) continue;
                        listSpec.Add(dr["Spec"].ToString());
                    }
                    item.DropdownItems = listSpec;
                    item.DropdownItemsLoaded = true;
                    #endregion
                }
            }
            if (item.DropdownItems != null)
            {
                foreach (string str in item.DropdownItems)
                    this.tscValue.Items.Add(str);
            }
            if (item.CanInput)
            {
                if (this.tscValue.DropDownStyle != ComboBoxStyle.DropDown)
                    this.tscValue.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                if (this.tscValue.DropDownStyle != ComboBoxStyle.DropDownList)
                    this.tscValue.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        private bool BindData()
        {
            string strSql = "SELECT * FROM V_PeiFang_Main_List WHERE 1=1";
            if(this.tscProcessCode.Text.Length>0)
            {
                strSql += string.Format(" and ProcessCode='{0}'", this.tscProcessCode.Text.Replace("'","''"));
            }
            if (this.tscGongYi.Text.Length > 0)
            {
                strSql += string.Format(" and GongYiTypeName='{0}'", this.tscGongYi.Text.Replace("'", "''"));
            }
            if (this.tscModeView.Text.Length > 0)
            {
                strSql += string.Format(" and ModeView='{0}'", this.tscModeView.Text.Replace("'", "''"));
            }
            if (this.tscValue.Text.Length > 0)
            {
                Common.MyEntity.SearchLabelItem shItem = this.ToolBarDropdownTitles_GetSearchLabelItem(this.tslTitle);
                if (shItem != null && shItem.StringFormat.Length > 0)
                {
                    strSql += string.Format(" AND " + shItem.StringFormat, this.tscValue.Text.Replace("'", "''"));
                }
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
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


        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (!CheckUserPower()) return;
            frmPeiFangEdit frm = new frmPeiFangEdit();
            frm.FormState = Common.MyEnums.FormStates.New;
            frm.FormParent = this;
            frm.Text = "新增配方";
            frm.Show(this);
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            bool blPower = Common.CurrentUserInfo.IsAdmin;
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            bool blUpdated = false;
            foreach (int row in list)
            {
                frmPeiFangEdit frm = new frmPeiFangEdit();
                frm.FormParent = this;
                if (blPower) frm.FormState = Common.MyEnums.FormStates.Edit;
                else frm.FormState = Common.MyEnums.FormStates.Readonly;
                frm._Guid = dt.DefaultView[row].Row["GUID"].ToString();
                frm.ShowDialog(this);
                if (frm._Updated) blUpdated = true;
            }
            if (blUpdated)
                this.BindData();
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (list.Count > 0)
            {
                if (!this.IsUserConfirm("您确定要删除选中数据吗？")) return;
            }
            List<string> listSql = new List<string>();
            string strGuid;
            int iReturnValue;
            string strMsg;
            bool blUpdted = false;
            foreach (int row in list)
            {
                strGuid = dt.DefaultView[row].Row["GUID"].ToString();
                try
                {
                    this.BllDAL.PeiFangDelete(strGuid, out iReturnValue, out strMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "PeiFangDelete");
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
            string strGuid = dt.DefaultView[e.RowIndex].Row["GUID"].ToString();
            frmPeiFangEdit frm = new frmPeiFangEdit();
            if (blPower) frm.FormState = Common.MyEnums.FormStates.Edit;
            else frm.FormState = Common.MyEnums.FormStates.Readonly;
            frm.FormParent = this;
            frm._Guid = strGuid;
            frm.ShowDialog(this);
            if (frm._Updated)
                this.BindData();
        }

        private void tstValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                BindData();
        }
        private void tscProcessCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                BindData();
        }

        private void tscGongYi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                BindData();
        }

        private void tscModeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                BindData();
        }
    }
}