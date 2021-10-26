using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;
using Common.MyEntity;

namespace BasicData.ProcessMacs
{
    public partial class frmProcessMacsEdit : frmBase
    {
        public frmProcessMacsEdit()
        {
            InitializeComponent();
        }
        #region 打开窗口
        public static void OpenEditFormByTester(IWin32Window owner,string sMacCode)
        {
            BasicData.ProcessMacs.frmProcessMacsEdit frm = new BasicData.ProcessMacs.frmProcessMacsEdit();
            frm._OpenFromTester = true;
            frmMainBase frmbase = new frmMainBase();
            List<Common.MyEnums.OperatePower> listPower = frmbase.GetOperatePower(Common.MyEnums.Modules.ProcessMacs);
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
        private BLLDAL.ProcessMacs _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.ProcessMacs BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.ProcessMacs();
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
            this.tbMacCode.ReadOnly = _OpenFromTester;
            this.tbMacName.ReadOnly = _OpenFromTester;
            this.tbAds.ReadOnly = _OpenFromTester;
            this.chkTerminated.Enabled = !_OpenFromTester;
            this.btTrue.Enabled = this.FormState == Common.MyEnums.FormStates.Edit;
            //绑定下拉列表
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "select Code,ProcessName from JC_Process where isnull(Terminated,0)=0 ORDER BY SortID ASC";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_Process", true));

            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //绑定下拉菜单
            Common.MyEntity.ComboBoxItem item;
            this.ComProcess.DisplayMember = "Text";
            foreach (DataRow dr in ds.Tables["JC_Process"].Rows)
            {
                item = new Common.MyEntity.ComboBoxItem(dr["ProcessName"].ToString(), dr["Code"].ToString());
                this.ComProcess.Items.Add(item);
            }
            return true;
        }
        private bool BindData(string strCode)
        {
            DataSet ds=null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM V_JC_ProcessMacs WHERE Code='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_ProcessMacs", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (ds.Tables["JC_ProcessMacs"].DefaultView.Count == 0)
            {
                this.ShowMsg("传入的OTDR设备不存在或已经被删除，请检查！");
                return false;
            }
            DataRow dr=ds.Tables["JC_ProcessMacs"].DefaultView[0].Row;
            this.tbMacCode.Text = dr["Code"].ToString();
            this.tbMacName.Text = dr["MacName"].ToString();
            this.tbAds.Text = dr["Address"].ToString();
            this.tbRemark.Text = dr["Remark"].ToString();
            this.chkTerminated.Checked = !dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"];
            Common.CommonFuns.FormatData.SetComboBoxText(this.ComProcess, new Common.MyEntity.ComboBoxItem("", dr["Code"].ToString()), 0);
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
            if (this.DataSource.Tables["JC_ProcessMacs"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据未能加载，请重新打开窗口！");
                return false;
            }
            if (string.Compare(this.DataSource.Tables["JC_ProcessMacs"].DefaultView[0].Row["Code"].ToString(), this.tbMacCode.Text, true) != 0)
            {
                //如果编码已经修改过，则要判断是否编码已经存在了
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_ProcessMacs WHERE MacCode='{0}'", this.tbMacCode.Text.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("设备编码“" + this.tbMacCode.Text + "”已经存在，请更换");
                    return false;
                }
            }
            return true;
        }
        private bool Save(DataSet dsSource)
        {
            DataRow dr = dsSource.Tables["JC_ProcessMacs"].DefaultView[0].Row;
            if (dr["Code"].ToString() != this.tbMacCode.Text)
                dr["Code"] = this.tbMacCode.Text;
            if (dr["MacName"].ToString() != this.tbMacName.Text)
                dr["MacName"] = this.tbMacName.Text;
            if (dr["Address"].ToString() != this.tbAds.Text)
                dr["Address"] = this.tbAds.Text;
            if (dr["Remark"].ToString() != this.tbRemark.Text)
                dr["Remark"] = this.tbRemark.Text;
            if ((!dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"]) ^ this.chkTerminated.Checked)
                dr["Terminated"] = this.chkTerminated.Checked;
            ComboBoxItem item = this.ComProcess.SelectedItem as ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString() == "")
            {
                this.ShowMsg("请选择工序。");
                return false;
            }
            dr["ProcessCode"] = item.Value.ToString();
            int iSortID;
            if (dsSource.Tables["JC_ProcessMacs"].DefaultView.Count == 0)
                iSortID = 1;
            else
            {
                if (string.Compare(dsSource.Tables["JC_ProcessMacs"].DefaultView.Sort, "SortID ASC", true) != 0)
                    dsSource.Tables["JC_ProcessMacs"].DefaultView.Sort = "SortID ASC";
                iSortID = int.Parse(dsSource.Tables["JC_ProcessMacs"].DefaultView[dsSource.Tables["JC_ProcessMacs"].DefaultView.Count - 1].Row["SortID"].ToString()) + 1;
            }
            dr["SortID"] = iSortID;

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