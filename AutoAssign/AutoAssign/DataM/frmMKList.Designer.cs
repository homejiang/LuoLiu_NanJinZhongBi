namespace AutoAssign.DataM
{
    partial class frmMKList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMKList));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsTesteTime = new System.Windows.Forms.ToolStripLabel();
            this.tslTitle = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsCombox = new System.Windows.Forms.ToolStripComboBox();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbOutputExcel = new System.Windows.Forms.ToolStripButton();
            this.dgvList = new MyControl.MyDataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 519);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbEdit,
            this.tsbDel,
            this.toolStripSeparator1,
            this.tlsTesteTime,
            this.tslTitle,
            this.tsCombox,
            this.tsbSearch,
            this.tsbOutputExcel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = global::AutoAssign.Properties.Resources.edit25;
            this.tsbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(56, 29);
            this.tsbEdit.Text = "打开";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = global::AutoAssign.Properties.Resources.Del25;
            this.tsbDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(55, 29);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // tlsTesteTime
            // 
            this.tlsTesteTime.Name = "tlsTesteTime";
            this.tlsTesteTime.Size = new System.Drawing.Size(56, 29);
            this.tlsTesteTime.Text = "测试时间";
            // 
            // tslTitle
            // 
            this.tslTitle.Name = "tslTitle";
            this.tslTitle.Size = new System.Drawing.Size(81, 29);
            this.tslTitle.Text = "测试批次号";
            // 
            // tsCombox
            // 
            this.tsCombox.Name = "tsCombox";
            this.tsCombox.Size = new System.Drawing.Size(120, 32);
            this.tsCombox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsCombox_KeyDown);
            // 
            // tsbSearch
            // 
            this.tsbSearch.Image = global::AutoAssign.Properties.Resources.search25;
            this.tsbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(57, 29);
            this.tsbSearch.Text = "搜索";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // tsbOutputExcel
            // 
            this.tsbOutputExcel.Image = global::AutoAssign.Properties.Resources.EXCEL;
            this.tsbOutputExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOutputExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOutputExcel.Name = "tsbOutputExcel";
            this.tsbOutputExcel.Size = new System.Drawing.Size(84, 29);
            this.tsbOutputExcel.Text = "导出清单";
            this.tsbOutputExcel.Click += new System.EventHandler(this.tsbOutputExcel_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column17,
            this.Column18,
            this.Column1,
            this.Column8,
            this.Column2,
            this.Column3,
            this.Column11,
            this.Column15,
            this.Column16,
            this.Column10,
            this.Column5,
            this.Column7,
            this.Column6,
            this.Column9});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 33);
            this.dgvList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidth = 37;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.ShowLineNo = true;
            this.dgvList.Size = new System.Drawing.Size(884, 486);
            this.dgvList.TabIndex = 1;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridView1_CellContentClick);
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridView1_CellDoubleClick);
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MKCode";
            this.Column4.HeaderText = "模块编号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "BatCnt";
            this.Column17.HeaderText = "电芯数量";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 78;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "AsbCnt";
            this.Column18.HeaderText = "插装次数";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 78;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Code";
            this.Column1.HeaderText = "测试批次";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "StateView";
            this.Column8.HeaderText = "测试状态";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 78;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "OperatorName";
            this.Column2.HeaderText = "测试人";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 68;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "StartTime";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "开始时间";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "EndTime";
            this.Column11.HeaderText = "结束时间";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "OrderNo";
            this.Column15.HeaderText = "生产计划";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "PactCode";
            this.Column16.HeaderText = "生产任务单";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Spec";
            this.Column10.HeaderText = "电芯规格分类";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 110;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ClassName";
            this.Column5.HeaderText = "电芯规格";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 88;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "GongYiTypeName";
            this.Column7.HeaderText = "工艺类型";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 78;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "SendMES";
            this.Column6.HeaderText = "上传MES";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "";
            this.Column9.MinimumWidth = 2;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 2;
            // 
            // frmMKList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 519);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMKList";
            this.ShowIcon = false;
            this.Text = "分选批次列表";
            this.Load += new System.EventHandler(this.frmPfList_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private MyControl.MyDataGridView dgvList;
        private System.Windows.Forms.ToolStripDropDownButton tslTitle;
        private System.Windows.Forms.ToolStripComboBox tsCombox;
        private System.Windows.Forms.ToolStripLabel tlsTesteTime;
        private System.Windows.Forms.ToolStripButton tsbOutputExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}