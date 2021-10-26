using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common
{
    public partial class frmBaseList : frmBase
    {
        public frmBaseList()
        {
            InitializeComponent();
        }
        #region 设置搜索
        public virtual void BindSearchItem()
        {

        }
        #endregion
        #region 设置日期查询按钮
        private System.Windows.Forms.DateTimePicker _dtpStart = null;
        private System.Windows.Forms.DateTimePicker _dtpEnd = null;
        /// <summary>
        /// 日期查询的开始日期
        /// </summary>
        public DateTimePicker BarSearchDateTimeStart
        {
            get 
            {
                if (this._dtpStart == null)
                {
                    this._dtpStart = new DateTimePicker();
                    this._dtpStart.Name = this.Name + "_BarSearchDateTimeStart";
                    this.SetDateTimePickerStyle(this._dtpStart);
                }
                return this._dtpStart;
            }
        }
        /// <summary>
        /// 设置查询起始日期控件样式，子类中可以修改此样式生成
        /// </summary>
        public virtual void SetDateTimePickerStyle(DateTimePicker dtp)
        {
            dtp.ShowCheckBox = true;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "yyyy-MM-dd";
            dtp.Width = 99;
            dtp.Height = 21;
        }
        /// <summary>
        /// 日期查询的结束日期
        /// </summary>
        public DateTimePicker BarSearchDateTimeEnd
        {
            get
            {
                if (this._dtpEnd == null)
                {
                    this._dtpEnd = new DateTimePicker();
                    this._dtpEnd.Name = this.Name + "_BarSearchDateTimeEnd";
                    this.SetDateTimePickerStyle(this._dtpEnd);
                }
                return this._dtpEnd;
            }
        }
        #region 设置时间选择控件
        private System.Windows.Forms.DateTimePicker _dtpTimeStart = null;
        private System.Windows.Forms.DateTimePicker _dtpTimeEnd = null;
        public DateTimePicker BarSearchTimeStart
        {
            get
            {
                if (this._dtpTimeStart == null)
                {
                    this._dtpTimeStart = new DateTimePicker();
                    this._dtpTimeStart.Name = this.Name + "_BarSearchTimeStart";
                    this.SetTimePickerStyle(this._dtpTimeStart);
                }
                return this._dtpTimeStart;
            }
        }
        public virtual void SetTimePickerStyle(DateTimePicker dtp)
        {
            dtp.ShowCheckBox = true;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "HH:mm";
            dtp.Width = 73;
            dtp.Height = 21;
            dtp.ShowUpDown = true;
        }
        public DateTimePicker BarSearchTimeEnd
        {
            get
            {
                if (this._dtpTimeEnd == null)
                {
                    this._dtpTimeEnd = new DateTimePicker();
                    this._dtpTimeEnd.Name = this.Name + "_BarSearchTimeEnd";
                    this.SetTimePickerStyle(this._dtpTimeEnd);
                }
                return this._dtpTimeEnd;
            }
        }
        #endregion
        /// <summary>
        /// 在工具条ToolStrip中插入日期控件
        /// </summary>
        /// <param name="bar">窗体中的ToolStrip控件</param>
        /// <param name="itemName">控件Name，新控件将会插入此控件后面</param>
        /// <returns></returns>
        public bool InsertDateTimePicker(System.Windows.Forms.ToolStrip bar, string itemName)
        {
            return this.InsertDateTimePicker(bar, itemName, false);
        }
        /// <summary>
        /// 在工具条ToolStrip中插入日期控件
        /// </summary>
        /// <param name="bar">窗体中的ToolStrip控件</param>
        /// <param name="itemName">控件Name，新控件将会插入此控件后面</param>
        /// <param name="IsSeparate">是否在前面插入分隔符</param>
        /// <returns></returns>
        public bool InsertDateTimePicker(System.Windows.Forms.ToolStrip bar, string itemName, bool IsSeparate)
        {
            itemName = itemName.ToUpper();
            int index = -1;
            if (itemName.Length == 0)
                index = 0;
            else
            {
                for (int i = 0; i < bar.Items.Count; i++)
                {
                    if (bar.Items[i].Name.ToUpper() == itemName)
                    {
                        index = i;
                        break;
                    }
                }
            }
            if (index == -1)
            {
                Exception e = new Exception("未能在ToolStrip中找到Name为“" + itemName + "”的子项;");
                wErrorMessage.ShowErrorDialog(this, e);
                return false;
            }
            ToolStripControlHost dtp1 = new ToolStripControlHost(this.BarSearchDateTimeStart);
            ToolStripControlHost dtp2 = new ToolStripControlHost(this.BarSearchDateTimeEnd);
            ToolStripLabel tsl = new ToolStripLabel();
            tsl.Text = "至";
            tsl.Width = 17;
            if (IsSeparate)
            {
                //添加分割调
                index++;
                bar.Items.Insert(index, new ToolStripSeparator());
            }
            bar.Items.Insert(index + 1, dtp1);
            bar.Items.Insert(index + 2, tsl);
            bar.Items.Insert(index + 3, dtp2);
            return true;
        }
        /// <summary>
        /// 在工具条ToolStrip中插入日期控件
        /// </summary>
        /// <param name="bar">窗体中的ToolStrip控件</param>
        /// <param name="itemName">控件Name，新控件将会插入此控件的前面或者后面</param>
        /// <param name="isAfter">是否是插入传入控件的后面</param>
        /// <param name="IsSeparate">是否在前面插入分隔符</param>
        /// <returns></returns>
        public bool InsertDateTimePicker(System.Windows.Forms.ToolStrip bar, string itemName, bool isAfter, bool IsSeparate)
        {
            itemName = itemName.ToUpper();
            int index = -1;
            if (itemName.Length == 0)
                index = 0;
            else
            {
                for (int i = 0; i < bar.Items.Count; i++)
                {
                    if (bar.Items[i].Name.ToUpper() == itemName)
                    {
                        index = i;
                        break;
                    }
                }
            }
            if (index == -1)
            {
                Exception e = new Exception("未能在ToolStrip中找到Name为“" + itemName + "”的子项;");
                wErrorMessage.ShowErrorDialog(this, e);
                return false;
            }
            ToolStripControlHost dtp1 = new ToolStripControlHost(this.BarSearchDateTimeStart);
            ToolStripControlHost dtp2 = new ToolStripControlHost(this.BarSearchDateTimeEnd);
            ToolStripLabel tsl = new ToolStripLabel();
            tsl.Text = "至";
            tsl.Width = 17;
            if (IsSeparate)
            {
                //添加分割调
                index++;
                bar.Items.Insert(index, new ToolStripSeparator());
            }
            if (isAfter)
                index++;
            bar.Items.Insert(index, dtp1);
            bar.Items.Insert(index + 1, tsl);
            bar.Items.Insert(index + 2, dtp2);
            return true;
        }
        #region 插入日期+时间格式的控件
        public bool InsertLongDateTimePicker(System.Windows.Forms.ToolStrip bar, string itemName, bool IsSeparate)
        {
            itemName = itemName.ToUpper();
            int index = -1;
            if (itemName.Length == 0)
                index = 0;
            else
            {
                for (int i = 0; i < bar.Items.Count; i++)
                {
                    if (bar.Items[i].Name.ToUpper() == itemName)
                    {
                        index = i;
                        break;
                    }
                }
            }
            if (index == -1)
            {
                Exception e = new Exception("未能在ToolStrip中找到Name为“" + itemName + "”的子项;");
                wErrorMessage.ShowErrorDialog(this, e);
                return false;
            }
            ToolStripControlHost dtp1 = new ToolStripControlHost(this.BarSearchDateTimeStart);
            ToolStripControlHost dtp11 = new ToolStripControlHost(this.BarSearchTimeStart);
            ToolStripControlHost dtp2 = new ToolStripControlHost(this.BarSearchDateTimeEnd);
            ToolStripControlHost dtp21 = new ToolStripControlHost(this.BarSearchTimeEnd);
            ToolStripLabel tsl = new ToolStripLabel();
            tsl.Text = "至";
            tsl.Width = 17;
            if (IsSeparate)
            {
                //添加分割调
                index++;
                bar.Items.Insert(index, new ToolStripSeparator());
            }
            bar.Items.Insert(index + 1, dtp1);
            bar.Items.Insert(index + 2, dtp11);
            bar.Items.Insert(index + 3, tsl);
            bar.Items.Insert(index + 4, dtp2);
            bar.Items.Insert(index + 5, dtp21);
            return true;
        }
        public bool InsertLongDateTimePicker(System.Windows.Forms.ToolStrip bar, string itemName)
        {
            return this.InsertLongDateTimePicker(bar, itemName, false);
        }
        #endregion
        #endregion
        #region 设置搜索栏下拉标题
        private MyControl.MyLabelEx _mylabel = null;
        public MyControl.MyLabelEx BarSearchMyLabelEx
        {
            get 
            {
                if (this._mylabel == null)
                {
                    this._mylabel = new MyControl.MyLabelEx();
                    this._mylabel.BackColor = Color.Transparent;
                    this._mylabel.ForeColor = Color.Black;
                    this._mylabel.TextAlign = ContentAlignment.MiddleCenter;
                    this._mylabel.IsTextChange = true;//需要切换文本
                    this._mylabel.Name = this.Name + "_BarSearchMyLabelEx";
                }
                return this._mylabel;
            }
        }
        /// <summary>
        /// 向工具栏插入搜索标题
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="itemName">被插入的控件Name值</param>
        /// <param name="listSearchItem"></param>
        /// <param name="IsSeparate">是否添加分隔符</param>
        /// <returns>插入控件的Name值</returns>
        public virtual string InsertMyLableEx(System.Windows.Forms.ToolStrip bar, string itemName, List<MyEntity.SearchLabelItem> listSearchItem, bool IsSeparate)
        {
            return this.InsertMyLableEx(bar, itemName, true, listSearchItem, IsSeparate);
        }
        /// <summary>
        /// 向工具栏插入搜索标题
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="itemName">被插入的控件Name值</param>
        /// <param name="IsBefore">是否是传入控件的前面，true为前面，否则为后面</param>
        /// <param name="listSearchItem"></param>
        /// <param name="IsSeparate">是否添加分隔符</param>
        /// <returns>插入控件的Name值</returns>
        public virtual string InsertMyLableEx(System.Windows.Forms.ToolStrip bar, string itemName, bool IsBefore, List<MyEntity.SearchLabelItem> listSearchItem, bool IsSeparate)
        {
            int index = -1;
            itemName = itemName.ToLower();
            for (int i = 0; i < bar.Items.Count; i++)
            {
                if (itemName == bar.Items[i].Name.ToLower())
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                Exception e = new Exception("未能在ToolStrip中找到Name为“" + itemName + "”的子项;");
                wErrorMessage.ShowErrorDialog(this, e);
                return string.Empty;
            }
            if (!IsBefore)//如果是传入控件的后面，则需要+1
                index++;
            return this.InsertMyLableEx(bar, index, listSearchItem, IsSeparate);
        }
        /// <summary>
        /// 向工具栏插入搜索标题
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="itemName">被插入的控件Name值</param>
        /// <param name="listSearchItem"></param>
        /// <returns>插入控件的Name值</returns>
        public virtual string InsertMyLableEx(System.Windows.Forms.ToolStrip bar, string itemName, List<MyEntity.SearchLabelItem> listSearchItem)
        {
            return this.InsertMyLableEx(bar, itemName, listSearchItem, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="index">要插入的位置</param>
        /// <param name="listSearchItem"></param>
        /// <param name="IsSeparate"></param>
        /// <returns>插入控件的Name值</returns>
        public virtual string InsertMyLableEx(System.Windows.Forms.ToolStrip bar, int index, List<MyEntity.SearchLabelItem> listSearchItem, bool IsSeparate)
        {
            this.BindMyLableEx(this.BarSearchMyLabelEx, listSearchItem);
            if (IsSeparate)
            {
                bar.Items.Insert(index, new ToolStripSeparator());
                index++;
            }
            ToolStripControlHost tsLabel = new ToolStripControlHost(this.BarSearchMyLabelEx);
            tsLabel.Name = this.Name + "_BarSearchMyLabelEx_" + index.ToString();
            bar.Items.Insert(index, tsLabel);
            return tsLabel.Name;
        }
        public virtual void BindMyLableEx(MyControl.MyLabelEx labex, List<MyEntity.SearchLabelItem> listSearchItem)
        {
            if (listSearchItem.Count == 0) return;
            labex.Text = listSearchItem.Count > 1 ? listSearchItem[0].TitleName + "  " : listSearchItem[0].TitleName;
            MyControl.MyLabelEx.MyLabelItem firstlab = new MyControl.MyLabelEx.MyLabelItem(listSearchItem[0].TitleName);
            firstlab.Tag = listSearchItem[0];
            labex.Tag = firstlab;
            for (int i = 1; i < listSearchItem.Count; i++)
            {
                MyControl.MyLabelEx.MyLabelItem mylab = new MyControl.MyLabelEx.MyLabelItem(listSearchItem[i].TitleName);
                mylab.Tag = listSearchItem[i];
                labex.AddItem(mylab);
            }
            labex.EnableDorpdown = listSearchItem.Count > 1;//如果只有一个搜索标题，那就不用下拉了
        }
        /// <summary>
        /// 向工具栏插入搜索标题
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="index">要插入的位置</param>
        /// <param name="listSearchItem"></param>
        /// <returns>插入控件的Name值</returns>
        public virtual string InsertMyLableEx(System.Windows.Forms.ToolStrip bar, int index, List<MyEntity.SearchLabelItem> listSearchItem)
        {
            return this.InsertMyLableEx(bar, index, listSearchItem, false);
        }
        public MyEntity.SearchLabelItem GetBarSearchMyLabelExItem()
        {
            return this.GetLabelExCurrentItem(this.BarSearchMyLabelEx);
            //MyControl.MyLabelEx.MyLabelItem curItem = this.BarSearchMyLabelEx.GetCurrentItem();
            //if (curItem == null) return null;
            //Common.MyEntity.SearchLabelItem item = curItem.Tag as Common.MyEntity.SearchLabelItem;
            //return item;
        }
        public MyEntity.SearchLabelItem GetLabelExCurrentItem(MyControl.MyLabelEx labEx)
        {
            MyControl.MyLabelEx.MyLabelItem curItem = labEx.GetCurrentItem();
            if (curItem == null) return null;
            Common.MyEntity.SearchLabelItem item = curItem.Tag as Common.MyEntity.SearchLabelItem;
            return item;
        }
        #endregion   
        #region 绑定搜索下拉标题（Microsoft版）
        public virtual void ToolBarDropdownTitles_Bind(System.Windows.Forms.ToolStripDropDownButton control, List<MyEntity.SearchLabelItem> listSearchItem)
        {
            control.DropDownItems.Clear();
            if (listSearchItem.Count == 0) return;
            MyEntity.SearchLabelItem item = listSearchItem[0];
            control.Text = item.TitleName;
            control.Tag = item;
            for (int i = 1; i < listSearchItem.Count; i++)
            {
                item = listSearchItem[i];
                System.Windows.Forms.ToolStripMenuItem newts = new ToolStripMenuItem();
                newts.Text = item.TitleName;
                newts.Tag = item;
                //newts.OwnerItem = control;//存储控件
                control.DropDownItems.Add(newts);
                //只定义子件的单击事件
                newts.Click += new EventHandler(ToolBarDropdownTitles_Click);
            }
        }
        public virtual void ToolBarDropdownTitles_SetItemByValue(System.Windows.Forms.ToolStripDropDownButton control,int iValue)
        {
            MyEntity.SearchLabelItem item;
            foreach (System.Windows.Forms.ToolStripMenuItem bt in control.DropDownItems)
            {
                item = bt.Tag as MyEntity.SearchLabelItem;
                if (item != null && item.Value==iValue)
                {
                    ToolBarDropdownTitles_Click(bt, null);
                    break;
                }
            }
        }
        protected virtual void ToolBarDropdownTitles_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem tsm = sender as System.Windows.Forms.ToolStripMenuItem;
            if (tsm == null) return;
            string strText;
            object objTag;
            strText = tsm.Text;
            objTag = tsm.Tag;
            System.Windows.Forms.ToolStripDropDownButton tsb = tsm.OwnerItem as System.Windows.Forms.ToolStripDropDownButton;
            if (tsb == null) return;
            tsm.Text = tsb.Text;
            tsm.Tag = tsb.Tag;
            tsb.Text = strText;
            tsb.Tag = objTag;
            this.ToolBarDropdownTitlesClick_Pro(tsm.Tag, tsb.Tag);
        }
        /// <summary>
        /// 搜索框下拉标题点击点击事件
        /// </summary>
        /// <param name="objOrginal">原标题</param>
        /// <param name="objNew">新标题</param>
        public virtual void ToolBarDropdownTitlesClick_Pro(object objOrginal, object objNew)
        {

        }
        public virtual MyEntity.SearchLabelItem ToolBarDropdownTitles_GetSearchLabelItem(System.Windows.Forms.ToolStripDropDownButton control)
        {
            if (control == null || control.Tag == null) return null;
            MyEntity.SearchLabelItem item = control.Tag as MyEntity.SearchLabelItem;
            return item;
        }
        #endregion
        #region 设置工具条上更多操作按钮
        private MyControl.MyLabelEx _barSearchMyButtons = null;
        public MyControl.MyLabelEx BarSearchMyButtons
        {
            get
            {
                if (this._barSearchMyButtons == null)
                {
                    this._barSearchMyButtons = new MyControl.MyLabelEx();
                    this._barSearchMyButtons.BackColor = Color.Transparent;
                    this._barSearchMyButtons.ForeColor = Color.Black;
                    this._barSearchMyButtons.TextAlign = ContentAlignment.MiddleCenter;
                    this._barSearchMyButtons.IsTextChange = false;//不需要切换文本
                    this._barSearchMyButtons.Name = this.Name + "_BarSearchMyButtons";
                }
                return this._barSearchMyButtons;
            }
        }
        /// <summary>
        ///  向工具条中插入“更多操作"按钮
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="itemName">bar工具条已有子控件Name值，当前控件需要插入到该控件后面</param>
        /// <param name="isAfter">是否是传入控件的后面</param>
        /// <param name="listSearchItem"></param>
        /// <param name="IsShowMarginImage">子按钮是否显示图标</param>
        /// <param name="IsSeparate">工具条上显示分隔符</param>
        /// <returns>插入控件的Name值</returns>
        public virtual string InsertMyButtons(System.Windows.Forms.ToolStrip bar, string itemName, bool isAfter, List<MyEntity.SearchButtonItem> listSearchItem, bool IsShowMarginImage, bool IsSeparate)
        {
            int index = -1;
            itemName = itemName.ToLower();
            for (int i = 0; i < bar.Items.Count; i++)
            {
                if (itemName == bar.Items[i].Name.ToLower())
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                Exception e = new Exception("未能在ToolStrip中找到Name为“" + itemName + "”的子项;");
                wErrorMessage.ShowErrorDialog(this, e);
                return string.Empty;
            }
            if (isAfter)
                index++;
            return this.InsertMyButtons(bar, index, listSearchItem, IsShowMarginImage, IsSeparate);
        }
        /// <summary>
        /// 向工具条中插入“更多操作"按钮
        /// </summary>
        /// <param name="bar">窗体工具条</param>
        /// <param name="itemName">控件名称，新控件插入在此控件之后</param>
        /// <param name="listSearchItem"></param>
        /// <param name="IsShowMarginImage">是否显示图标空间</param>
        /// <param name="IsSeparate">是否在前面插入分隔符</param>
        /// <returns>插入控件的Name值</returns>
        public virtual string InsertMyButtons(System.Windows.Forms.ToolStrip bar, string itemName, List<MyEntity.SearchButtonItem> listSearchItem, bool IsShowMarginImage, bool IsSeparate)
        {
            return this.InsertMyButtons(bar, itemName, true, listSearchItem, IsShowMarginImage, IsSeparate);
        }
        /// <summary>
        /// 向工具条中插入“更多操作"按钮
        /// </summary>
        /// <param name="bar">窗体工具条</param>
        /// <param name="itemName">控件名称，新控件插入在此控件之后</param>
        /// <param name="listSearchItem"></param>
        /// <param name="IsShowMarginImage">是否显示图标空间</param>
        /// <returns>插入控件的Name值</returns>
        public virtual string InsertMyButtons(System.Windows.Forms.ToolStrip bar, string itemName, List<MyEntity.SearchButtonItem> listSearchItem, bool IsShowMarginImage)
        {
            return this.InsertMyButtons(bar, itemName, listSearchItem, IsShowMarginImage,false);
        }
        /// <summary>
        /// 向工具条中插入“更多操作"按钮
        /// </summary>
        /// <param name="bar">窗体工具条</param>
        /// <param name="itemName">控件名称，新控件插入在此控件之后</param>
        /// <param name="listSearchItem"></param>
        /// <returns>插入控件的Name值</returns>
        public virtual string InsertMyButtons(System.Windows.Forms.ToolStrip bar, string itemName, List<MyEntity.SearchButtonItem> listSearchItem)
        {
            return this.InsertMyButtons(bar, itemName, listSearchItem,true, false);
        }
        /// <summary>
        /// 向工具条中插入“更多操作"按钮
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="index">要插入的位置</param>
        /// <param name="listSearchItem">按钮信息集合</param>
        /// <param name="IsShowMarginImage">按钮是否显示图标，默认显示</param>
        /// <param name="IsSeparate">是否在工具条上添加分隔符号，默认不添加</param>
        public virtual string InsertMyButtons(System.Windows.Forms.ToolStrip bar, int index, List<MyEntity.SearchButtonItem> listSearchItem,bool IsShowMarginImage, bool IsSeparate)
        {
            this.BindMyButtons(this.BarSearchMyButtons, listSearchItem, IsShowMarginImage);
            if (IsSeparate)
            {
                bar.Items.Insert(index, new ToolStripSeparator());
                index++;
            }
            ToolStripControlHost tsbutton = new ToolStripControlHost(this.BarSearchMyButtons);
            bar.Items.Insert(index, tsbutton);
            return tsbutton.Name;
        }
        public virtual void BindMyButtons(MyControl.MyLabelEx labex, List<MyEntity.SearchButtonItem> listSearchItem, bool IsShowMarginImage)
        {
            if (listSearchItem.Count == 0) return;
            //将第一个SearchItem设置为mylabelex初始化显示
            labex.Text = "更多操作";
            //this.BarSearchMyButtons.Tag = null;
            labex.ShowMarginImage = IsShowMarginImage;//是否控件显示图标
            for (int i = 0; i < listSearchItem.Count; i++)
            {
                MyControl.MyLabelEx.MyLabelItem mylab = new MyControl.MyLabelEx.MyLabelItem(listSearchItem[i].TitleName);
                mylab.MarginImage = listSearchItem[i].MarginImage;
                mylab.Tag = listSearchItem[i];
                mylab.CheckOnClick = listSearchItem[i].CheckOnClick;
                labex.AddItem(mylab);
            }
            labex.EnableDorpdown = listSearchItem.Count > 1;
        }
        /// <summary>
        /// 向工具条中插入“更多操作"按钮
        /// </summary>
        /// <param name="bar">窗体工具条</param>
        /// <param name="index">新控件在工具条中的位置</param>
        /// <param name="listSearchItem"></param>
        /// <param name="IsShowMarginImage">是否显示图标空间</param>
        /// <returns>插入控件的Name值</returns>
        public virtual string InsertMyButtons(System.Windows.Forms.ToolStrip bar, int index, List<MyEntity.SearchButtonItem> listSearchItem, bool IsShowMarginImage)
        {
            return this.InsertMyButtons(bar, index, listSearchItem, IsShowMarginImage, false);
        }
        /// <summary>
        /// 向工具条中插入“更多操作"按钮
        /// </summary>
        /// <param name="bar">窗体工具条</param>
        /// <param name="index">新控件在工具条中的位置</param>
        /// <param name="listSearchItem"></param>
        /// <returns>插入控件的Name值</returns>
        public virtual string InsertMyButtons(System.Windows.Forms.ToolStrip bar, int index, List<MyEntity.SearchButtonItem> listSearchItem)
        {
            return this.InsertMyButtons(bar, index, listSearchItem, true, false);
        }
        #endregion   
        #region 设置回车搜索功能
        public void SetBarSearchEnterKey(System.Windows.Forms.ToolStripComboBox combox)
        {
            if (combox != null)
                combox.KeyDown += new KeyEventHandler(combox_KeyDown);
        }
        public void SetBarSearchEnterKey(System.Windows.Forms.ToolStripTextBox textbox)
        {
            if (textbox != null)
                textbox.KeyDown += new KeyEventHandler(combox_KeyDown);
        }
        /// <summary>
        /// 设置列表工具栏中combox的回车搜索事件
        /// </summary>
        /// <param name="combox"></param>
        public void SetBarSearchEnterKey(Control con)
        {
            if (con != null)
                con.KeyDown+= new KeyEventHandler(combox_KeyDown);
        }
        protected void combox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                this.DoBarSearch();
        }
        /// <summary>
        /// 在子类中重写该搜索函数
        /// </summary>
        public virtual void DoBarSearch()
        {
            
        }
        #endregion
        #region 公共属性
        /// <summary>
        /// 列表一次性打开条数最大值
        /// </summary>
        public const int _MaxOpenRows = 15;
        #endregion

    }
}