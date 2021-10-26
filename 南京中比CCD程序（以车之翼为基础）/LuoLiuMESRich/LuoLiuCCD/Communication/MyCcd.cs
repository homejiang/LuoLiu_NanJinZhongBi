using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuoLiuCCD.Communication
{
    #region 相关类及委托
    public delegate void ShowMsgAsynCallBack(string sMsg);
    #endregion
    public class MyCcd
    {
        /// <summary>
        /// 是否读取到编号后，自动执行CCD测试
        /// </summary>
        public static bool AutoStartCCD = false;
        public MyCcd(frmCCD form)
        {
            this.MyForm = form;
        }
        public event CCDResultAsynCallBack CCDResultNotice = null;
        public frmCCD MyForm = null;
        public JpsOPC.OPCHelperCCD _OPCHelperCCD = null;
        /// <summary>
        /// 标识当前通讯是否中断状态
        /// </summary>
        public bool Interrupt = false;
        Thread _thread = null;
        public bool Running = false;
        CcdRunningStates _State = CcdRunningStates.None;
        private bool InitOPCHelperResult(out string sErr)
        {
            if (_OPCHelperCCD == null)
            {
                _OPCHelperCCD = new JpsOPC.OPCHelperCCD();
                _OPCHelperCCD.IsDebug = Communication.Debug.OPCDebug;
                _OPCHelperCCD.LogNotice += _OPCHelperCCD_LogNotice;
                _OPCHelperCCD.ErrorNotice += _OPCHelperCCD_ErrorNotice;
            }
            if (!this._OPCHelperCCD.InitServer(out sErr))
            {
                return false;
            }
            return true;
        }

        private void _OPCHelperCCD_ErrorNotice(string sMsg)
        {
            this.ShowErrAsyn("Dll:" + sMsg);
        }

        private void _OPCHelperCCD_LogNotice(string sMsg)
        {
            this.ShowLogAsyn("DLL:" + sMsg);
        }

        public bool StartListenning(out string sErr)
        {
            if (this.Running)
            {
                sErr = "测试结果的监听已经开启，请勿重复打开。";
                return false;
            }
            if (!InitOPCHelperResult(out sErr)) return false;
            if (this.Interrupt)
                this.Interrupt = false;
            Listening_Err = string.Empty;
            this._State = CcdRunningStates.ReadResult;
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
        string Listening_Err;
        public void Listening()
        {
            while (true)
            {
                if (!this.Running)
                {
                    this.ShowLogAsyn("测试结果读取停止。");
                    break;
                }
                Thread.Sleep(50);//休眠一下
                //读取数据库，并写入长度
                if (this._State == CcdRunningStates.ReadResult)
                {
                    //读取实时数据
                    if (!this._OPCHelperCCD.ReadCCDResult(out Listening_Err))
                    {
                        //此时读取出错
                        if (!Interrupt)
                            Interrupt = true;
                        this.ShowErrAsyn(Listening_Err);
                        Thread.Sleep(100);//休眠一下
                        continue;
                    }
                    this.ShowLogAsyn("结果读取成功");
                    if (this._OPCHelperCCD.Rt_CCD.Value_Short != 0)
                    {
                        this._State = CcdRunningStates.InitResult;
                    }
                }
                //此时读取成功，则上传至数据库
                if (this._State == CcdRunningStates.InitResult)
                {   //执行复位
                    this.ShowLogAsyn("执行复位");
                    if (this.InitResult())
                    {
                        //此时执行成功
                        this._State = CcdRunningStates.NoticeMainForm;
                        if (Interrupt)
                            Interrupt = false;//到这里通讯上已经没有问题了
                    }
                    else
                    {
                        if (!Interrupt)
                            Interrupt = true;
                    }
                }
                if (this._State == CcdRunningStates.NoticeMainForm)
                {
                    this.ShowLogAsyn("通知主程序");
                    //此时要通知主程序，结果已经获取了
                    if (this.Call_CCDResultNoticeAsyn(this._OPCHelperCCD.Rt_CCD.Value_Short))
                    {
                        //全部都完成了，则要退出当前线程
                        this._State = CcdRunningStates.None;
                        return;
                    }
                }
            }
        }
        #region 功能函数
        private bool Call_CCDResultNoticeAsyn(short iValue)
        {
            CCDResultAsynCallBack call = new CCDResultAsynCallBack(Call_CCDResultNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { iValue});
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
                return false;
            }
            return true;
        }
        private void Call_CCDResultNotice(short iValue)
        {
            //确保主线程能直接处理数据。
            if (this.CCDResultNotice != null)
                this.CCDResultNotice(iValue);
        }
        private bool InitResult()
        {
            if (!this._OPCHelperCCD.InitCCDResult(out Listening_Err))
            {
                this.ShowErrAsyn(Listening_Err);
                return false;
            }
            return true;
        }
        public bool SetErr1()
        {
            if (!this.InitOPCHelperResult(out Listening_Err))
            {
                this.ShowErrAsyn(Listening_Err);
                return false;
            }
            if (!this._OPCHelperCCD.SetErr1(out Listening_Err))
            {
                this.ShowErrAsyn(Listening_Err);
                return false;
            }
            return true;
        }

        #endregion
        #region 消息
        /// <summary>
        /// 异步消息显示
        /// </summary>
        /// <param name="sMsg">消息内容</param>
        public void ShowErrAsyn(string sMsg)
        {
            try
            {
                //BLLDAL.Testing.SaveResultLog("结果集执行出错：" + sMsg);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
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
            Common.frmMyLog.ShowMyLog(sMsg);
        }
        #endregion
        #region 相关委托
        public delegate void CCDResultAsynCallBack(short iValue);
        private enum CcdRunningStates
        {
            /// <summary>
            /// 未定义
            /// </summary>
            None=0,
            /// <summary>
            /// 读取结果
            /// </summary>
            ReadResult=1,
            /// <summary>
            /// 初始化结果
            /// </summary>
            InitResult=2,
            /// <summary>
            /// 通知主程序
            /// </summary>
            NoticeMainForm=3
        }
        #endregion
    }
    public class MyHanJieA
    {
        #region 工序相关字段
        public string _ProcessCode = string.Empty;
        public string _StationCode = string.Empty;
        public string _MacCode = string.Empty;
        
        #endregion
        #region 窗体数据连接实例
        private BLLDAL.Process1 _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Process1 BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Process1();
                return _dal;
            }
        }
        #endregion 
        public event NewShowMKCodeCallBack NewShowMKCodeNotice = null;
        #region 窗口字段
        public frmCCD MyForm = null;
        public JpsOPC.OPCHelperCCD _OPCHelperA = null;
        JpsOPC.CCDDataEntity _Data = null;
        string _MKCode1 = string.Empty;
        string _Guid1 = string.Empty;
        
        MySteps _MyStep = MySteps.None;
        #endregion
        public MyHanJieA(frmCCD form)
        {
            this.MyForm = form;
        }

        public bool Interrupt = false;
        Thread _thread = null;
        public bool Running = false;
        public string Listening_Err;
        public void InitData()
        {
            this._Data = new JpsOPC.CCDDataEntity();
            this._MKCode1 = string.Empty;
            this._MyStep = MySteps.None;
        }
        public bool StartListenning(out string sErr)
        {
            if (this.Running)
            {
                sErr = "测试结果的监听已经开启，请勿重复打开。";
                return false;
            }
            if (!InitOPCHelperA(out sErr)) return false;
            this.InitData();
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
                if (this._MyStep == MySteps.None || this._MyStep == MySteps.ReadAll)
                {
                    Thread.Sleep(200);//休眠一下
                    if (!this._OPCHelperA.ReadMKCode(this._Data, out Listening_Err))
                    {
                        this.SetInterrupt(true);
                        this.ShowErrAsyn(Listening_Err);
                        continue;
                    }
                    if (this.Listening_Err.Length > 0)
                    {
                        this.ShowErrAsyn(string.Format("消息提示(非报错信息):{0}", Listening_Err));
                    }
                    this._MyStep = MySteps.CheckMKCode;
                }
                if (this._MyStep == MySteps.CheckMKCode)
                {
                    if (this._Data.IsMKCodeChange(this._MKCode1))
                    {
                        this._MyStep = MySteps.CreateTasks;
                    }
                    else
                    {
                        this._MyStep = MySteps.ShowData;
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
                    this._MyStep = MySteps.ShowData;
                }
                if (this._MyStep == MySteps.ShowData)
                {
                    //直接保存
                    //通知主线程显示数据
                    this.CallNewShowMKCodeNoticeAsyn(this._MKCode1, this._Guid1, this._Data.SpecValue);
                    this._MyStep = MySteps.ReadAll;
                }
                this.SetInterrupt(false);
            }
        }
        #region 公共函数
        public bool ConnectMac(out string sErr)
        {

            if (!InitOPCHelperA(out sErr)) return false;
            if (!this.Running)
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
            if (this._Guid1.Length == 0 ) return CommunicationStates.GuidEmpty;//无任务
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
            string sGuid1;

            //通知远程服务器
            if (string.Compare(this._MKCode1, this._Data.Code, true) != 0)
            {
                if (this._Data.Code.Length > 0)
                {
                    string strErr;
                    if (!this.TakeTuoPan(this._Data.Code, out strErr))
                    {
                        this.ShowErrAsyn(strErr);
                        return false;
                    }
                    if (!this.CreateTask(this._Data.Code, _Data.SpecValue, out sGuid1))
                    {
                        return false;
                    }
                    this.ShowLogAsyn(string.Format("创建了模块{0}", this._Data.Code));
                    this._MKCode1 = this._Data.Code;
                    this._Guid1 = sGuid1;
                }
                else
                {
                    this._MKCode1 = string.Empty;
                    this._Guid1 = string.Empty;
                }
            }
            return true;
        }
        private bool TakeTuoPan(string sTuoPan,out string sErr)
        {
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.TakeTuoPan(sTuoPan, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                sErr = string.Format("自动领用托盘{0}时出错：{1}({2})", sTuoPan, ex.Message, ex.Source);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0) strMsg = "托盘领用失败，原因未知！";
                sErr = string.Format("自动领用托盘{0}时失败：{1}", sTuoPan, strMsg);
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        private bool CreateTask(string sMKCode, short iQuality, out string sGuid)
        {
            sGuid = string.Empty;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.CompeletedCCD(sMKCode,this._MacCode,this._StationCode,iQuality, out sGuid, out iReturnValue, out strMsg);
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
        
        #endregion
        #region 执行OPC通讯
        private bool InitOPCHelperA(out string sErr)
        {
            if (_OPCHelperA == null)
            {
                _OPCHelperA = new JpsOPC.OPCHelperCCD();
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
        
        #endregion
        #region 消息
        private void CallNewShowMKCodeNoticeAsyn(string sMKCode, string sGuid, short iSpecValue)
        {
            if (this.NewShowMKCodeNotice == null) return;
            NewShowMKCodeCallBack call = new NewShowMKCodeCallBack(CallNewShowMKCodeNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { sMKCode, sGuid,iSpecValue });
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }
        private void CallNewShowMKCodeNotice(string sMKCode, string sGuid, short iSpecValue)
        {
            if (this.NewShowMKCodeNotice == null) return;
            this.NewShowMKCodeNotice(sMKCode, sGuid,iSpecValue);
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
            Common.frmMyLog.ShowMyLog(sMsg);
        }
        #endregion
        #region 相关枚举
        public enum MySteps
        {
            None = 0,
            ReadAll,
            CheckMKCode = 2,
            CreateTasks = 3,
            ShowData = 4
        }
        public enum CommunicationStates
        {
            /// <summary>
            ///  未定义
            /// </summary>
            None = 0,
            /// <summary>
            /// 中断
            /// </summary>
            Interrupted = 1,
            /// <summary>
            /// 无任务
            /// </summary>
            GuidEmpty = 2,
            /// <summary>
            /// 停止运行
            /// </summary>
            Stoped = 3,
            /// <summary>
            /// 此时是正常的
            /// </summary>
            Normal = 4
        }
        #endregion
    }
    #region 相关类
    public delegate void NewShowMKCodeCallBack(string sMKCode, string sGuid, short iSpecValue);
    #endregion
    public class Debug
    {
        public static bool OPCDebug = false;
    }
}
