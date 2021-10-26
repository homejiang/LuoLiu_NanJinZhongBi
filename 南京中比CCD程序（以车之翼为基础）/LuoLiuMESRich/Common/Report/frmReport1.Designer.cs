namespace Common.Report
{
    partial class frmReport1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkRp = new System.Windows.Forms.LinkLabel();
            this.comReport = new System.Windows.Forms.ComboBox();
            this.linkTime = new System.Windows.Forms.LinkLabel();
            this.btOutputExcel = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.labZhi = new System.Windows.Forms.Label();
            this.dtpTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.labtotal = new System.Windows.Forms.Label();
            this.dgvList = new MyControl.MyDataGridView();
            this.tlDataGrid = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btOutputTxt = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.tlDataGrid.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btOutputTxt);
            this.panel1.Controls.Add(this.linkRp);
            this.panel1.Controls.Add(this.comReport);
            this.panel1.Controls.Add(this.linkTime);
            this.panel1.Controls.Add(this.btOutputExcel);
            this.panel1.Controls.Add(this.btSearch);
            this.panel1.Controls.Add(this.dtpTimeEnd);
            this.panel1.Controls.Add(this.dtpDateEnd);
            this.panel1.Controls.Add(this.labZhi);
            this.panel1.Controls.Add(this.dtpTimeStart);
            this.panel1.Controls.Add(this.dtpDateStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 30);
            this.panel1.TabIndex = 0;
            // 
            // linkRp
            // 
            this.linkRp.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkRp.AutoSize = true;
            this.linkRp.LinkColor = System.Drawing.Color.Black;
            this.linkRp.Location = new System.Drawing.Point(4, 10);
            this.linkRp.Name = "linkRp";
            this.linkRp.Size = new System.Drawing.Size(53, 12);
            this.linkRp.TabIndex = 14;
            this.linkRp.TabStop = true;
            this.linkRp.Text = "报表名称";
            this.linkRp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRp_LinkClicked);
            // 
            // comReport
            // 
            this.comReport.DropDownHeight = 406;
            this.comReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comReport.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comReport.FormattingEnabled = true;
            this.comReport.IntegralHeight = false;
            this.comReport.Location = new System.Drawing.Point(58, 3);
            this.comReport.Name = "comReport";
            this.comReport.Size = new System.Drawing.Size(272, 23);
            this.comReport.TabIndex = 13;
            this.comReport.SelectedIndexChanged += new System.EventHandler(this.comReport_SelectedIndexChanged);
            // 
            // linkTime
            // 
            this.linkTime.AutoSize = true;
            this.linkTime.Location = new System.Drawing.Point(411, 8);
            this.linkTime.Name = "linkTime";
            this.linkTime.Size = new System.Drawing.Size(35, 12);
            this.linkTime.TabIndex = 12;
            this.linkTime.TabStop = true;
            this.linkTime.Text = "时 间";
            this.linkTime.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTime_LinkClicked);
            // 
            // btOutputExcel
            // 
            this.btOutputExcel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btOutputExcel.Location = new System.Drawing.Point(907, 2);
            this.btOutputExcel.Name = "btOutputExcel";
            this.btOutputExcel.Size = new System.Drawing.Size(75, 23);
            this.btOutputExcel.TabIndex = 11;
            this.btOutputExcel.Text = "导出Excel";
            this.btOutputExcel.UseVisualStyleBackColor = true;
            this.btOutputExcel.Click += new System.EventHandler(this.btOutputExcel_Click);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(336, 2);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(66, 22);
            this.btSearch.TabIndex = 10;
            this.btSearch.Text = "搜索";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // dtpTimeEnd
            // 
            this.dtpTimeEnd.CustomFormat = "HH:mm";
            this.dtpTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeEnd.Location = new System.Drawing.Point(762, 3);
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            this.dtpTimeEnd.ShowUpDown = true;
            this.dtpTimeEnd.Size = new System.Drawing.Size(63, 21);
            this.dtpTimeEnd.TabIndex = 5;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateEnd.Location = new System.Drawing.Point(652, 3);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.ShowCheckBox = true;
            this.dtpDateEnd.Size = new System.Drawing.Size(105, 21);
            this.dtpDateEnd.TabIndex = 4;
            // 
            // labZhi
            // 
            this.labZhi.AutoSize = true;
            this.labZhi.Location = new System.Drawing.Point(630, 8);
            this.labZhi.Name = "labZhi";
            this.labZhi.Size = new System.Drawing.Size(17, 12);
            this.labZhi.TabIndex = 3;
            this.labZhi.Text = "至";
            // 
            // dtpTimeStart
            // 
            this.dtpTimeStart.CustomFormat = "HH:mm";
            this.dtpTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeStart.Location = new System.Drawing.Point(566, 3);
            this.dtpTimeStart.Name = "dtpTimeStart";
            this.dtpTimeStart.ShowUpDown = true;
            this.dtpTimeStart.Size = new System.Drawing.Size(61, 21);
            this.dtpTimeStart.TabIndex = 2;
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.CustomFormat = "yyyy-MM-dd";
            this.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateStart.Location = new System.Drawing.Point(456, 3);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.ShowCheckBox = true;
            this.dtpDateStart.Size = new System.Drawing.Size(105, 21);
            this.dtpDateStart.TabIndex = 1;
            // 
            // labtotal
            // 
            this.labtotal.AutoSize = true;
            this.labtotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labtotal.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labtotal.Location = new System.Drawing.Point(3, 590);
            this.labtotal.Name = "labtotal";
            this.labtotal.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labtotal.Size = new System.Drawing.Size(980, 30);
            this.labtotal.TabIndex = 12;
            this.labtotal.Text = "SDSFDS";
            this.labtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidth = 35;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.ShowLineNo = true;
            this.dgvList.Size = new System.Drawing.Size(986, 590);
            this.dgvList.TabIndex = 12;
            // 
            // tlDataGrid
            // 
            this.tlDataGrid.ColumnCount = 1;
            this.tlDataGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDataGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlDataGrid.Controls.Add(this.dgvList, 0, 0);
            this.tlDataGrid.Controls.Add(this.labtotal, 0, 1);
            this.tlDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDataGrid.Location = new System.Drawing.Point(0, 0);
            this.tlDataGrid.Name = "tlDataGrid";
            this.tlDataGrid.RowCount = 2;
            this.tlDataGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDataGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlDataGrid.Size = new System.Drawing.Size(986, 620);
            this.tlDataGrid.TabIndex = 13;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Panel2.Controls.Add(this.tlDataGrid);
            this.splitContainer1.Size = new System.Drawing.Size(986, 651);
            this.splitContainer1.SplitterDistance = 30;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(986, 620);
            this.webBrowser1.TabIndex = 14;
            // 
            // btOutputTxt
            // 
            this.btOutputTxt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btOutputTxt.Location = new System.Drawing.Point(831, 2);
            this.btOutputTxt.Name = "btOutputTxt";
            this.btOutputTxt.Size = new System.Drawing.Size(67, 23);
            this.btOutputTxt.TabIndex = 18;
            this.btOutputTxt.Text = "导出文本";
            this.btOutputTxt.UseVisualStyleBackColor = true;
            this.btOutputTxt.Click += new System.EventHandler(this.btOutputTxt_Click);
            // 
            // frmReport1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 651);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmReport1";
            this.Text = "统计报表";
            this.Load += new System.EventHandler(this.frmProduceList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.tlDataGrid.ResumeLayout(false);
            this.tlDataGrid.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkRp;
        private System.Windows.Forms.ComboBox comReport;
        private System.Windows.Forms.LinkLabel linkTime;
        private System.Windows.Forms.Button btOutputExcel;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.DateTimePicker dtpTimeEnd;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label labZhi;
        private System.Windows.Forms.DateTimePicker dtpTimeStart;
        private System.Windows.Forms.DateTimePicker dtpDateStart;
        private System.Windows.Forms.TableLayoutPanel tlDataGrid;
        private MyControl.MyDataGridView dgvList;
        private System.Windows.Forms.Label labtotal;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btOutputTxt;

    }
}