using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MyEntity
{
    #region ������
    public class AuditItem
    {
        private int _iSortID = -1;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        public int SortID
        {
            get { return this._iSortID; }
            set { this._iSortID = value; }
        }
        private string _strFlowName = string.Empty;
        /// <summary>
        /// ����������
        /// </summary>
        public string FlowName
        {
            get { return this._strFlowName; }
            set { this._strFlowName = value; }
        }
        private string _strWaitAuditer = string.Empty;
        /// <summary>
        /// �������˱��룬����ʱ�ԡ�|���ָ�
        /// </summary>
        public string WaitAuditer
        {
            get { return this._strWaitAuditer; }
            set { this._strWaitAuditer = value; }
        }
        private string _strAuditer = string.Empty;
        /// <summary>
        /// �����˱���
        /// </summary>
        public string Auditer
        {
            get { return this._strAuditer; }
            set { this._strAuditer = value; }
        }
        private int _iAuditState = -1;
        /// <summary>
        /// ����״̬��0����1���ͨ����2���δͨ����
        /// </summary>
        public int AuditState
        {
            get { return this._iAuditState; }
            set { this._iAuditState = value; }
        }
        private object _objAuditDate = null;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public object AuditDate
        {
            get { return this._objAuditDate; }
            set { this._objAuditDate = value; }
        }
        private string _strAuditNote = string.Empty;
        /// <summary>
        /// ����˵��
        /// </summary>
        public string AuditNote
        {
            get { return this._strAuditNote; }
            set { this._strAuditNote = value; }
        }
        private string _strWaitAuditerName = string.Empty;
        /// <summary>
        /// �����������ƣ�����ʱ�ԡ������ָ�
        /// </summary>
        public string WaitAuditerName
        {
            get { return this._strWaitAuditerName; }
            set { this._strWaitAuditerName = value; }
        }
        private string _strAuditerName = string.Empty;
        /// <summary>
        /// ����������
        /// </summary>
        public string AuditerName
        {
            get { return this._strAuditerName; }
            set { this._strAuditerName = value; }
        }
        private bool _blAllowAudit = false;
        /// <summary>
        /// �Ƿ���������
        /// </summary>
        public bool AllowAudit
        {
            get { return this._blAllowAudit; }
            set { this._blAllowAudit = value; }
        }
        private bool _blAllowEditWaiter = false;
        /// <summary>
        /// �Ƿ���������
        /// </summary>
        public bool AllowEditWaiter
        {
            get { return this._blAllowEditWaiter; }
            set { this._blAllowEditWaiter = value; }
        }
        /// <summary>
        /// �ж�sUser�Ƿ�Ϊ������Ա
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
