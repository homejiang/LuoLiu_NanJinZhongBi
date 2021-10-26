using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.UserControls
{
    public partial class ucAutoSaveTimerShow : UserControl
    {
        public event AutoSaveTimerStopCallBack AutoSaveTimerStopNotice = null;
        string _mText = "{0}秒后自动清空窗口";
        public string TextFormat
        {
            get
            {
                return this._mText;
            }
            set
            {
                this._mText = value;
            }
        }
        public ucAutoSaveTimerShow()
        {
            InitializeComponent();
            this.timer_AutoSave.Interval = 1000;
        }
        public void Start(int iDelaySeconds)
        {
            if (!this.panAutoSave.Visible)
                this.panAutoSave.Visible = true;
            this.labAutoSave.Text = string.Format("{0}秒后自动清空窗口", iDelaySeconds);
            this.AutoSave_TimeCounter = iDelaySeconds;
            this.timer_AutoSave.Enabled = true;
        }
        public void Stop()
        {
            HidenMe();
        }
        public bool IsActive()
        {
            if (this.AutoSave_TimeCounter > 0 && this.panAutoSave.Visible) return true;
            return false;
        }
        int AutoSave_TimeCounter = 0;
        private void timer_AutoSave_Tick(object sender, EventArgs e)
        {
            this.AutoSave_TimeCounter--;
            if (this.AutoSave_TimeCounter <= 0)
            {
                this.Notice();
                this.HidenMe();
            }
            else
            {
                this.labAutoSave.Text = string.Format(this.TextFormat, this.AutoSave_TimeCounter);
            }
        }
        private void HidenMe()
        {
            this.labAutoSave.Text = string.Empty;
            this.panAutoSave.Visible = false;
            this.timer_AutoSave.Enabled = false;
        }
        private void Notice()
        {
            if (AutoSaveTimerStopNotice != null)
                AutoSaveTimerStopNotice();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //此时用户终止了
            this.HidenMe();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.BorderStyle = BorderStyle.None;
        }
    }
    public delegate void AutoSaveTimerStopCallBack();
}
