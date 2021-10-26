using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common.Report
{
    public partial class frmReportTime : frmBase
    {
        public frmReportTime()
        {
            InitializeComponent();
        }
        #region ��������
        public DateTime StartTime;
        public DateTime EndTime;
        private string _strTimeHours1 = string.Empty;
        private string _strTimeHours2 = string.Empty;
        public string TimeHours1
        {
            get
            {
                if (_strTimeHours1 == string.Empty)
                    _strTimeHours1 = " 08:30";
                return _strTimeHours1;
            }
            set
            {
                this._strTimeHours1 = value;
                if (!_strTimeHours1.StartsWith(" "))
                    _strTimeHours1 = " " + _strTimeHours1;
            }
        }
        public string TimeHours2
        {
            get
            {
                if (_strTimeHours2 == string.Empty)
                    _strTimeHours2 = " 20:30";
                return _strTimeHours2;
            }
            set
            {
                this._strTimeHours2 = value;
                if (!_strTimeHours2.StartsWith(" "))
                    _strTimeHours2 = " " + _strTimeHours2;
            }
        }
        #endregion
        private void frmReportTime_Load(object sender, EventArgs e)
        {
            #region ��������ѡ��
            int i;
            for (i = 2012; i < 2020; i++)
            {
                this.comYear1.Items.Add(i.ToString());
                this.comYear2.Items.Add(i.ToString());
                this.comYear3.Items.Add(i.ToString());
            }
            for (i = 1; i < 13; i++)
            {
                this.comMonth1.Items.Add(i.ToString());
                this.comMonth2.Items.Add(i.ToString());
                this.comMonth3.Items.Add(i.ToString());
                    
            }
            for (i = 1; i < 32; i++)
            {
                this.comDay1.Items.Add(i.ToString());
                this.comDay2.Items.Add(i.ToString());
            }
            #endregion
            DateTime detSer;
            if (!Common.CommonFuns.GetSysCurrentDateTime(out detSer))
                return;
            detSer = detSer.AddDays(-1);//ͳ��ǰһ���
            this.comYear1.Text = detSer.ToString("yyyy");
            this.comMonth1.Text = detSer.ToString("MM");
            this.comDay1.Text = detSer.ToString("dd");
            this.comYear2.Text = detSer.ToString("yyyy");
            this.comMonth2.Text = detSer.ToString("MM");
            this.comDay2.Text = detSer.ToString("dd");
            this.comYear3.Text = detSer.ToString("yyyy");
            this.comMonth3.Text = detSer.ToString("MM");
            //���ص�ǰʱ��
            this.labCurTime.Text = "��ǰϵͳʱ�䣺" + Common.CommonFuns.FormatData.GetStringByDateTime(detSer, "yyyy-MM-dd HHʱmm��");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iTemp;
            //string strTemp;
            string strDate = string.Empty;
            if (this.comYear1.Text.Length == 0 || !int.TryParse(this.comYear1.Text, out iTemp) || iTemp.ToString().Length!=4)
            {
                this.ShowMsg("����ȷ������ݡ�");
                this.comYear1.Focus();
                return;
            }
            strDate = iTemp.ToString();
            if (this.comMonth1.Text.Length == 0 || !int.TryParse(this.comMonth1.Text, out iTemp) || iTemp > 12 || iTemp < 1)
            {
                this.ShowMsg("����ȷ�����·ݡ�");
                this.comMonth1.Focus();
                return;
            }
            if (iTemp < 10)
                strDate += "-0" + iTemp.ToString();
            else
                strDate += "-" + iTemp.ToString();
            if (this.comDay1.Text.Length == 0 || !int.TryParse(this.comDay1.Text, out iTemp) || iTemp > 31 || iTemp < 1)
            {
                this.ShowMsg("����ȷ�������ڡ�");
                this.comDay1.Focus();
                return;
            }
            if (iTemp < 10)
                strDate += "-0" + iTemp.ToString();
            else
                strDate += "-" + iTemp.ToString();
            if (this.radioDay.Checked)
            {
                //�װ�Ϊ��08:30��20:30
                this.StartTime = DateTime.Parse(strDate + this.TimeHours1);
                this.EndTime = DateTime.Parse(strDate + this.TimeHours2);
            }
            else if (this.radioNight.Checked)
            {
                //���Ϊ������20:30������08:30
                this.StartTime = DateTime.Parse(strDate + this.TimeHours2);
                this.EndTime = DateTime.Parse(this.StartTime.AddDays(1).ToString("yyyy-MM-dd") + this.TimeHours1);
            }
            else
            {
                this.ShowMsg("��ѡ��װ����ࡣ");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int iTemp;
            //string strTemp;
            string strDate = string.Empty;
            if (this.comYear2.Text.Length == 0 || !int.TryParse(this.comYear2.Text, out iTemp) || iTemp.ToString().Length != 4)
            {
                this.ShowMsg("����ȷ������ݡ�");
                this.comYear2.Focus();
                return;
            }
            strDate = iTemp.ToString();
            if (this.comMonth2.Text.Length == 0 || !int.TryParse(this.comMonth2.Text, out iTemp) || iTemp > 12 || iTemp < 1)
            {
                this.ShowMsg("����ȷ�����·ݡ�");
                this.comMonth2.Focus();
                return;
            }
            if (iTemp < 10)
                strDate += "-0" + iTemp.ToString();
            else
                strDate += "-" + iTemp.ToString();
            if (this.comDay2.Text.Length == 0 || !int.TryParse(this.comDay2.Text, out iTemp) || iTemp > 31 || iTemp < 1)
            {
                this.ShowMsg("����ȷ�������ڡ�");
                this.comDay2.Focus();
                return;
            }
            if (iTemp < 10)
                strDate += "-0" + iTemp.ToString();
            else
                strDate += "-" + iTemp.ToString();
            this.StartTime = DateTime.Parse(strDate + this.TimeHours1);
            this.EndTime = this.StartTime.AddDays(1);
            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int iTemp;
            //string strTemp;
            string strDate = string.Empty;
            if (this.comYear3.Text.Length == 0 || !int.TryParse(this.comYear3.Text, out iTemp) || iTemp.ToString().Length != 4)
            {
                this.ShowMsg("����ȷ������ݡ�");
                this.comYear3.Focus();
                return;
            }
            strDate = iTemp.ToString();
            if (this.comMonth3.Text.Length == 0 || !int.TryParse(this.comMonth3.Text, out iTemp) || iTemp > 12 || iTemp < 1)
            {
                this.ShowMsg("����ȷ�����·ݡ�");
                this.comMonth3.Focus();
                return;
            }
            if (iTemp < 10)
                strDate += "-0" + iTemp.ToString();
            else
                strDate += "-" + iTemp.ToString();
            this.StartTime = DateTime.Parse(strDate + "-01 08:30");
            this.EndTime = this.StartTime.AddMonths(1);
            this.DialogResult = DialogResult.OK;
        }
    }
}