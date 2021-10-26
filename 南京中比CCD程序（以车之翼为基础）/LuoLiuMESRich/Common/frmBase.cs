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
        #region 窗体公共属性
        #region 窗体关键字
        private object _objPrimaryValue = null;
        /// <summary>
        /// 关键字值
        /// </summary>
        public object PrimaryValue
        {
            get { return this._objPrimaryValue; }
            set { this._objPrimaryValue = value; }
        }
        #endregion
        #region 窗体数据源
        private DataSet _dataSource = null;
        /// <summary>
        /// 窗体数据源
        /// </summary>
        public DataSet DataSource
        {
            get { return this._dataSource; }
            set { this._dataSource = value; }
        }
        #endregion
        #region 窗体状态
        private Common.MyEnums.FormStates _formstate = Common.MyEnums.FormStates.None;
        /// <summary>
        /// 当前窗体状态
        /// </summary>
        public Common.MyEnums.FormStates FormState
        {
            get { return this._formstate; }
            set { this._formstate = value; }
        }
        #endregion
        #region 父级MDI窗体对象
        private frmMdiBase _parentMDI = null;
        /// <summary>
        /// 父级MDI窗体
        /// </summary>
        public frmMdiBase ParentMDI
        {
            get { return this._parentMDI; }
            set { this._parentMDI = value; }
        }
        #endregion
        #region 父级frmBase窗体对象
        private frmBase _frmParent = null;
        /// <summary>
        /// 母窗体
        /// </summary>
        public frmBase FormParent
        {
            get { return this._frmParent; }
            set { this._frmParent = value; }
        }
        #endregion
        #endregion
        #region 系统公共函数
        //关闭窗口前先检查，是否可以直接关闭
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
            //窗体关闭时调用，如果窗体有需要执行的操作，可在窗体中重写此方法
        }
        //刷新父级窗体，但父窗体必须先overid该方法，objArg为参数，当父级窗体打开多种个子窗体时，可以用到
        public virtual bool RefreshParetForm(object objArg)
        {
            return true;
        }
        /// <summary>
        /// 打开窗体
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
        /// 改变窗体标题
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
        /// 获取自动编码
        /// </summary>
        /// <param name="module">模块枚举值</param>
        /// <returns></returns>
        public virtual string GetAutoCode(Common.MyEnums.Modules module)
        {
            return this.GetAutoCode(module, 0);
        }
        /// <summary>
        /// 获取自动编码
        /// </summary>
        /// <param name="module">模块枚举值</param>
        /// <param name="argment">此参数备用，当模块中多个表需要自动编码时，可以用此参数标示</param>
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
                this.ShowMsg("获取服务器时间出错。");
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
            if (!dt.Columns.Contains("AutoCode")) return string.Empty;//此时表示存储过程没有返回自动编码
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
                this.ShowMsg("获取服务器时间出错。");
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
            #region 添加参数值
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
            if (!dt.Columns.Contains("AutoCode")) return string.Empty;//此时表示存储过程没有返回自动编码
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
        /// 获取自动编码
        /// </summary>
        /// <param name="module">模块枚举值</param>
        /// <returns></returns>
        public virtual string GetAutoCode(int iModule)
        {
            return this.GetAutoCode(iModule, 0);
        }
        /// <summary>
        /// 获取自动编码
        /// </summary>
        /// <param name="module">模块枚举值</param>
        /// <param name="argment">此参数备用，当模块中多个表需要自动编码时，可以用此参数标示</param>
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
                this.ShowMsg("获取服务器时间出错。");
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
            if (!dt.Columns.Contains("AutoCode")) return string.Empty;//此时表示存储过程没有返回自动编码
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
                this.ShowMsg("获取服务器时间出错。");
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
            #region 添加参数值
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
            if (!dt.Columns.Contains("AutoCode")) return string.Empty;//此时表示存储过程没有返回自动编码
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
        /// 打开系统相关文件管理窗口
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
        #region 打开Web信息
        public void OpenUrl(string sUrl)
        {

        }
        #endregion
        #region 传入窗体参数
        public virtual void InitParameters(string[] arrs)
        {

        }
        #endregion
        #region 获取编辑窗体的状态信息
        public virtual string GetEditFormText(string sCode, Common.MyEnums.FormStates state)
        {
            return string.Empty;
        }
        #endregion
    }
    public delegate void FormLoadedCallback(bool blSucessfule, string sMsg);
}