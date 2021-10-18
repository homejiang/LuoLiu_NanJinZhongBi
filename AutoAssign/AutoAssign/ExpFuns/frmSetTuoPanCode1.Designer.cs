namespace AutoAssign.ExpFuns
{
    partial class frmSetTuoPanCode1
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
            this.tbMacNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCaoIndex = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.picNext = new System.Windows.Forms.PictureBox();
            this.labDate = new System.Windows.Forms.Label();
            this.picPreDay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreDay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(88)))), ((int)(((byte)(136)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 49);
            this.label1.TabIndex = 8;
            this.label1.Text = "请按规则编辑托盘号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbMacNo
            // 
            this.tbMacNo.Font = new System.Drawing.Font("宋体", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMacNo.Location = new System.Drawing.Point(12, 101);
            this.tbMacNo.Margin = new System.Windows.Forms.Padding(4);
            this.tbMacNo.Name = "tbMacNo";
            this.tbMacNo.ReadOnly = true;
            this.tbMacNo.Size = new System.Drawing.Size(58, 33);
            this.tbMacNo.TabIndex = 9;
            this.tbMacNo.Text = "1";
            this.tbMacNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "机台";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "槽号";
            // 
            // tbCaoIndex
            // 
            this.tbCaoIndex.Font = new System.Drawing.Font("宋体", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCaoIndex.Location = new System.Drawing.Point(88, 101);
            this.tbCaoIndex.Margin = new System.Windows.Forms.Padding(4);
            this.tbCaoIndex.Name = "tbCaoIndex";
            this.tbCaoIndex.ReadOnly = true;
            this.tbCaoIndex.Size = new System.Drawing.Size(58, 33);
            this.tbCaoIndex.TabIndex = 11;
            this.tbCaoIndex.Text = "X";
            this.tbCaoIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "年份";
            // 
            // tbY
            // 
            this.tbY.Font = new System.Drawing.Font("宋体", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbY.Location = new System.Drawing.Point(162, 101);
            this.tbY.Margin = new System.Windows.Forms.Padding(4);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(76, 33);
            this.tbY.TabIndex = 14;
            this.tbY.Text = "X";
            this.tbY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbY.TextChanged += new System.EventHandler(this.tbY_TextChanged);
            // 
            // tbM
            // 
            this.tbM.Font = new System.Drawing.Font("宋体", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbM.Location = new System.Drawing.Point(248, 101);
            this.tbM.Margin = new System.Windows.Forms.Padding(4);
            this.tbM.Name = "tbM";
            this.tbM.Size = new System.Drawing.Size(76, 33);
            this.tbM.TabIndex = 16;
            this.tbM.Text = "X";
            this.tbM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbM.TextChanged += new System.EventHandler(this.tbM_TextChanged);
            this.tbM.Leave += new System.EventHandler(this.tbM_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "月份";
            // 
            // tbD
            // 
            this.tbD.Font = new System.Drawing.Font("宋体", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbD.Location = new System.Drawing.Point(336, 100);
            this.tbD.Margin = new System.Windows.Forms.Padding(4);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(52, 33);
            this.tbD.TabIndex = 0;
            this.tbD.Text = "X";
            this.tbD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbD.TextChanged += new System.EventHandler(this.tbD_TextChanged);
            this.tbD.Leave += new System.EventHandler(this.tbD_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(344, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 23);
            this.label6.TabIndex = 17;
            this.label6.Text = "日";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 45);
            this.button1.TabIndex = 19;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(428, 72);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 23);
            this.label7.TabIndex = 20;
            this.label7.Text = "起始序列号";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(436, 101);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(98, 33);
            this.numericUpDown1.TabIndex = 21;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // picNext
            // 
            this.picNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNext.Image = global::AutoAssign.Properties.Resources.up;
            this.picNext.Location = new System.Drawing.Point(540, 106);
            this.picNext.Name = "picNext";
            this.picNext.Size = new System.Drawing.Size(28, 24);
            this.picNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picNext.TabIndex = 22;
            this.picNext.TabStop = false;
            this.picNext.Click += new System.EventHandler(this.picNext_Click);
            this.picNext.MouseLeave += new System.EventHandler(this.picNext_MouseLeave);
            this.picNext.MouseHover += new System.EventHandler(this.picNext_MouseHover);
            // 
            // labDate
            // 
            this.labDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labDate.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labDate.ForeColor = System.Drawing.Color.Blue;
            this.labDate.Location = new System.Drawing.Point(0, 224);
            this.labDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDate.Name = "labDate";
            this.labDate.Size = new System.Drawing.Size(600, 26);
            this.labDate.TabIndex = 23;
            this.labDate.Text = "当前日期：2019-09-09";
            this.labDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picPreDay
            // 
            this.picPreDay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPreDay.Image = global::AutoAssign.Properties.Resources.down;
            this.picPreDay.Location = new System.Drawing.Point(391, 105);
            this.picPreDay.Name = "picPreDay";
            this.picPreDay.Size = new System.Drawing.Size(28, 24);
            this.picPreDay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPreDay.TabIndex = 24;
            this.picPreDay.TabStop = false;
            this.picPreDay.Click += new System.EventHandler(this.picPreDay_Click);
            this.picPreDay.MouseLeave += new System.EventHandler(this.picPreDay_MouseLeave);
            this.picPreDay.MouseHover += new System.EventHandler(this.picPreDay_MouseHover);
            // 
            // frmSetTuoPanCode1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 250);
            this.Controls.Add(this.picPreDay);
            this.Controls.Add(this.labDate);
            this.Controls.Add(this.picNext);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbM);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCaoIndex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMacNo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetTuoPanCode1";
            this.Text = "设置托盘编号";
            this.Load += new System.EventHandler(this.frmSetTuoPanCode1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMacNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCaoIndex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.PictureBox picNext;
        private System.Windows.Forms.Label labDate;
        private System.Windows.Forms.PictureBox picPreDay;
    }
}