using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace MyControl
{
    public class DropdownMultiSelect : System.Windows.Forms.Panel
    {
        #region 控件私有属性
        private System.Windows.Forms.ContextMenuStrip _conMstrip = null;
        private System.Windows.Forms.ContextMenuStrip ConMstrip
        {
            get
            {
                if (this._conMstrip == null)
                {
                    this._conMstrip = new ContextMenuStrip();
                    this._conMstrip.Name = this.Name + "_ContextMenuStrip";
                    this._conMstrip.ShowCheckMargin = true;//需要显示是否选中
                    this._conMstrip.ShowImageMargin = false;
                }
                return this._conMstrip;
            }
        }
        private TextBox _textBox = null;
        private TextBox PanelTextBox
        {
            get
            {
                if (this._textBox == null)
                {
                    this._textBox = new TextBox();
                    this._textBox.Top = 4;
                    this._textBox.Left = 3;
                    this._textBox.ReadOnly = true;
                    this._textBox.BackColor = this.BackColor;
                    this._textBox.Multiline = true;//允许多行是为了能调整高度
                    this._textBox.BorderStyle = BorderStyle.None;
                    this._textBox.Name = this.Name + "_PanelTextBox";
                    this.Controls.Add(this._textBox);
                }
                return this._textBox;
            }
        }
        private PictureBox _picBox = null;
        private PictureBox PanelPictureBox
        {
            get
            {
                if (this._picBox == null)
                {
                    this._picBox = new PictureBox();
                    this._picBox.Name = this.Name + "_PanelPictureBox";
                    this._picBox.Width = 14;
                    this._picBox.Image = global::DropdownMultiSelect.Properties.Resources.dropdown;
                    this._picBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    this.Controls.Add(this._picBox);
                    this._picBox.BackColor = Color.White;
                    this._picBox.Cursor = System.Windows.Forms.Cursors.Hand;
                    this._picBox.Click+=new EventHandler(_picBox_Click);
                }
                return this._picBox;
            }
        }
        #endregion
        #region 公共属性
        private string _strBorderColor = "#7F9DB9";
        [CategoryAttribute("DropdownMultiSelect"), DescriptionAttribute("BorderColor"), DefaultValue("#7F9DB9")]
        public string BorderColor
        {
            get { return this._strBorderColor; }
            set { this._strBorderColor = value; }
        }
        public new System.Drawing.Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                base.Size = value;
                //this.PanelTextBox.Width = value.Width - 4 - this.PanelPictureBox.Width;
                //this.PanelTextBox.Height = value.Height - 5;
                //this.PanelPictureBox.Height = value.Height - 2;
                //this.PanelPictureBox.Top = 1;
                //this.PanelPictureBox.Left = this.PanelTextBox.Width + 2;
            }
        }
        private bool _blMultiSelect = true;
        [CategoryAttribute("DropdownMultiSelect"), DescriptionAttribute("MultiSelect"), DefaultValue(true)]
        public bool MultiSelect
        {
            get { return this._blMultiSelect;}
            set { this._blMultiSelect = value; }
        }
        #endregion
        #region 公共函数
        public void BindData(List<DropdownMultiItem> listItem)
        {
            while (this.ConMstrip.Items.Count > listItem.Count)
            {
                this.RemoveStripMenuItem(this.ConMstrip.Items.Count - 1);
            }
            ToolStripMenuItem menuItem;
            for (int i = 1; i <= listItem.Count; i++)
            {
                if (this.ConMstrip.Items.Count < i)
                    this.AddStripMenuItem(listItem[i - 1]);
                else
                {
                    menuItem = (ToolStripMenuItem)this.ConMstrip.Items[i - 1];
                    menuItem.Text = listItem[i - 1].Text;
                    menuItem.Tag = listItem[i - 1].Value;
                    menuItem.Checked = listItem[i - 1].Selected;
                }
            }
            this.PanelPictureBox.Visible = listItem.Count > 0;
            this.BindText();
        }
        public List<DropdownMultiItem> GetSelected()
        {
            List<DropdownMultiItem> listItem = new List<DropdownMultiItem>();
            foreach (ToolStripMenuItem Item in this.ConMstrip.Items)
            {
                if (Item.Checked)
                {
                    listItem.Add(new DropdownMultiItem(Item.Text, Item.Tag, Item.Checked));
                }
            }
            return listItem;
        }
        #endregion
        #region 处理函数
        #region 操作ContextMenuStrip控件
        private void AddStripMenuItem(DropdownMultiItem item)
        {
            InsertStripMenuItem(this.ConMstrip.Items.Count, item);
        }
        private void InsertStripMenuItem(int index, DropdownMultiItem item)
        {
            System.Windows.Forms.ToolStripMenuItem tsItem = new ToolStripMenuItem(item.Text);
            tsItem.Click += new EventHandler(tsItem_Click);
            tsItem.Text = item.Text;
            tsItem.Tag = item.Value;
            tsItem.Checked = item.Selected;//是否选中
            this.ConMstrip.Items.Insert(index, tsItem);
            tsItem.CheckOnClick = true;//设置是否为复选按钮
        }
        private void RemoveStripMenuItem(int index)
        {
            //将制定的子label从子集中移除
            if (this.ConMstrip.Items.Count <= index)
                return;
            System.Windows.Forms.ToolStripMenuItem tsItem = (ToolStripMenuItem)this.ConMstrip.Items[index];
            tsItem.Dispose();
            tsItem = null;
            this.ConMstrip.Items.Remove(tsItem);
        }
        #endregion
        private void BindText()
        {
            string strText = string.Empty;
            foreach (ToolStripMenuItem Item in this.ConMstrip.Items)
            {
                if (Item.Checked)
                    strText += Item.Text + "、";
            }
            while (strText.EndsWith("、"))
                strText = strText.Substring(0, strText.Length - 1);
            if (this.PanelTextBox.Text != strText)
                this.PanelTextBox.Text = strText;
        }
        private void BindSize()
        {
            this.PanelTextBox.Width = this.Size.Width - 4 - this.PanelPictureBox.Width;
            this.PanelTextBox.Height = this.Size.Height - 5;
            this.PanelPictureBox.Height = this.Size.Height - 2;
            this.PanelPictureBox.Top = 1;
            this.PanelPictureBox.Left = this.PanelTextBox.Width + 2;
        }
        #endregion
        #region 重写事件及函数
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            BindSize();
            System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, System.Drawing.ColorTranslator.FromHtml(this.BorderColor), System.Windows.Forms.ButtonBorderStyle.Solid);
            

        }
        protected void _picBox_Click(object sender, EventArgs e)
        {
            if (this.ConMstrip.Visible)
                this.ConMstrip.Visible = false;
            else
                this.ConMstrip.Show(this, new Point(0, this.Height));
        }
        protected void tsItem_Click(object sender, EventArgs e)
        {
            if (!this.MultiSelect)
            {
                foreach (ToolStripMenuItem Item in this.ConMstrip.Items)
                {
                    if (Item.Checked && !Item.Equals(sender))
                        Item.Checked = false;
                }
            }
            this.BindText();
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
    public class DropdownMultiItem
    {
        string _strText = string.Empty;
        string _strText1 = string.Empty;
        object _objValue = null;
        public DropdownMultiItem()
        {
        }
        public DropdownMultiItem(string strText, object objValue)
        {
            this._strText = strText;
            this._objValue = objValue;
        }
        public DropdownMultiItem(string strText, object objValue,bool blSelected)
        {
            this._strText = strText;
            this._objValue = objValue;
            this._blSelected = blSelected;
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
        /// 值
        /// </summary>
        public object Value
        {
            get { return this._objValue; }
            set { this._objValue = value; }
        }
        bool _blSelected = false;
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Selected
        {
            get { return this._blSelected; }
            set { this._blSelected = value; }
        }
    }
}
