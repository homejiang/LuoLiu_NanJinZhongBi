using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.NanJingZB
{
    public partial class frmSwitchEdit : Common.frmBase
    {
        public frmSwitchEdit()
        {
            InitializeComponent();
        }
        private bool BindData()
        {
            try
            {
                this.myDataGridView1.DataSource = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("SELECT * FROM RealData_GroovesAB order by GrooveNo asc", true);
            }
            catch(Exception ex)
            {
                this.ShowMsg(ex.Message);
                return false;
            }
            return true;
        }

        private void frmYcEdit_Load(object sender, EventArgs e)
        {
            this.button1.Enabled = this.BindData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                this.ShowMsgRich("保存成功");
                this.button1.Enabled = this.BindData();
            }
        }
        private bool Save()
        {
            this.textBox1.Focus();
            this.textBox1.SelectAll();
            Application.DoEvents();
            DataTable dt = this.myDataGridView1.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源丢失，保存失败！");
                return false;
            }
            try
            {
                Common.CommonDAL.DoSqlCommandBasic.SaveTable(dt, "RealData_GroovesAB");
            }
            catch(Exception ex)
            {
                this.ShowMsg(ex.Message);
                return false;
            }
            return true;
        }
    }
}
