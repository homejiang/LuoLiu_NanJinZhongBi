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
        #region ��������
        public virtual void BindSearchItem()
        {

        }
        #endregion
        #region �������ڲ�ѯ��ť
        private System.Windows.Forms.DateTimePicker _dtpStart = null;
        private System.Windows.Forms.DateTimePicker _dtpEnd = null;
        /// <summary>
        /// ���ڲ�ѯ�Ŀ�ʼ����
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
        /// ���ò�ѯ��ʼ���ڿؼ���ʽ�������п����޸Ĵ���ʽ����
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
        /// ���ڲ�ѯ�Ľ�������
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
        #region ����ʱ��ѡ��ؼ�
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
        /// �ڹ�����ToolStrip�в������ڿؼ�
        /// </summary>
        /// <param name="bar">�����е�ToolStrip�ؼ�</param>
        /// <param name="itemName">�ؼ�Name���¿ؼ��������˿ؼ�����</param>
        /// <returns></returns>
        public bool InsertDateTimePicker(System.Windows.Forms.ToolStrip bar, string itemName)
        {
            return this.InsertDateTimePicker(bar, itemName, false);
        }
        /// <summary>
        /// �ڹ�����ToolStrip�в������ڿؼ�
        /// </summary>
        /// <param name="bar">�����е�ToolStrip�ؼ�</param>
        /// <param name="itemName">�ؼ�Name���¿ؼ��������˿ؼ�����</param>
        /// <param name="IsSeparate">�Ƿ���ǰ�����ָ���</param>
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
                Exception e = new Exception("δ����ToolStrip���ҵ�NameΪ��" + itemName + "��������;");
                wErrorMessage.ShowErrorDialog(this, e);
                return false;
            }
            ToolStripControlHost dtp1 = new ToolStripControlHost(this.BarSearchDateTimeStart);
            ToolStripControlHost dtp2 = new ToolStripControlHost(this.BarSearchDateTimeEnd);
            ToolStripLabel tsl = new ToolStripLabel();
            tsl.Text = "��";
            tsl.Width = 17;
            if (IsSeparate)
            {
                //��ӷָ��
                index++;
                bar.Items.Insert(index, new ToolStripSeparator());
            }
            bar.Items.Insert(index + 1, dtp1);
            bar.Items.Insert(index + 2, tsl);
            bar.Items.Insert(index + 3, dtp2);
            return true;
        }
        /// <summary>
        /// �ڹ�����ToolStrip�в������ڿؼ�
        /// </summary>
        /// <param name="bar">�����е�ToolStrip�ؼ�</param>
        /// <param name="itemName">�ؼ�Name���¿ؼ��������˿ؼ���ǰ����ߺ���</param>
        /// <param name="isAfter">�Ƿ��ǲ��봫��ؼ��ĺ���</param>
        /// <param name="IsSeparate">�Ƿ���ǰ�����ָ���</param>
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
                Exception e = new Exception("δ����ToolStrip���ҵ�NameΪ��" + itemName + "��������;");
                wErrorMessage.ShowErrorDialog(this, e);
                return false;
            }
            ToolStripControlHost dtp1 = new ToolStripControlHost(this.BarSearchDateTimeStart);
            ToolStripControlHost dtp2 = new ToolStripControlHost(this.BarSearchDateTimeEnd);
            ToolStripLabel tsl = new ToolStripLabel();
            tsl.Text = "��";
            tsl.Width = 17;
            if (IsSeparate)
            {
                //��ӷָ��
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
        #region ��������+ʱ���ʽ�Ŀؼ�
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
                Exception e = new Exception("δ����ToolStrip���ҵ�NameΪ��" + itemName + "��������;");
                wErrorMessage.ShowErrorDialog(this, e);
                return false;
            }
            ToolStripControlHost dtp1 = new ToolStripControlHost(this.BarSearchDateTimeStart);
            ToolStripControlHost dtp11 = new ToolStripControlHost(this.BarSearchTimeStart); dtp11.Margin = new Padding(3, 0, 0, 0);
             ToolStripControlHost dtp2 = new ToolStripControlHost(this.BarSearchDateTimeEnd);
            ToolStripControlHost dtp21 = new ToolStripControlHost(this.BarSearchTimeEnd); dtp21.Margin = new Padding(3, 0, 0, 0);
            ToolStripLabel tsl = new ToolStripLabel();
            tsl.Text = "��";
            tsl.Width = 17;
            if (IsSeparate)
            {
                //��ӷָ��
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
        #region �������������⣨Microsoft�棩
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
                //newts.OwnerItem = control;//�洢�ؼ�
                control.DropDownItems.Add(newts);
                //ֻ�����Ӽ��ĵ����¼�
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
        /// ��������������������¼�
        /// </summary>
        /// <param name="objOrginal">ԭ����</param>
        /// <param name="objNew">�±���</param>
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
        #region ���ûس���������
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
        /// �����б�������combox�Ļس������¼�
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
        /// ����������д����������
        /// </summary>
        public virtual void DoBarSearch()
        {
            
        }
        #endregion
        #region ��������
        /// <summary>
        /// �б�һ���Դ��������ֵ
        /// </summary>
        public const int _MaxOpenRows = 10;
        #endregion

    }
}