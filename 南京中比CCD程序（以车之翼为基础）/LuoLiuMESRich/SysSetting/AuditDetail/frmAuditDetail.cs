using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common.MyEnums;
namespace SysSetting.AuditDetail
{
    public partial class frmAuditDetail :Common.frmBase
    {
        const string ButtonTrueText = "确定送审";
        const string ButtonPassAuditText = "跳过审批流程";
        const string ButtonCancelSendAudit = "撤销送审";
        public event AuditDetailClickHandle OnClicks = null;
        public int ModuleNum = -1;
        public frmAuditDetail()
        {
            InitializeComponent();
        }
        #region 公共属性
        private List<Common.MyEntity.AuditItem> AuditDataSource
        {
            get
            {
                List<Common.MyEntity.AuditItem> list = new List<Common.MyEntity.AuditItem>();
                ucAuditControlItem ucItem;
                for (int i = 0; i < this.panDetail.Controls.Count; i++)
                {
                    ucItem = this.panDetail.Controls[this.GetItemControlName(i)] as ucAuditControlItem;
                    if (ucItem != null)
                    {
                        list.Add(ucItem.AuditItem);
                    }
                }
                return list;
            }
            set
            {
                #region 设置label控件
                if (value.Count >= 0)
                {
                    Label lab = this.panDetail.Controls["labTooltip"] as Label;
                    if (lab != null)
                        this.panDetail.Controls.Remove(lab);
                    this.btTrue.Text = ButtonTrueText;
                }
                #endregion
                #region 设置流程的可操作性能
                if (value == null) return;
                //设置是否允许审批
                bool blAudited = false;
                for (int i = value.Count; i > 0; i--)
                {
                    if (blAudited)
                        value[i-1].AllowAudit = false;//当下一流程已经做出审批时，此流程就不能再做审批操作了。
                    else
                    {
                        blAudited = value[i - 1].AuditState != 0;
                        //判断上移流程是否已经做出审批，如果未做出审批则当前流程也是不允许做审批的
                        if (i == 1)
                            value[i - 1].AllowAudit = true;//如果是第个审批行那肯定可以审批操作
                        else
                        {
                            value[i - 1].AllowAudit = value[i - 2].AuditState == 1;//如果存在前一个审批流程，那前一个审批流程必须是通过
                        }
                    }
                    if (value[i - 1].AllowAudit)
                    {
                        //如果可以做审批操作，那需要判断当前登录人是否有权限操作，目前的设计是必须为待审批人中的一员
                        string stemp = "|" + value[i - 1].WaitAuditer + "|";
                        value[i - 1].AllowAudit = stemp.ToUpper().IndexOf("|" + Common.CurrentUserInfo.UserCode.ToUpper() + "|") >= 0;
                    }
                }
                #endregion
                #region 加载子控件到窗体
                // 少补
                while (this.panDetail.Controls.Count < value.Count)
                {
                    ucAuditControlItem ucItem = new ucAuditControlItem();
                    ucItem.Left = 0;
                    ucItem.Top = this.panDetail.Controls.Count * ucItem.Height;
                    //子控件的命名必须按照一定的规则
                    ucItem.Name = this.GetItemControlName(this.panDetail.Controls.Count);
                    this.panDetail.Controls.Add(ucItem);
                }
                //多除
                while (this.panDetail.Controls.Count > value.Count)
                {
                    this.panDetail.Controls.RemoveAt(this.panDetail.Controls.Count - 1);//从后往前删除
                }
                //加载数据
                ucAuditControlItem uctemp;
                bool isAllowEdit = this.IsAllowEdit(this.AuditState);
                for (int i = 0; i < value.Count; i++)
                {
                    uctemp = this.panDetail.Controls[this.GetItemControlName(i)] as ucAuditControlItem;
                    uctemp.AllowEditWaitAuditer = isAllowEdit;
                    uctemp.AuditItem = value[i];
                }
                //设置窗体长度
                //设置窗体高度
                if (value.Count == 0 || value.Count == 1)
                    this.Height = 248;
                else if (value.Count == 2)
                    this.Height = 398;
                else
                {
                    this.Height = 548;
                    this.panDetail.AutoScroll = true;
                }
                #endregion
                #region 设置label控件
                if (value.Count == 0)
                {
                    //如果没有任何数据，则需要提示用户
                    Label lab = this.panDetail.Controls["labTooltip"] as Label;
                    if (lab == null)
                    {
                        lab = new Label();
                        lab.AllowDrop = true;
                        lab.Dock = System.Windows.Forms.DockStyle.Fill;
                        lab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        lab.ForeColor = System.Drawing.Color.Blue;
                        lab.Location = new System.Drawing.Point(0, 0);
                        lab.Name = "labTooltip";
                        lab.Size = new System.Drawing.Size(401, 117);
                        lab.TabIndex = 0;
                        lab.Text = "    尚未有审批流程，您可通过左下角按钮设置，并选择相应审批人，您也可以点击按钮“跳过审批流程”直接通过审批，但该操作将会以日志形式存入数据库。";
                        this.btTrue.Text = ButtonPassAuditText;
                        lab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.panDetail.Controls.Add(lab);
                    }
                }
                #endregion
            }
        }
        private string _strSendAuditer = string.Empty;
        /// <summary>
        /// 送审人编码
        /// </summary>
        public string SendAuditer
        {
            get { return this._strSendAuditer; }
            set
            {
                this._strSendAuditer = value;
            }
        }
        /// <summary>
        /// 获取和设置送审人名称
        /// </summary>
        public string SendAuditerName
        {
            get { return this.tbSendAuditerName.Text; }
            set 
            {
                this.tbSendAuditerName.Text = value;
            }
        }
        /// <summary>
        /// 设置送审时间
        /// </summary>
        public object SendAuditDate
        {
            get
            {
                DateTime det;
                if (!DateTime.TryParse(this.tbSendAuditDate.Text, out det))
                    return DBNull.Value;
                return det;
            }
            set
            {
                this.tbSendAuditDate.Text = Common.CommonFuns.FormatData.GetStringByDateTime(value, "yyyy-MM-dd HH:mm");
                
            }
        }
        /// <summary>
        /// 审批状态
        /// </summary>
        public string AuditStateView
        {
            get 
            {
                return this.tbAuditStateView.Text;
            }
            set
            {
                this.tbAuditStateView.Text = value;
            }
        }
        private int _iAuditState = int.MinValue;
        /// <summary>
        /// 获取和设置审批状态
        /// </summary>
        public int AuditState
        {
            get { return this._iAuditState; }
            set 
            {
                this._iAuditState = value;
            }
        }
        private int _module = 0;
        /// <summary>
        /// 模块对应的枚举值
        /// </summary>
        public int Module
        {
            get { return this._module; }
            set { this._module = value; ModuleNum = (int)value; }
        }
        private string _sUserCode = string.Empty;
        /// <summary>
        /// 当前操作用户
        /// </summary>
        public string CurrentUserCode
        {
            get { return this._sUserCode; }
            set { this._sUserCode = value; }
        }
        #endregion
        #region 修改审批流程操作
        //添加审批流程
        private void pbCreate_Click(object sender, EventArgs e)
        {
            List<Common.MyEntity.AuditItem> list = this.AuditDataSource;
            if (list == null) return;
            //先输入流程名称
            frmAddAuditItem frm = new frmAddAuditItem();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            Common.MyEntity.AuditItem auditItem = new Common.MyEntity.AuditItem();
            //流程名称
            auditItem.FlowName = frm.Title;
            auditItem.WaitAuditer = frm.SelectedUserCodes;
            auditItem.WaitAuditerName = frm.SelectedUserNames;
            //排序字段
            if (list.Count == 0)
                auditItem.SortID = 0;
            else
            {
                auditItem.SortID = list[list.Count - 1].SortID + 1;
            }
            auditItem.AllowEditWaiter = true;
            list.Add(auditItem);
            this.AuditDataSource = list;
        }
        //移除审批流程
        private void pbRemove_Click(object sender, EventArgs e)
        {
            List<Common.MyEntity.AuditItem> list = this.AuditDataSource;
            if (list == null || list.Count==0) return;
            Common.MyEntity.AuditItem item = list[list.Count - 1];
            if (item.AuditState > 0)
            {
                this.ShowMsg("最后一个审批流程已经做出相应审批，不能移除。");
                return;
            }
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要移除最后一个审批流程吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            list.Remove(item);
            this.AuditDataSource = list;
        }
        #endregion
        #region 处理函数
        /// <summary>
        /// 根据审批状态，和登录用户判断是否允许用户在编辑审批流程
        /// </summary>
        /// <param name="iAuditState"></param>
        /// <returns></returns>
        private bool IsAllowEdit(int iAuditState)
        {
            if (iAuditState == 0)
            {
                //还未送审的，则只要有新增或编辑权限就可以了
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(this.ModuleNum, this.PrimaryValue);
                return listPower != null && (listPower.Contains(OperatePower.New) || listPower.Contains(OperatePower.Eidt));
            }
            else return false;
        }
        private Common.MyEntity.AuditItem GetAuditItemBySortID(int iSortID)
        {
            if (this.AuditDataSource == null) return null;
            foreach (Common.MyEntity.AuditItem item in this.AuditDataSource)
            {
                if (item.SortID == iSortID) return item;
            }
            return null;
        }
        /// <summary>
        /// 设置编辑权限以及显示审批状态
        /// </summary>
        /// <param name="isAllowEdit"></param>
        /// <param name="iAuditState"></param>
        private void SetFormState(int iAuditState,bool isAllowAudit)
        {
            bool isAllowEdit = this.IsAllowEdit(iAuditState);
            this.pbCreate.Visible = isAllowEdit && iAuditState ==0;//当且仅当为送审时才能修改审批明细
            this.pbRemove.Visible = isAllowEdit && iAuditState == 0;//当且仅当为送审时才能修改审批明细
            this.btAudit.Visible = isAllowAudit;
            if (iAuditState == 0)
            {
                //只有为0时表示为送审
                this.btTrue.Text = this.AuditDataSource.Count > 0 ? ButtonTrueText : ButtonPassAuditText;
                this.btTrue.Visible = isAllowEdit;
            }
            else
            {
                this.btTrue.Text = ButtonCancelSendAudit;
                //只要送审之后，送审人任何状态下登录都可以撤销送审
                this.btTrue.Visible = this.SendAuditer.ToLower() == Common.CurrentUserInfo.UserCode.ToLower();
            }
            //设置显示信息
            if (iAuditState < 0)
                this.AuditStateView = "无需审批";
            else if (iAuditState == 0)
                this.AuditStateView = "未送审";
            else if (iAuditState == 1)
                this.AuditStateView = "已送审";
            else if (iAuditState == 2)
                this.AuditStateView = "审批中";
            else if (iAuditState == 3)
                this.AuditStateView = "审批通过";
            else if (iAuditState == 4)
                this.AuditStateView = "审批不通过";
            else
                this.AuditStateView = "未知状态";
            //调整按钮位置
            if (this.btTrue.Visible && this.btAudit.Visible)
            {
                //2个按钮都显示
                this.btTrue.Left = 90;
                this.btAudit.Left = 172;
                this.btClose.Left = 253;
            }
            else if(this.btTrue.Visible)
            {
                this.btTrue.Left = 125;
                this.btClose.Left = 220;
            }
            else
            {
                this.btAudit.Left = 125;
                this.btClose.Left = 220;
            }
        }
        /// <summary>
        /// 获取指定模块的默认审批流程
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        private List<Common.MyEntity.AuditItem> GetDefaultAuditItems(int iModule)
        {
            DataTable dt = null;
            string strSql = string.Format("SELECT A.*,B.EnumNo FROM Sys_ModuleAuditSetting A LEFT JOIN Sys_Module B ON A.ModuleCode=B.ModuleCode WHERE B.EnumNo={0}", iModule);
            try
            {
                dt =Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return null;
            }
            List<Common.MyEntity.AuditItem> listItem = new List<Common.MyEntity.AuditItem>();
            Common.MyEntity.AuditItem item;
            strSql = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Common.MyEntity.AuditItem();
                item.FlowName = dt.Rows[i]["FlowName"].ToString();
                item.SortID = (int)dt.Rows[i]["SortID"];
                item.WaitAuditer = dt.Rows[i]["WaitAuditer"].ToString();
                item.AllowEditWaiter = true;
                item.AllowAudit = false;
                listItem.Add(item);
                //获取查询审批人的字符窜
                strSql += string.Format("dbo.Common_GetWaitAuditerNames('{0}'),", item.WaitAuditer);
            }
            while (strSql.EndsWith(","))
                strSql = strSql.Substring(0, strSql.Length - 1);
            if (strSql.Length > 0)
            {
                strSql = string.Format("SELECT {0}", strSql);
                //获取数据
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return null;
                }
                for (int i = 0; i < listItem.Count; i++)
                {
                    listItem[i].WaitAuditerName = dt.Rows[0][i].ToString();
                }
            }
            return listItem;
        }
        /// <summary>
        /// 或获取已经存在的审批明细
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        private List<Common.MyEntity.AuditItem> GetAuditItems(int iModule)
        {
            DataTable dt = null;
            string strSql = string.Format("SELECT A.*,B.EnumNo FROM Sys_ModuleAuditDetail A LEFT JOIN Sys_Module B ON A.ModuleCode=B.ModuleCode WHERE B.EnumNo={0} AND PrimaryKeyValue='{1}'", iModule, this.PrimaryValue == null ? "" : this.PrimaryValue.ToString());
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return null;
            }
            List<Common.MyEntity.AuditItem> listItem = new List<Common.MyEntity.AuditItem>();
            Common.MyEntity.AuditItem item;
            strSql = string.Empty;
            bool isAllowEdit = this.IsAllowEdit(this.AuditState);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Common.MyEntity.AuditItem();
                item.FlowName = dt.Rows[i]["FlowName"].ToString();
                item.SortID = (int)dt.Rows[i]["SortID"];
                item.WaitAuditer = dt.Rows[i]["WaitAuditer"].ToString();
                item.WaitAuditerName = dt.Rows[i]["WaitAuditerName"].ToString();
                item.Auditer = dt.Rows[i]["Auditer"].ToString();
                item.AuditerName = dt.Rows[i]["AuditerName"].ToString();
                item.AuditNote = dt.Rows[i]["AuditNote"].ToString();
                item.AuditDate = dt.Rows[i]["AuditDate"];//审批日期
                item.AuditState = dt.Rows[i]["AuditState"].Equals(DBNull.Value) ? 0 : (int)dt.Rows[i]["AuditState"];
                //设置是否允许用户进行审批，允许：1、为待审批人；2、最后一级审批或者下移未做出审批
                //item.AllowAudit = item.IsWaiter(this.CurrentUserCode) && (i == dt.Rows.Count - 2 || dt.Rows[i + 1]["AuditState"].Equals(DBNull.Value) || (int)dt.Rows[i + 1]["AuditState"] == 0);
                //设置是否允许选贼待审批人，允许：1、当前状态为可编辑状态；2、待审状态
                item.AllowEditWaiter = isAllowEdit && (dt.Rows[i]["AuditState"].Equals(DBNull.Value) || (int)dt.Rows[i]["AuditState"] == 0);
                listItem.Add(item);
            }
            return listItem;
        }
        private string GetItemControlName(int index)
        {
            return string.Format("ucItem_{0}", index);
        }
        #endregion
        #region 按钮事件
        protected void btTrue_Click(object sender, EventArgs e)
        {
            bool blClose = true;
            if (this.OnClicks != null)
            {
                string sText = this.btTrue.Text.Trim();
                if (sText == ButtonTrueText)
                    this.OnClicks(ButtonType.True, this.AuditDataSource, 1, ref blClose);//表示送审
                else if (sText == ButtonPassAuditText)
                    this.OnClicks(ButtonType.PassAudit, null, -1, ref blClose);//跳过审核即为无需审核
                else if (sText == ButtonCancelSendAudit)
                    this.OnClicks(ButtonType.CancelSend, null, 0, ref blClose);//撤销送审
            }
            if (blClose)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        //待审批人做出审批后按此按钮来保存数据
        private void btAudit_Click(object sender, EventArgs e)
        {
            List<Common.MyEntity.AuditItem> list = this.AuditDataSource;
            bool blClose = true;
            if (this.OnClicks != null)
            {
                if (this.btTrue.Text == ButtonTrueText)
                {
                    bool blTempClose = false;
                    this.OnClicks(ButtonType.True, this.AuditDataSource, 1, ref blTempClose);//表示送审
                }
                //获取最总审批状态
                int iAuditState;
                if (list == null || list.Count == 0)
                    iAuditState = -1;//无需审批
                else
                {
                    iAuditState = 1;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].AuditState != 0)
                            iAuditState = 2;
                        if (list[i].AuditState == 2)
                        {
                            iAuditState = 4;
                            break;
                        }
                    }
                    //如果最后一个为审核通过，则为通过
                    if (list[list.Count - 1].AuditState == 1)
                        iAuditState = 3;
                }
                this.OnClicks(ButtonType.Audit, list, iAuditState, ref blClose);
            }
            if (blClose)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        #endregion
        #region 窗体OnLoad事件
        private void frmAuditDetail_Load(object sender, EventArgs e)
        {
            //初始化加载数据
            if (this.AuditState == 0)
            {
                //从系统中读取初始设置明细
                this.AuditDataSource = this.GetDefaultAuditItems(this.ModuleNum);
            }
            else if (this.AuditState > 0)
            {
                //已做出审批的则要读取审批明细信息
                this.AuditDataSource = this.GetAuditItems(this.ModuleNum);
            }
            //设置状态信息
            bool blAllowAudit = false;
            List<Common.MyEntity.AuditItem> listAudits=this.AuditDataSource;
            if (listAudits != null)
            {
                foreach (Common.MyEntity.AuditItem aidut in listAudits)
                {
                    if (aidut.AllowAudit)
                    {
                        blAllowAudit = true;
                        break;
                    }
                }
            }
            this.SetFormState(this.AuditState, blAllowAudit);
            //调整窗体在显示器中的高度和位置
            Rectangle rect = Screen.GetWorkingArea(this);
            if (rect.Size.Height < (this.Height + 40))
                this.Height = rect.Size.Height - 40;
            //剧中显示
            int itop = rect.Size.Height - this.Height;
            itop = itop / 2;
            this.Top = itop;
        }
        #endregion
    }
    public delegate void AuditDetailClickHandle(ButtonType button, List<Common.MyEntity.AuditItem> datasource, int iAuditState,ref bool closeForm);
    public enum ButtonType
    {
        /// <summary>
        /// 确认送审操作
        /// </summary>
        True=1,
        /// <summary>
        /// 撤销送审
        /// </summary>
        CancelSend=2,
        /// <summary>
        /// 跳过审批
        /// </summary>
        PassAudit=3,
        /// <summary>
        /// 待审批人做出审批后的保存事件
        /// </summary>
        Audit
    }
}