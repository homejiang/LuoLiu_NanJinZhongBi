using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace SysSetting.UserControl
{
    [Serializable]
    public partial class ucModuleAuditItem : System.Windows.Forms.UserControl
    {
        #region 公共事件
        public event ModuleAuditItemEventHandler ModuleAuditItemEvent = null;
        #endregion
        public ucModuleAuditItem()
        {
            InitializeComponent();
        }
        #region 公共属性
        int _iSortID = int.MinValue;
        /// <summary>
        /// 排序字段
        /// </summary>
        public int SortID
        {
            get { return this._iSortID; }
            set { this._iSortID = value; }
        }
        public string FlowName
        {
            get { return this.tbFlowName.Text.Trim(); }
            set { this.tbFlowName.Text = value; }
        }
        private string _strWaitAuditers = string.Empty;
        /// <summary>
        /// 待审批人员
        /// </summary>
        public string WaitAuditers
        {
            get { return this._strWaitAuditers; }
            set
            {
                this._strWaitAuditers = value;
            }
        }
        #endregion
        #region 公共方法
        public Common.MyEntity.ModuleAuditItem ModuleAuditItem
        {
            get
            {
                Common.MyEntity.ModuleAuditItem item = new Common.MyEntity.ModuleAuditItem();
                item.SortID = this.SortID;
                item.FlowName = this.FlowName;
                item.WaitAuditers = this.WaitAuditers;
                item.WaitAuditerNames = this.tbWaitAuditerNames.Text;
                return item;
            }
            set 
            {
                if (value != null)
                {
                    this.SortID = value.SortID;
                    this.FlowName = value.FlowName;
                    this.WaitAuditers = value.WaitAuditers;
                    this.tbWaitAuditerNames.Text = value.WaitAuditerNames;
                }
            }
        }
        #endregion
        #region 控件事件
        private void llabUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.ModuleAuditItemEvent!= null)
                this.ModuleAuditItemEvent(OperateType.Up, this.SortID);
        }
        private void llabDown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.ModuleAuditItemEvent != null)
                this.ModuleAuditItemEvent(OperateType.Down, this.SortID);
        }
        private void llabRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.ModuleAuditItemEvent != null)
                this.ModuleAuditItemEvent(OperateType.Delete, this.SortID);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.ModuleAuditItemEvent != null)
                this.ModuleAuditItemEvent(OperateType.SelectWaitAuditer, this.SortID);
        }
        #endregion
    }
    #region 操作类型枚举
    public enum OperateType
    {
        /// <summary>
        /// 上移
        /// </summary>
        Up,
        /// <summary>
        /// 下移
        /// </summary>
        Down,
        /// <summary>
        /// 移除
        /// </summary>
        Delete,
        /// <summary>
        /// 选择待审批人
        /// </summary>
        SelectWaitAuditer
    }
    #endregion
    #region 事件代理
    public delegate void ModuleAuditItemEventHandler(OperateType type, int iSortID);
    #endregion
}
