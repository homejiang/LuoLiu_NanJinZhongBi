using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BasicData.ProcessMacs
{
    public partial class frmMBdownEditSelTime : Common.frmBase
    {
        public frmMBdownEditSelTime()
        {
            InitializeComponent();
        }
        public object StartTime;
        public object EndTime;
        public object StartTime1;//开始维修时间
        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.dtpDateStart.Checked)
            {
                this.ShowMsg("异常发生时间必须选择");
                this.dtpDateStart.Focus();
                return;
            }
            this.StartTime = DateTime.Parse(string.Format("{0} {1}"
                , this.dtpDateStart.Value.ToString("yyyy-MM-dd"), this.dtpTimeStart.Value.ToString("HH:mm")));
            if (!this.dtpDateStart1.Checked)
            {
                this.ShowMsg("开始维修时间必须选择");
                this.dtpDateStart1.Focus();
                return;
            }
            this.StartTime1 = DateTime.Parse(string.Format("{0} {1}"
                , this.dtpDateStart1.Value.ToString("yyyy-MM-dd"), this.dtpTimeStart1.Value.ToString("HH:mm")));
            if (!this.dtpDateEnd.Checked)
                this.EndTime = DBNull.Value;
            else
            {
                this.EndTime = DateTime.Parse(string.Format("{0} {1}"
                , this.dtpDateEnd.Value.ToString("yyyy-MM-dd"), this.dtpTimeEnd.Value.ToString("HH:mm")));
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmMBdownEditSelTime_Load(object sender, EventArgs e)
        {
            if (this.StartTime == null || this.StartTime.Equals(DBNull.Value))
            {
                this.dtpDateStart.Checked = false;
            }
            else
            {
                this.dtpDateStart.Value = (DateTime)this.StartTime;
                this.dtpTimeStart.Value = (DateTime)this.StartTime;
            }
            if (this.StartTime1 == null || this.StartTime1.Equals(DBNull.Value))
            {
                this.dtpDateStart1.Checked = false;
            }
            else
            {
                this.dtpDateStart1.Value = (DateTime)this.StartTime1;
                this.dtpTimeStart1.Value = (DateTime)this.StartTime1;
            }

            if (this.EndTime == null || this.EndTime.Equals(DBNull.Value))
            {
                this.dtpDateEnd.Checked = false;
            }
            else
            {
                this.dtpDateEnd.Value = (DateTime)this.StartTime;
                this.dtpTimeEnd.Value = (DateTime)this.StartTime;
            }
        }
    }
}