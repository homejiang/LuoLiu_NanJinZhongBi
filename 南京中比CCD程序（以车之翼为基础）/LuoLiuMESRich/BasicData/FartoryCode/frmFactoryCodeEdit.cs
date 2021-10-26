using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;

namespace BasicData.FactoryCode
{
    public partial class frmFactoryCodeEdit : frmBase
    {
        public frmFactoryCodeEdit()
        {
            InitializeComponent();
        }
        #region 打开窗口
        public static void OpenEditFormByTester(IWin32Window owner,string sMacCode)
        {
            BasicData.FactoryCode.frmFactoryCodeEdit frm = new BasicData.FactoryCode.frmFactoryCodeEdit();
            frm._OpenFromTester = true;
            frmMainBase frmbase = new frmMainBase();
            List<Common.MyEnums.OperatePower> listPower = frmbase.GetOperatePower(Common.MyEnums.Modules.FactoryCode);
            if (listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                frm.FormState = Common.MyEnums.FormStates.Edit;
            }
            else
            {
                frm.FormState = Common.MyEnums.FormStates.Readonly;
                frm.Text += "（只读）";
            }
            frm.PrimaryValue = sMacCode;
            frm.ShowDialog(owner);
        }
        #endregion
        #region 窗体数据连接实例
        private BLLDAL.FactoryCode _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.FactoryCode BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.FactoryCode();
                return _dal;
            }
        }
        #endregion
        #region 公共属性
        public bool _OpenFromTester = false;
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            this.tbCode.ReadOnly = _OpenFromTester;
            this.tbCodeName.ReadOnly = _OpenFromTester;
            this.tbRemark.ReadOnly = _OpenFromTester;
            this.chkTerminated.Enabled = !_OpenFromTester;
            this.btTrue.Enabled = this.FormState == Common.MyEnums.FormStates.Edit;
            return true;
        }
        private bool BindData(string strCode)
        {
            DataSet ds=null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM JC_FactoryCode WHERE Code='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_FactoryCode", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (ds.Tables["JC_FactoryCode"].DefaultView.Count == 0)
            {
                this.ShowMsg("传入的系统编码不存在或已经被删除，请检查！");
                return false;
            }
            DataRow dr=ds.Tables["JC_FactoryCode"].DefaultView[0].Row;
            this.tbCode.Text = dr["Code"].ToString();
            this.tbCodeName.Text = dr["CodeName"].ToString();
            this.tbAnotherName.Text = dr["AnotherName"].ToString();
            this.tbRemark.Text = dr["Remark"].ToString();
            this.chkTerminated.Checked = !dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"];
            this.DataSource = ds;
            SetFormState();
            return true;
        }
        private void SetFormState()
        {
            
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失！");
                return false;
            }
            if (this.DataSource.Tables["JC_FactoryCode"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据未能加载，请重新打开窗口！");
                return false;
            }
            if (string.Compare(this.DataSource.Tables["JC_FactoryCode"].DefaultView[0].Row["Code"].ToString(), this.tbCode.Text, true) != 0)
            {
                //如果编码已经修改过，则要判断是否编码已经存在了
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_FactoryCode WHERE Code='{0}'", this.tbCode.Text.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("系统编码“" + this.tbCode.Text + "”已经存在，请更换");
                    return false;
                }
            }
            return true;
        }
        private bool Save(DataSet dsSource)
        {
            DataRow dr = dsSource.Tables["JC_FactoryCode"].DefaultView[0].Row;
            if (dr["Code"].ToString() != this.tbCode.Text)
                dr["Code"] = this.tbCode.Text;
            if (dr["CodeName"].ToString() != this.tbCodeName.Text)
                dr["CodeName"] = this.tbCodeName.Text;
            if (dr["AnotherName"].ToString() != this.tbAnotherName.Text)
                dr["AnotherName"] = this.tbAnotherName.Text;
            if (dr["Remark"].ToString() != this.tbRemark.Text)
                dr["Remark"] = this.tbRemark.Text;
            if ((!dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"]) ^ this.chkTerminated.Checked)
                dr["Terminated"] = this.chkTerminated.Checked;
           
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
        #endregion
        #region 窗体按钮事件
        private void btTrue_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，请重新打开窗体");
                return;
            } 
            if (this.FormState !=Common.MyEnums.FormStates.Edit )
            {
                this.ShowMsg("当前窗体状态不能编辑。");
                return;
            }
            if (!this.SaveCheck()) return;
            DataSet dsSource = this.DataSource.Copy();
            if (this.Save(dsSource))
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
            this.btTrue.Enabled = this.BindData(this.PrimaryValue == null ? "" : this.PrimaryValue.ToString());
        }
    }

}