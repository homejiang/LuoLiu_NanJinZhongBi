using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuoLiuDianHan.Communication
{
    public class ReadPeiFangManager
    {
        public event ReadFinishedCallBack ReadFinishedNotice = null;
        public event DataFromPlcCallBack DataFromPlcNotce = null;
        public LuoLiuDianHan.PeiFang.frmAddPf MyForm = null;
        public ReadPeiFangManager(LuoLiuDianHan.PeiFang.frmAddPf form, HanJieOPC.OPCHelperPointSetting opcHelper)
        {
            this.MyForm = form;
            this._OPCHelper = opcHelper;
        }
        /// <summary>
        /// 当前模块编号
        /// </summary>

        /// <summary>
        /// 当前已经读到第几个焊接点了，从0开始计数
        /// </summary>
        public int _N = 0;
        public bool Interrupt = false;
        Thread _thread = null;
        public bool Running = false;
        public string Listening_Err = string.Empty;
        public HanJieOPC.OPCHelperPointSetting _OPCHelper = null;
        public void StopListenning()
        {
            this.Running = false;

        }
        public bool StartListenning(int iPlanLCnt,int iPlanRCnt,out string sErr)
        {
            if (this.Running)
            {
                sErr = "焊点坐标读取中，请勿重复打开。";
                return false;
            }
            if (!InitOPCHelperB(out sErr)) return false;
            
            if (this.Interrupt)
                this.Interrupt = false;
            Listening_Err = string.Empty;
            this.InitData();
            this._Plan_L_Cnt = iPlanLCnt;
            this._Plan_R_Cnt = iPlanRCnt;
            this._MySetp = MySetps.None;
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
        public void Listen()
        {
            this.Running = true;
            this._N = 0;
            this.Listening();
            if (this.Running)
                this.Running = false;
        }
        MySetps _MySetp = MySetps.None;
        public void Listening()
        {
            while (true)
            {
                if (!this.Running)
                {
                    CallReadFinishedNoticeAsyn(false);
                    this.ShowLogAsyn("读取过程以被终止。");
                    break;
                }
                if (this._MySetp == MySetps.None || this._MySetp == MySetps.ReadPIndex)
                {
                    if (!this.ReadPIndex()) continue;
                    else this._MySetp = MySetps.GetData;
                }
                if (this._MySetp == MySetps.GetData)
                {
                    //此时开始读取各节点值了
                    if (!GetData()) continue;
                    else this._MySetp = MySetps.SaveData;
                }
                if (this._MySetp == MySetps.SaveData)
                {
                    //读取成功，则开始存入数据
                    if (!SaveData()) continue;
                    else this._MySetp = MySetps.NextPIndex;
                }
                //都完成了则
                if (this._MySetp == MySetps.NextPIndex)
                {
                    //读取成功，则开始存入数据
                    if (!NextPIndex(out Tmp_Compeleted))
                    {
                        continue;
                    }
                    else
                    {
                        if (Tmp_Compeleted)
                        {
                            //结束了
                            this._MySetp = MySetps.Compeleted;
                        }
                        else
                        {
                            this._MySetp = MySetps.ReadPIndex;
                        }
                    }
                }
                if (this._MySetp == MySetps.Compeleted)
                {
                    this.Running = false;
                    //通知主程序，已经完成了
                    this.ShowLogAsyn("已经完成读取，并且通知了主程序。");
                    CallReadFinishedNoticeAsyn(true);
                    return;
                }
            }
        }
        #region 公共函数
        public bool ConnectMac(out string sErr)
        {
            if (!InitOPCHelperB(out sErr)) return false;
            return true;
        }
        public void DisconnectMac()
        {
            if (this._OPCHelper != null)
            {
                string sErr;
                if (!this._OPCHelper.CloseOPC(out sErr))
                {
                    this.ShowErrAsyn(sErr);
                }
            }
        }

        public void ClearData()
        {
            if (this.Running)
                this.StopListenning();
            this.InitData();
            this._PIndex = 0;
        }
        #endregion
        #region 通讯结果值存储
        short _PIndex = 0;
        HanJieOPC.DataEntity _P1 = null;
        HanJieOPC.DataEntity _P2 = null;
        HanJieOPC.DataEntity _P3 = null;
        HanJieOPC.DataEntity _P4 = null;
        int _Plan_L_Cnt = 0;
        int _Plan_R_Cnt = 0;
        int _Read_L_Cnt = 0;
        int _Read_R_Cnt = 0;
        private void InitData()
        {
            _P1 = new HanJieOPC.DataEntity();
            _P2 = new HanJieOPC.DataEntity();
            _P3 = new HanJieOPC.DataEntity();
            _P4 = new HanJieOPC.DataEntity();

            this._PIndex = 0;
            this._Read_L_Cnt = 0;
            this._Read_R_Cnt = 0;
            this.Tmp_DataErrMsg = string.Empty;
            this.Tmp_Compeleted = false;
            this.Tmp_ErrMsg = string.Empty;
            this.Tmp_NextPIndexErrMsg = string.Empty;
            this.Tmp_PIndex = 0;
        }
        #endregion
        #region 功能函数
        short Tmp_PIndex = 0;
        string Tmp_ErrMsg = string.Empty;
        bool Tmp_Compeleted = false;
        private bool ReadPIndex()
        {
            if (ReadPeiFangManagerConfig.ReadPIndexDelayer > 0)
            {
                Thread.Sleep(ReadPeiFangManagerConfig.ReadPIndexDelayer);
            }
            //读取当前序列号
            if (!this._OPCHelper.ReadPIndex(out Tmp_PIndex, out Tmp_ErrMsg))
            {
                this.ShowErrAsyn(Tmp_ErrMsg);
                return false;
            }
            this.ShowLogAsyn(string.Format("Pindex={0}", Tmp_PIndex));
            if (Tmp_PIndex <= 0) return false;
            if (Tmp_PIndex == this._PIndex) return false;
            this._PIndex = Tmp_PIndex;
            return true;
        }
        string Tmp_DataErrMsg = string.Empty;
        private bool GetData()
        {
            if (!GetData(out Tmp_DataErrMsg))
            {
                this.ShowErrAsyn(Tmp_DataErrMsg);
                return false;
            }
            return true;
        }
        private bool GetData(out string sErr)
        {
            sErr = string.Empty;
            if (!this._OPCHelper.ReadData(this._P1, this._P2, this._P3, this._P4, out sErr))
                return false;
            return true;
        }

        MyDataEntity _MyData1 = new MyDataEntity();
        MyDataEntity _MyData2 = new MyDataEntity();
        MyDataEntity _MyData3 = new MyDataEntity();
        MyDataEntity _MyData4 = new MyDataEntity();
        private bool SaveData()
        {
            //目前是通知主程序进行数据刷新
            bool blL = this._PIndex < 20000;
            _MyData1 = new MyDataEntity(false);
            _MyData2 = new MyDataEntity(false);
            _MyData3 = new MyDataEntity(false);
            _MyData4 = new MyDataEntity(false);
            if (blL)
            {

                int iCnt = this._Read_L_Cnt;
                if (iCnt < this._Plan_L_Cnt)
                {
                    this._MyData1 = new MyDataEntity(this._P1);
                    this._Read_L_Cnt++;
                    iCnt++;
                }
                if (iCnt < this._Plan_L_Cnt)
                {
                    this._MyData2 = new MyDataEntity(this._P2);
                    this._Read_L_Cnt++;
                    iCnt++;
                }
                if (iCnt < this._Plan_L_Cnt)
                {
                    this._MyData3 = new MyDataEntity(this._P3);
                    this._Read_L_Cnt++;
                    iCnt++;
                }
                if (iCnt < this._Plan_L_Cnt)
                {
                    this._MyData4 = new MyDataEntity(this._P4);
                    this._Read_L_Cnt++;
                    iCnt++;
                }
            }
            else
            {

                int iCnt = this._Read_R_Cnt;
                if (iCnt < this._Plan_R_Cnt)
                {
                    this._MyData1 = new MyDataEntity(this._P1);
                    this._Read_R_Cnt++;
                    iCnt++;
                }
                if (iCnt < this._Plan_R_Cnt)
                {
                    this._MyData2 = new MyDataEntity(this._P2);
                    this._Read_R_Cnt++;
                    iCnt++;
                }
                if (iCnt < this._Plan_R_Cnt)
                {
                    this._MyData3 = new MyDataEntity(this._P3);
                    this._Read_R_Cnt++;
                    iCnt++;
                }
                if (iCnt < this._Plan_R_Cnt)
                {
                    this._MyData4 = new MyDataEntity(this._P4);
                    this._Read_R_Cnt++;
                    iCnt++;
                }
            }
            this.CallDataFromPlcCallBackAsyn(this._PIndex, this._MyData1, this._MyData2, this._MyData3, this._MyData4);
            return true;
        }
        string Tmp_NextPIndexErrMsg;
        //public int Stop = 1;
        private bool NextPIndex(out bool blCompeleted)
        {
            if (this._Read_L_Cnt >= this._Plan_L_Cnt && this._Read_R_Cnt >= this._Plan_R_Cnt)
            {
                blCompeleted = true;
                return true;
            }
            //if(Stop==1)
            //{
            //    blCompeleted = false;
            //    return false;
            //}
            blCompeleted = false;
            //写入数据
            if (!this._OPCHelper.InitPIndex(this._PIndex, out Tmp_NextPIndexErrMsg))
            {
                this.ShowErrAsyn(Tmp_NextPIndexErrMsg);
                return false;
            }
            //Stop = 1;
            return true;
        }
        public void SetInterrupt(bool blInterrupt)
        {
            if (this.Interrupt != blInterrupt)
                this.Interrupt = blInterrupt;
        }
        #endregion
        #region 执行OPC通讯
        private bool InitOPCHelperB(out string sErr)
        {
            if (_OPCHelper == null)
            {
                _OPCHelper = new HanJieOPC.OPCHelperPointSetting(Config.GetOPCTitle);
                _OPCHelper.IsDebug = Debug.OPCDebug;
            }
            if (!this._OPCHelper.InitServer(out sErr))
            {
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
            frmMyLogB.ShowMyLog(sMsg);
        }
        public void CallReadFinishedNoticeAsyn(bool blCompeleted)
        {
            ReadFinishedCallBack call = new ReadFinishedCallBack(CallReadFinishedNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { blCompeleted, this._Plan_L_Cnt, this._Plan_R_Cnt, this._Read_L_Cnt, this._Read_R_Cnt });
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("Call Asyn Error(X01.1):{0}({1})", ex.Message, ex.Source));
            }
        }
        public void CallReadFinishedNotice(bool blCompeleted, int iPlanLCnt, int iPlanRCnt, int iReadLCnt, int iReadRCnt)
        {
            if (this.ReadFinishedNotice != null)
            {
                this.ReadFinishedNotice(blCompeleted, iPlanLCnt, iPlanRCnt, iReadLCnt, iReadLCnt);
            }
        }
        public void CallDataFromPlcCallBackAsyn(short iStart, MyDataEntity data1, MyDataEntity data2, MyDataEntity data3, MyDataEntity data4)
        {
            DataFromPlcCallBack call = new DataFromPlcCallBack(CallDataFromPlcCallBack);
            try
            {
                this.MyForm.Invoke(call, new object[] { iStart, data1, data2, data3, data4 });
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("Call Asyn Error(X01.2):{0}({1})", ex.Message, ex.Source));
            }
        }
        public void CallDataFromPlcCallBack(short iStart, MyDataEntity data1, MyDataEntity data2, MyDataEntity data3, MyDataEntity data4)
        {
            if (this.DataFromPlcNotce != null)
                this.DataFromPlcNotce(iStart, data1, data2, data3, data4);
        }
        #endregion
        #region 相关类
        public delegate void ReadFinishedCallBack(bool blCompeleted, int iPlanLCnt, int iPlanRCnt, int iReadLCnt, int iReadRCnt);
        public delegate void DataFromPlcCallBack(short iStart, MyDataEntity data1, MyDataEntity data2, MyDataEntity data3, MyDataEntity data4);
        private enum MySetps
        {
            None = 0,
            ReadPIndex = 1,
            GetData = 2,
            SaveData = 3,
            NextPIndex = 4,
            Compeleted = 5
        }
        public class MyDataEntity : HanJieOPC.DataEntity
        {
            public bool Active = false;
            public MyDataEntity()
            {
            }
            public MyDataEntity(bool blActive)
            {
                this.Active = blActive;
            }
            public MyDataEntity(HanJieOPC.DataEntity data)
            {
                this.Active = true;
                this.P_Work = data.P_Work;
                this.P_Type = data.P_Type;
                this.P_AY = data.P_AY;
                this.P_AZ = data.P_AZ;
                this.P_BY = data.P_BY;
                this.P_BZ = data.P_BZ;
            }

        }
        #endregion
    }
    public class StartReadPeiFang
    {
        public event ReadDoingCallBack ReadDoingNotice = null;
        public HanJieOPC.OPCHelperPointSetting _OPCHelper = null;
        public LuoLiuDianHan.PeiFang.frmAddPf MyForm = null;
        public bool Interrupt = false;
        Thread _thread = null;
        public bool Running = false;
        public string Listening_Err = string.Empty;
        public StartReadPeiFang(LuoLiuDianHan.PeiFang.frmAddPf mForm ,HanJieOPC.OPCHelperPointSetting opcHelper)
        {
            _OPCHelper = opcHelper;
            this.MyForm = mForm;
        }
        public bool StartListenning(out string sErr)
        {
            if (this.Running)
            {
                sErr = "焊点坐标读取中，请勿重复打开。";
                return false;
            }
            
            if (this.Interrupt)
                this.Interrupt = false;
            Listening_Err = string.Empty;
            if(!this._OPCHelper.SetReadDoing(1,out sErr))
            {
                return false;
            }
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
        public void Listen()
        {
            this.Running = true;
            this.Listening();
            if (this.Running)
                this.Running = false;
        }
        public void Listening()
        {
            while (true)
            {
                if (!this.Running)
                {
                    this.ShowLogAsyn("读取过程以被终止。");
                    break;
                }
                if (!StartNow()) continue;
                //通知主窗体可以了
                CallReadDoingNoticeAsyn();
                this.Running = false;
                return;
            }
        }
        #region 功能函数
        int _LCnt = 0;
        int _RCnt = 0;
        short _ReadDoing = 0;
        private bool StartNow()
        {
            Thread.Sleep(20);
            if (!this._OPCHelper.ReadDoing(out _ReadDoing, out this._LCnt, out this._RCnt, out this.Listening_Err))
            {
                this.ShowErrAsyn(this.Listening_Err);
                return false;
            }
            if (this._ReadDoing != 1) return false;
            if (this._LCnt == 0 && this._RCnt == 0) return false;
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
            frmMyLogB.ShowMyLog(sMsg);
        }
        public void CallReadDoingNoticeAsyn()
        {
            ReadDoingCallBack call = new ReadDoingCallBack(CallReadDoingNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { this._LCnt, this._RCnt });
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
                return;
            }
        }
        public void CallReadDoingNotice(int iPlanLCnt, int iPlanRCnt)
        {
            if (this.ReadDoingNotice != null)
                this.ReadDoingNotice(iPlanLCnt, iPlanRCnt);
        }

        #endregion
        #region 相关类
        public delegate void ReadDoingCallBack(int iPlanLCnt, int iPlanRCnt);
        #endregion
    }
    public class ReadPeiFangSend2PLc
    {
        public event SendPLCFinishedCallBack SendFinishedNotice = null;
        public event DataSendPlcCallBack DataSendPlcNotce = null;
        public PeiFang.frmPfSendPLCProcess MyForm = null;
        public ReadPeiFangSend2PLc(PeiFang.frmPfSendPLCProcess form, HanJieOPC.OPCHelperPointSetting opcHelper)
        {
            this.MyForm = form;
            this._OPCHelper = opcHelper;
        }
        /// <summary>
        /// 当前模块编号
        /// </summary>

        /// <summary>
        /// 当前已经读到第几个焊接点了，从0开始计数
        /// </summary>
        public int _N = 0;
        public bool Interrupt = false;
        Thread _thread = null;
        public bool Running = false;
        public string Listening_Err = string.Empty;
        public bool Listening_Compeleted ;
        public HanJieOPC.OPCHelperPointSetting _OPCHelper = null;
        public DataTable _Points = null;
        public void StopListenning()
        {
            this.Running = false;

        }
        public bool StartListenning(DataTable dtSource,out string sErr)
        {
            if (this.Running)
            {
                sErr = "焊点坐标读取中，请勿重复打开。";
                return false;
            }
            if (!InitOPCHelperB(out sErr)) return false;
            if (this.Interrupt)
                this.Interrupt = false;
            Listening_Err = string.Empty;
            this.InitData();
            this._Points = dtSource;
            this._MySetp = MySetps.None;
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
        public void Listen()
        {
            this.Running = true;
            this._N = 0;
            this.Listening();
            if (this.Running)
                this.Running = false;
        }
        MySetps _MySetp = MySetps.None;
        public void Listening()
        {
            while (true)
            {
                if (!this.Running)
                {
                    CallReadFinishedNoticeAsyn(false);
                    this.ShowLogAsyn("读取过程以被终止。");
                    break;
                }
                if (this._MySetp == MySetps.None || this._MySetp == MySetps.ReadPIndex)
                {
                    if (!this.ReadPIndex()) continue;
                    else this._MySetp = MySetps.GetData;
                }
                if (this._MySetp == MySetps.GetData)
                {
                    //此时开始读取各节点值了
                    if (!GetData()) continue;
                    else this._MySetp = MySetps.SaveData;
                }
                if (this._MySetp == MySetps.SaveData)
                {
                    //读取成功，则开始存入数据,注意这个存入是指存入到PLC
                    if (!SaveData(out Listening_Compeleted)) continue;
                    if(this.Listening_Compeleted)
                    {
                        //结束了
                        this._MySetp = MySetps.Compeleted;
                    }
                    else
                    {
                        //还未结束
                        this._MySetp = MySetps.ReadPIndex;
                    }
                }
                if (this._MySetp == MySetps.Compeleted)
                {
                    this.Running = false;
                    //通知主程序，已经完成了
                    this.ShowLogAsyn("已经完成写入PLC，并且通知了主程序结束进程。");
                    CallReadFinishedNoticeAsyn(true);
                    return;
                }
            }
        }
        #region 公共函数
        public bool ConnectMac(out string sErr)
        {
            if (!InitOPCHelperB(out sErr)) return false;
            return true;
        }
        public void DisconnectMac()
        {
            if (this._OPCHelper != null)
            {
                string sErr;
                if (!this._OPCHelper.CloseOPC(out sErr))
                {
                    this.ShowErrAsyn(sErr);
                }
            }
        }

        public void ClearData()
        {
            if (this.Running)
                this.StopListenning();
            this.InitData();
            this._PIndex = 0;
        }
        #endregion
        #region 通讯结果值存储
        int _RowIndex = 0;
        short _PIndex = 0;
        MyDataEntity _P1 = null;
        MyDataEntity _P2 = null;
        MyDataEntity _P3 = null;
        MyDataEntity _P4 = null;
        private void InitData()
        {
            _P1 = new MyDataEntity();
            _P2 = new MyDataEntity();
            _P3 = new MyDataEntity();
            _P4 = new MyDataEntity();
            this._PIndex = 0;
            this._RowIndex = 0;
            this.Tmp_PIndex = 0;
            this.Tmp_DataErrMsg = string.Empty;
            this.Tmp_ErrMsg = string.Empty;
            this.Tmp_SendCnt = 0;
            this._PreIndex = -999;
        }
        #endregion
        #region 功能函数
        /// <summary>
        /// 上一次读取到的数据
        /// </summary>
        int _PreIndex = 0;
        public int MaxRowIndex = 1000000;
        short Tmp_PIndex = -999;
        short Tmp_SendCnt = 0;
        string Tmp_ErrMsg = string.Empty;
        private bool ReadPIndex()
        {
            if (this._RowIndex >= MaxRowIndex) return false;
            if (ReadPeiFangManagerConfig.SendPLCPIndexDelayer > 0)
            {
                Thread.Sleep(ReadPeiFangManagerConfig.SendPLCPIndexDelayer);
            }
            //读取当前序列号
            if (!this._OPCHelper.ReadPIndex(out Tmp_PIndex, out Tmp_ErrMsg))
            {
                this.ShowErrAsyn(Tmp_ErrMsg);
                return false;
            }
            if (_PreIndex == Tmp_PIndex)
            {
                this.ShowLogAsyn(string.Format("读取到和之前的值一样,row={0},read={1}", this._RowIndex, Tmp_PIndex));
                return false;
            }
            if (Tmp_PIndex < 0)
            {
                this._PreIndex = Tmp_PIndex;
                this.ShowLogAsyn(string.Format("读取到PIndex的PLC值为：{0}，开始写入PLC", Tmp_PIndex));
                return true;
            }
            if (this._RowIndex <= 0)
            {
                if (Tmp_PIndex == 0)
                {
                    this._PreIndex = Tmp_PIndex;
                    this.ShowLogAsyn(string.Format("第一个点时读取到PIndex的PLC值为：{0}，开始写入PLC", Tmp_PIndex));
                    return true;
                }
            }
            return false;
        }
        string Tmp_DataErrMsg = string.Empty;
        private bool GetData()
        {
            if (!GetData(out Tmp_DataErrMsg))
            {
                this.ShowErrAsyn(Tmp_DataErrMsg);
                return false;
            }
            return true;
        }
      
        private bool GetData(out string sErr)
        {
            sErr = string.Empty;
            if(_Points==null)
            {
                sErr = "坐标的数据源为空";
                return false;
            }
            if(this._RowIndex>=this._Points.DefaultView.Count)
            {
                sErr = string.Format("点位序号超出了数据范围(点位={0}，明细数量={1})", this._RowIndex, this._Points.DefaultView.Count);
                return false;
            }
            //设置_MyData1数据
            DataRow dr = this._Points.DefaultView[this._RowIndex].Row;
            if (!CheckData(dr, out sErr)) return false;
            this._PIndex = short.Parse(dr["Pindex"].ToString());
            bool isLeft = this._PIndex < 20000;//是否是左边的点
            this._P1.Active = true;
            this._P1.P_Work = bool.Parse(dr["P_Work"].ToString());
            this._P1.P_Type = int.Parse(dr["P_Type"].ToString());
            this._P1.P_AY = int.Parse(dr["P_AY"].ToString());
            this._P1.P_AZ = int.Parse(dr["P_AZ"].ToString());
            this._P1.P_BY = int.Parse(dr["P_BY"].ToString());
            this._P1.P_BZ = int.Parse(dr["P_BZ"].ToString());
            this.ShowLogAsyn(string.Format("从数据源总共{0}行，当前数据：row={1},左右={2},Pindex={3}", this._Points.DefaultView.Count, this._RowIndex, isLeft, this._PIndex));
            this._RowIndex++;
            if (!SetDataEntity(isLeft, this._P2, ref this._RowIndex, out sErr)) return false;
            this.ShowLogAsyn(string.Format("PLC点位组2值：Active={0}", this._P2.Active));
            if (!SetDataEntity(isLeft, this._P3, ref this._RowIndex, out sErr)) return false;
            this.ShowLogAsyn(string.Format("PLC点位组3值：Active={0}", this._P3.Active));
            if (!SetDataEntity(isLeft, this._P4, ref this._RowIndex, out sErr)) return false;
            this.ShowLogAsyn(string.Format("PLC点位组4值：Active={0}", this._P4.Active));
            return true;
        }
        private bool SetDataEntity(bool isLeft, MyDataEntity data, ref int iRowIndex, out string sErr)
        {
            if (iRowIndex >= this._Points.DefaultView.Count)
            {
                data = new MyDataEntity(false);
                sErr = string.Empty;
                return true;
            }
            //校验数据是否正确
            DataRow dr = this._Points.DefaultView[iRowIndex].Row;
            if (!this.CheckData(dr, out sErr)) return false;
            Tmp_PIndex= short.Parse(dr["Pindex"].ToString());
            if(isLeft)
            {
                if(Tmp_PIndex>20000)
                {
                    data = new MyDataEntity(false);
                    sErr = string.Empty;
                    this.ShowLogAsyn("当前点序号超过2万，与第一个点不符合，等待下一次发送。");
                    return true;
                }
            }
            else
            {
                if (Tmp_PIndex < 20000)
                {
                    data = new MyDataEntity(false);
                    sErr = string.Empty;
                    sErr = "当前点序号小于2万，与第一个点不符合，这是不允许的。";
                    return false;
                }
            }
            //此时符合了
            data.Active = true;
            data.P_Work = bool.Parse(dr["P_Work"].ToString());
            data.P_Type = int.Parse(dr["P_Type"].ToString());
            data.P_AY = int.Parse(dr["P_AY"].ToString());
            data.P_AZ = int.Parse(dr["P_AZ"].ToString());
            data.P_BY = int.Parse(dr["P_BY"].ToString());
            data.P_BZ = int.Parse(dr["P_BZ"].ToString());
            iRowIndex++;
            sErr = string.Empty;
            return true;
        }
        private bool CheckData(DataRow dr,out string sErr)
        {
            //校验数据
            if(dr["Pindex"].Equals(DBNull.Value))
            {
                sErr = string.Format("Pindex字段为空，这是不允许的！");
                return false;
            }
            if (dr["P_Work"].Equals(DBNull.Value))
            {
                sErr = string.Format("P_Work字段为空，这是不允许的！");
                return false;
            }
            if (dr["P_Type"].Equals(DBNull.Value))
            {
                sErr = string.Format("P_Type字段为空，这是不允许的！");
                return false;
            }
            if (dr["P_AY"].Equals(DBNull.Value))
            {
                sErr = string.Format("P_AY字段为空，这是不允许的！");
                return false;
            }
            if (dr["P_AZ"].Equals(DBNull.Value))
            {
                sErr = string.Format("P_AZ字段为空，这是不允许的！");
                return false;
            }
            if (dr["P_BY"].Equals(DBNull.Value))
            {
                sErr = string.Format("P_BY字段为空，这是不允许的！");
                return false;
            }
            if (dr["P_BZ"].Equals(DBNull.Value))
            {
                sErr = string.Format("P_BZ字段为空，这是不允许的！");
                return false;
            }
            sErr = string.Empty;
            return true;
        }

        private bool SaveData(out bool blCompeleted)
        {
            //判断当前的是否已经完成了
            blCompeleted = this._RowIndex >= this._Points.DefaultView.Count;
            //将数据写入PLC，数据通过GetData已经，存入_P1~_P4
            if (this._OPCHelper == null) return false;
            string strErr;
            if(!this._OPCHelper.WritePoints(this._PIndex,(HanJieOPC.DataEntity)this._P1, (HanJieOPC.DataEntity)this._P2, (HanJieOPC.DataEntity)this._P3, (HanJieOPC.DataEntity)this._P4,out strErr))
            {
                this.ShowErrAsyn(strErr);
                return false;
            }
            this.ShowLogAsyn(string.Format("点{7},P1[active={0},work={1},type={2},Ay={3},Az={4},By={5},Bz={6}]", this._P1.Active,this._P1.P_Work,this._P1.P_Type, this._P1.P_AY, this._P1.P_AZ, this._P1.P_BY, this._P1.P_BZ, this._PIndex));
            this.ShowLogAsyn(string.Format("点{7},P2[active={0},work={1},type={2},Ay={3},Az={4},By={5},Bz={6}]", this._P2.Active, this._P2.P_Work, this._P2.P_Type, this._P2.P_AY, this._P2.P_AZ, this._P2.P_BY, this._P2.P_BZ, this._PIndex));
            this.ShowLogAsyn(string.Format("点{7},P3[active={0},work={1},type={2},Ay={3},Az={4},By={5},Bz={6}]", this._P3.Active, this._P3.P_Work, this._P3.P_Type, this._P3.P_AY, this._P3.P_AZ, this._P3.P_BY, this._P3.P_BZ, this._PIndex));
            this.ShowLogAsyn(string.Format("点{7},P4[active={0},work={1},type={2},Ay={3},Az={4},By={5},Bz={6}]", this._P4.Active, this._P4.P_Work, this._P4.P_Type, this._P4.P_AY, this._P4.P_AZ, this._P4.P_BY, this._P4.P_BZ, this._PIndex));
            //通知主程序
            Tmp_SendCnt = 0;
            if (this._P1.Active) Tmp_SendCnt++;
            if (this._P2.Active) Tmp_SendCnt++;
            if (this._P3.Active) Tmp_SendCnt++;
            if (this._P4.Active) Tmp_SendCnt++;
            this.CallDataFromPlcNoticeAsyn(this._RowIndex, Tmp_SendCnt);
            return true;
        }
        
        public void SetInterrupt(bool blInterrupt)
        {
            if (this.Interrupt != blInterrupt)
                this.Interrupt = blInterrupt;
        }
        #endregion
        #region 执行OPC通讯
        private bool InitOPCHelperB(out string sErr)
        {
            if (_OPCHelper == null)
            {
                _OPCHelper = new HanJieOPC.OPCHelperPointSetting(Config.GetOPCTitle);
                _OPCHelper.IsDebug = Debug.OPCDebug;
            }
            if (!this._OPCHelper.InitServer(out sErr))
            {
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
            frmMyLogB.ShowMyLog(sMsg);
        }
        public void CallReadFinishedNoticeAsyn(bool blCompeleted)
        {
            SendPLCFinishedCallBack call = new SendPLCFinishedCallBack(CallReadFinishedNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { blCompeleted,  this._RowIndex });
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("Call Asyn Error(X01.1):{0}({1})", ex.Message, ex.Source));
            }
        }
        public void CallReadFinishedNotice(bool blCompeleted, int RowCnt)
        {
            if (this.SendFinishedNotice != null)
            {
                this.SendFinishedNotice(blCompeleted, RowCnt);
            }
        }
        public void CallDataFromPlcNoticeAsyn(int iStart, int iSendCnt)
        {
            DataSendPlcCallBack call = new DataSendPlcCallBack(CallDataFromPlcNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { iStart, iSendCnt });
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("Call Asyn Error(X01.2):{0}({1})", ex.Message, ex.Source));
            }
        }
        public void CallDataFromPlcNotice(int iStart,  int iSendCnt)
        {
            if (this.DataSendPlcNotce != null)
                this.DataSendPlcNotce(iStart, iSendCnt);
        }
        #endregion
        #region 相关类
        public delegate void SendPLCFinishedCallBack(bool blCompeleted, int RowCnt);
        public delegate void DataSendPlcCallBack(int iStart, int iSendCnt);
        private enum MySetps
        {
            None = 0,
            ReadPIndex = 1,
            GetData = 2,
            SaveData = 3,
            NextPIndex = 4,
            Compeleted = 5
        }
        public class MyDataEntity : HanJieOPC.DataEntity
        {
            public bool Active = false;
            public MyDataEntity()
            {
            }
            public MyDataEntity(bool blActive)
            {
                this.Active = blActive;
            }
            public MyDataEntity(HanJieOPC.DataEntity data)
            {
                this.Active = true;
                this.P_Work = data.P_Work;
                this.P_Type = data.P_Type;
                this.P_AY = data.P_AY;
                this.P_AZ = data.P_AZ;
                this.P_BY = data.P_BY;
                this.P_BZ = data.P_BZ;
            }

        }
        #endregion
    }
}
