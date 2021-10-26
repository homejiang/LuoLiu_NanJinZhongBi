using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;

namespace BasicData.ProcessMacs
{
    public partial class frmMBdownEdit : frmBase
    {
        public frmMBdownEdit()
        {
            InitializeComponent();
        }
        #region  系统常量
        const string BTCompletedText = "维修完成";
        const string BTCancelCompletedText = "撤销维修完成";
        const string BTStartText = "开始维修";
        const string BTCancelStartText = "撤销开始维修";
        #endregion
        #region 窗体数据连接实例
        private BLLDAL.MacBreakdown _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.MacBreakdown BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.MacBreakdown();
                return _dal;
            }
        }
        #endregion
        #region 公共属性
        /// <summary>
        /// 设备所属工序
        /// </summary>
        public string ProcessCode = string.Empty;
        /// <summary>
        /// 异常机台
        /// </summary>
        public string MacCode = string.Empty;
        /// <summary>
        /// 标示窗体已经更新过了，父窗体需要刷新数据
        /// </summary>
        public bool Updated = false;
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            if (this.ProcessCode.Length > 0)
            {
                DataTable dt;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code,MacName FROM JC_ProcessMacs WHERE ProcessCode='{0}' ORDER BY SortID", this.ProcessCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                this.comMac.DisplayMember = "Text";
                this.comMac.ValueMember = "Value";
                int iSelIndex = -1;
                foreach (DataRow dr in dt.Rows)
                {
                    if(string.Compare(dr["Code"].ToString(),this.MacCode,true)==0)
                        iSelIndex = comMac.Items.Add(new Common.MyEntity.ComboBoxItem(dr["MacName"].ToString(), dr["Code"].ToString()));
                    else comMac.Items.Add(new Common.MyEntity.ComboBoxItem(dr["MacName"].ToString(), dr["Code"].ToString()));
                }
                this.comMac.SelectedIndex = iSelIndex;
                this.linkProcess.Enabled = false;
            }
            this.comMac.Enabled = this.MacCode.Length == 0;
            this.dgvDetail.AutoGenerateColumns = false;
            this.Text = string.Format("设备异常内容编辑  登陆人：{0}", Common.CurrentUserInfo.UserName);
            //设置是否停机下拉框
            this.comMacTerminated.DisplayMember = "Text";
            this.comMacTerminated.ValueMember = "Value";
            this.comMacTerminated.Items.Add(new Common.MyEntity.ComboBoxItem("选择是否停机", 0));
            this.comMacTerminated.Items.Add(new Common.MyEntity.ComboBoxItem("停机维修", 1));
            this.comMacTerminated.Items.Add(new Common.MyEntity.ComboBoxItem("正常运行", 2));
            comMacTerminated.SelectedIndex = 0;
            return true;
        }
        private bool BindData(string strCode)
        {
            DataSet ds=null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM JC_MacBreakdown WHERE Code='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_MacBreakdown", true));
            strSql = "SELECT * FROM V_JC_MacBreakdownDetail WHERE MBCode='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_MacBreakdownDetail", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            ds.Tables["JC_MacBreakdownDetail"].Columns["ID"].AutoIncrement = true;
            DataTable dt = ds.Tables["JC_MacBreakdown"];
            if (dt.DefaultView.Count == 0)
            {
                if (strCode.Length > 0)
                {
                    this.ShowMsg("异常单\"" + strCode + "\"不存在或已经被删除。");
                    return false;
                }
                #region 新增一行数据
                DataRow drNew = dt.NewRow();
                string strMasSign = Common.CommonFuns.GetMacSign(this.MacCode);
                if (strMasSign == string.Empty) strMasSign = "00";
                strMasSign += "-";
                drNew["Code"] = this.GetAutoCode(Common.MyEnums.Modules.MacBreakdown, strMasSign);
                drNew["Operator"] = Common.CurrentUserInfo.UserCode;
                drNew["OperatorName"] = Common.CurrentUserInfo.UserName;
                DateTime detSer;
                if (!Common.CommonFuns.GetSysCurrentDateTime(out detSer))
                    return false;
                drNew["OperateTime"] = detSer;
                drNew["StartTime"] = detSer;
                if(this.MacCode.Length>0)
                    drNew["MacCode"] = this.MacCode;
                dt.Rows.Add(drNew);
                #endregion
            }
            //绑定数据
            DataRow dr = dt.DefaultView[0].Row;
            this.tbCode.Text = dr["Code"].ToString();
            this.tbStartTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["StartTime"], "yyyy-MM-dd HH:mm");
            this.tbStartTime1.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["ProcessTime"], "yyyy-MM-dd HH:mm");//开始维修时间
            this.tbEndTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["EndTime"], "yyyy-MM-dd HH:mm");
            this.tbOperator.Text = dr["OperatorName"].ToString();
            this.tbProUserNames.Text = dr["ProUserNames"].ToString();
            if (!dr["MacTerminated"].Equals(DBNull.Value))
            {
                int iMacTerminated;
                if (!dr["MacTerminated"].Equals(DBNull.Value) && (bool)dr["MacTerminated"])
                    iMacTerminated = 1;
                else iMacTerminated = 2;
                Common.CommonFuns.FormatData.SetComboBoxText(this.comMacTerminated, new Common.MyEntity.ComboBoxItem("", iMacTerminated), 0);
            }
            Common.CommonFuns.FormatData.SetComboBoxText(this.comMac, new Common.MyEntity.ComboBoxItem("", dr["MacCode"].ToString()), 0);
            this.tbRemark.Text = dr["Remark"].ToString();
            //绑定工序，因表中不包含工序信息
            DataTable dtTemp;
            if (this.ProcessCode.Length > 0)
            {
                #region 通过工序加载工序名称
                try
                {
                    dtTemp = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT ProcessName FROM JC_Process WHERE Code='{0}'", this.ProcessCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count == 0)
                {
                    this.ShowMsg("工序代码\"" + this.ProcessCode + "\"不存在或已经被删除。");
                    return false;
                }
                this.tbProcessName.Text = dtTemp.Rows[0]["ProcessName"].ToString();
                #endregion
            }
            else if (dr["MacCode"].ToString().Length > 0)
            {
                #region 通过机台号加载工序名称
                try
                {
                    dtTemp = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code,ProcessName FROM JC_Process WHERE Code=(SELECT ProcessCode FROM JC_ProcessMacs WHERE Code='{0}')", dr["MacCode"].ToString().Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count == 0)
                {
                    this.ShowMsg("设备编码\"" + dr["MacCode"].ToString() + "\"不存在或已经被删除。");
                    return false;
                }
                this.tbProcessName.Text = dtTemp.Rows[0]["ProcessName"].ToString();
                this.ProcessCode = dtTemp.Rows[0]["Code"].ToString();
                if (this.comMac.Items.Count == 0)
                {
                    #region 如果设备机台下拉菜单未加载，则在这里加载
                    DataTable dtMac;
                    try
                    {
                        dtMac = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code,MacName FROM JC_ProcessMacs WHERE ProcessCode='{0}' ORDER BY SortID", this.ProcessCode.Replace("'", "''")));
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return false;
                    }
                    this.comMac.DisplayMember = "Text";
                    this.comMac.ValueMember = "Value";
                    int iSelIndex = -1;
                    foreach (DataRow drMac in dtMac.Rows)
                    {
                        if (string.Compare(drMac["Code"].ToString(), dr["MacCode"].ToString(), true) == 0)
                            iSelIndex = comMac.Items.Add(new Common.MyEntity.ComboBoxItem(drMac["MacName"].ToString(), drMac["Code"].ToString()));
                        else comMac.Items.Add(new Common.MyEntity.ComboBoxItem(drMac["MacName"].ToString(), drMac["Code"].ToString()));
                    }
                    this.comMac.SelectedIndex = iSelIndex;
                    #endregion
                }
                #endregion
            }
            else this.tbProcessName.Clear();
            this.tbLog.Text = dr["weixiuLog"].ToString();
            if (dr["LogUserCode"].ToString().Length > 0)
                this.labLogUserName.Text = string.Format("填写人:{0}", dr["LogUserName"].ToString());
            this.dgvDetail.DataSource = ds.Tables["JC_MacBreakdownDetail"];
            this.DataSource = ds;
            this.SetFormState(strCode.Length == 0, !dr["EndTime"].Equals(DBNull.Value));
            return true;
        }
        private void SetFormState(bool isNew,bool isCompeted)
        {
            bool blForm = this.FormState == Common.MyEnums.FormStates.New || this.FormState == Common.MyEnums.FormStates.Edit;
            bool blStart = this.tbStartTime1.Text.ToString() != string.Empty;
            this.btTrue.Enabled = blForm;//处理完成还因该能编辑内容，但需要校验权限，目前是有编辑权限的人，注意：一般的填写人员只有新增权限
            this.btCompleted.Visible = (blForm && blStart) || (blForm && isCompeted); //&& !isNew;
            this.btCompleted.Text = isCompeted ? BTCancelCompletedText : BTCompletedText;
            //设置btCompleted背景色，避免操作工看错
            this.btCompleted.BackColor = isCompeted ? Color.Red : Color.Blue;
            this.btStart.Visible = blForm && !isNew && !isCompeted;
            this.btStart.Text = blStart ? BTCancelStartText : BTStartText;
            this.btStart.BackColor = blStart ? Color.Red : Color.LimeGreen;
            if (this.btDelete.Visible)
                this.btDelete.Enabled = blForm && !isNew;
            this.btSendLog.Enabled = isCompeted;//只有完成维修的才能编辑维修过程
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.FormState != Common.MyEnums.FormStates.New && this.FormState != Common.MyEnums.FormStates.Edit)
            {
                this.ShowMsg("当前窗体不允许编辑！");
                return false;
            }
            if (this.DataSource==null)
            {
                this.ShowMsg("数据源丢失！");
                return false;
            }
            if (tbCode.Text.Trim() == string.Empty)
            {
                this.ShowMsg("请输入异常编号。");
                return false;
            }
            object objMac = this.GetComboBoxValue(this.comMac);
            if (objMac.ToString().Length == 0)
            {
                this.ShowMsg("请选择设备。");
                return false;
            }
            #region 此时为新增，需要判读是否此机台还有未结束的异常单
            DataTable dtMacchk;
            try
            {
                dtMacchk = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC JC_MacBreakdown_CheckIsMacTerminated '{0}','{1}','{2}'"
                    , (PrimaryValue == null ? string.Empty : PrimaryValue.ToString().Replace("'", "''")), objMac.ToString().Replace("'", "''"), Common.CurrentUserInfo.UserCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dtMacchk.Rows.Count > 0 && dtMacchk.Columns.Contains("ErrMsg"))
            {
                this.ShowMsg(dtMacchk.Rows[0]["ErrMsg"].ToString());
                return false;
            }
            #endregion
            //校验是否没有选择异常内容
            DataTable dttemp = dgvDetail.DataSource as DataTable;
            if (dttemp == null || dttemp.DefaultView.Count == 0)
            {
                this.ShowMsg("请至少选中一条异常内容。");
                return false;
            }
            int itemp;
            if(!int.TryParse(this.GetComboBoxValue(this.comMacTerminated).ToString(),out itemp))
                itemp=0;
            if (itemp != 1 && itemp != 2)
            {
                this.ShowMsg("请选择是否需要停机维修。");
                return false;
            }
            if (string.Compare(this.DataSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["Code"].ToString(), this.tbCode.Text, true) != 0)
            {
                //如果编码已经修改过，则要判断是否编码已经存在了
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT count(*) FROM JC_MacBreakdown WHERE Code='{0}'", this.tbCode.Text.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (((int)dt.Rows[0][0]) > 0)
                {
                    this.ShowMsg("异常单“" + this.tbCode.Text + "”已经存在，请更换");
                    return false;
                }
            }
            if (this.tbRemark.Text.Length == 0 && this.DataSource.Tables["JC_MacBreakdownDetail"].DefaultView.Count == 0)
            {
                this.ShowMsg("请编辑异常内容。\r\n您可以在备注中写入异常信息，或者在异常列表中选择异常信息！");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 只提交异常单时读取
        /// </summary>
        /// <param name="dsSource"></param>
        private void ReadForm1(DataSet dsSource)
        {
            DataRow dr = dsSource.Tables["JC_MacBreakdown"].DefaultView[0].Row;
            if (!dr["Code"].Equals(this.tbCode.Text.Trim()))
                dr["Code"] = this.tbCode.Text.Trim();
            object objValue = GetComboBoxValue(this.comMac);
            if (!dr["MacCode"].Equals(objValue))
                dr["MacCode"] = objValue;
            if (dr["Remark"].ToString() != this.tbRemark.Text)
                dr["Remark"] = this.tbRemark.Text;
            bool blMacTerminated = this.GetComboBoxValue(this.comMacTerminated).ToString() == "1";
            if (blMacTerminated ^ (!dr["MacTerminated"].Equals(DBNull.Value) && (bool)dr["MacTerminated"]))
                dr["MacTerminated"] = blMacTerminated;
            string strDesc = string.Empty;
            string strClass = "、";
            foreach (DataRowView drv in dsSource.Tables["JC_MacBreakdownDetail"].DefaultView)
            {
                if (drv.Row["MBCode"].ToString() != this.tbCode.Text)
                    drv.Row["MBCode"] = this.tbCode.Text;
                if (drv.Row["CaseDesc"].ToString().Length > 0)
                    strDesc += drv.Row["CaseDesc"].ToString() + "；";
                if (drv.Row["ClassName"].ToString().Length > 0 && strClass.IndexOf("、" + drv.Row["ClassName"].ToString() + "、") < 0)
                    strClass += drv.Row["ClassName"].ToString() + "、";
            }
            if (strClass.Length > 1)
            {
                strClass = strClass.Substring(1);
                if (strClass.Length > 0)
                    strClass = strClass.Substring(0, strClass.Length - 1);//去除最后一个“、”
                if (dr["AllClassName"].ToString() != strClass)
                    dr["AllClassName"] = strClass;
            }
            if (dr["AllCaseDesc"].ToString() != strDesc)
                dr["AllCaseDesc"] = strDesc;
        }
        private bool Save(DataSet dsSource)
        {
            if (dsSource.GetChanges() == null)
                return true;
            try
            {
                this.BllDAL.Save(dsSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            return true;
        }
        private object GetComboBoxValue(ComboBox combox)
        {
            if (combox.SelectedItem == null) return DBNull.Value;
            Common.MyEntity.ComboBoxItem item = combox.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null) return DBNull.Value;
            return item.Value;
        }
        #endregion
        #region 窗体按钮事件
        private void btTrue_Click(object sender, EventArgs e)
        {
            bool blCompeleted;
            if (this.PrimaryValue == null || this.PrimaryValue.ToString().Length == 0)
                blCompeleted = false;
            {
                if (this.DataSource == null)
                {
                    this.ShowMsg("数据源为空。");
                    return;
                }
                blCompeleted = !this.DataSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["EndTime"].Equals(DBNull.Value);
            }
            //校验权限，必须有能新增或编辑的权限
            //校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (blCompeleted)
            {
                if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                {
                    this.ShowMsg("您没有修改已维修完成的异常单的权限，如果需要请联系管理员开放该权限。");
                    return;
                }
            }
            else
            {
                if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                {
                    this.ShowMsg("您没有提交异常单的权限，如果需要请联系管理员开放该权限。");
                    return;
                }
            }
            if (!this.SaveCheck()) return;
            DataSet dsSource = this.DataSource.Copy();
            this.ReadForm1(dsSource);
            if (this.Save(dsSource))
            {
                this.ShowMsg("提交成功。");
                this.PrimaryValue = dsSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["Code"].ToString();
                if (this.FormState != Common.MyEnums.FormStates.Edit)
                    this.FormState = Common.MyEnums.FormStates.Edit;
                if (!this.BindData(dsSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["Code"].ToString()))
                {
                    this.FormState = Common.MyEnums.FormStates.None;
                }
                if (!this.Updated)
                    this.Updated = true;
            }
        }
        #endregion
        private void frmUnitEdit_Load(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (listPower.Count == 0)
            {
                this.ShowMsg("您没有此模块的任何权限，窗口将自动关闭。");
                return;
            }
            else this.btDelete.Visible = listPower.Contains(Common.MyEnums.OperatePower.Delete);
            if (!this.PerInit())
            {
                this.FormState = Common.MyEnums.FormStates.None;
                return;
            }
            if(!this.BindData(this.PrimaryValue == null ? "" : this.PrimaryValue.ToString()))
            {
                this.FormState = Common.MyEnums.FormStates.None;
                return;
            }
        }
        private void btCompleted_Click(object sender, EventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.Edit)
            {
                if (this.FormState == Common.MyEnums.FormStates.New)
                    this.ShowMsg("请先提交异常内容。");
                else
                    this.ShowMsg("当前窗体状态不能编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失。");
                return;
            }
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (this.btCompleted.Text == BTCompletedText)
            {
                #region 完成维修
                if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                {
                    this.ShowMsg("您没有关于异常单完成的权限，如果需要请联系管理员开放该权限。");
                    return;
                }
                if (!this.IsUserConfirm("您确认设备已经维修完了吗？")) return;
                DataSet dsSource = this.DataSource.Copy();
                if (dsSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["EndTime"].Equals(DBNull.Value))
                {
                    DateTime detSer;
                    if (!Common.CommonFuns.GetSysCurrentDateTime(out detSer))
                        return;
                    dsSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["EndTime"] = detSer;
                }
                if (this.Save(dsSource))
                {
                    this.ShowMsg("提交成功。");
                    if (!this.BindData(this.PrimaryValue.ToString()))
                    {
                        this.FormState = Common.MyEnums.FormStates.None;
                    }
                    if (!this.Updated)
                        this.Updated = true;
                }
                #endregion
            }
            else if (this.btCompleted.Text == BTCancelCompletedText)
            {
                #region 撤销完成维修
                //注意撤销必须要有编辑和新增权限同时具备时才能执行
                if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt) || !listPower.Contains(Common.MyEnums.OperatePower.New))
                {
                    this.ShowMsg("您没有关于撤销异常单完成状态的权限，如果需要请联系管理员开放该权限。");
                    return;
                }
                if (!this.IsUserConfirm("您确定要撤销维修完成状态吗？")) return;
                DataSet dsSource = this.DataSource.Copy();
                dsSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["EndTime"] = DBNull.Value;
                //if (!this.SaveCheck()) return;
                if (this.Save(dsSource))
                {
                    this.ShowMsg("提交成功。");
                    if (!this.BindData(this.PrimaryValue.ToString()))
                    {
                        this.FormState = Common.MyEnums.FormStates.None;
                    }
                    if (!this.Updated)
                        this.Updated = true;
                }
                #endregion
            }
        }

        private void linkOperator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            //注意必须要有编辑权限和新增权限同时具备时才能选择填写人
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt) || !listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("您没有修改编辑填写人的权限，如果需要请联系管理员开放该权限。");
                return;
            }
            SysSetting.DeptUsers.frmSelectUserSample frm = new SysSetting.DeptUsers.frmSelectUserSample();
            frm.MultiSelected = false;
            frm.SelectedUserCodes = this.DataSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["Operator"].ToString();
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            string strUser = this.GetUser(frm.SelectedUserCodes);
            if (strUser.Length == 0)
                return;
            string strUserName = this.GetUser(frm.SelectedUserNames);
            //存入数据源
            if (this.DataSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["OperatorName"].ToString() != strUser)
            {
                this.DataSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["Operator"] = strUser;
                this.DataSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["OperatorName"] = strUserName;
                this.tbOperator.Text = strUserName;
            }
            //返回数据是以|分割的
        }
        private string GetUser(string str)
        {
            string[] arr = str.Split('|');
            foreach (string s in arr)
            {
                if (s.Length > 0) return s;
            }
            return string.Empty;
        }

        private void linkTime_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            //注意必须要有编辑权限和新增权限同时具备时才能编辑才能修改异常时间
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) || !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有修改编辑填写人的权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空。");
                return;
            }
            DataRow dr = this.DataSource.Tables["JC_MacBreakdown"].DefaultView[0].Row;
            frmMBdownEditSelTime frm = new frmMBdownEditSelTime();
            frm.StartTime = dr["StartTime"];
            frm.StartTime1 = dr["ProcessTime"];//开始维修时间
            frm.EndTime = dr["EndTime"];
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            
            if (!dr["StartTime"].Equals(frm.StartTime))
            {
                dr["StartTime"] = frm.StartTime;
                this.tbStartTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["StartTime"], "yyyy-MM-dd HH:mm");
            }
            if (!dr["ProcessTime"].Equals(frm.StartTime1))//开始维修时间
            {
                dr["ProcessTime"] = frm.StartTime1;
                this.tbStartTime1.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["ProcessTime"], "yyyy-MM-dd HH:mm");
            }
            if (!dr["EndTime"].Equals(frm.EndTime))
            {
                dr["EndTime"] = frm.EndTime;
                this.tbEndTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["EndTime"], "yyyy-MM-dd HH:mm");
            }
        }

        private void linkProUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空。");
                return;
            }
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有新增或编辑异常单的权限，如果需要请联系管理员开放该权限。");
                return;
            }
            DataRow dr = this.DataSource.Tables["JC_MacBreakdown"].DefaultView[0].Row;
            SysSetting.DeptUsers.frmSelectUserSample frm = new SysSetting.DeptUsers.frmSelectUserSample();
            frm.SelectedUserCodes = dr["ProUsers"].ToString();
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            if (dr["ProUsers"].ToString() != frm.SelectedUserCodes)
            {
                dr["ProUsers"] = frm.SelectedUserCodes;
                dr["ProUserNames"] = frm.SelectedUserNames;
                this.tbProUserNames.Text = frm.SelectedUserNames;
            }
        }

        private void linkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            //注意必须要有编辑权限才能修改异常时间
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有新增或编辑异常单的权限，如果需要请联系管理员开放该权限。");
                return;
            }
            BasicData.Process.frmSelectProcess frm = new BasicData.Process.frmSelectProcess();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this) || frm.SelectedData.Count == 0)
                return;
            string strProcessCode = frm.SelectedData[0].Code.ToString();
            this.tbProcessName.Text = frm.SelectedData[0].ProcessName.ToString();
            if (string.Compare(strProcessCode, this.ProcessCode, true) == 0) return;
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code,MacName FROM JC_ProcessMacs WHERE ProcessCode='{0}' ORDER BY SortID", strProcessCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("工序\"" + strProcessCode + "\"下未包含任何设备，请联系管理员进行添加。");
                return;
            }
            if (this.comMac.Items.Count > 0)
                this.comMac.Items.Clear();
            this.comMac.DisplayMember = "Text";
            this.comMac.ValueMember = "Value";
            foreach (DataRow dr in dt.Rows)
            {
                comMac.Items.Add(new Common.MyEntity.ComboBoxItem(dr["MacName"].ToString(), dr["Code"].ToString()));
            }
            this.comMac.SelectedIndex = -1;//默认未选择
            this.ProcessCode = strProcessCode;
            
            
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            //注意必须要有编辑权限才能修改异常时间
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("您没有删除异常单的权限。");
                return;
            }
            if (this.FormState != Common.MyEnums.FormStates.New && this.FormState != Common.MyEnums.FormStates.Edit || this.PrimaryValue==null || this.PrimaryValue.ToString().Length==0)
            {
                this.ShowMsg("当前窗体不能删除。");
                return;
            }
            if (!this.IsUserConfirm("您确定要删除设备异常单\"" + this.PrimaryValue.ToString() + "\"吗？"))
                return;
            string strMsg;
            int iReturnValue;
            try
            {
                this.BllDAL.Detele(this.PrimaryValue.ToString(), out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {

                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "删除失败，原因未知。";
                this.ShowMsg(strMsg);
                return;
            }
            this.ShowMsg("设备异常单\"" + this.PrimaryValue.ToString() + "\"已经删除。");
            if (!this.Updated)
                this.Updated = true;
            this.FormColse(null, false);
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有新增或编辑异常单的权限，如果需要请联系管理员开放该权限。");
                return;
            }
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt == null) return;
            frmSelectBdownCase frm = new frmSelectBdownCase();
            frm.MultiSelected = true;
            frm.DefaultProcess = this.ProcessCode;
            frm.FixProcess = true;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            if (frm.SelectedData.Count == 0) return;
            foreach (frmSelectBdownCase.SelectedMBdownCase info in frm.SelectedData)
            {
                if (dt.Select("CaseCode='"+info.Code.ToString()+"'").Length > 0)
                {
                    this.ShowMsg("异常内容\"" + info.Code.ToString() + "\"已经添加。");
                    continue;
                }
                DataRow drNew = dt.NewRow();
                drNew["CaseCode"] = info.Code;
                drNew["CaseDesc"] = info.CaseDesc;
                drNew["LevelDesc"] = info.LevelDesc;
                drNew["ClassName"] = info.ClassName;
                dt.Rows.Add(drNew);
            }
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有新增或编辑异常单的权限，如果需要请联系管理员开放该权限。");
                return;
            }
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt == null) return;
            if (this.dgvDetail.SelectedRows.Count == 0) return;
            if (!this.IsUserConfirm("您确定要移除选中的异常内容吗？"))
                return;
            dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row.Delete();
        }

        private void comMac_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.MyEntity.ComboBoxItem item = this.comMac.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value.ToString().Length == 0)
                this.labMacName.Text = "请选机台";
            else this.labMacName.Text = item.Text;
        }

        private void btSendLog_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有该模块的编辑权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.PrimaryValue == null || this.PrimaryValue.ToString().Length == 0)
            {
                this.ShowMsg("请重新加载窗体。");
                return;
            }
            if (this.tbLog.Text.Trim() == string.Empty)
            {
                this.ShowMsg("请输入维修过程。");
                return;
            }
            string strSql = string.Format("UPDATE JC_MacBreakdown SET LogUserCode='{0}',LogUserName='{1}',weixiuLog='{2}' WHERE Code='{3}'"
                , Common.CurrentUserInfo.UserCode.Replace("'", "''"), Common.CurrentUserInfo.UserName.Replace("'", "''"), this.tbLog.Text.Replace("'", "''"), this.PrimaryValue.ToString().Replace("'", "''"));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.ShowMsg("提交成功。");
            if (!this.BindData(this.PrimaryValue.ToString()))
            {
                this.FormState = Common.MyEnums.FormStates.None;
            }
        }
        private void comMacTerminated_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = this.GetComboBoxValue(this.comMacTerminated);
            if (obj.ToString() == "1")
                this.labMacName.ForeColor = Color.Red;
            else if (obj.ToString() == "2") this.labMacName.ForeColor = Color.Blue;
            else this.labMacName.ForeColor = Color.Black;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.Edit)
            {
                if (this.FormState == Common.MyEnums.FormStates.New)
                    this.ShowMsg("请先提交异常内容。");
                else
                    this.ShowMsg("当前窗体状态不能编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失。");
                return;
            }
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有关于异常单完成的权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.btStart.Text == BTStartText)
            {
                DataSet dsSource = this.DataSource.Copy();
                if (dsSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["ProUsers"].Equals(DBNull.Value) || this.tbProUserNames.Text.Equals(string.Empty))
                {
                    this.ShowMsg("请先选择异常处理人。");
                    return;
                }
                if (!this.IsUserConfirm("您确认设备可以开始维修了吗？")) return;
                if (dsSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["ProcessTime"].Equals(DBNull.Value))
                {
                    DateTime detSer;
                    if (!Common.CommonFuns.GetSysCurrentDateTime(out detSer))
                        return;
                    dsSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["ProcessTime"] = detSer;
                }
                if (this.Save(dsSource))
                {
                    this.ShowMsg("提交成功。");
                    if (!this.BindData(this.PrimaryValue.ToString()))
                    {
                        this.FormState = Common.MyEnums.FormStates.None;
                    }
                    if (!this.Updated)
                        this.Updated = true;
                }
            }
            else if (this.btStart.Text == BTCancelStartText)
            {
                if (!this.IsUserConfirm("您确认撤销开始维修吗？")) return;
                DataSet dsSource = this.DataSource.Copy();
                dsSource.Tables["JC_MacBreakdown"].DefaultView[0].Row["ProcessTime"] = DBNull.Value;
                if (this.Save(dsSource))
                {
                    this.ShowMsg("提交成功。");
                    if (!this.BindData(this.PrimaryValue.ToString()))
                    {
                        this.FormState = Common.MyEnums.FormStates.None;
                    }
                    if (!this.Updated)
                        this.Updated = true;
                }
            }
            
        }

        private void linkTstart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            //注意必须要有编辑权限和新增权限同时具备时才能编辑才能修改异常时间
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) || !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有修改编辑填写人的权限，如果需要请联系管理员开放该权限。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空。");
                return;
            }
            DataRow dr = this.DataSource.Tables["JC_MacBreakdown"].DefaultView[0].Row;
            frmMBdownEditSelTime frm = new frmMBdownEditSelTime();
            frm.StartTime = dr["StartTime"];
            frm.StartTime1 = dr["ProcessTime"];//开始维修时间
            frm.EndTime = dr["EndTime"];
            if (DialogResult.OK != frm.ShowDialog(this))
                return;

            if (!dr["StartTime"].Equals(frm.StartTime))
            {
                dr["StartTime"] = frm.StartTime;
                this.tbStartTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["StartTime"], "yyyy-MM-dd HH:mm");
            }
            if (!dr["ProcessTime"].Equals(frm.StartTime1))//开始维修时间
            {
                dr["ProcessTime"] = frm.StartTime1;
                this.tbStartTime1.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["ProcessTime"], "yyyy-MM-dd HH:mm");
            }
            if (!dr["EndTime"].Equals(frm.EndTime))
            {
                dr["EndTime"] = frm.EndTime;
                this.tbEndTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["EndTime"], "yyyy-MM-dd HH:mm");
            }
        }
    }
}