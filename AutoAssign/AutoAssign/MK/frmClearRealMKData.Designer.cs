namespace AutoAssign.MK
{
    partial class frmClearRealMKData
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbTestCode = new System.Windows.Forms.TextBox();
            this.tbMkCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCreateTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAsbCnt = new System.Windows.Forms.TextBox();
            this.tbBatCnt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPlcData = new System.Windows.Forms.TextBox();
            this.btClear = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "批次编号";
            // 
            // tbTestCode
            // 
            this.tbTestCode.BackColor = System.Drawing.Color.White;
            this.tbTestCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTestCode.Location = new System.Drawing.Point(82, 43);
            this.tbTestCode.Name = "tbTestCode";
            this.tbTestCode.ReadOnly = true;
            this.tbTestCode.Size = new System.Drawing.Size(128, 21);
            this.tbTestCode.TabIndex = 1;
            // 
            // tbMkCode
            // 
            this.tbMkCode.BackColor = System.Drawing.Color.White;
            this.tbMkCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMkCode.Location = new System.Drawing.Point(275, 43);
            this.tbMkCode.Name = "tbMkCode";
            this.tbMkCode.ReadOnly = true;
            this.tbMkCode.Size = new System.Drawing.Size(186, 21);
            this.tbMkCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "模块编号";
            // 
            // tbCreateTime
            // 
            this.tbCreateTime.BackColor = System.Drawing.Color.White;
            this.tbCreateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCreateTime.Location = new System.Drawing.Point(82, 69);
            this.tbCreateTime.Name = "tbCreateTime";
            this.tbCreateTime.ReadOnly = true;
            this.tbCreateTime.Size = new System.Drawing.Size(128, 21);
            this.tbCreateTime.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "创建时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "插装次数";
            // 
            // tbAsbCnt
            // 
            this.tbAsbCnt.BackColor = System.Drawing.Color.White;
            this.tbAsbCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAsbCnt.Location = new System.Drawing.Point(275, 69);
            this.tbAsbCnt.Name = "tbAsbCnt";
            this.tbAsbCnt.ReadOnly = true;
            this.tbAsbCnt.Size = new System.Drawing.Size(62, 21);
            this.tbAsbCnt.TabIndex = 7;
            // 
            // tbBatCnt
            // 
            this.tbBatCnt.BackColor = System.Drawing.Color.White;
            this.tbBatCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBatCnt.Location = new System.Drawing.Point(399, 69);
            this.tbBatCnt.Name = "tbBatCnt";
            this.tbBatCnt.ReadOnly = true;
            this.tbBatCnt.Size = new System.Drawing.Size(62, 21);
            this.tbBatCnt.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "电芯数量";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Maroon;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(508, 33);
            this.label6.TabIndex = 10;
            this.label6.Text = "自动插装数据清除";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "PLC数据";
            // 
            // tbPlcData
            // 
            this.tbPlcData.BackColor = System.Drawing.Color.White;
            this.tbPlcData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPlcData.Location = new System.Drawing.Point(82, 96);
            this.tbPlcData.Multiline = true;
            this.tbPlcData.Name = "tbPlcData";
            this.tbPlcData.ReadOnly = true;
            this.tbPlcData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbPlcData.Size = new System.Drawing.Size(379, 94);
            this.tbPlcData.TabIndex = 12;
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(183, 207);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(110, 39);
            this.btClear.TabIndex = 13;
            this.btClear.Text = "确认清除数据";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("楷体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(114, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(311, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "提示：以上数据不清除，无法开启新的测试";
            // 
            // frmClearRealMKData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 276);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.tbPlcData);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbBatCnt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbAsbCnt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCreateTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMkCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTestCode);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClearRealMKData";
            this.Text = "清楚正在插装的电芯数据";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTestCode;
        private System.Windows.Forms.TextBox tbMkCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCreateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAsbCnt;
        private System.Windows.Forms.TextBox tbBatCnt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPlcData;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Label label8;
    }
}