using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign
{
    public partial class frmGrooveSetting : Common.frmBase
    {
        public bool _IsNet = false;
        public bool _Updated = false;

        public JPSEnum.AotuMkMode _AutoMkMode = JPSEnum.AotuMkMode.None;
        public frmGrooveSetting(JPSEnum.AotuMkMode mode)
        {
            InitializeComponent();
            this._AutoMkMode = mode;
        }
        public void SetTuoBtyCntEnable(bool blEnabled)
        {
            this.uc1.SetTuoBtyCntEnable(blEnabled);
            this.uc2.SetTuoBtyCntEnable(blEnabled);
            this.uc3.SetTuoBtyCntEnable(blEnabled);
            this.uc4.SetTuoBtyCntEnable(blEnabled);
            this.uc5.SetTuoBtyCntEnable(blEnabled);
            this.uc6.SetTuoBtyCntEnable(blEnabled);
            this.uc7.SetTuoBtyCntEnable(blEnabled);
            this.uc8.SetTuoBtyCntEnable(blEnabled);
            this.uc9.SetTuoBtyCntEnable(blEnabled);
            this.uc10.SetTuoBtyCntEnable(blEnabled);
            this.uc11.SetTuoBtyCntEnable(blEnabled);
            this.uc12.SetTuoBtyCntEnable(blEnabled);
            this.uc13.SetTuoBtyCntEnable(blEnabled);
            this.uc14.SetTuoBtyCntEnable(blEnabled);
            this.uc15.SetTuoBtyCntEnable(blEnabled);
            this.uc16.SetTuoBtyCntEnable(blEnabled);
            this.uc17.SetTuoBtyCntEnable(blEnabled);
            this.uc18.SetTuoBtyCntEnable(blEnabled);
        }
        private bool BindRealGrooves()
        {
            DataTable dtDetail;
            try
            {
                dtDetail = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM RealData_Grooves ORDER BY GrooveNo ASC");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.uc1.BindData(dtDetail);
            this.uc2.BindData(dtDetail);
            this.uc3.BindData(dtDetail);
            this.uc4.BindData(dtDetail);
            this.uc5.BindData(dtDetail);
            this.uc6.BindData(dtDetail);
            this.uc7.BindData(dtDetail);
            this.uc8.BindData(dtDetail);
            this.uc9.BindData(dtDetail);
            this.uc10.BindData(dtDetail);
            this.uc11.BindData(dtDetail);
            this.uc12.BindData(dtDetail);
            this.uc13.BindData(dtDetail);
            this.uc14.BindData(dtDetail);
            this.uc15.BindData(dtDetail);
            this.uc16.BindData(dtDetail);
            this.uc17.BindData(dtDetail);
            this.uc18.BindData(dtDetail);
            this.uc1.SetAutoMKSetyle(this._AutoMkMode);
            this.uc2.SetAutoMKSetyle(this._AutoMkMode);
            this.uc3.SetAutoMKSetyle(this._AutoMkMode);
            this.uc4.SetAutoMKSetyle(this._AutoMkMode);
            this.uc5.SetAutoMKSetyle(this._AutoMkMode);
            this.uc6.SetAutoMKSetyle(this._AutoMkMode);
            this.uc7.SetAutoMKSetyle(this._AutoMkMode);
            this.uc8.SetAutoMKSetyle(this._AutoMkMode);
            this.uc9.SetAutoMKSetyle(this._AutoMkMode);
            this.uc10.SetAutoMKSetyle(this._AutoMkMode);
            this.uc11.SetAutoMKSetyle(this._AutoMkMode);
            this.uc12.SetAutoMKSetyle(this._AutoMkMode);
            this.uc13.SetAutoMKSetyle(this._AutoMkMode);
            this.uc14.SetAutoMKSetyle(this._AutoMkMode);
            this.uc15.SetAutoMKSetyle(this._AutoMkMode);
            this.uc16.SetAutoMKSetyle(this._AutoMkMode);
            this.uc17.SetAutoMKSetyle(this._AutoMkMode);
            this.uc18.SetAutoMKSetyle(this._AutoMkMode);
            return true;
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if(this._IsNet)
            {
                if (this.uc1.IsSendMesUnChecked || this.uc2.IsSendMesUnChecked || this.uc3.IsSendMesUnChecked || this.uc4.IsSendMesUnChecked || this.uc5.IsSendMesUnChecked ||
                    this.uc6.IsSendMesUnChecked || this.uc7.IsSendMesUnChecked || this.uc8.IsSendMesUnChecked || this.uc9.IsSendMesUnChecked || this.uc10.IsSendMesUnChecked ||
                    this.uc11.IsSendMesUnChecked || this.uc12.IsSendMesUnChecked || this.uc13.IsSendMesUnChecked || this.uc14.IsSendMesUnChecked || this.uc15.IsSendMesUnChecked ||
                    this.uc16.IsSendMesUnChecked || this.uc17.IsSendMesUnChecked || this.uc18.IsSendMesUnChecked)
                {
                    if (!this.IsUserConfirm("当前为网络模式，但部分槽的良品未选择上传MES！\r\n您确定这是正确的吗？")) return;
                }
                if (this.uc1.IsBhgSendMesChecked || this.uc2.IsBhgSendMesChecked || this.uc3.IsBhgSendMesChecked || this.uc4.IsBhgSendMesChecked || this.uc5.IsBhgSendMesChecked ||
                    this.uc6.IsBhgSendMesChecked || this.uc7.IsBhgSendMesChecked || this.uc8.IsBhgSendMesChecked || this.uc9.IsBhgSendMesChecked || this.uc10.IsBhgSendMesChecked ||
                    this.uc11.IsBhgSendMesChecked || this.uc12.IsBhgSendMesChecked || this.uc13.IsBhgSendMesChecked || this.uc14.IsBhgSendMesChecked || this.uc15.IsBhgSendMesChecked ||
                    this.uc16.IsBhgSendMesChecked || this.uc17.IsBhgSendMesChecked || this.uc18.IsBhgSendMesChecked)
                {
                    if (!this.IsUserConfirm("部分槽为不良品但选择了上传MES！\r\n您确定这是正确的吗？")) return;
                }
            }
            else
            {
                if (this.uc1.IsSendMesChecked || this.uc2.IsSendMesChecked || this.uc3.IsSendMesChecked || this.uc4.IsSendMesChecked || this.uc5.IsSendMesChecked ||
                    this.uc6.IsSendMesChecked || this.uc7.IsSendMesChecked || this.uc8.IsSendMesChecked || this.uc9.IsSendMesChecked || this.uc10.IsSendMesChecked ||
                    this.uc11.IsSendMesChecked || this.uc12.IsSendMesChecked || this.uc13.IsSendMesChecked || this.uc14.IsSendMesChecked || this.uc15.IsSendMesChecked ||
                    this.uc16.IsSendMesChecked || this.uc17.IsSendMesChecked || this.uc18.IsSendMesChecked)
                {
                    if (!this.IsUserConfirm("当前为单机模式，但部分槽选择上传MES！\r\n您确定这是正确的吗？")) return;
                }
            }
            if(this.Save())
            {
                this.ShowMsgRich("保存成功");
                this._Updated = true;
                return;
            }
        }
        private bool Save()
        {
            DataTable dtDetail;
            try
            {
                dtDetail = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM RealData_Grooves ORDER BY GrooveNo ASC");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            string strErr;
            if(!ReadForm(dtDetail,out strErr))
            {
                this.ShowMsg(strErr);
                return false;
            }
            //保存数据
            try
            {
                Common.CommonDAL.DoSqlCommand.SaveTable(dtDetail, "RealData_Grooves");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            return true;
        }
        private bool ReadForm(DataTable dtSource,out string sErr)
        {
            if (!this.uc1.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc2.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc3.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc4.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc5.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc6.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc7.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc8.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc9.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc10.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc11.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc12.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc13.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc14.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc15.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc16.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc17.ReadForm(dtSource, out sErr))
                return false;
            if (!this.uc18.ReadForm(dtSource, out sErr))
                return false;
            return true;
        }
        public void IsAllSame(bool blIsAllSame)
        {
            this.chkAll.Checked = blIsAllSame;
        }
        private void frmGrooveSetting_Load(object sender, EventArgs e)
        {
            this.uc1.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc2.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc3.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc4.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc5.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc6.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc7.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc8.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc9.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc10.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc11.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc12.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc13.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc14.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc15.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc16.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc17.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.uc18.MyGrooveTextChangedNotice += Uc1_MyGrooveTextChangedNotice;
            this.btTrue.Enabled = BindRealGrooves();
        }

        private void Uc1_MyGrooveTextChangedNotice(UserControls.TextNames name, string sText, int iQualtiy, UserControls.ucMyGroove uc)
        {
            if (!this.chkAll.Checked) return;
            if (!uc.Equals(this.uc1))
                this.uc1.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc2))
                this.uc2.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc3))
                this.uc3.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc4))
                this.uc4.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc5))
                this.uc5.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc6))
                this.uc6.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc7))
                this.uc7.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc8))
                this.uc8.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc9))
                this.uc9.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc10))
                this.uc10.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc11))
                this.uc11.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc12))
                this.uc12.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc13))
                this.uc13.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc14))
                this.uc14.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc15))
                this.uc15.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc16))
                this.uc16.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc17))
                this.uc17.SetText(name, sText, iQualtiy);
            if (!uc.Equals(this.uc18))
                this.uc18.SetText(name, sText, iQualtiy);
        }
    }
}
