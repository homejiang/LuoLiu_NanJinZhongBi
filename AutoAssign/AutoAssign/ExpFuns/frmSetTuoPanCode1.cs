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
    public partial class frmSetTuoPanCode1 : Common.frmBase
    {
        #region 窗体数据连接实例
        private BLLDAL.Testing _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Testing BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Testing();
                return _dal;
            }
        }
        #endregion 
        public frmSetTuoPanCode1()
        {
            InitializeComponent();
            if (JPSConfig.MacNo != 99)
            {
                this.tbMacNo.Text = JPSConfig.MacNo.ToString();
                this.tbCaoIndex.Text = "X";
            }
            else
            {
                this.tbMacNo.Text = "";
                this.tbCaoIndex.Text = "0";
            }
            this.tbY.Clear();
            this.tbM.Clear();
            this.tbD.Clear();
            this.numericUpDown1.Value = 1;
            this.labDate.Text = string.Format("当前日期:{0}", DateTime.Now.ToString("yyyy年MM月dd日"));
        }
        private bool BindData()
        {
            //DataTable dt;
            //try
            //{
            //    dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM TuoPanCode1");
            //}
            //catch(Exception ex)
            //{
            //    this.ShowMsg(ex.Message);
            //    return false;
            //}
            //if (dt.Rows.Count == 0) return true;
            string strCode = DateTime.Now.ToString("yyMMdd");//dt.Rows[0]["Code"].ToString();
            if (strCode.Length >=2)
                this.tbY.Text = strCode.Substring(0, 2);
            if (strCode.Length >= 4)
                this.tbM.Text = strCode.Substring(2, 2);
            if (strCode.Length >= 6)
                this.tbD.Text = strCode.Substring(4, 2);
            GetMaxCode();
            //try
            //{
            //    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MaxCode FROM Testing_MaxTuoPanCode WHERE YYM='{0}{1}'", JPSConfig.MacNo, strCode));
            //}
            //catch (Exception ex)
            //{
            //    this.ShowMsg(ex.Message);
            //    return false;
            //}
            //int iMaxValue;
            //if (dt.Rows.Count == 0)
            //    iMaxValue = 1;
            //else
            //{
            //    iMaxValue = dt.Rows[0]["MaxCode"].Equals(DBNull.Value) ? 1 : int.Parse(dt.Rows[0]["MaxCode"].ToString()) + 1;
            //}
            //this.numericUpDown1.Value = iMaxValue;
            return true;
        }

        private void frmSetTuoPanCode1_Load(object sender, EventArgs e)
        {
            this.button1.Enabled = this.BindData();
            this.tbMacNo.ReadOnly = JPSConfig.MacNo != 99;
        }

        private void tbM_Leave(object sender, EventArgs e)
        {
            if (this.tbM.Text.Length == 1)
                this.tbM.Text = "0" + this.tbM.Text;
        }

        private void tbD_Leave(object sender, EventArgs e)
        {
            if (this.tbD.Text.Length == 1)
                this.tbD.Text = "0" + this.tbD.Text;

        }
        private void GetMaxCode()
        {
            string strMacNo;
            if(JPSConfig.MacNo==99)
            {
                if (this.tbMacNo.Text.Length == 0) return;
                strMacNo = this.tbMacNo.Text;
            }
            else
            {
                if (JPSConfig.MacNo <= 9)
                    strMacNo = JPSConfig.MacNo.ToString();
                else
                {
                    if (JPSConfig.MacNo == 10)
                        strMacNo = "A";
                    else if (JPSConfig.MacNo == 11)
                        strMacNo = "B";
                    else if (JPSConfig.MacNo == 12)
                        strMacNo = "C";
                    else if (JPSConfig.MacNo == 13)
                        strMacNo = "D";
                    else if (JPSConfig.MacNo == 14)
                        strMacNo = "E";
                    else if (JPSConfig.MacNo == 15)
                        strMacNo = "F";
                    else if (JPSConfig.MacNo == 16)
                        strMacNo = "G";
                    else if (JPSConfig.MacNo == 17)
                        strMacNo = "H";
                    else if (JPSConfig.MacNo == 18)
                        strMacNo = "J";
                    else if (JPSConfig.MacNo == 19)
                        strMacNo = "K";
                    else if (JPSConfig.MacNo == 20)
                        strMacNo = "L";
                    else if (JPSConfig.MacNo == 21)
                        strMacNo = "M";
                    else if (JPSConfig.MacNo == 22)
                        strMacNo = "N";
                    else if (JPSConfig.MacNo == 23)
                        strMacNo = "P";
                    else if (JPSConfig.MacNo == 24)
                        strMacNo = "Q";
                    else if (JPSConfig.MacNo == 25)
                        strMacNo = "R";
                    else if (JPSConfig.MacNo == 26)
                        strMacNo = "S";
                    else if (JPSConfig.MacNo == 27)
                        strMacNo = "T";
                    else if (JPSConfig.MacNo == 28)
                        strMacNo = "U";
                    else if (JPSConfig.MacNo == 29)
                        strMacNo = "V";
                    else if (JPSConfig.MacNo == 30)
                        strMacNo = "W";
                    else if (JPSConfig.MacNo == 31)
                        strMacNo = "X";
                    else if (JPSConfig.MacNo == 32)
                        strMacNo = "Y";
                    else if (JPSConfig.MacNo == 33)
                        strMacNo = "Z";
                    else
                        strMacNo = "?";
                }
            }
            if (this.tbY.Text.Length != 2) return;
            if (this.tbM.Text.Length != 2) return;
            if (this.tbD.Text.Length != 2) return;
            string strCode = this.tbY.Text + this.tbM.Text + this.tbD.Text;
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MaxCode FROM Testing_MaxTuoPanCode where YYM='{0}{1}'", strMacNo, strCode));
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            int iMax;
            if (dt.Rows.Count == 0) iMax = 1;
            else
            {
                if (!int.TryParse(dt.Rows[0]["MaxCode"].ToString(), out iMax))
                {
                    iMax = 0;
                }
                else iMax++;
            }
            this.numericUpDown1.Value = iMax;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string strMacNo;
            if(JPSConfig.MacNo==99)
            {
                if(this.tbMacNo.Text.Length==0)
                {
                    this.ShowMsg("请输入设备编号。");
                    return;
                }
                //if(this.tbMacNo.Text!="1" && this.tbMacNo.Text != "2" && this.tbMacNo.Text != "3" && this.tbMacNo.Text != "4")
                //{
                //    this.ShowMsg("请正确输入设备编号从1~4。");
                //    return;
                //}
                strMacNo = this.tbMacNo.Text;
            }
            else
            {
                strMacNo = JPSConfig.MacNo.ToString();
            }
            //校验是否正确
            int iY;
            if(!int.TryParse(this.tbY.Text,out iY))
            {
                this.ShowMsg("请正确输入年份数据。");
                return;
            }
            if(this.tbY.Text.Length!=2)
            {
                this.ShowMsg("年份必须是2位的。");
                return;
            }
            if (this.tbM.Text.Length != 2)
            {
                this.ShowMsg("月份必须是2位的。");
                return;
            }
            int iM;
            if (!int.TryParse(this.tbM.Text, out iM))
            {
                this.ShowMsg("请正确输入月份数据。");
                return;
            }
            if(iM<=0 || iM>12)
            {
                this.ShowMsg("请正确输入月份数据。");
                return;
            }
            if (this.tbD.Text.Length != 2)
            {
                this.ShowMsg("日份必须是2位的。");
                return;
            }
            int iD;
            if (!int.TryParse(this.tbD.Text, out iD))
            {
                this.ShowMsg("请正确输入日数据。");
                return;
            }
            if (iD <= 0 || iD > 31)
            {
                this.ShowMsg("请正确输入日数据。");
                return;
            }
            string strCode = this.tbY.Text + this.tbM.Text + this.tbD.Text;
            string strMsg;
            int iReturnValue;
            try
            {
                if (JPSConfig.MacNo != 99)
                    this.BllDAL.ExpFuns_SetTuopanCode(strMacNo, strCode, (int)this.numericUpDown1.Value, out iReturnValue, out strMsg);
                else this.BllDAL.ExpFuns_SetTuopanCode4(strMacNo, strCode, (int)this.numericUpDown1.Value, out iReturnValue, out strMsg);
            }
            catch(Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0) strMsg = "操作失败，原因未知。";
                this.ShowMsg(strMsg);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void tbY_TextChanged(object sender, EventArgs e)
        {
            GetMaxCode();
        }

        private void tbM_TextChanged(object sender, EventArgs e)
        {

            GetMaxCode();
        }

        private void tbD_TextChanged(object sender, EventArgs e)
        {
            GetMaxCode();
        }

        private void picNext_MouseLeave(object sender, EventArgs e)
        {
            this.picNext.BorderStyle = BorderStyle.None;
        }

        private void picNext_MouseHover(object sender, EventArgs e)
        {
            this.picNext.BorderStyle = BorderStyle.FixedSingle;
        }

        private void picNext_Click(object sender, EventArgs e)
        {
            int iValue = (int)this.numericUpDown1.Value;
            iValue = iValue / 10;
            iValue++;
            iValue = iValue * 10 + 1;
            this.numericUpDown1.Value = iValue;
        }

        private void picPreDay_Click(object sender, EventArgs e)
        {
            int iValue;
            if (!int.TryParse(this.tbD.Text, out iValue)) return;
            iValue--;
            if (iValue <= 0) iValue = 1;
            string str = iValue.ToString();
            if (str.Length == 1) str = "0" + str;
            this.tbD.Text = str;
        }

        private void picPreDay_MouseHover(object sender, EventArgs e)
        {

            this.picPreDay.BorderStyle = BorderStyle.FixedSingle;
        }

        private void picPreDay_MouseLeave(object sender, EventArgs e)
        {
            this.picPreDay.BorderStyle = BorderStyle.None;

        }
    }
}
