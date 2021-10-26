using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using ErrorService;
using System.Data.SqlClient;

namespace BasicData.BOM.BOMVersion
{
    public partial class frmBOMVersion : frmBase
    {
        public frmBOMVersion()
        {
            InitializeComponent();
        }
        #region 窗体连接实例
        private BLLDAL.BOMBase _dal = null;
        private BLLDAL.BOMBase BLLDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.BOMBase();
                return _dal;
            }
        }
        #endregion
        private int _stateback = 0;
        private int _index;
        private void btnClosed_Click(object sender, EventArgs e)
        {
            DataTable dt = this.mdgv.DataSource as DataTable;
            if (dt != null && dt.GetChanges() != null)
            {
                DialogResult mresult = MessageBox.Show("您还有部分操作未保存，是否需要保存？", "操作提示", MessageBoxButtons.YesNoCancel);
                if (mresult == DialogResult.Yes)
                {
                    try
                    {
                        this.BLLDAL.SaveBOMVersion(dt);
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        _stateback = 1;//重新加载mdgv且选中item不变
                        this.listBox1.SelectedIndex = _index;
                        return;
                    }
                    dt.AcceptChanges();
                    this.ShowMsg("保存成功！");
                }
                if (mresult == DialogResult.Cancel)
                {
                    _stateback = 1;//重新加载mdgv且选中item不变
                    this.listBox1.SelectedIndex = _index;
                    return;
                }
                if (mresult == DialogResult.No)
                {
                    this._stateback = 2;
                }
            }
            this.FormColse();
        }

        private void frmBOMsign_Load(object sender, EventArgs e)
        {
            this.mdgv.AutoGenerateColumns = false;
            this.listBox1.DisplayMember = "Text";
            if (!BindClass()) return;
        }

        private bool BindClass()
        {
            string strsql = @"select Code,ClassName from BOM_Sys_ProductClass order by SortID asc";
            DataTable dtlist = new DataTable();
            try
            {
                dtlist = Common.CommonDAL.DoSqlCommand.GetDateTable(strsql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            Common.MyEntity.ComboBoxItem item;
            
            foreach (DataRow dr in dtlist.Rows)
            {
                item = new Common.MyEntity.ComboBoxItem();
                item.Text = dr["ClassName"].ToString();
                item.Value = dr["Code"].ToString();
                listBox1.Items.Add(item);
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtSource = mdgv.DataSource as DataTable;
            if (dtSource.GetChanges() == null) return;
            try
            {
                this.BLLDAL.SaveBOMVersion(dtSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            dtSource.AcceptChanges();
            this.ShowMsg("保存成功！");
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_stateback == 1)
            {
                _stateback = 0;
                return;
            }
            int index = -1;
            DataTable dt = this.mdgv.DataSource as DataTable;
            index = this.listBox1.SelectedIndex;
            if (dt != null && dt.GetChanges() != null)
            {
                DialogResult mresult = MessageBox.Show("您还有部分操作未保存，是否需要保存？", "操作提示", MessageBoxButtons.YesNoCancel);
                if (mresult == DialogResult.Yes)
                {
                    try
                    {
                        this.BLLDAL.SaveBOMVersion(dt);
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        _stateback = 1;//重新加载mdgv且选中item不变
                        this.listBox1.SelectedIndex = _index;
                        return;
                    }
                    dt.AcceptChanges();
                    this.ShowMsg("保存成功！");
                }
                if (mresult == DialogResult.Cancel)
                {
                    _stateback = 1;//重新加载mdgv且选中item不变
                    this.listBox1.SelectedIndex = _index;
                    return;
                }
                if (mresult == DialogResult.No)
                {
                    this._stateback = 2;
                }
            }
            if (_stateback == 2)
            {
                //此时无需校验是否修改了规格数据
                _stateback = 0;
            }
            this._index = index;
            Common.MyEntity.ComboBoxItem item = this.listBox1.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null)
                this.filldgv(string.Empty);
            else
                this.filldgv(item.Value.ToString());
        }

        private bool filldgv(string strcode)
        {
            string strsql = "select * from BOM_Sys_Version where SFGClass='" + strcode.Replace("'", "''") + "' order by VersionNo asc,VersionSpec asc";
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strsql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            dt.Columns["SFGClass"].DefaultValue = strcode;
            this.mdgv.DataSource = dt;
            return true;
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (mdgv.SelectedRows.Count <= 0)
            {
                this.ShowMsg("请选择一行数据！");
                return;
            }
            //int count = mdgv.SelectedRows.Count;
            List<int> list = Common.CommonFuns.GetSelectedRows(this.mdgv);
            DataTable dt = mdgv.DataSource as DataTable;
            if (!this.IsUserConfirm("您确实要删除这些数据吗？")) return;
            try
            {
                for (int i = list.Count; i > 0; i--)
                {
                    if (list[i - 1] >= dt.DefaultView.Count) 
                        i--;
                    if (i < 1) break;
                    dt.DefaultView[list[i - 1]].Row.Delete();
                }
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
        }

    }
}