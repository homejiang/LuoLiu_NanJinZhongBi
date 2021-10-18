namespace AutoAssign.BasicData
{
    partial class frmSelectMode
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.radNet1 = new System.Windows.Forms.RadioButton();
            this.radNet0 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radSN0 = new System.Windows.Forms.RadioButton();
            this.radSN1 = new System.Windows.Forms.RadioButton();
            this.btTrue = new System.Windows.Forms.Button();
            this.labErr = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radNet0);
            this.panel1.Controls.Add(this.radNet1);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 50);
            this.panel1.TabIndex = 0;
            // 
            // radNet1
            // 
            this.radNet1.AutoSize = true;
            this.radNet1.Location = new System.Drawing.Point(24, 13);
            this.radNet1.Name = "radNet1";
            this.radNet1.Size = new System.Drawing.Size(87, 24);
            this.radNet1.TabIndex = 0;
            this.radNet1.TabStop = true;
            this.radNet1.Text = "网络版";
            this.radNet1.UseVisualStyleBackColor = true;
            // 
            // radNet0
            // 
            this.radNet0.AutoSize = true;
            this.radNet0.Location = new System.Drawing.Point(117, 13);
            this.radNet0.Name = "radNet0";
            this.radNet0.Size = new System.Drawing.Size(87, 24);
            this.radNet0.TabIndex = 1;
            this.radNet0.TabStop = true;
            this.radNet0.Text = "单机版";
            this.radNet0.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.radSN0);
            this.panel2.Controls.Add(this.radSN1);
            this.panel2.Location = new System.Drawing.Point(247, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 50);
            this.panel2.TabIndex = 1;
            // 
            // radSN0
            // 
            this.radSN0.AutoSize = true;
            this.radSN0.Location = new System.Drawing.Point(101, 13);
            this.radSN0.Name = "radSN0";
            this.radSN0.Size = new System.Drawing.Size(87, 24);
            this.radSN0.TabIndex = 1;
            this.radSN0.TabStop = true;
            this.radSN0.Text = "不扫码";
            this.radSN0.UseVisualStyleBackColor = true;
            // 
            // radSN1
            // 
            this.radSN1.AutoSize = true;
            this.radSN1.Location = new System.Drawing.Point(8, 13);
            this.radSN1.Name = "radSN1";
            this.radSN1.Size = new System.Drawing.Size(67, 24);
            this.radSN1.TabIndex = 0;
            this.radSN1.TabStop = true;
            this.radSN1.Text = "扫码";
            this.radSN1.UseVisualStyleBackColor = true;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(171, 85);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(115, 41);
            this.btTrue.TabIndex = 2;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // labErr
            // 
            this.labErr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labErr.ForeColor = System.Drawing.Color.Red;
            this.labErr.Location = new System.Drawing.Point(0, 130);
            this.labErr.Name = "labErr";
            this.labErr.Size = new System.Drawing.Size(465, 27);
            this.labErr.TabIndex = 3;
            this.labErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSelectMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 157);
            this.Controls.Add(this.labErr);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectMode";
            this.Text = "选择测试模式";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radNet0;
        private System.Windows.Forms.RadioButton radNet1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radSN0;
        private System.Windows.Forms.RadioButton radSN1;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Label labErr;
    }
}