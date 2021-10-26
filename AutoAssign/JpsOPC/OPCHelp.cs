using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPCAutomation;
using JpsOPC.OPCEntitys;

namespace JpsOPC
{
    public class OPCHelperBase
    {
        public const int TransIDMainform = 2012;
        public const int TransIDSetttings = 2013;
        public const string OPCItemTitle = "1200.1217.";
        public int _ClientHandle = 0;
        public bool IsDebug = false;
        public bool InitSucessfully = false;
    }
    public class OPCHelperSJBase
    {
        public const int TransIDMainform = 2012;
        public const int TransIDSetttings = 2013;
        public const string OPCItemTitle = "1200.1218.";
        public int _ClientHandle = 0;
        public bool IsDebug = false;
        public bool InitSucessfully = false;
    }
    
    public class OPCHelperNanJingZhongBi : OPCHelperSJBase
    {
        OPCServer _Server = null;
        OPCGroups _ServerGroups = null;
        public OPCGroup _MyGroup_DoNow = null;
        public OPCGroup _MyGroup_Result = null;
        #region 用于读取的对象
        public JpsOPC.MyItemValue SJ_Work = null;
        public JpsOPC.MyItemValue SJ_V1min = null;
        public JpsOPC.MyItemValue SJ_V1max = null;
        public JpsOPC.MyItemValue SJ_R1min = null;
        public JpsOPC.MyItemValue SJ_R1max = null;
        public JpsOPC.MyItemValue SJ_V2min = null;
        public JpsOPC.MyItemValue SJ_V2max = null;
        public JpsOPC.MyItemValue SJ_R2min = null;
        public JpsOPC.MyItemValue SJ_R2max = null;
        public JpsOPC.MyItemValue SJ_V3min = null;
        public JpsOPC.MyItemValue SJ_V3max = null;
        public JpsOPC.MyItemValue SJ_R3min = null;
        public JpsOPC.MyItemValue SJ_R3max = null;
        public JpsOPC.MyItemValue SJ_V4min = null;
        public JpsOPC.MyItemValue SJ_V4max = null;
        public JpsOPC.MyItemValue SJ_R4min = null;
        public JpsOPC.MyItemValue SJ_R4max = null;
        public JpsOPC.MyItemValue SJ_V5min = null;
        public JpsOPC.MyItemValue SJ_V5max = null;
        public JpsOPC.MyItemValue SJ_R5min = null;
        public JpsOPC.MyItemValue SJ_R5max = null;
        public JpsOPC.MyItemValue SJ_V6min = null;
        public JpsOPC.MyItemValue SJ_V6max = null;
        public JpsOPC.MyItemValue SJ_R6min = null;
        public JpsOPC.MyItemValue SJ_R6max = null;
        public JpsOPC.MyItemValue SJ_V7min = null;
        public JpsOPC.MyItemValue SJ_V7max = null;
        public JpsOPC.MyItemValue SJ_R7min = null;
        public JpsOPC.MyItemValue SJ_R7max = null;
        public JpsOPC.MyItemValue SJ_V8min = null;
        public JpsOPC.MyItemValue SJ_V8max = null;
        public JpsOPC.MyItemValue SJ_R8min = null;
        public JpsOPC.MyItemValue SJ_R8max = null;
        public JpsOPC.MyItemValue SJ_V9min = null;
        public JpsOPC.MyItemValue SJ_V9max = null;
        public JpsOPC.MyItemValue SJ_R9min = null;
        public JpsOPC.MyItemValue SJ_R9max = null;
        public JpsOPC.MyItemValue SJ_V10min = null;
        public JpsOPC.MyItemValue SJ_V10max = null;
        public JpsOPC.MyItemValue SJ_R10min = null;
        public JpsOPC.MyItemValue SJ_R10max = null;
        public JpsOPC.MyItemValue SJ_V11min = null;
        public JpsOPC.MyItemValue SJ_V11max = null;
        public JpsOPC.MyItemValue SJ_R11min = null;
        public JpsOPC.MyItemValue SJ_R11max = null;
        public JpsOPC.MyItemValue SJ_V12min = null;
        public JpsOPC.MyItemValue SJ_V12max = null;
        public JpsOPC.MyItemValue SJ_R12min = null;
        public JpsOPC.MyItemValue SJ_R12max = null;
        public JpsOPC.MyItemValue SJ_V13min = null;
        public JpsOPC.MyItemValue SJ_V13max = null;
        public JpsOPC.MyItemValue SJ_R13min = null;
        public JpsOPC.MyItemValue SJ_R13max = null;
        public JpsOPC.MyItemValue SJ_V14min = null;
        public JpsOPC.MyItemValue SJ_V14max = null;
        public JpsOPC.MyItemValue SJ_R14min = null;
        public JpsOPC.MyItemValue SJ_R14max = null;
        public JpsOPC.MyItemValue SJ_V15min = null;
        public JpsOPC.MyItemValue SJ_V15max = null;
        public JpsOPC.MyItemValue SJ_R15min = null;
        public JpsOPC.MyItemValue SJ_R15max = null;
        public JpsOPC.MyItemValue SJ_V16min = null;
        public JpsOPC.MyItemValue SJ_V16max = null;
        public JpsOPC.MyItemValue SJ_R16min = null;
        public JpsOPC.MyItemValue SJ_R16max = null;
        //读取结果值
        public JpsOPC.MyItemValue SJ_Resut1 = null;
        public JpsOPC.MyItemValue SJ_Resut2 = null;
        public JpsOPC.MyItemValue SJ_Resut3 = null;
        public JpsOPC.MyItemValue SJ_Resut4 = null;
        public JpsOPC.MyItemValue SJ_Resut5 = null;
        public JpsOPC.MyItemValue SJ_Resut6 = null;
        public JpsOPC.MyItemValue SJ_Resut7 = null;
        public JpsOPC.MyItemValue SJ_Resut8 = null;
        public JpsOPC.MyItemValue SJ_Resut9 = null;
        public JpsOPC.MyItemValue SJ_Resut10 = null;
        public JpsOPC.MyItemValue SJ_Resut11 = null;
        public JpsOPC.MyItemValue SJ_Resut12 = null;
        public JpsOPC.MyItemValue SJ_Resut13 = null;
        public JpsOPC.MyItemValue SJ_Resut14 = null;
        public JpsOPC.MyItemValue SJ_Resut15 = null;
        public JpsOPC.MyItemValue SJ_Resut16 = null;

