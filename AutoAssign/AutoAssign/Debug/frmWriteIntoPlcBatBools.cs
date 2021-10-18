using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.Debug
{
    public partial class frmWriteIntoPlcBatBools : Common.frmBase
    {
        frmMain1 _MainForm = null;
        public frmWriteIntoPlcBatBools(frmMain1 mainFrom)
        {
            InitializeComponent();
            _MainForm = mainFrom;
        }
        private void SetValue()
        {
            bool[] bits = new bool[32];
            //电池1
            bits[0] = this.chkBat1Ng.Checked;
            bits[1] = this.chkBat1ChongFu.Checked;
            bits[2] = this.chkBat1MOK.Checked;
            //电池1
            bits[3] = this.chkBat2Ng.Checked;
            bits[4] = this.chkBat2ChongFu.Checked;
            bits[5] = this.chkBat2MOK.Checked;
            //电池1
            bits[6] = this.chkBat3Ng.Checked;
            bits[7] = this.chkBat3ChongFu.Checked;
            bits[8] = this.chkBat3MOK.Checked;
            //电池1
            bits[9] = this.chkBat4Ng.Checked;
            bits[10] = this.chkBat4ChongFu.Checked;
            bits[11] = this.chkBat4MOK.Checked;
            //电池1
            bits[12] = this.chkBat5Ng.Checked;
            bits[13] = this.chkBat5ChongFu.Checked;
            bits[14] = this.chkBat5MOK.Checked;
            //电池1
            bits[15] = this.chkBat6Ng.Checked;
            bits[16] = this.chkBat6ChongFu.Checked;
            bits[17] = this.chkBat6MOK.Checked;
            //电池1
            bits[18] = this.chkBat7Ng.Checked;
            bits[19] = this.chkBat7ChongFu.Checked;
            bits[20] = this.chkBat7MOK.Checked;
            //电池7
            bits[21] = this.chkBat8Ng.Checked;
            bits[22] = this.chkBat8ChongFu.Checked;
            bits[23] = this.chkBat8MOK.Checked;
            //电池1
            bits[24] = this.chkBat9Ng.Checked;
            bits[25] = this.chkBat9ChongFu.Checked;
            bits[26] = this.chkBat9MOK.Checked;
            //电池1
            bits[27] = this.chkBat10Ng.Checked;
            bits[28] = this.chkBat10ChongFu.Checked;
            bits[29] = this.chkBat10MOK.Checked;
            //标识已经有信息存入了
            bits[30] = this.chkCompeleted.Checked;
            //最高为目前为空,已不用赋值
            // bits[31] = false;
            int iValue = JPSFuns.GetInt32ByBit(bits);
            this.tbValue.Text = iValue.ToString();

        }

        private void btBat_bool1_Click(object sender, EventArgs e)
        {
            int iValue;
            if(!int.TryParse(this.tbValue.Text,out iValue))
            {
                this.ShowMsg("请输入正确的整型值。");
                return;
            }
            if(this._MainForm._MainControl==null)
            {
                this.ShowMsg("MainControl对象为空。");
                return;
            }
            if (this._MainForm._MainControl._OPCHelperBat == null)
            {
                this.ShowMsg("_OPCHelperBat对象为空。");
                return;
            }
            if (this._MainForm._MainControl._OPCHelperBat._BatBitValue1 == null)
            {
                this.ShowMsg("_BatBitValue1对象为空。");
                return;
            }
            string sErr;
            if(!this._MainForm._MainControl._OPCHelperBat._BatBitValue1.WriteData(iValue,out sErr))
            {
                this.ShowMsg(sErr);
                return;
            }
        }

        private void btBat_bool2_Click(object sender, EventArgs e)
        {
            int iValue;
            if (!int.TryParse(this.tbValue.Text, out iValue))
            {
                this.ShowMsg("请输入正确的整型值。");
                return;
            }
            if (this._MainForm._MainControl == null)
            {
                this.ShowMsg("MainControl对象为空。");
                return;
            }
            if (this._MainForm._MainControl._OPCHelperBat == null)
            {
                this.ShowMsg("_OPCHelperBat对象为空。");
                return;
            }
            if (this._MainForm._MainControl._OPCHelperBat._BatBitValue2 == null)
            {
                this.ShowMsg("_BatBitValue2对象为空。");
                return;
            }
            string sErr;
            if (!this._MainForm._MainControl._OPCHelperBat._BatBitValue2.WriteData(iValue, out sErr))
            {
                this.ShowMsg(sErr);
                return;
            }
        }

        private void frmWriteIntoPlcBatBools_Load(object sender, EventArgs e)
        {
            foreach (Control con in this.Controls)
            {
                CheckBox chk = con as CheckBox;
                if (chk != null)
                {
                    chk.CheckedChanged += Chk_CheckedChanged;
                }
            }
        }
        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            this.SetValue();
        }
    }
}
