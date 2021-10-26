using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoLiuEOLTest
{
    public partial class frmEOLTestDataList : Common.frmBaseList
    {
        public frmEOLTestDataList()
        {
            InitializeComponent();
        }
        #region  重写父类函数
        //重写搜索时间
        public override void DoBarSearch()
        {
            this.tsbSearch_Click(null, null);
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
                    #region 加载机台
                    DataTable dtMac;
                    try
                    {
                        dtMac = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT MacName,Code FROM JC_ProcessMacs WHERE ISNULL(Terminated,0)=0 AND ProcessCode=dbo.[Common_GetSysProcessCode](1) ORDER BY SortID ASC");
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return;
                    }
                    List<string> listMac = new List<string>();
                    foreach (DataRow dr in dtMac.Rows)
                    {
                        listMac.Add(dr["MacName"].ToString());
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
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            #region 设置工具栏日期控件
            DateTime detNow = Common.CommonFuns.FormatData.GetCurBanciStartTime();//获取当前班次起始时间
            this.BarSearchDateTimeStart.ShowCheckBox = false;
            this.BarSearchTimeStart.ShowCheckBox = false;
            this.BarSearchTimeEnd.ShowCheckBox = false;
            //设置起始时间
            this.BarSearchDateTimeStart.Checked = true;
            this.BarSearchDateTimeStart.Value = detNow;
            this.BarSearchTimeStart.Value = detNow;
            // 设置结束时间
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
            item.TitleName = "检测编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "Code LIKE '%{0}%'";
            item.Value = 2;
            listSearchItem.Add(item);
            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "保护板编号";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.StringFormat = "PcbCode like '%{0}%'";
            item.Value = 3;
            listSearchItem.Add(item);
            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "测试人员";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.StringFormat = "OperatorName like '%{0}%'";
            item.Value = 4;
            listSearchItem.Add(item);
            if (EOLConfig.MacName.Length == 0)
            {
                item = new Common.MyEntity.SearchLabelItem();
                item.TitleName = "机台";
                item.CanInput = true;
                item.DropdownItemsLoaded = false;
                item.StringFormat = "MacName LIKE '%{0}%'";
                item.Value = 5;
                listSearchItem.Add(item);
            }
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
          
            #endregion
            #region 设置combox回车事件
            this.SetBarSearchEnterKey(this.tsCombox);
            #endregion
            #region 设置当前机台号
            this.SetCurrentMacInfo();
            #endregion
            #region 绑定列表字段
            this.ShowDataGridViewSetting_BindColumn(this.dgvList, Common.MyEnums.Modules.EOLManage);
            #endregion
            this.dgvList.AutoGenerateColumns = false;
            return true;
        }
        private bool SetCurrentMacInfo()
        {

            if (EOLConfig.MacName.Length == 0)
            {
                this.tslCurrentMac.Text = "当前机台号:未设置";
                this.tslCurrentMac.ForeColor = Color.Red;
            }
            else
            {
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MacName FROM JC_ProcessMacs WHERE Code='{0}'", EOLConfig.MacCode.Replace("'", "''")), false);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count == 0)
                {
                    this.ShowMsg("系统设置的默认机台代码“" + EOLConfig.MacName + "”不存在或已经被删除。");
                    return false;
                }
                this.tslCurrentMac.Text = "当前机台号:" + dt.Rows[0]["MacName"].ToString();
                this.tslCurrentMac.ForeColor = Color.Blue;
            }
            return true;
        }
        private bool BindData()
        {
            string strSql;
            strSql = "SELECT * FROM [V_EOL_TestData_Cgy] WHERE 1=1";
            //设置生产机台号搜索
            if (EOLConfig.MacName.Length > 0)
                strSql += " AND (ISNULL(MacCode,'')='' OR MacCode='" + EOLConfig.MacCode.Replace("'", "''") + "')";
            //设置时间搜索
            strSql += string.Format(" AND StateTime>='{0} {1}'", this.BarSearchDateTimeStart.Value.ToString("yyyy-MM-dd"), this.BarSearchTimeStart.Value.ToString("HH:mm"));
            if (this.BarSearchDateTimeEnd.Checked)
            {
                strSql += string.Format(" AND StateTime<='{0} {1}'", this.BarSearchDateTimeEnd.Value.ToString("yyyy-MM-dd"), this.BarSearchTimeEnd.Value.ToString("HH:mm"));
            }
            //设置commbox搜索条件
            if (this.tsCombox.Text.Length > 0)
            {
                Common.MyEntity.SearchLabelItem shItem = this.ToolBarDropdownTitles_GetSearchLabelItem(this.tsDropTitle);
                if (shItem != null && shItem.StringFormat.Length > 0)
                {
                    strSql += string.Format(" AND " + shItem.StringFormat, this.tsCombox.Text.Replace("'", "''"));
                }
            }
            strSql += " ORDER BY SFGTypeName,PcbCode,StateTime DESC ";//按检测完成时间排序
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
            BindStatistic(dt);
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
        private void BindStatistic(DataTable dtSource)
        {

            this.labTotal.Text = string.Format("完成检测盘数：{0}", dtSource.DefaultView.Count.ToString("#,###,###,##0"));
        }
        private void OpenUpdateForm(int iRowIndex, DataTable dtList)
        {
            if (dtList == null) dtList = this.dgvList.DataSource as DataTable;
            if (dtList == null) return;
            if (iRowIndex >= dtList.DefaultView.Count) return;
            string strGuid = dtList.DefaultView[iRowIndex].Row["GUID"].ToString();
            string strEOLCode = dtList.DefaultView[iRowIndex].Row["Code"].ToString();
            int iSFGType =int.Parse(dtList.DefaultView[iRowIndex].Row["SFGType"].ToString());
            if (strGuid.Length == 0) return;
            frmEOLTestDataEdit frm = new frmEOLTestDataEdit();
            frm.FormParent = this;

            //校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.EOLManage, strEOLCode);
            if (listPower.Count == 0)
            {
                this.ShowMsg(string.Format("您没有权限打开EOL检测单“{0}”，因为你没有它的任何权限。", strEOLCode));
                return;
            }
            if (listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                frm.FormState = Common.MyEnums.FormStates.Edit;
                frm.Text = "EOL检测记录" + strEOLCode;
                frm.PrimaryValue = strGuid;
                frm.iSFGType = iSFGType;
                frm.TopMost = true;
                frm.ShowDialog();
                this.BindData();
            }
            else
            {
                frm.FormState = Common.MyEnums.FormStates.Readonly;
                frm.Text = string.Format("EOL检测记录{0}（只读）", strEOLCode);
                frm.PrimaryValue = strGuid;
                frm.iSFGType = iSFGType;
                frm.TopMost = true;
                //this.ShowChildForm(frm.Text, frm);
                if (DialogResult.OK != frm.ShowDialog(this))
                    return;
            }
        }
        #endregion
        #region 窗体加载
        private void frmEOLTestDataList_Load(object sender, EventArgs e)
        {
            if (!this.PerInit()) return;
            if (!this.BindData()) return;
        }

        #endregion
        #region 按钮控件

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            //校验数值
            MyControl.MyLabelEx.MyLabelItem item = this.BarSearchMyLabelEx.GetCurrentItem();
            this.BindData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
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
                this.OpenUpdateForm(this.dgvList.SelectedRows[i].Index, dt);
            }
        }

        private void dgvList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        #endregion

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            this.OpenUpdateForm(e.RowIndex, dt);
        }
    }
}
