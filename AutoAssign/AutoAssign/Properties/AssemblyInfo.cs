using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("AutoAssign")]
[assembly: AssemblyDescription("新能源电池自动分选系统")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("洛柳")]
[assembly: AssemblyProduct("AutoAssign")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//将 ComVisible 设置为 false 将使此程序集中的类型
//对 COM 组件不可见。  如果需要从 COM 访问此程序集中的类型，
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("6ac2952a-2462-4992-86f8-d76e5a60f850")]

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
[assembly: AssemblyVersion("86.21.1112.93")]
[assembly: AssemblyFileVersion("86.21.1112.93")]
/**********
 * 86.19.222.13：
 * 1、添加订单号
 * 2、修改正式表为工厂固定的表格式；
 * 3、主程序添加状态paused
 * 86.19.223.16：
 * 86.19.225.19:
 * 86.19.227.23:86.19.227.24:
 * 添加计划
 * 存储过程中Mycode重复不过滤，修改了[SaveResult]
 * 显示NG列
 * 拖号每次新增后从个1开始计数
 * 86.19.227.25:
 * 86.19.228.28：
 * 86.19.301.29：
 * 主界面添加实时数据显示
 * 86.19.302.30:
 * 添加SN编号重定义的校验，并修改了一个BUG，原先是先存储电芯，在校验重复性，这样就没法存入数据库了，虽然给PLC是没问题的
 * 86.19.304.32：
 * 修复 bug：托盘完成后会引起设备状态显示中断，在btStop_Click中添加代码：
    this._MainControl._ResultControler.Listen_TuoPanPlanCompeleted = false;
    86.19.306.33：
    添加清理电芯数据功能，可以根据托盘来，也可以根据槽号来
    86.19.312.34：
    据祁工反应计划完成终止后，还是有设备中断情况，现在_MainControl_SysPlanCompeetedNotice只能添加this._MainControl._ResultControler.SetInterrupt(false);语句，尝试是否可以解决
    86.19.312.35：
    修正不扫码时的bug
    86.19.319.36：
    修改bug，上传Sn，时间字段漏了
    修改bug：拷贝数据没有拷贝到本地数据库，而是网络的
    86.19.321.37：86.19.322.38:
    与客户沟通直接沟通后的修改，先关参见《开发日志.doc》中：最后的修改
    86.19.322.41：
    重新调整了权限，部分按钮只有管理员才能用
    86.19.326.43：
    修改了bug：不扫码时不刷新实时数据，因为不扫码不会有mycode，而原程序当mycode为空时就不刷新数据了
    86.19.327.45:
    取消打印机设置必须管理员权限的限制
    86.19.328.48：
    添加导出MES数据的Csv功能
    86.19.329.49：
    修复bug：WriteGroovesIntoPLC中修改为grooves[i].St_CaoUsed = dr["Quality"].ToString() == "1" || dr["Quality"].ToString() == "2";//1为良品，2位不良品，原先是！=0，这样就不对了。
    86.19.403.50：
    1、添加修正值功能
    2、当前为单机版时，如果选中了上传MES则要提示用户
    86.19.416.51:
    1、修正值单位调整
    86.19.416.52:
    调整扫码合格率的算法，改为直接读取通道
    86.19.424.53：
    上位机经常提示SN表插入重复键，根源还未查清楚，现在再存入SN表时利用group by 避免提示插入重复键
    SocktClient添加2个扫描枪之间重复性校验：添加静态变量用于存储2个扫描前之间的条码
    86.19.621.54：
    添加SpeedCalculator_DxCount字段
    86.19.706.57：
    打印设置中添加二维码尺寸设置功能
    86.19.726.58:
    添加选择生产计划，单机版可以不选
    86.19.726.59:
    添加用户从MES中选择
    添加工序，机台的配置
    86.19.729.60：
    去除约束：网络版不能选择不扫码，因为陕西的有些时候就是没有电芯条码的
    86.19.730.61：
    添加收料盒的比例，添加标签打印份数的自定义
    86.19.731.62：
    添加未上传的托盘上传MES功能，需新增表Testing_FinishedTuoPan
    86.19.801.63：
    添加订单剩余量监控
    86.19.810.64：
    添加检测批次的CSV导出，需要添加类MyCsvWriter_TestReuslt
    86.20.426.65:
    在长风项目的基础上添加了自动插装模块
    86.20.505.66：
    保留打印功能
    保留托盘功能
    86.20.506.67：
    调整自动插装的电芯序列号存储，以#为开头结尾，有几个电芯存几个电芯，最多20个，同步修改了存储过程[Assemble_SaveDianXin]，原先只支持14个电芯序列号
    86.20.507.68:
    修复bug:perinit中JpsOPC.OPCHelperMKBuilding opcMKBuilding声明了实力，但未initServer
    86.20.509.69:
    添加已完成模块历史记录查找
    86.20.509.70：
    添加了模块删除功能
    86.20.511.71：
    1、停止测试时，自动插装线程、打印监听线程不停止，只是暂停，开始测试时取消暂停
    2、新建测试时终止线程
    86.20.514.72:
    添加模块自动上传功能
    86.20.514.73:
    移除了Jpsconfig中的BindMac函数
    86.20.519.74:
    引入混合模式
    86.20.524.75:
    拷贝到长风二期的2号机台前修改，内容：
    1、修改存储过程， bug:@ModeIsNeter没用起来；
    2、frmPactDataView窗口中之前总完成量是模块完成量+托盘完成量；
    3、显示ucSendMES控件内容，这个是参考车之翼的
    86.20.614.76：
    修复bug：函数frmMain.cs的SetAutoMKModeControlStyle中else if (state == JPSEnum.AotuMkMode.TuoPanOnly)写成了if (state == JPSEnum.AotuMkMode.AutoMKOnly)导致托盘模式下没法打印了
    86.20.823.77：
    添加电池容量Capacity、槽电阻电压范围StMinR\StMaxR\StMinV\StMaxV功能，要在MES的表Produce_Assign_TuoPan中也同步添加字段
    86.20.823.78：
    将电池容量改成范围，添加字段Capacity1
    86.20.829.79:
    修改界面frmSetTuoPanCode1代码，机台超过10的时候用英文字母替代。和存储过程GetNewTuoPanCode1一致
    86.20.1114.80：
    解决了软件加载一直会去连接扫描枪，即便设置为停用也会连接。原因是会读取jc_processClass里面有扫描枪设置，如果设置1，则停用也给你开起来。窗口加载时是在v_testingmain视图中去读的应该
    86.21.1023.81：
    南京中比初始化版本，添加首检，分档，压差功能
    86.21.1023.82:
    固定为仅托盘模式
    86.21.1023.83:
    读取结果分AB档保存，同步添加存储过程86.21.1023.83
    86.21.1023.84：
    AB分档的历史记录显示
    86.21.1023.85：
    添加了日志NLog；同步添加日志配置文件NLog.config
    86.21.1023.86：
    修复bug：从数据库output decimal类型时 ，如果不指定小数位数，那就会四筛五入了，变成没有小数点了，设置方法是：sqlParam.Scale = 6;
    86.21.1024.87 ：
    添加压差写入，就一个值
    86.21.1024.88:
    修复bug：frmTestedData界面显示NG的槽是用了托盘号来查，结果把所有NG槽的数据都加载了，现在这种改为CaoIndex去过滤
    86.21.1024.89：
    关键修改，读取blockno之前等待100毫秒，因为从日志上看，连续2次收到blockNo=1，这个是不对的
    86.21.1025.90：
    修复不能打印的问题，原因是之前有选择自动插装和仅托盘，选择后会设置打印模式，那南京中比固定设置为了仅托盘模式，在开始测试事件中添加了
    86.21.1027.91：
    添加条码规则设置，以及打印时添加上槽号显示
    86.21.1027.92：
    条码规则改成14位的，后面7个追溯码也加上去了
 * *******************/
