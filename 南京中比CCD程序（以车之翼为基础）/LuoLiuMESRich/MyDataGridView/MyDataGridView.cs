using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MyControl
{
    public class MyDataGridView:System.Windows.Forms.DataGridView
    {
        #region ˽���ֶ�
        /// <summary>
        /// ���б����Ѿ��洢�������ؼ���ֻ�е����õ�Ԫ�����InitializeEditingControl������ϵͳ�Żᴴ�������ؼ�ʵ����Ȼ��洢�����ֶ��ڡ�
        /// </summary>
        private List<DropDownListEditingControl> _myComboxlist = null;
        /// <summary>
        /// ��ǰ�Ѿ������DropDownListEditingControl�ؼ����ƣ��������ǵ��õ�Ԫ�����InitializeEditingControl������ϵͳ�������������õģ�֮����Ҫ��������Ϊ
        /// ΢����б�ؼ�ֻ����һ��DropDownListEditingControlʵ������������б��а������DropDownListColumn�С�
        /// </summary>
        public string CurrentDropDownListEditingControlName = string.Empty;
        #endregion
        #region ��������
        private bool _blShowLineNo = false;
        [CategoryAttribute("MyDataGridView"), DescriptionAttribute("ShowLineNo"), DefaultValue(false)]
        public bool ShowLineNo
        {
            get { return this._blShowLineNo; }
            set { this._blShowLineNo = value; }
        }
        #endregion
        #region ��DropDownListColumn�е������˵�
        /// <summary>
        /// ͨ���÷�������ʵʱ�޸�������İ�����
        /// </summary>
        /// <param name="column">�б��ж�Ӧ��DropDownListColumn��</param>
        /// <param name="listItem">�����б�</param>
        /// <param name="isReplace">�Ƿ��滻ԭ�е���������</param>
        public void BindDropdownItems(MyControl.DropDownListColumn column, List<MyControl.MyDataGridViewDropDownListItem> listItem, bool isReplace)
        {
            //��ʱ��ֱ�Ӹ��ƣ������Ҫ��̬���������б����Ľ���
            //Ŀǰ�����������ǣ�1��΢����б�ؼ��е�DropDownListColumn�ؼ�ʵ��ֻ��1һ����2���������ComboBox.Items.Clear()�Ļ����ظ����ͬ��DropDownListCell��ͻ���ַ���ִ��SelectedIndexChanged�¼�
            column.DropDownItems = listItem;
        }
        /// <summary>
        /// ���������ؼ�����
        /// </summary>
        /// <param name="strComboxName">�����ؼ�����</param>
        public void SetComboBox(string strComboxName)
        {
            if (this.CurrentDropDownListEditingControlName != strComboxName)
                this.CurrentDropDownListEditingControlName = strComboxName;
        }
        #endregion
        #region �Զ��幫������
        public string GetCellControlName(MyControl.DropDownListColumn column)
        {
            //���ÿؼ�����ʱ�����봰�������ؼ�ͬ���ĸ���
            return string.Format("MyControl_MyDataGridView_byjps_{0}_{1}_{2}", this.Name, column.Name, column.ActiveRowSign);
        }
        public void SetColumnSortMode(System.Windows.Forms.DataGridViewColumnSortMode sortMode)
        {
            for (int i = 0; i < this.Columns.Count; i++)
            {
                if (this.Columns[i].SortMode != sortMode)
                    this.Columns[i].SortMode = sortMode;
            }
        }
        #endregion
        #region �ύ��Ԫ����Ϣ
        /// <summary>
        /// �ύ��Ԫ����Ϣ����ԭ΢���DataGridViewֻ���ڻ��к�ű�����һ�����ݣ��������鷳�����ô˷�����ϵͳ�ͻὫ���ֶα�������������
        /// </summary>
        public void UpdateCurrentRowCellValue()
        {
            if (this.CurrentRow == null) return;
            System.Data.DataTable dt = this.DataSource as System.Data.DataTable;
            string strDataPropertyName;
            for (int i = 0; i < this.CurrentRow.Cells.Count; i++)
            {
                strDataPropertyName = this.Columns[this.CurrentRow.Cells[i].ColumnIndex].DataPropertyName;
                if (strDataPropertyName.Length == 0) continue;
                if (this.CurrentRow.Cells[i].Value == null)
                {
                    if (!dt.DefaultView[this.CurrentRow.Index].Row[strDataPropertyName].Equals(DBNull.Value))
                        dt.DefaultView[this.CurrentRow.Index].Row[strDataPropertyName] = DBNull.Value;
                }
                else
                {
                    if (!dt.DefaultView[this.CurrentRow.Index].Row[strDataPropertyName].Equals(this.CurrentRow.Cells[i].Value))
                        dt.DefaultView[this.CurrentRow.Index].Row[strDataPropertyName] = this.CurrentRow.Cells[i].Value;
                }
            }
        }
        public void UpdateCurrentRowCellValue(System.Data.DataTable dt)
        {
            if (this.CurrentRow == null) return;
            string strDataPropertyName;
            for (int i = 0; i < this.CurrentRow.Cells.Count; i++)
            {
                strDataPropertyName = this.Columns[this.CurrentRow.Cells[i].ColumnIndex].DataPropertyName;
                if (strDataPropertyName.Length == 0) continue;
                if (this.CurrentRow.Cells[i].Value == null)
                {
                    if (!dt.DefaultView[this.CurrentRow.Index].Row[strDataPropertyName].Equals(DBNull.Value))
                        dt.DefaultView[this.CurrentRow.Index].Row[strDataPropertyName] = DBNull.Value;
                }
                else
                {
                    if (!dt.DefaultView[this.CurrentRow.Index].Row[strDataPropertyName,System.Data.DataRowVersion.Current].Equals(this.CurrentRow.Cells[i].Value))
                    {
                        dt.DefaultView[this.CurrentRow.Index].Row[strDataPropertyName] = this.CurrentRow.Cells[i].Value;
                        if (dt.DefaultView[this.CurrentRow.Index].Row.RowState == System.Data.DataRowState.Unchanged)
                            dt.DefaultView[this.CurrentRow.Index].Row.SetModified();
                    }
                }
            }
        }
        #endregion
        #region ��д�¼�
        protected override void OnRowPostPaint(System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            if (this.ShowLineNo)
            {
                #region ��ʾ�к�
                Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                this.RowHeadersWidth - 4,
                e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                    this.RowHeadersDefaultCellStyle.Font,
                    rectangle,
                    this.RowHeadersDefaultCellStyle.ForeColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                #endregion
            }
            base.OnRowPostPaint(e);
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
}
