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
        /// ���Զ����ص���Ϣ���ڣ�Ϊ�������ڣ������С����һ�����ƣ�Ŀǰ�˴�����ഫ��18�����֣�
        /// �˴�������ִ�гɹ������ʾ������Ϊ
        /// </summary>
        public frmMsgRich()
        {
            InitializeComponent();
        }
        /// <summary>
        /// OpacityΪ100%ʱͣ��ʱ�䣬��λ����
        /// </summary>
        public int ShowTime = 0;
        /// <summary>
        /// �ر�ʱtimer��intervalֵ
        /// </summary>
        public int CloseTimeInterval = 150;
        /// <summary>
        /// �ر�ʱÿ�μ��ٵ�Opacityֵ
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
                //��ʱҪ�����ļ�С͸����
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