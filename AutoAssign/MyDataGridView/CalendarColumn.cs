using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MyControl
{
    /*技术参考：http://msdn.microsoft.com/en-us/library/7tas5c80.aspx
    */
    public class CalendarColumn : DataGridViewColumn
    {
        public CalendarColumn()
            : base(new CalendarCell())
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
                    !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }
    public class CalendarCell : DataGridViewTextBoxCell
    {

        public CalendarCell(): base()
        {
            // 默认日期类型
            this.Style.Format = "yyyy-MM-dd";
        }
        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CalendarEditingControl ctl = DataGridView.EditingControl as CalendarEditingControl;
            ctl.ShowCheckBox = true;
            //ctl.Checked = false;
             //设置初始化值.
            string strIniValue;
            if (this.Value == null)
            {
                strIniValue = this.DefaultNewRowValue == null ? string.Empty : this.DefaultNewRowValue.ToString();
            }
            else
                strIniValue = this.Value.ToString();
            DateTime detInit;
            if (strIniValue.Length == 0 || !DateTime.TryParse(strIniValue, out detInit))
            {
                ctl.Checked = false;
                ctl.Value = DateTime.Now;
            }
            else
                ctl.Value = detInit;
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarCell uses.
                return typeof(CalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.

                return typeof(DateTime);
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
    class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public CalendarEditingControl()
        {
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "yyyy-MM-dd";
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                if (this.ShowCheckBox)
                {
                    if (this.Checked)
                        return this.Value.ToString("yyyy-MM-dd");
                    else
                        return string.Empty;
                }
                else
                    return this.Value.ToString("yyyy-MM-dd");
            }
            set
            {
                if (value != null && !value.Equals(DBNull.Value) && value.ToString().Length > 0)
                {
                    //转换成日期
                    try
                    {
                        this.Value = DateTime.Parse((String)value);
                    }
                    catch
                    {
                        if (this.ShowCheckBox)
                        {
                            this.Checked = false;
                            this.Value = DateTime.Now;
                        }
                        else
                            this.Value = DateTime.Now;
                    }
                }
                else
                {
                    //此时为空值
                    if (this.ShowCheckBox)
                        this.Checked = false;
                    else
                        this.Value = DateTime.Now;
                }
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
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
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

        protected override void OnValueChanged(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }

        #region IDataGridViewEditingControl 成员
        /*
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DataGridView EditingControlDataGridView
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
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
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Cursor EditingPanelCursor
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
        */
        #endregion
    }


}
