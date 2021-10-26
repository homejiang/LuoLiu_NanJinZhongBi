using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过下列属性集
// 控制。更改这些属性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("SysSetting")]
[assembly: AssemblyDescription("系统设置")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("futonggroup")]
[assembly: AssemblyProduct("SysSetting")]
[assembly: AssemblyCopyright("版权所有 (C) futonggroup 2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 属性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("1f88768a-5027-4044-9418-0cac40a45bcb")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      内部版本号
//      修订号
//
[assembly: AssemblyVersion("86.15.811.10")]
[assembly: AssemblyFileVersion("86.15.811.10")]
/*********
 * 4.13.718.4：
 * 添加班次设置模块
 * 修改了部门选择的bug，之前的版本无法获取选中的部门
 * 4.13.806.5：
 * 模块frmAuditDetail执行完成时设置this.DialogResult = DialogResult.OK
 * 4.13.831.6：
 * 修改审批，只要有新增或编辑权限就显示btTrue按钮，原先为只能拥有编辑权限
 * 4.13.1230.7：
 * 修改审批bug，当送审人也是审批人时，如果不点“确定送审”而直接点击“提交审批”的话，就不会保存送审数据，从而出现问题
 * 4.14.718.8：
 * 选择界面SysSetting.DeptUsers.frmSelectUser中添加MultiSelected的功能。
 * 1.14.1029.9：
 * 窗体SysSetting.AuditDetail.frmAuditDetail添加属性public int ModuleNum = -1;用以替代传入枚举Common.MyEnums.Modules Module，2给属性都可以赋值
 * 1.15.811.10：
 * 优化选择窗口SysSetting.DeptUsers.frmSelectUser的界面
 *********/
