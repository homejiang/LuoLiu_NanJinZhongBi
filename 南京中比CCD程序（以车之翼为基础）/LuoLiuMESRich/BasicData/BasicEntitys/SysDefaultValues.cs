using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.BasicEntitys
{
    public class SysDefaultValues
    {
        #region ϵͳ�Ѿ����õĵ�λ
        /// <summary>
        /// ϵͳ�Ѿ����õĵ�λ
        /// </summary>
        public class SysUnits
        {
            /// <summary>
            /// ��
            /// </summary>
            public static string Ge = "sysGe";
            /// <summary>
            /// ��
            /// </summary>
            public static string M = "sysM";
            /// <summary>
            /// ǧ��
            /// </summary>
            public static string KM = "sysKm";
            /// <summary>
            /// ����
            /// </summary>
            public static string MM = "sysmm";
            /// <summary>
            /// ��
            /// </summary>
            public static string G = "sysg";
            /// <summary>
            /// ǧ��
            /// </summary>
            public static string KG = "sysKg";
            /// <summary>
            /// ��
            /// </summary>
            public static string T = "sysT";
            /// <summary>
            /// ��
            /// </summary>
            public static string Gen = "sysGen";
        }
        public class SysUnitTypes
        {
            /// <summary>
            /// ���ȵ�λ
            /// </summary>
            public static string Length = "sys001";
            /// <summary>
            /// ������λ
            /// </summary>
            public static string Weight = "sys002";
            /// <summary>
            /// �����λ
            /// </summary>
            public static string Volume = "sys003";
            /// <summary>
            /// ������λ
            /// </summary>
            public static string Other = "sys000";
        }
        #endregion
        #region ϵͳ�Ѿ����õıұ�
        /// <summary>
        /// ϵͳ�Ѿ����õıұ�
        /// </summary>
        public class SysCurr
        {
            /// <summary>
            /// �����
            /// </summary>
            public static string RMB = "sysrmb";
        }
        #endregion
        #region ϵͳ�Ѿ����õĹ���
        public class SysProcesses
        {
            /// <summary>
            /// ��о��ܹ���
            /// </summary>
            public static string FixedDx = "01";
            /// <summary>
            /// CCD��⹤��
            /// </summary>
            public static string CCD = "02";
            /// <summary>
            /// ���ӣ����棩
            /// </summary>
            public static string HanJie_A = "04";
            /// <summary>
            /// ����(����)
            /// </summary>
            public static string HanJie_B = "04_1";
        }
        #endregion
        #region ϵͳ�Ѿ����õ�ԭ����
        public class SysMaterial
        {
            
        }
        public class SysMaterialClass
        {
            /// <summary>
            /// ԭ���Ϸ��ࣺ��о
            /// </summary>
            public static string DianXin = "DianXin";
        }
        #endregion
        #region ϵͳ�Ѿ����õ�BOM��Ʒ��
        public class SysBOMProductClass
        {
            public static string MuKuai = "01";
            public static string MuZu = "02";
            public static string Package = "03";
        }
        #endregion
        #region ϵͳ�Ѿ����õ�BOMStructure��GUID
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
