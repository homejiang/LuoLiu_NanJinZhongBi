using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MyEnums
{
    #region 系统包含的模块
    /// <summary>
    /// 本系统中的所有模块
    /// </summary>
    public enum Modules
    {
        //[1~10000]
        /// <summary>
        /// 未设置模块
        /// </summary>
        None = -1,
        #region 系统设置
        /// <summary>
        /// 模块设置
        /// </summary>
        ModuleSetting = 0,
        /// <summary>
        /// 部门及用户管理
        /// </summary>
        DeptAndUser = 1,
        /// <summary>
        /// 用户权限组编辑
        /// </summary>
        PowerGroup = 2,
        /// <summary>
        /// 自动编码
        /// </summary>
        AutoCode = 3,
        /// <summary>
        /// 模块审批设置
        /// </summary>
        ModuleAuditSetting = 4,
        /// <summary>
        /// 系统自定义模块设置模块组
        /// </summary>
        AutoExe_SysGroup = 5,
        /// <summary>
        /// 系统自定义模块设置打开窗体
        /// </summary>
        AutoExe_SysForms = 6,
        #endregion
        #region 基础信息设置模块
        /// <summary>
        /// 计量单位
        /// </summary>
        Unit = 7,
        /// <summary>
        /// 原材料类
        /// </summary>
        MaterialClass = 8,
        /// <summary>
        /// 原材料基础信息
        /// </summary>
        Material = 9,
        ///<summary>
        ///供应商
        ///</summary>
        Supplier = 10,
        /// <summary>
        /// 公司信息
        /// </summary>
        MyCompany = 11,
        /// <summary>
        /// 国家信息
        /// </summary>
        CountryAndProvince = 12,
        /// <summary>
        /// 仓库信息
        /// </summary>
        Storage = 13,
        /// <summary>
        /// 联系人
        /// </summary>
        Contacters = 14,
        /// <summary>
        /// 原材料型号
        /// </summary>
        MaterialSpec = 15,
        ///<summary>
        ///客户信息
        ///</summary>
        Client = 16,
        ///<summary>
        ///省份信息
        ///</summary>
        Province = 17,
        /// <summary>
        /// 临时存储区域管理
        /// </summary>
        TempArea = 18,
        /// <summary>
        /// 半成品存储仓库
        /// </summary>
        SFGStorage = 19,
        /// <summary>
        /// 贸易方式
        /// </summary>
        TradeMode = 20,
        /// <summary>
        /// 付款方式
        /// </summary>
        PaymentTerm = 21,
        /// <summary>
        /// BOM
        /// </summary>
        BOM = 22,
        /// <summary>
        /// 工序
        /// </summary>
        Process = 23,
        /// <summary>
        /// 机台
        /// </summary>
        ProcessMacs = 24,
        /// <summary>
        /// 设备异常内容编辑
        /// </summary>
        MacBreakdownCase = 25,
        /// <summary>
        /// 设备异常单管理
        /// </summary>
        MacBreakdown = 26,
        Jobs = 27,
        /// <summary>
        ///  工厂代码
        /// </summary>
        FactoryCode = 28,
        //电池组类型是全新的还是回收的
        PackTypeCode=29,
        /// <summary>
        /// 保护板检测
        /// </summary>
        PCBManage=30,
        /// <summary>
        /// EOL检测
        /// </summary>
        EOLManage = 31,
        /// <summary>
        /// 报废
        /// </summary>
        BaoFeiManage = 32,
        #endregion
        #region 订单模块100~200
        /// <summary>
        /// 订单管理
        /// </summary>
        PactManager = 100,
        /// <summary>
        /// 计划管理
        /// </summary>
        PlanManager = 101,
        /// <summary>
        /// 入库管理
        /// </summary>
        InStorage = 150,
        /// <summary>
        /// 报废管理
        /// </summary>
        Remove = 151,
        #endregion
        #region 装箱管理
        /// <summary>
        /// 装箱管理，如果包含删除功能的话，则可以删除已装托的托盘号，该权限较高
        /// </summary>
        Boxing =201,
        /// <summary>
        /// 托盘类型
        /// </summary>
        BoxType=202,
        /// <summary>
        /// 撤销托盘的结束状态，这个权限单独设定，因为撤销该状态后可以更改托盘数据了。项目为：编辑
        /// </summary>
        BoxingCancelCompeleted=203,
        #endregion
        /// <summary>
        /// 模块管理，只需删除权限即可
        /// </summary>
        MkManager = 251,
        /// <summary>
        /// 模块锁装
        /// </summary>
        EleCardComposing = 252,
        #region 点焊机
        DianHanPeiFang = 300,
        #endregion
    }
    #endregion
    #region 用户权限
    /// <summary>
    /// 用户操作权限
    /// </summary>
    public enum OperatePower
    {
        /// <summary>
        /// 新增权限
        /// </summary>
        New,
        /// <summary>
        /// 编辑功能
        /// </summary>
        Eidt,
        /// <summary>
        /// 删除
        /// </summary>
        Delete,
        /// <summary>
        /// 只读
        /// </summary>
        ReadOnly
    }
    #endregion
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
    #region 公共枚举
    public enum OTDRType
    {
        None = 0,
        AQ7275 = 1,
        AQ7280
    }
    #endregion
}
