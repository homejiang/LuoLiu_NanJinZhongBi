namespace Common.UserControls
{
    partial class ucStatistic1
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvStatisticPlan = new MyControl.MyDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labStatisticTimes = new System.Windows.Forms.Label();
            this.tbStatisticTimes = new System.Windows.Forms.TextBox();
            this.linkStatisticTimes = new System.Windows.Forms.LinkLabel();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatisticPlan)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 258F));
            this.tableLayoutPanel2.Controls.Add(this.label9, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvStatisticPlan, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1024, 150);
            this.tableLayoutPanel2.TabIndex = 220;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(766, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(258, 21);
            this.label9.TabIndex = 220;
            this.label9.Text = "生产统计";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(763, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.tableLayoutPanel2.SetRowSpan(this.label8, 2);
            this.label8.Size = new System.Drawing.Size(3, 150);
            this.label8.TabIndex = 219;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(763, 21);
            this.label7.TabIndex = 218;
            this.label7.Text = "订单完成量实时统计";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvStatisticPlan
            // 
            this.dgvStatisticPlan.AllowUserToAddRows = false;
            this.dgvStatisticPlan.AllowUserToDeleteRows = false;
            this.dgvStatisticPlan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvStatisticPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatisticPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvStatisticPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatisticPlan.Location = new System.Drawing.Point(0, 21);
            this.dgvStatisticPlan.Margin = new System.Windows.Forms.Padding(0);
            this.dgvStatisticPlan.Name = "dgvStatisticPlan";
            this.dgvStatisticPlan.ReadOnly = true;
            this.dgvStatisticPlan.RowHeadersWidth = 25;
            this.dgvStatisticPlan.RowTemplate.Height = 23;
            this.dgvStatisticPlan.ShowLineNo = true;
            this.dgvStatisticPlan.Size = new System.Drawing.Size(763, 129);
            this.dgvStatisticPlan.TabIndex = 221;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labStatisticTimes);
            this.panel3.Controls.Add(this.tbStatisticTimes);
            this.panel3.Controls.Add(this.linkStatisticTimes);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(766, 21);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(258, 129);
            this.panel3.TabIndex = 222;
            // 
            // labStatisticTimes
            // 
            this.labStatisticTimes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labStatisticTimes.Font = new System.Drawing.Font("微软雅黑 Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labStatisticTimes.Location = new System.Drawing.Point(0, 87);
            this.labStatisticTimes.Name = "labStatisticTimes";
            this.labStatisticTimes.Size = new System.Drawing.Size(258, 42);
            this.labStatisticTimes.TabIndex = 2;
            this.labStatisticTimes.Text = "已完成10000个，合格率99.9%";
            this.labStatisticTimes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbStatisticTimes
            // 
            this.tbStatisticTimes.Font = new System.Drawing.Font("黑体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbStatisticTimes.Location = new System.Drawing.Point(5, 25);
            this.tbStatisticTimes.Multiline = true;
            this.tbStatisticTimes.Name = "tbStatisticTimes";
            this.tbStatisticTimes.Size = new System.Drawing.Size(247, 59);
            this.tbStatisticTimes.TabIndex = 1;
            this.tbStatisticTimes.Text = "2019-09-09 08:30\r\n至\r\n2019-09-09 20:30\r\n";
            // 
            // linkStatisticTimes
            // 
            this.linkStatisticTimes.AutoSize = true;
            this.linkStatisticTimes.Location = new System.Drawing.Point(3, 7);
            this.linkStatisticTimes.Name = "linkStatisticTimes";
            this.linkStatisticTimes.Size = new System.Drawing.Size(53, 12);
            this.linkStatisticTimes.TabIndex = 0;
            this.linkStatisticTimes.TabStop = true;
            this.linkStatisticTimes.Text = "统计时间";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "生产计划";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 340;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "当前工序BOM";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "计划数量";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 82;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "已完成数量";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 95;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "剩余数量";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 82;
            // 
            // ucStatistic1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "ucStatistic1";
            this.Size = new System.Drawing.Size(1024, 150);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatisticPlan)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private MyControl.MyDataGridView dgvStatisticPlan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labStatisticTimes;
        private System.Windows.Forms.TextBox tbStatisticTimes;
        private System.Windows.Forms.LinkLabel linkStatisticTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}
