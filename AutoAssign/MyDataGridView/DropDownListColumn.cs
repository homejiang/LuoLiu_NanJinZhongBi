using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MyControl
{
    public class DropDownListColumn : DataGridViewColumn
    {
        public DropDownListColumn()
            : base(new DropDownListCell())
        {
        }
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(DropDownListCell)))
                {
                    throw new InvalidCastException("Must be a DropDownListCell");
                }
                base.CellTemplate = value;
            }
        }
        public string DisplayMember
        {
            get { return DataPropertyName; }
            set { DataPropertyName = value; }
        }
        private string _valueMember = string.Empty;
        public string ValueMember
        {
            get { return this._valueMember; }
            set { this._valueMember = value; }
        }
        private List<MyDataGridViewDropDownListItem> _DropdwonItems = null;
        [System.ComponentModel.Bindable(false), System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public List<MyDataGridViewDropDownListItem> DropDownItems
        {
            get
            {
                if (_DropdwonItems == null)
                    this._DropdwonItems = new List<MyDataGridViewDropDownListItem>();
                return this._DropdwonItems;
            }
            set
            {
                this._DropdwonItems = value;
            }
        }
        private int _iActiveRowSign = -1;
        /// <summary>
        /// ���úͻ�ȡѡ�л򼴽�ѡ�е��кţ����ֵ��Ҫ���ⲿ�������û��ֶ����á�
        /// Ŀǰ�û���ͬ�м��ز�ͬ����ѡ��,������е��������һ���������ø�ֵ����
        /// </summary>
        public int ActiveRowSign
        {
            get { return this._iActiveRowSign; }
            set { this._iActiveRowSign = value; }
        }
        /// <summary>
        /// �洢���еı༭�ؼ�,�������޷������ã���������DropDownListCell��InitializeEditingControl�����и�ֵ��ʵ��������Ϊ��
        /// ���������DatagridView�ײ��й�ϵ
        /// </summary>
        //public DropDownListEditingControl DropDownListControl
        //{
        //    get { return this._dropDownListControl; }
        //    set { this._dropDownListControl = value; }
        //}
        /// <summary>
        /// ��д��¡�����������޷��洢
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            DropDownListColumn newcol = base.Clone() as DropDownListColumn;
            newcol.DropDownItems = this.DropDownItems;
            newcol.ValueMember = this.ValueMember;
            newcol.DisplayMember = this.DisplayMember;
            newcol.ActiveRowSign = this.ActiveRowSign;
            return newcol;
        }
        private ComboBoxStyle _dropDownStyle = ComboBoxStyle.DropDownList;
        public ComboBoxStyle DropDownStyle
        {
            get { return this._dropDownStyle; }
            set { this._dropDownStyle = value; }
        }
    }
    public class DropDownListCell : DataGridViewTextBoxCell
    {
        public DropDownListCell()
            : base()
        {
            //���س�ʼ��Ϣ
        }
        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            DropDownListEditingControl combox = DataGridView.EditingControl as DropDownListEditingControl;
            DropDownListColumn dgvc = this.DataGridView.Columns[this.ColumnIndex] as DropDownListColumn;
            combox.DropDownStyle = dgvc.DropDownStyle;
            combox.DisplayMember = "Text";
            combox.ValueMember = "Value";
            combox.ColumnIndex = this.ColumnIndex;
            if (dgvc == null)
                return;
            MyDataGridView mygrid = this.DataGridView as MyDataGridView;
            combox.Name = mygrid.GetCellControlName(dgvc);//���ÿؼ��������룬�����ʱ�޷��ҵ��ÿؼ�
            if (mygrid.CurrentDropDownListEditingControlName != mygrid.GetCellControlName(dgvc))
            {
                mygrid.SetComboBox(mygrid.GetCellControlName(dgvc));//��ӿؼ�
                //���°������б�
                combox.Items.Clear();
                foreach (MyDataGridViewDropDownListItem dgvcitem in dgvc.DropDownItems)
                    combox.Items.Add(dgvcitem);
            }
            //combox.DataSource = dgvc.DropDownItems;//�������б�
            //���ó�ʼֵ
            System.Data.DataTable dt = this.DataGridView.DataSource as System.Data.DataTable;
            int iSelectedIndex = -1;
            if (dt != null)
            {
                if (dgvc.DropDownStyle == ComboBoxStyle.DropDownList)
                {
                    object objValue = dt.DefaultView[rowIndex].Row[dgvc.ValueMember];
                    for (int i = 0; i < combox.Items.Count; i++)
                    {
                        MyDataGridViewDropDownListItem item = combox.Items[i] as MyDataGridViewDropDownListItem;
                        if (item != null && item.Vallue != null && objValue.ToString().ToLower() == item.Vallue.ToString().ToLower())
                        {
                            iSelectedIndex = i;
                            break;
                        }
                    }
                    if (iSelectedIndex == -1)
                    {
                        if (dgvc.DisplayMember.Length > 0)
                        {
                            //����һ��������
                            string snewText = dt.DefaultView[rowIndex].Row[dgvc.DisplayMember].ToString();
                            MyDataGridViewDropDownListItem newItem = new MyDataGridViewDropDownListItem();
                            newItem.Text = snewText;
                            newItem.Vallue = objValue;
                            if (dgvc.DropDownItems == null)
                                dgvc.DropDownItems = new List<MyDataGridViewDropDownListItem>();
                            dgvc.DropDownItems.Insert(0, newItem);
                            combox.Items.Insert(0, newItem);
                            combox.SelectedIndex = 0;
                        }

                    }
                    else
                    {
                        combox.SelectedIndex = iSelectedIndex;
                    }
                }
                else if (dgvc.DropDownStyle == ComboBoxStyle.DropDown)
                {
                    combox.Text = dt.DefaultView[rowIndex].Row[dgvc.DisplayMember].ToString();
                }
            }
        }
        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that DropDownListEditingControl uses.
                return typeof(DropDownListEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.

                return typeof(string);
            }
        }
        public override object DefaultNewRowValue
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class DropDownListEditingControl : ComboBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView = null;
        int rowIndex;
        private bool valueChanged = false;
        #region IDataGridViewEditingControl ��Ա

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                this.dataGridView = value;
            }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                MyDataGridViewDropDownListItem item = this.SelectedItem as MyDataGridViewDropDownListItem;
                if (item == null)
                    return string.Empty;
                return item.Text;
                /*System.Data.DataTable dt = dataGridView.DataSource as System.Data.DataTable;
                if (dt != null)
                {
                    string strValueMember = string.Empty;
                    DropDownListColumn ddlcol = dataGridView.Columns[this.ColumnIndex] as DropDownListColumn;
                    if (ddlcol != null)
                    {
                        strValueMember = ddlcol.ValueMember;
                    }
                    if (strValueMember.Length > 0)
                    {
                        dt.DefaultView[EditingControlRowIndex].Row[strValueMember] = item.Vallue;
                    }
                    return item.Text;
                }*/
                //return item.Text;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {

        }

        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            //if (DropDownStyle != ComboBoxStyle.DropDownList) return;
            //ѡ��ı��Ҫ�ı�Ա���ݱ��е�Valueֵ
            System.Data.DataTable dt = this.dataGridView.DataSource as System.Data.DataTable;
            DropDownListColumn ddlcol = this.dataGridView.Columns[this.ColumnIndex] as DropDownListColumn;
            if (ddlcol == null) return;
            MyDataGridViewDropDownListItem item = this.SelectedItem as MyDataGridViewDropDownListItem;
            if (item == null) return;
            if (ddlcol.ValueMember.Length > 0 && item.Vallue != null)
                dt.DefaultView[this.rowIndex][ddlcol.ValueMember] = item.Vallue;
            if (ddlcol.DisplayMember.Length > 0)
                dt.DefaultView[this.rowIndex][ddlcol.DisplayMember] = item.Text;
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            //base.OnSelectedIndexChanged(e);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (DropDownStyle == ComboBoxStyle.DropDown)
            {
                DropDownListColumn ddlcol = this.dataGridView.Columns[this.ColumnIndex] as DropDownListColumn;
                if (ddlcol == null) return;
                System.Data.DataTable dt = this.dataGridView.DataSource as System.Data.DataTable;
                if (dt.DefaultView[this.rowIndex][ddlcol.DisplayMember].ToString() != this.Text)
                    dt.DefaultView[this.rowIndex][ddlcol.DisplayMember] = this.Text;
            }
        }
        #endregion
        #region �洢�к�
        private int _columnIndex = -1;
        /// <summary>
        /// �к�
        /// </summary>
        public int ColumnIndex
        {
            get { return this._columnIndex; }
            set { this._columnIndex = value; }
        }
        #endregion

    }
    [Serializable]
    public class MyDataGridViewDropDownListItem
    {
        private string _strText = string.Empty;
        public string Text
        {
            get { return this._strText; }
            set { this._strText = value; }
        }
        private object _strVallue = string.Empty;
        public object Vallue
        {
            get { return this._strVallue; }
            set { this._strVallue = value; }
        }
    }
}
