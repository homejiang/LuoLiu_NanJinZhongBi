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
namespace AutoAssign.Debug
{
    public partial class frmTuoPanBtyErr : Common.frmBase
    {
        frmMain1 _MainForm = null;
        public frmTuoPanBtyErr(frmMain1 mainFrom)
        {
            InitializeComponent();
            this._MainForm = mainFrom;
            this.dgvList.AutoGenerateColumns = false;
        }
        string _ResultTable = string.Empty;
        string _BatterysTable = string.Empty;
        public void BindData(List<string> listTuoPanCode,string sResultTable, string sBatterysTable)
        {
            this._ResultTable = string.Empty;
            this._BatterysTable = string.Empty;
            string strTuopans = string.Empty;
            this.treeView1.Nodes.Clear();
            TreeNode tnSelected = null;
            int iMaxCount = 0;
            int iTemp;
            foreach(string sCode in listTuoPanCode)
            {
                if (sCode.Length == 0) continue;
                DataTable dt;
                string strSql = string.Format("SELECT COUNT(*) FROM {0} WHERE TuoCode='{1}'", sResultTable, sCode.Replace("'", "''"));
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
                }
                catch(Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    continue;
                }
                TreeNode tn = new TreeNode();
                iTemp = int.Parse(dt.Rows[0][0].ToString());
                tn.Text = string.Format("{0}({1})", sCode, iTemp);
                tn.Tag = sCode;
                this.treeView1.Nodes.Add(tn);
                if(iMaxCount<iTemp)
                {
                    //默认选中最大的
                    iMaxCount = iTemp;
                    tnSelected = tn;
                }
            }
            this._ResultTable = sResultTable;
            this._BatterysTable = sBatterysTable;
            if (tnSelected != null)
            {
                this.treeView1.SelectedNode = tnSelected;
            }
            else
            {
                this.dgvList.DataSource = null;
            }
            this.treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strCode = string.Empty;
            if (e.Node != null && e.Node.Tag!=null)
            {
                strCode = e.Node.Tag.ToString();
            }

            DataTable dt;
            string strSql = string.Format("SELECT A.*,B.SN,b.ScannerNo FROM {0} A LEFT JOIN {1} B ON B.Code=A.MyCode WHERE A.TuoCode='{2}'", this._ResultTable,this._BatterysTable, strCode.Replace("'", "''"));
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.dgvList.DataSource = dt;
        }

        private void btIgnore_Click(object sender, EventArgs e)
        {
            if (this._MainForm._MainControl != null && this._MainForm._MainControl._ResultControler != null)
            {
                this._MainForm._MainControl._ResultControler.Listen_IgnoreTuoPanBtyCountError = true;
            }
            this.Close();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            if (!this.IsUserConfirm("您确定要停止测试吗？")) return;
            this._MainForm.StopTest();
            this.Close();
        }
    }
}
