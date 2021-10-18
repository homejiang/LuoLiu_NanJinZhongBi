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
        #region 私有字段
        /// <summary>
        /// 在列表中已经存储的下拉控件，只有当调用单元格类的InitializeEditingControl函数后系统才会创建下拉控件实例，然后存储到该字段内。
        /// </summary>
        private List<DropDownListEditingControl> _myComboxlist = null;
        /// <summary>
        /// 当前已经激活的DropDownListEditingControl控件名称，此名称是调用单元格类的InitializeEditingControl函数后系统根据列名来设置的，之所以要这样是因为
        /// 微软的列表控件只创建一个DropDownListEditingControl实例，哪怕你的列表中包含多个DropDownListColumn列。
        /// </summary>
        public string CurrentDropDownListEditingControlName = string.Empty;
        #endregion
        #region 公共属性
        private bool _blShowLineNo = false;
        [CategoryAttribute("MyDataGridView"), DescriptionAttribute("ShowLineNo"), DefaultValue(false)]
        public bool ShowLineNo
        {
            get { return this._blShowLineNo; }
            set { this._blShowLineNo = value; }
        }
        #endregion
        #region 绑定DropDownListColumn中的下拉菜单
        /// <summary>
        /// 通过该方法可以实时修改下拉框的绑定内容
        /// </summary>
        /// <param name="column">列表中对应的DropDownListColumn列</param>
        /// <param name="listItem">下拉列表</param>
        /// <param name="isReplace">是否替换原有的下拉内容</param>
        public void BindDropdownItems(MyControl.DropDownListColumn column, List<MyControl.MyDataGridViewDropDownListItem> listItem, bool isReplace)
        {
            //暂时先直接复制，如果需要动态加载下拉列表项还需改进。
            //目前遇到的问题是：1、微软的列表控件中的DropDownListColumn控件实例只有1一个，2、如果采用ComboBox.Items.Clear()的话，重复点击同意DropDownListCell后就会出现反复执行SelectedIndexChanged事件
            column.DropDownItems = listItem;
        }
        /// <summary>
        /// 设置下拉控件名称
        /// </summary>
        /// <param name="strComboxName">下拉控件名称</param>
        public void SetComboBox(string strComboxName)
        {
            if (this.CurrentDropDownListEditingControlName != strComboxName)
                this.CurrentDropDownListEditingControlName = strComboxName;
        }
        #endregion
        #region 自定义公共函数
        public string GetCellControlName(MyControl.DropDownListColumn column)
        {
            //设置控件名称时，有与窗体其他控件同名的概率
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
        #region 提交单元格信息
        /// <summary>
        /// 提交单元格信息，因原微软的DataGridView只有在换行后才保存上一行数据，这样很麻烦；调用此方法后系统就会将绑定字段保存在数据行中
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
        #region 重写事件
        protected override void OnRowPostPaint(System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            if (this.ShowLineNo)
            {
                #region 显示行号
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
}
