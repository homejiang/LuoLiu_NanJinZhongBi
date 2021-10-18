using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.ExpFuns
{
    public partial class frmCSVTestResult : Common.frmBase
    {
        JPSEntity.MyCsvWriter_TestReuslt _MyCsvWriter = null;
        string _TestCode = string.Empty;
        string _BatTableName = string.Empty;
        string _ResultTableName = string.Empty;
        #region 常量
        const string BTText_Start = "开始导出";
        const string BTText_Stop = "终止";
        const string BTText_Restart = "重新导出";
        #endregion
        int _MaxValue = 0;
        int _Value = 0;
        public frmCSVTestResult(string sTestCode,string sBatTable,string sResultTable)
        {
            InitializeComponent();
            this._TestCode = sTestCode;
            this._BatTableName = sBatTable;
            this._ResultTableName = sResultTable;
            this.labTitle.Text = string.Format("分选批次{0}数据导出CSV文件", sTestCode);
        }
        public void AddValue(int iAddValue)
        {
            this._Value += iAddValue;
            if (_MaxValue == 0)
            {
                this.labProgress.Width = this.panContainer.Width;
                this.labProgress.Text = "100%";
                return;
            }
            string strText;
            int iWidth;
            if (this._Value >= this._MaxValue)
            {
                strText = "100%";
                iWidth = this.panContainer.Width;
            }
            else
            {
                decimal dec = (decimal)this._Value / (decimal)this._MaxValue;
                strText = dec.ToString("#########0%");
                dec = dec * (decimal)this.panContainer.Width;
                iWidth = (int)dec;
                if (iWidth > this.panContainer.Width)
                    iWidth = this.panContainer.Width;
            }
            //计算进度条长度
            this.labProgress.Width = iWidth;
            if (iWidth > 10)
                this.labProgress.Text = strText;
        }
        public void Init(int iMaxValue)
        {
            this._MaxValue = iMaxValue;
            this.labProgress.Width = 0;
            this.labProgress.Text = string.Empty;
            this._Value = 0;
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            if (this.btTrue.Text != BTText_Stop)
            {
                string strFile;
                if(this.tbTarget.Text.Length==0)
                {
                    this.ShowMsg("请设置目标文件名！");
                }
                if(File.Exists(this.tbTarget.Text))
                {
                    this.ShowMsg("文件名已经存在了！");
                    return;
                }
                strFile = this.tbTarget.Text;
                string strErr;
                int iTotalCount;
                if (!JPSEntity.MyCsvWriter_TestReuslt.GetDataCount(this._BatTableName, this._ResultTableName,  out iTotalCount, out strErr))
                {
                    this.ShowMsg(strErr);
                    return;
                }
                //生成文件
                if (!_MyCsvWriter.StartListenning(strFile, out strErr))
                {
                    this.ShowMsg(strErr);
                    return;
                }
                this.Init(iTotalCount);
                this.panContainer.Visible = true;
                this.btTrue.Text = BTText_Stop;
            }
            else
            {
                //终止
                if (_MyCsvWriter != null)
                    _MyCsvWriter.Running = false;
            }

        }

        private void linkTarget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.Filter = "CSV文件(*.csv)|*.csv";
            dialog.OverwritePrompt = true;
            dialog.DefaultExt = ".csv";
            dialog.FileName = string.Format("分选批次数据备份_{0}.csv", this._TestCode);
            dialog.AddExtension = true;
            if (System.Windows.Forms.DialogResult.OK != dialog.ShowDialog(this))
                return ;
            if (dialog.FileName == string.Empty)
            {
                return ;
            }
            this.tbTarget.Text = dialog.FileName;
        }

        private void frmCSV_Load(object sender, EventArgs e)
        {
            this._MyCsvWriter = new JPSEntity.MyCsvWriter_TestReuslt(this, this._BatTableName, this._ResultTableName);
            this._MyCsvWriter.CsvSaveFinishedNotice += _MyCsvWriter_CsvSaveFinishedNotice;
            
        }

        private void _MyCsvWriter_CsvSaveFinishedNotice(bool blStop, bool blSucessfully, int iCount)
        {
            //更新当前进度
            if (blSucessfully)
            {
                this.AddValue(iCount);
                if (blStop)
                {
                    SetStatus(ClearStates.Compeleted);
                }
                else
                {
                    SetStatus(ClearStates.Writing);
                }
            }
            else
            {
                if (blStop)
                    SetStatus(ClearStates.Error);
            }
        }
        public void SetStatus(ClearStates state)
        {
            string strStatuText;
            if (state == ClearStates.Error)
            {
                strStatuText = BTText_Restart;
            }
            else if (state == ClearStates.Writing)
            {
                strStatuText = BTText_Stop;

            }
            else if (state == ClearStates.Compeleted)
            {
                strStatuText = BTText_Start;
            }
            else
            {
                //此时为.Compeleted
                strStatuText = "？？";
            }
            if (this.btTrue.Text != strStatuText)
                this.btTrue.Text = strStatuText;
        }
        public enum ClearStates
        {
            Error = 0,
            Compeleted = 1,
            Writing = 2
        }
        
        protected override void OnClosing(CancelEventArgs e)
        {
            if(this.btTrue.Text==BTText_Stop)
            {
                e.Cancel = true;
                this.ShowMsg("请先终止！");
                return;
            }
            base.OnClosing(e);
        }
    }
}
