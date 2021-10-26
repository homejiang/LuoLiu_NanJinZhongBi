using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorService;
using LuoLiuMES.MESConfig;

namespace LuoLiuMES.Boxing
{
    public partial class frmBoxing : Common.frmBase
    {
        const string C_PleaseInputItemCode = "InputItemCode";
        #region 窗体数据连接实例
        private BLLDAL.Boxing _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Boxing BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Boxing();
                return _dal;
            }
        }
        #endregion
        public frmBoxing()
        {
            InitializeComponent();
            this._Printer = new BoxPrinter();
            this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
            //初始化窗口数据
            this.labMyWeight.Text = string.Empty;
            this.labQty.Text = string.Empty;
            this.ucAutoSaveTimerShow1.Stop();
        }
        #region 窗口字段
        public string _Code = string.Empty;
        /// <summary>
        /// 可以装托数量
        /// </summary>
        private int _PlanQty = 0;
        /// <summary>
        /// 已经装托数量
        /// </summary>
        private int _BoxedQty = 0;
        /// <summary>
        /// 已装托的电池包净重，单位：kg
        /// </summary>
        private decimal _NetWeight = 0M;
        /// <summary>
        /// 纸箱类型代码
        /// </summary>
        private string _BoxType = string.Empty;
        /// <summary>
        /// 纸箱重量，单位：kg
        /// </summary>
        private decimal _BoxWeight = 0M;
        private string _BOMGuid = string.Empty;
        private string _MyType = string.Empty;
        private int _MyYear = 0;
        /// <summary>
        /// 指定的任务单号
        /// </summary>
        private string _PactDetailGuid = string.Empty;
        private string _Client = string.Empty;
        #endregion
        #region 重写函数
        public override void AcitiveTimer_Doing(object Arg)
        {
            if (Arg == null) return;
            if (string.Compare(Arg.ToString(), C_PleaseInputItemCode, true) == 0)
            {
                this.tbMyCode.Focus();
                this.tbMyCode.SelectAll();
            }
        }
        #endregion
        #region 公共函数
        public void RefreshBoxedCount(string sItemCode,string sBoxCode, int iBoxed,decimal decNetWeight)
        {
            if (string.Compare(this._Code, sBoxCode, true) != 0) return;
            this._BoxedQty = iBoxed;
            this._NetWeight = decNetWeight;
            this.SetBoxedStyle();
            this.AddRemoveLog(sItemCode);
        }
        #endregion
        #region 处理函数
        private bool BindData()
        {
            if (this.Binding())
            {
                this.BindPactInfo(this._PactDetailGuid);
                this.BindBoxType(this._BoxType);
                this.BindMyTypes(this._BOMGuid, this._MyType, this._MyYear);
                this.BindClient(this._Client);
                if (!panButtons.Enabled)
                    panButtons.Enabled = true;
                return true;
            }
            else
            {
                if (panButtons.Enabled)
                    panButtons.Enabled = false;
                return false;
            }
        }
        private bool Binding()
        {
            //记载已创建的箱号
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM V_Boxing_Box WHERE Code='{0}'", this._Code.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                this.ShowErr(ex.Message);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowErr("传入的托盘编号\"" + this._Code + "\"不存在或已经被删除了。");
                return false;
            }
            DataRow dr = dt.Rows[0];
            this.tbCode.Text = dr["Code"].ToString();
            this.tbBoxType.Text = dr["TypeName"].ToString();
            this.tbOperator.Text = dr["UserName"].ToString();
            #region 读取已经装托的电池包
            DataTable dtCnt;
            try
            {
                dtCnt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format(@"SELECT  COUNT(*) AS CNT,SUM(C.StructValue) AS TotalWeight
                FROM Boxing_Detail A LEFT JOIN Produce_SFG3 B ON B.Code = A.ItemCode
                LEFT JOIN BOM_Product_Structure C ON C.ProGuid = B.BOMGuid AND C.StructGuid = 'PerKg'
                WHERE A.Code = '{0}'", this._Code.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                this.ShowErr(ex.Message);
                return false;
            }
            this._BoxedQty = int.Parse(dtCnt.Rows[0]["CNT"].ToString());
            this._NetWeight = dtCnt.Rows[0]["TotalWeight"].Equals(DBNull.Value) ? 0M : decimal.Parse(dtCnt.Rows[0]["TotalWeight"].ToString());
            #endregion
            this._BoxType = dr["BoxType"].ToString();
            this._PlanQty = dr["Qty"].Equals(DBNull.Value) ? 0 : int.Parse(dr["Qty"].ToString());
            this._BOMGuid = dr["BOMGuid"].ToString();
            this._MyType = dr["MyType"].ToString();
            this._MyYear = dr["MyYear"].Equals(DBNull.Value) ? 0 : int.Parse(dr["MyYear"].ToString());
            this._PactDetailGuid = dr["PactDetail"].ToString();
            this._Client = dr["Client"].ToString();
            return true;
        }
        private bool CreateNewBox()
        {
            this._Code = string.Empty;
            this.tbOperator.Text = Common.CurrentUserInfo.UserName;
            //加载新的箱号
            this.tbCode.Text = this.GetAutoCode(Common.MyEnums.Modules.Boxing);
            this._BoxedQty = 0;//已装托数量清空
            this._NetWeight = 0M;
            this.tbOperator.Text = Common.CurrentUserInfo.UserName;
            if (_BoxType.Length==0 && MESConfig.BoxingConfig.DefaultBoxType.Length>0)
            {
                //这里不用判断是否加载正确，出错了也不要紧的
                BindBoxType(MESConfig.BoxingConfig.DefaultBoxType);
            }
            this.SetBoxedStyle();
            this.SetFormStyle();
            if (this.tbCode.Text.Length > 0)
                this.AddMyLog(string.Format("生成了新的托盘编号:{0}", this.tbCode.Text));
            return true;
        }

        private bool BindPactInfo(string sPactDetail)
        {
            if (sPactDetail.Length > 0)
            {
                DataTable dt;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT dbo.Boxing_GetPactInfo('{0}')", sPactDetail.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    this.ShowErr(ex.Message);
                    return false;
                }
                this.tbPactInfo.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                this.tbPactInfo.Clear();
            }
            if (this._PactDetailGuid != sPactDetail)
                this._PactDetailGuid = sPactDetail;
            return true;
        }
        private bool BindBoxType(string sBoxType)
        {
            DataTable dt;
            try
            {
                dt=Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM JC_BoxType WHERE Code='{0}'", sBoxType.Replace("'", "''")));
            }
            catch(Exception ex)
            {
                this.ShowErr(ex.Message);
                return false;
            }
            if(dt.Rows.Count==0)
            {
                this.ShowErr("传入的托盘类型\"" + sBoxType + "\"无效。");
                return false;
            }
            DataRow dr = dt.Rows[0];
            int iQty;
            if(!int.TryParse(dr["Qty"].ToString(),out iQty))
            {
                this.ShowMsg("当前托盘允许安装数量未定义！");
                return false;
            }
            this._PlanQty = iQty;
            this._BoxType = dr["Code"].ToString();
            this._BoxWeight = dr["MyWeight"].Equals(DBNull.Value) ? 0M : decimal.Parse(dr["MyWeight"].ToString());
            this.tbBoxType.Text = dr["TypeName"].ToString();
            return true;
        }
        private bool BindMyTypes(string sBom,string sMyType,int iMyYear)
        {
            DataTable dt;
            string sSpec = string.Empty;
            string sVersion = string.Empty;
            string sMyTypeName = string.Empty;
            if (sBom.Length > 0)
            {
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT A.Spec,B.VersionNo FROM BOM_Product A LEFT JOIN BOM_Sys_Version B ON B.ID=A.VersionID WHERE A.GUID='{0}'", sBom.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    this.ShowErr(ex.Message);
                    return false;
                }
                if (dt.Rows.Count == 0)
                {
                    this.ShowErr("传入的BOM结构标识不存在或已经被删除！");
                    return false;
                }
                DataRow dr = dt.Rows[0];
                sSpec = dr["Spec"].ToString();
                sVersion = dr["VersionNo"].ToString();
            }
            if (sMyType.Length > 0)
            {
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT CodeName FROM JC_PackTypeCode where Code='{0}'", sMyType.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    this.ShowErr(ex.Message);
                    return false;
                }
                if (dt.Rows.Count == 0)
                {
                    this.ShowErr("传入的产品类型不存在或已经被删除！");
                    return false;
                }
                DataRow dr = dt.Rows[0];
                sMyTypeName = dr["CodeName"].ToString();
            }
            string strText = string.Empty;
            if (sMyTypeName.Length > 0 || iMyYear > 0)
            {
                strText = "电池组类型：" + (sMyTypeName.Length == 0 ? "?" : sMyTypeName) + (iMyYear > 0 ? iMyYear.ToString() : "?");
            }
            if(sSpec.Length>0)
            {
                if (strText.Length > 0) strText += "，";
                strText += string.Format("{0}，版本号:{1}", sSpec, sVersion);
            }
            //组合起来
            this.tbBOMSpec.Text = strText;
            this._BOMGuid = sBom;
            this._MyType = sMyType;
            this._MyYear = iMyYear;
            return true;
        }
        private bool BindClient(string sClient)
        {
            if (sClient.Length > 0)
            {
                DataTable dt;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select Code,VirCode from JC_Client WHERE Code='{0}'", sClient.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    this.ShowErr(ex.Message);
                    return false;
                }
                if (dt.Rows.Count == 0)
                {
                    this.ShowErr("传入的客户代码\"" + sClient + "\"无效。");
                    return false;
                }
                DataRow dr = dt.Rows[0];

                this._Client = dr["Code"].ToString();
                this.tbClient.Text = dr["VirCode"].ToString();
            }
            else
            {
                this._Client = string.Empty;
                this.tbClient.Clear();
            }
            return true;
        }
        private void SetBoxedStyle()
        {
            //int iBoxed;
            //if (this._Code.Length == 0)
            //    iBoxed = 0;
            //else iBoxed = this._BoxedQty;
            //设置样式
            this.labQty.Text = string.Format("{0}/{1}", this._BoxedQty, this._PlanQty);
            this.labMyWeight.Text = string.Format("净重:{0}kg，毛重:{1}kg", this._NetWeight.ToString("#########0.###"), (this._NetWeight + this._BoxWeight).ToString("#########0.###"));
        }
        private void SetFormStyle()
        {
            //如果拖号确认的情况下，都是不能修改的额
            bool blReadonly = this._Code.Length > 0;
            if (this.tbCode.ReadOnly != blReadonly)
                this.tbCode.ReadOnly = blReadonly;
            if(blReadonly)
            {
                if (this.linkBOM.LinkArea.Length > 0)
                    this.linkBOM.LinkArea = new LinkArea(0, 0);
                if (this.linkBoxType.LinkArea.Length > 0)
                    this.linkBoxType.LinkArea = new LinkArea(0, 0);
                if (this.linkPact.LinkArea.Length > 0)
                    this.linkPact.LinkArea = new LinkArea(0, 0);
                if (this.linkClient.LinkArea.Length > 0)
                    this.linkClient.LinkArea = new LinkArea(0, 0);
            }
            else
            {
                if (this.linkBOM.LinkArea.Length == 0)
                    this.linkBOM.LinkArea = new LinkArea(0, this.linkBOM.Text.Length);
                if (this.linkBoxType.LinkArea.Length == 0)
                    this.linkBoxType.LinkArea = new LinkArea(0, this.linkBoxType.Text.Length);
                if (this.linkPact.LinkArea.Length == 0)
                    this.linkPact.LinkArea = new LinkArea(0, this.linkPact.Text.Length);
                if (this.linkClient.LinkArea.Length == 0)
                    this.linkClient.LinkArea = new LinkArea(0, this.linkClient.Text.Length);
            }
            if(this._PactDetailGuid.Length>0)
            {
                //如果已经有任务单了，则不用再去选择规格之类的，当然选了也是无效的，所以这里禁用掉，以免浪费操作员去执行操作。
                if (this.linkBOM.LinkArea.Length > 0)
                    this.linkBOM.LinkArea = new LinkArea(0, 0);
                if (this.linkClient.LinkArea.Length > 0)
                    this.linkClient.LinkArea = new LinkArea(0, 0);
            }
            else
            {
                if (this.linkBOM.LinkArea.Length > 0)
                    this.linkBOM.LinkArea = new LinkArea(0, this.linkBOM.Text.Length);
                if (this.linkClient.LinkArea.Length > 0)
                    this.linkClient.LinkArea = new LinkArea(0, this.linkClient.Text.Length);
            }
        }
        private void ClearFormData()
        {
            if(CreateNewBox())
            {
                if (this.tbCode.Text.Length > 0)
                    this.ShowMsgRich("新的托盘");
            }
        }
        #endregion
        #region 消息处理
        private void ShowErr(string sMsg)
        {
            frmBoxingErrMsg frm = new frmBoxingErrMsg();
            frm._Msg = sMsg;
            frm.ShowDialog(this);
        }
        private void PlayOK()
        {
            Common.CommonFuns.PlayOkMsg();
        }
        private void PlayFaild(string sAudio)
        {
            Common.CommonFuns.PlayErrMsg();
        }
        private void AddLog(string sCode)
        {
            //this.tbLog.Text = "电池包：" + sCode + "添加成功！->"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\r\n" + this.tbLog.Text;
            AddMyLog("电池包：" + sCode + "添加成功！");
        }
        private void AddRemoveLog(string sCode)
        {
            //this.tbLog.Text = "电池包：" + sCode + "移除成功！->" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + this.tbLog.Text;
            AddMyLog("电池包：" + sCode + "移除成功！");
        }
        private void AddMyLog(string sMsg)
        {
            this.tbLog.Text = sMsg + "->" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + this.tbLog.Text;
        }
        private void PlayCompeleted()
        {
            //完成提醒
        }
        #endregion
        #region 保存数据
        private bool Add(out bool blCompeleted, out string sErr, out string sAudio)
        {
            sErr = "";
            sAudio = string.Empty;
            blCompeleted = false;
            if (this._Code.Length == 0)
            {
                //此时要保存一下
                if (!this.SaveBox(out sErr, out sAudio))
                {
                    return false;
                }
                //此时成功了，需要加载一下
                if (!this.BindData())
                {
                    sAudio = "托盘信息加载失败！";
                    return false;
                }
                this.SetBoxedStyle();
                this.SetFormStyle();
            }
            if (this._Code.Length == 0)
            {
                sErr = "当前托盘创建失败！";
                sAudio = "托盘创建失败";
                return false;
            }
            //此时已经成功将第一盘和托盘号绑定
            int iReturnValue;
            string strMsg;
            int iCnt;
            decimal decNet;
            try
            {
                this.BllDAL.AddItem(this._Code, this.tbMyCode.Text, out iCnt, out decNet, out blCompeleted, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
                sAudio = "装托失败";
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "装托失败，原因未知。";
                sErr = strMsg;
                sAudio = "装托失败";
                return false;
            }
            //此时成功了
            this._BoxedQty = iCnt;
            this._NetWeight = decNet;
            return true;
        }
        private bool SaveBox(out string sErr, out string sAudio)
        {
            sAudio = "托盘创建失败";
            //此函数用于存储纸箱编号
            if (this.tbCode.Text.Length==0)
            {
                sErr = "托盘编号不能为空，托盘创建失败！";
                sAudio = "托盘编号不能为空";
                return false;
            }
            if (this._BoxType.Length == 0)
            {
                sErr = "托盘类型不能为空，托盘创建失败！";
                sAudio = "托盘类型不能为空";
                return false;
            }
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.CreateBox(this.tbCode.Text, this._BoxType, this._PactDetailGuid, this._BOMGuid, this._MyType, this._MyYear,this._Client, out iReturnValue, out strMsg);
            }
            catch(Exception ex)
            {
                sErr = string.Format("创建托盘出错：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            if(iReturnValue!=1)
            {
                if (strMsg.Length == 0)
                    strMsg = "托盘创建失败，原因未知！";
                sErr = strMsg;
                return false;
            }
            this._Code = this.tbCode.Text;
            sErr = "";
            sAudio = "";
            return true;
        }

        private void tbMyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
            {
                btAdd_Click(null, null);
            }
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (this.tbMyCode.Text.Length == 0) return;
            if (this.tbCode.Text.Length == 0)
            {
                this.ShowErr("请先输入托盘号！");
                return;
            }
            string strErr;
            string strAudio;
            bool blCompeleted;
            if (!this.Add(out blCompeleted, out strErr, out strAudio))
            {
                this.PlayFaild(strAudio);
                this.ShowErr(strErr);
                this.AcitiveTimer(300, C_PleaseInputItemCode);
            }
            else
            {
                this.PlayOK();
                this.AddLog(this.tbMyCode.Text);
                this.SetBoxedStyle();
                this.tbMyCode.Clear();
                this.AcitiveTimer(200, C_PleaseInputItemCode);
                //此时导入成功
                if (blCompeleted)
                {
                    //此时完成了
                    this.PlayCompeleted();
                    if (BoxPrinter.AutoPrint)
                    {
                        //自动打印
                        AutoPrinting(this._Code);
                    }
                }
            }
        }
        private bool CompeleteBoxing()
        {
            //完成本这次装托
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.Compeleted(this._Code, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "托盘创建失败，原因未知！";
                this.ShowMsg(strMsg);
                return false;
            }
            return true;
        }
        #endregion
        #region 打印
        BoxPrinter _Printer = null;
        private void _Printer_PrintFinishedNotice(string sTuoPanCode, bool blSucessful, string sErr, string sArg)
        {
            BoxPrinter.PrintFinishedCallback call = new BoxPrinter.PrintFinishedCallback(PrinterNotice);
            try
            {
                this.Invoke(call, new object[] { sTuoPanCode, blSucessful, sErr, sArg });
            }
            catch (Exception ex)
            {

            }
        }
        private void PrinterNotice(string sTuoPanCode, bool blSucessful, string sErr,string sArg)
        {
            if (blSucessful)
            {
                this.ShowMsgRich("标签已打印");
                if (string.Compare(sArg, "auto", true) == 0)
                {
                    if (BoxingConfig.AutoComposing.Auto && BoxingConfig.AutoComposing.DelaySeconds > 0)
                    {
                        this.ucAutoSaveTimerShow1.Start(BoxingConfig.AutoComposing.DelaySeconds);
                    }
                    else
                    {
                        this.ClearFormData();
                        this.AcitiveTimer(200, C_PleaseInputItemCode);
                    }
                }
            }
            else
            {
                //此时要弹出重新打印的对话框
                frmPrintFaild frm = new frmPrintFaild(sTuoPanCode, sErr);
                frm.ShowDialog(this);
            }
        }
        private bool AutoPrinting(string sCode)
        {
            //本函数只限自动打印调用
            this._Printer.Printing(sCode, "auto");
            return true;
        }

        private void ucAutoSaveTimerShow1_AutoSaveTimerStopNotice()
        {
            this.ClearFormData();
        }
        #endregion
        private void frmBoxing_Load(object sender, EventArgs e)
        {
            if (this._Code.Length > 0)
            {
                this.BindData();
            }
            else
            {
                this.CreateNewBox();
            }
            this.SetBoxedStyle();
            this.SetFormStyle();
        }

        

        private void btCompeleted_Click(object sender, EventArgs e)
        {
            if (this.ucAutoSaveTimerShow1.IsActive())
            {
                this.ClearFormData();
                this.ucAutoSaveTimerShow1.Stop();
            }
            //强制结束，检查是否
            if (this._Code.Length>0)
            {
                if(this._BoxedQty<this._PlanQty)
                {
                    if (!this.IsUserConfirm("当前托盘还未装托完成，您确定结束本次装托吗？")) return;
                }
                int iReturnValue;
                string strMsg;
                try
                {
                    this.BllDAL.Compeleted(this._Code,out iReturnValue, out strMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return ;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg.Length == 0)
                        strMsg = "托盘创建失败，原因未知！";
                    this.ShowMsg(strMsg);
                    return;
                }
                this._Printer.Printing(this._Code);
                this.ClearFormData();
            }
        }

        private void btPrinterSetting_Click(object sender, EventArgs e)
        {
            Boxing.frmPrinterSetting frm = new Boxing.frmPrinterSetting();
            if (DialogResult.OK == frm.ShowDialog())
            {

            }
        }

        private void linkBoxType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSelectBoxType frm = new frmSelectBoxType();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData.Count == 0) return;
            this.tbBoxType.Text = frm.SelectedData[0].TypeName.ToString();
            this._BoxType = frm.SelectedData[0].Code.ToString();
            this._PlanQty = frm.SelectedData[0].Qty.Equals(DBNull.Value) ? 0 : int.Parse(frm.SelectedData[0].Qty.ToString());
            this._BoxWeight = frm.SelectedData[0].MyWeight.Equals(DBNull.Value) ? 0M : decimal.Parse(frm.SelectedData[0].MyWeight.ToString());
            this.SetBoxedStyle();
        }

        private void linkPact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSelectPact frm = new frmSelectPact();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData.Count == 0) return;
            this.BindPactInfo(frm.SelectedData[0].DetailGuid.ToString());
            SetFormStyle();
        }

        private void linkBOM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSelectBOM frm = new frmSelectBOM();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.BindMyTypes(frm._BOMGuid, frm._MyType, frm._MyYear);
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            frmRemoveItem frm = new frmRemoveItem(this._Code, this);
            frm.ShowDialog(this);
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if(this._Code.Length==0)
            {
                if(this.tbCode.Text.Length>0)
                {
                    this.ShowMsg("当前箱号还未创建，只有导入过电池包后才会创建箱号。");
                    return;
                }
                return;
            }
            //调用打印
            this._Printer.Printing(this._Code);
        }

        private void btViewDetail_Click(object sender, EventArgs e)
        {
            if (this._Code.Length == 0)
            {
                return;
            }
            frmItemDetail frm = new frmItemDetail(this._Code);
            frm.ShowDialog(this);
        }

        private void linkClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BasicData.Client.frmSelectClient frm = new BasicData.Client.frmSelectClient();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData == null || frm.SelectedData.Count == 0) return;
            this.BindClient(frm.SelectedData[0].Code.ToString());
        }
    }
    
}
