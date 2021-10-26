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
        #region ����������
        
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
        #region ��ȡ�û�ģ��Ȩ��
        public virtual List<Common.MyEnums.OperatePower> GetOperatePower(string strUserCode, Common.MyEnums.Modules module, object objArg)
        {
            DataTable dt = null;
            List<Common.MyEnums.OperatePower> listPower = new List<Common.MyEnums.OperatePower>();
            //�ж��û��ȼ�
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
                //����ѯ��Ȩ�޷ǵ�½��ʱ
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
                //����ģ������֮����������й���
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
                //��ʱΪ�Զ���
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
        /// ��ȡ�û���ָ��ģ���µ�Ȩ��
        /// </summary>
        /// <param name="module"></param>
        /// <param name="objArg"></param>
        /// <returns></returns>
        public virtual List<Common.MyEnums.OperatePower> GetOperatePower(Common.MyEnums.Modules module, object objArg)
        {
            return this.GetOperatePower(Common.CurrentUserInfo.UserCode, module, objArg);
        }
        /// <summary>
        /// ��ȡ�û���ָ��ģ���µ�Ȩ��
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
            //�ж��û��ȼ�
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
                //����ѯ��Ȩ�޷ǵ�½��ʱ
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
                //����ģ������֮����������й���
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
                //��ʱΪ�Զ���
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
        /// ��ȡ�û���ָ��ģ���µ�Ȩ��
        /// </summary>
        /// <param name="module"></param>
        /// <param name="objArg"></param>
        /// <returns></returns>
        public virtual List<Common.MyEnums.OperatePower> GetOperatePower(int iModule, object objArg)
        {
            return this.GetOperatePower(Common.CurrentUserInfo.UserCode, iModule, objArg);
        }
        /// <summary>
        /// ��ȡ�û���ָ��ģ���µ�Ȩ��
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public virtual List<Common.MyEnums.OperatePower> GetOperatePower(int iModule)
        {
            return this.GetOperatePower(Common.CurrentUserInfo.UserCode, iModule, null);
        }
        #endregion
        #region ϵͳ��Ϣ��ʾ
        public virtual void ShowMsg(string strMsg)
        {
            if (strMsg == "����ɹ���" || strMsg == "����ɹ���" || strMsg == "����ɹ�")
            {
                this.ShowMsgRich();
                return;
            }
            MessageBox.Show(this, strMsg, "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// ��ʾ�û�ȷ�ϴ���
        /// </summary>
        /// <param name="sText">��Ҫ�û�ȷ�ϵ�����</param>
        /// <returns>�������Ϊtru,���û�ѡ����Yes��ʾȷ��ͨ��������ͨ��</returns>
        public virtual bool IsUserConfirm(string sText)
        {
            return DialogResult.Yes == MessageBox.Show(this, sText, "������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion
        #region �򿪷�ģ̬��Ϣ����
        public void ShowMsgRich()
        {
            ShowMsgRich("����ɹ���");
        }
        /// <summary>
        /// ����Ϣ���ڣ��˴��ڻ��Զ���ʧ
        /// </summary>
        /// <param name="sMsg">Ҫ��ʾ����Ϣ��ע����Ҫ����18�����֣�</param>
        public void ShowMsgRich(string sMsg)
        {
            ShowMsgRich(sMsg, 0, 150, 0.55);
        }
        /// <summary>
        /// ����Ϣ���ڣ���ɫ���������˴��ڻ��Զ���ʧ
        /// </summary>
        /// <param name="sMsg"></param>
        public void ShowMsgRich1(string sMsg)
        {
            Color back = Color.FromArgb(192, 80, 77);
            ShowMsgRich(sMsg, 0, 150, 0.55, back, Color.White);
        }
        /// <summary>
        /// ����Ϣ���ڣ��˴��ڻ��Զ���ʧ
        /// </summary>
        /// <param name="sMsg">Ҫ��ʾ����Ϣ��ע����Ҫ����18�����֣�Ĭ��Ϊ������ɹ�!</param>
        /// <param name="ShowTime">OpacityΪ100%��Ҫͣ��������ʱ�䣬��λΪ�룬Ĭ������0��</param>
        /// <param name="CloseInterval">�ر�ʱtimer�ؼ���Ƶ�ʣ�Ĭ��Ϊ150</param>
        /// <param name="ReduceOpacity">�ر�ʱOpacityÿ��ʣ��İٷֱȣ�Ĭ��Ϊ0.55</param>
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
        #region ��ȡGUID
        /// <summary>
        /// ��ȡGUID
        /// </summary>
        /// <param name="module">��Ӧģ��</param>
        /// <param name="strUserCode">����Ա����</param>
        /// <returns>һ��С�ڵ���50���ַ�����΢��GUIDΪ��������GUID����</returns>
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
        #region ����DataGridView�б�
        /// <summary>
        /// ��DataGridView����
        /// </summary>
        /// <param name="strModuleSign">ģ���ʾ��</param>
        /// <param name="strID">�ؼ�ID</param>
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
                //���°󶨸��б�
                return this.ShowDataGridViewSetting_BindColumn(dgv, iModule);
            }
            frm.Dispose();
            return true;
        }
        /// <summary>
        /// ������˳��
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
            //���Ƚ�����������Ϊ�Ƕ��ᣬ��������ʱ���ܻ���ִ���
            foreach (DataGridViewColumn col in dgv.Columns)
                col.Frozen = false;
            dt.DefaultView.Sort = "SortID ASC";
            //��ȡ���һ��������
            int iFozenIndex = -1;
            for (int i = dt.DefaultView.Count; i > 0; i--)
            {
                //Ĭ��Ϊ���һ��������Ϊ�еĶ���
                if (!dt.DefaultView[i - 1].Row["isFrozen"].Equals(DBNull.Value)
                    && (bool)dt.DefaultView[i - 1].Row["isFrozen"])
                {
                    iFozenIndex = i - 1;
                    break;
                }
            }
            //��ʼ����
            DataGridViewColumn colTemp;
            DataRow dr;
            int iDisIndex = 0;//��ʼ�����
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
                    colTemp.DisplayIndex = iDisIndex;//���������
                    colTemp.Frozen = iDisIndex <= iFozenIndex;
                    if (!dr["ColWidth"].Equals(DBNull.Value))
                        colTemp.Width = (int)dr["ColWidth"];
                    //���ñ���ɫ
                    if (Common.CommonFuns.StringRegexCheck.CheckIsColorHexString(dr["BackColor"].ToString()))
                    {
                        colTemp.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(dr["BackColor"].ToString());
                    }
                    //����������ɫ
                    if (Common.CommonFuns.StringRegexCheck.CheckIsColorHexString(dr["ForeColor"].ToString()))
                    {
                        colTemp.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(dr["ForeColor"].ToString());
                    }
                    //���������С
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
        /// ��ȡ�ؼ��������
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
                //���°󶨸��б�
                return this.ShowDataGridViewSetting_BindColumn(dgv, module);
            }
            frm.Dispose();
            return true;
        }
        #endregion
        #region ����Ϣ����
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
        /// <param name="showType">1�����δ����ֱ�Ӵ򿪣�0�����ҽ�����Ϣ�����Ѿ���ʾ����ʾ��Ϣ</param>
        /// <param name="strMsg">��Ϣ����</param>
        /// <param name="colorMsg">��Ϣ��ɫ</param>
        /// <param name="overwrite">�Ƿ���д</param>
        /// <param name="iWidth">���</param>
        /// <param name="iHeight">�߶�</param>
        /// <param name="iLeft">��ʾʱ����LEFTֵ</param>
        /// <param name="iTop">��ʾʱ����Topֵ</param>
        /// <param name="iMaxChars">������������������ֵ�ʹ����ļ���sLogDir��</param>
        /// <param name="sLogDir">�洢��־��Ŀ���ļ��У�ע�������ı������ַ�����iMaxCharsʱ�Ż�洢</param>
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
                    //��ʱ�Ѿ�������Ҫ��ģ�����պ�����ʾ��Ϣ
                    if (MsgFormSaveLog(sLogDir))
                    {
                        //�����洢�ɹ������
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
        /// �ر���Ϣ����
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
        /// �رղ��洢��Ϣ��־
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
                //��ʱ��Ҫ����ı�������
                this.CloseMsgForm(false);
            }
        }
        /// <summary>
        /// ��Ϣ�����������ر��¼�
        /// </summary>
        /// <returns>�������������رգ����ط���ֹ�ر�</returns>
        public virtual bool MsgFormClosing()
        {
            return true;
        }
        /// <summary>
        /// ������¼�
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
            //��ȡ�ļ���
            string strFileName = DateTime.Now.ToString("yyMMddHHmmss");
            string strfullPath = strFile + "\\" + strFileName + ".log";
            while (System.IO.File.Exists(strfullPath))
            {
                strFileName += "_1";
                strfullPath = strFile + "\\" + strFileName + ".log";
            }
            System.IO.StreamWriter swLog;
            StringBuilder sbcontent = new StringBuilder();
            sbcontent.Append("-----------------�洢ʱ��:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-----------------\r\n");
            sbcontent.Append("-----------------��ǰ������:" + Common.CurrentUserInfo.UserName + "-----------------\r\n");
            for (int i = 0; i < this._frmMsg._TextBox.Lines.Length; i++)
            {
                sbcontent.Append(this._frmMsg._TextBox.Lines[i]);
                sbcontent.Append("\r\n");
            }
            try
            {
                using (swLog = System.IO.File.CreateText(strfullPath))
                {

                    swLog.Write(sbcontent.ToString());      //д���ļ�����
                    swLog.Close(); //�����ļ�
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
        #region �첽�򿪴��󴰿�
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
        #region �򿪴�����Ϣ��ʾ����
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
        #region �򿪴�����Ϣ��ʾ����
        public void OpenBigMsgShine(string strMsg)
        {
            frmErrMsgBoxShine frm = new frmErrMsgBoxShine();
            frm._Msg = strMsg;
            frm.ShowDialog(this);
        }
        #endregion
        #region ��ȡ��ӡģ��
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
                this.ShowMsg("δ�ҵ���ʾΪ��" + sArg + "���Ĵ�ӡģ�壡 ");
                return string.Empty;
            }
            string strName = dt.Rows[0]["FileName"].ToString();
            string strVersion = dt.Rows[0]["FileVersion"].ToString(); 
            int iDotIndex = strName.LastIndexOf(".");
            if (iDotIndex < 0)
            {
                this.ShowMsg("��" + strName + "��������Ч���ļ����ƣ��������к�׺��");
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
                    this.ShowMsg("�ļ��С�" + strFile + "������ʧ��");
                    return string.Empty;
                }
            }
            strFile +=  "\\" + strName;
            if (System.IO.File.Exists(strFile)) return strFile;
            //��ʱ�������ļ���Ҫ����
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
                this.ShowMsg(string.Format("δ�ҵ���ʾ��{0}�����ļ���{1}����ʵ�����ݣ���֪ͨ����Ա�ϴ���"
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
                this.ShowMsg("�ļ���" + strFile + "������ʧ��");
                return string.Empty;
            }
            return strFile;
        }
        #endregion
        #region ��ȡ����ģ��
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
                this.ShowMsg("δ�ҵ���ʾΪ��" + sArg + "���Ĵ�ӡģ�壡 ");
                return string.Empty;
            }
            string strName = dt.Rows[0]["FileName"].ToString();
            string strVersion = dt.Rows[0]["FileVersion"].ToString();
            int iDotIndex = strName.LastIndexOf(".");
            if (iDotIndex < 0)
            {
                this.ShowMsg("��" + strName + "��������Ч���ļ����ƣ��������к�׺��");
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
                    this.ShowMsg("�ļ��С�" + strFile + "������ʧ��");
                    return string.Empty;
                }
            }
            strFile += "\\" + strName;
            if (System.IO.File.Exists(strFile)) return strFile;
            //��ʱ�������ļ���Ҫ����
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
                this.ShowMsg(string.Format("δ�ҵ���ʾ��{0}�����ļ���{1}����ʵ�����ݣ���֪ͨ����Ա�ϴ���"
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
                this.ShowMsg("�ļ���" + strFile + "������ʧ��");
                return string.Empty;
            }
            return strFile;
        }
        /// <summary>
        /// ��ȡ����ģ��
        /// </summary>
        /// <param name="iArg">��ʾ,�����������ĸ�����ģ��</param>
        /// <returns></returns>
        public string GetExcelPublicModule(int iArg)
        {
            return this.GetExcelModule("���������б�" + iArg.ToString());
        }
        #endregion
        #region ��ȡϵͳ����URL·��
        public string GetURL(string sType,string sArg)
        {
            string strHostName = System.Net.Dns.GetHostName();
            string strIP = string.Empty;
            if (strHostName != string.Empty)
            {
                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(strHostName);
                //ע��Ŀǰֻ��ȡIP4�ĵ�ַ
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
        #region ����Timer
        private Timer _Timer = null;
        private object _TimerArg = null;
        /// <summary>
        /// ����Timerһ�ε���
        /// </summary>
        /// <param name="iTimerInterval">Ƶ�ʣ���λ������</param>
        /// <param name="objArg">������������Ϊ�ͻ���ʶ��ı�ʶ</param>
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
            //ArgΪ���������ڿͻ���ʶ��
        }
        #endregion
        #region ��������ʱ��ʾ��panel����
        public string GetHiddenPanelTitle()
        {
            return GetHiddenPanelTitle(null);
        }
        public virtual string GetHiddenPanelTitle(object arg)
        {
            return "��������С��";
        }
        #endregion
        #region �û��ı��¼�
        /// <summary>
        /// �û��ı�������Ӧ��Ȩ��Ҳ��ı䣬һЩ��ʵ���ÿ���Ҳ��ġ����и��ģ�����ֱ����д�ú�������
        /// </summary>
        /// <param name="sOriginalUser">ԭ�û�</param>
        /// <param name="sNewUser">���û�</param>
        public virtual void LoginedUserChanged(string sOriginalUser, string sNewUser)
        {

        }
        #endregion
    }
}