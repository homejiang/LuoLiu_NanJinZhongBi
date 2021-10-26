using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
namespace MyControl
{
    public class MyLabelEx:System.Windows.Forms.Label
    {
        public System.Windows.Forms.ContextMenuStrip _conMstrip = null;
        #region �����¼�
        public event MyLabelExChageTitleEventHandler TitleChanged = null;
        #endregion
        #region ��������
        /// <summary>
        ///  ���ó�ʼ��ʱ��ʾ�Ŀؼ�
        /// </summary>
        /// <param name="item"></param>
        public void SetText(MyLabelItem item)
        {
            this.Text = item.Text;
            this.Tag = item;
        }
        /// <summary>
        /// ���ó�ʼ��ʱ��ʾ�Ŀؼ�
        /// </summary>
        /// <param name="strText"></param>
        public void SetText(string strText)
        {
            MyLabelItem item = new MyLabelItem(strText);
            this.SetText(item);
        }
        /// <summary>
        ///  ���ص�ǰѡ�е�item
        /// </summary>
        /// <returns></returns>
        public MyLabelItem GetCurrentItem()
        {
            MyLabelItem item = this.Tag as MyLabelItem;
            if (item == null)
                return new MyLabelItem(this.Text);
            return item;
        }
        public void AddItem(MyLabelItem item)
        {
            if (this._childItems == null)
                this._childItems = new List<MyLabelItem>();
            this._childItems.Add(item);
            //ͬ�����ContextMenuStrip
            this.AddStripMenuItem(this.ConMstrip.Items.Count, item);
        }
        public void InsertItem(int index, MyLabelItem item)
        {
            if (this._childItems == null)
                this._childItems = new List<MyLabelItem>();
            this._childItems.Insert(index, item);
            //ͬ������ContextMenuStrip
            this.AddStripMenuItem(index, item);
        }
        public void RemoveAt(int index)
        {
            if (this._childItems == null)
                return;
            if (this._childItems.Count ==0)
                return;
            this._childItems.RemoveAt(index);
            //ͬ���Ƴ�ContextMenuStrip
            this.RemoveStripMenuItem(index);
        }
        public void Remove(MyLabelItem item)
        {
            if (this._childItems == null)
                return;
            if (this._childItems.Count == 0)
                return;
            int index = -1;
            for(int i=0;i<this._childItems.Count;i++)
            {
                if (this._childItems[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1) return;
            this._childItems.RemoveAt(index);
            //ͬ���Ƴ�ContextMenuStrip
            this.RemoveStripMenuItem(index);

        }
        /// <summary>
        /// ��ȡ�����item��Ӧ����ģ���Ƿ�ѡ��
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool GetItemChecked(MyLabelItem item)
        {
            int index = -1;
            for (int i = 0; i < this.ChildItems.Count; i++)
            {
                if (this.ChildItems[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            if (index < 0) return false;
            ToolStripMenuItem tsp = this.ConMstrip.Items[index] as ToolStripMenuItem;
            return tsp.Checked;
        }
        /// <summary>
        /// ���õ�ǰѡ�б���
        /// </summary>
        /// <param name="labelItem">��Ҫѡ�б����MyLabelItemʵ��</param>
        public void SetCurrentItemByValue(MyControl.MyLabelEx.MyLabelItem labelItem)
        {
            if (this.Tag != null && this.Tag.Equals(labelItem))
                return;//��ʱ�Ѿ���ѡ��״̬
            for (int i = 0; i < this.ChildItems.Count; i++)
            {
                if (this.ChildItems[i].Equals(labelItem))
                {
                    this.tsItem_Click(this.ConMstrip.Items[i], null);
                }
            }
        }
        #endregion
        #region ˽������
        private System.Drawing.Color _orignalBackColor = Color.Transparent;
        private System.Drawing.Color _orignalForeColor = Color.Black;
        private BorderStyle _orignalBorderStyle = BorderStyle.None;
        private System.Windows.Forms.ContextMenuStrip ConMstrip
        {
            get
            {
                if (this._conMstrip == null)
                {
                    this._conMstrip = new ContextMenuStrip();
                    this._conMstrip.ShowImageMargin = false;
                }
                return this._conMstrip;
            }
        }
        const string TextRightBlank = "  ";
        #endregion
        #region ��������
        private List<MyLabelItem> _childItems = null;
        public List<MyLabelItem> ChildItems
        {
            get { return this._childItems; }
        }
        private System.Drawing.Color _hoverBackColor = Color.NavajoWhite;//Ĭ����������ɫ
        /// <summary>
        /// �������ȥ��ı���ɫ
        /// </summary>
        public System.Drawing.Color HoverBackColor
        {
            get { return this._hoverBackColor; }
            set { this._hoverBackColor = value; }
        }
        private System.Drawing.Color _hoverForeColor = Color.Black;//Ĭ����������ɫ
        /// <summary>
        /// �������ȥ���������ɫ
        /// </summary>
        public System.Drawing.Color HoverForeColor
        {
            get { return this._hoverForeColor; }
            set { this._hoverForeColor = value; }
        }
        /// <summary>
        /// �����Ƿ��������������������Ҫ��ʾ���������α�ʾ
        /// </summary>
        public bool EnableDorpdown
        {
            set
            {
                if (value)
                {
                    //������ʽ������ʾ����ͼƬ
                    this.Image = global::MyLabelEx.Properties.Resources.dropdown;
                    this.AutoSize = false;
                    this.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                    //����¼���ģ��foxmail������ȥ֮����ʾ����ɫ
                    //��¼ԭʼ�ı���ɫ��������ɫ
                    this._orignalBackColor = this.BackColor;
                    this._orignalForeColor = this.ForeColor;
                    this._orignalBorderStyle = this.BorderStyle;
                    this.Text += TextRightBlank;
                }
                else
                {
                    this.Image = null;
                }
            }
        }
        /// <summary>
        /// �Ӱ�ť�Ƿ���ʾͼ��
        /// </summary>
        public bool ShowMarginImage
        {
            get { return this.ConMstrip.ShowImageMargin; }
            set
            {
                this.ConMstrip.ShowImageMargin = value;
            }
        }
        private bool _IsTextChange = false;
        /// <summary>
        /// �Ƿ�ť������ı��л�
        /// </summary>
        public bool IsTextChange
        {
            get { return this._IsTextChange; }
            set
            {
                this._IsTextChange = value;
            }
        }
        #endregion
        #region ����ContextMenuStrip�ؼ�
        private void AddStripMenuItem(int index,MyLabelItem item)
        {
            System.Windows.Forms.ToolStripMenuItem tsItem = new ToolStripMenuItem(item.Text);
            tsItem.Click+=new EventHandler(tsItem_Click);
            this.ConMstrip.Items.Insert(index, tsItem);
            if (this.ConMstrip.ShowImageMargin && item.MarginImage != null)
            {
                tsItem.Image = item.MarginImage;
            }
            tsItem.CheckOnClick = item.CheckOnClick;//�����Ƿ�Ϊ��ѡ��ť
        }
        private void RemoveStripMenuItem(int index)
        {
            //���ƶ�����label���Ӽ����Ƴ�
            if (this.ConMstrip.Items.Count <= index)
                return;
            this.ConMstrip.Items.RemoveAt(index);
        }
        #region �л��ı��¼�
        protected void tsItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) return;
            //label������Ϣ
            MyLabelItem lableItem = this.Tag as MyLabelItem;
            if (lableItem == null)
                lableItem = new MyLabelItem(this.Text.Substring(0, this.Text.Length - TextRightBlank.Length));
            //��ǰ����İ�ť���ڼ����е����
            int index = -1;
            for (int i = 0; i < this.ConMstrip.Items.Count; i++)
            {
                if (this.ConMstrip.Items[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1) return;
            MyLabelItem curItem = this.ChildItems[index];
            if (this.IsTextChange)
            {
                //��ChildItems���ҵ�ָ����ʵ��
                this.Tag = curItem;
                this.Text = curItem.Text + TextRightBlank;
                this.ChildItems[index] = lableItem;
                item.Text = lableItem.Text;
                this.SetLeaveStyle();
            }
            //�¼�����
            if (this.TitleChanged != null)
                this.TitleChanged(lableItem, curItem);
        }
        #endregion
        #endregion
        #region �ؼ�����
        public class MyLabelItem
        {
            private string _strText = string.Empty;
            private int _index = 0;
            private object _tag = null;
            private Image _marginIamge = null;
            public MyLabelItem(string strText)
            {
                this._strText = strText;
            }
            /// <summary>
            /// ��ʾ�ı�
            /// </summary>
            public string Text
            {
                get { return this._strText; }
                set { this._strText = value; }
            }
            /// <summary>
            /// ���к�
            /// </summary>
            public int Index
            {
                get { return this._index; }
                set { this._index = value; }
            }
            /// <summary>
            /// �洢����
            /// </summary>
            public object Tag
            {
                get { return this._tag; }
                set { this._tag = value; }
            }
            /// <summary>
            /// �Լ���ťͼ��
            /// </summary>
            public Image MarginImage
            {
                get { return this._marginIamge; }
                set { this._marginIamge = value; }
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
        #endregion
        #region ��д�¼�
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            //�����Ҫ������Ҫ��ʾ����ɫ
            if (this.ConMstrip.Visible) return;//����Ӽ���ť�Ѿ���ʾ�ˣ�����Ҫ�ı䱳��ɫ��������ɫ
            this.SetHoverStyle();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.SetLeaveStyle();
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (this.ConMstrip.Visible)
            {
                this.ConMstrip.Hide();
                this.SetHoverStyle();
            }
            else
            {
                this.ConMstrip.Show(this, new Point(0, this.Height));
                this.SetLeaveStyle();
            }
        }
        
        #endregion
        #region ������
        private void SetHoverStyle()
        {
            this.BackColor = this.HoverBackColor;
            this.ForeColor = this.HoverForeColor;
        }
        private void SetLeaveStyle()
        {
            this.BackColor = this._orignalBackColor;
            this.ForeColor = this._orignalForeColor;
            //if (this.ConMstrip.Visible)
            //    this.BorderStyle = BorderStyle.FixedSingle;
            //else
            //    this.BorderStyle = this._orignalBorderStyle;

        }
        #endregion
        #region ��ȡ�汾��Ϣ
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
    public delegate void MyLabelExChageTitleEventHandler(MyControl.MyLabelEx.MyLabelItem originalItem,MyControl.MyLabelEx.MyLabelItem newItem);
}
