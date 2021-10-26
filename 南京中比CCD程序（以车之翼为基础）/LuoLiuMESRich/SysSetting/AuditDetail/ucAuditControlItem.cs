using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SysSetting.AuditDetail
{
    public partial class ucAuditControlItem : System.Windows.Forms.UserControl
    {
        public ucAuditControlItem()
        {
            InitializeComponent();
        }
        #region 事件
        /// <summary>
        /// 审批状态改变事件
        /// </summary>
        public event AuditItemChangedHandler AuditItemChangedEvent;
        public event WaitAuditerSelect WaitAuditerSelectEvent;
        #endregion
        #region 属性
        private Common.MyEntity.AuditItem _item = null;
        public Common.MyEntity.AuditItem AuditItem
        {
            get
            {
                if (this._item == null)
                    this._item = new Common.MyEntity.AuditItem();
                this._item.AuditNote = this.tbAuditNote.Text;
                int istate;
                if (this.rbPass.Checked) istate = 1;
                else if (this.rbReject.Checked) istate = 2;
                else istate = 0;
                if (this._item.AuditState != istate)
                {
                    //状态发生改变后要记录操作人
                    this._item.Auditer = Common.CurrentUserInfo.UserCode;
                    this._item.AuditerName = Common.CurrentUserInfo.UserName;
                    DateTime detNow;
                    if (!Common.CommonFuns.GetSysCurrentDateTime(out detNow))
                    {
                        MessageBox.Show(this,"系统时间获取错误","系统出错",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return null;
                    }
                    this._item.AuditDate = detNow;
                    this._item.AuditState = istate;
                }
                if (this._item.WaitAuditer != this.WaitAuditer)
                    this._item.WaitAuditer = this.WaitAuditer;
                if (this._item.WaitAuditerName != this.WaitAuditerName)
                    this._item.WaitAuditerName = this.WaitAuditerName;
                return this._item; 
            }
            set
            {
                this._item = value;
                if (_item == null)
                {
                    this.SetItem(-1, string.Empty, string.Empty, string.Empty, -1, 
                        string.Empty, string.Empty, null, string.Empty, false);
                    this.AllowEditWaitAuditer = false;
                }
                else
                {
                    this.SetItem(this._item.SortID, this._item.FlowName, this._item.WaitAuditer, this._item.WaitAuditerName,
                        this._item.AuditState, this._item.Auditer, this._item.AuditerName, this._item.AuditDate, this._item.AuditNote
                        , this._item.AllowAudit);
                    this.AllowEditWaitAuditer = this._item.AllowEditWaiter;
                }
            }
        }
        private int _SortID = 1;
        public int SortID
        {
            get { return this._SortID; }
            set { this._SortID = value; }
        }
        public string FlowName
        {
            get { return this.labFlowName.Text; }
            set { this.labFlowName.Text = value; }
        }
        private string _WaitAuditer = string.Empty;
        public string WaitAuditer
        {
            get { return this._WaitAuditer; }
            set { this._WaitAuditer = value; }
        }
        public string WaitAuditerName
        {
            get { return this.tbWaitAuditerName.Text; }
            set { this.tbWaitAuditerName.Text = value; }
        }
        private int _AuditState;
        public int AuditState
        {
            get
            {
                return this._AuditState;
            }
            set
            {
                if (value == 1)
                {
                    this.rbPass.Checked = true;
                    this._AuditState = 1;
                }
                else if (value == 2)
                {
                    this.rbReject.Checked = true;
                    this._AuditState = 2;
                }
                else
                {
                    this.rbWait.Checked = true;
                    this._AuditState = 0;
                }
            }
        }
        private string _Auditer = string.Empty;
        public string Auditer
        {
            get { return this._Auditer; }
            set { this._Auditer = value; }
        }
        public string AuditerName
        {
            get { return this.tbAuditerName.Text; }
            set { this.tbAuditerName.Text = value; }
        }
        public object AuditDate
        {
            get
            {
                DateTime det;
                if (!DateTime.TryParse(this.tbAuditDate.Text, out det))
                    return DBNull.Value;
                return det;
            }
            set
            {
                if (value == null || value.Equals(DBNull.Value))
                    this.tbAuditDate.Text = string.Empty;
                else
                    this.tbAuditDate.Text =Common.CommonFuns.FormatData.GetStringByDateTime(value, "yyyy-MM-dd HH:mm");
            }
        }
        public string AuditNote
        {
            get { return this.tbAuditNote.Text; }
            set { this.tbAuditNote.Text = value; }
        }
        public bool AllowAudit
        {
            get
            {
                return this.rbWait.Enabled;
            }
            set
            {
                this.rbPass.Enabled = value;
                this.rbReject.Enabled = value;
                this.rbWait.Enabled = value;
                this.tbAuditNote.ReadOnly = !value;
            }
        }
        /// <summary>
        /// 是否能编辑待审批人
        /// </summary>
        public bool AllowEditWaitAuditer
        {
            get { return this.llabWaitAuditer.Enabled; }
            set { this.llabWaitAuditer.Enabled = value; }
        }
        #endregion
        #region 设置控件属性
        public void SetItem(int iSortID, string strFlowName, string strWaitAuditer, string strWaitAuditerName, int iAuditState, string strAuditer, string strAuditerName, object dtAuditDate, string strAuditNote, bool bAllowAudit)
        {
            this.FlowName = strFlowName;
            this.SortID = iSortID;
            this.FlowName = strFlowName;
            this.WaitAuditer = strWaitAuditer;
            this.WaitAuditerName = strWaitAuditerName;
            this.AuditState = iAuditState;
            this.Auditer = strAuditer;
            this.AuditerName = strAuditerName;
            this.AuditDate = dtAuditDate;
            this.AuditNote = strAuditNote;
            this.AllowAudit = bAllowAudit;
        }
        #endregion
        #region 点击更改状态
        //通过
        private void rbPass_Click(object sender, EventArgs e)
        {
            
        }
        //拒绝
        private void rbReject_Click(object sender, EventArgs e)
        {
            if (this._AuditState != 2)
            {
                this._AuditState = 2;
                if (this.AuditItemChangedEvent != null)
                    this.AuditItemChangedEvent(this, 2);
            }
        }
        //待签
        private void rbWait_Click(object sender, EventArgs e)
        {
            if (this._AuditState != 0)
            {
                this._AuditState = 0;
                if (this.AuditItemChangedEvent != null)
                    this.AuditItemChangedEvent(this, 0);
            }
        }
        #endregion
        #region 选择待审批人
        private void llabWaitAuditer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SysSetting.DeptUsers.frmSelectUserSample frm = new SysSetting.DeptUsers.frmSelectUserSample();
            frm.SelectedUserCodes = this.WaitAuditer;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            this.WaitAuditer = frm.SelectedUserCodes;
            this.WaitAuditerName = frm.SelectedUserNames;
        }
        #endregion
    }
    #region 事件代理
    /// <summary>
    /// 审批状态改变事件
    /// </summary>
    /// <param name="iAuditState">0待审、1通过、2拒绝</param>
    public delegate void AuditItemChangedHandler(object sender,int iAuditState);
    /// <summary>
    /// 选择待审批人
    /// </summary>
    /// <param name="sender"></param>
    public delegate void WaitAuditerSelect(object sender);
    #endregion
}
