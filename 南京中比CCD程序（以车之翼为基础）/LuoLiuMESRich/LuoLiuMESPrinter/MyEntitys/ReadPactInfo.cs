using ErrorService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuoLiuMESPrinter.MyEntitys
{
    #region 相关类及委托
    public delegate void ShowMsgAsynCallBack(string sMsg);
    #endregion
    public class ReadPactInfo
    {
        public string Name = string.Empty;
        public ReadPactInfo(frmMain form,string sName)
        {
            this.MyForm = form;
            this.Name = sName;
        }
        public event SentPactInfoCallBack SentPactInfoNotice = null;
        public LuoLiuMESPrinter.frmMain MyForm = null;

        /// <summary>
        /// 标识当前通讯是否中断状态
        /// </summary>
        public bool Interrupt = false;
        Thread _thread = null;
        public bool Running = false;
        string _PlanGuid = string.Empty;
        string _Station = string.Empty;
        public bool StartListenning(string sPlanGuid,string sStation, out string sErr)
        {
            if (this.Running)
            {
                sErr = "测试结果的监听已经开启，请勿重复打开。";
                return false;
            }
            if (this.Interrupt)
                this.Interrupt = false;
            this._PlanGuid = sPlanGuid;
            this._Station = sStation;
            this.Listening_PactInfo = string.Empty;
            this.Listening_Err = string.Empty;
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
        string Listening_PactInfo;
        public void Listening()
        {
            if (!this.Running)
            {
                this.ShowLogAsyn("测试结果读取停止。");
                return;
            }
            Listening_PactInfo = this.ReadFromRemoteDB(this._PlanGuid, this._Station, out this.Listening_Err);
            if (Listening_PactInfo.Length == 0)
            {
                //此时获取出错了
                this.CallSentPactInfoNoticeAsyn(false, this.Listening_Err);
            }
            else
            {
                this.CallSentPactInfoNoticeAsyn(true, this.Listening_PactInfo);
            }
        }
        #region 功能函数
        public string ReadFromRemoteDB(string sPlanGuid,string sStation, out string sErrMsg)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC LuoLiuMESPrinter_GetPactInfo '{0}','{1}'"
                    , sPlanGuid.Replace("'", "''"), sStation.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                sErrMsg = string.Format("从远程数据库读取任务单信息时出错：{0}({1})", ex.Message, ex.Source);
                return string.Empty;
            }
            sErrMsg = string.Empty;
            return dt.Rows[0]["Info"].ToString();
        }
        private bool CallSentPactInfoNoticeAsyn(bool blSucessfully, string sMsg)
        {
            SentPactInfoCallBack call = new SentPactInfoCallBack(CallSentPactInfoNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { blSucessfully , sMsg });
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
                return false;
            }
            return true;
        }
        private void CallSentPactInfoNotice(bool blSucessfully, string sMsg)
        {
            //确保主线程能直接处理数据。
            if (this.SentPactInfoNotice != null)
                this.SentPactInfoNotice(blSucessfully, sMsg);
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
        public delegate void SentPactInfoCallBack(bool blSucessfully,string sMsg);
        
        #endregion
    }
}
