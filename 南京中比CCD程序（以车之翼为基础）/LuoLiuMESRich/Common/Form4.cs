using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /**********
             * 将DEDE09F0A4CD2640转成小数
             * 解析：
             * 1、首先转换先要将他们转成byte，即二进制，这样无论什么样的转换都行了。
             * 2、这个一般来说一个字节是8位，通常值可以用2个十六进制字母表示：16*16=256，与2的八次方是一样的。所以一般来讲用两个十六进制来表示一个字节，这是常规方法；
             * 3、这个字符窜总共有16个字母，如果仅是一个数字，那可以猜测是8个字节在，8个字节的话，double或decimal，这个要看最初转换时候的了，2者是不一样的。我们以double为例进行转换；
             * 4、除了类型不能确定外，字节的高地位也是不能确定的，因为这16个字母是转换后认为或者用系统已有的函数进行排列的，所以也不知道是高位在前还是低位在前，但按照习惯是低位在前，高位在后；
             * 
             * *******************/
            byte[] bs = new byte[8];
            bs[0] = 0xDE;
            bs[1] = 0xDE;
            bs[2] = 0x09;
            bs[3] = 0xF0;
            bs[4] = 0xA4;
            bs[5] = 0xCD;
            bs[6] = 0x26;
            bs[7] = 0x40;
            //将字节转换成double
            double db = BitConverter.ToDouble(bs, 0);
            this.textBox1.Text = db.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.textBox1.Text = decimal.MinValue.ToString();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = this.GetType().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}