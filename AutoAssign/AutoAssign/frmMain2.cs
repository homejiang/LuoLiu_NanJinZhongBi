using AutoAssign.JPSEntity;
using AutoAssign.JPSEnum;
using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign
{
    public partial class frmMain1 : Common.frmBase
    {
        DataTable _RealDataTable1 = null;
        DataTable _RealDataTable2 = null;
        //DataTable _RealDataTable3 = null;
        //DataTable _RealDataTable4 = null;
        #region 常量
        const string StatisticControlInitText = "---";
        #endregion
        #region 窗体数据连接实例
        private BLLDAL.Testing _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Testing BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Testing();
                return _dal;
            }
        }
        #endregion 
        public frmMain1()
        {
            InitializeComponent();
            SetAutoMKOnOffFromStyle();//自动插装的默认显示方案
            tsbDataOver.Visible = false;
            this.dgvGroove.AutoGenerateColumns = false;
            this.tbMacCode.Text = JPSConfig.MacCode;
            this.tbOperatorName.Text = Common.CurrentUserInfo.UserName;
            this.ucSendMES.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            this.ucSendMES.SetMyText(StatisticControlInitText);
            //this.ucPrint.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            //this.ucPrint.SetMyText(StatisticControlInitText);
            this.Text = string.Format("电芯分选系统 Version:{0}", Version.GetVersion());
            #region 绑定测试数据
            this.dgvReal1.AutoGenerateColumns = false;
            this.dgvReal2.AutoGenerateColumns = false;
            //this.dgvReal3.AutoGenerateColumns = false;
            //this.dgvReal4.AutoGenerateColumns = false;
            _RealDataTable1 = new DataTable();
            _RealDataTable1.Columns.Add("Index",Type.GetType("System.Int16"));
            _RealDataTable1.Columns.Add("CaoIndex", Type.GetType("System.Int16"));
            _RealDataTable1.Columns.Add("DianZu", Type.GetType("System.Decimal"));
            _RealDataTable1.Columns.Add("V", Type.GetType("System.Decimal"));
            _RealDataTable1.Columns.Add("SN", Type.GetType("System.String"));
            _RealDataTable1.Columns.Add("TestIndex", Type.GetType("System.Int16"));
            _RealDataTable2 = new DataTable();
            _RealDataTable2.Columns.Add("Index", Type.GetType("System.Int16"));
            _RealDataTable2.Columns.Add("CaoIndex", Type.GetType("System.Int16"));
            _RealDataTable2.Columns.Add("DianZu", Type.GetType("System.Decimal"));
            _RealDataTable2.Columns.Add("V", Type.GetType("System.Decimal"));
            _RealDataTable2.Columns.Add("SN", Type.GetType("System.String"));
            _RealDataTable2.Columns.Add("TestIndex", Type.GetType("System.Int16"));
            for (int i=1;i<=20;i++)
            {
                if(i<=10)
                {
                    DataRow drNew = this._RealDataTable1.NewRow();
                    drNew["Index"] = i;
                    
                    this._RealDataTable1.Rows.Add(drNew);
                }
                else if (i <= 20)
                {
                    DataRow drNew = this._RealDataTable2.NewRow();
                    drNew["Index"] = i;
                    this._RealDataTable2.Rows.Add(drNew);
                }
            }
            this.dgvReal1.DataSource = this._RealDataTable1;
            this.dgvReal2.DataSource = this._RealDataTable2;
            #endregion

        }
        #region 子窗口
        frmNewTest mFormNewTest = null;
        frmNewTest FormNewTest
        {
            get
            {
                if (mFormNewTest == null || mFormNewTest.IsDisposed)
                    mFormNewTest = new frmNewTest();
                return mFormNewTest;
            }
        }
        frmPlanCompeleted mFormPlanCompeleted = null;
        frmPlanCompeleted FormPlanCompeleted
        {
            get
            {
                if (mFormPlanCompeleted == null || mFormPlanCompeleted.IsDisposed)
                    mFormPlanCompeleted = new frmPlanCompeleted(this);
                return mFormPlanCompeleted;
            }
        }
        Debug.frmTuoPanBtyErr mFormTuoPanBtyErr = null;
        Debug.frmTuoPanBtyErr FormTuoPanBtyErr
        {
            get
            {
                if (mFormTuoPanBtyErr == null || mFormTuoPanBtyErr.IsDisposed)
                    mFormTuoPanBtyErr = new Debug.frmTuoPanBtyErr(this);
                return mFormTuoPanBtyErr;
            }
        }
        Scanner.frmScannerDebug mFormScannerDebug = null;
        public Scanner.frmScannerDebug FormScannerDebug
        {
            get
            {
                if (mFormScannerDebug == null || mFormScannerDebug.IsDisposed)
                    mFormScannerDebug = new Scanner.frmScannerDebug(this._MainControl._ScannControler, this);
                return mFormScannerDebug;
            }
        }
        /// <summary>
        /// 是否扫描枪调试窗口已经打开
        /// </summary>
        public bool IsFormScannerDebugOpened = false;
        Debug.frmBatData mFormBatData = null;
        public Debug.frmBatData FormBatData
        {
            get
            {
                if (mFormBatData == null || mFormBatData.IsDisposed)
                    mFormBatData = new Debug.frmBatData(this);
                return mFormBatData;
            }
        }
        /// <summary>
        /// 是否电池信息窗口已经打开
        /// </summary>
        public bool IsFormBatDataOpened = false;
        frmErrMsg merrForm = null;
        public frmErrMsg _ErrForm
        {
            get
            {
                if (this.merrForm == null || this.merrForm.IsDisposed)
                    this.merrForm = new frmErrMsg();
                return this.merrForm;
            }
        }
        RemoteMac.frmCopy mFormCopySN = null;
        public RemoteMac.frmCopy FormCopySN
        {
            get
            {
                if (this.mFormCopySN == null || this.mFormCopySN.IsDisposed)
                    this.mFormCopySN = new RemoteMac.frmCopy();
                if (this.mFormCopySN._RemoteSNCopyControler == null)
                    this.mFormCopySN._RemoteSNCopyControler = this._RemoteSNCopyControler;
                return this.mFormCopySN;
            }
        }

        ExpFuns.frmMacJdl mFormMacJdl = null;
        public ExpFuns.frmMacJdl FormMacJdl
        {
            get
            {
                if (this.mFormMacJdl == null || this.mFormMacJdl.IsDisposed)
                    this.mFormMacJdl = new ExpFuns.frmMacJdl();
                return this.mFormMacJdl;
            }
        }
        #endregion
        #region 窗口变量
        public TestStates _TestState = TestStates.None;
        ModeView _TestMode = null;//存储当前测试模式，加载检测数据时需要对其赋值
        string _ProductSpecGuid = string.Empty;//当前选中的产品唯一标识
        short _ProductClassValue = -1;//当前选中的产品分类的PLC代码
        short _ProductClassScanner = 0;//当前选中的产品分类对应的扫描枪
        string _PeiFangName = string.Empty;//配方名称
        //JPSEnum.GongYiTypes _GongYiType = JPSEnum.GongYiTypes.None;
        JPSEnum.OnOff _MBatchOnOff = JPSEnum.OnOff.Off;//来料工单号是否检查
        JPSEnum.OnOff _SNOnOff = JPSEnum.OnOff.None;//电芯条码重复性是否检查
        JPSEnum.OnOff _CharOnOff = JPSEnum.OnOff.None;//电芯条码字符检查
        public JPSEnum.AotuMkMode _AutoMKOnOff = JPSEnum.AotuMkMode.None;//自动插装模式
        public string _RealTable_Batterys = string.Empty;
        public string _RealTable_Result = string.Empty;
        public JPSEntity.MainControl _MainControl = null;
        public string _TestCode = string.Empty;
        public int Statistic_BtyCount = 0;//用于统计当前测试下完成电芯数量，显示在UC控件上，这里为了尽量减少读取数据库，采用这个方式来更新数量
        public int Statistic_TuoCount = 0;
        public JPSEntity.SendMesControler _SendMesControler = null;
        public JPSEntity.RemoteSNCopyControler _RemoteSNCopyControler = null;
        public int _PrintCunt = 1;//当前标签打印的数量
        public MKBuilding _MKBuilding = null;
        public JPSEnum.SwitchModes? _SwitchMode = null;
        #endregion
        #region 处理函数
        private bool Perinit()
        {
            this._MBatchOnOff = JPSEnum.OnOff.Off;
            this.ucSpeed.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            this.ucTotalSn.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            this.ucTotalLpl.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            this.ucTotalScannerLpl.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            this.FormClear();
           // SetOnOffControlStyle(this.labMbatchNumCheckOnView, OnOff.None);
            //SetOnOffControlStyle(this.labSNContainCheckOnView, OnOff.None);
            this._RemoteSNCopyControler = new RemoteSNCopyControler(this);
            this.dgvGroove.AutoGenerateColumns = false;
            
            //初始化程序控制对象
            _MainControl = new MainControl(this);
            _MainControl.SysNewReadCompeletedNotice += _MainControl_SysNewReadCompeletedNotice;
            _MainControl.SysPlanCompeetedNotice += _MainControl_SysPlanCompeetedNotice;
            string strErr;
            if (!this._MainControl.Init(out strErr))
            {
                this.ShowErr(strErr);
                if (!JPSConfig.Scaner1_Terminated)
                {
                    if (this._MainControl._ScannControler == null || this._MainControl._ScannControler._Scanner1 == null || this._MainControl._ScannControler._Scanner1._State == JPSEnum.ScannerStates.None)
                        JPSConfig.Scaner1_Terminated = true;
                }
                if (!JPSConfig.Scaner2_Terminated)
                {
                    if (this._MainControl._ScannControler == null || this._MainControl._ScannControler._Scanner2 == null || this._MainControl._ScannControler._Scanner2._State == JPSEnum.ScannerStates.None)
                        JPSConfig.Scaner2_Terminated = true;
                }
            }
            else
            {
                if (this._TestState == TestStates.None)
                    this._TestState = TestStates.Free;
            }
            if(this._MainControl._PrinterControl!=null)
            {
                this._MainControl._PrinterControl.PrinterControlerPrintTypeChangedNotice += _PrinterControl_PrinterControlerPrintTypeChangedNotice;
            }
            //初始化自动插装
            JpsOPC.OPCHelperMKBuilding opcMKBuilding = new JpsOPC.OPCHelperMKBuilding();
            opcMKBuilding.IsDebug = JPSEntity.Debug.ScannerOpc.IsDebug;
            if (!opcMKBuilding.InitServer(out strErr))
            {
                this.ShowErr(strErr);
                return false;
            }
            this._MKBuilding = new MKBuilding(this, opcMKBuilding, this._MainControl._PrinterControl);
            this._MKBuilding.RefreshMKCodeNoitce += _MKBuilding_RefreshMKCodeNoitce;
            //初始化参数
            _TestMode = new ModeView();
            if (!this.BindInitTestCode())
            {
                BindRealGrooves();
                this.Statistic_BtyCount = 0;
                this.Statistic_TuoCount = 0;
                this.tbTestCode.Text = this.GetAutoCode(1);
                this.BindPrintCnt();
                //this.tbOrderNo.Text = DateTime.Now.ToString("yyyyMMdd");
            }
            #region 直接开启上传MES统计数据
            this._SendMesControler = new SendMesControler(this);
            this._SendMesControler.RefreshSendMesNotice += _SendMesControler_RefreshSendMesNotice;
            this._SendMesControler.SNClearDataIsOverNotice += _SendMesControler_SNClearDataIsOverNotice;
            if(!this._SendMesControler.StartListenning(out strErr))
            {
                this.ShowErr("开启MES数据同步控制器时失败：" + strErr);
            }
            #endregion
            this.SetFormStyle();
            //显示总统计数量
            if (this._MainControl != null && this._MainControl._StatisticControler != null)
                this._MainControl._StatisticControler.ReadTotalSnStiatistic();
            return true;
        }

        

        private void _SendMesControler_SNClearDataIsOverNotice(bool blOver, int iCount)
        {
            //通知系统是否已经越界了
            if (tsbDataOver.Visible != blOver)
                tsbDataOver.Visible = blOver;
        }

        private void _ResultControler_TuopanPlanProgressNotice(bool blCompeleted, int iPlanFinishedCnt)
        {
            throw new NotImplementedException();
        }

        private void _MainControl_SysPlanCompeetedNotice(bool blSucessful, string sErrMsg)
        {
            //此时表示用户选择了完成，且PLC已将电池清出了
            this.FormPlanCompeleted.JPSCommand = true;
            this.FormPlanCompeleted.Close();
            if(this._MainControl!=null && this._MainControl._ResultControler!=null)
            {
                //不要定义成中断了
                this._MainControl._ResultControler.SetInterrupt(false);
            }
            btStop_Click(null, null);
        }

        private void _MainControl_SysNewReadCompeletedNotice(bool blSucessful, string sErrMsg)
        {
            //通知新建的读取完成了
            if(blSucessful)
            {
                this.FormNewTest.MyClose();
                this.FormClear();
                this._TestState = TestStates.Free;
                this.SetFormStyle();
            }
            else
            {
                //此时为失败。
                this.FormNewTest.ShowErr(sErrMsg);
            }
        }

        private void _SendMesControler_RefreshSendMesNotice(bool blSucessful, int iCount)
        {
            JPSEntity.RefreshSendMesCallback call = new RefreshSendMesCallback(RefreshSendMesData);
            try
            {
                this.Invoke(call, new object[] { blSucessful, iCount });
            }
            catch (Exception ex)
            {
                this.ShowErrAysn(ex.Message);
            }
        }
        private void SetFormStyle()
        {
            //根据测试状态，设置窗口样式
            this.btStart.Enabled = this._TestState == TestStates.Free || this._TestState == TestStates.Pause;
            this.btNew.Enabled = this._TestState == TestStates.Pause;
            this.btStop.Enabled = this._TestState == TestStates.Testing || this._TestState == TestStates.Pause;
            bool blReadOnly = this._TestState != TestStates.Free;
            this.tbTestCode.ReadOnly = blReadOnly;
            //this.tbOrderNo.ReadOnly = blReadOnly;
            SetFormStyle_SetLinkArea(this.linkModeView, blReadOnly);
            SetFormStyle_SetLinkArea(this.linkProductSpec, blReadOnly);
            //SetFormStyle_SetLinkArea(this.linkMBatchNumCheckOn, blReadOnly);
            //SetFormStyle_SetLinkArea(this.linkSNCheckOn, blReadOnly);
            //SetFormStyle_SetLinkArea(this.linkAutoMKOn, blReadOnly);
            SetFormStyle_SetLinkArea(this.linkGrooveSetting, this._TestState == TestStates.Testing);
            //SetFormStyle_SetLinkArea(this.linkGongYi, blReadOnly);
            SetFormStyle_SetLinkArea(this.linkPlanCnt, !blReadOnly);

        }
        private void SetFormStyle_SetLinkArea(LinkLabel label, bool blReadOnly)
        {
            label.LinkArea = new LinkArea(0, blReadOnly ? 0 : label.Text.Length);
        }
        private void RefreshTestStatus()
        {
            if (_MainControl == null) return;
            //定义扫描枪1
            if (!JPSConfig.Scaner1_Terminated)
            {
                if (this._MainControl._ScannControler != null && this._MainControl._ScannControler._Scanner1 != null)
                {
                    if (this._MainControl._ScannControler._Scanner1.Running)
                    {
                        if (this._MainControl._ScannControler._Scanner1.Interrupt)
                        {
                            this.ucScanner1.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Bursh_BaoJing);
                            this.ucScanner1.SetMyText("中断");
                        }
                        else
                        {
                            //this.ucScanner1.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Bursh_Normal);
                            //this.ucScanner1.SetMyText("作业中");
                        }
                    }
                    else
                    {
                        this.ucScanner1.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Pen_Free);
                        this.ucScanner1.SetMyText("空闲");
                    }
                }
                else
                {
                    this.ucScanner1.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Pen_Free);
                    this.ucScanner1.SetMyText("未定义");
                }
            }
            else
            {
                this.ucScanner1.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Pen_Free);
                this.ucScanner1.SetMyText("停用中");
            }
            //定义扫描枪2
            if (!JPSConfig.Scaner2_Terminated)
            {
                
                if (this._MainControl._ScannControler != null && this._MainControl._ScannControler._Scanner2 != null)
                {
                    if (this._MainControl._ScannControler._Scanner2.Running)
                    {
                        if (this._MainControl._ScannControler._Scanner2.Interrupt)
                        {
                            this.ucScanner2.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Bursh_BaoJing);
                            this.ucScanner2.SetMyText("中断");
                        }
                        else
                        {
                            //this.ucScanner2.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Bursh_Normal);
                            //this.ucScanner2.SetMyText("作业中");
                        }
                    }
                    else
                    {
                        this.ucScanner2.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Pen_Free);
                        this.ucScanner2.SetMyText("空闲");
                    }
                }
                else
                {
                    this.ucScanner2.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Pen_Free);
                    this.ucScanner2.SetMyText("未定义");
                }
                
            }
            else
            {
                
                this.ucScanner2.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Pen_Free);
                this.ucScanner2.SetMyText("停用中");
            }
            //定义设备
            if (this._TestState == TestStates.Free || this._TestState == TestStates.Pause)
            {
                this.ucMacState.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Pen_Free);
                this.ucMacState.SetMyText("空闲");
            }
            else if (this._TestState == TestStates.Testing)
            {

            }
            if (this._MainControl._ResultControler == null)
            {
                this.ucMacState.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Pen_Free);
                this.ucMacState.SetMyText("NULL");
            }
            else
            {
                if (this._MainControl._ResultControler.Running)
                {
                    //此时运行中
                    if (this._MainControl._ResultControler.Interrupt)
                    {
                        //此时出错了
                        this.ucMacState.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Bursh_BaoJing);
                        this.ucMacState.SetMyText("中断");
                    }
                    else
                    {
                        this.ucMacState.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Bursh_Normal);
                        this.ucMacState.SetMyText("作业中");
                    }
                }
                else
                {
                    this.ucMacState.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Pen_Free);
                    this.ucMacState.SetMyText("空闲");
                }
                _TimerCouniter_ForSpeed += this.timer1.Interval;
                if (_TimerCouniter_ForSpeed >= 10000)
                {
                    double dbSpeed = this._MainControl._ResultControler.GetSpeed();
                    this.ucSpeed.SetMyText(dbSpeed.ToString("#########0"));
                    _TimerCouniter_ForSpeed = 0;
                }
            }
           //自动插装设备
           if(this._MKBuilding==null)
            {
                this.ucMkAutomationState.SetMyText("未初始化");
                this.ucMacState.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Pen_BaoJing);
            }
            else
            {
                if (this._MKBuilding.Running)
                {
                    if (this._MKBuilding.Interrupt)
                    {
                        //此时出错了
                        this.ucMkAutomationState.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Bursh_BaoJing);
                        this.ucMkAutomationState.SetMyText("error");
                    }
                    else
                    {
                        if (this._MKBuilding.Pausing)
                        {
                            this.ucMkAutomationState.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Pen_JingGao);
                            this.ucMkAutomationState.SetMyText("暂停作业");
                        }
                        else
                        {
                            this.ucMkAutomationState.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Bursh_Normal);
                            this.ucMkAutomationState.SetMyText("作业中");
                        }
                    }
                }
                else
                {
                    this.ucMkAutomationState.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Pen_Free);
                    if (this._AutoMKOnOff == JPSEnum.AotuMkMode.TuoPanOnly)
                        this.ucMkAutomationState.SetMyText("停止作业");
                    else this.ucMkAutomationState.SetMyText("空闲");
                }
            }

        }
        private void FormClear()
        {
            //清空界面部分信息，处于用户输入状态
            this.tbTestCode.Text = this.GetAutoCode(1);
            //清除产品信息，开始时再重新选择
            //客户要求不要清19-3-20this.tbProductSpec.Clear();
            //客户要求不要清19-3-20this._ProductSpecGuid = string.Empty;
            //客户要求不要清19-3-20this._ProductClassValue = -1;
            //客户要求不要清19-3-20this.tbProductClass.Text = string.Empty;
            //this.tbOrderNo.Text = DateTime.Now.ToString("yyyyMMdd");
            //客户要求不要清19-3-20this.labPeiFangName.Text = "";
            this.tbCompeletedCnt.Clear();
            this.tbPlanCnt.Clear();
            //来料工单清除，要重新写入
            //客户要求不要清19-3-20this.tbMbatchNum.Clear();
            //清除开始时间
            this.tbStartTime.Clear();
            //清空统计数据
            this.ucDianXinCnt.SetMyText(StatisticControlInitText);
            this.ucDianXinCnt.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            //this.ucTuoPanCnt.SetMyText(StatisticControlInitText);
            //this.ucTuoPanCnt.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            this.ucBuHegeRate.SetMyText(StatisticControlInitText);
            this.ucBuHegeRate.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            this.ucSnNGRate.SetMyText(StatisticControlInitText);
            this.ucSnNGRate.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            //this.ucMBatchBhgRate.SetMyText(StatisticControlInitText);
            //this.ucMBatchBhgRate.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            this.ucMkAutomationState.SetMyText(StatisticControlInitText);
            this.ucMkAutomationState.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            this._RealTable_Batterys = string.Empty;
            this._RealTable_Result = string.Empty;
            this.Statistic_BtyCount = 0;
            this.Statistic_TuoCount = 0;
            this.BindRealGrooves();
        }
        private JPSEnum.OperateLevels GetOperateLevel()
        {
            if (Common.CurrentUserInfo.UserCode.Length == 0) return OperateLevels.None;
            if (Common.CurrentUserInfo.IsSuper) return OperateLevels.SysAdmin;
            if (Common.CurrentUserInfo.IsAdmin) return OperateLevels.Admin;
            return OperateLevels.Operate;
        }
        private void SetUserPower()
        {
            int iLevel = (int)this.GetOperateLevel();
            //设置当前
            this.用户管理ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            this.用户管理ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上

            this.扫描枪通讯设置ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            //this.设备通讯设置ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            this.电阻校准值ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            //this.托盘条码打印机ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            this.新增配方ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上

            this.自定义编码规则ToolStripMenuItem1.Enabled = iLevel >= 2;//管理员以上
            this.实时统计设置ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            this.编辑工序ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            this.电芯型号定义ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            this.品质描述自定义ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            调试串钩ToolStripMenuItem.Enabled = iLevel >= 3;//开发员
            系统先关频率设置ToolStripMenuItem.Enabled = iLevel >= 3;
            扫描枪日志存储方式ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            清理数据提高设备运行效率ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            设置当前机台ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            设置其他设备地址ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            //清除已经上传MES数据ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            系统最大电芯数量超过报警ToolStripMenuItem.Enabled = iLevel >= 2;//管理员以上
            结果读取日志存储方式ToolStripMenuItem.Enabled = iLevel > 2;//管理员以上
        }
        private bool BindInitTestCode()
        {
            DataTable dtcode;
            try
            {
                dtcode = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT TOP 1 Code FROM Testing_Main WHERE ISNULL(State,0)<=1 order by StartTime DESC");
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dtcode.Rows.Count == 0)
            {
                return false;
            }
            string strTestCode = dtcode.Rows[0]["Code"].ToString();
            //此时有，则要加载初始化数据
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM V_Testing_Main where Code='{0}'", strTestCode.Replace("'", "''")), "V_Testing_Main"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM [V_Testing_Grooves] where Code='{0}'", strTestCode.Replace("'", "''")), "V_Testing_Grooves"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT Code,AsbCnt FROM Assemble_RealMK", "Assemble_RealMK"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "数据加载");
                return false;
            }
            DataTable dt = ds.Tables["V_Testing_Main"];
            DataTable dtDetail = ds.Tables["V_Testing_Grooves"];
            DataRow dr = dt.DefaultView[0].Row;
            this.tbModeView.Text = JPSFuns.GetModeView(dr["ModeIsNeter"], dr["ModeIsScaner"]);
            this.tbProductSpec.Text = string.Format("{0}({1})-{2}[扫描枪{3}]", dr["ClassName"].ToString(), dr["Value"].ToString(), dr["Spec"].ToString(), dr["Scanner"].ToString());
            
            //this.tbGongYiType.Text = dr["GongYiTypeName"].ToString();
            //this.tbCapacity.Text = Common.CommonFuns.FormatData.GetStringByDecimal(dr["Capacity"], "#########0.######");
            //this.tbCapacity1.Text = Common.CommonFuns.FormatData.GetStringByDecimal(dr["Capacity1"], "#########0.######");
            this.BindPactInfo(dr["OrderNo"].ToString());
            //this.tbOrderNo.Text = dr["OrderNo"].ToString();
            this.labPeiFangName.Text = string.Format("当前配方：{0}", dr["PeiFangName"].ToString());
            this.tbPlanCnt.Text = dr["TargetMKCnt"].ToString();
            this.tbCompeletedCnt.Text = dr["FinishedMKCnt"].ToString();
            //这只隐藏字段值
            this._PeiFangName = dr["PeiFangName"].ToString();
            this._ProductSpecGuid = dr["ProductSpec"].ToString();
            if (this._TestMode == null) this._TestMode = new ModeView();
            this._TestMode.ModeIsNeter = dr["ModeIsNeter"];
            this._TestMode.ModeIsScaner = dr["ModeIsScaner"];
            if (dr["GongYiType"].ToString() == "1")
                this._SwitchMode = SwitchModes.普通分档;
            else if (dr["GongYiType"].ToString() == "2")
                this._SwitchMode = SwitchModes.分AB档;
            else this._SwitchMode = SwitchModes.未定义;
            if (!dr["Value"].Equals(DBNull.Value))
                _ProductClassValue = short.Parse(dr["Value"].ToString());
            else _ProductClassValue = -1;
            //扫描枪选择
            if (!dr["Scanner"].Equals(DBNull.Value))
                this._ProductClassScanner = short.Parse(dr["Scanner"].ToString());
            else _ProductClassScanner = 0;
            this.SetScannerByProductClass(_ProductClassScanner);
            //人工编辑的数据
            this.tbTestCode.Text = strTestCode;
            //this.tbMbatchNum.Text = dr["MbatchNum"].ToString();
            this.tbStartTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["StartTime"], "yyyy-MM-dd HH:mm:ss");
            JPSEnum.OnOff state;
            if (dr["MbatchNumCheckOn"].Equals(DBNull.Value))
                state = JPSEnum.OnOff.None;
            else if ((bool)dr["MbatchNumCheckOn"])
                state = JPSEnum.OnOff.On;
            else state = JPSEnum.OnOff.Off;
            //this._MBatchOnOff = state;
            //this.SetOnOffControlStyle(this.labMbatchNumCheckOnView, state);

            //if (dr["SNContainCheckOn"].Equals(DBNull.Value))
            //    state = JPSEnum.OnOff.None;
            //else if ((bool)dr["SNContainCheckOn"])
            //    state = JPSEnum.OnOff.On;
            //else state = JPSEnum.OnOff.Off;
            //this._SNOnOff = state;
            //this.SetOnOffControlStyle(this.labSNContainCheckOnView, state);


            if (dr["CharCheckOn"].Equals(DBNull.Value))
                state = JPSEnum.OnOff.None;
            else if ((bool)dr["CharCheckOn"])
                state = JPSEnum.OnOff.On;
            else state = JPSEnum.OnOff.Off;
            this._CharOnOff = state;
           // this.SetOnOffControlStyle(this.labCharCheckOnView, state);
            //添加是否自动插装
            JPSEnum.AotuMkMode autMkState;
            if (dr["AutoMKOn"].ToString() == "1")
                autMkState = JPSEnum.AotuMkMode.AutoMKOnly;
            else if (dr["AutoMKOn"].ToString() == "2")
                autMkState = JPSEnum.AotuMkMode.TuoPanOnly;
            else if (dr["AutoMKOn"].ToString() == "3")
                autMkState = JPSEnum.AotuMkMode.All;
            else autMkState = JPSEnum.AotuMkMode.None;
            this._AutoMKOnOff = autMkState;
            //this.SetAutoMKModeControlStyle(this.labAutoMKOn, autMkState);
            //表对象
            this._RealTable_Batterys = dr["BatterysTable"].ToString();
            this._RealTable_Result = dr["ResultTable"].ToString();
            //绑定明细
            this.dgvGroove.DataSource = dtDetail;
            if(dr["state"].ToString()=="1")
            {
                #region 如果状态时测试中的，则不允许修改任何参数
                this._TestState = TestStates.Pause;
                //这种情况很有可能是软件中途退出了，这个时候应该不允许修改参数，因为可能已经有结果数据存入了
                //this.btStart.Enabled = true;
                //this.btNew.Enabled = false;
                //this.btStop.Enabled = true;
                //bool blReadOnly = true;
                //this.tbTestCode.ReadOnly = blReadOnly;
                //SetFormStyle_SetLinkArea(this.linkModeView, blReadOnly);
                //SetFormStyle_SetLinkArea(this.linkProductSpec, blReadOnly);
                //SetFormStyle_SetLinkArea(this.linkMBatchNumCheckOn, blReadOnly);
                //SetFormStyle_SetLinkArea(this.linkSNCheckOn, blReadOnly);
                //SetFormStyle_SetLinkArea(this.linkProcessCode, blReadOnly);
                //SetFormStyle_SetLinkArea(this.linkGrooveSetting, blReadOnly);
                #endregion
            }
            SetDataGridViewRowStyle();
            BindStatisticData();
            this._TestCode = strTestCode;
            #region 插装模块信息
            if(ds.Tables["Assemble_RealMK"].Rows.Count>0)
            {
                this.tbRealMKCode.Text = ds.Tables["Assemble_RealMK"].Rows[0]["Code"].ToString();
                this.labRealMKAsbCnt.Text = ds.Tables["Assemble_RealMK"].Rows[0]["AsbCnt"].ToString();
            }
            #endregion
            return true;
