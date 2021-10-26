using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common.MyInterface
{
    public interface IAuditDataDAL
    {
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="objPrimaryKeyValue">ģ��ؼ���ֵ</param>
        /// <param name="strUserCode">������Ա</param>
        /// <param name="dtAuditDetail">����������ϸ</param>
        /// <param name="iReturnValue">����ֵ��1Ϊ����ɹ�</param>
        /// <param name="sMsg">��Ϣ���������󲻳ɹ�ԭ��</param>
        void SendAudit(object objPrimaryKeyValue, string strUserCode, string strUserName, List<Common.MyEntity.AuditItem> listAuditItem, out int iReturnValue, out string sMsg);
        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="objPrimaryKeyValue">ģ��ؼ���ֵ</param>
        /// <param name="strUserCode">������Ա</param>
        /// <param name="iReturnValue">����ֵ��1Ϊ�����ɹ�</param>
        /// <param name="sMsg">��Ϣ�����ز������ɹ�ԭ��</param>
        void PassAudit(object objPrimaryKeyValue, string strUserCode, string strUserName, out int iReturnValue, out string sMsg);
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="objPrimaryKeyValue">ģ��ؼ���ֵ</param>
        /// <param name="strUserCode">���������û�����</param>
        /// <param name="iReturnValue">����ֵ��1Ϊ�����ɹ���������Ϊ���ɹ�</param>
        /// <param name="sMsg">��Ϣ�����س������ɹ�ԭ��</param>
        void CancelAudit(object objPrimaryKeyValue, string strUserCode, string strUserName, out int iReturnValue, out string sMsg);
        /// <summary>
        /// ִ����������
        /// </summary>
        /// <param name="objPrimaryKeyValue">ģ��ؼ���ֵ</param>
        /// <param name="listAuditItem">������ϸ</param>
        /// <param name="iAuditState">������������������״̬</param>
        /// <param name="strUserCode">�����˱���</param>
        /// <param name="strUserName">����������</param>
        /// <param name="iReturnValue">����ֵ��1Ϊ�����ɹ���������Ϊ���ɹ�</param>
        /// <param name="sMsg">��Ϣ�����س������ɹ�ԭ��</param>
        void Auditing(object objPrimaryKeyValue, List<Common.MyEntity.AuditItem> listAuditItem, int iAuditState, string strUserCode, string strUserName, out int iReturnValue, out string sMsg);
    }
}
