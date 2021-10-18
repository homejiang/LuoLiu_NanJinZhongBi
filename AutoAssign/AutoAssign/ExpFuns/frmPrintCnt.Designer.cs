namespace AutoAssign.ExpFuns
{
    partial class frmPrintCnt
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
            this.numValue = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.chkAutoPrint = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "打印份数";
            // 
            // numValue
            // 
            this.numValue.Location = new System.Drawing.Point(124, 54);
            this.numValue.Name = "numValue";
            this.numValue.Size = new System.Drawing.Size(93, 27);
            this.numValue.TabIndex = 1;
            this.numValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkAutoPrint
            // 
            this.chkAutoPrint.AutoSize = true;
            this.chkAutoPrint.Location = new System.Drawing.Point(52, 16);
            this.chkAutoPrint.Name = "chkAutoPrint";
            this.chkAutoPrint.Size = new System.Drawing.Size(99, 22);
            this.chkAutoPrint.TabIndex = 3;
            this.chkAutoPrint.Text = "自动打印";
            this.chkAutoPrint.UseVisualStyleBackColor = true;
            this.chkAutoPrint.CheckedChanged += new System.EventHandler(this.chkAutoPrint_CheckedChanged);
            // 
            // frmPrintCnt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 167);
            this.Controls.Add(this.chkAutoPrint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numValue);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintCnt";
            this.Text = "设置托盘打印份数";
            this.Load += new System.EventHandler(this.frmPrintCnt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numValue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkAutoPrint;
    }
}