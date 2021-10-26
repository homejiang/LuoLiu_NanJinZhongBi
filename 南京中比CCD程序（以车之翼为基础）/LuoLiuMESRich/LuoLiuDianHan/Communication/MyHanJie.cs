using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuoLiuDianHan.Communication
{
    public class MyHanJieA
    {
        #region 工序相关字段
        public string _ProcessCode = string.Empty;
        public string _StationCode = string.Empty;
        public string _MacCode = string.Empty;
        #endregion
        #region 窗体数据连接实例
        private BLLDAL.HanJie _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.HanJie BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.HanJie();
                return _dal;
            }
        }
        #endregion 
        public event ClearTaskCallBack ClearTaskNotice = null;
        public event FoundNewMKCodeCallBack FoundNewMKCodeNotice = null;
        public event HanDianParamtersCallBack HanDianParamtersNotice = null;
        #region 窗口字段
        public frmDianHan MyForm = null;
        public MyTasks _MyTasks = null;
        public HanJieOPC.OPCHelperA _OPCHelperA = null;
        HanJieOPC.DianHanDataEntity _Data = null;
        string _MKCode1 = string.Empty;
        string _MKCode2 = string.Empty;
        string _Guid1 = string.Empty;
        string _Guid2 = string.Empty;
        int _TableN1 = 0;
        int _TableN2 = 0;
        int _CurrentPIndex1 = 0;
        int _CurrentPIndex2 = 1;
        MySteps _MyStep = MySteps.None;
        #endregion
        public MyHanJieA(frmDianHan form)
        {
            this.MyForm = form;
        }
        
        public bool Interrupt = false;
        Thread _thread = null;
        public bool Running = false;
        public string Listening_Err;
        public bool StartListenning(out string sErr)
        {
            if (this.Running)
            {
                sErr = "测试结果的监听已经开启，请勿重复打开。";
                return false;
            }
            if (!InitOPCHelperA(out sErr)) return false;
            this._Data = new HanJieOPC.DianHanDataEntity();
            if (this.Interrupt)
                this.Interrupt = false;
            Listening_Err = string.Empty;
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(Listen));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("结果监听启动时出错：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public void StopListenning()
        {
            this.Running = false;

        }
        public void Listen()
        {
            this.Running = true;
            this.Listening();
            this.Running = false;
        }
        public void Listening()
        {
            while (true)
            {
                if (!this.Running)
                {
                    this.ShowLogAsyn("测试结果读取停止。");
                    break;
                }
                if(this._MyStep==MySteps.None || this._MyStep==MySteps.ReadAll)
                {
                    Thread.Sleep(10);//休眠一下
                    if (!this._OPCHelperA.ReadMKCode(this._Data, out Listening_Err))
                    {
                        this.SetInterrupt(true);
                        this.ShowErrAsyn(Listening_Err);
                        continue;
                    }
                    //日志显示读取结果
                    this._MyStep = MySteps.CheckMKCode;
                }
                if (this._MyStep == MySteps.CheckMKCode)
                {
                    if (this._Data.IsMKCodeChange(this._MKCode1, this._MKCode2))
                    {
                        this._MyStep = MySteps.CreateTasks;
                    }
                    else
                    {
                        this._MyStep = MySteps.SaveHanDian;
                    }
                }
                if (this._MyStep == MySteps.CreateTasks)
                {
                    if (!this.CreateTasks())
                    {
                        //创建失败的话再重新读取，否则一直会循环这个creteTask，PLC里换了变量都没法跟进了
                        this._MyStep = MySteps.ReadAll;
                        continue;
                    }
                    if (this._ReadCounter != 10)
                        this._ReadCounter = 10;
                    this._MyStep = MySteps.SaveHanDian;
                }
                if (this._MyStep == MySteps.SaveHanDian)
                {
                    //直接保存
                    this.SendParatemers2RemoteMES();
                    this._MyStep = MySteps.ReadAll;
                }
                this.SetInterrupt(false);
            }
        }
        #region 公共函数
        public bool ConnectMac(out string sErr)
        {
           
            if (!InitOPCHelperA(out sErr)) return false;
            if(!this.Running)
            {
                this.StartListenning(out sErr);
            }
            return true;
        }

        public void DisconnectMac()
        {
            
            string sErr;
            if (this._OPCHelperA != null)
            {
                this.StopListenning();
                if (!this._OPCHelperA.CloseOPC(out sErr))
                {
                    this.ShowErrAsyn(sErr);
                }
            }
        }

        public CommunicationStates GetCommunicationState()
        {
            //获取当前通讯状态
            if (!this.Running) return CommunicationStates.Stoped;//已停止运行
            //此时是运行的
            if (this._Guid1.Length == 0 && this._Guid2.Length == 0) return CommunicationStates.GuidEmpty;//无任务
            if (this.Interrupt)
                return CommunicationStates.Interrupted;//通讯中断
            return CommunicationStates.Normal;
        }
        public void SetStation(string sProcessCode, string sStation, string sMacCode)
        {
            if (this._ProcessCode != sProcessCode)
                this._ProcessCode = sProcessCode;
            if (this._StationCode != sStation)
                this._StationCode = sStation;
            if (this._MacCode != sMacCode)
                this._MacCode = sMacCode;
        }

        #endregion
        #region 功能函数
        int _ReadCounter = 10;
        /// <summary>
        /// 设置通讯中断
        /// </summary>
        /// <param name="blInterrupt">是否中断</param>
        public void SetInterrupt(bool blInterrupt)
        {
            if (this.Interrupt != blInterrupt)
                this.Interrupt = blInterrupt;
        }
        private bool CreateTasks()
        {
            string sGuid1, sGuid2;
            int iTable1, iTable2;
            //通知远程服务器
            if(string.Compare(this._MKCode1,this._Data.Rt_MkCode,true)!=0)
            {
                if(this._Data.Rt_MkCode.Length>0)
                {
                    if(!this.CreateTask(this._Data.Rt_MkCode,_Data.Rt_PointCnt,out sGuid1,out iTable1))
                    {
                        if(_ReadCounter > 0)
                        {
                            this._ReadCounter--;
                            Thread.Sleep(500);
                            return false;
                        }
                        SetErr();
                        //此时强行执行存储吧
                        try
                        {
                            this.BllDAL.CreateTaskNone(this._Data.Rt_MkCode, _Data.Rt_PointCnt,Config.ProcessCode, Config.MacCode, Config.StationCode, out sGuid1, out iTable1);
                        }
                        catch (Exception ex)
                        {
                            this.ShowErrAsyn(string.Format("线程A在领用新模块\"{0}\"时出错：{1}({2})", this._Data.Rt_MkCode, ex.Message, ex.Source));
                            return false;
                        }
                        //return false;
                    }
                    this._MKCode1 = this._Data.Rt_MkCode;
                    this._Guid1 = sGuid1;
                    this._TableN1 = iTable1;
                    this._CurrentPIndex1 = 0;
                }
                else
                {
                    this._MKCode1 = string.Empty;
                    this._Guid1 = string.Empty;
                    this._TableN1 = 0;
                    this._CurrentPIndex1 = 0;
                }
            }
            if (string.Compare(this._MKCode2, this._Data.Rt_MkCode2, true) != 0)
            {
                if (this._Data.Rt_MkCode2.Length > 0)
                {
                    if (!this.CreateTask(this._Data.Rt_MkCode2, _Data.Rt_PointCnt, out sGuid2, out iTable2))
                    {
                        if (_ReadCounter > 0)
                        {
                            this._ReadCounter--;
                            Thread.Sleep(500);
                            return false;
                        }
                        SetErr();
                        //此时强行执行存储吧
                        try
                        {
                            this.BllDAL.CreateTaskNone(this._Data.Rt_MkCode2, _Data.Rt_PointCnt, Config.ProcessCode, Config.MacCode, Config.StationCode, out sGuid2, out iTable2);
                        }
                        catch (Exception ex)
                        {
                            this.ShowErrAsyn(string.Format("线程A在领用新模块\"{0}\"时出错：{1}({2})", this._Data.Rt_MkCode, ex.Message, ex.Source));
                            return false;
                        }
                    }
                    this._MKCode2 = this._Data.Rt_MkCode2;
                    this._Guid2 = sGuid2;
                    this._TableN2 = iTable2;
                    this._CurrentPIndex2 = 0;
                }
                else
                {
                    this._MKCode2 = string.Empty;
                    this._Guid2 = string.Empty;
                    this._TableN2 = 0;
                    this._CurrentPIndex2 = 0;
                }
            }
            //通知主程序加载
            this.CallFoundNewMKCodeNoticeAsyn(this._MKCode1, this._Guid1, this._TableN1, this._MKCode2, this._Guid2, this._TableN2, _Data.Rt_PointCnt);
            return true;
        }
        private bool CreateTask(string sMKCode,int iPtCnt,out string sGuid,out int iTableN)
        {
            sGuid = string.Empty;
            iTableN = 0;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.TakeMyMK(sMKCode, out iReturnValue, out strMsg);
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(string.Format("检查模块\"{0}\"是否领用时出错：{1}({2})", sMKCode, ex.Message, ex.Source));
                return false;
            }
            try
            {
                this.BllDAL.CreateTask(sMKCode, iPtCnt, this._ProcessCode, this._MacCode, this._StationCode, out sGuid, out iTableN, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("线程A在创建新模块\"{0}\"任务时出错：{1}({2})", sMKCode, ex.Message, ex.Source));
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0) strMsg = "任务创建失败，原因未知！";
                this.ShowErrAsyn(string.Format("线程A在创建新模块\"{0}\"任务失败：{1}", sMKCode, strMsg));
                return false;
            }
            return true;
        }
        private bool SendParatemers2RemoteMES()
        {
            if (this._Guid1.Length == 0 && this._Guid2.Length == 0)
                return true;
            List<string> listSql = new List<string>();

            if (this._Data.Pt_CurrentPoint1 > 0)
            {
                if (this._Guid1.Length > 0)
                {
                    if (this.SendParatemers2RemoteMES_IsNewPoint(this._TableN1, this._Guid1, this._Data.Pt_CurrentPoint1))
                    {
                        listSql.Add(string.Format("INSERT INTO LuoLiuMESDynamicTable.dbo.Mac_DianHan_Parameters_{0}(GUID,Pindex,A,V,Arg,Times,RA,RV,RArg) VALUES('{1}',{2},{3},{4},{5},getdate(),{6},{7},{8})"
                    , this._TableN1, this._Guid1, this._Data.Pt_CurrentPoint1, this._Data.Pt_A1, this._Data.Pt_V1, this._Data.Pt_PeiFang1, this._Data.RPt_A1, this._Data.RPt_V1, this._Data.RPt_PeiFang1));
                    }
                }
                else
                {
                    this.ShowLogAsyn(string.Format("模块1中焊点序号{0}已经存在，本次不存储！(Pt_CurrentPoint1)", this._Data.Pt_CurrentPoint1));
                }
                if (this._Guid2.Length > 0)
                {
                    if (this.SendParatemers2RemoteMES_IsNewPoint(this._TableN2, this._Guid2, this._Data.Pt_CurrentPoint1))
                    {
                        listSql.Add(string.Format("INSERT INTO LuoLiuMESDynamicTable.dbo.Mac_DianHan_Parameters_{0}(GUID,Pindex,A,V,Arg,Times,RA,RV,RArg) VALUES('{1}',{2},{3},{4},{5},getdate(),{6},{7},{8})"
                    , this._TableN2, this._Guid2, this._Data.Pt_CurrentPoint1, this._Data.Pt_A1, this._Data.Pt_V1, this._Data.Pt_PeiFang1, this._Data.RPt_A1, this._Data.RPt_V1, this._Data.RPt_PeiFang1));
                    }
                }
                else
                {
                    this.ShowLogAsyn(string.Format("模块2中焊点序号{0}已经存在，本次不存储！(Pt_CurrentPoint1)", this._Data.Pt_CurrentPoint1));
                }
            }
            //if(this._CurrentPIndex1!=this._Data.Pt_CurrentPoint1 )
            //{
            //    if (this._Data.Pt_CurrentPoint1 > 0)
            //    {
            //        if (this._Guid1.Length>0)
            //        {
            //            listSql.Add(string.Format("INSERT INTO LuoLiuMESDynamicTable.dbo.Mac_DianHan_Parameters_{0}(GUID,Pindex,A,V,Arg,Times,RA,RV,RArg) VALUES('{1}',{2},{3},{4},{5},getdate(),{6},{7},{8})"
            //        , this._TableN1, this._Guid1, this._Data.Pt_CurrentPoint1, this._Data.Pt_A1, this._Data.Pt_V1, this._Data.Pt_PeiFang1, this._Data.RPt_A1, this._Data.RPt_V1, this._Data.RPt_PeiFang1));
            //        }
            //        if (this._Guid2.Length > 0)
            //        {
            //            listSql.Add(string.Format("INSERT INTO LuoLiuMESDynamicTable.dbo.Mac_DianHan_Parameters_{0}(GUID,Pindex,A,V,Arg,Times,RA,RV,RArg) VALUES('{1}',{2},{3},{4},{5},getdate(),{6},{7},{8})"
            //        , this._TableN2, this._Guid2, this._Data.Pt_CurrentPoint1, this._Data.Pt_A1, this._Data.Pt_V1, this._Data.Pt_PeiFang1, this._Data.RPt_A1, this._Data.RPt_V1, this._Data.RPt_PeiFang1));
            //        }
            //    }
            //}
            if (this._Guid1.Length > 0)
            {
                if (this.SendParatemers2RemoteMES_IsNewPoint(this._TableN1, this._Guid1, this._Data.Pt_CurrentPoint2))
                {
                    listSql.Add(string.Format("INSERT INTO LuoLiuMESDynamicTable.dbo.Mac_DianHan_Parameters_{0}(GUID,Pindex,A,V,Arg,Times,RA,RV,RArg) VALUES('{1}',{2},{3},{4},{5},getdate(),{6},{7},{8})"
            , this._TableN1, this._Guid1, this._Data.Pt_CurrentPoint2, this._Data.Pt_A2, this._Data.Pt_V2, this._Data.Pt_PeiFang2, this._Data.RPt_A2, this._Data.RPt_V2, this._Data.RPt_PeiFang2));
                }
                else
                {
                    this.ShowLogAsyn(string.Format("模块1中焊点序号{0}已经存在，本次不存储！(Pt_CurrentPoint2)", this._Data.Pt_CurrentPoint2));
                }
            }
            if (this._Guid2.Length > 0)
            {
                if (this.SendParatemers2RemoteMES_IsNewPoint(this._TableN2, this._Guid2, this._Data.Pt_CurrentPoint2))
                {
                    listSql.Add(string.Format("INSERT INTO LuoLiuMESDynamicTable.dbo.Mac_DianHan_Parameters_{0}(GUID,Pindex,A,V,Arg,Times,RA,RV,RArg) VALUES('{1}',{2},{3},{4},{5},getdate(),{6},{7},{8})"
            , this._TableN2, this._Guid2, this._Data.Pt_CurrentPoint2, this._Data.Pt_A2, this._Data.Pt_V2, this._Data.Pt_PeiFang2, this._Data.RPt_A2, this._Data.RPt_V2, this._Data.RPt_PeiFang2));
                }
                else
                {
                    this.ShowLogAsyn(string.Format("模块2中焊点序号{0}已经存在，本次不存储！(Pt_CurrentPoint2)", this._Data.Pt_CurrentPoint2));
                }
            }
            //if (this._CurrentPIndex2 != this._Data.Pt_CurrentPoint2)
            //{
            //    if (this._Guid1.Length > 0)
            //    {
            //        listSql.Add(string.Format("INSERT INTO LuoLiuMESDynamicTable.dbo.Mac_DianHan_Parameters_{0}(GUID,Pindex,A,V,Arg,Times,RA,RV,RArg) VALUES('{1}',{2},{3},{4},{5},getdate(),{6},{7},{8})"
            //    , this._TableN1, this._Guid1, this._Data.Pt_CurrentPoint2, this._Data.Pt_A2, this._Data.Pt_V2, this._Data.Pt_PeiFang2, this._Data.RPt_A2, this._Data.RPt_V2, this._Data.RPt_PeiFang2));
            //    }
            //    if (this._Guid2.Length > 0)
            //    {
            //        listSql.Add(string.Format("INSERT INTO LuoLiuMESDynamicTable.dbo.Mac_DianHan_Parameters_{0}(GUID,Pindex,A,V,Arg,Times,RA,RV,RArg) VALUES('{1}',{2},{3},{4},{5},getdate(),{6},{7},{8})"
            //    , this._TableN2, this._Guid2, this._Data.Pt_CurrentPoint2, this._Data.Pt_A2, this._Data.Pt_V2, this._Data.Pt_PeiFang2, this._Data.RPt_A2, this._Data.RPt_V2, this._Data.RPt_PeiFang2));
            //    }
            //}
            if (listSql.Count == 0) return true;
            //检查是否所有焊点结束了
            int iPIndex = this._Data.Pt_CurrentPoint1;
            if(iPIndex< this._Data.Pt_CurrentPoint2)
            {
                iPIndex = this._Data.Pt_CurrentPoint2;
            }
           // if (iPIndex >= this._Data.Rt_PointCnt)这里注意一下，因为PLC中有个BUG，它是从0~48个开始计数的，但是它少发了一个，这里临时处理一下,正常的是不用-1的
            if (iPIndex >= (this._Data.Rt_PointCnt - 1))
            {
                //此时已经结束了，则更新结束时间
                if (this._Guid1.Length > 0)
                {
                    listSql.Add(string.Format("update Produce_SFG1_Process set EndTime=getdate(),Quality=1,State=1 where GUID='{0}'", this._Guid1.Replace("'", "''")));
                }
                if (this._Guid2.Length > 0)
                {
                    listSql.Add(string.Format("update Produce_SFG1_Process set EndTime=getdate(),Quality=1,State=1 where GUID='{0}'", this._Guid2.Replace("'", "''")));
                }
            }
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(listSql);
            }
            catch (Exception ex)
            {
                string strSqls = string.Empty;
                foreach (string s in listSql)
                    strSqls += s + "@@@";
                this.ShowErrAsyn(string.Format("焊点参数发送至远程MES时出错:{0}({1})[{2}]"
                    , ex.Message, ex.Source, strSqls));
                return false;
            }
            if(this._CurrentPIndex1 != this._Data.Pt_CurrentPoint1)
            {
                this._CurrentPIndex1 = this._Data.Pt_CurrentPoint1;
            }
            if (this._CurrentPIndex2 != this._Data.Pt_CurrentPoint2)
            {
                this._CurrentPIndex2 = this._Data.Pt_CurrentPoint2;
            }
            CallHanDianParamtersNoticeAsyn(this._Data);
            return true;
        }
        /// <summary>
        /// 判断是对于该模块来说是否是一个新的焊点
        /// </summary>
        /// <param name="iTableN"></param>
        /// <param name="sGuid"></param>
        /// <param name="iIndex"></param>
        /// <returns></returns>
        private bool SendParatemers2RemoteMES_IsNewPoint(int iTableN, string sGuid, int iIndex)
        {
            string strSql = string.Format("SELECT COUNT(*) FROM LuoLiuMESDynamicTable.dbo.Mac_DianHan_Parameters_{0} WHERE GUID='{1}' AND Pindex={2}"
                    , iTableN, sGuid.Replace("'", "''"), iIndex);
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("校验焊点是否已经保存时出错:{0}({1})[{2}]"
                    , ex.Message, ex.Source, strSql));
                return false;
            }
            if (int.Parse(dt.Rows[0][0].ToString()) > 0)
            {
                return false;
            }
            return true;
        }
        private void SetErr()
        {
            string strErr;
            if(!this._OPCHelperA.SetMesErr(out strErr))
            {
                this.ShowErrAsyn("通知设备报警出错：" + strErr);
                return;
            }
        }
        #endregion
        #region 执行OPC通讯
        private bool InitOPCHelperA(out string sErr)
        {
            if (_OPCHelperA == null)
            {
                _OPCHelperA = new HanJieOPC.OPCHelperA(Config.GetOPCTitle);
                _OPCHelperA.IsDebug = Debug.OPCDebug;
                _OPCHelperA.LogNotice += _OPCHelperA_LogNotice; ;
                _OPCHelperA.ErrorNotice += _OPCHelperA_ErrorNotice; ;
            }
            if (!this._OPCHelperA.InitServer(out sErr))
            {
                return false;
            }
            return true;
        }
        private void _OPCHelperA_ErrorNotice(string sMsg)
        {
            this.ShowErrAsyn(sMsg);
        }

        private void _OPCHelperA_LogNotice(string sMsg)
        {
            this.ShowLogAsyn(sMsg);
        }
        #endregion
        #region 异步调用事件
        private void CallClearTaskNoticeAsyn()
        {
            ClearTaskCallBack call = new ClearTaskCallBack(CallClearTaskNotice);
            try
            {
                this.MyForm.Invoke(call);
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }

        }
        private void CallClearTaskNotice()
        {
            if (this.ClearTaskNotice == null) return;
            this.ClearTaskNotice();
        }
        #endregion
        #region 消息
        private void CallHanDianParamtersNoticeAsyn(HanJieOPC.DianHanDataEntity data)
        {
            HanDianParamtersCallBack call = new HanDianParamtersCallBack(CallHanDianParamtersNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { data });
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }
        private void CallHanDianParamtersNotice(HanJieOPC.DianHanDataEntity data)
        {
            if (this.HanDianParamtersNotice != null)
                this.HanDianParamtersNotice(data);
        }
        private void CallFoundNewMKCodeNoticeAsyn(string sMkCode1, string sGuid1, int iTableN1, string sMkCode2, string sGuid2, int iTableN2, int iTotalPtCnt)
        {
            if (this.FoundNewMKCodeNotice == null) return;
            FoundNewMKCodeCallBack call = new FoundNewMKCodeCallBack(CallFoundNewMKCodeNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { sMkCode1, sGuid1, iTableN1, sMkCode2, sGuid2, iTableN2, iTotalPtCnt });
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }
        private void CallFoundNewMKCodeNotice(string sMkCode1, string sGuid1, int iTableN1, string sMkCode2, string sGuid2, int iTableN2, int iTotalPtCnt)
        {
            if (this.FoundNewMKCodeNotice == null) return;
            this.FoundNewMKCodeNotice(sMkCode1, sGuid1, iTableN1, sMkCode2, sGuid2, iTableN2, iTotalPtCnt);
        }
        /// <summary>
        /// 异步消息显示
        /// </summary>
        /// <param name="sMsg">消息内容</param>
        public void ShowErrAsyn(string sMsg)
        {
            ShowMsgAsynCallBack cb = new ShowMsgAsynCallBack(ShowErr);
            try
            {
                this.MyForm.Invoke(cb, new object[1] { sMsg });
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void ShowErr(string sMsg)
        {
            this.MyForm.ShowErr(sMsg);
        }
        public void ShowLogAsyn(string sMsg)
        {
            ShowMsgAsynCallBack cb = new ShowMsgAsynCallBack(ShowLog);
            try
            {
                this.MyForm.Invoke(cb, new object[1] { sMsg });
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public void ShowLog(string sMsg)
        {
            frmMyLog.ShowMyLog(sMsg);
        }
        #endregion
        #region 相关枚举
        public enum MySteps
        {
            None=0,
            ReadAll,
            CheckMKCode=2,
            CreateTasks=3,
            SaveHanDian=4
        }
        #endregion
    }
    #region 相关类信息
    public delegate void ShowMsgAsynCallBack(string sMsg);
    public delegate void ClearTaskCallBack();
    public delegate void ReadPointParameterFinishedCallBack(int iPIndex, int iTotalPtCnt);
    public delegate void FoundNewMKCodeCallBack(string sMkCode1, string sGuid1, int iTableN1, string sMkCode2, string sGuid2, int iTableN2, int iTotalPtCnt);
    public delegate void HanDianParamtersCallBack(HanJieOPC.DianHanDataEntity data);
    public enum HanJieBListenStates
    {
        /// <summary>
        /// 未定义
        /// </summary>
        None=0,
        /// <summary>
        /// 读取写入标识
        /// </summary>
        ReadWriteItemValue=1,
        /// <summary>
        /// 读取焊点工艺参数值
        /// </summary>
        ReadParatemers=2,
        /// <summary>
        /// 将ReadParatemers读取到的值发送至远程服务器
        /// </summary>
        SendParatemers2RemoteMES = 3,
        /// <summary>
        /// 重置写入标识，注意：该流程不一定非得成功
        /// </summary>
        ResetWriteItem=4
    }
    public class HanJiePointData
    {
        /// <summary>
        /// 电流，单位：KA
        /// </summary>
        public float A = -99999F;
        /// <summary>
        /// 电压，单位：KV
        /// </summary>
        public float V = -99999F;
        /// <summary>
        /// 焊接参数
        /// </summary>
        public short Arg = 0;
        public void InitData()
        {
            this.A = -99999F;
            this.V = -99999F;
            this.Arg = 0;
        }
    }
    public enum CommunicationStates
    {
        /// <summary>
        ///  未定义
        /// </summary>
        None=0,
        /// <summary>
        /// 中断
        /// </summary>
        Interrupted=1,
        /// <summary>
        /// 无任务
        /// </summary>
        GuidEmpty=2,
        /// <summary>
        /// 停止运行
        /// </summary>
        Stoped=3,
        /// <summary>
        /// 此时是正常的
        /// </summary>
        Normal=4
    }
    public class MyTasks
    {
        public string MKCode1 = string.Empty;
        public string MKCode2 = string.Empty;
        public string MKGuid1 = string.Empty;
        public string MKGuid2 = string.Empty;
        public int _TableN1 = 0;
        public int _TableN2 = 0;
    }
    #endregion
    public class Debug
    {
        public static bool OPCDebug = false;
    }
}
