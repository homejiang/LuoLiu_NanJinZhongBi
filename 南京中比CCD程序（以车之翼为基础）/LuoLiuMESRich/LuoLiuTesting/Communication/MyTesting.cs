using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuoLiuTesting.Communication
{
    #region 相关类及委托
    public delegate void ShowMsgAsynCallBack(string sMsg);
    #endregion
    public class MyTesting
    {
        /// <summary>
        /// 是否读取到编号后，自动执行CCD测试
        /// </summary>
        public static bool AutoStartCCD = false;
        public MyTesting(LuoLiuTesting.frmMain form)
        {
            this.MyForm = form;
        }
        public event CCDResultAsynCallBack CCDResultNotice = null;
        public LuoLiuTesting.frmMain MyForm = null;
        
        /// <summary>
        /// 标识当前通讯是否中断状态
        /// </summary>
        public bool Interrupt = false;
        Thread _thread = null;
        public bool Running = false;
        CcdRunningStates _State = CcdRunningStates.None;
        private bool InitOPCHelperResult(out string sErr)
        {
            sErr = string.Empty;
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
            
            return true;
        }
        public bool SetErr1()
        {
            
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
    public class Debug
    {
        public static bool SerialPortDebug = false;
    }
}
