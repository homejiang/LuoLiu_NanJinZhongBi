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

namespace AutoAssign.BasicData
{
    public partial class frmQualityDesc : Common.frmBase
    {
        public frmQualityDesc()
        {
            InitializeComponent();
            this.dgvList.AutoGenerateColumns = false;
        }
        private bool BindData()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("select * from V_JC_QualityDesc");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "QualityDescBind");
                return false;
            }
            this.dgvList.DataSource = dt;
            return true; ;
        }

        private void frmProcessCode_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            if (this.BindData())
                this.ShowMsgRich("刷新成功！");
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!JPSFuns.CheckUserPower())
                return;
            if(this.tbQualityDesc.Text.Length==0)
            {
                this.ShowMsg("请输入品质描述！");
                return;
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT COUNT(*) FROM JC_QualityDesc WHERE QualityDesc='{0}'", this.tbQualityDesc.Text.Replace("'","''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "校验规格是否存在");
                return;
            }
            if(int.Parse(dt.Rows[0][0].ToString())>0)
            {
                this.ShowMsg("品质描述已经存在！");
                return;
            }
            string sGuid = Guid.NewGuid().ToString();
            string strSql = string.Format("INSERT INTO JC_QualityDesc(GUID,QualityDesc) VALUES('{0}','{1}')", sGuid.Replace("'", "''"), this.tbQualityDesc.Text.Replace("'", "''"));
            try
            {
                Common.CommonDAL.DoSqlCommandBasic.DoSql(strSql);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "DOSQL.insert");
                return;
            }
            this.tbQualityDesc.Clear();
            this.BindData();
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (!JPSFuns.CheckUserPower())
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源为空。");
                return;
            }
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要删除的行。");
                return;
            }
            bool blUpdated = false;
            foreach (int row in list)
            {
                string sGuid = dt.DefaultView[row].Row["Guid"].ToString();
                string strSql = string.Format("delete from JC_QualityDesc where Guid='{0}'", sGuid.Replace("'", "''"));
                try
                {
                    Common.CommonDAL.DoSqlCommandBasic.DoSql(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "DOSQL.delete.processGuid");
                    break;
                }
                blUpdated = true;
            }
            if (blUpdated)
                this.BindData();
        }

        private void tsbOn_Click(object sender, EventArgs e)
        {
            if (!JPSFuns.CheckUserPower())
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源为空。");
                return;
            }
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要删除的行。");
                return;
            }
            bool blUpdated = false;
            foreach (int row in list)
            {
                string sGuid = dt.DefaultView[row].Row["Guid"].ToString();
                string strSql = string.Format("update JC_QualityDesc set Terminated=0 where Guid='{0}'", sGuid.Replace("'", "''"));
                try
                {
                    Common.CommonDAL.DoSqlCommandBasic.DoSql(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "DOSQL.delete.Terminated.0");
                    break;
                }
                blUpdated = true;
            }
            if (blUpdated)
                this.BindData();
        }

        private void tsbOff_Click(object sender, EventArgs e)
        {
            if (!JPSFuns.CheckUserPower())
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源为空。");
                return;
            }
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要删除的行。");
                return;
            }
            bool blUpdated = false;
            foreach (int row in list)
            {
                string sGuid = dt.DefaultView[row].Row["Guid"].ToString();
                string strSql = string.Format("update JC_QualityDesc set Terminated=1 where Guid='{0}'", sGuid.Replace("'", "''"));
                try
                {
                    Common.CommonDAL.DoSqlCommandBasic.DoSql(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "DOSQL.delete.Terminated.1");
                    break;
                }
                blUpdated = true;
            }
            if (blUpdated)
                this.BindData();
        }
    }
}
