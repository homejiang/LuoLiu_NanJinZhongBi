using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common.MyInterface
{
    public interface IDataDAL
    {
        /// <summary>
        /// 保存传入的DataSet数据集
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strMsg">消息</param>
        /// <param name="iReturn">执行是否成功</param>
        void Save(DataSet ds, out string strMsg, out int iReturn);
  
        /// <summary>
        /// 移除传入的数据
        /// </summary>
        /// <param name="obj">数据行关键字</param>
        /// <param name="strMsg">消息</param>
        /// <param name="iReturn">执行是否成功</param>
        void Detele(object obj, out string strMsg, out int iReturn);

        /// <summary>
        /// 保存传入的DataSet数据集
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strMsg">消息</param>
        /// <param name="iReturn">执行是否成功</param>
        void SaveGroup(DataSet ds, out string strMsg, out int iReturn);

        /// <summary>
        /// 移除传入的数据
        /// </summary>
        /// <param name="obj">数据行关键字</param>
        /// <param name="strMsg">消息</param>
        /// <param name="iReturn">执行是否成功</param>
        void DeteleGroup(object obj, out string strMsg, out int iReturn);

    }
}
