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
        #region 公共事件
        public event MyLabelExChageTitleEventHandler TitleChanged = null;
        #endregion
        #region 公共函数
        /// <summary>
        ///  设置初始化时显示的控件
        /// </summary>
        /// <param name="item"></param>
        public void SetText(MyLabelItem item)
        {
            this.Text = item.Text;
            this.Tag = item;
        }
        /// <summary>
        /// 设置初始化时显示的控件
        /// </summary>
        /// <param name="strText"></param>
        public void SetText(string strText)
        {
            MyLabelItem item = new MyLabelItem(strText);
            this.SetText(item);
        }
        /// <summary>
        ///  返回当前选中的item
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
            //同步添加ContextMenuStrip
            this.AddStripMenuItem(this.ConMstrip.Items.Count, item);
        }
        public void InsertItem(int index, MyLabelItem item)
        {
            if (this._childItems == null)
                this._childItems = new List<MyLabelItem>();
            this._childItems.Insert(index, item);
            //同步插入ContextMenuStrip
            this.AddStripMenuItem(index, item);
        }
        public void RemoveAt(int index)
        {
            if (this._childItems == null)
                return;
            if (this._childItems.Count ==0)
                return;
            this._childItems.RemoveAt(index);
            //同步移除ContextMenuStrip
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
            //同步移除ContextMenuStrip
            this.RemoveStripMenuItem(index);

        }
        /// <summary>
        /// 获取传入的item对应的子模块是否被选中
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
        /// 设置当前选中标题
        /// </summary>
        /// <param name="labelItem">需要选中标题的MyLabelItem实例</param>
        public void SetCurrentItemByValue(MyControl.MyLabelEx.MyLabelItem labelItem)
        {
            if (this.Tag != null && this.Tag.Equals(labelItem))
                return;//此时已经是选中状态
            for (int i = 0; i < this.ChildItems.Count; i++)
            {
                if (this.ChildItems[i].Equals(labelItem))
                {
                    this.tsItem_Click(this.ConMstrip.Items[i], null);
                }
            }
        }
        #endregion
        #region 私有属性
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
        #region 公共属性
        private List<MyLabelItem> _childItems = null;
        public List<MyLabelItem> ChildItems
        {
            get { return this._childItems; }
        }
        private System.Drawing.Color _hoverBackColor = Color.NavajoWhite;//默认用这种颜色
        /// <summary>
        /// 鼠标移上去后的背景色
        /// </summary>
        public System.Drawing.Color HoverBackColor
        {
            get { return this._hoverBackColor; }
            set { this._hoverBackColor = value; }
        }
        private System.Drawing.Color _hoverForeColor = Color.Black;//默认用这种颜色
        /// <summary>
        /// 鼠标移上去后的字体颜色
        /// </summary>
        public System.Drawing.Color HoverForeColor
        {
            get { return this._hoverForeColor; }
            set { this._hoverForeColor = value; }
        }
        /// <summary>
        /// 设置是否能下拉，如果能下拉需要显示下拉三角形标示
        /// </summary>
        public bool EnableDorpdown
        {
            set
            {
                if (value)
                {
                    //设置样式用于显示下拉图片
                    this.Image = global::MyLabelEx.Properties.Resources.dropdown;
                    this.AutoSize = false;
                    this.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                    //添加事件，模仿foxmail中移上去之后显示背景色
                    //记录原始的背景色和字体颜色
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
        /// 子按钮是否显示图标
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
        /// 是否按钮点击后文本切换
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
        #region 操作ContextMenuStrip控件
        private void AddStripMenuItem(int index,MyLabelItem item)
        {
            System.Windows.Forms.ToolStripMenuItem tsItem = new ToolStripMenuItem(item.Text);
            tsItem.Click+=new EventHandler(tsItem_Click);
            this.ConMstrip.Items.Insert(index, tsItem);
            if (this.ConMstrip.ShowImageMargin && item.MarginImage != null)
            {
                tsItem.Image = item.MarginImage;
            }
            tsItem.CheckOnClick = item.CheckOnClick;//设置是否为复选按钮
        }
        private void RemoveStripMenuItem(int index)
        {
            //将制定的子label从子集中移除
            if (this.ConMstrip.Items.Count <= index)
                return;
            this.ConMstrip.Items.RemoveAt(index);
        }
        #region 切换文本事件
        protected void tsItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) return;
            //label交换信息
            MyLabelItem lableItem = this.Tag as MyLabelItem;
            if (lableItem == null)
                lableItem = new MyLabelItem(this.Text.Substring(0, this.Text.Length - TextRightBlank.Length));
            //当前激活的按钮所在集合中的序号
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
                //从ChildItems中找到指定的实例
                this.Tag = curItem;
                this.Text = curItem.Text + TextRightBlank;
                this.ChildItems[index] = lableItem;
                item.Text = lableItem.Text;
                this.SetLeaveStyle();
            }
            //事件触发
            if (this.TitleChanged != null)
                this.TitleChanged(lableItem, curItem);
        }
        #endregion
        #endregion
        #region 控件子类
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
            /// 显示文本
            /// </summary>
            public string Text
            {
                get { return this._strText; }
                set { this._strText = value; }
            }
            /// <summary>
            /// 序列号
            /// </summary>
            public int Index
            {
                get { return this._index; }
                set { this._index = value; }
            }
            /// <summary>
            /// 存储对象
            /// </summary>
            public object Tag
            {
                get { return this._tag; }
                set { this._tag = value; }
            }
            /// <summary>
            /// 自己按钮图标
            /// </summary>
            public Image MarginImage
            {
                get { return this._marginIamge; }
                set { this._marginIamge = value; }
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
        #endregion
        #region 重写事件
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            //如果需要下拉则要显示背景色
            if (this.ConMstrip.Visible) return;//如果子件按钮已经显示了，则不需要改变背景色和字体颜色
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
        #region 处理函数
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
    public delegate void MyLabelExChageTitleEventHandler(MyControl.MyLabelEx.MyLabelItem originalItem,MyControl.MyLabelEx.MyLabelItem newItem);
}
