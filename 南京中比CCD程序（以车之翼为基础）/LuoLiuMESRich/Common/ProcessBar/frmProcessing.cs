using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common.ProcessBar
{
    public partial class frmProcessing : Form
    {
        public frmProcessing()
        {
            InitializeComponent();
        }
        #region 公共属性
        public int TimerInterval = 100;
        public int BarMaxValue = 0;
        public int BarMinValue = 0;
        public int BarValue = 0;
        public bool Sucessful = false;
        public string ShowText
        {
            set
            {
                this.labReadData.Text = value;
            }
        }
        #endregion
        public event ProcessBar_Processing frmProcessBar_Processing = null;
        private void frmEditProcess_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            if (this.timer1.Interval != this.TimerInterval)
                this.timer1.Interval = this.TimerInterval;
            this.progressBar1.Maximum = this.BarMaxValue;
            this.progressBar1.Minimum = this.BarMinValue;
            this.progressBar1.Value = this.BarValue;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            if (this.frmProcessBar_Processing != null)
            {
                bool blSucessful = false;
                this.frmProcessBar_Processing(this, this.progressBar1, ref blSucessful);
                //无论成功与否都关闭此窗口
                this.Sucessful = blSucessful;
                this.Close();
            }
        }
    }
    public delegate void ProcessBar_Processing(object sender, System.Windows.Forms.ProgressBar control,ref bool Sucessful);
}