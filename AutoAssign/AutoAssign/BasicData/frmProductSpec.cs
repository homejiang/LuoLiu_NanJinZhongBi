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
    public partial class frmProductSpec : Common.frmBase
    {
        public frmProductSpec()
        {
            InitializeComponent();
            this.dgvList.AutoGenerateColumns = false;
        }
        private bool BindProductClass()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("select * from JC_ProductClass");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "bindProductClass");
                return false;
            }
            this.treeView1.Nodes.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                TreeNode tn = new TreeNode();
                tn.Tag = dr["Value"].ToString();
                tn.Text = string.Format("{0}({1})[扫描枪{2}]",dr["ClassName"].ToString(), dr["Value"].ToString(), dr["Scanner"].ToString());
                this.treeView1.Nodes.Add(tn);
            }
            return true; ;
        }
        private bool BindData()
        {
            string strSql = "select * from V_JC_ProductSpec where 1=1";
            TreeNode tn = this.treeView1.SelectedNode as TreeNode;
            if (tn != null && tn.Tag != null && tn.Tag.ToString().Length > 0)
            {
                strSql += string.Format(" AND ClassValue=" + tn.Tag.ToString());
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "processBindDatas");
                return false;
            }
            this.dgvList.DataSource = dt;
            return true; ;
        }

        private void frmProcessCode_Load(object sender, EventArgs e)
        {
            this.BindProductClass();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            if (this.BindData())
                this.ShowMsgRich("刷新成功！");
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
                string strSql = string.Format("delete from JC_ProductSpec where Guid='{0}'", sGuid.Replace("'", "''"));
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
                string strSql = string.Format("update JC_ProductSpec set Terminated=0 where Guid='{0}'", sGuid.Replace("'", "''"));
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
                string strSql = string.Format("update JC_ProductSpec set Terminated=1 where Guid='{0}'", sGuid.Replace("'", "''"));
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = this.treeView1.SelectedNode as TreeNode;
            if (tn==null || tn.Tag==null)
            {
                this.dgvList.DataSource = null;
            }
            else
            {
                this.BindData();
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.treeView1.SelectedNode as TreeNode;
            if (tn == null || tn.Tag == null || tn.Tag.ToString().Length==0)
            {
                this.ShowMsg("请选择电芯分类");
                return;
            }
            short iClassValue;
            if(!short.TryParse(tn.Tag.ToString(),out iClassValue))
            {
                this.ShowMsg("电芯分类标识读取错误。");
                return;
            }
            frmProuctSpecEdit frm = new frmProuctSpecEdit(string.Empty, iClassValue);
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.BindData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!JPSFuns.CheckUserPower())
                return;
            TreeNode tn = this.treeView1.SelectedNode as TreeNode;
            if (tn == null || tn.Tag == null || tn.Tag.ToString().Length == 0)
            {
                this.ShowMsg("请选择要删除的电芯分类");
                return;
            }
            short iClassValue;
            if (!short.TryParse(tn.Tag.ToString(), out iClassValue))
            {
                this.ShowMsg("电芯分类标识读取错误。");
                return;
            }
            if (!this.IsUserConfirm("您确定要删除选中的电芯分类？")) return;
            string strSql = string.Format("DELETE FROM JC_ProductClass WHERE Value=" + iClassValue.ToString());
            try
            {
                Common.CommonDAL.DoSqlCommandBasic.DoSql(strSql);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindProductClass();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmProuctClassEdit frm = new frmProuctClassEdit();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.BindProductClass();
        }

        private void tsbClassEdit_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.treeView1.SelectedNode as TreeNode;
            if (tn == null)
                return;
            if (tn.Tag == null)
            {
                this.ShowMsg("PLC标识读取失败！");
                return;
            }
            if (tn.Tag.ToString().Length == 0)
            {
                this.ShowMsg("PLC标识读取错误！");
                return;
            }
            int iClassValue;
            if (!int.TryParse(tn.Tag.ToString(), out iClassValue))
            {
                this.ShowMsg("PLC标识[" + tn.Tag.ToString() + "]不是有效的整型！");
                return;
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("select classname from JC_ProductClass where value=" + iClassValue.ToString());
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "查找plcValue");
                return;
            }
            frmProuctClassEdit frm = new frmProuctClassEdit();
            frm._ClassValue = (short)iClassValue;
            if (dt.Rows.Count > 0)
                frm.ClassName = dt.Rows[0]["classname"].ToString();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.BindProductClass();
        }
    }
}
