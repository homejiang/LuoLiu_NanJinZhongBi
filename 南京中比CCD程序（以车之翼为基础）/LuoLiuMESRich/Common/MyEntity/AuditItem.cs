using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MyEntity
{
    #region 审批类
    public class AuditItem
    {
        private int _iSortID = -1;
        /// <summary>
        /// 排序字段
        /// </summary>
        public int SortID
        {
            get { return this._iSortID; }
            set { this._iSortID = value; }
        }
        private string _strFlowName = string.Empty;
        /// <summary>
        /// 审批流程名
        /// </summary>
        public string FlowName
        {
            get { return this._strFlowName; }
            set { this._strFlowName = value; }
        }
        private string _strWaitAuditer = string.Empty;
        /// <summary>
        /// 待审批人编码，多人时以“|”分割
        /// </summary>
        public string WaitAuditer
        {
            get { return this._strWaitAuditer; }
            set { this._strWaitAuditer = value; }
        }
        private string _strAuditer = string.Empty;
        /// <summary>
        /// 审批人编码
        /// </summary>
        public string Auditer
        {
            get { return this._strAuditer; }
            set { this._strAuditer = value; }
        }
        private int _iAuditState = -1;
        /// <summary>
        /// 审批状态：0待审，1审核通过，2审核未通过。
        /// </summary>
        public int AuditState
        {
            get { return this._iAuditState; }
            set { this._iAuditState = value; }
        }
        private object _objAuditDate = null;
        /// <summary>
        /// 审批时间
        /// </summary>
        public object AuditDate
        {
            get { return this._objAuditDate; }
            set { this._objAuditDate = value; }
        }
        private string _strAuditNote = string.Empty;
        /// <summary>
        /// 审批说明
        /// </summary>
        public string AuditNote
        {
            get { return this._strAuditNote; }
            set { this._strAuditNote = value; }
        }
        private string _strWaitAuditerName = string.Empty;
        /// <summary>
        /// 待审批人名称，多人时以“、”分割
        /// </summary>
        public string WaitAuditerName
        {
            get { return this._strWaitAuditerName; }
            set { this._strWaitAuditerName = value; }
        }
        private string _strAuditerName = string.Empty;
        /// <summary>
        /// 审批人名称
        /// </summary>
        public string AuditerName
        {
            get { return this._strAuditerName; }
            set { this._strAuditerName = value; }
        }
        private bool _blAllowAudit = false;
        /// <summary>
        /// 是否允许审批
        /// </summary>
        public bool AllowAudit
        {
            get { return this._blAllowAudit; }
            set { this._blAllowAudit = value; }
        }
        private bool _blAllowEditWaiter = false;
        /// <summary>
        /// 是否允许审批
        /// </summary>
        public bool AllowEditWaiter
        {
            get { return this._blAllowEditWaiter; }
            set { this._blAllowEditWaiter = value; }
        }
        /// <summary>
        /// 判断sUser是否为待审人员
        /// </summary>
        /// <param name="sUser"></param>
        /// <returns></returns>
        public bool IsWaiter(string sUser)
        {
            string str = "|" + this.WaitAuditer + "|";
            return str.ToLower().IndexOf("|" + sUser + "|") >= 0;
        }
    }
    #endregion
}
