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
            /// δ����
            /// </summary>
            None,
            /// <summary>
            /// ����
            /// </summary>
            Int32,
            /// <summary>
            /// �ַ���
            /// </summary>
            String,
            /// <summary>
            /// ��ֵ
            /// </summary>
            Decimal
        }
        /// <summary>
        /// �б����������Ŀ
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
        /// ��������
        /// </summary>
        public string TitleName
        {
            get { return this._titleName; }
            set { this._titleName = value; }
        }
        /// <summary>
        /// �����˵�
        /// </summary>
        public List<string> DropdownItems
        {
            get { return this._DropdownItems; }
            set { this._DropdownItems = value; }
        }
        /// <summary>
        /// �Ƿ������û��ֶ�����
        /// </summary>
        public bool CanInput
        {
            get { return this._canInput; }
            set { this._canInput = value; }
        }
        /// <summary>
        /// �Ƿ�ģ������
        /// </summary>
        public bool UseLike
        {
            get { return this._useLike; }
            set { this._useLike = value; }
        }
        /// <summary>
        /// �ַ���������ʽ���磺UserCode='{0}',��Ҫ����ֶ����Ͳ�ͬ����
        /// </summary>
        public string StringFormat
        {
            get { return this._stringformat; }
            set { this._stringformat = value; }
        }
        /// <summary>
        /// ��ʾ�б�������Ƿ��Ѿ�������
        /// </summary>
        public bool DropdownItemsLoaded
        {
            get { return this._dropdownItemsLoaded; }
            set { this._dropdownItemsLoaded = value; }
        }
        /// <summary>
        /// Ψһ��ʾ���ڼ�����ÿ����Ա��������Լ�Ψһ��valueֵ
        /// </summary>
        public int Value
        {
            get { return this._ivalue; }
            set { this._ivalue = value; }
        }
        private SearchValueTypes _type = SearchValueTypes.None;
        /// <summary>
        /// ����ֵ��Ӧ������
        /// </summary>
        public SearchValueTypes SearchValueType
        {
            get { return this._type; }
            set { this._type = value; }
        }
        #region ��������
        /// <summary>
        /// У�鴫���ֵ�Ƿ���Ԥ�ڵ�����
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
                    System.Windows.Forms.MessageBox.Show("\"" + sText + "\"�������������ֵ��");
                    return false;
                }
            }
            else if (this.SearchValueType == SearchValueTypes.Decimal)
            {
                decimal decTemp;
                if (!decimal.TryParse(sText, out decTemp))
                {
                    System.Windows.Forms.MessageBox.Show("\"" + sText + "\"�����������ֵ�͡�");
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
