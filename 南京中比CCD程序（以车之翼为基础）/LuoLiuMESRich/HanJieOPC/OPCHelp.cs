using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPCAutomation;

namespace HanJieOPC
{
    public class OPCHelperBase
    {
        public const int TransIDMainform = 2012;
        public const int TransIDSetttings = 2013;
        public string OPCItemTitle = "";
        public int _ClientHandle = 0;
        public bool IsDebug = false;
        public bool InitSucessfully = false;
    }
    #region 调试
    public class Debug
    {
        public static string MKCode = string.Empty;
        public static string MKCode2 = string.Empty;
        public static short PtCnt = 0;
        /// <summary>
        /// 是否成功写入了
        /// </summary>
        public static bool Writen = false;
        public static int Pindex = 0;
        public static float A = 0F;
        public static float V = 0F;
        public static short Arg = 0;


        public static int Pindex2 = 0;
        public static float A2 = 0F;
        public static float V2 = 0F;
        public static short Arg2 = 0;
    }
    public class PointSetDebug
    {
        public static short PIndex = 0;
        public static short Read_Doing = 0;
        public static short LP_Cnt = 0;
        public static short RP_Cnt = 0;
        //工艺参数
        public static bool P1_Work = false;
        public static int P1_Type = 0;
        public static int P1_AY = 0;
        public static int P1_AZ = 0;
        public static int P1_BY = 0;
        public static int P1_BZ = 0;
        public static bool P2_Work = false;
        public static int P2_Type = 0;
        public static int P2_AY = 0;
        public static int P2_AZ = 0;
        public static int P2_BY = 0;
        public static int P2_BZ = 0;
        public static bool P3_Work = false;
        public static int P3_Type = 0;
        public static int P3_AY = 0;
        public static int P3_AZ = 0;
        public static int P3_BY = 0;
        public static int P3_BZ = 0;
        public static bool P4_Work = false;
        public static int P4_Type = 0;
        public static int P4_AY = 0;
        public static int P4_AZ = 0;
        public static int P4_BY = 0;
        public static int P4_BZ = 0;
        //补偿
        public static int BC_A1 = 0;
        public static int BC_A2 = 0;
        public static int BC_A3 = 0;
        public static int BC_A4 = 0;
        public static int BC_A5 = 0;
        public static int BC_A6 = 0;
        public static int BC_B1 = 0;
        public static int BC_B2 = 0;
        public static int BC_B3 = 0;
        public static int BC_B4 = 0;
        public static int BC_B5 = 0;
        public static int BC_B6 = 0;

    }
    #endregion
    public class OPCHelperA : OPCHelperBase
    {
        public OPCHelperA(string sConnectTitle)
        {
            this.OPCItemTitle = sConnectTitle;
        }
        public event ShowMsgCallback LogNotice = null;
        public event ShowMsgCallback ErrorNotice = null;
        OPCServer _Server = null;
        OPCGroups _ServerGroups = null;
        public OPCGroup _MyGroup_HanjieA = null;
        public OPCGroup _MyGroup_Cs = null;
        public OPCGroup _MyGroup_HanjieErr = null;
        //获取槽号
        public HanJieOPC.MyItemValue Rt1_MkCode1 = null;
        public HanJieOPC.MyItemValue Rt1_MkCode2 = null;
        public HanJieOPC.MyItemValue Rt1_MkCode3 = null;
        public HanJieOPC.MyItemValue Rt1_MkCode4 = null;
        public HanJieOPC.MyItemValue Rt1_MkCode5 = null;
        public HanJieOPC.MyItemValue Rt1_MkCode6 = null;
        public HanJieOPC.MyItemValue Rt1_MkCode7 = null;
        public HanJieOPC.MyItemValue Rt1_MkCode8 = null;
        public HanJieOPC.MyItemValue Rt1_MkCode9 = null;
        public HanJieOPC.MyItemValue Rt1_MkCodeA = null;
        public HanJieOPC.MyItemValue Rt2_MkCode1 = null;
        public HanJieOPC.MyItemValue Rt2_MkCode2 = null;
        public HanJieOPC.MyItemValue Rt2_MkCode3 = null;
        public HanJieOPC.MyItemValue Rt2_MkCode4 = null;
        public HanJieOPC.MyItemValue Rt2_MkCode5 = null;
        public HanJieOPC.MyItemValue Rt2_MkCode6 = null;
        public HanJieOPC.MyItemValue Rt2_MkCode7 = null;
        public HanJieOPC.MyItemValue Rt2_MkCode8 = null;
        public HanJieOPC.MyItemValue Rt2_MkCode9 = null;
        public HanJieOPC.MyItemValue Rt2_MkCodeA = null;

        public HanJieOPC.MyItemValue Rt_PointCnt = null;//焊接点个数
        public HanJieOPC.MyItemValue At_MesErr = null;//错误消息
        public HanJieOPC.MyItemValue Pt_V1 = null;
        public HanJieOPC.MyItemValue Pt_A1 = null;
        public HanJieOPC.MyItemValue Pt_PeiFang1 = null;
        public HanJieOPC.MyItemValue Pt_CurrentPoint1 = null;
        public HanJieOPC.MyItemValue Pt_V2 = null;
        public HanJieOPC.MyItemValue Pt_A2 = null;
        public HanJieOPC.MyItemValue Pt_PeiFang2 = null;
        public HanJieOPC.MyItemValue Pt_CurrentPoint2 = null;
        //后期新增的右边点位
        public HanJieOPC.MyItemValue RPt_V1 = null;
        public HanJieOPC.MyItemValue RPt_A1 = null;
        public HanJieOPC.MyItemValue RPt_PeiFang1 = null;
        public HanJieOPC.MyItemValue RPt_V2 = null;
        public HanJieOPC.MyItemValue RPt_A2 = null;
        public HanJieOPC.MyItemValue RPt_PeiFang2 = null;
        
