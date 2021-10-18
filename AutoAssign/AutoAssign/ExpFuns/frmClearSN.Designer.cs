namespace AutoAssign.ExpFuns
{
    partial class frmClearSN
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
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panContainer = new System.Windows.Forms.Panel();
            this.labProgress = new System.Windows.Forms.Label();
            this.labNotice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(88)))), ((int)(((byte)(136)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 48);
            this.label1.TabIndex = 8;
            this.label1.Text = "为确保系统运行速度，请适量清除数据。";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "数据保留范围";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown1.Location = new System.Drawing.Point(155, 65);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(90, 35);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown1_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "天内";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 36);
            this.button1.TabIndex = 12;
            this.button1.Text = "确认清除";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panContainer
            // 
            this.panContainer.BackColor = System.Drawing.Color.Maroon;
            this.panContainer.Controls.Add(this.labProgress);
            this.panContainer.Location = new System.Drawing.Point(0, 176);
            this.panContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(405, 17);
            this.panContainer.TabIndex = 13;
            this.panContainer.Visible = false;
            // 
            // labProgress
            // 
            this.labProgress.BackColor = System.Drawing.Color.Lime;
            this.labProgress.Dock = System.Windows.Forms.DockStyle.Left;
            this.labProgress.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labProgress.Location = new System.Drawing.Point(0, 0);
            this.labProgress.Name = "labProgress";
            this.labProgress.Size = new System.Drawing.Size(28, 17);
            this.labProgress.TabIndex = 0;
            this.labProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labNotice
            // 
            this.labNotice.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labNotice.ForeColor = System.Drawing.Color.Gray;
            this.labNotice.Location = new System.Drawing.Point(76, 103);
            this.labNotice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labNotice.Name = "labNotice";
            this.labNotice.Size = new System.Drawing.Size(251, 16);
            this.labNotice.TabIndex = 14;
            this.labNotice.Text = "2019年03月20日前的都清除掉";
            this.labNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmClearSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 191);
            this.Controls.Add(this.labNotice);
            this.Controls.Add(this.panContainer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClearSN";
            this.Text = "电芯数据清理";
            this.Load += new System.EventHandler(this.frmClearSN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panContainer;
        private System.Windows.Forms.Label labProgress;
        private System.Windows.Forms.Label labNotice;
    }
}