namespace AutoAssign.BasicData
{
    partial class frmClearSN
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
            this.dgvDetail = new MyControl.MyDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btRemove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btUnSel = new System.Windows.Forms.Button();
            this.btSeled = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPici = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvDetail, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 661);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.dgvDetail.Location = new System.Drawing.Point(0, 80);
            this.dgvDetail.Margin = new System.Windows.Forms.Padding(0);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersWidth = 40;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.ShowLineNo = true;
            this.dgvDetail.Size = new System.Drawing.Size(984, 581);
            this.dgvDetail.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btRemove);
            this.panel2.Controls.Add(this.label2);
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
            this.panel2.Size = new System.Drawing.Size(984, 80);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(875, 40);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(98, 28);
            this.btRemove.TabIndex = 16;
            this.btRemove.Text = "删除选中数据";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Maroon;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(984, 37);
            this.label2.TabIndex = 15;
            this.label2.Text = "清除本地不用的电芯";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btUnSel
            // 
            this.btUnSel.Location = new System.Drawing.Point(747, 40);
            this.btUnSel.Name = "btUnSel";
            this.btUnSel.Size = new System.Drawing.Size(79, 28);
            this.btUnSel.TabIndex = 14;
            this.btUnSel.Text = "设置不选";
            this.btUnSel.UseVisualStyleBackColor = true;
            this.btUnSel.Click += new System.EventHandler(this.btUnSel_Click);
            // 
            // btSeled
            // 
            this.btSeled.Location = new System.Drawing.Point(657, 41);
            this.btSeled.Name = "btSeled";
            this.btSeled.Size = new System.Drawing.Size(79, 28);
            this.btSeled.TabIndex = 13;
            this.btSeled.Text = "设置选中";
            this.btSeled.UseVisualStyleBackColor = true;
            this.btSeled.Click += new System.EventHandler(this.btSeled_Click);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(566, 42);
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
            this.dtpEnd.Location = new System.Drawing.Point(217, 45);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(100, 21);
            this.dtpEnd.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "至";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(67, 45);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowCheckBox = true;
            this.dtpStart.Size = new System.Drawing.Size(120, 21);
            this.dtpStart.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "导入时间";
            // 
            // tbPici
            // 
            this.tbPici.Location = new System.Drawing.Point(380, 45);
            this.tbPici.Name = "tbPici";
            this.tbPici.Size = new System.Drawing.Size(170, 21);
            this.tbPici.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "导入批次";
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
            this.Column1.DataPropertyName = "InputCode";
            this.Column1.HeaderText = "导入批次";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 110;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "SN";
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
            this.Column7.DataPropertyName = "R";
            dataGridViewCellStyle10.Format = "#########0.####";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column7.HeaderText = "电阻";
            this.Column7.Name = "Column7";
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 98;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "V";
            dataGridViewCellStyle11.Format = "#########0.####";
            this.Column8.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column8.HeaderText = "电压";
            this.Column8.Name = "Column8";
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Times";
            dataGridViewCellStyle12.Format = "yyyy-MM-dd HH:mm:ss";
            this.Column10.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column10.HeaderText = "导入时间";
            this.Column10.Name = "Column10";
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 130;
            // 
            // frmClearSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmClearSN";
            this.Text = "选择要导入的电芯";
            this.Load += new System.EventHandler(this.frmBsFWithAllocateInfo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}