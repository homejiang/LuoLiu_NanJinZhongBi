using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common.Msg
{
    public partial class frmMsgRich : Form
    {
        /// <summary>
        /// 会自动隐藏的消息窗口，为美化窗口，字体大小都有一定控制，目前此窗口最多传入18个汉字；
        /// 此窗口用于执行成功后的提示，不作为
        /// </summary>
        public frmMsgRich()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Opacity为100%时停留时间，单位：秒
        /// </summary>
        public int ShowTime = 0;
        /// <summary>
        /// 关闭时timer的interval值
        /// </summary>
        public int CloseTimeInterval = 150;
        /// <summary>
        /// 关闭时每次减少的Opacity值
        /// </summary>
        public double ReduceOpacity = 0.55;

        public string Msg
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ShowTime == 0)
            {
                ShowTime--;
                this.timer1.Interval = CloseTimeInterval;
                this.timer1.Enabled = true;
            }
            if (ShowTime < 0)
            {
                //此时要慢慢的减小透明度
                double db = this.Opacity;
                if (db <= 0.1) this.Close();
                else
                {
                    this.Opacity = db * ReduceOpacity;
                }
            }
            if (ShowTime > 0) ShowTime--;
        }

        private void frmMsgRich_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 600;
            this.timer1.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}