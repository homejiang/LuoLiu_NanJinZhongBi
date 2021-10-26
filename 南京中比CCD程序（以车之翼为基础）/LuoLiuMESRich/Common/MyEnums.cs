using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MyEnums
{
    #region ϵͳ������ģ��
    /// <summary>
    /// ��ϵͳ�е�����ģ��
    /// </summary>
    public enum Modules
    {
        //[1~10000]
        /// <summary>
        /// δ����ģ��
        /// </summary>
        None = -1,
        #region ϵͳ����
        /// <summary>
        /// ģ������
        /// </summary>
        ModuleSetting = 0,
        /// <summary>
        /// ���ż��û�����
        /// </summary>
        DeptAndUser = 1,
        /// <summary>
        /// �û�Ȩ����༭
        /// </summary>
        PowerGroup = 2,
        /// <summary>
        /// �Զ�����
        /// </summary>
        AutoCode = 3,
        /// <summary>
        /// ģ����������
        /// </summary>
        ModuleAuditSetting = 4,
        /// <summary>
        /// ϵͳ�Զ���ģ������ģ����
        /// </summary>
        AutoExe_SysGroup = 5,
        /// <summary>
        /// ϵͳ�Զ���ģ�����ô򿪴���
        /// </summary>
        AutoExe_SysForms = 6,
        #endregion
        #region ������Ϣ����ģ��
        /// <summary>
        /// ������λ
        /// </summary>
        Unit = 7,
        /// <summary>
        /// ԭ������
        /// </summary>
        MaterialClass = 8,
        /// <summary>
        /// ԭ���ϻ�����Ϣ
        /// </summary>
        Material = 9,
        ///<summary>
        ///��Ӧ��
        ///</summary>
        Supplier = 10,
        /// <summary>
        /// ��˾��Ϣ
        /// </summary>
        MyCompany = 11,
        /// <summary>
        /// ������Ϣ
        /// </summary>
        CountryAndProvince = 12,
        /// <summary>
        /// �ֿ���Ϣ
        /// </summary>
        Storage = 13,
        /// <summary>
        /// ��ϵ��
        /// </summary>
        Contacters = 14,
        /// <summary>
        /// ԭ�����ͺ�
        /// </summary>
        MaterialSpec = 15,
        ///<summary>
        ///�ͻ���Ϣ
        ///</summary>
        Client = 16,
        ///<summary>
        ///ʡ����Ϣ
        ///</summary>
        Province = 17,
        /// <summary>
        /// ��ʱ�洢�������
        /// </summary>
        TempArea = 18,
        /// <summary>
        /// ���Ʒ�洢�ֿ�
        /// </summary>
        SFGStorage = 19,
        /// <summary>
        /// ó�׷�ʽ
        /// </summary>
        TradeMode = 20,
        /// <summary>
        /// ���ʽ
        /// </summary>
        PaymentTerm = 21,
        /// <summary>
        /// BOM
        /// </summary>
        BOM = 22,
        /// <summary>
        /// ����
        /// </summary>
        Process = 23,
        /// <summary>
        /// ��̨
        /// </summary>
        ProcessMacs = 24,
        /// <summary>
        /// �豸�쳣���ݱ༭
        /// </summary>
        MacBreakdownCase = 25,
        /// <summary>
        /// �豸�쳣������
        /// </summary>
        MacBreakdown = 26,
        Jobs = 27,
        /// <summary>
        ///  ��������
        /// </summary>
        FactoryCode = 28,
        //�����������ȫ�µĻ��ǻ��յ�
        PackTypeCode=29,
        /// <summary>
        /// ��������
        /// </summary>
        PCBManage=30,
        /// <summary>
        /// EOL���
        /// </summary>
        EOLManage = 31,
        /// <summary>
        /// ����
        /// </summary>
        BaoFeiManage = 32,
        #endregion
        #region ����ģ��100~200
        /// <summary>
        /// ��������
        /// </summary>
        PactManager = 100,
        /// <summary>
        /// �ƻ�����
        /// </summary>
        PlanManager = 101,
        /// <summary>
        /// ������
        /// </summary>
        InStorage = 150,
        /// <summary>
        /// ���Ϲ���
        /// </summary>
        Remove = 151,
        #endregion
        #region װ�����
        /// <summary>
        /// װ������������ɾ�����ܵĻ��������ɾ����װ�е����̺ţ���Ȩ�޽ϸ�
        /// </summary>
        Boxing =201,
        /// <summary>
        /// ��������
        /// </summary>
        BoxType=202,
        /// <summary>
        /// �������̵Ľ���״̬�����Ȩ�޵����趨����Ϊ������״̬����Ը������������ˡ���ĿΪ���༭
        /// </summary>
        BoxingCancelCompeleted=203,
        #endregion
        /// <summary>
        /// ģ�����ֻ��ɾ��Ȩ�޼���
        /// </summary>
        MkManager = 251,
        /// <summary>
        /// ģ����װ
        /// </summary>
        EleCardComposing = 252,
        #region �㺸��
        DianHanPeiFang = 300,
        #endregion
    }
    #endregion
    #region �û�Ȩ��
    /// <summary>
    /// �û�����Ȩ��
    /// </summary>
    public enum OperatePower
    {
        /// <summary>
        /// ����Ȩ��
        /// </summary>
        New,
        /// <summary>
        /// �༭����
        /// </summary>
        Eidt,
        /// <summary>
        /// ɾ��
        /// </summary>
        Delete,
        /// <summary>
        /// ֻ��
        /// </summary>
        ReadOnly
    }
    #endregion
    #region ����״̬
    public enum FormStates
    {
        /// <summary>
        /// ����
        /// </summary>
        New,
        /// <summary>
        /// ���ƣ�Ŀǰϵͳ�в���ʹ�ø�״̬�������Ǹ��Ʋ�����Ҳ����ΪNew����
        /// </summary>
        Copy,
        /// <summary>
        /// �༭
        /// </summary>
        Edit,
        /// <summary>
        /// ֻ��
        /// </summary>
        Readonly,
        /// <summary>
        /// ���κ�״̬
        /// </summary>
        None
    }
    #endregion
    #region ����ö��
    public enum OTDRType
    {
        None = 0,
        AQ7275 = 1,
        AQ7280
    }
    #endregion
}
