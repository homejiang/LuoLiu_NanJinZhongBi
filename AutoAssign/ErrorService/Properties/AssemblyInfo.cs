using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过下列属性集
// 控制。更改这些属性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("ErrorService")]
[assembly: AssemblyDescription("富阳姜鹏松日志组件")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("富阳姜鹏松")]
[assembly: AssemblyProduct("日志服务组件")]
[assembly: AssemblyCopyright("版权所有 富阳姜鹏松")]
[assembly: AssemblyTrademark("富阳姜鹏松")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 属性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("9119cff8-10a6-41db-8ba9-cb8d2c191c9d")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      内部版本号
//      修订号
//
// 可以指定所有这些值，也可以使用“修订号”和“内部版本号”的默认值，
// 方法是按如下所示使用“*”:
[assembly: AssemblyVersion("1.19.312.6")]
[assembly: AssemblyFileVersion("1.19.312.6")]
/*
 * 4.13.427.3：
 * 点击发送后错误消息存入表JC_ErrorService
 * 4.13.527.5：
 * 发送按钮与不发送按钮反了。
 * 1.19.312.6：
 * public static void WriteErrorLog(Exception e)不在写入日志了
 * 
 */
