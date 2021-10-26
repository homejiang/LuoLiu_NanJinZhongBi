using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过下列属性集
// 控制。更改这些属性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("Common")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("futonggroup")]
[assembly: AssemblyProduct("Common")]
[assembly: AssemblyCopyright("版权所有 (C) futonggroup 2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 属性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("a02e93cb-3302-4415-b74b-3678a04de905")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      内部版本号
//      修订号
//
[assembly: AssemblyVersion("86.19.731.116")]
[assembly: AssemblyFileVersion("86.19.731.116")]
/*
 * 4.13.419.10：
 * 添加combobox滚轮禁用代码
 * 添加获取打印文件代码
 * 4.13.423.11：
 * 修改Excel导出路径（传入虚拟路径改为物理路径）
 * 添加获取公共模板函数
 * 4.13.427.12：
 * 传入数据连接字符窜和登陆人信息到ErrorService
 * 4.13.428.14：
 * 添加函数：CommonFuns.GetMacSign
 * 添加获取自动编码时包含前缀
 * 4.13.503.15：
 * 添加了函数：ShowChildForm(string strTitle, frmBase frmNew, bool blNew)
 * 4.13.510.16：
 * 报表添加统计显示
 * 4.13.510.17：
 *加宽了报表名称下拉框，避免显示不下全名
 * 4.13.511.18
 * 修改公共报表，有时间和无时间过滤合并在一起
 * 4.13.521.19：
 * 添加html报表
 * 4.13.521.20:
 * 4.13.521.19版本中关闭报表窗体时未删除报表文件
 * 4.13.524.21：
 * 报表选择时间时的bug，选择月份时读取的是工作日的值
 * 4.13.527.22:
 * 报表添加时间设置
 * 4.13.529.23：
 * 添加处理呆滞枚举
 * 4.13.718.25：
 * 添加班次设置的模块枚举
 * 4.13.727.26：
 * 添加枚举值:AutoExe_SysGroup、AutoExe_SysForms
 * 添加用户控件HTMLTextBox
 * 添加公共函数InitParameters， AutoExe需要用到
 * 4.13.802.27：
 * 设置CommonFuns.GetTextFromXml为公共函数
 * 添加静态函数AutoInitUser
 * 添加Report.frmReport2，单个报表模块
 * 4.13.829.28：
 * 添加仓库管理枚举值
 * 4.13.1012.29：
 * 添加枚举ZSFiberM_Storage_BsfReStore=99（本色纤在入库操作）
 * 4.13.1014.30：
 * 同步蝶缆
 * 4.13.1019.31：
 * 列表设置添加重写，可以传入DataGridView控件的实际路径
 * 4.13.1108.32
 * 添加分割蓝管模块的枚举
 * 4.13.1120.33：
 * 添加着色纤外购导入枚举
 * 4.13.1121.34：
 * 添加着色纤转自用枚举
 * 4.13.1122.35：
 * 添加打印机校验函数CommonFuns.CheckPrinter
 * 4.13.1126.36、4.13.1126.37：
 * 登录框上添加查找用户编码的链接
 * 4.13.1129.38：
 * 添加静态函数:CommonFuns.SaveSqlText
 * 4.13.1130.39：
 * 添加模块枚举:DieLanOM_Tested_ShelfEdit
 * 4.13.1223.40：
 * 添加静态函数：List<int> GetSelectedRows(System.Windows.Forms.DataGridView dgv)
 * 4.13.1230.41：
 * 添加枚举:ProcessChildSFGPro_DieLanOM = 717,
 * 4.14.106.42：
 * 蝶缆异常处理添加枚举1200~1203
 * 4.14.119.43：
 * 添加消息模块
 * 4.14.121.44：
 * 完善消息模块
 * 4.14.208.45：
 * 添加模块枚举DieLanOM_ERPGenius
 * 4.14.222.46：
 * Common.BLLDAL.Msg中添加存储日志的函数
 * 4.14.228.47：4.14.228.48：
 * 添加交接班模块
 * 4.14.313.49：
 * 修改日志提交函数SaveErpLog，添加参数iType
 * 4.14.324.50：
 * 添加静态函数Common.CommonConfig.GetDefaultExpInfoFolder()用于获取默认存放异常信息的文件路径
 * 4.14.404.51：
 * 添加半成品盘点枚举ERPGenius_Pd = 511
 * 4.14.418.52：
 * 添加EXCEL导出函数CommonFuns.DataGridViewToExcel
 * 4.14.422.53：
 * 添加公共模块Common.ProcessBar.frmProcessing用于打开进度条
 * 4.14.423.54：
 * 添加模块枚举ERPGenius_PdRemoveSFG = 512,用于盘点工具删除多余库存数据
 * 4.14.425.55：
 * 添加日志查看模块Common.Msg.frmMsgList2
 * 4.14.513.56：
 * 添加骨架槽、骨架缆工序枚举值
 * 添加GetURL的公共方法
 * 添加岗位枚举Jobs=30
 * 添加静态函数CommonFuns.AddPactDetailText用于RichTextBox添加文本
 * 4.14.605.57：
 * 添加静态函数CommonFuns.SFGTestingIsCompeleted用于校验检测完成时是否已经提交过，以防用于打开多个界面导致数据出错
 * 用户登录时添加日志，记录时间、ip、计算机名
 * 4.14.609.58：
 * 添加着色纤种类管理的枚举
 * 4.14.612.59：
 * 添加个公共处理方法ToolBarDropdownTitles_SetItemByValue
 * 4.14.620.60：
 * 新增杂工模块枚举ERPGenius_ZaGong
 * 4.14.624.61：
 * 添加GetURL函数，从数据库读取路径时传入本机IP地址，用于解决服务器多网卡问题
 * 4.14.626.62：
 * 调用更新文件时传递参数时将原传入此程序的参数放入<OriginalArgs>中传入update.exe中，此目的是为了处理pk8000等外部程序直接打开编辑界面并加载数据，更新完后
 * 还能直接打开编辑界面并加载原数据；
 * 4.14.626.63：
 * frmMdiBase中添加SetMdiCaption()，用于设置各个MDI窗体的标题
 * 4.14.630.64：
 * 添加声音提示路径：CommonConfig{SoundErr、SoundOk}
 * 添加播放声音的静态函数CommonFuns{PlayErrMsg、PlayOkMsg}
 * 4.14.712.65：
 * 添加枚举BanCiEdit_GJC\BanCiEdit_GJStrand
 * 4.14.903.66：
 * 添加静态函数，获取树控件的 Tag值
 * 1.14.1024.67：
 * 添加Common.CommonFuns.DataGridViewRowUp和Common.CommonFuns.DataGridViewRowDown
 * 1.14.1028.68：
 * GetOperatePower、GetGUID添加int参数，代替枚举Common.MyEnums.Modules
 * 1.14.1108.69：
 * 添加枚举：BOMM_EtcCable
 * 添加枚举：BOMStructure = 162,
 * 添加窗口拖拽的功能：Common.CommonFuns.FormMove
 * 1.14.1219.70：
 * 添加公共Excel导出模块：Common.OutputExcel.frmOutputExcel
 * 1.14.1225.71：
 * frmMainBase中添加“调用Timer”，可以通过AcitiveTimer调用timer控件解决控件获取焦点的问题
 * 1.15.123.72：
 * 添加静态函数：Common.CommonConfig.GetMyCompanyCode()，用一个字段来存储当前工厂代码，因所以工厂都用此程序，但毕竟工厂之间会有区别
 * 1.15.123.73：
 * 修改函数Common.OutputExcel.frmOutputExcel.OutputExcel，对应的存储过程原先只有一个参数type,现将参数值也传入；
 * 1.15.124.74：
 * 添加修改函数Common.OutputExcel.frmOutputExcel.OutputExcel重载，可以传入参数字段List<object> listArg
 * 1.15.129.75：
 * 添加枚举Common.MyEnums.Modules.BOMM_TaoSu
 * 1.15.129.76：
 * 添加枚举Common.MyEnums.Modules.ERPGenius_ExpandBOM
 * Common.ProcessBar.frmProcessing添加ShowText属性
 * 1.15.204.76：
 * 添加静态函数Common.CommonFuns.OpenWeb
 * 添加窗口Common.Codes.frmCodes，处理批量数据
 * 1.15.209.77：
 * 添加枚举PM_FGTuiKu\PM_FGTuiKuReason
 * 1.15.210.78：
 * 添加ucGongYiFiles，用于显示工艺文件
 * 1.15.304.79：
 * 添加模块枚举OSheathM_DeliveryNotice=255（发货通知单）,
 * 添加模块枚举Computer=33（授权设备）
 * 添加模块枚举ERPGenius_BhgDuiCe=513,（不合格对策编辑）
 * 1.15.323.80：
 * OpenWeb添加IE浏览器的文件路径，因为有可能系统不支持直接“IEXPLORE.exe”的调用
 * 1.15.324.81：
 * 1.15.323.80中函数少传了个参数，导致报错
 * 1.15.427.82：
 * 修改frmBase中的函数ChangeWinTitle，当存在tagPage时也要对Form.Text赋值
 * 添加virtual函数GetEditFormText
 * 1.15.507.83：
 * 添加【#region 与SFC合并时新增的从10000~11000】中相关模块中的枚举10000~10002
 * 1.15.520.84：
 * 添加枚举值ZSFiberM_SetBsfSupplier=103
 * 1.15.724.85：
 * 添加OEMNo值，并在ReadInifile中读取该值，需要添加数据库函数:Common_System_GetOEMNo
 * 1.15.930.86：
 * 添加枚举ERPGenius_ReworkSetting、ERPGenius_ReworkDone
 * 1.15.1012.87：
 * 添加Common.MinPanel.frmProducePanel1.cs
 * 1.15.1013.88：
 * 修改Common.MinPanel.frmProducePanel1的ShowInTaskerbar设置为False
 * 1.15.1016.89：
 * Common.MinPanel.frmProducePanel1添加“退出程序”的按钮，并提供属性AppExitEnabled可以设置，默认为不显示
 * 1.15.1119.90：
 * 基础窗体frmMainBase，当owner的topmost为真时，此窗口也要为真，否则就看不到了；
 * frmMainBase.cs添加了富通log的ICON
 * 1.15.1213.91：
 * 添加更新文件的下载功能，以应对老是被360误删除的问题；
 * 1.16.706.92:
 * 修改CommonFuns中的OTDR7275公共类，添加登记时间的设置和读取
 * 1.16.718.93:
 * 添加物流系统数据库读取  class DoSqlCommandWuLiuA
 * 1.16.808.94:
 * 添加枚举Common.MyEnums.OTDRType
 * 86.16.824.95：
 * 添加静态函数Common.CommonFuns.CNWordsToEN
 * 添加打开非模态消息窗口Common.frmMainBase.ShowMsgRich，并修改原有ShowMsg，如果是保存成功的都用该窗口弹出
 * 86.16.831.96:
 * 添加Common.CommonDAL.DoSqlCommandCableERPPlan用于计划排产
 * 86.16.906.97：
 * 读取server.ini过程中赋值错误日志组件wErrorMessage的ErrorDAL.DBConnStringERPLog赋值
 * 86.16.918.98：
 * Common.Codes.frmCodes添加公共属性_DefaultCodes
 * 86.16.919.99：
 * CommonDAL下获取各个数据量数据类下添加GetDateSet(string strSql, bool isSchemaSource)的函数
 * 86.16.1010.100：
 * CommonDAL中添加本地Access数据库操作类 public static class DoSqlCommandAccessDB
 * CommonDAL中添加DoSqlCommandRealData
 * 添加CommonFuns.SendExceptionToMES
 * 86.16.1024.101：
 * CommonFuns.SendExceptionToMES_SC
 * CommonFuns.SendExceptionToMES_WZ
 * CommonFuns.SendExceptionToMES_PZ
 * 86.16.1117.102:
 * 添加时间格式化函数CommonFuns.GetHowLongAgo1
 * 86.16.1129.103：
 * 添加公共模块
 * Common.frmSetTime1，目前在TubeManage.Produce.frmProcessArgEdit1的生产和结束时间设置上使用
 * 添加Common.CommonFuns.GetMyIPs目前还未用到此函数，留做以后用
 * 86.16.1130.104：
 * Common.Report.frmReport2和Common.Report.frmReport1添加外部参数功能，见_ListArg的使用，这样可以让一个存储过程创建多张报表；
 * Common.Report.frmReport2和Common.Report.frmReport1导出添加了导出gridviewexcel的功能，见参数@MyDataGridView，这种方式导出的报表快
 * 86.17.119.105：
 * 添加函数public static void StartUpdate(string[] args,List<Common.MyEntity.VersionEntity> listVersion,bool blAutoKill)（重载），多了参数blAutoKill
 * 86.17.313.107:
 * 添加公共函数public static void SaveModifyXML(string sProcessCode, string sGuid, string SFGGode, string sOperator, string sXml,string sRemark)
 * 86.18.1220.108：银湖光纤MES初始化
 * 86.18.1221.109:
 * 添加函数：CommonFuns.FormatData.GetDecimalFromString 、GetBoolenFromString、GetDateTimeFromString
 * 86.18.1227.110：
 * 调整了继承窗口类中数据库连接对象为Basic
 * 86.19.231.111：
 *  CommonDAL.WuLiuAutomationDBConnString从服务器端同步IP连接地址
 *  86.19.214.112：
 *  添加函数 public bool ShowMainForm(string strTitle, frmBase frmNew,int iPageIndex)，原先 public bool ShowMainForm(string strTitle, frmBase frmNew)；
 *  86.19.309.114：
 *  添加语音播报Common.CommonFuns.PlayText("");
 *  86.19.320.115:
 *  控件ucRecordPage添加总行数的显示
 *  86.19.731.116:
 *  增加报废原因管理32
 */
