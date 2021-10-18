using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MyEnums
{
    #region 窗体状态
    public enum FormStates
    {
        /// <summary>
        /// 新增
        /// </summary>
        New,
        /// <summary>
        /// 复制（目前系统中并不使用该状态，即便是复制操作，也是做为New处理）
        /// </summary>
        Copy,
        /// <summary>
        /// 编辑
        /// </summary>
        Edit,
        /// <summary>
        /// 只读
        /// </summary>
        Readonly,
        /// <summary>
        /// 无任何状态
        /// </summary>
        None
    }
    #endregion
}
