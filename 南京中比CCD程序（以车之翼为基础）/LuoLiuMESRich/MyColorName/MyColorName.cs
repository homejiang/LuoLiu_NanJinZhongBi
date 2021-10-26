using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MyControl
{
    public class MyColorName:System.Windows.Forms.Panel
    {
        #region  公共属性
        private string _strBorderColor = "#7F9DB9";
        [CategoryAttribute("MyColorName"), DescriptionAttribute("BorderColor"), DefaultValue("#7F9DB9")]
        public string BorderColor
        {
            get { return this._strBorderColor; }
            set { this._strBorderColor = value; }
        }
        [CategoryAttribute("MyColorName"), DescriptionAttribute("Color"), DefaultValue("#000000")]
        public string Color
        {
            get
            {
                return System.Drawing.ColorTranslator.ToHtml(this.BackColor);
            }
            set
            {
                if (value.Length > 0)
                    this.BackColor = System.Drawing.ColorTranslator.FromHtml(value);
            }
        }
        private string _strColorName="[未设置]";
        [CategoryAttribute("MyColorName"), DescriptionAttribute("ColorName"), DefaultValue("[未设置]")]
        public string ColorName
        {
            get { return this._strColorName; }
            set { this._strColorName = value; }
        }
        [CategoryAttribute("MyColorName"), DescriptionAttribute("TextWidth"), DefaultValue(36)]
        private int _iTextWidth = 36;
        public int TextWidth
        {
            get
            {
                return this._iTextWidth;
            }
            set
            {
                this._iTextWidth = value;
            }
        }
        private bool _blShowBorder = true;
        public bool ShowBorder
        {
            get { return this._blShowBorder; }
            set 
            {
                //if (value)
                //    this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                //else
                //    this.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this._blShowBorder = value;
            }
        }
        #endregion
        public void SetNoneColor()
        {
            this.ColorName = "[未设置]";
        }
        #region 重写事件及函数
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.ShowBorder)
                System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, System.Drawing.ColorTranslator.FromHtml(this.BorderColor), System.Windows.Forms.ButtonBorderStyle.Solid);
            //设置文本标示
            System.Windows.Forms.Label lab;
            if (this.Controls.Count > 0)
                lab = this.Controls[0] as System.Windows.Forms.Label;
            else
            {
                //创建一个
                lab = new System.Windows.Forms.Label();
                lab.BackColor = System.Drawing.Color.White;
                
                lab.Name = "MyColorName_" + this.Name + "lable";
                lab.Width = this.TextWidth;
                lab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                System.Windows.Forms.Padding padding;
                if (this.ShowBorder)
                {
                    padding = new System.Windows.Forms.Padding(1);
                    lab.Location = new System.Drawing.Point(1, 1);
                }
                else
                {
                    padding = new System.Windows.Forms.Padding(0);
                    lab.Location = new System.Drawing.Point(0, 0);
                }
                this.Padding = padding;
                this.Controls.Add(lab);
            }
            lab.Text = this.ColorName;
            if (lab.Text == "[未设置]")
                lab.Dock = System.Windows.Forms.DockStyle.Fill;
            else
                lab.Dock = System.Windows.Forms.DockStyle.Left;
        }
        #endregion
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
