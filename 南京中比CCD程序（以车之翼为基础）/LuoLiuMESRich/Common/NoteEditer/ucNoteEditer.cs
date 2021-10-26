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
        #region ˽�к���
        /// <summary>
        /// ���ı���ʽ�����˵�
        /// </summary>
        private void BindNoteType()
        {
            this.comNoteType.Items.Clear();
            this.comNoteType.DisplayMember = "Text";
            this.comNoteType.ValueMember = "Value";
            this.comNoteType.Items.Add(new Common.MyEntity.ComboBoxItem("���ı���ʽ", NoteFormart.Word));
            this.comNoteType.Items.Add(new Common.MyEntity.ComboBoxItem("HTML��ʽ", NoteFormart.HTML));
        }
        #endregion
        #region ��������
        /// <summary>
        /// ��ȡ��ǰ�༭���ͣ�1Ϊ���ı���2ΪHTML
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
            /// ���úͻ�ȡ��ǰ��ʾ�ı�
            /// </summary>
        public string Note
        {
            get { return this.tbNote.Text; }
            set { this.tbNote.Text = value; }
        }
        private NoteFormart _defaultnoteType = NoteFormart.Word;
        /// <summary>
        /// ���úͻ�ȡĬ�ϱ༭��ʽ�����δ����Ϊ���ı�
        /// </summary>
        public NoteFormart DefaultNoteType
        {
            get { return this._defaultnoteType; }
            set { this._defaultnoteType = value; }
        }
        #endregion
        #region ��������
        /// <summary>
        /// ��ȡ���ı����ݣ������HTML ����Ҫ��HTML���ݹ��˵�
        /// </summary>
        /// <returns></returns>
        public string GetNoteWithWord()
        {
            //��ʱ�ȷ����ı�������
            return this.Note;
        }
        #endregion
        /// <summary>
        /// �ı��༭��ʽ
        /// </summary>
        public enum NoteFormart
        {
            /// <summary>
            /// ���ı���ʽ
            /// </summary>
            Word=1,
            /// <summary>
            /// HTML��ʽ
            /// </summary>
            HTML=2
        }
    }
}
