using AutoAssign.JPSEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.Debug
{
    public partial class frmBatData : Common.frmBase
    {
        frmMain1 _MainForm = null;
        public frmBatData(frmMain1 mainForm)
        {
            InitializeComponent();
            this._MainForm = mainForm;
            this.dgv1.AutoGenerateColumns = false;
            this.dgv2.AutoGenerateColumns = false;
        }
        DataTable _DataTable1 = null;
        DataTable _DataTable2 = null;

        private void frmBatData_Load(object sender, EventArgs e)
        {
            this._MainForm.IsFormBatDataOpened = true;
            _DataTable1 = new DataTable();
            _DataTable1.Columns.Add("No", Type.GetType("System.Int16"));
            _DataTable1.Columns.Add("SNCode", Type.GetType("System.String"));
            _DataTable1.Columns.Add("MyCode", Type.GetType("System.String"));
            _DataTable1.Columns.Add("IsNGView", Type.GetType("System.String"));
            _DataTable1.Columns.Add("IschongFuView", Type.GetType("System.String"));
            _DataTable1.Columns.Add("IsMBatchNumView", Type.GetType("System.String"));
            _DataTable1.DefaultView.Sort = "No asc";
            _DataTable2 = new DataTable();
            _DataTable2.Columns.Add("No", Type.GetType("System.Int16"));
            _DataTable2.Columns.Add("SNCode", Type.GetType("System.String"));
            _DataTable2.Columns.Add("MyCode", Type.GetType("System.String"));
            _DataTable2.Columns.Add("IsNGView", Type.GetType("System.String"));
            _DataTable2.Columns.Add("IschongFuView", Type.GetType("System.String"));
            _DataTable2.Columns.Add("IsMBatchNumView", Type.GetType("System.String"));
            _DataTable2.DefaultView.Sort = "No asc";
            this.dgv1.DataSource = _DataTable1;
            this.dgv2.DataSource = _DataTable2;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this._MainForm.IsFormBatDataOpened = false;
            base.OnClosing(e);
        }
        
        public void RefreshData1(ScannerDianXinData[] codeEntitys,int iValue)
        {
            if (this.chkStopReceive.Checked) return;
            DataRow dr;
            string strView;
            for (int i = 0; i < codeEntitys.Length; i++)
            {
                if(_DataTable1.Rows.Count<=i)
                {
                    DataRow drNew = _DataTable1.NewRow();
                    drNew["No"] = i + 1;
                    _DataTable1.Rows.Add(drNew);
                }
                dr = _DataTable1.Rows[i];
                if (dr["SNCode"].ToString() != codeEntitys[i].SNCode)
                    dr["SNCode"] = codeEntitys[i].SNCode;
                if (dr["MyCode"].ToString() != codeEntitys[i].MyCode)
                    dr["MyCode"] = codeEntitys[i].MyCode;
                strView = codeEntitys[i].IsNG ? "是" : "否";
                if (dr["IsNGView"].ToString() != strView)
                    dr["IsNGView"] = strView;
                strView = codeEntitys[i].IsChongFu ? "是" : "否";
                if (dr["IschongFuView"].ToString() != strView)
                    dr["IschongFuView"] = strView;
                strView = codeEntitys[i].MBatchIsOk ? "是" : "否";
                if (dr["IsMBatchNumView"].ToString() != strView)
                    dr["IsMBatchNumView"] = strView;
            }
            strView = iValue.ToString();
            if (this.tbBitsValue1.Text != strView)
                this.tbBitsValue1.Text = strView;
        }
        public void RefreshData2(ScannerDianXinData[] codeEntitys, int iValue)
        {
            if (this.chkStopReceive.Checked) return;
            DataRow dr;
            string strView;
            for (int i = 0; i < codeEntitys.Length; i++)
            {
                if (_DataTable2.Rows.Count <= i)
                {
                    DataRow drNew = _DataTable2.NewRow();
                    drNew["No"] = i + 1;
                    _DataTable2.Rows.Add(drNew);
                }
                dr = _DataTable2.Rows[i];
                if (dr["SNCode"].ToString() != codeEntitys[i].SNCode)
                    dr["SNCode"] = codeEntitys[i].SNCode;
                if (dr["MyCode"].ToString() != codeEntitys[i].MyCode)
                    dr["MyCode"] = codeEntitys[i].MyCode;
                strView = codeEntitys[i].IsNG ? "是" : "否";
                if (dr["IsNGView"].ToString() != strView)
                    dr["IsNGView"] = strView;
                strView = codeEntitys[i].IsChongFu ? "是" : "否";
                if (dr["IschongFuView"].ToString() != strView)
                    dr["IschongFuView"] = strView;
                strView = codeEntitys[i].MBatchIsOk ? "是" : "否";
                if (dr["IsMBatchNumView"].ToString() != strView)
                    dr["IsMBatchNumView"] = strView;
            }
            strView = iValue.ToString();
            if (this.tbBitsValue2.Text != strView)
                this.tbBitsValue2.Text = strView;
        }
    }
}
