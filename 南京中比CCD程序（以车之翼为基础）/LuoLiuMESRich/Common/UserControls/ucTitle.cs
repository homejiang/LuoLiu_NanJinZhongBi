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
    public partial class ucTitle : UserControl
    {
        public ucTitle()
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


    }
}
