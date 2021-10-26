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
    public partial class frmBreakdownCaseEdit : frmBase
    {
        public frmBreakdownCaseEdit()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.MacBreakdownCase _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.MacBreakdownCase BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.MacBreakdownCase();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql;
            strSql = "SELECT Code,LevelDesc FROM JC_MacBreakdownCaseLevel WHERE ISNULL(Terminated,0)=0 ORDER BY SortID";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_MacBreakdownCaseLevel", true));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT Code,ProcessName FROM JC_Process WHERE ISNULL(Terminated,0)=0 ORDER BY SortID", "JC_Process", true));
            strSql = "SELECT Code,ClassName FROM JC_MacBreakdownCaseClass WHERE ISNULL(Terminated,0)=0 ORDER BY SortID";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_MacBreakdownCaseClass", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comLevel.DisplayMember = "Text";
            this.comLevel.ValueMember = "Value";
            foreach (DataRow dr in ds.Tables["JC_MacBreakdownCaseLevel"].Rows)
            {
                comLevel.Items.Add(new Common.MyEntity.ComboBoxItem(dr["LevelDesc"].ToString(), dr["Code"].ToString()));
            }
            this.comProcess.DisplayMember = "Text";
            this.comProcess.ValueMember = "Value";
            foreach (DataRow dr in ds.Tables["JC_Process"].Rows)
            {
                comProcess.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ProcessName"].ToString(), dr["Code"].ToString()));
            }
            this.comClass.DisplayMember = "Text";
            this.comClass.ValueMember = "Value";
            foreach (DataRow dr in ds.Tables["JC_MacBreakdownCaseClass"].Rows)
            {
                comClass.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ClassName"].ToString(), dr["Code"].ToString()));
            }
            this.chkIsSys.Enabled = Common.CurrentUserInfo.IsSuper;
            return true;
        }
        private bool BindData(string strCode)
        {
            DataSet ds=null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM JC_MacBreakdownCase WHERE Code='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_MacBreakdownCase", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (ds.Tables["JC_MacBreakdownCase"].DefaultView.Count == 0)
            {
                this.ShowMsg("当前异常内容不存在或已经被删除，请检查！");
                return false;
            }
            DataRow dr = ds.Tables["JC_MacBreakdownCase"].DefaultView[0].Row;
            this.tbCode.Text = dr["Code"].ToString();
            this.tbRemark.Text = dr["CaseDesc"].ToString();
            Common.CommonFuns.FormatData.SetComboBoxText(this.comLevel, new Common.MyEntity.ComboBoxItem("", dr["LevelCode"].ToString()), 0);
            Common.CommonFuns.FormatData.SetComboBoxText(this.comClass, new Common.MyEntity.ComboBoxItem("", dr["ClassCode"].ToString()), 0);
            Common.CommonFuns.FormatData.SetComboBoxText(this.comProcess, new Common.MyEntity.ComboBoxItem("", dr["ProcessCode"].ToString()), 0);
            this.chkTerminated.Checked = !dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"];
            this.chkIsSys.Checked = !dr["IsSys"].Equals(DBNull.Value) && (bool)dr["IsSys"];
            this.DataSource = ds;
            SetFormState();
            return true;
        }
        private bool ReBindLevel()
        {
            DataTable dt;
            string strSql;
            strSql = "SELECT Code,LevelDesc FROM JC_MacBreakdownCaseLevel WHERE ISNULL(Terminated,0)=0 ORDER BY SortID";
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comLevel.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                comLevel.Items.Add(new Common.MyEntity.ComboBoxItem(dr["LevelDesc"].ToString(), dr["Code"].ToString()));
            }
            return true;
        }
        private bool ReBindClass()
        {
            DataTable dt;
            string strSql;
            strSql = "SELECT Code,ClassName FROM JC_MacBreakdownCaseClass WHERE ISNULL(Terminated,0)=0 ORDER BY SortID";
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comClass.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                comClass.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ClassName"].ToString(), dr["Code"].ToString()));
            }
            return true;
        }
        private void SetFormState()
        {
            this.btTrue.Enabled = !this.chkIsSys.Checked || (this.chkIsSys.Checked && Common.CurrentUserInfo.IsSuper);
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.DataSource==null)
            {
                this.ShowMsg("数据源丢失！");
                return false;
            }
            if (this.DataSource.Tables["JC_MacBreakdownCase"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据未能加载，请重新打开窗口！");
                return false;
            }
            if (string.Compare(this.DataSource.Tables["JC_MacBreakdownCase"].DefaultView[0].Row["Code"].ToString(), this.tbCode.Text, true) != 0)
            {
                //如果编码已经修改过，则要判断是否编码已经存在了
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_MacBreakdownCase WHERE Code='{0}'", this.tbCode.Text.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("异常代码“" + this.tbCode.Text + "”已经存在，请更换");
                    return false;
                }
            }
            if (this.tbRemark.Text.Length == 0)
            {
                this.ShowMsg("请输入异常内容！");
                return false;
            }
            Common.MyEntity.ComboBoxItem item = this.comLevel.SelectedItem as Common.MyEntity.ComboBoxItem;
            if(item==null || item.Value==null || item.Value.ToString().Length==0)
            {
                this.ShowMsg("请选择异常等级。");
                return false;
            }
            return true;
        }
        private bool Save()
        {
            DataRow dr = this.DataSource.Tables["JC_MacBreakdownCase"].DefaultView[0].Row;
            if (!dr["Code"].Equals(this.tbCode.Text.Trim()))
                dr["Code"] = this.tbCode.Text.Trim();
            if (!dr["CaseDesc"].Equals(this.tbRemark.Text.Trim()))
                dr["CaseDesc"] = this.tbRemark.Text.Trim();
            object objValue = GetComboBoxValue(this.comLevel);
            if (!dr["LevelCode"].Equals(objValue))
                dr["LevelCode"] = objValue;
            objValue = GetComboBoxValue(this.comClass);
            if (!dr["ClassCode"].Equals(objValue))
                dr["ClassCode"] = objValue;
            objValue = GetComboBoxValue(this.comProcess);
            if (!dr["ProcessCode"].Equals(objValue))
                dr["ProcessCode"] = objValue;
            if ((!dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"]) ^ this.chkTerminated.Checked)
                dr["Terminated"] = this.chkTerminated.Checked;
            if ((!dr["IsSys"].Equals(DBNull.Value) && (bool)dr["IsSys"]) ^ this.chkIsSys.Checked)
                dr["IsSys"] = this.chkIsSys.Checked;
            if (this.DataSource.GetChanges() == null)
                return true;
            try
            {
                this.BllDAL.Save(this.DataSource);
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
            if (!this.SaveCheck()) return;
            if (this.Save())
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void frmUnitEdit_Load(object sender, EventArgs e)
        {
            if (!this.PerInit()) return;
            this.BindData(this.PrimaryValue == null ? "" : this.PrimaryValue.ToString());
        }

        private void picLevelAdd_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdownCase);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有编辑计量异常模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            frmBdownCaseLevel frm = new frmBdownCaseLevel();
            frm.ShowDialog(this);
            this.ReBindLevel();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ///校验用户权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdownCase);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("您没有编辑计量异常模块权限，如果需要请联系管理员开放该权限。");
                return;
            }
            frmBdownCaseClass frm = new frmBdownCaseClass();
            frm.ShowDialog(this);
            this.ReBindClass();
        }
    }
}