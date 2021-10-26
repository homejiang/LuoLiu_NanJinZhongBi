using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common.SetTime
{
    public partial class frmSetTime1 : frmBase
    {
        public frmSetTime1()
        {
            InitializeComponent();
        }
        public bool _ShowCheckbox = false;
        public bool _Checked
        {
            get
            {
                return this.dateTimePicker1.Checked;
            }
        }
        public DateTime _SetDateTime
        {
            get
            {
                return DateTime.Parse(this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + this.dateTimePicker2.Value.ToString("HH:mm:ss"));
            }
            set
            {
                this.dateTimePicker1.Value = value;
                this.dateTimePicker2.Value = value;
            }
        }
        private void frmSetTime_Load(object sender, EventArgs e)
        {
            this.dateTimePicker1.ShowCheckBox = _ShowCheckbox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}