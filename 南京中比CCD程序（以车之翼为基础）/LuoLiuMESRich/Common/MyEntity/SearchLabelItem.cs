using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MyEntity
{
    public class SearchLabelItem
    {
        public enum SearchValueTypes
        {
            /// <summary>
            /// 未设置
            /// </summary>
            None,
            /// <summary>
            /// 整型
            /// </summary>
            Int32,
            /// <summary>
            /// 字符窜
            /// </summary>
            String,
            /// <summary>
            /// 数值
            /// </summary>
            Decimal
        }
        /// <summary>
        /// 列表界面搜索项目
        /// </summary>
        public SearchLabelItem()
        {

        }
        private string _titleName = string.Empty;
        private List<string> _DropdownItems = null;
        private bool _canInput = true;
        private bool _useLike = true;
        private string _stringformat = string.Empty;
        private bool _dropdownItemsLoaded = false;
        private int _ivalue = -1;
        /// <summary>
        /// 搜索标题
        /// </summary>
        public string TitleName
        {
            get { return this._titleName; }
            set { this._titleName = value; }
        }
        /// <summary>
        /// 下拉菜单
        /// </summary>
        public List<string> DropdownItems
        {
            get { return this._DropdownItems; }
            set { this._DropdownItems = value; }
        }
        /// <summary>
        /// 是否允许用户手动输入
        /// </summary>
        public bool CanInput
        {
            get { return this._canInput; }
            set { this._canInput = value; }
        }
        /// <summary>
        /// 是否模糊搜索
        /// </summary>
        public bool UseLike
        {
            get { return this._useLike; }
            set { this._useLike = value; }
        }
        /// <summary>
        /// 字符窜搜索格式例如：UserCode='{0}',主要解决字段类型不同问题
        /// </summary>
        public string StringFormat
        {
            get { return this._stringformat; }
            set { this._stringformat = value; }
        }
        /// <summary>
        /// 表示列表加载项是否已经加载了
        /// </summary>
        public bool DropdownItemsLoaded
        {
            get { return this._dropdownItemsLoaded; }
            set { this._dropdownItemsLoaded = value; }
        }
        /// <summary>
        /// 唯一标示，在集合中每个成员都因该有自己唯一的value值
        /// </summary>
        public int Value
        {
            get { return this._ivalue; }
            set { this._ivalue = value; }
        }
        private SearchValueTypes _type = SearchValueTypes.None;
        /// <summary>
        /// 搜素值对应的类型
        /// </summary>
        public SearchValueTypes SearchValueType
        {
            get { return this._type; }
            set { this._type = value; }
        }
        #region 公共函数
        /// <summary>
        /// 校验传入的值是否是预期的类型
        /// </summary>
        /// <param name="sText"></param>
        /// <returns></returns>
        public bool CheckSearchValueType(string sText)
        {
            if (this.SearchValueType == SearchValueTypes.None || this.SearchValueType == SearchValueTypes.String) return true;
            if (this.SearchValueType == SearchValueTypes.Int32)
            {
                int iTemp;
                if (!int.TryParse(sText, out iTemp))
                {
                    System.Windows.Forms.MessageBox.Show("\"" + sText + "\"不是所需的整型值。");
                    return false;
                }
            }
            else if (this.SearchValueType == SearchValueTypes.Decimal)
            {
                decimal decTemp;
                if (!decimal.TryParse(sText, out decTemp))
                {
                    System.Windows.Forms.MessageBox.Show("\"" + sText + "\"不是所需的数值型。");
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
