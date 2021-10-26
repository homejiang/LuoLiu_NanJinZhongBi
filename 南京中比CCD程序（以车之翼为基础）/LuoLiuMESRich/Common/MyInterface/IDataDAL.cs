using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common.MyInterface
{
    public interface IDataDAL
    {
        /// <summary>
        /// ���洫���DataSet���ݼ�
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strMsg">��Ϣ</param>
        /// <param name="iReturn">ִ���Ƿ�ɹ�</param>
        void Save(DataSet ds, out string strMsg, out int iReturn);
  
        /// <summary>
        /// �Ƴ����������
        /// </summary>
        /// <param name="obj">�����йؼ���</param>
        /// <param name="strMsg">��Ϣ</param>
        /// <param name="iReturn">ִ���Ƿ�ɹ�</param>
        void Detele(object obj, out string strMsg, out int iReturn);

        /// <summary>
        /// ���洫���DataSet���ݼ�
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strMsg">��Ϣ</param>
        /// <param name="iReturn">ִ���Ƿ�ɹ�</param>
        void SaveGroup(DataSet ds, out string strMsg, out int iReturn);

        /// <summary>
        /// �Ƴ����������
        /// </summary>
        /// <param name="obj">�����йؼ���</param>
        /// <param name="strMsg">��Ϣ</param>
        /// <param name="iReturn">ִ���Ƿ�ɹ�</param>
        void DeteleGroup(object obj, out string strMsg, out int iReturn);

    }
}
