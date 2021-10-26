using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MyEntity
{
    [Serializable]
    public class ModuleAuditItem
    {
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
        private string _strFlowName = string.Empty;
        /// <summary>
        /// 审批流程名
        /// </summary>
        public string FlowName
        {
            get { return this._strFlowName; }
            set { this._strFlowName = value; }
        }
        private string _strWaitAuditers = string.Empty;
        /// <summary>
        /// 待审批人员编码
        /// </summary>
        public string WaitAuditers
        {
            get { return this._strWaitAuditers; }
            set
            {
                this._strWaitAuditers = value;
            }
        }
        private string _strWaitAuditerNames = string.Empty;
        /// <summary>
        /// 待审批人员姓名
        /// </summary>
        public string WaitAuditerNames
        {
            get { return this._strWaitAuditerNames; }
            set
            {
                this._strWaitAuditerNames = value;
            }
        }
        #endregion
    }
}
