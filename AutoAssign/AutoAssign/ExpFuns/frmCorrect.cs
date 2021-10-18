using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.ExpFuns
{
    public partial class frmCorrect : Common.frmBase
    {
        JpsOPC.OPCHelperCorrect _OPCHelperCorrect = null;
        public frmCorrect()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                if (this._OPCHelperCorrect != null)
                {
                    string strErr;
                    if(!this._OPCHelperCorrect.CloseOPC(out strErr))
                    {
                        this.ShowMsg(strErr);
                    }
                }
            }
            catch(Exception ex)
            {
                this.ShowMsg(ex.Message);
            }
            base.OnClosing(e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            float fDz1, fV1;
            float fDz2, fV2;
            float fDz3, fV3;
            float fDz4, fV4;
            float fDz5, fV5;
            float fDz6, fV6;
            float fDz7, fV7;
            float fDz8, fV8;
            float fDz9, fV9;
            float fDz10, fV10;
            float fDz11, fV11;
            float fDz12, fV12;
            float fDz13, fV13;
            float fDz14, fV14;
            float fDz15, fV15;
            float fDz16, fV16;
            float fDz17, fV17;
            float fDz18, fV18;
            float fDz19, fV19;
            float fDz20, fV20;
            float fDz21, fV21;
            float fDz22, fV22;
            float fDz23, fV23;
            float fDz24, fV24;
            float fDz25, fV25;
            float fDz26, fV26;
            float fDz27, fV27;
            float fDz28, fV28;
            float fDz29, fV29;
            float fDz30, fV30;
            float fDz31, fV31;
            float fDz32, fV32;
            float fDz33, fV33;
            float fDz34, fV34;
            float fDz35, fV35;
            float fDz36, fV36;
            float fDz37, fV37;
            float fDz38, fV38;
            float fDz39, fV39;
            float fDz40, fV40;
            string strErr;
            if (!this.uc1.GetValues(out fDz1, out fV1, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc2.GetValues(out fDz2, out fV2, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc3.GetValues(out fDz3, out fV3, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc4.GetValues(out fDz4, out fV4, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc5.GetValues(out fDz5, out fV5, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc6.GetValues(out fDz6, out fV6, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc7.GetValues(out fDz7, out fV7, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc8.GetValues(out fDz8, out fV8, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc9.GetValues(out fDz9, out fV9, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc10.GetValues(out fDz10, out fV10, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc11.GetValues(out fDz11, out fV11, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc12.GetValues(out fDz12, out fV12, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc13.GetValues(out fDz13, out fV13, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc14.GetValues(out fDz14, out fV14, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc15.GetValues(out fDz15, out fV15, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc16.GetValues(out fDz16, out fV16, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc17.GetValues(out fDz17, out fV17, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc18.GetValues(out fDz18, out fV18, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc19.GetValues(out fDz19, out fV19, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc20.GetValues(out fDz20, out fV20, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc21.GetValues(out fDz21, out fV21, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc22.GetValues(out fDz22, out fV22, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc23.GetValues(out fDz23, out fV23, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc24.GetValues(out fDz24, out fV24, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc25.GetValues(out fDz25, out fV25, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc26.GetValues(out fDz26, out fV26, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc27.GetValues(out fDz27, out fV27, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc28.GetValues(out fDz28, out fV28, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc29.GetValues(out fDz29, out fV29, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc30.GetValues(out fDz30, out fV30, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc31.GetValues(out fDz31, out fV31, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc32.GetValues(out fDz32, out fV32, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc33.GetValues(out fDz33, out fV33, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc34.GetValues(out fDz34, out fV34, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc35.GetValues(out fDz35, out fV35, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc36.GetValues(out fDz36, out fV36, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc37.GetValues(out fDz37, out fV37, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc38.GetValues(out fDz38, out fV38, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc39.GetValues(out fDz39, out fV39, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this.uc40.GetValues(out fDz40, out fV40, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            if (!this._OPCHelperCorrect.WriteCorret(fV1, fDz1,
                fV2, fDz2,
                fV3, fDz3,
                fV4, fDz4,
                fV5, fDz5,
                fV6, fDz6,
                fV7, fDz7,
                fV8, fDz8,
                fV9, fDz9,
                fV10, fDz10,
                fV11, fDz11,
                fV12, fDz12,
                fV13, fDz13,
                fV14, fDz14,
                fV15, fDz15,
                fV16, fDz16,
                fV17, fDz17,
                fV18, fDz18,
                fV19, fDz19,
                fV20, fDz20,
                fV21, fDz21,
                fV22, fDz22,
                fV23, fDz23,
                fV24, fDz24,
                fV25, fDz25,
                fV26, fDz26,
                fV27, fDz27,
                fV28, fDz28,
                fV29, fDz29,
                fV30, fDz30,
                fV31, fDz31,
                fV32, fDz32,
                fV33, fDz33,
                fV34, fDz34,
                fV35, fDz35,
                fV36, fDz36,
                fV37, fDz37,
                fV38, fDz38,
                fV39, fDz39,
                fV40, fDz40, out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            this.ShowMsgRich("写入成功！");
        }

        private void frmCorrect_Load(object sender, EventArgs e)
        {
            if (_OPCHelperCorrect == null)
                _OPCHelperCorrect = new JpsOPC.OPCHelperCorrect();
            string strErr;
            if (!_OPCHelperCorrect.InitServer(out strErr))
            {
                this.ShowMsg(strErr);
            }
            if (_OPCHelperCorrect.InitSucessfully)
            {
                //读取数据
                this.timer1.Interval = 1000;
                this.timer1.Enabled = true;
            }
            this.uc1.TabIndex = 1;
            this.uc2.TabIndex = 2;
            this.uc3.TabIndex = 3;
            this.uc4.TabIndex = 4;
            this.uc5.TabIndex = 5;
            this.uc6.TabIndex = 6;
            this.uc7.TabIndex = 7;
            this.uc8.TabIndex = 8;
            this.uc9.TabIndex = 9;
            this.uc10.TabIndex = 10;
            this.uc11.TabIndex = 11;
            this.uc12.TabIndex = 12;
            this.uc13.TabIndex = 13;
            this.uc14.TabIndex = 14;
            this.uc15.TabIndex = 15;
            this.uc16.TabIndex = 16;
            this.uc17.TabIndex = 17;
            this.uc18.TabIndex = 18;
            this.uc19.TabIndex = 19;
            this.uc20.TabIndex = 20;
            this.uc21.TabIndex = 21;
            this.uc22.TabIndex = 22;
            this.uc23.TabIndex = 23;
            this.uc24.TabIndex = 24;
            this.uc25.TabIndex = 25;
            this.uc26.TabIndex = 26;
            this.uc27.TabIndex = 27;
            this.uc28.TabIndex = 28;
            this.uc29.TabIndex = 29;
            this.uc30.TabIndex = 30;
            this.uc31.TabIndex = 31;
            this.uc32.TabIndex = 32;
            this.uc33.TabIndex = 33;
            this.uc34.TabIndex = 34;
            this.uc35.TabIndex = 35;
            this.uc36.TabIndex = 36;
            this.uc37.TabIndex = 37;
            this.uc38.TabIndex = 38;
            this.uc39.TabIndex = 39;
            this.uc40.TabIndex = 40;
        }
        private bool BindData()
        {
            string strErr;
            if (_OPCHelperCorrect == null)
            {
                _OPCHelperCorrect = new JpsOPC.OPCHelperCorrect();
                if (!_OPCHelperCorrect.InitServer(out strErr))
                {
                    this.ShowMsg(strErr);
                    return false;
                }
            }
            if(!this._OPCHelperCorrect.ReadCorrect(out strErr))
            {
                this.ShowMsg(strErr);
                return false;
            }
            this.uc1.SetValue(this._OPCHelperCorrect._CorrectValues[0]);
            this.uc2.SetValue(this._OPCHelperCorrect._CorrectValues[1]);
            this.uc3.SetValue(this._OPCHelperCorrect._CorrectValues[2]);
            this.uc4.SetValue(this._OPCHelperCorrect._CorrectValues[3]);
            this.uc5.SetValue(this._OPCHelperCorrect._CorrectValues[4]);
            this.uc6.SetValue(this._OPCHelperCorrect._CorrectValues[5]);
            this.uc7.SetValue(this._OPCHelperCorrect._CorrectValues[6]);
            this.uc8.SetValue(this._OPCHelperCorrect._CorrectValues[7]);
            this.uc9.SetValue(this._OPCHelperCorrect._CorrectValues[8]);
            this.uc10.SetValue(this._OPCHelperCorrect._CorrectValues[9]);
            this.uc11.SetValue(this._OPCHelperCorrect._CorrectValues[10]);
            this.uc12.SetValue(this._OPCHelperCorrect._CorrectValues[11]);
            this.uc13.SetValue(this._OPCHelperCorrect._CorrectValues[12]);
            this.uc14.SetValue(this._OPCHelperCorrect._CorrectValues[13]);
            this.uc15.SetValue(this._OPCHelperCorrect._CorrectValues[14]);
            this.uc16.SetValue(this._OPCHelperCorrect._CorrectValues[15]);
            this.uc17.SetValue(this._OPCHelperCorrect._CorrectValues[16]);
            this.uc18.SetValue(this._OPCHelperCorrect._CorrectValues[17]);
            this.uc19.SetValue(this._OPCHelperCorrect._CorrectValues[18]);
            this.uc20.SetValue(this._OPCHelperCorrect._CorrectValues[19]);
            this.uc21.SetValue(this._OPCHelperCorrect._CorrectValues[20]);
            this.uc22.SetValue(this._OPCHelperCorrect._CorrectValues[21]);
            this.uc23.SetValue(this._OPCHelperCorrect._CorrectValues[22]);
            this.uc24.SetValue(this._OPCHelperCorrect._CorrectValues[23]);
            this.uc25.SetValue(this._OPCHelperCorrect._CorrectValues[24]);
            this.uc26.SetValue(this._OPCHelperCorrect._CorrectValues[25]);
            this.uc27.SetValue(this._OPCHelperCorrect._CorrectValues[26]);
            this.uc28.SetValue(this._OPCHelperCorrect._CorrectValues[27]);
            this.uc29.SetValue(this._OPCHelperCorrect._CorrectValues[28]);
            this.uc30.SetValue(this._OPCHelperCorrect._CorrectValues[29]);
            this.uc31.SetValue(this._OPCHelperCorrect._CorrectValues[30]);
            this.uc32.SetValue(this._OPCHelperCorrect._CorrectValues[31]);
            this.uc33.SetValue(this._OPCHelperCorrect._CorrectValues[32]);
            this.uc34.SetValue(this._OPCHelperCorrect._CorrectValues[33]);
            this.uc35.SetValue(this._OPCHelperCorrect._CorrectValues[34]);
            this.uc36.SetValue(this._OPCHelperCorrect._CorrectValues[35]);
            this.uc37.SetValue(this._OPCHelperCorrect._CorrectValues[36]);
            this.uc38.SetValue(this._OPCHelperCorrect._CorrectValues[37]);
            this.uc39.SetValue(this._OPCHelperCorrect._CorrectValues[38]);
            this.uc40.SetValue(this._OPCHelperCorrect._CorrectValues[39]);
            return true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!this._OPCHelperCorrect.InitSucessfully)
            {
                this.ShowMsg("设备连出错，无法刷新！");
                return;
            }
            if(this.BindData())
            {
                this.ShowMsgRich("刷新成功！");
            }
        }
    }
}
