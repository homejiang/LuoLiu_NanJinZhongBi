using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common.Msg
{
    public partial class frmMsgInfo : Form
    {
        public frmMsgInfo()
        {
            InitializeComponent();
        }
        public long _ID = 0;
        private void frmMsgInfo_Load(object sender, EventArgs e)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandLog.GetDateTable(string.Format("select LogText from EventLogs WHERE [id]={0}"
                    , _ID));
            }
            catch (Exception ex)
            {
                throw (ex);
                return;
            }
            if (dt.Rows.Count > 0)
                this.richTextBox1.Text = dt.Rows[0]["LogText"].ToString();
        }
    }
}