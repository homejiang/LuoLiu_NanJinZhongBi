using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace MyControl
{
    /*技术参考：http://msdn.microsoft.com/en-us/library/7tas5c80.aspx
    */
    public class NumericBoxColumn : DataGridViewColumn
    {
        public NumericBoxColumn()
            : base(new NumericBoxCell())
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
                    !value.GetType().IsAssignableFrom(typeof(NumericBoxCell)))
                {
                    throw new InvalidCastException("Must be a NumericBoxCell");
                }
                base.CellTemplate = value;
            }
        }
        #region 公共属性
        private string _strFormat = "##########0.######";
        [CategoryAttribute("NumericBox"), DescriptionAttribute("Format"), DefaultValue("##########0.######")]
        public string Format
        {
            get { return this._strFormat; }
            set 
            {
                this._strFormat = value;
                if (this.IsInteger)
                    this._strFormat = "#########0";//如果已经设置为整型了，则掩码必须是整型的
            }
        }
        private bool _isFilterQuanJiao = false;
        [CategoryAttribute("NumericBox"), DescriptionAttribute("IsFilterQuanJiao"), DefaultValue(true)]
        public bool FilterQuanJiao
        {
            get
            {
                return this._isFilterQuanJiao;
            }
            set
            {
                this._isFilterQuanJiao = value;
            }
        }
        private bool _isInteger = false;
        [CategoryAttribute("NumericBox"), DescriptionAttribute("IsInteger"), DefaultValue(false)]
        public bool IsInteger
        {
            get { return this._isInteger; }
            set 
            { 
                this._isInteger = value;
                if (this._isInteger)
                    this.Format = "#########0";
            }
        }
        #endregion
        public override object Clone()
        {
            NumericBoxColumn nbcol = base.Clone() as NumericBoxColumn;
            nbcol.Format = this.Format;
            nbcol.FilterQuanJiao = this.FilterQuanJiao;
            nbcol.IsInteger = this.IsInteger;
            return nbcol;
        }
    }
    public class NumericBoxCell : DataGridViewTextBoxCell
    {

        public NumericBoxCell()
            : base()
        {
            this.Style.Format = "#########0.######";
        }
        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            NumericBoxEditingControl ctl = DataGridView.EditingControl as NumericBoxEditingControl;
            NumericBoxColumn nbcol = this.DataGridView.Columns[this.ColumnIndex] as NumericBoxColumn;
            ctl.Formart = nbcol.Format;
            ctl.FilterQuanJiao = nbcol.FilterQuanJiao;
            ctl.ColumnIndex = this.ColumnIndex;
             //设置初始化值.
            string strIniValue;
            if (initialFormattedValue == null)
            {
                strIniValue = this.DefaultNewRowValue == null ? string.Empty : this.DefaultNewRowValue.ToString();
            }
            else
                strIniValue = initialFormattedValue.ToString();
            ctl.Text = strIniValue;
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarCell uses.
                return typeof(NumericBoxEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.
                NumericBoxColumn nbcol = this.DataGridView.Columns[this.ColumnIndex] as NumericBoxColumn;
                if (nbcol != null)
                    return nbcol.IsInteger ? typeof(int) : typeof(decimal);
                return typeof(decimal);
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
    class NumericBoxEditingControl : MyControl.NumericBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public NumericBoxEditingControl()
        {
           
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                NumericBoxColumn nbcol = this.dataGridView.Columns[this.ColumnIndex] as NumericBoxColumn;
                if (nbcol != null)
                {
                    if (nbcol.IsInteger)
                    {
                        int ivalue;
                        if (!int.TryParse(this.Text, out ivalue))
                            return string.Empty;
                        else return ivalue.ToString();
                    }
                    else
                    {
                        decimal dec;
                        if (!decimal.TryParse(this.Text, out dec))
                            return string.Empty;
                        return dec.ToString(this.Formart);
                    }
                }
                else return string.Empty;
                
            }
            set
            {
                this.BindValue = value;
                //if (value is String)
                //{
                //    try
                //    {
                //        // This will throw an exception of the string is 
                //        // null, empty, or not in the format of a date.
                //        this.Value = DateTime.Parse((String)value);
                //    }
                //    catch
                //    {
                //        // In the case of an exception, just use the 
                //        // default value so we're not left with a null
                //        // value.
                //        this.Value = DateTime.Now;
                //    }
                //}
            }
        }

        // Implements the 
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
        // property.
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

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
        // method.
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
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

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
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

        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnTextChanged(e);
        }
        #region 存储列号
        private int _columnIndex = -1;
        /// <summary>
        /// 列号
        /// </summary>
        public int ColumnIndex
        {
            get { return this._columnIndex; }
            set { this._columnIndex = value; }
        }
        #endregion
    }


}