;        }
        private bool BindOrderInfo()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("exec ExpFuns_GetTuopanCodeInfo '{0}'", JPSConfig.MacNo));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.tbTuoPan1.Clear();
                this.tbTuoPan2.Clear();
            }
            else
            {
                this.tbTuoPan1.Text = dt.Rows[0]["TuoPanCode"].ToString();
                this.tbTuoPan2.Text = dt.Rows[0]["MxValue"].ToString();
            }
            return true;
        }
        private bool BindStatisticData()
        {
            DataTable dtDetail = this.dgvGroove.DataSource as DataTable;
            this.Statistic_TuoCount = 0;
            foreach (DataRowView drv in dtDetail.DefaultView)
            {
                if (!drv.Row["TuoCount"].Equals(DBNull.Value))
                    this.Statistic_TuoCount += int.Parse(drv.Row["TuoCount"].ToString());
            }
            //统计总电芯数量
            DataTable dtBty;
            try
            {
                dtBty = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT COUNT(*) FROM {0}", this._RealTable_Result));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.Statistic_BtyCount = int.Parse(dtBty.Rows[0][0].ToString());
            return true;
        }
        private bool BindTuoPanCodeInfo()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("exec ExpFuns_GetTuopanCodeInfo '{0}'", JPSConfig.MacNo));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.tbTuoPan1.Clear();
                this.tbTuoPan2.Clear();
            }
            else
            {
                this.tbTuoPan1.Text = dt.Rows[0]["TuoPanCode"].ToString();
                this.tbTuoPan2.Text = dt.Rows[0]["MxValue"].ToString();
            }
            return true;
        }
        
        #endregion
        private void frmMain1_Load(object sender, EventArgs e)
        {
            this.SetUserPower();
            Perinit();
            this.BindTuoPanCodeInfo();
            this.timer1.Interval = JPSConfig.TesteStatusReaderInterval;
            this.timer1.Enabled = true;
            this.timer2.Interval = 10000;
            this.timer2.Enabled = true;
            if (JPSEntity.Debug.PLCResultReader.IsDebug)
                JPSEntity.Debug.PLCResultReader.Init();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
        }
        #region 参数设置
        private void 选择配方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._TestState == TestStates.Testing)
            {
                this.ShowMsg("当前为测试状态，不能修改工艺参数。");
                return;
            }
            PeiFang.frmSelectPf frm = new PeiFang.frmSelectPf();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm._SeledGuid.Length == 0) return;
            //记载默认数据
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM V_PeiFang_Main where GUID='{0}'", frm._SeledGuid.Replace("'", "''")), "PeiFang_Main"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM PeiFang_Grooves where GUID='{0}'", frm._SeledGuid.Replace("'", "''")), "PeiFang_Grooves"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "数据加载");
                return;
            }
            DataTable dt = ds.Tables["PeiFang_Main"];
            DataTable dtDetail = ds.Tables["PeiFang_Grooves"];
            if (dt.DefaultView.Count == 0)
            {
                this.ShowMsg("您选择的配方不存在或已经被删除。");
                return;
            }
            DataRow dr = dt.DefaultView[0].Row;
            this.tbModeView.Text = JPSFuns.GetModeView(dr["ModeIsNeter"], dr["ModeIsScaner"]);
            this.tbProductSpec.Text = string.Format("{0}({1})-{2}", dr["ClassName"].ToString(), dr["Value"].ToString(), dr["Spec"].ToString());
            //this.tbProductClass.Text = dr["ClassName"].ToString();
            //this.tbProductClass.Text = string.Format("{0}({1})", dr["ClassName"].ToString(), dr["Value"].ToString());
            //this.tbGongYiType.Text = dr["GongYiTypeName"].ToString();
            
            this.labPeiFangName.Text = string.Format("当前配方：{0}", dr["PeiFangName"].ToString());
            //这只隐藏字段值
            this._PeiFangName = dr["PeiFangName"].ToString();
            this._ProductSpecGuid = dr["ProductSpec"].ToString();
            if (this._TestMode == null) this._TestMode = new ModeView();
            this._TestMode.ModeIsNeter = dr["ModeIsNeter"];
            this._TestMode.ModeIsScaner = dr["ModeIsScaner"];
            if (dr["GongYiType"].ToString() == "1")
                this._SwitchMode = SwitchModes.普通分档;
            else if (dr["GongYiType"].ToString() == "2")
                this._SwitchMode = SwitchModes.分AB档;
            else this._SwitchMode = SwitchModes.未定义;
            if (!dr["ProductClassValue"].Equals(DBNull.Value))
                _ProductClassValue = short.Parse(dr["ProductClassValue"].ToString());
            else _ProductClassValue = -1;
            //选择扫描枪
            if (!dr["Scanner"].Equals(DBNull.Value))
                this._ProductClassScanner = short.Parse(dr["Scanner"].ToString());
            else _ProductClassScanner = 0;
            this.SetScannerByProductClass(this._ProductClassScanner);
            //添加明细
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(string.Format("EXEC RealData_InitFromPeiFang '{0}'", frm._SeledGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "initRealGrooves");
                return;
            }
            this.BindRealGrooves();
        }
        private void BindRealGrooves()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM V_RealData_Grooves ORDER BY GrooveNo ASC");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.dgvGroove.DataSource = dt;
            SetDataGridViewRowStyle();
        }
        private void SetDataGridViewRowStyle()
        {
            DataTable dt = this.dgvGroove.DataSource as DataTable;
            DataRow dr;
            Color color = Color.FromArgb(219, 225, 236);
            Color cNoBk, cNoFore;
            short iQuality;
            for (int i = 0; i < this.dgvGroove.Rows.Count; i++)
            {
                if (dt != null)
                {
                    dr = dt.DefaultView[i].Row;
                    if (dr["Quality"].Equals(DBNull.Value)) iQuality = 0;
                    else iQuality = short.Parse(dr["Quality"].ToString());
                    if (iQuality == 0)
                    {
                        cNoBk = Color.White;
                        cNoFore = Color.Gray;
                    }
                    else if (iQuality == 1)
                    {
                        cNoBk = Color.FromArgb(55, 88, 136);
                        cNoFore = Color.White;
                    }
                    else
                    {
                        cNoBk = Color.Maroon;
                        cNoFore = Color.White;
                    }
                    this.dgvGroove[0, i].Style.BackColor = cNoBk;
                    this.dgvGroove[0, i].Style.ForeColor = cNoFore;
                }
                if ((i % 2) == 0) continue;
                for (int j = 1; j < this.dgvGroove.Columns.Count; j++)
                {
                    this.dgvGroove[j, i].Style.BackColor = color;
                    //this.dgvGroove.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                }
            }
        }
        private void linkGrooveSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmGrooveSetting frm = new frmGrooveSetting(this._AutoMKOnOff);
            frm._IsNet = _TestMode.ModeIsNeter != null && !_TestMode.ModeIsNeter.Equals(DBNull.Value) && (bool)_TestMode.ModeIsNeter;
            frm.IsAllSame(true);//设置同工艺
            if (this._TestState == TestStates.Testing || this._TestState == TestStates.Pause)
                frm.SetTuoBtyCntEnable(false);
            else frm.SetTuoBtyCntEnable(true);
            frm.ShowDialog(this);
            if (!frm._Updated) return;
            this.BindRealGrooves();
        }
        private void linkModeView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BasicData.frmSelectMode frm = new BasicData.frmSelectMode();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this._TestMode.ModeIsNeter = frm._ModeIsNeter;
            this._TestMode.ModeIsScaner = frm._ModeIsScaner;
            this.tbModeView.Text = JPSFuns.GetModeView(this._TestMode);
        }
        

        private void linkProductSpec_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BasicData.frmSelectProductSpec frm = new BasicData.frmSelectProductSpec(this._ProductClassValue);
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData == null || frm.SelectedData.Count == 0) return;
            this.tbProductSpec.Text = string.Format("{0}-{1}[扫描枪{2}]", frm.SelectedData[0].ClassFullName.ToString(), frm.SelectedData[0].Spec.ToString(), frm.SelectedData[0].Scanner.ToString());
            this._ProductSpecGuid = frm.SelectedData[0].GUID.ToString();
            if (!frm.SelectedData[0].ClassValue.Equals(DBNull.Value))
                this._ProductClassValue = short.Parse(frm.SelectedData[0].ClassValue.ToString());
            else this._ProductClassValue = -1;

            if (!frm.SelectedData[0].Scanner.Equals(DBNull.Value))
                this._ProductClassScanner = short.Parse(frm.SelectedData[0].Scanner.ToString());
            else this._ProductClassScanner = 0;
            //设置扫描枪
            SetScannerByProductClass(this._ProductClassScanner);

            //this.tbProductClass.Text = frm.SelectedData[0].ClassFullName.ToString();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*
            BasicData.frmSelectGongYi frm = new BasicData.frmSelectGongYi();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this._GongYiType = frm._SelectedType;
            //this.tbGongYiType.Text = JPSFuns.GetGongYiTypeName(this._GongYiType);
            this.SetAutoMKValueByGongYiValue(this._GongYiType);
            */
        }
        private void linkSNCheckOn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //BasicData.frmSelectOnOff frm = new BasicData.frmSelectOnOff();
            //if (DialogResult.OK != frm.ShowDialog(this)) return;
            //this._SNOnOff = frm._SelectedType;
            //SetOnOffControlStyle(this.labSNContainCheckOnView, this._SNOnOff);
        }

        private void linkMBatchNumCheckOn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //BasicData.frmSelectOnOff frm = new BasicData.frmSelectOnOff();
            //if (DialogResult.OK != frm.ShowDialog(this)) return;
            //this._MBatchOnOff = frm._SelectedType;
            //SetOnOffControlStyle(this.labMbatchNumCheckOnView, this._MBatchOnOff);
        }
        private void SetOnOffControlStyle(Label lab, JPSEnum.OnOff state)
        {
            /*
            Color cBk, cFore;
            string strText;
            if (state == JPSEnum.OnOff.None)
            {
                cBk = Color.White;
                cFore = Color.Black;
                strText = "";
            }
            else if (state == JPSEnum.OnOff.On)
            {
                cBk = Color.FromArgb(0, 192, 0);
                cFore = Color.White;
                strText = JPSFuns.GetOnOffView(state);
            }
            else
            {
                cBk = Color.Gray;
                cFore = Color.White;
                strText = JPSFuns.GetOnOffView(state);
            }
            if (lab.BackColor != cBk)
                lab.BackColor = cBk;
            if (lab.ForeColor != cFore)
                lab.ForeColor = cFore;
            if (lab.Text != strText)
                lab.Text = strText;
            if(lab.Equals(this.labAutoMKOn))
            {
                SetAutoMKOnOffFromStyle();
                if (this._MainControl != null && this._MainControl._PrinterControl != null)
                {
                    if (state == OnOff.On)
                        this._MainControl._PrinterControl.SetPrintType(PrinterControl.PrintTypes.MKCode);
                    else if (state == OnOff.Off)
                        this._MainControl._PrinterControl.SetPrintType(PrinterControl.PrintTypes.TuoPanCode);
                    else
                        this._MainControl._PrinterControl.SetPrintType(PrinterControl.PrintTypes.None);
                }
            }*/
        }
        private void SetAutoMKModeControlStyle(Label lab, JPSEnum.AotuMkMode state)
        {
            Color cBk, cFore;
            string strText;
            if (state == JPSEnum.AotuMkMode.None)
            {
                //cBk = Color.White;
                //cFore = Color.Black;
                strText = "未定义";
            }
            else if (state == JPSEnum.AotuMkMode.AutoMKOnly)
            {
                //cBk = Color.FromArgb(0, 192, 0);
                //cFore = Color.White;
                strText = "仅自动插装";
            }
            else if (state == JPSEnum.AotuMkMode.TuoPanOnly)
            {
                //cBk = Color.FromArgb(0, 192, 0);
                //cFore = Color.White;
                strText = "仅托盘";
            }
            else
            {
                //cBk = Color.Gray;
                //cFore = Color.White;
                strText = "混合模式";
            }
            //if (lab.BackColor != cBk)
            //    lab.BackColor = cBk;
            //if (lab.ForeColor != cFore)
            //    lab.ForeColor = cFore;
            if (lab.Text != strText)
                lab.Text = strText;
            SetAutoMKOnOffFromStyle();
            if (this._MainControl != null && this._MainControl._PrinterControl != null)
            {
                if (state == JPSEnum.AotuMkMode.AutoMKOnly)
                    this._MainControl._PrinterControl.SetPrintType(PrinterControl.PrintTypes.MKCode);
                else if (state == JPSEnum.AotuMkMode.TuoPanOnly)
                    this._MainControl._PrinterControl.SetPrintType(PrinterControl.PrintTypes.TuoPanCode);
                else if (state == JPSEnum.AotuMkMode.All)
                    this._MainControl._PrinterControl.SetPrintType(PrinterControl.PrintTypes.ALL);
                else if (state == JPSEnum.AotuMkMode.None)
                    this._MainControl._PrinterControl.SetPrintType(PrinterControl.PrintTypes.None);
            }
        }
        public bool SaveData()
        {
            if (Common.CurrentUserInfo.UserCode.Length == 0)
            {
                this.ShowMsg("请先登录。");
                return false;
            }
            if (this.tbTestCode.Text.Length == 0)
            {
                this.ShowMsg("请输入测试编号！");
                return false;
            }
            DataTable dtSource = null;
           
            try
            {
                dtSource = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM Testing_Main WHERE Code='{0}'"
                    , this.tbTestCode.Text.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "GetDataSource");
                return false;
            }
            if (dtSource.Rows.Count > 0)
            {
                if(dtSource.Rows[0]["State"].ToString()=="2")
                {
                    this.ShowMsg("该测试编号已经结束完成，请更换！");
                    return false;
                }
            }
            if (dtSource.DefaultView.Count == 0)
            {
                DataRow drNew = dtSource.NewRow();
                dtSource.Rows.Add(drNew);
            }
            DataRow dr = dtSource.DefaultView[0].Row;
            if (this._TestMode.ModeIsNeter == null || this._TestMode.ModeIsNeter.Equals(DBNull.Value))
            {
                this.ShowMsg("请选择单机版或是网络版。");
                return false;
            }
            if((bool)this._TestMode.ModeIsNeter)
            {
                if (this._OrderNo.Length == 0)
                {
                    this.ShowMsg("当前为网络版，请选择生产计划。");
                    return false;
                }
            }
            if (this._TestMode.ModeIsScaner == null || this._TestMode.ModeIsScaner.Equals(DBNull.Value))
            {
                this.ShowMsg("请选择扫码还是不扫码。");
                return false;
            }
            if (this._ProductSpecGuid.Length == 0)
            {
                this.ShowMsg("请选择电芯型号。");
                return false;
            }
            if (this._SwitchMode==null || this._SwitchMode == SwitchModes.未定义)
            {
                this.ShowMsg("请选择分档模式。");
                return false;
            }
            //if (this._MBatchOnOff == OnOff.None)
            //{
            //    this.ShowMsg("请选择是否来料工单校验。");
            //    return false;
            //}
            //if(this._MBatchOnOff==OnOff.On)
            //{
            //    ////此时开启的必须添加来料工单号，因为检查的就是个号码是否包含在电芯条码中
            //    //if(this.tbMbatchNum.Text.Length==0)
            //    //{
            //    //    this.ShowMsg("当前开启了来料工单校验，请输入来料工单号！");
            //    //    return false;
            //    //}
            //}
            if (this._SNOnOff == OnOff.None)
            {
                this.ShowMsg("请选择是否电芯条码重复性校验。");
                return false;
            }
            //if (this._CharOnOff == OnOff.None)
            //{
            //    this.ShowMsg("请选择是否开启电芯条码非法字符校验。");
            //    return false;
            //}
            if (this._AutoMKOnOff == JPSEnum.AotuMkMode.None)
            {
                this.ShowMsg("请选择是否开启自动插装功能。");
                return false;
            }
            //if (this.tbCapacity.Text.Length == 0)
            //{
            //    this.ShowMsg("请输入电池容量范围的最小值。");
            //    return false;
            //}
            //if (this.tbCapacity1.Text.Length == 0)
            //{
            //    this.ShowMsg("请输入电池容量范围的最大值。");
            //    return false;
            //}
            if (this.tbMacCode.Text.Length == 0)
            {
                this.ShowMsg("请添加设备代码。");
                return false;
            }
            int iPlancnt;
            if(!int.TryParse(this.tbPlanCnt.Text,out iPlancnt))
            {
                this.ShowMsg("请输入计划托盘数量。0表示不限。");
                return false;
            }
            //decimal decCapacity;
            //if(!decimal.TryParse(this.tbCapacity.Text,out decCapacity))
            //{
            //    this.ShowMsg("请正确输入电池容量范围的最小的值。");
            //    return false;
            //}
            //decimal decCapacity1;
            //if (!decimal.TryParse(this.tbCapacity1.Text, out decCapacity1))
            //{
            //    this.ShowMsg("请正确输入电池容量范围的最大的值。");
            //    return false;
            //}
            //if(decCapacity>decCapacity1)
            //{
            //    this.ShowMsg("请正确输入电池容量范围，最小值不能大于最大值！");
            //    return false;
            //}
            dr["TargetMKCnt"] = iPlancnt;
            dr["Code"] = this.tbTestCode.Text;
            dr["Operator"] = Common.CurrentUserInfo.UserCode;
            dr["OperatorName"] = Common.CurrentUserInfo.UserName;
            dr["ModeIsNeter"] = this._TestMode.ModeIsNeter;
            dr["ModeIsScaner"] = this._TestMode.ModeIsScaner;
            dr["ProductSpec"] = this._ProductSpecGuid;
            //dr["MbatchNum"] = this.tbMbatchNum.Text;
            //dr["MbatchNumCheckOn"] = this._MBatchOnOff == OnOff.On ;
            dr["SNContainCheckOn"] = this._SNOnOff == OnOff.On;
            dr["CharCheckOn"] = this._CharOnOff == OnOff.On;
            dr["AutoMKOn"] = (short)this._AutoMKOnOff;
            dr["GongYiType"] = (int)this._SwitchMode;
            //dr["Capacity"] = decCapacity;
            //dr["Capacity1"] = decCapacity1;
            dr["MacCode"] = this.tbMacCode.Text;
            dr["OrderNo"] = this._OrderNo;
            dr["PactCode"] = this._PactCode;
            dr["PeiFangName"] = this._PeiFangName;
            string sTableBatterys, sTableResult;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.StartTesting(dtSource, out sTableBatterys, out sTableResult, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "StartTesting");
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0) strMsg = "存储数据失败，原因未知。";
                this.ShowMsg(strMsg);
                return false;
            }
            this._RealTable_Batterys = sTableBatterys;
            this._RealTable_Result = sTableResult;
            JPSEntity.ResultControler.TuopanPlanCnt = iPlancnt;
            return true;
        }
        /// <summary>
        /// 将槽工艺参数写入PLC
        /// </summary>
        /// <returns></returns>
        public bool WriteGroovesIntoPLC()
        {
            if (this._MainControl == null)
            {
                this.ShowMsg("程序控制对象为空，请重新打开窗口！");
                return false;
            }
            if (this._MainControl._OPCHelperGongYi == null)
            {
                this.ShowMsg("程序控制对象(工艺参数写入)为空，请重新打开窗口！");
                return false;
            }
            string strErr;
            if (!this._MainControl._OPCHelperGongYi.SetExp_SwMode((short)this._SwitchMode,out strErr))
            {
                this.ShowMsg($"设置分档模式出错：{strErr}");
                return false;
            }
            bool GY_IsNet = this._TestMode.ModeIsNeter.Equals(DBNull.Value) ? false : (bool)this._TestMode.ModeIsNeter;
            bool GY_IsScanner = this._TestMode.ModeIsScaner.Equals(DBNull.Value) ? false : (bool)this._TestMode.ModeIsScaner;
            bool GY_MBatchChecker = this._MBatchOnOff == OnOff.On;
            short GY_IsSameGy = 1;//南京中比都定义为通工艺
            short GY_DxSize = this._ProductClassValue;
            JpsOPC.GrooveGongyiEntity[] grooves = new JpsOPC.GrooveGongyiEntity[18];
            DataTable dt = this.dgvGroove.DataSource as DataTable;
            //if (dt.DefaultView.Count != 18)
            //{
            //    this.ShowMsg("当前槽数量不是18，写入失败！");
            //    return false;
            //}
            DataRow dr;
            DataRow[] drs;
            for (int i =0; i <18; i++)
            {
                drs = dt.Select("GrooveNo=" + (i + 1).ToString());
                if (drs.Length == 0)
                    dr = dt.NewRow();
                else dr = drs[0];
                grooves[i] = new JpsOPC.GrooveGongyiEntity((short)(i + 1));
                if (dr["Vmin"].Equals(DBNull.Value))
                    grooves[i].St_CaoVmin = 0M;
                else
                    grooves[i].St_CaoVmin = decimal.Parse(dr["Vmin"].ToString());
                if (dr["Vmax"].Equals(DBNull.Value))
                    grooves[i].St_CaoVmax = 0M;
                else
                    grooves[i].St_CaoVmax = decimal.Parse(dr["Vmax"].ToString());
                //电阻
                if (dr["DianZuMin"].Equals(DBNull.Value))
                    grooves[i].St_CaoDzmin = 0M;
                else
                    grooves[i].St_CaoDzmin = decimal.Parse(dr["DianZuMin"].ToString());
                if (dr["DianZuMax"].Equals(DBNull.Value))
                    grooves[i].St_CaoDzmax = 0M;
                else
                    grooves[i].St_CaoDzmax = decimal.Parse(dr["DianZuMax"].ToString());
                grooves[i].St_CaoUsed = dr["Quality"].ToString() == "1" || dr["Quality"].ToString() == "2";//1为良品，2位不良品
                //电池数量
                if (dr["TuoBtyCount"].Equals(DBNull.Value))
                    grooves[i].St_CaoDxCnt = 0;
                else
                    grooves[i].St_CaoDxCnt = short.Parse(dr["TuoBtyCount"].ToString());
            }
            if (!this._MainControl._OPCHelperGongYi.WriteGongyi(GY_IsNet, GY_IsScanner, GY_MBatchChecker, GY_IsSameGy, GY_DxSize, grooves, out strErr))
            {
                if (strErr.Length == 0)
                    strErr = "写入工艺时失败，原因未知。";
                this.ShowMsg(strErr);
                return false;
            }
            return true;
        }
        public bool WriteNanjingZBIntoPLc()
        {
            /******************
             * 将南京中比特有的分档信息写入PLC
             * ***************/
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("select * from NanJingZB_YaCha");
            }
            catch(Exception ex)
            {
                this.ShowMsg($"获取压差值出错：{ex.Message}");
                return false;
            }
            JpsOPC.OPCEntitys.YaChaEntity yacha = new JpsOPC.OPCEntitys.YaChaEntity();
            int iMyIndex;
            float decValue;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MyIndex"].Equals(DBNull.Value)) continue;
                if (dr["YcValue"].Equals(DBNull.Value)) continue;
                iMyIndex = int.Parse(dr["MyIndex"].ToString());
                decValue = (float)decimal.Parse(dr["YcValue"].ToString());
                if (iMyIndex == 1)
                    yacha.Yc1 = decValue;
                else if (iMyIndex == 2) yacha.Yc2 = decValue;
                else if (iMyIndex == 3) yacha.Yc3 = decValue;
                else if (iMyIndex == 4) yacha.Yc4 = decValue;
                else if (iMyIndex == 5) yacha.Yc5 = decValue;
                else if (iMyIndex == 6) yacha.Yc6 = decValue;
                else if (iMyIndex == 7) yacha.Yc7 = decValue;
                else if (iMyIndex == 8) yacha.Yc8 = decValue;
                else if (iMyIndex == 9) yacha.Yc9 = decValue;
                else if (iMyIndex == 10) yacha.Yc10 = decValue;
                else if (iMyIndex == 11) yacha.Yc11 = decValue;
                else if (iMyIndex == 12) yacha.Yc12 = decValue;
                else if (iMyIndex == 13) yacha.Yc13 = decValue;
                else if (iMyIndex == 14) yacha.Yc14 = decValue;
                else if (iMyIndex == 15) yacha.Yc15 = decValue;
                else if (iMyIndex == 16) yacha.Yc16 = decValue;
                else if (iMyIndex == 17) yacha.Yc17 = decValue;
                else if (iMyIndex == 18) yacha.Yc18 = decValue;
                else if (iMyIndex == 19) yacha.Yc19 = decValue;
                else if (iMyIndex == 20) yacha.Yc20 = decValue;
            }
            if (this._MainControl == null)
            {
                this.ShowMsg("写入压差数据出错：程序控制对象为空，请重新打开窗口！");
                return false;
            }
            if (this._MainControl._OPCHelperGongYi == null)
            {
                this.ShowMsg("写入压差数据出错：程序控制对象(工艺参数写入)为空，请重新打开窗口！");
                return false;
            }
            string strErr;
            if (!this._MainControl._OPCHelperGongYi.WriteYaCha(false,yacha, out strErr))
            {
                this.ShowMsg($"写入压差数据出错：{strErr}");
                return false;
            }
            //不是分档不用写入
            if (this._SwitchMode != SwitchModes.分AB档) return true;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable($"SELECT * FROM Testing_GroovesAB WHERE CODE='{this._TestCode.Replace("'", "''")}'");
            }
            catch (Exception ex)
            {
                this.ShowMsg($"获取AB分档设置信息出错：{ex.Message}");
                return false;
            }
            List<JpsOPC.OPCEntitys.SwichABEntity> list = new List<JpsOPC.OPCEntitys.SwichABEntity>();
            for (int i = 0; i < 9; i++)
            {
                JpsOPC.OPCEntitys.SwichABEntity set = new JpsOPC.OPCEntitys.SwichABEntity();
                set.CaoIndex = (short)(i + 1);
                list.Add(set);
            }
            int iGrooveNo;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["GrooveNo"].Equals(DBNull.Value)) continue;
                iGrooveNo = int.Parse(dr["GrooveNo"].ToString());
                if (iGrooveNo < 1 || iGrooveNo > list.Count) continue;
                JpsOPC.OPCEntitys.SwichABEntity set = list[iGrooveNo - 1];
                set.MinValueA = (float)(dr["Amin"].Equals(DBNull.Value) ? 0M : decimal.Parse(dr["Amin"].ToString()));
                set.MaxValueA = (float)(dr["Amax"].Equals(DBNull.Value) ? 0M : decimal.Parse(dr["Amax"].ToString()));
                set.MinValueB = (float)(dr["Bmin"].Equals(DBNull.Value) ? 0M : decimal.Parse(dr["Bmin"].ToString()));
                set.MaxValueB = (float)(dr["Bmax"].Equals(DBNull.Value) ? 0M : decimal.Parse(dr["Bmax"].ToString()));
                set.QtyA = dr["AQty"].Equals(DBNull.Value) ? (short)0 : short.Parse(dr["AQty"].ToString());
                set.QtyB = dr["BQty"].Equals(DBNull.Value) ? (short)0 : short.Parse(dr["BQty"].ToString());
            }
            if (!this._MainControl._OPCHelperGongYi.WriteSwichSetting(false, list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8], out strErr))
            {
                this.ShowMsg($"写入分档数据出错：{strErr}");
                return false;
            }
            return true;
        }
        #endregion
        #region  扫描枪
        /// <summary>
        /// 扫描枪1是否允许被关闭
        /// </summary>
        /// <returns></returns>
        public bool IsScanner1AllowStop(out string sErr)
        {
            sErr = string.Empty;
            return true;
        }
        /// <summary>
        /// 扫描枪2是否允许被关闭
        /// </summary>
        /// <returns></returns>
        public bool IsScanner2AllowStop(out string sErr)
        {
            sErr = string.Empty;
            return true;
        }
        public void RefreshScanner1Data(string sData)
        {
            this.FormScannerDebug.RereshReceivedScanner1Data(sData);
        }
        public void RefreshScanner2Data(string sData)
        {
            this.FormScannerDebug.RereshReceivedScanner2Data(sData);
        }
        private void SetScannerByProductClass(short iScanner)
        {
            if (this._MainControl._ScannControler == null)
            {
                this.ShowMsg("扫描枪判断失败，因为控制对象为空！");
                return;
            }
            string strErr;
            if (iScanner == 1)
            {
                if (JPSConfig.Scaner1_Terminated)
                {
                    this._MainControl._ScannControler._Scanner1.SetScannerIP(JPSConfig.Scaner1_IP, JPSConfig.Scaner1_Port);
                    JPSConfig.Scaner1_Terminated = false;
                }
                if (!JPSConfig.Scaner2_Terminated)
                {
                    //此时要关闭扫描枪2
                    if (this._MainControl._ScannControler._Scanner2.Running)
                    {
                        if(!this._MainControl._ScannControler._Scanner2.StopListenning(out strErr))
                        {
                            this.ShowMsg("扫描枪2关闭失败：" + strErr);
                        }
                    }
                    JPSConfig.Scaner2_Terminated = true;
                }
            }
            else if (iScanner == 2)
            {
                if (JPSConfig.Scaner2_Terminated)
                {
                    this._MainControl._ScannControler._Scanner2.SetScannerIP(JPSConfig.Scaner2_IP, JPSConfig.Scaner2_Port);
                    JPSConfig.Scaner2_Terminated = false;
                }
                if (!JPSConfig.Scaner1_Terminated)
                {
                    //此时要关闭扫描枪1
                    if (this._MainControl._ScannControler._Scanner1.Running)
                    {
                        if (!this._MainControl._ScannControler._Scanner1.StopListenning(out strErr))
                        {
                            this.ShowMsg("扫描枪1关闭失败：" + strErr);
                        }
                    }
                    JPSConfig.Scaner1_Terminated = true;
                }
            }
        }
        #endregion
        #region 执行按钮
        private void btStart_Click(object sender, EventArgs e)
        {
            if (this._TestState == TestStates.None)
            {
                this.ShowMsg("当前窗口状态无效，请排除故障然后重新运行软件。");
                return;
            }
            if (this._TestState != TestStates.Free && this._TestState != TestStates.Pause)
            {
                this.ShowMsg("当前状态不是空闲，不能启动测试。");
                return;
            }
            this._MainControl._ResultControler.ShowLog("窗口状态无误。");
            if (Common.CurrentUserInfo.UserCode.Length==0)
            {
                this.ShowMsg("请先登录！");
                return;
            }
            if (!this.SaveData()) return;
            if (this._SNOnOff == OnOff.On)
            {
                if (this._RemoteSNCopyControler != null)
                    this._RemoteSNCopyControler.Stop();
                RemoteMac.frmCopy frm = new RemoteMac.frmCopy();
                frm.ShowDialog();
                //return;
            }
            this._TestCode = this.tbTestCode.Text;
            this._MainControl._ResultControler.SetSwitchMode((SwitchModes)this._SwitchMode);
            this._MainControl._ResultControler.ShowLog("数据已提交至远程服务器。");
            //将槽的工艺参数写入设备
            if (!WriteGroovesIntoPLC()) return;
            if (!WriteNanjingZBIntoPLc()) return;
            this._MainControl._ResultControler.ShowLog("工艺参数已写入PLC。");
            this._MainControl._ScannControler.SetTestingData(this._MBatchOnOff == OnOff.On, string.Empty, this._SNOnOff == OnOff.On, this._CharOnOff == OnOff.On, this._RealTable_Batterys, this._RealTable_Result);

            this._MainControl._ResultControler.ShowLog("参数已写入扫描枪控制对象。");
            #region 读取槽明细数据
            DataTable dtGrooves;
            try
            {
                dtGrooves = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM V_Testing_Grooves WHERE Code='{0}' AND isnull(Quality,0)<>0  order by GrooveNo asc"
                    , this.tbTestCode.Text.Replace("'", "''")));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.dgvGroove.DataSource = dtGrooves;
            this._MainControl._ResultControler.ShowLog("已重新绑定槽明细。");
            this.SetDataGridViewRowStyle();
            this.BindStatisticData();//读取当前托盘数量和电芯数量
            this.ucDianXinCnt.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            //this.ucTuoPanCnt.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            this.ucDianXinCnt.SetMyText(Statistic_BtyCount.ToString());
            //this.ucTuoPanCnt.SetMyText(Statistic_TuoCount.ToString());
            //初始化结果控制对象中18个槽实例的相关数据
            long lID;
            string sTuoPanCode;
            short iQuality;
            int iTuoBtyCount;
            DataRow drGroove;
            DataRow[] drs;
            //short iGrooveNo;
            bool blNet;
            if (this._TestMode.ModeIsNeter != null && !this._TestMode.ModeIsNeter.Equals(DBNull.Value) && (bool)this._TestMode.ModeIsNeter)
                blNet = true;
            else blNet = false;
            bool blSendMes;
            bool blAutoMK = false;
            for (short iGrooveNo = 1; iGrooveNo <= 18; iGrooveNo++)
            {
                drs = dtGrooves.Select("GrooveNo=" + iGrooveNo.ToString());
                if (drs.Length == 0)
                {
                    lID = 0;
                    sTuoPanCode = string.Empty;
                    iQuality = 0;
                    iTuoBtyCount = 0;
                    blSendMes = false;
                    blAutoMK = false;
                }
                else
                {
                    drGroove = drs[0];
                    lID = long.Parse(drGroove["ID"].ToString());
                    sTuoPanCode = drGroove["TuoCode"].ToString();
                    iQuality = drGroove["Quality"].Equals(DBNull.Value) ? (short)0 : short.Parse(drGroove["Quality"].ToString());
                    
                    iTuoBtyCount = drGroove["TuoBtyCount"].Equals(DBNull.Value) ? 0 : int.Parse(drGroove["TuoBtyCount"].ToString());
                    if (blNet)
                    {
                        //只有网络版的才需要用户选择
                        blSendMes = !drGroove["SendMes"].Equals(DBNull.Value) && (bool)drGroove["SendMes"];
                    }
                    else blSendMes = false;
                    blAutoMK = !drGroove["AutoMK"].Equals(DBNull.Value) && (bool)drGroove["AutoMK"];
                }
                #region 赋值18个槽对象
                if (iGrooveNo == 1)
                {
                    this._MainControl._ResultControler.Groove1.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove1.GrooveID = lID;
                    this._MainControl._ResultControler.Groove1.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove1.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove1.Quality = iQuality;
                    this._MainControl._ResultControler.Groove1.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove1.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove1.Quality = iQuality;

                }
                else if (iGrooveNo == 2)
                {
                    this._MainControl._ResultControler.Groove2.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove2.GrooveID = lID;
                    this._MainControl._ResultControler.Groove2.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove2.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove2.Quality = iQuality;
                    this._MainControl._ResultControler.Groove2.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove2.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove2.Quality = iQuality;
                }
                else if (iGrooveNo == 3)
                {
                    this._MainControl._ResultControler.Groove3.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove3.GrooveID = lID;
                    this._MainControl._ResultControler.Groove3.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove3.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove3.Quality = iQuality;
                    this._MainControl._ResultControler.Groove3.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove3.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove3.Quality = iQuality;
                }
                else if (iGrooveNo == 4)
                {
                    this._MainControl._ResultControler.Groove4.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove4.GrooveID = lID;
                    this._MainControl._ResultControler.Groove4.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove4.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove4.Quality = iQuality;
                    this._MainControl._ResultControler.Groove4.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove4.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove4.Quality = iQuality;
                }
                else if (iGrooveNo == 5)
                {
                    this._MainControl._ResultControler.Groove5.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove5.GrooveID = lID;
                    this._MainControl._ResultControler.Groove5.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove5.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove5.Quality = iQuality;
                    this._MainControl._ResultControler.Groove5.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove5.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove5.Quality = iQuality;
                }
                else if (iGrooveNo == 6)
                {
                    this._MainControl._ResultControler.Groove6.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove6.GrooveID = lID;
                    this._MainControl._ResultControler.Groove6.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove6.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove6.Quality = iQuality;
                    this._MainControl._ResultControler.Groove6.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove6.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove1.Quality = iQuality;
                }
                else if (iGrooveNo == 7)
                {
                    this._MainControl._ResultControler.Groove7.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove7.GrooveID = lID;
                    this._MainControl._ResultControler.Groove7.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove7.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove7.Quality = iQuality;
                    this._MainControl._ResultControler.Groove7.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove7.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove7.Quality = iQuality;
                }
                else if (iGrooveNo == 8)
                {
                    this._MainControl._ResultControler.Groove8.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove8.GrooveID = lID;
                    this._MainControl._ResultControler.Groove8.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove8.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove8.Quality = iQuality;
                    this._MainControl._ResultControler.Groove8.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove8.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove8.Quality = iQuality;
                }
                else if (iGrooveNo == 9)
                {
                    this._MainControl._ResultControler.Groove9.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove9.GrooveID = lID;
                    this._MainControl._ResultControler.Groove9.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove9.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove9.Quality = iQuality;
                    this._MainControl._ResultControler.Groove9.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove9.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove9.Quality = iQuality;
                }
                else if (iGrooveNo == 10)
                {
                    this._MainControl._ResultControler.Groove10.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove10.GrooveID = lID;
                    this._MainControl._ResultControler.Groove10.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove10.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove10.Quality = iQuality;
                    this._MainControl._ResultControler.Groove10.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove10.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove10.Quality = iQuality;
                }
                else if (iGrooveNo == 11)
                {
                    this._MainControl._ResultControler.Groove11.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove11.GrooveID = lID;
                    this._MainControl._ResultControler.Groove11.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove11.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove11.Quality = iQuality;
                    this._MainControl._ResultControler.Groove11.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove11.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove11.Quality = iQuality;
                }
                else if (iGrooveNo == 12)
                {
                    this._MainControl._ResultControler.Groove12.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove12.GrooveID = lID;
                    this._MainControl._ResultControler.Groove12.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove12.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove12.Quality = iQuality;
                    this._MainControl._ResultControler.Groove12.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove12.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove12.Quality = iQuality;
                }
                else if (iGrooveNo == 13)
                {
                    this._MainControl._ResultControler.Groove13.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove13.GrooveID = lID;
                    this._MainControl._ResultControler.Groove13.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove13.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove13.Quality = iQuality;
                    this._MainControl._ResultControler.Groove13.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove13.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove13.Quality = iQuality;
                }
                else if (iGrooveNo == 14)
                {
                    this._MainControl._ResultControler.Groove14.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove14.GrooveID = lID;
                    this._MainControl._ResultControler.Groove14.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove14.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove14.Quality = iQuality;
                    this._MainControl._ResultControler.Groove14.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove14.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove14.Quality = iQuality;
                }
                else if (iGrooveNo == 15)
                {
                    this._MainControl._ResultControler.Groove15.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove15.GrooveID = lID;
                    this._MainControl._ResultControler.Groove15.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove15.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove15.Quality = iQuality;
                    this._MainControl._ResultControler.Groove15.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove15.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove15.Quality = iQuality;
                }
                else if (iGrooveNo == 16)
                {
                    this._MainControl._ResultControler.Groove16.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove16.GrooveID = lID;
                    this._MainControl._ResultControler.Groove16.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove16.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove16.Quality = iQuality;
                    this._MainControl._ResultControler.Groove16.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove16.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove16.Quality = iQuality;
                }
                else if (iGrooveNo == 17)
                {
                    this._MainControl._ResultControler.Groove17.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove17.GrooveID = lID;
                    this._MainControl._ResultControler.Groove17.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove17.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove17.Quality = iQuality;
                    this._MainControl._ResultControler.Groove17.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove17.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove17.Quality = iQuality;
                }
                else if (iGrooveNo == 18)
                {
                    this._MainControl._ResultControler.Groove18.AutoMK = this.MyCaoIsAutoMK(blAutoMK);
                    this._MainControl._ResultControler.Groove18.GrooveID = lID;
                    this._MainControl._ResultControler.Groove18.TuoPanCode = sTuoPanCode;
                    this._MainControl._ResultControler.Groove18.SendMes = blSendMes;
                    this._MainControl._ResultControler.Groove18.Quality = iQuality;
                    this._MainControl._ResultControler.Groove18.TuoBtyCount = iTuoBtyCount;
                    this._MainControl._StatisticControler.Groove18.GrooveID = lID;
                    this._MainControl._StatisticControler.Groove18.Quality = iQuality;
                }
                #endregion
            }
            #endregion
            //写入系统标识
            string strErr;
            if (!this._MainControl.InitScannerPLCIOValue(out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            #region 设备4专项处理
            if (JPSConfig.MacNo == 99)
            {
                DataTable dtSnCnt = null;
                try
                {
                    dtSnCnt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select GrooveBtyCont from Testing_Grooves where Code='{0}'", this._TestCode));
                }
                catch (Exception ex)
                {
                    this.ShowErr(string.Format("4号机专项处理：读取槽1内电芯数量时出错：{0}({1})", ex.Message, ex.Source));
                    return;
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
                    if (!this._MainControl._ResultControler._OPCHelperResult.SetSNCount(iSnCnt, out strErr))
                    {
                        this.ShowErr(string.Format("4号机专项处理：写入槽1内电芯数量时出错：{0}", strErr));
                        return;
                    }
                }
            }
            #endregion
            if (!this._MainControl._ResultControler.Listen_ResetAt_ReadResult())
            {
                this.ShowMsg("初始化结果集标识符时失败。");
                return;
            }
            if (!this._MainControl._OPCHelperGongYi.SetAt_SysRun(true, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            //开启扫描枪监听
            if (!this._MainControl._ScannControler.StartListenning(out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            this._MainControl._ResultControler.SetTestingData(this._TestCode,this._RealTable_Batterys);
            //开启模块插装监听
            if (this._AutoMKOnOff !=JPSEnum.AotuMkMode.TuoPanOnly)
            {
                if (!this._MKBuilding.Running)
                {
                    if (!this._MKBuilding.StartListenning(out strErr))
                    {
                        this.ShowMsg(strErr);
                        return;
                    }
                }
                else
                {
                    //此时解除暂停
                    this._MKBuilding.PauseListening(false);
                }
            }
            //开启检测结果监听
            if (!this._MainControl._ResultControler.StartListenning(out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (AutoAssign.MyPrinter.AutoPrint)//如果没有开启打印，不要启动监听，以免让费CPU资源 2020-04-20 jiangpengsong
            {
                //开启打印机监听
                if (!this._MainControl._PrinterControl.Running)
                {
                    if (!this._MainControl._PrinterControl.StartListenning(out strErr))
                    {
                        this.ShowMsg(strErr);
                        return;
                    }
                }
                //else
                //{
                //    this._MainControl._PrinterControl.PauseListening(false);
                //}
                this._MainControl._PrinterControl.PauseListening(false);//确保打印不暂停
            }
            //执行最后标识，检测中
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.SetTestingState(this.tbTestCode.Text, 1, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                this.ShowMsg("标识检测状态为检测中时出错：" + ex.Message);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "标识检测状态为检测中时出错，原因未知。";
                this.ShowMsg(strMsg);
                return;
            }
            //开启统计对象
            if(this._MainControl._StatisticControler!=null)
            {
                if(!this._MainControl._StatisticControler.StartListenning(this._RealTable_Batterys,this._RealTable_Result,this._MBatchOnOff==OnOff.On,out strErr))
                {
                    this.ShowErr("开启数据统计对象时出错：" + strErr);//统计不是关键的，仍旧继续执行下去
                }
            }
            this._TestState = TestStates.Testing;
            this.SetFormStyle();
        }
        private bool MyCaoIsAutoMK(bool blVAlue)
        {
            if (this._AutoMKOnOff == JPSEnum.AotuMkMode.TuoPanOnly) return false;
            if (this._AutoMKOnOff == JPSEnum.AotuMkMode.AutoMKOnly) return true;
            return blVAlue;
        }
        private void btStop_Click(object sender, EventArgs e)
        {
            if(sender!=null)
            {
                if (!this.IsUserConfirm("您确定要停止测试吗？")) return;
            }
            if (this._TestState == TestStates.None)
            {
                this.ShowMsg("当前窗口状态无效，请排除故障然后重新运行软件。");
                return;
            }
            if (this._TestState != TestStates.Testing && this._TestState != TestStates.Pause)
            {
                this.ShowMsg("当前状态不是运行中，不能停止测试。");
                return;
            }
            if (this._MainControl == null)
            {
                this.ShowMsg("程序控制器为空，停止失败！");
                return;
            }
            if (this._MainControl._OPCHelperGongYi == null)
            {
                this.ShowMsg("程序控制器(工艺)为空，停止失败！");
                return;
            }
            string strErr;
            //设置设备停止运行
            if (!this._MainControl._OPCHelperGongYi.SetAt_SysRun(false, out strErr))
            {
                this.ShowMsg(string.Format("通知PLC停止运行时出错：{0}", strErr));
                return;
            }
            //关闭扫描枪
            if (this._MainControl._ScannControler != null)
            {
                if (this._MainControl._ScannControler._Scanner1 != null)
                {
                    if (this._MainControl._ScannControler._Scanner1.Running)
                    {
                        if (!this._MainControl._ScannControler._Scanner1.StopListenning(out strErr))
                        {
                            this.ShowErrAysn(string.Format("扫描枪1关闭时出错：{0}", strErr));
                            return;
                        }
                    }
                }
                if (this._MainControl._ScannControler._Scanner2 != null)
                {
                    if (this._MainControl._ScannControler._Scanner2.Running)
                    {
                        if (!this._MainControl._ScannControler._Scanner2.StopListenning(out strErr))
                        {
                            this.ShowErrAysn(string.Format("扫描枪2关闭时出错：{0}", strErr));
                            return;
                        }
                    }
                }
            }
            //关闭结果采集
            if (this._MainControl._ResultControler != null)
            {
                if (!this._MainControl._ResultControler.StopListenning(out strErr))
                {
                    this.ShowErrAysn(string.Format("结果数据采集器关闭时出错：{0}", strErr));
                    return;
                }
            }
            if (this._MainControl._StatisticControler != null)
            {
                
                if(!this._MainControl._StatisticControler.StopListenning(out strErr))
                {
                    this.ShowErrAysn(string.Format("数据统计分析器关闭时出错：{0}", strErr));
                    return;
                }
            }
            this._MainControl._ResultControler.Listen_TuoPanPlanCompeleted = false;
            //关闭打印机监听
            this._MainControl._PrinterControl.PauseListening(true);//仅暂停
            //this._MainControl._PrinterControl.StopListenning();
            //关闭自动插装
            //if(!this._MKBuilding.StopListenning(out strErr))
            //{
            //    this.ShowErrAysn(string.Format("自动插装通讯关闭出错：{0}", strErr));
            //    return;
            //}
            this._MKBuilding.PauseListening(true);//仅暂停
            //执行最后标识，检测完成
            //int iReturnValue;
            //string strMsg;
            //try
            //{
            //    this.BllDAL.SetTestingState(this._TestCode, 2, out iReturnValue, out strMsg);
            //}
            //catch (Exception ex)
            //{
            //    this.ShowMsg("标识检测状态为检测中时出错：" + ex.Message);
            //    return;
            //}
            //if (iReturnValue != 1)
            //{
            //    if (strMsg.Length == 0)
            //        strMsg = "标识检测状态为检测完成时出错，原因未知。";
            //    this.ShowMsg(strMsg);
            //    return;
            //}
            this._TestState = TestStates.Pause;
            this.SetFormStyle();
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            //此时为新增
            if (this._TestState != TestStates.Pause && this._TestState != TestStates.Free)
            {
                this.ShowMsg("当前状态不是停止状态，不能新建。");
                return;
            }
            if(this._MainControl==null)
            {
                this.ShowMsg("通讯对象为空，无法写入。");
                return;
            }
            string strErr;
            if(this._MainControl._OPCHelperGongYi==null)
            {
                this.ShowMsg("工艺数据通讯对象为空，无法写入。");
                return;
            }
            if (!this.CheckExsistRealMK()) return;
            /************
             * 因引入了自动插装，托盘编码不需要了，所以移除 by jiangpengsong 2020-04-24
            ExpFuns.frmSetTuoPanCode1 frmTp = new ExpFuns.frmSetTuoPanCode1();
            if (DialogResult.OK != frmTp.ShowDialog(this)) return;
            ***********************/
            //try
            //{
            //    Common.CommonDAL.DoSqlCommand.DoSql(string.Format("exec ResetTuopanCode {0}", JPSConfig.MacNo));
            //}
            //catch(Exception ex)
            //{
            //    wErrorMessage.ShowErrorDialog(this, ex);
            //    return;
            //}
            //执行最后标识，检测完成
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.SetTestingState(this._TestCode, 2, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                this.ShowMsg("检测状态为检测完成时出错：" + ex.Message);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "标识检测状态为检测完成时出错，原因未知。";
                this.ShowMsg(strMsg);
                return;
            }
            //停止自动插装作业
            if (this._MKBuilding != null)
            {
                if(!this._MKBuilding.StopListenning(out strErr))
                {
                    this.ShowErrAysn(strErr);
                }
            }
            if (!this._MainControl._OPCHelperGongYi.SetAt_SysNew(out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            //此时为写入成功，则打开监控对象
            if (!this._MainControl.StartSysNewListenning(out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            this.FormNewTest.ClearErr();
            this.FormNewTest.Show();
            this.BindTuoPanCodeInfo();
            
        }
        #endregion
        #region timer控件
        int _TimerCouniter_ForSpeed = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //刷新底部状态
            this.RefreshTestStatus();   
        }
        #endregion
        #region 顶部工具条按钮
        private void 新增配方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeiFang.frmPfList frm = new PeiFang.frmPfList();
            frm.Show();
        }

        private void 电芯型号定义ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicData.frmProductSpec frm = new BasicData.frmProductSpec();
            frm.ShowDialog(this);
        }

        private void 品质描述自定义ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicData.frmQualityDesc frm = new BasicData.frmQualityDesc();
            frm.ShowDialog(this);
        }
        private void 编辑工序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicData.frmProcessCode frm = new BasicData.frmProcessCode();
            frm.ShowDialog(this);
        }

        private void 日志窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScanner1Log.ShowMyLog(string.Empty);
        }

        private void 监听扫描枪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormScannerDebug.Show();
        }

        private void 扫描枪通讯设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._MainControl == null || this._MainControl._ScannControler == null)
            {
                this.ShowMsg("控制对象初始化失败！");
                return;
            }
            Setting.frmScannerSetting frm = new Setting.frmScannerSetting();
            if (DialogResult.OK != frm.ShowDialog()) return;
            if (this._MainControl._ScannControler != null)
            {
                string strErr;
                if (JPSConfig.Scaner1_Terminated)
                {
                    if (this._MainControl._ScannControler._Scanner1.Running)
                    {
                        //此时立即停止
                        if (!this._MainControl._ScannControler._Scanner1.StopListenning(out strErr))
                        {
                            this.ShowErr(strErr);
                        }
                    }
                }
                else
                {
                    this._MainControl._ScannControler._Scanner1.SetScannerIP(JPSConfig.Scaner1_IP, JPSConfig.Scaner1_Port);
                    if (!this._MainControl._ScannControler._Scanner1.Running && this._TestState==TestStates.Testing)
                    {
                        //打开
                        if (!this._MainControl._ScannControler._Scanner1.StartListenning(out strErr))
                        {
                            this.ShowMsg(strErr);
                        }
                    }
                }
                if (JPSConfig.Scaner2_Terminated)
                {
                    if (this._MainControl._ScannControler._Scanner2.Running)
                    {
                        //此时立即停止
                        if (!this._MainControl._ScannControler._Scanner2.StopListenning(out strErr))
                        {
                            this.ShowErr(strErr);
                        }
                    }
                }
                else
                {
                    this._MainControl._ScannControler._Scanner2.SetScannerIP(JPSConfig.Scaner2_IP, JPSConfig.Scaner2_Port);
                    if (!this._MainControl._ScannControler._Scanner2.Running && this._TestState == TestStates.Testing)
                    {
                        //打开
                        if (!this._MainControl._ScannControler._Scanner2.StartListenning(out strErr))
                        {
                            this.ShowMsg(strErr);
                        }
                    }
                }
            }
        }



        private void saoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 刷新批次编号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sCode = this.GetAutoCode(1);
            if (sCode.Length == 0)
            {
                this.ShowErr("自动编码获取失败！");
                return;
            }
            if (this.tbTestCode.Text != sCode)
                this.tbTestCode.Text = sCode;
            this.ShowMsgRich("刷新成功！");
        }

        private void 自定义编码规则ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AutoCode.frmAutoCode frm = new AutoCode.frmAutoCode();
            frm.Show(this);
        }

        private void 扫描枪1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScanner1Log.ShowMyLog("");
        }

        private void 扫描枪2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScanner2Log.ShowMyLog("");

        }

        private void 模拟设备PLC状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.frmDebug frm = new Debug.frmDebug();
            frm.Show();
        }

        private void 电芯信息实时查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormBatData.Show();
        }

        private void 系统设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 设置当前机台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._TestState == TestStates.Testing)
            {
                this.ShowMsg("正在测试中，不能修改关键信息。");
                return;
            }
            Setting.frmStationConfig frm = new Setting.frmStationConfig();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.tbMacCode.Text = JPSConfig.MacName;
        }
        #endregion
        #region  消息处理
        public void ShowErrAysn(string sMsg)
        {

        }
        public void ShowErr(string sMsg)
        {
            if (this._ErrForm.ErrMsg != sMsg)
                this._ErrForm.ErrMsg = sMsg;
            if (!this._ErrForm.Visible)
                this._ErrForm.Show();
        }

        #endregion
        #region 公共函数
        public void RefreshGroovesData(List<JPSEntity.GrooveData> changedGrooves, int iAddBtyCount, int iAddTuoCount)
        {
            if (changedGrooves == null) return;
            DataTable dt = this.dgvGroove.DataSource as DataTable;
            if (dt == null) return;
            //if (dt.DefaultView.Count != 18)
            //{
            //    this.ShowErr("槽明细不是18行！这是不正确的。");
            //    return;
            //}
            DataRow dr;
            DataRow[] drs;
            foreach (JPSEntity.GrooveData groove in changedGrooves)
            {
                drs = dt.Select("GrooveNo=" + groove.Index);
                if (drs.Length == 0) continue;
                dr = drs[0];
                //托盘编号
                if (dr["TuoCode"].ToString() != groove.TuoPanCode)
                    dr["TuoCode"] = groove.TuoPanCode;
                //当前电芯数量
                if (dr["GrooveBtyCont"].ToString() != groove.GrooveBtyCont.ToString())
                    dr["GrooveBtyCont"] = groove.GrooveBtyCont;
                //当前总托盘数量
                if (dr["TuoCount"].ToString() != groove.TuoCount.ToString())
                    dr["TuoCount"] = groove.TuoCount;
            }
            this.Statistic_BtyCount += iAddBtyCount;
            this.Statistic_TuoCount += iAddTuoCount;
            this.ucDianXinCnt.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            //this.ucTuoPanCnt.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            this.ucDianXinCnt.SetMyText(Statistic_BtyCount.ToString());
            //this.ucTuoPanCnt.SetMyText(Statistic_TuoCount.ToString());
        }
        public void RefreshNGRate(bool NGRateIsSucessful, decimal decNGRate, bool isCheckerMBatchNum, decimal decMBatchYcRate)
        {
            if(NGRateIsSucessful)
            {
                decimal dec = 1M - decNGRate;
                //此时统计数据读取成功
                this.ucSnNGRate.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Normal);
                this.ucSnNGRate.SetMyText(dec.ToString("#########0.00%"));
                //this.ucMBatchBhgRate.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Normal);
                //dec = 1M - decMBatchYcRate;
                //this.ucMBatchBhgRate.SetMyText(dec.ToString("#########0.00%"));
            }
            else
            {
                //此时统计数据读取失败
                this.ucSnNGRate.SetMyReelSatus(UserControls.DrawingReelSatus.Bursh_BaoJing);
                this.ucSnNGRate.SetMyText("error");
                if (isCheckerMBatchNum)
                {
                    //此时需要同步更新来料工单信息
                    //this.ucMBatchBhgRate.SetMyReelSatus(UserControls.DrawingReelSatus.Bursh_BaoJing);
                    //this.ucMBatchBhgRate.SetMyText("error");
                }
            }
        }
        public void RefreshUnQualityRate(bool blUnQualitySucessful, decimal decUnQRate)
        {
            if(blUnQualitySucessful)
            {
                //刷新成功
                this.ucBuHegeRate.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Normal);
                decimal dec = 1M - decUnQRate;
                this.ucBuHegeRate.SetMyText(dec.ToString("#########0.00%"));
            }
            else
            {
                this.ucBuHegeRate.SetMyReelSatus(UserControls.DrawingReelSatus.Bursh_BaoJing);
                this.ucBuHegeRate.SetMyText("error");
            }
        }
        public void RefreshSendMesData(bool blSucessful, int iCount)
        {
            if (blSucessful)
            {
                this.ucSendMES.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Normal);
                this.ucSendMES.SetMyText(iCount.ToString());
            }
            else
            {
                this.ucSendMES.SetMyReelSatus(UserControls.DrawingReelSatus.Bursh_BaoJing);
                this.ucSendMES.SetMyText("error");
            }
        }
        public void RefehsScanner1State(ScannerTextStates state)
        {
            this.ucScanner1.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Bursh_Normal);
            string str;
            if (state == ScannerTextStates.WattingData)
                str = "等待数据";
            else if (state == ScannerTextStates.WattingScann)
                str = "等待扫描";
            else if (state == ScannerTextStates.Proing)
                str = "处理数据";
            else str = "unkown";
            this.ucScanner1.SetMyText(str);
        }
        public void RefehsScanner2State(ScannerTextStates state)
        {
            /* 现在只用1把扫描枪
            this.ucScanner2.SetMyReelSatus(AutoAssign.UserControls.DrawingReelSatus.Bursh_Normal);
            string str;
            if (state == ScannerTextStates.WattingData)
                str = "等待数据";
            else if (state == ScannerTextStates.WattingScann)
                str = "等待扫描";
            else if (state == ScannerTextStates.Proing)
                str = "处理数据";
            else str = "unkown";
            this.ucScanner2.SetMyText(str);
            */
        }
        public void RefreshTuoPanBtyCntErr(List<string> listTuoPan)
        {
            if (!this.FormTuoPanBtyErr.Visible)
            {
                this.FormTuoPanBtyErr.BindData(listTuoPan, this._RealTable_Result, this._RealTable_Batterys);
                this.FormTuoPanBtyErr.Show();
            }
        }
        public void StopTest()
        {
            this.FormPlanCompeleted.JPSCommand = true;
            this.FormPlanCompeleted.Close();
            btStop_Click(null, null);
        }
        public void RefreshTuopanPlanProgress(bool blCompeleted, int iPlanFinishedCnt)
        {
            //通知主线程，当前计划完成情况
            if (!blCompeleted)
            {
                this.tbCompeletedCnt.Text = iPlanFinishedCnt.ToString();
            }
            else
            {
                this.tbCompeletedCnt.Text = iPlanFinishedCnt.ToString();
                //此时应该通知用户，到达计划了
                this.FormPlanCompeleted.Bind(this._TestCode);
                this.FormPlanCompeleted.Show();
            }
        }
        public void BindTuoPlan()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT TargetMKCnt,FinishedMKCnt FROM Testing_Main WHERE Code='{0}'", this._TestCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("未找到传入的检测批次号。");
                return;
            }
            int iPlan, iCompeleted;
            DataRow dr = dt.Rows[0];
            if (!int.TryParse(dr["TargetMKCnt"].ToString(), out iPlan))
                iPlan = 0;
            if (!int.TryParse(dr["FinishedMKCnt"].ToString(), out iCompeleted))
                iCompeleted = 0;
            this.tbPlanCnt.Text = iPlan.ToString();
            this.tbCompeletedCnt.Text = iCompeleted.ToString();
            JPSEntity.ResultControler.TuopanPlanCnt = iPlan;
        }
        public void BindMKPlan()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT TargetMKCnt,FinishedMKCnt FROM Testing_Main WHERE Code='{0}'", this._TestCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("未找到传入的检测批次号。");
                return;
            }
            int iPlan, iCompeleted;
            DataRow dr = dt.Rows[0];
            if (!int.TryParse(dr["TargetMKCnt"].ToString(), out iPlan))
                iPlan = 0;
            if (!int.TryParse(dr["FinishedMKCnt"].ToString(), out iCompeleted))
                iCompeleted = 0;
            this.tbPlanCnt.Text = iPlan.ToString();
            this.tbCompeletedCnt.Text = iCompeleted.ToString();
           // JPSEntity.ResultControler.TuopanPlanCnt = iPlan;该字段无效，故模块不添加
        }
        public void RefresRealDataShowNotice(ResultData data1, ResultData data2, ResultData data3, ResultData data4, ResultData data5, ResultData data6, ResultData data7, ResultData data8, ResultData data9, ResultData data10, ResultData data11, ResultData data12, ResultData data13, ResultData data14, ResultData data15, ResultData data16, ResultData data17, ResultData data18, ResultData data19, ResultData data20)
        {
            DataRow dr;
            ResultData data;
            if (this._RealDataTable1 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (this._RealDataTable1.DefaultView.Count <= i) break;
                    dr = this._RealDataTable1.DefaultView[i].Row;
                    if (i == 0) data = data1;
                    else if (i == 1) data = data2;
                    else if (i == 2) data = data3;
                    else if (i == 3) data = data4;
                    else if (i == 4) data = data5;
                    else if (i == 5) data = data6;
                    else if (i == 6) data = data7;
                    else if (i == 7) data = data8;
                    else if (i == 8) data = data9;
                    else data = data10;
                    if (dr["CaoIndex"].ToString() != data.CaoIndex.ToString())
                        dr["CaoIndex"] = data.CaoIndex;
                    if (!dr["DianZu"].Equals(data.DianZu))
                        dr["DianZu"] = data.DianZu;
                    if (!dr["V"].Equals(data.V))
                        dr["V"] = data.V;
                    if (dr["SN"].ToString() != data.SN)
                        dr["SN"] = data.SN;
                    if (dr["TestIndex"].ToString() != data.TestIndex.ToString())
                        dr["TestIndex"] = data.TestIndex;
                }
            }
            if (this._RealDataTable2 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (this._RealDataTable2.DefaultView.Count <= i) break;
                    dr = this._RealDataTable2.DefaultView[i].Row;
                    if (i == 0) data = data11;
                    else if (i == 1) data = data12;
                    else if (i == 2) data = data13;
                    else if (i == 3) data = data14;
                    else if (i == 4) data = data15;
                    else if (i == 5) data = data16;
                    else if (i == 6) data = data17;
                    else if (i == 7) data = data18;
                    else if (i == 8) data = data19;
                    else data = data20;
                    if (dr["CaoIndex"].ToString() != data.CaoIndex.ToString())
                        dr["CaoIndex"] = data.CaoIndex;
                    if (!dr["DianZu"].Equals(data.DianZu))
                        dr["DianZu"] = data.DianZu;
                    if (!dr["V"].Equals(data.V))
                        dr["V"] = data.V;
                    if (dr["SN"].ToString() != data.SN)
                        dr["SN"] = data.SN;
                    if (dr["TestIndex"].ToString() != data.TestIndex.ToString())
                        dr["TestIndex"] = data.TestIndex;
                }
            }
        }
        public void RefreshGroovesData()
        {
            if (this._TestState == TestStates.Pause || this._TestState == TestStates.Testing)
            {
                DataTable dtGrooves;
                try
                {
                    dtGrooves = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM V_Testing_Grooves WHERE Code='{0}' AND isnull(Quality,0)<>0  order by GrooveNo asc"
                        , this.tbTestCode.Text.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                this.dgvGroove.DataSource = dtGrooves;
                this._MainControl._ResultControler.ShowLog("已重新绑定槽明细。");
                this.SetDataGridViewRowStyle();
                this.BindStatisticData();//读取当前托盘数量和电芯数量
                this.ucDianXinCnt.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
                //this.ucTuoPanCnt.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
                this.ucDianXinCnt.SetMyText(Statistic_BtyCount.ToString());
            }
        }
        public void RefreshSnStatistic(string iSnCnt, string decLpl, string decScannLpl, string decMBatchLpl, bool blSucessfully, string sErr)
        {
            if (blSucessfully)
            {
                this.ucTotalSn.SetMyText(iSnCnt);
                this.ucTotalScannerLpl.SetMyText(decScannLpl);
                this.ucTotalLpl.SetMyText(decLpl);
                
                this.ucTotalSn.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
                this.ucTotalScannerLpl.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
                this.ucTotalLpl.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_Free);
            }
            else
            {
                this.ucTotalSn.SetMyText("Error");
                this.ucTotalScannerLpl.SetMyText("Error");
                this.ucTotalLpl.SetMyText("Error");

                this.ucTotalSn.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_BaoJing);
                this.ucTotalScannerLpl.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_BaoJing);
                this.ucTotalLpl.SetMyReelSatus(UserControls.DrawingReelSatus.Pen_BaoJing);
                this.ShowErr(sErr);
            }
        }
       
        #endregion
        #region 用户管理
        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this._TestState==TestStates.Testing)
            {
                this.ShowMsg("测试中，不能注销！");
                return;
            }
            Common.CurrentUserInfo.Logout();
            this.ShowMsgRich("注销成功！");
            this.tbOperatorName.Text = "用户已注销";
            this.SetUserPower();
        }

        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._TestState == TestStates.Testing)
            {
                this.ShowMsg("测试中，不能切换用户！");
                return;
            }
            Login.frmLogin frm = new Login.frmLogin();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.tbOperatorName.Text = Common.CurrentUserInfo.UserName;
            this.SetUserPower();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.frmModifyPwd frm = new Login.frmModifyPwd();
            frm.UserCode = Common.CurrentUserInfo.UserCode;
            frm.ShowDialog();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!Common.CurrentUserInfo.IsAdmin && !Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有管理员才能操作！");
                return;
            }
            BasicData.frmUserManager frm = new BasicData.frmUserManager();
            frm.ShowDialog(this);
        }
        #endregion
        #region 生产计划相关
        /// <summary>
        /// 早期版本存储的是客户的订单号，后面引入MES后存储的是生产计划单号。
        /// </summary>
        public string _OrderNo = string.Empty;
        /// <summary>
        /// 引入MES后添加该字段存储MES的任务单号，即ERP中的工单号
        /// </summary>
        string _PactCode = string.Empty;
        /// <summary>
        /// 收料和比例，注意这里存储的是编码
        /// </summary>
        string _FxRatioCode = string.Empty;
        /// <summary>
        /// 模块生产计划，如果是0的表示不受限制，这里定义成小数，是因为存在1:1.5的情况
        /// </summary>
        decimal _PlanQty = 0M;
        private void linkSelPlan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.ShowMsg("当前版本为非网络版，无法选择生产计划。");
            //return;
            BasicData.frmSelectPlan frm = new BasicData.frmSelectPlan();
            frm.MultiSelected = false;
            if (frm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (frm.SelectedData == null || frm.SelectedData.Count == 0) return;
            this.BindPactInfo(frm.SelectedData[0].GUID.ToString());
            if(this._PlanQty>0M)
            {
                int iQtyMk;
                string strErr;
                if(!JPSEntity.SendMesControler.GetCompeletedMKQty(this._OrderNo,out iQtyMk, out strErr))
                {
                    this.ShowMsg(strErr);
                }
                else
                {
                    decimal dec = this._PlanQty - (decimal)iQtyMk;
                    int iRemain = (int)dec;
                    if ((dec % 1M) != 0)
                        iRemain++;
                    if (iRemain < 0)
                        iRemain = 0;
                    if (this._TestCode.Length > 0)
                    {
                        string strSql = string.Format("update Testing_Main set TargetMKCnt={0} where Code='{1}'", iRemain, this._TestCode.Replace("'", "''"));
                        try
                        {
                            Common.CommonDAL.DoSqlCommand.DoSql(strSql);
                        }
                        catch (Exception ex)
                        {
                            this.ShowMsg(ex.Message);
                            return;
                        }
                        this.BindMKPlan();
                        /***************
                         * 以后都是统一字段啦
                        if (this._AutoMKOnOff == OnOff.On)
                        {
                            string strSql = string.Format("update Testing_Main set TargetMKCnt={0} where Code='{1}'", iRemain, this._TestCode.Replace("'", "''"));
                            try
                            {
                                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
                            }
                            catch (Exception ex)
                            {
                                this.ShowMsg(ex.Message);
                                return;
                            }
                            this.BindMKPlan();
                        }
                        else if (this._AutoMKOnOff == OnOff.Off)
                        {
                            string strSql = string.Format("update Testing_Main set TargetTuoCnt={0} where Code='{1}'", iRemain, this._TestCode.Replace("'", "''"));
                            try
                            {
                                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
                            }
                            catch (Exception ex)
                            {
                                this.ShowMsg(ex.Message);
                                return;
                            }
                            this.BindTuoPlan();
                        }
                        else
                        {
                            this.ShowMsg("当前还未选择是否启用自动插装。");
                        }
                        ***********************/
                    }
                    else
                    {
                        this.tbPlanCnt.Text = iRemain.ToString();
                    }
                }
            }
        }

        private void tbOrderNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this._OrderNo.Length == 0) return;
            DataM.frmPactDataView frm = new DataM.frmPactDataView(this._OrderNo);
            frm.Show();
        }
        private bool BindPactInfo(string sGuid)
        {
            if (sGuid.Length == 0)
            {
                this.tbOrderNo.Clear();
                this._OrderNo = string.Empty;
                this._PactCode = string.Empty;
                this._FxRatioCode = string.Empty;
                return true;
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandRemoteMES.GetDateTable(string.Format("SELECT PactCode,GUID,MkBOMSpec,ChengPinBOMSpec,FxRatio,FxRatioCode,PlanQty FROM V_Pact_Detail_4AutoAssign WHERE GUID='{0}'", sGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this._OrderNo = string.Empty;
                this._PactCode = string.Empty;
                this.tbOrderNo.Clear();
                this._FxRatioCode = string.Empty;
                this._PlanQty = 0M;
                this.tbPlanTotalQty.Clear();
            }
            else
            {
                DataRow dr = dt.Rows[0];
                this._FxRatioCode = dr["FxRatioCode"].ToString();
                this.tbOrderNo.Text = string.Format("任务单:{0}，收料盒比例:{1}，生产计划:{2}，模块BOM:{3}，成品BOM:{4}", dr["PactCode"], dr["FxRatio"], dr["GUID"], dr["MkBOMSpec"], dr["ChengPinBOMSpec"]);
                this._OrderNo = dr["GUID"].ToString();
                this._PactCode = dr["PactCode"].ToString();
                this._PlanQty = dr["PlanQty"].Equals(DBNull.Value) ? 0M : decimal.Parse(dr["PlanQty"].ToString());
            }
            int iCnt;
            if (string.Compare(this._FxRatioCode, "sys002", true) == 0)
            {
                iCnt = 2;
                this._PlanQty = this._PlanQty * 2M / 3M;
            }
            else
            {
                iCnt = 1;
            }
            this.SavePrintCnt(iCnt);
            this.tbPlanTotalQty.Text = this._PlanQty.ToString("#########0.###");
            return true;
        }
        private void SavePrintCnt(int iCnt)
        {
            //this.tbPrinterCunt.Text = iCnt.ToString();
            this._PrintCunt = iCnt;
            //定义打印张数
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(string.Format("EXEC SavePrintCnt {0}", iCnt));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            SetPrintSettingText();
        }
        private void BindPrintCnt()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT TOP 1 CNT FROM Testing_PrintCnt ORDER BY ID DESC"));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                SavePrintCnt(1);
                return;
            }
            if(dt.Rows.Count==0)
            {
                SavePrintCnt(1);
            }
            else
            {
                if (dt.Rows[0]["CNT"].Equals(DBNull.Value))
                    SavePrintCnt(1);
                else
                {
                    int iCnt = int.Parse(dt.Rows[0]["CNT"].ToString());
                    this.tbPrinterCunt.Text = iCnt.ToString();
                    this._PrintCunt = iCnt;
                    this.SetPrintSettingText();//显示文本
                }
            }
        }
        
        private void 查看当前生产计划详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._OrderNo.Length == 0)
            {
                this.ShowMsg("当前还未导入生产计划。");
                return;
            }
            tbOrderNo_MouseDoubleClick(null, null);
        }
        #endregion
        #region 自动插装相关
        private bool CheckExsistRealMK()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM Assemble_RealMK");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //读取PLC数据
            string strValue;
            string strErr;
            if (!this._MKBuilding._OPCHelperMKBuilding.ReadBatCodes(out strValue, out strErr))
            {
                this.ShowMsg(strErr);
                return false;
            }
            short iFinished;
            if (!this._MKBuilding._OPCHelperMKBuilding.ReadFinished(out iFinished, out strErr))
            {
                this.ShowMsg(strErr);
                return false;
            }
            if(dt.Rows.Count>0 || strValue.Length>0 || iFinished==1)
            {
                MK.frmClearRealMKData frm = new MK.frmClearRealMKData(this.BllDAL, this._MKBuilding);
                frm.BindData(dt, strValue, iFinished);
                if (DialogResult.OK != frm.ShowDialog(this)) return false;
            }
            return true;
        }
        private void _MKBuilding_RefreshMKCodeNoitce(string sMkCode, short iAsbCnt, bool blFinished, short iMKFinishedCnt)
        {
            //自动刷新数据
            if (blFinished)
            {
                //此时已经完成了，则属于最近完成模块了
                if (this.tbFinishedMKCode.Text != sMkCode)
                    this.tbFinishedMKCode.Text = sMkCode;
                if (this.labRealMKAsbCnt.Text != "0")
                    this.labRealMKAsbCnt.Text = "0";
                if (this.tbRealMKCode.Text.Length > 0)
                    this.tbRealMKCode.Clear();
            }
            else
            {
                if (this.tbRealMKCode.Text != sMkCode)
                    this.tbRealMKCode.Text = sMkCode;
                if (this.labRealMKAsbCnt.Text != iAsbCnt.ToString())
                    this.labRealMKAsbCnt.Text = iAsbCnt.ToString();
            }
            if (iMKFinishedCnt >= 0)
            {
                if (this.tbCompeletedCnt.Text != iMKFinishedCnt.ToString())
                    this.tbCompeletedCnt.Text = iMKFinishedCnt.ToString();
            }
        }

        private void linkAutoMKOn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*
            BasicData.frmSelectAutoMKMode frm = new BasicData.frmSelectAutoMKMode();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this._AutoMKOnOff = frm._SelectedType;
            this.SetAutoMKModeControlStyle(this.labAutoMKOn, this._AutoMKOnOff);
            */
        }
        private void SetAutoMKOnOffFromStyle()
        {
            //if(this._AutoMKOnOff==OnOff.On)
            //{
            //    //此时启用插装模块
            //    this.panAboutMK.Visible = true;
            //    this.panAboutMK.Location = new Point(873, 106);
            //    this.panAboutTuoPanCode.Visible = false;
            //    this.linkTuoPanCode1.LinkArea = new LinkArea(0, 0);
            //    this.linkTuoPanCode2.LinkArea = new LinkArea(0, 0);
            //    this.linkPlanCnt.Text = "模块计划数";
            //}
            //else if (this._AutoMKOnOff == OnOff.Off)
            //{
            //    //此时不启用插装模块
            //    this.panAboutMK.Visible = false;
            //    this.panAboutTuoPanCode.Location = new Point(873, 106);
            //    this.panAboutTuoPanCode.Visible = true;
            //    this.linkTuoPanCode1.LinkArea = new LinkArea(0, this.linkTuoPanCode1.Text.Length);
            //    this.linkTuoPanCode2.LinkArea = new LinkArea(0, this.linkTuoPanCode2.Text.Length);
            //    this.linkPlanCnt.Text = "托盘计划数";
            //}
            //else
            //{
            //    //此时未定义
            //    this.panAboutMK.Visible = false;
            //    this.panAboutTuoPanCode.Visible = true;
            //    this.linkPlanCnt.Text = "??计划数";
            //}
        }
        private void SetAutoMKValueByGongYiValue(JPSEnum.GongYiTypes gy)
        {
            /*
            if (gy == JPSEnum.GongYiTypes.Same)
            {
                //同工艺，将自动插装选中
                this._AutoMKOnOff = AotuMkMode.AutoMKOnly;
                this.SetAutoMKModeControlStyle(this.labAutoMKOn, this._AutoMKOnOff);
            }
            else if (gy == JPSEnum.GongYiTypes.Deffrent)
            {
                //多工艺不用开启
                this._AutoMKOnOff = AotuMkMode.All;
                SetAutoMKModeControlStyle(this.labAutoMKOn, this._AutoMKOnOff);
            }*/
        }
        private void SetPrintSettingText()
        {
            //设置打印设置显示
            if (MyPrinter.AutoPrint)
            {
                //string strType;
                //if (this._MainControl == null || this._MainControl._PrinterControl == null)
                //    strType = "NULL";
                //else if (this._MainControl._PrinterControl._PrintType == PrinterControl.PrintTypes.MKCode)
                //    strType = "模块编号";
                //else if (this._MainControl._PrinterControl._PrintType == PrinterControl.PrintTypes.TuoPanCode)
                //    strType = "托盘编号";
                //else strType = "????";
                this.tbPrinterCunt.Text = this._PrintCunt.ToString() + "份标签";//string.Format("{0}份{1}", this._PrintCunt, strType);
            }
            else
            {
                this.tbPrinterCunt.Text = "不打印";
            }
        }
        private void _PrinterControl_PrinterControlerPrintTypeChangedNotice(PrinterControl.PrintTypes oldType, PrinterControl.PrintTypes newType)
        {
            SetPrintSettingText();
        }
        #endregion
        private void 重置设备连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //初始化扫描枪对象
            if (this._MainControl == null)
                _MainControl = new MainControl(this);
            string strErr;
            if (!this._MainControl.Init(out strErr))
            {
                this.ShowErr(strErr);
                if (!JPSConfig.Scaner1_Terminated)
                {
                    if (this._MainControl._ScannControler == null || this._MainControl._ScannControler._Scanner1 == null || this._MainControl._ScannControler._Scanner1._State == JPSEnum.ScannerStates.None)
                        JPSConfig.Scaner1_Terminated = true;
                }
                if (!JPSConfig.Scaner2_Terminated)
                {
                    if (this._MainControl._ScannControler == null || this._MainControl._ScannControler._Scanner2 == null || this._MainControl._ScannControler._Scanner2._State == JPSEnum.ScannerStates.None)
                        JPSConfig.Scaner2_Terminated = true;
                }
            }
            else
            {
                if (this._TestState == TestStates.None)
                {
                    this._TestState = TestStates.Free;
                    this.SetFormStyle();
                }
            }
        }

        private void 虚拟检测结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.frmPLCValue frm = new Debug.frmPLCValue();
            frm.Show();
        }

        private void 结果集读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGetResultLog.ShowMyLog("");
        }
        private void 上传MES数据更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmSendMesLog.ShowMyLog("");
        }

        private void 待传MES数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strTextCode = string.Empty;
            if (this._TestState == TestStates.Pause || this._TestState == TestStates.Testing)
                strTextCode = this._TestCode;
            DataM.frmSendMsgList frm = new DataM.frmSendMsgList(this.tbOrderNo.Text);
            frm.Show();
        }

        private void 继续未完成的测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this._TestCode.Length==0)
            {
                this.ShowMsg("当前没有测试。");
                return;
            }
            DataM.frmTestedData frm = new DataM.frmTestedData(this._TestCode);
            frm.Show();
        }

        private void 历史数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataM.frmTestedList frm = new DataM.frmTestedList();
            frm.Show();
        }

        private void 系统先关频率设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有超级管理员才能设置");
                return;
            }
            Setting.frmSysInterval frm = new Setting.frmSysInterval();
            frm.ShowDialog();
        }

        private void 打印机日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrinterLog.ShowMyLog("");
        }

        private void 托盘条码打印机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Printer.frmPrinterSetting frm = new Printer.frmPrinterSetting();
            //Setting.frmPrinter frm = new Setting.frmPrinter();
            if(DialogResult.OK==frm.ShowDialog())
            {
                
            }
        }

        private void 打印托盘编号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Printer.frmPrinter frm = new Printer.frmPrinter();
            frm.ShowDialog();
        }

        private void 设备通讯设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.IsUserConfirm("你确定要退出吗？")) return;
            Application.Exit();
        }

        private void 手动写入电芯数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.frmWriteIntoPlcBatBools frm = new Debug.frmWriteIntoPlcBatBools(this);
            frm.Show();
        }

        private void 重置扫描枪连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this._MainControl==null)
            {
                this.ShowMsg("");
            }
        }

        private void 清除已经上传MES数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataM.frmSendMesDataClear frm = new DataM.frmSendMesDataClear();
            frm.Show(this);
        }

        private void 扫描枪日志存储方式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.frmScannerLogSendDataBase frm = new Debug.frmScannerLogSendDataBase();
            frm.ShowDialog();
        }

        private void linkPlanCnt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddTuoPlanCnt frm = new frmAddTuoPlanCnt(this._TestCode, this);
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.BindMKPlan();
            //this.tbPlanCnt.Text = frm.ResetCount.ToString();
            //JPSEntity.ResultControler.TuopanPlanCnt = frm.ResetCount;
            //if (this._AutoMKOnOff == OnOff.On)
            //    this.BindMKPlan();
            //else if (this._AutoMKOnOff == OnOff.Off)
            //    this.BindTuoPlan();
        }
        private void 结果读取日志存储方式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.frmResultLogSendDataBase frm = new Debug.frmResultLogSendDataBase();
            frm.ShowDialog(this);
            //JPSEntity.Debug.ScannerOpc.IsDebug = false;
            //string strErr;
            //this._MainControl.Init(out strErr);this.ShowMsg(strErr);
            //this._MainControl._OPCHelperResult.GetResult(out strErr);
            //this.ShowMsg(strErr);

        }

        private void linkCharCheckOn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BasicData.frmSelectOnOff frm = new BasicData.frmSelectOnOff();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this._CharOnOff = frm._SelectedType;
            //SetOnOffControlStyle(this.labCharCheckOnView, this._CharOnOff);
        }

        private void dgvReal1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void 根据托盘号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearData.frmByTuoPanCode frm = new ClearData.frmByTuoPanCode(this._TestCode);
            frm._MainFrom = this;
            frm.Show();
        }

        private void 根据槽号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearData.frmByCaoIndex frm = new ClearData.frmByCaoIndex(this._TestCode);
            frm._MainFrom = this;
            frm.Show();
        }

        private void 拷贝其他设备电芯编号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCopySN.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //执行远程数据拷贝
            if (this._TestState != TestStates.Testing)
            {
                if (this.FormCopySN.Visible)
                    this._RemoteSNCopyControler.Stop();
                else
                    this._RemoteSNCopyControler.Start();
                if (_SendMesControler != null)
                    _SendMesControler.CheckTotalDataIsOver = true;
            }
            else
            {
                this._RemoteSNCopyControler.Stop();
                if (_SendMesControler != null)
                    _SendMesControler.CheckTotalDataIsOver = false;
            }
            //执行数据清除
        }

        private void 电芯数据远程拷贝日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSNCopyLog.ShowMyLog("");
        }

        private void 设置其他设备地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoteMac.frmRemoteMacIP frm = new RemoteMac.frmRemoteMacIP();
            frm.ShowDialog();
        }

        private void linkTuoPanCode1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(this._TestState==TestStates.Testing)
            {
                this.ShowMsg("当前为测试状态不能修改。");
                return;
            }
            if (this._TestState == TestStates.Pause)
            {
                this.ShowMsg("当前不是新建状态，不能修改。");
                return;
            }
            ExpFuns.frmSetTuoPanCode1 frm = new ExpFuns.frmSetTuoPanCode1();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.BindTuoPanCodeInfo();
        }

        private void linkTuoPanCode2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this._TestState == TestStates.Testing)
            {
                this.ShowMsg("当前为测试状态不能修改。");
                return;
            }
            if (this._TestState == TestStates.Pause)
            {
                this.ShowMsg("当前不是新建状态，不能修改。");
                return;
            }
            ExpFuns.frmSetTuoPanCode1 frm = new ExpFuns.frmSetTuoPanCode1();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.BindTuoPanCodeInfo();
        }

        private void 清理数据提高设备运行效率ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpFuns.frmClearSN frm = new ExpFuns.frmClearSN();
            frm.Show();
        }

        private void 系统最大电芯数量超过报警ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpFuns.frmSNCntOverSetting frm = new ExpFuns.frmSNCntOverSetting();
            frm.ShowDialog();
        }

        private void 设备稼动率查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMacJdl.Show();
        }

        private void 清空总电芯数据统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.IsUserConfirm("您确定要清除电芯统计信息吗？")) return;
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql("exec [ExpFuns_RestTotalSnStatistic]");
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            //刷新数据
            if (this._MainControl != null && this._MainControl._StatisticControler != null)
                this._MainControl._StatisticControler.ReadTotalSnStiatistic();
            this.ShowMsg("清理成功");
        }

        private void 导入远程设备的托盘数据仅4号机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(JPSConfig.MacNo!=99)
            {
                this.ShowMsg("该功能仅限4号机。");
                return;
            }
            if(this._TestState!=TestStates.Pause)
            {
                this.ShowMsg("该功能只有在设备暂停时使用。");
                return;
            }
            ExpFuns.frmGetTuoFromRemoteMac frm = new ExpFuns.frmGetTuoFromRemoteMac(this._TestCode);
            if (DialogResult.OK != frm.ShowDialog()) return;
            //此时导入成功，则要重新加载当前数据
            RefreshGroovesData();
        }

        private void 导出MES数据CSV文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpFuns.frmCSV frm = new ExpFuns.frmCSV();
            frm.Show();
        }

        private void 电阻校准值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpFuns.frmCorrect frm = new ExpFuns.frmCorrect();
            frm.ShowDialog(this);
        }

        private void 电压校准值ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 发送打印命令ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpFuns.frmSendPrintCmd frm = new ExpFuns.frmSendPrintCmd(this._MainControl._PrinterControl, this._TestCode);
            frm.ShowDialog(this) ;
        }

        private void linkPrintCnt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExpFuns.frmPrintCnt frm = new ExpFuns.frmPrintCnt();
            if (DialogResult.OK != frm.ShowDialog(this)) return;

            this.SavePrintCnt(frm._Cnt);
        }

        private void 清理电芯数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 自动插装日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            APLog.frmMKBuildingLog.ShowMyLog(this._MKBuilding);
        }

        private void 自动插装ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.frmMKAutomation frm = new Debug.frmMKAutomation(this._MKBuilding._OPCHelperMKBuilding);
            frm.Show(this);
        }

        private void 已完成模块ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataM.frmMKList frm = new DataM.frmMKList();
            frm.Show();
        }

        private void 正在插装的模块ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoAssign.DataM.frmMKBuildingDetail.OpenMKBuildingData();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbOperatorName_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkSwitchMode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BasicData.frmSelectSwitchMode frm = new BasicData.frmSelectSwitchMode();
            if (DialogResult.OK != frm.ShowDialog()) return;
            this.SetSwitchMode(frm._SelectedType);
        }
        private void SetSwitchMode(JPSEnum.SwitchModes? mode)
        {
            this._SwitchMode = mode;
            if (mode == null)
                this.tbSwitchModeView.Text = "";
            else this.tbSwitchModeView.Text = mode.ToString();
        }

        private void btYaCha_Click(object sender, EventArgs e)
        {
            NanJingZB.frmYcEdit frm = new NanJingZB.frmYcEdit();
            frm.ShowDialog();
        }

        private void linkGrooveABSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(this._SwitchMode!=SwitchModes.分AB档)
            {
                this.ShowMsg("当前分档模式不是AB档，无法编辑！");
                return;
            }
            NanJingZB.frmSwitchEdit frm = new NanJingZB.frmSwitchEdit();
            frm.ShowDialog();
        }

        private void btSj_Click(object sender, EventArgs e)
        {
            NanJingZB.frmSj frm = new NanJingZB.frmSj();
            frm.ShowDialog();
        }

        private void 首检记录查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NanJingZB.frmSjList frm = new NanJingZB.frmSjList();
            frm.Show();
        }

        private void 首检调试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NanJingZB.frmNjzbDebug frm = new NanJingZB.frmNjzbDebug();
            frm.Show();
        }
    }
}
