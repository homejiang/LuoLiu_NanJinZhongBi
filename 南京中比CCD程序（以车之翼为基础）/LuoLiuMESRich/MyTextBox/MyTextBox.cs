using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace MyControl
{
    public class MyTextBox : TextBox
    {
        #region 私有属性
        private bool _IsForSel = false;
        #endregion
        #region 属性
        private string _strTextSplitWorld = string.Empty;
        public string TextSplitWorld
        {
            get
            {
                if (_strTextSplitWorld == string.Empty)
                    _strTextSplitWorld = "、";
                return this._strTextSplitWorld;
            }
            set
            {
                this._strTextSplitWorld = value;
            }
        }
        private string _strValueSplitWorld = string.Empty;
        public string ValueSplitWorld
        {
            get
            {
                if (_strValueSplitWorld == string.Empty)
                    _strValueSplitWorld = "|";
                return this._strValueSplitWorld;
            }
            set
            {
                this._strValueSplitWorld = value;
            }
        }
        #endregion
        #region 公共方法
        public bool Bind(string sValues, string sTexts)
        {
            string[] values = sValues.Split(this.ValueSplitWorld.ToCharArray());
            string[] texts = sTexts.Split(this.TextSplitWorld.ToCharArray());
            if (texts.Length != values.Length)
            {
                MessageBox.Show("传入的文本和值字符串数目不一样。");
                return false;
            }
            this.Tag = sValues;
            this.Text = sTexts;
            if (!this._IsForSel)
                this._IsForSel = true;
            return true;
        }
        #endregion
        private bool _isFilterQuanJiao = true;
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
        private bool _isUpper = false;
        public bool IsUpper
        {
            get
            {
                return this._isUpper;
            }
            set
            {
                this._isUpper = value;
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (this._IsForSel)
            {
                #region 当此控件为选择类型
                if ((int)e.KeyChar != 8)
                    e.KeyChar = (char)27;
                else
                {
                    int iSelIndex = this.SelectionStart;
                    if (this.SelectionLength > 0)
                    {
                        e.KeyChar = (char)27;
                        return;
                    }
                    //注：如果光标恰好在分割符的后面，则因删除前面的内容，所以需往前移一格
                    //例如“姜鹏松、哈哈”，如果在哈哈前面，就因该删除姜鹏松
                    if (iSelIndex - this.TextSplitWorld.Length > 0)
                    {
                        if (this.Text.Substring(iSelIndex - 1, this.TextSplitWorld.Length) == this.TextSplitWorld)
                            iSelIndex -= this.TextSplitWorld.Length;
                    }
                    string sText = this.Text.Substring(0, iSelIndex);
                    if (sText == string.Empty)
                        e.KeyChar = (char)27;
                    else
                    {
                        string[] arr = sText.Split(this.TextSplitWorld.ToCharArray());
                        string[] values = this.Tag.ToString().Split(this.ValueSplitWorld.ToCharArray());
                        string[] texts = this.Text.Split(this.TextSplitWorld.ToCharArray());
                        string strNewText = string.Empty;
                        string strNewValue = string.Empty;
                        int iNewSel = 0;
                        bool blNewSel = false;
                        for (int i = 0; i < texts.Length; i++)
                        {
                            if (i == arr.Length - 1)
                            {
                                blNewSel = true;
                                continue;
                            }
                            if (!blNewSel)
                                iNewSel += texts[i].Length + this.TextSplitWorld.Length;
                            strNewText += texts[i] + this.TextSplitWorld;
                            strNewValue += values[i] + this.ValueSplitWorld;
                        }
                        if (strNewText != string.Empty)
                            strNewText = strNewText.Substring(0, strNewText.Length - this.TextSplitWorld.Length);
                        if (strNewValue != string.Empty)
                            strNewValue = strNewValue.Substring(0, strNewValue.Length - this.ValueSplitWorld.Length);
                        this.Tag = strNewValue;
                        this.Text = strNewText;
                        if (iNewSel > strNewText.Length)
                            iNewSel = strNewText.Length;
                        e.KeyChar = (char)17;
                        this.SelectionStart = iNewSel;
                    }
                }
                #endregion
            }
            else
            {
                #region 仅仅作为文本框用
                if (this.FilterQuanJiao)
                {
                    #region 定义要过滤的全角ASC码
                    //"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890.,-=[]{}/~`?";
                    List<int> listAsc = new List<int>();
                    listAsc.Add(65345);
                    listAsc.Add(65346);
                    listAsc.Add(65347);
                    listAsc.Add(65348);
                    listAsc.Add(65349);
                    listAsc.Add(65350);
                    listAsc.Add(65351);
                    listAsc.Add(65352);
                    listAsc.Add(65353);
                    listAsc.Add(65354);
                    listAsc.Add(65355);
                    listAsc.Add(65356);
                    listAsc.Add(65357);
                    listAsc.Add(65358);
                    listAsc.Add(65359);
                    listAsc.Add(65360);
                    listAsc.Add(65361);
                    listAsc.Add(65362);
                    listAsc.Add(65363);
                    listAsc.Add(65364);
                    listAsc.Add(65365);
                    listAsc.Add(65366);
                    listAsc.Add(65367);
                    listAsc.Add(65368);
                    listAsc.Add(65369);
                    listAsc.Add(65370);
                    listAsc.Add(65313);
                    listAsc.Add(65314);
                    listAsc.Add(65315);
                    listAsc.Add(65316);
                    listAsc.Add(65317);
                    listAsc.Add(65318);
                    listAsc.Add(65319);
                    listAsc.Add(65320);
                    listAsc.Add(65321);
                    listAsc.Add(65322);
                    listAsc.Add(65323);
                    listAsc.Add(65324);
                    listAsc.Add(65325);
                    listAsc.Add(65326);
                    listAsc.Add(65327);
                    listAsc.Add(65328);
                    listAsc.Add(65329);
                    listAsc.Add(65330);
                    listAsc.Add(65331);
                    listAsc.Add(65332);
                    listAsc.Add(65333);
                    listAsc.Add(65334);
                    listAsc.Add(65335);
                    listAsc.Add(65336);
                    listAsc.Add(65337);
                    listAsc.Add(65338);
                    listAsc.Add(65297);
                    listAsc.Add(65298);
                    listAsc.Add(65299);
                    listAsc.Add(65300);
                    listAsc.Add(65301);
                    listAsc.Add(65302);
                    listAsc.Add(65303);
                    listAsc.Add(65304);
                    listAsc.Add(65305);
                    listAsc.Add(65296);
                    listAsc.Add(65294);
                    listAsc.Add(65292);
                    listAsc.Add(65293);
                    listAsc.Add(65309);
                    listAsc.Add(65339);
                    listAsc.Add(65341);
                    listAsc.Add(65371);
                    listAsc.Add(65373);
                    listAsc.Add(65295);
                    listAsc.Add(65374);
                    listAsc.Add(65344);
                    listAsc.Add(65311);
                    #endregion
                    int iAsc = (int)e.KeyChar;
                    if (listAsc.IndexOf(iAsc) >= 0)
                    {
                        iAsc -= 65248;
                        Char ch = (Char)iAsc;
                        e.KeyChar = ch;
                    }
                }
                if (this.IsUpper)
                {
                    char[] arrC = e.KeyChar.ToString().ToUpper().ToCharArray();
                    if (arrC.Length > 0)
                        e.KeyChar = arrC[0];
                }
                #endregion
            }
            base.OnKeyPress(e);
        }
        //粘贴消息 
        public const int WM_PASTE = 0x0302;
        protected override void WndProc(ref Message m)
        {
            //目前仅作为选择类控件用时才取消粘帖
            if (!this._IsForSel || m.Msg != WM_PASTE) base.WndProc(ref m);
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