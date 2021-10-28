using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.NanJingZB
{
    public partial class frmCreateTuopanCode : Common.frmBase
    {
        public string _CodeHeader = "";
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
        List<TextBox> _Textbox = null;
        public frmCreateTuopanCode(string sCodeHeader)
        {
            InitializeComponent();
           
            this.tbCode1_3.Tag = 3;
            this.tbCode2_1.Tag = 1;
            this.tbCode3_1.Tag = 1;
            this.tbCode4_2.Tag = 2;
            this.tbCode5_7.Tag = 7;
            _Textbox = new List<TextBox>();
            _Textbox.Add(tbCode1_3);
            _Textbox.Add(tbCode2_1);
            _Textbox.Add(tbCode3_1);
            _Textbox.Add(tbCode4_2);
            _Textbox.Add(tbCode5_7);
            #region 分配已有数据
            int iStartPos = 0;
            foreach(TextBox tb in _Textbox)
            {
                int iLen = int.Parse(tb.Tag.ToString());
                string sMyCode;
                if (sCodeHeader.Length < iStartPos)
                    sMyCode = string.Empty;
                else
                {
                    if (sCodeHeader.Length < (iStartPos + iLen))
                        sMyCode = sCodeHeader.Substring(iStartPos, sCodeHeader.Length - iStartPos);
                    else sMyCode = sCodeHeader.Substring(iStartPos, iLen);
                }
                tb.Text = sMyCode;
                iStartPos += iLen;
            }
            if (this.tbCode5_7.Text.Length == 0)
                this.tbCode5_7.Text = "0000000";
            this.BindSerial();
            #endregion
            foreach (TextBox tb in _Textbox)
            {
                tb.TextChanged += Tb_TextChanged;
            }
        }
        private void Tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;
            if (tb.Tag == null) return;
            int iCnt;
            if (!int.TryParse(tb.Tag.ToString(), out iCnt)) return;
            if (tb.Text.Length != iCnt)
            {
                return;
            }
            tb = this.GetNextTextBox(tb);
            this.tbSerial.ReadOnly = !this.BindSerial();
            if (tb == null) return;
            tb.Focus();
            tb.SelectAll();
        }
        #region 相关类
        private TextBox GetNextTextBox(TextBox tb)
        {
            if (tb.Equals(tbCode1_3)) return tbCode2_1;
            if (tb.Equals(tbCode2_1)) return tbCode3_1;
            if (tb.Equals(tbCode3_1)) return tbCode4_2;
            if (tb.Equals(tbCode4_2)) return tbCode5_7;
            return null;
        }
        private void ShowErr(string sMsg)
        {
            if (this.labErr.Text != sMsg)
                this.labErr.Text = sMsg;
        }

        private bool BindSerial()
        {
            string sCode = string.Empty;
            foreach(TextBox tb in this._Textbox)
            {
                sCode += tb.Text;
            }
            if (sCode.Length != 14)
            {
                ShowErr("编码总长度不是14位");
                return false;
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable($"SELECT * FROM Testing_MaxTuoPanCode WHERE YYM='{sCode.Replace("'", "''")}'");
            }
            catch(Exception ex)
            {
                this.ShowErr(ex.Message);
                return false;
            }
            int iSerial;
            if (dt.Rows.Count == 0) iSerial = 1;
            else
            {
                iSerial = dt.Rows[0]["MaxCode"].Equals(DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["MaxCode"].ToString());
                iSerial++;
            }
            this.tbSerial.Text = iSerial.ToString();
            this.ShowErr("");
            return true;
        }
        #endregion

        private void btSave_Click(object sender, EventArgs e)
        {
            string sCode = string.Empty;
            foreach (TextBox tb in this._Textbox)
            {
                int i = int.Parse(tb.Tag.ToString());
                if (i != tb.Text.Length)
                {
                    this.ShowMsg("编码长度填写不对！");
                    return;
                }
                sCode += tb.Text;
            }
            if (sCode.Length != 14)
            {
                this.ShowMsg("编码总长度不是14位");
                return ;
            }
            //更新
            if (!this.tbSerial.ReadOnly)
            {
                int iSeral;
                if (int.TryParse(this.tbSerial.Text, out iSeral))
                {
                    if(iSeral<1)
                    {
                        this.ShowMsg("序列号不能小于1");
                        return;
                    }
                    int iReturnValue;
                    string sErr;
                    try
                    {
                        this.BllDAL.NanJingZB_InitTuopanCode(sCode, iSeral, out iReturnValue, out sErr);
                    }
                    catch(Exception ex)
                    {
                        this.ShowMsg(ex.Message);
                        return;
                    }
                    if(iReturnValue!=1)
                    {
                        if (sErr.Length == 0) sErr = "序列号更新失败，原因未知。";
                        this.ShowMsg(sErr);
                        return;
                    }
                }
            }
            this._CodeHeader = sCode;
            this.DialogResult = DialogResult.OK;
        }

        private void frmCreateTuopanCode_Load(object sender, EventArgs e)
        {

        }

        private void btRefreshSerial_Click(object sender, EventArgs e)
        {
            this.tbSerial.ReadOnly = !this.BindSerial();
        }
    }
}
