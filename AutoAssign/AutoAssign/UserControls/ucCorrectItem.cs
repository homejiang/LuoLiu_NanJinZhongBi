using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.UserControls
{
    public partial class ucCorrectItem : UserControl
    {
        public ucCorrectItem()
        {
            InitializeComponent();
            //this.Showinit();
        }
        short mNo = 0;
        public short No
        {
            get
            {
                return this.mNo;
            }
            set
            {
                if (mNo != value)
                {
                    mNo = value;
                    this.labNo.Text = "组" + value.ToString();
                }
            }
        }
        JpsOPC.OPCHelperCorrect.CorrectValue _MyValue;
        public void SetValue(JpsOPC.OPCHelperCorrect.CorrectValue values)
        {
            if(values==null)
            {
                this.Showinit();
                return;
            }
            Color cfore;
            string strText;
            //电阻
            if(values.DzSucessfully)
            {
                cfore = Color.Black;
                strText = values.Dz.ToString("#########0.######");
            }
            else
            {
                cfore = Color.Red;
                strText = "error";
            }
            if (this.tbDz.ForeColor != cfore)
                this.tbDz.ForeColor = cfore;
            if (this.tbDz.Text != strText)
                this.tbDz.Text = strText;

            //电压
            if (values.VSucessfully)
            {
                cfore = Color.Black;
                strText = values.V.ToString("#########0.######");
            }
            else
            {
                cfore = Color.Red;
                strText = "error";
            }
            if (this.tbV.ForeColor != cfore)
                this.tbV.ForeColor = cfore;
            if (this.tbV.Text != strText)
                this.tbV.Text = strText;
            this._MyValue = values;
        }
        public void Showinit()
        {
            if(this.tbDz.Text!= "---")
            {
                this.tbDz.Text = "---";
            }
            if (this.tbV.Text != "---")
            {
                this.tbV.Text = "---";
            }
        }

        private void tbDz_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this._MyValue == null) return;
            if (this._MyValue.DzSucessfully) return;
            ExpFuns.frmCorrectErrMsg frm = new ExpFuns.frmCorrectErrMsg(this._MyValue.DzErrMsg);
            frm.Show();

        }

        private void tbV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this._MyValue == null) return;
            if (this._MyValue.VSucessfully) return;
            ExpFuns.frmCorrectErrMsg frm = new ExpFuns.frmCorrectErrMsg(this._MyValue.VErrMsg);
            frm.Show();
        }
        public bool GetValues(out float fDz,out float fV,out string sErr)
        {
            fDz = 0F;
            fV = 0F;
            if(this.tbDz.Text.Length==0)
            {
                sErr = string.Format("组{0}的电阻修正值不能为空！",this.No);
                return false;
            }
            if (this.tbV.Text.Length == 0)
            {
                sErr = string.Format("组{0}的电压修正值不能为空！", this.No);
                return false;
            }
            if(!float.TryParse(this.tbDz.Text,out fDz))
            {
                sErr = string.Format("组{0}的电阻修正值输入不正确，请输入数值！", this.No);
                return false;
            }
            if (!float.TryParse(this.tbV.Text, out fV))
            {
                sErr = string.Format("组{0}的电压修正值输入不正确，请输入数值！", this.No);
                return false;
            }
            sErr = string.Empty;
            return true;
        }
    }
}
