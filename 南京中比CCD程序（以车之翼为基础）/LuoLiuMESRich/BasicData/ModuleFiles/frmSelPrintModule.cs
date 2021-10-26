using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BasicData.ModuleFiles
{
    public partial class frmSelPrintModule : Common.frmBase
    {
        public frmSelPrintModule()
        {
            InitializeComponent();
            this.myDataGridView1.AutoGenerateColumns = false;
        }
        public string _ModuleName = string.Empty;
        public DataTable _DataSource
        {
            get
            {
                return this.myDataGridView1.DataSource as DataTable;
            }
            set
            {
                this.myDataGridView1.DataSource = value;
            }
        }
        public string _Title
        {
            get
            {
                return this.labTitle.Text;
            }
            set
            {
                this.labTitle.Text = value;
            }
        }
        private void frmSelPrintModule_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = this.myDataGridView1.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源获取失败！");
                return;
            }
            if (this.myDataGridView1.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中一行！");
                return;
            }
            this._ModuleName = dt.DefaultView[this.myDataGridView1.SelectedRows[0].Index].Row["ModuleName"].ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void myDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button1_Click(null, null);
        }
    }
}