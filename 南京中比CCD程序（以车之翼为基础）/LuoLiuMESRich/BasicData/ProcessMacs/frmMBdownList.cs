using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace BasicData.ProcessMacs
{
    public partial class frmMBdownList : Common.frmBaseList
    {
        public frmMBdownList()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.MacBreakdown _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.MacBreakdown BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.MacBreakdown();
                return _dal;
            }
        }
        #endregion
        #region 公共属性
        /// <summary>
        /// 默认工序
        /// </summary>
        public string DefaultProcess = string.Empty;
        /// <summary>
        /// 固定工序
        /// </summary>
        public bool FixProcess = false;
        /// <summary>
        /// 默认机台
        /// </summary>
        public string DefaultMac = string.Empty;
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            #region 设置工具栏日期控件
            this.BarSearchDateTimeStart.Value = DateTime.Now.AddMonths(-1);
            this.BarSearchDateTimeStart.Checked = true;
            this.BarSearchDateTimeEnd.Value = DateTime.Now;
            this.BarSearchDateTimeEnd.Checked = false;
            this.InsertDateTimePicker(this.toolStrip1, this.tslStartTime.Name, false);//插入日期控件
            #endregion
            #region 设置更多操作按钮
            List<Common.MyEntity.SearchButtonItem> listBarbuts = new List<Common.MyEntity.SearchButtonItem>();
            Common.MyEntity.SearchButtonItem barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "高级搜索";
            barbut.Value = 1;
            listBarbuts.Add(barbut);
            barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "列表字段显示";
            barbut.Value = 2;
            listBarbuts.Add(barbut);
            this.InsertMyButtons(this.toolStrip1, this.tsbSearch.Name, listBarbuts,true,true);//插入到搜索按钮后面
            this.BarSearchMyButtons.TitleChanged+=new MyControl.MyLabelExChageTitleEventHandler(BarSearchMyButtons_TitleChanged);
            #endregion
            #region 绑定列表字段
            this.ShowDataGridViewSetting_BindColumn(this.dgvList, Common.MyEnums.Modules.MacBreakdown);
            #endregion
            #region 绑定机台及工序
            if (this.DefaultMac.Length > 0)
            {
                #region 如果传入了机台要以机台为准
                DataTable dtMac = null;
                try
                {
                    dtMac = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select MacName,ProcessName,ProcessCode from V_JC_ProcessMacs where Code='{0}' AND isnull(Terminated,0)=0 order by Sortid asc", this.DefaultMac.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dtMac.Rows.Count == 0)
                {
                    this.ShowMsg("设备编码\"" + DefaultMac + "\"不存在或已经被删除。");
                    return false;
                }
                this.tscMac.ComboBox.DisplayMember = "Text";
                this.tscMac.ComboBox.ValueMember = "Value";
                this.tscMac.ComboBox.Items.Add(new Common.MyEntity.ComboBoxItem(dtMac.Rows[0]["MacName"].ToString(), DefaultMac));
                this.tscMac.SelectedIndex = 0;
                //设置工序
                this.tscProcess.ComboBox.DisplayMember = "Text";
                this.tscProcess.ComboBox.ValueMember = "Value";
                this.tscProcess.ComboBox.Items.Add(new Common.MyEntity.ComboBoxItem(dtMac.Rows[0]["ProcessName"].ToString(), dtMac.Rows[0]["ProcessCode"].ToString()));
                this.tscProcess.SelectedIndex = 0;
                #endregion
            }
            else
            {
                #region 绑定工序
                DataTable dtProcess = null;
                try
                {
                    dtProcess = Common.CommonDAL.DoSqlCommand.GetDateTable("select Code,ProcessName from JC_Process where isnull(Terminated,0)=0 order by Sortid asc");
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                this.tscProcess.ComboBox.DisplayMember = "Text";
                this.tscProcess.ComboBox.ValueMember = "Value";
                this.tscProcess.SelectedIndexChanged += new EventHandler(tscProcess_SelectedIndexChanged);
                int iSelIndex = -1;
                foreach (DataRow dr in dtProcess.Rows)
                {
                    if (string.Compare(this.DefaultProcess, dr["Code"].ToString(), true) == 0)
                        iSelIndex = this.tscProcess.ComboBox.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ProcessName"].ToString(), dr["Code"].ToString()));
                    else this.tscProcess.ComboBox.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ProcessName"].ToString(), dr["Code"].ToString()));
                }
                this.tscProcess.ComboBox.SelectedIndex = iSelIndex;
                this.tscProcess.ComboBox.Enabled = !this.FixProcess;
                #endregion
            }
            #endregion
            this.dgvList.AutoGenerateColumns = false;
            return true;
        }
        private bool BindData()
        {
            string strSql;
            strSql = "SELECT * FROM V_JC_MacBreakdown_List WHERE 1=1";
            //设置时间搜索
            if (this.BarSearchDateTimeStart.Checked)
                strSql += " AND StartTime>='" + this.BarSearchDateTimeStart.Value.ToString("yyyy-MM-dd") + "'";
            if (this.BarSearchDateTimeEnd.Checked)
                strSql += " AND StartTime<'" + this.BarSearchDateTimeEnd.Value.AddDays(1).ToString("yyyy-MM-dd") + "'";
            
            Common.MyEntity.ComboBoxItem item = this.tscMac.ComboBox.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item != null && item.Value != null && item.Value.ToString().Length > 0)
                strSql += string.Format(" AND MacCode='{0}'", item.Value.ToString().Replace("'", "''"));
            else
            {
                item = this.tscProcess.ComboBox.SelectedItem as Common.MyEntity.ComboBoxItem;
                if (item != null && item.Value != null && item.Value.ToString().Length > 0)
                    strSql += string.Format(" AND ProcessCode='{0}'", item.Value.ToString().Replace("'", "''"));
            }
            strSql += " ORDER BY StartTime DESC";//以倒序排列
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
        #endregion
        #region 工具栏事件
        //combox标题切换事件
        protected void BarSearchMyButtons_TitleChanged(MyControl.MyLabelEx.MyLabelItem originalItem, MyControl.MyLabelEx.MyLabelItem newItem)
        {
            Common.MyEntity.SearchButtonItem item = newItem.Tag as Common.MyEntity.SearchButtonItem;
            if (item == null) return;
            //根据value值，执行不同的功能
            if (item.Value == 2)
            {
                this.DataGridViewSetting(Common.MyEnums.Modules.MacBreakdown, this.dgvList);
            }
        }
        //新增按钮
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            //先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("你没有新建设备异常单的权限，如有需要请联系管理员开放该权限。");
                return;
            }
            if (this.DefaultMac.Length > 0)
            {
                #region 校验是否此机台还有停机维修的未结束
                DataTable dttemp;
                try
                {
                    dttemp = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC JC_MacBreakdown_CheckIsMacTerminated '','{0}','{1}'"
                        , this.DefaultMac.Replace("'", "''"), Common.CurrentUserInfo.UserCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (dttemp.Rows.Count > 0 && dttemp.Columns.Contains("ErrMsg"))
                {
                    this.ShowMsg(dttemp.Rows[0]["ErrMsg"].ToString());
                    return;
                }
                #endregion
            }
            frmMBdownEdit frm = new frmMBdownEdit();
            frm.MacCode = this.DefaultMac;
            frm.ProcessCode = this.DefaultProcess;
            frm.FormParent = this;
            frm.FormState = Common.MyEnums.FormStates.New;
            frm.Text = "新建设备异常单";
            frm.TopMost = true;
            frm.ShowDialog(this);
            if (frm.Updated)
                this.BindData();
            //this.ShowChildForm(frm.Text, frm);
        }
        //打开按钮
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (listPower.Count == 0)
            {
                this.ShowMsg("您没有该模块的任何权限。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strCode;
            //打开所有选中的行
            if (this.dgvList.SelectedRows.Count > _MaxOpenRows)
            {
                this.ShowMsg(string.Format("对不起，一次性最多只能打开{0}行数据。", _MaxOpenRows));
                return;
            }
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                if (strCode == string.Empty) continue;
                this.OpenEditForm(strCode);
            }
        }
        private void OpenEditForm(string sCode)
        {
            frmMBdownEdit frm = new frmMBdownEdit();
            frm.FormParent = this;
            frm.MacCode = this.DefaultMac;
            //校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown, sCode);
            if (listPower.Count == 0)
            {
                this.ShowMsg(string.Format("您没有设备异常单{0}的任何权限。", sCode));
                return;
            }
            if (listPower.Contains(Common.MyEnums.OperatePower.New) || listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                frm.FormState = Common.MyEnums.FormStates.Edit;
                frm.Text = "设备异常单" + sCode;
                frm.PrimaryValue = sCode;
            }
            else
            {
                frm.FormState = Common.MyEnums.FormStates.Readonly;
                frm.Text = string.Format("设备异常单{0}（只读）", sCode);
                frm.PrimaryValue = sCode;
            }
            frm.TopMost = true;
            frm.ShowDialog(this);
            if (frm.Updated)
                this.BindData();
        }
        //删除按钮
        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0 || DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的" + this.dgvList.SelectedRows.Count.ToString() + "条数据吗？此操作数据将不可恢复，确定要继续吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strCode;
            bool isDeleted = false;
            int iReturn;
            string sMsg;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown, strCode);
                if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
                {
                    this.ShowMsg(string.Format("您没有权限删除设备异常单“{0}”。", strCode));
                    continue;
                }
                try
                {
                    this.BllDAL.Detele(strCode, out sMsg, out iReturn);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturn != 1)
                {
                    if (sMsg.Length == 0)
                        sMsg = "设备异常单“" + strCode + "”删除不成功，但未能获取错误原因，可用与管理员联系查明原因。";
                    this.ShowMsg(sMsg);
                    continue;
                }
                else if (!isDeleted)
                    isDeleted = true;
            }
            if (isDeleted)
                this.BindData();
        }
        //关闭窗体
        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }
        //搜索按钮
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
        #endregion
        #region 窗体事件
        private void frmGPactList_Load(object sender, EventArgs e)
        {
            //先判断权限，用户只要有只读权限就可以打开
            // 先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (listPower.Count == 0)
            {
                this.ShowMsg("你没有权限查看此模块，窗口将自动关闭。");
                this.FormColse();
                return;
            }
            if (!this.PerInit()) return;
            if (!this.BindData()) return;
        }
        #endregion
        #region  重写父类函数
        /// <summary>
        /// 刷新当前窗口
        /// </summary>
        /// <returns></returns>
        public override bool RefreshParetForm(object objArg)
        {
            return this.BindData();
        }
        //重写搜索时间
        public override void DoBarSearch()
        {
            this.tsbSearch_Click(null, null);
        }
        public override void InitParameters(string[] arrs)
        {
            this.DefaultProcess = arrs[0];
        }
        #endregion
        #region 主列表事件
        //双击事件
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            string strCode = dt.DefaultView[e.RowIndex].Row["Code"].ToString();
            if (strCode.Length == 0) return;
            this.OpenEditForm(strCode);
        }
        #endregion

        private void tscProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strProcessCode = string.Empty;
            Common.MyEntity.ComboBoxItem item = this.tscProcess.ComboBox.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null)
                strProcessCode = string.Empty;
            else strProcessCode = item.Value.ToString();
            string strSql;
            if (strProcessCode.Length == 0)
                strSql = "SELECT Code,MacName FROM JC_ProcessMacs  WHERE isnull(Terminated,0)=0 ORDER BY SortID";
            else strSql = string.Format("SELECT Code,MacName FROM JC_ProcessMacs  WHERE ProcessCode='{0}' AND isnull(Terminated,0)=0 ORDER BY SortID", strProcessCode.Replace("'", "''"));
            DataTable dtMac = null;
            try
            {
                dtMac = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.tscMac.Items.Clear();
            this.tscMac.ComboBox.DisplayMember = "Text";
            this.tscMac.ComboBox.ValueMember = "Value";
            this.tscMac.ComboBox.Items.Add(new Common.MyEntity.ComboBoxItem("-所有机台-",""));
            foreach (DataRow dr in dtMac.Rows)
            {
                this.tscMac.ComboBox.Items.Add(new Common.MyEntity.ComboBoxItem(dr["MacName"].ToString(), dr["Code"].ToString()));
            }
            this.tscMac.SelectedIndex = 0;
        }
    }
}