        #region 公共函数
        public bool InitServer(out string sErr)
        {
            if (this.IsDebug)
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
                    sErr = "OPC：初始化Server出错：" + ex.Message + "(" + ex.Source + ")";
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
                if (this.Rt1_MkCode1 != null)
                    this.Rt1_MkCode1.InitItem();
                if (this.Rt1_MkCode2 != null)
                    this.Rt1_MkCode2.InitItem();
                if (this.Rt1_MkCode3 != null)
                    this.Rt1_MkCode3.InitItem();
                if (this.Rt1_MkCode4 != null)
                    this.Rt1_MkCode4.InitItem();
                if (this.Rt1_MkCode5 != null)
                    this.Rt1_MkCode5.InitItem();
                if (this.Rt1_MkCode6 != null)
                    this.Rt1_MkCode6.InitItem();
                if (this.Rt1_MkCode7 != null)
                    this.Rt1_MkCode7.InitItem();
                if (this.Rt1_MkCode8 != null)
                    this.Rt1_MkCode8.InitItem();
                if (this.Rt1_MkCode9 != null)
                    this.Rt1_MkCode9.InitItem();
                if (this.Rt1_MkCodeA != null)
                    this.Rt1_MkCodeA.InitItem();
                
                if (this.Rt2_MkCode1 != null)
                    this.Rt2_MkCode1.InitItem();
                if (this.Rt2_MkCode2 != null)
                    this.Rt2_MkCode2.InitItem();
                if (this.Rt2_MkCode3 != null)
                    this.Rt2_MkCode3.InitItem();
                if (this.Rt2_MkCode4 != null)
                    this.Rt2_MkCode4.InitItem();
                if (this.Rt2_MkCode5 != null)
                    this.Rt2_MkCode5.InitItem();
                if (this.Rt2_MkCode6 != null)
                    this.Rt2_MkCode6.InitItem();
                if (this.Rt2_MkCode7 != null)
                    this.Rt2_MkCode7.InitItem();
                if (this.Rt2_MkCode8 != null)
                    this.Rt2_MkCode8.InitItem();
                if (this.Rt2_MkCode9 != null)
                    this.Rt2_MkCode9.InitItem();
                if (this.Rt2_MkCodeA != null)
                    this.Rt2_MkCodeA.InitItem();
                

                if (this.Rt_PointCnt != null)
                    this.Rt_PointCnt.InitItem();
                if (this.At_MesErr != null)
                    this.At_MesErr.InitItem();
                if (this.Pt_V1 != null)
                    this.Pt_V1.InitItem();
                if (this.Pt_A1 != null)
                    this.Pt_A1.InitItem();
                if (this.Pt_PeiFang1 != null)
                    this.Pt_PeiFang1.InitItem();
                if (this.Pt_CurrentPoint1 != null)
                    this.Pt_CurrentPoint1.InitItem();
                if (this.Pt_V2 != null)
                    this.Pt_V2.InitItem();
                if (this.Pt_A2 != null)
                    this.Pt_A2.InitItem();
                if (this.Pt_PeiFang2 != null)
                    this.Pt_PeiFang2.InitItem();
                if (this.Pt_CurrentPoint2 != null)
                    this.Pt_CurrentPoint2.InitItem();
                //后期新增的右边点位
                if (this.RPt_V1 != null)
                    this.RPt_V1.InitItem();
                if (this.RPt_A1 != null)
                    this.RPt_A1.InitItem();
                if (this.RPt_PeiFang1 != null)
                    this.RPt_PeiFang1.InitItem();
                if (this.RPt_V2 != null)
                    this.RPt_V2.InitItem();
                if (this.RPt_A2 != null)
                    this.RPt_A2.InitItem();
                if (this.RPt_PeiFang2 != null)
                    this.RPt_PeiFang2.InitItem();

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
                    this._MyGroup_HanjieA = _ServerGroups.Add("jpsHanjieGroupA");
                    this._MyGroup_HanjieA.UpdateRate = 100;
                    this._MyGroup_HanjieA.IsActive = true;

                    //this._MyGroup_Cs = _ServerGroups.Add("_MyGroup_Cs");
                    //this._MyGroup_Cs.UpdateRate = 100;
                    //this._MyGroup_Cs.IsActive = true;

                    this._MyGroup_HanjieErr = _ServerGroups.Add("jpsHanjieGroupMesErr");
                    this._MyGroup_HanjieErr.UpdateRate = 500;
                    this._MyGroup_HanjieErr.IsActive = true;
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
            if (this.Rt1_MkCode1 == null)
                Rt1_MkCode1 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt1_MkCode1");
            if (this.Rt1_MkCode2 == null)
                Rt1_MkCode2 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt1_MkCode2");
            if (this.Rt1_MkCode3 == null)
                Rt1_MkCode3 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt1_MkCode3");
            if (this.Rt1_MkCode4 == null)
                Rt1_MkCode4 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt1_MkCode4");
            if (this.Rt1_MkCode5 == null)
                Rt1_MkCode5 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt1_MkCode5");
            if (this.Rt1_MkCode6 == null)
                Rt1_MkCode6 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt1_MkCode6");
            if (this.Rt1_MkCode7 == null)
                Rt1_MkCode7 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt1_MkCode7");
            if (this.Rt1_MkCode8 == null)
                Rt1_MkCode8 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt1_MkCode8");
            if (this.Rt1_MkCode9 == null)
                Rt1_MkCode9 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt1_MkCode9");
            if (this.Rt1_MkCodeA == null)
                Rt1_MkCodeA = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt1_MkCodeA");
            if (this.Rt2_MkCode1 == null)
                Rt2_MkCode1 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt2_MkCode1");
            if (this.Rt2_MkCode2 == null)
                Rt2_MkCode2 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt2_MkCode2");
            if (this.Rt2_MkCode3 == null)
                Rt2_MkCode3 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt2_MkCode3");
            if (this.Rt2_MkCode4 == null)
                Rt2_MkCode4 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt2_MkCode4");
            if (this.Rt2_MkCode5 == null)
                Rt2_MkCode5 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt2_MkCode5");
            if (this.Rt2_MkCode6 == null)
                Rt2_MkCode6 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt2_MkCode6");
            if (this.Rt2_MkCode7 == null)
                Rt2_MkCode7 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt2_MkCode7");
            if (this.Rt2_MkCode8 == null)
                Rt2_MkCode8 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt2_MkCode8");
            if (this.Rt2_MkCode9 == null)
                Rt2_MkCode9 = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt2_MkCode9");
            if (this.Rt2_MkCodeA == null)
                Rt2_MkCodeA = new MyItemValue(DataTypes.String, OPCItemTitle + "Rt2_MkCodeA");

            if (this.Rt_PointCnt == null)
                Rt_PointCnt = new MyItemValue(DataTypes.Int16, OPCItemTitle + "Rt_PointCnt");
            if (this.At_MesErr == null)
                At_MesErr = new MyItemValue(DataTypes.Bool, OPCItemTitle + "At_MesErr");

            if (this.Pt_V1 == null)
                Pt_V1 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "Pt_V1");
            if (this.Pt_A1 == null)
                Pt_A1 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "Pt_A1");
            if (this.Pt_PeiFang1 == null)
                Pt_PeiFang1 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "Pt_PeiFang1");
            if (this.Pt_CurrentPoint1 == null)
                Pt_CurrentPoint1 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "Pt_CurrentPoint1");
            if (this.Pt_V2 == null)
                Pt_V2 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "Pt_V2");
            if (this.Pt_A2 == null)
                Pt_A2 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "Pt_A2");
            if (this.Pt_PeiFang2 == null)
                Pt_PeiFang2 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "Pt_PeiFang2");
            if (this.Pt_CurrentPoint2 == null)
                Pt_CurrentPoint2 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "Pt_CurrentPoint2");
            ///右边点位
            ///
            if (this.RPt_V1 == null)
                RPt_V1 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "RPt_V1");
            if (this.RPt_A1 == null)
                RPt_A1 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "RPt_A1");
            if (this.RPt_PeiFang1 == null)
                RPt_PeiFang1 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "RPt_PeiFang1");
            if (this.RPt_V2 == null)
                RPt_V2 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "RPt_V2");
            if (this.RPt_A2 == null)
                RPt_A2 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "RPt_A2");
            if (this.RPt_PeiFang2 == null)
                RPt_PeiFang2 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "RPt_PeiFang2");



            if (this._MyGroup_HanjieA == null)
            {
                sErr = "HanjieA组添加item时失败，因为group为空。";
                return false;
            }
            if (_MyGroup_HanjieA.OPCItems == null)
            {
                sErr = "HanjieA组添加item时失败，因为group.Items为空。";
                return false;
            }


            //if (this._MyGroup_Cs == null)
            //{
            //    sErr = "Hanjie参数组添加item时失败，因为group为空。";
            //    return false;
            //}
            //if (_MyGroup_Cs.OPCItems == null)
            //{
            //    sErr = "Hanjie参数组添加item时失败，因为group.Items为空。";
            //    return false;
            //}

            //处理标识
            if (!InitMyItems_AddItem(this.Rt1_MkCode1, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt1_MkCode2, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt1_MkCode3, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt1_MkCode4, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt1_MkCode5, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt1_MkCode6, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt1_MkCode7, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt1_MkCode8, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt1_MkCode9, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt1_MkCodeA, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }
            

            if (!InitMyItems_AddItem(this.Rt2_MkCode1, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt2_MkCode2, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt2_MkCode3, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt2_MkCode4, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Rt2_MkCode5, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }


            if (!InitMyItems_AddItem(this.Rt2_MkCode6, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }


            if (!InitMyItems_AddItem(this.Rt2_MkCode7, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }


            if (!InitMyItems_AddItem(this.Rt2_MkCode8, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }


            if (!InitMyItems_AddItem(this.Rt2_MkCode9, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }


            if (!InitMyItems_AddItem(this.Rt2_MkCodeA, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }
            

            if (!InitMyItems_AddItem(this.Rt_PointCnt, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.At_MesErr, this._MyGroup_HanjieErr, true, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Pt_V1, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Pt_A1, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Pt_PeiFang1, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Pt_CurrentPoint1, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Pt_V2, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Pt_A2, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Pt_PeiFang2, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.Pt_CurrentPoint2, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }
            //右边点位
            if (!InitMyItems_AddItem(this.RPt_V1, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.RPt_A1, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.RPt_PeiFang1, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.RPt_V2, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.RPt_A2, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.RPt_PeiFang2, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }
            return true;
        }
        private bool InitMyItems_AddItem(MyItemValue myItem, OPCGroup targetGroup, bool saveItem, out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
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
        public bool ReadMKCode(DianHanDataEntity data,out string sErr)
        {
            this.ShowLogAsyn("开始读取点焊机所有数据");
            if (this.IsDebug)
            {
                this.ShowLogAsyn("OPCHelperA当前为Debug模式");
                data.Rt_MkCode = Debug.MKCode;
                data.Rt_MkCode2 = Debug.MKCode2;
                data.Pt_CurrentPoint1 = (short)Debug.Pindex;
                data.Pt_CurrentPoint2 = (short)Debug.Pindex2;
                data.Pt_PeiFang1 = Debug.Arg;
                data.Pt_PeiFang2 = Debug.Arg2;
                data.Pt_A1 = (decimal)Debug.A;
                data.Pt_A2 = (decimal)Debug.A2;
                data.Pt_V1 = (decimal)Debug.V;
                data.Pt_V2 = (decimal)Debug.V2;
                data.Rt_PointCnt = Debug.PtCnt;
                sErr = string.Empty;
                return true;
            }
            Array values = null;
            #region serverHandles
            Array serverHandles = new int[36] { 0
               , this.Rt1_MkCode1.ServerHandle
               , this.Rt1_MkCode2.ServerHandle
               , this.Rt1_MkCode3.ServerHandle
               , this.Rt1_MkCode4.ServerHandle
               , this.Rt1_MkCode5.ServerHandle
               , this.Rt1_MkCode6.ServerHandle
               , this.Rt1_MkCode7.ServerHandle
               , this.Rt1_MkCode8.ServerHandle
               , this.Rt1_MkCode9.ServerHandle
               , this.Rt1_MkCodeA.ServerHandle
               , this.Rt2_MkCode1.ServerHandle
               , this.Rt2_MkCode2.ServerHandle
               , this.Rt2_MkCode3.ServerHandle
               , this.Rt2_MkCode4.ServerHandle
               , this.Rt2_MkCode5.ServerHandle
               , this.Rt2_MkCode6.ServerHandle
               , this.Rt2_MkCode7.ServerHandle
               , this.Rt2_MkCode8.ServerHandle
               , this.Rt2_MkCode9.ServerHandle
               , this.Rt2_MkCodeA.ServerHandle
                , this.Rt_PointCnt.ServerHandle
                , this.Pt_V1.ServerHandle
                , this.Pt_A1.ServerHandle
                , this.Pt_PeiFang1.ServerHandle
                , this.Pt_CurrentPoint1.ServerHandle
                , this.Pt_V2.ServerHandle
                , this.Pt_A2.ServerHandle
                , this.Pt_PeiFang2.ServerHandle
                , this.Pt_CurrentPoint2.ServerHandle
                , this.RPt_V1.ServerHandle
                , this.RPt_A1.ServerHandle
                , this.RPt_PeiFang1.ServerHandle
                , this.RPt_V2.ServerHandle
                , this.RPt_A2.ServerHandle
                , this.RPt_PeiFang2.ServerHandle
            };
            #endregion
            object objQ;
            object objT;
            Array errors;
            try
            {
                this._MyGroup_HanjieA.SyncRead(1, 35, ref serverHandles, out values, out errors, out objQ, out objT);
            }
            catch (Exception ex)
            {
                sErr = string.Format("GroupHanjieA读取出错01：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            this.ShowLogAsyn("GroupHanjieA的Read已经执行，开始分析返回数据。");
            if (values == null)
            {
                sErr = "GroupHanjieA读取出错02:values为空！";
                return false;
            }
            if (values.Length != 35)
            {
                sErr = string.Format("GroupHanjieA读取出错03:values长度为{0}，不是预期的2！", values.Length);
                return false;
            }
            Array arrQ = objQ as Array;
            if (arrQ == null)
            {
                sErr = "GroupHanjieA读取出错04:qualitys为空！";
                return false;
            }
            if (arrQ.Length != 35)
            {
                sErr = string.Format("GroupHanjieA读取出错05:qualitys长度为{0}，不是预期的2！", values.Length);
                return false;
            }
            this.ShowLogAsyn("GroupHanjieA的Read结果长度分析无误，开始分析数据格式。");
            object objValue;
            short iValue;
            decimal decValue;
            int iIndex = 1;
            string sTag;
            int R1Code1, R1Code2, R1Code3, R1Code4, R1Code5, R1Code6, R1Code7, R1Code8, R1Code9, R1CodeA;
            int R2Code1, R2Code2, R2Code3, R2Code4, R2Code5, R2Code6, R2Code7, R2Code8, R2Code9, R2CodeA;
            //Rt1_MkCode1
            sTag = "模块编号1_1";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R1Code1, out sErr)) return false;
            //Rt1_MkCode2
            iIndex++;
            sTag = "模块编号1_2";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R1Code2, out sErr)) return false;
            //Rt1_MkCode3
            iIndex++;
            sTag = "模块编号1_3";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R1Code3, out sErr)) return false;
            //Rt1_MkCode4
            iIndex++;
            sTag = "模块编号1_4";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R1Code4, out sErr)) return false;
            
            //Rt2_MkCode1
            iIndex++;
            sTag = "模块编号1_5";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R1Code5, out sErr)) return false;

            //Rt2_MkCode1
            iIndex++;
            sTag = "模块编号1_6";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R1Code6, out sErr)) return false;


            //Rt2_MkCode1
            iIndex++;
            sTag = "模块编号1_7";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R1Code7, out sErr)) return false;

            //Rt2_MkCode1
            iIndex++;
            sTag = "模块编号1_8";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R1Code8, out sErr)) return false;

            //Rt2_MkCode1
            iIndex++;
            sTag = "模块编号1_9";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R1Code9, out sErr)) return false;

            //Rt2_MkCode1
            iIndex++;
            sTag = "模块编号1_A";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R1CodeA, out sErr)) return false;
            data.Rt_MkCode = this.GetCode(R1Code1, R1Code2, R1Code3, R1Code4, R1Code5, R1Code6, R1Code7, R1Code8, R1Code9, R1CodeA);
            this.ShowLogAsyn(string.Format("读取到模块1编号为：{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}，解析后的值为：{10}"
                , R1Code1, R1Code2, R1Code3, R1Code4, R1Code5, R1Code6, R1Code7, R1Code8, R1Code9, R1CodeA, data.Rt_MkCode));
            //Rt2_MkCode1
            iIndex++;
            sTag = "模块编号2_1";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code1, out sErr)) return false;
            //Rt2_MkCode2
            iIndex++;
            sTag = "模块编号2_2";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code2, out sErr)) return false;
            //Rt2_MkCode3
            iIndex++;
            sTag = "模块编号2_3";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code3, out sErr)) return false;
            //Rt2_MkCode4
            iIndex++;
            sTag = "模块编号2_4";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code4, out sErr)) return false;
            //Rt2_MkCode5
            iIndex++;
            sTag = "模块编号2_5";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code5, out sErr)) return false;
            //Rt2_MkCode6
            iIndex++;
            sTag = "模块编号2_6";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code6, out sErr)) return false;
            //Rt2_MkCode7
            iIndex++;
            sTag = "模块编号2_7";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code7, out sErr)) return false;
            //Rt2_MkCode8
            iIndex++;
            sTag = "模块编号2_8";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code8, out sErr)) return false;
            //Rt2_MkCode9
            iIndex++;
            sTag = "模块编号2_9";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code9, out sErr)) return false;
            //Rt2_MkCode9
            iIndex++;
            sTag = "模块编号2_A";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2CodeA, out sErr)) return false;
            data.Rt_MkCode2 = this.GetCode(R2Code1, R2Code2, R2Code3, R2Code4, R2Code5, R2Code6, R2Code7, R2Code8, R2Code9, R2CodeA);
            this.ShowLogAsyn(string.Format("读取到模块2编号为：{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}，解析后的值为：{10}"
                , R2Code1, R2Code2, R2Code3, R2Code4, R2Code5, R2Code6, R2Code7, R2Code8, R2Code9, R2CodeA, data.Rt_MkCode2));
            //Rt_PointCnt
            iIndex++;
            sTag = "焊点总个数";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            data.Rt_PointCnt = iValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Rt_PointCnt));

            //Pt_V1
            iIndex++;
            sTag = "焊点1的电压";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.Pt_V1 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_V1));

            //Pt_A1
            iIndex++;
            sTag = "焊点1的电流";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.Pt_A1 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_A1));

            //Pt_PeiFang1
            iIndex++;
            sTag = "焊点1的规范";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            data.Pt_PeiFang1 = iValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_PeiFang1));

            //Pt_CurrentPoint1
            iIndex++;
            sTag = "焊点1的序号";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            //data.Pt_CurrentPoint1 = (short)(iValue + 1);//由于PLC中是从0开始计数的，所以这里直接加上1，modified by jiangpengsong 2019-10-17
            data.Pt_CurrentPoint1 = iValue;//以上不用改了jiangpengsong 2019-10-17
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_CurrentPoint1));


            //Pt_V2
            iIndex++;
            sTag = "焊点2的电压";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.Pt_V2 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_V2));

            //Pt_A2
            iIndex++;
            sTag = "焊点2的电流";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.Pt_A2 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_A2));

            //Pt_PeiFang2
            iIndex++;
            sTag = "焊点2的规范";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            data.Pt_PeiFang2 = iValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_PeiFang2));

            //Pt_CurrentPoint2
            iIndex++;
            sTag = "焊点2的序号";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            //data.Pt_CurrentPoint2 = (short)(iValue + 1);//由于PLC中是从0开始计数的，所以这里直接加上1，modified by jiangpengsong 2019-10-17
            data.Pt_CurrentPoint2 = iValue;//以上不用改了
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_CurrentPoint2));

            //RPt_V1
            iIndex++;
            sTag = "焊点1的右边电压值";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.RPt_V1 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.RPt_V1));

            //RPt_A1
            iIndex++;
            sTag = "焊点1的右边电流值";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.RPt_A1 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.RPt_A1));

            //RPt_PeiFang1
            iIndex++;
            sTag = "焊点1的右边规范值";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            data.RPt_PeiFang1 = iValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.RPt_PeiFang1));

            //RPt_V2
            iIndex++;
            sTag = "焊点2的右边电压值";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.RPt_V2 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.RPt_V2));

            //RPt_A2
            iIndex++;
            sTag = "焊点2的右边电流值";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.RPt_A2 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.RPt_A2));

            //RPt_PeiFang2
            iIndex++;
            sTag = "焊点2的右边规范值";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            data.RPt_PeiFang2 = iValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.RPt_PeiFang2));
            return true;
        }
        public bool ReadAV(DianHanDataEntity data, out string sErr)
        {
            this.ShowLogAsyn("开始读取点焊机所有数据");
            if (this.IsDebug)
            {
                this.ShowLogAsyn("OPCHelperA当前为Debug模式");
                data.Rt_MkCode = Debug.MKCode;
                data.Rt_MkCode2 = Debug.MKCode2;
                data.Pt_CurrentPoint1 = (short)Debug.Pindex;
                data.Pt_CurrentPoint2 = (short)Debug.Pindex2;
                data.Pt_PeiFang1 = Debug.Arg;
                data.Pt_PeiFang2 = Debug.Arg2;
                data.Pt_A1 = (decimal)Debug.A;
                data.Pt_A2 = (decimal)Debug.A2;
                data.Pt_V1 = (decimal)Debug.V;
                data.Pt_V2 = (decimal)Debug.V2;
                data.Rt_PointCnt = Debug.PtCnt;
                sErr = string.Empty;
                return true;
            }
            Array values = null;
            #region serverHandles
            Array serverHandles = new int[24] { 0
               , this.Rt1_MkCode1.ServerHandle
               , this.Rt1_MkCode2.ServerHandle
               , this.Rt1_MkCode3.ServerHandle
               , this.Rt1_MkCode4.ServerHandle
               , this.Rt2_MkCode1.ServerHandle
               , this.Rt2_MkCode2.ServerHandle
               , this.Rt2_MkCode3.ServerHandle
               , this.Rt2_MkCode4.ServerHandle
                , this.Rt_PointCnt.ServerHandle
                , this.Pt_V1.ServerHandle
                , this.Pt_A1.ServerHandle
                , this.Pt_PeiFang1.ServerHandle
                , this.Pt_CurrentPoint1.ServerHandle
                , this.Pt_V2.ServerHandle
                , this.Pt_A2.ServerHandle
                , this.Pt_PeiFang2.ServerHandle
                , this.Pt_CurrentPoint2.ServerHandle
                , this.RPt_V1.ServerHandle
                , this.RPt_A1.ServerHandle
                , this.RPt_PeiFang1.ServerHandle
                , this.RPt_V2.ServerHandle
                , this.RPt_A2.ServerHandle
                , this.RPt_PeiFang2.ServerHandle

            };
            #endregion
            object objQ;
            object objT;
            Array errors;
            try
            {
                this._MyGroup_HanjieA.SyncRead(1, 23, ref serverHandles, out values, out errors, out objQ, out objT);
            }
            catch (Exception ex)
            {
                sErr = string.Format("GroupHanjieA读取出错01：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            this.ShowLogAsyn("GroupHanjieA的Read已经执行，开始分析返回数据。");
            if (values == null)
            {
                sErr = "GroupHanjieA读取出错02:values为空！";
                return false;
            }
            if (values.Length != 23)
            {
                sErr = string.Format("GroupHanjieA读取出错03:values长度为{0}，不是预期的2！", values.Length);
                return false;
            }
            Array arrQ = objQ as Array;
            if (arrQ == null)
            {
                sErr = "GroupHanjieA读取出错04:qualitys为空！";
                return false;
            }
            if (arrQ.Length != 23)
            {
                sErr = string.Format("GroupHanjieA读取出错05:qualitys长度为{0}，不是预期的2！", values.Length);
                return false;
            }
            this.ShowLogAsyn("GroupHanjieA的Read结果长度分析无误，开始分析数据格式。");
            object objValue;
            short iValue;
            decimal decValue;
            int iIndex = 1;
            string sTag;
            int R1Code1, R1Code2, R1Code3, R1Code4;
            int R2Code1, R2Code2, R2Code3, R2Code4;
            //Rt1_MkCode1
            sTag = "模块编号1_1";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code1, out sErr)) return false;
            //Rt1_MkCode2
            iIndex++;
            sTag = "模块编号1_2";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code2, out sErr)) return false;
            //Rt1_MkCode3
            iIndex++;
            sTag = "模块编号1_3";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code3, out sErr)) return false;
            //Rt1_MkCode4
            iIndex++;
            sTag = "模块编号1_4";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code4, out sErr)) return false;
           // data.Rt_MkCode = this.GetCode(R2Code1, R2Code2, R2Code3, R2Code4, R2Code4, R2Code5, R2Code6, R2Code7, R2Code8, R2Code9, R2CodeA);
            this.ShowLogAsyn(string.Format("读取到模块1编号为：{0},{1},{2},{3}，解析后的值为：{4}", R2Code1, R2Code2, R2Code3, R2Code4, data.Rt_MkCode));
            //Rt2_MkCode1
            iIndex++;
            sTag = "模块编号2_1";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code1, out sErr)) return false;
            //Rt2_MkCode2
            iIndex++;
            sTag = "模块编号2_2";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code2, out sErr)) return false;
            //Rt2_MkCode3
            iIndex++;
            sTag = "模块编号2_3";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code3, out sErr)) return false;
            //Rt2_MkCode4
            iIndex++;
            sTag = "模块编号2_4";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.Getint32Value(sTag, objValue, objQ, out R2Code4, out sErr)) return false;
           // data.Rt_MkCode2 = this.GetCode(R2Code1, R2Code2, R2Code3, R2Code4);
            this.ShowLogAsyn(string.Format("读取到模块2编号为：{0},{1},{2},{3}，解析后的值为：{4}", R2Code1, R2Code2, R2Code3, R2Code4, data.Rt_MkCode2));
            //Rt_PointCnt
            iIndex++;
            sTag = "焊点总个数";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            data.Rt_PointCnt = iValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Rt_PointCnt));

            //Pt_V1
            iIndex++;
            sTag = "焊点1的电压";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.Pt_V1 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_V1));

            //Pt_A1
            iIndex++;
            sTag = "焊点1的电流";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.Pt_A1 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_A1));

            //Pt_PeiFang1
            iIndex++;
            sTag = "焊点1的规范";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            data.Pt_PeiFang1 = iValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_PeiFang1));

            //Pt_CurrentPoint1
            iIndex++;
            sTag = "焊点1的序号";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            data.Pt_CurrentPoint1 = iValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_CurrentPoint1));


            //Pt_V2
            iIndex++;
            sTag = "焊点2的电压";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.Pt_V2 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_V2));

            //Pt_A2
            iIndex++;
            sTag = "焊点2的电流";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.Pt_A2 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_A2));

            //Pt_PeiFang2
            iIndex++;
            sTag = "焊点2的规范";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            data.Pt_PeiFang2 = iValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_PeiFang2));

            //Pt_CurrentPoint2
            iIndex++;
            sTag = "焊点2的序号";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            data.Pt_CurrentPoint2 = iValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.Pt_CurrentPoint2));

            //RPt_V1
            iIndex++;
            sTag = "焊点1的右边电压值";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.RPt_V1 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.RPt_V1));

            //RPt_A1
            iIndex++;
            sTag = "焊点1的右边电流值";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.RPt_A1 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.RPt_A1));

            //RPt_PeiFang1
            iIndex++;
            sTag = "焊点1的右边规范值";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            data.RPt_PeiFang1 = iValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.RPt_PeiFang1));

            //RPt_V2
            iIndex++;
            sTag = "焊点2的右边电压值";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.RPt_V2 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.RPt_V2));

            //RPt_A2
            iIndex++;
            sTag = "焊点2的右边电流值";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetDecimalValue(sTag, objValue, objQ, out decValue, out sErr)) return false;
            data.RPt_A2 = decValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.RPt_A2));

            //RPt_PeiFang2
            iIndex++;
            sTag = "焊点2的右边规范值";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, out sErr)) return false;
            data.RPt_PeiFang2 = iValue;
            this.ShowLogAsyn(string.Format("[{0}]获取值为：{1}", sTag, data.RPt_PeiFang2));
            return true;
        }
        private string GetCode(int i1,int i2,int i3,int i4, int i5, int i6, int i7, int i8, int i9, int iA)
        {
            byte[] bs1 = BitConverter.GetBytes(i1);
            byte[] bs2 = BitConverter.GetBytes(i2);
            byte[] bs3 = BitConverter.GetBytes(i3);
            byte[] bs4 = BitConverter.GetBytes(i4);
            byte[] bs5 = BitConverter.GetBytes(i5);
            byte[] bs6 = BitConverter.GetBytes(i6);
            byte[] bs7 = BitConverter.GetBytes(i7);
            byte[] bs8 = BitConverter.GetBytes(i8);
            byte[] bs9 = BitConverter.GetBytes(i9);
            byte[] bsA = BitConverter.GetBytes(iA);
            StringBuilder sb = new StringBuilder();
            sb.Append(GetChar(bs1[0]));
            sb.Append(GetChar(bs1[1]));
            sb.Append(GetChar(bs1[2]));
            sb.Append(GetChar(bs1[3]));

            sb.Append(GetChar(bs2[0]));
            sb.Append(GetChar(bs2[1]));
            sb.Append(GetChar(bs2[2]));
            sb.Append(GetChar(bs2[3]));

            sb.Append(GetChar(bs3[0]));
            sb.Append(GetChar(bs3[1]));
            sb.Append(GetChar(bs3[2]));
            sb.Append(GetChar(bs3[3]));

            sb.Append(GetChar(bs4[0]));
            sb.Append(GetChar(bs4[1]));
            sb.Append(GetChar(bs4[2]));
            sb.Append(GetChar(bs4[3]));

            sb.Append(GetChar(bs5[0]));
            sb.Append(GetChar(bs5[1]));
            sb.Append(GetChar(bs5[2]));
            sb.Append(GetChar(bs5[3]));

            sb.Append(GetChar(bs6[0]));
            sb.Append(GetChar(bs6[1]));
            sb.Append(GetChar(bs6[2]));
            sb.Append(GetChar(bs6[3]));

            sb.Append(GetChar(bs7[0]));
            sb.Append(GetChar(bs7[1]));
            sb.Append(GetChar(bs7[2]));
            sb.Append(GetChar(bs7[3]));

            sb.Append(GetChar(bs8[0]));
            sb.Append(GetChar(bs8[1]));
            sb.Append(GetChar(bs8[2]));
            sb.Append(GetChar(bs8[3]));

            sb.Append(GetChar(bs9[0]));
            sb.Append(GetChar(bs9[1]));
            sb.Append(GetChar(bs9[2]));
            sb.Append(GetChar(bs9[3]));

            sb.Append(GetChar(bsA[0]));
            sb.Append(GetChar(bsA[1]));
            sb.Append(GetChar(bsA[2]));
            sb.Append(GetChar(bsA[3]));
            
            return sb.ToString();
        }
        private string GetChar(byte b)
        {
            if (b == 0x00)
                return string.Empty;
            return ((char)b).ToString();
        }
        private bool GetShortValue(string sTagName, object objValue, object objQ, out short iValue, out string sErr)
        {
            if (objQ == null)
            {
                iValue = 0;
                sErr = string.Format("GroupHanjieA读取出错Rs1：Tag[{0}]返回的Quality为空！", sTagName);
                return false;
            }
            if (objQ.ToString() != "192")
            {

                iValue = 0;
                sErr = string.Format("GroupHanjieA读取出错Rs2：Tag[{0}]返回的Quality为{1}不是预期的192！", sTagName, objQ.ToString());
                return true;//临时的，不知道为什么
                return false;
            }
            if (objValue == null)
                iValue = 0;
            else
            {
                if (!short.TryParse(objValue.ToString(), out iValue))
                {
                    sErr = string.Format("GroupHanjieA读取出错Rs3：Tag[{0}]返回的Value为{1}不是有效的ini16！", sTagName, objValue.ToString());
                    iValue = 0;
                    return false;
                }
            }
            sErr = string.Empty;
            return true;
        }
        private bool Getint32Value(string sTagName, object objValue, object objQ, out int iValue, out string sErr)
        {
            if (objQ == null)
            {
                iValue = 0;
                sErr = string.Format("GroupHanjieA读取出错Rc1：Tag[{0}]返回的Quality为空！", sTagName);
                return false;
            }
            if (objQ.ToString() != "192")
            {
                iValue = 0;
                sErr = string.Format("GroupHanjieA读取出错Rc2：Tag[{0}]返回的Quality为{1}不是预期的192！", sTagName, objQ.ToString());
                return false;
            }
            if (objValue == null)
                iValue = 0;
            else
            {
                if (!int.TryParse(objValue.ToString(), out iValue))
                {
                    sErr = string.Format("GroupHanjieA读取出错Rc3：Tag[{0}]返回的Value为{1}不是有效的ini16！", sTagName, objValue.ToString());
                    iValue = 0;
                    return false;
                }
            }
            sErr = string.Empty;
            return true;
        }

        private bool GetDecimalValue(string sTagName, object objValue, object objQ, out decimal decValue, out string sErr)
        {
            
            if (objQ == null)
            {
                decValue = 0M;
                sErr = string.Format("GroupHanjieA读取出错Rm1：Tag[{0}]返回的Quality为空！", sTagName);
                return false;
            }
            if (objQ.ToString() != "192")
            {
                decValue = -1M;
                sErr = string.Empty;
                return true;

                decValue = 0;
                sErr = string.Format("GroupHanjieA读取出错Rm2：Tag[{0}]返回的Quality为{1}不是预期的192，值为：{2}！", sTagName, objQ.ToString(), objValue == null ? "kong" : objValue.ToString());
                return false;
            }
            if (objValue == null)
                decValue = 0M;
            else
            {
                if (!decimal.TryParse(objValue.ToString(), out decValue))
                {
                    sErr = string.Format("GroupHanjieA读取出错Rm3：Tag[{0}]返回的Value为{1}不是有效的数值！", sTagName, objValue.ToString());
                    decValue = 0M;
                    return false;
                }
            }
            sErr = string.Empty;
            return true;
        }
        public bool SetMesErr(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            if (this.At_MesErr == null)
            {
                sErr = "At_MesErr设置失败：opc为空！";
                return false;
            }
            else if (this.At_MesErr._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "At_MesErr设置失败：OPCItem为空，且初始化出错：" + sErr;
                    return false;
                }
            }
            if (!this.At_MesErr.WriteData(true, out sErr))
            {
                sErr = "At_MesErr写入出错：" + sErr;
                return false;
            }
            return true;
        }
        #endregion
        #region 消息
        private void ShowLogAsyn(string sMsg)
        {
            if (this.LogNotice == null) return;
            this.LogNotice(sMsg);
        }
        private void ShowErrAsyn(string sMsg)
        {
            if (this.ErrorNotice == null) return;
            this.ErrorNotice(sMsg);
        }
        #endregion
    }
    
    public class OPCHelperPointSetting : OPCHelperBase
    {
        public OPCHelperPointSetting(string sConnectTitle)
        {
            this.OPCItemTitle = sConnectTitle;
        }
        public event ShowMsgCallback LogNotice = null;
        public event ShowMsgCallback ErrorNotice = null;
        OPCServer _Server = null;
        OPCGroups _ServerGroups = null;
        public OPCGroup _MyGroup_HanjieA = null;
        //获取槽号
        public HanJieOPC.MyItemValue Read_Doing = null;//状态标识
        public HanJieOPC.MyItemValue Write_Doing = null;//状态标识
        public HanJieOPC.MyItemValue LP_Cnt = null;//做边总焊点量
        public HanJieOPC.MyItemValue RP_Cnt = null;//右边总焊点量

        public HanJieOPC.MyItemValue P_Index = null;//点序号
        public HanJieOPC.MyItemValue P1_Work = null;
        public HanJieOPC.MyItemValue P1_Type = null;
        public HanJieOPC.MyItemValue P1_AY = null;
        public HanJieOPC.MyItemValue P1_AZ = null;
        public HanJieOPC.MyItemValue P1_BY = null;
        public HanJieOPC.MyItemValue P1_BZ = null;
        public HanJieOPC.MyItemValue P2_Work = null;
        public HanJieOPC.MyItemValue P2_Type = null;
        public HanJieOPC.MyItemValue P2_AY = null;
        public HanJieOPC.MyItemValue P2_AZ = null;
        public HanJieOPC.MyItemValue P2_BY = null;
        public HanJieOPC.MyItemValue P2_BZ = null;
        public HanJieOPC.MyItemValue P3_Work = null;
        public HanJieOPC.MyItemValue P3_Type = null;
        public HanJieOPC.MyItemValue P3_AY = null;
        public HanJieOPC.MyItemValue P3_AZ = null;
        public HanJieOPC.MyItemValue P3_BY = null;
        public HanJieOPC.MyItemValue P3_BZ = null;
        public HanJieOPC.MyItemValue P4_Work = null;
        public HanJieOPC.MyItemValue P4_Type = null;
        public HanJieOPC.MyItemValue P4_AY = null;
        public HanJieOPC.MyItemValue P4_AZ = null;
        public HanJieOPC.MyItemValue P4_BY = null;
        public HanJieOPC.MyItemValue P4_BZ = null;
        //补偿点
        public HanJieOPC.MyItemValue BC_A1 = null;
        public HanJieOPC.MyItemValue BC_A2 = null;
        public HanJieOPC.MyItemValue BC_A3 = null;
        public HanJieOPC.MyItemValue BC_A4 = null;
        public HanJieOPC.MyItemValue BC_A5 = null;
        public HanJieOPC.MyItemValue BC_A6 = null;
        public HanJieOPC.MyItemValue BC_B1 = null;
        public HanJieOPC.MyItemValue BC_B2 = null;
        public HanJieOPC.MyItemValue BC_B3 = null;
        public HanJieOPC.MyItemValue BC_B4 = null;
        public HanJieOPC.MyItemValue BC_B5 = null;
        public HanJieOPC.MyItemValue BC_B6 = null;

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
                    sErr = "OPC：初始化Server出错：" + ex.Message + "(" + ex.Source + ")";
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
                if (this.Read_Doing != null)
                    this.Read_Doing.InitItem();
                if (this.Write_Doing != null)
                    this.Write_Doing.InitItem();
                if (this.LP_Cnt != null)
                    this.LP_Cnt.InitItem();
                if (this.RP_Cnt != null)
                    this.RP_Cnt.InitItem();
                if (this.P_Index != null)
                    this.P_Index.InitItem();
                if (this.P1_Work != null)
                    this.P1_Work.InitItem();
                if (this.P1_Type != null)
                    this.P1_Type.InitItem();
                if (this.P1_AY != null)
                    this.P1_AY.InitItem();
                if (this.P1_AZ != null)
                    this.P1_AZ.InitItem();
                if (this.P1_BY != null)
                    this.P1_BY.InitItem();
                if (this.P1_BZ != null)
                    this.P1_BZ.InitItem();
                if (this.P2_Work != null)
                    this.P2_Work.InitItem();
                if (this.P2_Type != null)
                    this.P2_Type.InitItem();
                if (this.P2_AY != null)
                    this.P2_AY.InitItem();
                if (this.P2_AZ != null)
                    this.P2_AZ.InitItem();
                if (this.P2_BY != null)
                    this.P2_BY.InitItem();
                if (this.P2_BZ != null)
                    this.P2_BZ.InitItem();
                if (this.P3_Work != null)
                    this.P3_Work.InitItem();
                if (this.P3_Type != null)
                    this.P3_Type.InitItem();
                if (this.P3_AY != null)
                    this.P3_AY.InitItem();
                if (this.P3_AZ != null)
                    this.P3_AZ.InitItem();
                if (this.P3_BY != null)
                    this.P3_BY.InitItem();
                if (this.P3_BZ != null)
                    this.P3_BZ.InitItem();
                if (this.P4_Work != null)
                    this.P4_Work.InitItem();
                if (this.P4_Type != null)
                    this.P4_Type.InitItem();
                if (this.P4_AY != null)
                    this.P4_AY.InitItem();
                if (this.P4_AZ != null)
                    this.P4_AZ.InitItem();
                if (this.P4_BY != null)
                    this.P4_BY.InitItem();
                if (this.P4_BZ != null)
                    this.P4_BZ.InitItem();
                //补偿值
                if (this.BC_A1 != null)
                    this.BC_A1.InitItem();
                if (this.BC_A2 != null)
                    this.BC_A2.InitItem();
                if (this.BC_A3 != null)
                    this.BC_A3.InitItem();
                if (this.BC_A4 != null)
                    this.BC_A4.InitItem();
                if (this.BC_A5 != null)
                    this.BC_A5.InitItem();
                if (this.BC_A6 != null)
                    this.BC_A6.InitItem();
                if (this.BC_B1 != null)
                    this.BC_B1.InitItem();
                if (this.BC_B2 != null)
                    this.BC_B2.InitItem();
                if (this.BC_B3 != null)
                    this.BC_B3.InitItem();
                if (this.BC_B4 != null)
                    this.BC_B4.InitItem();
                if (this.BC_B5 != null)
                    this.BC_B5.InitItem();
                if (this.BC_B6 != null)
                    this.BC_B6.InitItem();


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
                    this._MyGroup_HanjieA = _ServerGroups.Add("jpsHanjieGroupA");
                    this._MyGroup_HanjieA.UpdateRate = 100;
                    this._MyGroup_HanjieA.IsActive = true;
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
            if (this.Read_Doing == null)
                Read_Doing = new MyItemValue(DataTypes.Int16, OPCItemTitle + "Read_Doing");
            if (this.Write_Doing == null)
                Write_Doing = new MyItemValue(DataTypes.Int16, OPCItemTitle + "Write_Doing");
            if (this.LP_Cnt == null)
                LP_Cnt = new MyItemValue(DataTypes.Int16, OPCItemTitle + "LP_Cnt");
            if (this.RP_Cnt == null)
                RP_Cnt = new MyItemValue(DataTypes.Int16, OPCItemTitle + "RP_Cnt");
            if (this.P_Index == null)
                P_Index = new MyItemValue(DataTypes.String, OPCItemTitle + "P_Index");
            if (this.P1_Work == null)
                P1_Work = new MyItemValue(DataTypes.String, OPCItemTitle + "P1_Work");
            if (this.P1_Type == null)
                P1_Type = new MyItemValue(DataTypes.String, OPCItemTitle + "P1_Type");
            if (this.P1_AY == null)
                P1_AY = new MyItemValue(DataTypes.String, OPCItemTitle + "P1_AY");
            if (this.P1_AZ == null)
                P1_AZ = new MyItemValue(DataTypes.String, OPCItemTitle + "P1_AZ");
            if (this.P1_BY == null)
                P1_BY = new MyItemValue(DataTypes.String, OPCItemTitle + "P1_BY");
            if (this.P1_BZ == null)
                P1_BZ = new MyItemValue(DataTypes.String, OPCItemTitle + "P1_BZ");
            if (this.P2_Work == null)
                P2_Work = new MyItemValue(DataTypes.String, OPCItemTitle + "P2_Work");
            if (this.P2_Type == null)
                P2_Type = new MyItemValue(DataTypes.String, OPCItemTitle + "P2_Type");
            if (this.P2_AY == null)
                P2_AY = new MyItemValue(DataTypes.String, OPCItemTitle + "P2_AY");
            if (this.P2_AZ == null)
                P2_AZ = new MyItemValue(DataTypes.String, OPCItemTitle + "P2_AZ");
            if (this.P2_BY == null)
                P2_BY = new MyItemValue(DataTypes.String, OPCItemTitle + "P2_BY");
            if (this.P2_BZ == null)
                P2_BZ = new MyItemValue(DataTypes.String, OPCItemTitle + "P2_BZ");
            if (this.P3_Work == null)
                P3_Work = new MyItemValue(DataTypes.String, OPCItemTitle + "P3_Work");
            if (this.P3_Type == null)
                P3_Type = new MyItemValue(DataTypes.String, OPCItemTitle + "P3_Type");
            if (this.P3_AY == null)
                P3_AY = new MyItemValue(DataTypes.String, OPCItemTitle + "P3_AY");
            if (this.P3_AZ == null)
                P3_AZ = new MyItemValue(DataTypes.String, OPCItemTitle + "P3_AZ");
            if (this.P3_BY == null)
                P3_BY = new MyItemValue(DataTypes.String, OPCItemTitle + "P3_BY");
            if (this.P3_BZ == null)
                P3_BZ = new MyItemValue(DataTypes.String, OPCItemTitle + "P3_BZ");
            if (this.P4_Work == null)
                P4_Work = new MyItemValue(DataTypes.String, OPCItemTitle + "P4_Work");
            if (this.P4_Type == null)
                P4_Type = new MyItemValue(DataTypes.String, OPCItemTitle + "P4_Type");
            if (this.P4_AY == null)
                P4_AY = new MyItemValue(DataTypes.String, OPCItemTitle + "P4_AY");
            if (this.P4_AZ == null)
                P4_AZ = new MyItemValue(DataTypes.String, OPCItemTitle + "P4_AZ");
            if (this.P4_BY == null)
                P4_BY = new MyItemValue(DataTypes.String, OPCItemTitle + "P4_BY");
            if (this.P4_BZ == null)
                P4_BZ = new MyItemValue(DataTypes.String, OPCItemTitle + "P4_BZ");
            //初始化补偿
            if (this.BC_A1 == null)
                BC_A1 = new MyItemValue(DataTypes.String, OPCItemTitle + "BC_A1");
            if (this.BC_A2 == null)
                BC_A2 = new MyItemValue(DataTypes.String, OPCItemTitle + "BC_A2");
            if (this.BC_A3 == null)
                BC_A3 = new MyItemValue(DataTypes.String, OPCItemTitle + "BC_A3");
            if (this.BC_A4 == null)
                BC_A4 = new MyItemValue(DataTypes.String, OPCItemTitle + "BC_A4");
            if (this.BC_A5 == null)
                BC_A5 = new MyItemValue(DataTypes.String, OPCItemTitle + "BC_A5");
            if (this.BC_A6 == null)
                BC_A6 = new MyItemValue(DataTypes.String, OPCItemTitle + "BC_A6");
            if (this.BC_B1 == null)
                BC_B1 = new MyItemValue(DataTypes.String, OPCItemTitle + "BC_B1");
            if (this.BC_B2 == null)
                BC_B2 = new MyItemValue(DataTypes.String, OPCItemTitle + "BC_B2");
            if (this.BC_B3 == null)
                BC_B3 = new MyItemValue(DataTypes.String, OPCItemTitle + "BC_B3");
            if (this.BC_B4 == null)
                BC_B4 = new MyItemValue(DataTypes.String, OPCItemTitle + "BC_B4");
            if (this.BC_B5 == null)
                BC_B5 = new MyItemValue(DataTypes.String, OPCItemTitle + "BC_B5");
            if (this.BC_B6 == null)
                BC_B6 = new MyItemValue(DataTypes.String, OPCItemTitle + "BC_B6");


            if (this._MyGroup_HanjieA == null)
            {
                sErr = "HanjieA组添加item时失败，因为group为空。";
                return false;
            }
            if (_MyGroup_HanjieA.OPCItems == null)
            {
                sErr = "HanjieA组添加item时失败，因为group.Items为空。";
                return false;
            }
            //处理标识
            if (!InitMyItems_AddItem(this.Read_Doing, this._MyGroup_HanjieA, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.Write_Doing, this._MyGroup_HanjieA, true, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.LP_Cnt, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.RP_Cnt, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P_Index, this._MyGroup_HanjieA, true, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P1_Work, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P1_Type, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P1_AY, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P1_AZ, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P1_BY, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P1_BZ, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P2_Work, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P2_Type, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P2_AY, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P2_AZ, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P2_BY, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P2_BZ, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P3_Work, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P3_Type, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P3_AY, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P3_AZ, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P3_BY, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P3_BZ, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P4_Work, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P4_Type, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P4_AY, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P4_AZ, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P4_BY, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.P4_BZ, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }
            //补偿
            if (!InitMyItems_AddItem(this.BC_A1, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.BC_A2, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.BC_A3, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.BC_A4, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.BC_A5, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.BC_A6, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.BC_B1, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.BC_B2, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.BC_B3, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.BC_B4, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.BC_B5, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }

            if (!InitMyItems_AddItem(this.BC_B6, this._MyGroup_HanjieA, false, out sErr))
            {
                return false;
            }
            return true;
        }
        private bool InitMyItems_AddItem(MyItemValue myItem, OPCGroup targetGroup, bool saveItem, out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
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
        public bool SetReadDoing(short iValue, out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            if (this.Read_Doing == null)
            {
                sErr = "Read_Doing设置失败：opc为空！";
                return false;
            }
            else if (this.Read_Doing._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "Read_Doing设置失败：OPCItem为空，且初始化出错：" + sErr;
                    return false;
                }
            }
            if (!this.Read_Doing.WriteData(iValue, out sErr))
            {
                sErr = "Read_Doing写入出错：" + sErr;
                return false;
            }
            return true;
        }
        
        public bool ReadDoing(out short iDoing, out int iLeftCnt, out int iRightCnt, out string sErr)
        {
            this.ShowLogAsyn("开始读取状态值");
            if (this.IsDebug)
            {
                this.ShowLogAsyn("OPCHelperPointSetting当前为Debug模式");
                iDoing = PointSetDebug.Read_Doing;
                iLeftCnt = PointSetDebug.LP_Cnt;
                iRightCnt = PointSetDebug.RP_Cnt;
                sErr = string.Empty;
                return true;
            }
            Array values = null;
            #region serverHandles
            Array serverHandles = new int[4] { 0
                , this.Read_Doing.ServerHandle
                , this.LP_Cnt.ServerHandle
                , this.RP_Cnt.ServerHandle
            };
            #endregion
            object objQ;
            object objT;
            Array errors;
            try
            {
                this._MyGroup_HanjieA.SyncRead(1, 3, ref serverHandles, out values, out errors, out objQ, out objT);
            }
            catch (Exception ex)
            {
                iDoing = 0;
                iLeftCnt = 0;
                iRightCnt = 0;
                sErr = string.Format("ReadDoing读取出错01：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            this.ShowLogAsyn("ReadDoing的Read已经执行，开始分析返回数据。");
            if (values == null)
            {
                iDoing = 0;
                iLeftCnt = 0;
                iRightCnt = 0;
                sErr = "ReadDoing读取出错02:values为空！";
                return false;
            }
            if (values.Length != 3)
            {
                iDoing = 0;
                iLeftCnt = 0;
                iRightCnt = 0;
                sErr = string.Format("ReadDoing读取出错03:values长度为{0}，不是预期的3！", values.Length);
                return false;
            }
            Array arrQ = objQ as Array;
            if (arrQ == null)
            {
                iDoing = 0;
                iLeftCnt = 0;
                iRightCnt = 0;
                sErr = "ReadDoing读取出错04:qualitys为空！";
                return false;
            }
            if (arrQ.Length != 3)
            {
                iDoing = 0;
                iLeftCnt = 0;
                iRightCnt = 0;
                sErr = string.Format("ReadDoing读取出错05:qualitys长度为{0}，不是预期的3！", values.Length);
                return false;
            }
            this.ShowLogAsyn("ReadDoing的Read结果长度分析无误，开始分析数据格式。");
            int iIndex = 1;//注意Arrary的GetValue序号从1开始，这与c#中不一样
            iDoing = 0;
            iLeftCnt = 0;
            iRightCnt = 0;
            if (!this.SetResult1("Read_Doing", out iDoing, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult1("LP_Cnt", out iLeftCnt, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult1("RP_Cnt", out iRightCnt, values, arrQ, ref iIndex, out sErr)) return false;
            return true;
        }
        private bool SetResult1(string sTagName,out short iValue, Array arrValues, Array arrQ, ref int iIndex, out string sErr)
        {
            object objValue;
            object objQ;
            //
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                iValue = 0;
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", sTagName);
                return false;
            }
            if (objQ.ToString() != "192")
            {
                iValue = 0;
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", sTagName, objQ.ToString());
                return false;
            }
            if (objValue == null) iValue = 0;
            else
            {
                if (!short.TryParse(objValue.ToString(), out iValue))
                {
                    sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的值为\"{1}\"不是预期的数值类型！", sTagName, objValue.ToString());
                    return false;
                }
            }
            iIndex++;
            sErr = string.Empty;
            return true;
        }
        private bool SetResult1(string sTagName, out int iValue, Array arrValues, Array arrQ, ref int iIndex, out string sErr)
        {
            object objValue;
            object objQ;
            //
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                iValue = 0;
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", sTagName);
                return false;
            }
            if (objQ.ToString() != "192")
            {
                iValue = 0;
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", sTagName, objQ.ToString());
                return false;
            }
            if (objValue == null) iValue = 0;
            else
            {
                if (!int.TryParse(objValue.ToString(), out iValue))
                {
                    sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的值为\"{1}\"不是预期的数值类型！", sTagName, objValue.ToString());
                    return false;
                }
            }
            iIndex++;
            sErr = string.Empty;
            return true;
        }
        public bool ReadPIndex(out short iPIndex,out string sErr)
        {
            this.ShowLogAsyn("开始读取Index值");
            if (this.IsDebug)
            {
                this.ShowLogAsyn("OPCHelperPointSetting当前为Debug模式");
                iPIndex = PointSetDebug.PIndex;
                sErr = string.Empty;
                return true;
            }
            Array values = null;
            #region serverHandles
            Array serverHandles = new int[2] { 0
                , this.P_Index.ServerHandle
            };
            #endregion
            object objQ;
            object objT;
            Array errors;
            try
            {
                this._MyGroup_HanjieA.SyncRead(1, 1, ref serverHandles, out values, out errors, out objQ, out objT);
            }
            catch (Exception ex)
            {
                iPIndex = 0;
                sErr = string.Format("PIndex读取出错01：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            this.ShowLogAsyn("PIndex的Read已经执行，开始分析返回数据。");
            if (values == null)
            {
                iPIndex = 0;
                sErr = "PIndex读取出错02:values为空！";
                return false;
            }
            if (values.Length != 1)
            {
                iPIndex = 0;
                sErr = string.Format("PIndex读取出错03:values长度为{0}，不是预期的1！", values.Length);
                return false;
            }
            Array arrQ = objQ as Array;
            if (arrQ == null)
            {
                iPIndex = 0;
                sErr = "PIndex读取出错04:qualitys为空！";
                return false;
            }
            if (arrQ.Length != 1)
            {
                iPIndex = 0;
                sErr = string.Format("PIndex读取出错05:qualitys长度为{0}，不是预期的1！", values.Length);
                return false;
            }
            this.ShowLogAsyn("PIndex的Read结果长度分析无误，开始分析数据格式。");
            object objValue;
            short iValue;
            //读取编号
            objValue = values.GetValue(1);
            objQ = arrQ.GetValue(1);
            if (objQ == null)
            {
                iPIndex = 0;
                sErr = "PIndex读取出错06：Tag返回的Quality为空！";
                return false;
            }
            if (objQ.ToString() != "192")
            {
                iPIndex = 0;
                sErr = string.Format("PIndex读取出错07：Tag[Rt_MkCode]返回的Quality为{0}不是预期的192！", objQ.ToString());
                return false;
            }
            if (!short.TryParse(objValue.ToString(), out iValue))
            {
                iPIndex = 0;
                sErr = string.Format("PIndex读取出错10：Tag返回的值为\"{0}\"不是预期的数值类型！", objValue.ToString());
                return false;
            }
            iPIndex = iValue;
            this.ShowLogAsyn("PIndex的Read结果焊接点位数量获取成功为：" + iPIndex.ToString());
            sErr = string.Empty;
            return true;
        }
        public bool ReadData(DataEntity data1, DataEntity data2, DataEntity data3, DataEntity data4, out string sErr)
        {
            this.ShowLogAsyn("开始读取各点值");
            if (this.IsDebug)
            {
                this.ShowLogAsyn("OPCHelperPointSetting当前为Debug模式");
                data1.P_Work = PointSetDebug.P1_Work;
                data1.P_Type = PointSetDebug.P1_Type;
                data1.P_AY = PointSetDebug.P1_AY;
                data1.P_AZ = PointSetDebug.P1_AZ;
                data1.P_BY = PointSetDebug.P1_BY;
                data1.P_BZ = PointSetDebug.P1_BZ;
                data2.P_Work = PointSetDebug.P2_Work;
                data2.P_Type = PointSetDebug.P2_Type;
                data2.P_AY = PointSetDebug.P2_AY;
                data2.P_AZ = PointSetDebug.P2_AZ;
                data2.P_BY = PointSetDebug.P2_BY;
                data2.P_BZ = PointSetDebug.P2_BZ;
                data3.P_Work = PointSetDebug.P3_Work;
                data3.P_Type = PointSetDebug.P3_Type;
                data3.P_AY = PointSetDebug.P3_AY;
                data3.P_AZ = PointSetDebug.P3_AZ;
                data3.P_BY = PointSetDebug.P3_BY;
                data3.P_BZ = PointSetDebug.P3_BZ;
                data4.P_Work = PointSetDebug.P4_Work;
                data4.P_Type = PointSetDebug.P4_Type;
                data4.P_AY = PointSetDebug.P4_AY;
                data4.P_AZ = PointSetDebug.P4_AZ;
                data4.P_BY = PointSetDebug.P4_BY;
                data4.P_BZ = PointSetDebug.P4_BZ;

                sErr = string.Empty;
                return true;
            }
            Array values = null;
            #region serverHandles
            Array serverHandles = new int[25] { 0
                , this.P1_Work.ServerHandle
                , this.P1_Type.ServerHandle
                , this.P1_AY.ServerHandle
                , this.P1_AZ.ServerHandle
                , this.P1_BY.ServerHandle
                , this.P1_BZ.ServerHandle
                , this.P2_Work.ServerHandle
                , this.P2_Type.ServerHandle
                , this.P2_AY.ServerHandle
                , this.P2_AZ.ServerHandle
                , this.P2_BY.ServerHandle
                , this.P2_BZ.ServerHandle
                , this.P3_Work.ServerHandle
                , this.P3_Type.ServerHandle
                , this.P3_AY.ServerHandle
                , this.P3_AZ.ServerHandle
                , this.P3_BY.ServerHandle
                , this.P3_BZ.ServerHandle
                , this.P4_Work.ServerHandle
                , this.P4_Type.ServerHandle
                , this.P4_AY.ServerHandle
                , this.P4_AZ.ServerHandle
                , this.P4_BY.ServerHandle
                , this.P4_BZ.ServerHandle
            };
            #endregion
            object objQ;
            object objT;
            Array errors;
            try
            {
                this._MyGroup_HanjieA.SyncRead(1, 24, ref serverHandles, out values, out errors, out objQ, out objT);
            }
            catch (Exception ex)
            {
                sErr = string.Format("PData读取出错01：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            this.ShowLogAsyn("PData的Read已经执行，开始分析返回数据。");
            if (values == null)
            {
                sErr = "PData读取出错02:values为空！";
                return false;
            }
            if (values.Length != 24)
            {
                sErr = string.Format("PData读取出错03:values长度为{0}，不是预期的24！", values.Length);
                return false;
            }
            Array arrQ = objQ as Array;
            if (arrQ == null)
            {
                sErr = "PData读取出错04:qualitys为空！";
                return false;
            }
            if (arrQ.Length != 24)
            {
                sErr = string.Format("PData读取出错05:qualitys长度为{0}，不是预期的24！", values.Length);
                return false;
            }
            this.ShowLogAsyn("PData的Read结果长度分析无误，开始分析数据格式。");
            //解析数值
            int iIndex = 1;//注意Arrary的GetValue序号从1开始，这与c#中不一样
            if(!this.SetResult(data1, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult(data2, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult(data3, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult(data4, values, arrQ, ref iIndex, out sErr)) return false;
            sErr = string.Empty;
            return true;
        }
        private bool SetResult(DataEntity data, Array arrValues, Array arrQ, ref int iIndex, out string sErr)
        {
            object objValue;
            object objQ;
            int iValue;
            string strValue;
            //读取P_work
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", "P1_Work");
                return false;
            }
            if (objQ.ToString() != "192")
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", "P1_Work", objQ.ToString());
                return false;
            }
            strValue= objValue == null ? "" : objValue.ToString().ToLower();
            data.P_Work = strValue == "true" || strValue == "1" || strValue == "yes";
            iIndex++;
            //读取P1_Type
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", "P1_Type");
                return false;
            }
            if (objQ.ToString() != "192")
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", "P1_Type", objQ.ToString());
                return false;
            }
            if (objValue == null) iValue = 0;
            else
            {
                if (!int.TryParse(objValue.ToString(), out iValue))
                {
                    sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的值为\"{1}\"不是预期的数值类型！", "P1_Type", objValue.ToString());
                    return false;
                }
            }
            data.P_Type = iValue;
            iIndex++;
            //读取P1_AY
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", "P1_AY");
                return false;
            }
            if (objQ.ToString() != "192")
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", "P1_AY", objQ.ToString());
                return false;
            }
            if (objValue == null) iValue = 0;
            else
            {
                if (!int.TryParse(objValue.ToString(), out iValue))
                {
                    sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的值为\"{1}\"不是预期的数值类型！", "P1_AY", objValue.ToString());
                    return false;
                }
            }
            data.P_AY = iValue;
            iIndex++;
            //读取P1_AZ
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", "P1_AZ");
                return false;
            }
            if (objQ.ToString() != "192")
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", "P1_AZ", objQ.ToString());
                return false;
            }
            if (objValue == null) iValue = 0;
            else
            {
                if (!int.TryParse(objValue.ToString(), out iValue))
                {
                    sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的值为\"{1}\"不是预期的数值类型！", "P1_AZ", objValue.ToString());
                    return false;
                }
            }
            data.P_AZ = iValue;
            iIndex++;
            //读取P1_BY
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", "P1_BY");
                return false;
            }
            if (objQ.ToString() != "192")
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", "P1_BY", objQ.ToString());
                return false;
            }
            if (objValue == null) iValue = 0;
            else
            {
                if (!int.TryParse(objValue.ToString(), out iValue))
                {
                    sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的值为\"{1}\"不是预期的数值类型！", "P1_BY", objValue.ToString());
                    return false;
                }
            }
            data.P_BY = iValue;
            iIndex++;
            //读取P1_BZ
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", "P1_BZ");
                return false;
            }
            if (objQ.ToString() != "192")
            {
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", "P1_BZ", objQ.ToString());
                return false;
            }
            if (objValue == null) iValue = 0;
            else
            {
                if (!int.TryParse(objValue.ToString(), out iValue))
                {
                    sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的值为\"{1}\"不是预期的数值类型！", "P1_BZ", objValue.ToString());
                    return false;
                }
            }
            data.P_BZ = iValue;
            iIndex++;
            sErr = string.Empty;
            return true;
        }
        public bool InitPIndex(short iPIndex,out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            if (this.P_Index == null)
            {
                sErr = "P_Index设置失败：opc为空！";
                return false;
            }
            else if (this.P_Index._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "P_Index设置失败：OPCItem为空，且初始化出错：" + sErr;
                    return false;
                }
            }
            iPIndex = (short)(iPIndex * -1);
            if (!this.P_Index.WriteData(iPIndex, out sErr))
            {
                sErr = "P_Index写入出错：" + sErr;
                return false;
            }
            return true;
        }
        public bool ReadBC(out int BC_A1
                            , out int BC_A2
                            , out int BC_A3
                            , out int BC_A4
                            , out int BC_A5
                            , out int BC_A6
                            , out int BC_B1
                            , out int BC_B2
                            , out int BC_B3
                            , out int BC_B4
                            , out int BC_B5
                            , out int BC_B6
                            , out string sErr)
        {
            this.ShowLogAsyn("开始读取补偿值");
            BC_A1 = 0;
            BC_A2 = 0;
            BC_A3 = 0;
            BC_A4 = 0;
            BC_A5 = 0;
            BC_A6 = 0;
            BC_B1 = 0;
            BC_B2 = 0;
            BC_B3 = 0;
            BC_B4 = 0;
            BC_B5 = 0;
            BC_B6 = 0;
            if (this.IsDebug)
            {
                this.ShowLogAsyn("OPCHelperPointSetting当前为Debug模式");
                BC_A1 = PointSetDebug.BC_A1;
                BC_A2 = PointSetDebug.BC_A2;
                BC_A3 = PointSetDebug.BC_A3;
                BC_A4 = PointSetDebug.BC_A4;
                BC_A5 = PointSetDebug.BC_A5;
                BC_A6 = PointSetDebug.BC_A6;
                BC_B1 = PointSetDebug.BC_B1;
                BC_B2 = PointSetDebug.BC_B2;
                BC_B3 = PointSetDebug.BC_B3;
                BC_B4 = PointSetDebug.BC_B4;
                BC_B5 = PointSetDebug.BC_B5;
                BC_B6 = PointSetDebug.BC_B6;

                sErr = string.Empty;
                return true;
            }
            Array values = null;
            #region serverHandles
            Array serverHandles = new int[13] { 0
            ,this.BC_A1.ServerHandle
            ,this.BC_A2.ServerHandle
            ,this.BC_A3.ServerHandle
            ,this.BC_A4.ServerHandle
            ,this.BC_A5.ServerHandle
            ,this.BC_A6.ServerHandle
            ,this.BC_B1.ServerHandle
            ,this.BC_B2.ServerHandle
            ,this.BC_B3.ServerHandle
            ,this.BC_B4.ServerHandle
            ,this.BC_B5.ServerHandle
            ,this.BC_B6.ServerHandle
            };
            #endregion
            object objQ;
            object objT;
            Array errors;
            try
            {
                this._MyGroup_HanjieA.SyncRead(1, 12, ref serverHandles, out values, out errors, out objQ, out objT);
            }
            catch (Exception ex)
            {
                sErr = string.Format("补偿值读取出错01：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            this.ShowLogAsyn("补偿值的Read已经执行，开始分析返回数据。");
            if (values == null)
            {
                sErr = "补偿值读取出错02:values为空！";
                return false;
            }
            if (values.Length != 12)
            {
                sErr = string.Format("补偿值读取出错03:values长度为{0}，不是预期的12！", values.Length);
                return false;
            }
            Array arrQ = objQ as Array;
            if (arrQ == null)
            {
                sErr = "补偿值读取出错04:qualitys为空！";
                return false;
            }
            if (arrQ.Length != 12)
            {
                sErr = string.Format("补偿值读取出错05:qualitys长度为{0}，不是预期的12！", values.Length);
                return false;
            }
            this.ShowLogAsyn("补偿值的Read结果长度分析无误，开始分析数据格式。");
            int iIndex = 1;//注意Arrary的GetValue序号从1开始，这与c#中不一样
            if (!this.SetResult_Bc("BC_A1", out BC_A1, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult_Bc("BC_A2", out BC_A2, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult_Bc("BC_A3", out BC_A3, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult_Bc("BC_A4", out BC_A4, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult_Bc("BC_A5", out BC_A5, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult_Bc("BC_A6", out BC_A6, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult_Bc("BC_B1", out BC_B1, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult_Bc("BC_B2", out BC_B2, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult_Bc("BC_B3", out BC_B3, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult_Bc("BC_B4", out BC_B4, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult_Bc("BC_B5", out BC_B5, values, arrQ, ref iIndex, out sErr)) return false;
            if (!this.SetResult_Bc("BC_B6", out BC_B6, values, arrQ, ref iIndex, out sErr)) return false;
            return true;
        }
        private bool SetResult_Bc(string sTagName, out int iValue, Array arrValues, Array arrQ, ref int iIndex, out string sErr)
        {
            object objValue;
            object objQ;
            //
            objValue = arrValues.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (objQ == null)
            {
                iValue = 0;
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为空！", sTagName);
                return false;
            }
            if (objQ.ToString() != "192")
            {
                iValue = 0;
                sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的Quality为{1}不是预期的192！", sTagName, objQ.ToString());
                return false;
            }
            if (objValue == null) iValue = 0;
            else
            {
                if (!int.TryParse(objValue.ToString(), out iValue))
                {
                    sErr = string.Format("ResultOPC读取出错：Tag[{0}]返回的值为\"{1}\"不是预期的数值类型！", sTagName, objValue.ToString());
                    return false;
                }
            }
            iIndex++;
            sErr = string.Empty;
            return true;
        }
        #endregion
        #region 向PLC写入数据
        public bool SetWriteDoing(short iValue, out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            if (this.Write_Doing == null)
            {
                sErr = "Write_Doing设置失败：opc为空！";
                return false;
            }
            else if (this.Write_Doing._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "Write_Doing设置失败：OPCItem为空，且初始化出错：" + sErr;
                    return false;
                }
            }
            if (!this.Write_Doing.WriteData(iValue, out sErr))
            {
                sErr = "Write_Doing写入出错：" + sErr;
                return false;
            }
            return true;
        }
        public bool StartWriteDoing(int iLP_Cnt, int iRP_Cnt, int BC_A1,  int BC_A2,  int BC_A3,  int BC_A4,  int BC_A5,  int BC_A6
                            ,  int BC_B1,  int BC_B2,  int BC_B3,  int BC_B4,  int BC_B5,  int BC_B6, out  string sErr)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                PointSetDebug.Read_Doing = 1;
                PointSetDebug.PIndex = 0;
                PointSetDebug.LP_Cnt = (short)iLP_Cnt;
                PointSetDebug.RP_Cnt = (short)iRP_Cnt;

                return true;
            }
            //写入数据，注意同时要重置P_Index的值
            Array serverHandles = new int[17] { 0, this.P_Index.ServerHandle, this.Write_Doing.ServerHandle, this.LP_Cnt.ServerHandle, this.RP_Cnt.ServerHandle
            ,this.BC_A1.ServerHandle
            ,this.BC_A2.ServerHandle
            ,this.BC_A3.ServerHandle
            ,this.BC_A4.ServerHandle
            ,this.BC_A5.ServerHandle
            ,this.BC_A6.ServerHandle
            ,this.BC_B1.ServerHandle
            ,this.BC_B2.ServerHandle
            ,this.BC_B3.ServerHandle
            ,this.BC_B4.ServerHandle
            ,this.BC_B5.ServerHandle
            ,this.BC_B6.ServerHandle};
            Array values = new object[17] { "", 0, 1, iLP_Cnt, iRP_Cnt, BC_A1, BC_A2, BC_A3, BC_A4, BC_A5, BC_A6, BC_B1, BC_B2, BC_B3, BC_B4, BC_B5, BC_B6 };
            Array errors;
            try
            {
                this._MyGroup_HanjieA.SyncWrite(16, ref serverHandles, ref values, out errors);
            }
            catch (Exception ex)
            {
                sErr = string.Format("StartWriteDoing写入出错：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            sErr = string.Empty;
            return true;
        }


        public bool WritePoints(int iStart,DataEntity data1, DataEntity data2, DataEntity data3, DataEntity data4, out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                PointSetDebug.PIndex = (short)iStart;
                return true;
            }
            //写入数据，注意同时要重置P_Index的值
            Array serverHandles = new int[26] { 0
                , this.P1_Work.ServerHandle
                , this.P1_Type.ServerHandle
                , this.P1_AY.ServerHandle
                , this.P1_AZ.ServerHandle
                , this.P1_BY.ServerHandle
                , this.P1_BZ.ServerHandle
                , this.P2_Work.ServerHandle
                , this.P2_Type.ServerHandle
                , this.P2_AY.ServerHandle
                , this.P2_AZ.ServerHandle
                , this.P2_BY.ServerHandle
                , this.P2_BZ.ServerHandle
                , this.P3_Work.ServerHandle
                , this.P3_Type.ServerHandle
                , this.P3_AY.ServerHandle
                , this.P3_AZ.ServerHandle
                , this.P3_BY.ServerHandle
                , this.P3_BZ.ServerHandle
                , this.P4_Work.ServerHandle
                , this.P4_Type.ServerHandle
                , this.P4_AY.ServerHandle
                , this.P4_AZ.ServerHandle
                , this.P4_BY.ServerHandle
                , this.P4_BZ.ServerHandle
                ,this.P_Index.ServerHandle
            };
            Array values = new object[26] { "",
                data1.P_Work,
                data1.P_Type,
                data1.P_AY,
                data1.P_AZ,
                data1.P_BY,
                data1.P_BZ,

                data2.P_Work,
                data2.P_Type,
                data2.P_AY,
                data2.P_AZ,
                data2.P_BY,
                data2.P_BZ,

                data3.P_Work,
                data3.P_Type,
                data3.P_AY,
                data3.P_AZ,
                data3.P_BY,
                data3.P_BZ,

                data4.P_Work,
                data4.P_Type,
                data4.P_AY,
                data4.P_AZ,
                data4.P_BY,
                data4.P_BZ,
                iStart
            };
            Array errors;
            try
            {
                this._MyGroup_HanjieA.SyncWrite(25, ref serverHandles, ref values, out errors);
            }
            catch (Exception ex)
            {
                sErr = string.Format("StartWriteDoing写入出错：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            sErr = string.Empty;
            return true;
        }

        #endregion
        #region 消息
        private void ShowLogAsyn(string sMsg)
        {
            if (this.LogNotice == null) return;
            this.LogNotice(sMsg);
        }
        private void ShowErrAsyn(string sMsg)
        {
            if (this.ErrorNotice == null) return;
            this.ErrorNotice(sMsg);
        }
        #endregion
    }
    public class HanJieBResult
    {
        public MyItemValue ItemA = null;
        public MyItemValue ItemV = null;
        public MyItemValue ItemArg = null;
        public HanJieBResult()
        {

        }
        public HanJieBResult(MyItemValue itemA,MyItemValue itemV,MyItemValue itemArg)
        {
            this.ItemA = itemA;
            this.ItemV = itemV;
            this.ItemArg = itemArg;
        }
    }
    public enum DataTypes
    {
        Bool = 1,
        Float = 2,
        Int16 = 3,
        String=4
    }
    public class MyItemValue
    {
        public DataTypes MyType;
        public OPCItem _OPCItem = null;
        public MyItemValue(DataTypes dataType, string sTagName)
        {
            this.TagName = sTagName;
            this.MyType = dataType;
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
    public class DataEntity
    {
        public static int DefaultValue = -99999;
        public bool P_Work = false;
        public int P_Type = DefaultValue;
        public int P_AY = DefaultValue;
        public int P_AZ = DefaultValue;
        public int P_BY = DefaultValue;
        public int P_BZ = DefaultValue;
    }
    public class DianHanDataEntity
    {
        
        public string Rt_MkCode = string.Empty;
        public string Rt_MkCode2 = string.Empty;
        public short Rt_PointCnt = 0;
        public decimal Pt_V1 = 0M;
        public decimal Pt_A1 = 0M;
        public short Pt_PeiFang1 = 0;
        public short Pt_CurrentPoint1 = 0;
        public decimal Pt_V2 = 0M;
        public decimal Pt_A2 = 0M;
        public short Pt_PeiFang2 = 0;
        public short Pt_CurrentPoint2 = 0;
        //右边焊点
        public decimal RPt_V1 = 0M;
        public decimal RPt_A1 = 0M;
        public short RPt_PeiFang1 = 0;
        public decimal RPt_V2 = 0M;
        public decimal RPt_A2 = 0M;
        public short RPt_PeiFang2 = 0;

        public bool IsMKCodeChange(string sMkCode1,string sMkCode2)
        {
            if (string.Compare(this.Rt_MkCode, sMkCode1, true) != 0 || string.Compare(this.Rt_MkCode2, sMkCode2, true) != 0)
                return true;
            return false;
        }
    }
    public delegate void ShowMsgCallback(string sMsg);
    #region 读取版本信息
    public class Version
    {
        public static string GetVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        public static string GetGuid()
        {
            System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
            object[] attrs = ass.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
            Guid id = new Guid(((System.Runtime.InteropServices.GuidAttribute)attrs[0]).Value);
            return id.ToString();
        }
        public static string GetTitle()
        {
            System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
            object[] attributes = ass.GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), false);
            System.Reflection.AssemblyTitleAttribute titleAttribute = (System.Reflection.AssemblyTitleAttribute)attributes[0];
            return titleAttribute.Title;
        }
        public static string GetStrForUpdate()
        {
            return GetGuid() + "|" + GetVersion();
        }

        public static void ContainGuids(List<string> list)
        {
            if (list == null)
                list = new List<string>();
            string str = GetStrForUpdate();
            if (!list.Contains(str))
                list.Add(str);
            
            Common.Version.ContainGuids(list);
            

        }
        public static List<Common.MyEntity.VersionEntity> GetCurrentVersions()
        {
            List<Common.MyEntity.VersionEntity> listV = new List<Common.MyEntity.VersionEntity>();
            List<string> listGuids = new List<string>();
            ContainGuids(listGuids);
            if (listGuids != null)
            {
                foreach (string str in listGuids)
                    listV.Add(new Common.MyEntity.VersionEntity(str));
            }
            return listV;
        }
    }
    #endregion
}

