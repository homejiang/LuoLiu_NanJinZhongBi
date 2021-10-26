using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("JpsOPC")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("JpsOPC")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//将 ComVisible 设置为 false 将使此程序集中的类型
//对 COM 组件不可见。  如果需要从 COM 访问此程序集中的类型，
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("99161d4b-2d76-4242-9e91-b1cef3dbdebc")]

// 程序集的版本信息由下列四个值组成: 
//
//      主版本
//      次版本
//      生成号
//      修订号
//
//可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值，
// 方法是按如下所示使用“*”: :
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("86.21.1024.23")]
[assembly: AssemblyFileVersion("86.21.1024.23")]
/********
 * 添加了新建字段AT_SysNew的OPCitem
 * 86.19.227.7：
 * 添加AT_SysCompeleted操作
 * 86.19.321.10：
 * 修改WriteGongyi函数中的槽内电芯数，原先是固定槽1的，因为有可能槽1坏了，会不启用。
 * 86.19.403.11：
 * 添加类OPCHelperCorrect，用于电压、电阻修正值
 * 86.19.416.12:
 * 修复BUG，ReadCorrectFromOPC中的FOR循环导致超出数组范围
 * 86.19.416.14：
 * 修复BUG，CorrectValue类中SetV和SetDz居然没有给V和Dz变量赋值
 * 86.19.416.15：
 * 修正值写入BUG
 * 86.19.416.16：86.19.627.18:
 * 写入修正值时，serverHandles数组中居然都是1的，改成1到40的
 * 86.20.509.19:
 * 将OPC字段Asb_Finished改成Asb_AFinished
 * 86.20.517.20:
 * 之前项目把所槽的电芯数量设置成一样的，所以只写入一个槽1的，现在改回来了，全部18个写u人
 * 86.21.1023.21：
 * 南京中比初始化版本
 * 86.21.1023.22:
 * 修复首检读取数据的小bug
 * 86.21.1024.23：
 * 添加压差值写入，单个值的
 * ************/
