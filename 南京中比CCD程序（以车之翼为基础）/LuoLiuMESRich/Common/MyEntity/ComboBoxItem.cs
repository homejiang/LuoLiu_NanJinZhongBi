using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MyEntity
{
    public class ComboBoxItem
    {
        string _strText = string.Empty;
        string _strText1 = string.Empty;
        object _objValue = null;
        object _objTag = null;
        public ComboBoxItem()
        {
        }
        public ComboBoxItem(string strText, object objValue)
        {
            this._strText = strText;
            this._objValue = objValue;
        }
        public ComboBoxItem(string strText, string strText1, object objValue)
        {
            this._strText = strText;
            this._objValue = objValue;
            this._strText1 = strText1;
        }
        /// <summary>
        /// 显示值
        /// </summary>
        public string Text
        {
            get { return this._strText; }
            set { this._strText = value; }
        }
        /// <summary>
        /// 显示值1
        /// </summary>
        public string Text1
        {
            get { return this._strText1; }
            set { this._strText1 = value; }
        }
        /// <summary>
        /// 值
        /// </summary>
        public object Value
        {
            get { return this._objValue; }
            set { this._objValue = value; }
        }
        public object Tag
        {
            get { return this._objTag; }
            set { this._objTag = value; }
        }

    }
}
