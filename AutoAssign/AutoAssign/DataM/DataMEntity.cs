using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoAssign.DataM
{
    #region 发送到MES
    public class GrooveDetialBtyStatisticControler
    {
        public event GrooveStatisticFnishedCallback GrooveStatisticFnisheNotice = null;
        public event TuoPanStatisticFnishedCallback TuoPanStatisticFnishedNotice = null;
        public frmTestedData MyForm = null;
        Thread _thread = null;
        public bool Running = false;
        string _ResultTable = string.Empty;
        public GrooveDetialBtyStatisticControler(frmTestedData mainForm)
        {
            this.MyForm = mainForm;
        }

        public bool StartStatistic(string sResultTable ,out string sErr)
        {
            if (this.Running)
            {
                sErr = "槽明细数据统计已经开启，请勿重复打开。";
                return false;
            }
            this.Running = true;
            this._ResultTable = sResultTable;
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(Listen));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("槽明细数据统计开启时出错：{0}({1})", ex.Message, ex.Source);
                this.Running = false;
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool StopStatistic(out string sErr)
        {
            sErr = string.Empty;
            this.Running = false;
            return true;
        }

        #region 统计数据
        List<GrooveStatisticResult> Listen_Results = null;
        #endregion
        private void Listen()
        {
            if (!this.Running)
            {
                return;
            }
            if(this.CalculatorGroove())
            {
                GrooveStatisticFnisheNoticeCall(true, this.Listen_Results);
                ////此时成功
                //if (GrooveStatisticFnisheNotice != null)
                //    this.GrooveStatisticFnisheNotice(true, this.Listen_Results);
            }
            else
            {
                //此时失败

                GrooveStatisticFnisheNoticeCall(false, null);
            }
            if (!this.CalculatorTuoPan())
            {

                tuoPanStatisticFnishedCall(false, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            }
            this.Running = false;
        }
        #region 事件异步执行
        private void GrooveStatisticFnisheNoticeCall(bool blSucessful, List<GrooveStatisticResult> reuslts)
        {
            if (this.GrooveStatisticFnisheNotice == null) return;
            GrooveStatisticFnishedCallback call = new GrooveStatisticFnishedCallback(GrooveStatisticFnisheNoticeAsyn);
            try
            {
                this.MyForm.Invoke(call, new object[] { blSucessful, reuslts });
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }
        private void GrooveStatisticFnisheNoticeAsyn(bool blSucessful, List<GrooveStatisticResult> reuslts)
        {
            this.GrooveStatisticFnisheNotice(blSucessful, reuslts);
        }

        private void tuoPanStatisticFnishedCall(bool blSucessful, List<TuoPanData> tuoPans1, List<TuoPanData> tuoPans2, List<TuoPanData> tuoPans3, List<TuoPanData> tuoPans4, List<TuoPanData> tuoPans5, List<TuoPanData> tuoPans6, List<TuoPanData> tuoPans7, List<TuoPanData> tuoPans8, List<TuoPanData> tuoPans9, List<TuoPanData> tuoPans10, List<TuoPanData> tuoPans11, List<TuoPanData> tuoPans12, List<TuoPanData> tuoPans13, List<TuoPanData> tuoPans14, List<TuoPanData> tuoPans15, List<TuoPanData> tuoPans16, List<TuoPanData> tuoPans17, List<TuoPanData> tuoPans18)
        {
            if (this.TuoPanStatisticFnishedNotice == null) return;
            TuoPanStatisticFnishedCallback call = new TuoPanStatisticFnishedCallback(tuoPanStatisticFnishedAsyn);
            try
            {
                this.MyForm.Invoke(call, new object[] { blSucessful, tuoPans1, tuoPans2, tuoPans3, tuoPans4, tuoPans5, tuoPans6, tuoPans7, tuoPans8, tuoPans9, tuoPans10, tuoPans11, tuoPans12, tuoPans13, tuoPans14, tuoPans15, tuoPans16, tuoPans17, tuoPans18 });
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }
        private void tuoPanStatisticFnishedAsyn(bool blSucessful, List<TuoPanData> tuoPans1, List<TuoPanData> tuoPans2, List<TuoPanData> tuoPans3, List<TuoPanData> tuoPans4, List<TuoPanData> tuoPans5, List<TuoPanData> tuoPans6, List<TuoPanData> tuoPans7, List<TuoPanData> tuoPans8, List<TuoPanData> tuoPans9, List<TuoPanData> tuoPans10, List<TuoPanData> tuoPans11, List<TuoPanData> tuoPans12, List<TuoPanData> tuoPans13, List<TuoPanData> tuoPans14, List<TuoPanData> tuoPans15, List<TuoPanData> tuoPans16, List<TuoPanData> tuoPans17, List<TuoPanData> tuoPans18)
        {
            this.TuoPanStatisticFnishedNotice(blSucessful, tuoPans1, tuoPans2, tuoPans3, tuoPans4, tuoPans5, tuoPans6, tuoPans7, tuoPans8, tuoPans9, tuoPans10, tuoPans11, tuoPans12, tuoPans13, tuoPans14, tuoPans15, tuoPans16, tuoPans17, tuoPans18);
        }
        #endregion
        private bool CalculatorGroove()
        {
            DataTable dt;
            string strSql = string.Format("SELECT CaoIndex,COUNT(*) AS BtyCnt FROM {0} GROUP BY CaoIndex ORDER BY CaoIndex", this._ResultTable);
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("读取电池检测结果时出错：{0}({1})", ex.Message, ex.Source));
                return false;
            }
            this.Listen_Results = new List<GrooveStatisticResult>();
            int iTotalBtyCount = 0;
            int iTmp;
            short iCaoIndex;
            GrooveStatisticResult entity;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["BtyCnt"].Equals(DBNull.Value))
                    iTmp = 0;
                else
                {
                    iTmp = int.Parse(dr["BtyCnt"].ToString());
                    iTotalBtyCount += iTmp;
                }
                if (dr["CaoIndex"].Equals(DBNull.Value))
                    iCaoIndex = 0;
                else
                {
                    iCaoIndex = short.Parse(dr["CaoIndex"].ToString());
                    entity = new GrooveStatisticResult(iCaoIndex);
                    entity.BtyCount = iTmp;
                    this.Listen_Results.Add(entity);
                }
            }
            if (iTotalBtyCount > 0)
            {
                decimal decRate;
                foreach (GrooveStatisticResult data in this.Listen_Results)
                {
                    decRate = (decimal)data.BtyCount / iTotalBtyCount;
                    data.RateText = decRate.ToString("#########0.###%");
                }
            }
            //执行完毕，通知客户端
            return true;
        }
        private bool CalculatorTuoPan()
        {
            DataTable dt;
            string strSql = string.Format("select CaoIndex,TuoCode,COUNT(*) as Cnt from {0} group by CaoIndex,TuoCode", this._ResultTable);
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("读取槽统计结果时出错：{0}({1})", ex.Message, ex.Source));
                return false;
            }
            List<TuoPanData> tuopans1 = new List<TuoPanData>();
            List<TuoPanData> tuopans2 = new List<TuoPanData>();
            List<TuoPanData> tuopans3 = new List<TuoPanData>();
            List<TuoPanData> tuopans4 = new List<TuoPanData>();
            List<TuoPanData> tuopans5 = new List<TuoPanData>();
            List<TuoPanData> tuopans6 = new List<TuoPanData>();
            List<TuoPanData> tuopans7 = new List<TuoPanData>();
            List<TuoPanData> tuopans8 = new List<TuoPanData>();
            List<TuoPanData> tuopans9 = new List<TuoPanData>();
            List<TuoPanData> tuopans10 = new List<TuoPanData>();
            List<TuoPanData> tuopans11 = new List<TuoPanData>();
            List<TuoPanData> tuopans12 = new List<TuoPanData>();
            List<TuoPanData> tuopans13 = new List<TuoPanData>();
            List<TuoPanData> tuopans14 = new List<TuoPanData>();
            List<TuoPanData> tuopans15 = new List<TuoPanData>();
            List<TuoPanData> tuopans16 = new List<TuoPanData>();
            List<TuoPanData> tuopans17 = new List<TuoPanData>();
            List<TuoPanData> tuopans18 = new List<TuoPanData>();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["CaoIndex"].ToString() == "1")
                {
                    tuopans1.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "2")
                {
                    tuopans2.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "3")
                {
                    tuopans3.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "4")
                {
                    tuopans4.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "5")
                {
                    tuopans5.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "6")
                {
                    tuopans6.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "7")
                {
                    tuopans7.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "8")
                {
                    tuopans8.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "9")
                {
                    tuopans9.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "10")
                {
                    tuopans10.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "11")
                {
                    tuopans11.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "12")
                {
                    tuopans12.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "13")
                {
                    tuopans13.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "14")
                {
                    tuopans14.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "15")
                {
                    tuopans15.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "16")
                {
                    tuopans16.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "17")
                {
                    tuopans17.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
                else if (dr["CaoIndex"].ToString() == "18")
                {
                    tuopans18.Add(new TuoPanData(dr["TuoCode"], dr["Cnt"]));
                }
            }

            this.tuoPanStatisticFnishedCall(true, tuopans1, tuopans2, tuopans3, tuopans4, tuopans5, tuopans6, tuopans7, tuopans8, tuopans9, tuopans10, tuopans11, tuopans12, tuopans13, tuopans14, tuopans15, tuopans16, tuopans17, tuopans18);
            return true;
        }
        #region 消息
        /// <summary>
        /// 异步消息显示
        /// </summary>
        /// <param name="sMsg">消息内容</param>
        public void ShowErrAsyn(string sMsg)
        {
            JPSEntity.ShowMsgAsynCallBack cb = new JPSEntity.ShowMsgAsynCallBack(ShowErr);
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
            //if (this.IsFormForOperatorOpend)
            //    this.MsgFormForOperator_AddMsg(sMsg, true);
            //else
            //{
            //    this.MyForm.ShowErr(sMsg);
            //}
        }
        public void ShowLogAsyn(string sMsg)
        {
            JPSEntity.ShowMsgAsynCallBack cb = new JPSEntity.ShowMsgAsynCallBack(ShowLog);
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
            //frmSendMesLog.ShowMyLog(sMsg);
        }
        #endregion
    }
    public class GrooveStatisticResult
    {
        public GrooveStatisticResult(short iCaoIndex)
        {
            this.CaoIndex = iCaoIndex;
        }
        public short CaoIndex = 0;
        public int BtyCount = 0;
        public string RateText = string.Empty;
    }
    public class TuoPanData
    {
        public TuoPanData(object objTuoCode,object objBtyCount)
        {
            this.TuoCode = objTuoCode.ToString();
            if (objBtyCount.Equals(DBNull.Value))
                BtyCount = 0;
            else BtyCount = int.Parse(objBtyCount.ToString());
        }
        public string TuoCode = string.Empty;
        public int BtyCount = 0;

    }
    public delegate void GrooveStatisticFnishedCallback(bool blSucessful, List<GrooveStatisticResult> reuslts);
    public delegate void TuoPanStatisticFnishedCallback(bool blSucessful, List<TuoPanData> tuoPans1, List<TuoPanData> tuoPans2, List<TuoPanData> tuoPans3, List<TuoPanData> tuoPans4, List<TuoPanData> tuoPans5, List<TuoPanData> tuoPans6, List<TuoPanData> tuoPans7, List<TuoPanData> tuoPans8, List<TuoPanData> tuoPans9, List<TuoPanData> tuoPans10, List<TuoPanData> tuoPans11, List<TuoPanData> tuoPans12, List<TuoPanData> tuoPans13, List<TuoPanData> tuoPans14, List<TuoPanData> tuoPans15, List<TuoPanData> tuoPans16, List<TuoPanData> tuoPans17, List<TuoPanData> tuoPans18);
    #endregion
}
