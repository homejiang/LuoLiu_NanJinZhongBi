using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.BasicEntitys
{
    public class SysDefaultValues
    {
        #region 系统已经设置的单位
        /// <summary>
        /// 系统已经设置的单位
        /// </summary>
        public class SysUnits
        {
            /// <summary>
            /// 个
            /// </summary>
            public static string Ge = "sysGe";
            /// <summary>
            /// 米
            /// </summary>
            public static string M = "sysM";
            /// <summary>
            /// 千米
            /// </summary>
            public static string KM = "sysKm";
            /// <summary>
            /// 毫米
            /// </summary>
            public static string MM = "sysmm";
            /// <summary>
            /// 克
            /// </summary>
            public static string G = "sysg";
            /// <summary>
            /// 千克
            /// </summary>
            public static string KG = "sysKg";
            /// <summary>
            /// 吨
            /// </summary>
            public static string T = "sysT";
            /// <summary>
            /// 根
            /// </summary>
            public static string Gen = "sysGen";
        }
        public class SysUnitTypes
        {
            /// <summary>
            /// 长度单位
            /// </summary>
            public static string Length = "sys001";
            /// <summary>
            /// 质量单位
            /// </summary>
            public static string Weight = "sys002";
            /// <summary>
            /// 体积单位
            /// </summary>
            public static string Volume = "sys003";
            /// <summary>
            /// 其他单位
            /// </summary>
            public static string Other = "sys000";
        }
        #endregion
        #region 系统已经设置的币别
        /// <summary>
        /// 系统已经设置的币别
        /// </summary>
        public class SysCurr
        {
            /// <summary>
            /// 人民币
            /// </summary>
            public static string RMB = "sysrmb";
        }
        #endregion
        #region 系统已经设置的工序
        public class SysProcesses
        {
            /// <summary>
            /// 电芯入架工序
            /// </summary>
            public static string FixedDx = "01";
            /// <summary>
            /// CCD检测工序
            /// </summary>
            public static string CCD = "02";
            /// <summary>
            /// 焊接（正面）
            /// </summary>
            public static string HanJie_A = "04";
            /// <summary>
            /// 焊接(反面)
            /// </summary>
            public static string HanJie_B = "04_1";
        }
        #endregion
        #region 系统已经设置的原材料
        public class SysMaterial
        {
            
        }
        public class SysMaterialClass
        {
            /// <summary>
            /// 原材料分类：电芯
            /// </summary>
            public static string DianXin = "DianXin";
        }
        #endregion
        #region 系统已经设置的BOM产品组
        public class SysBOMProductClass
        {
            public static string MuKuai = "01";
            public static string MuZu = "02";
            public static string Package = "03";
        }
        #endregion
        #region 系统已经设置的BOMStructure的GUID
        public class SysBomStruGuid
        {
            public static string PerKg = "PerKg";
            public static string DxCnt = "DxCnt";
            public static string MuKuai_Length = "MuKuai_Length";
            public static string MuKuai_Width = "MuKuai_Width";
            public static string MuKuai_Height = "MuKuai_Height";
        }
        #endregion
    }
}
