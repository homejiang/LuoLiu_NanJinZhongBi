using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Execute
{
    public class ExecuteGenius
    {
        /*****************
         * Created 2018-09-12 by jiangpengsong
         * 用途：便于统一调用各SAP上传程序，通过继承该类，实现统一部署统一调用。
         * 用法：
         * 1、用户的自定义数据处理类需继承该类，并重写函数MyExecuting，该函数是直接操作数据的，并在每处理一行后调用子函数RowCompeletedNoticeAsyn，以便通知UI线程做界面上的更新。
         * 2、统一数据设置：初始化时系统会自动完成对该类关键属性的赋值：ClassCode、ClassName、_MainForm、FailedNeedStopClass
         * 3、用户新添加好自定义数据处理类后需要到数据库登记好信息；以便主程序可以加载到新增的数据处理类
         * 4、数据处理函数是由子线程调用的，所以在MyExecuting中不要调用UI对象。
         * 5、因为是子线程执行的，所以无法直接断点调试，劲量详细的用日志记录
         * 6、自定义处理类中最好能监控StopCmd的状态，如果为真的话要立即结束处理。以便主程序可以控制，如果不监控也可以，主程序会在当前自定义执行类后终止程序
         * 7、如果有异常要直接报MES异常的，可调用函数Common.CommonFuns.SendExceptionToMES
         *  该对象除SAP上传外也可处理其他业务，不仅仅限制于上传数据
         * ****************/
        #region 公共字段
        public System.Windows.Forms.Form _MainForm = null;
        /// <summary>
        /// 存储当前实例执行失败后，后面需要停止的类，用以避免数据不全SAP报错
        /// </summary>
        public List<string> FailedNeedStopClass = null;
        /// <summary>
        /// 类的唯一标识
        /// </summary>
        public string ClassCode = string.Empty;
        /// <summary>
        /// 类名描述，用于日志显示用
        /// </summary>
        public string ClassName = string.Empty;
        /// <summary>
        /// 是否已经收到停止执行的命令了
        /// </summary>
        public bool StopCmd = false;//该字段值只需在Executing中初始化（=false）即可，其他不用管了。
        #endregion
        #region 公共函数
        public void StopExecute()
        {
            //终止执行
            StopCmd = true;
        }
        #endregion
        /// <summary>
        /// 是否全部都成功执行
        /// </summary>
        public bool AllSucessful = true;
        public bool Runing = false;
        System.Threading.Thread _thread = null;
        /// <summary>
        /// 通知时间
        /// </summary>
        public event ExecuteGeniusCallBack ExecuteGenius_Notice = null;
        public event ExecuteGeniusCompeletedCallBack ExecuteGeniusCompeleted_Notice = null;
        /// <summary>
        ///  执行函数，该函数由主线程调用
        /// </summary>
        public bool Executing()
        {
            if (this.Runing)
            {
                this.ShowLog(string.Format("实例\"{0}\"已启动执行，请勿重复调用。",this.ClassName));
                return false;
            }
            this.Runing = true;
            this.StopCmd = false;
            //一旦调用该函数表示重新读取，重新开始了，所以要初始化数据。
            //这里要初始化信息
            AllSucessful = true;
            this.ShowLog(string.Format("开始执行实例\"{0}\"", this.ClassName));
            //开启线程
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(ExecutingAsyn));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                string strMsg = string.Format("实例\"{0}\"启动失败(pos.Mes.ThreadStart)，错误：{1}({2})", this.ClassName, ex.Message, ex.Source);
                this.ShowLog(strMsg);
                Common.CommonFuns.SendExceptionToMES(strMsg, "SAP数据上传异常。");
                this.Runing = false;
                return false;
            }
            this.ShowLog(string.Format("结束执行实例\"{0}\"", this.ClassName));
            return true;
        }
        private void ExecutingAsyn()
        {
            MyExecuting();
            this.ShowLogAsyn(string.Format("执行类\"{0}\"已经执行完成。", this.ClassName));
            //此时执行完成，通知主程序
            ExecuteCompeletedNoticeAsyn();
            this.Runing = false;
        }
        /// <summary>
        /// 在函数中执行的子函数，需要子类实现，该函数不允许被调用，需要调用函数Executing
        /// 实现时注意，每执行完一行数据后调用函数RowCompeletedNotice
        /// 注意：该函数为子线成调用，切不可调用UI对象
        /// </summary>
        public virtual void MyExecuting()
        {

        }

        /// <summary>
        /// 每执行完一行后调用该函数
        /// </summary>
        /// <param name="blSucessful">是否当前行执行成功</param>
        /// <param name="sMsg">消息</param>
        /// <param name="iTotalRows">总数据行</param>
        /// <param name="iFinishedRows">已完成数量</param>
        /// <param name="iFailedRows">失败行数</param>
        public void RowCompeletedNoticeAsyn(bool blSucessful,string sMsg,int iTotalRows,int iFinishedRows,int iFailedRows, bool blStop)
        {
            if (!blSucessful)
            {
                //如果有一行出错了，则标识一下
                if (this.AllSucessful) this.AllSucessful = false;
            }
            if (this._MainForm == null) return;
            ExecuteGeniusRowNoticeAsyn cal = new ExecuteGeniusRowNoticeAsyn(RowCompeletedNotice);
            object[] objs = new object[] { blSucessful, sMsg, iTotalRows, iFinishedRows, iFailedRows, blStop };
            try
            {
                this._MainForm.Invoke(cal, objs);
            }
            catch (Exception ex)
            {
                //未找到合适的方法来处理该消息
                Common.CommonFuns.SendExceptionToMES(string.Format("Pos=RowCompeletedNotice.Asyn.Invoke,ClassCode={0},ErrMsg={1}", this.ClassCode, ex.Message), "SAP数据上传失败！");
            }
        }
        private void RowCompeletedNotice(bool blSuccessful, string sMsg, int iTotalRows, int iFinishedRows, int iFailedRows, bool blStop)
        {
            if (ExecuteGenius_Notice != null)
            {
                //通知UI线程
                this.ExecuteGenius_Notice(this.ClassCode, blSuccessful, sMsg, iTotalRows, iFinishedRows, iFailedRows, blStop);
            }
        }
        private void ExecuteCompeletedNoticeAsyn()
        {
            if (this._MainForm == null) return;
            ExecuteGeniusCompeletedAsyn cal = new ExecuteGeniusCompeletedAsyn(ExecuteCompeletedNotice);
            try
            {
                this._MainForm.Invoke(cal);
            }
            catch (Exception ex)
            {
                //未找到合适的方法来处理该消息
                Common.CommonFuns.SendExceptionToMES(string.Format("Pos=ExecuteCompeletedNotice.Asyn.Invoke,ClassCode={0},ErrMsg={1}", this.ClassCode, ex.Message), "SAP数据上传失败！");
            }
        }
        private void ExecuteCompeletedNotice()
        {
            if (ExecuteGeniusCompeleted_Notice != null)
                ExecuteGeniusCompeleted_Notice(this.ClassCode, this.AllSucessful, this.FailedNeedStopClass, this.StopCmd);
        }
        /// <summary>
        /// 显示日志，改函数是由UI线程调用的
        /// </summary>
        /// <param name="sMsg">消息内容</param>
        public void ShowLog(string sMsg)
        {
            //打开日志对话框
            if (Execute.frmAPException._APExceptionForm != null && !Execute.frmAPException._APExceptionForm.IsDisposed && Execute.frmAPException._APExceptionForm.Visible)
                Execute.frmAPException._APExceptionForm.AddMsg(sMsg);
        }
        /// <summary>
        /// 显示日志，改函数是由子线程调用的
        /// </summary>
        /// <param name="sMsg"></param>
        public void ShowLogAsyn(string sMsg)
        {
            if (this._MainForm == null) return;
            ExecuteGeniusLogAsyn cal = new ExecuteGeniusLogAsyn(ShowLog);
            object[] objs = new object[] { sMsg };
            try
            {
                this._MainForm.Invoke(cal, objs);
            }
            catch(Exception ex)
            {
                //未找到合适的方法来处理该消息
                Common.CommonFuns.SendExceptionToMES(string.Format("Pos=ShowLog.Asyn.Invoke,ClassCode={0},ErrMsg={1}", this.ClassCode, ex.Message), "SAP数据上传失败！");
            }
        }
    }
    /// <summary>
    /// 每执行一行数据后的信息通知，它的调用线程为ExecuteGenius的实例的调用线程，如果ExecuteGenius是子线程的，则事件回调后的消息处理需要通知主线程。
    /// </summary>
    /// <param name="sClassCode">每个ExecuteGenius类的唯一标识号</param>
    /// <param name="blSuccesful">当前行调用是否成功</param>
    /// <param name="sMsg"></param>
    /// <param name="iTotalRows"></param>
    /// <param name="iFinishedRows"></param>
    /// <param name="blStop">当当前类执行完成后的标识</param>
    /// <param name="listNeedStopClass">后面受限制的类，当执行完成后如果该参数不为空，则后面的类要停止数据上传，否则SAP会因为前面的数据不完整而报错</param>
    public delegate void ExecuteGeniusCallBack(string sClassCode, bool blSuccesful, string sMsg, int iTotalRows, int iFinishedRows, int iFailedRows, bool blStop);
    public delegate void ExecuteGeniusRowNoticeAsyn(bool blSucessful, string sMsg, int iTotalRows, int iFinishedRows,int iFailedRows, bool blStop);
    public delegate void ExecuteGeniusCompeletedCallBack(string sClassCode,bool blAllSucessful, List<string> listNeedStopClass,bool blStopExecute);
    public delegate void ExecuteGeniusCompeletedAsyn();

    /// <summary>
    /// 仅用于消息回传
    /// </summary>
    /// <param name="sMsg"></param>
    public delegate void ExecuteGeniusLogAsyn(string sMsg);
}
