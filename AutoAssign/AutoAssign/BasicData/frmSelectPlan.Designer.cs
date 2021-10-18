namespace AutoAssign.BasicData
{
    partial class frmSelectPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btTrue = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.dgvDetail = new MyControl.MyDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btSearch = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comClient = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPactCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comPactState = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvDetail, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 668);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btTrue);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 626);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 42);
            this.panel1.TabIndex = 0;
            // 
            // btTrue
            // 
            this.btTrue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTrue.Location = new System.Drawing.Point(785, 5);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(75, 30);
            this.btTrue.TabIndex = 1;
            this.btTrue.Text = "确 定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Location = new System.Drawing.Point(886, 4);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 30);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "关 闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckBox,
            this.Column1,
            this.Column17,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column16,
            this.Column12,
            this.Column15,
            this.Column3,
            this.Column4,
            this.Column11,
            this.Column5,
            this.Column13,
            this.Column10,
            this.Column14,
            this.Column2});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 45);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersWidth = 25;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(978, 578);
            this.dgvDetail.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comPactState);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btSearch);
            this.panel2.Controls.Add(this.dtpEnd);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dtpStart);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.comClient);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbPactCode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 42);
            this.panel2.TabIndex = 2;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(811, 9);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 28);
            this.btSearch.TabIndex = 12;
            this.btSearch.Text = "搜索";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(192, 12);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(103, 21);
            this.dtpEnd.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "至";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(67, 12);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(100, 21);
            this.dtpStart.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "下单日期";
            // 
            // comClient
            // 
            this.comClient.FormattingEnabled = true;
            this.comClient.Location = new System.Drawing.Point(535, 13);
            this.comClient.Name = "comClient";
            this.comClient.Size = new System.Drawing.Size(76, 20);
            this.comClient.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(476, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "关联客户";
            // 
            // tbPactCode
            // 
            this.tbPactCode.Location = new System.Drawing.Point(358, 12);
            this.tbPactCode.Name = "tbPactCode";
            this.tbPactCode.Size = new System.Drawing.Size(112, 21);
            this.tbPactCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "任务单号";
            // 
            // colCheckBox
            // 
            this.colCheckBox.Frozen = true;
            this.colCheckBox.HeaderText = "";
            this.colCheckBox.Name = "colCheckBox";
            this.colCheckBox.Width = 35;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PactCode";
            this.Column1.HeaderText = "任务单号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "FxRatio";
            this.Column17.HeaderText = "收料盒比例";
            this.Column17.Name = "Column17";
            this.Column17.Width = 90;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "PlanQty";
            this.Column6.HeaderText = "模块总数";
            this.Column6.Name = "Column6";
            this.Column6.Width = 78;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "RemainQty";
            this.Column7.HeaderText = "剩余模块数";
            this.Column7.Name = "Column7";
            this.Column7.Width = 98;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "DianXinVirCode";
            this.Column8.HeaderText = "电芯种类";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "DianXinBzq";
            this.Column9.HeaderText = "电芯规格";
            this.Column9.Name = "Column9";
            this.Column9.Width = 78;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "GUID";
            this.Column16.HeaderText = "生产计划单";
            this.Column16.Name = "Column16";
            this.Column16.Width = 88;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "CompeletedStateView";
            this.Column12.HeaderText = "任务单状态";
            this.Column12.Name = "Column12";
            this.Column12.Width = 88;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "CreateTime";
            dataGridViewCellStyle21.Format = "yyyy-MM-dd HH:mm";
            this.Column15.DefaultCellStyle = dataGridViewCellStyle21;
            this.Column15.HeaderText = "下单时间";
            this.Column15.Name = "Column15";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ClientVirCode";
            this.Column3.HeaderText = "关联客户";
            this.Column3.Name = "Column3";
            this.Column3.Width = 78;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "FactoryVirCode";
            this.Column4.HeaderText = "厂商";
            this.Column4.Name = "Column4";
            this.Column4.Width = 58;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "DeliveryDate";
            dataGridViewCellStyle22.Format = "yyyy-MM-dd";
            this.Column11.DefaultCellStyle = dataGridViewCellStyle22;
            this.Column11.HeaderText = "交货期";
            this.Column11.Name = "Column11";
            this.Column11.Width = 88;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ChengPinBOMSpec";
            this.Column5.HeaderText = "成品BOM结构";
            this.Column5.Name = "Column5";
            this.Column5.Width = 110;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "ChengPinBOMVersion";
            this.Column13.HeaderText = "版本号";
            this.Column13.Name = "Column13";
            this.Column13.Width = 68;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "MkBOMSpec";
            this.Column10.HeaderText = "模块BOM结构";
            this.Column10.Name = "Column10";
            this.Column10.Width = 110;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "MkBOMVersion";
            this.Column14.HeaderText = "版本号";
            this.Column14.Name = "Column14";
            this.Column14.Width = 68;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.MinimumWidth = 2;
            this.Column2.Name = "Column2";
            this.Column2.Width = 2;
            // 
            // comPactState
            // 
            this.comPactState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPactState.FormattingEnabled = true;
            this.comPactState.Location = new System.Drawing.Point(686, 13);
            this.comPactState.Name = "comPactState";
            this.comPactState.Size = new System.Drawing.Size(111, 20);
            this.comPactState.TabIndex = 14;
            
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(616, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "任务单状态";
            // 
            // frmSelectPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 668);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSelectPlan";
            this.Text = "选择生产计划";
            this.Load += new System.EventHandler(this.frmBsFWithAllocateInfo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Button btClose;
        private MyControl.MyDataGridView dgvDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPactCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ComboBox comPactState;
        private System.Windows.Forms.Label label3;
    }
}