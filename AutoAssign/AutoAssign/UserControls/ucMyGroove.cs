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
    public partial class ucMyGroove : UserControl
    {
        public event MyGrooveTextChangedCallBack MyGrooveTextChangedNotice = null;
        public ucMyGroove()
        {
            InitializeComponent();
            this.comQuality.Items.Add("不启用");
            this.comQuality.Items.Add("良品");
            this.comQuality.Items.Add("不良品");
            this.comQuality.SelectedIndex = 0;
        }
        short mGrooveNo = 0;
        public short GrooveNo
        {
            get
            {
                return mGrooveNo;
            }
            set
            {
                if(this.mGrooveNo!=value)
                {
                    this.mGrooveNo = value;
                    this.labNo.Text = value.ToString();
                }
            }
        }
        public bool IsSendMesUnChecked
        {
            get
            {
                if (chkMes.Checked) return false;
                if (this.comQuality.SelectedIndex != 1) return false;
                return true;
            }
        }
        /// <summary>
        /// 是否选中了上传MES，用于校验不联网的时候
        /// </summary>
        public bool IsSendMesChecked
        {
            get
            {
                if (!chkMes.Checked) return false;
                if (this.comQuality.SelectedIndex == 0) return false;//不启用的不用管了
                return true;
            }
        }
        public bool IsAutoMKChecked
        {
            get
            {
                if (!this.chkAutoMK.Checked) return false;
                if (this.comQuality.SelectedIndex == 0) return false;//不启用的不用管了
                return true;
            }
        }
        public bool IsBhgSendMesChecked
        {
            get
            {
                if (!chkMes.Checked) return false;
                if (this.comQuality.SelectedIndex != 2) return false;
                return true;
            }
        }
        public bool ReadForm(DataTable dtSource,out string sErr)
        {
            sErr = "";
            DataRow[] drs = dtSource.Select("GrooveNo=" + this.GrooveNo.ToString());
            DataRow dr;
            if(drs.Length==0)
            {
                dr = dtSource.NewRow();
                dr["GrooveNo"] = this.GrooveNo;
                dtSource.Rows.Add(dr);
            }
            else
            {
                dr = drs[0];
            }
            if (this.comQuality.SelectedIndex == 0)
            {
                //不启用
                if (!dr["Vmin"].Equals(DBNull.Value))
                    dr["Vmin"] = DBNull.Value;
                if (!dr["Vmax"].Equals(DBNull.Value))
                    dr["Vmax"] = DBNull.Value;
                if (!dr["DianZuMin"].Equals(DBNull.Value))
                    dr["DianZuMin"] = DBNull.Value;
                if (!dr["DianZuMax"].Equals(DBNull.Value))
                    dr["DianZuMax"] = DBNull.Value;
                if (!dr["QualityDesc"].Equals(DBNull.Value))
                    dr["QualityDesc"] = DBNull.Value;
                if (!dr["TuoBtyCount"].Equals(DBNull.Value))
                    dr["TuoBtyCount"] = DBNull.Value;
                if (dr["Quality"].ToString() != "0")
                    dr["Quality"] = (short)0;
                if ((!dr["SendMes"].Equals(DBNull.Value) && (bool)dr["SendMes"]) != false)
                    dr["SendMes"] = false;
                if ((!dr["AutoMK"].Equals(DBNull.Value) && (bool)dr["AutoMK"]) != false)
                    dr["AutoMK"] = false;
            }
            else
            {
                object obj;
                if (!this.GetDecimalValue(this.tbDianZuMin, "电阻值下限", out obj, out sErr)) return false;
                if (!dr["DianZuMin"].Equals(obj))
                    dr["DianZuMin"] = obj;
                if (!this.GetDecimalValue(this.tbDianZuMax, "电阻值上限", out obj, out sErr)) return false;
                if (!dr["DianZuMax"].Equals(obj))
                    dr["DianZuMax"] = obj;
                if (!this.GetDecimalValue(this.tbVMin, "电压值下限", out obj, out sErr)) return false;
                if (!dr["Vmin"].Equals(obj))
                    dr["Vmin"] = obj;
                if (!this.GetDecimalValue(this.tbVMax, "电压值上限", out obj, out sErr)) return false;
                if (!dr["Vmax"].Equals(obj))
                    dr["Vmax"] = obj;
                if (this.tbTuoBtyCount.Text.Length == 0)
                {
                    obj = DBNull.Value;
                }
                else
                {
                    short iBtyCount;
                    if (!short.TryParse(this.tbTuoBtyCount.Text, out iBtyCount))
                    {
                        sErr = string.Format("槽{0}的装托量设置不正确。", this.GrooveNo);
                        return false;
                    }
                    obj = iBtyCount;
                }
                if (dr["TuoBtyCount"].ToString() != obj.ToString())
                    dr["TuoBtyCount"] = obj;
                if (dr["Quality"].ToString() != this.comQuality.SelectedIndex.ToString())
                    dr["Quality"] = (short)this.comQuality.SelectedIndex;
                if (dr["QualityDesc"].ToString() != this.tbQualityDesc.Text)
                    dr["QualityDesc"] = this.tbQualityDesc.Text;

                if ((!dr["SendMes"].Equals(DBNull.Value) && (bool)dr["SendMes"]) != this.chkMes.Checked)
                    dr["SendMes"] = this.chkMes.Checked;
                if ((!dr["AutoMK"].Equals(DBNull.Value) && (bool)dr["AutoMK"]) != this.chkAutoMK.Checked)
                    dr["AutoMK"] = this.chkAutoMK.Checked;
                return true;
            }
            return true;
        }
        private bool GetDecimalValue(TextBox tb,string sItemName,out object objValue,out string sErr)
        {
            sErr = string.Empty;
            if (tb.Text.Length == 0)
            {
                objValue = DBNull.Value;
                return true;
            }
            else
            {
                decimal dec;
                if (!decimal.TryParse(tb.Text, out dec))
                {
                    objValue = DBNull.Value;
                    sErr = string.Format("请真确输入槽{0}\"{1}\"的值。", this.GrooveNo, sItemName);
                    return false;
                }
                objValue = dec;
                return true;
            }
        }
        private void ShowMsg(string sMsg)
        {
            MessageBox.Show(sMsg);
        }
        public void BindData(DataTable dt)
        {
            DataRow[] drs = dt.Select("GrooveNo=" + this.GrooveNo.ToString());
            if(drs.Length==0)
            {
                this.tbDianZuMin.Clear();
                this.tbDianZuMax.Clear();
                this.tbVMin.Clear();
                this.tbVMax.Clear();
                this.tbTuoBtyCount.Clear();
                this.comQuality.SelectedIndex = 0;
                this.tbQualityDesc.Clear();
                this.chkMes.Checked = false;
                this.chkAutoMK.Checked = false;
            }
            else
            {
                this.tbDianZuMin.Text = Common.CommonFuns.FormatData.GetStringByDecimal(drs[0]["DianZuMin"], "#########0.######");
                this.tbDianZuMax.Text = Common.CommonFuns.FormatData.GetStringByDecimal(drs[0]["DianZuMax"], "#########0.######");
                this.tbVMin.Text = Common.CommonFuns.FormatData.GetStringByDecimal(drs[0]["Vmin"], "#########0.######");
                this.tbVMax.Text = Common.CommonFuns.FormatData.GetStringByDecimal(drs[0]["Vmax"], "#########0.######");
                this.tbTuoBtyCount.Text = drs[0]["TuoBtyCount"].ToString();
                this.tbQualityDesc.Text= drs[0]["QualityDesc"].ToString();
                int iIndex;
                if (drs[0]["Quality"].Equals(DBNull.Value))
                    iIndex = -1;
                else
                {
                    iIndex = int.Parse(drs[0]["Quality"].ToString());
                }
                this.comQuality.SelectedIndex = iIndex;
                this.chkMes.Checked = !drs[0]["SendMes"].Equals(DBNull.Value) && (bool)drs[0]["SendMes"];
                this.chkAutoMK.Checked = !drs[0]["AutoMK"].Equals(DBNull.Value) && (bool)drs[0]["AutoMK"];
            }
            SetFormStyle();
        }
        private void SetFormStyle()
        {
            Color cbk;
            Color cfore;
            if(this.comQuality.SelectedIndex==0)
            {
                //如果不启用的话，直接都为只读
                this.tbDianZuMin.ReadOnly = true;
                this.tbDianZuMax.ReadOnly = true;
                this.tbVMin.ReadOnly = true;
                this.tbVMax.ReadOnly = true;
                this.tbTuoBtyCount.ReadOnly = true;
                this.tbQualityDesc.Visible = false;
                this.linkQualityDesc.Visible = false;
                this.chkAutoMK.Visible = false;
                this.chkMes.Visible = false;
                cbk = Color.White;
                cfore = Color.Gray;
            }
            else
            {
                //如果不启用的话，直接都为只读
                this.tbDianZuMin.ReadOnly = false;
                this.tbDianZuMax.ReadOnly = false;
                this.tbVMin.ReadOnly = false;
                this.tbVMax.ReadOnly = false;
                this.tbTuoBtyCount.ReadOnly = false;
                this.tbQualityDesc.Visible = true;
                this.linkQualityDesc.Visible = true;
                this.chkAutoMK.Visible = true;
                this.chkMes.Visible = true;
                if (this.comQuality.SelectedIndex==1)
                {
                    cbk = Color.FromArgb(55, 88, 136);
                    cfore = Color.White;
                }
                else
                {
                    cbk = Color.Maroon;
                    cfore = Color.White;
                }
            }
            if (this.labNo.BackColor != cbk)
                this.labNo.BackColor = cbk;
            if (this.labNo.ForeColor != cfore)
                this.labNo.ForeColor = cfore;
        }
        private void comQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFormStyle();
        }

        private void linkQualityDesc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BasicData.frmSelectQualityDesc frm = new BasicData.frmSelectQualityDesc();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData == null || frm.SelectedData.Count == 0) return;
            this.tbQualityDesc.Text = frm.SelectedData[0].QualityDesc.ToString();
        }

        private void tbDianZuMin_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbDianZuMin_Leave(object sender, EventArgs e)
        {
            if (MyGrooveTextChangedNotice != null)
                MyGrooveTextChangedNotice(TextNames.DianZuMin, this.tbDianZuMin.Text,this.comQuality.SelectedIndex, this);
        }

        private void tbDianZuMax_Leave(object sender, EventArgs e)
        {
            if (MyGrooveTextChangedNotice != null)
                MyGrooveTextChangedNotice(TextNames.DianZuMax, this.tbDianZuMax.Text, this.comQuality.SelectedIndex, this);
        }

        private void tbVMin_Leave(object sender, EventArgs e)
        {
            if (MyGrooveTextChangedNotice != null)
                MyGrooveTextChangedNotice(TextNames.VMin, this.tbVMin.Text, this.comQuality.SelectedIndex, this);
        }

        private void tbVMax_Leave(object sender, EventArgs e)
        {
            if (MyGrooveTextChangedNotice != null)
                MyGrooveTextChangedNotice(TextNames.VMax, this.tbVMax.Text, this.comQuality.SelectedIndex, this);
        }

        private void tbTuoBtyCount_Leave(object sender, EventArgs e)
        {
            if (MyGrooveTextChangedNotice != null)
                MyGrooveTextChangedNotice(TextNames.TuoBtyCnt, this.tbTuoBtyCount.Text, this.comQuality.SelectedIndex, this);
        }
        public void SetText(TextNames name,string strText,int iQuality)
        {
            if (iQuality != this.comQuality.SelectedIndex) return;
            if (name == TextNames.DianZuMin)
                this.tbDianZuMin.Text = strText;
            else if (name == TextNames.DianZuMax)
                this.tbDianZuMax.Text = strText;
            else if (name == TextNames.VMin)
                this.tbVMin.Text = strText;
            else if (name == TextNames.VMax)
                this.tbVMax.Text = strText;
            else if (name == TextNames.TuoBtyCnt)
                this.tbTuoBtyCount.Text = strText;
        }
        public void SetTuoBtyCntEnable(bool blEnabled)
        {
            if (this.tbTuoBtyCount.Enabled != blEnabled)
                this.tbTuoBtyCount.Enabled = blEnabled;
        }
        public void SetAutoMKSetyle(JPSEnum.AotuMkMode mode)
        {
            if (mode == JPSEnum.AotuMkMode.AutoMKOnly)
                this.chkAutoMK.Checked = true;
            else if (mode == JPSEnum.AotuMkMode.TuoPanOnly)
            {
                this.chkAutoMK.Checked = false;
            }
        }
    }
    public delegate void MyGrooveTextChangedCallBack(TextNames name,string sText,int iQualtiy, ucMyGroove uc);
    public enum TextNames
    {
        DianZuMin,
        DianZuMax,
        VMin,
        VMax,
        TuoBtyCnt
    }
}
