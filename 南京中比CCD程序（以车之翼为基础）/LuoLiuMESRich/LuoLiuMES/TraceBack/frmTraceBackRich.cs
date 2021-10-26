using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES.TraceBack
{
    public partial class frmTraceBackRich : Common.frmBase
    {
        const string CInput = "input";
        int _UCChengPinHei = 0;
        int _UCMkHei = 0;
        int _UCMzHei = 0;
        public frmTraceBackRich()
        {
            InitializeComponent();
            this._UCChengPinHei = this.ucChengPin1.Height;
            this._UCMkHei = this.ucMz1.Height;
            this._UCMzHei = this.ucMk1.Height;
            this.ucChengPin1._MainForm = this;
            this.ucMz1._MainForm = this;
            this.ucMk1._MainForm = this;
        }
        #region 重写函数
        public override void AcitiveTimer_Doing(object Arg)
        {
            if(Arg!=null && Arg.ToString()==CInput)
            {
                this.tbSFGCode.Focus();
                this.tbSFGCode.SelectAll();
            }
        }
        #endregion
        #region 打开各个工序数据
        /// <summary>
        /// 打开工序作业信息及检测信息
        /// </summary>
        /// <param name="iSFGType">半成品类型3：电池包，2：模组，1：模块</param>
        /// <param name="sProcessCode">工序</param>
        /// <param name="sCode">半成品编号</param>
        /// <param name="sGuid">工序表中的GUID</param>
        public void OpenProcessData(int iSFGType,string sProcessCode, string sCode, string sGuid)
        {
            if(iSFGType==1)
            {
                #region 模块
                if (sProcessCode=="00")
                {
                    //此时打开的是分选工序
                    AutoAssign.frmAutoAssignData frm = new AutoAssign.frmAutoAssignData();
                    frm._MKCode = sCode;
                    frm.FormParent = this;
                    frm.FormState = Common.MyEnums.FormStates.Readonly;
                    frm.Text = string.Format("模块{0}数据(只读)", sCode);
                    this.ShowChildForm(frm.Text, frm);
                }
                #endregion
            }
            else if (iSFGType == 2)
            {
                #region 模组
                if (sProcessCode == "06")
                {
                    //此时打开的是分选工序
                    EleCardComposing.DataM.frmComposedData frm = new EleCardComposing.DataM.frmComposedData();
                    frm._MzCode = sCode;
                    frm.FormParent = this;
                    frm.FormState = Common.MyEnums.FormStates.Readonly;
                    frm.Text = string.Format("模组{0}锁装记录(只读)", sCode);
                    this.ShowChildForm(frm.Text, frm);
                }
                if (sProcessCode == "18")
                {
                    //EOL测试
                    LuoLiuEOLTest.frmEOLTestDataEdit frm = new LuoLiuEOLTest.frmEOLTestDataEdit();
                    frm.PrimaryValue = sGuid;
                    frm.iSFGType = 1;
                    frm.FormParent = this;
                    frm.FormState = Common.MyEnums.FormStates.Readonly;
                    frm.Text = string.Format("模组{0}EOL检测记录(只读)", sCode);
                    this.ShowChildForm(frm.Text, frm);
                }

                #endregion
            }
            else if (iSFGType == 3)
            {
                #region 电池包
                if (sProcessCode == "20")
                {
                   
                }
                if (sProcessCode == "18")
                {
                    //EOL测试
                    LuoLiuEOLTest.frmEOLTestDataEdit frm = new LuoLiuEOLTest.frmEOLTestDataEdit();
                    frm.PrimaryValue = sGuid;
                    frm.iSFGType = 2;
                    frm.FormParent = this;
                    frm.FormState = Common.MyEnums.FormStates.Readonly;
                    frm.Text = string.Format("电池包{0}EOL检测记录(只读)", sCode);
                    this.ShowChildForm(frm.Text, frm);
                }
                #endregion
            }

        }
        #endregion
        #region 处理函数
        private bool Perinit()
        {
            //绑定半成品类别
            this.comSFGTypes.DisplayMember = "Text";
            this.comSFGTypes.Items.Add(new Common.MyEntity.ComboBoxItem("电池包", 3));
            this.comSFGTypes.Items.Add(new Common.MyEntity.ComboBoxItem("模组", 2));
            this.comSFGTypes.Items.Add(new Common.MyEntity.ComboBoxItem("模块", 1));
            return true;
        }
        #endregion
        private void btSearch_Click(object sender, EventArgs e)
        {
            if (this.tbSFGCode.Text.Length == 0) return;
            int iType;
            Common.MyEntity.ComboBoxItem item = this.comSFGTypes.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString().Length == 0 || !int.TryParse(item.Value.ToString(), out iType))
            {
                this.ShowMsg("请选择产品类型。");
                this.comSFGTypes.Focus();
                return ;
            }
            if (this.tbSFGCode.Text.Length == 0)
            {
                this.ShowMsg("请输入产品编号。");
                this.tbSFGCode.Focus();
                return ;
            }
            DataTable dt = this.GetDataSource(iType, this.tbSFGCode.Text);
            if(dt==null)
            {
                this.AcitiveTimer(200, CInput);
                return;
            }
            List<string> listCp = new List<string>();
            List<string> listMz = new List<string>();
            List<string> listMk = new List<string>();
            foreach(DataRow dr in dt.Select("SFGType=3"))
            {
                listCp.Add(dr["SFGCode"].ToString());
            }
            foreach (DataRow dr in dt.Select("SFGType=2"))
            {
                listMz.Add(dr["SFGCode"].ToString());
            }
            foreach (DataRow dr in dt.Select("SFGType=1"))
            {
                listMk.Add(dr["SFGCode"].ToString());
            }
            BindChengPin(listCp);
            BindMz(listMz);
            BindMk(listMk);
        }
        private DataTable GetDataSource(int iType,string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC TraceBackRich_GetSFGCodes '{0}',{1}", sCode.Replace("'", "''"), iType));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return null;   
            }
            if(dt.Columns.Contains("ErrMsg"))
            {
                this.ShowMsg(dt.Rows[0]["ErrMsg"].ToString());
                return null;
            }
            return dt;
        }
        private void BindChengPin(List<string> listCode)
        {
            while(listCode.Count>this.panChengPin.Controls.Count)
            {
                ucChengPin uc = new ucChengPin();
                uc.Name = this.GetGUID(Common.MyEnums.Modules.None, Common.CurrentUserInfo.UserCode);
                uc.Left = 0;
                uc.Top = this.panChengPin.Controls.Count * _UCChengPinHei + (this.panChengPin.Controls.Count == 0 ? 0 : 3);
                uc._MainForm = this;
                this.panChengPin.Controls.Add(uc);
            }
            while (listCode.Count < this.panChengPin.Controls.Count)
            {
                Control con = this.panChengPin.Controls[this.panChengPin.Controls.Count - 1];
                this.panChengPin.Controls.Remove(con);
                con.Dispose();
                con = null;
            }
            this.panChengPin.Height = (this.panChengPin.Controls.Count * (_UCChengPinHei + 3)) + 10;
            //绑定
            for(int i=0;i<listCode.Count;i++)
            {
                ucChengPin uc = this.panChengPin.Controls[i] as ucChengPin;
                if (uc == null) continue;
                uc.BindData(listCode[i]);
            }
        }
        private void BindMz(List<string> listCode)
        {
            while (listCode.Count > this.panMz.Controls.Count)
            {
                ucMz uc = new ucMz();
                uc.Name = this.GetGUID(Common.MyEnums.Modules.None, Common.CurrentUserInfo.UserCode);
                uc.Left = 0;
                uc.Top = this.panMz.Controls.Count * _UCMzHei + (this.panMz.Controls.Count == 0 ? 0 : 3);
                uc._MainForm = this;
                this.panMz.Controls.Add(uc);
            }
            while (listCode.Count < this.panMz.Controls.Count)
            {
                Control con = this.panMz.Controls[this.panMz.Controls.Count - 1];
                this.panMz.Controls.Remove(con);
                con.Dispose();
                con = null;
            }
            this.panMz.Height = (this.panMz.Controls.Count * (_UCMzHei + 3)) + 10;
            //绑定
            for (int i = 0; i < listCode.Count; i++)
            {
                ucMz uc = this.panMz.Controls[i] as ucMz;
                if (uc == null) continue;
                uc.BindData(listCode[i]);
            }
        }
        private void BindMk(List<string> listCode)
        {
            while (listCode.Count > this.panMk.Controls.Count)
            {
                ucMk uc = new ucMk();
                uc.Name = this.GetGUID(Common.MyEnums.Modules.None, Common.CurrentUserInfo.UserCode);
                uc.Left = 0;
                uc.Top = this.panMk.Controls.Count * _UCMkHei + (this.panMk.Controls.Count == 0 ? 0 : 3);
                uc._MainForm = this;
                this.panMk.Controls.Add(uc);
            }
            while (listCode.Count < this.panMk.Controls.Count)
            {
                Control con = this.panMk.Controls[this.panMk.Controls.Count - 1];
                this.panMk.Controls.Remove(con);
                con.Dispose();
                con = null;
            }
            this.panMk.Height = (this.panMk.Controls.Count * (_UCMkHei + 3)) + 10;
            //绑定
            for (int i = 0; i < listCode.Count; i++)
            {
                ucMk uc = this.panMk.Controls[i] as ucMk;
                if (uc == null) continue;
                uc.BindData(listCode[i]);
            }
        }

        private void tbSFGCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            if (this.tbSFGCode.Text == string.Empty) return;
            btSearch_Click(null, null);
        }

        private void frmTraceBackRich_Load(object sender, EventArgs e)
        {
            Perinit();
        }
    }
}
