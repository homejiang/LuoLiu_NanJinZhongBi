namespace BasicData.ProcessMacs
{
    partial class frmMBdownEditSelTime
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpTimeStart1 = new System.Windows.Forms.DateTimePicker();
            this.dtpDateStart1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "异常发生时间";
            // 
            // dtpTimeStart
            // 
            this.dtpTimeStart.CustomFormat = "HH:mm";
            this.dtpTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeStart.Location = new System.Drawing.Point(283, 11);
            this.dtpTimeStart.Name = "dtpTimeStart";
            this.dtpTimeStart.ShowUpDown = true;
            this.dtpTimeStart.Size = new System.Drawing.Size(78, 27);
            this.dtpTimeStart.TabIndex = 4;
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.CustomFormat = "yyyy-MM-dd";
            this.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateStart.Location = new System.Drawing.Point(130, 11);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.ShowCheckBox = true;
            this.dtpDateStart.Size = new System.Drawing.Size(138, 27);
            this.dtpDateStart.TabIndex = 3;
            // 
            // dtpTimeEnd
            // 
            this.dtpTimeEnd.CustomFormat = "HH:mm";
            this.dtpTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeEnd.Location = new System.Drawing.Point(283, 110);
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            this.dtpTimeEnd.ShowUpDown = true;
            this.dtpTimeEnd.Size = new System.Drawing.Size(78, 27);
            this.dtpTimeEnd.TabIndex = 7;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateEnd.Location = new System.Drawing.Point(130, 110);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.ShowCheckBox = true;
            this.dtpDateEnd.Size = new System.Drawing.Size(138, 27);
            this.dtpDateEnd.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "开始维修时间";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpTimeStart1
            // 
            this.dtpTimeStart1.CustomFormat = "HH:mm";
            this.dtpTimeStart1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeStart1.Location = new System.Drawing.Point(283, 61);
            this.dtpTimeStart1.Name = "dtpTimeStart1";
            this.dtpTimeStart1.ShowUpDown = true;
            this.dtpTimeStart1.Size = new System.Drawing.Size(78, 27);
            this.dtpTimeStart1.TabIndex = 11;
            // 
            // dtpDateStart1
            // 
            this.dtpDateStart1.CustomFormat = "yyyy-MM-dd";
            this.dtpDateStart1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateStart1.Location = new System.Drawing.Point(130, 61);
            this.dtpDateStart1.Name = "dtpDateStart1";
            this.dtpDateStart1.ShowCheckBox = true;
            this.dtpDateStart1.Size = new System.Drawing.Size(138, 27);
            this.dtpDateStart1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "异常结束时间";
            // 
            // frmMBdownEditSelTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 201);
            this.Controls.Add(this.dtpTimeStart1);
            this.Controls.Add(this.dtpDateStart1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpTimeEnd);
            this.Controls.Add(this.dtpDateEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTimeStart);
            this.Controls.Add(this.dtpDateStart);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMBdownEditSelTime";
            this.ShowIcon = false;
            this.Text = "选择设备异常时间段";
            this.Load += new System.EventHandler(this.frmMBdownEditSelTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTimeStart;
        private System.Windows.Forms.DateTimePicker dtpDateStart;
        private System.Windows.Forms.DateTimePicker dtpTimeEnd;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpTimeStart1;
        private System.Windows.Forms.DateTimePicker dtpDateStart1;
        private System.Windows.Forms.Label label3;
    }
}