        #endregion
        #region 公共函数
        public bool InitServer(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (_Server == null)
            {
                try
                {
                    this._Server = new OPCServer();
                }
                catch (Exception ex)
                {
                    sErr = "ResultOPC：初始化Server出错：" + ex.Message + "(" + ex.Source + ")";
                    return false;
                }
            }
            if (this._Server.ServerState != (int)OPCServerState.OPCRunning)
            {
                try
                {
                    this._Server.Connect("KEPware.KEPServerEx.V6", "");
                }
                catch (Exception ex)
                {
                    sErr = string.Format("ResultOPC：server初始化出错：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
                //重新连接过的话重新定义组
                _ServerGroups = null;
                if (this.SJ_Work != null)
                    this.SJ_Work.InitItem();
                if (this.SJ_V1min != null)
                    this.SJ_V1min.InitItem();
                if (this.SJ_V1max != null)
                    this.SJ_V1max.InitItem();
                if (this.SJ_R1min != null)
                    this.SJ_R1min.InitItem();
                if (this.SJ_R1max != null)
                    this.SJ_R1max.InitItem();
                if (this.SJ_V2min != null)
                    this.SJ_V2min.InitItem();
                if (this.SJ_V2max != null)
                    this.SJ_V2max.InitItem();
                if (this.SJ_R2min != null)
                    this.SJ_R2min.InitItem();
                if (this.SJ_R2max != null)
                    this.SJ_R2max.InitItem();
                if (this.SJ_V3min != null)
                    this.SJ_V3min.InitItem();
                if (this.SJ_V3max != null)
                    this.SJ_V3max.InitItem();
                if (this.SJ_R3min != null)
                    this.SJ_R3min.InitItem();
                if (this.SJ_R3max != null)
                    this.SJ_R3max.InitItem();
                if (this.SJ_V4min != null)
                    this.SJ_V4min.InitItem();
                if (this.SJ_V4max != null)
                    this.SJ_V4max.InitItem();
                if (this.SJ_R4min != null)
                    this.SJ_R4min.InitItem();
                if (this.SJ_R4max != null)
                    this.SJ_R4max.InitItem();
                if (this.SJ_V5min != null)
                    this.SJ_V5min.InitItem();
                if (this.SJ_V5max != null)
                    this.SJ_V5max.InitItem();
                if (this.SJ_R5min != null)
                    this.SJ_R5min.InitItem();
                if (this.SJ_R5max != null)
                    this.SJ_R5max.InitItem();
                if (this.SJ_V6min != null)
                    this.SJ_V6min.InitItem();
                if (this.SJ_V6max != null)
                    this.SJ_V6max.InitItem();
                if (this.SJ_R6min != null)
                    this.SJ_R6min.InitItem();
                if (this.SJ_R6max != null)
                    this.SJ_R6max.InitItem();
                if (this.SJ_V7min != null)
                    this.SJ_V7min.InitItem();
                if (this.SJ_V7max != null)
                    this.SJ_V7max.InitItem();
                if (this.SJ_R7min != null)
                    this.SJ_R7min.InitItem();
                if (this.SJ_R7max != null)
                    this.SJ_R7max.InitItem();
                if (this.SJ_V8min != null)
                    this.SJ_V8min.InitItem();
                if (this.SJ_V8max != null)
                    this.SJ_V8max.InitItem();
                if (this.SJ_R8min != null)
                    this.SJ_R8min.InitItem();
                if (this.SJ_R8max != null)
                    this.SJ_R8max.InitItem();
                if (this.SJ_V9min != null)
                    this.SJ_V9min.InitItem();
                if (this.SJ_V9max != null)
                    this.SJ_V9max.InitItem();
                if (this.SJ_R9min != null)
                    this.SJ_R9min.InitItem();
                if (this.SJ_R9max != null)
                    this.SJ_R9max.InitItem();
                if (this.SJ_V10min != null)
                    this.SJ_V10min.InitItem();
                if (this.SJ_V10max != null)
                    this.SJ_V10max.InitItem();
                if (this.SJ_R10min != null)
                    this.SJ_R10min.InitItem();
                if (this.SJ_R10max != null)
                    this.SJ_R10max.InitItem();
                if (this.SJ_V11min != null)
                    this.SJ_V11min.InitItem();
                if (this.SJ_V11max != null)
                    this.SJ_V11max.InitItem();
                if (this.SJ_R11min != null)
                    this.SJ_R11min.InitItem();
                if (this.SJ_R11max != null)
                    this.SJ_R11max.InitItem();
                if (this.SJ_V12min != null)
                    this.SJ_V12min.InitItem();
                if (this.SJ_V12max != null)
                    this.SJ_V12max.InitItem();
                if (this.SJ_R12min != null)
                    this.SJ_R12min.InitItem();
                if (this.SJ_R12max != null)
                    this.SJ_R12max.InitItem();
                if (this.SJ_V13min != null)
                    this.SJ_V13min.InitItem();
                if (this.SJ_V13max != null)
                    this.SJ_V13max.InitItem();
                if (this.SJ_R13min != null)
                    this.SJ_R13min.InitItem();
                if (this.SJ_R13max != null)
                    this.SJ_R13max.InitItem();
                if (this.SJ_V14min != null)
                    this.SJ_V14min.InitItem();
                if (this.SJ_V14max != null)
                    this.SJ_V14max.InitItem();
                if (this.SJ_R14min != null)
                    this.SJ_R14min.InitItem();
                if (this.SJ_R14max != null)
                    this.SJ_R14max.InitItem();
                if (this.SJ_V15min != null)
                    this.SJ_V15min.InitItem();
                if (this.SJ_V15max != null)
                    this.SJ_V15max.InitItem();
                if (this.SJ_R15min != null)
                    this.SJ_R15min.InitItem();
                if (this.SJ_R15max != null)
                    this.SJ_R15max.InitItem();
                if (this.SJ_V16min != null)
                    this.SJ_V16min.InitItem();
                if (this.SJ_V16max != null)
                    this.SJ_V16max.InitItem();
                if (this.SJ_R16min != null)
                    this.SJ_R16min.InitItem();
                if (this.SJ_R16max != null)
                    this.SJ_R16max.InitItem();

                if (this.SJ_Resut1 != null)
                    this.SJ_Resut1.InitItem();
                if (this.SJ_Resut2 != null)
                    this.SJ_Resut2.InitItem();
                if (this.SJ_Resut3 != null)
                    this.SJ_Resut3.InitItem();
                if (this.SJ_Resut4 != null)
                    this.SJ_Resut4.InitItem();
                if (this.SJ_Resut5 != null)
                    this.SJ_Resut5.InitItem();
                if (this.SJ_Resut6 != null)
                    this.SJ_Resut6.InitItem();
                if (this.SJ_Resut7 != null)
                    this.SJ_Resut7.InitItem();
                if (this.SJ_Resut8 != null)
                    this.SJ_Resut8.InitItem();
                if (this.SJ_Resut9 != null)
                    this.SJ_Resut9.InitItem();
                if (this.SJ_Resut10 != null)
                    this.SJ_Resut10.InitItem();
                if (this.SJ_Resut11 != null)
                    this.SJ_Resut11.InitItem();
                if (this.SJ_Resut12 != null)
                    this.SJ_Resut12.InitItem();
                if (this.SJ_Resut13 != null)
                    this.SJ_Resut13.InitItem();
                if (this.SJ_Resut14 != null)
                    this.SJ_Resut14.InitItem();
                if (this.SJ_Resut15 != null)
                    this.SJ_Resut15.InitItem();
                if (this.SJ_Resut16 != null)
                    this.SJ_Resut16.InitItem();
            }
            //添加组
            if (_ServerGroups == null)
            {
                _ServerGroups = this._Server.OPCGroups;
                _ServerGroups.DefaultGroupIsActive = true; //设置组集合默认为激活状态
                //下面这个几个暂时不设定，看看是否有异常，因为DefaultGroupUpdateRate这个值很关键，估计是与写入和读取的频率相关了，应该设置到某个单一的节点为好。
                _ServerGroups.DefaultGroupDeadband = 0;    //设置死区
                _ServerGroups.DefaultGroupUpdateRate = 100;//设置更新频率
                try
                {
                    //电池组1
                    this._MyGroup_DoNow = _ServerGroups.Add("NanJingGroup1");
                    this._MyGroup_DoNow.UpdateRate = 200; //刷新频率
                    this._MyGroup_DoNow.IsActive = true;
                    //电池组2
                    this._MyGroup_Result = _ServerGroups.Add("NanJingGroup2");
                    this._MyGroup_Result.UpdateRate = 1000;
                    this._MyGroup_Result.IsActive = true;
                }
                catch (Exception ex)
                {
                    sErr = string.Format("创建各组失败：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
            }
            if (!this.InitMyItems(out sErr))
            {
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool InitMyItems(out string sErr)
        {
            if (this.SJ_Work == null)
                SJ_Work = new MyItemValue(OPCItemTitle + "SJ_Work");
            if (this.SJ_V1min == null)
                SJ_V1min = new MyItemValue(OPCItemTitle + "SJ_V1min");
            if (this.SJ_V1max == null)
                SJ_V1max = new MyItemValue(OPCItemTitle + "SJ_V1max");
            if (this.SJ_R1min == null)
                SJ_R1min = new MyItemValue(OPCItemTitle + "SJ_R1min");
            if (this.SJ_R1max == null)
                SJ_R1max = new MyItemValue(OPCItemTitle + "SJ_R1max");
            if (this.SJ_V2min == null)
                SJ_V2min = new MyItemValue(OPCItemTitle + "SJ_V2min");
            if (this.SJ_V2max == null)
                SJ_V2max = new MyItemValue(OPCItemTitle + "SJ_V2max");
            if (this.SJ_R2min == null)
                SJ_R2min = new MyItemValue(OPCItemTitle + "SJ_R2min");
            if (this.SJ_R2max == null)
                SJ_R2max = new MyItemValue(OPCItemTitle + "SJ_R2max");
            if (this.SJ_V3min == null)
                SJ_V3min = new MyItemValue(OPCItemTitle + "SJ_V3min");
            if (this.SJ_V3max == null)
                SJ_V3max = new MyItemValue(OPCItemTitle + "SJ_V3max");
            if (this.SJ_R3min == null)
                SJ_R3min = new MyItemValue(OPCItemTitle + "SJ_R3min");
            if (this.SJ_R3max == null)
                SJ_R3max = new MyItemValue(OPCItemTitle + "SJ_R3max");
            if (this.SJ_V4min == null)
                SJ_V4min = new MyItemValue(OPCItemTitle + "SJ_V4min");
            if (this.SJ_V4max == null)
                SJ_V4max = new MyItemValue(OPCItemTitle + "SJ_V4max");
            if (this.SJ_R4min == null)
                SJ_R4min = new MyItemValue(OPCItemTitle + "SJ_R4min");
            if (this.SJ_R4max == null)
                SJ_R4max = new MyItemValue(OPCItemTitle + "SJ_R4max");
            if (this.SJ_V5min == null)
                SJ_V5min = new MyItemValue(OPCItemTitle + "SJ_V5min");
            if (this.SJ_V5max == null)
                SJ_V5max = new MyItemValue(OPCItemTitle + "SJ_V5max");
            if (this.SJ_R5min == null)
                SJ_R5min = new MyItemValue(OPCItemTitle + "SJ_R5min");
            if (this.SJ_R5max == null)
                SJ_R5max = new MyItemValue(OPCItemTitle + "SJ_R5max");
            if (this.SJ_V6min == null)
                SJ_V6min = new MyItemValue(OPCItemTitle + "SJ_V6min");
            if (this.SJ_V6max == null)
                SJ_V6max = new MyItemValue(OPCItemTitle + "SJ_V6max");
            if (this.SJ_R6min == null)
                SJ_R6min = new MyItemValue(OPCItemTitle + "SJ_R6min");
            if (this.SJ_R6max == null)
                SJ_R6max = new MyItemValue(OPCItemTitle + "SJ_R6max");
            if (this.SJ_V7min == null)
                SJ_V7min = new MyItemValue(OPCItemTitle + "SJ_V7min");
            if (this.SJ_V7max == null)
                SJ_V7max = new MyItemValue(OPCItemTitle + "SJ_V7max");
            if (this.SJ_R7min == null)
                SJ_R7min = new MyItemValue(OPCItemTitle + "SJ_R7min");
            if (this.SJ_R7max == null)
                SJ_R7max = new MyItemValue(OPCItemTitle + "SJ_R7max");
            if (this.SJ_V8min == null)
                SJ_V8min = new MyItemValue(OPCItemTitle + "SJ_V8min");
            if (this.SJ_V8max == null)
                SJ_V8max = new MyItemValue(OPCItemTitle + "SJ_V8max");
            if (this.SJ_R8min == null)
                SJ_R8min = new MyItemValue(OPCItemTitle + "SJ_R8min");
            if (this.SJ_R8max == null)
                SJ_R8max = new MyItemValue(OPCItemTitle + "SJ_R8max");
            if (this.SJ_V9min == null)
                SJ_V9min = new MyItemValue(OPCItemTitle + "SJ_V9min");
            if (this.SJ_V9max == null)
                SJ_V9max = new MyItemValue(OPCItemTitle + "SJ_V9max");
            if (this.SJ_R9min == null)
                SJ_R9min = new MyItemValue(OPCItemTitle + "SJ_R9min");
            if (this.SJ_R9max == null)
                SJ_R9max = new MyItemValue(OPCItemTitle + "SJ_R9max");
            if (this.SJ_V10min == null)
                SJ_V10min = new MyItemValue(OPCItemTitle + "SJ_V10min");
            if (this.SJ_V10max == null)
                SJ_V10max = new MyItemValue(OPCItemTitle + "SJ_V10max");
            if (this.SJ_R10min == null)
                SJ_R10min = new MyItemValue(OPCItemTitle + "SJ_R10min");
            if (this.SJ_R10max == null)
                SJ_R10max = new MyItemValue(OPCItemTitle + "SJ_R10max");
            if (this.SJ_V11min == null)
                SJ_V11min = new MyItemValue(OPCItemTitle + "SJ_V11min");
            if (this.SJ_V11max == null)
                SJ_V11max = new MyItemValue(OPCItemTitle + "SJ_V11max");
            if (this.SJ_R11min == null)
                SJ_R11min = new MyItemValue(OPCItemTitle + "SJ_R11min");
            if (this.SJ_R11max == null)
                SJ_R11max = new MyItemValue(OPCItemTitle + "SJ_R11max");
            if (this.SJ_V12min == null)
                SJ_V12min = new MyItemValue(OPCItemTitle + "SJ_V12min");
            if (this.SJ_V12max == null)
                SJ_V12max = new MyItemValue(OPCItemTitle + "SJ_V12max");
            if (this.SJ_R12min == null)
                SJ_R12min = new MyItemValue(OPCItemTitle + "SJ_R12min");
            if (this.SJ_R12max == null)
                SJ_R12max = new MyItemValue(OPCItemTitle + "SJ_R12max");
            if (this.SJ_V13min == null)
                SJ_V13min = new MyItemValue(OPCItemTitle + "SJ_V13min");
            if (this.SJ_V13max == null)
                SJ_V13max = new MyItemValue(OPCItemTitle + "SJ_V13max");
            if (this.SJ_R13min == null)
                SJ_R13min = new MyItemValue(OPCItemTitle + "SJ_R13min");
            if (this.SJ_R13max == null)
                SJ_R13max = new MyItemValue(OPCItemTitle + "SJ_R13max");
            if (this.SJ_V14min == null)
                SJ_V14min = new MyItemValue(OPCItemTitle + "SJ_V14min");
            if (this.SJ_V14max == null)
                SJ_V14max = new MyItemValue(OPCItemTitle + "SJ_V14max");
            if (this.SJ_R14min == null)
                SJ_R14min = new MyItemValue(OPCItemTitle + "SJ_R14min");
            if (this.SJ_R14max == null)
                SJ_R14max = new MyItemValue(OPCItemTitle + "SJ_R14max");
            if (this.SJ_V15min == null)
                SJ_V15min = new MyItemValue(OPCItemTitle + "SJ_V15min");
            if (this.SJ_V15max == null)
                SJ_V15max = new MyItemValue(OPCItemTitle + "SJ_V15max");
            if (this.SJ_R15min == null)
                SJ_R15min = new MyItemValue(OPCItemTitle + "SJ_R15min");
            if (this.SJ_R15max == null)
                SJ_R15max = new MyItemValue(OPCItemTitle + "SJ_R15max");
            if (this.SJ_V16min == null)
                SJ_V16min = new MyItemValue(OPCItemTitle + "SJ_V16min");
            if (this.SJ_V16max == null)
                SJ_V16max = new MyItemValue(OPCItemTitle + "SJ_V16max");
            if (this.SJ_R16min == null)
                SJ_R16min = new MyItemValue(OPCItemTitle + "SJ_R16min");
            if (this.SJ_R16max == null)
                SJ_R16max = new MyItemValue(OPCItemTitle + "SJ_R16max");

            if (this.SJ_Resut1 == null)
                SJ_Resut1 = new MyItemValue(OPCItemTitle + "SJ_Resut1");
            if (this.SJ_Resut2 == null)
                SJ_Resut2 = new MyItemValue(OPCItemTitle + "SJ_Resut2");
            if (this.SJ_Resut3 == null)
                SJ_Resut3 = new MyItemValue(OPCItemTitle + "SJ_Resut3");
            if (this.SJ_Resut4 == null)
                SJ_Resut4 = new MyItemValue(OPCItemTitle + "SJ_Resut4");
            if (this.SJ_Resut5 == null)
                SJ_Resut5 = new MyItemValue(OPCItemTitle + "SJ_Resut5");
            if (this.SJ_Resut6 == null)
                SJ_Resut6 = new MyItemValue(OPCItemTitle + "SJ_Resut6");
            if (this.SJ_Resut7 == null)
                SJ_Resut7 = new MyItemValue(OPCItemTitle + "SJ_Resut7");
            if (this.SJ_Resut8 == null)
                SJ_Resut8 = new MyItemValue(OPCItemTitle + "SJ_Resut8");
            if (this.SJ_Resut9 == null)
                SJ_Resut9 = new MyItemValue(OPCItemTitle + "SJ_Resut9");
            if (this.SJ_Resut10 == null)
                SJ_Resut10 = new MyItemValue(OPCItemTitle + "SJ_Resut10");
            if (this.SJ_Resut11 == null)
                SJ_Resut11 = new MyItemValue(OPCItemTitle + "SJ_Resut11");
            if (this.SJ_Resut12 == null)
                SJ_Resut12 = new MyItemValue(OPCItemTitle + "SJ_Resut12");
            if (this.SJ_Resut13 == null)
                SJ_Resut13 = new MyItemValue(OPCItemTitle + "SJ_Resut13");
            if (this.SJ_Resut14 == null)
                SJ_Resut14 = new MyItemValue(OPCItemTitle + "SJ_Resut14");
            if (this.SJ_Resut15 == null)
                SJ_Resut15 = new MyItemValue(OPCItemTitle + "SJ_Resut15");
            if (this.SJ_Resut16 == null)
                SJ_Resut16 = new MyItemValue(OPCItemTitle + "SJ_Resut16");


            //在OPCGroup中添加IOPCItem
            if (this._MyGroup_DoNow == null)
            {
                sErr = "初始化电池组item时失败，因为group1为空。";
                return false;
            }
            if (this._MyGroup_Result == null)
            {
                sErr = "初始化电池组item时失败，因为group2为空。";
                return false;
            }
            if (_MyGroup_DoNow.OPCItems == null)
            {
                sErr = "初始化电池组item时失败，因为group1.OPCItems为空。";
                return false;
            }
            if (_MyGroup_Result.OPCItems == null)
            {
                sErr = "初始化电池组item时失败，因为group2.OPCItems为空。";
                return false;
            }
            #region 加入到group中
            if (!InitMyItems_AddItem(this.SJ_Work, this._MyGroup_DoNow, true, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V1min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V1max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R1min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R1max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V2min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V2max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R2min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R2max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V3min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V3max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R3min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R3max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V4min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V4max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R4min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R4max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V5min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V5max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R5min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R5max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V6min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V6max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R6min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R6max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V7min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V7max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R7min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R7max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V8min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V8max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R8min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R8max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V9min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V9max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R9min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R9max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V10min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V10max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R10min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R10max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V11min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V11max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R11min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R11max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V12min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V12max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R12min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R12max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V13min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V13max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R13min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R13max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V14min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V14max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R14min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R14max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V15min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V15max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R15min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R15max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V16min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_V16max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R16min, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_R16max, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }


            if (!InitMyItems_AddItem(this.SJ_Resut1, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut2, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut3, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut4, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut5, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut6, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut7, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut8, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut9, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut10, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut11, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut12, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut13, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut14, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut15, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.SJ_Resut16, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }
            #endregion
            return true;
        }
        private bool InitMyItems_AddItem(MyItemValue myItem, OPCGroup targetGroup, bool saveItem, out string sErr)
        {
            if (myItem.ServerHandle <= 0)
            {
                if (this.IsDebug)
                {
                    sErr = string.Empty;
                    return true;
                }
                //此时添加Item
                _ClientHandle++;
                OPCItem item = null;
                string strTagName = myItem.TagName;
                try
                {
                    item = targetGroup.OPCItems.AddItem(strTagName, _ClientHandle);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("添加Item：{0}，出错:{1}({2})", myItem.TagName, ex.Message, ex.Source);
                    return false;
                }
                if (item == null)
                {
                    sErr = string.Format("添加Item：{0}失败，返回为空。", myItem.TagName);
                    return false;
                }
                if (item.ServerHandle <= 0)
                {
                    sErr = string.Format("添加Item：{0}失败，返回值ServerHandle为{1}。", myItem.TagName, myItem.ServerHandle);
                    return false;
                }
                myItem.ServerHandle = item.ServerHandle;
                myItem.ClientHandle = this._ClientHandle;
                if (saveItem)
                    myItem._OPCItem = item;
            }
            sErr = string.Empty;
            return true;
        }
        public bool CloseOPC(out string sErr)
        {
            sErr = "";
            if (this._Server == null) return true;
            try
            {
                this._Server.Disconnect();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
                return false;
            }
            return true;
        }
        #endregion
        #region 功能函数
        public bool ReadWrkState(out short iValue,out string sErr)
        {
            if(this.IsDebug)
            {
                iValue = SJDebug.WorkState;
                sErr = "";
                return true;
            }
            iValue = 0;
            if (this.SJ_Work == null)
            {
                sErr = "OPC字段SJ_Work为空！";
                return false;
            }
            else if (this.SJ_Work._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "OPC字段SJ_Work为空，且初始化出错：" + sErr;
                    return false;
                }
            }
            if (this.SJ_Work.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "OPC字段SJ_Work的OPCItemHandle值为0，但重新初始化时出错：" + sErr;
                    return false;
                }
            }
            //此时有效了，直接读取值
            object objValue;
            if (!this.SJ_Work.ReadData(out objValue, out sErr))
            {
                sErr = "OPCItem(SJ_Work)读取出错：" + sErr;
                return false;
            }
            if (objValue == null)
            {
                sErr = string.Format("OPCItem(SJ_Work)读取出错：item对象[{0}]的返回值NULL。", this.SJ_Work.TagName);
                return false;
            }
            //此时读取成功了，则转换
            if(!short.TryParse(objValue.ToString(),out iValue))
            {
                sErr = $"OPCItem(SJ_Work)读取出错：返回值[{objValue.ToString()}]不是预期的16位整型。";
                return false;
            }
            return true;
        }
        #endregion
        #region 写入功能函数
        public bool WriteSjRange(NanJingZB_SJRVRange data, out string sErr, bool blReWrite = false)
        {
            //sErr = string.Format("数量serverID:{0}，数量值:{1}", this.St_Cao1DxCnt.ServerHandle, grooves[0].St_CaoDxCnt);
            //return false;
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            //写入数据
            Array serverHandles = new int[65] { 0,
                this.SJ_V1min.ServerHandle,
                this.SJ_V1max.ServerHandle,
                this.SJ_R1min.ServerHandle,
                this.SJ_R1max.ServerHandle,
                this.SJ_V2min.ServerHandle,
                this.SJ_V2max.ServerHandle,
                this.SJ_R2min.ServerHandle,
                this.SJ_R2max.ServerHandle,
                this.SJ_V3min.ServerHandle,
                this.SJ_V3max.ServerHandle,
                this.SJ_R3min.ServerHandle,
                this.SJ_R3max.ServerHandle,
                this.SJ_V4min.ServerHandle,
                this.SJ_V4max.ServerHandle,
                this.SJ_R4min.ServerHandle,
                this.SJ_R4max.ServerHandle,
                this.SJ_V5min.ServerHandle,
                this.SJ_V5max.ServerHandle,
                this.SJ_R5min.ServerHandle,
                this.SJ_R5max.ServerHandle,
                this.SJ_V6min.ServerHandle,
                this.SJ_V6max.ServerHandle,
                this.SJ_R6min.ServerHandle,
                this.SJ_R6max.ServerHandle,
                this.SJ_V7min.ServerHandle,
                this.SJ_V7max.ServerHandle,
                this.SJ_R7min.ServerHandle,
                this.SJ_R7max.ServerHandle,
                this.SJ_V8min.ServerHandle,
                this.SJ_V8max.ServerHandle,
                this.SJ_R8min.ServerHandle,
                this.SJ_R8max.ServerHandle,
                this.SJ_V9min.ServerHandle,
                this.SJ_V9max.ServerHandle,
                this.SJ_R9min.ServerHandle,
                this.SJ_R9max.ServerHandle,
                this.SJ_V10min.ServerHandle,
                this.SJ_V10max.ServerHandle,
                this.SJ_R10min.ServerHandle,
                this.SJ_R10max.ServerHandle,
                this.SJ_V11min.ServerHandle,
                this.SJ_V11max.ServerHandle,
                this.SJ_R11min.ServerHandle,
                this.SJ_R11max.ServerHandle,
                this.SJ_V12min.ServerHandle,
                this.SJ_V12max.ServerHandle,
                this.SJ_R12min.ServerHandle,
                this.SJ_R12max.ServerHandle,
                this.SJ_V13min.ServerHandle,
                this.SJ_V13max.ServerHandle,
                this.SJ_R13min.ServerHandle,
                this.SJ_R13max.ServerHandle,
                this.SJ_V14min.ServerHandle,
                this.SJ_V14max.ServerHandle,
                this.SJ_R14min.ServerHandle,
                this.SJ_R14max.ServerHandle,
                this.SJ_V15min.ServerHandle,
                this.SJ_V15max.ServerHandle,
                this.SJ_R15min.ServerHandle,
                this.SJ_R15max.ServerHandle,
                this.SJ_V16min.ServerHandle,
                this.SJ_V16max.ServerHandle,
                this.SJ_R16min.ServerHandle,
                this.SJ_R16max.ServerHandle,
            };
            Array values = new object[65] { ""
               ,data.SJ_V1min
                ,data.SJ_V1max
                ,data.SJ_R1min
                ,data.SJ_R1max
                ,data.SJ_V2min
                ,data.SJ_V2max
                ,data.SJ_R2min
                ,data.SJ_R2max
                ,data.SJ_V3min
                ,data.SJ_V3max
                ,data.SJ_R3min
                ,data.SJ_R3max
                ,data.SJ_V4min
                ,data.SJ_V4max
                ,data.SJ_R4min
                ,data.SJ_R4max
                ,data.SJ_V5min
                ,data.SJ_V5max
                ,data.SJ_R5min
                ,data.SJ_R5max
                ,data.SJ_V6min
                ,data.SJ_V6max
                ,data.SJ_R6min
                ,data.SJ_R6max
                ,data.SJ_V7min
                ,data.SJ_V7max
                ,data.SJ_R7min
                ,data.SJ_R7max
                ,data.SJ_V8min
                ,data.SJ_V8max
                ,data.SJ_R8min
                ,data.SJ_R8max
                ,data.SJ_V9min
                ,data.SJ_V9max
                ,data.SJ_R9min
                ,data.SJ_R9max
                ,data.SJ_V10min
                ,data.SJ_V10max
                ,data.SJ_R10min
                ,data.SJ_R10max
                ,data.SJ_V11min
                ,data.SJ_V11max
                ,data.SJ_R11min
                ,data.SJ_R11max
                ,data.SJ_V12min
                ,data.SJ_V12max
                ,data.SJ_R12min
                ,data.SJ_R12max
                ,data.SJ_V13min
                ,data.SJ_V13max
                ,data.SJ_R13min
                ,data.SJ_R13max
                ,data.SJ_V14min
                ,data.SJ_V14max
                ,data.SJ_R14min
                ,data.SJ_R14max
                ,data.SJ_V15min
                ,data.SJ_V15max
                ,data.SJ_R15min
                ,data.SJ_R15max
                ,data.SJ_V16min
                ,data.SJ_V16max
                ,data.SJ_R16min
                ,data.SJ_R16max
            };
            Array errors;
            try
            {
                this._MyGroup_Result.SyncWrite(64, ref serverHandles, ref values, out errors);
            }
            catch (Exception ex)
            {
                if (!blReWrite)
                {
                    //此时不是第二次调用了
                    if (!this.InitServer(out sErr)) return false;
                    return this.WriteSjRange(data, out sErr, true);
                }
                else
                {
                    sErr = string.Format("首检范围参数写入出错：{0}({1})", ex.Message, ex.Source);
                }
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        #endregion
        #region 读取结果
        public bool ReadResult(ref NanJingZB_SJResult data,out string sErr)
        {
            if(this.IsDebug)
            {
                sErr = string.Empty;
                data.SJ_Resut1 = SJDebug.SJ_Resut1;
                data.SJ_Resut2 = SJDebug.SJ_Resut2;
                data.SJ_Resut3 = SJDebug.SJ_Resut3;
                data.SJ_Resut4 = SJDebug.SJ_Resut4;
                data.SJ_Resut5 = SJDebug.SJ_Resut5;
                data.SJ_Resut6 = SJDebug.SJ_Resut6;
                data.SJ_Resut7 = SJDebug.SJ_Resut7;
                data.SJ_Resut8 = SJDebug.SJ_Resut8;
                data.SJ_Resut9 = SJDebug.SJ_Resut9;
                data.SJ_Resut10 = SJDebug.SJ_Resut10;
                data.SJ_Resut11 = SJDebug.SJ_Resut11;
                data.SJ_Resut12 = SJDebug.SJ_Resut12;
                data.SJ_Resut13 = SJDebug.SJ_Resut13;
                data.SJ_Resut14 = SJDebug.SJ_Resut14;
                data.SJ_Resut15 = SJDebug.SJ_Resut15;
                data.SJ_Resut16 = SJDebug.SJ_Resut16;
                return true;
            }
            Array values = null;
            #region serverHandles
            Array serverHandles = new int[17] { 0
                , this.SJ_Resut1.ServerHandle
                , this.SJ_Resut2.ServerHandle
                , this.SJ_Resut3.ServerHandle
                , this.SJ_Resut4.ServerHandle
                , this.SJ_Resut5.ServerHandle
                , this.SJ_Resut6.ServerHandle
                , this.SJ_Resut7.ServerHandle
                , this.SJ_Resut8.ServerHandle
                , this.SJ_Resut9.ServerHandle
                , this.SJ_Resut10.ServerHandle
                , this.SJ_Resut11.ServerHandle
                , this.SJ_Resut12.ServerHandle
                , this.SJ_Resut13.ServerHandle
                , this.SJ_Resut14.ServerHandle
                , this.SJ_Resut15.ServerHandle
                , this.SJ_Resut16.ServerHandle
            };
            #endregion
            object objQ;
            object objT;
            Array errors;
            try
            {
                this._MyGroup_Result.SyncRead(1, 16, ref serverHandles, out values, out errors, out objQ, out objT);
            }
            catch (Exception ex)
            {
                sErr = string.Format("首检结果OPC读取出错01：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            if (values == null)
            {
                sErr = "首检结果OPC读取出错:values为空！";
                return false;
            }
            if (values.Length != 16)
            {
                sErr = string.Format("首检结果OPC读取出错:values长度为{0}，不是预期的16！", values.Length);
                return false;
            }
            Array arrQ = objQ as Array;
            if (arrQ == null)
            {
                sErr = "首检结果OPC读取出错:qualitys为空！";
                return false;
            }
            if (arrQ.Length != 16)
            {
                sErr = string.Format("首检结果OPC读取出错:qualitys长度为{0}，不是预期的16！", values.Length);
                return false;
            }
            //解析数值
            int iIndex = 1;
            
            decimal decValue;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut1 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut2 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut3 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut4 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut5 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut6 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut7 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut8 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut9 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut10 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut11 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut12 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut13 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut14 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut15 = decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.SJ_Resut16 = decValue;
            //iIndex++;
            return true;
            
        }
        private bool GetMyDecimal(out decimal decValue,int iIndex, object objQItem,object objValue, out string sErr)
        {
            decValue = 0M;
            if (objQItem == null)
            {
                sErr = $"首检结果值[index={iIndex}]返回的Quality为空！";
                return false;
            }
            else if (objQItem.ToString() != "192")
            {
                sErr = $"首检结果值[index={iIndex}]返回的Quality为{objQItem.ToString()}不是预期的192！";
                return false;
            }
            else
            {
                if (objValue == null)
                {
                    decValue = 0M;
                }
                else
                {
                    float fValue;
                    if (!float.TryParse(objValue.ToString(), out fValue))
                    {
                        sErr = $"返回的值为[{objValue.ToString()}]不是数值类型！";
                        return false;
                    }
                    decValue = (decimal)fValue;
                }
                sErr = string.Empty;
                return true;
            }
        }
        #endregion
        #region 设置WorkState
        public bool SetWorkState(short iValue,out string sErr)
        {
            if(this.IsDebug)
            {
                SJDebug.WorkState = iValue;
                sErr = string.Empty;
                return true;
            }
            if (this.SJ_Work == null)
            {
                sErr = "SJ_Work复位失败：opc为空！";
                return false;
            }
            else if (this.SJ_Work._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "SJ_Work复位失败：OPCItem为空，且初始化出错：" + sErr;
                    return false;
                }
            }
            if (this.SJ_Work.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "SJ_Work复位失败：OPCItemHandle值为0，但重新初始化时出错：" + sErr;
                    return false;
                }
            }
            if (!this.SJ_Work.WriteData(iValue, out sErr))
            {
                sErr = "SJ_Work复位出错：" + sErr;
                return false;
            }
            return true;
        }
        #endregion
        #region 设置结果值为-1
        public bool ResetResult(bool blReWrite, out string sErr)
        {
            if (this.IsDebug)
            {

                sErr = string.Empty;
                return true;
            }
            Array serverHandles = new int[17] { 0
                , this.SJ_Resut1.ServerHandle
                , this.SJ_Resut2.ServerHandle
                , this.SJ_Resut3.ServerHandle
                , this.SJ_Resut4.ServerHandle
                , this.SJ_Resut5.ServerHandle
                , this.SJ_Resut6.ServerHandle
                , this.SJ_Resut7.ServerHandle
                , this.SJ_Resut8.ServerHandle
                , this.SJ_Resut9.ServerHandle
                , this.SJ_Resut10.ServerHandle
                , this.SJ_Resut11.ServerHandle
                , this.SJ_Resut12.ServerHandle
                , this.SJ_Resut13.ServerHandle
                , this.SJ_Resut14.ServerHandle
                , this.SJ_Resut15.ServerHandle
                , this.SJ_Resut16.ServerHandle
            };
            Array values = new object[17] { "",
                -1F,
                -1F,
                -1F,
                -1F,
                -1F,
                -1F,
                -1F,
                -1F,
                -1F,
                -1F,
                -1F,
                -1F,
                -1F,
                -1F,
                -1F,
                -1F
                 };
            Array errors;
            try
            {
                this._MyGroup_Result.SyncWrite(16, ref serverHandles, ref values, out errors);
            }
            catch (Exception ex)
            {
                if (!blReWrite)
                {
                    //此时不是第二次调用了
                    if (!this.InitServer(out sErr)) return false;
                    return this.ResetResult(true, out sErr);
                }
                else
                {
                    sErr = string.Format("复位首检结果出错：{0}({1})", ex.Message, ex.Source);
                }
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        #endregion
    }
    public class OPCHelperBat : OPCHelperBase
    {
        OPCServer _Server = null;
        OPCGroups _ServerGroups = null;
        //电池组1信息
        public OPCGroup _MyGroup_Bat1 = null;
        //电池组2信息
        public OPCGroup _MyGroup_Bat2 = null;
        #region 写入对象
        public JpsOPC.MyItemValue _BatCodeValue1 = null;
        public JpsOPC.MyItemValue _BatCodeValue2 = null;
        //电池组1的开关量存储（short类型）
        public JpsOPC.MyItemValue _BatBitValue1 = null;//存储电池1~10开关量信息的值
        //电池组2的开关量存储（short类型）
        public JpsOPC.MyItemValue _BatBitValue2 = null;//存储电池11~20开关量信息的值

        //电池组1的开关量数据复位（布尔类型）
        public JpsOPC.MyItemValue _Bat_Bool1Reset = null;//通知PLC复位
        //电池组2的开关量数据复位（布尔类型）
        public JpsOPC.MyItemValue _Bat_Bool2Reset = null;//通知PLC复位

        //告知上位机将电池信息存储至Bat_Bool1还是Bat_Bool2（short类型）
        public JpsOPC.MyItemValue _Bat_BlockNo = null;//关键字段，标识存入1还是2的
        #endregion
        #region 南京中比添加电芯原始数据
        public JpsOPC.MyItemValue Exp_DxCapacity1 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity2 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity3 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity4 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity5 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity6 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity7 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity8 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity9 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity10 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity11 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity12 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity13 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity14 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity15 = null;
        public JpsOPC.MyItemValue Exp_DxCapacity16 = null;
        //内阻电压
        public JpsOPC.MyItemValue Exp_DxV1 = null;
        public JpsOPC.MyItemValue Exp_DxR1 = null;
        public JpsOPC.MyItemValue Exp_DxV2 = null;
        public JpsOPC.MyItemValue Exp_DxR2 = null;
        public JpsOPC.MyItemValue Exp_DxV3 = null;
        public JpsOPC.MyItemValue Exp_DxR3 = null;
        public JpsOPC.MyItemValue Exp_DxV4 = null;
        public JpsOPC.MyItemValue Exp_DxR4 = null;
        public JpsOPC.MyItemValue Exp_DxV5 = null;
        public JpsOPC.MyItemValue Exp_DxR5 = null;
        public JpsOPC.MyItemValue Exp_DxV6 = null;
        public JpsOPC.MyItemValue Exp_DxR6 = null;
        public JpsOPC.MyItemValue Exp_DxV7 = null;
        public JpsOPC.MyItemValue Exp_DxR7 = null;
        public JpsOPC.MyItemValue Exp_DxV8 = null;
        public JpsOPC.MyItemValue Exp_DxR8 = null;
        public JpsOPC.MyItemValue Exp_DxV9 = null;
        public JpsOPC.MyItemValue Exp_DxR9 = null;
        public JpsOPC.MyItemValue Exp_DxV10 = null;
        public JpsOPC.MyItemValue Exp_DxR10 = null;
        public JpsOPC.MyItemValue Exp_DxV11 = null;
        public JpsOPC.MyItemValue Exp_DxR11 = null;
        public JpsOPC.MyItemValue Exp_DxV12 = null;
        public JpsOPC.MyItemValue Exp_DxR12 = null;
        public JpsOPC.MyItemValue Exp_DxV13 = null;
        public JpsOPC.MyItemValue Exp_DxR13 = null;
        public JpsOPC.MyItemValue Exp_DxV14 = null;
        public JpsOPC.MyItemValue Exp_DxR14 = null;
        public JpsOPC.MyItemValue Exp_DxV15 = null;
        public JpsOPC.MyItemValue Exp_DxR15 = null;
        public JpsOPC.MyItemValue Exp_DxV16 = null;
        public JpsOPC.MyItemValue Exp_DxR16 = null;
        #endregion
        public OPCHelperBat()
        {
        }
        #region 公共函数
        public bool InitServer(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (_Server == null)
            {
                try
                {
                    this._Server = new OPCServer();
                }
                catch (Exception ex)
                {
                    sErr = "初始化Server出错：" + ex.Message + "(" + ex.Source + ")";
                    return false;
                }
            }
            if (this._Server.ServerState != (int)OPCServerState.OPCRunning)
            {
                try
                {
                    this._Server.Connect("KEPware.KEPServerEx.V6", "");
                }
                catch (Exception ex)
                {
                    sErr = string.Format("server初始化出错：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
                //重新连接过的话重新定义组
                _ServerGroups = null;
                //重新读取opcItem
                if (this._BatCodeValue1 != null)
                    this._BatCodeValue1.InitItem();
                if (this._BatCodeValue2 != null)
                    this._BatCodeValue2.InitItem();
                if (this._BatBitValue1 != null)
                    this._BatBitValue1.InitItem();
                if (this._BatBitValue2 != null)
                    this._BatBitValue2.InitItem();

                if (this._Bat_Bool1Reset != null)
                    this._Bat_Bool1Reset.InitItem();
                if (this._Bat_Bool2Reset != null)
                    this._Bat_Bool2Reset.InitItem();

                if (this._Bat_BlockNo != null)
                    this._Bat_BlockNo.InitItem();
                #region 南京中比添加
                if (this.Exp_DxCapacity1 != null)
                    this.Exp_DxCapacity1.InitItem();
                if (this.Exp_DxCapacity2 != null)
                    this.Exp_DxCapacity2.InitItem();
                if (this.Exp_DxCapacity3 != null)
                    this.Exp_DxCapacity3.InitItem();
                if (this.Exp_DxCapacity4 != null)
                    this.Exp_DxCapacity4.InitItem();
                if (this.Exp_DxCapacity5 != null)
                    this.Exp_DxCapacity5.InitItem();
                if (this.Exp_DxCapacity6 != null)
                    this.Exp_DxCapacity6.InitItem();
                if (this.Exp_DxCapacity7 != null)
                    this.Exp_DxCapacity7.InitItem();
                if (this.Exp_DxCapacity8 != null)
                    this.Exp_DxCapacity8.InitItem();
                if (this.Exp_DxCapacity9 != null)
                    this.Exp_DxCapacity9.InitItem();
                if (this.Exp_DxCapacity10 != null)
                    this.Exp_DxCapacity10.InitItem();
                if (this.Exp_DxCapacity11 != null)
                    this.Exp_DxCapacity11.InitItem();
                if (this.Exp_DxCapacity12 != null)
                    this.Exp_DxCapacity12.InitItem();
                if (this.Exp_DxCapacity13 != null)
                    this.Exp_DxCapacity13.InitItem();
                if (this.Exp_DxCapacity14 != null)
                    this.Exp_DxCapacity14.InitItem();
                if (this.Exp_DxCapacity15 != null)
                    this.Exp_DxCapacity15.InitItem();
                if (this.Exp_DxCapacity16 != null)
                    this.Exp_DxCapacity16.InitItem();
                //内阻电压
                if (this.Exp_DxV1 != null)
                    this.Exp_DxV1.InitItem();
                if (this.Exp_DxR1 != null)
                    this.Exp_DxR1.InitItem();
                if (this.Exp_DxV2 != null)
                    this.Exp_DxV2.InitItem();
                if (this.Exp_DxR2 != null)
                    this.Exp_DxR2.InitItem();
                if (this.Exp_DxV3 != null)
                    this.Exp_DxV3.InitItem();
                if (this.Exp_DxR3 != null)
                    this.Exp_DxR3.InitItem();
                if (this.Exp_DxV4 != null)
                    this.Exp_DxV4.InitItem();
                if (this.Exp_DxR4 != null)
                    this.Exp_DxR4.InitItem();
                if (this.Exp_DxV5 != null)
                    this.Exp_DxV5.InitItem();
                if (this.Exp_DxR5 != null)
                    this.Exp_DxR5.InitItem();
                if (this.Exp_DxV6 != null)
                    this.Exp_DxV6.InitItem();
                if (this.Exp_DxR6 != null)
                    this.Exp_DxR6.InitItem();
                if (this.Exp_DxV7 != null)
                    this.Exp_DxV7.InitItem();
                if (this.Exp_DxR7 != null)
                    this.Exp_DxR7.InitItem();
                if (this.Exp_DxV8 != null)
                    this.Exp_DxV8.InitItem();
                if (this.Exp_DxR8 != null)
                    this.Exp_DxR8.InitItem();
                if (this.Exp_DxV9 != null)
                    this.Exp_DxV9.InitItem();
                if (this.Exp_DxR9 != null)
                    this.Exp_DxR9.InitItem();
                if (this.Exp_DxV10 != null)
                    this.Exp_DxV10.InitItem();
                if (this.Exp_DxR10 != null)
                    this.Exp_DxR10.InitItem();
                if (this.Exp_DxV11 != null)
                    this.Exp_DxV11.InitItem();
                if (this.Exp_DxR11 != null)
                    this.Exp_DxR11.InitItem();
                if (this.Exp_DxV12 != null)
                    this.Exp_DxV12.InitItem();
                if (this.Exp_DxR12 != null)
                    this.Exp_DxR12.InitItem();
                if (this.Exp_DxV13 != null)
                    this.Exp_DxV13.InitItem();
                if (this.Exp_DxR13 != null)
                    this.Exp_DxR13.InitItem();
                if (this.Exp_DxV14 != null)
                    this.Exp_DxV14.InitItem();
                if (this.Exp_DxR14 != null)
                    this.Exp_DxR14.InitItem();
                if (this.Exp_DxV15 != null)
                    this.Exp_DxV15.InitItem();
                if (this.Exp_DxR15 != null)
                    this.Exp_DxR15.InitItem();
                if (this.Exp_DxV16 != null)
                    this.Exp_DxV16.InitItem();
                if (this.Exp_DxR16 != null)
                    this.Exp_DxR16.InitItem();

                #endregion
            }
            //添加组
            if (_ServerGroups == null)
            {
                _ServerGroups = this._Server.OPCGroups;
                _ServerGroups.DefaultGroupIsActive = true; //设置组集合默认为激活状态
                //下面这个几个暂时不设定，看看是否有异常，因为DefaultGroupUpdateRate这个值很关键，估计是与写入和读取的频率相关了，应该设置到某个单一的节点为好。
                _ServerGroups.DefaultGroupDeadband = 0;    //设置死区
                _ServerGroups.DefaultGroupUpdateRate = 200;//设置更新频率
                try
                {
                    //电池组1
                    _MyGroup_Bat1 = _ServerGroups.Add("BatGroup1");
                    _MyGroup_Bat1.UpdateRate = 100; //刷新频率
                    _MyGroup_Bat1.IsActive = true;
                    //电池组2
                    _MyGroup_Bat2 = _ServerGroups.Add("BatGroup2");
                    _MyGroup_Bat2.UpdateRate = 100;
                    _MyGroup_Bat2.IsActive = true;
                }
                catch (Exception ex)
                {
                    sErr = string.Format("创建各组失败：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
            }
            if (!this.InitMyItems(out sErr))
            {
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool InitMyItems(out string sErr)
        {
            if (this._BatCodeValue1 == null)
                _BatCodeValue1 = new MyItemValue(OPCItemTitle + "Bat_Code1");
            if (this._BatCodeValue2 == null)
                _BatCodeValue2 = new MyItemValue(OPCItemTitle + "Bat_Code2");

            if (this._BatBitValue1 == null)
                _BatBitValue1 = new MyItemValue(OPCItemTitle + "Bat_Bool1");
            if (this._BatBitValue2 == null)
                _BatBitValue2 = new MyItemValue(OPCItemTitle + "Bat_Bool2");

            if (this._Bat_Bool1Reset == null)
                _Bat_Bool1Reset = new MyItemValue(OPCItemTitle + "Bat_Bool1Reset");
            if (this._Bat_Bool2Reset == null)
                _Bat_Bool2Reset = new MyItemValue(OPCItemTitle + "Bat_Bool2Reset");

            if (this._Bat_BlockNo == null)
                _Bat_BlockNo = new MyItemValue(OPCItemTitle + "Bat_BlockNo");
            #region 南京中比添加
            if (this.Exp_DxCapacity1 == null)
                Exp_DxCapacity1 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity1");
            if (this.Exp_DxCapacity2 == null)
                Exp_DxCapacity2 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity2");
            if (this.Exp_DxCapacity3 == null)
                Exp_DxCapacity3 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity3");
            if (this.Exp_DxCapacity4 == null)
                Exp_DxCapacity4 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity4");
            if (this.Exp_DxCapacity5 == null)
                Exp_DxCapacity5 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity5");
            if (this.Exp_DxCapacity6 == null)
                Exp_DxCapacity6 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity6");
            if (this.Exp_DxCapacity7 == null)
                Exp_DxCapacity7 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity7");
            if (this.Exp_DxCapacity8 == null)
                Exp_DxCapacity8 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity8");
            if (this.Exp_DxCapacity9 == null)
                Exp_DxCapacity9 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity9");
            if (this.Exp_DxCapacity10 == null)
                Exp_DxCapacity10 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity10");
            if (this.Exp_DxCapacity11 == null)
                Exp_DxCapacity11 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity11");
            if (this.Exp_DxCapacity12 == null)
                Exp_DxCapacity12 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity12");
            if (this.Exp_DxCapacity13 == null)
                Exp_DxCapacity13 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity13");
            if (this.Exp_DxCapacity14 == null)
                Exp_DxCapacity14 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity14");
            if (this.Exp_DxCapacity15 == null)
                Exp_DxCapacity15 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity15");
            if (this.Exp_DxCapacity16 == null)
                Exp_DxCapacity16 = new MyItemValue(OPCItemTitle + "Exp_DxCapacity16");
            //内阻电压
            if (this.Exp_DxV1 == null)
                Exp_DxV1 = new MyItemValue(OPCItemTitle + "Exp_DxV1");
            if (this.Exp_DxR1 == null)
                Exp_DxR1 = new MyItemValue(OPCItemTitle + "Exp_DxR1");
            if (this.Exp_DxV2 == null)
                Exp_DxV2 = new MyItemValue(OPCItemTitle + "Exp_DxV2");
            if (this.Exp_DxR2 == null)
                Exp_DxR2 = new MyItemValue(OPCItemTitle + "Exp_DxR2");
            if (this.Exp_DxV3 == null)
                Exp_DxV3 = new MyItemValue(OPCItemTitle + "Exp_DxV3");
            if (this.Exp_DxR3 == null)
                Exp_DxR3 = new MyItemValue(OPCItemTitle + "Exp_DxR3");
            if (this.Exp_DxV4 == null)
                Exp_DxV4 = new MyItemValue(OPCItemTitle + "Exp_DxV4");
            if (this.Exp_DxR4 == null)
                Exp_DxR4 = new MyItemValue(OPCItemTitle + "Exp_DxR4");
            if (this.Exp_DxV5 == null)
                Exp_DxV5 = new MyItemValue(OPCItemTitle + "Exp_DxV5");
            if (this.Exp_DxR5 == null)
                Exp_DxR5 = new MyItemValue(OPCItemTitle + "Exp_DxR5");
            if (this.Exp_DxV6 == null)
                Exp_DxV6 = new MyItemValue(OPCItemTitle + "Exp_DxV6");
            if (this.Exp_DxR6 == null)
                Exp_DxR6 = new MyItemValue(OPCItemTitle + "Exp_DxR6");
            if (this.Exp_DxV7 == null)
                Exp_DxV7 = new MyItemValue(OPCItemTitle + "Exp_DxV7");
            if (this.Exp_DxR7 == null)
                Exp_DxR7 = new MyItemValue(OPCItemTitle + "Exp_DxR7");
            if (this.Exp_DxV8 == null)
                Exp_DxV8 = new MyItemValue(OPCItemTitle + "Exp_DxV8");
            if (this.Exp_DxR8 == null)
                Exp_DxR8 = new MyItemValue(OPCItemTitle + "Exp_DxR8");
            if (this.Exp_DxV9 == null)
                Exp_DxV9 = new MyItemValue(OPCItemTitle + "Exp_DxV9");
            if (this.Exp_DxR9 == null)
                Exp_DxR9 = new MyItemValue(OPCItemTitle + "Exp_DxR9");
            if (this.Exp_DxV10 == null)
                Exp_DxV10 = new MyItemValue(OPCItemTitle + "Exp_DxV10");
            if (this.Exp_DxR10 == null)
                Exp_DxR10 = new MyItemValue(OPCItemTitle + "Exp_DxR10");
            if (this.Exp_DxV11 == null)
                Exp_DxV11 = new MyItemValue(OPCItemTitle + "Exp_DxV11");
            if (this.Exp_DxR11 == null)
                Exp_DxR11 = new MyItemValue(OPCItemTitle + "Exp_DxR11");
            if (this.Exp_DxV12 == null)
                Exp_DxV12 = new MyItemValue(OPCItemTitle + "Exp_DxV12");
            if (this.Exp_DxR12 == null)
                Exp_DxR12 = new MyItemValue(OPCItemTitle + "Exp_DxR12");
            if (this.Exp_DxV13 == null)
                Exp_DxV13 = new MyItemValue(OPCItemTitle + "Exp_DxV13");
            if (this.Exp_DxR13 == null)
                Exp_DxR13 = new MyItemValue(OPCItemTitle + "Exp_DxR13");
            if (this.Exp_DxV14 == null)
                Exp_DxV14 = new MyItemValue(OPCItemTitle + "Exp_DxV14");
            if (this.Exp_DxR14 == null)
                Exp_DxR14 = new MyItemValue(OPCItemTitle + "Exp_DxR14");
            if (this.Exp_DxV15 == null)
                Exp_DxV15 = new MyItemValue(OPCItemTitle + "Exp_DxV15");
            if (this.Exp_DxR15 == null)
                Exp_DxR15 = new MyItemValue(OPCItemTitle + "Exp_DxR15");
            if (this.Exp_DxV16 == null)
                Exp_DxV16 = new MyItemValue(OPCItemTitle + "Exp_DxV16");
            if (this.Exp_DxR16 == null)
                Exp_DxR16 = new MyItemValue(OPCItemTitle + "Exp_DxR16");

            #endregion
            //在OPCGroup中添加IOPCItem
            if (this._MyGroup_Bat1 == null)
            {
                sErr = "初始化电池组item时失败，因为group1为空。";
                return false;
            }
            if (this._MyGroup_Bat2 == null)
            {
                sErr = "初始化电池组item时失败，因为group2为空。";
                return false;
            }
            if (_MyGroup_Bat1.OPCItems == null)
            {
                sErr = "初始化电池组item时失败，因为group1.OPCItems为空。";
                return false;
            }
            if (_MyGroup_Bat2.OPCItems == null)
            {
                sErr = "初始化电池组item时失败，因为group2.OPCItems为空。";
                return false;
            }
            //处理电池组1的
            if (!InitMyItems_AddItem(this._BatCodeValue1, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this._BatBitValue1, this._MyGroup_Bat1, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this._Bat_Bool1Reset, this._MyGroup_Bat1, true, out sErr))
            {
                return false;
            }
            //处理电池组2的
            if (!InitMyItems_AddItem(this._BatCodeValue2, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this._BatBitValue2, this._MyGroup_Bat2, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this._Bat_Bool2Reset, this._MyGroup_Bat2, true, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this._Bat_BlockNo, this._MyGroup_Bat1, true, out sErr))
            {
                return false;
            }
            #region 南京中比添加
            if (!InitMyItems_AddItem(this.Exp_DxCapacity1, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity2, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity3, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity4, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity5, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity6, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity7, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity8, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity9, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity10, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity11, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity12, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity13, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity14, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity15, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxCapacity16, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }





            if (!InitMyItems_AddItem(this.Exp_DxV1, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR1, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV2, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR2, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV3, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR3, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV4, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR4, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV5, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR5, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV6, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR6, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV7, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR7, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV8, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR8, this._MyGroup_Bat1, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV9, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR9, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV10, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR10, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV11, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR11, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV12, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR12, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV13, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR13, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV14, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR14, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV15, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR15, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxV16, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_DxR16, this._MyGroup_Bat2, false, out sErr))
            {
                return false;
            }
            #endregion
            return true;
        }
        private bool InitMyItems_AddItem(MyItemValue myItem, OPCGroup targetGroup, bool saveItem, out string sErr)
        {
            if (myItem.ServerHandle <= 0)
            {
                if (this.IsDebug)
                {
                    sErr = string.Empty;
                    return true;
                }
                //此时添加Item
                _ClientHandle++;
                OPCItem item = null;
                string strTagName = myItem.TagName;
                try
                {
                    item = targetGroup.OPCItems.AddItem(strTagName, _ClientHandle);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("添加Item：{0}，出错:{1}({2})", myItem.TagName, ex.Message, ex.Source);
                    return false;
                }
                if (item == null)
                {
                    sErr = string.Format("添加Item：{0}失败，返回为空。", myItem.TagName);
                    return false;
                }
                if (item.ServerHandle <= 0)
                {
                    sErr = string.Format("添加Item：{0}失败，返回值ServerHandle为{1}。", myItem.TagName, myItem.ServerHandle);
                    return false;
                }
                myItem.ServerHandle = item.ServerHandle;
                myItem.ClientHandle = this._ClientHandle;
                if (saveItem)
                    myItem._OPCItem = item;
            }
            sErr = string.Empty;
            return true;
        }
        public bool CloseOPC(out string sErr)
        {
            sErr = "";
            if (this._Server == null) return true;
            try
            {
                this._Server.Disconnect();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
                return false;
            }
            return true;
        }
        public bool WriteGroup1(string sBatsString, int iBatsValue, out string sErr, bool blReWrite = false)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            //写入数据
            Array serverHandles = new int[3] { 0, this._BatCodeValue1.ServerHandle, this._BatBitValue1.ServerHandle };
            Array values = new object[3] { "", sBatsString, iBatsValue };
            Array errors;
            try
            {
                this._MyGroup_Bat1.SyncWrite(2, ref serverHandles, ref values, out errors);
            }
            catch (Exception ex)
            {
                if (!blReWrite)
                {
                    //此时不是第二次调用了
                    if (!this.InitServer(out sErr)) return false;
                    return this.WriteGroup1(sBatsString, iBatsValue, out sErr, true);
                }
                else
                {
                    sErr = string.Format("电池组1Group写入出错：{0}({1})", ex.Message, ex.Source);
                }
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool WriteGroup2(string sBatsString, int iBatsValue, out string sErr, bool blReWrite = false)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            //写入数据
            Array serverHandles = new int[3] { 0, this._BatCodeValue2.ServerHandle, this._BatBitValue2.ServerHandle };
            Array values = new object[3] { "", sBatsString, iBatsValue };
            Array errors;
            try
            {
                this._MyGroup_Bat2.SyncWrite(2, ref serverHandles, ref values, out errors);
            }
            catch (Exception ex)
            {
                if (!blReWrite)
                {
                    //此时不是第二次调用了
                    if (!this.InitServer(out sErr)) return false;
                    return this.WriteGroup2(sBatsString, iBatsValue, out sErr, true);
                }
                else
                {
                    sErr = string.Format("电池组2Group写入出错：{0}({1})", ex.Message, ex.Source);
                }
                return false;
            }
            sErr = string.Empty;
            return true;
        }

        #endregion
        #region 南京中比写入电芯原始数据
        public bool WriteDXOrg1(decimal decCapacity1,decimal decR1,decimal decV1
            , decimal decCapacity2, decimal decR2, decimal decV2
            , decimal decCapacity3, decimal decR3, decimal decV3
            , decimal decCapacity4, decimal decR4, decimal decV4
            , decimal decCapacity5, decimal decR5, decimal decV5
            , decimal decCapacity6, decimal decR6, decimal decV6
            , decimal decCapacity7, decimal decR7, decimal decV7
            , decimal decCapacity8, decimal decR8, decimal decV8
            , out string sErr, bool blReWrite = false)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            //写入数据
            Array serverHandles = new int[25] { 0,
                this.Exp_DxCapacity1.ServerHandle,
                this.Exp_DxCapacity2.ServerHandle,
                this.Exp_DxCapacity3.ServerHandle,
                this.Exp_DxCapacity4.ServerHandle,
                this.Exp_DxCapacity5.ServerHandle,
                this.Exp_DxCapacity6.ServerHandle,
                this.Exp_DxCapacity7.ServerHandle,
                this.Exp_DxCapacity8.ServerHandle,
                this.Exp_DxR1.ServerHandle,
                this.Exp_DxR2.ServerHandle,
                this.Exp_DxR3.ServerHandle,
                this.Exp_DxR4.ServerHandle,
                this.Exp_DxR5.ServerHandle,
                this.Exp_DxR6.ServerHandle,
                this.Exp_DxR7.ServerHandle,
                this.Exp_DxR8.ServerHandle,
                this.Exp_DxV1.ServerHandle,
                this.Exp_DxV2.ServerHandle,
                this.Exp_DxV3.ServerHandle,
                this.Exp_DxV4.ServerHandle,
                this.Exp_DxV5.ServerHandle,
                this.Exp_DxV6.ServerHandle,
                this.Exp_DxV7.ServerHandle,
                this.Exp_DxV8.ServerHandle,
            };
            Array values = new object[25] {""
            ,decCapacity1
            ,decCapacity2
            ,decCapacity3
            ,decCapacity4
            ,decCapacity5
            ,decCapacity6
            ,decCapacity7
            ,decCapacity8
            ,decR1
            ,decR2
            ,decR3
            ,decR4
            ,decR5
            ,decR6
            ,decR7
            ,decR8
            ,decV1
            ,decV2
            ,decV3
            ,decV4
            ,decV5
            ,decV6
            ,decV7
            ,decV8
            };
            Array errors;
            try
            {
                this._MyGroup_Bat1.SyncWrite(24, ref serverHandles, ref values, out errors);
            }
            catch (Exception ex)
            {
                if (!blReWrite)
                {
                    //此时不是第二次调用了
                    if (!this.InitServer(out sErr)) return false;
                    return this.WriteDXOrg1(decCapacity1, decR1, decV1
            , decCapacity2, decR2, decV2
            , decCapacity3, decR3, decV3
            , decCapacity4, decR4, decV4
            , decCapacity5, decR5, decV5
            , decCapacity6, decR6, decV6
            , decCapacity7, decR7, decV7
            , decCapacity8, decR8, decV8, out sErr, true);
                }
                else
                {
                    sErr = string.Format("电池组1的原始电芯数据写入出错：{0}({1})", ex.Message, ex.Source);
                }
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool WriteDXOrg2(decimal decCapacity1, decimal decR1, decimal decV1
            , decimal decCapacity2, decimal decR2, decimal decV2
            , decimal decCapacity3, decimal decR3, decimal decV3
            , decimal decCapacity4, decimal decR4, decimal decV4
            , decimal decCapacity5, decimal decR5, decimal decV5
            , decimal decCapacity6, decimal decR6, decimal decV6
            , decimal decCapacity7, decimal decR7, decimal decV7
            , decimal decCapacity8, decimal decR8, decimal decV8
            , out string sErr, bool blReWrite = false)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            //写入数据
            Array serverHandles = new int[25] { 0,
            this.Exp_DxCapacity9.ServerHandle,
            this.Exp_DxCapacity10.ServerHandle,
            this.Exp_DxCapacity11.ServerHandle,
            this.Exp_DxCapacity12.ServerHandle,
            this.Exp_DxCapacity13.ServerHandle,
            this.Exp_DxCapacity14.ServerHandle,
            this.Exp_DxCapacity15.ServerHandle,
            this.Exp_DxCapacity16.ServerHandle,
            this.Exp_DxR9.ServerHandle,
            this.Exp_DxR10.ServerHandle,
            this.Exp_DxR11.ServerHandle,
            this.Exp_DxR12.ServerHandle,
            this.Exp_DxR13.ServerHandle,
            this.Exp_DxR14.ServerHandle,
            this.Exp_DxR15.ServerHandle,
            this.Exp_DxR16.ServerHandle,
            this.Exp_DxV9.ServerHandle,
            this.Exp_DxV10.ServerHandle,
            this.Exp_DxV11.ServerHandle,
            this.Exp_DxV12.ServerHandle,
            this.Exp_DxV13.ServerHandle,
            this.Exp_DxV14.ServerHandle,
            this.Exp_DxV15.ServerHandle,
            this.Exp_DxV16.ServerHandle,
            };
            Array values = new object[25] {""
            ,decCapacity1
            ,decCapacity2
            ,decCapacity3
            ,decCapacity4
            ,decCapacity5
            ,decCapacity6
            ,decCapacity7
            ,decCapacity8
            ,decR1
            ,decR2
            ,decR3
            ,decR4
            ,decR5
            ,decR6
            ,decR7
            ,decR8
            ,decV1
            ,decV2
            ,decV3
            ,decV4
            ,decV5
            ,decV6
            ,decV7
            ,decV8
            };
            Array errors;
            try
            {
                this._MyGroup_Bat2.SyncWrite(24, ref serverHandles, ref values, out errors);
            }
            catch (Exception ex)
            {
                if (!blReWrite)
                {
                    //此时不是第二次调用了
                    if (!this.InitServer(out sErr)) return false;
                    return this.WriteDXOrg2(decCapacity1, decR1, decV1
            , decCapacity2, decR2, decV2
            , decCapacity3, decR3, decV3
            , decCapacity4, decR4, decV4
            , decCapacity5, decR5, decV5
            , decCapacity6, decR6, decV6
            , decCapacity7, decR7, decV7
            , decCapacity8, decR8, decV8, out sErr, true);
                }
                else
                {
                    sErr = string.Format("电池组2的原始电芯数据写入出错：{0}({1})", ex.Message, ex.Source);
                }
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        #endregion
        #region  特殊功能函数
        public bool ReadBatBitValue_Group1(out int iValue, out string sErr)
        {
            if (!this.ReadBatBitValue(this._BatBitValue1, out iValue, out sErr))
                return false;
            return true;
        }
        public bool ReadBatBitValue_Group2(out int iValue, out string sErr)
        {
            if (!this.ReadBatBitValue(this._BatBitValue2, out iValue, out sErr))
                return false;
            return true;
        }
        private bool ReadBatBitValue(JpsOPC.MyItemValue myItemValue, out int iValue, out string sErr)
        {
            if (myItemValue == null)
            {
                sErr = "电池的开关量对象还未初始化";
                iValue = 0;
                return false;
            }
            else if (myItemValue._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "电池的开关量对象为空，但初始化时出错：" + sErr;
                    iValue = 0;
                    return false;
                }
            }
            if (myItemValue.ServerHandle == 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "电池开关量对象值为0，但重新初始化时出错：" + sErr;
                    iValue = 0;
                    return false;
                }
            }
            //此时有效了，直接读取值
            object objValue;
            if (!myItemValue.ReadData(out objValue, out sErr))
            {
                iValue = 0;
                return false;
            }
            if (objValue == null)
            {
                sErr = string.Format("item对象[{0}]的返回值NULL不是预期的短整型。", myItemValue.TagName);
                iValue = 0;
                return false;
            }
            //此时读取成功了，则转换
            if (!int.TryParse(objValue.ToString(), out iValue))
            {
                sErr = string.Format("item对象[{0}]的返回值\"{1}\"不是预期的短整型。", myItemValue.TagName, objValue.ToString());
                iValue = 0;
                return false;
            }
            return true;
        }
        public bool ReadTargetBlockNo( out short iValue, out string sErr)
        {
            if (this._Bat_BlockNo == null)
            {
                sErr = "Bat-BlockNo对象还未初始化";
                iValue = 0;
                return false;
            }
            else if (this._Bat_BlockNo._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "Bat-BlockNo对象为空，但初始化时出错：" + sErr;
                    iValue = 0;
                    return false;
                }
            }
            if (this._Bat_BlockNo.ServerHandle == 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "Bat-BlockNo对象值为0，但重新初始化时出错：" + sErr;
                    iValue = 0;
                    return false;
                }
            }
            //此时有效了，直接读取值
            object objValue;
            if (!this._Bat_BlockNo.ReadData(out objValue, out sErr))
            {
                iValue = 0;
                return false;
            }
            if (objValue == null)
            {
                sErr = string.Format("item对象[{0}]的返回值NULL不是预期的短整型。", this._Bat_BlockNo.TagName);
                iValue = 0;
                return false;
            }
            //此时读取成功了，则转换
            if (!short.TryParse(objValue.ToString(), out iValue))
            {
                sErr = string.Format("item对象[{0}]的返回值\"{1}\"不是预期的短整型。", this._Bat_BlockNo.TagName, objValue.ToString());
                iValue = 0;
                return false;
            }
            return true;
        }
        #endregion
    }
    public class OPCHelperResult : OPCHelperBase
    {
        public bool _IsMacNo4 = false;
        OPCServer _Server = null;
        OPCGroups _ServerGroups = null;
        public OPCGroup _MyGroup_DoNow = null;
        public OPCGroup _MyGroup_Result = null;
        //获取槽号
        public JpsOPC.MyItemValue AT_ReadResult = null;
        public JpsOPC.MyItemValue AT_SNCount = null;
        #region 用于读取结果的opcitem的
        public JpsOPC.MyItemValue Rt_Bat1Code = null;
        public JpsOPC.MyItemValue Rt_Bat1V = null;
        public JpsOPC.MyItemValue Rt_Bat1Dz = null;
        public JpsOPC.MyItemValue Rt_Bat1Cao = null;
        public JpsOPC.MyItemValue Rt_Bat1NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat2Code = null;
        public JpsOPC.MyItemValue Rt_Bat2V = null;
        public JpsOPC.MyItemValue Rt_Bat2Dz = null;
        public JpsOPC.MyItemValue Rt_Bat2Cao = null;
        public JpsOPC.MyItemValue Rt_Bat2NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat3Code = null;
        public JpsOPC.MyItemValue Rt_Bat3V = null;
        public JpsOPC.MyItemValue Rt_Bat3Dz = null;
        public JpsOPC.MyItemValue Rt_Bat3Cao = null;
        public JpsOPC.MyItemValue Rt_Bat3NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat4Code = null;
        public JpsOPC.MyItemValue Rt_Bat4V = null;
        public JpsOPC.MyItemValue Rt_Bat4Dz = null;
        public JpsOPC.MyItemValue Rt_Bat4Cao = null;
        public JpsOPC.MyItemValue Rt_Bat4NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat5Code = null;
        public JpsOPC.MyItemValue Rt_Bat5V = null;
        public JpsOPC.MyItemValue Rt_Bat5Dz = null;
        public JpsOPC.MyItemValue Rt_Bat5Cao = null;
        public JpsOPC.MyItemValue Rt_Bat5NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat6Code = null;
        public JpsOPC.MyItemValue Rt_Bat6V = null;
        public JpsOPC.MyItemValue Rt_Bat6Dz = null;
        public JpsOPC.MyItemValue Rt_Bat6Cao = null;
        public JpsOPC.MyItemValue Rt_Bat6NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat7Code = null;
        public JpsOPC.MyItemValue Rt_Bat7V = null;
        public JpsOPC.MyItemValue Rt_Bat7Dz = null;
        public JpsOPC.MyItemValue Rt_Bat7Cao = null;
        public JpsOPC.MyItemValue Rt_Bat7NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat8Code = null;
        public JpsOPC.MyItemValue Rt_Bat8V = null;
        public JpsOPC.MyItemValue Rt_Bat8Dz = null;
        public JpsOPC.MyItemValue Rt_Bat8Cao = null;
        public JpsOPC.MyItemValue Rt_Bat8NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat9Code = null;
        public JpsOPC.MyItemValue Rt_Bat9V = null;
        public JpsOPC.MyItemValue Rt_Bat9Dz = null;
        public JpsOPC.MyItemValue Rt_Bat9Cao = null;
        public JpsOPC.MyItemValue Rt_Bat9NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat10Code = null;
        public JpsOPC.MyItemValue Rt_Bat10V = null;
        public JpsOPC.MyItemValue Rt_Bat10Dz = null;
        public JpsOPC.MyItemValue Rt_Bat10Cao = null;
        public JpsOPC.MyItemValue Rt_Bat10NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat11Code = null;
        public JpsOPC.MyItemValue Rt_Bat11V = null;
        public JpsOPC.MyItemValue Rt_Bat11Dz = null;
        public JpsOPC.MyItemValue Rt_Bat11Cao = null;
        public JpsOPC.MyItemValue Rt_Bat11NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat12Code = null;
        public JpsOPC.MyItemValue Rt_Bat12V = null;
        public JpsOPC.MyItemValue Rt_Bat12Dz = null;
        public JpsOPC.MyItemValue Rt_Bat12Cao = null;
        public JpsOPC.MyItemValue Rt_Bat12NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat13Code = null;
        public JpsOPC.MyItemValue Rt_Bat13V = null;
        public JpsOPC.MyItemValue Rt_Bat13Dz = null;
        public JpsOPC.MyItemValue Rt_Bat13Cao = null;
        public JpsOPC.MyItemValue Rt_Bat13NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat14Code = null;
        public JpsOPC.MyItemValue Rt_Bat14V = null;
        public JpsOPC.MyItemValue Rt_Bat14Dz = null;
        public JpsOPC.MyItemValue Rt_Bat14Cao = null;
        public JpsOPC.MyItemValue Rt_Bat14NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat15Code = null;
        public JpsOPC.MyItemValue Rt_Bat15V = null;
        public JpsOPC.MyItemValue Rt_Bat15Dz = null;
        public JpsOPC.MyItemValue Rt_Bat15Cao = null;
        public JpsOPC.MyItemValue Rt_Bat15NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat16Code = null;
        public JpsOPC.MyItemValue Rt_Bat16V = null;
        public JpsOPC.MyItemValue Rt_Bat16Dz = null;
        public JpsOPC.MyItemValue Rt_Bat16Cao = null;
        public JpsOPC.MyItemValue Rt_Bat16NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat17Code = null;
        public JpsOPC.MyItemValue Rt_Bat17V = null;
        public JpsOPC.MyItemValue Rt_Bat17Dz = null;
        public JpsOPC.MyItemValue Rt_Bat17Cao = null;
        public JpsOPC.MyItemValue Rt_Bat17NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat18Code = null;
        public JpsOPC.MyItemValue Rt_Bat18V = null;
        public JpsOPC.MyItemValue Rt_Bat18Dz = null;
        public JpsOPC.MyItemValue Rt_Bat18Cao = null;
        public JpsOPC.MyItemValue Rt_Bat18NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat19Code = null;
        public JpsOPC.MyItemValue Rt_Bat19V = null;
        public JpsOPC.MyItemValue Rt_Bat19Dz = null;
        public JpsOPC.MyItemValue Rt_Bat19Cao = null;
        public JpsOPC.MyItemValue Rt_Bat19NGCase = null;
        public JpsOPC.MyItemValue Rt_Bat20Code = null;
        public JpsOPC.MyItemValue Rt_Bat20V = null;
        public JpsOPC.MyItemValue Rt_Bat20Dz = null;
        public JpsOPC.MyItemValue Rt_Bat20Cao = null;
        public JpsOPC.MyItemValue Rt_Bat20NGCase = null;
        #endregion
        #region 南京中比的
        //通道的压差
        public JpsOPC.MyItemValue Exp_Yc1 = null;
        public JpsOPC.MyItemValue Exp_Yc2 = null;
        public JpsOPC.MyItemValue Exp_Yc3 = null;
        public JpsOPC.MyItemValue Exp_Yc4 = null;
        public JpsOPC.MyItemValue Exp_Yc5 = null;
        public JpsOPC.MyItemValue Exp_Yc6 = null;
        public JpsOPC.MyItemValue Exp_Yc7 = null;
        public JpsOPC.MyItemValue Exp_Yc8 = null;
        public JpsOPC.MyItemValue Exp_Yc9 = null;
        public JpsOPC.MyItemValue Exp_Yc10 = null;
        public JpsOPC.MyItemValue Exp_Yc11 = null;
        public JpsOPC.MyItemValue Exp_Yc12 = null;
        public JpsOPC.MyItemValue Exp_Yc13 = null;
        public JpsOPC.MyItemValue Exp_Yc14 = null;
        public JpsOPC.MyItemValue Exp_Yc15 = null;
        public JpsOPC.MyItemValue Exp_Yc16 = null;
        #endregion
        #region 公共函数
        public bool InitServer(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (_Server == null)
            {
                try
                {
                    this._Server = new OPCServer();
                }
                catch (Exception ex)
                {
                    sErr = "ResultOPC：初始化Server出错：" + ex.Message + "(" + ex.Source + ")";
                    return false;
                }
            }
            if (this._Server.ServerState != (int)OPCServerState.OPCRunning)
            {
                try
                {
                    this._Server.Connect("KEPware.KEPServerEx.V6", "");
                }
                catch (Exception ex)
                {
                    sErr = string.Format("ResultOPC：server初始化出错：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
                //重新连接过的话重新定义组
                _ServerGroups = null;
                if (this.AT_ReadResult != null)
                    this.AT_ReadResult.InitItem();
                if(_IsMacNo4)
                {
                    if (this.AT_SNCount != null)
                        this.AT_SNCount.InitItem();
                }
                //重新读取opcItem
                if (this.Rt_Bat1Code != null)
                    this.Rt_Bat1Code.InitItem();
                if (this.Rt_Bat1V != null)
                    this.Rt_Bat1V.InitItem();
                if (this.Rt_Bat1Dz != null)
                    this.Rt_Bat1Dz.InitItem();
                if (this.Rt_Bat1Cao != null)
                    this.Rt_Bat1Cao.InitItem();
                if (this.Rt_Bat1NGCase != null)
                    this.Rt_Bat1NGCase.InitItem();
                if (this.Rt_Bat2Code != null)
                    this.Rt_Bat2Code.InitItem();
                if (this.Rt_Bat2V != null)
                    this.Rt_Bat2V.InitItem();
                if (this.Rt_Bat2Dz != null)
                    this.Rt_Bat2Dz.InitItem();
                if (this.Rt_Bat2Cao != null)
                    this.Rt_Bat2Cao.InitItem();
                if (this.Rt_Bat2NGCase != null)
                    this.Rt_Bat2NGCase.InitItem();
                if (this.Rt_Bat3Code != null)
                    this.Rt_Bat3Code.InitItem();
                if (this.Rt_Bat3V != null)
                    this.Rt_Bat3V.InitItem();
                if (this.Rt_Bat3Dz != null)
                    this.Rt_Bat3Dz.InitItem();
                if (this.Rt_Bat3Cao != null)
                    this.Rt_Bat3Cao.InitItem();
                if (this.Rt_Bat3NGCase != null)
                    this.Rt_Bat3NGCase.InitItem();
                if (this.Rt_Bat4Code != null)
                    this.Rt_Bat4Code.InitItem();
                if (this.Rt_Bat4V != null)
                    this.Rt_Bat4V.InitItem();
                if (this.Rt_Bat4Dz != null)
                    this.Rt_Bat4Dz.InitItem();
                if (this.Rt_Bat4Cao != null)
                    this.Rt_Bat4Cao.InitItem();
                if (this.Rt_Bat4NGCase != null)
                    this.Rt_Bat4NGCase.InitItem();
                if (this.Rt_Bat5Code != null)
                    this.Rt_Bat5Code.InitItem();
                if (this.Rt_Bat5V != null)
                    this.Rt_Bat5V.InitItem();
                if (this.Rt_Bat5Dz != null)
                    this.Rt_Bat5Dz.InitItem();
                if (this.Rt_Bat5Cao != null)
                    this.Rt_Bat5Cao.InitItem();
                if (this.Rt_Bat5NGCase != null)
                    this.Rt_Bat5NGCase.InitItem();
                if (this.Rt_Bat6Code != null)
                    this.Rt_Bat6Code.InitItem();
                if (this.Rt_Bat6V != null)
                    this.Rt_Bat6V.InitItem();
                if (this.Rt_Bat6Dz != null)
                    this.Rt_Bat6Dz.InitItem();
                if (this.Rt_Bat6Cao != null)
                    this.Rt_Bat6Cao.InitItem();
                if (this.Rt_Bat6NGCase != null)
                    this.Rt_Bat6NGCase.InitItem();
                if (this.Rt_Bat7Code != null)
                    this.Rt_Bat7Code.InitItem();
                if (this.Rt_Bat7V != null)
                    this.Rt_Bat7V.InitItem();
                if (this.Rt_Bat7Dz != null)
                    this.Rt_Bat7Dz.InitItem();
                if (this.Rt_Bat7Cao != null)
                    this.Rt_Bat7Cao.InitItem();
                if (this.Rt_Bat7NGCase != null)
                    this.Rt_Bat7NGCase.InitItem();
                if (this.Rt_Bat8Code != null)
                    this.Rt_Bat8Code.InitItem();
                if (this.Rt_Bat8V != null)
                    this.Rt_Bat8V.InitItem();
                if (this.Rt_Bat8Dz != null)
                    this.Rt_Bat8Dz.InitItem();
                if (this.Rt_Bat8Cao != null)
                    this.Rt_Bat8Cao.InitItem();
                if (this.Rt_Bat8NGCase != null)
                    this.Rt_Bat8NGCase.InitItem();
                if (this.Rt_Bat9Code != null)
                    this.Rt_Bat9Code.InitItem();
                if (this.Rt_Bat9V != null)
                    this.Rt_Bat9V.InitItem();
                if (this.Rt_Bat9Dz != null)
                    this.Rt_Bat9Dz.InitItem();
                if (this.Rt_Bat9Cao != null)
                    this.Rt_Bat9Cao.InitItem();
                if (this.Rt_Bat9NGCase != null)
                    this.Rt_Bat9NGCase.InitItem();
                if (this.Rt_Bat10Code != null)
                    this.Rt_Bat10Code.InitItem();
                if (this.Rt_Bat10V != null)
                    this.Rt_Bat10V.InitItem();
                if (this.Rt_Bat10Dz != null)
                    this.Rt_Bat10Dz.InitItem();
                if (this.Rt_Bat10Cao != null)
                    this.Rt_Bat10Cao.InitItem();
                if (this.Rt_Bat10NGCase != null)
                    this.Rt_Bat10NGCase.InitItem();
                if (this.Rt_Bat11Code != null)
                    this.Rt_Bat11Code.InitItem();
                if (this.Rt_Bat11V != null)
                    this.Rt_Bat11V.InitItem();
                if (this.Rt_Bat11Dz != null)
                    this.Rt_Bat11Dz.InitItem();
                if (this.Rt_Bat11Cao != null)
                    this.Rt_Bat11Cao.InitItem();
                if (this.Rt_Bat11NGCase != null)
                    this.Rt_Bat11NGCase.InitItem();
                if (this.Rt_Bat12Code != null)
                    this.Rt_Bat12Code.InitItem();
                if (this.Rt_Bat12V != null)
                    this.Rt_Bat12V.InitItem();
                if (this.Rt_Bat12Dz != null)
                    this.Rt_Bat12Dz.InitItem();
                if (this.Rt_Bat12Cao != null)
                    this.Rt_Bat12Cao.InitItem();
                if (this.Rt_Bat12NGCase != null)
                    this.Rt_Bat12NGCase.InitItem();
                if (this.Rt_Bat13Code != null)
                    this.Rt_Bat13Code.InitItem();
                if (this.Rt_Bat13V != null)
                    this.Rt_Bat13V.InitItem();
                if (this.Rt_Bat13Dz != null)
                    this.Rt_Bat13Dz.InitItem();
                if (this.Rt_Bat13Cao != null)
                    this.Rt_Bat13Cao.InitItem();
                if (this.Rt_Bat13NGCase != null)
                    this.Rt_Bat13NGCase.InitItem();
                if (this.Rt_Bat14Code != null)
                    this.Rt_Bat14Code.InitItem();
                if (this.Rt_Bat14V != null)
                    this.Rt_Bat14V.InitItem();
                if (this.Rt_Bat14Dz != null)
                    this.Rt_Bat14Dz.InitItem();
                if (this.Rt_Bat14Cao != null)
                    this.Rt_Bat14Cao.InitItem();
                if (this.Rt_Bat14NGCase != null)
                    this.Rt_Bat14NGCase.InitItem();
                if (this.Rt_Bat15Code != null)
                    this.Rt_Bat15Code.InitItem();
                if (this.Rt_Bat15V != null)
                    this.Rt_Bat15V.InitItem();
                if (this.Rt_Bat15Dz != null)
                    this.Rt_Bat15Dz.InitItem();
                if (this.Rt_Bat15Cao != null)
                    this.Rt_Bat15Cao.InitItem();
                if (this.Rt_Bat15NGCase != null)
                    this.Rt_Bat15NGCase.InitItem();
                if (this.Rt_Bat16Code != null)
                    this.Rt_Bat16Code.InitItem();
                if (this.Rt_Bat16V != null)
                    this.Rt_Bat16V.InitItem();
                if (this.Rt_Bat16Dz != null)
                    this.Rt_Bat16Dz.InitItem();
                if (this.Rt_Bat16Cao != null)
                    this.Rt_Bat16Cao.InitItem();
                if (this.Rt_Bat16NGCase != null)
                    this.Rt_Bat16NGCase.InitItem();
                if (this.Rt_Bat17Code != null)
                    this.Rt_Bat17Code.InitItem();
                if (this.Rt_Bat17V != null)
                    this.Rt_Bat17V.InitItem();
                if (this.Rt_Bat17Dz != null)
                    this.Rt_Bat17Dz.InitItem();
                if (this.Rt_Bat17Cao != null)
                    this.Rt_Bat17Cao.InitItem();
                if (this.Rt_Bat17NGCase != null)
                    this.Rt_Bat17NGCase.InitItem();
                if (this.Rt_Bat18Code != null)
                    this.Rt_Bat18Code.InitItem();
                if (this.Rt_Bat18V != null)
                    this.Rt_Bat18V.InitItem();
                if (this.Rt_Bat18Dz != null)
                    this.Rt_Bat18Dz.InitItem();
                if (this.Rt_Bat18Cao != null)
                    this.Rt_Bat18Cao.InitItem();
                if (this.Rt_Bat18NGCase != null)
                    this.Rt_Bat18NGCase.InitItem();
                if (this.Rt_Bat19Code != null)
                    this.Rt_Bat19Code.InitItem();
                if (this.Rt_Bat19V != null)
                    this.Rt_Bat19V.InitItem();
                if (this.Rt_Bat19Dz != null)
                    this.Rt_Bat19Dz.InitItem();
                if (this.Rt_Bat19Cao != null)
                    this.Rt_Bat19Cao.InitItem();
                if (this.Rt_Bat19NGCase != null)
                    this.Rt_Bat19NGCase.InitItem();
                if (this.Rt_Bat20Code != null)
                    this.Rt_Bat20Code.InitItem();
                if (this.Rt_Bat20V != null)
                    this.Rt_Bat20V.InitItem();
                if (this.Rt_Bat20Dz != null)
                    this.Rt_Bat20Dz.InitItem();
                if (this.Rt_Bat20Cao != null)
                    this.Rt_Bat20Cao.InitItem();
                if (this.Rt_Bat20NGCase != null)
                    this.Rt_Bat20NGCase.InitItem();
                //南京中比的压差
                if (this.Exp_Yc1 != null)
                    this.Exp_Yc1.InitItem();
                if (this.Exp_Yc2 != null)
                    this.Exp_Yc2.InitItem();
                if (this.Exp_Yc3 != null)
                    this.Exp_Yc3.InitItem();
                if (this.Exp_Yc4 != null)
                    this.Exp_Yc4.InitItem();
                if (this.Exp_Yc5 != null)
                    this.Exp_Yc5.InitItem();
                if (this.Exp_Yc6 != null)
                    this.Exp_Yc6.InitItem();
                if (this.Exp_Yc7 != null)
                    this.Exp_Yc7.InitItem();
                if (this.Exp_Yc8 != null)
                    this.Exp_Yc8.InitItem();
                if (this.Exp_Yc9 != null)
                    this.Exp_Yc9.InitItem();
                if (this.Exp_Yc10 != null)
                    this.Exp_Yc10.InitItem();
                if (this.Exp_Yc11 != null)
                    this.Exp_Yc11.InitItem();
                if (this.Exp_Yc12 != null)
                    this.Exp_Yc12.InitItem();
                if (this.Exp_Yc13 != null)
                    this.Exp_Yc13.InitItem();
                if (this.Exp_Yc14 != null)
                    this.Exp_Yc14.InitItem();
                if (this.Exp_Yc15 != null)
                    this.Exp_Yc15.InitItem();
                if (this.Exp_Yc16 != null)
                    this.Exp_Yc16.InitItem();
            }
            //添加组
            if (_ServerGroups == null)
            {
                _ServerGroups = this._Server.OPCGroups;
                _ServerGroups.DefaultGroupIsActive = true; //设置组集合默认为激活状态
                //下面这个几个暂时不设定，看看是否有异常，因为DefaultGroupUpdateRate这个值很关键，估计是与写入和读取的频率相关了，应该设置到某个单一的节点为好。
                _ServerGroups.DefaultGroupDeadband = 0;    //设置死区
                _ServerGroups.DefaultGroupUpdateRate = 100;//设置更新频率
                try
                {
                    //电池组1
                    this._MyGroup_DoNow = _ServerGroups.Add("BatGroup1");
                    this._MyGroup_DoNow.UpdateRate = 50; //刷新频率
                    this._MyGroup_DoNow.IsActive = true;
                    //电池组2
                    this._MyGroup_Result = _ServerGroups.Add("BatGroup2");
                    this._MyGroup_Result.UpdateRate = 100;
                    this._MyGroup_Result.IsActive = true;
                }
                catch (Exception ex)
                {
                    sErr = string.Format("创建各组失败：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
            }
            if (!this.InitMyItems(out sErr))
            {
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool InitMyItems(out string sErr)
        {
            if (this.AT_ReadResult == null)
                AT_ReadResult = new MyItemValue(OPCItemTitle + "AT_ReadResult");
            if (_IsMacNo4)
            {
                if (this.AT_SNCount == null)
                    AT_SNCount = new MyItemValue(OPCItemTitle + "AT_SNCount");
            }
            if (this.Rt_Bat1Code == null)
                Rt_Bat1Code = new MyItemValue(OPCItemTitle + "Rt_Bat1Code");
            if (this.Rt_Bat1V == null)
                Rt_Bat1V = new MyItemValue(OPCItemTitle + "Rt_Bat1V");
            if (this.Rt_Bat1Dz == null)
                Rt_Bat1Dz = new MyItemValue(OPCItemTitle + "Rt_Bat1Dz");
            if (this.Rt_Bat1Cao == null)
                Rt_Bat1Cao = new MyItemValue(OPCItemTitle + "Rt_Bat1Cao");
            if (this.Rt_Bat1NGCase == null)
                Rt_Bat1NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat1NGCase");
            if (this.Rt_Bat2Code == null)
                Rt_Bat2Code = new MyItemValue(OPCItemTitle + "Rt_Bat2Code");
            if (this.Rt_Bat2V == null)
                Rt_Bat2V = new MyItemValue(OPCItemTitle + "Rt_Bat2V");
            if (this.Rt_Bat2Dz == null)
                Rt_Bat2Dz = new MyItemValue(OPCItemTitle + "Rt_Bat2Dz");
            if (this.Rt_Bat2Cao == null)
                Rt_Bat2Cao = new MyItemValue(OPCItemTitle + "Rt_Bat2Cao");
            if (this.Rt_Bat2NGCase == null)
                Rt_Bat2NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat2NGCase");
            if (this.Rt_Bat3Code == null)
                Rt_Bat3Code = new MyItemValue(OPCItemTitle + "Rt_Bat3Code");
            if (this.Rt_Bat3V == null)
                Rt_Bat3V = new MyItemValue(OPCItemTitle + "Rt_Bat3V");
            if (this.Rt_Bat3Dz == null)
                Rt_Bat3Dz = new MyItemValue(OPCItemTitle + "Rt_Bat3Dz");
            if (this.Rt_Bat3Cao == null)
                Rt_Bat3Cao = new MyItemValue(OPCItemTitle + "Rt_Bat3Cao");
            if (this.Rt_Bat3NGCase == null)
                Rt_Bat3NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat3NGCase");
            if (this.Rt_Bat4Code == null)
                Rt_Bat4Code = new MyItemValue(OPCItemTitle + "Rt_Bat4Code");
            if (this.Rt_Bat4V == null)
                Rt_Bat4V = new MyItemValue(OPCItemTitle + "Rt_Bat4V");
            if (this.Rt_Bat4Dz == null)
                Rt_Bat4Dz = new MyItemValue(OPCItemTitle + "Rt_Bat4Dz");
            if (this.Rt_Bat4Cao == null)
                Rt_Bat4Cao = new MyItemValue(OPCItemTitle + "Rt_Bat4Cao");
            if (this.Rt_Bat4NGCase == null)
                Rt_Bat4NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat4NGCase");
            if (this.Rt_Bat5Code == null)
                Rt_Bat5Code = new MyItemValue(OPCItemTitle + "Rt_Bat5Code");
            if (this.Rt_Bat5V == null)
                Rt_Bat5V = new MyItemValue(OPCItemTitle + "Rt_Bat5V");
            if (this.Rt_Bat5Dz == null)
                Rt_Bat5Dz = new MyItemValue(OPCItemTitle + "Rt_Bat5Dz");
            if (this.Rt_Bat5Cao == null)
                Rt_Bat5Cao = new MyItemValue(OPCItemTitle + "Rt_Bat5Cao");
            if (this.Rt_Bat5NGCase == null)
                Rt_Bat5NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat5NGCase");
            if (this.Rt_Bat6Code == null)
                Rt_Bat6Code = new MyItemValue(OPCItemTitle + "Rt_Bat6Code");
            if (this.Rt_Bat6V == null)
                Rt_Bat6V = new MyItemValue(OPCItemTitle + "Rt_Bat6V");
            if (this.Rt_Bat6Dz == null)
                Rt_Bat6Dz = new MyItemValue(OPCItemTitle + "Rt_Bat6Dz");
            if (this.Rt_Bat6Cao == null)
                Rt_Bat6Cao = new MyItemValue(OPCItemTitle + "Rt_Bat6Cao");
            if (this.Rt_Bat6NGCase == null)
                Rt_Bat6NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat6NGCase");
            if (this.Rt_Bat7Code == null)
                Rt_Bat7Code = new MyItemValue(OPCItemTitle + "Rt_Bat7Code");
            if (this.Rt_Bat7V == null)
                Rt_Bat7V = new MyItemValue(OPCItemTitle + "Rt_Bat7V");
            if (this.Rt_Bat7Dz == null)
                Rt_Bat7Dz = new MyItemValue(OPCItemTitle + "Rt_Bat7Dz");
            if (this.Rt_Bat7Cao == null)
                Rt_Bat7Cao = new MyItemValue(OPCItemTitle + "Rt_Bat7Cao");
            if (this.Rt_Bat7NGCase == null)
                Rt_Bat7NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat7NGCase");
            if (this.Rt_Bat8Code == null)
                Rt_Bat8Code = new MyItemValue(OPCItemTitle + "Rt_Bat8Code");
            if (this.Rt_Bat8V == null)
                Rt_Bat8V = new MyItemValue(OPCItemTitle + "Rt_Bat8V");
            if (this.Rt_Bat8Dz == null)
                Rt_Bat8Dz = new MyItemValue(OPCItemTitle + "Rt_Bat8Dz");
            if (this.Rt_Bat8Cao == null)
                Rt_Bat8Cao = new MyItemValue(OPCItemTitle + "Rt_Bat8Cao");
            if (this.Rt_Bat8NGCase == null)
                Rt_Bat8NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat8NGCase");
            if (this.Rt_Bat9Code == null)
                Rt_Bat9Code = new MyItemValue(OPCItemTitle + "Rt_Bat9Code");
            if (this.Rt_Bat9V == null)
                Rt_Bat9V = new MyItemValue(OPCItemTitle + "Rt_Bat9V");
            if (this.Rt_Bat9Dz == null)
                Rt_Bat9Dz = new MyItemValue(OPCItemTitle + "Rt_Bat9Dz");
            if (this.Rt_Bat9Cao == null)
                Rt_Bat9Cao = new MyItemValue(OPCItemTitle + "Rt_Bat9Cao");
            if (this.Rt_Bat9NGCase == null)
                Rt_Bat9NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat9NGCase");
            if (this.Rt_Bat10Code == null)
                Rt_Bat10Code = new MyItemValue(OPCItemTitle + "Rt_Bat10Code");
            if (this.Rt_Bat10V == null)
                Rt_Bat10V = new MyItemValue(OPCItemTitle + "Rt_Bat10V");
            if (this.Rt_Bat10Dz == null)
                Rt_Bat10Dz = new MyItemValue(OPCItemTitle + "Rt_Bat10Dz");
            if (this.Rt_Bat10Cao == null)
                Rt_Bat10Cao = new MyItemValue(OPCItemTitle + "Rt_Bat10Cao");
            if (this.Rt_Bat10NGCase == null)
                Rt_Bat10NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat10NGCase");
            if (this.Rt_Bat11Code == null)
                Rt_Bat11Code = new MyItemValue(OPCItemTitle + "Rt_Bat11Code");
            if (this.Rt_Bat11V == null)
                Rt_Bat11V = new MyItemValue(OPCItemTitle + "Rt_Bat11V");
            if (this.Rt_Bat11Dz == null)
                Rt_Bat11Dz = new MyItemValue(OPCItemTitle + "Rt_Bat11Dz");
            if (this.Rt_Bat11Cao == null)
                Rt_Bat11Cao = new MyItemValue(OPCItemTitle + "Rt_Bat11Cao");
            if (this.Rt_Bat11NGCase == null)
                Rt_Bat11NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat11NGCase");
            if (this.Rt_Bat12Code == null)
                Rt_Bat12Code = new MyItemValue(OPCItemTitle + "Rt_Bat12Code");
            if (this.Rt_Bat12V == null)
                Rt_Bat12V = new MyItemValue(OPCItemTitle + "Rt_Bat12V");
            if (this.Rt_Bat12Dz == null)
                Rt_Bat12Dz = new MyItemValue(OPCItemTitle + "Rt_Bat12Dz");
            if (this.Rt_Bat12Cao == null)
                Rt_Bat12Cao = new MyItemValue(OPCItemTitle + "Rt_Bat12Cao");
            if (this.Rt_Bat12NGCase == null)
                Rt_Bat12NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat12NGCase");
            if (this.Rt_Bat13Code == null)
                Rt_Bat13Code = new MyItemValue(OPCItemTitle + "Rt_Bat13Code");
            if (this.Rt_Bat13V == null)
                Rt_Bat13V = new MyItemValue(OPCItemTitle + "Rt_Bat13V");
            if (this.Rt_Bat13Dz == null)
                Rt_Bat13Dz = new MyItemValue(OPCItemTitle + "Rt_Bat13Dz");
            if (this.Rt_Bat13Cao == null)
                Rt_Bat13Cao = new MyItemValue(OPCItemTitle + "Rt_Bat13Cao");
            if (this.Rt_Bat13NGCase == null)
                Rt_Bat13NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat13NGCase");
            if (this.Rt_Bat14Code == null)
                Rt_Bat14Code = new MyItemValue(OPCItemTitle + "Rt_Bat14Code");
            if (this.Rt_Bat14V == null)
                Rt_Bat14V = new MyItemValue(OPCItemTitle + "Rt_Bat14V");
            if (this.Rt_Bat14Dz == null)
                Rt_Bat14Dz = new MyItemValue(OPCItemTitle + "Rt_Bat14Dz");
            if (this.Rt_Bat14Cao == null)
                Rt_Bat14Cao = new MyItemValue(OPCItemTitle + "Rt_Bat14Cao");
            if (this.Rt_Bat14NGCase == null)
                Rt_Bat14NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat14NGCase");
            if (this.Rt_Bat15Code == null)
                Rt_Bat15Code = new MyItemValue(OPCItemTitle + "Rt_Bat15Code");
            if (this.Rt_Bat15V == null)
                Rt_Bat15V = new MyItemValue(OPCItemTitle + "Rt_Bat15V");
            if (this.Rt_Bat15Dz == null)
                Rt_Bat15Dz = new MyItemValue(OPCItemTitle + "Rt_Bat15Dz");
            if (this.Rt_Bat15Cao == null)
                Rt_Bat15Cao = new MyItemValue(OPCItemTitle + "Rt_Bat15Cao");
            if (this.Rt_Bat15NGCase == null)
                Rt_Bat15NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat15NGCase");
            if (this.Rt_Bat16Code == null)
                Rt_Bat16Code = new MyItemValue(OPCItemTitle + "Rt_Bat16Code");
            if (this.Rt_Bat16V == null)
                Rt_Bat16V = new MyItemValue(OPCItemTitle + "Rt_Bat16V");
            if (this.Rt_Bat16Dz == null)
                Rt_Bat16Dz = new MyItemValue(OPCItemTitle + "Rt_Bat16Dz");
            if (this.Rt_Bat16Cao == null)
                Rt_Bat16Cao = new MyItemValue(OPCItemTitle + "Rt_Bat16Cao");
            if (this.Rt_Bat16NGCase == null)
                Rt_Bat16NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat16NGCase");
            if (this.Rt_Bat17Code == null)
                Rt_Bat17Code = new MyItemValue(OPCItemTitle + "Rt_Bat17Code");
            if (this.Rt_Bat17V == null)
                Rt_Bat17V = new MyItemValue(OPCItemTitle + "Rt_Bat17V");
            if (this.Rt_Bat17Dz == null)
                Rt_Bat17Dz = new MyItemValue(OPCItemTitle + "Rt_Bat17Dz");
            if (this.Rt_Bat17Cao == null)
                Rt_Bat17Cao = new MyItemValue(OPCItemTitle + "Rt_Bat17Cao");
            if (this.Rt_Bat17NGCase == null)
                Rt_Bat17NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat17NGCase");
            if (this.Rt_Bat18Code == null)
                Rt_Bat18Code = new MyItemValue(OPCItemTitle + "Rt_Bat18Code");
            if (this.Rt_Bat18V == null)
                Rt_Bat18V = new MyItemValue(OPCItemTitle + "Rt_Bat18V");
            if (this.Rt_Bat18Dz == null)
                Rt_Bat18Dz = new MyItemValue(OPCItemTitle + "Rt_Bat18Dz");
            if (this.Rt_Bat18Cao == null)
                Rt_Bat18Cao = new MyItemValue(OPCItemTitle + "Rt_Bat18Cao");
            if (this.Rt_Bat18NGCase == null)
                Rt_Bat18NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat18NGCase");
            if (this.Rt_Bat19Code == null)
                Rt_Bat19Code = new MyItemValue(OPCItemTitle + "Rt_Bat19Code");
            if (this.Rt_Bat19V == null)
                Rt_Bat19V = new MyItemValue(OPCItemTitle + "Rt_Bat19V");
            if (this.Rt_Bat19Dz == null)
                Rt_Bat19Dz = new MyItemValue(OPCItemTitle + "Rt_Bat19Dz");
            if (this.Rt_Bat19Cao == null)
                Rt_Bat19Cao = new MyItemValue(OPCItemTitle + "Rt_Bat19Cao");
            if (this.Rt_Bat19NGCase == null)
                Rt_Bat19NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat19NGCase");
            if (this.Rt_Bat20Code == null)
                Rt_Bat20Code = new MyItemValue(OPCItemTitle + "Rt_Bat20Code");
            if (this.Rt_Bat20V == null)
                Rt_Bat20V = new MyItemValue(OPCItemTitle + "Rt_Bat20V");
            if (this.Rt_Bat20Dz == null)
                Rt_Bat20Dz = new MyItemValue(OPCItemTitle + "Rt_Bat20Dz");
            if (this.Rt_Bat20Cao == null)
                Rt_Bat20Cao = new MyItemValue(OPCItemTitle + "Rt_Bat20Cao");
            if (this.Rt_Bat20NGCase == null)
                Rt_Bat20NGCase = new MyItemValue(OPCItemTitle + "Rt_Bat20NGCase");
            //南京中比压差
            if (this.Exp_Yc1 == null)
                Exp_Yc1 = new MyItemValue(OPCItemTitle + "Exp_Yc1");
            if (this.Exp_Yc2 == null)
                Exp_Yc2 = new MyItemValue(OPCItemTitle + "Exp_Yc2");
            if (this.Exp_Yc3 == null)
                Exp_Yc3 = new MyItemValue(OPCItemTitle + "Exp_Yc3");
            if (this.Exp_Yc4 == null)
                Exp_Yc4 = new MyItemValue(OPCItemTitle + "Exp_Yc4");
            if (this.Exp_Yc5 == null)
                Exp_Yc5 = new MyItemValue(OPCItemTitle + "Exp_Yc5");
            if (this.Exp_Yc6 == null)
                Exp_Yc6 = new MyItemValue(OPCItemTitle + "Exp_Yc6");
            if (this.Exp_Yc7 == null)
                Exp_Yc7 = new MyItemValue(OPCItemTitle + "Exp_Yc7");
            if (this.Exp_Yc8 == null)
                Exp_Yc8 = new MyItemValue(OPCItemTitle + "Exp_Yc8");
            if (this.Exp_Yc9 == null)
                Exp_Yc9 = new MyItemValue(OPCItemTitle + "Exp_Yc9");
            if (this.Exp_Yc10 == null)
                Exp_Yc10 = new MyItemValue(OPCItemTitle + "Exp_Yc10");
            if (this.Exp_Yc11 == null)
                Exp_Yc11 = new MyItemValue(OPCItemTitle + "Exp_Yc11");
            if (this.Exp_Yc12 == null)
                Exp_Yc12 = new MyItemValue(OPCItemTitle + "Exp_Yc12");
            if (this.Exp_Yc13 == null)
                Exp_Yc13 = new MyItemValue(OPCItemTitle + "Exp_Yc13");
            if (this.Exp_Yc14 == null)
                Exp_Yc14 = new MyItemValue(OPCItemTitle + "Exp_Yc14");
            if (this.Exp_Yc15 == null)
                Exp_Yc15 = new MyItemValue(OPCItemTitle + "Exp_Yc15");
            if (this.Exp_Yc16 == null)
                Exp_Yc16 = new MyItemValue(OPCItemTitle + "Exp_Yc16");

            //在OPCGroup中添加IOPCItem
            if (this._MyGroup_DoNow == null)
            {
                sErr = "初始化电池组item时失败，因为group1为空。";
                return false;
            }
            if (this._MyGroup_Result == null)
            {
                sErr = "初始化电池组item时失败，因为group2为空。";
                return false;
            }
            if (_MyGroup_DoNow.OPCItems == null)
            {
                sErr = "初始化电池组item时失败，因为group1.OPCItems为空。";
                return false;
            }
            if (_MyGroup_Result.OPCItems == null)
            {
                sErr = "初始化电池组item时失败，因为group2.OPCItems为空。";
                return false;
            }
            //处理标识
            if (!InitMyItems_AddItem(this.AT_ReadResult, this._MyGroup_DoNow, true, out sErr))
            {
                return false;
            }
            if(this._IsMacNo4)
            {
                if (!InitMyItems_AddItem(this.AT_SNCount, this._MyGroup_DoNow, true, out sErr))
                {
                    return false;
                }
            }
            //处理电池组1的
            if (!InitMyItems_AddItem(this.Rt_Bat1Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat1V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat1Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat1Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat1NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat2Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat2V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat2Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat2Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat2NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat3Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat3V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat3Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat3Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat3NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat4Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat4V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat4Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat4Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat4NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat5Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat5V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat5Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }


            if (!InitMyItems_AddItem(this.Rt_Bat5Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat5NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat6Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat6V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat6Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }


            if (!InitMyItems_AddItem(this.Rt_Bat6Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat6NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat7Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat7V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat7Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat7Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat7NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat8Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat8V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat8Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat8Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat8NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat9Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat9V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat9Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat9Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat9NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat10Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat10V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat10Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat10Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat10NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat11Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat11V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat11Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat11Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat11NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat12Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat12V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat12Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat12Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat12NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat13Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat13V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat13Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat13Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat13NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat14Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat14V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat14Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat14Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat14NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat15Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat15V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat15Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat15Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat15NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat16Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat16V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat16Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat16Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat16NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat17Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat17V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat17Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat17Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat17NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat18Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat18V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat18Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat18Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat18NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat19Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat19V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat19Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat19Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat19NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat20Code, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat20V, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat20Dz, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat20Cao, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt_Bat20NGCase, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }
            //压差
            if (!InitMyItems_AddItem(this.Exp_Yc1, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc2, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc3, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc4, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc5, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc6, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc7, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc8, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc9, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc10, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc11, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc12, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc13, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc14, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc15, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Yc16, this._MyGroup_Result, false, out sErr))
            {
                return false;
            }
            return true;
        }
        private bool InitMyItems_AddItem(MyItemValue myItem, OPCGroup targetGroup, bool saveItem, out string sErr)
        {
            if (myItem.ServerHandle <= 0)
            {
                if (this.IsDebug)
                {
                    sErr = string.Empty;
                    return true;
                }
                //此时添加Item
                _ClientHandle++;
                OPCItem item = null;
                string strTagName = myItem.TagName;
                try
                {
                    item = targetGroup.OPCItems.AddItem(strTagName, _ClientHandle);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("添加Item：{0}，出错:{1}({2})", myItem.TagName, ex.Message, ex.Source);
                    return false;
                }
                if (item == null)
                {
                    sErr = string.Format("添加Item：{0}失败，返回为空。", myItem.TagName);
                    return false;
                }
                if (item.ServerHandle <= 0)
                {
                    sErr = string.Format("添加Item：{0}失败，返回值ServerHandle为{1}。", myItem.TagName, myItem.ServerHandle);
                    return false;
                }
                myItem.ServerHandle = item.ServerHandle;
                myItem.ClientHandle = this._ClientHandle;
                if (saveItem)
                    myItem._OPCItem = item;
            }
            sErr = string.Empty;
            return true;
        }
        public bool CloseOPC(out string sErr)
        {
            sErr = "";
            if (this._Server == null) return true;
            try
            {
                this._Server.Disconnect();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
                return false;
            }
            return true;
        }
        #endregion
        #region 特殊功能函数
        /// <summary>
        /// 判断PLC标识，是否现在可以读取测试结果了
        /// </summary>
        /// <param name="sErr"></param>
        /// <returns>是否执行成功</returns>
        public bool IsReadResultNow(out string sErr)
        {
            if (this.AT_ReadResult == null)
            {
                sErr = "result槽号为空！";
                return false;
            }
            else if (this.AT_ReadResult._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "result槽号的OPCItem为空，且初始化出错：" + sErr;
                    return false;
                }
            }
            if (this.AT_ReadResult.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "result槽号的OPCItemHandle值为0，但重新初始化时出错：" + sErr;
                    return false;
                }
            }
            //此时有效了，直接读取值
            object objValue;
            if (!this.AT_ReadResult.ReadData(out objValue, out sErr))
            {
                sErr = "result槽号的OPCItem(AT_ReadResult)读取出错：" + sErr;
                return false;
            }
            if (objValue == null)
            {
                sErr = string.Format("result槽号读取出错：item对象[{0}]的返回值NULL。", this.AT_ReadResult.TagName);
                return false;
            }
            //此时读取成功了，则转换
            string strValue = objValue.ToString().ToLower();
            sErr = string.Format("读取到AT_ReadResult值为[{0}]", strValue);
            if (strValue == "true" || strValue == "1" || strValue == "yes")
                this.AT_ReadResult.Value_Bool = true;
            else this.AT_ReadResult.Value_Bool = false;
            return true;
        }
        public bool ResetAT_ReadResult(out string sErr)
        {
            if (this.AT_ReadResult == null)
            {
                sErr = "AT_ReadResult复位失败：opc为空！";
                return false;
            }
            else if (this.AT_ReadResult._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "AT_ReadResult复位失败：OPCItem为空，且初始化出错：" + sErr;
                    return false;
                }
            }
            if (this.AT_ReadResult.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "AT_ReadResult复位失败：OPCItemHandle值为0，但重新初始化时出错：" + sErr;
                    return false;
                }
            }
            if (!this.AT_ReadResult.WriteData(false, out sErr))
            {
                sErr = "AT_ReadResult复位出错：" + sErr;
                return false;
            }
            return true;
        }
        public bool SetSNCount(short iCount,out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            if (this.AT_SNCount == null)
            {
                sErr = "AT_SNCount设置失败：opc为空！";
                return false;
            }
            else if (this.AT_SNCount._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "AT_SNCount设置失败：OPCItem为空，且初始化出错：" + sErr;
                    return false;
                }
            }
            if (!this.AT_SNCount.WriteData(iCount, out sErr))
            {
                sErr = "AT_SNCount写入出错：" + sErr;
                return false;
            }
            return true;
        }
        public bool GetResult(out string sErr)
        {
            Array values = null;
            #region serverHandles
            Array serverHandles = new int[101] { 0
                , this.Rt_Bat1Code.ServerHandle
                , this.Rt_Bat1V.ServerHandle
                , this.Rt_Bat1Dz.ServerHandle
                , this.Rt_Bat1Cao.ServerHandle
                , this.Rt_Bat1NGCase.ServerHandle
                , this.Rt_Bat2Code.ServerHandle
                , this.Rt_Bat2V.ServerHandle
                , this.Rt_Bat2Dz.ServerHandle
                , this.Rt_Bat2Cao.ServerHandle
                , this.Rt_Bat2NGCase.ServerHandle
                , this.Rt_Bat3Code.ServerHandle
                , this.Rt_Bat3V.ServerHandle
                , this.Rt_Bat3Dz.ServerHandle
                , this.Rt_Bat3Cao.ServerHandle
                , this.Rt_Bat3NGCase.ServerHandle
                , this.Rt_Bat4Code.ServerHandle
                , this.Rt_Bat4V.ServerHandle
                , this.Rt_Bat4Dz.ServerHandle
                , this.Rt_Bat4Cao.ServerHandle
                , this.Rt_Bat4NGCase.ServerHandle
                , this.Rt_Bat5Code.ServerHandle
                , this.Rt_Bat5V.ServerHandle
                , this.Rt_Bat5Dz.ServerHandle
                , this.Rt_Bat5Cao.ServerHandle
                , this.Rt_Bat5NGCase.ServerHandle
                , this.Rt_Bat6Code.ServerHandle
                , this.Rt_Bat6V.ServerHandle
                , this.Rt_Bat6Dz.ServerHandle
                , this.Rt_Bat6Cao.ServerHandle
                , this.Rt_Bat6NGCase.ServerHandle
                , this.Rt_Bat7Code.ServerHandle
                , this.Rt_Bat7V.ServerHandle
                , this.Rt_Bat7Dz.ServerHandle
                , this.Rt_Bat7Cao.ServerHandle
                , this.Rt_Bat7NGCase.ServerHandle
                , this.Rt_Bat8Code.ServerHandle
                , this.Rt_Bat8V.ServerHandle
                , this.Rt_Bat8Dz.ServerHandle
                , this.Rt_Bat8Cao.ServerHandle
                , this.Rt_Bat8NGCase.ServerHandle
                , this.Rt_Bat9Code.ServerHandle
                , this.Rt_Bat9V.ServerHandle
                , this.Rt_Bat9Dz.ServerHandle
                , this.Rt_Bat9Cao.ServerHandle
                , this.Rt_Bat9NGCase.ServerHandle
                , this.Rt_Bat10Code.ServerHandle
                , this.Rt_Bat10V.ServerHandle
                , this.Rt_Bat10Dz.ServerHandle
                , this.Rt_Bat10Cao.ServerHandle
                , this.Rt_Bat10NGCase.ServerHandle
                , this.Rt_Bat11Code.ServerHandle
                , this.Rt_Bat11V.ServerHandle
                , this.Rt_Bat11Dz.ServerHandle
                , this.Rt_Bat11Cao.ServerHandle
                , this.Rt_Bat11NGCase.ServerHandle
                , this.Rt_Bat12Code.ServerHandle
                , this.Rt_Bat12V.ServerHandle
                , this.Rt_Bat12Dz.ServerHandle
                , this.Rt_Bat12Cao.ServerHandle
                , this.Rt_Bat12NGCase.ServerHandle
                , this.Rt_Bat13Code.ServerHandle
                , this.Rt_Bat13V.ServerHandle
                , this.Rt_Bat13Dz.ServerHandle
                , this.Rt_Bat13Cao.ServerHandle
                , this.Rt_Bat13NGCase.ServerHandle
                , this.Rt_Bat14Code.ServerHandle
                , this.Rt_Bat14V.ServerHandle
                , this.Rt_Bat14Dz.ServerHandle
                , this.Rt_Bat14Cao.ServerHandle
                , this.Rt_Bat14NGCase.ServerHandle
                , this.Rt_Bat15Code.ServerHandle
                , this.Rt_Bat15V.ServerHandle
                , this.Rt_Bat15Dz.ServerHandle
                , this.Rt_Bat15Cao.ServerHandle
                , this.Rt_Bat15NGCase.ServerHandle
                , this.Rt_Bat16Code.ServerHandle
                , this.Rt_Bat16V.ServerHandle
                , this.Rt_Bat16Dz.ServerHandle
                , this.Rt_Bat16Cao.ServerHandle
                , this.Rt_Bat16NGCase.ServerHandle
                , this.Rt_Bat17Code.ServerHandle
                , this.Rt_Bat17V.ServerHandle
                , this.Rt_Bat17Dz.ServerHandle
                , this.Rt_Bat17Cao.ServerHandle
                , this.Rt_Bat17NGCase.ServerHandle
                , this.Rt_Bat18Code.ServerHandle
                , this.Rt_Bat18V.ServerHandle
                , this.Rt_Bat18Dz.ServerHandle
                , this.Rt_Bat18Cao.ServerHandle
                , this.Rt_Bat18NGCase.ServerHandle
                , this.Rt_Bat19Code.ServerHandle
                , this.Rt_Bat19V.ServerHandle
                , this.Rt_Bat19Dz.ServerHandle
                , this.Rt_Bat19Cao.ServerHandle
                , this.Rt_Bat19NGCase.ServerHandle
                , this.Rt_Bat20Code.ServerHandle
                , this.Rt_Bat20V.ServerHandle
                , this.Rt_Bat20Dz.ServerHandle
                , this.Rt_Bat20Cao.ServerHandle
                , this.Rt_Bat20NGCase.ServerHandle
            };
            #endregion
            object objQ;
            object objT;
            Array errors;
            try
            {
                this._MyGroup_Result.SyncRead(1, 100, ref serverHandles, out values, out errors, out objQ, out objT);
            }
            catch (Exception ex)
            {
                sErr = string.Format("ResultOPC读取出错01：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            if (values == null)
            {
                sErr = "ResultOPC读取出错:values为空！";
                return false;
            }
            if (values.Length != 100)
            {
                sErr = string.Format("ResultOPC读取出错:values长度为{0}，不是预期的100！", values.Length);
                return false;
            }
            Array arrQ = objQ as Array;
            if (arrQ == null)
            {
                sErr = "ResultOPC读取出错:qualitys为空！";
                return false;
            }
            if (arrQ.Length != 100)
            {
                sErr = string.Format("ResultOPC读取出错:qualitys长度为{0}，不是预期的100！", values.Length);
                return false;
            }
            //解析数值
            int iIndex = 1;//注意Arrary的GetValue序号从1开始，这与c#中不一样
            if (!this.SetResult(this.Rt_Bat1Code, this.Rt_Bat1V, this.Rt_Bat1Dz, this.Rt_Bat1Cao, this.Rt_Bat1NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat1Code:{0},Rt_Bat1V:{1},Rt_Bat1Dz{2},Rt_Bat1Cao:{3}\r\n", Rt_Bat1Code.Value_String, Rt_Bat1V.Value_Decimal, Rt_Bat1Dz.Value_Decimal, Rt_Bat1Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat2Code, this.Rt_Bat2V, this.Rt_Bat2Dz, this.Rt_Bat2Cao, this.Rt_Bat2NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat2Code:{0},Rt_Bat2V:{1},Rt_Bat2Dz{2},Rt_Bat2Cao:{3}\r\n", Rt_Bat2Code.Value_String, Rt_Bat2V.Value_Decimal, Rt_Bat2Dz.Value_Decimal, Rt_Bat2Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat3Code, this.Rt_Bat3V, this.Rt_Bat3Dz, this.Rt_Bat3Cao, this.Rt_Bat3NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat3Code:{0},Rt_Bat3V:{1},Rt_Bat3Dz{2},Rt_Bat3Cao:{3}\r\n", Rt_Bat3Code.Value_String, Rt_Bat3V.Value_Decimal, Rt_Bat3Dz.Value_Decimal, Rt_Bat3Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat4Code, this.Rt_Bat4V, this.Rt_Bat4Dz, this.Rt_Bat4Cao, this.Rt_Bat4NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat4Code:{0},Rt_Bat4V:{1},Rt_Bat4Dz{2},Rt_Bat4Cao:{3}\r\n", Rt_Bat4Code.Value_String, Rt_Bat4V.Value_Decimal, Rt_Bat4Dz.Value_Decimal, Rt_Bat4Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat5Code, this.Rt_Bat5V, this.Rt_Bat5Dz, this.Rt_Bat5Cao, this.Rt_Bat5NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat5Code:{0},Rt_Bat5V:{1},Rt_Bat5Dz{2},Rt_Bat5Cao:{3}\r\n", Rt_Bat5Code.Value_String, Rt_Bat5V.Value_Decimal, Rt_Bat5Dz.Value_Decimal, Rt_Bat5Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat6Code, this.Rt_Bat6V, this.Rt_Bat6Dz, this.Rt_Bat6Cao, this.Rt_Bat6NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat6Code:{0},Rt_Bat6V:{1},Rt_Bat6Dz{2},Rt_Bat6Cao:{3}\r\n", Rt_Bat6Code.Value_String, Rt_Bat6V.Value_Decimal, Rt_Bat6Dz.Value_Decimal, Rt_Bat6Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat7Code, this.Rt_Bat7V, this.Rt_Bat7Dz, this.Rt_Bat7Cao, this.Rt_Bat7NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat7Code:{0},Rt_Bat7V:{1},Rt_Bat7Dz{2},Rt_Bat7Cao:{3}\r\n", Rt_Bat7Code.Value_String, Rt_Bat7V.Value_Decimal, Rt_Bat7Dz.Value_Decimal, Rt_Bat7Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat8Code, this.Rt_Bat8V, this.Rt_Bat8Dz, this.Rt_Bat8Cao, this.Rt_Bat8NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat8Code:{0},Rt_Bat8V:{1},Rt_Bat8Dz{2},Rt_Bat8Cao:{3}\r\n", Rt_Bat8Code.Value_String, Rt_Bat8V.Value_Decimal, Rt_Bat8Dz.Value_Decimal, Rt_Bat8Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat9Code, this.Rt_Bat9V, this.Rt_Bat9Dz, this.Rt_Bat9Cao, this.Rt_Bat9NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat9Code:{0},Rt_Bat9V:{1},Rt_Bat9Dz{2},Rt_Bat9Cao:{3}\r\n", Rt_Bat9Code.Value_String, Rt_Bat9V.Value_Decimal, Rt_Bat9Dz.Value_Decimal, Rt_Bat9Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat10Code, this.Rt_Bat10V, this.Rt_Bat10Dz, this.Rt_Bat10Cao, this.Rt_Bat10NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat10Code:{0},Rt_Bat10V:{1},Rt_Bat10Dz{2},Rt_Bat10Cao:{3}\r\n", Rt_Bat10Code.Value_String, Rt_Bat10V.Value_Decimal, Rt_Bat10Dz.Value_Decimal, Rt_Bat10Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat11Code, this.Rt_Bat11V, this.Rt_Bat11Dz, this.Rt_Bat11Cao, this.Rt_Bat11NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat11Code:{0},Rt_Bat11V:{1},Rt_Bat11Dz{2},Rt_Bat11Cao:{3}\r\n", Rt_Bat11Code.Value_String, Rt_Bat11V.Value_Decimal, Rt_Bat11Dz.Value_Decimal, Rt_Bat11Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat12Code, this.Rt_Bat12V, this.Rt_Bat12Dz, this.Rt_Bat12Cao, this.Rt_Bat12NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat12Code:{0},Rt_Bat12V:{1},Rt_Bat12Dz{2},Rt_Bat12Cao:{3}\r\n", Rt_Bat12Code.Value_String, Rt_Bat12V.Value_Decimal, Rt_Bat12Dz.Value_Decimal, Rt_Bat12Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat13Code, this.Rt_Bat13V, this.Rt_Bat13Dz, this.Rt_Bat13Cao, this.Rt_Bat13NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat13Code:{0},Rt_Bat13V:{1},Rt_Bat13Dz{2},Rt_Bat13Cao:{3}\r\n", Rt_Bat13Code.Value_String, Rt_Bat13V.Value_Decimal, Rt_Bat13Dz.Value_Decimal, Rt_Bat13Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat14Code, this.Rt_Bat14V, this.Rt_Bat14Dz, this.Rt_Bat14Cao, this.Rt_Bat14NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat14Code:{0},Rt_Bat14V:{1},Rt_Bat14Dz{2},Rt_Bat14Cao:{3}\r\n", Rt_Bat14Code.Value_String, Rt_Bat14V.Value_Decimal, Rt_Bat14Dz.Value_Decimal, Rt_Bat14Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat15Code, this.Rt_Bat15V, this.Rt_Bat15Dz, this.Rt_Bat15Cao, this.Rt_Bat15NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat15Code:{0},Rt_Bat15V:{1},Rt_Bat15Dz{2},Rt_Bat15Cao:{3}\r\n", Rt_Bat15Code.Value_String, Rt_Bat15V.Value_Decimal, Rt_Bat15Dz.Value_Decimal, Rt_Bat15Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat16Code, this.Rt_Bat16V, this.Rt_Bat16Dz, this.Rt_Bat16Cao, this.Rt_Bat16NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat16Code:{0},Rt_Bat16V:{1},Rt_Bat16Dz{2},Rt_Bat16Cao:{3}\r\n", Rt_Bat16Code.Value_String, Rt_Bat16V.Value_Decimal, Rt_Bat16Dz.Value_Decimal, Rt_Bat16Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat17Code, this.Rt_Bat17V, this.Rt_Bat17Dz, this.Rt_Bat17Cao, this.Rt_Bat17NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat17Code:{0},Rt_Bat17V:{1},Rt_Bat17Dz{2},Rt_Bat17Cao:{3}\r\n", Rt_Bat17Code.Value_String, Rt_Bat17V.Value_Decimal, Rt_Bat17Dz.Value_Decimal, Rt_Bat17Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat18Code, this.Rt_Bat18V, this.Rt_Bat18Dz, this.Rt_Bat18Cao, this.Rt_Bat18NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat18Code:{0},Rt_Bat18V:{1},Rt_Bat18Dz{2},Rt_Bat18Cao:{3}\r\n", Rt_Bat18Code.Value_String, Rt_Bat18V.Value_Decimal, Rt_Bat18Dz.Value_Decimal, Rt_Bat18Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat19Code, this.Rt_Bat19V, this.Rt_Bat19Dz, this.Rt_Bat19Cao, this.Rt_Bat19NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat19Code:{0},Rt_Bat19V:{1},Rt_Bat19Dz{2},Rt_Bat19Cao:{3}\r\n", Rt_Bat19Code.Value_String, Rt_Bat19V.Value_Decimal, Rt_Bat19Dz.Value_Decimal, Rt_Bat19Cao.Value_Short);
            if (!this.SetResult(this.Rt_Bat20Code, this.Rt_Bat20V, this.Rt_Bat20Dz, this.Rt_Bat20Cao, this.Rt_Bat20NGCase, values, arrQ, ref iIndex, out sErr)) return false;
            sErr += string.Format("Rt_Bat20Code:{0},Rt_Bat20V:{1},Rt_Bat20Dz{2},Rt_Bat20Cao:{3}\r\n", Rt_Bat20Code.Value_String, Rt_Bat20V.Value_Decimal, Rt_Bat20Dz.Value_Decimal, Rt_Bat20Cao.Value_Short);
            return true;
        }
        
        private bool SetResult(MyItemValue itemCode, MyItemValue itemV, MyItemValue itemDz, MyItemValue itemCao, MyItemValue itemNGCase, Array arrValues, Array arrQ, ref int iIndex, out string sErr)
        {
            object objValue;
            object objQ;
            //decimal decValue;
            float fValue;
            short iValue;
            //读取编号
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", itemCode.TagName);
                return false;
            }
            if (objQ.ToString() != "192")
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", itemCode.TagName, objQ.ToString());
                return false;
            }
            itemCode.Value_String = objValue == null ? "" : objValue.ToString();
            iIndex++;
            //读取电压
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", itemV.TagName);
                return false;
            }
            if (objQ.ToString() != "192")
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", itemV.TagName, objQ.ToString());
                return false;
            }
            if (objValue == null) fValue = 0F;
            else
            {
                if (!float.TryParse(objValue.ToString(), out fValue))
                {
                    sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的值为\"{1}\"不是预期的数值类型！", itemV.TagName, objValue.ToString());
                    return false;
                }
            }
            itemV.Value_Decimal = (decimal)fValue;
            iIndex++;
            //读取电阻
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", itemDz.TagName);
                return false;
            }
            if (objQ.ToString() != "192")
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", itemDz.TagName, objQ.ToString());
                return false;
            }
            if (objValue == null) fValue = 0F;
            else
            {
                if (!float.TryParse(objValue.ToString(), out fValue))
                {
                    sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的值为\"{1}\"不是预期的数值类型！", itemDz.TagName, objValue.ToString());
                    return false;
                }
            }
            itemDz.Value_Decimal = (decimal)fValue;
            iIndex++;
            //读取槽号
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", itemCao.TagName);
                return false;
            }
            if (objQ.ToString() != "192")
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", itemCao.TagName, objQ.ToString());
                return false;
            }
            if (objValue == null) iValue = 0;
            else
            {
                if (!short.TryParse(objValue.ToString(), out iValue))
                {
                    sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的值为\"{1}\"不是预期的数值类型！", itemCao.TagName, objValue.ToString());
                    return false;
                }
            }
            itemCao.Value_Short = iValue;
            iIndex++;
            //读取NG原因
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", itemNGCase.TagName);
                return false;
            }
            if (objQ.ToString() != "192")
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", itemNGCase.TagName, objQ.ToString());
                return false;
            }
            if (objValue == null) iValue = 0;
            else
            {
                if (!short.TryParse(objValue.ToString(), out iValue))
                {
                    sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的值为\"{1}\"不是预期的整型！", itemNGCase.TagName, objValue.ToString());
                    return false;
                }
            }
            itemNGCase.Value_Short = iValue;
            iIndex++;
            sErr = string.Empty;
            return true;
        }
        #endregion
        #region 南京中比读取压差
        public bool GetYaChaResult(ref YaChaEntity data, out string sErr)
        {
            Array values = null;
            #region serverHandles
            Array serverHandles = new int[17] { 0
                , this.Exp_Yc1.ServerHandle
                , this.Exp_Yc2.ServerHandle
                , this.Exp_Yc3.ServerHandle
                , this.Exp_Yc4.ServerHandle
                , this.Exp_Yc5.ServerHandle
                , this.Exp_Yc6.ServerHandle
                , this.Exp_Yc7.ServerHandle
                , this.Exp_Yc8.ServerHandle
                , this.Exp_Yc9.ServerHandle
                , this.Exp_Yc10.ServerHandle
                , this.Exp_Yc11.ServerHandle
                , this.Exp_Yc12.ServerHandle
                , this.Exp_Yc13.ServerHandle
                , this.Exp_Yc14.ServerHandle
                , this.Exp_Yc15.ServerHandle
                , this.Exp_Yc16.ServerHandle
            };
            #endregion
            object objQ;
            object objT;
            Array errors;
            try
            {
                this._MyGroup_Result.SyncRead(1, 16, ref serverHandles, out values, out errors, out objQ, out objT);
            }
            catch (Exception ex)
            {
                sErr = string.Format("压差OPC读取出错01：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            if (values == null)
            {
                sErr = "压差OPC读取出错:values为空！";
                return false;
            }
            if (values.Length != 16)
            {
                sErr = string.Format("压差OPC读取出错:values长度为{0}，不是预期的16！", values.Length);
                return false;
            }
            Array arrQ = objQ as Array;
            if (arrQ == null)
            {
                sErr = "压差OPC读取出错:qualitys为空！";
                return false;
            }
            if (arrQ.Length != 16)
            {
                sErr = string.Format("压差OPC读取出错:qualitys长度为{0}，不是预期的16！", values.Length);
                return false;
            }
            //解析数值
            int iIndex = 1;//注意Arrary的GetValue序号从1开始，这与c#中不一样
            decimal decValue;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc1 = (float)decValue;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc2 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc3 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc4 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc5 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc6 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc7 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc8 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc9 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc10 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc11 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc12 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc13 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc14 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc15 = (float)decValue;;
            iIndex++;
            if (!this.GetMyDecimal(out decValue, iIndex, arrQ.GetValue(iIndex), values.GetValue(iIndex), out sErr)) return false;
            data.Yc16 = (float)decValue;;
            return true;
        }
        private bool GetMyDecimal(out decimal decValue, int iIndex, object objQItem, object objValue, out string sErr)
        {
            decValue = 0M;
            if (objQItem == null)
            {
                sErr = $"压差结果值[index={iIndex}]返回的Quality为空！";
                return false;
            }
            else if (objQItem.ToString() != "192")
            {
                sErr = $"压差结果值[index={iIndex}]返回的Quality为{objQItem.ToString()}不是预期的192！";
                return false;
            }
            else
            {
                if (objValue == null)
                {
                    decValue = 0M;
                }
                else
                {
                    float fValue;
                    if (!float.TryParse(objValue.ToString(), out fValue))
                    {
                        sErr = $"压差OPC读取的返回值为[{objValue.ToString()}]不是数值类型！";
                        return false;
                    }
                    decValue = (decimal)fValue;
                }
                sErr = string.Empty;
                return true;
            }
        }
        #endregion
    }
    public class OPCHelperPrinter : OPCHelperBase
    {
        public event ShowMsgCallback LogNotice = null;
        OPCServer _Server = null;
        OPCGroups _ServerGroups = null;
        public OPCGroup _MyGroup_Printer = null;
        //获取槽号
        #region 用于读取结果的opcitem的
        public JpsOPC.MyItemValue Pt_Finished1 = null;
        public JpsOPC.MyItemValue Pt_Finished2 = null;
        public JpsOPC.MyItemValue Pt_Finished3 = null;
        public JpsOPC.MyItemValue Pt_Finished4 = null;
        public JpsOPC.MyItemValue Pt_Finished5 = null;
        public JpsOPC.MyItemValue Pt_Finished6 = null;
        public JpsOPC.MyItemValue Pt_Finished7 = null;
        public JpsOPC.MyItemValue Pt_Finished8 = null;
        public JpsOPC.MyItemValue Pt_Finished9 = null;
        public JpsOPC.MyItemValue Pt_Finished10 = null;
        #endregion
        #region 公共函数
        public bool InitServer(out string sErr)
        {
            if(this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (_Server == null)
            {
                try
                {
                    this._Server = new OPCServer();
                }
                catch (Exception ex)
                {
                    sErr = "ResultOPC：初始化Server出错：" + ex.Message + "(" + ex.Source + ")";
                    return false;
                }
            }
            if (this._Server.ServerState != (int)OPCServerState.OPCRunning)
            {
                try
                {
                    this._Server.Connect("KEPware.KEPServerEx.V6", "");
                }
                catch (Exception ex)
                {
                    sErr = string.Format("ResultOPC：server初始化出错：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
                //重新连接过的话重新定义组
                _ServerGroups = null;

                //重新读取opcItem
                if (this.Pt_Finished1 != null)
                    this.Pt_Finished1.InitItem();
                if (this.Pt_Finished2 != null)
                    this.Pt_Finished2.InitItem();
                if (this.Pt_Finished3 != null)
                    this.Pt_Finished3.InitItem();
                if (this.Pt_Finished4 != null)
                    this.Pt_Finished4.InitItem();
                if (this.Pt_Finished5 != null)
                    this.Pt_Finished5.InitItem();
                if (this.Pt_Finished6 != null)
                    this.Pt_Finished6.InitItem();
                if (this.Pt_Finished7 != null)
                    this.Pt_Finished7.InitItem();
                if (this.Pt_Finished8 != null)
                    this.Pt_Finished8.InitItem();
                if (this.Pt_Finished9 != null)
                    this.Pt_Finished9.InitItem();
                if (this.Pt_Finished10 != null)
                    this.Pt_Finished10.InitItem();

            }
            //添加组
            if (_ServerGroups == null)
            {
                _ServerGroups = this._Server.OPCGroups;
                _ServerGroups.DefaultGroupIsActive = true; //设置组集合默认为激活状态
                //下面这个几个暂时不设定，看看是否有异常，因为DefaultGroupUpdateRate这个值很关键，估计是与写入和读取的频率相关了，应该设置到某个单一的节点为好。
                _ServerGroups.DefaultGroupDeadband = 0;    //设置死区
                _ServerGroups.DefaultGroupUpdateRate = 100;//设置更新频率
                try
                {
                    //
                    this._MyGroup_Printer = _ServerGroups.Add("myGroupPrinter");
                    this._MyGroup_Printer.UpdateRate = 100;
                    this._MyGroup_Printer.IsActive = true;
                }
                catch (Exception ex)
                {
                    sErr = string.Format("创建各组失败：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
            }
            if (!this.InitMyItems(out sErr))
            {
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool InitMyItems(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (this.Pt_Finished1 == null)
                Pt_Finished1 = new MyItemValue(OPCItemTitle + "Pt_Finished1");
            if (this.Pt_Finished2 == null)
                Pt_Finished2 = new MyItemValue(OPCItemTitle + "Pt_Finished2");
            if (this.Pt_Finished3 == null)
                Pt_Finished3 = new MyItemValue(OPCItemTitle + "Pt_Finished3");
            if (this.Pt_Finished4 == null)
                Pt_Finished4 = new MyItemValue(OPCItemTitle + "Pt_Finished4");
            if (this.Pt_Finished5 == null)
                Pt_Finished5 = new MyItemValue(OPCItemTitle + "Pt_Finished5");
            if (this.Pt_Finished6 == null)
                Pt_Finished6 = new MyItemValue(OPCItemTitle + "Pt_Finished6");
            if (this.Pt_Finished7 == null)
                Pt_Finished7 = new MyItemValue(OPCItemTitle + "Pt_Finished7");
            if (this.Pt_Finished8 == null)
                Pt_Finished8 = new MyItemValue(OPCItemTitle + "Pt_Finished8");
            if (this.Pt_Finished9 == null)
                Pt_Finished9 = new MyItemValue(OPCItemTitle + "Pt_Finished9");
            if (this.Pt_Finished10 == null)
                Pt_Finished10 = new MyItemValue(OPCItemTitle + "Pt_Finished10");

            //在OPCGroup中添加IOPCItem
            if (this._MyGroup_Printer == null)
            {
                sErr = "初始化打印状态item时失败，因为group为空。";
                return false;
            }
            if (_MyGroup_Printer.OPCItems == null)
            {
                sErr = "初始化打印状态item时失败，因为group.OPCItems为空。";
                return false;
            }
            //处理标识

            if (!InitMyItems_AddItem(this.Pt_Finished1, this._MyGroup_Printer, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Pt_Finished2, this._MyGroup_Printer, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Pt_Finished3, this._MyGroup_Printer, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Pt_Finished4, this._MyGroup_Printer, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Pt_Finished5, this._MyGroup_Printer, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Pt_Finished6, this._MyGroup_Printer, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Pt_Finished7, this._MyGroup_Printer, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Pt_Finished8, this._MyGroup_Printer, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Pt_Finished9, this._MyGroup_Printer, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Pt_Finished10, this._MyGroup_Printer, true, out sErr))
            {
                return false;
            }
            return true;
        }
        private bool InitMyItems_AddItem(MyItemValue myItem, OPCGroup targetGroup, bool saveItem, out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (myItem.ServerHandle <= 0)
            {
                if (this.IsDebug)
                {
                    sErr = string.Empty;
                    return true;
                }
                //此时添加Item
                _ClientHandle++;
                OPCItem item = null;
                string strTagName = myItem.TagName;
                try
                {
                    item = targetGroup.OPCItems.AddItem(strTagName, _ClientHandle);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("添加Item：{0}，出错:{1}({2})", myItem.TagName, ex.Message, ex.Source);
                    return false;
                }
                if (item == null)
                {
                    sErr = string.Format("添加Item：{0}失败，返回为空。", myItem.TagName);
                    return false;
                }
                if (item.ServerHandle <= 0)
                {
                    sErr = string.Format("添加Item：{0}失败，返回值ServerHandle为{1}。", myItem.TagName, myItem.ServerHandle);
                    return false;
                }
                myItem.ServerHandle = item.ServerHandle;
                myItem.ClientHandle = this._ClientHandle;
                if (saveItem)
                    myItem._OPCItem = item;
            }
            sErr = string.Empty;
            return true;
        }
        public bool CloseOPC(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            sErr = "";
            if (this._Server == null) return true;
            try
            {
                this._Server.Disconnect();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
                return false;
            }
            return true;
        }
        #endregion
        #region 特殊功能函数
        public bool IsPrintingNow(int iIndex,out bool blPrintNow, out string sErr)
        {
            this.ShowLog(string.Format("from JPSOPC：当前请求查询{0}号槽是否要打印。", iIndex));
            if(this.IsDebug)
            {
                blPrintNow = true;
                sErr = string.Empty;
                return true;
            }
            MyItemValue item;
            if (iIndex == 1)
            {
                item = this.Pt_Finished1;
            }
            else if (iIndex == 2)
            {
                item = this.Pt_Finished2;
            }
            else if (iIndex == 3)
            {
                item = this.Pt_Finished3;
            }
            else if (iIndex == 4)
            {
                item = this.Pt_Finished4;
            }
            else if (iIndex == 5)
            {
                item = this.Pt_Finished5;
            }
            else if (iIndex == 6)
            {
                item = this.Pt_Finished6;
            }
            else if (iIndex == 7)
            {
                item = this.Pt_Finished7;
            }
            else if (iIndex == 8)
            {
                item = this.Pt_Finished8;
            }
            else if (iIndex == 9)
            {
                item = this.Pt_Finished9;
            }
            else if (iIndex == 10)
            {
                item = this.Pt_Finished10;
            }
            else
            {
                sErr = "请传入正确的打印机序号，必须是1~10的，当前传入值:" + iIndex.ToString();
                blPrintNow = false;
                return false;
            }
            if(!this.ReadPrinterState(item,out sErr))
            {
                blPrintNow = false;
                return false;
            }
            blPrintNow = item.Value_Bool;
            return true;
        }
        /// <summary>
        /// 判断PLC标识，是否现在可以读取测试结果了
        /// </summary>
        /// <param name="sErr"></param>
        /// <returns>是否执行成功</returns>
        private bool ReadPrinterState(MyItemValue item,out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (item == null)
            {
                sErr = "OPC.Printer对象为空！";
                return false;
            }
            else if (item._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "OPC.Printer的OPCItem为空，且初始化出错：" + sErr;
                    return false;
                }
            }
            if (item.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "OPC.Printer的OPCItemHandle值为0，但重新初始化时出错：" + sErr;
                    return false;
                }
            }
            //此时有效了，直接读取值
            object objValue;
            if (!item.ReadData(out objValue, out sErr))
            {
                sErr = "OPC.Printer的OPCItem(AT_ReadResult)读取出错：" + sErr;
                return false;
            }
            if (objValue == null)
            {
                sErr = string.Format("OPC.Printer读取出错：item对象[{0}]的返回值NULL。", item.TagName);
                return false;
            }
            //此时读取成功了，则转换
            string strValue = objValue.ToString().ToLower();
            this.ShowLog(string.Format("读取到{0}值为[{1}]", item.TagName, strValue));
            if (strValue == "true" || strValue == "1" || strValue == "yes")
                item.Value_Bool = true;
            else item.Value_Bool = false;
            return true;
        }
        #endregion
        #region 消息处理
        private void ShowLog(string sMsg)
        {
            if (this.LogNotice != null)
                this.LogNotice(sMsg);
        }
        #endregion
    }
    public class OPCHelperGongYi : OPCHelperBase
    {
        public static short Debug_sysNew = 0;
        public static short Debug_SysCompeleted = 0;
        OPCServer _Server = null;
        OPCGroups _ServerGroups = null;
        public OPCGroup _MyGroup_Gongyi = null;
        public OPCGroup _MyGroup_Correct = null;
        //获取槽号
        public JpsOPC.MyItemValue At_SysRun = null;
        public JpsOPC.MyItemValue At_SysNew = null;
        public JpsOPC.MyItemValue At_SysCompeleted = null;
        public JpsOPC.MyItemValue Exp_SwMode = null;

        #region 用于写入工艺数据
        public JpsOPC.MyItemValue GY_IsNet = null;
        public JpsOPC.MyItemValue GY_IsScanner = null;
        public JpsOPC.MyItemValue GY_MBatchChecker = null;
        public JpsOPC.MyItemValue GY_IsSameGy = null;
        public JpsOPC.MyItemValue GY_DxSize = null;
        public JpsOPC.MyItemValue St_Cao1Vmin = null;
        public JpsOPC.MyItemValue St_Cao1Vmax = null;
        public JpsOPC.MyItemValue St_Cao1Dzmin = null;
        public JpsOPC.MyItemValue St_Cao1Dzmax = null;
        public JpsOPC.MyItemValue St_Cao1Used = null;
        public JpsOPC.MyItemValue St_Cao1DxCnt = null;
        public JpsOPC.MyItemValue St_Cao2Vmin = null;
        public JpsOPC.MyItemValue St_Cao2Vmax = null;
        public JpsOPC.MyItemValue St_Cao2Dzmin = null;
        public JpsOPC.MyItemValue St_Cao2Dzmax = null;
        public JpsOPC.MyItemValue St_Cao2Used = null;
        public JpsOPC.MyItemValue St_Cao2DxCnt = null;
        public JpsOPC.MyItemValue St_Cao3Vmin = null;
        public JpsOPC.MyItemValue St_Cao3Vmax = null;
        public JpsOPC.MyItemValue St_Cao3Dzmin = null;
        public JpsOPC.MyItemValue St_Cao3Dzmax = null;
        public JpsOPC.MyItemValue St_Cao3Used = null;
        public JpsOPC.MyItemValue St_Cao3DxCnt = null;
        public JpsOPC.MyItemValue St_Cao4Vmin = null;
        public JpsOPC.MyItemValue St_Cao4Vmax = null;
        public JpsOPC.MyItemValue St_Cao4Dzmin = null;
        public JpsOPC.MyItemValue St_Cao4Dzmax = null;
        public JpsOPC.MyItemValue St_Cao4Used = null;
        public JpsOPC.MyItemValue St_Cao4DxCnt = null;
        public JpsOPC.MyItemValue St_Cao5Vmin = null;
        public JpsOPC.MyItemValue St_Cao5Vmax = null;
        public JpsOPC.MyItemValue St_Cao5Dzmin = null;
        public JpsOPC.MyItemValue St_Cao5Dzmax = null;
        public JpsOPC.MyItemValue St_Cao5Used = null;
        public JpsOPC.MyItemValue St_Cao5DxCnt = null;
        public JpsOPC.MyItemValue St_Cao6Vmin = null;
        public JpsOPC.MyItemValue St_Cao6Vmax = null;
        public JpsOPC.MyItemValue St_Cao6Dzmin = null;
        public JpsOPC.MyItemValue St_Cao6Dzmax = null;
        public JpsOPC.MyItemValue St_Cao6Used = null;
        public JpsOPC.MyItemValue St_Cao6DxCnt = null;
        public JpsOPC.MyItemValue St_Cao7Vmin = null;
        public JpsOPC.MyItemValue St_Cao7Vmax = null;
        public JpsOPC.MyItemValue St_Cao7Dzmin = null;
        public JpsOPC.MyItemValue St_Cao7Dzmax = null;
        public JpsOPC.MyItemValue St_Cao7Used = null;
        public JpsOPC.MyItemValue St_Cao7DxCnt = null;
        public JpsOPC.MyItemValue St_Cao8Vmin = null;
        public JpsOPC.MyItemValue St_Cao8Vmax = null;
        public JpsOPC.MyItemValue St_Cao8Dzmin = null;
        public JpsOPC.MyItemValue St_Cao8Dzmax = null;
        public JpsOPC.MyItemValue St_Cao8Used = null;
        public JpsOPC.MyItemValue St_Cao8DxCnt = null;
        public JpsOPC.MyItemValue St_Cao9Vmin = null;
        public JpsOPC.MyItemValue St_Cao9Vmax = null;
        public JpsOPC.MyItemValue St_Cao9Dzmin = null;
        public JpsOPC.MyItemValue St_Cao9Dzmax = null;
        public JpsOPC.MyItemValue St_Cao9Used = null;
        public JpsOPC.MyItemValue St_Cao9DxCnt = null;
        public JpsOPC.MyItemValue St_Cao10Vmin = null;
        public JpsOPC.MyItemValue St_Cao10Vmax = null;
        public JpsOPC.MyItemValue St_Cao10Dzmin = null;
        public JpsOPC.MyItemValue St_Cao10Dzmax = null;
        public JpsOPC.MyItemValue St_Cao10Used = null;
        public JpsOPC.MyItemValue St_Cao10DxCnt = null;
        public JpsOPC.MyItemValue St_Cao11Vmin = null;
        public JpsOPC.MyItemValue St_Cao11Vmax = null;
        public JpsOPC.MyItemValue St_Cao11Dzmin = null;
        public JpsOPC.MyItemValue St_Cao11Dzmax = null;
        public JpsOPC.MyItemValue St_Cao11Used = null;
        public JpsOPC.MyItemValue St_Cao11DxCnt = null;
        public JpsOPC.MyItemValue St_Cao12Vmin = null;
        public JpsOPC.MyItemValue St_Cao12Vmax = null;
        public JpsOPC.MyItemValue St_Cao12Dzmin = null;
        public JpsOPC.MyItemValue St_Cao12Dzmax = null;
        public JpsOPC.MyItemValue St_Cao12Used = null;
        public JpsOPC.MyItemValue St_Cao12DxCnt = null;
        public JpsOPC.MyItemValue St_Cao13Vmin = null;
        public JpsOPC.MyItemValue St_Cao13Vmax = null;
        public JpsOPC.MyItemValue St_Cao13Dzmin = null;
        public JpsOPC.MyItemValue St_Cao13Dzmax = null;
        public JpsOPC.MyItemValue St_Cao13Used = null;
        public JpsOPC.MyItemValue St_Cao13DxCnt = null;
        public JpsOPC.MyItemValue St_Cao14Vmin = null;
        public JpsOPC.MyItemValue St_Cao14Vmax = null;
        public JpsOPC.MyItemValue St_Cao14Dzmin = null;
        public JpsOPC.MyItemValue St_Cao14Dzmax = null;
        public JpsOPC.MyItemValue St_Cao14Used = null;
        public JpsOPC.MyItemValue St_Cao14DxCnt = null;
        public JpsOPC.MyItemValue St_Cao15Vmin = null;
        public JpsOPC.MyItemValue St_Cao15Vmax = null;
        public JpsOPC.MyItemValue St_Cao15Dzmin = null;
        public JpsOPC.MyItemValue St_Cao15Dzmax = null;
        public JpsOPC.MyItemValue St_Cao15Used = null;
        public JpsOPC.MyItemValue St_Cao15DxCnt = null;
        public JpsOPC.MyItemValue St_Cao16Vmin = null;
        public JpsOPC.MyItemValue St_Cao16Vmax = null;
        public JpsOPC.MyItemValue St_Cao16Dzmin = null;
        public JpsOPC.MyItemValue St_Cao16Dzmax = null;
        public JpsOPC.MyItemValue St_Cao16Used = null;
        public JpsOPC.MyItemValue St_Cao16DxCnt = null;
        public JpsOPC.MyItemValue St_Cao17Vmin = null;
        public JpsOPC.MyItemValue St_Cao17Vmax = null;
        public JpsOPC.MyItemValue St_Cao17Dzmin = null;
        public JpsOPC.MyItemValue St_Cao17Dzmax = null;
        public JpsOPC.MyItemValue St_Cao17Used = null;
        public JpsOPC.MyItemValue St_Cao17DxCnt = null;
        public JpsOPC.MyItemValue St_Cao18Vmin = null;
        public JpsOPC.MyItemValue St_Cao18Vmax = null;
        public JpsOPC.MyItemValue St_Cao18Dzmin = null;
        public JpsOPC.MyItemValue St_Cao18Dzmax = null;
        public JpsOPC.MyItemValue St_Cao18Used = null;
        public JpsOPC.MyItemValue St_Cao18DxCnt = null;
        #endregion
        #region 用于写入修正值的
        public JpsOPC.MyItemValue Ct_Mes1V = null;
        public JpsOPC.MyItemValue Ct_Mes1Dz = null;
        public JpsOPC.MyItemValue Ct_Mes2V = null;
        public JpsOPC.MyItemValue Ct_Mes2Dz = null;
        public JpsOPC.MyItemValue Ct_Mes3V = null;
        public JpsOPC.MyItemValue Ct_Mes3Dz = null;
        public JpsOPC.MyItemValue Ct_Mes4V = null;
        public JpsOPC.MyItemValue Ct_Mes4Dz = null;
        public JpsOPC.MyItemValue Ct_Mes5V = null;
        public JpsOPC.MyItemValue Ct_Mes5Dz = null;
        public JpsOPC.MyItemValue Ct_Mes6V = null;
        public JpsOPC.MyItemValue Ct_Mes6Dz = null;
        public JpsOPC.MyItemValue Ct_Mes7V = null;
        public JpsOPC.MyItemValue Ct_Mes7Dz = null;
        public JpsOPC.MyItemValue Ct_Mes8V = null;
        public JpsOPC.MyItemValue Ct_Mes8Dz = null;
        public JpsOPC.MyItemValue Ct_Mes9V = null;
        public JpsOPC.MyItemValue Ct_Mes9Dz = null;
        public JpsOPC.MyItemValue Ct_Mes10V = null;
        public JpsOPC.MyItemValue Ct_Mes10Dz = null;
        public JpsOPC.MyItemValue Ct_Mes11V = null;
        public JpsOPC.MyItemValue Ct_Mes11Dz = null;
        public JpsOPC.MyItemValue Ct_Mes12V = null;
        public JpsOPC.MyItemValue Ct_Mes12Dz = null;
        public JpsOPC.MyItemValue Ct_Mes13V = null;
        public JpsOPC.MyItemValue Ct_Mes13Dz = null;
        public JpsOPC.MyItemValue Ct_Mes14V = null;
        public JpsOPC.MyItemValue Ct_Mes14Dz = null;
        public JpsOPC.MyItemValue Ct_Mes15V = null;
        public JpsOPC.MyItemValue Ct_Mes15Dz = null;
        public JpsOPC.MyItemValue Ct_Mes16V = null;
        public JpsOPC.MyItemValue Ct_Mes16Dz = null;
        public JpsOPC.MyItemValue Ct_Mes17V = null;
        public JpsOPC.MyItemValue Ct_Mes17Dz = null;
        public JpsOPC.MyItemValue Ct_Mes18V = null;
        public JpsOPC.MyItemValue Ct_Mes18Dz = null;
        public JpsOPC.MyItemValue Ct_Mes19V = null;
        public JpsOPC.MyItemValue Ct_Mes19Dz = null;
        public JpsOPC.MyItemValue Ct_Mes20V = null;
        public JpsOPC.MyItemValue Ct_Mes20Dz = null;
        public JpsOPC.MyItemValue Ct_Mes21V = null;
        public JpsOPC.MyItemValue Ct_Mes21Dz = null;
        public JpsOPC.MyItemValue Ct_Mes22V = null;
        public JpsOPC.MyItemValue Ct_Mes22Dz = null;
        public JpsOPC.MyItemValue Ct_Mes23V = null;
        public JpsOPC.MyItemValue Ct_Mes23Dz = null;
        public JpsOPC.MyItemValue Ct_Mes24V = null;
        public JpsOPC.MyItemValue Ct_Mes24Dz = null;
        public JpsOPC.MyItemValue Ct_Mes25V = null;
        public JpsOPC.MyItemValue Ct_Mes25Dz = null;
        public JpsOPC.MyItemValue Ct_Mes26V = null;
        public JpsOPC.MyItemValue Ct_Mes26Dz = null;
        public JpsOPC.MyItemValue Ct_Mes27V = null;
        public JpsOPC.MyItemValue Ct_Mes27Dz = null;
        public JpsOPC.MyItemValue Ct_Mes28V = null;
        public JpsOPC.MyItemValue Ct_Mes28Dz = null;
        public JpsOPC.MyItemValue Ct_Mes29V = null;
        public JpsOPC.MyItemValue Ct_Mes29Dz = null;
        public JpsOPC.MyItemValue Ct_Mes30V = null;
        public JpsOPC.MyItemValue Ct_Mes30Dz = null;
        public JpsOPC.MyItemValue Ct_Mes31V = null;
        public JpsOPC.MyItemValue Ct_Mes31Dz = null;
        public JpsOPC.MyItemValue Ct_Mes32V = null;
        public JpsOPC.MyItemValue Ct_Mes32Dz = null;
        public JpsOPC.MyItemValue Ct_Mes33V = null;
        public JpsOPC.MyItemValue Ct_Mes33Dz = null;
        public JpsOPC.MyItemValue Ct_Mes34V = null;
        public JpsOPC.MyItemValue Ct_Mes34Dz = null;
        public JpsOPC.MyItemValue Ct_Mes35V = null;
        public JpsOPC.MyItemValue Ct_Mes35Dz = null;
        public JpsOPC.MyItemValue Ct_Mes36V = null;
        public JpsOPC.MyItemValue Ct_Mes36Dz = null;
        public JpsOPC.MyItemValue Ct_Mes37V = null;
        public JpsOPC.MyItemValue Ct_Mes37Dz = null;
        public JpsOPC.MyItemValue Ct_Mes38V = null;
        public JpsOPC.MyItemValue Ct_Mes38Dz = null;
        public JpsOPC.MyItemValue Ct_Mes39V = null;
        public JpsOPC.MyItemValue Ct_Mes39Dz = null;
        public JpsOPC.MyItemValue Ct_Mes40V = null;
        public JpsOPC.MyItemValue Ct_Mes40Dz = null;

        #endregion
        #region 南京中比各槽AB档上下限和数量
        //槽AB上下限
        public JpsOPC.MyItemValue Exp_Cao1ACapMax = null;
        public JpsOPC.MyItemValue Exp_Cao1ACapMin = null;
        public JpsOPC.MyItemValue Exp_Cao1BCapMax = null;
        public JpsOPC.MyItemValue Exp_Cao1BCapMin = null;
        public JpsOPC.MyItemValue Exp_Cao2ACapMax = null;
        public JpsOPC.MyItemValue Exp_Cao2ACapMin = null;
        public JpsOPC.MyItemValue Exp_Cao2BCapMax = null;
        public JpsOPC.MyItemValue Exp_Cao2BCapMin = null;
        public JpsOPC.MyItemValue Exp_Cao3ACapMax = null;
        public JpsOPC.MyItemValue Exp_Cao3ACapMin = null;
        public JpsOPC.MyItemValue Exp_Cao3BCapMax = null;
        public JpsOPC.MyItemValue Exp_Cao3BCapMin = null;
        public JpsOPC.MyItemValue Exp_Cao4ACapMax = null;
        public JpsOPC.MyItemValue Exp_Cao4ACapMin = null;
        public JpsOPC.MyItemValue Exp_Cao4BCapMax = null;
        public JpsOPC.MyItemValue Exp_Cao4BCapMin = null;
        public JpsOPC.MyItemValue Exp_Cao5ACapMax = null;
        public JpsOPC.MyItemValue Exp_Cao5ACapMin = null;
        public JpsOPC.MyItemValue Exp_Cao5BCapMax = null;
        public JpsOPC.MyItemValue Exp_Cao5BCapMin = null;
        public JpsOPC.MyItemValue Exp_Cao6ACapMax = null;
        public JpsOPC.MyItemValue Exp_Cao6ACapMin = null;
        public JpsOPC.MyItemValue Exp_Cao6BCapMax = null;
        public JpsOPC.MyItemValue Exp_Cao6BCapMin = null;
        public JpsOPC.MyItemValue Exp_Cao7ACapMax = null;
        public JpsOPC.MyItemValue Exp_Cao7ACapMin = null;
        public JpsOPC.MyItemValue Exp_Cao7BCapMax = null;
        public JpsOPC.MyItemValue Exp_Cao7BCapMin = null;
        public JpsOPC.MyItemValue Exp_Cao8ACapMax = null;
        public JpsOPC.MyItemValue Exp_Cao8ACapMin = null;
        public JpsOPC.MyItemValue Exp_Cao8BCapMax = null;
        public JpsOPC.MyItemValue Exp_Cao8BCapMin = null;
        public JpsOPC.MyItemValue Exp_Cao9ACapMax = null;
        public JpsOPC.MyItemValue Exp_Cao9ACapMin = null;
        public JpsOPC.MyItemValue Exp_Cao9BCapMax = null;
        public JpsOPC.MyItemValue Exp_Cao9BCapMin = null;
        //各槽的AB数量
        public JpsOPC.MyItemValue Exp_Cao1AQty = null;
        public JpsOPC.MyItemValue Exp_Cao1BQty = null;
        public JpsOPC.MyItemValue Exp_Cao2AQty = null;
        public JpsOPC.MyItemValue Exp_Cao2BQty = null;
        public JpsOPC.MyItemValue Exp_Cao3AQty = null;
        public JpsOPC.MyItemValue Exp_Cao3BQty = null;
        public JpsOPC.MyItemValue Exp_Cao4AQty = null;
        public JpsOPC.MyItemValue Exp_Cao4BQty = null;
        public JpsOPC.MyItemValue Exp_Cao5AQty = null;
        public JpsOPC.MyItemValue Exp_Cao5BQty = null;
        public JpsOPC.MyItemValue Exp_Cao6AQty = null;
        public JpsOPC.MyItemValue Exp_Cao6BQty = null;
        public JpsOPC.MyItemValue Exp_Cao7AQty = null;
        public JpsOPC.MyItemValue Exp_Cao7BQty = null;
        public JpsOPC.MyItemValue Exp_Cao8AQty = null;
        public JpsOPC.MyItemValue Exp_Cao8BQty = null;
        public JpsOPC.MyItemValue Exp_Cao9AQty = null;
        public JpsOPC.MyItemValue Exp_Cao9BQty = null;
        //通道的压差
        //public JpsOPC.MyItemValue Exp_Yc1 = null;
        //public JpsOPC.MyItemValue Exp_Yc2 = null;
        //public JpsOPC.MyItemValue Exp_Yc3 = null;
        //public JpsOPC.MyItemValue Exp_Yc4 = null;
        //public JpsOPC.MyItemValue Exp_Yc5 = null;
        //public JpsOPC.MyItemValue Exp_Yc6 = null;
        //public JpsOPC.MyItemValue Exp_Yc7 = null;
        //public JpsOPC.MyItemValue Exp_Yc8 = null;
        //public JpsOPC.MyItemValue Exp_Yc9 = null;
        //public JpsOPC.MyItemValue Exp_Yc10 = null;
        //public JpsOPC.MyItemValue Exp_Yc11 = null;
        //public JpsOPC.MyItemValue Exp_Yc12 = null;
        //public JpsOPC.MyItemValue Exp_Yc13 = null;
        //public JpsOPC.MyItemValue Exp_Yc14 = null;
        //public JpsOPC.MyItemValue Exp_Yc15 = null;
        //public JpsOPC.MyItemValue Exp_Yc16 = null;
        //压差设置
        public JpsOPC.MyItemValue Exp_YcSet = null;

        #endregion
        #region 公共函数
        public bool InitServer(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (_Server == null)
            {
                try
                {
                    this._Server = new OPCServer();
                }
                catch (Exception ex)
                {
                    sErr = "GongYiOPC：初始化Server出错：" + ex.Message + "(" + ex.Source + ")";
                    return false;
                }
            }
            if (this._Server.ServerState != (int)OPCServerState.OPCRunning)
            {
                try
                {
                    this._Server.Connect("KEPware.KEPServerEx.V6", "");
                }
                catch (Exception ex)
                {
                    sErr = string.Format("GongYiOPC：server初始化出错：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
                //重新连接过的话重新定义组
                _ServerGroups = null;
                if (this.At_SysRun != null)
                    this.At_SysRun.InitItem();
                if (this.At_SysNew != null)
                    this.At_SysNew.InitItem();
                if (this.At_SysCompeleted != null)
                    this.At_SysCompeleted.InitItem();
                if (this.Exp_SwMode != null)
                    this.Exp_SwMode.InitItem();
                //重新读取opcItem
                if (this.GY_IsNet != null)
                    this.GY_IsNet.InitItem();
                if (this.GY_IsScanner != null)
                    this.GY_IsScanner.InitItem();
                if (this.GY_MBatchChecker != null)
                    this.GY_MBatchChecker.InitItem();
                if (this.GY_IsSameGy != null)
                    this.GY_IsSameGy.InitItem();
                if (this.GY_DxSize != null)
                    this.GY_DxSize.InitItem();
                if (this.St_Cao1Vmin != null)
                    this.St_Cao1Vmin.InitItem();
                if (this.St_Cao1Vmax != null)
                    this.St_Cao1Vmax.InitItem();
                if (this.St_Cao1Dzmin != null)
                    this.St_Cao1Dzmin.InitItem();
                if (this.St_Cao1Dzmax != null)
                    this.St_Cao1Dzmax.InitItem();
                if (this.St_Cao1Used != null)
                    this.St_Cao1Used.InitItem();
                if (this.St_Cao1DxCnt != null)
                    this.St_Cao1DxCnt.InitItem();
                if (this.St_Cao2Vmin != null)
                    this.St_Cao2Vmin.InitItem();
                if (this.St_Cao2Vmax != null)
                    this.St_Cao2Vmax.InitItem();
                if (this.St_Cao2Dzmin != null)
                    this.St_Cao2Dzmin.InitItem();
                if (this.St_Cao2Dzmax != null)
                    this.St_Cao2Dzmax.InitItem();
                if (this.St_Cao2Used != null)
                    this.St_Cao2Used.InitItem();
                if (this.St_Cao2DxCnt != null)
                    this.St_Cao2DxCnt.InitItem();
                if (this.St_Cao3Vmin != null)
                    this.St_Cao3Vmin.InitItem();
                if (this.St_Cao3Vmax != null)
                    this.St_Cao3Vmax.InitItem();
                if (this.St_Cao3Dzmin != null)
                    this.St_Cao3Dzmin.InitItem();
                if (this.St_Cao3Dzmax != null)
                    this.St_Cao3Dzmax.InitItem();
                if (this.St_Cao3Used != null)
                    this.St_Cao3Used.InitItem();
                if (this.St_Cao3DxCnt != null)
                    this.St_Cao3DxCnt.InitItem();
                if (this.St_Cao4Vmin != null)
                    this.St_Cao4Vmin.InitItem();
                if (this.St_Cao4Vmax != null)
                    this.St_Cao4Vmax.InitItem();
                if (this.St_Cao4Dzmin != null)
                    this.St_Cao4Dzmin.InitItem();
                if (this.St_Cao4Dzmax != null)
                    this.St_Cao4Dzmax.InitItem();
                if (this.St_Cao4Used != null)
                    this.St_Cao4Used.InitItem();
                if (this.St_Cao4DxCnt != null)
                    this.St_Cao4DxCnt.InitItem();
                if (this.St_Cao5Vmin != null)
                    this.St_Cao5Vmin.InitItem();
                if (this.St_Cao5Vmax != null)
                    this.St_Cao5Vmax.InitItem();
                if (this.St_Cao5Dzmin != null)
                    this.St_Cao5Dzmin.InitItem();
                if (this.St_Cao5Dzmax != null)
                    this.St_Cao5Dzmax.InitItem();
                if (this.St_Cao5Used != null)
                    this.St_Cao5Used.InitItem();
                if (this.St_Cao5DxCnt != null)
                    this.St_Cao5DxCnt.InitItem();
                if (this.St_Cao6Vmin != null)
                    this.St_Cao6Vmin.InitItem();
                if (this.St_Cao6Vmax != null)
                    this.St_Cao6Vmax.InitItem();
                if (this.St_Cao6Dzmin != null)
                    this.St_Cao6Dzmin.InitItem();
                if (this.St_Cao6Dzmax != null)
                    this.St_Cao6Dzmax.InitItem();
                if (this.St_Cao6Used != null)
                    this.St_Cao6Used.InitItem();
                if (this.St_Cao6DxCnt != null)
                    this.St_Cao6DxCnt.InitItem();
                if (this.St_Cao7Vmin != null)
                    this.St_Cao7Vmin.InitItem();
                if (this.St_Cao7Vmax != null)
                    this.St_Cao7Vmax.InitItem();
                if (this.St_Cao7Dzmin != null)
                    this.St_Cao7Dzmin.InitItem();
                if (this.St_Cao7Dzmax != null)
                    this.St_Cao7Dzmax.InitItem();
                if (this.St_Cao7Used != null)
                    this.St_Cao7Used.InitItem();
                if (this.St_Cao7DxCnt != null)
                    this.St_Cao7DxCnt.InitItem();
                if (this.St_Cao8Vmin != null)
                    this.St_Cao8Vmin.InitItem();
                if (this.St_Cao8Vmax != null)
                    this.St_Cao8Vmax.InitItem();
                if (this.St_Cao8Dzmin != null)
                    this.St_Cao8Dzmin.InitItem();
                if (this.St_Cao8Dzmax != null)
                    this.St_Cao8Dzmax.InitItem();
                if (this.St_Cao8Used != null)
                    this.St_Cao8Used.InitItem();
                if (this.St_Cao8DxCnt != null)
                    this.St_Cao8DxCnt.InitItem();
                if (this.St_Cao9Vmin != null)
                    this.St_Cao9Vmin.InitItem();
                if (this.St_Cao9Vmax != null)
                    this.St_Cao9Vmax.InitItem();
                if (this.St_Cao9Dzmin != null)
                    this.St_Cao9Dzmin.InitItem();
                if (this.St_Cao9Dzmax != null)
                    this.St_Cao9Dzmax.InitItem();
                if (this.St_Cao9Used != null)
                    this.St_Cao9Used.InitItem();
                if (this.St_Cao9DxCnt != null)
                    this.St_Cao9DxCnt.InitItem();
                if (this.St_Cao10Vmin != null)
                    this.St_Cao10Vmin.InitItem();
                if (this.St_Cao10Vmax != null)
                    this.St_Cao10Vmax.InitItem();
                if (this.St_Cao10Dzmin != null)
                    this.St_Cao10Dzmin.InitItem();
                if (this.St_Cao10Dzmax != null)
                    this.St_Cao10Dzmax.InitItem();
                if (this.St_Cao10Used != null)
                    this.St_Cao10Used.InitItem();
                if (this.St_Cao10DxCnt != null)
                    this.St_Cao10DxCnt.InitItem();
                if (this.St_Cao11Vmin != null)
                    this.St_Cao11Vmin.InitItem();
                if (this.St_Cao11Vmax != null)
                    this.St_Cao11Vmax.InitItem();
                if (this.St_Cao11Dzmin != null)
                    this.St_Cao11Dzmin.InitItem();
                if (this.St_Cao11Dzmax != null)
                    this.St_Cao11Dzmax.InitItem();
                if (this.St_Cao11Used != null)
                    this.St_Cao11Used.InitItem();
                if (this.St_Cao11DxCnt != null)
                    this.St_Cao11DxCnt.InitItem();
                if (this.St_Cao12Vmin != null)
                    this.St_Cao12Vmin.InitItem();
                if (this.St_Cao12Vmax != null)
                    this.St_Cao12Vmax.InitItem();
                if (this.St_Cao12Dzmin != null)
                    this.St_Cao12Dzmin.InitItem();
                if (this.St_Cao12Dzmax != null)
                    this.St_Cao12Dzmax.InitItem();
                if (this.St_Cao12Used != null)
                    this.St_Cao12Used.InitItem();
                if (this.St_Cao12DxCnt != null)
                    this.St_Cao12DxCnt.InitItem();
                if (this.St_Cao13Vmin != null)
                    this.St_Cao13Vmin.InitItem();
                if (this.St_Cao13Vmax != null)
                    this.St_Cao13Vmax.InitItem();
                if (this.St_Cao13Dzmin != null)
                    this.St_Cao13Dzmin.InitItem();
                if (this.St_Cao13Dzmax != null)
                    this.St_Cao13Dzmax.InitItem();
                if (this.St_Cao13Used != null)
                    this.St_Cao13Used.InitItem();
                if (this.St_Cao13DxCnt != null)
                    this.St_Cao13DxCnt.InitItem();
                if (this.St_Cao14Vmin != null)
                    this.St_Cao14Vmin.InitItem();
                if (this.St_Cao14Vmax != null)
                    this.St_Cao14Vmax.InitItem();
                if (this.St_Cao14Dzmin != null)
                    this.St_Cao14Dzmin.InitItem();
                if (this.St_Cao14Dzmax != null)
                    this.St_Cao14Dzmax.InitItem();
                if (this.St_Cao14Used != null)
                    this.St_Cao14Used.InitItem();
                if (this.St_Cao14DxCnt != null)
                    this.St_Cao14DxCnt.InitItem();
                if (this.St_Cao15Vmin != null)
                    this.St_Cao15Vmin.InitItem();
                if (this.St_Cao15Vmax != null)
                    this.St_Cao15Vmax.InitItem();
                if (this.St_Cao15Dzmin != null)
                    this.St_Cao15Dzmin.InitItem();
                if (this.St_Cao15Dzmax != null)
                    this.St_Cao15Dzmax.InitItem();
                if (this.St_Cao15Used != null)
                    this.St_Cao15Used.InitItem();
                if (this.St_Cao15DxCnt != null)
                    this.St_Cao15DxCnt.InitItem();
                if (this.St_Cao16Vmin != null)
                    this.St_Cao16Vmin.InitItem();
                if (this.St_Cao16Vmax != null)
                    this.St_Cao16Vmax.InitItem();
                if (this.St_Cao16Dzmin != null)
                    this.St_Cao16Dzmin.InitItem();
                if (this.St_Cao16Dzmax != null)
                    this.St_Cao16Dzmax.InitItem();
                if (this.St_Cao16Used != null)
                    this.St_Cao16Used.InitItem();
                if (this.St_Cao16DxCnt != null)
                    this.St_Cao16DxCnt.InitItem();
                if (this.St_Cao17Vmin != null)
                    this.St_Cao17Vmin.InitItem();
                if (this.St_Cao17Vmax != null)
                    this.St_Cao17Vmax.InitItem();
                if (this.St_Cao17Dzmin != null)
                    this.St_Cao17Dzmin.InitItem();
                if (this.St_Cao17Dzmax != null)
                    this.St_Cao17Dzmax.InitItem();
                if (this.St_Cao17Used != null)
                    this.St_Cao17Used.InitItem();
                if (this.St_Cao17DxCnt != null)
                    this.St_Cao17DxCnt.InitItem();
                if (this.St_Cao18Vmin != null)
                    this.St_Cao18Vmin.InitItem();
                if (this.St_Cao18Vmax != null)
                    this.St_Cao18Vmax.InitItem();
                if (this.St_Cao18Dzmin != null)
                    this.St_Cao18Dzmin.InitItem();
                if (this.St_Cao18Dzmax != null)
                    this.St_Cao18Dzmax.InitItem();
                if (this.St_Cao18Used != null)
                    this.St_Cao18Used.InitItem();
                if (this.St_Cao18DxCnt != null)
                    this.St_Cao18DxCnt.InitItem();
                //南京中比的ab档的上下限
                if (this.Exp_Cao1ACapMax != null)
                    this.Exp_Cao1ACapMax.InitItem();
                if (this.Exp_Cao1ACapMin != null)
                    this.Exp_Cao1ACapMin.InitItem();
                if (this.Exp_Cao1BCapMax != null)
                    this.Exp_Cao1BCapMax.InitItem();
                if (this.Exp_Cao1BCapMin != null)
                    this.Exp_Cao1BCapMin.InitItem();
                if (this.Exp_Cao2ACapMax != null)
                    this.Exp_Cao2ACapMax.InitItem();
                if (this.Exp_Cao2ACapMin != null)
                    this.Exp_Cao2ACapMin.InitItem();
                if (this.Exp_Cao2BCapMax != null)
                    this.Exp_Cao2BCapMax.InitItem();
                if (this.Exp_Cao2BCapMin != null)
                    this.Exp_Cao2BCapMin.InitItem();
                if (this.Exp_Cao3ACapMax != null)
                    this.Exp_Cao3ACapMax.InitItem();
                if (this.Exp_Cao3ACapMin != null)
                    this.Exp_Cao3ACapMin.InitItem();
                if (this.Exp_Cao3BCapMax != null)
                    this.Exp_Cao3BCapMax.InitItem();
                if (this.Exp_Cao3BCapMin != null)
                    this.Exp_Cao3BCapMin.InitItem();
                if (this.Exp_Cao4ACapMax != null)
                    this.Exp_Cao4ACapMax.InitItem();
                if (this.Exp_Cao4ACapMin != null)
                    this.Exp_Cao4ACapMin.InitItem();
                if (this.Exp_Cao4BCapMax != null)
                    this.Exp_Cao4BCapMax.InitItem();
                if (this.Exp_Cao4BCapMin != null)
                    this.Exp_Cao4BCapMin.InitItem();
                if (this.Exp_Cao5ACapMax != null)
                    this.Exp_Cao5ACapMax.InitItem();
                if (this.Exp_Cao5ACapMin != null)
                    this.Exp_Cao5ACapMin.InitItem();
                if (this.Exp_Cao5BCapMax != null)
                    this.Exp_Cao5BCapMax.InitItem();
                if (this.Exp_Cao5BCapMin != null)
                    this.Exp_Cao5BCapMin.InitItem();
                if (this.Exp_Cao6ACapMax != null)
                    this.Exp_Cao6ACapMax.InitItem();
                if (this.Exp_Cao6ACapMin != null)
                    this.Exp_Cao6ACapMin.InitItem();
                if (this.Exp_Cao6BCapMax != null)
                    this.Exp_Cao6BCapMax.InitItem();
                if (this.Exp_Cao6BCapMin != null)
                    this.Exp_Cao6BCapMin.InitItem();
                if (this.Exp_Cao7ACapMax != null)
                    this.Exp_Cao7ACapMax.InitItem();
                if (this.Exp_Cao7ACapMin != null)
                    this.Exp_Cao7ACapMin.InitItem();
                if (this.Exp_Cao7BCapMax != null)
                    this.Exp_Cao7BCapMax.InitItem();
                if (this.Exp_Cao7BCapMin != null)
                    this.Exp_Cao7BCapMin.InitItem();
                if (this.Exp_Cao8ACapMax != null)
                    this.Exp_Cao8ACapMax.InitItem();
                if (this.Exp_Cao8ACapMin != null)
                    this.Exp_Cao8ACapMin.InitItem();
                if (this.Exp_Cao8BCapMax != null)
                    this.Exp_Cao8BCapMax.InitItem();
                if (this.Exp_Cao8BCapMin != null)
                    this.Exp_Cao8BCapMin.InitItem();
                if (this.Exp_Cao9ACapMax != null)
                    this.Exp_Cao9ACapMax.InitItem();
                if (this.Exp_Cao9ACapMin != null)
                    this.Exp_Cao9ACapMin.InitItem();
                if (this.Exp_Cao9BCapMax != null)
                    this.Exp_Cao9BCapMax.InitItem();
                if (this.Exp_Cao9BCapMin != null)
                    this.Exp_Cao9BCapMin.InitItem();
                //南京中比的ab档的数量
                if (this.Exp_Cao1AQty != null)
                    this.Exp_Cao1AQty.InitItem();
                if (this.Exp_Cao1BQty != null)
                    this.Exp_Cao1BQty.InitItem();
                if (this.Exp_Cao2AQty != null)
                    this.Exp_Cao2AQty.InitItem();
                if (this.Exp_Cao2BQty != null)
                    this.Exp_Cao2BQty.InitItem();
                if (this.Exp_Cao3AQty != null)
                    this.Exp_Cao3AQty.InitItem();
                if (this.Exp_Cao3BQty != null)
                    this.Exp_Cao3BQty.InitItem();
                if (this.Exp_Cao4AQty != null)
                    this.Exp_Cao4AQty.InitItem();
                if (this.Exp_Cao4BQty != null)
                    this.Exp_Cao4BQty.InitItem();
                if (this.Exp_Cao5AQty != null)
                    this.Exp_Cao5AQty.InitItem();
                if (this.Exp_Cao5BQty != null)
                    this.Exp_Cao5BQty.InitItem();
                if (this.Exp_Cao6AQty != null)
                    this.Exp_Cao6AQty.InitItem();
                if (this.Exp_Cao6BQty != null)
                    this.Exp_Cao6BQty.InitItem();
                if (this.Exp_Cao7AQty != null)
                    this.Exp_Cao7AQty.InitItem();
                if (this.Exp_Cao7BQty != null)
                    this.Exp_Cao7BQty.InitItem();
                if (this.Exp_Cao8AQty != null)
                    this.Exp_Cao8AQty.InitItem();
                if (this.Exp_Cao8BQty != null)
                    this.Exp_Cao8BQty.InitItem();
                if (this.Exp_Cao9AQty != null)
                    this.Exp_Cao9AQty.InitItem();
                if (this.Exp_Cao9BQty != null)
                    this.Exp_Cao9BQty.InitItem();
                //南京中比的压差
                
                if (this.Exp_YcSet != null)
                    this.Exp_YcSet.InitItem();

            }
            //添加组
            if (_ServerGroups == null)
            {
                _ServerGroups = this._Server.OPCGroups;
                _ServerGroups.DefaultGroupIsActive = true; //设置组集合默认为激活状态
                //下面这个几个暂时不设定，看看是否有异常，因为DefaultGroupUpdateRate这个值很关键，估计是与写入和读取的频率相关了，应该设置到某个单一的节点为好。
                _ServerGroups.DefaultGroupDeadband = 0;    //设置死区
                _ServerGroups.DefaultGroupUpdateRate = 100;//设置更新频率
                try
                {
                    //电池组2
                    this._MyGroup_Gongyi = _ServerGroups.Add("GrooveGongYi");
                    this._MyGroup_Gongyi.UpdateRate = 100;
                    this._MyGroup_Gongyi.IsActive = true;
                }
                catch (Exception ex)
                {
                    sErr = string.Format("GrooveGongYiOPC:创建各组失败：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
            }
            if (!this.InitMyItems(out sErr))
            {
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool InitMyItems(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (this.At_SysRun == null)
                At_SysRun = new MyItemValue(OPCItemTitle + "At_SysRun");
            if (this.At_SysNew == null)
                At_SysNew = new MyItemValue(OPCItemTitle + "AT_SysNew");
            if (this.At_SysCompeleted == null)
                At_SysCompeleted = new MyItemValue(OPCItemTitle + "AT_SysCompeleted");
            if (this.Exp_SwMode == null)
                Exp_SwMode = new MyItemValue(OPCItemTitle + "Exp_SwMode");
            if (this.GY_IsNet == null)
                GY_IsNet = new MyItemValue(OPCItemTitle + "GY_IsNet");
            if (this.GY_IsScanner == null)
                GY_IsScanner = new MyItemValue(OPCItemTitle + "GY_IsScanner");
            if (this.GY_MBatchChecker == null)
                GY_MBatchChecker = new MyItemValue(OPCItemTitle + "GY_MBatchChecker");
            if (this.GY_IsSameGy == null)
                GY_IsSameGy = new MyItemValue(OPCItemTitle + "GY_IsSameGy");
            if (this.GY_DxSize == null)
                GY_DxSize = new MyItemValue(OPCItemTitle + "GY_DxSize");
            if (this.St_Cao1Vmin == null)
                St_Cao1Vmin = new MyItemValue(OPCItemTitle + "St_Cao1Vmin");
            if (this.St_Cao1Vmax == null)
                St_Cao1Vmax = new MyItemValue(OPCItemTitle + "St_Cao1Vmax");
            if (this.St_Cao1Dzmin == null)
                St_Cao1Dzmin = new MyItemValue(OPCItemTitle + "St_Cao1Dzmin");
            if (this.St_Cao1Dzmax == null)
                St_Cao1Dzmax = new MyItemValue(OPCItemTitle + "St_Cao1Dzmax");
            if (this.St_Cao1Used == null)
                St_Cao1Used = new MyItemValue(OPCItemTitle + "St_Cao1Used");
            if (this.St_Cao1DxCnt == null)
                St_Cao1DxCnt = new MyItemValue(OPCItemTitle + "St_Cao1DxCnt");
            if (this.St_Cao2Vmin == null)
                St_Cao2Vmin = new MyItemValue(OPCItemTitle + "St_Cao2Vmin");
            if (this.St_Cao2Vmax == null)
                St_Cao2Vmax = new MyItemValue(OPCItemTitle + "St_Cao2Vmax");
            if (this.St_Cao2Dzmin == null)
                St_Cao2Dzmin = new MyItemValue(OPCItemTitle + "St_Cao2Dzmin");
            if (this.St_Cao2Dzmax == null)
                St_Cao2Dzmax = new MyItemValue(OPCItemTitle + "St_Cao2Dzmax");
            if (this.St_Cao2Used == null)
                St_Cao2Used = new MyItemValue(OPCItemTitle + "St_Cao2Used");
            if (this.St_Cao2DxCnt == null)
                St_Cao2DxCnt = new MyItemValue(OPCItemTitle + "St_Cao2DxCnt");
            if (this.St_Cao3Vmin == null)
                St_Cao3Vmin = new MyItemValue(OPCItemTitle + "St_Cao3Vmin");
            if (this.St_Cao3Vmax == null)
                St_Cao3Vmax = new MyItemValue(OPCItemTitle + "St_Cao3Vmax");
            if (this.St_Cao3Dzmin == null)
                St_Cao3Dzmin = new MyItemValue(OPCItemTitle + "St_Cao3Dzmin");
            if (this.St_Cao3Dzmax == null)
                St_Cao3Dzmax = new MyItemValue(OPCItemTitle + "St_Cao3Dzmax");
            if (this.St_Cao3Used == null)
                St_Cao3Used = new MyItemValue(OPCItemTitle + "St_Cao3Used");
            if (this.St_Cao3DxCnt == null)
                St_Cao3DxCnt = new MyItemValue(OPCItemTitle + "St_Cao3DxCnt");
            if (this.St_Cao4Vmin == null)
                St_Cao4Vmin = new MyItemValue(OPCItemTitle + "St_Cao4Vmin");
            if (this.St_Cao4Vmax == null)
                St_Cao4Vmax = new MyItemValue(OPCItemTitle + "St_Cao4Vmax");
            if (this.St_Cao4Dzmin == null)
                St_Cao4Dzmin = new MyItemValue(OPCItemTitle + "St_Cao4Dzmin");
            if (this.St_Cao4Dzmax == null)
                St_Cao4Dzmax = new MyItemValue(OPCItemTitle + "St_Cao4Dzmax");
            if (this.St_Cao4Used == null)
                St_Cao4Used = new MyItemValue(OPCItemTitle + "St_Cao4Used");
            if (this.St_Cao4DxCnt == null)
                St_Cao4DxCnt = new MyItemValue(OPCItemTitle + "St_Cao4DxCnt");
            if (this.St_Cao5Vmin == null)
                St_Cao5Vmin = new MyItemValue(OPCItemTitle + "St_Cao5Vmin");
            if (this.St_Cao5Vmax == null)
                St_Cao5Vmax = new MyItemValue(OPCItemTitle + "St_Cao5Vmax");
            if (this.St_Cao5Dzmin == null)
                St_Cao5Dzmin = new MyItemValue(OPCItemTitle + "St_Cao5Dzmin");
            if (this.St_Cao5Dzmax == null)
                St_Cao5Dzmax = new MyItemValue(OPCItemTitle + "St_Cao5Dzmax");
            if (this.St_Cao5Used == null)
                St_Cao5Used = new MyItemValue(OPCItemTitle + "St_Cao5Used");
            if (this.St_Cao5DxCnt == null)
                St_Cao5DxCnt = new MyItemValue(OPCItemTitle + "St_Cao5DxCnt");
            if (this.St_Cao6Vmin == null)
                St_Cao6Vmin = new MyItemValue(OPCItemTitle + "St_Cao6Vmin");
            if (this.St_Cao6Vmax == null)
                St_Cao6Vmax = new MyItemValue(OPCItemTitle + "St_Cao6Vmax");
            if (this.St_Cao6Dzmin == null)
                St_Cao6Dzmin = new MyItemValue(OPCItemTitle + "St_Cao6Dzmin");
            if (this.St_Cao6Dzmax == null)
                St_Cao6Dzmax = new MyItemValue(OPCItemTitle + "St_Cao6Dzmax");
            if (this.St_Cao6Used == null)
                St_Cao6Used = new MyItemValue(OPCItemTitle + "St_Cao6Used");
            if (this.St_Cao6DxCnt == null)
                St_Cao6DxCnt = new MyItemValue(OPCItemTitle + "St_Cao6DxCnt");
            if (this.St_Cao7Vmin == null)
                St_Cao7Vmin = new MyItemValue(OPCItemTitle + "St_Cao7Vmin");
            if (this.St_Cao7Vmax == null)
                St_Cao7Vmax = new MyItemValue(OPCItemTitle + "St_Cao7Vmax");
            if (this.St_Cao7Dzmin == null)
                St_Cao7Dzmin = new MyItemValue(OPCItemTitle + "St_Cao7Dzmin");
            if (this.St_Cao7Dzmax == null)
                St_Cao7Dzmax = new MyItemValue(OPCItemTitle + "St_Cao7Dzmax");
            if (this.St_Cao7Used == null)
                St_Cao7Used = new MyItemValue(OPCItemTitle + "St_Cao7Used");
            if (this.St_Cao7DxCnt == null)
                St_Cao7DxCnt = new MyItemValue(OPCItemTitle + "St_Cao7DxCnt");
            if (this.St_Cao8Vmin == null)
                St_Cao8Vmin = new MyItemValue(OPCItemTitle + "St_Cao8Vmin");
            if (this.St_Cao8Vmax == null)
                St_Cao8Vmax = new MyItemValue(OPCItemTitle + "St_Cao8Vmax");
            if (this.St_Cao8Dzmin == null)
                St_Cao8Dzmin = new MyItemValue(OPCItemTitle + "St_Cao8Dzmin");
            if (this.St_Cao8Dzmax == null)
                St_Cao8Dzmax = new MyItemValue(OPCItemTitle + "St_Cao8Dzmax");
            if (this.St_Cao8Used == null)
                St_Cao8Used = new MyItemValue(OPCItemTitle + "St_Cao8Used");
            if (this.St_Cao8DxCnt == null)
                St_Cao8DxCnt = new MyItemValue(OPCItemTitle + "St_Cao8DxCnt");
            if (this.St_Cao9Vmin == null)
                St_Cao9Vmin = new MyItemValue(OPCItemTitle + "St_Cao9Vmin");
            if (this.St_Cao9Vmax == null)
                St_Cao9Vmax = new MyItemValue(OPCItemTitle + "St_Cao9Vmax");
            if (this.St_Cao9Dzmin == null)
                St_Cao9Dzmin = new MyItemValue(OPCItemTitle + "St_Cao9Dzmin");
            if (this.St_Cao9Dzmax == null)
                St_Cao9Dzmax = new MyItemValue(OPCItemTitle + "St_Cao9Dzmax");
            if (this.St_Cao9Used == null)
                St_Cao9Used = new MyItemValue(OPCItemTitle + "St_Cao9Used");
            if (this.St_Cao9DxCnt == null)
                St_Cao9DxCnt = new MyItemValue(OPCItemTitle + "St_Cao9DxCnt");
            if (this.St_Cao10Vmin == null)
                St_Cao10Vmin = new MyItemValue(OPCItemTitle + "St_Cao10Vmin");
            if (this.St_Cao10Vmax == null)
                St_Cao10Vmax = new MyItemValue(OPCItemTitle + "St_Cao10Vmax");
            if (this.St_Cao10Dzmin == null)
                St_Cao10Dzmin = new MyItemValue(OPCItemTitle + "St_Cao10Dzmin");
            if (this.St_Cao10Dzmax == null)
                St_Cao10Dzmax = new MyItemValue(OPCItemTitle + "St_Cao10Dzmax");
            if (this.St_Cao10Used == null)
                St_Cao10Used = new MyItemValue(OPCItemTitle + "St_Cao10Used");
            if (this.St_Cao10DxCnt == null)
                St_Cao10DxCnt = new MyItemValue(OPCItemTitle + "St_Cao10DxCnt");
            if (this.St_Cao11Vmin == null)
                St_Cao11Vmin = new MyItemValue(OPCItemTitle + "St_Cao11Vmin");
            if (this.St_Cao11Vmax == null)
                St_Cao11Vmax = new MyItemValue(OPCItemTitle + "St_Cao11Vmax");
            if (this.St_Cao11Dzmin == null)
                St_Cao11Dzmin = new MyItemValue(OPCItemTitle + "St_Cao11Dzmin");
            if (this.St_Cao11Dzmax == null)
                St_Cao11Dzmax = new MyItemValue(OPCItemTitle + "St_Cao11Dzmax");
            if (this.St_Cao11Used == null)
                St_Cao11Used = new MyItemValue(OPCItemTitle + "St_Cao11Used");
            if (this.St_Cao11DxCnt == null)
                St_Cao11DxCnt = new MyItemValue(OPCItemTitle + "St_Cao11DxCnt");
            if (this.St_Cao12Vmin == null)
                St_Cao12Vmin = new MyItemValue(OPCItemTitle + "St_Cao12Vmin");
            if (this.St_Cao12Vmax == null)
                St_Cao12Vmax = new MyItemValue(OPCItemTitle + "St_Cao12Vmax");
            if (this.St_Cao12Dzmin == null)
                St_Cao12Dzmin = new MyItemValue(OPCItemTitle + "St_Cao12Dzmin");
            if (this.St_Cao12Dzmax == null)
                St_Cao12Dzmax = new MyItemValue(OPCItemTitle + "St_Cao12Dzmax");
            if (this.St_Cao12Used == null)
                St_Cao12Used = new MyItemValue(OPCItemTitle + "St_Cao12Used");
            if (this.St_Cao12DxCnt == null)
                St_Cao12DxCnt = new MyItemValue(OPCItemTitle + "St_Cao12DxCnt");
            if (this.St_Cao13Vmin == null)
                St_Cao13Vmin = new MyItemValue(OPCItemTitle + "St_Cao13Vmin");
            if (this.St_Cao13Vmax == null)
                St_Cao13Vmax = new MyItemValue(OPCItemTitle + "St_Cao13Vmax");
            if (this.St_Cao13Dzmin == null)
                St_Cao13Dzmin = new MyItemValue(OPCItemTitle + "St_Cao13Dzmin");
            if (this.St_Cao13Dzmax == null)
                St_Cao13Dzmax = new MyItemValue(OPCItemTitle + "St_Cao13Dzmax");
            if (this.St_Cao13Used == null)
                St_Cao13Used = new MyItemValue(OPCItemTitle + "St_Cao13Used");
            if (this.St_Cao13DxCnt == null)
                St_Cao13DxCnt = new MyItemValue(OPCItemTitle + "St_Cao13DxCnt");
            if (this.St_Cao14Vmin == null)
                St_Cao14Vmin = new MyItemValue(OPCItemTitle + "St_Cao14Vmin");
            if (this.St_Cao14Vmax == null)
                St_Cao14Vmax = new MyItemValue(OPCItemTitle + "St_Cao14Vmax");
            if (this.St_Cao14Dzmin == null)
                St_Cao14Dzmin = new MyItemValue(OPCItemTitle + "St_Cao14Dzmin");
            if (this.St_Cao14Dzmax == null)
                St_Cao14Dzmax = new MyItemValue(OPCItemTitle + "St_Cao14Dzmax");
            if (this.St_Cao14Used == null)
                St_Cao14Used = new MyItemValue(OPCItemTitle + "St_Cao14Used");
            if (this.St_Cao14DxCnt == null)
                St_Cao14DxCnt = new MyItemValue(OPCItemTitle + "St_Cao14DxCnt");
            if (this.St_Cao15Vmin == null)
                St_Cao15Vmin = new MyItemValue(OPCItemTitle + "St_Cao15Vmin");
            if (this.St_Cao15Vmax == null)
                St_Cao15Vmax = new MyItemValue(OPCItemTitle + "St_Cao15Vmax");
            if (this.St_Cao15Dzmin == null)
                St_Cao15Dzmin = new MyItemValue(OPCItemTitle + "St_Cao15Dzmin");
            if (this.St_Cao15Dzmax == null)
                St_Cao15Dzmax = new MyItemValue(OPCItemTitle + "St_Cao15Dzmax");
            if (this.St_Cao15Used == null)
                St_Cao15Used = new MyItemValue(OPCItemTitle + "St_Cao15Used");
            if (this.St_Cao15DxCnt == null)
                St_Cao15DxCnt = new MyItemValue(OPCItemTitle + "St_Cao15DxCnt");
            if (this.St_Cao16Vmin == null)
                St_Cao16Vmin = new MyItemValue(OPCItemTitle + "St_Cao16Vmin");
            if (this.St_Cao16Vmax == null)
                St_Cao16Vmax = new MyItemValue(OPCItemTitle + "St_Cao16Vmax");
            if (this.St_Cao16Dzmin == null)
                St_Cao16Dzmin = new MyItemValue(OPCItemTitle + "St_Cao16Dzmin");
            if (this.St_Cao16Dzmax == null)
                St_Cao16Dzmax = new MyItemValue(OPCItemTitle + "St_Cao16Dzmax");
            if (this.St_Cao16Used == null)
                St_Cao16Used = new MyItemValue(OPCItemTitle + "St_Cao16Used");
            if (this.St_Cao16DxCnt == null)
                St_Cao16DxCnt = new MyItemValue(OPCItemTitle + "St_Cao16DxCnt");
            if (this.St_Cao17Vmin == null)
                St_Cao17Vmin = new MyItemValue(OPCItemTitle + "St_Cao17Vmin");
            if (this.St_Cao17Vmax == null)
                St_Cao17Vmax = new MyItemValue(OPCItemTitle + "St_Cao17Vmax");
            if (this.St_Cao17Dzmin == null)
                St_Cao17Dzmin = new MyItemValue(OPCItemTitle + "St_Cao17Dzmin");
            if (this.St_Cao17Dzmax == null)
                St_Cao17Dzmax = new MyItemValue(OPCItemTitle + "St_Cao17Dzmax");
            if (this.St_Cao17Used == null)
                St_Cao17Used = new MyItemValue(OPCItemTitle + "St_Cao17Used");
            if (this.St_Cao17DxCnt == null)
                St_Cao17DxCnt = new MyItemValue(OPCItemTitle + "St_Cao17DxCnt");
            if (this.St_Cao18Vmin == null)
                St_Cao18Vmin = new MyItemValue(OPCItemTitle + "St_Cao18Vmin");
            if (this.St_Cao18Vmax == null)
                St_Cao18Vmax = new MyItemValue(OPCItemTitle + "St_Cao18Vmax");
            if (this.St_Cao18Dzmin == null)
                St_Cao18Dzmin = new MyItemValue(OPCItemTitle + "St_Cao18Dzmin");
            if (this.St_Cao18Dzmax == null)
                St_Cao18Dzmax = new MyItemValue(OPCItemTitle + "St_Cao18Dzmax");
            if (this.St_Cao18Used == null)
                St_Cao18Used = new MyItemValue(OPCItemTitle + "St_Cao18Used");
            if (this.St_Cao18DxCnt == null)
                St_Cao18DxCnt = new MyItemValue(OPCItemTitle + "St_Cao18DxCnt");

            //南京中比AB档上下限
            if (this.Exp_Cao1ACapMax == null)
                Exp_Cao1ACapMax = new MyItemValue(OPCItemTitle + "Exp_Cao1ACapMax");
            if (this.Exp_Cao1ACapMin == null)
                Exp_Cao1ACapMin = new MyItemValue(OPCItemTitle + "Exp_Cao1ACapMin");
            if (this.Exp_Cao1BCapMax == null)
                Exp_Cao1BCapMax = new MyItemValue(OPCItemTitle + "Exp_Cao1BCapMax");
            if (this.Exp_Cao1BCapMin == null)
                Exp_Cao1BCapMin = new MyItemValue(OPCItemTitle + "Exp_Cao1BCapMin");
            if (this.Exp_Cao2ACapMax == null)
                Exp_Cao2ACapMax = new MyItemValue(OPCItemTitle + "Exp_Cao2ACapMax");
            if (this.Exp_Cao2ACapMin == null)
                Exp_Cao2ACapMin = new MyItemValue(OPCItemTitle + "Exp_Cao2ACapMin");
            if (this.Exp_Cao2BCapMax == null)
                Exp_Cao2BCapMax = new MyItemValue(OPCItemTitle + "Exp_Cao2BCapMax");
            if (this.Exp_Cao2BCapMin == null)
                Exp_Cao2BCapMin = new MyItemValue(OPCItemTitle + "Exp_Cao2BCapMin");
            if (this.Exp_Cao3ACapMax == null)
                Exp_Cao3ACapMax = new MyItemValue(OPCItemTitle + "Exp_Cao3ACapMax");
            if (this.Exp_Cao3ACapMin == null)
                Exp_Cao3ACapMin = new MyItemValue(OPCItemTitle + "Exp_Cao3ACapMin");
            if (this.Exp_Cao3BCapMax == null)
                Exp_Cao3BCapMax = new MyItemValue(OPCItemTitle + "Exp_Cao3BCapMax");
            if (this.Exp_Cao3BCapMin == null)
                Exp_Cao3BCapMin = new MyItemValue(OPCItemTitle + "Exp_Cao3BCapMin");
            if (this.Exp_Cao4ACapMax == null)
                Exp_Cao4ACapMax = new MyItemValue(OPCItemTitle + "Exp_Cao4ACapMax");
            if (this.Exp_Cao4ACapMin == null)
                Exp_Cao4ACapMin = new MyItemValue(OPCItemTitle + "Exp_Cao4ACapMin");
            if (this.Exp_Cao4BCapMax == null)
                Exp_Cao4BCapMax = new MyItemValue(OPCItemTitle + "Exp_Cao4BCapMax");
            if (this.Exp_Cao4BCapMin == null)
                Exp_Cao4BCapMin = new MyItemValue(OPCItemTitle + "Exp_Cao4BCapMin");
            if (this.Exp_Cao5ACapMax == null)
                Exp_Cao5ACapMax = new MyItemValue(OPCItemTitle + "Exp_Cao5ACapMax");
            if (this.Exp_Cao5ACapMin == null)
                Exp_Cao5ACapMin = new MyItemValue(OPCItemTitle + "Exp_Cao5ACapMin");
            if (this.Exp_Cao5BCapMax == null)
                Exp_Cao5BCapMax = new MyItemValue(OPCItemTitle + "Exp_Cao5BCapMax");
            if (this.Exp_Cao5BCapMin == null)
                Exp_Cao5BCapMin = new MyItemValue(OPCItemTitle + "Exp_Cao5BCapMin");
            if (this.Exp_Cao6ACapMax == null)
                Exp_Cao6ACapMax = new MyItemValue(OPCItemTitle + "Exp_Cao6ACapMax");
            if (this.Exp_Cao6ACapMin == null)
                Exp_Cao6ACapMin = new MyItemValue(OPCItemTitle + "Exp_Cao6ACapMin");
            if (this.Exp_Cao6BCapMax == null)
                Exp_Cao6BCapMax = new MyItemValue(OPCItemTitle + "Exp_Cao6BCapMax");
            if (this.Exp_Cao6BCapMin == null)
                Exp_Cao6BCapMin = new MyItemValue(OPCItemTitle + "Exp_Cao6BCapMin");
            if (this.Exp_Cao7ACapMax == null)
                Exp_Cao7ACapMax = new MyItemValue(OPCItemTitle + "Exp_Cao7ACapMax");
            if (this.Exp_Cao7ACapMin == null)
                Exp_Cao7ACapMin = new MyItemValue(OPCItemTitle + "Exp_Cao7ACapMin");
            if (this.Exp_Cao7BCapMax == null)
                Exp_Cao7BCapMax = new MyItemValue(OPCItemTitle + "Exp_Cao7BCapMax");
            if (this.Exp_Cao7BCapMin == null)
                Exp_Cao7BCapMin = new MyItemValue(OPCItemTitle + "Exp_Cao7BCapMin");
            if (this.Exp_Cao8ACapMax == null)
                Exp_Cao8ACapMax = new MyItemValue(OPCItemTitle + "Exp_Cao8ACapMax");
            if (this.Exp_Cao8ACapMin == null)
                Exp_Cao8ACapMin = new MyItemValue(OPCItemTitle + "Exp_Cao8ACapMin");
            if (this.Exp_Cao8BCapMax == null)
                Exp_Cao8BCapMax = new MyItemValue(OPCItemTitle + "Exp_Cao8BCapMax");
            if (this.Exp_Cao8BCapMin == null)
                Exp_Cao8BCapMin = new MyItemValue(OPCItemTitle + "Exp_Cao8BCapMin");
            if (this.Exp_Cao9ACapMax == null)
                Exp_Cao9ACapMax = new MyItemValue(OPCItemTitle + "Exp_Cao9ACapMax");
            if (this.Exp_Cao9ACapMin == null)
                Exp_Cao9ACapMin = new MyItemValue(OPCItemTitle + "Exp_Cao9ACapMin");
            if (this.Exp_Cao9BCapMax == null)
                Exp_Cao9BCapMax = new MyItemValue(OPCItemTitle + "Exp_Cao9BCapMax");
            if (this.Exp_Cao9BCapMin == null)
                Exp_Cao9BCapMin = new MyItemValue(OPCItemTitle + "Exp_Cao9BCapMin");
            //南京中比AB档数量
            if (this.Exp_Cao1AQty == null)
                Exp_Cao1AQty = new MyItemValue(OPCItemTitle + "Exp_Cao1AQty");
            if (this.Exp_Cao1BQty == null)
                Exp_Cao1BQty = new MyItemValue(OPCItemTitle + "Exp_Cao1BQty");
            if (this.Exp_Cao2AQty == null)
                Exp_Cao2AQty = new MyItemValue(OPCItemTitle + "Exp_Cao2AQty");
            if (this.Exp_Cao2BQty == null)
                Exp_Cao2BQty = new MyItemValue(OPCItemTitle + "Exp_Cao2BQty");
            if (this.Exp_Cao3AQty == null)
                Exp_Cao3AQty = new MyItemValue(OPCItemTitle + "Exp_Cao3AQty");
            if (this.Exp_Cao3BQty == null)
                Exp_Cao3BQty = new MyItemValue(OPCItemTitle + "Exp_Cao3BQty");
            if (this.Exp_Cao4AQty == null)
                Exp_Cao4AQty = new MyItemValue(OPCItemTitle + "Exp_Cao4AQty");
            if (this.Exp_Cao4BQty == null)
                Exp_Cao4BQty = new MyItemValue(OPCItemTitle + "Exp_Cao4BQty");
            if (this.Exp_Cao5AQty == null)
                Exp_Cao5AQty = new MyItemValue(OPCItemTitle + "Exp_Cao5AQty");
            if (this.Exp_Cao5BQty == null)
                Exp_Cao5BQty = new MyItemValue(OPCItemTitle + "Exp_Cao5BQty");
            if (this.Exp_Cao6AQty == null)
                Exp_Cao6AQty = new MyItemValue(OPCItemTitle + "Exp_Cao6AQty");
            if (this.Exp_Cao6BQty == null)
                Exp_Cao6BQty = new MyItemValue(OPCItemTitle + "Exp_Cao6BQty");
            if (this.Exp_Cao7AQty == null)
                Exp_Cao7AQty = new MyItemValue(OPCItemTitle + "Exp_Cao7AQty");
            if (this.Exp_Cao7BQty == null)
                Exp_Cao7BQty = new MyItemValue(OPCItemTitle + "Exp_Cao7BQty");
            if (this.Exp_Cao8AQty == null)
                Exp_Cao8AQty = new MyItemValue(OPCItemTitle + "Exp_Cao8AQty");
            if (this.Exp_Cao8BQty == null)
                Exp_Cao8BQty = new MyItemValue(OPCItemTitle + "Exp_Cao8BQty");
            if (this.Exp_Cao9AQty == null)
                Exp_Cao9AQty = new MyItemValue(OPCItemTitle + "Exp_Cao9AQty");
            if (this.Exp_Cao9BQty == null)
                Exp_Cao9BQty = new MyItemValue(OPCItemTitle + "Exp_Cao9BQty");

            //南京中比压差
           
            if (this.Exp_YcSet == null)
                Exp_YcSet = new MyItemValue(OPCItemTitle + "Exp_YcSet");

            if (this._MyGroup_Gongyi == null)
            {
                sErr = "初始化工艺写入OPCitem时失败，因为group为空。";
                return false;
            }

            if (_MyGroup_Gongyi.OPCItems == null)
            {
                sErr = "初始化工艺写入OPCitem时失败，因为group.OPCItems为空。";
                return false;
            }
            //处理系统标识
            if (!InitMyItems_AddItem(this.At_SysRun, this._MyGroup_Gongyi, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.At_SysNew, this._MyGroup_Gongyi, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.At_SysCompeleted, this._MyGroup_Gongyi, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Exp_SwMode, this._MyGroup_Gongyi, true, out sErr))
            {
                return false;
            }
            //处理工艺参数组
            if (!InitMyItems_AddItem(this.GY_IsNet, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.GY_IsScanner, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.GY_MBatchChecker, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.GY_IsSameGy, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.GY_DxSize, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao1Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao1Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao1Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao1Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao1Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao1DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao2Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao2Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao2Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao2Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao2Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao2DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao3Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao3Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao3Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao3Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao3Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao3DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao4Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao4Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao4Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao4Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao4Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao4DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao5Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao5Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao5Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao5Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao5Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao5DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao6Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao6Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao6Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao6Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao6Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao6DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao7Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao7Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao7Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao7Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao7Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao7DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao8Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao8Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao8Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao8Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao8Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao8DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao9Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao9Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao9Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao9Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao9Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao9DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao10Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao10Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao10Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao10Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao10Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao10DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao11Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao11Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao11Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao11Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao11Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao11DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao12Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao12Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao12Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao12Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao12Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao12DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao13Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao13Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao13Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao13Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao13Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao13DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao14Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao14Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao14Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao14Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao14Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao14DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao15Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao15Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao15Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao15Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao15Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao15DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao16Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao16Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao16Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao16Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao16Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao16DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao17Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao17Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao17Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao17Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao17Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao17DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao18Vmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao18Vmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao18Dzmin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao18Dzmax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao18Used, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.St_Cao18DxCnt, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            #region 南京中比添加
            if (!InitMyItems_AddItem(this.Exp_Cao1ACapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao1ACapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao1BCapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao1BCapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao2ACapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao2ACapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao2BCapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao2BCapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao3ACapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao3ACapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao3BCapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao3BCapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao4ACapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao4ACapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao4BCapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao4BCapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao5ACapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao5ACapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao5BCapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao5BCapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao6ACapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao6ACapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao6BCapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao6BCapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao7ACapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao7ACapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao7BCapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao7BCapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao8ACapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao8ACapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao8BCapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao8BCapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao9ACapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao9ACapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao9BCapMax, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao9BCapMin, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }


            if (!InitMyItems_AddItem(this.Exp_Cao1AQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao1BQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao2AQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao2BQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao3AQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao3BQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao4AQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao4BQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao5AQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao5BQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao6AQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao6BQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao7AQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao7BQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao8AQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao8BQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao9AQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Exp_Cao9BQty, this._MyGroup_Gongyi, false, out sErr))
            {
                return false;
            }
            //压差
            
            if (!InitMyItems_AddItem(this.Exp_YcSet, this._MyGroup_Gongyi, true, out sErr))
            {
                return false;
            }
            #endregion
            return true;
        }
        private bool InitMyItems_AddItem(MyItemValue myItem, OPCGroup targetGroup, bool saveItem, out string sErr)
        {
            if (myItem.ServerHandle <= 0)
            {
                if (this.IsDebug)
                {
                    sErr = string.Empty;
                    return true;
                }
                //此时添加Item
                _ClientHandle++;
                OPCItem item = null;
                string strTagName = myItem.TagName;
                try
                {
                    item = targetGroup.OPCItems.AddItem(strTagName, _ClientHandle);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("添加Item：{0}，出错:{1}({2})", myItem.TagName, ex.Message, ex.Source);
                    return false;
                }
                if (item == null)
                {
                    sErr = string.Format("添加Item：{0}失败，返回为空。", myItem.TagName);
                    return false;
                }
                if (item.ServerHandle <= 0)
                {
                    sErr = string.Format("添加Item：{0}失败，返回值ServerHandle为{1}。", myItem.TagName, myItem.ServerHandle);
                    return false;
                }
                myItem.ServerHandle = item.ServerHandle;
                myItem.ClientHandle = this._ClientHandle;
                if (saveItem)
                    myItem._OPCItem = item;
            }
            sErr = string.Empty;
            return true;
        }
        public bool CloseOPC(out string sErr)
        {
            sErr = "";
            if (this._Server == null) return true;
            try
            {
                this._Server.Disconnect();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
                return false;
            }
            return true;
        }
        #endregion
        #region 特殊功能函数
        /// <summary>
        /// 标识系统是否运行（写入PLC）
        /// </summary>
        /// <param name="blRun"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        public bool SetAt_SysRun(bool blRun, out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (this.At_SysRun == null)
            {
                sErr = string.Format("At_SysRun设置为{0}时失败：opc为空！", blRun ? "true" : "false");
                return false;
            }
            else if (this.At_SysRun._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("At_SysRun设置为{0}时失败：opcItem为空，且初始化出错：{1}", blRun ? "true" : "false", sErr);
                    return false;
                }
            }
            if (this.At_SysRun.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("At_SysRun设置为{0}时失败：opcItem的serverhandle，且初始化出错：{1}", blRun ? "true" : "false", sErr);
                    return false;
                }
            }
            if (!this.At_SysRun.WriteData(blRun, out sErr))
            {
                sErr = string.Format("At_SysRun设置为{0}时出错：{1}", blRun ? "true" : "false", sErr);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 通知PLC上位机要新建了
        /// </summary>
        /// <param name="sErr"></param>
        /// <returns></returns>
        public bool SetAt_SysNew(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (this.At_SysNew == null)
            {
                sErr = "At_SysNew设置失败：opc为空！";
                return false;
            }
            else if (this.At_SysNew._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("At_SysNew设置失败：opcItem为空，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (this.At_SysNew.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("At_SysNew设置失败：opcItem的serverhandle，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (!this.At_SysNew.WriteData((short)1, out sErr))
            {
                sErr = string.Format("At_SysNew设置时出错：{0}", sErr);
                return false;
            }
            return true;
        }
        public bool ReadAt_SysNew(out short iValue, out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                iValue = Debug_sysNew;
                return true;
            }
            if (this.At_SysNew == null)
            {
                sErr = "At_SysNew读取失败：opc为空！";
                iValue = 0;
                return false;
            }
            else if (this.At_SysNew._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("At_SysNew读取失败：opcItem为空，且初始化出错：{0}", sErr);
                    iValue = 0;
                    return false;
                }
            }
            if (this.At_SysNew.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("At_SysNew读取失败：opcItem的serverhandle，且初始化出错：{0}", sErr);
                    iValue = 0;
                    return false;
                }
            }
            object objValue;
            if (!this.At_SysNew.ReadData(out objValue, out sErr))
            {
                sErr = string.Format("At_SysNew读取时出错：{0}", sErr);
                iValue = 0;
                return false;
            }
            if (objValue == null)
            {
                sErr = "At_SysNew读取失败，返回为NULL";
                iValue = 0;
                return false;
            }
            if (objValue.ToString().Length == 0)
            {
                sErr = "At_SysNew读取失败，返回为空字符";
                iValue = 0;
                return false;
            }
            if (!short.TryParse(objValue.ToString(), out iValue))
            {
                sErr = string.Format("At_SysNew读取失败，返回值\"{0}\"不是预期的整型。", objValue.ToString());
                iValue = 0;
            }
            return true;
        }

        public bool SetAt_SysCompeleted(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (this.At_SysCompeleted == null)
            {
                sErr = "At_SysCompeleted设置失败：opc为空！";
                return false;
            }
            else if (this.At_SysCompeleted._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("At_SysCompeleted设置失败：opcItem为空，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (this.At_SysCompeleted.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("At_SysCompeleted设置失败：opcItem的serverhandle，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (!this.At_SysCompeleted.WriteData((short)1, out sErr))
            {
                sErr = string.Format("At_SysCompeleted设置时出错：{0}", sErr);
                return false;
            }
            return true;
        }
        public bool ReadAt_SysCompeleted(out short iValue, out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                iValue = Debug_SysCompeleted;
                return true;
            }
            if (this.At_SysCompeleted == null)
            {
                sErr = "At_SysCompeleted读取失败：opc为空！";
                iValue = 0;
                return false;
            }
            else if (this.At_SysCompeleted._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("At_SysCompeleted读取失败：opcItem为空，且初始化出错：{0}", sErr);
                    iValue = 0;
                    return false;
                }
            }
            if (this.At_SysCompeleted.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("At_SysCompeleted读取失败：opcItem的serverhandle，且初始化出错：{0}", sErr);
                    iValue = 0;
                    return false;
                }
            }
            object objValue;
            if (!this.At_SysCompeleted.ReadData(out objValue, out sErr))
            {
                sErr = string.Format("At_SysCompeleted读取时出错：{0}", sErr);
                iValue = 0;
                return false;
            }
            if (objValue == null)
            {
                sErr = "At_SysCompeleted读取失败，返回为NULL";
                iValue = 0;
                return false;
            }
            if (objValue.ToString().Length == 0)
            {
                sErr = "At_SysCompeleted读取失败，返回为空字符";
                iValue = 0;
                return false;
            }
            if (!short.TryParse(objValue.ToString(), out iValue))
            {
                sErr = string.Format("At_SysCompeleted读取失败，返回值\"{0}\"不是预期的整型。", objValue.ToString());
                iValue = 0;
            }
            return true;
        }
        public bool WriteGongyi(bool GY_IsNet, bool GY_IsScanner, bool GY_MBatchChecker, short GY_IsSameGy, short GY_DxSize, GrooveGongyiEntity[] grooves, out string sErr, bool blReWrite = false)
        {
            //sErr = string.Format("数量serverID:{0}，数量值:{1}", this.St_Cao1DxCnt.ServerHandle, grooves[0].St_CaoDxCnt);
            //return false;
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            //foreach(GrooveGongyiEntity entity in grooves)
            //{
            //    if(entity.St_CaoUsed && entity.St_CaoDxCnt>0)
            //    {
            //        iCaoBtyCnt = entity.St_CaoDxCnt;
            //        break;
            //    }
            //}
            //写入数据
            Array serverHandles = new int[114] { 0, this.GY_IsNet.ServerHandle,
                this.GY_IsScanner.ServerHandle,
                this.GY_MBatchChecker.ServerHandle,
                this.GY_IsSameGy.ServerHandle,
                this.GY_DxSize.ServerHandle,
                this.St_Cao1Vmin.ServerHandle,
                this.St_Cao1Vmax.ServerHandle,
                this.St_Cao1Dzmin.ServerHandle,
                this.St_Cao1Dzmax.ServerHandle,
                this.St_Cao1Used.ServerHandle,
                this.St_Cao1DxCnt.ServerHandle,
                this.St_Cao2Vmin.ServerHandle,
                this.St_Cao2Vmax.ServerHandle,
                this.St_Cao2Dzmin.ServerHandle,
                this.St_Cao2Dzmax.ServerHandle,
                this.St_Cao2Used.ServerHandle,
                this.St_Cao2DxCnt.ServerHandle,
                this.St_Cao3Vmin.ServerHandle,
                this.St_Cao3Vmax.ServerHandle,
                this.St_Cao3Dzmin.ServerHandle,
                this.St_Cao3Dzmax.ServerHandle,
                this.St_Cao3Used.ServerHandle,
                this.St_Cao3DxCnt.ServerHandle,
                this.St_Cao4Vmin.ServerHandle,
                this.St_Cao4Vmax.ServerHandle,
                this.St_Cao4Dzmin.ServerHandle,
                this.St_Cao4Dzmax.ServerHandle,
                this.St_Cao4Used.ServerHandle,
                this.St_Cao4DxCnt.ServerHandle,
                this.St_Cao5Vmin.ServerHandle,
                this.St_Cao5Vmax.ServerHandle,
                this.St_Cao5Dzmin.ServerHandle,
                this.St_Cao5Dzmax.ServerHandle,
                this.St_Cao5Used.ServerHandle,
                this.St_Cao5DxCnt.ServerHandle,
                this.St_Cao6Vmin.ServerHandle,
                this.St_Cao6Vmax.ServerHandle,
                this.St_Cao6Dzmin.ServerHandle,
                this.St_Cao6Dzmax.ServerHandle,
                this.St_Cao6Used.ServerHandle,
                this.St_Cao6DxCnt.ServerHandle,
                this.St_Cao7Vmin.ServerHandle,
                this.St_Cao7Vmax.ServerHandle,
                this.St_Cao7Dzmin.ServerHandle,
                this.St_Cao7Dzmax.ServerHandle,
                this.St_Cao7Used.ServerHandle,
                this.St_Cao7DxCnt.ServerHandle,
                this.St_Cao8Vmin.ServerHandle,
                this.St_Cao8Vmax.ServerHandle,
                this.St_Cao8Dzmin.ServerHandle,
                this.St_Cao8Dzmax.ServerHandle,
                this.St_Cao8Used.ServerHandle,
                this.St_Cao8DxCnt.ServerHandle,
                this.St_Cao9Vmin.ServerHandle,
                this.St_Cao9Vmax.ServerHandle,
                this.St_Cao9Dzmin.ServerHandle,
                this.St_Cao9Dzmax.ServerHandle,
                this.St_Cao9Used.ServerHandle,
                this.St_Cao9DxCnt.ServerHandle,
                this.St_Cao10Vmin.ServerHandle,
                this.St_Cao10Vmax.ServerHandle,
                this.St_Cao10Dzmin.ServerHandle,
                this.St_Cao10Dzmax.ServerHandle,
                this.St_Cao10Used.ServerHandle,
                this.St_Cao10DxCnt.ServerHandle,
                this.St_Cao11Vmin.ServerHandle,
                this.St_Cao11Vmax.ServerHandle,
                this.St_Cao11Dzmin.ServerHandle,
                this.St_Cao11Dzmax.ServerHandle,
                this.St_Cao11Used.ServerHandle,
                this.St_Cao11DxCnt.ServerHandle,
                this.St_Cao12Vmin.ServerHandle,
                this.St_Cao12Vmax.ServerHandle,
                this.St_Cao12Dzmin.ServerHandle,
                this.St_Cao12Dzmax.ServerHandle,
                this.St_Cao12Used.ServerHandle,
                this.St_Cao12DxCnt.ServerHandle,
                this.St_Cao13Vmin.ServerHandle,
                this.St_Cao13Vmax.ServerHandle,
                this.St_Cao13Dzmin.ServerHandle,
                this.St_Cao13Dzmax.ServerHandle,
                this.St_Cao13Used.ServerHandle,
                this.St_Cao13DxCnt.ServerHandle,
                this.St_Cao14Vmin.ServerHandle,
                this.St_Cao14Vmax.ServerHandle,
                this.St_Cao14Dzmin.ServerHandle,
                this.St_Cao14Dzmax.ServerHandle,
                this.St_Cao14Used.ServerHandle,
                this.St_Cao14DxCnt.ServerHandle,
                this.St_Cao15Vmin.ServerHandle,
                this.St_Cao15Vmax.ServerHandle,
                this.St_Cao15Dzmin.ServerHandle,
                this.St_Cao15Dzmax.ServerHandle,
                this.St_Cao15Used.ServerHandle,
                this.St_Cao15DxCnt.ServerHandle,
                this.St_Cao16Vmin.ServerHandle,
                this.St_Cao16Vmax.ServerHandle,
                this.St_Cao16Dzmin.ServerHandle,
                this.St_Cao16Dzmax.ServerHandle,
                this.St_Cao16Used.ServerHandle,
                this.St_Cao16DxCnt.ServerHandle,
                this.St_Cao17Vmin.ServerHandle,
                this.St_Cao17Vmax.ServerHandle,
                this.St_Cao17Dzmin.ServerHandle,
                this.St_Cao17Dzmax.ServerHandle,
                this.St_Cao17Used.ServerHandle,
                this.St_Cao17DxCnt.ServerHandle,
                this.St_Cao18Vmin.ServerHandle,
                this.St_Cao18Vmax.ServerHandle,
                this.St_Cao18Dzmin.ServerHandle,
                this.St_Cao18Dzmax.ServerHandle,
                this.St_Cao18Used.ServerHandle,
                this.St_Cao18DxCnt.ServerHandle
            };
            Array values = new object[114] { "", GY_IsNet,
                GY_IsScanner,
                GY_MBatchChecker,
                GY_IsSameGy,
                GY_DxSize,
                grooves[0].St_CaoVmin,//0
                grooves[0].St_CaoVmax,
                grooves[0].St_CaoDzmin,
                grooves[0].St_CaoDzmax,
                grooves[0].St_CaoUsed,
                grooves[0].St_CaoDxCnt,
                grooves[1].St_CaoVmin,//1
                grooves[1].St_CaoVmax,
                grooves[1].St_CaoDzmin,
                grooves[1].St_CaoDzmax,
                grooves[1].St_CaoUsed,
                grooves[1].St_CaoDxCnt,
                grooves[2].St_CaoVmin,//2
                grooves[2].St_CaoVmax,
                grooves[2].St_CaoDzmin,
                grooves[2].St_CaoDzmax,
                grooves[2].St_CaoUsed,
                grooves[2].St_CaoDxCnt,
                grooves[3].St_CaoVmin,//3
                grooves[3].St_CaoVmax,
                grooves[3].St_CaoDzmin,
                grooves[3].St_CaoDzmax,
                grooves[3].St_CaoUsed,
                grooves[3].St_CaoDxCnt,
                grooves[4].St_CaoVmin,//4
                grooves[4].St_CaoVmax,
                grooves[4].St_CaoDzmin,
                grooves[4].St_CaoDzmax,
                grooves[4].St_CaoUsed,
                grooves[4].St_CaoDxCnt,
                grooves[5].St_CaoVmin,//5
                grooves[5].St_CaoVmax,
                grooves[5].St_CaoDzmin,
                grooves[5].St_CaoDzmax,
                grooves[5].St_CaoUsed,
                grooves[5].St_CaoDxCnt,
                grooves[6].St_CaoVmin,//6
                grooves[6].St_CaoVmax,
                grooves[6].St_CaoDzmin,
                grooves[6].St_CaoDzmax,
                grooves[6].St_CaoUsed,
                grooves[6].St_CaoDxCnt,
                grooves[7].St_CaoVmin,//7
                grooves[7].St_CaoVmax,
                grooves[7].St_CaoDzmin,
                grooves[7].St_CaoDzmax,
                grooves[7].St_CaoUsed,
                grooves[7].St_CaoDxCnt,
                grooves[8].St_CaoVmin,//8
                grooves[8].St_CaoVmax,
                grooves[8].St_CaoDzmin,
                grooves[8].St_CaoDzmax,
                grooves[8].St_CaoUsed,
                grooves[8].St_CaoDxCnt,
                grooves[9].St_CaoVmin,//9
                grooves[9].St_CaoVmax,
                grooves[9].St_CaoDzmin,
                grooves[9].St_CaoDzmax,
                grooves[9].St_CaoUsed,
                grooves[9].St_CaoDxCnt,
                grooves[10].St_CaoVmin,//10
                grooves[10].St_CaoVmax,
                grooves[10].St_CaoDzmin,
                grooves[10].St_CaoDzmax,
                grooves[10].St_CaoUsed,
                grooves[10].St_CaoDxCnt,
                grooves[11].St_CaoVmin,//11
                grooves[11].St_CaoVmax,
                grooves[11].St_CaoDzmin,
                grooves[11].St_CaoDzmax,
                grooves[11].St_CaoUsed,
                grooves[11].St_CaoDxCnt,
                grooves[12].St_CaoVmin,//12
                grooves[12].St_CaoVmax,
                grooves[12].St_CaoDzmin,
                grooves[12].St_CaoDzmax,
                grooves[12].St_CaoUsed,
                grooves[12].St_CaoDxCnt,
                grooves[13].St_CaoVmin,//13
                grooves[13].St_CaoVmax,
                grooves[13].St_CaoDzmin,
                grooves[13].St_CaoDzmax,
                grooves[13].St_CaoUsed,
                grooves[13].St_CaoDxCnt,
                grooves[14].St_CaoVmin,//14
                grooves[14].St_CaoVmax,
                grooves[14].St_CaoDzmin,
                grooves[14].St_CaoDzmax,
                grooves[14].St_CaoUsed,
                grooves[14].St_CaoDxCnt,
                grooves[15].St_CaoVmin,//15
                grooves[15].St_CaoVmax,
                grooves[15].St_CaoDzmin,
                grooves[15].St_CaoDzmax,
                grooves[15].St_CaoUsed,
                grooves[15].St_CaoDxCnt,
                grooves[16].St_CaoVmin,//16
                grooves[16].St_CaoVmax,
                grooves[16].St_CaoDzmin,
                grooves[16].St_CaoDzmax,
                grooves[16].St_CaoUsed,
                grooves[16].St_CaoDxCnt,
                grooves[17].St_CaoVmin,//17
                grooves[17].St_CaoVmax,
                grooves[17].St_CaoDzmin,
                grooves[17].St_CaoDzmax,
                grooves[17].St_CaoUsed,
                grooves[17].St_CaoDxCnt
                 };
            Array errors;
            try
            {
                this._MyGroup_Gongyi.SyncWrite(96, ref serverHandles, ref values, out errors);
            }
            catch (Exception ex)
            {
                if (!blReWrite)
                {
                    //此时不是第二次调用了
                    if (!this.InitServer(out sErr)) return false;
                    return this.WriteGongyi(GY_IsNet, GY_IsScanner, GY_MBatchChecker, GY_IsSameGy, GY_DxSize, grooves, out sErr, true);
                }
                else
                {
                    sErr = string.Format("各槽的工艺参数写入出错：{0}({1})", ex.Message, ex.Source);
                }
                return false;
            }
            sErr = string.Empty;
            return true;
        }

        #endregion
        #region 南京中比AB档操作
        public bool SetExp_YcSet(float fValue,out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (this.Exp_YcSet == null)
            {
                sErr = "Exp_YcSet设置失败：opc为空！";
                return false;
            }
            else if (this.Exp_YcSet._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Exp_YcSet设置失败：opcItem为空，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (this.Exp_YcSet.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Exp_YcSet设置失败：opcItem的serverhandle，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (!this.Exp_YcSet.WriteData(fValue, out sErr))
            {
                sErr = string.Format("Exp_YcSet设置时出错：{0}", sErr);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 南京中比追加的，写入分档模式
        /// </summary>
        /// <param name="iValue"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        public bool SetExp_SwMode(short iValue, out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (this.Exp_SwMode == null)
            {
                sErr = "Exp_SwMode设置失败：opc为空！";
                return false;
            }
            else if (this.Exp_SwMode._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Exp_SwMode设置失败：opcItem为空，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (this.Exp_SwMode.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Exp_SwMode设置失败：opcItem的serverhandle，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (!this.Exp_SwMode.WriteData(iValue, out sErr))
            {
                sErr = string.Format("Exp_SwMode设置时出错：{0}", sErr);
                return false;
            }
            return true;
        }
        public bool WriteSwichSetting(bool blReWrite,JpsOPC.OPCEntitys.SwichABEntity set1, JpsOPC.OPCEntitys.SwichABEntity set2, JpsOPC.OPCEntitys.SwichABEntity set3, JpsOPC.OPCEntitys.SwichABEntity set4, JpsOPC.OPCEntitys.SwichABEntity set5
            , JpsOPC.OPCEntitys.SwichABEntity set6, JpsOPC.OPCEntitys.SwichABEntity set7, JpsOPC.OPCEntitys.SwichABEntity set8, JpsOPC.OPCEntitys.SwichABEntity set9, out string sErr)
        {
            //sErr = string.Format("数量serverID:{0}，数量值:{1}", this.St_Cao1DxCnt.ServerHandle, grooves[0].St_CaoDxCnt);
            //return false;
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            if (set1 == null) set1 = new OPCEntitys.SwichABEntity();
            if (set2 == null) set2 = new OPCEntitys.SwichABEntity();
            if (set3 == null) set3 = new OPCEntitys.SwichABEntity();
            if (set4 == null) set4 = new OPCEntitys.SwichABEntity();
            if (set5 == null) set5 = new OPCEntitys.SwichABEntity();
            if (set6 == null) set6 = new OPCEntitys.SwichABEntity();
            if (set7 == null) set7 = new OPCEntitys.SwichABEntity();
            if (set8 == null) set8 = new OPCEntitys.SwichABEntity();
            if (set9 == null) set9 = new OPCEntitys.SwichABEntity();
            //foreach(GrooveGongyiEntity entity in grooves)
            //{
            //    if(entity.St_CaoUsed && entity.St_CaoDxCnt>0)
            //    {
            //        iCaoBtyCnt = entity.St_CaoDxCnt;
            //        break;
            //    }
            //}
            //写入数据
            Array serverHandles = new int[55] { 0,
                this.Exp_Cao1ACapMax.ServerHandle,
                this.Exp_Cao1ACapMin.ServerHandle,
                this.Exp_Cao1BCapMax.ServerHandle,
                this.Exp_Cao1BCapMin.ServerHandle,
                this.Exp_Cao1AQty.ServerHandle,
                this.Exp_Cao1BQty.ServerHandle,
                this.Exp_Cao2ACapMax.ServerHandle,
                this.Exp_Cao2ACapMin.ServerHandle,
                this.Exp_Cao2BCapMax.ServerHandle,
                this.Exp_Cao2BCapMin.ServerHandle,
                this.Exp_Cao2AQty.ServerHandle,
                this.Exp_Cao2BQty.ServerHandle,
                this.Exp_Cao3ACapMax.ServerHandle,
                this.Exp_Cao3ACapMin.ServerHandle,
                this.Exp_Cao3BCapMax.ServerHandle,
                this.Exp_Cao3BCapMin.ServerHandle,
                this.Exp_Cao3AQty.ServerHandle,
                this.Exp_Cao3BQty.ServerHandle,
                this.Exp_Cao4ACapMax.ServerHandle,
                this.Exp_Cao4ACapMin.ServerHandle,
                this.Exp_Cao4BCapMax.ServerHandle,
                this.Exp_Cao4BCapMin.ServerHandle,
                this.Exp_Cao4AQty.ServerHandle,
                this.Exp_Cao4BQty.ServerHandle,
                this.Exp_Cao5ACapMax.ServerHandle,
                this.Exp_Cao5ACapMin.ServerHandle,
                this.Exp_Cao5BCapMax.ServerHandle,
                this.Exp_Cao5BCapMin.ServerHandle,
                this.Exp_Cao5AQty.ServerHandle,
                this.Exp_Cao5BQty.ServerHandle,
                this.Exp_Cao6ACapMax.ServerHandle,
                this.Exp_Cao6ACapMin.ServerHandle,
                this.Exp_Cao6BCapMax.ServerHandle,
                this.Exp_Cao6BCapMin.ServerHandle,
                this.Exp_Cao6AQty.ServerHandle,
                this.Exp_Cao6BQty.ServerHandle,
                this.Exp_Cao7ACapMax.ServerHandle,
                this.Exp_Cao7ACapMin.ServerHandle,
                this.Exp_Cao7BCapMax.ServerHandle,
                this.Exp_Cao7BCapMin.ServerHandle,
                this.Exp_Cao7AQty.ServerHandle,
                this.Exp_Cao7BQty.ServerHandle,
                this.Exp_Cao8ACapMax.ServerHandle,
                this.Exp_Cao8ACapMin.ServerHandle,
                this.Exp_Cao8BCapMax.ServerHandle,
                this.Exp_Cao8BCapMin.ServerHandle,
                this.Exp_Cao8AQty.ServerHandle,
                this.Exp_Cao8BQty.ServerHandle,
                this.Exp_Cao9ACapMax.ServerHandle,
                this.Exp_Cao9ACapMin.ServerHandle,
                this.Exp_Cao9BCapMax.ServerHandle,
                this.Exp_Cao9BCapMin.ServerHandle,
                this.Exp_Cao9AQty.ServerHandle,
                this.Exp_Cao9BQty.ServerHandle
            };
            Array values = new object[55] { "",
                set1.MaxValueA,
                set1.MinValueA,
                set1.MaxValueB,
                set1.MinValueB,
                set1.QtyA,
                set1.QtyB,
                set2.MaxValueA,
                set2.MinValueA,
                set2.MaxValueB,
                set2.MinValueB,
                set2.QtyA,
                set2.QtyB,
                set3.MaxValueA,
                set3.MinValueA,
                set3.MaxValueB,
                set3.MinValueB,
                set3.QtyA,
                set3.QtyB,
                set4.MaxValueA,
                set4.MinValueA,
                set4.MaxValueB,
                set4.MinValueB,
                set4.QtyA,
                set4.QtyB,
                set5.MaxValueA,
                set5.MinValueA,
                set5.MaxValueB,
                set5.MinValueB,
                set5.QtyA,
                set5.QtyB,
                set6.MaxValueA,
                set6.MinValueA,
                set6.MaxValueB,
                set6.MinValueB,
                set6.QtyA,
                set6.QtyB,
                set7.MaxValueA,
                set7.MinValueA,
                set7.MaxValueB,
                set7.MinValueB,
                set7.QtyA,
                set7.QtyB,
                set8.MaxValueA,
                set8.MinValueA,
                set8.MaxValueB,
                set8.MinValueB,
                set8.QtyA,
                set8.QtyB,
                set9.MaxValueA,
                set9.MinValueA,
                set9.MaxValueB,
                set9.MinValueB,
                set9.QtyA,
                set9.QtyB
                 };
            Array errors;
            try
            {
                this._MyGroup_Gongyi.SyncWrite(54, ref serverHandles, ref values, out errors);
            }
            catch (Exception ex)
            {
                if (!blReWrite)
                {
                    //此时不是第二次调用了
                    if (!this.InitServer(out sErr)) return false;
                    return this.WriteSwichSetting(true,set1, set2, set3, set4, set5, set6, set7, set8, set9,out sErr);
                }
                else
                {
                    sErr = string.Format("各槽AB档工艺参数写入出错：{0}({1})", ex.Message, ex.Source);
                }
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        
        #endregion
    }
    public class OPCHelperCorrect : OPCHelperBase
    {
        OPCServer _Server = null;
        OPCGroups _ServerGroups = null;
        public OPCGroup _MyGroup_Correct = null;
        public OPCHelperCorrect()
        {
            _CorrectValues = new CorrectValue[40];
        }
        #region 用于写入修正值的
        public JpsOPC.MyItemValue Ct_Mes1V = null;
        public JpsOPC.MyItemValue Ct_Mes1Dz = null;
        public JpsOPC.MyItemValue Ct_Mes2V = null;
        public JpsOPC.MyItemValue Ct_Mes2Dz = null;
        public JpsOPC.MyItemValue Ct_Mes3V = null;
        public JpsOPC.MyItemValue Ct_Mes3Dz = null;
        public JpsOPC.MyItemValue Ct_Mes4V = null;
        public JpsOPC.MyItemValue Ct_Mes4Dz = null;
        public JpsOPC.MyItemValue Ct_Mes5V = null;
        public JpsOPC.MyItemValue Ct_Mes5Dz = null;
        public JpsOPC.MyItemValue Ct_Mes6V = null;
        public JpsOPC.MyItemValue Ct_Mes6Dz = null;
        public JpsOPC.MyItemValue Ct_Mes7V = null;
        public JpsOPC.MyItemValue Ct_Mes7Dz = null;
        public JpsOPC.MyItemValue Ct_Mes8V = null;
        public JpsOPC.MyItemValue Ct_Mes8Dz = null;
        public JpsOPC.MyItemValue Ct_Mes9V = null;
        public JpsOPC.MyItemValue Ct_Mes9Dz = null;
        public JpsOPC.MyItemValue Ct_Mes10V = null;
        public JpsOPC.MyItemValue Ct_Mes10Dz = null;
        public JpsOPC.MyItemValue Ct_Mes11V = null;
        public JpsOPC.MyItemValue Ct_Mes11Dz = null;
        public JpsOPC.MyItemValue Ct_Mes12V = null;
        public JpsOPC.MyItemValue Ct_Mes12Dz = null;
        public JpsOPC.MyItemValue Ct_Mes13V = null;
        public JpsOPC.MyItemValue Ct_Mes13Dz = null;
        public JpsOPC.MyItemValue Ct_Mes14V = null;
        public JpsOPC.MyItemValue Ct_Mes14Dz = null;
        public JpsOPC.MyItemValue Ct_Mes15V = null;
        public JpsOPC.MyItemValue Ct_Mes15Dz = null;
        public JpsOPC.MyItemValue Ct_Mes16V = null;
        public JpsOPC.MyItemValue Ct_Mes16Dz = null;
        public JpsOPC.MyItemValue Ct_Mes17V = null;
        public JpsOPC.MyItemValue Ct_Mes17Dz = null;
        public JpsOPC.MyItemValue Ct_Mes18V = null;
        public JpsOPC.MyItemValue Ct_Mes18Dz = null;
        public JpsOPC.MyItemValue Ct_Mes19V = null;
        public JpsOPC.MyItemValue Ct_Mes19Dz = null;
        public JpsOPC.MyItemValue Ct_Mes20V = null;
        public JpsOPC.MyItemValue Ct_Mes20Dz = null;
        public JpsOPC.MyItemValue Ct_Mes21V = null;
        public JpsOPC.MyItemValue Ct_Mes21Dz = null;
        public JpsOPC.MyItemValue Ct_Mes22V = null;
        public JpsOPC.MyItemValue Ct_Mes22Dz = null;
        public JpsOPC.MyItemValue Ct_Mes23V = null;
        public JpsOPC.MyItemValue Ct_Mes23Dz = null;
        public JpsOPC.MyItemValue Ct_Mes24V = null;
        public JpsOPC.MyItemValue Ct_Mes24Dz = null;
        public JpsOPC.MyItemValue Ct_Mes25V = null;
        public JpsOPC.MyItemValue Ct_Mes25Dz = null;
        public JpsOPC.MyItemValue Ct_Mes26V = null;
        public JpsOPC.MyItemValue Ct_Mes26Dz = null;
        public JpsOPC.MyItemValue Ct_Mes27V = null;
        public JpsOPC.MyItemValue Ct_Mes27Dz = null;
        public JpsOPC.MyItemValue Ct_Mes28V = null;
        public JpsOPC.MyItemValue Ct_Mes28Dz = null;
        public JpsOPC.MyItemValue Ct_Mes29V = null;
        public JpsOPC.MyItemValue Ct_Mes29Dz = null;
        public JpsOPC.MyItemValue Ct_Mes30V = null;
        public JpsOPC.MyItemValue Ct_Mes30Dz = null;
        public JpsOPC.MyItemValue Ct_Mes31V = null;
        public JpsOPC.MyItemValue Ct_Mes31Dz = null;
        public JpsOPC.MyItemValue Ct_Mes32V = null;
        public JpsOPC.MyItemValue Ct_Mes32Dz = null;
        public JpsOPC.MyItemValue Ct_Mes33V = null;
        public JpsOPC.MyItemValue Ct_Mes33Dz = null;
        public JpsOPC.MyItemValue Ct_Mes34V = null;
        public JpsOPC.MyItemValue Ct_Mes34Dz = null;
        public JpsOPC.MyItemValue Ct_Mes35V = null;
        public JpsOPC.MyItemValue Ct_Mes35Dz = null;
        public JpsOPC.MyItemValue Ct_Mes36V = null;
        public JpsOPC.MyItemValue Ct_Mes36Dz = null;
        public JpsOPC.MyItemValue Ct_Mes37V = null;
        public JpsOPC.MyItemValue Ct_Mes37Dz = null;
        public JpsOPC.MyItemValue Ct_Mes38V = null;
        public JpsOPC.MyItemValue Ct_Mes38Dz = null;
        public JpsOPC.MyItemValue Ct_Mes39V = null;
        public JpsOPC.MyItemValue Ct_Mes39Dz = null;
        public JpsOPC.MyItemValue Ct_Mes40V = null;
        public JpsOPC.MyItemValue Ct_Mes40Dz = null;
        #endregion
        #region 公共函数
        public bool InitServer(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (!this.InitServerDoing(out sErr))
            {
                this.InitSucessfully = false;
                return false;
            }
            this.InitSucessfully = true;
            return true;
        }
        private bool InitServerDoing(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (_Server == null)
            {
                try
                {
                    this._Server = new OPCServer();
                }
                catch (Exception ex)
                {
                    sErr = "CorrectOPC：初始化Server出错：" + ex.Message + "(" + ex.Source + ")";
                    return false;
                }
            }
            if (this._Server.ServerState != (int)OPCServerState.OPCRunning)
            {
                try
                {
                    this._Server.Connect("KEPware.KEPServerEx.V6", "");
                }
                catch (Exception ex)
                {
                    sErr = string.Format("GongYiOPC：server初始化出错：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
                //重新连接过的话重新定义组
                _ServerGroups = null;
                if (this.Ct_Mes1V != null)
                    this.Ct_Mes1V.InitItem();
                if (this.Ct_Mes1Dz != null)
                    this.Ct_Mes1Dz.InitItem();
                if (this.Ct_Mes2V != null)
                    this.Ct_Mes2V.InitItem();
                if (this.Ct_Mes2Dz != null)
                    this.Ct_Mes2Dz.InitItem();
                if (this.Ct_Mes3V != null)
                    this.Ct_Mes3V.InitItem();
                if (this.Ct_Mes3Dz != null)
                    this.Ct_Mes3Dz.InitItem();
                if (this.Ct_Mes4V != null)
                    this.Ct_Mes4V.InitItem();
                if (this.Ct_Mes4Dz != null)
                    this.Ct_Mes4Dz.InitItem();
                if (this.Ct_Mes5V != null)
                    this.Ct_Mes5V.InitItem();
                if (this.Ct_Mes5Dz != null)
                    this.Ct_Mes5Dz.InitItem();
                if (this.Ct_Mes6V != null)
                    this.Ct_Mes6V.InitItem();
                if (this.Ct_Mes6Dz != null)
                    this.Ct_Mes6Dz.InitItem();
                if (this.Ct_Mes7V != null)
                    this.Ct_Mes7V.InitItem();
                if (this.Ct_Mes7Dz != null)
                    this.Ct_Mes7Dz.InitItem();
                if (this.Ct_Mes8V != null)
                    this.Ct_Mes8V.InitItem();
                if (this.Ct_Mes8Dz != null)
                    this.Ct_Mes8Dz.InitItem();
                if (this.Ct_Mes9V != null)
                    this.Ct_Mes9V.InitItem();
                if (this.Ct_Mes9Dz != null)
                    this.Ct_Mes9Dz.InitItem();
                if (this.Ct_Mes10V != null)
                    this.Ct_Mes10V.InitItem();
                if (this.Ct_Mes10Dz != null)
                    this.Ct_Mes10Dz.InitItem();
                if (this.Ct_Mes11V != null)
                    this.Ct_Mes11V.InitItem();
                if (this.Ct_Mes11Dz != null)
                    this.Ct_Mes11Dz.InitItem();
                if (this.Ct_Mes12V != null)
                    this.Ct_Mes12V.InitItem();
                if (this.Ct_Mes12Dz != null)
                    this.Ct_Mes12Dz.InitItem();
                if (this.Ct_Mes13V != null)
                    this.Ct_Mes13V.InitItem();
                if (this.Ct_Mes13Dz != null)
                    this.Ct_Mes13Dz.InitItem();
                if (this.Ct_Mes14V != null)
                    this.Ct_Mes14V.InitItem();
                if (this.Ct_Mes14Dz != null)
                    this.Ct_Mes14Dz.InitItem();
                if (this.Ct_Mes15V != null)
                    this.Ct_Mes15V.InitItem();
                if (this.Ct_Mes15Dz != null)
                    this.Ct_Mes15Dz.InitItem();
                if (this.Ct_Mes16V != null)
                    this.Ct_Mes16V.InitItem();
                if (this.Ct_Mes16Dz != null)
                    this.Ct_Mes16Dz.InitItem();
                if (this.Ct_Mes17V != null)
                    this.Ct_Mes17V.InitItem();
                if (this.Ct_Mes17Dz != null)
                    this.Ct_Mes17Dz.InitItem();
                if (this.Ct_Mes18V != null)
                    this.Ct_Mes18V.InitItem();
                if (this.Ct_Mes18Dz != null)
                    this.Ct_Mes18Dz.InitItem();
                if (this.Ct_Mes19V != null)
                    this.Ct_Mes19V.InitItem();
                if (this.Ct_Mes19Dz != null)
                    this.Ct_Mes19Dz.InitItem();
                if (this.Ct_Mes20V != null)
                    this.Ct_Mes20V.InitItem();
                if (this.Ct_Mes20Dz != null)
                    this.Ct_Mes20Dz.InitItem();
                if (this.Ct_Mes21V != null)
                    this.Ct_Mes21V.InitItem();
                if (this.Ct_Mes21Dz != null)
                    this.Ct_Mes21Dz.InitItem();
                if (this.Ct_Mes22V != null)
                    this.Ct_Mes22V.InitItem();
                if (this.Ct_Mes22Dz != null)
                    this.Ct_Mes22Dz.InitItem();
                if (this.Ct_Mes23V != null)
                    this.Ct_Mes23V.InitItem();
                if (this.Ct_Mes23Dz != null)
                    this.Ct_Mes23Dz.InitItem();
                if (this.Ct_Mes24V != null)
                    this.Ct_Mes24V.InitItem();
                if (this.Ct_Mes24Dz != null)
                    this.Ct_Mes24Dz.InitItem();
                if (this.Ct_Mes25V != null)
                    this.Ct_Mes25V.InitItem();
                if (this.Ct_Mes25Dz != null)
                    this.Ct_Mes25Dz.InitItem();
                if (this.Ct_Mes26V != null)
                    this.Ct_Mes26V.InitItem();
                if (this.Ct_Mes26Dz != null)
                    this.Ct_Mes26Dz.InitItem();
                if (this.Ct_Mes27V != null)
                    this.Ct_Mes27V.InitItem();
                if (this.Ct_Mes27Dz != null)
                    this.Ct_Mes27Dz.InitItem();
                if (this.Ct_Mes28V != null)
                    this.Ct_Mes28V.InitItem();
                if (this.Ct_Mes28Dz != null)
                    this.Ct_Mes28Dz.InitItem();
                if (this.Ct_Mes29V != null)
                    this.Ct_Mes29V.InitItem();
                if (this.Ct_Mes29Dz != null)
                    this.Ct_Mes29Dz.InitItem();
                if (this.Ct_Mes30V != null)
                    this.Ct_Mes30V.InitItem();
                if (this.Ct_Mes30Dz != null)
                    this.Ct_Mes30Dz.InitItem();
                if (this.Ct_Mes31V != null)
                    this.Ct_Mes31V.InitItem();
                if (this.Ct_Mes31Dz != null)
                    this.Ct_Mes31Dz.InitItem();
                if (this.Ct_Mes32V != null)
                    this.Ct_Mes32V.InitItem();
                if (this.Ct_Mes32Dz != null)
                    this.Ct_Mes32Dz.InitItem();
                if (this.Ct_Mes33V != null)
                    this.Ct_Mes33V.InitItem();
                if (this.Ct_Mes33Dz != null)
                    this.Ct_Mes33Dz.InitItem();
                if (this.Ct_Mes34V != null)
                    this.Ct_Mes34V.InitItem();
                if (this.Ct_Mes34Dz != null)
                    this.Ct_Mes34Dz.InitItem();
                if (this.Ct_Mes35V != null)
                    this.Ct_Mes35V.InitItem();
                if (this.Ct_Mes35Dz != null)
                    this.Ct_Mes35Dz.InitItem();
                if (this.Ct_Mes36V != null)
                    this.Ct_Mes36V.InitItem();
                if (this.Ct_Mes36Dz != null)
                    this.Ct_Mes36Dz.InitItem();
                if (this.Ct_Mes37V != null)
                    this.Ct_Mes37V.InitItem();
                if (this.Ct_Mes37Dz != null)
                    this.Ct_Mes37Dz.InitItem();
                if (this.Ct_Mes38V != null)
                    this.Ct_Mes38V.InitItem();
                if (this.Ct_Mes38Dz != null)
                    this.Ct_Mes38Dz.InitItem();
                if (this.Ct_Mes39V != null)
                    this.Ct_Mes39V.InitItem();
                if (this.Ct_Mes39Dz != null)
                    this.Ct_Mes39Dz.InitItem();
                if (this.Ct_Mes40V != null)
                    this.Ct_Mes40V.InitItem();
                if (this.Ct_Mes40Dz != null)
                    this.Ct_Mes40Dz.InitItem();
            }
            //添加组
            if (_ServerGroups == null)
            {
                _ServerGroups = this._Server.OPCGroups;
                _ServerGroups.DefaultGroupIsActive = true; //设置组集合默认为激活状态
                //下面这个几个暂时不设定，看看是否有异常，因为DefaultGroupUpdateRate这个值很关键，估计是与写入和读取的频率相关了，应该设置到某个单一的节点为好。
                _ServerGroups.DefaultGroupDeadband = 0;    //设置死区
                _ServerGroups.DefaultGroupUpdateRate = 100;//设置更新频率
                try
                {
                    //电池组2
                    this._MyGroup_Correct = _ServerGroups.Add("groupCorrect");
                    this._MyGroup_Correct.UpdateRate = 100;
                    this._MyGroup_Correct.IsActive = true;
                }
                catch (Exception ex)
                {
                    sErr = string.Format("GROUPCorrectOPC:创建各组失败：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
            }
            if (!this.InitMyItems(out sErr))
            {
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool InitMyItems(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (this.Ct_Mes1V == null)
                this.Ct_Mes1V = new MyItemValue(OPCItemTitle + "Ct_Mes1V");
            if (this.Ct_Mes1Dz == null)
                this.Ct_Mes1Dz = new MyItemValue(OPCItemTitle + "Ct_Mes1Dz");
            if (this.Ct_Mes2V == null)
                this.Ct_Mes2V = new MyItemValue(OPCItemTitle + "Ct_Mes2V");
            if (this.Ct_Mes2Dz == null)
                this.Ct_Mes2Dz = new MyItemValue(OPCItemTitle + "Ct_Mes2Dz");
            if (this.Ct_Mes3V == null)
                this.Ct_Mes3V = new MyItemValue(OPCItemTitle + "Ct_Mes3V");
            if (this.Ct_Mes3Dz == null)
                this.Ct_Mes3Dz = new MyItemValue(OPCItemTitle + "Ct_Mes3Dz");
            if (this.Ct_Mes4V == null)
                this.Ct_Mes4V = new MyItemValue(OPCItemTitle + "Ct_Mes4V");
            if (this.Ct_Mes4Dz == null)
                this.Ct_Mes4Dz = new MyItemValue(OPCItemTitle + "Ct_Mes4Dz");
            if (this.Ct_Mes5V == null)
                this.Ct_Mes5V = new MyItemValue(OPCItemTitle + "Ct_Mes5V");
            if (this.Ct_Mes5Dz == null)
                this.Ct_Mes5Dz = new MyItemValue(OPCItemTitle + "Ct_Mes5Dz");
            if (this.Ct_Mes6V == null)
                this.Ct_Mes6V = new MyItemValue(OPCItemTitle + "Ct_Mes6V");
            if (this.Ct_Mes6Dz == null)
                this.Ct_Mes6Dz = new MyItemValue(OPCItemTitle + "Ct_Mes6Dz");
            if (this.Ct_Mes7V == null)
                this.Ct_Mes7V = new MyItemValue(OPCItemTitle + "Ct_Mes7V");
            if (this.Ct_Mes7Dz == null)
                this.Ct_Mes7Dz = new MyItemValue(OPCItemTitle + "Ct_Mes7Dz");
            if (this.Ct_Mes8V == null)
                this.Ct_Mes8V = new MyItemValue(OPCItemTitle + "Ct_Mes8V");
            if (this.Ct_Mes8Dz == null)
                this.Ct_Mes8Dz = new MyItemValue(OPCItemTitle + "Ct_Mes8Dz");
            if (this.Ct_Mes9V == null)
                this.Ct_Mes9V = new MyItemValue(OPCItemTitle + "Ct_Mes9V");
            if (this.Ct_Mes9Dz == null)
                this.Ct_Mes9Dz = new MyItemValue(OPCItemTitle + "Ct_Mes9Dz");
            if (this.Ct_Mes10V == null)
                this.Ct_Mes10V = new MyItemValue(OPCItemTitle + "Ct_Mes10V");
            if (this.Ct_Mes10Dz == null)
                this.Ct_Mes10Dz = new MyItemValue(OPCItemTitle + "Ct_Mes10Dz");
            if (this.Ct_Mes11V == null)
                this.Ct_Mes11V = new MyItemValue(OPCItemTitle + "Ct_Mes11V");
            if (this.Ct_Mes11Dz == null)
                this.Ct_Mes11Dz = new MyItemValue(OPCItemTitle + "Ct_Mes11Dz");
            if (this.Ct_Mes12V == null)
                this.Ct_Mes12V = new MyItemValue(OPCItemTitle + "Ct_Mes12V");
            if (this.Ct_Mes12Dz == null)
                this.Ct_Mes12Dz = new MyItemValue(OPCItemTitle + "Ct_Mes12Dz");
            if (this.Ct_Mes13V == null)
                this.Ct_Mes13V = new MyItemValue(OPCItemTitle + "Ct_Mes13V");
            if (this.Ct_Mes13Dz == null)
                this.Ct_Mes13Dz = new MyItemValue(OPCItemTitle + "Ct_Mes13Dz");
            if (this.Ct_Mes14V == null)
                this.Ct_Mes14V = new MyItemValue(OPCItemTitle + "Ct_Mes14V");
            if (this.Ct_Mes14Dz == null)
                this.Ct_Mes14Dz = new MyItemValue(OPCItemTitle + "Ct_Mes14Dz");
            if (this.Ct_Mes15V == null)
                this.Ct_Mes15V = new MyItemValue(OPCItemTitle + "Ct_Mes15V");
            if (this.Ct_Mes15Dz == null)
                this.Ct_Mes15Dz = new MyItemValue(OPCItemTitle + "Ct_Mes15Dz");
            if (this.Ct_Mes16V == null)
                this.Ct_Mes16V = new MyItemValue(OPCItemTitle + "Ct_Mes16V");
            if (this.Ct_Mes16Dz == null)
                this.Ct_Mes16Dz = new MyItemValue(OPCItemTitle + "Ct_Mes16Dz");
            if (this.Ct_Mes17V == null)
                this.Ct_Mes17V = new MyItemValue(OPCItemTitle + "Ct_Mes17V");
            if (this.Ct_Mes17Dz == null)
                this.Ct_Mes17Dz = new MyItemValue(OPCItemTitle + "Ct_Mes17Dz");
            if (this.Ct_Mes18V == null)
                this.Ct_Mes18V = new MyItemValue(OPCItemTitle + "Ct_Mes18V");
            if (this.Ct_Mes18Dz == null)
                this.Ct_Mes18Dz = new MyItemValue(OPCItemTitle + "Ct_Mes18Dz");
            if (this.Ct_Mes19V == null)
                this.Ct_Mes19V = new MyItemValue(OPCItemTitle + "Ct_Mes19V");
            if (this.Ct_Mes19Dz == null)
                this.Ct_Mes19Dz = new MyItemValue(OPCItemTitle + "Ct_Mes19Dz");
            if (this.Ct_Mes20V == null)
                this.Ct_Mes20V = new MyItemValue(OPCItemTitle + "Ct_Mes20V");
            if (this.Ct_Mes20Dz == null)
                this.Ct_Mes20Dz = new MyItemValue(OPCItemTitle + "Ct_Mes20Dz");
            if (this.Ct_Mes21V == null)
                this.Ct_Mes21V = new MyItemValue(OPCItemTitle + "Ct_Mes21V");
            if (this.Ct_Mes21Dz == null)
                this.Ct_Mes21Dz = new MyItemValue(OPCItemTitle + "Ct_Mes21Dz");
            if (this.Ct_Mes22V == null)
                this.Ct_Mes22V = new MyItemValue(OPCItemTitle + "Ct_Mes22V");
            if (this.Ct_Mes22Dz == null)
                this.Ct_Mes22Dz = new MyItemValue(OPCItemTitle + "Ct_Mes22Dz");
            if (this.Ct_Mes23V == null)
                this.Ct_Mes23V = new MyItemValue(OPCItemTitle + "Ct_Mes23V");
            if (this.Ct_Mes23Dz == null)
                this.Ct_Mes23Dz = new MyItemValue(OPCItemTitle + "Ct_Mes23Dz");
            if (this.Ct_Mes24V == null)
                this.Ct_Mes24V = new MyItemValue(OPCItemTitle + "Ct_Mes24V");
            if (this.Ct_Mes24Dz == null)
                this.Ct_Mes24Dz = new MyItemValue(OPCItemTitle + "Ct_Mes24Dz");
            if (this.Ct_Mes25V == null)
                this.Ct_Mes25V = new MyItemValue(OPCItemTitle + "Ct_Mes25V");
            if (this.Ct_Mes25Dz == null)
                this.Ct_Mes25Dz = new MyItemValue(OPCItemTitle + "Ct_Mes25Dz");
            if (this.Ct_Mes26V == null)
                this.Ct_Mes26V = new MyItemValue(OPCItemTitle + "Ct_Mes26V");
            if (this.Ct_Mes26Dz == null)
                this.Ct_Mes26Dz = new MyItemValue(OPCItemTitle + "Ct_Mes26Dz");
            if (this.Ct_Mes27V == null)
                this.Ct_Mes27V = new MyItemValue(OPCItemTitle + "Ct_Mes27V");
            if (this.Ct_Mes27Dz == null)
                this.Ct_Mes27Dz = new MyItemValue(OPCItemTitle + "Ct_Mes27Dz");
            if (this.Ct_Mes28V == null)
                this.Ct_Mes28V = new MyItemValue(OPCItemTitle + "Ct_Mes28V");
            if (this.Ct_Mes28Dz == null)
                this.Ct_Mes28Dz = new MyItemValue(OPCItemTitle + "Ct_Mes28Dz");
            if (this.Ct_Mes29V == null)
                this.Ct_Mes29V = new MyItemValue(OPCItemTitle + "Ct_Mes29V");
            if (this.Ct_Mes29Dz == null)
                this.Ct_Mes29Dz = new MyItemValue(OPCItemTitle + "Ct_Mes29Dz");
            if (this.Ct_Mes30V == null)
                this.Ct_Mes30V = new MyItemValue(OPCItemTitle + "Ct_Mes30V");
            if (this.Ct_Mes30Dz == null)
                this.Ct_Mes30Dz = new MyItemValue(OPCItemTitle + "Ct_Mes30Dz");
            if (this.Ct_Mes31V == null)
                this.Ct_Mes31V = new MyItemValue(OPCItemTitle + "Ct_Mes31V");
            if (this.Ct_Mes31Dz == null)
                this.Ct_Mes31Dz = new MyItemValue(OPCItemTitle + "Ct_Mes31Dz");
            if (this.Ct_Mes32V == null)
                this.Ct_Mes32V = new MyItemValue(OPCItemTitle + "Ct_Mes32V");
            if (this.Ct_Mes32Dz == null)
                this.Ct_Mes32Dz = new MyItemValue(OPCItemTitle + "Ct_Mes32Dz");
            if (this.Ct_Mes33V == null)
                this.Ct_Mes33V = new MyItemValue(OPCItemTitle + "Ct_Mes33V");
            if (this.Ct_Mes33Dz == null)
                this.Ct_Mes33Dz = new MyItemValue(OPCItemTitle + "Ct_Mes33Dz");
            if (this.Ct_Mes34V == null)
                this.Ct_Mes34V = new MyItemValue(OPCItemTitle + "Ct_Mes34V");
            if (this.Ct_Mes34Dz == null)
                this.Ct_Mes34Dz = new MyItemValue(OPCItemTitle + "Ct_Mes34Dz");
            if (this.Ct_Mes35V == null)
                this.Ct_Mes35V = new MyItemValue(OPCItemTitle + "Ct_Mes35V");
            if (this.Ct_Mes35Dz == null)
                this.Ct_Mes35Dz = new MyItemValue(OPCItemTitle + "Ct_Mes35Dz");
            if (this.Ct_Mes36V == null)
                this.Ct_Mes36V = new MyItemValue(OPCItemTitle + "Ct_Mes36V");
            if (this.Ct_Mes36Dz == null)
                this.Ct_Mes36Dz = new MyItemValue(OPCItemTitle + "Ct_Mes36Dz");
            if (this.Ct_Mes37V == null)
                this.Ct_Mes37V = new MyItemValue(OPCItemTitle + "Ct_Mes37V");
            if (this.Ct_Mes37Dz == null)
                this.Ct_Mes37Dz = new MyItemValue(OPCItemTitle + "Ct_Mes37Dz");
            if (this.Ct_Mes38V == null)
                this.Ct_Mes38V = new MyItemValue(OPCItemTitle + "Ct_Mes38V");
            if (this.Ct_Mes38Dz == null)
                this.Ct_Mes38Dz = new MyItemValue(OPCItemTitle + "Ct_Mes38Dz");
            if (this.Ct_Mes39V == null)
                this.Ct_Mes39V = new MyItemValue(OPCItemTitle + "Ct_Mes39V");
            if (this.Ct_Mes39Dz == null)
                this.Ct_Mes39Dz = new MyItemValue(OPCItemTitle + "Ct_Mes39Dz");
            if (this.Ct_Mes40V == null)
                this.Ct_Mes40V = new MyItemValue(OPCItemTitle + "Ct_Mes40V");
            if (this.Ct_Mes40Dz == null)
                this.Ct_Mes40Dz = new MyItemValue(OPCItemTitle + "Ct_Mes40Dz");

            if (this._MyGroup_Correct == null)
            {
                sErr = "初始化工艺写入OPCitem时失败，因为group为空。";
                return false;
            }

            if (_MyGroup_Correct.OPCItems == null)
            {
                sErr = "初始化工艺写入OPCitem时失败，因为group.OPCItems为空。";
                return false;
            }
            //处理系统标识
            if (!InitMyItems_AddItem(this.Ct_Mes1V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes1Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes2V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes2Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes3V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes3Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes4V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes4Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes5V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes5Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes6V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes6Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes7V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes7Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes8V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes8Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes9V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes9Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes10V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes10Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes11V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes11Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes12V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes12Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes13V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes13Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes14V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes14Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes15V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes15Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes16V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes16Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes17V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes17Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes18V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes18Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes19V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes19Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes20V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes20Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes21V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes21Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes22V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes22Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes23V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes23Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes24V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes24Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes25V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes25Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes26V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes26Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes27V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes27Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes28V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes28Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes29V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes29Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes30V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes30Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes31V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes31Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes32V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes32Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes33V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes33Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes34V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes34Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes35V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes35Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes36V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes36Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes37V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes37Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes38V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes38Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes39V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes39Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes40V, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Ct_Mes40Dz, this._MyGroup_Correct, false, out sErr))
            {
                return false;
            }
            return true;
        }
        private bool InitMyItems_AddItem(MyItemValue myItem, OPCGroup targetGroup, bool saveItem, out string sErr)
        {
            if (myItem.ServerHandle <= 0)
            {
                if (this.IsDebug)
                {
                    sErr = string.Empty;
                    return true;
                }
                //此时添加Item
                _ClientHandle++;
                OPCItem item = null;
                string strTagName = myItem.TagName;
                try
                {
                    item = targetGroup.OPCItems.AddItem(strTagName, _ClientHandle);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("添加Item：{0}，出错:{1}({2})", myItem.TagName, ex.Message, ex.Source);
                    return false;
                }
                if (item == null)
                {
                    sErr = string.Format("添加Item：{0}失败，返回为空。", myItem.TagName);
                    return false;
                }
                if (item.ServerHandle <= 0)
                {
                    sErr = string.Format("添加Item：{0}失败，返回值ServerHandle为{1}。", myItem.TagName, myItem.ServerHandle);
                    return false;
                }
                myItem.ServerHandle = item.ServerHandle;
                myItem.ClientHandle = this._ClientHandle;
                if (saveItem)
                    myItem._OPCItem = item;
            }
            sErr = string.Empty;
            return true;
        }
        public bool CloseOPC(out string sErr)
        {
            sErr = "";
            if (this._Server == null) return true;
            try
            {
                this._Server.Disconnect();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
                return false;
            }
            return true;
        }
        #endregion
        #region  读取结果值存储
        public CorrectValue[] _CorrectValues;
        #endregion
        #region 写入功能函数
        public bool WriteCorret(float fV1, float fDz1,
                float fV2, float fDz2,
                float fV3, float fDz3,
                float fV4, float fDz4,
                float fV5, float fDz5,
                float fV6, float fDz6,
                float fV7, float fDz7,
                float fV8, float fDz8,
                float fV9, float fDz9,
                float fV10, float fDz10,
                float fV11, float fDz11,
                float fV12, float fDz12,
                float fV13, float fDz13,
                float fV14, float fDz14,
                float fV15, float fDz15,
                float fV16, float fDz16,
                float fV17, float fDz17,
                float fV18, float fDz18,
                float fV19, float fDz19,
                float fV20, float fDz20,
                float fV21, float fDz21,
                float fV22, float fDz22,
                float fV23, float fDz23,
                float fV24, float fDz24,
                float fV25, float fDz25,
                float fV26, float fDz26,
                float fV27, float fDz27,
                float fV28, float fDz28,
                float fV29, float fDz29,
                float fV30, float fDz30,
                float fV31, float fDz31,
                float fV32, float fDz32,
                float fV33, float fDz33,
                float fV34, float fDz34,
                float fV35, float fDz35,
                float fV36, float fDz36,
                float fV37, float fDz37,
                float fV38, float fDz38,
                float fV39, float fDz39,
                float fV40, float fDz40, out string sErr, bool blReWrite = false)
        {
            //sErr = string.Format("数量serverID:{0}，数量值:{1}", this.St_Cao1DxCnt.ServerHandle, grooves[0].St_CaoDxCnt);
            //return false;
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            //写入数据
            Array serverHandles = new int[81] { 0,
                this.Ct_Mes1V.ServerHandle,
                this.Ct_Mes1Dz.ServerHandle,
                this.Ct_Mes2V.ServerHandle,
                this.Ct_Mes2Dz.ServerHandle,
                this.Ct_Mes3V.ServerHandle,
                this.Ct_Mes3Dz.ServerHandle,
                this.Ct_Mes4V.ServerHandle,
                this.Ct_Mes4Dz.ServerHandle,
                this.Ct_Mes5V.ServerHandle,
                this.Ct_Mes5Dz.ServerHandle,
                this.Ct_Mes6V.ServerHandle,
                this.Ct_Mes6Dz.ServerHandle,
                this.Ct_Mes7V.ServerHandle,
                this.Ct_Mes7Dz.ServerHandle,
                this.Ct_Mes8V.ServerHandle,
                this.Ct_Mes8Dz.ServerHandle,
                this.Ct_Mes9V.ServerHandle,
                this.Ct_Mes9Dz.ServerHandle,
                this.Ct_Mes10V.ServerHandle,
                this.Ct_Mes10Dz.ServerHandle,
                this.Ct_Mes11V.ServerHandle,
                this.Ct_Mes11Dz.ServerHandle,
                this.Ct_Mes12V.ServerHandle,
                this.Ct_Mes12Dz.ServerHandle,
                this.Ct_Mes13V.ServerHandle,
                this.Ct_Mes13Dz.ServerHandle,
                this.Ct_Mes14V.ServerHandle,
                this.Ct_Mes14Dz.ServerHandle,
                this.Ct_Mes15V.ServerHandle,
                this.Ct_Mes15Dz.ServerHandle,
                this.Ct_Mes16V.ServerHandle,
                this.Ct_Mes16Dz.ServerHandle,
                this.Ct_Mes17V.ServerHandle,
                this.Ct_Mes17Dz.ServerHandle,
                this.Ct_Mes18V.ServerHandle,
                this.Ct_Mes18Dz.ServerHandle,
                this.Ct_Mes19V.ServerHandle,
                this.Ct_Mes19Dz.ServerHandle,
                this.Ct_Mes20V.ServerHandle,
                this.Ct_Mes20Dz.ServerHandle,
                this.Ct_Mes21V.ServerHandle,
                this.Ct_Mes21Dz.ServerHandle,
                this.Ct_Mes22V.ServerHandle,
                this.Ct_Mes22Dz.ServerHandle,
                this.Ct_Mes23V.ServerHandle,
                this.Ct_Mes23Dz.ServerHandle,
                this.Ct_Mes24V.ServerHandle,
                this.Ct_Mes24Dz.ServerHandle,
                this.Ct_Mes25V.ServerHandle,
                this.Ct_Mes25Dz.ServerHandle,
                this.Ct_Mes26V.ServerHandle,
                this.Ct_Mes26Dz.ServerHandle,
                this.Ct_Mes27V.ServerHandle,
                this.Ct_Mes27Dz.ServerHandle,
                this.Ct_Mes28V.ServerHandle,
                this.Ct_Mes28Dz.ServerHandle,
                this.Ct_Mes29V.ServerHandle,
                this.Ct_Mes29Dz.ServerHandle,
                this.Ct_Mes30V.ServerHandle,
                this.Ct_Mes30Dz.ServerHandle,
                this.Ct_Mes31V.ServerHandle,
                this.Ct_Mes31Dz.ServerHandle,
                this.Ct_Mes32V.ServerHandle,
                this.Ct_Mes32Dz.ServerHandle,
                this.Ct_Mes33V.ServerHandle,
                this.Ct_Mes33Dz.ServerHandle,
                this.Ct_Mes34V.ServerHandle,
                this.Ct_Mes34Dz.ServerHandle,
                this.Ct_Mes35V.ServerHandle,
                this.Ct_Mes35Dz.ServerHandle,
                this.Ct_Mes36V.ServerHandle,
                this.Ct_Mes36Dz.ServerHandle,
                this.Ct_Mes37V.ServerHandle,
                this.Ct_Mes37Dz.ServerHandle,
                this.Ct_Mes38V.ServerHandle,
                this.Ct_Mes38Dz.ServerHandle,
                this.Ct_Mes39V.ServerHandle,
                this.Ct_Mes39Dz.ServerHandle,
                this.Ct_Mes40V.ServerHandle,
                this.Ct_Mes40Dz.ServerHandle,

            };
            Array values = new object[81] { "", fV1,fDz1
                            , fV2,fDz2
                            , fV3,fDz3
                            , fV4,fDz4
                            , fV5,fDz5
                            , fV6,fDz6
                            , fV7,fDz7
                            , fV8,fDz8
                            , fV9,fDz9
                            , fV10,fDz10
                            , fV11,fDz11
                            , fV12,fDz12
                            , fV13,fDz13
                            , fV14,fDz14
                            , fV15,fDz15
                            , fV16,fDz16
                            , fV17,fDz17
                            , fV18,fDz18
                            , fV19,fDz19
                            , fV20,fDz20
                            , fV21,fDz21
                            , fV22,fDz22
                            , fV23,fDz23
                            , fV24,fDz24
                            , fV25,fDz25
                            , fV26,fDz26
                            , fV27,fDz27
                            , fV28,fDz28
                            , fV29,fDz29
                            , fV30,fDz30
                            , fV31,fDz31
                            , fV32,fDz32
                            , fV33,fDz33
                            , fV34,fDz34
                            , fV35,fDz35
                            , fV36,fDz36
                            , fV37,fDz37
                            , fV38,fDz38
                            , fV39,fDz39
                            , fV40,fDz40
            };
            Array errors;
            try
            {
                this._MyGroup_Correct.SyncWrite(80, ref serverHandles, ref values, out errors);
            }
            catch (Exception ex)
            {
                if (!blReWrite)
                {
                    //此时不是第二次调用了
                    if (!this.InitServer(out sErr)) return false;
                    return this.WriteCorret(fV1, fDz1
                            , fV2, fDz2
                            , fV3, fDz3
                            , fV4, fDz4
                            , fV5, fDz5
                            , fV6, fDz6
                            , fV7, fDz7
                            , fV8, fDz8
                            , fV9, fDz9
                            , fV10, fDz10
                            , fV11, fDz11
                            , fV12, fDz12
                            , fV13, fDz13
                            , fV14, fDz14
                            , fV15, fDz15
                            , fV16, fDz16
                            , fV17, fDz17
                            , fV18, fDz18
                            , fV19, fDz19
                            , fV20, fDz20
                            , fV21, fDz21
                            , fV22, fDz22
                            , fV23, fDz23
                            , fV24, fDz24
                            , fV25, fDz25
                            , fV26, fDz26
                            , fV27, fDz27
                            , fV28, fDz28
                            , fV29, fDz29
                            , fV30, fDz30
                            , fV31, fDz31
                            , fV32, fDz32
                            , fV33, fDz33
                            , fV34, fDz34
                            , fV35, fDz35
                            , fV36, fDz36
                            , fV37, fDz37
                            , fV38, fDz38
                            , fV39, fDz39
                            , fV40, fDz40, out sErr, true);
                }
                else
                {
                    sErr = string.Format("各修正值参数写入出错：{0}({1})", ex.Message, ex.Source);
                }
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        #endregion
        #region 读取功能函数
        public bool ReadCorrect(out string sErr)
        {
            if (this._MyGroup_Correct == null)
            {
                sErr = "GROUP对象为空，数据读取失败！";
                return false;
            }
            if (this.Ct_Mes1V == null)
            {
                sErr = "GROUP的Item对象为空，数据读取失败！";
                return false;
            }
            if (!this.ReadCorrectFromOPC(out sErr))
                return false;
            return true;
        }
        private bool ReadCorrectFromOPC(out string sErr)
        {
            Array values = null;
            #region serverHandles
            Array serverHandles = new int[81] { 0,
                this.Ct_Mes1V.ServerHandle,
                this.Ct_Mes1Dz.ServerHandle,
                this.Ct_Mes2V.ServerHandle,
                this.Ct_Mes2Dz.ServerHandle,
                this.Ct_Mes3V.ServerHandle,
                this.Ct_Mes3Dz.ServerHandle,
                this.Ct_Mes4V.ServerHandle,
                this.Ct_Mes4Dz.ServerHandle,
                this.Ct_Mes5V.ServerHandle,
                this.Ct_Mes5Dz.ServerHandle,
                this.Ct_Mes6V.ServerHandle,
                this.Ct_Mes6Dz.ServerHandle,
                this.Ct_Mes7V.ServerHandle,
                this.Ct_Mes7Dz.ServerHandle,
                this.Ct_Mes8V.ServerHandle,
                this.Ct_Mes8Dz.ServerHandle,
                this.Ct_Mes9V.ServerHandle,
                this.Ct_Mes9Dz.ServerHandle,
                this.Ct_Mes10V.ServerHandle,
                this.Ct_Mes10Dz.ServerHandle,
                this.Ct_Mes11V.ServerHandle,
                this.Ct_Mes11Dz.ServerHandle,
                this.Ct_Mes12V.ServerHandle,
                this.Ct_Mes12Dz.ServerHandle,
                this.Ct_Mes13V.ServerHandle,
                this.Ct_Mes13Dz.ServerHandle,
                this.Ct_Mes14V.ServerHandle,
                this.Ct_Mes14Dz.ServerHandle,
                this.Ct_Mes15V.ServerHandle,
                this.Ct_Mes15Dz.ServerHandle,
                this.Ct_Mes16V.ServerHandle,
                this.Ct_Mes16Dz.ServerHandle,
                this.Ct_Mes17V.ServerHandle,
                this.Ct_Mes17Dz.ServerHandle,
                this.Ct_Mes18V.ServerHandle,
                this.Ct_Mes18Dz.ServerHandle,
                this.Ct_Mes19V.ServerHandle,
                this.Ct_Mes19Dz.ServerHandle,
                this.Ct_Mes20V.ServerHandle,
                this.Ct_Mes20Dz.ServerHandle,
                this.Ct_Mes21V.ServerHandle,
                this.Ct_Mes21Dz.ServerHandle,
                this.Ct_Mes22V.ServerHandle,
                this.Ct_Mes22Dz.ServerHandle,
                this.Ct_Mes23V.ServerHandle,
                this.Ct_Mes23Dz.ServerHandle,
                this.Ct_Mes24V.ServerHandle,
                this.Ct_Mes24Dz.ServerHandle,
                this.Ct_Mes25V.ServerHandle,
                this.Ct_Mes25Dz.ServerHandle,
                this.Ct_Mes26V.ServerHandle,
                this.Ct_Mes26Dz.ServerHandle,
                this.Ct_Mes27V.ServerHandle,
                this.Ct_Mes27Dz.ServerHandle,
                this.Ct_Mes28V.ServerHandle,
                this.Ct_Mes28Dz.ServerHandle,
                this.Ct_Mes29V.ServerHandle,
                this.Ct_Mes29Dz.ServerHandle,
                this.Ct_Mes30V.ServerHandle,
                this.Ct_Mes30Dz.ServerHandle,
                this.Ct_Mes31V.ServerHandle,
                this.Ct_Mes31Dz.ServerHandle,
                this.Ct_Mes32V.ServerHandle,
                this.Ct_Mes32Dz.ServerHandle,
                this.Ct_Mes33V.ServerHandle,
                this.Ct_Mes33Dz.ServerHandle,
                this.Ct_Mes34V.ServerHandle,
                this.Ct_Mes34Dz.ServerHandle,
                this.Ct_Mes35V.ServerHandle,
                this.Ct_Mes35Dz.ServerHandle,
                this.Ct_Mes36V.ServerHandle,
                this.Ct_Mes36Dz.ServerHandle,
                this.Ct_Mes37V.ServerHandle,
                this.Ct_Mes37Dz.ServerHandle,
                this.Ct_Mes38V.ServerHandle,
                this.Ct_Mes38Dz.ServerHandle,
                this.Ct_Mes39V.ServerHandle,
                this.Ct_Mes39Dz.ServerHandle,
                this.Ct_Mes40V.ServerHandle,
                this.Ct_Mes40Dz.ServerHandle
            };
            #endregion
            object objQ;
            object objT;
            Array errors = null;
            try
            {
                this._MyGroup_Correct.SyncRead(1, 80, ref serverHandles, out values, out errors, out objQ, out objT);
            }
            catch (System.AccessViolationException ex1)
            {
                sErr = string.Format("CorrectOPC读取出错01：{0}({1})", ex1.Message, ex1.Source);
                return false;
            }
            catch (Exception ex)
            {
                sErr = string.Format("CorrectOPC读取出错01：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            if (values == null)
            {
                sErr = "CorrectOPC读取出错02:values为空！";
                return false;
            }
            if (values.Length != 80)
            {
                sErr = string.Format("CorrectOPC读取出错03:values长度为{0}，不是预期的100！", values.Length);
                return false;
            }
            Array arrQ = objQ as Array;
            if (arrQ == null)
            {
                sErr = "CorrectOPC读取出错04:qualitys为空！";
                return false;
            }
            if (arrQ.Length != 80)
            {
                sErr = string.Format("CorrectOPC读取出错05:qualitys长度为{0}，不是预期的100！", values.Length);
                return false;
            }
            int iIndex;
            //获取电压值
            object objValue;
            object objQItem;
            float decValue;
            bool blSucessfuly;
            for (int i=0;i<40;i++)
            {
                if (this._CorrectValues[i] == null)
                    this._CorrectValues[i] = new CorrectValue();
                iIndex = i * 2+1;
                decValue = -999999F;
                //读取电压
                objValue = values.GetValue(iIndex );
                objQItem = arrQ.GetValue(iIndex);
                if (objQItem == null)
                {
                    this._CorrectValues[i].VError("返回的Quality为空！");
                    blSucessfuly = false;
                }
                else if (objQItem.ToString() != "192")
                {
                    this._CorrectValues[i].VError(string.Format("返回的Quality为{0}不是预期的192！", objQItem.ToString()));
                    blSucessfuly = false;
                }
                else
                {
                    if (objValue == null)
                    {
                        decValue = 0F;
                        blSucessfuly = true;
                    }
                    else
                    {
                        if (!float.TryParse(objValue.ToString(), out decValue))
                        {
                            this._CorrectValues[i].VError(string.Format("返回的值为\"{0}\"不是预期的数值类型！", objValue.ToString()));
                            blSucessfuly = false;
                        }
                        else
                        {
                            blSucessfuly = true;
                        }
                    }
                }
                if (blSucessfuly)
                    this._CorrectValues[i].SetV(decValue);
                iIndex++;
                //读取电阻
                decValue = -999999F;
                objValue = values.GetValue(iIndex);
                objQItem = arrQ.GetValue(iIndex);
                if (objQItem == null)
                {
                    this._CorrectValues[i].DzError("返回的Quality为空！");
                    blSucessfuly = false;
                }
                else if (objQItem.ToString() != "192")
                {
                    this._CorrectValues[i].DzError(string.Format("返回的Quality为{0}不是预期的192！", objQItem.ToString()));
                    blSucessfuly = false;
                }
                else
                {
                    if (objValue == null)
                    {
                        decValue = 0F;
                        blSucessfuly = true;
                    }
                    else
                    {
                        if (!float.TryParse(objValue.ToString(), out decValue))
                        {
                            this._CorrectValues[i].DzError(string.Format("返回的值为\"{0}\"不是预期的数值类型！", objValue.ToString()));
                            blSucessfuly = false;
                        }
                        else
                        {
                            blSucessfuly = true;
                        }
                    }
                }
                if (blSucessfuly)
                    this._CorrectValues[i].SetDz(decValue);
            }
            sErr = string.Empty;
            return true;
        }
        #endregion
        #region 相关类
        public class CorrectValue
        {
            public float V = 0F;
            public float Dz = 0F;
            /// <summary>
            /// 电压是否读取成功
            /// </summary>
            public bool VSucessfully = false;
            /// <summary>
            /// 电阻是否读取成功
            /// </summary>
            public bool DzSucessfully = false;
            /// <summary>
            /// 电压错误消息，如果读取正确，则为空
            /// </summary>
            public string VErrMsg = string.Empty;
            /// <summary>
            /// 电阻错误消息，如果读取正确，则为空
            /// </summary>
            public string DzErrMsg = string.Empty;
            public CorrectValue()
            {
            }
            public void SetV(float fValue)
            {
                if (!this.VSucessfully)
                    this.VSucessfully = true;
                if (this.VErrMsg.Length > 0)
                    this.VErrMsg = string.Empty;
                this.V = fValue;
            }
            public void SetDz(float fValue)
            {
                if (!this.DzSucessfully)
                    this.DzSucessfully = true;
                if (this.DzErrMsg.Length > 0)
                    this.DzErrMsg = string.Empty;
                this.Dz = fValue;
            }
            public void VError(string sMsg)
            {
                this.VSucessfully = false;
                this.VErrMsg = sMsg;
            }
            public void DzError(string sMsg)
            {
                this.DzSucessfully = false;
                this.DzErrMsg = sMsg;
            }
        }
        #endregion
    }
    public class GrooveGongyiEntity
    {
        public short Index;
        public GrooveGongyiEntity(short iIndex)
        {
            Index = iIndex;
        }
        public decimal St_CaoVmin = 0M;
        public decimal St_CaoVmax = 0M;
        public decimal St_CaoDzmin = 0M;
        public decimal St_CaoDzmax = 0M;
        public bool St_CaoUsed = false;
        public short St_CaoDxCnt = 0;

    }
    public class OPCHelperMKBuilding : OPCHelperBase
    {
        OPCServer _Server = null;
        OPCGroups _ServerGroups = null;
        //电池组1信息
        public OPCGroup _MyGroup_Bat1 = null;
        #region 写入对象
        /// <summary>
        ///读取和写入OPC字段Asb_BatCode
        /// </summary>
        public JpsOPC.MyItemValue _Asb_BatCode = null;
        /// <summary>
        /// 写入OPC字段Asb_Code
        /// </summary>
        public JpsOPC.MyItemValue _Asb_Code = null;
        /// <summary>
        /// 读取和写入OPC字段Asb_Finished
        /// </summary>
        public JpsOPC.MyItemValue _Asb_AFinished = null;
        #endregion
        public OPCHelperMKBuilding()
        {
        }
        #region 公共函数
        public bool InitServer(out string sErr)
        {
            if(this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            if (_Server == null)
            {
                try
                {
                    this._Server = new OPCServer();
                }
                catch (Exception ex)
                {
                    sErr = "初始化MKBuilding的OPCServer出错：" + ex.Message + "(" + ex.Source + ")";
                    return false;
                }
            }
            if (this._Server.ServerState != (int)OPCServerState.OPCRunning)
            {
                try
                {
                    this._Server.Connect("KEPware.KEPServerEx.V6", "");
                }
                catch (Exception ex)
                {
                    sErr = string.Format("MKBuilding的OPCserver初始化出错：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
                //重新连接过的话重新定义组
                _ServerGroups = null;
                //重新读取opcItem
                if (this._Asb_BatCode != null)
                    this._Asb_BatCode.InitItem();
                if (this._Asb_Code != null)
                    this._Asb_Code.InitItem();
                if (this._Asb_AFinished != null)
                    this._Asb_AFinished.InitItem();
            }
            //添加组
            if (_ServerGroups == null)
            {
                _ServerGroups = this._Server.OPCGroups;
                _ServerGroups.DefaultGroupIsActive = true; //设置组集合默认为激活状态
                //下面这个几个暂时不设定，看看是否有异常，因为DefaultGroupUpdateRate这个值很关键，估计是与写入和读取的频率相关了，应该设置到某个单一的节点为好。
                _ServerGroups.DefaultGroupDeadband = 0;    //设置死区
                _ServerGroups.DefaultGroupUpdateRate = 200;//设置更新频率
                try
                {
                    //电池组1
                    _MyGroup_Bat1 = _ServerGroups.Add("MKBuildingGroup1");
                    _MyGroup_Bat1.UpdateRate = 100; //刷新频率
                    _MyGroup_Bat1.IsActive = true;
                }
                catch (Exception ex)
                {
                    sErr = string.Format("MKBuildingGroup创建各组失败：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
            }
            if (!this.InitMyItems(out sErr))
            {
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool InitMyItems(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            if (this._Asb_BatCode == null)
                _Asb_BatCode = new MyItemValue(OPCItemTitle + "Asb_BatCode");
            if (this._Asb_Code == null)
                _Asb_Code = new MyItemValue(OPCItemTitle + "Asb_Code");

            if (this._Asb_AFinished == null)
                _Asb_AFinished = new MyItemValue(OPCItemTitle + "Asb_AFinished");

            //在OPCGroup中添加IOPCItem
            if (this._MyGroup_Bat1 == null)
            {
                sErr = "初始化MKBuildingitem时失败，因为group1为空。";
                return false;
            }
            
            if (_MyGroup_Bat1.OPCItems == null)
            {
                sErr = "初始化MKBuildingitem时失败，因为group1.OPCItems为空。";
                return false;
            }
            
            //处理电池组1的
            if (!InitMyItems_AddItem(this._Asb_BatCode, this._MyGroup_Bat1, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this._Asb_Code, this._MyGroup_Bat1, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this._Asb_AFinished, this._MyGroup_Bat1, true, out sErr))
            {
                return false;
            }
            return true;
        }
        private bool InitMyItems_AddItem(MyItemValue myItem, OPCGroup targetGroup, bool saveItem, out string sErr)
        {
            if (myItem.ServerHandle <= 0)
            {
                if (this.IsDebug)
                {
                    sErr = string.Empty;
                    return true;
                }
                //此时添加Item
                _ClientHandle++;
                OPCItem item = null;
                string strTagName = myItem.TagName;
                try
                {
                    item = targetGroup.OPCItems.AddItem(strTagName, _ClientHandle);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("添加Item：{0}，出错:{1}({2})", myItem.TagName, ex.Message, ex.Source);
                    return false;
                }
                if (item == null)
                {
                    sErr = string.Format("添加Item：{0}失败，返回为空。", myItem.TagName);
                    return false;
                }
                if (item.ServerHandle <= 0)
                {
                    sErr = string.Format("添加Item：{0}失败，返回值ServerHandle为{1}。", myItem.TagName, myItem.ServerHandle);
                    return false;
                }
                myItem.ServerHandle = item.ServerHandle;
                myItem.ClientHandle = this._ClientHandle;
                if (saveItem)
                    myItem._OPCItem = item;
            }
            sErr = string.Empty;
            return true;
        }
        public bool CloseOPC(out string sErr)
        {
            sErr = "";
            if (this._Server == null) return true;
            try
            {
                this._Server.Disconnect();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
                return false;
            }
            return true;
        }

        #endregion
        #region  特殊功能函数
        public bool ReadBatCodes(out string sValue, out string sErr)
        {
            if(this.IsDebug)
            {
                sErr = string.Empty;
                sValue = JPSDebug.MKAutomationDebug.BatCodes;
                return true;
            }
            if (this._Asb_BatCode == null)
            {
                sErr = "Asb_BatCode对象还未初始化";
                sValue = string.Empty;
                return false;
            }
            else if (this._Asb_BatCode._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "Asb_BatCode对象为空，但初始化时出错：" + sErr;
                    sValue = string.Empty;
                    return false;
                }
            }
            if (this._Asb_BatCode.ServerHandle == 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "Asb_BatCode对象为0，但重新初始化时出错：" + sErr;
                    sValue = string.Empty;
                    return false;
                }
            }
            //此时有效了，直接读取值
            object objValue;
            if (!this._Asb_BatCode.ReadData(out objValue, out sErr))
            {
                sValue = string.Empty;
                return false;
            }
            if (objValue == null)
            {
                sErr = string.Format("item对象[{0}]的返回值NULL不是预期的字符型。", this._Asb_BatCode.TagName);
                sValue = string.Empty;
                return false;
            }
            sValue = objValue.ToString();
            return true;
        }
        public bool ReadFinished(out short iValue, out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                iValue = JPSDebug.MKAutomationDebug.Finished;
                return true;
            }
            if (this._Asb_AFinished == null)
            {
                sErr = "Asb_Finished对象还未初始化";
                iValue = 0;
                return false;
            }
            else if (this._Asb_AFinished._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "Asb_Finished对象为空，但初始化时出错：" + sErr;
                    iValue = 0;
                    return false;
                }
            }
            if (this._Asb_AFinished.ServerHandle == 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "Asb_Finished对象为0，但重新初始化时出错：" + sErr;
                    iValue = 0;
                    return false;
                }
            }
            //此时有效了，直接读取值
            object objValue;
            if (!this._Asb_AFinished.ReadData(out objValue, out sErr))
            {
                iValue = 0;
                return false;
            }
            if (objValue == null)
            {
                sErr = string.Format("item对象[{0}]的返回值NULL不是预期的字符型。", this._Asb_AFinished.TagName);
                iValue = 0;
                return false;
            }
            if (!short.TryParse(objValue.ToString(), out iValue))
            {
                sErr = string.Format("item对象[{0}]的返回值\"{1}\"不是预期的短整型。", this._Asb_AFinished.TagName, objValue.ToString());
                iValue = 0;
                return false;
            }
            return true;
        }
        public bool ResetFinished(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                JPSDebug.MKAutomationDebug.Finished = 2;//复位
                return true;
            }
            if (this._Asb_AFinished == null)
            {
                sErr = "Asb_Finished设置失败：opc为空！";
                return false;
            }
            else if (this._Asb_AFinished._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Asb_Finished设置失败：opcItem为空，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (this._Asb_AFinished.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Asb_Finished设置失败：opcItem的serverhandle，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (!this._Asb_AFinished.WriteData((short)2, out sErr))
            {
                sErr = string.Format("Asb_Finished设置时出错：{0}", sErr);
                return false;
            }
            return true;
        }
        public bool PlanCompleted(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                JPSDebug.MKAutomationDebug.Finished = 3;//复位
                return true;
            }
            if (this._Asb_AFinished == null)
            {
                sErr = "Asb_Finished设置失败：opc为空！";
                return false;
            }
            else if (this._Asb_AFinished._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Asb_Finished设置失败：opcItem为空，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (this._Asb_AFinished.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Asb_Finished设置失败：opcItem的serverhandle，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (!this._Asb_AFinished.WriteData((short)3, out sErr))
            {
                sErr = string.Format("Asb_Finished设置时出错：{0}", sErr);
                return false;
            }
            return true;
        }
        public bool ClearBatCodes(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "调试模式：清空电芯编码";
                JPSDebug.MKAutomationDebug.BatCodes = string.Empty;//复位
                return true;
            }
            if (this._Asb_BatCode == null)
            {
                sErr = "Asb_BatCode清空失败：opc为空！";
                return false;
            }
            else if (this._Asb_BatCode._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Asb_BatCode清空失败：opcItem为空，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (this._Asb_BatCode.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Asb_BatCode清空失败：opcItem的serverhandle，且初始化出错：{0}", sErr);
                    return false;
                }
            }
            if (!this._Asb_BatCode.WriteData(string.Empty, out sErr))
            {
                sErr = string.Format("清空Asb_BatCode时出错：{0}", sErr);
                return false;
            }
            return true;
        }
        public bool SetMkCode(string sMkCode,out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                JPSDebug.MKAutomationDebug.MKCode = sMkCode;//复位
                return true;
            }
            if (this._Asb_Code == null)
            {
                sErr = string.Format("Asb_Code值[{0}]写入失败：opc为空！", sMkCode);
                return false;
            }
            else if (this._Asb_Code._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Asb_Code值[{0}]写入失败：opcItem为空，且初始化出错：{1}", sMkCode, sErr);
                    return false;
                }
            }
            if (this._Asb_Code.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Asb_Code值[{0}]写入失败：opcItem的serverhandle，且初始化出错：{1}",sMkCode, sErr);
                    return false;
                }
            }
            if (!this._Asb_Code.WriteData(sMkCode, out sErr))
            {
                sErr = string.Format("写入Asb_Code值[{0}]时出错：{1}",sMkCode, sErr);
                return false;
            }
            return true;
        }
        #endregion
    }
    public class MyItemValue
    {
        public OPCItem _OPCItem = null;
        public MyItemValue(string sTagName)
        {
            this.TagName = sTagName;
        }
        public string Value_String = string.Empty;
        public decimal Value_Decimal = 0M;
        public float Value_Float = 0F;
        public bool Value_Bool = false;
        public short Value_Short = 0;
        public int ClientHandle = 0;
        public int ServerHandle = 0;
        public string TagName = string.Empty;
        public void InitItem()
        {
            this.ServerHandle = 0;
            this._OPCItem = null;
        }
        public bool ReadData(out object value, out string sErr)
        {
            if (this._OPCItem == null)
            {
                value = "";
                sErr = "OPCItem地址为空";
                return false;
            }
            else
            {
                object objQ;
                object objT;
                try
                {
                    this._OPCItem.Read(1, out value, out objQ, out objT);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("OPCItem[{0}]Exception:", this.TagName, ex.Message);
                    value = "";
                    return false;
                }
                if (objQ == null)
                {
                    sErr = "读取[" + this.TagName + "]的值时Quality值不是预期的192。(quality IS NULL)";
                    return false;
                }
                if (objQ.ToString() != "192")
                {
                    sErr = "读取[" + this.TagName + "]的值时的Quality值不是预期的192。(quality:" + objQ.ToString() + ")";
                    return false;
                }
                sErr = string.Empty;
                return true;
            }
        }
        public bool WriteData(object value, out string sErr)
        {
            if (this._OPCItem == null)
            {
                sErr = string.Format("OPCItem[{0}]写入失败：地址为空！", this.TagName);
                return false;
            }
            else
            {
                try
                {
                    this._OPCItem.Write(value);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("OPCItem[{0}]写入出错:{1}({2})", this.TagName, ex.Message, ex.Source);
                    return false;
                }
                sErr = string.Empty;
                return true;
            }
        }
    }
    public class OPCHelperMacJDL : OPCHelperBase
    {
        public static short Debug_sysNew = 0;
        public static short Debug_SysCompeleted = 0;
        OPCServer _Server = null;
        OPCGroups _ServerGroups = null;
        public OPCGroup _MyGroup_Jdl = null;
        
        #region 稼动率对象数据
        public JpsOPC.MyItemValue Zt_TimeEfficiency = null;
        public JpsOPC.MyItemValue Zt_PerEfficiency = null;
        #endregion
        #region 公共函数
        public bool InitServer(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (_Server == null)
            {
                try
                {
                    this._Server = new OPCServer();
                }
                catch (Exception ex)
                {
                    sErr = "稼动率OPC：初始化Server出错：" + ex.Message + "(" + ex.Source + ")";
                    return false;
                }
            }
            if (this._Server.ServerState != (int)OPCServerState.OPCRunning)
            {
                try
                {
                    this._Server.Connect("KEPware.KEPServerEx.V6", "");
                }
                catch (Exception ex)
                {
                    sErr = string.Format("GongYiOPC：server初始化出错：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
                //重新连接过的话重新定义组
                _ServerGroups = null;
                if (this.Zt_PerEfficiency != null)
                    this.Zt_PerEfficiency.InitItem();
                if (this.Zt_TimeEfficiency != null)
                    this.Zt_TimeEfficiency.InitItem();
               
            }
            //添加组
            if (_ServerGroups == null)
            {
                _ServerGroups = this._Server.OPCGroups;
                _ServerGroups.DefaultGroupIsActive = true; //设置组集合默认为激活状态
                //下面这个几个暂时不设定，看看是否有异常，因为DefaultGroupUpdateRate这个值很关键，估计是与写入和读取的频率相关了，应该设置到某个单一的节点为好。
                _ServerGroups.DefaultGroupDeadband = 0;    //设置死区
                _ServerGroups.DefaultGroupUpdateRate = 100;//设置更新频率
                try
                {
                    //电池组2
                    this._MyGroup_Jdl = _ServerGroups.Add("GrooveGongYi");
                    this._MyGroup_Jdl.UpdateRate = 200;
                    this._MyGroup_Jdl.IsActive = true;
                }
                catch (Exception ex)
                {
                    sErr = string.Format("稼动率OPC:创建各组失败：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
            }
            if (!this.InitMyItems(out sErr))
            {
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool InitMyItems(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                return true;
            }
            if (this.Zt_TimeEfficiency == null)
                Zt_TimeEfficiency = new MyItemValue(OPCItemTitle + "Zt_TimeEfficiency");
            if (this.Zt_PerEfficiency == null)
                Zt_PerEfficiency = new MyItemValue(OPCItemTitle + "Zt_PerEfficiency");
            
            if (this._MyGroup_Jdl == null)
            {
                sErr = "稼动率OPCitem初始化时失败，因为group为空。";
                return false;
            }

            if (_MyGroup_Jdl.OPCItems == null)
            {
                sErr = "稼动率OPCitem初始化时失败，因为group.OPCItems为空。";
                return false;
            }
            //处理系统标识
            if (!InitMyItems_AddItem(this.Zt_TimeEfficiency, this._MyGroup_Jdl, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Zt_PerEfficiency, this._MyGroup_Jdl, true, out sErr))
            {
                return false;
            }
            return true;
        }
        private bool InitMyItems_AddItem(MyItemValue myItem, OPCGroup targetGroup, bool saveItem, out string sErr)
        {
            if (myItem.ServerHandle <= 0)
            {
                if (this.IsDebug)
                {
                    sErr = string.Empty;
                    return true;
                }
                //此时添加Item
                _ClientHandle++;
                OPCItem item = null;
                string strTagName = myItem.TagName;
                try
                {
                    item = targetGroup.OPCItems.AddItem(strTagName, _ClientHandle);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("添加Item：{0}，出错:{1}({2})", myItem.TagName, ex.Message, ex.Source);
                    return false;
                }
                if (item == null)
                {
                    sErr = string.Format("添加Item：{0}失败，返回为空。", myItem.TagName);
                    return false;
                }
                if (item.ServerHandle <= 0)
                {
                    sErr = string.Format("添加Item：{0}失败，返回值ServerHandle为{1}。", myItem.TagName, myItem.ServerHandle);
                    return false;
                }
                myItem.ServerHandle = item.ServerHandle;
                myItem.ClientHandle = this._ClientHandle;
                if (saveItem)
                    myItem._OPCItem = item;
            }
            sErr = string.Empty;
            return true;
        }
        public bool CloseOPC(out string sErr)
        {
            sErr = "";
            if (this._Server == null) return true;
            try
            {
                this._Server.Disconnect();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
                return false;
            }
            return true;
        }
        #endregion
        #region 特殊功能函数
        public bool ReadJdl(out double dbTime,out double dbPer, out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = "";
                dbTime = 0D;
                dbPer = 0D;
                return true;
            }
            if (this.Zt_PerEfficiency == null)
            {
                sErr = "Zt_PerEfficiency读取失败：opcITEM为空！";
                dbTime = 0D;
                dbPer = 0D;
                return false;
            }
            if (this.Zt_PerEfficiency._OPCItem==null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Zt_PerEfficiency读取失败：opcItem为空，且初始化出错：{0}", sErr);
                    dbTime = 0D;
                    dbPer = 0D;
                    return false;
                }
            }
            if (this.Zt_PerEfficiency == null)
            {
                sErr = "Zt_PerEfficiency读取失败：opcITEM为空！";
                dbTime = 0D;
                dbPer = 0D;
                return false;
            }
            if (this.Zt_PerEfficiency._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = string.Format("Zt_PerEfficiency读取失败：opcItem为空，且初始化出错：{0}", sErr);
                    dbTime = 0D;
                    dbPer = 0D;
                    return false;
                }
            }
            //读取数据
            object objValue;
            if (!this.Zt_TimeEfficiency.ReadData(out objValue, out sErr))
            {
                sErr = string.Format("Zt_TimeEfficiency读取时出错：{0}", sErr);
                dbTime = 0D;
                dbPer = 0D;
                return false;
            }
            if (objValue == null)
            {
                sErr = "Zt_TimeEfficiency读取失败，返回为NULL";
                dbTime = 0D;
                dbPer = 0D;
                return false;
            }
            if (objValue.ToString().Length == 0)
            {
                sErr = "Zt_TimeEfficiency读取失败，返回为空字符";
                dbTime = 0D;
                dbPer = 0D;
                return false;
            }
            if (!double.TryParse(objValue.ToString(), out dbTime))
            {
                sErr = string.Format("Zt_TimeEfficiency读取失败，返回值\"{0}\"不是预期的整型。", objValue.ToString());
                dbTime = 0D;
                dbPer = 0D;
            }

            if (!this.Zt_PerEfficiency.ReadData(out objValue, out sErr))
            {
                sErr = string.Format("Zt_PerEfficiency读取时出错：{0}", sErr);
                dbTime = 0D;
                dbPer = 0D;
                return false;
            }
            if (objValue == null)
            {
                sErr = "Zt_PerEfficiency读取失败，返回为NULL";
                dbTime = 0D;
                dbPer = 0D;
                return false;
            }
            if (objValue.ToString().Length == 0)
            {
                sErr = "Zt_PerEfficiency读取失败，返回为空字符";
                dbTime = 0D;
                dbPer = 0D;
                return false;
            }
            if (!double.TryParse(objValue.ToString(), out dbPer))
            {
                sErr = string.Format("Zt_PerEfficiency读取失败，返回值\"{0}\"不是预期的整型。", objValue.ToString());
                dbTime = 0D;
                dbPer = 0D;
            }
            return true;
        }
        #endregion
    }
    public delegate void AsyncWriteCompleteCallback(int TransactionID, int NumItems, ref Array ClientHandles, ref Array Errors);
    public delegate void ShowMsgCallback(string sMsg);
}

