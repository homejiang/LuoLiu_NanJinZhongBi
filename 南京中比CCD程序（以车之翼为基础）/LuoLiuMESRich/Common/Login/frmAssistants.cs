using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace Common.Login
{
    public partial class frmAssistants : Common.frmBaseEdit
    {
        public frmAssistants()
        {
            InitializeComponent();
        }
        public List<Common.MyEntity.Job> _SelectedData = null;
        private DataTable _DataTable = null;
        private bool Perinit()
        {
            this.dgvList.AutoGenerateColumns = false;
            _DataTable = new DataTable();
            _DataTable.Columns.Add("Code", Type.GetType("System.String"));
            _DataTable.Columns.Add("JobName", Type.GetType("System.String"));
            _DataTable.Columns.Add("UserCode", Type.GetType("System.String"));
            _DataTable.Columns.Add("UserName", Type.GetType("System.String"));
            _DataTable.Columns.Add("JobDesc", Type.GetType("System.String"));
            _DataTable.Columns.Add("ID", Type.GetType("System.Int32"));
            _DataTable.Columns["ID"].AutoIncrement = true;
            _DataTable.DefaultView.Sort = "ID ASC";
            return true;
        }
        private bool BindData()
        {
            if (_SelectedData != null && _SelectedData.Count > 0)
            {
                foreach (Common.MyEntity.Job job in _SelectedData)
                {
                    DataRow drNew = _DataTable.NewRow();
                    drNew["Code"] = job.JobCode;
                    drNew["JobName"] = job.JobName;
                    drNew["UserCode"] = job.UserCode;
                    drNew["UserName"] = job.UserName;
                    drNew["JobDesc"] = job.JobDesc;
                    _DataTable.Rows.Add(drNew);
                }
            }
            this.dgvList.DataSource = _DataTable;
            return true;
        }
        private void frmAssistants_Load(object sender, EventArgs e)
        {
            this.btTrue.Enabled = this.Perinit() && this.BindData();
            this.btAdd.Enabled = this.btRemove.Enabled = this.btTrue.Enabled;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Common.ProcessJobs.frmSelectJobs frm = new Common.ProcessJobs.frmSelectJobs();
            frm.MultiSelected = true;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData.Count == 0) return;
            foreach (Common.ProcessJobs.frmSelectJobs.SelectedJobInfo info in frm.SelectedData)
            {
                DataRow drNew = _DataTable.NewRow();
                drNew["Code"] = info.Code.ToString();
                drNew["JobName"] = info.JobName.ToString();
                drNew["JobDesc"] = info.JobDesc.ToString();
                _DataTable.Rows.Add(drNew);
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            List<int> listID = new List<int>();
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                listID.Add((int)_DataTable.DefaultView[this.dgvList.SelectedRows[i].Index].Row["ID"]);
            }
            DataRow[] drs;
            foreach (int i in listID)
            {
                drs = _DataTable.Select("ID=" + i.ToString());
                drs[0].Delete();
            }
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if (_DataTable.Select("ISNULL(UserCode,'')=''").Length > 0)
            {
                this.ShowMsg("请输入员工工号。");
                return;
            }
            if (_DataTable.Select("ISNULL(UserName,'')=''").Length > 0)
            {
                this.ShowMsg("输入员工工号后请按回车或将焦点移至其他地方，以便校验您输入的工号是否正确。");
                return;
            }
            //检查是否有相同工种相同人员的，这是不允许的
            //主操不能添加为助理
            if (_DataTable.Select(string.Format("Usercode='{0}'", Common.CurrentUserInfo.UserCode)).Length > 0)
            {
                this.ShowMsg("主操不能被添加为助理岗位中。");
                return;
            }
            foreach (DataRowView drv in _DataTable.DefaultView)
            {
                if (_DataTable.Select(string.Format("Usercode='{0}' AND Code='{1}'", drv.Row["Usercode"], drv.Row["Code"])).Length > 1)
                {
                    this.ShowMsg("有重复数据（同一岗位同一个人）。");
                    return;
                }
            }
            _SelectedData = new List<Common.MyEntity.Job>();
            Common.MyEntity.Job newjob;
            foreach (DataRowView drv in _DataTable.DefaultView)
            {
                newjob = new Common.MyEntity.Job();
                newjob.JobCode = drv.Row["Code"].ToString();
                newjob.JobName = drv.Row["JobName"].ToString();
                newjob.JobDesc = drv.Row["JobDesc"].ToString();
                newjob.UserCode = drv.Row["UserCode"].ToString();
                newjob.UserName = drv.Row["UserName"].ToString();
                _SelectedData.Add(newjob);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void dgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (string.Compare(this.dgvList.Columns[e.ColumnIndex].DataPropertyName, "UserCode", true) != 0)
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strCode = dt.DefaultView[e.RowIndex].Row["UserCode"].ToString();
            DataTable dtUser;
            try
            {
                dtUser = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("select UserName from sys_users WHERE Usercode='{0}'", strCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dtUser.Rows.Count == 0)
            {
                dt.DefaultView[e.RowIndex].Row["UserName"] = DBNull.Value;
            }
            else
                dt.DefaultView[e.RowIndex].Row["UserName"] = dtUser.Rows[0]["UserName"];
        }
    }
}