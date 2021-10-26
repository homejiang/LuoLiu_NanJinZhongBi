using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common.Msg
{
    public partial class frmSelectMsgTye : Common.frmSelectBase
    {
        public frmSelectMsgTye()
        {
            InitializeComponent();
        }
        public string _SelectedArgs = string.Empty;
        #region 处理函数
        private bool Perinit()
        {
            this.dgvDetail.AutoGenerateColumns = false;
            this.dgvDetail.MultiSelect = this.MultiSelected;//是否允许多选
            if (this.MultiSelected)
                this.BindDataGridViewCheckBox(this.dgvDetail, this.colCheckBox);
            else
            {
                //单选无需添加复选框
                this.colCheckBox.Visible = false;
                this.dgvDetail.CellDoubleClick+=new DataGridViewCellEventHandler(dgvDetail_CellDoubleClick);
            }
            this.btEmpty.Visible = _ShowEmptyButton;
            return true;
        }
        private bool BindData()
        {
            DataTable dt = null;
            string strSql = string.Format("EXEC Msg_GetMsgTypes '{0}','{1}'", _SelectedArgs, this.tbSearch.Text);
            try
            {
                dt = Common.CommonDAL.DoSqlCommandLog.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (this.MultiSelected)
            {
                dt.Columns.Add(this.GetDataGridViewCheckBoxColumn());
                if (this.SelectedData != null && this.SelectedData.Count > 0)
                {
                    string strSeld = "";
                    foreach (SelectedMsgType msg in this.SelectedData)
                    {
                        strSeld += msg.Arg.ToString() + ",";
                    }
                    if (strSeld != string.Empty)
                        strSeld = strSeld.Substring(0, strSeld.Length - 1);
                    if (strSeld != string.Empty)
                    {
                        DataRow[] drs;
                        if (strSeld.IndexOf(",") < 0)
                            drs = dt.Select("Arg=" + strSeld);
                        else
                            drs = dt.Select(string.Format("arg in ({0})", strSeld));
                        foreach (DataRow dr in drs)
                        {
                            dr[this.DataGridViewCheckColumnName] = true;
                        }
                    }
                }
            }
            this.dgvDetail.DataSource = dt;
            return true;
        }
        #endregion
        #region 公共属性
        public bool _ShowEmptyButton = false;
        private List<SelectedMsgType> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedMsgType> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        
        #endregion
        #region 窗体OnLoad事件
        private void frmSelect_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            if (!this.BindData()) return;
        }
        #endregion
        
        #region 底部按钮事件
        private void btClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源丢失，请重新加载窗体。");
                return;
            }
            if (this.MultiSelected)
            {
                DataRow[] drs = dt.Select(this.DataGridViewCheckColumnName + "=1");
                if (drs.Length == 0)
                {
                    this.ShowMsg("请至少选中一行数据。");
                    return;
                }
                this.SelectedData = new List<SelectedMsgType>();
                SelectedMsgType info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedMsgType();
                    info.ReadFromDataRow(dr);
                    this.SelectedData.Add(info);
                }
            }
            else
            {
                if (this.dgvDetail.SelectedRows.Count == 0)
                {
                    this.ShowMsg("请选中一行数据。");
                    return;
                }
                if (dt.DefaultView.Count <= this.dgvDetail.SelectedRows[0].Index)
                    return;
                SelectedMsgType info = new SelectedMsgType();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedMsgType>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectedMsgType
        {
            public SelectedMsgType()
            {
            }
            public SelectedMsgType(DataRow dr)
            {
                this.ReadFromDataRow(dr);
            }
            
            private object _iArg;
            /// <summary>
            ///
            /// </summary>
            public object Arg
            {
                get { return this._iArg; }
                set { this._iArg = value; }
            }
            private object _strMsgDesc;
            /// <summary>
            ///
            /// </summary>
            public object MsgDesc
            {
                get { return this._strMsgDesc; }
                set { this._strMsgDesc = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.Arg = dr["Arg"];
                this.MsgDesc = dr["MsgDesc"];
            }
        }
        #endregion
        #region 列表框事件
        //行双击事件
        protected void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btTrue_Click(null, null);
        }
        #endregion

        private void btSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                this.btSearch_Click(null, null);
        }

        private void btEmpty_Click(object sender, EventArgs e)
        {
            SelectedData = new List<SelectedMsgType>();
            this.DialogResult = DialogResult.OK;
        }
    }
}