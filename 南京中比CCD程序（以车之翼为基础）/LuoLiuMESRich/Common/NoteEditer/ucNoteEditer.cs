using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Common.NoteEditer
{
    public partial class ucNoteEditer : System.Windows.Forms.UserControl
    {
        public ucNoteEditer()
        {
            InitializeComponent();
        }

        private void ucNoteEditer_Load(object sender, EventArgs e)
        {
            if (this.comNoteType.Items.Count < 1)
                this.BindNoteType();
        }
        #region 私有函数
        /// <summary>
        /// 绑定文本格式下拉菜单
        /// </summary>
        private void BindNoteType()
        {
            this.comNoteType.Items.Clear();
            this.comNoteType.DisplayMember = "Text";
            this.comNoteType.ValueMember = "Value";
            this.comNoteType.Items.Add(new Common.MyEntity.ComboBoxItem("纯文本格式", NoteFormart.Word));
            this.comNoteType.Items.Add(new Common.MyEntity.ComboBoxItem("HTML格式", NoteFormart.HTML));
        }
        #endregion
        #region 公共属性
        /// <summary>
        /// 获取当前编辑类型，1为纯文本，2为HTML
        /// </summary>
        /// <returns></returns>
        public int NoteType
        {
            get
            {
                Common.MyEntity.ComboBoxItem item = this.comNoteType.SelectedItem as Common.MyEntity.ComboBoxItem;
                if (item == null || item.Value == null) return 0;
                return (int)item.Value;
            }
            set
            {
                if (this.comNoteType.Items.Count < 2)
                    this.BindNoteType();
                if (value != (int)NoteFormart.HTML && value != (int)NoteFormart.Word)
                {
                    value = (int)this.DefaultNoteType;
                }
                if (value == (int)NoteFormart.Word)
                    this.comNoteType.SelectedIndex = 0;
                else if (value == (int)NoteFormart.HTML)
                    this.comNoteType.SelectedIndex = 1;
                else
                    this.comNoteType.SelectedIndex = -1;
            }
        }
        /// <summary>
            /// 设置和获取当前显示文本
            /// </summary>
        public string Note
        {
            get { return this.tbNote.Text; }
            set { this.tbNote.Text = value; }
        }
        private NoteFormart _defaultnoteType = NoteFormart.Word;
        /// <summary>
        /// 设置和获取默认编辑格式，如果未设置为纯文本
        /// </summary>
        public NoteFormart DefaultNoteType
        {
            get { return this._defaultnoteType; }
            set { this._defaultnoteType = value; }
        }
        #endregion
        #region 公共方法
        /// <summary>
        /// 获取纯文本内容，如果是HTML 的需要将HTML数据过滤掉
        /// </summary>
        /// <returns></returns>
        public string GetNoteWithWord()
        {
            //暂时先返回文本框内容
            return this.Note;
        }
        #endregion
        /// <summary>
        /// 文本编辑格式
        /// </summary>
        public enum NoteFormart
        {
            /// <summary>
            /// 纯文本格式
            /// </summary>
            Word=1,
            /// <summary>
            /// HTML格式
            /// </summary>
            HTML=2
        }
    }
}
