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
    public partial class frmBase : frmMainBase
    {
        public frmBase()
        {
            InitializeComponent();
        }
        #region ���幫������
        #region ����ؼ���
        private object _objPrimaryValue = null;
        /// <summary>
        /// �ؼ���ֵ
        /// </summary>
        public object PrimaryValue
        {
            get { return this._objPrimaryValue; }
            set { this._objPrimaryValue = value; }
        }
        #endregion
        #region ��������Դ
        private DataSet _dataSource = null;
        /// <summary>
        /// ��������Դ
        /// </summary>
        public DataSet DataSource
        {
            get { return this._dataSource; }
            set { this._dataSource = value; }
        }
        #endregion
        #region ����״̬
        private Common.MyEnums.FormStates _formstate = Common.MyEnums.FormStates.None;
        /// <summary>
        /// ��ǰ����״̬
        /// </summary>
        public Common.MyEnums.FormStates FormState
        {
            get { return this._formstate; }
            set { this._formstate = value; }
        }
        #endregion
        #region ����MDI�������
        private frmMdiBase _parentMDI = null;
        /// <summary>
        /// ����MDI����
        /// </summary>
        public frmMdiBase ParentMDI
        {
            get { return this._parentMDI; }
            set { this._parentMDI = value; }
        }
        #endregion
        #region ����frmBase�������
        private frmBase _frmParent = null;
        /// <summary>
        /// ĸ����
        /// </summary>
        public frmBase FormParent
        {
            get { return this._frmParent; }
            set { this._frmParent = value; }
        }
        #endregion
        #endregion
        #region ϵͳ��������
        //�رմ���ǰ�ȼ�飬�Ƿ����ֱ�ӹر�
        public virtual bool FormColse(object objArg)
        {
            return this.FormColse(objArg, true);
            //if (this.FormParent != null)
            //    this.FormParent.RefreshParetForm(objArg);
            //if (this.ParentMDI != null)
            //    return this.ParentMDI.CloseChildForm();
            //else
            //{
            //    this.Close();
            //    return true;
            //}
        }
        public virtual bool FormColse(object objArg,bool blConfrmchanged)
        {
            if (this.FormParent != null)
                this.FormParent.RefreshParetForm(objArg);
            if (this.ParentMDI != null)
                return this.ParentMDI.CloseChildForm(blConfrmchanged);
            else
            {
                this.Close();
                return true;
            }
        }
        public virtual bool FormColse()
        {
            return this.FormColse(null);
        }
        public virtual bool CheckClose()
        {
            return true;
        }
        public virtual void MyFormClose()
        {
            //����ر�ʱ���ã������������Ҫִ�еĲ��������ڴ�������д�˷���
        }
        //ˢ�¸������壬�������������overid�÷�����objArgΪ����������������򿪶��ָ��Ӵ���ʱ�������õ�
        public virtual bool RefreshParetForm(object objArg)
        {
            return true;
        }
        /// <summary>
        /// �򿪴���
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="frmNew"></param>
        /// <returns></returns>
        public virtual bool ShowChildForm(string strTitle, frmBase frmNew)
        {
            return ShowChildForm(strTitle, frmNew, false);
            //if (this.ParentMDI != null)
            //    return this.ParentMDI.ShowChildForm(strTitle, frmNew);
            //else
            //{
            //    frmNew.Text = strTitle;
            //    frmNew.Show();
            //    return true;
            //}
        }
        public virtual bool ShowChildForm(string strTitle, frmBase frmNew, bool blNew)
        {
            if (this.ParentMDI != null)
                return this.ParentMDI.ShowChildForm(strTitle, frmNew,blNew);
            else
            {
                frmNew.Text = strTitle;
                frmNew.Show();
                return true;
            }
        }
        /// <summary>
        /// �ı䴰�����
        /// </summary>
        /// <param name="strNewTitle"></param>
        public void ChangeWinTitle(string strNewTitle)
        {
            TabPage page = this.Parent as TabPage;
            if (page != null)
            {
                if (page.Text != strNewTitle)
                    page.Text = strNewTitle;
                if (this.Text != strNewTitle)
                    this.Text = strNewTitle;
            }
            else
            {
                if (this.Text != strNewTitle)
                    this.Text = strNewTitle;
            }
        }
        /// <summary>
        /// ��ȡ�Զ�����
        /// </summary>
        /// <param name="module">ģ��ö��ֵ</param>
        /// <returns></returns>
        public virtual string GetAutoCode(Common.MyEnums.Modules module)
        {
            return this.GetAutoCode(module, 0);
        }
        /// <summary>
        /// ��ȡ�Զ�����
        /// </summary>
        /// <param name="module">ģ��ö��ֵ</param>
        /// <param name="argment">�˲������ã���ģ���ж������Ҫ�Զ�����ʱ�������ô˲�����ʾ</param>
        /// <returns></returns>
        public virtual string GetAutoCode(Common.MyEnums.Modules module,int argment)
        {
            string strSql = string.Format("SELECT * FROM V_Sys_AutoCode WHERE EnumNo={0}", (int)module);
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt.Rows.Count == 0)
                return string.Empty;
            string strRule = dt.Rows[0]["CodeRule"].ToString();
            string strCode = string.Empty;
            DateTime detNow;
            if (!Common.CommonFuns.GetSysCurrentDateTime(out detNow))
            {
                this.ShowMsg("��ȡ������ʱ�����");
                return string.Empty;
            }
            while (strRule.IndexOf("[yyyy]") >= 0)
                strRule = strRule.Replace("[yyyy]", detNow.ToString("yyyy"));
            while (strRule.IndexOf("[yy]") >= 0)
                strRule = strRule.Replace("[yy]", detNow.ToString("yy"));
            while (strRule.IndexOf("[MM]") >= 0)
                strRule = strRule.Replace("[MM]", detNow.ToString("MM"));
            while (strRule.IndexOf("[dd]") >= 0)
                strRule = strRule.Replace("[dd]", detNow.ToString("dd"));
            int iSerailLen;
            if (dt.Rows[0]["SerialLen"].Equals(DBNull.Value))
                iSerailLen = 1;
            else
                iSerailLen = (int)dt.Rows[0]["SerialLen"];
            strSql = string.Format("exec GetAutoCode {0},'{1}',{2},{3}", (int)module, strRule, iSerailLen, argment);
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt == null) return string.Empty;
            if (!dt.Columns.Contains("AutoCode")) return string.Empty;//��ʱ��ʾ�洢����û�з����Զ�����
            int iMaxValue = 0;
            int iTemp;
            string strTemp;
            foreach (DataRow dr in dt.Rows)
            {
                strTemp = dr["AutoCode"].ToString().Substring(dr["AutoCode"].ToString().Length - iSerailLen);
                if (!int.TryParse(strTemp, out iTemp))
                    continue;
                if (iTemp > iMaxValue)
                    iMaxValue = iTemp;
            }
            iMaxValue++;
            strTemp = iMaxValue.ToString();
            for (int i = strTemp.Length; i < iSerailLen; i++)
                strTemp = "0" + strTemp;
            return strRule + strTemp;
        }
        public virtual string GetAutoCode(Common.MyEnums.Modules module,string sArg)
        {
            string strSql = string.Format("SELECT * FROM V_Sys_AutoCode WHERE EnumNo={0}", (int)module);
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt.Rows.Count == 0)
                return string.Empty;
            string strRule = dt.Rows[0]["CodeRule"].ToString();
            string strCode = string.Empty;
            DateTime detNow;
            if (!Common.CommonFuns.GetSysCurrentDateTime(out detNow))
            {
                this.ShowMsg("��ȡ������ʱ�����");
                return string.Empty;
            }
            while (strRule.IndexOf("[yyyy]") >= 0)
                strRule = strRule.Replace("[yyyy]", detNow.ToString("yyyy"));
            while (strRule.IndexOf("[yy]") >= 0)
                strRule = strRule.Replace("[yy]", detNow.ToString("yy"));
            while (strRule.IndexOf("[MM]") >= 0)
                strRule = strRule.Replace("[MM]", detNow.ToString("MM"));
            while (strRule.IndexOf("[dd]") >= 0)
                strRule = strRule.Replace("[dd]", detNow.ToString("dd"));
            int iSerailLen;
            if (dt.Rows[0]["SerialLen"].Equals(DBNull.Value))
                iSerailLen = 1;
            else
                iSerailLen = (int)dt.Rows[0]["SerialLen"];
            #region ��Ӳ���ֵ
            if (sArg.Length > 0)
            {
                strRule = sArg + strRule;
            }
            #endregion
            strSql = string.Format("exec GetAutoCode {0},'{1}',{2},{3}", (int)module, strRule, iSerailLen, 0);
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt == null) return string.Empty;
            if (!dt.Columns.Contains("AutoCode")) return string.Empty;//��ʱ��ʾ�洢����û�з����Զ�����
            int iMaxValue = 0;
            int iTemp;
            string strTemp;
            foreach (DataRow dr in dt.Rows)
            {
                strTemp = dr["AutoCode"].ToString().Substring(dr["AutoCode"].ToString().Length - iSerailLen);
                if (!int.TryParse(strTemp, out iTemp))
                    continue;
                if (iTemp > iMaxValue)
                    iMaxValue = iTemp;
            }
            iMaxValue++;
            strTemp = iMaxValue.ToString();
            for (int i = strTemp.Length; i < iSerailLen; i++)
                strTemp = "0" + strTemp;
            return strRule + strTemp;
        }
        /// <summary>
        /// ��ȡ�Զ�����
        /// </summary>
        /// <param name="module">ģ��ö��ֵ</param>
        /// <returns></returns>
        public virtual string GetAutoCode(int iModule)
        {
            return this.GetAutoCode(iModule, 0);
        }
        /// <summary>
        /// ��ȡ�Զ�����
        /// </summary>
        /// <param name="module">ģ��ö��ֵ</param>
        /// <param name="argment">�˲������ã���ģ���ж������Ҫ�Զ�����ʱ�������ô˲�����ʾ</param>
        /// <returns></returns>
        public virtual string GetAutoCode(int iModule, int argment)
        {
            string strSql = string.Format("SELECT * FROM V_Sys_AutoCode WHERE EnumNo={0}", iModule);
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt.Rows.Count == 0)
                return string.Empty;
            string strRule = dt.Rows[0]["CodeRule"].ToString();
            string strCode = string.Empty;
            DateTime detNow;
            if (!Common.CommonFuns.GetSysCurrentDateTime(out detNow))
            {
                this.ShowMsg("��ȡ������ʱ�����");
                return string.Empty;
            }
            while (strRule.IndexOf("[yyyy]") >= 0)
                strRule = strRule.Replace("[yyyy]", detNow.ToString("yyyy"));
            while (strRule.IndexOf("[yy]") >= 0)
                strRule = strRule.Replace("[yy]", detNow.ToString("yy"));
            while (strRule.IndexOf("[MM]") >= 0)
                strRule = strRule.Replace("[MM]", detNow.ToString("MM"));
            while (strRule.IndexOf("[dd]") >= 0)
                strRule = strRule.Replace("[dd]", detNow.ToString("dd"));
            int iSerailLen;
            if (dt.Rows[0]["SerialLen"].Equals(DBNull.Value))
                iSerailLen = 1;
            else
                iSerailLen = (int)dt.Rows[0]["SerialLen"];
            strSql = string.Format("exec GetAutoCode {0},'{1}',{2},{3}", iModule, strRule, iSerailLen, argment);
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt == null) return string.Empty;
            if (!dt.Columns.Contains("AutoCode")) return string.Empty;//��ʱ��ʾ�洢����û�з����Զ�����
            int iMaxValue = 0;
            int iTemp;
            string strTemp;
            foreach (DataRow dr in dt.Rows)
            {
                strTemp = dr["AutoCode"].ToString().Substring(dr["AutoCode"].ToString().Length - iSerailLen);
                if (!int.TryParse(strTemp, out iTemp))
                    continue;
                if (iTemp > iMaxValue)
                    iMaxValue = iTemp;
            }
            iMaxValue++;
            strTemp = iMaxValue.ToString();
            for (int i = strTemp.Length; i < iSerailLen; i++)
                strTemp = "0" + strTemp;
            return strRule + strTemp;
        }
        public virtual string GetAutoCode(int iModule, string sArg)
        {
            string strSql = string.Format("SELECT * FROM V_Sys_AutoCode WHERE EnumNo={0}", iModule);
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt.Rows.Count == 0)
                return string.Empty;
            string strRule = dt.Rows[0]["CodeRule"].ToString();
            string strCode = string.Empty;
            DateTime detNow;
            if (!Common.CommonFuns.GetSysCurrentDateTime(out detNow))
            {
                this.ShowMsg("��ȡ������ʱ�����");
                return string.Empty;
            }
            while (strRule.IndexOf("[yyyy]") >= 0)
                strRule = strRule.Replace("[yyyy]", detNow.ToString("yyyy"));
            while (strRule.IndexOf("[yy]") >= 0)
                strRule = strRule.Replace("[yy]", detNow.ToString("yy"));
            while (strRule.IndexOf("[MM]") >= 0)
                strRule = strRule.Replace("[MM]", detNow.ToString("MM"));
            while (strRule.IndexOf("[dd]") >= 0)
                strRule = strRule.Replace("[dd]", detNow.ToString("dd"));
            int iSerailLen;
            if (dt.Rows[0]["SerialLen"].Equals(DBNull.Value))
                iSerailLen = 1;
            else
                iSerailLen = (int)dt.Rows[0]["SerialLen"];
            #region ��Ӳ���ֵ
            if (sArg.Length > 0)
            {
                strRule = sArg + strRule;
            }
            #endregion
            strSql = string.Format("exec GetAutoCode {0},'{1}',{2},{3}", iModule, strRule, iSerailLen, 0);
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt == null) return string.Empty;
            if (!dt.Columns.Contains("AutoCode")) return string.Empty;//��ʱ��ʾ�洢����û�з����Զ�����
            int iMaxValue = 0;
            int iTemp;
            string strTemp;
            foreach (DataRow dr in dt.Rows)
            {
                strTemp = dr["AutoCode"].ToString().Substring(dr["AutoCode"].ToString().Length - iSerailLen);
                if (!int.TryParse(strTemp, out iTemp))
                    continue;
                if (iTemp > iMaxValue)
                    iMaxValue = iTemp;
            }
            iMaxValue++;
            strTemp = iMaxValue.ToString();
            for (int i = strTemp.Length; i < iSerailLen; i++)
                strTemp = "0" + strTemp;
            return strRule + strTemp;
        }
        /// <summary>
        /// ��ϵͳ����ļ�������
        /// </summary>
        /// <param name="module"></param>
        /// <param name="objPrimaryKey"></param>
        public virtual void ModuleFiles(Common.MyEnums.Modules module, object objPrimaryKey,string strUserCode)
        {

        }
        public virtual void ModuleOutPut(Common.MyEnums.Modules module, object objPrimaryKey, string strUserCode)
        {

        }
        public virtual void ModulePrint(Common.MyEnums.Modules module, object objPrimaryKey, string strUserCode)
        {

        }
        #endregion
        #region ��Web��Ϣ
        public void OpenUrl(string sUrl)
        {

        }
        #endregion
        #region ���봰�����
        public virtual void InitParameters(string[] arrs)
        {

        }
        #endregion
        #region ��ȡ�༭�����״̬��Ϣ
        public virtual string GetEditFormText(string sCode, Common.MyEnums.FormStates state)
        {
            return string.Empty;
        }
        #endregion
    }
    public delegate void FormLoadedCallback(bool blSucessfule, string sMsg);
}