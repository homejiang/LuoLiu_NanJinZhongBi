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
        public frmCreateTuopanCode()
        {
            InitializeComponent();
            this.tbCode1_3.Tag = 3;
            this.tbCode2_1.Tag = 1;
            this.tbCode3_1.Tag = 1;
            this.tbCode4_2.Tag = 2;
            _Textbox = new List<TextBox>();
            _Textbox.Add(tbCode1_3);
            _Textbox.Add(tbCode2_1);
            _Textbox.Add(tbCode3_1);
            _Textbox.Add(tbCode4_2);
            foreach(TextBox tb in _Textbox)
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
            if (sCode.Length != 7)
            {
                ShowErr("编码总长度不是7位");
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
            return true;
        }
        #endregion

        private void btSave_Click(object sender, EventArgs e)
        {
            string sCode = string.Empty;
            foreach (TextBox tb in this._Textbox)
            {
                sCode += tb.Text;
            }
            if (sCode.Length != 7)
            {
                this.ShowMsg("编码总长度不是7位");
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
                        if(sErr.Length==0)sErr="序列号更新失败，原因未知。"
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
