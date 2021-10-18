namespace AutoAssign.DataM
{
    partial class frmMKDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvList = new MyControl.MyDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbTestCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAsbcnt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBatCnt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMKCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(956, 617);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8,
            this.Column2,
            this.Column1,
            this.Column15,
            this.Column13,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.Column14,
            this.Column3,
            this.dataGridViewTextBoxColumn9});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 47);
            this.dgvList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.ShowLineNo = true;
            this.dgvList.Size = new System.Drawing.Size(956, 570);
            this.dgvList.TabIndex = 249;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbTestCode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbAsbcnt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbBatCnt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbMKCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 41);
            this.panel1.TabIndex = 0;
            // 
            // tbTestCode
            // 
            this.tbTestCode.BackColor = System.Drawing.Color.White;
            this.tbTestCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTestCode.Location = new System.Drawing.Point(531, 11);
            this.tbTestCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbTestCode.Name = "tbTestCode";
            this.tbTestCode.ReadOnly = true;
            this.tbTestCode.Size = new System.Drawing.Size(119, 21);
            this.tbTestCode.TabIndex = 247;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(474, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 248;
            this.label4.Text = "测试批次";
            // 
            // tbAsbcnt
            // 
            this.tbAsbcnt.BackColor = System.Drawing.Color.White;
            this.tbAsbcnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAsbcnt.Location = new System.Drawing.Point(405, 11);
            this.tbAsbcnt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbAsbcnt.Name = "tbAsbcnt";
            this.tbAsbcnt.ReadOnly = true;
            this.tbAsbcnt.Size = new System.Drawing.Size(65, 21);
            this.tbAsbcnt.TabIndex = 245;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 246;
            this.label3.Text = "插装次数";
            // 
            // tbBatCnt
            // 
            this.tbBatCnt.BackColor = System.Drawing.Color.White;
            this.tbBatCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBatCnt.Location = new System.Drawing.Point(279, 9);
            this.tbBatCnt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbBatCnt.Name = "tbBatCnt";
            this.tbBatCnt.ReadOnly = true;
            this.tbBatCnt.Size = new System.Drawing.Size(65, 21);
            this.tbBatCnt.TabIndex = 243;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 244;
            this.label1.Text = "电芯数量";
            // 
            // tbMKCode
            // 
            this.tbMKCode.BackColor = System.Drawing.Color.White;
            this.tbMKCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMKCode.Location = new System.Drawing.Point(64, 9);
            this.tbMKCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbMKCode.Name = "tbMKCode";
            this.tbMKCode.ReadOnly = true;
            this.tbMKCode.Size = new System.Drawing.Size(154, 21);
            this.tbMKCode.TabIndex = 241;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 242;
            this.label2.Text = "模块编号";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SN";
            this.dataGridViewTextBoxColumn3.HeaderText = "电芯条码";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MyCode";
            this.dataGridViewTextBoxColumn5.HeaderText = "系统自编号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 88;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Times";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn8.HeaderText = "插装时间";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "AsbSort";
            this.Column2.HeaderText = "第几次插装";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SortID";
            this.Column1.HeaderText = "插装序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "CaoIndex";
            this.Column15.HeaderText = "槽";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 40;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "TestIndex";
            this.Column13.HeaderText = "检测通道";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 78;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "QualityView";
            this.dataGridViewTextBoxColumn4.HeaderText = "品质";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 68;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "V";
            dataGridViewCellStyle2.Format = "#########0.0000";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn6.HeaderText = "电压(V)";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 78;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DianZu";
            dataGridViewCellStyle3.Format = "#########0.0000";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn7.HeaderText = "电阻(mΩ)";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 88;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "NGCase";
            this.Column14.HeaderText = "入槽顺序";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 78;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "times1";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd HH:mm:ss";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "入槽时间";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 2;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 2;
            // 
            // frmMKDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 617);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmMKDetail";
            this.Text = "模块详细信息";
            this.Load += new System.EventHandler(this.frmMKDetail_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbAsbcnt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBatCnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMKCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTestCode;
        private System.Windows.Forms.Label label4;
        private MyControl.MyDataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}