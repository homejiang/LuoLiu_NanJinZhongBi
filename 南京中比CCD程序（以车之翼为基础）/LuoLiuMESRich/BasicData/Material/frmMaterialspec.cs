using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using ErrorService;
using Common.MyEnums;

namespace BasicData.Material
{
    public partial class frmMaterialspec : frmBase
    {
        public frmMaterialspec()
        {
            InitializeComponent();
        }
        #region 公共属性
        public string _Spec = string.Empty;
        public object _objDensity = DBNull.Value;
        public object _objLossRate = DBNull.Value;
        public string _DTypeView = string.Empty;//尺寸描述
        public object _objDiameter1 = DBNull.Value;
        public object _objDiameter2 = DBNull.Value;
        public object _objDiameter3 = DBNull.Value;
        public string _BusinessCode = string.Empty;
        public string _Remark = string.Empty;
        public bool _Terminated = false;
        /// <summary>
        /// 是否尺寸描述显示
        /// </summary>
        public bool _IsD1Show = false;
        public bool _IsD2Show = false;
        public bool _IsD3Show = false;
        #endregion
        private bool ReadData()
        {
            if (this.tbSpec.Text.Trim().Length == 0)
            {
                this.ShowMsg("规格不能为空");
                this.tbSpec.Focus();
                return false;
            }
            this._Spec = this.tbSpec.Text;
            decimal dec;
           
            if (this._IsD1Show)
            {
                if (this.tbDiameter1.Text == string.Empty || !decimal.TryParse(this.tbDiameter1.Text, out dec) || dec <= 0M)
                {
                    this.ShowMsg("尺寸值必须为一个大于0的数值。");
                    this.tbDiameter1.Focus();
                    return false;
                }
                this._objDiameter1 = dec;
            }
            else this._objDiameter1 = DBNull.Value;
            if (this._IsD2Show)
            {
                if (this.tbDiameter2.Text == string.Empty || !decimal.TryParse(this.tbDiameter2.Text, out dec) || dec <= 0M)
                {
                    this.ShowMsg("尺寸值必须为一个大于0的数值。");
                    this.tbDiameter2.Focus();
                    return false;
                }
                this._objDiameter2 = dec;
            }
            else this._objDiameter2 = DBNull.Value;

            if (this._IsD3Show)
            {
                if (this.tbDiameter3.Text == string.Empty || !decimal.TryParse(this.tbDiameter3.Text, out dec) || dec <= 0M)
                {
                    this.ShowMsg("尺寸值必须为一个大于0的数值。");
                    this.tbDiameter3.Focus();
                    return false;
                }
                this._objDiameter3 = dec;
            }
            else this._objDiameter3 = DBNull.Value;
            this._Remark = this.tbRemark.Text;
            this._Terminated = this.cbTerminated.Checked;
            return true;
        }
        #region 窗体事件
        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ReadData()) return;
            this.DialogResult = DialogResult.OK;
        }

        private void frmMaterialspec_Load(object sender, EventArgs e)
        {
            this.tbSpec.Text = this._Spec;
            if (!this._IsD1Show && !this._IsD1Show && !this._IsD1Show)
                this.tbDTypeView.Text = "无";
            else
                this.tbDTypeView.Text = this._DTypeView;
            if (this._IsD1Show)
                this.tbDiameter1.Text = Common.CommonFuns.FormatData.GetStringByDecimal(this._objDiameter1, "#########0.###");
            if (this._IsD2Show)
                this.tbDiameter2.Text = Common.CommonFuns.FormatData.GetStringByDecimal(this._objDiameter2, "#########0.###");
            if (this._IsD3Show)
                this.tbDiameter3.Text = Common.CommonFuns.FormatData.GetStringByDecimal(this._objDiameter3, "#########0.###");
            this.tbDiameter1.Enabled = this._IsD1Show;
            this.tbDiameter2.Enabled = this._IsD2Show;
            this.tbDiameter3.Enabled = this._IsD3Show;
            this.tbRemark.Text = this._Remark;
            this.cbTerminated.Checked = this._Terminated;
        }
        #endregion
    }
}