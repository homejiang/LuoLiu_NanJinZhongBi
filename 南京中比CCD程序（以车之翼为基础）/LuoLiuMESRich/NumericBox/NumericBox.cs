using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
namespace MyControl
{
    public class NumericBox : TextBox
    {
        private string _strFormart;
        [CategoryAttribute("NumericBox"), DescriptionAttribute("Format"), DefaultValue("##########0.######")]
        public string Formart
        {
            get
            {
                return this._strFormart;
            }
            set
            {
                this._strFormart = value;
            }
        }
        public object BindValue
        {
            get
            {
                //将Text转换为数值
                decimal dec;
                //如果是有百分号的要去除百分号
                if (this.Text.IndexOf("%") > 0)
                {
                    string strText = this.Text;
                    strText = strText.Replace("%", "");
                    decimal decText;
                    if (!decimal.TryParse(strText, out decText))
                        decText = 0M;
                    decText = decText / 100;
                    if (this.IsHundred)
                        decText = decText / 100;
                    return decText;
                }
                if (!decimal.TryParse(this.Text, out dec))
                    return DBNull.Value;
                return dec;
            }
            set
            {
                if (!String.IsNullOrEmpty(this.Formart))
                {
                    if (value != null && !value.Equals(DBNull.Value))
                    {
                        decimal dec;
                        if (decimal.TryParse(value.ToString(), out dec))
                            this.Text = dec.ToString(this.Formart);
                    }
                }
                if (value == null || value.Equals(DBNull.Value))
                    this.Text = string.Empty;
            }
        }
        #region 是否过滤全角
        private bool _isFilterQuanJiao = false;
        public bool FilterQuanJiao
        {
            get
            {
                return this._isFilterQuanJiao;
            }
            set
            {
                this._isFilterQuanJiao = value;
            }
        }
        #endregion
        #region 百分号设置
        [CategoryAttribute("Percent"), DescriptionAttribute("IsShow"), DefaultValue(false)]
        private bool _blPercent;
        public bool IsPercent
        {
            get
            {
                return this._blPercent;
            }
            set
            {
                this._blPercent = value;
            }
        }
        [CategoryAttribute("Percent"), DescriptionAttribute("IsHundred"), DefaultValue(false)]
        private bool _blIsHundred;
        public bool IsHundred
        {
            get
            {
                return this._blIsHundred;
            }
            set
            {
                this._blIsHundred = value;
            }
        }
        #endregion
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            int iAsc;
            if (this.FilterQuanJiao)
            {
                //过滤全角:如果输入的为数字全角则转换为数字
                iAsc = (int)e.KeyChar;
                if (iAsc >= 65296 && iAsc <= 65305)
                {
                    iAsc -= 65248;
                    Char ch = (Char)iAsc;
                    e.KeyChar = ch;
                }
                else if (iAsc == 12290)
                    e.KeyChar = (char)(46);
            }
            //过滤数字和小数点
            iAsc = (int)e.KeyChar;
            bool isPass = false;
            if (iAsc >= 48 && iAsc <= 57)
                isPass = true;
            if (iAsc == 8)
                isPass = true;
            if (iAsc == 46 && this.Text.IndexOf(".") < 0)
            {
                isPass = true;//只能有一个小数点
            }
            //判断百分号
            if (e.KeyChar == '%' && this.IsPercent)
            {
                if (this.Text.IndexOf("%") == -1)
                    isPass = true;
            }
            if (!isPass)
            {
                e.KeyChar = (char)13;
                e.Handled = false;
            }
            base.OnKeyPress(e);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            if (this.IsPercent)
            {
                if (this.Text.IndexOf("%") >= 0 && !this.Text.EndsWith("%"))
                {
                    //如果百分号不在最后一位，则要吧百分号后面的清除掉
                    this.Text = this.Text.Substring(0, this.Text.IndexOf("%") + 1);
                }
                if (this.Text.IndexOf("%") == -1 && this.Text.Length > 0)
                {
                    if (this.IsHundred)
                    {
                        decimal decText;
                        if (!decimal.TryParse(this.Text, out decText))
                            decText = 0M;
                        decText = decText * 100;
                        this.Text = decText.ToString() + "%";
                    }
                    else
                    {
                        this.Text += "%";
                    }
                }
            }
            base.OnLostFocus(e);
        }
        #region 读取版本信息
        public class Version
        {
            public static string GetVersion()
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            public static string GetGuid()
            {
                System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
                object[] attrs = ass.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
                Guid id = new Guid(((System.Runtime.InteropServices.GuidAttribute)attrs[0]).Value);
                return id.ToString();
            }
            public static string GetTitle()
            {
                System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
                object[] attributes = ass.GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), false);
                System.Reflection.AssemblyTitleAttribute titleAttribute = (System.Reflection.AssemblyTitleAttribute)attributes[0];
                return titleAttribute.Title;
            }
            public static string GetStrForUpdate()
            {
                return GetGuid() + "|" + GetVersion();
            }
            public static void ContainGuids(List<string> list)
            {
                if (list == null)
                    list = new List<string>();
                string str = GetStrForUpdate();
                if (!list.Contains(str))
                    list.Add(str);
            }
        }
        #endregion
    }
}
