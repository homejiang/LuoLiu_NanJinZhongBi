using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Common.MyEntity
{
    public class SearchButtonItem
    {
        /// <summary>
        /// �б����������Ŀ
        /// </summary>
        public SearchButtonItem()
        {

        }
        private string _titleName = string.Empty;
        private int _ivalue = -1;
        private Image _marginImage = null;
        /// <summary>
        /// ��������
        /// </summary>
        public string TitleName
        {
            get { return this._titleName; }
            set { this._titleName = value; }
        }
        /// <summary>
        /// ������ť��ʾ
        /// </summary>
        public int Value
        {
            get { return this._ivalue; }
            set { this._ivalue = value; }
        }
        /// <summary>
        /// ��ťͼ��
        /// </summary>
        public Image MarginImage
        {
            get { return this._marginImage; }
            set { this._marginImage = value; }
        }
        private bool _blCheckOnClick = false;
        /// <summary>
        /// �Ƿ�Ϊ��ѡ��ť
        /// </summary>
        public bool CheckOnClick
        {
            get { return this._blCheckOnClick; }
            set { this._blCheckOnClick = value; }
        }
    }
}
