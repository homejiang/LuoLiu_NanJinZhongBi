using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common.MyInterface
{
    public interface IAuditDataDAL
    {
        /// <summary>
        /// 送审
        /// </summary>
        /// <param name="objPrimaryKeyValue">模块关键字值</param>
        /// <param name="strUserCode">送审人员</param>
        /// <param name="dtAuditDetail">审批流程明细</param>
        /// <param name="iReturnValue">返回值，1为送审成功</param>
        /// <param name="sMsg">消息，返回送审不成功原因</param>
        void SendAudit(object objPrimaryKeyValue, string strUserCode, string strUserName, List<Common.MyEntity.AuditItem> listAuditItem, out int iReturnValue, out string sMsg);
        /// <summary>
        /// 调过审批操作
        /// </summary>
        /// <param name="objPrimaryKeyValue">模块关键字值</param>
        /// <param name="strUserCode">操作人员</param>
        /// <param name="iReturnValue">返回值，1为操作成功</param>
        /// <param name="sMsg">消息，返回操作不成功原因</param>
        void PassAudit(object objPrimaryKeyValue, string strUserCode, string strUserName, out int iReturnValue, out string sMsg);
        /// <summary>
        /// 撤销送审
        /// </summary>
        /// <param name="objPrimaryKeyValue">模块关键字值</param>
        /// <param name="strUserCode">撤销送审用户代码</param>
        /// <param name="iReturnValue">返回值，1为撤销成功，其他都为不成功</param>
        /// <param name="sMsg">消息，返回撤销不成功原因</param>
        void CancelAudit(object objPrimaryKeyValue, string strUserCode, string strUserName, out int iReturnValue, out string sMsg);
        /// <summary>
        /// 执行审批操作
        /// </summary>
        /// <param name="objPrimaryKeyValue">模块关键字值</param>
        /// <param name="listAuditItem">审批明细</param>
        /// <param name="iAuditState">本次审批操作后任务单状态</param>
        /// <param name="strUserCode">审批人编码</param>
        /// <param name="strUserName">审批人姓名</param>
        /// <param name="iReturnValue">返回值，1为撤销成功，其他都为不成功</param>
        /// <param name="sMsg">消息，返回撤销不成功原因</param>
        void Auditing(object objPrimaryKeyValue, List<Common.MyEntity.AuditItem> listAuditItem, int iAuditState, string strUserCode, string strUserName, out int iReturnValue, out string sMsg);
    }
}
