using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common
{
    public partial class frmMainBase : Form
    {
        public frmMainBase()
        {
            InitializeComponent();
            Form form = Owner as Form;
            if (form != null && form.TopMost)
                this.TopMost = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            NoneMouseWheel();
        }
        #region 禁用鼠标滚轮
        
        protected void NoneMouseWheel()
        {
            foreach (Control con in this.Controls)
            {
                if (con.GetType().ToString().ToLower() == "System.Windows.Forms.ComboBox".ToLower())
                {
                    con.MouseWheel += new MouseEventHandler(combobox_MouseWheel);
                }
                NoneMouseWheel(con);
            }
        }
        protected void NoneMouseWheel(Control conParent)
        {
            foreach (Control con in conParent.Controls)
            {
                if (con.GetType().ToString().ToLower() == "System.Windows.Forms.ComboBox".ToLower())
                {
                    con.MouseWheel += new MouseEventHandler(combobox_MouseWheel);
                }
                NoneMouseWheel(con);
            }
        }
        protected void combobox_MouseWheel(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.HandledMouseEventArgs hme = (System.Windows.Forms.HandledMouseEventArgs)e;
            hme.Handled = true;
        }
        #endregion
        #region 读取用户模块权限
        public virtual List<Common.MyEnums.OperatePower> GetOperatePower(string strUserCode, Common.MyEnums.Modules module, object objArg)
        {
            DataTable dt = null;
            List<Common.MyEnums.OperatePower> listPower = new List<Common.MyEnums.OperatePower>();
            //判断用户等级
            int iUserLevel;
            if (strUserCode.ToUpper() == Common.CurrentUserInfo.UserCode.ToUpper())
            {
                if (Common.CurrentUserInfo.IsSuper)
                    iUserLevel = 0;
                else if (Common.CurrentUserInfo.IsAdmin)
                    iUserLevel = 1;
                else
                    iUserLevel = 2;
            }
            else
            {
                //当查询的权限非登陆人时
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT IsAdmin,IsSuper,PowerGroupCode FROM Sys_Users WHERE UserCode='{0}'", strUserCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return listPower;
                }
                if (dt.Rows.Count == 0)
                    return listPower;

                if (!dt.Rows[0]["IsSuper"].Equals(DBNull.Value) && (bool)dt.Rows[0]["IsSuper"])
                    iUserLevel = 0;
                else if (!dt.Rows[0]["IsAdmin"].Equals(DBNull.Value) && (bool)dt.Rows[0]["IsAdmin"])
                    iUserLevel = 1;
                else
                    iUserLevel = 2;
            }
            if (iUserLevel == 0)
            {
                listPower.Add(Common.MyEnums.OperatePower.New);
                listPower.Add(Common.MyEnums.OperatePower.Eidt);
                listPower.Add(Common.MyEnums.OperatePower.Delete);
                listPower.Add(Common.MyEnums.OperatePower.ReadOnly);
                return listPower;
            }
            else if (iUserLevel == 1)
            {
                //除了模块设置之外的其他所有功能
                if (Common.MyEnums.Modules.ModuleSetting != module)
                {
                    listPower.Add(Common.MyEnums.OperatePower.New);
                    listPower.Add(Common.MyEnums.OperatePower.Eidt);
                    listPower.Add(Common.MyEnums.OperatePower.Delete);
                    listPower.Add(Common.MyEnums.OperatePower.ReadOnly);
                    return listPower;
                }
            }
            else
            {
                //此时为自定义
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("EXEC sys_GetUserModulePowers '{0}',{1}", strUserCode.Replace("'", "''"), (int)module));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return listPower;
                }
                if (dt.Rows.Count == 0)
                    return listPower;
                DataRow dr = dt.Rows[0];
                if (!dr["NewPower"].Equals(DBNull.Value) && (bool)dr["NewPower"])
                    listPower.Add(Common.MyEnums.OperatePower.New);
                if (!dr["EditPower"].Equals(DBNull.Value) && (bool)dr["EditPower"])
                    listPower.Add(Common.MyEnums.OperatePower.Eidt);
                if (!dr["DeletePower"].Equals(DBNull.Value) && (bool)dr["DeletePower"])
                    listPower.Add(Common.MyEnums.OperatePower.Delete);
                if (!dr["ReadOnlyPower"].Equals(DBNull.Value) && (bool)dr["ReadOnlyPower"])
                    listPower.Add(Common.MyEnums.OperatePower.ReadOnly);
                return listPower;
            }
            return listPower;
        }
        /// <summary>
        /// 获取用户在指定模块下的权限
        /// </summary>
        /// <param name="module"></param>
        /// <param name="objArg"></param>
        /// <returns></returns>
        public virtual List<Common.MyEnums.OperatePower> GetOperatePower(Common.MyEnums.Modules module, object objArg)
        {
            return this.GetOperatePower(Common.CurrentUserInfo.UserCode, module, objArg);
        }
        /// <summary>
        /// 获取用户在指定模块下的权限
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public virtual List<Common.MyEnums.OperatePower> GetOperatePower(Common.MyEnums.Modules module)
        {
            return this.GetOperatePower(Common.CurrentUserInfo.UserCode, module, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUserCode"></param>
        /// <param name="module"></param>
        /// <param name="objArg"></param>
        /// <returns></returns>
        public virtual List<Common.MyEnums.OperatePower> GetOperatePower(string strUserCode, int iModule, object objArg)
        {
            DataTable dt = null;
            List<Common.MyEnums.OperatePower> listPower = new List<Common.MyEnums.OperatePower>();
            //判断用户等级
            int iUserLevel;
            if (strUserCode.ToUpper() == Common.CurrentUserInfo.UserCode.ToUpper())
            {
                if (Common.CurrentUserInfo.IsSuper)
                    iUserLevel = 0;
                else if (Common.CurrentUserInfo.IsAdmin)
                    iUserLevel = 1;
                else
                    iUserLevel = 2;
            }
            else
            {
                //当查询的权限非登陆人时
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT IsAdmin,IsSuper,PowerGroupCode FROM Sys_Users WHERE UserCode='{0}'", strUserCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return listPower;
                }
                if (dt.Rows.Count == 0)
                    return listPower;

                if (!dt.Rows[0]["IsSuper"].Equals(DBNull.Value) && (bool)dt.Rows[0]["IsSuper"])
                    iUserLevel = 0;
                else if (!dt.Rows[0]["IsAdmin"].Equals(DBNull.Value) && (bool)dt.Rows[0]["IsAdmin"])
                    iUserLevel = 1;
                else
                    iUserLevel = 2;
            }
            if (iUserLevel == 0)
            {
                listPower.Add(Common.MyEnums.OperatePower.New);
                listPower.Add(Common.MyEnums.OperatePower.Eidt);
                listPower.Add(Common.MyEnums.OperatePower.Delete);
                listPower.Add(Common.MyEnums.OperatePower.ReadOnly);
                return listPower;
            }
            else if (iUserLevel == 1)
            {
                //除了模块设置之外的其他所有功能
                if ((int)Common.MyEnums.Modules.ModuleSetting != iModule)
                {
                    listPower.Add(Common.MyEnums.OperatePower.New);
                    listPower.Add(Common.MyEnums.OperatePower.Eidt);
                    listPower.Add(Common.MyEnums.OperatePower.Delete);
                    listPower.Add(Common.MyEnums.OperatePower.ReadOnly);
                    return listPower;
                }
            }
            else
            {
                //此时为自定义
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("EXEC sys_GetUserModulePowers '{0}',{1}", strUserCode.Replace("'", "''"), iModule));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return listPower;
                }
                if (dt.Rows.Count == 0)
                    return listPower;
                DataRow dr = dt.Rows[0];
                if (!dr["NewPower"].Equals(DBNull.Value) && (bool)dr["NewPower"])
                    listPower.Add(Common.MyEnums.OperatePower.New);
                if (!dr["EditPower"].Equals(DBNull.Value) && (bool)dr["EditPower"])
                    listPower.Add(Common.MyEnums.OperatePower.Eidt);
                if (!dr["DeletePower"].Equals(DBNull.Value) && (bool)dr["DeletePower"])
                    listPower.Add(Common.MyEnums.OperatePower.Delete);
                if (!dr["ReadOnlyPower"].Equals(DBNull.Value) && (bool)dr["ReadOnlyPower"])
                    listPower.Add(Common.MyEnums.OperatePower.ReadOnly);
                return listPower;
            }
            return listPower;
        }
        /// <summary>
        /// 获取用户在指定模块下的权限
        /// </summary>
        /// <param name="module"></param>
        /// <param name="objArg"></param>
        /// <returns></returns>
        public virtual List<Common.MyEnums.OperatePower> GetOperatePower(int iModule, object objArg)
        {
            return this.GetOperatePower(Common.CurrentUserInfo.UserCode, iModule, objArg);
        }
        /// <summary>
        /// 获取用户在指定模块下的权限
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public virtual List<Common.MyEnums.OperatePower> GetOperatePower(int iModule)
        {
            return this.GetOperatePower(Common.CurrentUserInfo.UserCode, iModule, null);
        }
        #endregion
        #region 系统消息提示
        public virtual void ShowMsg(string strMsg)
        {
            if (strMsg == "保存成功！" || strMsg == "保存成功。" || strMsg == "保存成功")
            {
                this.ShowMsgRich();
                return;
            }
            MessageBox.Show(this, strMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 显示用户确认窗体
        /// </summary>
        /// <param name="sText">需要用户确认的内容</param>
        /// <returns>如果返回为tru,则用户选择了Yes表示确认通过，否则不通过</returns>
        public virtual bool IsUserConfirm(string sText)
        {
            return DialogResult.Yes == MessageBox.Show(this, sText, "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion
        #region 打开非模态消息窗口
        public void ShowMsgRich()
        {
            ShowMsgRich("保存成功！");
        }
        /// <summary>
        /// 打开消息窗口，此窗口会自动消失
        /// </summary>
        /// <param name="sMsg">要显示的消息，注：不要超过18个汉字！</param>
        public void ShowMsgRich(string sMsg)
        {
            ShowMsgRich(sMsg, 0, 150, 0.55);
        }
        /// <summary>
        /// 打开消息窗口（红色背景），此窗口会自动消失
        /// </summary>
        /// <param name="sMsg"></param>
        public void ShowMsgRich1(string sMsg)
        {
            Color back = Color.FromArgb(192, 80, 77);
            ShowMsgRich(sMsg, 0, 150, 0.55, back, Color.White);
        }
        /// <summary>
        /// 打开消息窗口，此窗口会自动消失
        /// </summary>
        /// <param name="sMsg">要显示的消息，注：不要超过18个汉字！默认为：保存成功!</param>
        /// <param name="ShowTime">Opacity为100%需要停留的增加时间，单位为秒，默认增加0秒</param>
        /// <param name="CloseInterval">关闭时timer控件的频率，默认为150</param>
        /// <param name="ReduceOpacity">关闭时Opacity每次剩余的百分比，默认为0.55</param>
        public void ShowMsgRich(string sMsg, int ShowTime, int CloseInterval, double ReduceOpacity)
        {
            Msg.frmMsgRich frm = new Common.Msg.frmMsgRich();
            frm.Msg = sMsg;
            frm.ShowTime = ShowTime;
            frm.CloseTimeInterval = CloseInterval;
            frm.ReduceOpacity = ReduceOpacity;
            frm.Show();
        }
        public void ShowMsgRich(string sMsg, int ShowTime, int CloseInterval, double ReduceOpacity,Color backColor,Color foreColor)
        {
            Msg.frmMsgRich frm = new Common.Msg.frmMsgRich();
            if (frm.BackColor != backColor)
                frm.BackColor = backColor;
            if (frm.ForeColor != foreColor)
                frm.ForeColor = foreColor;
            frm.Msg = sMsg;
            frm.ShowTime = ShowTime;
            frm.CloseTimeInterval = CloseInterval;
            frm.ReduceOpacity = ReduceOpacity;
            frm.Show();
        }
        #endregion
        #region 获取GUID
        /// <summary>
        /// 获取GUID
        /// </summary>
        /// <param name="module">对应模块</param>
        /// <param name="strUserCode">操作员编码</param>
        /// <returns>一个小于等于50个字符的以微软GUID为基础的新GUID编码</returns>
        public virtual string GetGUID(Common.MyEnums.Modules module, string strUserCode)
        {
            return Guid.NewGuid().ToString();
        }
        public virtual string GetGUID(int iModule, string strUserCode)
        {
            return Guid.NewGuid().ToString();
        }
        public virtual string GetGUID()
        {
            return Guid.NewGuid().ToString();
        }
        #endregion
        #region 设置DataGridView列表
        /// <summary>
        /// 打开DataGridView设置
        /// </summary>
        /// <param name="strModuleSign">模块表示符</param>
        /// <param name="strID">控件ID</param>
        /// <returns></returns>
        public bool DataGridViewSetting(Common.MyEnums.Modules module, DataGridView dgv)
        {
            return DataGridViewSetting((int)module, dgv);
        }
        public bool DataGridViewSetting(int iModule, DataGridView dgv)
        {
            DataTable dt = null;
            string strDgvName = this.GetDataGridViewFullName(dgv);
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT * FROM Sys_DataGridViewSetting WHERE ModuleEnumNo={0} AND UserCode='{1}' AND DataGridViewID='{2}' ORDER BY SortID", iModule, Common.CurrentUserInfo.UserCode.Replace("'", "''"), strDgvName.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataRow[] drs;
            List<DataGridViewColumn> listCol = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                listCol.Add(col);
                drs = dt.Select("TitleName='" + col.HeaderText + "'");
                if (drs.Length == 0)
                {
                    DataRow drNew = dt.NewRow();
                    drNew["ModuleEnumNo"] = iModule;
                    drNew["UserCode"] = Common.CurrentUserInfo.UserCode;
                    drNew["DataGridViewID"] = strDgvName;
                    drNew["SortID"] = ShowDataGridViewSetting_GetNewSortID(dt);
                    drNew["TitleName"] = col.HeaderText;
                    drNew["ColWidth"] = col.Width;
                    drNew["IsHidden"] = !col.Visible;
                    drNew["isFrozen"] = col.Frozen;
                    drNew["BackColor"] = ColorTranslator.ToHtml(col.DefaultCellStyle.BackColor);
                    drNew["ForeColor"] = ColorTranslator.ToHtml(col.DefaultCellStyle.ForeColor);
                    if (col.DefaultCellStyle != null && col.DefaultCellStyle.Font != null)
                        drNew["FontSize"] = col.DefaultCellStyle.Font.Size.ToString();
                    dt.Rows.Add(drNew);
                }
            }
            Common.DataGridSetting.frmEdit frm = new Common.DataGridSetting.frmEdit();
            frm.DataTableSource = dt;
            frm.ShowDialog();
            if (frm.IsUpdated)
            {
                //重新绑定该列表
                return this.ShowDataGridViewSetting_BindColumn(dgv, iModule);
            }
            frm.Dispose();
            return true;
        }
        /// <summary>
        /// 设置列顺序
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        public bool ShowDataGridViewSetting_BindColumn(DataGridView dgv, Common.MyEnums.Modules module)
        {
            return ShowDataGridViewSetting_BindColumn(dgv, (int)module);
        }
        public bool ShowDataGridViewSetting_BindColumn(DataGridView dgv, int iModule)
        {
            DataTable dt = null;
            string strDgvName = this.GetDataGridViewFullName(dgv);
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT * FROM Sys_DataGridViewSetting WHERE ModuleEnumNo={0} AND UserCode='{1}' AND DataGridViewID='{2}' ORDER BY SortID", iModule, Common.CurrentUserInfo.UserCode.Replace("'", "''"), strDgvName.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
                return true;
            //首先将所有列设置为非冻结，否则排序时可能会出现错误
            foreach (DataGridViewColumn col in dgv.Columns)
                col.Frozen = false;
            dt.DefaultView.Sort = "SortID ASC";
            //获取最后一个冻结列
            int iFozenIndex = -1;
            for (int i = dt.DefaultView.Count; i > 0; i--)
            {
                //默认为最后一个冻结列为列的冻结
                if (!dt.DefaultView[i - 1].Row["isFrozen"].Equals(DBNull.Value)
                    && (bool)dt.DefaultView[i - 1].Row["isFrozen"])
                {
                    iFozenIndex = i - 1;
                    break;
                }
            }
            //开始排序
            DataGridViewColumn colTemp;
            DataRow dr;
            int iDisIndex = 0;//初始列序号
            foreach (DataRowView drv in dt.DefaultView)
            {
                dr = drv.Row;
                colTemp = null;
                foreach (DataGridViewColumn dc in dgv.Columns)
                {
                    if (dc.HeaderText == dr["TitleName"].ToString())
                    {
                        colTemp = dc;
                        break;
                    }
                }
                if (colTemp != null)
                {
                    colTemp.DisplayIndex = iDisIndex;//设置排序号
                    colTemp.Frozen = iDisIndex <= iFozenIndex;
                    if (!dr["ColWidth"].Equals(DBNull.Value))
                        colTemp.Width = (int)dr["ColWidth"];
                    //设置背景色
                    if (Common.CommonFuns.StringRegexCheck.CheckIsColorHexString(dr["BackColor"].ToString()))
                    {
                        colTemp.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(dr["BackColor"].ToString());
                    }
                    //设置字体颜色
                    if (Common.CommonFuns.StringRegexCheck.CheckIsColorHexString(dr["ForeColor"].ToString()))
                    {
                        colTemp.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(dr["ForeColor"].ToString());
                    }
                    //设置字体大小
                    if (!dr["FontSize"].Equals(DBNull.Value))
                    {
                        Font font = new Font("", float.Parse(dr["FontSize"].ToString()));
                        colTemp.DefaultCellStyle.Font = font;
                    }
                    iDisIndex++;
                }
            }
            return true;
        }
        private int ShowDataGridViewSetting_GetNewSortID(DataTable dt)
        {
            if (dt.DefaultView.Count == 0) return 1;
            dt.DefaultView.Sort = "SortID";
            return (int)dt.DefaultView[dt.DefaultView.Count - 1].Row["SortID"] + 1;
        }
        /// <summary>
        /// 获取控件完成名称
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        private string GetDataGridViewFullName(DataGridView dgv)
        {
            return this.GetType().ToString() + "." + dgv.Name;
        }
        public bool DataGridViewSetting(Common.MyEnums.Modules module,string strGridFullPath, DataGridView dgv)
        {
            DataTable dt = null;
            string strDgvName = strGridFullPath + "." + dgv.Name;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT * FROM Sys_DataGridViewSetting WHERE ModuleEnumNo={0} AND UserCode='{1}' AND DataGridViewID='{2}' ORDER BY SortID", (int)module, Common.CurrentUserInfo.UserCode.Replace("'", "''"), strDgvName.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataRow[] drs;
            List<DataGridViewColumn> listCol = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                listCol.Add(col);
                drs = dt.Select("TitleName='" + col.HeaderText + "'");
                if (drs.Length == 0)
                {
                    DataRow drNew = dt.NewRow();
                    drNew["ModuleEnumNo"] = (int)module;
                    drNew["UserCode"] = Common.CurrentUserInfo.UserCode;
                    drNew["DataGridViewID"] = strDgvName;
                    drNew["SortID"] = ShowDataGridViewSetting_GetNewSortID(dt);
                    drNew["TitleName"] = col.HeaderText;
                    drNew["ColWidth"] = col.Width;
                    drNew["IsHidden"] = !col.Visible;
                    drNew["isFrozen"] = col.Frozen;
                    drNew["BackColor"] = ColorTranslator.ToHtml(col.DefaultCellStyle.BackColor);
                    drNew["ForeColor"] = ColorTranslator.ToHtml(col.DefaultCellStyle.ForeColor);
                    if (col.DefaultCellStyle != null && col.DefaultCellStyle.Font != null)
                        drNew["FontSize"] = col.DefaultCellStyle.Font.Size.ToString();
                    dt.Rows.Add(drNew);
                }
            }
            Common.DataGridSetting.frmEdit frm = new Common.DataGridSetting.frmEdit();
            frm.DataTableSource = dt;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.IsUpdated)
            {
                //重新绑定该列表
                return this.ShowDataGridViewSetting_BindColumn(dgv, module);
            }
            frm.Dispose();
            return true;
        }
        #endregion
        #region 打开消息窗体
        private frmCommMessage _frmMsg = null;
        public bool IsMsgFormShown
        {
            get
            {
                if (_frmMsg != null && !_frmMsg.IsDisposed) return _frmMsg.Visible;
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="showType">1→如果未打开则直接打开，0→当且仅当消息窗口已经显示才显示消息</param>
        /// <param name="strMsg">消息内容</param>
        /// <param name="colorMsg">消息颜色</param>
        /// <param name="overwrite">是否重写</param>
        /// <param name="iWidth">宽度</param>
        /// <param name="iHeight">高度</param>
        /// <param name="iLeft">显示时窗体LEFT值</param>
        /// <param name="iTop">显示时窗体Top值</param>
        /// <param name="iMaxChars">允许最大字数，查过该值就存入文件夹sLogDir中</param>
        /// <param name="sLogDir">存储日志的目标文件夹，注：仅当文本框内字符超过iMaxChars时才会存储</param>
        public void ToMsgForm(int showType,string strMsg,Color colorMsg,bool overwrite,int iWidth,int iHeight,int iLeft,int iTop,int iMaxChars,string sLogDir)
        {
            if (showType == 0)
            {
                if (_frmMsg == null || !_frmMsg.Visible) return;
            }
            if (_frmMsg == null)
            {
                _frmMsg = new frmCommMessage();
                _frmMsg.TopMost = true;
            }
            if(iMaxChars>0)
            {
                if (_frmMsg._TextBox.Text.Length > iMaxChars)
                {
                    //此时已经超过了要求的，则清空后再显示消息
                    if (MsgFormSaveLog(sLogDir))
                    {
                        //仅当存储成功后清空
                        _frmMsg._TextBox.Clear();
                    }
                }
            }
            int iStart;
            if (overwrite)
            {
                iStart = 0;
                this._frmMsg._TextBox.Text = strMsg;
            }
            else
            {
                iStart = this._frmMsg._TextBox.Text.Length;
                this._frmMsg._TextBox.AppendText(strMsg);
            }
            if (iWidth > 0)
                _frmMsg.Width = iWidth;
            if (iHeight > 0)
                _frmMsg.Height = iHeight;
            if (iLeft >= 0)
                _frmMsg.Left = iLeft;
            if (iTop >= 0)
                _frmMsg.Top = iTop;
            if (!_frmMsg.Visible)
            {
                _frmMsg.Show();
                MsgFormShowed();
            }
            if (colorMsg != Color.Black)
            {
                int imsgLen = strMsg.Length;
                if (strMsg.ToLower().IndexOf("\r\n") >= 0)
                    imsgLen -= 2;
                _frmMsg._TextBox.Select(iStart, imsgLen);
                //_frmMsg._TextBox.SelectionBackColor = colorMsg;
                _frmMsg._TextBox.SelectionColor = colorMsg;
            }
            _frmMsg.Activate();
            _frmMsg._TextBox.Select(_frmMsg._TextBox.Text.Length - 1, 0);
        }
        public void ToMsgForm(int showType, string strMsg, Color colorMsg, bool overwrite, int iWidth, int iHeight, int iLeft, int iTop)
        {
            ToMsgForm(showType, strMsg, colorMsg, overwrite, iWidth, iHeight, iLeft, iTop, 8000, string.Empty);
        }
        public void ToMsgForm(int showType, string strMsg, bool overwrite)
        {
            //348, 447
            ToMsgForm(showType, strMsg, Color.Black, overwrite, 0, 0, -1, -1);
        }
        /// <summary>
        /// 关闭消息窗体
        /// </summary>
        /// <param name="clearText"></param>
        public void CloseMsgForm(bool clearText)
        {
            if (_frmMsg == null) return;
            if (clearText) _frmMsg._TextBox.Clear();
            if (_frmMsg.Visible)
            {
                if (MsgFormClosing())
                    _frmMsg.Hide();
            }
        }
        /// <summary>
        /// 关闭并存储消息日志
        /// </summary>
        /// <param name="sDir"></param>
        /// <param name="iWordCount"></param>
        public void CloseMsgForm(string sDir, int iWordCount)
        {
            if (_frmMsg == null) return;
            if (this._frmMsg._TextBox.Text.Length >= iWordCount)
            {
                if(!MsgFormSaveLog(sDir))
                {
                    this.CloseMsgForm(false);
                }
                else
                {
                    this.CloseMsgForm(true);
                }
            }
            else
            {
                //此时需要清空文本框内容
                this.CloseMsgForm(false);
            }
        }
        /// <summary>
        /// 消息窗体出发窗体关闭事件
        /// </summary>
        /// <returns>返回真则正常关闭，返回否终止关闭</returns>
        public virtual bool MsgFormClosing()
        {
            return true;
        }
        /// <summary>
        /// 窗体打开事件
        /// </summary>
        public virtual void MsgFormShowed()
        {
        }
        public bool MsgFormSaveLog(string sFolder)
        {
            if (sFolder == string.Empty)
                sFolder = "MESMsgFormLog";
            string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFile.EndsWith("\\"))
                strFile += "\\";
            strFile += sFolder;
            try
            {
                if (!System.IO.Directory.Exists(strFile))
                {
                    System.IO.Directory.CreateDirectory(strFile);
                }
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //获取文件名
            string strFileName = DateTime.Now.ToString("yyMMddHHmmss");
            string strfullPath = strFile + "\\" + strFileName + ".log";
            while (System.IO.File.Exists(strfullPath))
            {
                strFileName += "_1";
                strfullPath = strFile + "\\" + strFileName + ".log";
            }
            System.IO.StreamWriter swLog;
            StringBuilder sbcontent = new StringBuilder();
            sbcontent.Append("-----------------存储时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-----------------\r\n");
            sbcontent.Append("-----------------当前操作人:" + Common.CurrentUserInfo.UserName + "-----------------\r\n");
            for (int i = 0; i < this._frmMsg._TextBox.Lines.Length; i++)
            {
                sbcontent.Append(this._frmMsg._TextBox.Lines[i]);
                sbcontent.Append("\r\n");
            }
            try
            {
                using (swLog = System.IO.File.CreateText(strfullPath))
                {

                    swLog.Write(sbcontent.ToString());      //写入文件内容
                    swLog.Close(); //保存文件
                }
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            return true;
        }
        #endregion
        #region 异步打开错误窗口
        public void ShowErrorDialogAsyn(Exception e, string sCauseAt)
        {
            ShowErrorCallBack cb = new ShowErrorCallBack(ShowErrorDialog);
            try
            {
                this.Invoke(cb, new object[2] { e, sCauseAt });
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, sCauseAt+ "(tryShowErrorDialogAsyncatch)");
            }
        }
        public void ShowErrorDialog(Exception e, string sCauseAt)
        {
            wErrorMessage.ShowErrorDialog1(this, e, sCauseAt);
        }
        public delegate void ShowErrorCallBack(Exception e, string sCauseAt);
        #endregion
        #region 打开大型消息提示窗体
        public void OpenBigMsg(string strMsg, string sType, Color color)
        {
            frmExpMsgBox frm = new frmExpMsgBox();
            frm._FontColor = color;
            frm._Type = sType;
            frm._Msg = strMsg;
            frm.ShowDialog(this);
        }
        public void OpenBigMsg(string strMsg, string sType, Color color,bool autoClose)
        {
            frmExpMsgBox frm = new frmExpMsgBox();
            frm._FontColor = color;
            frm._Type = sType;
            frm._Msg = strMsg;
            frm.AutoClose = autoClose;
            frm.ShowDialog(this);
        }
        #endregion
        #region 打开大型消息提示窗体
        public void OpenBigMsgShine(string strMsg)
        {
            frmErrMsgBoxShine frm = new frmErrMsgBoxShine();
            frm._Msg = strMsg;
            frm.ShowDialog(this);
        }
        #endregion
        #region 获取打印模板
        const string PrintModuleDirectory = "PrintModule";
        public string GetPrintModule(string sArg)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT FileName,FileVersion FROM JC_PrintFile WHERE PrintArg='{0}'", sArg.Replace("''", "''")));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("未找到标示为“" + sArg + "”的打印模板！ ");
                return string.Empty;
            }
            string strName = dt.Rows[0]["FileName"].ToString();
            string strVersion = dt.Rows[0]["FileVersion"].ToString(); 
            int iDotIndex = strName.LastIndexOf(".");
            if (iDotIndex < 0)
            {
                this.ShowMsg("“" + strName + "”不是有效的文件名称，它至少有后缀。");
                return string.Empty;
            }
            if (strVersion.Length > 0)
            {
                strName = strName.Substring(0, iDotIndex) + strVersion + "." + strName.Substring(iDotIndex + 1);
            }
            string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFile.EndsWith("\\"))
                strFile += "\\";
            strFile += PrintModuleDirectory;
            if (!System.IO.Directory.Exists(strFile))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(strFile);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    this.ShowMsg("文件夹“" + strFile + "”创建失败");
                    return string.Empty;
                }
            }
            strFile +=  "\\" + strName;
            if (System.IO.File.Exists(strFile)) return strFile;
            //此时不包含文件需要下载
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT FileEntity FROM JC_PrintFile WHERE PrintArg='{0}'", sArg.Replace("''", "''")));
            }
            catch (Exception ex)
            {
                ErrorService.wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt.Rows[0]["FileEntity"].Equals(DBNull.Value))
            {
                this.ShowMsg(string.Format("未找到标示“{0}”下文件“{1}”的实体数据，请通知管理员上传。"
                    , sArg, strName));
                return string.Empty;
            }
            try
            {
                byte[] byFile = (byte[])dt.Rows[0]["FileEntity"];
                System.IO.FileStream fs;
                System.IO.FileInfo file = new System.IO.FileInfo(strFile);
                fs = file.OpenWrite();
                fs.Write(byFile, 0, byFile.Length);
                fs.Close();
                fs.Dispose();
                file = null;
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                this.ShowMsg("文件“" + strFile + "”创建失败");
                return string.Empty;
            }
            return strFile;
        }
        #endregion
        #region 获取导出模板
        const string ExcelModuleDirectory = "ExcelModule";
        public string GetExcelModule(string sArg)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT FileName,FileVersion FROM JC_OutputFile WHERE outArg='{0}'", sArg.Replace("''", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("未找到标示为“" + sArg + "”的打印模板！ ");
                return string.Empty;
            }
            string strName = dt.Rows[0]["FileName"].ToString();
            string strVersion = dt.Rows[0]["FileVersion"].ToString();
            int iDotIndex = strName.LastIndexOf(".");
            if (iDotIndex < 0)
            {
                this.ShowMsg("“" + strName + "”不是有效的文件名称，它至少有后缀。");
                return string.Empty;
            }
            if (strVersion.Length > 0)
            {
                strName = strName.Substring(0, iDotIndex) + strVersion + "." + strName.Substring(iDotIndex + 1);
            }
            string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFile.EndsWith("\\"))
                strFile += "\\";
            strFile += ExcelModuleDirectory;
            if (!System.IO.Directory.Exists(strFile))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(strFile);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    this.ShowMsg("文件夹“" + strFile + "”创建失败");
                    return string.Empty;
                }
            }
            strFile += "\\" + strName;
            if (System.IO.File.Exists(strFile)) return strFile;
            //此时不包含文件需要下载
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT FileEntity FROM JC_OutputFile WHERE OutArg='{0}'", sArg.Replace("''", "''")));
            }
            catch (Exception ex)
            {
                ErrorService.wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt.Rows[0]["FileEntity"].Equals(DBNull.Value))
            {
                this.ShowMsg(string.Format("未找到标示“{0}”下文件“{1}”的实体数据，请通知管理员上传。"
                    , sArg, strName));
                return string.Empty;
            }
            try
            {
                byte[] byFile = (byte[])dt.Rows[0]["FileEntity"];
                System.IO.FileStream fs;
                System.IO.FileInfo file = new System.IO.FileInfo(strFile);
                fs = file.OpenWrite();
                fs.Write(byFile, 0, byFile.Length);
                fs.Close();
                fs.Dispose();
                file = null;
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                this.ShowMsg("文件“" + strFile + "”创建失败");
                return string.Empty;
            }
            return strFile;
        }
        /// <summary>
        /// 获取公共模板
        /// </summary>
        /// <param name="iArg">标示,用于区分是哪个公共模板</param>
        /// <returns></returns>
        public string GetExcelPublicModule(int iArg)
        {
            return this.GetExcelModule("公共导出列表" + iArg.ToString());
        }
        #endregion
        #region 获取系统所需URL路径
        public string GetURL(string sType,string sArg)
        {
            string strHostName = System.Net.Dns.GetHostName();
            string strIP = string.Empty;
            if (strHostName != string.Empty)
            {
                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(strHostName);
                //注：目前只读取IP4的地址
                foreach (System.Net.IPAddress ip in ips)
                {
                    if (ip.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        strIP = ip.ToString();
                    }
                }
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select dbo.Common_GetURL('{0}','{1}','{2}')"
                    , sType, sArg, strIP.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt.Rows.Count == 0) return string.Empty;
            return dt.Rows[0][0].ToString();
        }
        #endregion
        #region 调用Timer
        private Timer _Timer = null;
        private object _TimerArg = null;
        /// <summary>
        /// 激活Timer一次调用
        /// </summary>
        /// <param name="iTimerInterval">频率，单位：毫秒</param>
        /// <param name="objArg">参数，可以作为客户端识别的标识</param>
        public void AcitiveTimer(int iTimerInterval,object objArg)
        {
            if (_Timer == null)
            {
                _Timer = new Timer();
                _Timer.Tick+=new EventHandler(_Timer_Tick);
            }
            if (_Timer.Interval != iTimerInterval)
                this._Timer.Interval = iTimerInterval;
            if (!this._Timer.Enabled)
                this._Timer.Enabled = true;
            _TimerArg = objArg;
        }
        protected void _Timer_Tick(object sender, EventArgs e)
        {
            this._Timer.Enabled = false;
            AcitiveTimer_Doing(_TimerArg);
        }
        public virtual void AcitiveTimer_Doing(object Arg)
        {
            //Your code?????
            //Arg为参数，便于客户端识别
        }
        #endregion
        #region 窗口隐藏时显示的panel标题
        public string GetHiddenPanelTitle()
        {
            return GetHiddenPanelTitle(null);
        }
        public virtual string GetHiddenPanelTitle(object arg)
        {
            return "程序已最小化";
        }
        #endregion
        #region 用户改变事件
        /// <summary>
        /// 用户改变往往对应的权限也会改变，一些现实设置可能也会改。如有更改，窗口直接重写该函数即可
        /// </summary>
        /// <param name="sOriginalUser">原用户</param>
        /// <param name="sNewUser">新用户</param>
        public virtual void LoginedUserChanged(string sOriginalUser, string sNewUser)
        {

        }
        #endregion
    }
}