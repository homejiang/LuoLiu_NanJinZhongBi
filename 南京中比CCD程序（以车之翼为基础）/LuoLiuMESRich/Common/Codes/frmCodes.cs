using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ErrorService;

namespace Common.Codes
{
    public partial class frmCodes : Common.frmBase
    {
        #region 常量
        const string BTTextStart = "执 行";
        const string BTTextStop = "停 止";
        const string BTTextClose = "关 闭";
        #endregion
        #region 公共变量
        public string _DefaultCodes = string.Empty;
        #endregion
        #region 私有变量
        private bool _Start = true;
        private Thread _thread = null;
        private int _LineIndex = 0;
        private string[] _LineData;
        //用于检查是否有重号
        private string[] _LineDataCopy;
        #endregion
        #region 窗体事件
        public event ProCode frmCodes_ProCode = null;
        #endregion
        #region 私有delegate
        private delegate void SetTextCallback(int iLine, int iProResult);
        #endregion
        public frmCodes()
        {
            InitializeComponent();
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            if (this.btTrue.Text == BTTextStart)
            {
                this.btTrue.Text = BTTextStop;
                if (!this._Start) this._Start = true;
                if (!Start())
                    this.btTrue.Text = BTTextClose;
            }
            else if (this.btTrue.Text == BTTextStop)
            {
                if (!this.IsUserConfirm("您确定要停止吗？")) return;
                this._Start = false;
            }
            else
            {
                this.FormColse();
            }
        }
        private void frmCodes_Load(object sender, EventArgs e)
        {
            this.btTrue.Text = BTTextStart;
            if (_DefaultCodes.Length > 0)
                this.richTextBox1.Text = _DefaultCodes;
        }
        #region 重写函数
        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.btTrue.Text == BTTextStop)
            {
                this.ShowMsg("数据处理中，不能关闭。");
                e.Cancel = true;
            }
            base.OnClosing(e);
        }
        #endregion
        #region 处理函数
        private bool Start()
        {
            this._LineIndex = 0;
            _LineData = this.richTextBox1.Lines;
            _LineDataCopy = new string[_LineData.Length];
            _LineData.CopyTo(_LineDataCopy, 0);
            try
            {
                _thread = new Thread(new ThreadStart(Doing));
                _thread.IsBackground = true;//标记为后台线程，进入托管状态，此窗体内不对该线程进行结束操作了
                _thread.Start();
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            return true;
        }
        private void Doing()
        {
            if (frmCodes_ProCode != null)
            {
                bool blErrStop;
                if (this._LineIndex >= this._LineData.Length) return;
                string str;
                for (int i = this._LineIndex; i < this._LineData.Length; i++)
                {
                    if (!this._Start) return;
                    str = this._LineData[i];
                    //检查是否有重号
                    if (ChongHao(str, i))
                        AddResult(i, 3);
                    else
                    {
                        if (frmCodes_ProCode(str, out blErrStop))
                        {
                            //此时为成功，则要标识当前行为成功执行了；
                            AddResult(this._LineIndex, 1);
                        }
                        else
                        {
                            if (blErrStop) break;
                            else AddResult(this._LineIndex, 2);
                        }
                    }
                    this._LineIndex++;
                }
                //设置按钮文本
                if (this._LineIndex >= this._LineData.Length)
                    AddResult(-1, 1);
                else AddResult(-1, 2);
            }
        }
        private bool ChongHao(string sCode,int iEndLine)
        {
            //iEndLine：当前传入编码所在的行号，检查重号时应检查它之前的所有行号
            if (iEndLine == 0) return false;
            for (int i = 0; i < iEndLine; i++)
            {
                if (string.Compare(this._LineDataCopy[i], sCode, true) == 0) return true;
            }
            return false;
        }
        /// <summary>
        /// 添加处理结果
        /// </summary>
        /// <param name="iLine">当前行号</param>
        /// <param name="iProResult">1：成功；2：处理失败；3：重号</param>
        private void AddResult(int iLine, int iProResult)
        {
            try
            {
                SetTextCallback stcb = new SetTextCallback(SetResult);
                this.Invoke(stcb, new object[2] { iLine, iProResult });
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void SetResult(int iLine, int iProResult)
        {
            //如果iLine为-1，表示执行完了，则要将按钮设置为关闭状态
            if (iLine == -1)
            {
                this.btTrue.Text = BTTextClose;
                if (iProResult==1)
                    this.btTrue.Text += "(完成)";
                else
                    this.btTrue.Text += "(未处理完)";
                return;
            }
            //将结果显示在文本框内
            if (iLine >= this._LineData.Length) return;
            if (iProResult == 1) this._LineData[iLine] += "  →处理成功";
            else if (iProResult == 2) this._LineData[iLine] += "  →失败！！！！！！！！";
            else if (iProResult == 3) this._LineData[iLine] += "  →重号～～～～～～～～";
            StringBuilder sb = new StringBuilder();
            foreach (string str in this._LineData)
                sb.Append(str + "\r\n");
            this.richTextBox1.Text = sb.ToString();
        }
        #endregion
    }
    public delegate bool ProCode(string sCode,out bool isErrStop);

}