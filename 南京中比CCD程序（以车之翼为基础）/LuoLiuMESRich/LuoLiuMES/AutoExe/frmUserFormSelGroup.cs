using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LuoLiuMES.AutoExe
{
    public partial class frmUserFormSelGroup : Common.frmBase
    {
        public frmUserFormSelGroup()
        {
            InitializeComponent();
        }
        #region 公共属性
        public List<Common.MyEntity.ComboBoxItem> _ListGroup = null;
        public Common.MyEntity.ComboBoxItem _SelectedItem = null;
        #endregion

        private void frmUserFormSelGroup_Load(object sender, EventArgs e)
        {
            if (_ListGroup != null)
            {
                this.listBox1.DisplayMember = "Text";
                this.listBox1.ValueMember = "Value";
                foreach (Common.MyEntity.ComboBoxItem item in _ListGroup)
                    this.listBox1.Items.Add(item);
            }
            else
                this.button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem == null)
            {
                this.ShowMsg("请选择一行数据");
                return;
            }
            _SelectedItem = this.listBox1.SelectedItem as Common.MyEntity.ComboBoxItem;
            this.DialogResult = DialogResult.OK;
        }

    }
}