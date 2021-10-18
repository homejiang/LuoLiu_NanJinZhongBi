using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAssign.JPSEnum
{
    public enum OperateLevels
    {
        /// <summary>
        /// 无任何权限
        /// </summary>
        None=0,
        /// <summary>
        /// 操作员：无任何权限
        /// </summary>
        Operate= 1,
        /// <summary>
        /// 管理员，有大部分设置权限
        /// </summary>
        Admin = 2,
        /// <summary>
        /// 超级管理员，有任何权限
        /// </summary>
        SysAdmin =3,
    }
   public enum GongYiTypes
    {
        /// <summary>
        /// 未定义
        /// </summary>
        None=0,
        /// <summary>
        /// 同工艺
        /// </summary>
        Same=1,
        /// <summary>
        /// 不同工艺
        /// </summary>
        Deffrent=2
    }
    public enum OnOff
    {
        /// <summary>
        /// 为定义
        /// </summary>
        None=0,
        /// <summary>
        /// 打开
        /// </summary>
        On=1,
        /// <summary>
        /// 关闭
        /// </summary>
        Off=2
    }
    public enum AotuMkMode
    {
        /// <summary>
        /// 为定义
        /// </summary>
        None = 0,
        /// <summary>
        /// 打开
        /// </summary>
        AutoMKOnly = 1,
        /// <summary>
        /// 关闭
        /// </summary>
        TuoPanOnly = 2,
        /// <summary>
        /// 混合模式
        /// </summary>
        All=3
    }
    public enum ScannerTextStates
    {
        /// <summary>
        /// 未定义
        /// </summary>
        None=0,
        /// <summary>
        /// 等待数据
        /// </summary>
        WattingScann=1,
        /// <summary>
        /// 等待条码枪数据
        /// </summary>
        WattingData=2,
        /// <summary>
        /// 处理数据中
        /// </summary>
        Proing=3
    }
    public enum TestStates
    {
        /// <summary>
        /// 未定义，该状态表示软件加载出错，不能执行测试
        /// </summary>
        None = 0,
        /// <summary>
        /// 空闲
        /// </summary>
        Free = 1,
        /// <summary>
        /// 测试中
        /// </summary>
        Testing = 2,
        /// <summary>
        /// 测试完成
        /// </summary>
        
        /// <summary>
        /// 暂停，测试中途退出来了，但设备还是在测试中的。
        /// </summary>
        Pause=3
    }
    public enum ScannerStates
    {
        /// <summary>
        /// 未定义
        /// </summary>
        None=0,
        /// <summary>
        /// 读取PLC开关量
        /// </summary>
        ReadingPLCIOValue=1,
        /// <summary>
        /// 通知扫描枪读取条码
        /// </summary>
        NoticeScannerReadBarCode=2,
        /// <summary>
        /// 已经发送LON给扫描枪了
        /// </summary>
        SendLON=3,
        /// <summary>
        /// 从远程数据库中获取系统编码
        /// </summary>
        WriteInotPLC_GetMyCode=4,
        /// <summary>
        /// 校验是否重复
        /// </summary>
        WriteInotPLC_CheckChongFu = 5,
        /// <summary>
        /// 读取存储到哪个块中
        /// </summary>
        ReadBlockNo=6,
        /// <summary>
        /// 写入OPC
        /// </summary>
        WriteInotPLC_OPC = 7
    }
    public enum ResultStates
    {
        /// <summary>
        /// 未定义
        /// </summary>
        None=0,
        /// <summary>
        /// 读取槽号，当大于0是表示可以读取结果信息了
        /// </summary>
        IsReadResult=1,
        /// <summary>
        /// 可以读取结果了
        /// </summary>
        ReadingPLCValue=2,
        /// <summary>
        /// 重置槽号（通知PLC，系统已经读取完检测结果了）
        /// </summary>
        ResetAtFalse=3,
        /// <summary>
        /// 保存到数据库
        /// </summary>
        SaveResult=4,
        /// <summary>
        /// 统计数据
        /// </summary>
        Statistic=5
    }
    public enum SwitchModes
    {
        /// <summary>
        ///还未定义
        /// </summary>
        未定义=0,
        /// <summary>
        /// 普通分档模式
        /// </summary>
        普通分档=1,
        /// <summary>
        /// 分AB档
        /// </summary>
        分AB档=1
    }
}
