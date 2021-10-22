using AutoAssign.JPSEnum;
using Common;
using JpsOPC.OPCEntitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoAssign.JPSEntity
{
    public class ModeView
    {
        public object ModeIsNeter = DBNull.Value;
        public object ModeIsScaner = DBNull.Value;
    }
    #region  扫描枪控制器
    public class ScannControler
    {
        public SocketClient _Scanner1 = null;
        public SocketClient _Scanner2 = null;
        
        public frmMain1 MyForm = null;
        public ScannControler(frmMain1 mainForm, JpsOPC.OPCHelperBat opcHelpBat)
        {
            this.MyForm = mainForm;
            //初始话子对象，这里必须要将子对象中的关键字段补全
            _Scanner1 = new SocketClient(this, 1, opcHelpBat);
            _Scanner1.SocketClientReceveOrginalDataNotice += _Scanner1_SocketClientReceveOrginalDataNotice;
            _Scanner1.ShowLogNotice += _Scanner1_ShowLogNotice;
            _Scanner1.SocketClientAnalyzeDataNotice += _Scanner1_SocketClientAnalyzeDataNotice;
            _Scanner1.SocketClientRefreshStatusNotice += _Scanner1_SocketClientRefreshStatusNotice;
            _Scanner2 = new SocketClient(this, 2, opcHelpBat);
            _Scanner2.SocketClientReceveOrginalDataNotice += _Scanner2_SocketClientReceveOrginalDataNotice;
            _Scanner2.ShowLogNotice += _Scanner2_ShowLogNotice;
            _Scanner2.SocketClientAnalyzeDataNotice += _Scanner2_SocketClientAnalyzeDataNotice;
            _Scanner2.SocketClientRefreshStatusNotice += _Scanner2_SocketClientRefreshStatusNotice;
        }
        private void _Scanner1_SocketClientRefreshStatusNotice(ScannerTextStates state)
        {
            JPSEntity.SocketClientRefreshStatusCallBack call = new SocketClientRefreshStatusCallBack(_Scanner1_MainRefreshStatusNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { state });
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }

        private void _Scanner2_SocketClientRefreshStatusNotice(ScannerTextStates state)
        {
            JPSEntity.SocketClientRefreshStatusCallBack call = new SocketClientRefreshStatusCallBack(_Scanner2_MainRefreshStatusNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { state });
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }


        private void _Scanner1_SocketClientAnalyzeDataNotice(ScannerDianXinData[] codeEntitys, int iValue)
        {
            if (!this.MyForm.IsFormBatDataOpened) return;
            JPSEntity.SocketClientAnalyzeDataCallBack call = new SocketClientAnalyzeDataCallBack(RefreshAnalyzeDataNotice1);
            try
            {
                this.MyForm.Invoke(call, new object[] { codeEntitys, iValue });
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }
        private void _Scanner2_SocketClientAnalyzeDataNotice(ScannerDianXinData[] codeEntitys, int iValue)
        {
            if (!this.MyForm.IsFormBatDataOpened) return;
            JPSEntity.SocketClientAnalyzeDataCallBack call = new SocketClientAnalyzeDataCallBack(RefreshAnalyzeDataNotice2);
            try
            {
                this.MyForm.Invoke(call, new object[] { codeEntitys, iValue });
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }
       
        private void _Scanner1_ShowLogNotice(string sMsg)
        {
            //直接显示日志消息
            frmScanner1Log.ShowMyLog(sMsg);
        }
        private void _Scanner2_ShowLogNotice(string sMsg)
        {
            //直接显示日志消息
            frmScanner2Log.ShowMyLog(sMsg);
        }
        #region 公共函数
        public bool Init(out string sErr)
        {
            if (!JPSConfig.Scaner1_Terminated)
            {
                this._Scanner1.SetScannerIP(JPSConfig.Scaner1_IP, JPSConfig.Scaner1_Port);
                if (!_Scanner1.InitSocket(out sErr)) return false;
                this._Scanner1.InitState();
            }
            if (!JPSConfig.Scaner2_Terminated)
            {
                this._Scanner2.SetScannerIP(JPSConfig.Scaner2_IP, JPSConfig.Scaner2_Port);
                if (!_Scanner2.InitSocket(out sErr)) return false;
                this._Scanner2.InitState();
            }
            sErr = "";
            return true;
        }
        /// <summary>
        /// 设置OPC对象，所有OPC对象创建
        /// </summary>

        public void SetTestingData(bool blCheckerMBatchNum, string sMBatchCode, bool blChongFuChecker, bool blCharChecker, string sBatteryTable, string sResultTable)
        {
            if (this._Scanner1 != null)
                this._Scanner1.SetTestingData(blCheckerMBatchNum, sMBatchCode, blChongFuChecker, blCharChecker, sBatteryTable, sResultTable);
            if (this._Scanner2 != null)
                this._Scanner2.SetTestingData(blCheckerMBatchNum, sMBatchCode, blChongFuChecker, blCharChecker, sBatteryTable, sResultTable);
        }
        public bool StartListenning(out string sErr)
        {
            bool blScanner1Sucessful = true;
            bool blScanner2Sucessful = true;
            string strErr1 = string.Empty, strErr2 = string.Empty;
            if (!JPSConfig.Scaner1_Terminated)
            {
                blScanner1Sucessful = StartListenning1(out strErr1);
            }
            if (!JPSConfig.Scaner2_Terminated)
            {
                blScanner2Sucessful= StartListenning2(out strErr2);
            }
            if(!blScanner1Sucessful || !blScanner2Sucessful)
            {
                sErr = strErr1;
                if(strErr2.Length>0)
                {
                    if (sErr.Length > 0) sErr += "；";
                    sErr += strErr2;
                }
                return false;
            }
            sErr = "";
            return true;
        }
        public bool StartListenning1(out string sErr)
        {
            if(JPSConfig.Scaner1_Terminated)
            {
                sErr = "扫描枪1当前为停用状态。";
                return false;
            }
            if (this._Scanner1 == null)
            {
                if (!_Scanner1.InitSocket(out sErr)) return false;
            }
            else
            {
                if (this._Scanner1.IP != JPSConfig.Scaner1_IP || this._Scanner1.Port != JPSConfig.Scaner1_Port)
                {
                    //此时重新初始化
                    if (this._Scanner1.Running)
                    {
                        if (!this._Scanner1.StopListenning(out sErr)) return false;
                    }
                    if (!this._Scanner1.InitSocket(out sErr)) return false;
                }
            }
            if (this._Scanner1 == null)
            {
                sErr = "扫描枪1启动失败！";
                return false;
            }
            else
            {
                if (!this._Scanner1.StartListenning(out sErr)) return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool StartListenning2(out string sErr)
        {
            if (JPSConfig.Scaner2_Terminated)
            {
                sErr = "扫描枪2当前为停用状态。";
                return false;
            }
            if (this._Scanner2 == null)
            {
                if (!_Scanner2.InitSocket(out sErr)) return false;
            }
            else
            {
                if (this._Scanner2.IP != JPSConfig.Scaner2_IP || this._Scanner2.Port != JPSConfig.Scaner2_Port)
                {
                    //此时重新初始化
                    if (this._Scanner2.Running)
                    {
                        if (!this._Scanner2.StopListenning(out sErr)) return false;
                    }
                    if (!this._Scanner2.InitSocket(out sErr)) return false;
                }
            }
            if (this._Scanner2 == null)
            {
                sErr = "扫描枪2启动失败！";
                return false;
            }
            else
            {
                if (!this._Scanner2.StartListenning(out sErr)) return false;
            }
            sErr = string.Empty;
            return true;
        }
        
        #endregion
        private void _Scanner1_SocketClientReceveOrginalDataNotice(string sData)
        {
            
            if(this.MyForm.IsFormScannerDebugOpened)
            {
                this.RefreshScanner1DataAsyn(sData);
            }
        }
        private void _Scanner2_SocketClientReceveOrginalDataNotice(string sData)
        {
            if (this.MyForm.IsFormScannerDebugOpened)
            {
                this.RefreshScanner2DataAsyn(sData);
            }    
        }
        
        #region 消息
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
            //if (this.IsFormForOperatorOpend)
            //    this.MsgFormForOperator_AddMsg(sMsg, true);
            //else
            //{
            //    this.MyForm.ShowErr(sMsg);
            //}
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
            frmScanner1Log.ShowMyLog(sMsg);
        }
        public void RefreshScanner1DataAsyn(string sMsg)
        {
            ShowMsgAsynCallBack cb = new ShowMsgAsynCallBack(RefreshScanner1Data);
            try
            {
                this.MyForm.Invoke(cb, new object[1] { sMsg });
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public void RefreshScanner2DataAsyn(string sMsg)
        {
            ShowMsgAsynCallBack cb = new ShowMsgAsynCallBack(RefreshScanner2Data);
            try
            {
                this.MyForm.Invoke(cb, new object[1] { sMsg });
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public void RefreshScanner1Data(string sMsg)
        {
            this.MyForm.RefreshScanner1Data(sMsg);
        }
        public void RefreshScanner2Data(string sMsg)
        {
            this.MyForm.RefreshScanner2Data(sMsg);
        }
        private void RefreshAnalyzeDataNotice1(ScannerDianXinData[] codeEntitys, int iValue)
        {
            if (this.MyForm.FormBatData != null && !this.MyForm.FormBatData.IsDisposed)
                this.MyForm.FormBatData.RefreshData1(codeEntitys, iValue);
        }
        private void RefreshAnalyzeDataNotice2(ScannerDianXinData[] codeEntitys, int iValue)
        {
            if (this.MyForm.FormBatData != null && !this.MyForm.FormBatData.IsDisposed)
                this.MyForm.FormBatData.RefreshData2(codeEntitys, iValue);
        }
        public void _Scanner1_MainRefreshStatusNotice(ScannerTextStates state)
        {
            this.MyForm.RefehsScanner1State(state);
        }
        public void _Scanner2_MainRefreshStatusNotice(ScannerTextStates state)
        {
            this.MyForm.RefehsScanner2State(state);
        }
        #endregion
    }
    #endregion
    #region  扫描枪对象
    public class SocketClient
    {
        /// <summary>
        /// 扫描枪1读取到的电芯明细
        /// </summary>
        public static string Scanner1Sns = string.Empty;
        /// <summary>
        /// 扫描枪2读取到的电芯明细
        /// </summary>
        public static string Scanner2Sns = string.Empty;
        public static bool ChongFu(string sDxSN, string sOtherScannerText)
        {
            return false;//暂时先不启用该功能，一般重复的话是扫描枪把另外一组的电芯条码给扫过来了。
            if (sDxSN.Length == 0) return false;
            //sOtherScannerText的格式为“,X,X,X,X,”
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(string.Format(",{0},", sDxSN), System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Match mc = reg.Match(sOtherScannerText);
            if (mc == null || String.IsNullOrEmpty(mc.Value) || mc.Value.Length == 0) return false;
            return true;
        }
        public event SocketClientRefreshStatusCallBack SocketClientRefreshStatusNotice = null;
        public event ShowMsgAsynCallBack ShowLogNotice = null;
        public event SocketClientAnalyzeDataCallBack SocketClientAnalyzeDataNotice = null;
        /// <summary>
        /// 当前扫描枪的上级控制对象
        /// </summary>
        ScannControler _ScannControler = null;
        /// <summary>
        /// 是否开启来料工单检查
        /// </summary>
        public bool _CheckerMBatchNum = false;
        /// <summary>
        /// 来料批次号(注意：传入必须是大写的)
        /// </summary>
        public string _MBatchCode = string.Empty;
        /// <summary>
        /// 当前第几个扫描枪。1：第一把扫描枪，2：第二把扫描枪
        /// </summary>
        short _ScannerNo = 0;
        /// <summary>
        /// 是否开启电池编号的重复校验
        /// </summary>
        public bool _CheckChongFu = false;
        /// <summary>
        /// 是否开启非法字符校验
        /// </summary>
        public bool _CheckChar = false;
        /// <summary>
        /// 存储电池上传数据的表
        /// </summary>
        public string _BatteryTable = string.Empty;
        public string _ResultTable = string.Empty;
        System.Text.RegularExpressions.Regex _CharRegular = new System.Text.RegularExpressions.Regex("[^0-9a-zA-Z#]", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex _SNCharRegular = new System.Text.RegularExpressions.Regex("[^0-9a-zA-Z]", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        #region 控制流程的关键字段
        /// <summary>
        /// 表示正在处于等待状态，即等待扫描枪把编号发过来，如果不是等待状态的话，不用启用receive函数，该线程继续while
        /// </summary>
        public JPSEnum.ScannerStates _State = JPSEnum.ScannerStates.None;
        public bool _State_SocketReceiving = false;
        #endregion
        #region PLC写入对象
        JpsOPC.OPCHelperBat _OPCHelpBat = null;
        #endregion        
        public event SocketClientReceveOrginalDataCallBack SocketClientReceveOrginalDataNotice = null;
        /// <summary>
        /// 等待发来数据的iP地址
        /// </summary>
        public string IP;
        public int Port;
        /// <summary>
        /// 标识当前通讯是否中断状态
        /// </summary>
        public bool Interrupt = false;
        Thread _thread = null;
        Socket _client = null;
        Socket _socket = null;
        /// <summary>
        /// 运行
        /// </summary>
        public bool Running = false;
        public SocketClient(ScannControler control, short scannerNo, JpsOPC.OPCHelperBat opcHelpBat)
        {
            this._ScannControler = control;
            this._ScannerNo = scannerNo;
            this._OPCHelpBat = opcHelpBat;
        }
        /// <summary>
        /// 初始化当前实例
        /// </summary>
        /// <param name="sErr">初始化出错</param>
        /// <returns></returns>
        public bool InitSocket(out string sErr)
        {
            if (this.IP.Length == 0 || this.Port <= 0)
            {
                sErr = string.Format("请正确配置扫描枪{0}的IP地址和端口号。", this._ScannerNo);
                return false;
            }
            if (this._client != null && this._client.Connected)
            {
                sErr = string.Empty;
                return true;
            }
            try
            {
                IPAddress ip = IPAddress.Parse(this.IP);
                this._client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    this._client.Connect(new IPEndPoint(ip, this.Port)); //配置服务器IP与端口
                    this._client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, JPSConfig.Scaner_TimeoutMiilSeconds);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("初始化通讯端口失败：{0}({1})。", ex.Message, ex.Source);
                    return false;
                }
            }
            catch (Exception ex)
            {
                sErr = string.Format("初始化出错：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool StartListenning(out string sErr)
        {
            if (this.Running)
            {
                sErr = string.Format("扫描枪{0}：监听已经开启，请勿重复打开。", this._ScannerNo);
                return false;
            }
            if (this.IP.Length == 0)
            {
                sErr = "扫描枪IP地址不能为空。";
                return false;
            }
            if (this.Port <= 0)
            {
                sErr = "扫描枪端口号不能为空。";
                return false;
            }
            if (!this.InitSocket(out sErr)) return false;
            this.Running = true;
            this.Listen_PLCIO_IsZero = false;//初始化为false，这样：读取到0时可以直接扫描了
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(Listen));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("IP\"{0}\"启动监听时出错：{1}({2})", this.IP, ex.Message, ex.Source);
                this.Running = false;
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool StopListenning(out string sErr)
        {
            sErr = string.Empty;
            this.Running = false;
            return true;
        }
        private void Listen()
        {
            while (true)
            {
                if (!this.Running)
                {
                    this.ShowLogAsyn(string.Format("扫描枪{0}：停止。", this._ScannerNo));
                    break;
                }
                if (this._ScannControler.MyForm._TestState != JPSEnum.TestStates.Testing)
                {
                    continue;
                }
                if (this._State == JPSEnum.ScannerStates.ReadingPLCIOValue || this._State == JPSEnum.ScannerStates.None)
                {
                    Thread.Sleep(JPSConfig.SocketClientSleepMillSeconds);
                    if (SocketClientRefreshStatusNotice != null)
                        SocketClientRefreshStatusNotice(JPSEnum.ScannerTextStates.WattingScann);
                    //此时实时读取PLC开关量
                    if (!Listen_PLCIO()) continue;//此时还要继续读取PLC地址。
                    //此时已经表示电芯开关量信息已经被设置为0了，就是说通知程序可以读取下一组电池了
                    this.ShowLogAsyn(string.Format("扫描枪{0}：PLC通知读取条码。", this._ScannerNo));
                    this._State = JPSEnum.ScannerStates.ReadBlockNo;
                }
                if (this._State == JPSEnum.ScannerStates.ReadBlockNo)
                {
                    if (!this.Listen_ReadBlockNo()) continue;
                    this._State = JPSEnum.ScannerStates.NoticeScannerReadBarCode;
                }
                if (this._State == JPSEnum.ScannerStates.NoticeScannerReadBarCode)
                {
                    //通知扫描枪可以发送电池过来了
                    if (!this.SendText("LON")) continue;//发送失败则继续发送
                    if (SocketClientRefreshStatusNotice != null)
                        SocketClientRefreshStatusNotice(JPSEnum.ScannerTextStates.WattingData);
                    // this.ShowLogAsyn(string.Format("扫描枪{0}：已成功发送LON命令。", this._ScannerNo));
                    //此时已经发送了，这里要打开计时器
                    this.Listen_SendLONTime = DateTime.Now;
                    this._State = JPSEnum.ScannerStates.SendLON;//已经成功发送了，可以进入监听状态了
                }
                if (this._State == JPSEnum.ScannerStates.SendLON)
                {
                    if (!Listen_Socket())
                    {
                        continue;
                    }
                    //此时已经成功收到信息了，需要将信息写入PLC
                    this._State = JPSEnum.ScannerStates.WriteInotPLC_CheckChongFu;
                }
                if (SocketClientRefreshStatusNotice != null)
                    SocketClientRefreshStatusNotice(JPSEnum.ScannerTextStates.Proing);

                if (this._State == JPSEnum.ScannerStates.WriteInotPLC_CheckChongFu)
                {
                    if (!this.Listen_WriteIntoPLC_CheckChongfu()) continue;
                    this._State = JPSEnum.ScannerStates.WriteInotPLC_GetMyCode;
                }
                if (this._State == JPSEnum.ScannerStates.WriteInotPLC_GetMyCode)
                {
                    if (!this.Listen_WriteIntoPLC_GetMyCode()) continue;
                    if (!this.Listen_WriteIntoPLC_GetDxOrgInfo()) continue;//2020-10-22南京中比添加原始数据读取
                    this._State = JPSEnum.ScannerStates.WriteInotPLC_OPC;
                }
                if (this._State == JPSEnum.ScannerStates.WriteInotPLC_OPC)
                {
                    if (!this.Listen_WriteIntoPLC_OPC()) continue;
                    if (!Listen_WriteIntoPLC_OPC_DxOrgData()) continue;
                    //写入成功，延时
                    this._State = JPSEnum.ScannerStates.ReadingPLCIOValue;
                    //这里存储电芯数据，但出错了就不用管了，毕竟与逻辑无关联
                    //this.Listen_WriteIntoPLC_SaveSN();
                    Thread.Sleep(JPSConfig.SocketClientSleepMillSeconds);
                    //没办法，只能延时了
                    //Thread.Sleep(JPSConfig.DelayerMillScdsAfterBatDataWriteIntoOPC);
                }
            }
        }
        #region 用于Listen的临时变量
        DateTime Listen_SendLONTime;//通知时间
        object Listen_IOValue;
        int Listen_IOValueShort;
        short Listen_BlockNo = 0;
        string Listen_ErrMsg;
        byte[] Listen_Data = new byte[1024];
        short Listen_PLCValue_IO = 0;//写入PLC的IO变量
        string Listen_PLCValue_String = "";//写入PLC的电池编号
        string Listen_ChongFuSns = string.Empty;
        ScannerDianXinData[] Listen_CodeEntitys = new ScannerDianXinData[10];
        //List<string> Listen_SaveSNs;
        bool Listen_PLCIO_IsZero = false;
        #endregion
        public bool _isResetd = false;
        private bool Listen_PLCIO()
        {
            
            //现在一把扫描枪了只有，同时监听2个地址，该函数是从车之翼拷贝过来的。2020-04-20 jiangpengsong
            if (Debug.ScannerOpc.IsDebug)
            {
                Thread.Sleep(500);
                return Debug.ScannerOpc.Bat_Bool1 && Debug.ScannerOpc.Bat_Bool2;
            }
            //实时读取PLC，判断是否已经为0了，因为为0的话需要读取电芯信息了
            if (!this._OPCHelpBat._BatBitValue1.ReadData(out Listen_IOValue, out Listen_ErrMsg))
            {
                this.ShowErrAsyn(string.Format("BatBitValue1.ReadData:{0}", Listen_ErrMsg));
                return false;
            }
            if (Listen_IOValue == null)
            {
                this.ShowErrAsyn("Bat_Bool1的值为空");
                return false;
            }
            if (!int.TryParse(Listen_IOValue.ToString(), out Listen_IOValueShort))
            {
                this.ShowErrAsyn(string.Format("Bat_Bool1的值对象\"{0}\"不是预期的int32类型", Listen_IOValue));
                return false;
            }
            this.ShowLogAsyn("获取Bat_Bool1值为" + Listen_IOValueShort.ToString());
            if (Listen_IOValueShort == 0)
            {
                //Bat_Bool1的值不为空，那就不用在读Bat_Bool2的了，因为逻辑上判断是两者都为0时算0，只要有一个不是0就，不为0；
                if (!this._OPCHelpBat._BatBitValue2.ReadData(out Listen_IOValue, out Listen_ErrMsg))
                {
                    this.ShowErrAsyn(string.Format("BatBitValue2.ReadData:{0}", Listen_ErrMsg));
                    return false;
                }
                if (Listen_IOValue == null)
                {
                    this.ShowErrAsyn("Bat_Bool2的值为空");
                    return false;
                }
                if (!int.TryParse(Listen_IOValue.ToString(), out Listen_IOValueShort))
                {
                    this.ShowErrAsyn(string.Format("Bat_Bool2的值对象\"{0}\"不是预期的int32类型", Listen_IOValue));
                    return false;
                }
            }

            if (Listen_IOValueShort != 0)
            {
                if (this.Listen_PLCIO_IsZero)
                {
                    this.ShowLogAsyn("上一次记录为0，本次标识为不是0;");
                    this.Listen_PLCIO_IsZero = false;
                }
                else
                {
                    this.ShowLogAsyn("上一次记录为不是0，本次不更改。");
                }
                //写入，注意这里永远只有1把扫描枪了，即永远是_ScannerNo == 1
                if (this._ScannerNo == 1)
                {
                    if (!_isResetd)
                    {
                        if (!this._OPCHelpBat._Bat_Bool1Reset.WriteData(true, out Listen_ErrMsg))
                        {
                            //此时写入成功
                            this.ShowErrAsyn("扫描枪1通知PLC清空电芯信息时出错：" + Listen_ErrMsg);
                            return false;
                        }
                        _isResetd = true;//发送过通知了
                                         //此时已经通知PLC了，则这里暂停一会，
                        this.ShowLogAsyn("扫描枪1已通知PLC清空电芯数据，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                    }
                    else
                    {
                        this.ShowLogAsyn("扫描枪1之前已通知PLC清空电芯数据，本次不执行写入，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                    }
                    Thread.Sleep(JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData);
                }
                else
                {
                    if (!_isResetd)
                    {
                        if (!this._OPCHelpBat._Bat_Bool2Reset.WriteData(true, out Listen_ErrMsg))
                        {
                            //此时写入成功
                            this.ShowErrAsyn("扫描枪2通知PLC清空电芯信息时出错：" + Listen_ErrMsg);
                            return false;
                        }
                        _isResetd = true;//发送过通知了
                                         //此时已经通知PLC了，则这里暂停一会，
                        this.ShowLogAsyn("扫描枪2已通知PLC清空电芯数据，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                    }
                    else
                    {
                        this.ShowLogAsyn("扫描枪2之前已通知PLC清空电芯数据，本次不执行写入，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                    }
                    Thread.Sleep(JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData);
                }
                return false;
            }
            else
            {
                _isResetd = false;//如果为0表示清除过过了
                //此时为0了，则要判断一下上一次读取的值是否是0，如果也是0的，则不算
                if (this.Listen_PLCIO_IsZero)
                {
                    this.ShowLogAsyn("上一次记录为0，虽然本次记录为0，但不是可以扫码了;");
                    //此时上一次也是为0
                    return false;
                }
                else
                {
                    this.ShowLogAsyn("上一次记录为不0，而且本次记录为0，可以扫码了;");
                    //此时上一次不是0了，则返回可以读取了
                    this.Listen_PLCIO_IsZero = true;
                    return true;
                }
            }
            //return Listen_IOValueShort == 0;
        }
        private bool Listen_PLCIO原长风的作废()
        {
            /* 陕西的设备只要存储bat_bool1的，2的都不用了，包括编号，复位标识，因为它只有一把扫描枪在使用
             * 这里代码不删除，以便日后读取代码时知道不同客户，不同的逻辑，便于更好的理解代码
            if (this._ScannerNo == 1)
            {
                if (Debug.ScannerOpc.IsDebug)
                {
                    Thread.Sleep(500);
                    return Debug.ScannerOpc.Bat_Bool1;
                }
                //实时读取PLC，判断是否已经为0了，因为为0的话需要读取电芯信息了
                if (!this._OPCHelpBat._BatBitValue1.ReadData(out Listen_IOValue, out Listen_ErrMsg))
                {
                    this.ShowErrAsyn(string.Format("From Scanner{0}:{1}", this._ScannerNo, Listen_ErrMsg));
                    return false;
                }
            }
            else
            {
                if (Debug.ScannerOpc.IsDebug)
                {
                    Thread.Sleep(500);
                    return Debug.ScannerOpc.Bat_Bool2;
                }
                if (!this._OPCHelpBat._BatBitValue2.ReadData(out Listen_IOValue, out Listen_ErrMsg))
                {
                    this.ShowErrAsyn(string.Format("From Scanner{0}:{1}", this._ScannerNo, Listen_ErrMsg));
                    return false;
                }
            }
            ******************/
            ///以上删除的代码改为以下的， 2019-06-27/////////////////////////////////
            if (Debug.ScannerOpc.IsDebug)
            {
                Thread.Sleep(500);
                return Debug.ScannerOpc.Bat_Bool1;
            }
            //实时读取PLC，判断是否已经为0了，因为为0的话需要读取电芯信息了
            if (!this._OPCHelpBat._BatBitValue1.ReadData(out Listen_IOValue, out Listen_ErrMsg))
            {
                this.ShowErrAsyn(string.Format("From Scanner{0}:{1}", this._ScannerNo, Listen_ErrMsg));
                return false;
            }
            ///end/////////////////////////////////
            if (Listen_IOValue == null)
            {
                this.ShowErrAsyn(string.Format("From Scanner{0}:Bat_Bool1的值为空", this._ScannerNo));
                return false;
            }
            if (!int.TryParse(Listen_IOValue.ToString(), out Listen_IOValueShort))
            {
                this.ShowErrAsyn(string.Format("来自Scanner{0}:值对象\"{1}\"不是预期的int32类型", this._ScannerNo, Listen_IOValue));
                return false;
            }
            this.ShowLogAsyn("获取Bat_Bool值为" + Listen_IOValueShort.ToString());
            if (Listen_IOValueShort != 0)
            {
                if (this.Listen_PLCIO_IsZero)
                {
                    this.ShowLogAsyn("上一次记录为0，本次标识为不是0;");
                    this.Listen_PLCIO_IsZero = false;
                }
                else
                {
                    this.ShowLogAsyn("上一次记录为不是0，本次不更改。");
                }
                /**********************
                 * 删除这部分代码，目前只要地址1
                //写入
                if (this._ScannerNo == 1)
                {
                    if (!_isResetd)
                    {
                        if (!this._OPCHelpBat._Bat_Bool1Reset.WriteData(true, out Listen_ErrMsg))
                        {
                            //此时写入成功
                            this.ShowErrAsyn("扫描枪1通知PLC清空电芯信息时出错：" + Listen_ErrMsg);
                            return false;
                        }
                        _isResetd = true;//发送过通知了
                                         //此时已经通知PLC了，则这里暂停一会，
                        this.ShowLogAsyn("扫描枪1已通知PLC清空电芯数据，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                    }
                    else
                    {
                        this.ShowLogAsyn("扫描枪1之前已通知PLC清空电芯数据，本次不执行写入，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                    }
                    Thread.Sleep(JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData);
                }
                else
                {
                    if (!_isResetd)
                    {
                        if (!this._OPCHelpBat._Bat_Bool2Reset.WriteData(true, out Listen_ErrMsg))
                        {
                            //此时写入成功
                            this.ShowErrAsyn("扫描枪2通知PLC清空电芯信息时出错：" + Listen_ErrMsg);
                            return false;
                        }
                        _isResetd = true;//发送过通知了
                                         //此时已经通知PLC了，则这里暂停一会，
                        this.ShowLogAsyn("扫描枪2已通知PLC清空电芯数据，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                    }
                    else
                    {
                        this.ShowLogAsyn("扫描枪2之前已通知PLC清空电芯数据，本次不执行写入，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                    }
                    Thread.Sleep(JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData);
                }
                ***************************/
                ////以上删除的代码改为以下2019-06-27
                if (!_isResetd)
                {
                    if (!this._OPCHelpBat._Bat_Bool1Reset.WriteData(true, out Listen_ErrMsg))
                    {
                        //此时写入成功
                        this.ShowErrAsyn("扫描枪1通知PLC清空电芯信息时出错：" + Listen_ErrMsg);
                        return false;
                    }
                    _isResetd = true;//发送过通知了
                                     //此时已经通知PLC了，则这里暂停一会，
                    this.ShowLogAsyn("扫描枪1已通知PLC清空电芯数据，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                }
                else
                {
                    this.ShowLogAsyn("扫描枪1之前已通知PLC清空电芯数据，本次不执行写入，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                }
                Thread.Sleep(JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData);
                //end/////////////////////
                return false;
            }
            else
            {
                _isResetd = false;//如果为0表示清除过过了
                //此时为0了，则要判断一下上一次读取的值是否是0，如果也是0的，则不算
                if (this.Listen_PLCIO_IsZero)
                {
                    this.ShowLogAsyn("上一次记录为0，虽然本次记录为0，但不是可以扫码了;");
                    //此时上一次也是为0
                    return false;
                }
                else
                {
                    this.ShowLogAsyn("上一次记录为不0，而且本次记录为0，可以扫码了;");
                    //此时上一次不是0了，则返回可以读取了
                    this.Listen_PLCIO_IsZero = true;
                    return true;
                }
            }
            //return Listen_IOValueShort == 0;
        }
        private bool Listen_PLCIO_DISPOSE该函数为湖南项目的()
        {
            //该函数撤销，原先的逻辑有问题，不能Bat_Bool1 和 Bat_Bool2同时为0时读取。因为设备是分两次扫，且等2次扫完后才读取数据，且清空Bat_Bool1和Bat_Bool2
            /*
            if (this._ScannerNo == 1)
            {
                if (Debug.ScannerOpc.IsDebug)
                {
                    Thread.Sleep(500);
                    return Debug.ScannerOpc.Bat_Bool1;
                }
                //实时读取PLC，判断是否已经为0了，因为为0的话需要读取电芯信息了
                if (!this._OPCHelpBat._BatBitValue1.ReadData(out Listen_IOValue, out Listen_ErrMsg))
                {
                    this.ShowErrAsyn(string.Format("From Scanner{0}:{1}", this._ScannerNo, Listen_ErrMsg));
                    return false;
                }
            }
            else
            {
                if (Debug.ScannerOpc.IsDebug)
                {
                    Thread.Sleep(500);
                    return Debug.ScannerOpc.Bat_Bool2;
                }
                if (!this._OPCHelpBat._BatBitValue2.ReadData(out Listen_IOValue, out Listen_ErrMsg))
                {
                    this.ShowErrAsyn(string.Format("From Scanner{0}:{1}", this._ScannerNo, Listen_ErrMsg));
                    return false;
                }
            }
            */
            //现在一把扫描枪了只有，同时监听2个地址
            if (Debug.ScannerOpc.IsDebug)
            {
                Thread.Sleep(500);
                return Debug.ScannerOpc.Bat_Bool1 && Debug.ScannerOpc.Bat_Bool2;
            }
            //实时读取PLC，判断是否已经为0了，因为为0的话需要读取电芯信息了
            if (!this._OPCHelpBat._BatBitValue1.ReadData(out Listen_IOValue, out Listen_ErrMsg))
            {
                this.ShowErrAsyn(string.Format("BatBitValue1.ReadData:{0}", Listen_ErrMsg));
                return false;
            }
            if (Listen_IOValue == null)
            {
                this.ShowErrAsyn("Bat_Bool1的值为空");
                return false;
            }
            if (!int.TryParse(Listen_IOValue.ToString(), out Listen_IOValueShort))
            {
                this.ShowErrAsyn(string.Format("Bat_Bool1的值对象\"{0}\"不是预期的int32类型",  Listen_IOValue));
                return false;
            }
            this.ShowLogAsyn("获取Bat_Bool1值为" + Listen_IOValueShort.ToString());
            if(Listen_IOValueShort==0)
            {
                //Bat_Bool1的值不为空，那就不用在读Bat_Bool2的了，因为逻辑上判断是两者都为0时算0，只要有一个不是0就，不为0；
                if (!this._OPCHelpBat._BatBitValue2.ReadData(out Listen_IOValue, out Listen_ErrMsg))
                {
                    this.ShowErrAsyn(string.Format("BatBitValue2.ReadData:{0}", Listen_ErrMsg));
                    return false;
                }
                if (Listen_IOValue == null)
                {
                    this.ShowErrAsyn("Bat_Bool2的值为空");
                    return false;
                }
                if (!int.TryParse(Listen_IOValue.ToString(), out Listen_IOValueShort))
                {
                    this.ShowErrAsyn(string.Format("Bat_Bool2的值对象\"{0}\"不是预期的int32类型", Listen_IOValue));
                    return false;
                }
            }

            if (Listen_IOValueShort != 0)
            {
                if (this.Listen_PLCIO_IsZero)
                {
                    this.ShowLogAsyn("上一次记录为0，本次标识为不是0;");
                    this.Listen_PLCIO_IsZero = false;
                }
                else
                {
                    this.ShowLogAsyn("上一次记录为不是0，本次不更改。");
                }
                //写入，注意这里永远只有1把扫描枪了，即永远是_ScannerNo == 1；
                //从2019-06-27日开始逻辑改了，该对象socketclient不区分哪把扫描枪了，2个地址同时更改了。
                if (this._ScannerNo == 1)
                {
                    if (!_isResetd)
                    {
                        if (!this._OPCHelpBat._Bat_Bool1Reset.WriteData(true, out Listen_ErrMsg))
                        {
                            //此时写入成功
                            this.ShowErrAsyn("扫描枪1通知PLC清空电芯信息时出错：" + Listen_ErrMsg);
                            return false;
                        }
                        _isResetd = true;//发送过通知了
                                         //此时已经通知PLC了，则这里暂停一会，
                        this.ShowLogAsyn("扫描枪1已通知PLC清空电芯数据，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                    }
                    else
                    {
                        this.ShowLogAsyn("扫描枪1之前已通知PLC清空电芯数据，本次不执行写入，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                    }
                    Thread.Sleep(JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData);
                }
                else
                {
                    if (!_isResetd)
                    {
                        if (!this._OPCHelpBat._Bat_Bool2Reset.WriteData(true, out Listen_ErrMsg))
                        {
                            //此时写入成功
                            this.ShowErrAsyn("扫描枪2通知PLC清空电芯信息时出错：" + Listen_ErrMsg);
                            return false;
                        }
                        _isResetd = true;//发送过通知了
                                         //此时已经通知PLC了，则这里暂停一会，
                        this.ShowLogAsyn("扫描枪2已通知PLC清空电芯数据，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                    }
                    else
                    {
                        this.ShowLogAsyn("扫描枪2之前已通知PLC清空电芯数据，本次不执行写入，线程休眠" + JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData.ToString() + "毫秒。");
                    }
                    Thread.Sleep(JPSConfig.SocketClientDelayerMillSecondsAfterNoticePLcClearBatData);
                }
                return false;
            }
            else
            {
                _isResetd = false;//如果为0表示清除过过了
                //此时为0了，则要判断一下上一次读取的值是否是0，如果也是0的，则不算
                if (this.Listen_PLCIO_IsZero)
                {
                    this.ShowLogAsyn("上一次记录为0，虽然本次记录为0，但不是可以扫码了;");
                    //此时上一次也是为0
                    return false;
                }
                else
                {
                    this.ShowLogAsyn("上一次记录为不0，而且本次记录为0，可以扫码了;");
                    //此时上一次不是0了，则返回可以读取了
                    this.Listen_PLCIO_IsZero = true;
                    return true;
                }
            }
            //return Listen_IOValueShort == 0;
        }
        private bool Listen_ReadBlockNo()
        {
            if (Debug.ScannerOpc.IsDebug)
            {
                Thread.Sleep(500);
                this.Listen_BlockNo = Debug.ScannerOpc.BlockNo;
                return true;
            }
            if (!this._OPCHelpBat.ReadTargetBlockNo(out Listen_BlockNo, out Listen_ErrMsg))
            {
                this.ShowErrAsyn(string.Format("ReadBlockNo.Err:{0}", Listen_ErrMsg));
                return false;
            }
            if (Listen_BlockNo != 1 && Listen_BlockNo != 2)
            {
                this.ShowLogAsyn(string.Format("PLC中BlockNo设定值为：{0}", Listen_BlockNo));
                if (Listen_BlockNo != 0)
                    this.ShowErrAsyn(string.Format("PLC中BlockNo设定值为：{0}，这不是预期的值。", Listen_BlockNo));
                Thread.Sleep(100);//基本上是不可能的，OPC不会这么慢的，除非PLC没有正确赋值
                return false;
            }
            return true;
        }
        private bool Listen_Socket()
        {
            try
            {
                if (this._client == null || !this._client.Connected)
                {
                    string strErr;
                    if (!InitSocket(out strErr))
                    {
                        if (!this.Interrupt) Interrupt = true;
                        this.ShowErrAsyn(strErr);
                        return false;
                    }
                }
                if (this._client == null || !this._client.Connected)
                {
                    if (!this.Interrupt) Interrupt = true;
                    this.ShowErrAsyn("IP：" + this.IP + "的监听工具创建失败。");
                    return false;
                }
                _State_SocketReceiving = true;
                this.ShowLogAsyn(string.Format("扫描枪{0}：等待接收", this._ScannerNo));
                int iReceived = this._client.Receive(Listen_Data);
                _State_SocketReceiving = false;
                if (iReceived == 0)
                {
                    //此时判断是否超时
                    TimeSpan ts = DateTime.Now - this.Listen_SendLONTime;
                    if (ts.TotalMilliseconds > JPSConfig.Scaner_TimeoutMiilSeconds)
                    {
                        this.SendText("LOFF");
                    }
                    return false;
                }
                string strData = Encoding.ASCII.GetString(Listen_Data, 0, iReceived);
                this.ShowLogAsyn(string.Format("扫描枪{0}：收到数据[{1}]", this._ScannerNo, strData));
                this.Listen_Socket_AnalyzeData(strData);//解析数据
                //是有数据
                if (this.Interrupt) Interrupt = false;
                if (this.SocketClientReceveOrginalDataNotice != null)
                    this.SocketClientReceveOrginalDataNotice(strData);
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10060)
                {
                    this.ShowLogAsyn("等待超时：发送LOFF命令。");
                    //此时为超时
                    this.SendText("LOFF");
                }
                return false;
            }
            catch (Exception ex)
            {
                this._client.Disconnect(true);// 关闭，再重新连接过
                this.ShowLogAsyn(ex.Message);
                return false;
            }
            return true;
        }
        private void Listen_Socket_AnalyzeData(string sData)
        {
            System.Text.RegularExpressions.Regex reg;
            System.Text.RegularExpressions.Match mc;
            System.Text.RegularExpressions.Match mcChar;
            bool blCheckChar;
            if (this._CheckChar)
            {
                mcChar = _CharRegular.Match(sData);
                if (this._CheckChar && mcChar != null && !String.IsNullOrEmpty(mcChar.Value)) blCheckChar = true;
                else blCheckChar = false;
            }
            else blCheckChar = false;
            string sPat1, sPat2;
            Listen_ChongFuSns = string.Empty;
            string sSns = ",";
            for (int i = 0; i <= 9; i++)
            {
                sPat1 = i.ToString();
                if (i == 9)
                    sPat2 = "A";
                else sPat2 = Convert.ToString(i + 1);
                //解析出10个条码
                if (this.Listen_CodeEntitys[i] == null)
                    this.Listen_CodeEntitys[i] = new ScannerDianXinData();
                reg = new System.Text.RegularExpressions.Regex(string.Format("{0}#.*{1}#", sPat1, sPat2), System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                mc = reg.Match(sData);
                if (mc == null || mc.Value == string.Empty)
                {
                    this.Listen_CodeEntitys[i].SNCode = string.Empty;
                    this.Listen_CodeEntitys[i].IsNG = true;
                    this.Listen_CodeEntitys[i].MBatchIsOk = true;
                    this.Listen_CodeEntitys[i].IsChongFu = false;
                    this.ShowLogAsyn(string.Format("条码{0}:NG", i));
                }
                else
                {
                    this.Listen_CodeEntitys[i].SNCode = mc.Value.Substring(2, mc.Value.Length - 4);
                    if (string.Compare("ng", this.Listen_CodeEntitys[i].SNCode, true) == 0)
                    {
                        this.Listen_CodeEntitys[i].IsNG = true;
                    }
                    else if (this.Listen_CodeEntitys[i].SNCode.Length == 0)
                    {
                        this.Listen_CodeEntitys[i].IsNG = true;
                    }
                    else
                    {
                        this.Listen_CodeEntitys[i].IsNG = false;
                    }
                    //如果电池没有NG，则校验字符是否过关
                    if (blCheckChar && !this.Listen_CodeEntitys[i].IsNG)
                    {
                        mcChar = _SNCharRegular.Match(this.Listen_CodeEntitys[i].SNCode);
                        if (mcChar != null && !String.IsNullOrEmpty(mcChar.Value))
                        {
                            this.Listen_CodeEntitys[i].IsNG = true;
                            this.ShowLogAsyn(string.Format("第{0}节电池不是NG，但有非法字符{1}，条码判定为NG。", i + 1, mcChar.Value));
                        }
                        else
                        {
                            this.ShowLogAsyn(string.Format("第{0}节电池不是NG，也没有非法字符。", i + 1));
                        }
                    }
                    if (!this._CheckerMBatchNum || this.Listen_CodeEntitys[i].IsNG || (this.Listen_CodeEntitys[i].SNCode.ToUpper().IndexOf(this._MBatchCode) >= 0))
                        this.Listen_CodeEntitys[i].MBatchIsOk = true;//注意，这里不需要判断来料工单或者说条码NG的，都算是来料工单没问题
                    else this.Listen_CodeEntitys[i].MBatchIsOk = false;//这里是在需要判断的情况下，在电池条码中找不到工单号，所以不符合。
                    if (!this.Listen_CodeEntitys[i].IsNG)
                    {
                        Listen_ChongFuSns += string.Format("'{0}',", this.Listen_CodeEntitys[i].SNCode.Replace("'", "''"));
                    }
                    else
                    {
                        this.Listen_CodeEntitys[i].IsChongFu = false;
                    }
                    this.ShowLogAsyn(string.Format("条码{0}:{1}，来料工单({2})：{3}", i, this.Listen_CodeEntitys[i].SNCode, this._MBatchCode, this.Listen_CodeEntitys[i].MBatchIsOk));
                }
                this.Listen_CodeEntitys[i].Index = i;
                sSns += this.Listen_CodeEntitys[i].SNCode + ",";
            }
            if (this.Listen_ChongFuSns.Length > 0)
                this.Listen_ChongFuSns = this.Listen_ChongFuSns.Substring(0, this.Listen_ChongFuSns.Length - 1);
            //存储当前读取到的电芯：暂时不用该功能
            //if (this._ScannerNo == 1)
            //    SocketClient.Scanner1Sns = sSns;
            //else SocketClient.Scanner2Sns = sSns;
        }
        private bool Listen_WriteIntoPLC_GetMyCode()
        {
            //获取系统编号
            string sMyCode0, sMyCode1, sMyCode2, sMyCode3, sMyCode4, sMyCode5, sMyCode6, sMyCode7, sMyCode8, sMyCode9;
            try
            {
                this._ScannControler.MyForm.BllDAL.SaveDianXin(JPSConfig.MacNo.ToString(), this._ScannControler.MyForm._RealTable_Batterys, this.Listen_BlockNo,
                    this.Listen_CodeEntitys[0].SNCode, this.Listen_CodeEntitys[1].SNCode, this.Listen_CodeEntitys[2].SNCode, this.Listen_CodeEntitys[3].SNCode,
                    this.Listen_CodeEntitys[4].SNCode, this.Listen_CodeEntitys[5].SNCode, this.Listen_CodeEntitys[6].SNCode, this.Listen_CodeEntitys[7].SNCode,
                    this.Listen_CodeEntitys[8].SNCode, this.Listen_CodeEntitys[9].SNCode,
                    this.Listen_CodeEntitys[0].IsNG, this.Listen_CodeEntitys[1].IsNG, this.Listen_CodeEntitys[2].IsNG, this.Listen_CodeEntitys[3].IsNG,
                    this.Listen_CodeEntitys[4].IsNG, this.Listen_CodeEntitys[5].IsNG, this.Listen_CodeEntitys[6].IsNG, this.Listen_CodeEntitys[7].IsNG,
                    this.Listen_CodeEntitys[8].IsNG, this.Listen_CodeEntitys[9].IsNG,
                    this.Listen_CodeEntitys[0].MBatchIsOk, this.Listen_CodeEntitys[1].MBatchIsOk, this.Listen_CodeEntitys[2].MBatchIsOk, this.Listen_CodeEntitys[3].MBatchIsOk,
                    this.Listen_CodeEntitys[4].MBatchIsOk, this.Listen_CodeEntitys[5].MBatchIsOk, this.Listen_CodeEntitys[6].MBatchIsOk, this.Listen_CodeEntitys[7].MBatchIsOk,
                    this.Listen_CodeEntitys[8].MBatchIsOk, this.Listen_CodeEntitys[9].MBatchIsOk,
                    this.Listen_CodeEntitys[0].IsChongFu, this.Listen_CodeEntitys[1].IsChongFu, this.Listen_CodeEntitys[2].IsChongFu, this.Listen_CodeEntitys[3].IsChongFu,
                    this.Listen_CodeEntitys[4].IsChongFu, this.Listen_CodeEntitys[5].IsChongFu, this.Listen_CodeEntitys[6].IsChongFu, this.Listen_CodeEntitys[7].IsChongFu,
                    this.Listen_CodeEntitys[8].IsChongFu, this.Listen_CodeEntitys[9].IsChongFu,
                    out sMyCode0, out sMyCode1, out sMyCode2, out sMyCode3, out sMyCode4, out sMyCode5, out sMyCode6, out sMyCode7, out sMyCode8, out sMyCode9);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("扫描枪{0}存入电芯条码时出错：{1}{2}", this._ScannerNo, ex.Message, ex.Source));
                return false;
            }
            this.ShowLogAsyn(string.Format("扫描枪{0}：获取数据库编号：{1}、{2}、{3}、{4}、{5}、{6}、{7}、{8}、{9}、{10}。", this._ScannerNo, sMyCode0, sMyCode1, sMyCode2, sMyCode3, sMyCode4, sMyCode5, sMyCode6, sMyCode7, sMyCode8, sMyCode9));
            this.Listen_CodeEntitys[0].MyCode = sMyCode0;
            this.Listen_CodeEntitys[1].MyCode = sMyCode1;
            this.Listen_CodeEntitys[2].MyCode = sMyCode2;
            this.Listen_CodeEntitys[3].MyCode = sMyCode3;
            this.Listen_CodeEntitys[4].MyCode = sMyCode4;
            this.Listen_CodeEntitys[5].MyCode = sMyCode5;
            this.Listen_CodeEntitys[6].MyCode = sMyCode6;
            this.Listen_CodeEntitys[7].MyCode = sMyCode7;
            this.Listen_CodeEntitys[8].MyCode = sMyCode8;
            this.Listen_CodeEntitys[9].MyCode = sMyCode9;
            return true;
        }
        private bool Listen_WriteIntoPLC_GetDxOrgInfo()
        {
            #region 申明变量
            decimal decCapacity0;
            decimal decR0;
            decimal decV0;
            decimal decCapacity1;
            decimal decR1;
            decimal decV1;
            decimal decCapacity2;
            decimal decR2;
            decimal decV2;
            decimal decCapacity3;
            decimal decR3;
            decimal decV3;
            decimal decCapacity4;
            decimal decR4;
            decimal decV4;
            decimal decCapacity5;
            decimal decR5;
            decimal decV5;
            decimal decCapacity6;
            decimal decR6;
            decimal decV6;
            decimal decCapacity7;
            decimal decR7;
            decimal decV7;
            decimal decCapacity8;
            decimal decR8;
            decimal decV8;
            decimal decCapacity9;
            decimal decR9;
            decimal decV9;
            #endregion
            try
            {
                #region 调用数据获取结果
                this._ScannControler.MyForm.BllDAL.GetDxOrgInfo(this.Listen_BlockNo,
                     this.Listen_CodeEntitys[0].SNCode, this.Listen_CodeEntitys[1].SNCode, this.Listen_CodeEntitys[2].SNCode, this.Listen_CodeEntitys[3].SNCode,
                    this.Listen_CodeEntitys[4].SNCode, this.Listen_CodeEntitys[5].SNCode, this.Listen_CodeEntitys[6].SNCode, this.Listen_CodeEntitys[7].SNCode,
                    this.Listen_CodeEntitys[8].SNCode, this.Listen_CodeEntitys[9].SNCode
                    , out decCapacity0
                    , out decCapacity1
                    , out decCapacity2
                    , out decCapacity3
                    , out decCapacity4
                    , out decCapacity5
                    , out decCapacity6
                    , out decCapacity7
                    , out decCapacity8
                    , out decCapacity9
                    , out decR0
                    , out decR1
                    , out decR2
                    , out decR3
                    , out decR4
                    , out decR5
                    , out decR6
                    , out decR7
                    , out decR8
                    , out decR9
                    , out decV0
                    , out decV1
                    , out decV2
                    , out decV3
                    , out decV4
                    , out decV5
                    , out decV6
                    , out decV7
                    , out decV8
                    , out decV9
                    );
                #endregion
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn($"读取扫描枪[{this.Listen_BlockNo}]电芯原始数据出错：{ex.Message}({ex.Source})");
                return false;
            }
            #region 赋值
            this.Listen_CodeEntitys[0].Capacity = decCapacity0;
            this.Listen_CodeEntitys[0].R = decR0;
            this.Listen_CodeEntitys[0].V = decV0;
            this.Listen_CodeEntitys[1].Capacity = decCapacity1;
            this.Listen_CodeEntitys[1].R = decR1;
            this.Listen_CodeEntitys[1].V = decV1;
            this.Listen_CodeEntitys[2].Capacity = decCapacity2;
            this.Listen_CodeEntitys[2].R = decR2;
            this.Listen_CodeEntitys[2].V = decV2;
            this.Listen_CodeEntitys[3].Capacity = decCapacity3;
            this.Listen_CodeEntitys[3].R = decR3;
            this.Listen_CodeEntitys[3].V = decV3;
            this.Listen_CodeEntitys[4].Capacity = decCapacity4;
            this.Listen_CodeEntitys[4].R = decR4;
            this.Listen_CodeEntitys[4].V = decV4;
            this.Listen_CodeEntitys[5].Capacity = decCapacity5;
            this.Listen_CodeEntitys[5].R = decR5;
            this.Listen_CodeEntitys[5].V = decV5;
            this.Listen_CodeEntitys[6].Capacity = decCapacity6;
            this.Listen_CodeEntitys[6].R = decR6;
            this.Listen_CodeEntitys[6].V = decV6;
            this.Listen_CodeEntitys[7].Capacity = decCapacity7;
            this.Listen_CodeEntitys[7].R = decR7;
            this.Listen_CodeEntitys[7].V = decV7;
            this.Listen_CodeEntitys[8].Capacity = decCapacity8;
            this.Listen_CodeEntitys[8].R = decR8;
            this.Listen_CodeEntitys[8].V = decV8;
            this.Listen_CodeEntitys[9].Capacity = decCapacity9;
            this.Listen_CodeEntitys[9].R = decR9;
            this.Listen_CodeEntitys[9].V = decV9;
            #endregion
            return true;
        }
        private bool Listen_WriteIntoPLC_CheckChongfu()
        {
            this.Listen_CodeEntitys[0].IsChongFu = false;
            this.Listen_CodeEntitys[1].IsChongFu = false;
            this.Listen_CodeEntitys[2].IsChongFu = false;
            this.Listen_CodeEntitys[3].IsChongFu = false;
            this.Listen_CodeEntitys[4].IsChongFu = false;
            this.Listen_CodeEntitys[5].IsChongFu = false;
            this.Listen_CodeEntitys[6].IsChongFu = false;
            this.Listen_CodeEntitys[7].IsChongFu = false;
            this.Listen_CodeEntitys[8].IsChongFu = false;
            this.Listen_CodeEntitys[9].IsChongFu = false;
            //Listen_SaveSNs = new List<string>();
            if (this._CheckChongFu && this.Listen_ChongFuSns.Length > 0)
            {
                this.ShowLogAsyn("开始重复性校验");
                DataTable dt = null;
                string strSql;               
                if (JPSConfig.CheckSNReDefine)
                {
                    string strOtherText = string.Empty;
                    //暂时不用该功能if (this._ScannerNo == 1)
                    //    strOtherText = SocketClient.Scanner2Sns;
                    //else strOtherText = SocketClient.Scanner1Sns;
                    //首先校验当前组内是否存在重复
                    foreach(ScannerDianXinData tmpD in this.Listen_CodeEntitys)
                    {
                        if (tmpD.IsNG || tmpD.IsChongFu) continue;
                        foreach (ScannerDianXinData mD in this.Listen_CodeEntitys)
                        {
                            if (mD.IsNG) continue;
                            if (tmpD.Index == mD.Index) continue;
                            if (tmpD.Equals(mD)) continue;
                            if(string.Compare(mD.SNCode,tmpD.SNCode,true)==0)
                            {
                                this.ShowLogAsyn(string.Format("当前组内第{0}和第{1}节电池编码重复了,都为{2}，都设置为重复", tmpD.Index, mD.Index, tmpD.SNCode));
                                tmpD.IsChongFu = true;
                                mD.IsChongFu = true;
                                break;
                            }
                        }
                        if (!tmpD.IsChongFu && strOtherText.Length > 0)
                        {
                            this.ShowLogAsyn(string.Format("开始校验另外一把扫描枪扫到的是否有重复：{0}", strOtherText));
                            //这里校验是否存在2个扫描枪之间的重复性问题
                            if (SocketClient.ChongFu(tmpD.SNCode, strOtherText))
                            {
                                this.ShowLogAsyn(string.Format("当前组内第{0}和与另外一把扫描枪扫到的为重复编码：{1}", tmpD.Index, tmpD.SNCode));
                                tmpD.IsChongFu = true;
                            }
                        }
                    }
                    #region 校验是否已经上传过了
                    strSql = string.Format(@"SELECT A.SN
                    FROM {0} A LEFT JOIN {1} B ON B.MyCode = A.Code
                    LEFT JOIN Testing_Grooves C ON C.ID = B.GrooveID
                    WHERE C.Quality = 1 AND A.SN IN ({2})", this._BatteryTable, this._ResultTable, this.Listen_ChongFuSns);
                    //strSql = string.Format("SELECT SN FROM {0} WHERE SN IN ({1})",this._BatteryTable, this.Listen_ChongFuSns);
                    try
                    {
                        dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
                    }
                    catch (Exception ex)
                    {
                        this.ShowErrAsyn(string.Format("扫描枪{0}判断条码重复定义时出错：{1}{2}[{3}]", this._ScannerNo, ex.Message, ex.Source, strSql));
                        //return false;
                    }
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (ScannerDianXinData dx in this.Listen_CodeEntitys)
                            {
                                if (dx.IsNG) continue;
                                if (dt.Select("sn='" + dx.SNCode + "'").Length > 0)
                                {
                                    dx.IsChongFu = true;
                                    this.ShowLogAsyn(string.Format("SN：{0}为重定义编码。", dx.SNCode));
                                }
                                else
                                {
                                    //此时没有重复，除了标识外还要存入数据库
                                    // Listen_SaveSNs.Add(string.Format("INSERT INTO SN(SN) VALUES('{0}')", dx.SNCode.Replace("'", "''")));
                                }
                            }
                        }
                    }
                    #endregion
                }
                //此时开启重复性校验
                strSql = string.Format("SELECT SN FROM SN WHERE SN IN ({0})", this.Listen_ChongFuSns);
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn(string.Format("扫描枪{0}存校验重复性时出错：{1}{2}[{3}]", this._ScannerNo, ex.Message, ex.Source, strSql));
                    return false;
                }
                if (dt.Rows.Count == 0)
                {
                    this.ShowLogAsyn(string.Format("重复性校验获取了0条数据。表示传入的电芯都不重复"));
                    //foreach (ScannerDianXinData dx in this.Listen_CodeEntitys)
                    //{
                    //    if (!dx.IsNG)
                    //    {
                    //        //Listen_SaveSNs.Add(string.Format("INSERT INTO SN(SN) VALUES('{0}')", dx.SNCode.Replace("'", "''")));
                    //    }
                    //}
                }
                else
                {
                    this.ShowLogAsyn(string.Format("重复性校验获取了{0}条数据。", dt.Rows.Count));
                    foreach (ScannerDianXinData dx in this.Listen_CodeEntitys)
                    {
                        if (dx.IsNG) continue;
                        if (dx.IsChongFu) continue;
                        if (dt.Select("sn='" + dx.SNCode + "'").Length > 0)
                            dx.IsChongFu = true;
                        else
                        {
                            //此时没有重复，除了标识外还要存入数据库
                           // Listen_SaveSNs.Add(string.Format("INSERT INTO SN(SN) VALUES('{0}')", dx.SNCode.Replace("'", "''")));
                        }
                    }
                }
                strSql = string.Format("SELECT SN FROM SN1 WHERE SN IN ({0})", this.Listen_ChongFuSns);
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn(string.Format("扫描枪{0}存校验重复性时出错：{1}{2}[{3}]", this._ScannerNo, ex.Message, ex.Source, strSql));
                    return false;
                }
                if (dt.Rows.Count == 0)
                {
                    this.ShowLogAsyn(string.Format("针对远程设备的重复性校验获取了0条数据。表示传入的电芯都不重复"));
                }
                else
                {
                    this.ShowLogAsyn(string.Format("针对远程设备的重复性校验获取了{0}条数据。", dt.Rows.Count));
                    foreach (ScannerDianXinData dx in this.Listen_CodeEntitys)
                    {
                        if (dx.IsNG) continue;
                        if (dx.IsChongFu) continue;
                        if (dt.Select("sn='" + dx.SNCode + "'").Length > 0)
                            dx.IsChongFu = true;
                        else
                        {
                            //此时没有重复，除了标识外还要存入数据库
                            // Listen_SaveSNs.Add(string.Format("INSERT INTO SN(SN) VALUES('{0}')", dx.SNCode.Replace("'", "''")));
                        }
                    }
                }
            }
            else if (!this._CheckChongFu)
            {
                this.ShowLogAsyn("当前不校验重复性，不用上传电芯条码。");
                //foreach (ScannerDianXinData dx in this.Listen_CodeEntitys)
                //{
                //    if (!dx.IsNG)
                //    {
                //        Listen_SaveSNs.Add(string.Format("INSERT INTO SN(SN) VALUES('{0}')", dx.SNCode.Replace("'", "''")));
                //    }
                //}
            }
            return true;
        }
        private bool Listen_WriteIntoPLC_SaveSN()
        {

            //if (this.Listen_SaveSNs != null && this.Listen_SaveSNs.Count > 0)
            //{
            //    if (this._CheckChongFu)
            //    {
            //        try
            //        {
            //            Common.CommonDAL.DoSqlCommand.DoSql(Listen_SaveSNs);
            //        }
            //        catch (Exception ex)
            //        {
            //            //注意：这里不是写错了，是不需要ShowErrAsyn的，这里报错的概率会比较大
            //            this.ShowLogAsyn(string.Format("保存电芯编号时出错：{0}({1})", ex.Message, ex.Source)); //刚写到这里，这这个过程要单独用一个函数来执行，并分配一个枚举值
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        //很有可能不校验重复的，所以提交时会出现插入重复键，遇到报错直接跳过
            //        foreach (string sql in this.Listen_SaveSNs)
            //        {
            //            try
            //            {
            //                Common.CommonDAL.DoSqlCommand.DoSql(sql);
            //            }
            //            catch (Exception ex)
            //            {
            //                this.ShowLogAsyn(string.Format("保存单条电芯编号时出错：{0}({1})[{2}]", ex.Message, ex.Source, sql)); //刚写到这里，这这个过程要单独用一个函数来执行，并分配一个枚举值
            //                return false;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    this.ShowLogAsyn("无电芯条码提交到重复性表中。");
            //}
            return true;
        }
        private bool Listen_WriteIntoPLC_OPC原长风的作废()
        {
            if (this._OPCHelpBat == null)
            {
                this.ShowErrAsyn(string.Format("扫描枪{0}:电池信息OPC对象为空，无法写入数据！", this._ScannerNo));
                return false;
            }
            //利用OPC写入到PLC指定的电池地址中
            string strErr;
            string strCodes = this.Listen_CodeEntitys[0].MyCode + this.Listen_CodeEntitys[1].MyCode + this.Listen_CodeEntitys[2].MyCode + this.Listen_CodeEntitys[3].MyCode + this.Listen_CodeEntitys[4].MyCode
                + this.Listen_CodeEntitys[5].MyCode + this.Listen_CodeEntitys[6].MyCode + this.Listen_CodeEntitys[7].MyCode + this.Listen_CodeEntitys[8].MyCode + this.Listen_CodeEntitys[9].MyCode;
            //定义Short值
            bool[] bits = new bool[32];
            //电池1
            bits[0] = this.Listen_CodeEntitys[0].IsNG;
            bits[1] = this.Listen_CodeEntitys[0].IsChongFu;
            bits[2] = this.Listen_CodeEntitys[0].MBatchIsOk;
            //电池2
            bits[3] = this.Listen_CodeEntitys[1].IsNG;
            bits[4] = this.Listen_CodeEntitys[1].IsChongFu;
            bits[5] = this.Listen_CodeEntitys[1].MBatchIsOk;
            //电池3
            bits[6] = this.Listen_CodeEntitys[2].IsNG;
            bits[7] = this.Listen_CodeEntitys[2].IsChongFu;
            bits[8] = this.Listen_CodeEntitys[2].MBatchIsOk;
            //电池4
            bits[9] = this.Listen_CodeEntitys[3].IsNG;
            bits[10] = this.Listen_CodeEntitys[3].IsChongFu;
            bits[11] = this.Listen_CodeEntitys[3].MBatchIsOk;
            //电池5
            bits[12] = this.Listen_CodeEntitys[4].IsNG;
            bits[13] = this.Listen_CodeEntitys[4].IsChongFu;
            bits[14] = this.Listen_CodeEntitys[4].MBatchIsOk;
            //电池6
            bits[15] = this.Listen_CodeEntitys[5].IsNG;
            bits[16] = this.Listen_CodeEntitys[5].IsChongFu;
            bits[17] = this.Listen_CodeEntitys[5].MBatchIsOk;
            //电池7
            bits[18] = this.Listen_CodeEntitys[6].IsNG;
            bits[19] = this.Listen_CodeEntitys[6].IsChongFu;
            bits[20] = this.Listen_CodeEntitys[6].MBatchIsOk;
            //电池8
            bits[21] = this.Listen_CodeEntitys[7].IsNG;
            bits[22] = this.Listen_CodeEntitys[7].IsChongFu;
            bits[23] = this.Listen_CodeEntitys[7].MBatchIsOk;
            //电池9
            bits[24] = this.Listen_CodeEntitys[8].IsNG;
            bits[25] = this.Listen_CodeEntitys[8].IsChongFu;
            bits[26] = this.Listen_CodeEntitys[8].MBatchIsOk;
            //电池10
            bits[27] = this.Listen_CodeEntitys[9].IsNG;
            bits[28] = this.Listen_CodeEntitys[9].IsChongFu;
            bits[29] = this.Listen_CodeEntitys[9].MBatchIsOk;
            //标识已经有信息存入了
            bits[30] = true;
            //最高为目前为空,已不用赋值
            // bits[31] = false;
            int iValue = JPSFuns.GetInt32ByBit(bits);
            //将数据发送到客户端显示，因为是异步的，所以不会耽搁此函数执行
            if (this.SocketClientAnalyzeDataNotice != null)
                this.SocketClientAnalyzeDataNotice(this.Listen_CodeEntitys, iValue);
            /***********************
             * 陕西项目只需要用地址1的就可以了
            if (this._ScannerNo == 1)
            {
                if (!this._OPCHelpBat.WriteGroup1(strCodes, iValue, out strErr))
                {
                    this.ShowErrAsyn("电池组1写入PLC失败：" + strErr);
                    return false;
                }
                else
                {
                    this.ShowLogAsyn(string.Format("扫描枪{0}:OPC成功写入电池组信息：{1},{2}！", this._ScannerNo, strCodes, iValue));
                }
                return true;
            }
            else
            {
                if (!this._OPCHelpBat.WriteGroup2(strCodes, iValue, out strErr))
                {
                    this.ShowErrAsyn("电池组2写入PLC失败：" + strErr);
                    return false;
                }
                else
                {
                    this.ShowLogAsyn(string.Format("扫描枪{0}:OPC成功写入电池组信息：{1},{2}！", this._ScannerNo, strCodes, iValue));
                }
                return true;
            }
            ********************/
            if (!this._OPCHelpBat.WriteGroup1(strCodes, iValue, out strErr))
            {
                this.ShowErrAsyn("电池组1写入PLC失败：" + strErr);
                return false;
            }
            else
            {
                this.ShowLogAsyn(string.Format("扫描枪{0}:OPC成功写入电池组信息：{1},{2}！", this._ScannerNo, strCodes, iValue));
            }
            return true;
        }
        private bool Listen_WriteIntoPLC_OPC()
        {
            //该函数从车之翼项目拷贝过来，因为需要1把扫描枪扫描2次。2020-04-20 jiangpengsong
            if (this._OPCHelpBat == null)
            {
                this.ShowErrAsyn(string.Format("扫描枪{0}:电池信息OPC对象为空，无法写入数据！", this._ScannerNo));
                return false;
            }
            //利用OPC写入到PLC指定的电池地址中
            string strErr;
            string strCodes = this.Listen_CodeEntitys[0].MyCode + this.Listen_CodeEntitys[1].MyCode + this.Listen_CodeEntitys[2].MyCode + this.Listen_CodeEntitys[3].MyCode + this.Listen_CodeEntitys[4].MyCode
                + this.Listen_CodeEntitys[5].MyCode + this.Listen_CodeEntitys[6].MyCode + this.Listen_CodeEntitys[7].MyCode + this.Listen_CodeEntitys[8].MyCode + this.Listen_CodeEntitys[9].MyCode;
            //定义Short值
            bool[] bits = new bool[32];
            //电池1
            bits[0] = this.Listen_CodeEntitys[0].IsNG;
            bits[1] = this.Listen_CodeEntitys[0].IsChongFu;
            bits[2] = this.Listen_CodeEntitys[0].MBatchIsOk;
            //电池2
            bits[3] = this.Listen_CodeEntitys[1].IsNG;
            bits[4] = this.Listen_CodeEntitys[1].IsChongFu;
            bits[5] = this.Listen_CodeEntitys[1].MBatchIsOk;
            //电池3
            bits[6] = this.Listen_CodeEntitys[2].IsNG;
            bits[7] = this.Listen_CodeEntitys[2].IsChongFu;
            bits[8] = this.Listen_CodeEntitys[2].MBatchIsOk;
            //电池4
            bits[9] = this.Listen_CodeEntitys[3].IsNG;
            bits[10] = this.Listen_CodeEntitys[3].IsChongFu;
            bits[11] = this.Listen_CodeEntitys[3].MBatchIsOk;
            //电池5
            bits[12] = this.Listen_CodeEntitys[4].IsNG;
            bits[13] = this.Listen_CodeEntitys[4].IsChongFu;
            bits[14] = this.Listen_CodeEntitys[4].MBatchIsOk;
            //电池6
            bits[15] = this.Listen_CodeEntitys[5].IsNG;
            bits[16] = this.Listen_CodeEntitys[5].IsChongFu;
            bits[17] = this.Listen_CodeEntitys[5].MBatchIsOk;
            //电池7
            bits[18] = this.Listen_CodeEntitys[6].IsNG;
            bits[19] = this.Listen_CodeEntitys[6].IsChongFu;
            bits[20] = this.Listen_CodeEntitys[6].MBatchIsOk;
            //电池8
            bits[21] = this.Listen_CodeEntitys[7].IsNG;
            bits[22] = this.Listen_CodeEntitys[7].IsChongFu;
            bits[23] = this.Listen_CodeEntitys[7].MBatchIsOk;
            //电池9
            bits[24] = this.Listen_CodeEntitys[8].IsNG;
            bits[25] = this.Listen_CodeEntitys[8].IsChongFu;
            bits[26] = this.Listen_CodeEntitys[8].MBatchIsOk;
            //电池10
            bits[27] = this.Listen_CodeEntitys[9].IsNG;
            bits[28] = this.Listen_CodeEntitys[9].IsChongFu;
            bits[29] = this.Listen_CodeEntitys[9].MBatchIsOk;
            //标识已经有信息存入了
            bits[30] = true;
            //最高为目前为空,已不用赋值
            // bits[31] = false;
            int iValue = JPSFuns.GetInt32ByBit(bits);
            //将数据发送到客户端显示，因为是异步的，所以不会耽搁此函数执行
            if (this.SocketClientAnalyzeDataNotice != null)
                this.SocketClientAnalyzeDataNotice(this.Listen_CodeEntitys, iValue);
            //通过Listen_BlockNo的值来确定存入哪个地址
            if (this.Listen_BlockNo == 1)
            {
                if (!this._OPCHelpBat.WriteGroup1(strCodes, iValue, out strErr))
                {
                    this.ShowErrAsyn("电池组1写入PLC失败：" + strErr);
                    return false;
                }
                else
                {
                    this.ShowLogAsyn(string.Format("扫描枪{0}:OPC成功写入电池组信息：{1},{2}！", this._ScannerNo, strCodes, iValue));
                }
                return true;
            }
            else
            {
                if (!this._OPCHelpBat.WriteGroup2(strCodes, iValue, out strErr))
                {
                    this.ShowErrAsyn("电池组2写入PLC失败：" + strErr);
                    return false;
                }
                else
                {
                    this.ShowLogAsyn(string.Format("扫描枪{0}:OPC成功写入电池组信息：{1},{2}！", this._ScannerNo, strCodes, iValue));
                }
                return true;
            }
        }
        private bool Listen_WriteIntoPLC_OPC_DxOrgData()
        {
            //该函数从车之翼项目拷贝过来，因为需要1把扫描枪扫描2次。2020-04-20 jiangpengsong
            if (this._OPCHelpBat == null)
            {
                this.ShowErrAsyn(string.Format("扫描枪{0}:电池信息OPC对象为空，无法写入数据！", this._ScannerNo));
                return false;
            }
            //利用OPC写入到PLC指定的电池地址中
            string strErr;
          
            //通过Listen_BlockNo的值来确定存入哪个地址
            if (this.Listen_BlockNo == 1)
            {
                if (!this._OPCHelpBat.WriteDXOrg1(this.Listen_CodeEntitys[0].Capacity, this.Listen_CodeEntitys[0].R, this.Listen_CodeEntitys[0].V
                    , this.Listen_CodeEntitys[1].Capacity, this.Listen_CodeEntitys[1].R, this.Listen_CodeEntitys[1].V
                    , this.Listen_CodeEntitys[2].Capacity, this.Listen_CodeEntitys[2].R, this.Listen_CodeEntitys[2].V
                    , this.Listen_CodeEntitys[3].Capacity, this.Listen_CodeEntitys[3].R, this.Listen_CodeEntitys[3].V
                    , this.Listen_CodeEntitys[4].Capacity, this.Listen_CodeEntitys[4].R, this.Listen_CodeEntitys[4].V
                    , this.Listen_CodeEntitys[5].Capacity, this.Listen_CodeEntitys[5].R, this.Listen_CodeEntitys[5].V
                    , this.Listen_CodeEntitys[6].Capacity, this.Listen_CodeEntitys[6].R, this.Listen_CodeEntitys[6].V
                    , this.Listen_CodeEntitys[7].Capacity, this.Listen_CodeEntitys[7].R, this.Listen_CodeEntitys[7].V
                    , out strErr))
                {
                    this.ShowErrAsyn("电池组1写入原始电芯数据失败：" + strErr);
                    return false;
                }
                else
                {
                    this.ShowLogAsyn($"扫描枪{this._ScannerNo}:OPC成功写入电池原始信息成功。");
                }
                return true;
            }
            else
            {
                if (!this._OPCHelpBat.WriteDXOrg2(this.Listen_CodeEntitys[0].Capacity, this.Listen_CodeEntitys[0].R, this.Listen_CodeEntitys[0].V
                    , this.Listen_CodeEntitys[1].Capacity, this.Listen_CodeEntitys[1].R, this.Listen_CodeEntitys[1].V
                    , this.Listen_CodeEntitys[2].Capacity, this.Listen_CodeEntitys[2].R, this.Listen_CodeEntitys[2].V
                    , this.Listen_CodeEntitys[3].Capacity, this.Listen_CodeEntitys[3].R, this.Listen_CodeEntitys[3].V
                    , this.Listen_CodeEntitys[4].Capacity, this.Listen_CodeEntitys[4].R, this.Listen_CodeEntitys[4].V
                    , this.Listen_CodeEntitys[5].Capacity, this.Listen_CodeEntitys[5].R, this.Listen_CodeEntitys[5].V
                    , this.Listen_CodeEntitys[6].Capacity, this.Listen_CodeEntitys[6].R, this.Listen_CodeEntitys[6].V
                    , this.Listen_CodeEntitys[7].Capacity, this.Listen_CodeEntitys[7].R, this.Listen_CodeEntitys[7].V
                    , out strErr))
                {
                    this.ShowErrAsyn("电池组2写入原始电芯数据失败：" + strErr);
                    return false;
                }
                else
                {
                    this.ShowLogAsyn($"扫描枪{this._ScannerNo}:OPC成功写入电池原始信息成功。");
                }
                return true;
            }
        }
        public bool SendText(string sText)
        {
            try
            {
                if (this._client == null || !this._client.Connected)
                {
                    string strErr;
                    if (!InitSocket(out strErr))
                    {
                        this.ShowErrAsyn(strErr);
                        if (!this.Interrupt) Interrupt = true;
                        return false;
                    }
                }
                if (this._client == null || !this._client.Connected)
                {
                    if (!this.Interrupt) Interrupt = true;
                    this.ShowErrAsyn("IP：" + this.IP + "的监听工具创建失败。");
                    return false;
                }
                char cCR = (char)13;
                sText += cCR.ToString();
                byte[] datas = Encoding.ASCII.GetBytes(sText);
                //byte bCR = 0x13;
                //byte[] newdatas = new byte[data.Length + 1];
                //for (int i = 0; i < data.Length; i++)
                //{
                //    newdatas[i] = data[i];
                //}
                //newdatas[newdatas.Length - 1] = bCR;
                this._client.Send(datas);
                //int iReceived = this._client.Receive(data);
                //this.ShowLogAsyn("发送数据：" + sText);
                this.ShowLogAsyn(string.Format("扫描枪{0}：发送数据：{1}", this._ScannerNo, JPSFuns.GetByteToHex(datas)));
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
                this.ShowLogAsyn(string.Format("扫描枪{0}：发送失败：{1}", this._ScannerNo, ex.Message));
                return false;
            }
            return true;
        }
        #region  公共函数
        public void SetTestingData(bool blCheckerMBatchNum, string sMBatchCode, bool blChongfuChecker,bool blCharChecker,string sBatteryTable,string sResultTable)
        {
            this._CheckerMBatchNum = blCheckerMBatchNum;
            this._MBatchCode = sMBatchCode.ToUpper();
            this._CheckChongFu = blChongfuChecker;
            this._CheckChar = blCharChecker;
            this._BatteryTable = sBatteryTable;
            this._ResultTable = sResultTable;
        }
        /// <summary>
        /// 设置扫描枪为初始化状态
        /// 1：读取当前状态为监听PLC值状态
        /// </summary>
        public void InitState()
        {
            this._State = JPSEnum.ScannerStates.ReadingPLCIOValue;
        }
        public void SetScannerIP(string sIp, int iPort)
        {
            this.IP = sIp;
            this.Port = iPort;
        }
        public void ReInit(string sErr)
        {

        }
        #endregion
        #region 消息
        /// <summary>
        /// 异步消息显示
        /// </summary>
        /// <param name="sMsg">消息内容</param>
        public void ShowErrAsyn(string sMsg)
        {
            ShowMsgAsynCallBack cb = new ShowMsgAsynCallBack(ShowErr);
            try
            {
                this._ScannControler.MyForm.Invoke(cb, new object[1] { sMsg });
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void ShowErr(string sMsg)
        {
            this._ScannControler.MyForm.ShowErr(sMsg);
            //if (this.IsFormForOperatorOpend)
            //    this.MsgFormForOperator_AddMsg(sMsg, true);
            //else
            //{
            //    this.MyForm.ShowErr(sMsg);
            //}
        }
        public void ShowLogAsyn(string sMsg)
        {
            if (JPSConfig.ScannerLogSavetoDataBase)
            {
                if (this._ScannerNo == 1)
                {
                    try
                    {
                        BLLDAL.Testing.SaveScanner1Log(sMsg);
                    }
                    catch (Exception ex)
                    {
                        this.ShowErrAsyn(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        BLLDAL.Testing.SaveScanner2Log(sMsg);
                    }
                    catch (Exception ex)
                    {
                        this.ShowErrAsyn(ex.Message);
                    }
                }
            }
            else
            {
                ShowMsgAsynCallBack cb = new ShowMsgAsynCallBack(ShowLog);
                try
                {
                    this._ScannControler.MyForm.Invoke(cb, new object[1] { sMsg });
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }
        public void ShowLog(string sMsg)
        {
            if (this.ShowLogNotice != null)
                ShowLogNotice(sMsg);
            //frmScanner1Log.ShowMyLog(sMsg);
        }
        #endregion
    }
    public class ScannerDianXinData
    {
        /// <summary>
        /// 序号，从0开始计数
        /// </summary>
        public int Index = -1;
        /// <summary>
        /// 电芯序列号
        /// </summary>
        public string SNCode = string.Empty;
        /// <summary>
        /// 条码是否NG
        /// </summary>
        public bool IsNG = false;
        /// <summary>
        /// 是否来料工单正确
        /// </summary>
        public bool MBatchIsOk = false;
        /// <summary>
        /// 电芯编号是否重复
        /// </summary>
        public bool IsChongFu = false;
        /// <summary>
        /// 系统自编号，传给PLC的
        /// </summary>
        public string MyCode = string.Empty;
        #region 南京中比追加的电芯原始信息，来自供货方
        /// <summary>
        /// 电芯原始容量
        /// </summary>
        public decimal Capacity = 0M;
        /// <summary>
        /// 电芯原始内阻
        /// </summary>
        public decimal R = 0M;
        /// <summary>
        /// 电芯原始电压
        /// </summary>
        public decimal V = 0M;
        #endregion
    }
    #endregion
    #region 实时结果知道读取
    public class ResultControler
    {
        /// <summary>
        /// 分档模式
        /// </summary>
        public JPSEnum.SwitchModes SwitchMode = JPSEnum.SwitchModes.普通分档;
        public void SetSwitchMode(JPSEnum.SwitchModes mode)
        {
            this.ShowLogAsyn($"结果读取对象的分档模式从[{this.SwitchMode}]改为[{mode}]");
            if (this.SwitchMode != mode)
            {
                this.SwitchMode = mode;
            }
        }
        /// <summary>
        /// 用于计算速度的，表示每次多少节电池
        /// </summary>
        public static double SpeedCalculator_DxCount = 10;
        public event RealDataShowCallBack RealDataShowNotice = null;
        /// <summary>
        /// 目标托盘数量
        /// </summary>
        public static int TuopanPlanCnt = 0;
        public PrinterControl _Printer = null;
        public string _RealTableBattery = string.Empty;
        public string _TestCode = string.Empty;
        /// <summary>
        /// 托盘下电芯数量出错后的通知
        /// </summary>
        public event ResultControlerTuoPanBtyErrorCallback ResultControlerTuoPanBtyErrorNotice = null;
        public event GrooveStatisticSucessfulCallBack GrooveStatisticSucessfulNotice = null;
        public event TuopanPlanProgressCallBack TuopanPlanProgressNotice = null;
        public frmMain1 MyForm = null;
        public JpsOPC.OPCHelperResult _OPCHelperResult = null;
        /// <summary>
        /// 标识当前通讯是否中断状态
        /// </summary>
        public bool Interrupt = false;
        Thread _thread = null;
        public JPSEnum.ResultStates _State = JPSEnum.ResultStates.None;
        public bool Running = false;
        public ResultControler(frmMain1 mainForm, JpsOPC.OPCHelperResult opc,PrinterControl printer)
        {
            this.MyForm = mainForm;
            this._OPCHelperResult = opc;
            this._Printer = printer;
            //this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
            //初始化18个槽
            this.Groove1 = new GrooveData(1);
            this.Groove2 = new GrooveData(2);
            this.Groove3 = new GrooveData(3);
            this.Groove4 = new GrooveData(4);
            this.Groove5 = new GrooveData(5);
            this.Groove6 = new GrooveData(6);
            this.Groove7 = new GrooveData(7);
            this.Groove8 = new GrooveData(8);
            this.Groove9 = new GrooveData(9);
            this.Groove10 = new GrooveData(10);
            this.Groove11 = new GrooveData(11);
            this.Groove12 = new GrooveData(12);
            this.Groove13 = new GrooveData(13);
            this.Groove14 = new GrooveData(14);
            this.Groove15 = new GrooveData(15);
            this.Groove16 = new GrooveData(16);
            this.Groove17 = new GrooveData(17);
            this.Groove18 = new GrooveData(18);
        }
        private void _Printer_PrintFinishedNotice(string sTuoPanCode, bool blSucessful, string sErr)
        {
            if(blSucessful)
            {
                this.ShowLogAsyn(string.Format("托盘{0}完成打印。",sTuoPanCode));
            }
            else
            {
                this.ShowErrAsyn(string.Format("托盘{0}打印出错：{0}", sTuoPanCode, sErr));
            }
        }
        public void SetTestingData(string sTestCode,string sBattryTableName)
        {
            this._TestCode = sTestCode;
            _RealTableBattery = sBattryTableName;
        }
        public bool StartListenning(out string sErr)
        {
            if (this.Running)
            {
                sErr = "测试结果的监听已经开启，请勿重复打开。";
                return false;
            }
            this.Running = true;
            this.Listen_TuoPanBtyCountError = false;//重置
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(Listen));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("测试结果监听启动时出错：{0}({1})", ex.Message, ex.Source);
                this.Running = false;
                return false;
            }
            sErr = string.Empty;
            this._State = JPSEnum.ResultStates.IsReadResult;
            return true;
        }
        public bool StopListenning(out string sErr)
        {
            InitSpeed();
            sErr = string.Empty;
            this.Running = false;
            return true;
        }
        /// <summary>
        /// 设置当前通讯是否中断
        /// </summary>
        /// <param name="blInterrupt">true：通讯中断，false：通讯正常</param>
        public void SetInterrupt(bool blInterrupt)
        {
            if (this.Interrupt != blInterrupt)
                this.Interrupt = blInterrupt;
            if(blInterrupt)
            {
                InitSpeed();
            }
        }
        #region 监听过程变量
        List<GrooveData> Listen_Grooves = null;
        int Listen_BtyAddCount = 0;
        int Listen_TuoPanAddCount = 0;
        /// <summary>
        /// 托盘下的总电芯数量出错了
        /// </summary>
        bool Listen_TuoPanBtyCountError = false;
        /// <summary>
        /// 忽略电芯的错误，继续往下执行
        /// </summary>
        public bool Listen_IgnoreTuoPanBtyCountError = false;
        /// <summary>
        /// 托盘任务已经完成了
        /// </summary>
        public bool Listen_TuoPanPlanCompeleted = false;

        //GrooveData Listen_Groove = null;
        #endregion
        private void Listen()
        {
            InitSpeed();
            while (true)
            {
                if (!this.Running)
                {
                    this.ShowLogAsyn("测试结果读取停止。");
                    InitSpeed();
                    break;
                }
                if (this.MyForm._TestState != JPSEnum.TestStates.Testing)
                {
                    Thread.Sleep(500);
                    continue;
                }
                if(this.Listen_TuoPanPlanCompeleted)
                {
                    //此时用户托盘计划数已经完成了
                    Thread.Sleep(JPSConfig.DelayerMillSecondesAfterTuopanPlanCompeleted);
                    continue;
                }
                if (this._State == JPSEnum.ResultStates.IsReadResult)
                {
                    this.ShowLogAsyn(string.Format("RunState:IsReadResult,休眠{0}毫秒后读取标识AT_ReadResult的值。", JPSConfig.DelayerMiilSecondsReadIsReadResult));
                    Thread.Sleep(JPSConfig.DelayerMiilSecondsReadIsReadResult);
                    //此时实时读取P槽编号
                    if (!this.Listen_IsReadReusltNow()) continue;
                    this._State = JPSEnum.ResultStates.ReadingPLCValue;
                }
                if (this._State == JPSEnum.ResultStates.ReadingPLCValue)
                {
                    this.ShowLogAsyn(string.Format("RunState:ReadingPLCValue，休眠{0}毫秒后读取结果值", JPSConfig.DelayerBeforReadResult));
                    Thread.Sleep(JPSConfig.DelayerBeforReadResult);
                    if (!Listen_GetReuslt())
                    {
                        this.SetInterrupt(true);
                        continue;
                    }
                    this.AddTime();
                    this._State = JPSEnum.ResultStates.SaveResult;//已经读取成功，可以复位了
                }
                //这里改一下要先保存到数据库，然后再统计托盘下数量是否正确后才进行复位
                if (this._State == JPSEnum.ResultStates.SaveResult)
                {
                    this.ShowLogAsyn("RunState:SaveResult");
                    if (!Listen_SaveReuslt())
                    {
                        this.SetInterrupt(true);
                        continue;
                    }
                    this._State = JPSEnum.ResultStates.Statistic;//已经保存成功，可以统计数据了，涉及到标签的打印
                }
                if (this._State == JPSEnum.ResultStates.Statistic)
                {
                    this.ShowLogAsyn("RunState:Statistic");
                    if (!this.Listen_Statistic())
                    {
                        this.SetInterrupt(true);
                        continue;
                    }
                    this._State = JPSEnum.ResultStates.ResetAtFalse;
                }
                if (this._State == JPSEnum.ResultStates.ResetAtFalse)
                {
                    this.ShowLogAsyn("RunState:ResetAtFalse");
                    if (!this.Listen_ResetAt_ReadResult())
                    {
                        this.SetInterrupt(true);
                        continue;
                    }
                    this.ShowLogAsyn("已将AT_ReadResult设置为false，程序休眠" + JPSConfig.DelayerMillScdsAfterResultSaved + "毫秒。");
                    Thread.Sleep(JPSConfig.DelayerMillScdsAfterResultSaved);
                    this._State = JPSEnum.ResultStates.IsReadResult;//复位成功后，从头开始了
                }
                this.SetInterrupt(false);
            }
            InitSpeed();
        }
        /// <summary>
        /// 是否现在可以读取结果集了
        /// </summary>
        /// <returns>true：可以读取了，false：不可以读，也有可能程序出错(这里不用管出错)</returns>
        private bool Listen_IsReadReusltNow()
        {
            if(Debug.PLCResultReader.IsDebug)
            {
                #region  调试模式
                return Debug.PLCResultReader.IsReadNow;
                #endregion
            }
            string strErr;
            if (this._OPCHelperResult == null)
            {
                this.ShowErrAsyn("结果集OPC对象为空！");
                this.SetInterrupt(true);
                return false;
            }
            if(!this._OPCHelperResult.IsReadResultNow(out strErr))
            {
                this.SetInterrupt(true);
                this.ShowErrAsyn(string.Format("读取测试结果的槽号出错：{0}", strErr));
                return false;
            }
            if(strErr.Length>0)
            {
                this.ShowLogAsyn(strErr);
            }
            if (!this._OPCHelperResult.AT_ReadResult.Value_Bool) return false;
            this.ShowLogAsyn("可以读取结果集了。");
            this.SetInterrupt(false);
            return true;
        }
        private bool Listen_GetReuslt()
        {
            if(Debug.PLCResultReader.IsDebug)
            {
                #region 调试模式
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result1, this._OPCHelperResult.Rt_Bat1Code, this._OPCHelperResult.Rt_Bat1V, this._OPCHelperResult.Rt_Bat1Dz, this._OPCHelperResult.Rt_Bat1Cao, this._OPCHelperResult.Rt_Bat1NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result2, this._OPCHelperResult.Rt_Bat2Code, this._OPCHelperResult.Rt_Bat2V, this._OPCHelperResult.Rt_Bat2Dz, this._OPCHelperResult.Rt_Bat2Cao, this._OPCHelperResult.Rt_Bat2NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result3, this._OPCHelperResult.Rt_Bat3Code, this._OPCHelperResult.Rt_Bat3V, this._OPCHelperResult.Rt_Bat3Dz, this._OPCHelperResult.Rt_Bat3Cao, this._OPCHelperResult.Rt_Bat3NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result4, this._OPCHelperResult.Rt_Bat4Code, this._OPCHelperResult.Rt_Bat4V, this._OPCHelperResult.Rt_Bat4Dz, this._OPCHelperResult.Rt_Bat4Cao, this._OPCHelperResult.Rt_Bat4NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result5, this._OPCHelperResult.Rt_Bat5Code, this._OPCHelperResult.Rt_Bat5V, this._OPCHelperResult.Rt_Bat5Dz, this._OPCHelperResult.Rt_Bat5Cao, this._OPCHelperResult.Rt_Bat5NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result6, this._OPCHelperResult.Rt_Bat6Code, this._OPCHelperResult.Rt_Bat6V, this._OPCHelperResult.Rt_Bat6Dz, this._OPCHelperResult.Rt_Bat6Cao, this._OPCHelperResult.Rt_Bat6NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result7, this._OPCHelperResult.Rt_Bat7Code, this._OPCHelperResult.Rt_Bat7V, this._OPCHelperResult.Rt_Bat7Dz, this._OPCHelperResult.Rt_Bat7Cao, this._OPCHelperResult.Rt_Bat7NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result8, this._OPCHelperResult.Rt_Bat8Code, this._OPCHelperResult.Rt_Bat8V, this._OPCHelperResult.Rt_Bat8Dz, this._OPCHelperResult.Rt_Bat8Cao, this._OPCHelperResult.Rt_Bat8NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result9, this._OPCHelperResult.Rt_Bat9Code, this._OPCHelperResult.Rt_Bat9V, this._OPCHelperResult.Rt_Bat9Dz, this._OPCHelperResult.Rt_Bat9Cao, this._OPCHelperResult.Rt_Bat9NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result10, this._OPCHelperResult.Rt_Bat10Code, this._OPCHelperResult.Rt_Bat10V, this._OPCHelperResult.Rt_Bat10Dz, this._OPCHelperResult.Rt_Bat10Cao, this._OPCHelperResult.Rt_Bat10NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result11, this._OPCHelperResult.Rt_Bat11Code, this._OPCHelperResult.Rt_Bat11V, this._OPCHelperResult.Rt_Bat11Dz, this._OPCHelperResult.Rt_Bat11Cao, this._OPCHelperResult.Rt_Bat11NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result12, this._OPCHelperResult.Rt_Bat12Code, this._OPCHelperResult.Rt_Bat12V, this._OPCHelperResult.Rt_Bat12Dz, this._OPCHelperResult.Rt_Bat12Cao, this._OPCHelperResult.Rt_Bat12NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result13, this._OPCHelperResult.Rt_Bat13Code, this._OPCHelperResult.Rt_Bat13V, this._OPCHelperResult.Rt_Bat13Dz, this._OPCHelperResult.Rt_Bat13Cao, this._OPCHelperResult.Rt_Bat13NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result14, this._OPCHelperResult.Rt_Bat14Code, this._OPCHelperResult.Rt_Bat14V, this._OPCHelperResult.Rt_Bat14Dz, this._OPCHelperResult.Rt_Bat14Cao, this._OPCHelperResult.Rt_Bat14NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result15, this._OPCHelperResult.Rt_Bat15Code, this._OPCHelperResult.Rt_Bat15V, this._OPCHelperResult.Rt_Bat15Dz, this._OPCHelperResult.Rt_Bat15Cao, this._OPCHelperResult.Rt_Bat15NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result16, this._OPCHelperResult.Rt_Bat16Code, this._OPCHelperResult.Rt_Bat16V, this._OPCHelperResult.Rt_Bat16Dz, this._OPCHelperResult.Rt_Bat16Cao, this._OPCHelperResult.Rt_Bat16NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result17, this._OPCHelperResult.Rt_Bat17Code, this._OPCHelperResult.Rt_Bat17V, this._OPCHelperResult.Rt_Bat17Dz, this._OPCHelperResult.Rt_Bat17Cao, this._OPCHelperResult.Rt_Bat17NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result18, this._OPCHelperResult.Rt_Bat18Code, this._OPCHelperResult.Rt_Bat18V, this._OPCHelperResult.Rt_Bat18Dz, this._OPCHelperResult.Rt_Bat18Cao, this._OPCHelperResult.Rt_Bat18NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result19, this._OPCHelperResult.Rt_Bat19Code, this._OPCHelperResult.Rt_Bat19V, this._OPCHelperResult.Rt_Bat19Dz, this._OPCHelperResult.Rt_Bat19Cao, this._OPCHelperResult.Rt_Bat19NGCase);
                Debug.PLCResultReader.DebugFunSetResult(Debug.PLCResultReader.Result20, this._OPCHelperResult.Rt_Bat20Code, this._OPCHelperResult.Rt_Bat20V, this._OPCHelperResult.Rt_Bat20Dz, this._OPCHelperResult.Rt_Bat20Cao, this._OPCHelperResult.Rt_Bat20NGCase);
                return true;
                #endregion
            }
            string strErr;
            if (this._OPCHelperResult == null)
            {
                this.ShowErrAsyn("结果集OPC对象为空！");
                return false;
            }
            if (!this._OPCHelperResult.GetResult(out strErr))
            {
                this.ShowErrAsyn(string.Format("读取测试结果出错：{0}", strErr));
                return false;
            }
            this.ShowLogAsyn("成功读取测试结果。\r\n" + strErr);
            return true;
        }
        public bool Listen_ResetAt_ReadResult()
        {
            if (Debug.PLCResultReader.IsDebug)
            {
                #region  调试模式
                Debug.PLCResultReader.IsReadNow=false;
                return true;
                #endregion
            }
            string strErr;
            if (this._OPCHelperResult == null)
            {
                this.ShowErrAsyn("重置AT_ReadResult失败：结果集OPC对象为空！");
                return false;
            }
            if (!this._OPCHelperResult.ResetAT_ReadResult(out strErr))
            {
                this.ShowErrAsyn(string.Format("AT_ReadResult槽号出错：{0}", strErr));
                return false;
            }
            this.ShowLogAsyn("AT_ReadResult成功重置为false。");
            return true;
        }
        private bool Listen_SaveReuslt()
        {
            Listen_Grooves = new List<GrooveData>();
            string strErr;
            string sTuoPanCode1, sTuoPanCode2, sTuoPanCode3, sTuoPanCode4, sTuoPanCode5, sTuoPanCode6, sTuoPanCode7, sTuoPanCode8, sTuoPanCode9, sTuoPanCode10;
            string sTuoPanCode11, sTuoPanCode12, sTuoPanCode13, sTuoPanCode14, sTuoPanCode15, sTuoPanCode16, sTuoPanCode17, sTuoPanCode18, sTuoPanCode19, sTuoPanCode20;
            long iGrooveID1, iGrooveID2, iGrooveID3, iGrooveID4, iGrooveID5, iGrooveID6, iGrooveID7, iGrooveID8, iGrooveID9,
                iGrooveID10, iGrooveID11, iGrooveID12, iGrooveID13, iGrooveID14, iGrooveID15, iGrooveID16, iGrooveID17, iGrooveID18, iGrooveID19, iGrooveID20;
            short iCaoIndex1, iCaoIndex2, iCaoIndex3, iCaoIndex4, iCaoIndex5, iCaoIndex6, iCaoIndex7, iCaoIndex8, iCaoIndex9, iCaoIndex10;
            short iCaoIndex11, iCaoIndex12, iCaoIndex13, iCaoIndex14, iCaoIndex15, iCaoIndex16, iCaoIndex17, iCaoIndex18, iCaoIndex19, iCaoIndex20;
            short iQuality1, iQuality2, iQuality3, iQuality4, iQuality5, iQuality6, iQuality7, iQuality8, iQuality9, iQuality10;
            short iQuality11, iQuality12, iQuality13, iQuality14, iQuality15, iQuality16, iQuality17, iQuality18, iQuality19, iQuality20;
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat1Cao,out iCaoIndex1, out sTuoPanCode1,out iGrooveID1,out iQuality1, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽1地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat2Cao, out iCaoIndex2, out sTuoPanCode2, out iGrooveID2, out iQuality2, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽2地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat3Cao, out iCaoIndex3, out sTuoPanCode3, out iGrooveID3, out iQuality3, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽3地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat4Cao, out iCaoIndex4, out sTuoPanCode4, out iGrooveID4, out iQuality4, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽4地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat5Cao, out iCaoIndex5, out sTuoPanCode5, out iGrooveID5, out iQuality5, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽5地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat6Cao, out iCaoIndex6, out sTuoPanCode6, out iGrooveID6, out iQuality6, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽6地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat7Cao, out iCaoIndex7, out sTuoPanCode7, out iGrooveID7, out iQuality7, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽7地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat8Cao, out iCaoIndex8, out sTuoPanCode8, out iGrooveID8, out iQuality8, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽8地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat9Cao, out iCaoIndex9, out sTuoPanCode9, out iGrooveID9, out iQuality9, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽9地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat10Cao, out iCaoIndex10, out sTuoPanCode10, out iGrooveID10, out iQuality10, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽10地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat11Cao, out iCaoIndex11, out sTuoPanCode11, out iGrooveID11, out iQuality11, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽11地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat12Cao, out iCaoIndex12, out sTuoPanCode12, out iGrooveID12, out iQuality12, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽12地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat13Cao, out iCaoIndex13, out sTuoPanCode13, out iGrooveID13, out iQuality13, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽13地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat14Cao, out iCaoIndex14, out sTuoPanCode14, out iGrooveID14, out iQuality14, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽14地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat15Cao, out iCaoIndex15, out sTuoPanCode15, out iGrooveID15, out iQuality15, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽15地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat16Cao, out iCaoIndex16, out sTuoPanCode16, out iGrooveID16, out iQuality16, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽16地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat17Cao, out iCaoIndex17, out sTuoPanCode17, out iGrooveID17, out iQuality17, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽17地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat18Cao, out iCaoIndex18, out sTuoPanCode18, out iGrooveID18, out iQuality18, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽18地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat19Cao, out iCaoIndex19, out sTuoPanCode19, out iGrooveID19, out iQuality19, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽18地址时出错：{0}", strErr));
                return false;
            }
            if (!this.Listen_SaveReuslt_TuoPanCode_GrooveID(this._OPCHelperResult.Rt_Bat20Cao, out iCaoIndex20, out sTuoPanCode20, out iGrooveID20, out iQuality20, out strErr))
            {
                this.ShowErrAsyn(string.Format("读取结果数据的槽20地址时出错：{0}", strErr));
                return false;
            }
            int iBtyAddCount;
            try
            {
                this.MyForm.BllDAL.SaveResult(this.MyForm._RealTable_Result
                    , this._OPCHelperResult.Rt_Bat1Code.Value_String, this._OPCHelperResult.Rt_Bat1V.Value_Decimal, this._OPCHelperResult.Rt_Bat1Dz.Value_Decimal, iGrooveID1, this._OPCHelperResult.Rt_Bat1NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat2Code.Value_String, this._OPCHelperResult.Rt_Bat2V.Value_Decimal, this._OPCHelperResult.Rt_Bat2Dz.Value_Decimal, iGrooveID2, this._OPCHelperResult.Rt_Bat2NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat3Code.Value_String, this._OPCHelperResult.Rt_Bat3V.Value_Decimal, this._OPCHelperResult.Rt_Bat3Dz.Value_Decimal, iGrooveID3, this._OPCHelperResult.Rt_Bat3NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat4Code.Value_String, this._OPCHelperResult.Rt_Bat4V.Value_Decimal, this._OPCHelperResult.Rt_Bat4Dz.Value_Decimal, iGrooveID4, this._OPCHelperResult.Rt_Bat4NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat5Code.Value_String, this._OPCHelperResult.Rt_Bat5V.Value_Decimal, this._OPCHelperResult.Rt_Bat5Dz.Value_Decimal, iGrooveID5, this._OPCHelperResult.Rt_Bat5NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat6Code.Value_String, this._OPCHelperResult.Rt_Bat6V.Value_Decimal, this._OPCHelperResult.Rt_Bat6Dz.Value_Decimal, iGrooveID6, this._OPCHelperResult.Rt_Bat6NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat7Code.Value_String, this._OPCHelperResult.Rt_Bat7V.Value_Decimal, this._OPCHelperResult.Rt_Bat7Dz.Value_Decimal, iGrooveID7, this._OPCHelperResult.Rt_Bat7NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat8Code.Value_String, this._OPCHelperResult.Rt_Bat8V.Value_Decimal, this._OPCHelperResult.Rt_Bat8Dz.Value_Decimal, iGrooveID8, this._OPCHelperResult.Rt_Bat8NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat9Code.Value_String, this._OPCHelperResult.Rt_Bat9V.Value_Decimal, this._OPCHelperResult.Rt_Bat9Dz.Value_Decimal, iGrooveID9, this._OPCHelperResult.Rt_Bat9NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat10Code.Value_String, this._OPCHelperResult.Rt_Bat10V.Value_Decimal, this._OPCHelperResult.Rt_Bat10Dz.Value_Decimal, iGrooveID10, this._OPCHelperResult.Rt_Bat10NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat11Code.Value_String, this._OPCHelperResult.Rt_Bat11V.Value_Decimal, this._OPCHelperResult.Rt_Bat11Dz.Value_Decimal, iGrooveID11, this._OPCHelperResult.Rt_Bat11NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat12Code.Value_String, this._OPCHelperResult.Rt_Bat12V.Value_Decimal, this._OPCHelperResult.Rt_Bat12Dz.Value_Decimal, iGrooveID12, this._OPCHelperResult.Rt_Bat12NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat13Code.Value_String, this._OPCHelperResult.Rt_Bat13V.Value_Decimal, this._OPCHelperResult.Rt_Bat13Dz.Value_Decimal, iGrooveID13, this._OPCHelperResult.Rt_Bat13NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat14Code.Value_String, this._OPCHelperResult.Rt_Bat14V.Value_Decimal, this._OPCHelperResult.Rt_Bat14Dz.Value_Decimal, iGrooveID14, this._OPCHelperResult.Rt_Bat14NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat15Code.Value_String, this._OPCHelperResult.Rt_Bat15V.Value_Decimal, this._OPCHelperResult.Rt_Bat15Dz.Value_Decimal, iGrooveID15, this._OPCHelperResult.Rt_Bat15NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat16Code.Value_String, this._OPCHelperResult.Rt_Bat16V.Value_Decimal, this._OPCHelperResult.Rt_Bat16Dz.Value_Decimal, iGrooveID16, this._OPCHelperResult.Rt_Bat16NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat17Code.Value_String, this._OPCHelperResult.Rt_Bat17V.Value_Decimal, this._OPCHelperResult.Rt_Bat17Dz.Value_Decimal, iGrooveID17, this._OPCHelperResult.Rt_Bat17NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat18Code.Value_String, this._OPCHelperResult.Rt_Bat18V.Value_Decimal, this._OPCHelperResult.Rt_Bat18Dz.Value_Decimal, iGrooveID18, this._OPCHelperResult.Rt_Bat18NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat19Code.Value_String, this._OPCHelperResult.Rt_Bat19V.Value_Decimal, this._OPCHelperResult.Rt_Bat19Dz.Value_Decimal, iGrooveID19, this._OPCHelperResult.Rt_Bat19NGCase.Value_Short
                    , this._OPCHelperResult.Rt_Bat20Code.Value_String, this._OPCHelperResult.Rt_Bat20V.Value_Decimal, this._OPCHelperResult.Rt_Bat20Dz.Value_Decimal, iGrooveID20, this._OPCHelperResult.Rt_Bat20NGCase.Value_Short
                    , sTuoPanCode1, sTuoPanCode2, sTuoPanCode3, sTuoPanCode4, sTuoPanCode5, sTuoPanCode6, sTuoPanCode7, sTuoPanCode8, sTuoPanCode9, sTuoPanCode10,
                    sTuoPanCode11, sTuoPanCode12, sTuoPanCode13, sTuoPanCode14, sTuoPanCode15, sTuoPanCode16, sTuoPanCode17, sTuoPanCode18, sTuoPanCode19, sTuoPanCode20
                    , iCaoIndex1, iCaoIndex2, iCaoIndex3, iCaoIndex4, iCaoIndex5, iCaoIndex6, iCaoIndex7, iCaoIndex8, iCaoIndex9, iCaoIndex10,
                    iCaoIndex11, iCaoIndex12, iCaoIndex13, iCaoIndex14, iCaoIndex15, iCaoIndex16, iCaoIndex17, iCaoIndex18, iCaoIndex19, iCaoIndex20
                    , iQuality1, iQuality2, iQuality3, iQuality4, iQuality5, iQuality6, iQuality7, iQuality8, iQuality9, iQuality10,
                    iQuality11, iQuality12, iQuality13, iQuality14, iQuality15, iQuality16, iQuality17, iQuality18, iQuality19, iQuality20
                    , out iBtyAddCount);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("保存结果到远程服务器时出错：{0}({1})", ex.Message, ex.Source));
                return false;
            }
            this.Listen_BtyAddCount = iBtyAddCount;
            this.ShowLogAsyn(string.Format(@"成功保存结果,托盘号：{0}\{1}\{2}\{3}\{4}\{5}\{6}\{7}\{8}\{9}\{10}\{11}\{12}\{13}\{14}\{15}\{16}\{17}\{18}\{19}，新增：{20}个电芯",
                sTuoPanCode1, sTuoPanCode2, sTuoPanCode3, sTuoPanCode4, sTuoPanCode5, sTuoPanCode6, sTuoPanCode7, sTuoPanCode8, sTuoPanCode9, sTuoPanCode10,
                sTuoPanCode11, sTuoPanCode12, sTuoPanCode13, sTuoPanCode14, sTuoPanCode15, sTuoPanCode16, sTuoPanCode17, sTuoPanCode18, sTuoPanCode19, sTuoPanCode20, iBtyAddCount));
            if (this.RealDataShowNotice != null)
            {
                #region 发送测试结果
                string strCode = string.Empty;
                if (this._OPCHelperResult.Rt_Bat1Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat1Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat2Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat2Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat3Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat3Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat4Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat4Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat5Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat5Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat6Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat6Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat7Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat7Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat8Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat8Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat9Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat9Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat10Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat10Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat11Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat11Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat12Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat12Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat13Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat13Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat14Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat14Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat15Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat15Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat16Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat16Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat17Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat17Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat18Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat18Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat19Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat19Code.Value_String);
                if (this._OPCHelperResult.Rt_Bat20Code.Value_String.Length > 0)
                    strCode += string.Format("'{0}',", this._OPCHelperResult.Rt_Bat20Code.Value_String);
                if (strCode.Length > 0)
                    strCode = strCode.Substring(0, strCode.Length - 1);
                DataTable dtSNGet = null;
                if (strCode.Length > 0)
                {
                    string strSql = string.Format("SELECT Code,SN FROM {0} where code in ({1})", _RealTableBattery, strCode);
                    try
                    {
                        dtSNGet = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
                    }
                    catch (Exception ex)
                    {
                        this.ShowErrAsyn(string.Format("读取结果反馈数据时出错：{0}[{1}]", ex.Message, strSql));
                    }
                }
                #region 初始化要传输的对象
                
                ResultData data1 = new ResultData(1, iCaoIndex1, this._OPCHelperResult.Rt_Bat1Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat1V.Value_Decimal, this._OPCHelperResult.Rt_Bat1NGCase.Value_Short);
               
                ResultData data2 = new ResultData(2, iCaoIndex2, this._OPCHelperResult.Rt_Bat2Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat2V.Value_Decimal, this._OPCHelperResult.Rt_Bat2NGCase.Value_Short);
               
                ResultData data3 = new ResultData(3, iCaoIndex3, this._OPCHelperResult.Rt_Bat3Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat3V.Value_Decimal, this._OPCHelperResult.Rt_Bat3NGCase.Value_Short);
                
                ResultData data4 = new ResultData(4, iCaoIndex4, this._OPCHelperResult.Rt_Bat4Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat4V.Value_Decimal, this._OPCHelperResult.Rt_Bat4NGCase.Value_Short);
                
                ResultData data5 = new ResultData(5, iCaoIndex5, this._OPCHelperResult.Rt_Bat5Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat5V.Value_Decimal, this._OPCHelperResult.Rt_Bat5NGCase.Value_Short);
                
                ResultData data6 = new ResultData(6, iCaoIndex6, this._OPCHelperResult.Rt_Bat6Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat6V.Value_Decimal, this._OPCHelperResult.Rt_Bat6NGCase.Value_Short);
                
                ResultData data7 = new ResultData(7, iCaoIndex7, this._OPCHelperResult.Rt_Bat7Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat7V.Value_Decimal, this._OPCHelperResult.Rt_Bat7NGCase.Value_Short);
               
                ResultData data8 = new ResultData(8, iCaoIndex8, this._OPCHelperResult.Rt_Bat8Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat8V.Value_Decimal, this._OPCHelperResult.Rt_Bat8NGCase.Value_Short);
                
                ResultData data9 = new ResultData(9, iCaoIndex9, this._OPCHelperResult.Rt_Bat9Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat9V.Value_Decimal, this._OPCHelperResult.Rt_Bat9NGCase.Value_Short);
               
                ResultData data10 = new ResultData(10, iCaoIndex10, this._OPCHelperResult.Rt_Bat10Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat10V.Value_Decimal, this._OPCHelperResult.Rt_Bat10NGCase.Value_Short);
                
                ResultData data11 = new ResultData(11, iCaoIndex11, this._OPCHelperResult.Rt_Bat11Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat11V.Value_Decimal, this._OPCHelperResult.Rt_Bat11NGCase.Value_Short);
                
                ResultData data12 = new ResultData(12, iCaoIndex12, this._OPCHelperResult.Rt_Bat12Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat12V.Value_Decimal, this._OPCHelperResult.Rt_Bat12NGCase.Value_Short);
               
                ResultData data13 = new ResultData(13, iCaoIndex13, this._OPCHelperResult.Rt_Bat13Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat13V.Value_Decimal, this._OPCHelperResult.Rt_Bat13NGCase.Value_Short);
               
                ResultData data14 = new ResultData(14, iCaoIndex14, this._OPCHelperResult.Rt_Bat14Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat14V.Value_Decimal, this._OPCHelperResult.Rt_Bat14NGCase.Value_Short);
               
                ResultData data15 = new ResultData(15, iCaoIndex15, this._OPCHelperResult.Rt_Bat15Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat15V.Value_Decimal, this._OPCHelperResult.Rt_Bat15NGCase.Value_Short);
                
                ResultData data16 = new ResultData(16, iCaoIndex16, this._OPCHelperResult.Rt_Bat16Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat16V.Value_Decimal, this._OPCHelperResult.Rt_Bat16NGCase.Value_Short);
                
                ResultData data17 = new ResultData(17, iCaoIndex17, this._OPCHelperResult.Rt_Bat17Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat17V.Value_Decimal, this._OPCHelperResult.Rt_Bat17NGCase.Value_Short);
                
                ResultData data18 = new ResultData(18, iCaoIndex18, this._OPCHelperResult.Rt_Bat18Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat18V.Value_Decimal, this._OPCHelperResult.Rt_Bat18NGCase.Value_Short);
                
                ResultData data19 = new ResultData(19, iCaoIndex19, this._OPCHelperResult.Rt_Bat19Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat19V.Value_Decimal, this._OPCHelperResult.Rt_Bat19NGCase.Value_Short);
                
                ResultData data20 = new ResultData(20, iCaoIndex20, this._OPCHelperResult.Rt_Bat20Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat20V.Value_Decimal, this._OPCHelperResult.Rt_Bat20NGCase.Value_Short);
                
                #endregion
                if (dtSNGet != null)
                {
                    DataRow[] drsSn;
                    //此时读取成功了
                   // //ResultData data1 = new ResultData(1, iCaoIndex1, this._OPCHelperResult.Rt_Bat1Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat1V.Value_Decimal, this._OPCHelperResult.Rt_Bat1NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat1Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data1.SN = drsSn[0]["SN"].ToString();
                    //ResultData data2 = new ResultData(2, iCaoIndex2, this._OPCHelperResult.Rt_Bat2Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat2V.Value_Decimal, this._OPCHelperResult.Rt_Bat2NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat2Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data2.SN = drsSn[0]["SN"].ToString();
                    //ResultData data3 = new ResultData(3, iCaoIndex3, this._OPCHelperResult.Rt_Bat3Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat3V.Value_Decimal, this._OPCHelperResult.Rt_Bat3NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat3Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data3.SN = drsSn[0]["SN"].ToString();
                    //ResultData data4 = new ResultData(4, iCaoIndex4, this._OPCHelperResult.Rt_Bat4Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat4V.Value_Decimal, this._OPCHelperResult.Rt_Bat4NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat4Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data4.SN = drsSn[0]["SN"].ToString();
                    //ResultData data5 = new ResultData(5, iCaoIndex5, this._OPCHelperResult.Rt_Bat5Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat5V.Value_Decimal, this._OPCHelperResult.Rt_Bat5NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat5Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data5.SN = drsSn[0]["SN"].ToString();
                    //ResultData data6 = new ResultData(6, iCaoIndex6, this._OPCHelperResult.Rt_Bat6Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat6V.Value_Decimal, this._OPCHelperResult.Rt_Bat6NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat6Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data6.SN = drsSn[0]["SN"].ToString();
                    //ResultData data7 = new ResultData(7, iCaoIndex7, this._OPCHelperResult.Rt_Bat7Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat7V.Value_Decimal, this._OPCHelperResult.Rt_Bat7NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat7Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data7.SN = drsSn[0]["SN"].ToString();
                    //ResultData data8 = new ResultData(8, iCaoIndex8, this._OPCHelperResult.Rt_Bat8Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat8V.Value_Decimal, this._OPCHelperResult.Rt_Bat8NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat8Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data8.SN = drsSn[0]["SN"].ToString();
                    //ResultData data9 = new ResultData(9, iCaoIndex9, this._OPCHelperResult.Rt_Bat9Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat9V.Value_Decimal, this._OPCHelperResult.Rt_Bat9NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat9Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data9.SN = drsSn[0]["SN"].ToString();
                    //ResultData data10 = new ResultData(10, iCaoIndex10, this._OPCHelperResult.Rt_Bat10Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat10V.Value_Decimal, this._OPCHelperResult.Rt_Bat10NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat10Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data10.SN = drsSn[0]["SN"].ToString();
                    //ResultData data11 = new ResultData(11, iCaoIndex11, this._OPCHelperResult.Rt_Bat11Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat11V.Value_Decimal, this._OPCHelperResult.Rt_Bat11NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat11Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data11.SN = drsSn[0]["SN"].ToString();
                    //ResultData data12 = new ResultData(12, iCaoIndex12, this._OPCHelperResult.Rt_Bat12Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat12V.Value_Decimal, this._OPCHelperResult.Rt_Bat12NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat12Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data12.SN = drsSn[0]["SN"].ToString();
                    //ResultData data13 = new ResultData(13, iCaoIndex13, this._OPCHelperResult.Rt_Bat13Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat13V.Value_Decimal, this._OPCHelperResult.Rt_Bat13NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat13Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data13.SN = drsSn[0]["SN"].ToString();
                    //ResultData data14 = new ResultData(14, iCaoIndex14, this._OPCHelperResult.Rt_Bat14Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat14V.Value_Decimal, this._OPCHelperResult.Rt_Bat14NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat14Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data14.SN = drsSn[0]["SN"].ToString();
                    //ResultData data15 = new ResultData(15, iCaoIndex15, this._OPCHelperResult.Rt_Bat15Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat15V.Value_Decimal, this._OPCHelperResult.Rt_Bat15NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat15Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data15.SN = drsSn[0]["SN"].ToString();
                    //ResultData data16 = new ResultData(16, iCaoIndex16, this._OPCHelperResult.Rt_Bat16Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat16V.Value_Decimal, this._OPCHelperResult.Rt_Bat16NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat16Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data16.SN = drsSn[0]["SN"].ToString();
                    //ResultData data17 = new ResultData(17, iCaoIndex17, this._OPCHelperResult.Rt_Bat17Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat17V.Value_Decimal, this._OPCHelperResult.Rt_Bat17NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat17Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data17.SN = drsSn[0]["SN"].ToString();
                    //ResultData data18 = new ResultData(18, iCaoIndex18, this._OPCHelperResult.Rt_Bat18Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat18V.Value_Decimal, this._OPCHelperResult.Rt_Bat18NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat18Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data18.SN = drsSn[0]["SN"].ToString();
                    //ResultData data19 = new ResultData(19, iCaoIndex19, this._OPCHelperResult.Rt_Bat19Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat19V.Value_Decimal, this._OPCHelperResult.Rt_Bat19NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat19Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data19.SN = drsSn[0]["SN"].ToString();
                    //ResultData data20 = new ResultData(20, iCaoIndex20, this._OPCHelperResult.Rt_Bat20Dz.Value_Decimal, this._OPCHelperResult.Rt_Bat20V.Value_Decimal, this._OPCHelperResult.Rt_Bat20NGCase.Value_Short);
                    //读取条码
                    drsSn = dtSNGet.Select("Code='" + this._OPCHelperResult.Rt_Bat20Code.Value_String + "'");
                    if (drsSn.Length > 0)
                        data20.SN = drsSn[0]["SN"].ToString();
                }
                this.RealDataShowNotice(data1, data2, data3, data4, data5, data6, data7, data8, data9, data10, data11, data12, data13, data14, data15, data16, data17, data18, data19, data20);
                #endregion
            }
            #region 设备4特殊处理
            if (JPSConfig.MacNo == 99)
            {
                DataTable dtSnCnt = null;
                try
                {
                    dtSnCnt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select GrooveBtyCont from Testing_Grooves where Code='{0}'", this._TestCode));
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn(string.Format("4号机专项处理：读取槽1内电芯数量时出错：{0}({1})", ex.Message, ex.Source));
                }
                if (dtSnCnt != null)
                {
                    short iSnCnt;
                    if (dtSnCnt.Rows.Count == 0 || dtSnCnt.Rows[0]["GrooveBtyCont"].Equals(DBNull.Value))
                        iSnCnt = 0;
                    else
                    {
                        iSnCnt = short.Parse(dtSnCnt.Rows[0]["GrooveBtyCont"].ToString());
                    }
                    //写入
                    if(!this._OPCHelperResult.SetSNCount(iSnCnt, out strErr))
                    {
                        this.ShowErrAsyn(string.Format("4号机专项处理：写入槽1内电芯数量时出错：{0}", strErr));
                    }
                }
            }
            #endregion
            return true;
        }
        private bool Listen_SaveReuslt_TuoPanCode_GrooveID(JpsOPC.MyItemValue Rt_BatCao,out short iCaoIndex,out string sTuoPanCode,out long iGrooveID, out short iQuality, out string sErr)
        {
            if(Rt_BatCao==null)
            {
                sTuoPanCode = string.Empty;
                iGrooveID = 0;
                sErr = "结果集Rt_BatCao为空！";
                iCaoIndex = 0;
                iQuality = 0;
                return false;
            }
            if (Rt_BatCao.Value_Short <= 0 )
            {
                //此时可以认为这个槽没有电池
                sTuoPanCode = "";
                iGrooveID = 0;
                sErr = string.Empty;
                iCaoIndex = 0;
                iQuality = 0;
                return true;
            }
            if (Rt_BatCao.Value_Short > 18)
            {
                iGrooveID = 0;
                sTuoPanCode = string.Empty;
                sErr = string.Format("结果数据槽地址:{0}的值{1}不是预期的1~18！", Rt_BatCao.TagName, Rt_BatCao.Value_Short);
                iCaoIndex = 0;
                iQuality = 0;
                return false;
            }
            iCaoIndex = Rt_BatCao.Value_Short;
            GrooveData groove = this.FindGroove(iCaoIndex);
            sTuoPanCode = groove.TuoPanCode;
            iGrooveID = groove.GrooveID;
            iQuality = groove.Quality;
            if (Listen_Grooves == null)
                Listen_Grooves = new List<GrooveData>();
            if (Listen_Grooves.Find(delegate (GrooveData tempgroove) {
                return tempgroove.Index == groove.Index;
            }) == null)
            {
                Listen_Grooves.Add(groove);
            }
            sErr = string.Empty;
            this.ShowLogAsyn(string.Format("Cao:{0},GrooveID:{1}，TuoPanCode：{2}", iCaoIndex, iGrooveID, sTuoPanCode));
            return true;
        }
        private bool Listen_Statistic()
        {
            string strGrooveID = string.Empty;
            string strTuoPanCode = string.Empty;
            if (this.Listen_Grooves != null)
            {
                foreach (GrooveData groove in this.Listen_Grooves)
                {
                    strGrooveID += groove.GrooveID.ToString() + ",";
                    strTuoPanCode += string.Format("'{0}',", groove.TuoPanCode);
                }
            }
            if (strGrooveID == string.Empty) return true;
            strGrooveID = strGrooveID.Substring(0, strGrooveID.Length - 1);
            strTuoPanCode = strTuoPanCode.Substring(0, strTuoPanCode.Length - 1);
            string strSql = string.Format("SELECT GrooveID,COUNT(*) AS Cnt FROM {0} WHERE GrooveID in ({1}) AND TuoCode in ({2}) GROUP BY GrooveID", this.MyForm._RealTable_Result, strGrooveID, strTuoPanCode);
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("统计的电芯完成量时出错(GetCount)：{0}{1}[{2}]", ex.Message, ex.Source, strSql));
                return false;
            }
            //int iTotalBtyCount, iTotalTuoCount = 0;
            int iTuoPanAddCnt;
            #region 定义变量
            long lGrooveID1, lGrooveID2, lGrooveID3, lGrooveID4, lGrooveID5, lGrooveID6, lGrooveID7, lGrooveID8, lGrooveID9, lGrooveID10, lGrooveID11, lGrooveID12, lGrooveID13, lGrooveID14, lGrooveID15, lGrooveID16, lGrooveID17, lGrooveID18;
            string sTuoPanCode1, sTuoPanCode2, sTuoPanCode3, sTuoPanCode4, sTuoPanCode5, sTuoPanCode6, sTuoPanCode7, sTuoPanCode8, sTuoPanCode9, sTuoPanCode10, sTuoPanCode11, sTuoPanCode12, sTuoPanCode13, sTuoPanCode14, sTuoPanCode15, sTuoPanCode16, sTuoPanCode17, sTuoPanCode18;
            int iGrooveBtyCont1, iGrooveBtyCont2, iGrooveBtyCont3, iGrooveBtyCont4, iGrooveBtyCont5, iGrooveBtyCont6, iGrooveBtyCont7, iGrooveBtyCont8, iGrooveBtyCont9, iGrooveBtyCont10, iGrooveBtyCont11, iGrooveBtyCont12, iGrooveBtyCont13, iGrooveBtyCont14, iGrooveBtyCont15, iGrooveBtyCont16, iGrooveBtyCont17, iGrooveBtyCont18;
            int iTuoCount1, iTuoCount2, iTuoCount3, iTuoCount4, iTuoCount5, iTuoCount6, iTuoCount7, iTuoCount8, iTuoCount9, iTuoCount10, iTuoCount11, iTuoCount12, iTuoCount13, iTuoCount14, iTuoCount15, iTuoCount16, iTuoCount17, iTuoCount18;
            lGrooveID1 = 0;//this.Groove1.GrooveID;
            lGrooveID2 = 0;//this.Groove2.GrooveID;
            lGrooveID3 = 0;//this.Groove3.GrooveID;
            lGrooveID4 = 0;//this.Groove4.GrooveID;
            lGrooveID5 = 0;//this.Groove5.GrooveID;
            lGrooveID6 = 0;//this.Groove6.GrooveID;
            lGrooveID7 = 0;//this.Groove7.GrooveID;
            lGrooveID8 = 0;//this.Groove8.GrooveID;
            lGrooveID9 = 0;//this.Groove9.GrooveID;
            lGrooveID10 = 0;//this.Groove10.GrooveID;
            lGrooveID11 = 0;//this.Groove11.GrooveID;
            lGrooveID12 = 0;//this.Groove12.GrooveID;
            lGrooveID13 = 0;//this.Groove13.GrooveID;
            lGrooveID14 = 0;//this.Groove14.GrooveID;
            lGrooveID15 = 0;//this.Groove15.GrooveID;
            lGrooveID16 = 0;//this.Groove16.GrooveID;
            lGrooveID17 = 0;//this.Groove17.GrooveID;
            lGrooveID18 = 0;//this.Groove18.GrooveID;
            int iCount1 = 0, iCount2 = 0, iCount3 = 0, iCount4 = 0, iCount5 = 0, iCount6 = 0, iCount7 = 0, iCount8 = 0, iCount9 = 0, iCount10 = 0, iCount11 = 0, iCount12 = 0, iCount13 = 0, iCount14 = 0, iCount15 = 0, iCount16 = 0, iCount17 = 0, iCount18 = 0;
            long lTemp;
            int iCntTmp;
            foreach (DataRow dr in dt.Rows)
            {
                lTemp = long.Parse(dr["GrooveID"].ToString());
                iCntTmp = int.Parse(dr["Cnt"].ToString());
                if (lTemp == this.Groove1.GrooveID)
                {
                    iCount1 = iCntTmp;
                    lGrooveID1 = this.Groove1.GrooveID;
                    if (this.Groove1.TuoBtyCount > 0 && iCntTmp > this.Groove1.TuoBtyCount && !this.Groove1.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove2.GrooveID)
                {
                    iCount2 = iCntTmp;
                    lGrooveID2 = this.Groove2.GrooveID;
                    if (this.Groove2.TuoBtyCount > 0 && iCntTmp > this.Groove2.TuoBtyCount && !this.Groove2.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove3.GrooveID)
                {
                    iCount3 = iCntTmp;
                    lGrooveID3 = this.Groove3.GrooveID;
                    if (this.Groove3.TuoBtyCount > 0 && iCntTmp > this.Groove3.TuoBtyCount && !this.Groove3.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove4.GrooveID)
                {
                    iCount4 = iCntTmp;
                    lGrooveID4 = this.Groove4.GrooveID;
                    if (this.Groove4.TuoBtyCount > 0 && iCntTmp > this.Groove4.TuoBtyCount && !this.Groove4.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove5.GrooveID)
                {
                    iCount5 = iCntTmp;
                    lGrooveID5 = this.Groove5.GrooveID;
                    if (this.Groove5.TuoBtyCount > 0 && iCntTmp > this.Groove5.TuoBtyCount && !this.Groove5.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove6.GrooveID)
                {
                    iCount6 = iCntTmp;
                    lGrooveID6 = this.Groove6.GrooveID;
                    if (this.Groove6.TuoBtyCount > 0 && iCntTmp > this.Groove6.TuoBtyCount && !this.Groove6.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove7.GrooveID)
                {
                    iCount7 = iCntTmp;
                    lGrooveID7 = this.Groove7.GrooveID;
                    if (this.Groove7.TuoBtyCount > 0 && iCntTmp > this.Groove7.TuoBtyCount && !this.Groove7.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove8.GrooveID)
                {
                    iCount8 = iCntTmp;
                    lGrooveID8 = this.Groove8.GrooveID;
                    if (this.Groove8.TuoBtyCount > 0 && iCntTmp > this.Groove8.TuoBtyCount && !this.Groove8.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove9.GrooveID)
                {
                    iCount9 = iCntTmp;
                    lGrooveID9 = this.Groove9.GrooveID;
                    if (this.Groove9.TuoBtyCount > 0 && iCntTmp > this.Groove9.TuoBtyCount && !this.Groove9.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove10.GrooveID)
                {
                    iCount10 = iCntTmp;
                    lGrooveID10 = this.Groove10.GrooveID;
                    if (this.Groove10.TuoBtyCount > 0 && iCntTmp > this.Groove10.TuoBtyCount && !this.Groove10.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove11.GrooveID)
                {
                    iCount11 = iCntTmp;
                    lGrooveID11 = this.Groove11.GrooveID;
                    if (this.Groove11.TuoBtyCount > 0 && iCntTmp > this.Groove11.TuoBtyCount && !this.Groove11.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove12.GrooveID)
                {
                    iCount12 = iCntTmp;
                    lGrooveID12 = this.Groove12.GrooveID;
                    if (this.Groove12.TuoBtyCount > 0 && iCntTmp > this.Groove12.TuoBtyCount && !this.Groove12.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove13.GrooveID)
                {
                    iCount13 = iCntTmp;
                    lGrooveID13 = this.Groove13.GrooveID;
                    if (this.Groove13.TuoBtyCount > 0 && iCntTmp > this.Groove13.TuoBtyCount && !this.Groove13.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove14.GrooveID)
                {
                    iCount14 = iCntTmp;
                    lGrooveID14 = this.Groove14.GrooveID;
                    if (this.Groove14.TuoBtyCount > 0 && iCntTmp > this.Groove14.TuoBtyCount && !this.Groove14.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove15.GrooveID)
                {
                    iCount15 = iCntTmp;
                    lGrooveID15 = this.Groove15.GrooveID;
                    if (this.Groove15.TuoBtyCount > 0 && iCntTmp > this.Groove15.TuoBtyCount && !this.Groove15.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove16.GrooveID)
                {
                    iCount16 = iCntTmp;
                    lGrooveID16 = this.Groove16.GrooveID;
                    if (this.Groove16.TuoBtyCount > 0 && iCntTmp > this.Groove16.TuoBtyCount && !this.Groove16.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove17.GrooveID)
                {
                    iCount17 = iCntTmp;
                    lGrooveID17 = this.Groove17.GrooveID;
                    if (this.Groove17.TuoBtyCount > 0 && iCntTmp > this.Groove17.TuoBtyCount && !this.Groove17.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
                else if (lTemp == this.Groove18.GrooveID)
                {
                    iCount18 = iCntTmp;
                    lGrooveID18 = this.Groove18.GrooveID;
                    if (this.Groove18.TuoBtyCount > 0 && iCntTmp > this.Groove18.TuoBtyCount && !this.Groove18.AutoMK)
                    {
                        this.Listen_TuoPanBtyCountError = true;
                        //暂时不用退出return false;
                    }
                }
            }
            if(this.Listen_TuoPanBtyCountError)
            {
                if(this.Listen_IgnoreTuoPanBtyCountError)
                {
                    //此时外部操作将其错误忽略了，则继续执行下去
                    this.ShowLogAsyn("忽略了托盘内电芯数量超过规定数量，程序继续执行。");
                    this.Listen_TuoPanBtyCountError = false;//将错误清除掉
                    this.Listen_IgnoreTuoPanBtyCountError = false;//下次进入该函数还是需要重新判定是否有错误的
                }
                else
                {
                    //此时没有忽略，则继续往下执行
                    if (this.ResultControlerTuoPanBtyErrorNotice != null)
                        this.ResultControlerTuoPanBtyErrorNotice(this.Listen_Grooves);
                    Thread.Sleep(500);
                    return false;
                }
            }
            //iTotalBtyCount = iCount1 + iCount2 + iCount3 + iCount4 + iCount5 + iCount6 + iCount7 + iCount8 + iCount9 + iCount10 + iCount11 + iCount12 + iCount13 + iCount14 + iCount15 + iCount16 + iCount17 + iCount18;
            #endregion
            bool blTuopanPlanCompeleted;
            int iPlanFinisehedCnt;
            try
            {
                this.MyForm.BllDAL.GrooveStatistic(this.MyForm._TestCode, JPSConfig.MacNo,
                    lGrooveID1, iCount1, out sTuoPanCode1, out iGrooveBtyCont1, out iTuoCount1,
                    lGrooveID2, iCount2, out sTuoPanCode2, out iGrooveBtyCont2, out iTuoCount2,
                    lGrooveID3, iCount3, out sTuoPanCode3, out iGrooveBtyCont3, out iTuoCount3,
                    lGrooveID4, iCount4, out sTuoPanCode4, out iGrooveBtyCont4, out iTuoCount4,
                    lGrooveID5, iCount5, out sTuoPanCode5, out iGrooveBtyCont5, out iTuoCount5,
                    lGrooveID6, iCount6, out sTuoPanCode6, out iGrooveBtyCont6, out iTuoCount6,
                    lGrooveID7, iCount7, out sTuoPanCode7, out iGrooveBtyCont7, out iTuoCount7,
                    lGrooveID8, iCount8, out sTuoPanCode8, out iGrooveBtyCont8, out iTuoCount8,
                    lGrooveID9, iCount9, out sTuoPanCode9, out iGrooveBtyCont9, out iTuoCount9,
                    lGrooveID10, iCount10, out sTuoPanCode10, out iGrooveBtyCont10, out iTuoCount10,
                    lGrooveID11, iCount11, out sTuoPanCode11, out iGrooveBtyCont11, out iTuoCount11,
                    lGrooveID12, iCount12, out sTuoPanCode12, out iGrooveBtyCont12, out iTuoCount12,
                    lGrooveID13, iCount13, out sTuoPanCode13, out iGrooveBtyCont13, out iTuoCount13,
                    lGrooveID14, iCount14, out sTuoPanCode14, out iGrooveBtyCont14, out iTuoCount14,
                    lGrooveID15, iCount15, out sTuoPanCode15, out iGrooveBtyCont15, out iTuoCount15,
                    lGrooveID16, iCount16, out sTuoPanCode16, out iGrooveBtyCont16, out iTuoCount16,
                    lGrooveID17, iCount17, out sTuoPanCode17, out iGrooveBtyCont17, out iTuoCount17,
                    lGrooveID18, iCount18, out sTuoPanCode18, out iGrooveBtyCont18, out iTuoCount18
                    , out iTuoPanAddCnt, out blTuopanPlanCompeleted, out iPlanFinisehedCnt);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("统计电芯数量时出错(Statistic)：{0}{1}",  ex.Message, ex.Source));
                return false;
            }
            this.Listen_TuoPanAddCount = iTuoPanAddCnt;//本次托盘新增次数
            foreach (GrooveData groove in this.Listen_Grooves)
            {
                if (groove.Index == 1)
                {
                    if (sTuoPanCode1.Length > 0)
                    {
                        if (string.Compare(this.Groove1.TuoPanCode, sTuoPanCode1, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(1, this.Groove1.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：1号槽、托盘编号：" + this.Groove1.TuoPanCode);
                            }
                            this.Groove1.TuoPanCode = sTuoPanCode1;
                        }
                        this.Groove1.TuoCount = iTuoCount1;
                    }
                    if (iGrooveBtyCont1 >= 0)
                        this.Groove1.GrooveBtyCont = iGrooveBtyCont1;
                }
                else if (groove.Index == 2)
                {
                    if (sTuoPanCode2.Length > 0)
                    {
                        if (string.Compare(this.Groove2.TuoPanCode, sTuoPanCode2, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(2,this.Groove2.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：2号槽、托盘编号：" + this.Groove2.TuoPanCode);
                            }
                            this.Groove2.TuoPanCode = sTuoPanCode2;
                        }
                        this.Groove2.TuoCount = iTuoCount2;
                    }
                    if (iGrooveBtyCont2 >= 0)
                        this.Groove2.GrooveBtyCont = iGrooveBtyCont2;
                }
                else if (groove.Index == 3)
                {
                    if (sTuoPanCode3.Length > 0)
                    {
                        if (string.Compare(this.Groove3.TuoPanCode, sTuoPanCode3, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(3,this.Groove3.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：3号槽、托盘编号：" + this.Groove3.TuoPanCode);
                            }
                            this.Groove3.TuoPanCode = sTuoPanCode3;
                        }
                        this.Groove3.TuoCount = iTuoCount3;
                    }
                    if (iGrooveBtyCont3 >= 0)
                        this.Groove3.GrooveBtyCont = iGrooveBtyCont3;
                }
                else if (groove.Index == 4)
                {
                    if (sTuoPanCode4.Length > 0)
                    {
                        if (string.Compare(this.Groove4.TuoPanCode, sTuoPanCode4, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(4,this.Groove4.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：4号槽、托盘编号：" + this.Groove4.TuoPanCode);
                            }
                            this.Groove4.TuoPanCode = sTuoPanCode4;
                        }
                        this.Groove4.TuoCount = iTuoCount4;
                    }
                    if (iGrooveBtyCont4 >= 0)
                        this.Groove4.GrooveBtyCont = iGrooveBtyCont4;
                }
                else if (groove.Index == 5)
                {
                    if (sTuoPanCode5.Length > 0)
                    {
                        if (string.Compare(this.Groove5.TuoPanCode, sTuoPanCode5, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(5,this.Groove5.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：打印5号槽、托盘编号：" + this.Groove5.TuoPanCode);
                            }
                            this.Groove5.TuoPanCode = sTuoPanCode5;
                        }
                        this.Groove5.TuoCount = iTuoCount5;
                    }
                    if (iGrooveBtyCont5 >= 0)
                        this.Groove5.GrooveBtyCont = iGrooveBtyCont5;
                }
                else if (groove.Index == 6)
                {
                    if (sTuoPanCode6.Length > 0)
                    {
                        if (string.Compare(this.Groove6.TuoPanCode, sTuoPanCode6, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(6,this.Groove6.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：6号槽托、盘编号：" + this.Groove6.TuoPanCode);
                            }
                            this.Groove6.TuoPanCode = sTuoPanCode6;
                        }
                        this.Groove6.TuoCount = iTuoCount6;
                    }
                    if (iGrooveBtyCont6 >= 0)
                        this.Groove6.GrooveBtyCont = iGrooveBtyCont6;
                }
                else if (groove.Index == 7)
                {
                    if (sTuoPanCode7.Length > 0)
                    {
                        if (string.Compare(this.Groove7.TuoPanCode, sTuoPanCode7, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(7,this.Groove7.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：7号槽、托盘编号：" + this.Groove7.TuoPanCode);
                            }
                            this.Groove7.TuoPanCode = sTuoPanCode7;
                        }
                        this.Groove7.TuoCount = iTuoCount7;
                    }
                    if (iGrooveBtyCont7 >= 0)
                        this.Groove7.GrooveBtyCont = iGrooveBtyCont7;
                }
                else if (groove.Index == 8)
                {
                    if (sTuoPanCode8.Length > 0)
                    {
                        if (string.Compare(this.Groove8.TuoPanCode, sTuoPanCode8, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(8,this.Groove8.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：8号槽、托盘编号：" + this.Groove8.TuoPanCode);
                            }
                            this.Groove8.TuoPanCode = sTuoPanCode8;
                        }
                        this.Groove8.TuoCount = iTuoCount8;
                    }
                    if (iGrooveBtyCont8 >= 0)
                        this.Groove8.GrooveBtyCont = iGrooveBtyCont8;
                }
                else if (groove.Index == 9)
                {
                    if (sTuoPanCode9.Length > 0)
                    {
                        if (string.Compare(this.Groove9.TuoPanCode, sTuoPanCode9, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(9,this.Groove9.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：9号槽、托盘编号：" + this.Groove9.TuoPanCode);
                            }
                            this.Groove9.TuoPanCode = sTuoPanCode9;
                        }
                        this.Groove9.TuoCount = iTuoCount9;
                    }
                    if (iGrooveBtyCont9 >= 0)
                        this.Groove9.GrooveBtyCont = iGrooveBtyCont9;
                }
                else if (groove.Index == 10)
                {
                    if (sTuoPanCode10.Length > 0)
                    {
                        if (string.Compare(this.Groove10.TuoPanCode, sTuoPanCode10, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(10,this.Groove10.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：10号槽、托盘编号：" + this.Groove10.TuoPanCode);
                            }
                            this.Groove10.TuoPanCode = sTuoPanCode10;
                        }
                        this.Groove10.TuoCount = iTuoCount10;
                    }
                    if (iGrooveBtyCont10 >= 0)
                        this.Groove10.GrooveBtyCont = iGrooveBtyCont10;
                }
                else if (groove.Index == 11)
                {
                    if (sTuoPanCode11.Length > 0)
                    {
                        if (string.Compare(this.Groove11.TuoPanCode, sTuoPanCode11, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(11,this.Groove11.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：11号槽、托盘编号：" + this.Groove11.TuoPanCode);
                            }
                            this.Groove11.TuoPanCode = sTuoPanCode11;
                        }
                        this.Groove11.TuoCount = iTuoCount11;
                    }
                    if (iGrooveBtyCont11 >= 0)
                        this.Groove11.GrooveBtyCont = iGrooveBtyCont11;
                }
                else if (groove.Index == 12)
                {
                    if (sTuoPanCode12.Length > 0)
                    {
                        if (string.Compare(this.Groove12.TuoPanCode, sTuoPanCode12, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(12,this.Groove12.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：12号槽、托盘编号：" + this.Groove12.TuoPanCode);
                            }
                            this.Groove12.TuoPanCode = sTuoPanCode12;
                        }
                        this.Groove12.TuoCount = iTuoCount12;
                    }
                    if (iGrooveBtyCont12 >= 0)
                        this.Groove12.GrooveBtyCont = iGrooveBtyCont12;
                }
                else if (groove.Index == 13)
                {
                    if (sTuoPanCode13.Length > 0)
                    {
                        if (string.Compare(this.Groove13.TuoPanCode, sTuoPanCode13, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(13,this.Groove13.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：13号槽、托盘编号：" + this.Groove13.TuoPanCode);
                            }
                            this.Groove13.TuoPanCode = sTuoPanCode13;
                        }
                        this.Groove13.TuoCount = iTuoCount13;
                    }
                    if (iGrooveBtyCont13 >= 0)
                        this.Groove13.GrooveBtyCont = iGrooveBtyCont13;
                }
                else if (groove.Index == 14)
                {
                    if (sTuoPanCode14.Length > 0)
                    {
                        if (string.Compare(this.Groove14.TuoPanCode, sTuoPanCode14, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(14,this.Groove14.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：14号槽、托盘编号：" + this.Groove14.TuoPanCode);
                            }
                            this.Groove14.TuoPanCode = sTuoPanCode14;
                        }
                        this.Groove14.TuoCount = iTuoCount14;
                    }
                    if (iGrooveBtyCont14 >= 0)
                        this.Groove14.GrooveBtyCont = iGrooveBtyCont14;
                }
                else if (groove.Index == 15)
                {
                    if (sTuoPanCode15.Length > 0)
                    {
                        if (string.Compare(this.Groove15.TuoPanCode, sTuoPanCode15, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(15,this.Groove15.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：15号槽、托盘编号：" + this.Groove15.TuoPanCode);
                            }
                            this.Groove15.TuoPanCode = sTuoPanCode15;
                        }
                        this.Groove15.TuoCount = iTuoCount15;
                    }
                    if (iGrooveBtyCont15 >= 0)
                        this.Groove15.GrooveBtyCont = iGrooveBtyCont15;
                }
                else if (groove.Index == 16)
                {
                    if (sTuoPanCode16.Length > 0)
                    {
                        if (string.Compare(this.Groove16.TuoPanCode, sTuoPanCode16, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(16,this.Groove16.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：16号槽、托盘编号：" + this.Groove16.TuoPanCode);
                            }
                            this.Groove16.TuoPanCode = sTuoPanCode16;
                        }
                        this.Groove16.TuoCount = iTuoCount16;
                    }
                    if (iGrooveBtyCont16 >= 0)
                        this.Groove16.GrooveBtyCont = iGrooveBtyCont16;
                }
                else if (groove.Index == 17)
                {
                    if (sTuoPanCode17.Length > 0)
                    {
                        if (string.Compare(this.Groove17.TuoPanCode, sTuoPanCode17, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(17,this.Groove17.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：17号槽、托盘编号：" + this.Groove17.TuoPanCode);
                            }
                            this.Groove17.TuoPanCode = sTuoPanCode17;
                        }
                        this.Groove17.TuoCount = iTuoCount17;
                    }
                    if (iGrooveBtyCont17 >= 0)
                        this.Groove17.GrooveBtyCont = iGrooveBtyCont17;
                }
                else if (groove.Index == 18)
                {
                    if (sTuoPanCode18.Length > 0)
                    {
                        if (string.Compare(this.Groove18.TuoPanCode, sTuoPanCode18, true) != 0)
                        {
                            //iTotalTuoCount++;
                            //此时托盘编号变了，则要打印之前的编号
                            if (this._Printer.RequestPrint(18,this.Groove18.TuoPanCode))
                            {
                                this.ShowLogAsyn("已发送打印命令：18号槽托、盘编号：" + this.Groove18.TuoPanCode);
                            }
                            this.Groove18.TuoPanCode = sTuoPanCode18;
                        }
                        this.Groove18.TuoCount = iTuoCount18;
                    }
                    if (iGrooveBtyCont18 >= 0)
                        this.Groove18.GrooveBtyCont = iGrooveBtyCont18;
                }
            }
            //此时统计完成了，则通知主界面刷新，不需要重新刷新数据库来读取了
            if (this.GrooveStatisticSucessfulNotice != null)
                this.GrooveStatisticSucessfulNotice(this.Listen_Grooves, this.Listen_BtyAddCount, this.Listen_TuoPanAddCount);
            if (iTuoPanAddCnt > 0)
            {
                if (this.TuopanPlanProgressNotice != null)
                    this.TuopanPlanProgressNotice(blTuopanPlanCompeleted, iPlanFinisehedCnt);
                if (blTuopanPlanCompeleted)
                {
                    //此时托盘任务已经完成了，则通知用户
                    this.Listen_TuoPanPlanCompeleted = true;
                    this.ShowLogAsyn("托盘计划数量已经完成了，通知用户。");
                    return false;
                }
            }
            return true;
        }
        #region 总共18个槽号实例化对象
        public GrooveData Groove1 = null;
        public GrooveData Groove2 = null;
        public GrooveData Groove3 = null;
        public GrooveData Groove4 = null;
        public GrooveData Groove5 = null;
        public GrooveData Groove6 = null;
        public GrooveData Groove7 = null;
        public GrooveData Groove8 = null;
        public GrooveData Groove9 = null;
        public GrooveData Groove10 = null;
        public GrooveData Groove11 = null;
        public GrooveData Groove12 = null;
        public GrooveData Groove13 = null;
        public GrooveData Groove14 = null;
        public GrooveData Groove15 = null;
        public GrooveData Groove16 = null;
        public GrooveData Groove17 = null;
        public GrooveData Groove18 = null;
        
        private GrooveData FindGroove(short iCaoIndex)
        {
            if (iCaoIndex == 1) return this.Groove1;
            if (iCaoIndex == 2) return this.Groove2;
            if (iCaoIndex == 3) return this.Groove3;
            if (iCaoIndex == 4) return this.Groove4;
            if (iCaoIndex == 5) return this.Groove5;
            if (iCaoIndex == 6) return this.Groove6;
            if (iCaoIndex == 7) return this.Groove7;
            if (iCaoIndex == 8) return this.Groove8;
            if (iCaoIndex == 9) return this.Groove9;
            if (iCaoIndex == 10) return this.Groove10;
            if (iCaoIndex == 11) return this.Groove11;
            if (iCaoIndex == 12) return this.Groove12;
            if (iCaoIndex == 13) return this.Groove13;
            if (iCaoIndex == 14) return this.Groove14;
            if (iCaoIndex == 15) return this.Groove15;
            if (iCaoIndex == 16) return this.Groove16;
            if (iCaoIndex == 17) return this.Groove17;
            if (iCaoIndex == 18) return this.Groove18;
            this.ShowErrAsyn(string.Format("传入的槽编号{0}无效，应该是1到18的整数。", iCaoIndex));
            return null;
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
                BLLDAL.Testing.SaveResultLog("结果集执行出错：" + sMsg);
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
            //if (this.IsFormForOperatorOpend)
            //    this.MsgFormForOperator_AddMsg(sMsg, true);
            //else
            //{
            //    this.MyForm.ShowErr(sMsg);
            //}
        }
        public void ShowLogAsyn(string sMsg)
        {
            if (JPSConfig.ResultLogSavetoDataBase)
            {
                try
                {
                    BLLDAL.Testing.SaveResultLog(sMsg);
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn(ex.Message);
                }
            }
            else
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
            //ShowMsgAsynCallBack cb = new ShowMsgAsynCallBack(ShowLog);
            //try
            //{
            //    this.MyForm.Invoke(cb, new object[1] { sMsg });
            //}
            //catch (Exception ex)
            //{
            //    return;
            //}
        }
        public void ShowLog(string sMsg)
        {
            frmGetResultLog.ShowMyLog(sMsg);
        }
        #endregion
        #region 目标托盘数量操作

        #endregion
        #region 计算速度
        List<DateTime> ListTimes = new List<DateTime>();
        private void AddTime()
        {
            if (this.ListTimes.Count >= 20)
            {
                this.ListTimes.RemoveAt(0);
            }
            this.ListTimes.Add(DateTime.Now);
        }
        public void InitSpeed()
        {
            ListTimes = new List<DateTime>(); 
        }
        public double GetSpeed()
        {
            //读取速度
            if (ListTimes.Count <= 1) return 0D;
            TimeSpan ts = ListTimes[ListTimes.Count - 1] - ListTimes[0];
            double db = ts.TotalMilliseconds;
            double dbCount = SpeedCalculator_DxCount * (ListTimes.Count - 1);
            return 3600D * 1000D * dbCount / db;
        }
        #endregion
    }
    public class GrooveData
    {
        public GrooveData(short iIndex)
        {
            this.Index = iIndex;
        }
        /// <summary>
        /// 当前槽的序号，取值范围：[1,18]
        /// </summary>
        public short Index;
        public string TuoPanCode = string.Empty;
        public long GrooveID = 0;
        /// <summary>
        /// 总共已经完成托少托了
        /// </summary>
        public int TuoCount = 0;
        /// <summary>
        /// 每托电芯数量
        /// </summary>
        public int TuoBtyCount = 0;
        /// <summary>
        /// 当前托盘电芯数量（实时数据）
        /// </summary>
        public int GrooveBtyCont = 0;
        /// <summary>
        /// 是否上传MES
        /// </summary>
        public bool SendMes = false;
        public short Quality = 0;
        /// <summary>
        /// 是否自动插装的
        /// </summary>
        public bool AutoMK = false;
    }
    public class ResultData
    {
        public short Index = 0;
        public short CaoIndex = 0;
        public decimal DianZu = 0M;
        public decimal V = 0M;
        public string SN = string.Empty;
        /// <summary>
        /// 槽中的序列号
        /// </summary>
        public short TestIndex = 0;
        public ResultData(short iIndex,short iCaoIndex,decimal decDianZu,decimal decV,short iTestIndex)
        {
            this.Index = iIndex;
            this.CaoIndex = iCaoIndex;
            this.DianZu = decDianZu;
            this.V = decV;
            this.TestIndex = iTestIndex;
        }
    }

    public class Printer
    {
        frmMain1 MyForm = null;
        OperateExcel _Excel1 = null;
        OperateExcel _Excel2 = null;
        OperateExcel _Excel3 = null;
        OperateExcel _Excel4 = null;
        OperateExcel _Excel5 = null;
        OperateExcel _Excel6 = null;
        OperateExcel _Excel7 = null;
        OperateExcel _Excel8 = null;
        OperateExcel _Excel9 = null;
        OperateExcel _Excel10 = null;
        OperateExcel _Excel11 = null;
        OperateExcel _Excel12 = null;
        OperateExcel _Excel13 = null;
        OperateExcel _Excel14 = null;
        OperateExcel _Excel15 = null;
        OperateExcel _Excel16 = null;
        OperateExcel _Excel17 = null;
        OperateExcel _Excel18 = null;
        public Printer(frmMain1 myForm)
        {
            MyForm = myForm;
            _Excel1 = new OperateExcel(1);
            _Excel2 = new OperateExcel(2);
            _Excel3 = new OperateExcel(3);
            _Excel4 = new OperateExcel(4);
            _Excel5 = new OperateExcel(5);
            _Excel6 = new OperateExcel(6);
            _Excel7 = new OperateExcel(7);
            _Excel8 = new OperateExcel(8);
            _Excel9 = new OperateExcel(9);
            _Excel10 = new OperateExcel(10);
            _Excel11 = new OperateExcel(11);
            _Excel12 = new OperateExcel(12);
            _Excel13 = new OperateExcel(13);
            _Excel14 = new OperateExcel(14);
            _Excel15 = new OperateExcel(15);
            _Excel16 = new OperateExcel(16);
            _Excel17 = new OperateExcel(17);
            _Excel18 = new OperateExcel(18);
        }
        public bool Printing(string sTuoPanCode,short iCaoIndex)
        {
            this.ShowLogAsyn(string.Format("槽{0}请求打印\"{1}\"", iCaoIndex, sTuoPanCode));
            if (iCaoIndex > 0 && !JPSConfig.AutoPrintTuoPan)
            {
                //如果iCaoIndex的话表示是人工手动打印的，不是槽自动请求打印的
                this.ShowLogAsyn("当前系统为不自动打印，终止执行！");
                return true;
            }
            string strErr;
            if(iCaoIndex==1)
            {
                if(!_Excel1.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode,out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 2)
            {
                if (!_Excel2.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 3)
            {
                if (!_Excel3.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 4)
            {
                if (!_Excel4.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 5)
            {
                if (!_Excel5.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 6)
            {
                if (!_Excel6.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 7)
            {
                if (!_Excel7.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 8)
            {
                if (!_Excel8.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 9)
            {
                if (!_Excel9.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 10)
            {
                if (!_Excel10.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 11)
            {
                if (!_Excel11.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 12)
            {
                if (!_Excel12.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 13)
            {
                if (!_Excel13.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 14)
            {
                if (!_Excel14.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 15)
            {
                if (!_Excel15.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 16)
            {
                if (!_Excel16.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 17)
            {
                if (!_Excel17.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            else if (iCaoIndex == 18)
            {
                if (!_Excel18.RunExcelMacro(JPSConfig.TuoPanPrinter, sTuoPanCode, out strErr))
                {
                    this.ShowErrAsyn(string.Format("槽{0}打印\"{1}\"时出错：{2}", iCaoIndex, sTuoPanCode, strErr));
                    return false;
                }
                this.ShowLogAsyn(string.Format("槽{0}打印\"{1}\"成功！", iCaoIndex, sTuoPanCode));
            }
            return true;
        }
        #region 消息
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
            frmPrinterLog.ShowMyLog(sMsg);
        }
        #endregion
    }
    #endregion
    #region 工艺参数写入
    public class GongyiControl
    {
        public frmMain1 MyForm = null;
    }
    #endregion
    #region 统计数据
    public class StatisticControler
    {
        public event SnStatisticReadedCallBack SnStatisticReadedNotice = null;
        public event StatisticNGRateFinisehdCallback StatisticNGRateFinisehdNotice = null;
        public event StatisticUnQualityRateFinisehdCallback StatisticUnQualityRateFinisehdNotice = null;
        public frmMain1 MyForm = null;
        public bool Interrupt = false;
        Thread _thread = null;
        public bool Running = false;
        public string _RealTable_Batterys = string.Empty;
        public string _RealTable_Result = string.Empty;
        public bool _IsCheckerMBatchNum;
        public StatisticControler(frmMain1 mainForm)
        {
            this.MyForm = mainForm;
            //初始化18个槽
            this.Groove1 = new GrooveQuality(1);
            this.Groove2 = new GrooveQuality(2);
            this.Groove3 = new GrooveQuality(3);
            this.Groove4 = new GrooveQuality(4);
            this.Groove5 = new GrooveQuality(5);
            this.Groove6 = new GrooveQuality(6);
            this.Groove7 = new GrooveQuality(7);
            this.Groove8 = new GrooveQuality(8);
            this.Groove9 = new GrooveQuality(9);
            this.Groove10 = new GrooveQuality(10);
            this.Groove11 = new GrooveQuality(11);
            this.Groove12 = new GrooveQuality(12);
            this.Groove13 = new GrooveQuality(13);
            this.Groove14 = new GrooveQuality(14);
            this.Groove15 = new GrooveQuality(15);
            this.Groove16 = new GrooveQuality(16);
            this.Groove17 = new GrooveQuality(17);
            this.Groove18 = new GrooveQuality(18);
        }
        #region 18个槽的实例化对象
        public GrooveQuality Groove1 = null;
        public GrooveQuality Groove2 = null;
        public GrooveQuality Groove3 = null;
        public GrooveQuality Groove4 = null;
        public GrooveQuality Groove5 = null;
        public GrooveQuality Groove6 = null;
        public GrooveQuality Groove7 = null;
        public GrooveQuality Groove8 = null;
        public GrooveQuality Groove9 = null;
        public GrooveQuality Groove10 = null;
        public GrooveQuality Groove11 = null;
        public GrooveQuality Groove12 = null;
        public GrooveQuality Groove13 = null;
        public GrooveQuality Groove14 = null;
        public GrooveQuality Groove15 = null;
        public GrooveQuality Groove16 = null;
        public GrooveQuality Groove17 = null;
        public GrooveQuality Groove18 = null;
        #endregion
        public bool StartListenning(string sBatterysTable,string sResultTable,bool blIsCheckerMBatchNum, out string sErr)
        {
            if (this.Running)
            {
                sErr = "数据统计控制器的已经开启，请勿重复打开。";
                return false;
            }
            this.Running = true;
            this._RealTable_Batterys = sBatterysTable;
            this._RealTable_Result = sResultTable;
            this._IsCheckerMBatchNum = blIsCheckerMBatchNum;
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(Listen));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("数据统计控制器启动时出错：{0}({1})", ex.Message, ex.Source);
                this.Running = false;
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool StopListenning(out string sErr)
        {
            sErr = string.Empty;
            this.Running = false;
            return true;
        }
        /// <summary>
        /// 设置当前通讯是否中断
        /// </summary>
        /// <param name="blInterrupt">true：通讯中断，false：通讯正常</param>
        private void SetInterrupt(bool blInterrupt)
        {
            if (this.Interrupt != blInterrupt)
                this.Interrupt = blInterrupt;
        }
        #region 统计数据
        decimal Listen_ScannerNGRete = 0M;
        decimal Listen_MBatchNumYcRete = 0M;
        bool Listen_ScannerNGReteSuccessful = false;
        decimal Listen_UnQualityRate = 0M;
        bool Listen_UnQualityRateSuceessful = false;
        /// <summary>
        /// 总电芯数量
        /// </summary>
        string Listen_SnStatistic_SnCount = "---";
        /// <summary>
        /// 总良品率
        /// </summary>
        string Listen_SnStatistic_Lpl = "---";
        /// <summary>
        /// 总扫描良品率
        /// </summary>
        string Listen_SnStatistic_ScanLpl = "---";
        /// <summary>
        /// 总工单良品率
        /// </summary>
        string Listen_SnStatistic_MBatchLpl = "---";
        #endregion
        private void Listen()
        {
            while (true)
            {
                if (!this.Running)
                {
                    this.ShowLogAsyn("测试结果读取停止。");
                    break;
                }
                Thread.Sleep(JPSConfig.RefreshStatisticData);
                if (this.MyForm._TestState != JPSEnum.TestStates.Testing)
                {
                    continue;
                }
                if(StatisticNGRateFinisehdNotice!=null)
                {
                    this.ReadScannerNGRete();
                    this.StatisticNGRateFinisehdNotice(Listen_ScannerNGReteSuccessful, this.Listen_ScannerNGRete, this._IsCheckerMBatchNum, this.Listen_MBatchNumYcRete);
                }
                else
                {
                    this.ShowLogAsyn("NGRateFinisehdNotice事件未定义，不进行数据刷新。");
                }
                if(this.StatisticUnQualityRateFinisehdNotice!=null)
                {
                    this.ReadUnQualityRate();
                    this.StatisticUnQualityRateFinisehdNotice(this.Listen_UnQualityRateSuceessful, this.Listen_UnQualityRate);
                    this.ShowLogAsyn("UnQualityRateFinisehdNotice事件未定义，不进行数据刷新。");
                }
                ReadTotalSnStiatistic();
                this.SetInterrupt(false);
            }
        }
        private bool ReadScannerNGRete()
        {
            int iNGCount;
            int iAllCount;
            string strSql;
            DataTable dt;
            if (this._IsCheckerMBatchNum)
            {
                strSql = string.Format(@"SELECT SUM(CASE WHEN CaoIndex=16 THEN 1 ELSE 0 END) AS NGCount,SUM(CASE WHEN CaoIndex=15 THEN 1 ELSE 0 END) AS IsMBatchNumYcCount,COUNT(*) AS AllCount 
                FROM {0}", this._RealTable_Result);
                this.ShowLogAsyn(strSql);
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn(string.Format("统计扫码不良率及工单不良率时出错：{0}({1})[{2}]", ex.Message, ex.Source, strSql));
                    this.Listen_ScannerNGReteSuccessful = false;
                    return false;
                }
                iNGCount = dt.Rows[0]["NGCount"].Equals(DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["NGCount"].ToString());
                int iIsMBatchNumYcCount = dt.Rows[0]["IsMBatchNumYcCount"].Equals(DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["IsMBatchNumYcCount"].ToString());
                iAllCount = dt.Rows[0]["AllCount"].Equals(DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["AllCount"].ToString());
                if (iAllCount != 0)
                {
                    this.Listen_ScannerNGRete = (decimal)iNGCount / iAllCount;
                    this.Listen_MBatchNumYcRete = (decimal)iIsMBatchNumYcCount / iAllCount;
                }
                else
                {
                    this.Listen_ScannerNGRete = 0M;
                    this.Listen_MBatchNumYcRete = 0M;
                }
                this.Listen_ScannerNGReteSuccessful = true;
            }
            else
            {
                //此时不用读来料工单数据
                strSql = string.Format(@"SELECT SUM(CASE WHEN CaoIndex=16 THEN 1 ELSE 0 END) AS NGCount,COUNT(*) AS AllCount 
                FROM {0}", this._RealTable_Result);
                this.ShowLogAsyn(strSql);
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn(string.Format("统计扫码不良率时出错：{0}({1})[{2}]", ex.Message, ex.Source, strSql));
                    this.Listen_ScannerNGReteSuccessful = false;
                    return false;
                }
                iNGCount = dt.Rows[0]["NGCount"].Equals(DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["NGCount"].ToString());
                iAllCount = dt.Rows[0]["AllCount"].Equals(DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["AllCount"].ToString());
                if (iAllCount != 0)
                {
                    this.Listen_ScannerNGRete = (decimal)iNGCount / iAllCount;
                }
                else
                {
                    this.Listen_ScannerNGRete = 0;
                }
                this.Listen_ScannerNGReteSuccessful = true;
            }
            return true;
        }
        private bool ReadUnQualityRate()
        {
            DataTable dt;
            string strSql = string.Format("SELECT CaoIndex,COUNT(*) AS Cnt FROM {0} GROUP BY CaoIndex", this._RealTable_Result);
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("统计不良率时出错：{0}({1})", ex.Message, ex.Source));
                this.Listen_UnQualityRateSuceessful = false;
                return false;
            }
            int iTmp;
            int iUnQ = 0;
            int iCount = 0;
            GrooveQuality entity = null;
            foreach(DataRow dr in dt.Rows)
            {
                if (dr["Cnt"].Equals(DBNull.Value)) continue;
                iTmp = int.Parse(dr["Cnt"].ToString());
                #region 获取槽对象
                if (dr["CaoIndex"].ToString() == "1")
                    entity = this.Groove1;
                else if (dr["CaoIndex"].ToString() == "2")
                    entity = this.Groove2;
                else if (dr["CaoIndex"].ToString() == "3")
                    entity = this.Groove3;
                else if (dr["CaoIndex"].ToString() == "4")
                    entity = this.Groove4;
                else if (dr["CaoIndex"].ToString() == "5")
                    entity = this.Groove5;
                else if (dr["CaoIndex"].ToString() == "6")
                    entity = this.Groove6;
                else if (dr["CaoIndex"].ToString() == "7")
                    entity = this.Groove7;
                else if (dr["CaoIndex"].ToString() == "8")
                    entity = this.Groove8;
                else if (dr["CaoIndex"].ToString() == "9")
                    entity = this.Groove9;
                else if (dr["CaoIndex"].ToString() == "10")
                    entity = this.Groove10;
                else if (dr["CaoIndex"].ToString() == "11")
                    entity = this.Groove11;
                else if (dr["CaoIndex"].ToString() == "12")
                    entity = this.Groove12;
                else if (dr["CaoIndex"].ToString() == "13")
                    entity = this.Groove13;
                else if (dr["CaoIndex"].ToString() == "14")
                    entity = this.Groove14;
                else if (dr["CaoIndex"].ToString() == "15")
                    entity = this.Groove15;
                else if (dr["CaoIndex"].ToString() == "16")
                    entity = this.Groove16;
                else if (dr["CaoIndex"].ToString() == "17")
                    entity = this.Groove17;
                else if (dr["CaoIndex"].ToString() == "18")
                    entity = this.Groove18;
                else
                {
                    this.ShowErrAsyn(string.Format("统计不良率时获取的槽号\"{0}\"不是预期的1~18的值。", dr["CaoIndex"].ToString()));
                    entity = null;
                }
                #endregion
                if (entity == null)
                {
                    this.ShowErrAsyn(string.Format("统计不良率时无法获取的槽对象，槽号为：{0}。", dr["CaoIndex"].ToString()));
                    continue;
                }
                if (entity.Quality == 2)
                    iUnQ += iTmp;
                iCount += iTmp;
            }
            if(iCount==0)
            {
                Listen_UnQualityRate = 0;
            }
            else
            {
                Listen_UnQualityRate = (decimal)iUnQ / iCount;
            }
            this.Listen_UnQualityRateSuceessful = true;
            return true;
        }
        public bool ReadTotalSnStiatistic()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("EXEC ExpFuns_GetSnStatistic");
            }
            catch (Exception ex)
            {
                if (SnStatisticReadedNotice != null)
                    this.SnStatisticReadedNotice(string.Empty, string.Empty, string.Empty, string.Empty, false, string.Format("统计总电芯数据时出错：{0}({1})", ex.Message, ex.Source));
                //this.ShowErrAsyn(string.Format("统计总电芯数据时出错：{0}({1})", ex.Message, ex.Source));
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                if (SnStatisticReadedNotice != null)
                    this.SnStatisticReadedNotice(string.Empty, string.Empty, string.Empty, string.Empty, false, "返回了0行数据。");
                return false;
            }
            else
            {
                DataRow dr = dt.Rows[0];
                if (dr["SnCnt"].Equals(DBNull.Value))
                    this.Listen_SnStatistic_SnCount = "---";
                else
                {
                    this.Listen_SnStatistic_SnCount = decimal.Parse(dr["SnCnt"].ToString()).ToString("#########0");
                }
                if (dr["Lpl"].Equals(DBNull.Value))
                    this.Listen_SnStatistic_Lpl = "---";
                else
                {
                    this.Listen_SnStatistic_Lpl = decimal.Parse(dr["Lpl"].ToString()).ToString("#########0.00%");
                }
                if (dr["ScannLpl"].Equals(DBNull.Value))
                    this.Listen_SnStatistic_ScanLpl = "---";
                else
                {
                    this.Listen_SnStatistic_ScanLpl = decimal.Parse(dr["ScannLpl"].ToString()).ToString("#########0.00%");
                }
                if (dr["MbatchLpl"].Equals(DBNull.Value))
                    this.Listen_SnStatistic_MBatchLpl = "---";
                else
                {
                    this.Listen_SnStatistic_MBatchLpl = decimal.Parse(dr["MbatchLpl"].ToString()).ToString("#########0.00%");
                }
                if (SnStatisticReadedNotice != null)
                    this.SnStatisticReadedNotice(Listen_SnStatistic_SnCount, this.Listen_SnStatistic_Lpl, this.Listen_SnStatistic_ScanLpl, this.Listen_SnStatistic_MBatchLpl, true, string.Empty);
            }
            return true;
        }
        
        #region 消息
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
            //if (this.IsFormForOperatorOpend)
            //    this.MsgFormForOperator_AddMsg(sMsg, true);
            //else
            //{
            //    this.MyForm.ShowErr(sMsg);
            //}
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
            frmStatisticLog.ShowMyLog(sMsg);
        }
        #endregion
    }
    public class GrooveQuality
    {
        public GrooveQuality(short iIndex)
        {
            this.Index = iIndex;
        }
        public short Index = 0;
        public long GrooveID = 0;
        public short Quality = 0;
    }
    #endregion
    #region 发送到MES
    public class SendMesControler
    {
        public event RefreshSendMesCallback RefreshSendMesNotice = null;
        public event SNClearDataIsOverCallBack SNClearDataIsOverNotice = null;
        public frmMain1 MyForm = null;
        public bool Interrupt = false;
        Thread _thread = null;
        public bool Running = false;
        /// <summary>
        /// 校验执行数据总量是否超限了，该对象由主程序控制，当检查时不进行读取，以免影响效率
        /// </summary>
        public bool CheckTotalDataIsOver = true;
        public SendMesControler(frmMain1 mainForm)
        {
            this.MyForm = mainForm;
        }
        
        public bool StartListenning(out string sErr)
        {
            if (this.Running)
            {
                sErr = "数据统计控制器的已经开启，请勿重复打开。";
                return false;
            }
            this.Running = true;
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(Listen));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("上传MES数据控制器启动时出错：{0}({1})", ex.Message, ex.Source);
                this.Running = false;
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool StopListenning(out string sErr)
        {
            sErr = string.Empty;
            this.Running = false;
            return true;
        }
        
        #region 统计数据
        int Listen_SendingMesCount = 0;
        bool Listen_SendingMesSuceessful = false;
        #endregion
        private void Listen()
        {
            while (true)
            {
                if (!this.Running)
                {
                    this.ShowLogAsyn("MES上传更新停止。");
                    break;
                }
                Thread.Sleep(JPSConfig.RefreshSendMes);
                this.SendMes();
                
                //读取系统中总的数量
                if (this.CheckTotalDataIsOver)
                {
                    this.ShowLogAsyn("开始读取系统中总电芯量");
                    int iCount;
                    bool blOver;
                    string strErr;
                    if (!SNClear.GetDataCount(out blOver, out iCount, out strErr))
                    {
                        this.ShowErrAsyn(strErr);
                    }
                    else
                    {
                        this.SNClearDataIsOverNoticeAsyn(blOver, iCount);
                        this.ShowLogAsyn(string.Format("电芯量为：{0}，是否超限:{1}，系统最大：{2}", iCount, blOver, SNClear.MaxData));
                    }
                }
            }
        }
        private bool SendMes()
        {
            //int iQty;
            //string strErr;
            //if (GetCompeletedQty(this.MyForm._OrderNo, out iQty, out strErr))
            //{
            //    this.Listen_SendingMesSuceessful = true;
            //    this.Listen_SendingMesCount = iQty;
            //    this.ShowLogAsyn(string.Format("读取成功，已万恒MES托盘数量为：{0}。", iQty));
            //}
            //else
            //{
            //    this.Listen_SendingMesSuceessful = false;
            //    this.Listen_SendingMesCount = 0;
            //    this.ShowLogAsyn(string.Format("读取已上传托盘数量出错：{0}。", strErr));
            //}
            //if (RefreshSendMesNotice != null)
            //    RefreshSendMesNotice(this.Listen_SendingMesSuceessful, this.Listen_SendingMesCount);

            //发送数据
            DataTable dt, dtMK;
            string strSql = "select TuoPanCode,TestCode,FinishedTime,StMinR,StMaxR,StMinV,StMaxV,Capacity,Capacity1 FROM LuoLiuAssignerSendMes.dbo.SendMes_FinishedTuoPan where ISNULL(IsSentMes,0)=0  ORDER BY FinishedTime ASC";
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("读取待上传MES时出错：{0}({1})", ex.Message, ex.Source));
                this.CallRefreshSendMesNotice(false, 0);
                return false;
            }
            strSql = "select Code,StMinR,StMaxR,StMinV,StMaxV,Capacity,Capacity1 from LuoLiuAssignerSendMes.DBO.Assemble_MKSendMES order by FinishedTime ASC";
            try
            {
                dtMK = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("读取待上传MES时出错：{0}({1})", ex.Message, ex.Source));
                this.CallRefreshSendMesNotice(false, 0);
                return false;
            }
            this.CallRefreshSendMesNotice(true, dt.Rows.Count + dtMK.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                Thread.Sleep(100);
                this.Send2Mes(dr["TestCode"].ToString(), dr["TuoPanCode"].ToString(), dr["FinishedTime"], dr["StMinR"], dr["StMaxR"], dr["StMinV"], dr["StMaxV"], dr["Capacity"], dr["Capacity1"]);
            }
            foreach (DataRow dr in dtMK.Rows)
            {
                Thread.Sleep(100);
                this.Send2MesMK(dr["Code"].ToString(), dr["StMinR"], dr["StMaxR"], dr["StMinV"], dr["StMaxV"], dr["Capacity"], dr["Capacity1"]);
            }
            return true;
        }
        private void Send2MesMK(string sMKCodeCode, object objStMinR, object objStMaxR, object objStMinV, object objStMaxV, object objCapacity, object objCapacity1)
        {
            this.ShowLogAsyn(string.Format("开始上传模块[{0}]", sMKCodeCode));
            DataTable dtMain;
            string strSql = string.Format("SELECT A.*,B.OrderNo FROM LuoLiuAssignerSendMes.dbo.Assemble_MKSendMES A LEFT JOIN Testing_Main B ON B.Code=A.TestCode WHERE A.Code='{0}'", sMKCodeCode.Replace("'", "''"));
            try
            {
                dtMain = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("数据传至MES时出错：{0}({1})[{2}]", ex.Message, ex.Source, strSql));
                return;
            }
            if (dtMain.Rows.Count == 0)
            {
                this.ShowErrAsyn(string.Format("数据发送至MES表时出错：检测批次\"{0}\"的数据已被删除", sMKCodeCode));
                return;
            }
            DataRow drMain = dtMain.Rows[0];
            string sTestCode = drMain["TestCode"].ToString();
            object objFinishedTime;
            if (drMain["OrderNo"].Equals(DBNull.Value))
                objFinishedTime = DBNull.Value;
            else objFinishedTime = drMain["FinishedTime"];
            string strOrderNo = drMain["OrderNo"].ToString();
            string strTableResult = drMain["ResultTable"].ToString();
            string strTableBat = drMain["BatterysTable"].ToString();
            string strTableMkBatterys = drMain["MKBatterysTable"].ToString();
            strSql = string.Format(@"SELECT B.V,B.DianZu,C.SN FROM {0} A LEFT JOIN {1} B ON B.MyCode=A.MyCode
            LEFT JOIN {2} C ON C.Code=A.MyCode WHERE A.Code='{3}' order by a.AsbSort,a.SortID", strTableMkBatterys, strTableResult, strTableBat, sMKCodeCode.Replace("'", "''"));
            
            DataTable dtDx;
            try
            {
                dtDx = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("模块数据发送MES时出错：{0}({1})[{2}]", ex.Message, ex.Source, strSql));
                return;
            }
            this.ShowLogAsyn(string.Format("模块[{0}]，获取到电芯数量[{1}]", sMKCodeCode, dtDx.Rows.Count));
            //保存到远程数据库
            //校验是否已经存在
            DataTable dtExist;
            strSql = string.Format(@"SELECT A.*,B.MacName,C.UserName FROM Produce_Assign_TuoPan A LEFT JOIN JC_ProcessMacs B ON B.Code=A.MacCode 
                    LEFT JOIN Sys_Users C ON C.UserCode = A.Operator
                    WHERE A.TuoPan = '{0}'", sMKCodeCode.Replace("'", "''"));
            try
            {
                dtExist = CommonDAL.DoSqlCommandRemoteMES.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("模块数据发送至MES前校验托盘是否已发送时出错：{0}({1})[{2}]", ex.Message, ex.Source, strSql));
                return;
            }
            if (dtExist.Rows.Count > 0)
            {
                DataRow drExsit = dtExist.Rows[0];
                this.ShowErrAsyn(string.Format("托盘\"{0}\"已经由{1}于{2}在机台\"{3}\"上传至MES，当前不能传送该托盘信息。"
                    , drExsit["TuoPan"], drExsit["UserName"], drExsit["Times"], drExsit["MacName"]));
                return;
            }
            this.ShowLogAsyn(string.Format("开始 上传模块[{0}]，电芯数量[{1}]", sMKCodeCode, dtDx.Rows.Count));
            //获取数据源
            DataSet dsSource;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            listSql.Add(new CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM Produce_Assign_TuoPan WHERE TuoPan='{0}'", sMKCodeCode.Replace("'", "''")), "Produce_Assign_TuoPan", true));
            listSql.Add(new CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM Produce_Assign_Dx WHERE TuoPan='{0}'", sMKCodeCode.Replace("'", "''")), "Produce_Assign_Dx", true));
            try
            {
                dsSource = CommonDAL.DoSqlCommandRemoteMES.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("发送MES数据前获取数据源时出错：{0}({1})", ex.Message, ex.Source));
                return;
            }
            //填充数据源
            DataRow drNew = dsSource.Tables["Produce_Assign_TuoPan"].NewRow();
            drNew["TuoPan"] = sMKCodeCode;
            drNew["Operator"] = Common.CurrentUserInfo.UserCode;
            drNew["StationCode"] = JPSConfig.StationCode;
            drNew["MacCode"] = JPSConfig.MacCode;
            drNew["PlanGuid"] = strOrderNo;
            drNew["FinishedTime"] = objFinishedTime;
            drNew["StMinR"] = objStMinR;
            drNew["StMaxR"] = objStMaxR;
            drNew["StMinV"] = objStMinV;
            drNew["StMaxV"] = objStMaxV;
            drNew["Capacity"] = objCapacity;
            drNew["Capacity1"] = objCapacity1;
            dsSource.Tables["Produce_Assign_TuoPan"].Rows.Add(drNew);
            //添加电芯明细
            int iExcDxCnt = dtDx.Rows.Count;
            foreach (DataRow dr in dtDx.Rows)
            {
                DataRow drDx = dsSource.Tables["Produce_Assign_Dx"].NewRow();
                drDx["TuoPan"] = sMKCodeCode;
                drDx["DxSn"] = dr["SN"];
                drDx["DianZu"] = dr["DianZu"];
                drDx["V"] = dr["V"];
                dsSource.Tables["Produce_Assign_Dx"].Rows.Add(drDx);
            }
            //提交数据库
            try
            {
                BLLDAL.RemoteMES.Save2Mes(dsSource);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("发送MES数据时出错：{0}({1})", ex.Message, ex.Source));
                return;
            }
            this.ShowLogAsyn(string.Format("已将批次{0}下模块{1}的数据上传至MES，共执行了{2}行数据。", sTestCode, sMKCodeCode, iExcDxCnt));
            //更新当前托盘数据
            strSql = string.Format("DELETE FROM LuoLiuAssignerSendMes.dbo.Assemble_MKSendMES WHERE Code='{0}'"
                , sMKCodeCode.Replace("'", "''"));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("发送MES数据完后更新待上传托盘时出错：{0}({1})[{2}]", ex.Message, ex.Source, strSql));
                return;
            }
            this.ShowLogAsyn(string.Format("已成功将模块[{0}]上传并移除。", sMKCodeCode));
        }
        private void Send2Mes(string sTestCode, string sTuoPanCode, object objFinishedTime, object objStMinR, object objStMaxR, object objStMinV, object objStMaxV, object objCapacity, object objCapacity1)
        {
            DataTable dtMain;
            string strSql = string.Format("SELECT Operator,MacCode,OrderNo,ResultTable,BatterysTable,AutoMKOn FROM Testing_Main WHERE Code='{0}'", sTestCode.Replace("'", "''"));
            try
            {
                dtMain = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("数据传至MES时出错：{0}({1})[{2}]", ex.Message, ex.Source, strSql));
                return;
            }
            if (dtMain.Rows.Count == 0)
            {
                this.ShowErrAsyn(string.Format("数据发送至MES表时出错：检测批次\"{0}\"的数据已被删除", sTestCode));
                return;
            }
            DataRow drMain = dtMain.Rows[0];
            string strTableResult = drMain["ResultTable"].ToString();
            string strTableBat = drMain["BatterysTable"].ToString();
           
            strSql = string.Format(@"SELECT A.V,A.DianZu,B.SN FROM {0} A LEFT JOIN {1} B ON B.Code=A.MyCode
                    WHERE A.TuoCode = '{2}'", strTableResult, strTableBat, sTuoPanCode.Replace("'", "''"));
            string strOrderNo = drMain["OrderNo"].ToString();
            DataTable dtDx;
            try
            {
                dtDx = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("数据发送MES时出错：{0}({1})[{2}]", ex.Message, ex.Source, strSql));
                return;
            }
            //保存到远程数据库
            //校验是否已经存在
            DataTable dtExist;
            strSql = string.Format(@"SELECT A.*,B.MacName,C.UserName FROM Produce_Assign_TuoPan A LEFT JOIN JC_ProcessMacs B ON B.Code=A.MacCode 
                    LEFT JOIN Sys_Users C ON C.UserCode = A.Operator
                    WHERE A.TuoPan = '{0}'", sTuoPanCode.Replace("'", "''"));
            try
            {
                dtExist = CommonDAL.DoSqlCommandRemoteMES.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("发送MES数据前校验托盘是否已发送时出错：{0}({1})[{2}]", ex.Message, ex.Source, strSql));
                return;
            }
            if (dtExist.Rows.Count > 0)
            {
                DataRow drExsit = dtExist.Rows[0];
                this.ShowErrAsyn(string.Format("托盘\"{0}\"已经由{1}于{2}在机台\"{3}\"上传至MES，当前不能传送该托盘信息。"
                    , drExsit["TuoPan"], drExsit["UserName"], drExsit["Times"], drExsit["MacName"]));
                return;
            }
            //获取数据源
            DataSet dsSource;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            listSql.Add(new CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM Produce_Assign_TuoPan WHERE TuoPan='{0}'", sTuoPanCode.Replace("'", "''")), "Produce_Assign_TuoPan", true));
            listSql.Add(new CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM Produce_Assign_Dx WHERE TuoPan='{0}'", sTuoPanCode.Replace("'", "''")), "Produce_Assign_Dx", true));
            try
            {
                dsSource = CommonDAL.DoSqlCommandRemoteMES.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("发送MES数据前获取数据源时出错：{0}({1})", ex.Message, ex.Source));
                return;
            }
            //填充数据源
            DataRow drNew = dsSource.Tables["Produce_Assign_TuoPan"].NewRow();
            drNew["TuoPan"] = sTuoPanCode;
            drNew["Operator"] = Common.CurrentUserInfo.UserCode;
            drNew["StationCode"] = JPSConfig.StationCode;
            drNew["MacCode"] = JPSConfig.MacCode;
            drNew["PlanGuid"] = strOrderNo;
            drNew["FinishedTime"] = objFinishedTime;
            drNew["StMinR"] = objStMinR;
            drNew["StMaxR"] = objStMaxR;
            drNew["StMinV"] = objStMinV;
            drNew["StMaxV"] = objStMaxV;
            drNew["Capacity"] = objCapacity;
            drNew["Capacity1"] = objCapacity1;
            dsSource.Tables["Produce_Assign_TuoPan"].Rows.Add(drNew);
            //添加电芯明细
            int iExcDxCnt = dtDx.Rows.Count;
            foreach (DataRow dr in dtDx.Rows)
            {
                DataRow drDx = dsSource.Tables["Produce_Assign_Dx"].NewRow();
                drDx["TuoPan"] = sTuoPanCode;
                drDx["DxSn"] = dr["SN"];
                drDx["DianZu"] = dr["DianZu"];
                drDx["V"] = dr["V"];
                dsSource.Tables["Produce_Assign_Dx"].Rows.Add(drDx);
            }
            //提交数据库
            try
            {
                BLLDAL.RemoteMES.Save2Mes(dsSource);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("发送MES数据时出错：{0}({1})", ex.Message, ex.Source));
                return;
            }
            this.ShowLogAsyn(string.Format("已将批次号{0}下托盘{1}的数据上传至MES，共执行了{2}行数据。", sTestCode, sTuoPanCode, iExcDxCnt));
            //更新当前托盘数据
            strSql = string.Format("UPDATE LuoLiuAssignerSendMes.dbo.SendMes_FinishedTuoPan SET IsSentMes=1,SentMesCount={0},SentMesTime=getdate() WHERE TuoPanCode='{1}'"
                , iExcDxCnt, sTuoPanCode.Replace("'", "''"));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("发送MES数据完后更新待上传托盘时出错：{0}({1})[{2}]", ex.Message, ex.Source, strSql));
                return;
            }
        }
        #region 消息
        private void CallRefreshSendMesNotice(bool blSuccessfule,int iCnt)
        {
            if (this.RefreshSendMesNotice != null)
                RefreshSendMesNotice(blSuccessfule, iCnt);
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
            //if (this.IsFormForOperatorOpend)
            //    this.MsgFormForOperator_AddMsg(sMsg, true);
            //else
            //{
            //    this.MyForm.ShowErr(sMsg);
            //}
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
            frmSendMesLog.ShowMyLog(sMsg);
        }

        #endregion
        #region 通知是否总是超限了
        private void SNClearDataIsOverNoticeAsyn(bool blOver, int iCount)
        {
            SNClearDataIsOverCallBack call = new SNClearDataIsOverCallBack(CallSNClearDataIsOverNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { blOver , iCount });
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }
        private void CallSNClearDataIsOverNotice(bool blOver, int iCount)
        {
            if (this.SNClearDataIsOverNotice != null)
                this.SNClearDataIsOverNotice(blOver, iCount);
        }
        #endregion
        #region 获取当前已经完成的托盘数量
        
        public static bool GetCompeletedMKQty(string sPlanGuid, out int iQty, out string sErrMsg)
        {
            iQty = 0;
            sErrMsg = string.Empty;
            DataTable dt;
            string strSql = string.Format(@"SELECT FinishedMKCnt FROM Testing_Main where OrderNo='{0}'", sPlanGuid.Replace("'", "''"));
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                sErrMsg = string.Format("读取已完成模块总数时出错：{0}({1})[{2}]", ex.Message, ex.Source, strSql);
                return false;
            }
            if (dt.Rows.Count == 0)
                return true;
            iQty = dt.Rows[0]["FinishedMKCnt"].Equals(DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["FinishedMKCnt"].ToString());
            return true;
        }
        #endregion
    }
    #endregion
    #region 远程数据拷贝
    public class RemoteSNCopyControler
    {
        public frmMain1 MyForm = null;
        public RemoteSNCopyControler(frmMain1 mainForm)
        {
            this.MyForm = mainForm;
        }
        public RemoteSNCopy _RemoteSNCopy1 = null;
        public RemoteSNCopy _RemoteSNCopy2 = null;
        public RemoteSNCopy _RemoteSNCopy3 = null;
        public void Start()
        {
            this.ShowLogAsyn(string.Format("当前不执行测试，启动电芯数据拷贝，当前设备号：{0}。", JPSConfig.MacNo));
            short iMacNo1, iMacNo2, iMacNo3;
            if(JPSConfig.MacNo==1)
            {
                iMacNo1 = 2;
                iMacNo2 = 3;
                iMacNo3 = 4;
            }
            else if (JPSConfig.MacNo == 2)
            {
                iMacNo1 = 1;
                iMacNo2 = 3;
                iMacNo3 = 4;
            }
            else if (JPSConfig.MacNo == 3)
            {
                iMacNo1 = 1;
                iMacNo2 = 2;
                iMacNo3 = 4;
            }
            else if (JPSConfig.MacNo == 4)
            {
                iMacNo1 = 1;
                iMacNo2 = 2;
                iMacNo3 = 3;
            }
            else
            {
                return;
            }
            long lStartID;
            string strErr;
            if (JPSConfig.RemoteMacConfig._IP1.Length > 0)
            {
                if (this._RemoteSNCopy1 == null || !this._RemoteSNCopy1.Running)
                {
                    Common.SqlServerCommand sqlCmd = new Common.SqlServerCommand(string.Format(@"Server={0}\JPS2008;Database=LuoLiuAssigner;User=sa;Password=zxp;Connect Timeout=120;", JPSConfig.RemoteMacConfig._IP1));
                    this._RemoteSNCopy1 = new RemoteSNCopy(this.MyForm, sqlCmd, iMacNo1, true);
                    if (this.GetStartID(iMacNo1, sqlCmd, out lStartID))
                    {
                        if(this._RemoteSNCopy1.StartListenning(lStartID, out strErr))
                        {
                            this.ShowLogAsyn(string.Format("成功启动设备{0}的电芯数据复制。", iMacNo1));
                        }
                        else
                        {
                            this.ShowErrAsyn(string.Format("启动设备{0}的电芯数据复制时出错：{1}。", iMacNo1, strErr));
                        }
                    }
                }
                else
                {
                    this.ShowLogAsyn(string.Format("设备{0}正在电芯数据拷贝中，没有再启动。", iMacNo1));
                }
            }
            if (JPSConfig.RemoteMacConfig._IP2.Length > 0)
            {
                if (this._RemoteSNCopy2 == null || !this._RemoteSNCopy2.Running)
                {
                    Common.SqlServerCommand sqlCmd = new Common.SqlServerCommand(string.Format(@"Server={0}\JPS2008;Database=LuoLiuAssigner;User=sa;Password=zxp;Connect Timeout=120;", JPSConfig.RemoteMacConfig._IP2));
                    this._RemoteSNCopy2 = new RemoteSNCopy(this.MyForm, sqlCmd, iMacNo2, true);
                    if (this.GetStartID(iMacNo2, sqlCmd, out lStartID))
                    {
                        if (this._RemoteSNCopy2.StartListenning(lStartID, out strErr))
                        {
                            this.ShowLogAsyn(string.Format("成功启动设备{0}的电芯数据复制。", iMacNo2));
                        }
                        else
                        {
                            this.ShowErrAsyn(string.Format("启动设备{0}的电芯数据复制时出错：{1}。", iMacNo2, strErr));
                        }
                    }
                }
                else
                {
                    this.ShowLogAsyn(string.Format("设备{0}正在电芯数据拷贝中，没有再启动。", iMacNo2));
                }
            }
            if (JPSConfig.RemoteMacConfig._IP3.Length > 0)
            {
                if (this._RemoteSNCopy3 == null || !this._RemoteSNCopy3.Running)
                {
                    Common.SqlServerCommand sqlCmd = new Common.SqlServerCommand(string.Format(@"Server={0}\JPS2008;Database=LuoLiuAssigner;User=sa;Password=zxp;Connect Timeout=120;", JPSConfig.RemoteMacConfig._IP3));
                    this._RemoteSNCopy3 = new RemoteSNCopy(this.MyForm, sqlCmd, iMacNo3, true);
                    if (this.GetStartID(iMacNo3, sqlCmd, out lStartID))
                    {
                        if (this._RemoteSNCopy3.StartListenning(lStartID, out strErr))
                        {
                            this.ShowLogAsyn(string.Format("成功启动设备{0}的电芯数据复制。", iMacNo3));
                        }
                        else
                        {
                            this.ShowErrAsyn(string.Format("启动设备{0}的电芯数据复制时出错：{1}。", iMacNo3, strErr));
                        }
                    }
                }
                else
                {
                    this.ShowLogAsyn(string.Format("设备{0}正在电芯数据拷贝中，没有再启动。", iMacNo3));
                }
            }
        }
        public void Stop()
        {
            if(this._RemoteSNCopy1!=null && this._RemoteSNCopy1.Running)
            {
                this._RemoteSNCopy1.Running = false;
                this.ShowLogAsyn("电芯数据复制工具1正在执行中，当前终止执行。");
            }
            else
            {
                this.ShowLogAsyn("电芯数据复制工具1没有运行，无需终止。");
            }
            if (this._RemoteSNCopy2 != null && this._RemoteSNCopy2.Running)
            {
                this._RemoteSNCopy2.Running = false;
                this.ShowLogAsyn("电芯数据复制工具2正在执行中，当前终止执行。");
            }
            else
            {
                this.ShowLogAsyn("电芯数据复制工具2没有运行，无需终止。");
            }
            if (this._RemoteSNCopy3 != null && this._RemoteSNCopy3.Running)
            {
                this._RemoteSNCopy3.Running = false;
                this.ShowLogAsyn("电芯数据复制工具3正在执行中，当前终止执行。");
            }
            else
            {
                this.ShowLogAsyn("电芯数据复制工具3没有运行，无需终止。");
            }
        }
        public bool GetStartID(short iMacNo, Common.SqlServerCommand sqlCmd,out long lStartID)
        {
            lStartID = 0;
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MAX(LocalID) AS ID FROM SN1 WHERE MacNo={0}", iMacNo));
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(string.Format("读取设备{0}的最大电芯的ID值时出错：{1}({2})", iMacNo, ex.Message, ex.Source));
                return false;
            }
            if (dt.Rows.Count == 0 || dt.Rows[0]["ID"].Equals(DBNull.Value))
                lStartID = 0;
            else lStartID = long.Parse(dt.Rows[0]["ID"].ToString());
            return true;
        }
        #region 消息
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
            //if (this.IsFormForOperatorOpend)
            //    this.MsgFormForOperator_AddMsg(sMsg, true);
            //else
            //{
            //    this.MyForm.ShowErr(sMsg);
            //}
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
            frmSNCopyLog.ShowMyLog(sMsg);
        }
        #endregion
    }
    public class RemoteSNCopy
    {
        public event RemoteSNCopyFinishedCallBack RemoteSNCopyFinishedNotice = null;
        short _MacNo = 0;
        public SqlServerCommand _SqlCmd = null;
        /// <summary>
        /// 是否是程序在后台自动执行的
        /// </summary>
        bool _IsAutoCopy = false;
        /// <summary>
        /// 起始ID
        /// </summary>
        long _StartID = 0;
        /// <summary>
        /// 错误消息
        /// </summary>
        public string _ErrMsg = string.Empty;
        public RemoteSNCopy(System.Windows.Forms.Form mainForm,SqlServerCommand sqlCmd,short iMacNo,bool isAutoCopy)
        {
            this.MyForm = mainForm;
            this._SqlCmd = sqlCmd;
            this._MacNo = iMacNo;
            this._IsAutoCopy = isAutoCopy;
        }
        private void Copy()
        {
            int iCount;
            bool blResult;
            while(true)
            {
                if (!this.Running)
                {
                    this.ShowLogAsyn("当前退出执行,通过running退出。");
                    this.RemoteSNCopyFinishedNoticeAsyn(true, true, 0);
                    return;
                }
                blResult = this.Copying(out iCount);
                if(!blResult)
                {
                    this.RemoteSNCopyFinishedNoticeAsyn(true, false, iCount);
                    return;
                }
                else
                {
                    if(iCount==0)
                    {
                        this.ShowLogAsyn("当前退出执行,因为远程设备只有0行数据。");
                        //此时表示已经执行完了
                        this.RemoteSNCopyFinishedNoticeAsyn(true, true, 0);
                        this.Running = false;
                        return;
                    }
                    else
                    {
                        this.RemoteSNCopyFinishedNoticeAsyn(false, true, iCount);
                    }
                }
                if (this._IsAutoCopy)
                {
                    //此时没有执行完成
                    Thread.Sleep(JPSConfig.DelayerRemoteSNCopySleep);
                }
            }
        }
        private void RemoteSNCopyFinishedNoticeAsyn(bool blStop, bool blSucessfully, int iCount)
        {
            RemoteSNCopyFinishedCallBack call = new RemoteSNCopyFinishedCallBack(CallRemoteSNCopyFinishedNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { blStop, blSucessfully, iCount });
            }
            catch(Exception ex)
            {
                
            }
        }
        private void CallRemoteSNCopyFinishedNotice(bool blStop, bool blSucessfully, int iCount)
        {
            if (this.RemoteSNCopyFinishedNotice != null)
                this.RemoteSNCopyFinishedNotice(blStop, blSucessfully, iCount);
        }
        private bool Copying(out int iCount)
        {
            iCount = 0;
            DataTable dt;
            try
            {
                dt = this._SqlCmd.GetDateTable(string.Format("SELECT top 500 SN,Times,ID FROM SN where ID>{0} order by ID ASC", this._StartID));
            }
            catch(Exception ex)
            {
                this._ErrMsg = string.Format("GetData.ERR:{0}({1})", ex.Message, ex.Source);
                this.ShowErrAsyn(_ErrMsg);
                return false;
            }
            iCount = dt.Rows.Count;
            this.ShowLogAsyn(string.Format("从远程设备获取了{0}行数据。", iCount));
            if (iCount == 0) return true;
            List<string> listSql = new List<string>();
            foreach(DataRow dr in dt.Rows)
            {
                listSql.Add(string.Format("INSERT INTO SN1(SN,Times,MacNo,LocalID) VALUES('{0}','{1}',{2},{3})"
                    , dr["SN"].ToString(), dr["Times"].ToString().Length == 0 ? "2000-01-01" : dr["Times"].ToString(), this._MacNo, dr["ID"].ToString()));
            }
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(listSql);
            }
            catch (Exception ex)
            {
                this._ErrMsg = string.Format("DoSql.ERR:{0}({1})", ex.Message, ex.Source);
                this.ShowErrAsyn(_ErrMsg);
                return false;
            }
            this._StartID = long.Parse(dt.Rows[dt.Rows.Count - 1]["ID"].ToString());
            this.ShowLogAsyn("已将远程设备数据存入本地，当前最大ID为：" + this._StartID.ToString() + "。");
            return true;
        }
        public System.Windows.Forms.Form MyForm = null;
        Thread _thread = null;
        public bool Running = false;
        public bool StartListenning(long lStartID,out string sErr)
        {
            if (this.Running)
            {
                sErr = "远程数据复制控制器已经开启，请勿重复打开。";
                return false;
            }
            this._StartID = lStartID;
            this.ShowLogAsyn(string.Format("开始启动从远程设备复制数据，起始ID:{0}。", this._StartID));
            this.Running = true;
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(Copy));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("远程数据复制控制器已经启动时出错：{0}({1})", ex.Message, ex.Source);
                this.Running = false;
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool StopListenning(out string sErr)
        {
            sErr = string.Empty;
            this.Running = false;
            return true;
        }
        #region 消息
        /// <summary>
        /// 异步消息显示
        /// </summary>
        /// <param name="sMsg">消息内容</param>
        public void ShowErrAsyn(string sMsg)
        {
            ShowLogAsyn("Error:" + sMsg);
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
            frmSNCopyLog.ShowMyLog(sMsg);
        }
        #endregion
    }
    public class SNClear
    {
        /// <summary>
        /// 当前检查出系统数据量在MaxData以上时提醒客户要清理数据了
        /// </summary>
        public static int MaxData = 1000000;
        /// <summary>
        /// 获取当前系统中数据
        /// </summary>
        /// <returns></returns>
        public static int GetSN1Data(string sEndTime)
        {
            DataTable dt;
            string strSql;
            if(sEndTime.Length>0)
            {
                strSql = string.Format("SELECT COUNT(*) FROM SN1 where Times<'{0}'", sEndTime);
            }
            else
            {
                strSql = "SELECT COUNT(*) FROM SN1";
            }
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch(Exception EX)
            {
                throw (EX);
            }
            if (dt.Rows[0][0].Equals(DBNull.Value)) return 0;
            else return int.Parse(dt.Rows[0][0].ToString());
        }
        public static int GetSNData(string sEndTime)
        {
            DataTable dt;
            string strSql;
            if (sEndTime.Length > 0)
            {
                strSql = string.Format("SELECT COUNT(*) FROM SN where Times<'{0}'", sEndTime);
            }
            else
            {
                strSql = "SELECT COUNT(*) FROM SN";
            }
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception EX)
            {
                throw (EX);
            }
            if (dt.Rows[0][0].Equals(DBNull.Value)) return 0;
            else return int.Parse(dt.Rows[0][0].ToString());
        }
        public static int GetSentTuoPan(string sEndTime)
        {
            DataTable dt;
            string strSql;
            if (sEndTime.Length > 0)
            {
                strSql = string.Format("SELECT COUNT(*) FROM LuoLiuAssignerSendMes.DBO.SendMes_FinishedTuoPan where  SentMesTime IS NOT NULL AND SentMesTime<'{0}'", sEndTime);
            }
            else
            {
                strSql = "SELECT COUNT(*) FROM LuoLiuAssignerSendMes.DBO.SendMes_FinishedTuoPan";
            }
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception EX)
            {
                throw (EX);
            }
            if (dt.Rows[0][0].Equals(DBNull.Value)) return 0;
            else return int.Parse(dt.Rows[0][0].ToString());
        }
        public static int GetMesData(string sEndTime)
        {
            DataTable dt;
            string strSql;
            if (sEndTime.Length > 0)
            {
                strSql = string.Format("SELECT COUNT(*) FROM IFDB.dbo.FST_PACK where ISNULL(STATE,'')<>'D' and Input_Time<'{0}'", sEndTime);
            }
            else
            {
                strSql = "SELECT COUNT(*) FROM IFDB.dbo.FST_PACK";
            }
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception EX)
            {
                throw (EX);
            }
            if (dt.Rows[0][0].Equals(DBNull.Value)) return 0;
            else return int.Parse(dt.Rows[0][0].ToString());
        }
        public static bool GetDataCount(out bool blOver,out int iCount,out string sErr)
        {
            iCount = 0;
            sErr = "";
            try
            {
                iCount = SNClear.GetSN1Data(string.Empty);
                if(iCount>MaxData)
                {
                    blOver = true;
                    return true;
                }
                iCount = SNClear.GetSNData(string.Empty);
                if (iCount > MaxData)
                {
                    blOver = true;
                    return true;
                }
                //iCount = SNClear.GetMesData(string.Empty);
                //if (iCount > MaxData)
                //{
                //    blOver = true;
                //    return true;
                //}
                blOver = false;
                return true;
            }
            catch(Exception ex)
            {
                blOver = false;
                sErr = string.Format("读取总数据量出错：{0}({1})", ex.Message, ex.Source);
                return false;
            }
        }
        public static bool GetDataCount(string sEndTime,out int iCount, out string sErr)
        {

            iCount = 0;
            sErr = "";
            try
            {
                iCount += SNClear.GetSN1Data(sEndTime);

                iCount += SNClear.GetSNData(sEndTime);
                
                //iCount += SNClear.GetMesData(sEndTime);
                iCount += SNClear.GetSentTuoPan(sEndTime);

                return true;
            }
            catch (Exception ex)
            {
                sErr = string.Format("读取总量时出错：{0}({1})", ex.Message, ex.Source);
                return false;
            }
        }
        /***************
         * 当前需要清理的表有：
         * 1、SN1,
         * 2、SN
         * 3、SendMes_FinishedTuoPan
         * 4、FST_PACK
         * ***************/
        public event RemoteSNCopyFinishedCallBack RemoteSNCopyFinishedNotice = null;
        short _MacNo = 0;
        /// <summary>
        /// 是否是程序在后台自动执行的
        /// </summary>
        bool _IsAutoCopy = false;
        string EndTime = "2025-01-01";
        /// <summary>
        /// 错误消息
        /// </summary>
        public string _ErrMsg = string.Empty;
        public SNClear(System.Windows.Forms.Form mainForm, short iMacNo, bool isAutoCopy)
        {
            this.MyForm = mainForm;
            this._MacNo = iMacNo;
            this._IsAutoCopy = isAutoCopy;
        }
        private void Clear()
        {
            int iCount;
            int iTotalCount;
            bool blResult;
            while (true)
            {
                if (!this.Running)
                {
                    this.ShowLogAsyn("当前退出执行,通过running退出。");
                    this.RemoteSNCopyFinishedNoticeAsyn(true, true, 0);
                    return;
                }
                iTotalCount = 0;
                blResult = this.Clearing_SN(out iCount);
                if (!blResult)
                {
                    this.RemoteSNCopyFinishedNoticeAsyn(true, false, iCount);
                    return;
                }
                else
                {
                    iTotalCount += iCount;
                    this.RemoteSNCopyFinishedNoticeAsyn(false, true, iCount);
                }
                blResult = this.Clearing_SN1(out iCount);
                if (!blResult)
                {
                    this.RemoteSNCopyFinishedNoticeAsyn(true, false, iCount);
                    return;
                }
                else
                {
                    iTotalCount += iCount;
                    this.RemoteSNCopyFinishedNoticeAsyn(false, true, iCount);
                }

                blResult = this.Clearing_Mes(out iCount);
                if (!blResult)
                {
                    this.RemoteSNCopyFinishedNoticeAsyn(true, false, iCount);
                    return;
                }
                else
                {
                    iTotalCount += iCount;
                    this.RemoteSNCopyFinishedNoticeAsyn(false, true, iCount);
                }

                blResult = this.Clearing_FinishedTuoPan(out iCount);
                if (!blResult)
                {
                    this.RemoteSNCopyFinishedNoticeAsyn(true, false, iCount);
                    return;
                }
                else
                {
                    iTotalCount += iCount;
                    this.RemoteSNCopyFinishedNoticeAsyn(false, true, iCount);
                }
                if(iTotalCount==0)
                {
                    this.RemoteSNCopyFinishedNoticeAsyn(true, true, 0);
                    string strErr;
                    this.StopListenning(out strErr);
                }
                if (this._IsAutoCopy)
                {
                    //此时没有执行完成
                    Thread.Sleep(JPSConfig.DelayerRemoteSNCopySleep);
                }
            }
        }
        private void RemoteSNCopyFinishedNoticeAsyn(bool blStop, bool blSucessfully, int iCount)
        {
            RemoteSNCopyFinishedCallBack call = new RemoteSNCopyFinishedCallBack(CallRemoteSNCopyFinishedNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { blStop, blSucessfully, iCount });
            }
            catch (Exception ex)
            {

            }
        }
        private void CallRemoteSNCopyFinishedNotice(bool blStop, bool blSucessfully, int iCount)
        {
            if (this.RemoteSNCopyFinishedNotice != null)
                this.RemoteSNCopyFinishedNotice(blStop, blSucessfully, iCount);
        }
        private bool Clearing_SN(out int iCount)
        {
            try
            {
                iCount=Common.CommonDAL.DoSqlCommand.DoSql(string.Format("DELETE top(5000) FROM SN WHERE Times<'{0}'", this.EndTime));
            }
            catch (Exception ex)
            {
                iCount = 0;
                this._ErrMsg = string.Format("DELETE.SN.ERR:{0}({1})", ex.Message, ex.Source);
                this.ShowErrAsyn(_ErrMsg);
                return false;
            }
            this.ShowLogAsyn(string.Format("从SN表中删除了{0}行数据。", iCount));
            return true;
        }
        private bool Clearing_SN1(out int iCount)
        {
            try
            {
                iCount = Common.CommonDAL.DoSqlCommand.DoSql(string.Format("DELETE top(5000) FROM SN1 WHERE Times<'{0}'", this.EndTime));
            }
            catch (Exception ex)
            {
                iCount = 0;
                this._ErrMsg = string.Format("delete.sn1.ERR:{0}({1})", ex.Message, ex.Source);
                this.ShowErrAsyn(_ErrMsg);
                return false;
            }
            this.ShowLogAsyn(string.Format("从SN1表中删除了{0}行数据。", iCount));
            return true;
        }
        private bool Clearing_Mes(out int iCount)
        {
            try
            {
                iCount = Common.CommonDAL.DoSqlCommand.DoSql(string.Format("DELETE top(5000) FROM IFDB.DBO.FST_PACK WHERE ISNULL(STATE,'')<>'D' AND Input_Time<'{0}'", this.EndTime));
            }
            catch (Exception ex)
            {
                iCount = 0;
                this._ErrMsg = string.Format("delete.sn1.ERR:{0}({1})", ex.Message, ex.Source);
                this.ShowErrAsyn(_ErrMsg);
                return false;
            }
            this.ShowLogAsyn(string.Format("从FST_PACK表中删除了{0}行数据。", iCount));
            return true;
        }
        private bool Clearing_FinishedTuoPan(out int iCount)
        {
            try
            {
                iCount = Common.CommonDAL.DoSqlCommand.DoSql(string.Format("DELETE top(5000) FROM LuoLiuAssignerSendMes.DBO.SendMes_FinishedTuoPan WHERE SentMesTime IS NOT NULL AND SentMesTime<'{0}'", this.EndTime));
            }
            catch (Exception ex)
            {
                iCount = 0;
                this._ErrMsg = string.Format("delete.FinishedTuoPan.ERR:{0}({1})", ex.Message, ex.Source);
                this.ShowErrAsyn(_ErrMsg);
                return false;
            }
            this.ShowLogAsyn(string.Format("从FinishedTuoPan表中删除了{0}行数据。", iCount));
            return true;
        }
        public System.Windows.Forms.Form MyForm = null;
        Thread _thread = null;
        public bool Running = false;
        public bool StartListenning(string sEndTime, out string sErr)
        {
            if (this.Running)
            {
                sErr = "清除电芯数据工具已经打开，请勿重复打开。";
                return false;
            }
            this.EndTime = sEndTime;
            this.ShowLogAsyn(string.Format("开始启动清除电芯数据，最大时间为:{0}。", sEndTime));
            this.Running = true;
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(Clear));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("清除电芯数据启动时出错：{0}({1})", ex.Message, ex.Source);
                this.Running = false;
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool StopListenning(out string sErr)
        {
            sErr = string.Empty;
            this.Running = false;
            return true;
        }
        #region 消息
        /// <summary>
        /// 异步消息显示
        /// </summary>
        /// <param name="sMsg">消息内容</param>
        public void ShowErrAsyn(string sMsg)
        {
            ShowLogAsyn("Error:" + sMsg);
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
            frmSNCopyLog.ShowMyLog(sMsg);
        }
        #endregion
    }
    public class MyPing
    {
        public event MyPingFinishedCallBack MyPingFinishedNotice = null;
        string _IP1 = string.Empty;
        string _IP2 = string.Empty;
        string _IP3 = string.Empty;
        public MyPing(System.Windows.Forms.Form mainForm, string sIP1,string sIP2,string sIP3)
        {
            this.MyForm = mainForm;
            this._IP1 = sIP1;
            this._IP2 = sIP2;
            this._IP3 = sIP3;
        }
        private void Copy()
        {
            Copying();
            this.Running = false;
        }
        private void Copying()
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            if (this._IP1.Length > 0)
            {
                System.Net.NetworkInformation.PingReply result = p.Send(this._IP1);
                this.MyPingFinishedNoticeAsyn(1, result.Status == System.Net.NetworkInformation.IPStatus.Success);
            }
            if (this._IP2.Length > 0)
            {
                System.Net.NetworkInformation.PingReply result = p.Send(this._IP2);
                this.MyPingFinishedNoticeAsyn(2, result.Status == System.Net.NetworkInformation.IPStatus.Success);
            }
            if (this._IP3.Length > 0)
            {
                System.Net.NetworkInformation.PingReply result = p.Send(this._IP3);
                this.MyPingFinishedNoticeAsyn(3, result.Status == System.Net.NetworkInformation.IPStatus.Success);
            }
        }
        private void MyPingFinishedNoticeAsyn(short iIndex, bool blSucessfully)
        {
            MyPingFinishedCallBack call = new MyPingFinishedCallBack(CallPingFinishedNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { iIndex, blSucessfully });
            }
            catch (Exception ex)
            {

            }
        }
        private void CallPingFinishedNotice(short iIndex, bool blSucessfully)
        {
            if (this.MyPingFinishedNotice != null)
                this.MyPingFinishedNotice(iIndex, blSucessfully);
        }
        
        public System.Windows.Forms.Form MyForm = null;
        Thread _thread = null;
        public bool Running = false;
        public bool StartListenning(out string sErr)
        {
            if (this.Running)
            {
                sErr = "远程设备Ping工具已经开启，请勿重复打开。";
                return false;
            }
            this.Running = true;
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(Copy));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("远程设备Ping工具启动时出错：{0}({1})", ex.Message, ex.Source);
                this.Running = false;
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool StopListenning(out string sErr)
        {
            sErr = string.Empty;
            this.Running = false;
            return true;
        }
    }

    #endregion
    #region 导出CSV
    public class MyCsvWriter
    {
        public static bool GetDataCount(out int iCount, out string sErr)
        {
            iCount = 0;
            sErr = "";
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT COUNT(*) FROM IFDB.DBO.FST_PACK");
            }
            catch (Exception ex)
            {
                sErr = string.Format("读取总量时出错：{0}({1})", ex.Message, ex.Source);
                return false;
            }

            if (dt.Rows[0][0].Equals(DBNull.Value)) iCount = 0;
            else
            {
                iCount = int.Parse(dt.Rows[0][0].ToString());
            }
            return true;
        }
        public event RemoteSNCopyFinishedCallBack CsvSaveFinishedNotice = null;
        StreamWriter _StreamWriter = null;
        FileStream _FileStream = null;
        string _TargetFile = string.Empty;
        /// <summary>
        /// 起始ID
        /// </summary>
        long _StartID = 0;
        /// <summary>
        /// 错误消息
        /// </summary>
        public string _ErrMsg = string.Empty;

        public MyCsvWriter(System.Windows.Forms.Form mainForm)
        {
            this.MyForm = mainForm;
        }
        private void WriteControler()
        {
            this.Write();
            if(this._StreamWriter!=null)
            {
                try
                {
                    this._StreamWriter.Close();
                }
                catch(Exception ex)
                {
                    this.ShowErrAsyn("CloeStreamWriter.Err" + ex.Message);
                    return;
                }
            }
            if (this._FileStream != null)
            {
                try
                {
                    this._FileStream.Close();
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn("CloeFileStream.Err" + ex.Message);
                    return;
                }
            }
        }
        private void Write()
        {
            int iCount;
            bool blResult;
            try
            {
                _StreamWriter.Write("Order_No,SFC,SchemeName,StationNo,Volt_Value,IR_Value,Capacity_Value,Rank,RankBD,Result,State,Channel,TrayNo,BoxBarCode,IP_address,Material_OrderNo,MachineNo,Input_Time,Emp_Code,Reserved1,Reserved2,Reserved3\r\n");
            }
            catch (Exception ex)
            {
                //报错
                this._ErrMsg = "write.title.Err:" + ex.Message;
                this.RemoteSNCopyFinishedNoticeAsyn(true, true, 0);
                return;
            }
            while (true)
            {
                if (!this.Running)
                {
                    this.ShowLogAsyn("当前退出执行,通过running退出。");
                    this.RemoteSNCopyFinishedNoticeAsyn(true, true, 0);
                    return;
                }
                blResult = this.Writing(out iCount);
                if (!blResult)
                {
                    this.RemoteSNCopyFinishedNoticeAsyn(true, false, iCount);
                    return;
                }
                else
                {
                    if (iCount == 0)
                    {
                        this.ShowLogAsyn("当前退出执行,因为没有更新任何数据。");
                        //此时表示已经执行完了
                        this.RemoteSNCopyFinishedNoticeAsyn(true, true, 0);
                        this.Running = false;
                        return;
                    }
                    else
                    {
                        this.RemoteSNCopyFinishedNoticeAsyn(false, true, iCount);
                    }
                }
            }
        }
        private void RemoteSNCopyFinishedNoticeAsyn(bool blStop, bool blSucessfully, int iCount)
        {
            RemoteSNCopyFinishedCallBack call = new RemoteSNCopyFinishedCallBack(CallRemoteSNCopyFinishedNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { blStop, blSucessfully, iCount });
            }
            catch (Exception ex)
            {

            }
        }
        private void CallRemoteSNCopyFinishedNotice(bool blStop, bool blSucessfully, int iCount)
        {
            if (this.CsvSaveFinishedNotice != null)
                this.CsvSaveFinishedNotice(blStop, blSucessfully, iCount);
        }
        private bool Writing(out int iCount)
        {
            iCount = 0;
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT TOP 500 * FROM V_MesData WHERE RowIndex>={0} ORDER BY RowIndex ASC", this._StartID));
            }
            catch (Exception ex)
            {
                this._ErrMsg = string.Format("GetData.ERR:{0}({1})", ex.Message, ex.Source);
                this.ShowErrAsyn(_ErrMsg);
                return false;
            }
            iCount = dt.Rows.Count;
            this.ShowLogAsyn(string.Format("从mes表中获取了{0}行数据。", iCount));
            if (iCount == 0) return true;
            List<string> listSql = new List<string>();
            
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    _StreamWriter.Write(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}\r\n"
                    , GetValue(dr["Order_No"]), GetValue(dr["SFC"]), GetValue(dr["SchemeName"]), GetValue(dr["StationNo"]), GetValue(dr["Volt_Value"]),
                    GetValue(dr["IR_Value"]), GetValue(dr["Capacity_Value"]), GetValue(dr["Rank"]), GetValue(dr["RankBD"]), GetValue(dr["Result"]),
                    GetValue(dr["State"]), GetValue(dr["Channel"]), GetValue(dr["TrayNo"]), GetValue(dr["BoxBarCode"]), GetValue(dr["IP_address"]),
                    GetValue(dr["Material_OrderNo"]), GetValue(dr["MachineNo"]), GetValue(dr["Input_Time"]), GetValue(dr["Emp_Code"]), GetValue(dr["Reserved1"]),
                    GetValue(dr["Reserved2"]), GetValue(dr["Reserved3"])));
                }
                catch (Exception ex)
                {
                    this._ErrMsg = string.Format("DoSql.ERR:{0}({1})", ex.Message, ex.Source);
                    this.ShowErrAsyn(_ErrMsg);
                    return false;
                }
            }
            this._StartID += dt.Rows.Count;
            this.ShowLogAsyn("当前导出起始行号更新为：" + this._StartID.ToString() + "。");
            return true;
        }
        private string GetValue(object objValue)
        {
            if (objValue == null ||　objValue.Equals(DBNull.Value)) return "NULL";
            return objValue.ToString();
        }
        public System.Windows.Forms.Form MyForm = null;
        Thread _thread = null;
        public bool Running = false;
        public bool StartListenning(string sTargetFile,out string sErr)
        {
            if (this.Running)
            {
                sErr = "远程数据复制控制器已经开启，请勿重复打开。";
                return false;
            }
            try
            {
                _FileStream = new FileStream(sTargetFile, FileMode.Create);
                _StreamWriter = new StreamWriter(_FileStream, Encoding.GetEncoding("GB2312"));
            }
            catch(Exception ex)
            {
                sErr = string.Format("CreateText.Err:{0}({1})", ex.Message, ex.Source);
                return false;
            }
            this._TargetFile = sTargetFile;
            this._StartID = 1;
            //初始化写入对象
            this.Running = true;
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(WriteControler));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("远程数据复制控制器已经启动时出错：{0}({1})", ex.Message, ex.Source);
                this.Running = false;
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool StopListenning(out string sErr)
        {
            sErr = string.Empty;
            this.Running = false;
            return true;
        }
        #region 消息
        /// <summary>
        /// 异步消息显示
        /// </summary>
        /// <param name="sMsg">消息内容</param>
        public void ShowErrAsyn(string sMsg)
        {
            ShowLogAsyn("Error:" + sMsg);
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
            frmSNCopyLog.ShowMyLog(sMsg);
        }
        #endregion
    }
    public class MyCsvWriter_TestReuslt
    {
        public static bool GetDataCount(string sBatTable, string sResultTable, out int iCount, out string sErr)
        {
            iCount = 0;
            sErr = "";
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT COUNT(*) FROM {0} where isnull(TuoCode,'')<>''"
                    , sResultTable));
            }
            catch (Exception ex)
            {
                sErr = string.Format("读取总量时出错：{0}({1})", ex.Message, ex.Source);
                return false;
            }

            if (dt.Rows[0][0].Equals(DBNull.Value)) iCount = 0;
            else
            {
                iCount = int.Parse(dt.Rows[0][0].ToString());
            }
            return true;
        }
        public event RemoteSNCopyFinishedCallBack CsvSaveFinishedNotice = null;
        StreamWriter _StreamWriter = null;
        FileStream _FileStream = null;
        string _TargetFile = string.Empty;
        string _BatTableName = string.Empty;
        string _ResultTableName = string.Empty;
        /// <summary>
        /// 起始ID
        /// </summary>
        long _StartID = 0;
        /// <summary>
        /// 错误消息
        /// </summary>
        public string _ErrMsg = string.Empty;

        public MyCsvWriter_TestReuslt(System.Windows.Forms.Form mainForm, string sBatTable, string sResultTable)
        {
            this.MyForm = mainForm;
            this._BatTableName = sBatTable;
            this._ResultTableName = sResultTable;
        }
        private void WriteControler()
        {
            this.Write();
            if (this._StreamWriter != null)
            {
                try
                {
                    this._StreamWriter.Close();
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn("CloeStreamWriter.Err" + ex.Message);
                    return;
                }
            }
            if (this._FileStream != null)
            {
                try
                {
                    this._FileStream.Close();
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn("CloeFileStream.Err" + ex.Message);
                    return;
                }
            }
        }
        private void Write()
        {
            int iCount;
            bool blResult;
            try
            {
                _StreamWriter.Write("分选批次号,槽号,托盘号,电芯编码,电阻(mΩ),电压(V),入槽时间\r\n");
            }
            catch (Exception ex)
            {
                //报错
                this._ErrMsg = "write.title.Err:" + ex.Message;
                this.RemoteSNCopyFinishedNoticeAsyn(true, true, 0);
                return;
            }
            while (true)
            {
                if (!this.Running)
                {
                    this.ShowLogAsyn("当前退出执行,通过running退出。");
                    this.RemoteSNCopyFinishedNoticeAsyn(true, true, 0);
                    return;
                }
                blResult = this.Writing(out iCount);
                if (!blResult)
                {
                    this.RemoteSNCopyFinishedNoticeAsyn(true, false, iCount);
                    return;
                }
                else
                {
                    if (iCount == 0)
                    {
                        this.ShowLogAsyn("当前退出执行,因为没有更新任何数据。");
                        //此时表示已经执行完了
                        this.RemoteSNCopyFinishedNoticeAsyn(true, true, 0);
                        this.Running = false;
                        return;
                    }
                    else
                    {
                        this.RemoteSNCopyFinishedNoticeAsyn(false, true, iCount);
                    }
                }
            }
        }
        private void RemoteSNCopyFinishedNoticeAsyn(bool blStop, bool blSucessfully, int iCount)
        {
            RemoteSNCopyFinishedCallBack call = new RemoteSNCopyFinishedCallBack(CallRemoteSNCopyFinishedNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { blStop, blSucessfully, iCount });
            }
            catch (Exception ex)
            {

            }
        }
        private void CallRemoteSNCopyFinishedNotice(bool blStop, bool blSucessfully, int iCount)
        {
            if (this.CsvSaveFinishedNotice != null)
                this.CsvSaveFinishedNotice(blStop, blSucessfully, iCount);
        }
        private bool Writing(out int iCount)
        {
            iCount = 0;
            DataTable dt;
            try
            {
                //dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT TOP 200 * FROM V_MesData WHERE RowIndex>={0} ORDER BY RowIndex ASC", this._StartID));

                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format(@"SELECT Top 500 Code,GrooveNo,TuoCode,SN,DianZu,V,CONVERT(NVARCHAR(20),Times,120) as Times FROM (
                SELECT C.Code,C.GrooveNo,A.TuoCode,B.SN,A.DianZu,A.V,A.Times,ROW_NUMBER() over(order by a.TuoCode,a.times asc) AS RowIndex
                FROM {0} A LEFT JOIN {1} B ON B.Code=A.MyCode
                LEFT JOIN Testing_Grooves C ON C.ID=A.GrooveID
                WHERE ISNULL(A.TuoCode,'')<>'') AS T WHERE RowIndex>={2}", this._ResultTableName, this._BatTableName, this._StartID));
            }
            catch (Exception ex)
            {
                this._ErrMsg = string.Format("GetData.ERR:{0}({1})", ex.Message, ex.Source);
                this.ShowErrAsyn(_ErrMsg);
                return false;
            }
            iCount = dt.Rows.Count;
            this.ShowLogAsyn(string.Format("从mes表中获取了{0}行数据。", iCount));
            if (iCount == 0) return true;
            List<string> listSql = new List<string>();

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    _StreamWriter.Write(string.Format("{0},{1},{2},{3},{4},{5},{6}\r\n"
                    , GetValue(dr["Code"]), GetValue(dr["GrooveNo"]), GetValue1(dr["TuoCode"]), GetValue(dr["SN"]), GetValue(dr["DianZu"]),
                    GetValue(dr["V"]), GetValue(dr["Times"])));
                }
                catch (Exception ex)
                {
                    this._ErrMsg = string.Format("DoSql.ERR:{0}({1})", ex.Message, ex.Source);
                    this.ShowErrAsyn(_ErrMsg);
                    return false;
                }
            }
            this._StartID += dt.Rows.Count;
            this.ShowLogAsyn("当前导出起始行号更新为：" + this._StartID.ToString() + "。");
            return true;
        }
        private string GetValue(object objValue)
        {
            if (objValue == null || objValue.Equals(DBNull.Value)) return "NULL";
            return objValue.ToString();
        }
        private string GetValue1(object objValue)
        {
            if (objValue == null || objValue.Equals(DBNull.Value)) return "NULL";
            return "'" + objValue.ToString();
        }
        public System.Windows.Forms.Form MyForm = null;
        Thread _thread = null;
        public bool Running = false;
        public bool StartListenning(string sTargetFile, out string sErr)
        {
            if (this.Running)
            {
                sErr = "远程数据复制控制器已经开启，请勿重复打开。";
                return false;
            }
            try
            {
                _FileStream = new FileStream(sTargetFile, FileMode.Create);
                _StreamWriter = new StreamWriter(_FileStream, Encoding.GetEncoding("GB2312"));
            }
            catch (Exception ex)
            {
                sErr = string.Format("CreateText.Err:{0}({1})", ex.Message, ex.Source);
                return false;
            }
            this._TargetFile = sTargetFile;
            this._StartID = 1;
            //初始化写入对象
            this.Running = true;
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(WriteControler));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("远程数据复制控制器已经启动时出错：{0}({1})", ex.Message, ex.Source);
                this.Running = false;
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool StopListenning(out string sErr)
        {
            sErr = string.Empty;
            this.Running = false;
            return true;
        }
        #region 消息
        /// <summary>
        /// 异步消息显示
        /// </summary>
        /// <param name="sMsg">消息内容</param>
        public void ShowErrAsyn(string sMsg)
        {
            ShowLogAsyn("Error:" + sMsg);
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
            frmSNCopyLog.ShowMyLog(sMsg);
        }
        #endregion
    }
    #endregion
    #region 打印监控
    public class PrinterControl
    {
        public event PrinterControlerPrintTypeChangedCallBack PrinterControlerPrintTypeChangedNotice = null;
        public PrinterControl(frmMain1 form)
        {
            this.MyForm = form;
            _RequestEntitys = new PrintRequestEntity[10];
            for (short i = 1; i <= 10; i++)
            {
                _RequestEntitys[i-1] = new PrintRequestEntity(i);
            }
            _MKRequestEntity = new PrintRequestEntity(-1);
            //初始化打印输出
            this._Printer = new MyPrinter();
            this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
            
        }

        private void _Printer_PrintFinishedNotice(short iIndex, string sTuoPanCode, bool blSucessful, string sErr)
        {
            if(!blSucessful)
            {
                this.ShowErrAsyn(string.Format("打印槽{0}的托盘号\"{1}\"时出错：{2}", iIndex, sTuoPanCode, sErr));
            }
            else
            {
                this.ShowLogAsyn(string.Format("已成功打印槽{0}的托盘号\"{1}\"", iIndex, sTuoPanCode));
            }
        }
        public frmMain1 MyForm = null;
        public JpsOPC.OPCHelperPrinter _OPCHelperPrinter = null;
        
        Thread _thread = null;
        public bool Running = false;
        /// <summary>
        /// 暂停中
        /// </summary>
        public bool Pausing = false;
        public bool StartListenning(out string sErr)
        {
            if (this.Running)
            {
                sErr = "测试结果的监听已经开启，请勿重复打开。";
                return false;
            }
            if (this.Pausing)
                this.Pausing = false;
            if (this._OPCHelperPrinter == null)
            {
                this._OPCHelperPrinter = new JpsOPC.OPCHelperPrinter();
                this._OPCHelperPrinter.IsDebug = Debug.ScannerOpc.IsDebug;
                this._OPCHelperPrinter.LogNotice += _OPCHelperPrinter_LogNotice;
            }
            if (!this._OPCHelperPrinter.InitServer(out sErr)) return false;
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(Listen));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("打印监听启动时出错：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            sErr = string.Empty;
            return true;
        }

        private void _OPCHelperPrinter_LogNotice(string sMsg)
        {
            //显示来自JPSOPC的日志
            this.ShowLogAsyn(sMsg);
        }

        public void StopListenning()
        {
            this.Running = false;
            if(this._RequestEntitys!=null)
            {
                foreach(PrintRequestEntity entity in this._RequestEntitys)
                {
                    if (entity != null)
                        entity.InitData();
                }
            }
        }
        public AutoAssign.MyPrinter _Printer = null;
        PrintRequestEntity[] _RequestEntitys;
        PrintRequestEntity _MKRequestEntity = null;//模块打印需求
        public PrintTypes _PrintType = PrintTypes.None;

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
                    this.ShowLogAsyn("打印监听终止（running is false）。");
                    break;
                }
                if(this.Pausing)
                {
                    Thread.Sleep(800);//休眠一下
                    continue;
                }
                Thread.Sleep(500);//休眠一下
                if(!AutoAssign.MyPrinter.AutoPrint)
                {
                    //此时不要自动打印，所以不用监听了
                    Thread.Sleep(3000);//休眠一下
                    continue;
                }
                //检查是否有打印需求，如果为指定是模块还是托盘，则都去查找需求。但一般是要制定的。
                if(this._PrintType ==PrintTypes.ALL || this._PrintType==PrintTypes.MKCode)
                {
                    if (_MKRequestEntity != null)
                    {
                        if (!this._MKRequestEntity.Printing)
                        {
                            this.ShowLogAsyn("模块无打印请求。");
                        }
                        else
                        {
                            this.ShowLogAsyn("收到模块打印请求。");
                            this.Printing(this._MKRequestEntity);
                        }
                    }
                }
                if (this._PrintType == PrintTypes.ALL || this._PrintType == PrintTypes.TuoPanCode)
                {
                    //打印机1检查是否要打印
                    foreach (PrintRequestEntity entity in this._RequestEntitys)
                    {
                        if (entity == null)
                        {
                            this.ShowLogAsyn(string.Format("打印机控制对象内部槽地址为空。"));
                            continue;
                        }
                        if (!entity.Printing)
                        {
                            this.ShowLogAsyn(string.Format("槽{0}无打印请求。", entity.Index));
                        }
                        else
                        {
                            this.ShowLogAsyn(string.Format("打印机控制收到槽{0}请求打印，需检查托盘是否已经拉出。", entity.Index));
                            this.Printing(entity);
                        }
                    }
                }
            }
        }
        private void Printing(PrintRequestEntity entity)
        {
            //判断是否槽中托盘已经抽出来了
            if(_OPCHelperPrinter==null)
            {
                this.ShowErrAsyn("负责打印的OPC对象为空！");
                return;
            }
            if(this._Printer==null)
            {
                this.ShowErrAsyn("打印机输出对象为空！");
                return;
            }
            bool blPrint;
            if (entity.Index == -1)
                blPrint = true;
            else
            {
                string sErr;
                if (!_OPCHelperPrinter.IsPrintingNow(entity.Index, out blPrint, out sErr))
                {
                    this.ShowErrAsyn(string.Format("读取打印OPC_{0}状态值时出错：{1}", entity.Index, sErr));
                    return;
                }
            }
            //此时状态值读取正确
            if(blPrint)
            {
                if (entity.Index > -1)
                    this.ShowLogAsyn(string.Format("检查到槽{0}托盘已经被拉出。", entity.Index));
                else
                    this.ShowLogAsyn("开始打印模块编号:" + entity.PrintCode);
                if (entity.PrintCode.Length==0)
                {
                    this.ShowErrAsyn(string.Format("槽{0}的打印请求的托盘编号为空。", entity.Index));
                    //不要退出，继续打印出来
                }
                this.ShowLogAsyn(string.Format("立即执行槽{0}托盘号打印。", entity.Index));
                //调用打印
                int iPrintCnt = 0;
                if (this.MyForm != null)
                    iPrintCnt = this.MyForm._PrintCunt;
                if (iPrintCnt <= 0) iPrintCnt = 1;
                this.ShowLogAsyn(string.Format("槽{0}，托盘{1}打印{2}张标签。", entity.Index, entity.PrintCode, iPrintCnt));
                for (int i = 0; i < iPrintCnt; i++)
                {
                    if (!this._Printer.Printing(entity.PrintCode, entity.Index))
                    {
                        //此时打印成功了
                        entity.Counter++;
                        if (entity.Counter < 3)
                        {
                            this.ShowLogAsyn(string.Format("托盘\"{0}\"打印失败了{1}次。", entity.PrintCode, entity.Counter));
                            return;
                        }
                        this.ShowLogAsyn(string.Format("托盘\"{0}\"打印失败了{1}次，当前不再继续打印该托盘号。", entity.PrintCode, entity.Counter));
                    }
                }
                this.ShowLogAsyn(string.Format("槽{0}，托盘{1}打印完毕后撤销打印状态。", entity.Index, entity.PrintCode));
                entity.InitData();//此时表示打印结束
            }
            else
            {
                this.ShowLogAsyn(string.Format("打印OPC_{0}状态为不打印", entity.Index));
            }
        }
        #region 公共函数
        public bool RequestMKPrint(string sMKCode)
        {
            this.ShowLogAsyn(string.Format("收到模块打印请求：模块号：{0}", sMKCode));
            if (!MyPrinter.AutoPrint)
            {
                this.ShowLogAsyn("因当前非自动打印模式，不启动打印。");
                return true;
            }
            if (this._MKRequestEntity == null)
            {
                _MKRequestEntity = new PrintRequestEntity(-1);
            }
            
            this._MKRequestEntity.PrintCode = sMKCode;
            this._MKRequestEntity.Printing = true;
            this.ShowLogAsyn("模块打印请求已接收。");
            if (!this.Running)
            {
                this.ShowLogAsyn("打印机控制对象Starting。");
                string sErr;
                if (!this.StartListenning(out sErr))
                {
                    this.ShowErrAsyn(sErr);
                    return false;
                }
            }
            else
            {
                this.ShowLogAsyn("打印机控制对象Runing中，请等待。");
            }
            return true;
        }
        public bool RequestPrint(short iIndex, string sTuoPanCode)
        {
            this.ShowLogAsyn(string.Format("收到打印请求：槽{0}、托盘号：{1}", iIndex, sTuoPanCode));
            if (!MyPrinter.AutoPrint)
            {
                this.ShowLogAsyn("因当前非自动打印模式，不启动打印。");
                return true;
            }
            if (this._RequestEntitys == null)
            {
                this.ShowErrAsyn("Request Entitys还未初始化！");
                return false;
            }
            if (this._RequestEntitys.Length != 10)
            {
                this.ShowErrAsyn("Request Entitys初始化不正确！");
                return false;
            }
            if (iIndex < 1 || iIndex > 10)
            {
                this.ShowErrAsyn("请求打印的槽只能是1~10的，当前为" + iIndex.ToString());
                return false;
            }
            this._RequestEntitys[iIndex - 1].PrintCode = sTuoPanCode;
            this._RequestEntitys[iIndex - 1].Printing = true;
            this.ShowLogAsyn("打印请求已接收。");
            if (!this.Running)
            {
                this.ShowLogAsyn("打印机控制对象Starting。");
                string sErr;
                if (!this.StartListenning(out sErr))
                {
                    this.ShowErrAsyn(sErr);
                    return false;
                }
            }
            else
            {
                this.ShowLogAsyn("打印机控制对象Runing中，请等待。");
            }
            return true;
        }
        /// <summary>
        /// 判断是否有打印请求
        /// </summary>
        /// <returns></returns>
        public short RequestCount()
        {
            if (this._RequestEntitys == null) return 0;
            short iCount = 0;
            foreach(PrintRequestEntity entity in _RequestEntitys)
            {
                if (entity != null && entity.Printing)
                    iCount++;
            }
            return iCount;
        }
        public void SetPrintType(PrintTypes type)
        {
            if (this._PrintType != type)
            {
                PrintTypes oldType = this._PrintType;
                this._PrintType = type;
                //注意：changed的意思是已经改变了，所以这里要放在this._PrintType = type;后调用委托
                this.CallPrinterControlerPrintTypeChangedAsyn(oldType, type);
            }
        }
        public void PauseListening(bool blPausing)
        {
            this.Pausing = blPausing;
        }
        #endregion
        #region 异步调用
        private void CallPrinterControlerPrintTypeChangedAsyn(PrinterControl.PrintTypes oldType, PrinterControl.PrintTypes newType)
        {
            PrinterControlerPrintTypeChangedCallBack cb = new PrinterControlerPrintTypeChangedCallBack(CallPrinterControlerPrintTypeChanged);
            try
            {
                this.MyForm.Invoke(cb, new object[2] { oldType, newType });
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void CallPrinterControlerPrintTypeChanged(PrinterControl.PrintTypes oldType, PrinterControl.PrintTypes newType)
        {
            if (this.PrinterControlerPrintTypeChangedNotice != null)
                this.PrinterControlerPrintTypeChangedNotice(oldType, newType);
        }
        #endregion
        #region 消息
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
            //if (this.IsFormForOperatorOpend)
            //    this.MsgFormForOperator_AddMsg(sMsg, true);
            //else
            //{
            //    this.MyForm.ShowErr(sMsg);
            //}
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
            frmPrinterLog.ShowMyLog(sMsg);
        }
        #endregion
        public class PrintRequestEntity
        {
            /// <summary>
            /// 用于计数，不能每次失败就重新打印，超过一定次数就不要打印了。
            /// </summary>
            public int Counter = 0;
            public PrintRequestEntity(short iIndex)
            {
                this.Index = iIndex;
            }
            public short Index = 0;
            public bool Printing = false;
            public string PrintCode = string.Empty;
            public void SetValue(bool blPrintNow,string sPrintCode)
            {
                if (this.Printing != blPrintNow)
                    this.Printing = blPrintNow;
                if (this.PrintCode != sPrintCode)
                    this.PrintCode = sPrintCode;
            }
            public void InitData()
            {
                if (this.Printing)
                    this.Printing = false;
                if (this.PrintCode.Length > 0)
                    this.PrintCode = string.Empty;
                if (this.Counter > 0)
                    this.Counter = 0;
            }
        }
        public enum PrintTypes
        {
            /// <summary>
            /// 未定义过
            /// </summary>
            None=0,
            /// <summary>
            /// 打印托盘编号
            /// </summary>
            TuoPanCode=1,
            /// <summary>
            /// 打印模块编号
            /// </summary>
            MKCode=2,
            /// <summary>
            /// 模块和托盘号都打印
            /// </summary>
            ALL=3
        }
    }
    #endregion
    #region 组装模块
    public class MKBuilding
    {
        public event RefreshMKCodeCallBack RefreshMKCodeNoitce = null;
        public string _TestCode
        {
            get
            {
                if (this.MyForm == null) return string.Empty;
                return this.MyForm._TestCode;
            }
        }
        public JpsOPC.OPCHelperMKBuilding _OPCHelperMKBuilding = null;
        public frmMain1 MyForm = null;
        public bool Interrupt = false;
        Thread _thread = null;
        public bool Running = false;
        /// <summary>
        /// 暂停中
        /// </summary>
        public bool Pausing = false;
        MKBuildingSteps _Step = MKBuildingSteps.ReadOPC_BatCode;
        public PrinterControl _Printer = null;
        public MKBuilding(frmMain1 form, JpsOPC.OPCHelperMKBuilding opc, PrinterControl printer)
        {
            this.MyForm = form;
            this._OPCHelperMKBuilding = opc;
            this._Printer = printer;
        }
        public bool StartListenning(out string sErr)
        {
            if (this.Running)
            {
                sErr = "自动插装控制器的已经开启，请勿重复打开。";
                return false;
            }
            if (this.Pausing)
                this.Pausing = false;
            if (!this.InitData(out sErr)) return false;
            this.Running = true;
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(Listen));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("自动插装控制器启动时出错：{0}({1})", ex.Message, ex.Source);
                this.Running = false;
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        private bool InitData(out string sErr)
        {
            sErr = string.Empty;
            _MyCodes = new string[20];
            for(int i=0;i<14;i++)
            {
                _MyCodes[i] = string.Empty;
            }
            this._ReadBatCodes = string.Empty;
            this._ReadFinished = 0;
            this._ResetFinished = false;
            this._PlanCompeleted = false;
            return true;
        }
        public void PauseListening(bool blPausing)
        {
            this.Pausing = blPausing;
        }
        public bool StopListenning(out string sErr)
        {
            sErr = string.Empty;
            this.Running = false;
            return true;
        }
        private bool Listen_IsNewBatCode;
        private string Listen_ErrMsg = string.Empty;
        private void Listen()
        {
            while (true)
            {
                if (!this.Running)
                {
                    this.ShowLogAsyn("自动插装已强制停止。");
                    break;
                }
                if(this.Pausing)
                {
                    Thread.Sleep(800);
                    this.ShowLogAsyn("程序暂停中...");
                    continue;
                }
                if(this.IsShowLog && this.IsShowLog_ReadAll)
                {
                    this.ShowLogAsyn("执行命令：" + this.GetStepName(this._Step));
                }
                Thread.Sleep(JPSConfig.MKBuildingSleeep);
                if (MKBuildingSteps.ReadOPC_BatCode == this._Step)
                {
                    //此时为从OPC中去读取电芯编号
                    if (this.OPC_ReadBatCodes(out Listen_IsNewBatCode))
                    {
                        this.SetInterrupt(false);
                        if (Listen_IsNewBatCode)
                        {
                            //此时有新的电芯写入了，则读取是否结束的标识
                            this._Step = MKBuildingSteps.ReadOPC_Finished;
                        }
                        else
                        {
                            //此时没有电芯写入，则休眠一下，把CPU让给人家使用
                            Thread.Sleep(JPSConfig.MKBuildingSleeep_NoneBatCode);
                        }
                    }
                }
                if (MKBuildingSteps.ReadOPC_Finished == this._Step)
                {
                    //读取OPC的是否完成标识，这个决定了存储电芯编号时的后台操作，很重要
                    if (this.OPC_ReadFinished())
                    {
                        this.SetInterrupt(false);
                        //读取成功了，则读取是否结束的标识
                        this._Step = MKBuildingSteps.SaveDianxins;
                    }
                }
                if (MKBuildingSteps.SaveDianxins == this._Step)
                {
                    //保存电芯数据
                    if (this.DB_SaveDianXin())
                    {
                        this.SetInterrupt(false);
                        this._Step = MKBuildingSteps.WriteOPC_ClearBatCode;
                    }
                }
                if (MKBuildingSteps.WriteOPC_ClearBatCode == this._Step)
                {
                    //清空OPC中的电芯编号，以此通知PLC上位机已经读取到了
                    if (this.OPC_ClearBatCodes())
                    {
                        this.SetInterrupt(false);
                        //执行成功了，则向OPC写入模块编码，注意：不一定会有模块编号，但这个有功能函数自己控制了，线程按照步骤走下去
                        this._Step = MKBuildingSteps.WriteOPC_MKCode;
                    }
                }
                if (MKBuildingSteps.WriteOPC_MKCode == this._Step)
                {
                    //向OPC写入模块编码
                    if (this.OPC_WriteMKCode())
                    {
                        this.SetInterrupt(false);
                        //执行成功了或者说不用写，则处理Asb_Finished字段，当然和处理Asb_Code一样，可能不需要
                        this._Step = MKBuildingSteps.WriteOPC_ResetFinished;
                    }
                }
                if (MKBuildingSteps.WriteOPC_ResetFinished == this._Step)
                {
                    //处理Asb_Finished字段
                    if (this.OPC_ResetFinished())
                    {
                        this.SetInterrupt(false);
                        //执行成功了或者说不用写，则继续读取电芯编号
                        this._Step = MKBuildingSteps.ReadOPC_BatCode;
                    }
                }
            }
        }
        #region 功能函数
        string _ReadBatCodes = string.Empty;//记录下读取到的电芯编号
        private bool OPC_ReadBatCodes(out bool newBatCode)
        {
            newBatCode = false;
            if(this._OPCHelperMKBuilding==null)
            {
                this.ShowErrAsyn("电芯编号读取失败，OpcHelper对象为空！");
                return false;
            }
            string strCode;
            if(!this._OPCHelperMKBuilding.ReadBatCodes(out strCode,out Listen_ErrMsg))
            {
                this.ShowErrAsyn(string.Format("电芯编号读取出错：{0}", Listen_ErrMsg));
                return false;
            }
            if(strCode.Length==0)
            {
                //此时没有电芯编号
                newBatCode = false;
                if (_ReadBatCodes.Length > 0)
                {
                    if (this.IsShowLog)
                    {
                        this.ShowLogAsyn("无电芯序列号被读取到，清空之前的记录：" + _ReadBatCodes);
                    }
                    _ReadBatCodes = string.Empty;
                }
                else
                {
                    if (this.IsShowLog && this.IsShowLog_ReadAll)
                    {
                        this.ShowLogAsyn("未读取到电芯序列号。");
                    }
                }
            }
            else
            {
                //此时有编号，则要判断是否是之前读取到过的，因为OPC是有延时的，虽然上位机清空了，但要过几毫秒或者几百毫秒才能在OPC中清空
                if(this._ReadBatCodes!=strCode)
                {
                    if (!strCode.StartsWith("#"))
                    {
                        this.ShowErrAsyn(string.Format("插装完的电芯序列号必须以#开头，详细电芯序列号内容:{0}"
                    , strCode));
                        return false;
                    }
                    if (!strCode.EndsWith("#"))
                    {
                        this.ShowErrAsyn(string.Format("插装完的电芯序列号必须以#结尾，详细电芯序列号内容:{0}"
                    , strCode));
                        return false;
                    }
                    newBatCode = true;
                    this._ReadBatCodes = strCode;
                    if(this.IsShowLog)
                    {
                        this.ShowLogAsyn(string.Format("读取到新的电芯序列号："+ strCode));
                    }
                }
                else
                {
                    if (this.IsShowLog && this.IsShowLog_ReadAll)
                    {
                        this.ShowLogAsyn("连续读取到电芯序列号：" + strCode);
                    }
                }
            }
            return true;
        }
        short _ReadFinished = 0;
        private bool OPC_ReadFinished()
        {
            if (this._OPCHelperMKBuilding == null)
            {
                this.ShowErrAsyn("插装完成标识读取失败，OpcHelper对象为空！");
                return false;
            }
            short iValue;
            if (!this._OPCHelperMKBuilding.ReadFinished(out iValue, out Listen_ErrMsg))
            {
                this.ShowErrAsyn(string.Format("插装完成标识读取出错：{0}", Listen_ErrMsg));
                return false;
            }
            if (iValue != this._ReadFinished)
            {
                if (this.IsShowLog)
                {
                    this.ShowLogAsyn(string.Format("读取到新的插装状态[{0}]，原状态[{1}]", iValue, this._ReadFinished));
                }
                this._ReadFinished = iValue;
                
            }
            else
            {
                if (this.IsShowLog && this.IsShowLog_ReadAll)
                {
                    this.ShowLogAsyn("连续读取到插装状态[" + iValue.ToString() + "]");
                }
            }
            return true;
        }
        string[] _MyCodes;
        int DB_SaveDianXin_ReturnValue;
        string DB_SaveDianXin_Errmsg;
        private bool DB_SaveDianXin()
        {
            bool blFinished = this._ReadFinished == 1;
            //存储电芯数据
            if (_ReadBatCodes.Length == 0)
            {
                return true;
            }
            if (!this._ReadBatCodes.StartsWith("#"))
            {
                this.ShowErrAsyn(string.Format("插装完的电芯序列号必须以#开头，详细电芯序列号内容:{0}"
            , this._ReadBatCodes));
                this._Step = MKBuildingSteps.ReadOPC_BatCode;//不设置这个的话，一直会提示这个错误，因为this._ReadBatCodes没有机会改变楼。
                return false;
            }
            if (!this._ReadBatCodes.EndsWith("#"))
            {
                this.ShowErrAsyn(string.Format("插装完的电芯序列号必须以#结尾，详细电芯序列号内容:{0}"
            , this._ReadBatCodes));
                this._Step = MKBuildingSteps.ReadOPC_BatCode;//不设置这个的话，一直会提示这个错误，因为this._ReadBatCodes没有机会改变楼。
                return false;
            }
            //if (this._ReadBatCodes.Length != 126)
            //{
            //    this.ShowErrAsyn(string.Format("插装完的电芯编号总长度必须是126位，当前为{0}位，详细内容:{1}"
            //        , this._ReadBatCodes.Length, this._ReadBatCodes));
            //    this._Step = MKBuildingSteps.ReadOPC_BatCode;//不设置这个的话，一直会提示这个错误，因为this._ReadBatCodes没有机会改变楼。
            //    return false;
            //}
            if (this.IsShowLog)
            {
                this.ShowLogAsyn("存储电芯数据:" + this._ReadBatCodes);
            }
            int i = 0;
            string strCode = this._ReadBatCodes.Substring(1, this._ReadBatCodes.Length - 2);//去除前后2个#
            for (;i<20;i++)
            {
                if (strCode.Length <= i * 9)
                {
                    if (this.IsShowLog)
                    {
                        this.ShowLogAsyn(string.Format("读取了{0}个电芯序列号。", i));
                    }
                    break;
                }
                //赋值
                this._MyCodes[i] = strCode.Substring(9 * i , 9);
            }
            for(;i<20;i++)
            {
                //设定为空
                this._MyCodes[i] = string.Empty;
            }
            string sMkCode;
            short iAsbCnt;
            bool blPlanComepleted;
            short iMKFinishedCnt;
            try
            {
                this.MyForm.BllDAL.Assemble_SaveDianXin(this._TestCode, JPSConfig.MacNo, blFinished, false, this._MyCodes, out sMkCode,out iAsbCnt,out blPlanComepleted,out iMKFinishedCnt, out DB_SaveDianXin_ReturnValue, out DB_SaveDianXin_Errmsg);
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(string.Format("存储电芯时出错：{0}({1})[电芯编号：{2}]", ex.Message, ex.Source, this._ReadBatCodes));
                return false;
            }
            if(DB_SaveDianXin_ReturnValue!=1)
            {
                if (DB_SaveDianXin_Errmsg.Length == 0)
                    DB_SaveDianXin_Errmsg = "存储电芯失败，原因未知！";
                this.ShowErrAsyn(DB_SaveDianXin_Errmsg);
                return false;
            }
            if (this.IsShowLog)
            {
                this.ShowLogAsyn("存储电芯完毕，当前模块编号:" + sMkCode);
                if(blPlanComepleted)
                {
                    this.ShowLogAsyn("模块计划数量已经完成！！！！");
                }
                else
                {
                    this.ShowLogAsyn("模块计划数量未到达，继续作业。");
                }
            }
            //注意这里要确定_ResetFinished和_MKCode，因为这涉及到这两个字段是否要写入OPC，目前的设想如下
            if (blFinished)
            {
                if (this._PlanCompeleted != blPlanComepleted)
                    this._PlanCompeleted = blPlanComepleted;
                if (!this._ResetFinished)
                    this._ResetFinished = true;
                if(sMkCode.Length==0)
                {
                    this.ShowErrAsyn("插装已完成，但模块编号获取失败！");
                    return false;
                }
                //_MKCode则从数据库中返回
                this._MKCode = sMkCode;
            }
            else
            {
                //此时表示未完成组装
                if (this._ResetFinished)
                    this._ResetFinished = false;
                if (this._MKCode.Length > 0)
                    this._MKCode = string.Empty;
            }
            //刷新主界面
            this.CallRefreshMKCodeAsyn(sMkCode, iAsbCnt, blFinished, iMKFinishedCnt);
            return true;
        }
        private bool OPC_ClearBatCodes()
        {
            if (this._OPCHelperMKBuilding == null)
            {
                this.ShowErrAsyn("清空电芯编号失败，OpcHelper对象为空！");
                return false;
            }
            if (!this._OPCHelperMKBuilding.ClearBatCodes(out Listen_ErrMsg))
            {
                this.ShowErrAsyn(string.Format("清空电芯编号时出错：{0}", Listen_ErrMsg));
                return false;
            }
            if (this.IsShowLog)
            {
                this.ShowLogAsyn("PLC电芯序号清除成功！" + Listen_ErrMsg);
            }
            return true;
        }
        string _MKCode = string.Empty;//模块编号
        private bool OPC_WriteMKCode()
        {
            if (_MKCode.Length == 0) return true;//此时不用写
            if (this._OPCHelperMKBuilding == null)
            {
                this.ShowErrAsyn("向PLC写入模块编号失败，OpcHelper对象为空！");
                return false;
            }
            if(this._Printer==null)
            {
                this.ShowErrAsyn("打印控制对象为空！");
            }
            else
            {
                if (this.IsShowLog)
                {
                    this.ShowLogAsyn("向打印控制对象发送模块[" + this._MKCode + "]打印的请求！");
                }
                this._Printer.RequestMKPrint(this._MKCode);
            }
            if (!this._OPCHelperMKBuilding.SetMkCode(_MKCode, out Listen_ErrMsg))
            {
                this.ShowErrAsyn(string.Format("向PLC写入模块编号时出错：{0}", Listen_ErrMsg));
                return false;
            }
            if (this.IsShowLog)
            {
                this.ShowLogAsyn("成功向PLC写入模块编号[" + _MKCode + "]！");
            }
            return true;
        }
        bool _ResetFinished = false;//复位标识
        bool _PlanCompeleted = false;//标识是否计划完成了
        private bool OPC_ResetFinished()
        {
            if (!_ResetFinished) return true;
            if (this._OPCHelperMKBuilding == null)
            {
                this.ShowErrAsyn("复位插装完成标识失败，OpcHelper对象为空！");
                return false;
            }
            if (this._PlanCompeleted)
            {
                if (!this._OPCHelperMKBuilding.PlanCompleted(out Listen_ErrMsg))
                {
                    this.ShowErrAsyn(string.Format("通知PLC模块计划数量完成时出错：{0}", Listen_ErrMsg));
                    return false;
                }
                if (this.IsShowLog)
                {
                    this.ShowLogAsyn("成功通知PLC计划数量已经完成！");
                }
            }
            else
            {
                if (!this._OPCHelperMKBuilding.ResetFinished(out Listen_ErrMsg))
                {
                    this.ShowErrAsyn(string.Format("复位插装完成标识时出错：{0}", Listen_ErrMsg));
                    return false;
                }
                if (this.IsShowLog)
                {
                    this.ShowLogAsyn("成功复位PLC的插装完成状态！");
                }
            }
            return true;
        }
        #endregion
        #region 信息回调
        private void CallRefreshMKCodeAsyn(string sMkCode, short iAsbCnt, bool blFinished, short iMKFinishedCnt)
        {
            RefreshMKCodeCallBack cb = new RefreshMKCodeCallBack(CallRefreshMKCode);
            try
            {
                this.MyForm.Invoke(cb, new object[4] { sMkCode, iAsbCnt, blFinished, iMKFinishedCnt });
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void CallRefreshMKCode(string sMkCode, short iAsbCnt, bool blFinished, short iMKFinishedCnt)
        {
            if(this.RefreshMKCodeNoitce!=null)
            {
                this.RefreshMKCodeNoitce(sMkCode,iAsbCnt, blFinished,iMKFinishedCnt);
            }
        }
        #endregion
        #region 消息
        public bool IsShowLog = false;
        public bool IsShowLog_ReadAll = false;
        /// <summary>
        /// 异步消息显示
        /// </summary>
        /// <param name="sMsg">消息内容</param>
        public void ShowErrAsyn(string sMsg)
        {
            this.SetInterrupt(true);
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
            APLog.frmMKBuildingLog.ShowMyLog(sMsg);
        }
        private string GetStepName(MKBuildingSteps step)
        {
            if (step == MKBuildingSteps.ReadOPC_BatCode) return "读取PLC电芯序列号";
            if (step == MKBuildingSteps.ReadOPC_Finished) return "读取PLC电芯插装完成状态";
            if (step == MKBuildingSteps.SaveDianxins) return "存储电芯序列号";
            if (step == MKBuildingSteps.WriteOPC_ClearBatCode) return "清除PLC电芯序列号";
            if (step == MKBuildingSteps.WriteOPC_MKCode) return "向PLC写入模块编号";
            if (step == MKBuildingSteps.WriteOPC_ResetFinished) return "重置PLC的电芯插装完成状态";
            return "unkown";
        }
        private void SetInterrupt(bool blInterrupt)
        {
            if (this.Interrupt != blInterrupt)
                this.Interrupt = blInterrupt;
        }
        #endregion
        #region 相关枚举
        private enum MKBuildingSteps
        {
            /// <summary>
            /// 读取OPC的电芯编号，该值是由PLC写入的
            /// </summary>
            ReadOPC_BatCode = 0,
            /// <summary>
            /// 读取是否已经完成了的标识
            /// </summary>
            ReadOPC_Finished = 1,
            /// <summary>
            /// 向OPC写入模块编号
            /// </summary>
            WriteOPC_MKCode = 2,
            /// <summary>
            /// 清空OPC的电芯编号信息
            /// </summary>
            WriteOPC_ClearBatCode = 3,
            /// <summary>
            /// 对OPC字段Asb_Finished设置为2，作用是通知PLC，上位机已经处理完了
            /// </summary>
            WriteOPC_ResetFinished = 4,
            /// <summary>
            /// 保存电芯明细
            /// </summary>
            SaveDianxins = 5
        }
        #endregion
    }
    #endregion
    #region 首检线程
    public class SJListen
    {
        public event SJResultCompeletedCallBack SJResultCompeletedNotice = null;
        public event SJCompeletedCallBack SJCompeletedNotice = null;
        public event ShowMsgAsynCallBack ShowLogNotice = null;
        public event ShowMsgAsynCallBack ShowErrNotice = null;
        public JpsOPC.OPCHelperNanJingZhongBi _OPCHelper = null;
        public NanJingZB.frmSj MyForm = null;
        public bool Interrupt = false;
        Thread _thread = null;
        public bool Running = false;
        public SJListenSteps _Steps = SJListenSteps.None;
        NanJingZB_SJRVRange _NanJingZB_SJRVRange = null;
        public SJListen(NanJingZB.frmSj mform)
        {
            this.MyForm = mform;
        }
        public bool StartListenning(NanJingZB_SJRVRange setData,out string sErr)
        {
            if (this.Running)
            {
                sErr = "线程已经开启，请勿重复打开。";
                return false;
            }
            if (setData == null)
            {
                sErr = "传入的设置对象为空！";
                return false;
            }
            //初始化对象
            if (_OPCHelper==null)
            {
                this._OPCHelper = new JpsOPC.OPCHelperNanJingZhongBi();
                try
                {
                    if(!this._OPCHelper.InitServer(out sErr))
                    {
                        _OPCHelper = null;
                        return false;
                    }
                }
                catch(Exception ex)
                {
                    sErr = $"初始化OPC出错：{ex.Message}({ex.Source})。";
                    return false;
                }
            }
            this._NanJingZB_SJRVRange = setData;
            this._Steps = SJListenSteps.Setting;//首先进入后直接设置参数
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(Listen));
            _thread.IsBackground = true;
            try
            {
                _thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("首检控制线程启动时出错：{0}({1})", ex.Message, ex.Source);
                this.Running = false;
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        private void Listen()
        {
            this.Running = true;
            Listeniing();
            this.Running = false;
        }
        private void Listeniing()
        {
            while (true)
            {
                if (!this.Running)
                {
                    this.ShowLogAsyn("自动插装已强制停止。");
                    break;
                }
                this.Doing();
                Thread.Sleep(1000);
            }
        }
        private void Doing()
        {
            if (this._Steps == SJListenSteps.Setting)
            {
                //设置信息
                string sErr;
                try
                {
                    this._OPCHelper.WriteSjRange(this._NanJingZB_SJRVRange, out sErr, false);
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn($"写入OPC出错：{ex.Message}({ex.Source})");
                    return;
                }
                Thread.Sleep(1000);//等待一秒，因为这个oPC组扫描率比较低
                this._Steps = SJListenSteps.Start;
            }
            if (this._Steps == SJListenSteps.Start)
            {
                //通知下位机可以开始检测了
                string sErr;
                try
                {
                    if(!this._OPCHelper.SetWorkState(1, out sErr))
                    {
                        this.ShowErrAsyn($"通知下位机开始检测时写入OPC出错：{sErr}");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn($"通知下位机开始检测时写入OPC出错：{ex.Message}({ex.Source})");
                    return;
                }
                this._Steps = SJListenSteps.Waitting;
                Thread.Sleep(2000);
            }
            if (this._Steps == SJListenSteps.Waitting)
            {
                //等待下位机，判断是否已经写入了
                string sErr;
                short iValue;
                try
                {
                    if (!this._OPCHelper.ReadWrkState(out iValue, out sErr))
                    {
                        this.ShowErrAsyn($"读取下位机状态出错：{sErr}");
                        return;
                    }
                    if(iValue==2)
                    {
                        //此时已经检测完了。则开始读取结果
                        this._Steps = SJListenSteps.Reading;
                        Thread.Sleep(1000);
                    }
                    this.ShowLogAsyn($"设备检测进度值:{iValue}，继续等待。");
                    Thread.Sleep(1000);
                    return;
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn($"读取下位机状态出错：{ex.Message}({ex.Source})");
                    return;
                }
            }
            if (this._Steps == SJListenSteps.Reading)
            {
                //读取结果值
                string sErr;
                NanJingZB_SJResult result = new NanJingZB_SJResult();
                try
                {
                    if (!this._OPCHelper.ReadResult(ref result, out sErr))
                    {
                        this.ShowErrAsyn($"读取下位机首检结果出错：{sErr}");
                        return;
                    }
                    if (result == null)
                    {
                        ; this.ShowErrAsyn($"读取下位机首检结果出错：result值为NULL！");
                        return;
                    }
                    if (!result.IsOK())
                    {
                        ; this.ShowLog($"下位机返回的结果有-1，继续等待。");
                        return;
                    }
                    this.ShowLogAsyn($"数据读取成功。");
                    //通知主界面显示数据
                    this.CallSJResultCompeletedAsyn(result);
                    this._Steps = SJListenSteps.Restet;
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn($"读取下位机首检结果出错：{ex.Message}({ex.Source})");
                    return;
                }
            }
            if (this._Steps == SJListenSteps.Restet)
            {
                //复位
                string sErr;
                try
                {
                    if (!this._OPCHelper.SetWorkState(0, out sErr))
                    {
                        this.ShowErrAsyn($"复位下位机状态时写入OPC出错：{sErr}");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn($"复位下位机状态时写入OPC出错：{ex.Message}({ex.Source})");
                    return;
                }
                //将结果值设置为-1
                try
                {
                    if (!this._OPCHelper.ResetResult(false, out sErr))
                    {
                        this.ShowErrAsyn($"复位下位机结果值时写入OPC出错：{sErr}");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.ShowErrAsyn($"复位下位机结果值时写入OPC出错：{ex.Message}({ex.Source})");
                    return;
                }
                this.StopListenning();
                this._Steps = SJListenSteps.None;
                //此时完成了，则通知主界面
                this.CallSJCompeletedAsyn();
            }
        }
        public void StopListenning()
        {
            this.Running = false;
        }
        #region 消息
        
        /// <summary>
        /// 异步消息显示
        /// </summary>
        /// <param name="sMsg">消息内容</param>
        public void ShowErrAsyn(string sMsg)
        {
            this.SetInterrupt(true);
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
            if (this.ShowErrNotice != null)
                this.ShowErrNotice(sMsg);
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
            if (this.ShowLogNotice != null)
                this.ShowLogNotice(sMsg);
        }
        private void CallSJResultCompeletedAsyn(NanJingZB_SJResult result)
        {
            SJResultCompeletedCallBack cb = new SJResultCompeletedCallBack(CallSJResultCompeleted);
            try
            {
                this.MyForm.Invoke(cb, new object[1] { result });
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void CallSJResultCompeleted(NanJingZB_SJResult result)
        {
            if (this.SJResultCompeletedNotice != null)
                this.SJResultCompeletedNotice(result);
        }
        private void CallSJCompeletedAsyn()
        {
            SJCompeletedCallBack cb = new SJCompeletedCallBack(CallSJCompeleted);
            try
            {
                this.MyForm.Invoke(cb);
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void CallSJCompeleted()
        {
            if (this.SJCompeletedNotice != null)
                this.SJCompeletedNotice();
        }
        private void SetInterrupt(bool blInterrupt)
        {
            if (this.Interrupt != blInterrupt)
                this.Interrupt = blInterrupt;
        }
        #endregion
        #region 相关类及枚举
        public enum SJListenSteps
        {
            None=0,
            Setting=1,
            Start=2,
            Waitting=3,
            Reading=4,
            Restet=5
        }
        public delegate void SJResultCompeletedCallBack(NanJingZB_SJResult result);
        public delegate void SJCompeletedCallBack();
        #endregion
    }
    #endregion
    public delegate void ShowMsgAsynCallBack(string sMsg);
    public delegate void SocketClientReceveCallBack(List<string> listSn);
    public delegate void SocketClientReceveOrginalDataCallBack(string sData);
    public delegate void SocketClientAnalyzeDataCallBack(ScannerDianXinData[] codeEntitys, int iValue);
    public delegate void ResultControlerSavedSucessfulCallBack(short iCaoIndex, long lGrooveID, string sTuoPanCode);
    public delegate void GrooveStatisticSucessfulCallBack(List<GrooveData> changedGroove, int iAddBtyCount, int iAddTuoCount);
    public delegate void StatisticNGRateFinisehdCallback(bool NGRateIsSucessful, decimal decNGRate, bool isCheckerMBatchNum, decimal decMBatchYcRate);
    public delegate void StatisticUnQualityRateFinisehdCallback( bool blUnQualitySucessful, decimal decUnQRate);
    public delegate void RefreshSendMesCallback(bool blSucessful, int iCount);
    public delegate void SocketClientRefreshStatusCallBack(JPSEnum.ScannerTextStates state);
    public delegate void ResultControlerTuoPanBtyErrorCallback(List<GrooveData> grooves);
    public delegate void SysNewReadCompeletedCallBack(bool blSucessful, string sErrMsg);
    public delegate void TuopanPlanProgressCallBack(bool blCompeleted, int iPlanFinishedCnt);
    public delegate void RealDataShowCallBack(ResultData data1, ResultData data2, ResultData data3, ResultData data4, ResultData data5, ResultData data6, ResultData data7, ResultData data8, ResultData data9, ResultData data10, ResultData data11, ResultData data12, ResultData data13, ResultData data14, ResultData data15, ResultData data16, ResultData data17, ResultData data18, ResultData data19, ResultData data20);
    public delegate void RemoteSNCopyFinishedCallBack(bool blStop, bool blSucessfully, int iCount);
    public delegate void MyPingFinishedCallBack(short iIndex,bool blSucessfully);
    public delegate void SNClearDataIsOverCallBack(bool blOver, int iCount);
    public delegate void SnStatisticReadedCallBack(string iSnCnt, string decLpl, string decScannLpl, string decMBatchLpl, bool blSucessfully, string sErr);
    public delegate void RefreshMKCodeCallBack(string sMkCode,short iAsbCnt, bool blFinished,short iMKFinishedCnt);
    public delegate void PrinterControlerPrintTypeChangedCallBack(PrinterControl.PrintTypes oldType, PrinterControl.PrintTypes newType);
    public class MainControl
    {
        public event SysNewReadCompeletedCallBack SysNewReadCompeletedNotice = null;
        public event SysNewReadCompeletedCallBack SysPlanCompeetedNotice = null;
        frmMain1 MyForm = null;
        public MainControl(frmMain1 mainForm)
        {
            this.MyForm = mainForm;
        }
        #region 常量区域
        #endregion
        #region 关键对象
        public JpsOPC.OPCHelperBat _OPCHelperBat = null;
        public JpsOPC.OPCHelperResult _OPCHelperResult = null;
        public JpsOPC.OPCHelperGongYi _OPCHelperGongYi = null;
        public ScannControler _ScannControler = null;
        public ResultControler _ResultControler = null;
        public StatisticControler _StatisticControler = null;
        public PrinterControl _PrinterControl = null;
        /// <summary>
        /// 是否是激活状态，即各子对象初始化都正确
        /// </summary>
        public bool Actived = false;
        #endregion
        #region 消息
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
            frmScanner1Log.ShowMyLog(sMsg);
        }
        #endregion
        #region 公共函数
        public bool InitScannerPLCIOValue(out string sErr)
        {
            if (Debug.ScannerOpc.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            if (this._ScannControler._Scanner1 != null)
                this._ScannControler._Scanner1._isResetd = false;
            if (this._ScannControler._Scanner2 != null)
                this._ScannControler._Scanner2._isResetd = false;
            //给电池标识符赋个初始值，避免一开始就不停的读编号
            int iInit = 1;
            if (_OPCHelperBat == null)
            {
                sErr = "OPCHelperBat对象为空，无法初始化PLC中判定是否扫描的标识值.";
                return false;
            }
            if (_OPCHelperBat._BatBitValue1 == null)
            {
                sErr = "OPCHelper_BatBitValue1对象为空，无法初始化PLC中判定是否扫描的标识值.";
                return false;
            }
            else
            {
                if (!_OPCHelperBat._BatBitValue1.WriteData(iInit, out sErr))
                {
                    return false;
                }
            }
            //if (_OPCHelperBat._BatBitValue2 == null)
            //{
            //    sErr = "OPCHelper_BatBitValue1对象为空，无法初始化PLC中判定是否扫描的标识值.";
            //    return false;
            //}
            //else
            //{
            //    if (!_OPCHelperBat._BatBitValue2.WriteData(iInit, out sErr))
            //    {
            //        return false;
            //    }
            //}
            return true;
        }
        public bool Init(out string sErr)
        {
            //先初始化OPC对象(该OPC负责写入电芯数据)
            if (this._OPCHelperBat == null)
                this._OPCHelperBat = new JpsOPC.OPCHelperBat();
            if (this._OPCHelperResult == null)
                this._OPCHelperResult = new JpsOPC.OPCHelperResult();
            if (JPSConfig.MacNo == 99)
                this._OPCHelperResult._IsMacNo4 = true;//标识是第4台设备
            if (this._OPCHelperGongYi == null)
                this._OPCHelperGongYi = new JpsOPC.OPCHelperGongYi();
            this._OPCHelperBat.IsDebug = Debug.ScannerOpc.IsDebug;
            this._OPCHelperResult.IsDebug = Debug.ScannerOpc.IsDebug;
            this._OPCHelperGongYi.IsDebug = Debug.ScannerOpc.IsDebug;
            if (!this._OPCHelperBat.InitServer(out sErr)) return false;
            if (!this._OPCHelperResult.InitServer(out sErr)) return false;
            if (!this._OPCHelperGongYi.InitServer(out sErr)) return false;
            if (_ScannControler == null)
                this._ScannControler = new ScannControler(this.MyForm, this._OPCHelperBat);
            if (!this._ScannControler.Init(out sErr)) return false;

            //打印控制对象
            if (_PrinterControl == null)
                _PrinterControl = new PrinterControl(this.MyForm);
            if (this._ResultControler == null)
            {
                this._ResultControler = new ResultControler(this.MyForm, this._OPCHelperResult, this._PrinterControl);
                this._ResultControler.GrooveStatisticSucessfulNotice += _ResultControler_GrooveStatisticSucessfulNotice;
                this._ResultControler.ResultControlerTuoPanBtyErrorNotice += _ResultControler_ResultControlerTuoPanBtyErrorNotice;
                this._ResultControler.TuopanPlanProgressNotice += _ResultControler_TuopanPlanProgressNotice;//引入模块后，托盘就不用显示了。addby jiangpengsong 2020-04-26
                this._ResultControler.RealDataShowNotice += _ResultControler_RealDataShowNotice;
            }
            if (this._StatisticControler == null)
            {
                this._StatisticControler = new StatisticControler(this.MyForm);
                this._StatisticControler.StatisticNGRateFinisehdNotice += _StatisticControler_StatisticNGRateFinisehdNotice;
                this._StatisticControler.StatisticUnQualityRateFinisehdNotice += _StatisticControler_StatisticUnQualityRateFinisehdNotice;
                this._StatisticControler.SnStatisticReadedNotice += _StatisticControler_SnStatisticReadedNotice;
            }
            this.Actived = true;
            return true;
        }

        private void _StatisticControler_SnStatisticReadedNotice(string iSnCnt, string decLpl, string decScannLpl, string decMBatchLpl, bool blSucessfully, string sErr)
        {
            if (this.MyForm == null) return;
            SnStatisticReadedCallBack call = new SnStatisticReadedCallBack(RefreshMainStatisticControler_SnStatisticReadedNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { iSnCnt, decLpl, decScannLpl, decMBatchLpl, blSucessfully, sErr });
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }

        private void _ResultControler_RealDataShowNotice(ResultData data1, ResultData data2, ResultData data3, ResultData data4, ResultData data5, ResultData data6, ResultData data7, ResultData data8, ResultData data9, ResultData data10, ResultData data11, ResultData data12, ResultData data13, ResultData data14, ResultData data15, ResultData data16, ResultData data17, ResultData data18, ResultData data19, ResultData data20)
        {
            RealDataShowCallBack call = new RealDataShowCallBack(RefreshMainRealDataShowNotice);
            try
            {
                this.MyForm.Invoke(call, new object[] { data1, data2, data3, data4, data5, data6, data7, data8, data9, data10, data11, data12, data13, data14, data15, data16, data17, data18, data19, data20 });
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }
        private void RefreshMainRealDataShowNotice(ResultData data1, ResultData data2, ResultData data3, ResultData data4, ResultData data5, ResultData data6, ResultData data7, ResultData data8, ResultData data9, ResultData data10, ResultData data11, ResultData data12, ResultData data13, ResultData data14, ResultData data15, ResultData data16, ResultData data17, ResultData data18, ResultData data19, ResultData data20)
        {
            this.MyForm.RefresRealDataShowNotice(data1, data2, data3, data4, data5, data6, data7, data8, data9, data10, data11, data12, data13, data14, data15, data16, data17, data18, data19, data20);
        }

        private void _ResultControler_TuopanPlanProgressNotice(bool blCompeleted, int iPlanFinishedCnt)
        {
            //托盘计划完成进度
            TuopanPlanProgressCallBack call = new TuopanPlanProgressCallBack(RefreshMainFormTuopanPlanProgress);
            try
            {
                this.MyForm.Invoke(call, new object[] { blCompeleted, iPlanFinishedCnt });
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }

        private void _ResultControler_ResultControlerTuoPanBtyErrorNotice(List<GrooveData> grooves)
        {
            
            ResultControlerTuoPanBtyErrorCallback call = new ResultControlerTuoPanBtyErrorCallback(RefreshMainFormTuoPanBtyCntErr);
            try
            {
                this.MyForm.Invoke(call, new object[] { grooves });
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn("Invoke.ResultControlerTuoPanBtyErrorCallback.Exception:" + ex.Message);
            }
        }

        private void _StatisticControler_StatisticUnQualityRateFinisehdNotice(bool blUnQualitySucessful, decimal decUnQRate)
        {
            if (this.MyForm == null) return;
            StatisticUnQualityRateFinisehdCallback call = new StatisticUnQualityRateFinisehdCallback(RefreshMainFormUnQualityRate);
            try
            {
                this.MyForm.Invoke(call, new object[] { blUnQualitySucessful, decUnQRate });
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn("Invoke.StatisticUnQualityRateFinisehdCallback.Exception:" + ex.Message);
            }
        }

        private void _StatisticControler_StatisticNGRateFinisehdNotice(bool NGRateIsSucessful, decimal decNGRate, bool isCheckerMBatchNum, decimal decMBatchYcRate)
        {
            if (this.MyForm == null) return;
            StatisticNGRateFinisehdCallback call = new StatisticNGRateFinisehdCallback(RefreshMainFormNGRate);
            try
            {
                this.MyForm.Invoke(call, new object[] { NGRateIsSucessful, decNGRate, isCheckerMBatchNum, decMBatchYcRate });
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn("Invoke.StatisticNGRateFinisehdCallback.Exception:" + ex.Message);
            }
        }
        #endregion
        #region 刷新测试结果信息
        private void _ResultControler_GrooveStatisticSucessfulNotice(List<GrooveData> changedGroove, int iAddBtyCount, int iAddTuoCount)
        {
            //刷新主界面的数据
            GrooveStatisticSucessfulCallBack call = new GrooveStatisticSucessfulCallBack(RefreshMainFormGroovesData);
            try
            {
                this.MyForm.Invoke(call, new object[] { changedGroove, iAddBtyCount, iAddTuoCount });
            }
            catch(Exception ex)
            {

            }
        }
        private void RefreshMainFormGroovesData(List<GrooveData> changedGroove, int iAddBtyCount, int iAddTuoCount)
        {
            this.MyForm.RefreshGroovesData(changedGroove, iAddBtyCount, iAddTuoCount);
        }
        private void RefreshMainFormNGRate(bool blNGRateIsSucessful, decimal decNGRate, bool isCheckerMBatchNum, decimal decMBatchYcRate)
        {
            this.MyForm.RefreshNGRate(blNGRateIsSucessful, decNGRate, isCheckerMBatchNum, decMBatchYcRate);
        }
        private void RefreshMainFormUnQualityRate(bool blUnQualitySucessful, decimal decUnQRate)
        {
            this.MyForm.RefreshUnQualityRate(blUnQualitySucessful, decUnQRate);
        }
        private void RefreshMainFormTuoPanBtyCntErr(List<GrooveData> grooves)
        {
            List<string> list = new List<string>();
            if (grooves != null)
            {
                foreach (GrooveData g in grooves)
                {
                    list.Add(g.TuoPanCode);
                }
            }
            this.MyForm.RefreshTuoPanBtyCntErr(list);
        }
        private void RefreshMainFormTuopanPlanProgress(bool blCompeleted, int iPlanFinishedCnt)
        {
            //通知主线程，当前计划完成情况
            this.MyForm.RefreshTuopanPlanProgress(blCompeleted, iPlanFinishedCnt);
        }
        #endregion
        #region 新建测试
        Thread SysNew_thread = null;
        public bool SysNew_Running = false;
        public bool StartSysNewListenning( out string sErr)
        {
            if (this.SysNew_Running)
            {
                sErr = "新建过程监控器已经打开，请勿重复打开。";
                return false;
            }
            SysNew_thread = new System.Threading.Thread(new System.Threading.ThreadStart(SysNew_Listen));
            SysNew_thread.IsBackground = true;
            try
            {
                SysNew_thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("新建过程监控器启动出错：{0}({1})", ex.Message, ex.Source);
                this.SysNew_Running = false;
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool StopSysNewListenning(out string sErr)
        {
            sErr = string.Empty;
            this.SysNew_Running = false;
            return true;
        }
        short SysNew_Listen_Value;
        string SysNew_Listen_Err;
        public void SysNew_Listen()
        {
            this.SysNew_Running = true;
            SysNew_Listening();
            this.SysNew_Running = false;
        }
        public void SysNew_Listening()
        {
            while (true)
            {
                if (!this.SysNew_Running)
                {
                    this.ShowLogAsyn("SysNew_Running is FALSE ,so Listen has been stoped。");
                    break;
                }
                Thread.Sleep(JPSConfig.DelayerMiilSecondsReadSysNew);
                if (!this._OPCHelperGongYi.ReadAt_SysNew(out SysNew_Listen_Value, out SysNew_Listen_Err))
                {
                    //此时读取失败，应该退出的
                    SysNewReadCompeletedNoticeAysn(false, SysNew_Listen_Err);
                    break;//退出循环
                }
                //此时读取成功了
                if(SysNew_Listen_Value==2)
                {
                    //此时已经新建成功了
                    SysNewReadCompeletedNoticeAysn(true, string.Empty);
                    break;
                }
                this.ShowLogAsyn("The tag names SysNew value is:" + SysNew_Listen_Value.ToString());
                //继续循环
            }
        }
        private void SysNewReadCompeletedNoticeAysn(bool blSucessful, string sErrMsg)
        {
            SysNewReadCompeletedCallBack call = new SysNewReadCompeletedCallBack(SysNewReadCompeletedNoticeMainForm);
            try
            {
                this.MyForm.Invoke(call, new object[] { blSucessful, sErrMsg });
            }
            catch(Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }
        private void SysNewReadCompeletedNoticeMainForm(bool blSucessful, string sErrMsg)
        {
            if (this.SysNewReadCompeletedNotice != null)
                this.SysNewReadCompeletedNotice(blSucessful, sErrMsg);
        }
        #endregion
        #region 通知PLC完成测试
        short SysCompeleted_Listen_Value;
        string SysCompeleted_Listen_Err;
        Thread SysCompeleted_thread = null;
        public bool SysCompeleted_Running = false;
        public bool StartSysCompeletedListenning(out string sErr)
        {
            if (this.SysCompeleted_Running)
            {
                sErr = "终止过程监控器已经打开，请勿重复打开。";
                return false;
            }
            //this.SysCompeleted_Running = true;
            SysCompeleted_thread = new System.Threading.Thread(new System.Threading.ThreadStart(SysCompeleted_Listen));
            SysCompeleted_thread.IsBackground = true;
            try
            {
                SysCompeleted_thread.Start();
            }
            catch (Exception ex)
            {
                sErr = string.Format("终止过程监控器启动出错：{0}({1})", ex.Message, ex.Source);
                this.SysCompeleted_Running = false;
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool StopSysCompeletedListenning(out string sErr)
        {
            sErr = string.Empty;
            this.SysCompeleted_Running = false;
            return true;
        }
        public void SysCompeleted_Listen()
        {
            this.SysCompeleted_Running = true;
            SysCompeleted_Listening();
            this.SysCompeleted_Running = false;
        }
        public void SysCompeleted_Listening()
        {
            while (true)
            {
                if (!this.SysCompeleted_Running)
                {
                    this.ShowLogAsyn("SysCompeleted_Running is FALSE ,so Listen has been stoped。");
                    break;
                }
                Thread.Sleep(JPSConfig.DelayerMiilSecondsReadSysCompeleted);
                if (!this._OPCHelperGongYi.ReadAt_SysCompeleted(out SysCompeleted_Listen_Value, out SysCompeleted_Listen_Err))
                {
                    //此时读取失败，应该退出的
                    SysCompeletedReadCompeletedNoticeAysn(false, SysCompeleted_Listen_Err);
                    break;//退出循环
                }
                //此时读取成功了
                if (SysCompeleted_Listen_Value == 2)
                {
                    //此时已经新建成功了
                    SysCompeletedReadCompeletedNoticeAysn(true, string.Empty);
                    break;
                }
                this.ShowLogAsyn("The tag names SysCompeleted value is:" + SysCompeleted_Listen_Value.ToString());
                //继续循环
            }
        }
        private void SysCompeletedReadCompeletedNoticeAysn(bool blSucessful, string sErrMsg)
        {
            SysNewReadCompeletedCallBack call = new SysNewReadCompeletedCallBack(SysCompeletedReadCompeletedNoticeMainForm);
            try
            {
                this.MyForm.Invoke(call, new object[] { blSucessful, sErrMsg });
            }
            catch (Exception ex)
            {
                this.ShowErrAsyn(ex.Message);
            }
        }
        private void SysCompeletedReadCompeletedNoticeMainForm(bool blSucessful, string sErrMsg)
        {
            if (this.SysPlanCompeetedNotice != null)
                this.SysPlanCompeetedNotice(blSucessful, sErrMsg);
        }
        #endregion
        #region 统计总芯数
        private void RefreshMainStatisticControler_SnStatisticReadedNotice(string iSnCnt, string decLpl, string decScannLpl, string decMBatchLpl, bool blSucessfully, string sErr)
        {
            if (this.MyForm != null)
                this.MyForm.RefreshSnStatistic(iSnCnt, decLpl, decScannLpl, decMBatchLpl, blSucessfully, sErr);
        }
        #endregion
    }
    public class Debug
    {
        public class ScannerOpc
        {
            public static bool IsDebug = true;
            public static bool Bat_Bool1 = false;
            public static bool Bat_Bool2 = false;
            public static short SysNew = 0;
            public static short BlockNo = 0;
        }
        public class PLCResultReader
        {
            public static bool IsDebug = true;
            /// <summary>
            /// 是否立即读取结果集
            /// </summary>
            public static bool IsReadNow = false;
            public static void Init()
            {
                PLCResultReader.Result1 = new PLCResultData();
                PLCResultReader.Result2 = new PLCResultData();
                PLCResultReader.Result3 = new PLCResultData();
                PLCResultReader.Result4 = new PLCResultData();
                PLCResultReader.Result5 = new PLCResultData();
                PLCResultReader.Result6 = new PLCResultData();
                PLCResultReader.Result7 = new PLCResultData();
                PLCResultReader.Result8 = new PLCResultData();
                PLCResultReader.Result9 = new PLCResultData();
                PLCResultReader.Result10 = new PLCResultData();
                PLCResultReader.Result11 = new PLCResultData();
                PLCResultReader.Result12 = new PLCResultData();
                PLCResultReader.Result13 = new PLCResultData();
                PLCResultReader.Result14 = new PLCResultData();
                PLCResultReader.Result15 = new PLCResultData();
                PLCResultReader.Result16 = new PLCResultData();
                PLCResultReader.Result17 = new PLCResultData();
                PLCResultReader.Result18 = new PLCResultData();
                PLCResultReader.Result19 = new PLCResultData();
                PLCResultReader.Result20 = new PLCResultData();
            }
            public static PLCResultData Result1 = null;
            public static PLCResultData Result2 = null;
            public static PLCResultData Result3 = null;
            public static PLCResultData Result4 = null;
            public static PLCResultData Result5 = null;
            public static PLCResultData Result6 = null;
            public static PLCResultData Result7 = null;
            public static PLCResultData Result8 = null;
            public static PLCResultData Result9 = null;
            public static PLCResultData Result10 = null;
            public static PLCResultData Result11 = null;
            public static PLCResultData Result12 = null;
            public static PLCResultData Result13 = null;
            public static PLCResultData Result14 = null;
            public static PLCResultData Result15 = null;
            public static PLCResultData Result16 = null;
            public static PLCResultData Result17 = null;
            public static PLCResultData Result18 = null;
            public static PLCResultData Result19 = null;
            public static PLCResultData Result20 = null;
            public static void DebugFunSetResult(Debug.PLCResultData debugResult, JpsOPC.MyItemValue itemCode, JpsOPC.MyItemValue itemV, 
                JpsOPC.MyItemValue itemDz, JpsOPC.MyItemValue itemCao, JpsOPC.MyItemValue itemNGCase)
            {
                if (debugResult == null) debugResult = new PLCResultData();
                itemCode.Value_String = debugResult.MyCode;
                itemV.Value_Decimal = debugResult.V;
                itemDz.Value_Decimal = debugResult.DianZu;
                itemCao.Value_Short = debugResult.CaoIndex;
                itemNGCase.Value_Short = debugResult.NGCase;
            }
        }
        public class PLCResultData
        {
            public string MyCode = "";
            public decimal V = 0M;
            public decimal DianZu = 0M;
            public short CaoIndex = 0;
            public short NGCase = 0;
        }

    }
}
