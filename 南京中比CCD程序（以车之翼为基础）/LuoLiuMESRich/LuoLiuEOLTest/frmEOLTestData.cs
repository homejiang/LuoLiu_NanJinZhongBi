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
using System.Reflection;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace LuoLiuEOLTest
{
    public partial class frmEOLTestData :Common.frmProduceBase
    {
        public frmEOLTestData()
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
        private short Quality = 0;
        bool _NeedFind = false;
        bool _blRead = false;//用次标识正在读取中，避免子线程还要继续读取
        private string _delStrPath = string.Empty;
        DataTable dtItem = new DataTable();
        DataTable dtResult = new DataTable();
        DataColumn dc1 = new DataColumn("Item", Type.GetType("System.String"));
        DataColumn dc2 = new DataColumn("StateView", Type.GetType("System.String"));
        DataColumn dc3 = new DataColumn("Result", Type.GetType("System.String"));

        DataColumn dc4 = new DataColumn("Item", Type.GetType("System.String"));
        DataColumn dc5 = new DataColumn("MinValue", Type.GetType("System.String"));
        DataColumn dc6 = new DataColumn("MaxValue", Type.GetType("System.String"));
        DataColumn dc7 = new DataColumn("ItemUnit", Type.GetType("System.String"));
        DataColumn dc8 = new DataColumn("ResultValue", Type.GetType("System.String"));
        DataColumn dc9 = new DataColumn("Result", Type.GetType("System.String"));
        string strNextFileName = string.Empty;
        DateTime det = DateTime.Parse("1900-1-1 00:00");
        string strNextPath = string.Empty;
        private  int SFGType=0;
        #endregion
        #region 窗体数据连接实例
        private BLLDAL.EOLProduct _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.EOLProduct BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.EOLProduct();
                return _dal;
            }
        }
        #endregion 
        #region 公有变量
        public int _TableNItem = 0;
        public int _TableNReslut = 0;
        public string _GUID = string.Empty;
        #endregion
        #region 函数功能
        private bool Perinit()
        {
            this.ClearData();
            //设置标题信息
            // this.dgHisRecord.AutoGenerateColumns = false;
            this.dgItemList.AutoGenerateColumns = false;
            this.dgResultList.AutoGenerateColumns = false;
            dtResult.Columns.Add(dc1);
            dtResult.Columns.Add(dc2);
            dtResult.Columns.Add(dc3);
            dtItem.Columns.Add(dc4);
            dtItem.Columns.Add(dc5);
            dtItem.Columns.Add(dc6);
            dtItem.Columns.Add(dc7);
            dtItem.Columns.Add(dc8);
            dtItem.Columns.Add(dc9);
            this.ucTitle1.Process = EOLConfig.ProcessName;
            this.ucTitle1.Mac = EOLConfig.MacName;
            this.ucTitle1.Station = EOLConfig.StationName;
            this.BindOperator();
            this.BindTitle();
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
        /// <summary>
        ///递归获取指定类型文件,包含子文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <param name="extName"></param>
        private  void Getdir(string path, string extName)
        {
           try
            {
                string[] dir = Directory.GetDirectories(path); //文件夹列表   
                DirectoryInfo fdir = new DirectoryInfo(path);
                FileInfo[] file = fdir.GetFiles();
                TimeSpan tsfile;
                if (file.Length != 0 ) //当前目录文件或文件夹不为空                   
                {
                    foreach (FileInfo f in file)//显示当前目录所有文件   
                    {
                        if (extName.ToLower().IndexOf(f.Extension.ToLower()) >= 0)
                        {
                            tsfile = f.LastWriteTime - det;
                            //获取最后的时间和文件
                            if (tsfile.TotalSeconds > 0)
                            {
                                det = f.LastWriteTime;
                                strNextFileName = f.Name;
                                strNextPath = path;
                            }
                        }
                    }
                   
                }
                if (dir.Length != 0)
                {
                    foreach (string d in dir)
                    {
                        Getdir(d, extName);//递归   
                    }
                }
              
            }
            catch (Exception ex)
            {
                SendMessage(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        ///递归获取指定类型文件,包含子文件夹删除文件夹下文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="extName"></param>
        private void Deletedir(string path)
        {
            try
            {
                string[] dir = Directory.GetDirectories(path); //文件夹列表   
                foreach (string file in Directory.GetFiles(path,"*.xls"))
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
                 
                if (dir.Length != 0)
                {
                    foreach (string d in dir)
                    {
                        Deletedir(d);//递归   
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
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
            this.ucTitle1.Process = EOLConfig.ProcessName;
            this.ucTitle1.Station = EOLConfig.StationName;
            this.ucTitle1.Mac = EOLConfig.MacName;
        }
        private bool BindHistory()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM V_PCB_TestData_Cgy WHERE EOLCode='{0}'", this.tbEOLCode.Text.ToString().Replace("'", "''")), "EOL_TestData", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //this.dgHisRecord.DataSource = ds.Tables["EOL_TestData"];
            //this.label10.Text = "当前保护板：" + this.tbEOLCode.Text.ToString().Replace("\r", "").Replace("\n", "") + "的历史检测记录(F2刷新)";
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
                this.BllDAL.Update_EOLTestDataRemark(this._GUID,this.tbRemark.Text.ToString(), out iReturnValue, out strMsg);
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
            LuoLiuEOLTest.frmEOLTestDataList frm = new LuoLiuEOLTest.frmEOLTestDataList();
            frm.Text = "历史EOL检测记录";
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
            frm.DefaultProcess = EOLConfig.ProcessCode;
            frm.DefaultMac = EOLConfig.MacCode;
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
            this.ucTitle1.Process = EOLConfig.ProcessName;
            this.ucTitle1.Mac = EOLConfig.MacName;
            this.ucTitle1.Station = EOLConfig.StationName;
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
        private void EOLTestData_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("EOL测试 Version:{0}", Version.GetVersion());
            Perinit();
            this.WndProc(ref this._meg);
            Common.CommonFuns.Hotkey.Regist(this.Handle, Common.CommonFuns.HotkeyModifiers.None, Keys.F1, new Common.CommonFuns.Hotkey.HotKeyCallBackHanlder(this.HotKeyPupForm));
            //Common.CommonFuns.Hotkey.Regist(this.Handle, Common.CommonFuns.HotkeyModifiers.None, Keys.F2, new Common.CommonFuns.Hotkey.HotKeyCallBackHanlder(this.HotKeyPupForm_F2));
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
                //ActiveMianForm.SendF2ToPro();
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
                strPath = EOLConfig.ResultDir;
                FileInfo fileInfo = new FileInfo(strPath);
                if (!System.IO.Directory.Exists(EOLConfig.ResultDir))
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        this.ShowMsg(" 路径“" + strPath + "”不存在，请点击系统设置->设置测试文件存储路径重新设置文件路径，并关闭程序重新打开进行采集！");

                    }));
                    return;
                }
         
                #region 根据子文件夹下面获取最新的EXCEL文件
                //strNextFileName = string.Empty;
                //strNextPath = string.Empty;
                //det = DateTime.Parse("1900-1-1 00:00");
                //this.Getdir(strPath, ".xls");
                #endregion
                #region 查找最新文件
                string[] files = Directory.GetFiles(strPath, "*.xls");
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
                        strNextFileName = fileInfoTemp.Name;
                    }

                }
                if (!strPath.EndsWith("\\"))
                    strPath += "\\";
                _delStrPath = strPath;
                #endregion
                string[] filess = Directory.GetFiles(strPath, strNextFileName);
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
               if(EOLConfig.AutoComposing.Auto && EOLConfig.AutoComposing.DelaySeconds>0)
                {
                    //此时实现自动隐藏
                    this.ucAutoSaveTimerShow1.Start(EOLConfig.AutoComposing.DelaySeconds);
                   // ActiveMianForm.SendF2ToPro();
                }
            }
        }
        private bool MyReadData(string sFile)
        {
            _blRead = true;
            #region 分解EXCEL文件名
            string[] arr = strNextFileName.Split('_');
            if (arr.Length > 1)
            {
                this.tbEndTime.Text = det.ToString();
                string[] arr1 = arr[3].ToString().Split('.');
                if (arr1.Length > 1)
                    this.labResult.Text = arr1[0].ToString();
                if (this.labResult.Text.ToString().Trim() == "OK")
                {
                    Quality = 1;
                    SetResult(Quality);
                }
                else
                {
                    Quality = 2;
                    SetResult(Quality);
                }
                this.tbEOLCode.Text = arr[1];
            }
            #endregion
            DataTable dt = null;
            dt = ExcelToDT(sFile);
            int icount=0;
            #region 处理数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i][0].ToString() == "项目List")
                {
                    icount = i;
                    break;
                }
            }
            for (int i = 0; i < icount-1; i++)
            {
                DataRow dr = dtResult.NewRow();
                 arr = dt.Rows[i][0].ToString().Split('.');
                if (arr.Length > 1)
                {
                    dr["Item"] = arr[1];
                }
                else
                {
                    dr["Item"] = dt.Rows[i][0].ToString();
                }
                
                dr["StateView"] = dt.Rows[i][1].ToString();
                dr["Result"] = dt.Rows[i][2].ToString();
                dtResult.Rows.Add(dr);
            }
            for (int i = icount+1; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtItem.NewRow();
                dr["Item"] = dt.Rows[i][0].ToString();
                dr["MinValue"] = dt.Rows[i][1].ToString();
                dr["MaxValue"] = dt.Rows[i][2].ToString();
                dr["ItemUnit"] = dt.Rows[i][3].ToString();
                dr["ResultValue"] =dt.Rows[i][4].ToString();
                dr["Result"] = dt.Rows[i][5].ToString();
                dtItem.Rows.Add(dr);
            }
            this.dgResultList.DataSource = dtResult;
            this.dgItemList.DataSource = dtItem;
            #endregion
            #region 校验是否存在半成品
            //无论校验是否成功，数据还是会上传到数据库并将错误记录在备注中
            if (!this.DataCheckMES(this.tbEOLCode.Text.ToString()))
            {

                this._GUID = this.GetGUID();
                //只保存一下保护板测试记录，避免文件误删
                if (!this.DataSendMES(sFile))
                {
                    this.ShowMsg("MES上传数据失败");
                }
                Thread.Sleep(200);
                foreach (string file in Directory.GetFiles(_delStrPath, "*.xls"))
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
            
            #endregion
            #region 根据编号改信息
            //根据编号判断类别
            if (SFGType==1)
            {   
                //模组编号
                //SFGType = 1;
                this.label1.Text = "模组编号";
                this.labSFGType.Text = "模组测试";


            }
            else
            {

                //电池包编号
               // SFGType = 2;
                this.label1.Text = "电池包编号";
                this.labSFGType.Text = "电池包测试";
            }
            #endregion
            //获取GUID
            this.MESOutGuid();
            if (!this.DataSendMES(sFile))
            {
                this.ShowMsg("MES上传数据失败");
                _blRead = false;
            }
            //移除文件
            Thread.Sleep(200);
            foreach (string file in Directory.GetFiles(_delStrPath,"*.xls"))
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
        //EXCEL转DataTable
        private DataTable ExcelToDT(string sPath)
        {
            DataTable dt = new DataTable();
            string filePath = sPath;
            string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'", filePath);
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                string firstSheetName = sheetsName.Rows[0][2].ToString();
                string strExcel = string.Format("SELECT * FROM [{0}]", firstSheetName);
                //string strExcel = "select * from [sheet1$]";
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn);
                myCommand.Fill(dt);
            }
            return dt;
        }
        //判断文件是否被占用
        private bool IsFileInUse(string sFile)
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
        private bool DataCheckMES(string sCode)
        {
            DataTable dt = null;
            //首先通过保护板编号去获取半成品编号
            //if (SFGType == 1)
            //{
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Process_GetSFGInfo_EOL_Cgy '{0}'"
                       , sCode.ToString().Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    SendMessage(ex.Message);
                    return false;
                }
                if (dt.Columns.Contains("ErrMsg"))
                {
                    //此时有错误，当前工序加载失败
                    this.tbRemark.Text = dt.Rows[0]["ErrMsg"].ToString();
                    this.ShowMsgRich1("未过上工序生产");
                    return false;
                }
                if (dt.Rows.Count == 0)
                {
                    this.ShowMsg("基础信息加载失败！");
                    return false;
                }
                DataRow dr = dt.Rows[0];
                SFGType =int.Parse(dr["SFGType"].ToString());
                this.PcbCode.Text= dr["SFGCode"].ToString();
                this.myPactView.Text = dr["PactMessage"].ToString();
                this.myBOM.Text = dr["BOMMessage"].ToString();
                return true;
            //}
            //else if(SFGType==2)
            //{
            //    try
            //    {
            //        dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Process3_GetSFGInfo_Cgy '{0}'"
            //           , this.tbEOLCode.Text.ToString().Replace("'", "''")));
            //    }
            //    catch (Exception ex)
            //    {
            //        SendMessage(ex.Message);
            //        return false;
            //    }
            //    if (dt.Columns.Contains("ErrMsg"))
            //    {
            //        //此时有错误，当前工序加载失败
            //        this.tbRemark.Text = dt.Rows[0]["ErrMsg"].ToString();
            //        this.ShowMsg(dt.Rows[0]["ErrMsg"].ToString());
            //        return false;
            //    }
            //    if (dt.Rows.Count == 0)
            //    {
            //        this.ShowMsg("基础信息加载失败！");
            //        return false;
            //    }
            //    DataRow dr = dt.Rows[0];
            //   // this.myCode.Text = dr["SFGCode"].ToString();
            //    this.myPactView.Text = dr["PactMessage"].ToString();
            //    this.myBOM.Text = dr["BOMMessage"].ToString();
            //    return true;

            //}
            //else
            //{
            //    return false;
            //}
            
        }
        private bool MESOutGuid()
        {
            int iReturnValue;
            string strMsg;
            string sGuid;
            if (SFGType == 1)
            {

                
                try
                {
                    this.BllDAL.CompeletedProcess(this.tbEOLCode.Text.ToString(), EOLConfig.ProcessCode, EOLConfig.MacCode, EOLConfig.StationCode, Quality, DBNull.Value, DateTime.Now, out sGuid, out iReturnValue, out strMsg);
                }
                catch (Exception ex)
                {
                    SendMessage(ex.Message);
                    return false;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg == string.Empty) strMsg = "创建工序任务失败，请退出检查原因";
                    this.ShowMsgRich1(strMsg);
                    return false;
                }
                this._GUID = sGuid;
                return true;
            }
            else if (SFGType == 2)
            {
                try
                {
                    this.BllDAL.CompeletedProcessPack(this.tbEOLCode.Text.ToString(), EOLConfig.ProcessCode, EOLConfig.MacCode, EOLConfig.StationCode, Quality, DBNull.Value, DateTime.Now, out sGuid, out iReturnValue, out strMsg);
                }
                catch (Exception ex)
                {
                    SendMessage(ex.Message);
                    return false;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg == string.Empty) strMsg = "创建工序任务失败，请退出检查原因";
                    this.ShowMsg(strMsg);
                    return false;
                }
                this._GUID = sGuid;
                return true;
            }
            else
            {
                strMsg = "创建工序任务，检查EXCEL采集编号是否有问题，请退出检查原因";
                return false;

            }
        }
        private bool DataSendMES(string sFile)
        {
            try
            {
                Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC [EOL_TestStateUpdate_Cgy] '{0}',{1}", this.tbEOLCode.Text.ToString().Replace("'", "''"), SFGType));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = null;
            //将数据插入到参数表
            List<string> listSql = new List<string>();
            string strSql1 = string.Format("INSERT INTO EOL_TestData(GUID,Code,PcbCode,StateTime,Operator,OperatorName,MacCode,StationCode,ActiveTableItem,ActiveTableResult,Quality,Remark,SFGType,State) " +
                "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},'{11}',{12},{13})",
                this._GUID, this.tbEOLCode.Text.ToString(), this.PcbCode.Text.ToString(), this.tbEndTime.Text.ToString(),
                Common.CurrentUserInfo.UserCode, Common.CurrentUserInfo.UserName, EOLConfig.MacCode, EOLConfig.StationCode,
                "LuoLiuMESDynamicTable.dbo.Mac_EOLItem_Parameters_" + this._TableNItem.ToString(), "LuoLiuMESDynamicTable.dbo.Mac_EOLResult_Parameters_" + this._TableNReslut.ToString(), Quality, this.tbRemark.Text.ToString(), SFGType,1);
            listSql.Add(strSql1);
            dt = this.dgItemList.DataSource as DataTable;
            //将数据检测参数明细表
            string strFormat = "INSERT INTO LuoLiuMESDynamicTable.dbo.Mac_EOLItem_Parameters_{0}(GUID,P1,P2,P3,P4,P5,P6,Times)" +
            "VALUES('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')";
            foreach (DataRow dr in dt.Rows)
            {
                listSql.Add(string.Format(strFormat, this._TableNItem, this._GUID, dr["Item"].ToString(), dr["MinValue"].ToString(),
                  dr["MaxValue"].ToString(), dr["ItemUnit"].ToString(), dr["ResultValue"].ToString(), dr["Result"].ToString(), this.tbEndTime.Text.ToString()));
            }
            dt = this.dgResultList.DataSource as DataTable;
            //将数据检测结果明细表
            strFormat = "INSERT INTO LuoLiuMESDynamicTable.dbo.Mac_EOLResult_Parameters_{0}(GUID,P1,P2,P3,Times)" +
            "VALUES('{1}','{2}','{3}','{4}','{5}')";
            foreach (DataRow dr in dt.Rows)
            {
                listSql.Add(string.Format(strFormat, this._TableNReslut, this._GUID, dr["Item"].ToString(), dr["StateView"].ToString(), dr["Result"].ToString(), this.tbEndTime.Text.ToString()));
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
            return true;

        }
        //清除界面数据
        private void ClearData()
        {
            this.ucAutoSaveTimerShow1.Stop();
            this.CreateTableItem();
            this.CreateTableResult();
            this.SetResult(0);
            this.tbEOLCode.Text = string.Empty;
            this.tbEndTime.Text = string.Empty;
            this.labResult.Text = string.Empty;
            this.tbRemark.Text = string.Empty;
            this.myBOM.Text = string.Empty;
            this.PcbCode.Text= string.Empty;
            this.myPactView.Text = string.Empty;
            this._GUID = string.Empty;
            Quality = 0;
            SFGType = 0;
            //this.label1.Text = "保护板编号";
            //this.label7.Visible = true;
            //this.myCode.Visible = true;
            //this.tbEOLCode.Width = 202;
            dtResult.Rows.Clear();
            dtItem.Rows.Clear();
            strNextFileName = string.Empty;
            det = DateTime.Parse("1900-1-1 00:00");
            return;
        }
        //创建参数表
        private bool CreateTableItem()
        {
            int iReturnValue;
            string strMsg;
            int N = 0;
            try
            {
                this.BllDAL.Get_EOLItemActiveTable(out N, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
               SendMessage(ex.Message);
                return false;
            }
            this._TableNItem = N;
            return true;
        }
        private bool CreateTableResult()
        {
            int iReturnValue;
            string strMsg;
            int N = 0;
            try
            {
                this.BllDAL.Get_EOLResultActiveTable(out N, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                SendMessage(ex.Message);
                return false;
            }
            this._TableNReslut = N;
            return true;
        }
        #endregion
        #region 自动隐藏相关
        private void ucAutoSaveTimerShow1_AutoSaveTimerStopNotice()
        {
            this.Close();
        }
        #endregion
        #region 工具栏
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
        #endregion
        #region DataView显示
        private void dgResultList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            for (int i = 0; i < dgResultList.Rows.Count; i++)
            {
                if (dgResultList[2, i].Value.ToString() != string.Empty&& dgResultList[2, i].Value.ToString()!="OK")
                {
                     dgResultList[2, i].Style.BackColor = Color.Red;
                }
            }
        }

        private void dgItemList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dgItemList.Rows.Count; i++)
            {
                if (dgItemList[5, i].Value.ToString() != string.Empty && dgItemList[5, i].Value.ToString() != "OK")
                {
                    dgItemList[5, i].Style.BackColor = Color.Red;
                }
            }
        }
        #endregion
      
        public class ActiveMianForm
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern void SetForegroundWindow(IntPtr hwnd);
            [DllImport("user32.dll")]
            public static extern void SetFocus(IntPtr hwnd);
            [DllImport("user32.dll")]
            public static extern IntPtr FindWindow(String classname, String title);
            [DllImport("user32.dll", EntryPoint = "keybd_event")]
            public static extern void keybd_event(
                byte bVk,
                byte bScan,
                int dwFlags,
                int dwExtraInfo
            );
            public static void SendF2ToPro()
            {
                IntPtr hwnd1 = FindWindow(null, "瑞能 动力GGC V3.01 (2019-07024)");
                if (hwnd1 != (IntPtr)0)
                    SetFocus(hwnd1);
                SetForegroundWindow(hwnd1);
            }
            public static void SetTab1()
            {
                keybd_event(0x12, 0, 0, 0);
                keybd_event(0x09, 0, 0, 0);
                keybd_event(0x12, 0, 0x2, 0);
                keybd_event(0x09, 0, 0x2, 0);

            }

        }
    }
}
