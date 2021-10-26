using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Common.MyEntity
{
    public class SearchButtonItem
    {
        /// <summary>
        /// 列表界面搜索项目
        /// </summary>
        public SearchButtonItem()
        {

        }
        private string _titleName = string.Empty;
        private int _ivalue = -1;
        private Image _marginImage = null;
        /// <summary>
        /// 搜索标题
        /// </summary>
        public string TitleName
        {
            get { return this._titleName; }
            set { this._titleName = value; }
        }
        /// <summary>
        /// 下拉按钮标示
        /// </summary>
        public int Value
        {
            get { return this._ivalue; }
            set { this._ivalue = value; }
        }
        /// <summary>
        /// 按钮图标
        /// </summary>
        public Image MarginImage
        {
            get { return this._marginImage; }
            set { this._marginImage = value; }
        }
        private bool _blCheckOnClick = false;
        /// <summary>
        /// 是否为复选按钮
        /// </summary>
        public bool CheckOnClick
        {
            get { return this._blCheckOnClick; }
            set { this._blCheckOnClick = value; }
        }
    }
}
