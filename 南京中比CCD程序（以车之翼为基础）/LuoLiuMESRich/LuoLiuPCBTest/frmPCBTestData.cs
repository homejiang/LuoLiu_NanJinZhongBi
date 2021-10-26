using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ErrorService;
using System.IO;
using System.Xml;

namespace LuoLiuPCBTest
{
    public partial class frmPCBTestData :Common.frmProduceBase
    {
        public frmPCBTestData()
        {
            InitializeComponent();
        }
        #region 私有属性
        private Message _meg;
        private Thread _thread = null;
        private delegate void SetCallback();
        private delegate void SetCallback1(string sPath);
        #endregion
        #region 私有变量
        List<string> _delFiles = null;
        DataTable dt = new DataTable("PCB_TestData");
        DataColumn dc3 = new DataColumn("Node3", Type.GetType("System.String"));
        DataColumn dc4 = new DataColumn("Node4", Type.GetType("System.String"));
        DataColumn dc5 = new DataColumn("Nature0", Type.GetType("System.Int16"));
        DataColumn dc6 = new DataColumn("Nature1", Type.GetType("System.Int16"));
        DataColumn dc7 = new DataColumn("Nature2", Type.GetType("System.String"));
        DataColumn dc8 = new DataColumn("Value", Type.GetType("System.Decimal"));
        //private int State = 0;
        private short Quality = 0;
        bool _NeedFind = false;
        bool _blRead = false;//用次标识正在读取中，避免子线程还要继续读取
        private string _delStrPath = string.Empty;
        #endregion
        #region 窗体数据连接实例
        private BLLDAL.PCBProduct _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.PCBProduct BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.PCBProduct();
                return _dal;
            }
        }
        #endregion 
        #region 公有变量
        public int _TableN = 0;
        public string _GUID = string.Empty;
        #endregion
        #region 函数功能
        private bool Perinit()
        {
            this.ClearData();
            //设置标题信息
            this.dgHisRecord.AutoGenerateColumns = false;
            this.ucTitle1.Process = PCBConfig.ProcessName;
            this.ucTitle1.Mac = PCBConfig.MacName;
            this.ucTitle1.Station = PCBConfig.StationName;
            this.BindOperator();
            this.BindTitle();
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
            dt.Columns.Add(dc8);
            #region 开启子线程
            this._NeedFind = true;
            try
            {
                _thread = new Thread(new ThreadStart(Doing));
                _thread.IsBackground = true;//标记为后台线程，进入托管状态，此窗体内不对该线程进行结束操作了
                _thread.Start();
            }
            catch (Exception ex)
            {
                 SendMessage(ex.Message);
                return false;
            }
            #endregion
            //当前窗体创建获取当前数据库参数表
            CreateTable();
            return true;
        }
        private void ShowForm()
        {
            if (!this.Visible) this.Show();
            else this.Activate();
        }
        private string GetValue(object obj, int iType)
        {
            //iType:1为数值型，2为时间，其它用不上
            if (iType == 1)
            {
                if (obj == null || obj.ToString() == "") return "NULL";
                return obj.ToString();
            }
            else if (iType == 2)
            {
                if (obj == null || obj.ToString() == "") return "NULL";
                DateTime det;
                if (!DateTime.TryParse(obj.ToString(), out det))
                    return "null";
                return string.Format("'{0}'", det.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            
            return "null";
        }
        private void SetResult(short iValue)
        {
            Color cB, cF;
            string strText;
            if (iValue == 1)
            {
                cB = Color.Lime;
                cF = Color.Black;
                strText = "合格";
            }
            else if (iValue == 2)
            {
                cB = Color.Red;
                cF = Color.White;
                strText = "不合格";
            }
            else
            {
                cB = Color.White;
                cF = Color.Black;
                strText = "------";
            }
            if (this.labResult.Text != strText)
                this.labResult.Text = strText;
            if (this.labResult.ForeColor != cF)
                this.labResult.ForeColor = cF;
            if (this.labResult.BackColor != cB)
                this.labResult.BackColor = cB;
        }
        #endregion
        #region 加载数据
        private bool BindOperator()
        {
            string strText = string.Empty;
            if (Common.CurrentUserInfo.UserCode.Length > 0)
            {
                strText = Common.CurrentUserInfo.UserName;
            }
            else strText = "已注销";
            if (this.ucTitle1.Operator != strText)
                this.ucTitle1.Operator = strText;
            return true;
        }
        public void BindTitle()
        {
            this.ucTitle1.Process = PCBConfig.ProcessName;
            this.ucTitle1.Station = PCBConfig.StationName;
            this.ucTitle1.Mac = PCBConfig.MacName;
        }
        private bool BindHistory()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM V_PCB_TestData_Cgy WHERE PcbCode='{0}'", this.tbPcbCode.Text.ToString().Replace("'", "''")), "PCB_TestData", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgHisRecord.DataSource = ds.Tables["PCB_TestData"];
            this.label10.Text = "当前保护板：" + this.tbPcbCode.Text.ToString().Replace("\r", "").Replace("\n", "") + "的历史检测记录(F2刷新)";
            return true;
        }
        #endregion
        #region 控件按钮
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.ShowForm();
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowForm();
        }
       
        private void tsbMsfForm_Click(object sender, EventArgs e)
        {
            Common.frmMyLog.ShowMyLog("");
        }
        private void btRemark_Click(object sender, EventArgs e)
        {
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.Update_PCBTestDataRemark(this._GUID,this.tbRemark.Text.ToString(), out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                SendMessage(ex.Message);
                return ;
            }
            this.ShowMsg("更新成功");
            this.Close();
            return ;
        }
        private void 设置测试文件存储路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmResultFile frm = new frmResultFile();
            frm.TopMost = true;
            frm.ShowDialog(this);
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DisposeHotKey();
            Application.Exit();
        }
        private void 历史记录查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LuoLiuPCBTest.frmPCBTestDataList frm = new LuoLiuPCBTest.frmPCBTestDataList();
            frm.Text = "历史保护板检测记录";
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void 设备异常单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (listPower.Count == 0)
            {
                this.ShowMsg("你没有此模块的任何权限，如有需要请联系管理员开放相应权限。");
                return;
            }
            BasicData.ProcessMacs.frmMBdownList frm = new BasicData.ProcessMacs.frmMBdownList();
            frm.DefaultProcess = PCBConfig.ProcessCode;
            frm.DefaultMac = PCBConfig.MacCode;
            frm.Text = "设备异常登记列表";
            frm.TopMost = true;
            frm.ShowDialog();
           
            
            //this.ShowChildForm(frm.Text, frm);
        }
        private void 当前工作站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStationConfig frm = new frmStationConfig(true);
            frm.TopMost = true;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.ucTitle1.Process = PCBConfig.ProcessName;
            this.ucTitle1.Mac = PCBConfig.MacName;
            this.ucTitle1.Station = PCBConfig.StationName;
        }

        private void 清空窗口数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ClearData();
        }

        private void 终止结果读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._blRead)
            {
                this._blRead = false;
            }
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.CurrentUserInfo.Logout();
            this.BindOperator();

            this.ShowMsgRich("注销成功");
        }

        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Login.frmLogin frmlogin1 = new Common.Login.frmLogin();
            if (DialogResult.OK != frmlogin1.ShowDialog(this))
                return;
            this.BindOperator();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Login.frmModifyPwd frm = new Common.Login.frmModifyPwd();
            frm.UserCode = Common.CurrentUserInfo.UserCode;
            frm.ShowDialog(this);
        }
        #endregion
        #region 窗体加载
        private void PCBTestData_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("保护板测试 Version:{0}", Version.GetVersion());
            Perinit();
            this.WndProc(ref this._meg);
            Common.CommonFuns.Hotkey.Regist(this.Handle, Common.CommonFuns.HotkeyModifiers.None, Keys.F1, new Common.CommonFuns.Hotkey.HotKeyCallBackHanlder(this.HotKeyPupForm));
            Common.CommonFuns.Hotkey.Regist(this.Handle, Common.CommonFuns.HotkeyModifiers.None, Keys.F2, new Common.CommonFuns.Hotkey.HotKeyCallBackHanlder(this.HotKeyPupForm_F2));
            this.KeyPreview = true;//让窗体最先获取按键事件
        }
        
        #endregion
        #region 捕捉windows快捷按钮设置
        //处理接收的消息
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            Common.CommonFuns.Hotkey.ProcessHotKey(m);
        }
        /*此处事件都由委托调用*/
        //弹出窗口
        private void HotKeyPupForm()
        {
            //如果窗口是显示的则，需要隐藏，否则显示窗口
            if (!this.Visible || this.WindowState == FormWindowState.Minimized)
                this.ShowForm();//只显示窗体
            else
                this.Close();
        }
        private void HotKeyPupForm_F2()
        {
           if(this.Visible)
            {
                if (BindHistory())
                    this.ShowMsgRich("刷新成功");
            }
        }
        //注销热键
        private void DisposeHotKey()
        {
            Common.CommonFuns.Hotkey.UnRegist(this.Handle, this.HotKeyPupForm);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!e.Cancel)
            {
                //本程序不直接退出，隐藏再后台
                this.Hide();
                //当程序没有在读取文件时，程序隐藏清空界面数据
                if (!this._blRead) this.ClearData();
                e.Cancel = true;
            }
            base.OnClosing(e);
        }
        #endregion
        #region 读取数据
        private void SendMessage(string sMsg)
        {
            try
            {
                SetCallback1 cb = new SetCallback1(ShowMessage);
                this.Invoke(cb, new object[1] { sMsg });
            }
            catch (Exception ex)
            {
                 SendMessage(ex.Message);
                return;
            }
        }
        private void ShowMessage(string sMsg)
        {
            //this.richTextBox1.AppendText(sMsg + "\r\n");
        }
        private void Doing()
        {
            while (true)
            {
                //SendMessage("comming");
                Thread.Sleep(100);
                if (!_NeedFind) continue;
                //SendMessage("NeedFind");
                if (_blRead) continue;//此时主线程正在读取数据
                //窗体显示时不进行采集
                
                //SendMessage("un read");
                //if (_dr == null)
                //    _dr = new DirectoryInfo(Common.CommonDAL.ResultDir);
                //Directory.GetFiles(
                string strPath;
                strPath = PCBConfig.ResultDir;
                FileInfo fileInfo = new FileInfo(strPath);
                if (!System.IO.Directory.Exists(PCBConfig.ResultDir))
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        this.ShowMsg(" 路径“" + strPath + "”不存在，请点击系统设置->设置测试文件存储路径重新设置文件路径，并关闭程序重新打开进行采集！");

                    }));
                    return;
                }
                #region 获取路径下的所有子文件夹和文件
                string[] files = Directory.GetDirectories(strPath, "*");
                DateTime det = DateTime.Parse("1900-1-1 00:00"); //可能创建文件夹的时间比子文件夹的时间晚，所以初始时间设定一个早的固定时间
                string strLastFileName = fileInfo.Name;
                TimeSpan ts;
                FileInfo fileInfoTemp;
                foreach (string str in files)
                {
                    fileInfoTemp = new FileInfo(str);
                    ts = fileInfoTemp.LastWriteTime - det;

                    //获取最后的时间和文件
                    if (ts.TotalSeconds > 0)
                    {
                        det = fileInfoTemp.LastWriteTime;
                        strLastFileName = fileInfoTemp.Name;
                    }

                }
                if (!strPath.EndsWith("\\"))
                      strPath += "\\";
                strPath = strPath + strLastFileName;
                _delStrPath = strPath;
                #endregion
                #region 根据子文件夹下面获取最新的xlm文件
                files = Directory.GetFiles(strPath, "*.xml");
                det = DateTime.Parse("1900-1-1 00:00");//可能创建文件夹的时间比文件的时间晚，所以初始时间设定一个早的固定时间
                strLastFileName = fileInfo.Name;
                TimeSpan tsfile;
                FileInfo fileInfoTempNext;
                foreach (string str in files)
                {
                    fileInfoTempNext = new FileInfo(str);
                    tsfile = fileInfoTempNext.LastWriteTime - det;

                    //获取最后的时间和文件
                    if (tsfile.TotalSeconds > 0)
                    {
                        det = fileInfoTempNext.LastWriteTime;
                        strLastFileName = fileInfoTempNext.Name;
                    }

                }
                if (!strPath.EndsWith("\\"))
                    strPath += "\\";
                #endregion
                string[] filess = Directory.GetFiles(strPath, strLastFileName);
                //SendMessage("filescount=" + files.Length.ToString());
                if (filess.Length == 0) continue;
                //当文件被占用时
                if (this.IsFileInUse(filess[0])) continue;
                //此时已经找到，则立即显示窗体，
                try
                {
                    SetCallback cb = new SetCallback(ShowForm);
                    this.Invoke(cb);
                }
                catch (Exception ex)
                {
                    SendMessage(ex.Message);
                    continue;
                }
                Thread.Sleep(100);
                try
                {
                    SetCallback1 cb1 = new SetCallback1(ReadData);
                    this.Invoke(cb1, new object[1] { filess[0] });
                }
                catch (Exception ex)
                {
                    SendMessage(ex.Message);
                    continue;
                }
                
            }
        }
        private void ReadData(string sFile)
        {
            if(this.MyReadData(sFile))
            {
               if(PCBConfig.AutoComposing.Auto && PCBConfig.AutoComposing.DelaySeconds>0)
                {
                    //此时实现自动隐藏
                    this.ucAutoSaveTimerShow1.Start(PCBConfig.AutoComposing.DelaySeconds);
                }
            }
        }
        private bool MyReadData(string sFile)
        {
            _blRead = true;
            dt.Rows.Clear();
            //解析xlm文件
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(sFile);
            }
            catch (Exception ex)
            {
                Exception ex1 = new Exception(ex.Message + "\r\n XML:" + sFile);
                wErrorMessage.ShowErrorDialog(null, ex1);
                _blRead = false;
                return false;
            }
            if (doc == null)
            {
                _blRead = false;
                return false;
            }
            XmlElement root = null;
            root = doc.DocumentElement;
            XmlNodeList listNodes = null;
            //获取主表信息
            listNodes = doc.GetElementsByTagName("Record"); //= root.SelectNodes("//@Begin | //@LotNumber | //@Model | //@Result | //@End | //MPT_Data/Record//CellCount/* | //MPT_Data/Record//Barcode/* | //MPT_Data/Record//SpendTime/*");
            if (listNodes.Count == 0)
            {
                _blRead = false;
                return false;
            }
            for (int i = 0; i < listNodes.Count; i++)
            {
                this.tbStartTime.Text =listNodes[0].Attributes[0].InnerText.ToString();
                this.tbLobNumber.Text = listNodes[0].Attributes[2].InnerText.ToString();
                this.tbModel.Text = listNodes[0].Attributes[3].InnerText.ToString();
                this.labResult.Text = listNodes[0].Attributes[4].InnerText.ToString();
                this.tbEndTime.Text = listNodes[0].Attributes[5].InnerText.ToString();
            }
            if (this.labResult.Text.ToString() == "Pass")
            {
                //State = 1;
                Quality = 1;
                this.SetResult(Quality);
            }
            else
            {
                //State = 0;
                Quality = 2;
                this.SetResult(Quality);
            }
            listNodes = doc.GetElementsByTagName("CellCount");
            this.tbCellCount.Text = listNodes[0].InnerText.ToString();
            listNodes = doc.GetElementsByTagName("Barcode");
            this.tbPcbCode.Text = listNodes[0].InnerText.ToString();
            listNodes = doc.GetElementsByTagName("SpendTime");
            this.tbSpendTime.Text = listNodes[0].InnerText.ToString();
            //获取明细表
            listNodes = root.SelectNodes("//MPT_Data/Record/Data/*");
            foreach (XmlElement element in listNodes)
            {
                //解析只有一个特性节点
                if (element.Attributes.Count == 1 && element.Name != "Balance")
                {
                    DataRow dr = dt.NewRow();
                    dr["Node3"] = element.Name;
                    dr["Nature2"] = element.Attributes[0].InnerText;
                    dr["Value"] = element.InnerText;
                    dt.Rows.Add(dr);
                }
             }
            listNodes = root.SelectNodes("//Cons/*  | //ODD/*  | //OCR/*  | //ODR/*  | //ConsStandby/*  | //OC/*  | //FOCD/*  | //OD/*  | //FODD/*  | //ALLOCD/*  | //ALLOC/*  | //ALLODD/*  | //ALLOD/*");
            foreach (XmlElement element in listNodes)
            {
                //解析只有Cons个特性节点
                DataRow dr = dt.NewRow();
                dr["Node3"] = element.ParentNode.Name;
                dr["Nature1"] = element.Attributes[0].InnerText;
                dr["Nature2"] = element.Attributes[1].InnerText;
                dr["Value"] = element.InnerText.Replace("uA", "").Trim();
                dt.Rows.Add(dr);

            }
            listNodes = root.SelectNodes("//BLV/* | //BLC/*");
            foreach (XmlElement element in listNodes)
            {
                //解析Balance
                DataRow dr = dt.NewRow();
                dr["Node3"] = element.ParentNode.ParentNode.Name;
                dr["Node4"] = element.ParentNode.Name;
                dr["Nature0"] = element.ParentNode.ParentNode.Attributes[0].InnerText;
                dr["Nature1"] = element.Attributes[0].InnerText;
                dr["Nature2"] = element.Attributes[1].InnerText;
                dr["Value"] = element.InnerText.Trim();
                dt.Rows.Add(dr);

            }

            if (!this.DataSendMES(sFile))
            {
                this.ShowMsg("发送MES数据失败！");
                _blRead = false;
            }
            //移除文件
            Thread.Sleep(200);
            foreach (string file in Directory.GetFiles(_delStrPath, "*.xml"))
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    if (_delFiles == null) _delFiles = new List<string>();
                    _delFiles.Add(file);
                }
            }
            _blRead = false;
            return true;
        }
        //判断文件是否被占用
        public bool IsFileInUse(string sFile)
        {
            string vFileName = sFile;
            bool inUse = true;
            StreamWriter kf_total_SW = null;
            try
            {
                kf_total_SW = new StreamWriter(vFileName, true);
                inUse = false;
            }
            catch(Exception ex)
            {
                 SendMessage(ex.Message);
                return true;
            }
            finally
            {
                if (kf_total_SW != null)

                    kf_total_SW.Close();
            }
            return inUse;//true表示正在使用,false没有使用
        }
        //将数据发送到MES
        public bool DataSendMES(string sFile)
        {

            try
            {
                Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC [PCB_TestStateUpdate_Cgy] '{0}'", this.tbPcbCode.Text.ToString().Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this._GUID = GetGUID();
            //将数据插入到参数表
            List<string> listSql = new List<string>();
            //将数据插入到主表
            string strSql1 = string.Format("INSERT INTO PCB_TestData(GUID,PcbCode,CellCount,StartTime,EndTime,LotNumber,Model,SpendTime,Quality,State,Operator,OperatorName,MacCode,StationCode,ActiveTable) " +
                "VALUES('{0}','{1}',{2},'{3}','{4}','{5}','{6}',{7},{8},{9},'{10}','{11}','{12}','{13}','{14}')",
                this._GUID, this.tbPcbCode.Text.ToString(), GetValue(this.tbCellCount.Text.ToString(), 1), this.tbStartTime.Text.ToString(), this.tbEndTime.Text.ToString(), this.tbLobNumber.Text.ToString(), this.tbModel.Text.ToString(),
               GetValue(this.tbSpendTime.Text.ToString(), 1), Quality, 1, Common.CurrentUserInfo.UserCode, Common.CurrentUserInfo.UserName, PCBConfig.MacCode, PCBConfig.StationCode, "LuoLiuMESDynamicTable.dbo.Mac_PCB_Parameters_"+this._TableN.ToString());
            listSql.Add(strSql1);
            string strFormat = "INSERT INTO LuoLiuMESDynamicTable.dbo.Mac_PCB_Parameters_{0}(GUID,Node0,Node1,Node2,Node3,Node4,Nature0,Nature1,Nature2,Value,Times)" +
            "VALUES('{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},'{9}',{10},'{11}')";
            foreach (DataRow dr in dt.Rows)
            {
                listSql.Add(string.Format(strFormat,this._TableN, this._GUID, "MPT_Data", "Record", "Data", dr["Node3"],dr["Node4"], 
                   GetValue(dr["Nature0"],1), GetValue(dr["Nature1"], 1), dr["Nature2"],GetValue(dr["Value"],1), this.tbEndTime.Text.ToString()));
            }
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(listSql);
            }
            catch (Exception ex)
            {
                SendMessage(ex.Message);
                return false;
            }
            this.BindHistory();
            ////将XML文件转化为二进制数据流到服务器
            //byte[] buffer = File.ReadAllBytes(sFile);
         
            return true;
        }
        //清除界面数据
        private void ClearData()
        {
            this.ucAutoSaveTimerShow1.Stop();
            this.CreateTable();
            this.SetResult(0);
            this._GUID = string.Empty;
            this.tbPcbCode.Text = string.Empty;
            this.tbSpendTime.Text = string.Empty;
            this.tbStartTime.Text = string.Empty;
            this.tbEndTime.Text = string.Empty;
            this.tbCellCount.Text = string.Empty;
            this.tbModel.Text = string.Empty;
            this.labResult.Text = string.Empty;
            this.tbRemark.Text = string.Empty;
            this.tbLobNumber.Text = string.Empty;
           // State = 0;
            Quality = 0;
            dt.Rows.Clear();
            return;
        }
        //创建参数表
        private bool CreateTable()
        {
            int iReturnValue;
            string strMsg;
            int N = 0;
            try
            {
                this.BllDAL.Get_PCBActiveTable(out N, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
               SendMessage(ex.Message);
                return false;
            }
            this._TableN = N;
            return true;
        }
        #endregion
        #region 自动隐藏相关
        private void ucAutoSaveTimerShow1_AutoSaveTimerStopNotice()
        {
            this.Close();
        }
        #endregion
        private void 软件版本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 自动隐藏设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySetting.frmAutoComposing frm = new MySetting.frmAutoComposing();
            frm.TopMost = true;
            frm.ShowDialog();
        }

        private void tbRemark_MouseClick(object sender, MouseEventArgs e)
        {
            this.ucAutoSaveTimerShow1.Stop();
        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 联系管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 关于我们ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void linkSelRemark_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ucAutoSaveTimerShow1.Stop();
            //选择备注模板
        }
    }
}
