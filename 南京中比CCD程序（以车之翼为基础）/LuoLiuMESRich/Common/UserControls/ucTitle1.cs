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
    public partial class ucTitle1 : UserControl
    {
        public event System.EventHandler SetBOMClass = null;
        public ucTitle1()
        {
            InitializeComponent();
        }
        public string Process
        {
            get
            {
                return this.labProcess.Text;
            }
            set
            {
                this.labProcess.Text = value;
            }
        }
        public string Station
        {
            get
            {
                return this.labStation.Text;
            }
            set
            {
                this.labStation.Text = value;
            }
        }
        public string Mac
        {
            get
            {
                return this.labMac.Text;
            }
            set
            {
                this.labMac.Text = value;
            }
        }
        public string Operator
        {
            get
            {
                return this.labOperator.Text;
            }
            set
            {
                this.labOperator.Text = value;
            }
        }
        public string BOMClassName
        {
            get
            {
                return this.labBOMClassName.Text;
            }
            set
            {
                this.labBOMClassName.Text = value;
            }
        }
        #region 选择测试对象
        private void labBOMClassName_Click(object sender, EventArgs e)
        {
            if (this.SetBOMClass != null)
                this.SetBOMClass(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (this.SetBOMClass != null)
                this.SetBOMClass(sender, e);
        }
        
        #endregion
    }
}
