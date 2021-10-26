using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common.SystemHelp
{
    public partial class frmDataSource : Form
    {
        public frmDataSource()
        {
            InitializeComponent();
        }
        public DataSet _DataSource = null;
        private void frmDataSource_Load(object sender, EventArgs e)
        {
            if (_DataSource == null) return;
            List<MyControl.MyDataGridView> list = new List<MyControl.MyDataGridView>();
            list.Add(this.myDataGridView1);
            list.Add(this.myDataGridView2);
            list.Add(this.myDataGridView3);
            list.Add(this.myDataGridView4);
            list.Add(this.myDataGridView5);
            list.Add(this.myDataGridView6);
            list.Add(this.myDataGridView7);
            list.Add(this.myDataGridView8);
            list.Add(this.myDataGridView9);
            list.Add(this.myDataGridView10);
            list.Add(this.myDataGridView11);
            list.Add(this.myDataGridView12);
            for (int i = 0; i < _DataSource.Tables.Count; i++)
            {
                if (i > 11) break;
                list[i].DataSource = _DataSource.Tables[i];
                list[i].Rows[0].Cells[0].ToolTipText = _DataSource.Tables[i].TableName;
            }
        }
    }
}