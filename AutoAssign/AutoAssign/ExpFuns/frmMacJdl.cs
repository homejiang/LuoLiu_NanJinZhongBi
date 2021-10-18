using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AutoAssign.ExpFuns
{
    public partial class frmMacJdl : Common.frmBase
    {
        JpsOPC.OPCHelperMacJDL _MacJDL = null;
        public frmMacJdl()
        {
            InitializeComponent();
        }

        private void frmMacJdl_Load(object sender, EventArgs e)
        {
            if (_MacJDL == null)
                _MacJDL = new JpsOPC.OPCHelperMacJDL();
            string strErr;
            if (!_MacJDL.InitServer(out strErr))
            {
                this.ShowMsg(strErr);
            }
            //读取数据
            this.timer1.Interval = 1000;
            this.timer1.Enabled = true;
        }
        private bool BindData()
        {
            string strErr;
            if (_MacJDL == null)
            {
                _MacJDL = new JpsOPC.OPCHelperMacJDL();
                if (!_MacJDL.InitServer(out strErr))
                {
                    this.ShowMsg(strErr);
                    return false;
                }
            }
           
            double dbPre, dbTime;
            if (!this._MacJDL.ReadJdl(out dbTime, out dbPre, out strErr))
            {
                this.ShowMsg(strErr);
                return false;
            }
            this.tbPer.Text = dbPre.ToString("#########0.0%");
            this.tbTime.Text = dbTime.ToString("#########0.0%");
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.BindData())
            {
                this.ShowMsgRich("刷新成功！");
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (this._MacJDL != null)
            {
                string strErr;
                this._MacJDL.CloseOPC(out strErr);
            }
            base.OnClosing(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.BindData();
        }
    }
}
