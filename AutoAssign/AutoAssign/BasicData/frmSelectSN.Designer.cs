namespace AutoAssign.BasicData
{
    partial class frmSelectSN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btTrue = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.dgvDetail = new MyControl.MyDataGridView();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btUnSel = new System.Windows.Forms.Button();
            this.btSeled = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPici = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labNoticeCliear = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.labNoticeCliear);
            this.panel1.Controls.Add(this.button1);
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
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckBox,
            this.Column1,
            this.Column17,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column10});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 42);
            this.dgvDetail.Margin = new System.Windows.Forms.Padding(0);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersWidth = 25;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.ShowLineNo = true;
            this.dgvDetail.Size = new System.Drawing.Size(984, 584);
            this.dgvDetail.TabIndex = 1;
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
            this.Column1.DataPropertyName = "PatchCode";
            this.Column1.HeaderText = "导入批次";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 110;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "ItemCode";
            this.Column17.HeaderText = "电芯编号";
            this.Column17.Name = "Column17";
            this.Column17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column17.Width = 220;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Capacity";
            dataGridViewCellStyle9.Format = "#########0.####";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column6.HeaderText = "电容";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 78;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Resistance";
            dataGridViewCellStyle10.Format = "#########0.####";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column7.HeaderText = "电阻";
            this.Column7.Name = "Column7";
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 98;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Voltage";
            dataGridViewCellStyle11.Format = "#########0.####";
            this.Column8.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column8.HeaderText = "电压";
            this.Column8.Name = "Column8";
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "InsertTimes";
            dataGridViewCellStyle12.Format = "yyyy-MM-dd HH:mm:ss";
            this.Column10.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column10.HeaderText = "导入时间";
            this.Column10.Name = "Column10";
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 110;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btUnSel);
            this.panel2.Controls.Add(this.btSeled);
            this.panel2.Controls.Add(this.btSearch);
            this.panel2.Controls.Add(this.dtpEnd);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dtpStart);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbPici);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 42);
            this.panel2.TabIndex = 2;
            // 
            // btUnSel
            // 
            this.btUnSel.Location = new System.Drawing.Point(818, 7);
            this.btUnSel.Name = "btUnSel";
            this.btUnSel.Size = new System.Drawing.Size(79, 28);
            this.btUnSel.TabIndex = 14;
            this.btUnSel.Text = "设置不选";
            this.btUnSel.UseVisualStyleBackColor = true;
            this.btUnSel.Click += new System.EventHandler(this.btUnSel_Click);
            // 
            // btSeled
            // 
            this.btSeled.Location = new System.Drawing.Point(723, 8);
            this.btSeled.Name = "btSeled";
            this.btSeled.Size = new System.Drawing.Size(79, 28);
            this.btSeled.TabIndex = 13;
            this.btSeled.Text = "设置选中";
            this.btSeled.UseVisualStyleBackColor = true;
            this.btSeled.Click += new System.EventHandler(this.btSeled_Click);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(610, 9);
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
            this.dtpEnd.ShowCheckBox = true;
            this.dtpEnd.Size = new System.Drawing.Size(125, 21);
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
            this.label4.Text = "导入时间";
            // 
            // tbPici
            // 
            this.tbPici.Location = new System.Drawing.Point(380, 12);
            this.tbPici.Name = "tbPici";
            this.tbPici.Size = new System.Drawing.Size(206, 21);
            this.tbPici.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "导入批次";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(12, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "清理本地电芯";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labNoticeCliear
            // 
            this.labNoticeCliear.AutoSize = true;
            this.labNoticeCliear.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labNoticeCliear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labNoticeCliear.Location = new System.Drawing.Point(129, 18);
            this.labNoticeCliear.Name = "labNoticeCliear";
            this.labNoticeCliear.Size = new System.Drawing.Size(397, 15);
            this.labNoticeCliear.TabIndex = 8;
            this.labNoticeCliear.Text = "请及时清除本地不用的电芯，否则系统查询电芯效率会降低";
            // 
            // frmSelectSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 668);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSelectSN";
            this.Text = "选择要导入的电芯";
            this.Load += new System.EventHandler(this.frmBsFWithAllocateInfo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox tbPici;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Button btUnSel;
        private System.Windows.Forms.Button btSeled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Label labNoticeCliear;
        private System.Windows.Forms.Button button1;
    }
}