namespace AutoAssign.Printer
{
    partial class frmPrinterSetting
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
            this.comQyPrinters = new System.Windows.Forms.ComboBox();
            this.btTrue = new System.Windows.Forms.Button();
            this.chkAutoPrint = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numQRSize = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numWordsSet_Left = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numWordsSet_Top = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numQRSet_Left = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numQRSet_Top = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQRSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWordsSet_Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWordsSet_Top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQRSet_Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQRSet_Top)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "标签打印机";
            // 
            // comQyPrinters
            // 
            this.comQyPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comQyPrinters.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comQyPrinters.FormattingEnabled = true;
            this.comQyPrinters.Location = new System.Drawing.Point(89, 18);
            this.comQyPrinters.Margin = new System.Windows.Forms.Padding(4);
            this.comQyPrinters.Name = "comQyPrinters";
            this.comQyPrinters.Size = new System.Drawing.Size(296, 21);
            this.comQyPrinters.TabIndex = 19;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(124, 304);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(142, 40);
            this.btTrue.TabIndex = 34;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // chkAutoPrint
            // 
            this.chkAutoPrint.AutoSize = true;
            this.chkAutoPrint.Location = new System.Drawing.Point(47, 280);
            this.chkAutoPrint.Name = "chkAutoPrint";
            this.chkAutoPrint.Size = new System.Drawing.Size(86, 19);
            this.chkAutoPrint.TabIndex = 35;
            this.chkAutoPrint.Text = "自动打印";
            this.chkAutoPrint.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.numFontSize);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numQRSize);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numWordsSet_Left);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numWordsSet_Top);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numQRSet_Left);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numQRSet_Top);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(47, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 210);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标签位置调整";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(225, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 15);
            this.label12.TabIndex = 26;
            this.label12.Text = "像素";
            // 
            // numFontSize
            // 
            this.numFontSize.Location = new System.Drawing.Point(137, 173);
            this.numFontSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(82, 24);
            this.numFontSize.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(65, 177);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 15);
            this.label13.TabIndex = 24;
            this.label13.Text = "字体大小";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(225, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "像素";
            // 
            // numQRSize
            // 
            this.numQRSize.Location = new System.Drawing.Point(137, 142);
            this.numQRSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQRSize.Name = "numQRSize";
            this.numQRSize.Size = new System.Drawing.Size(82, 24);
            this.numQRSize.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(49, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "二维码尺寸";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(225, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "像素";
            // 
            // numWordsSet_Left
            // 
            this.numWordsSet_Left.Location = new System.Drawing.Point(137, 112);
            this.numWordsSet_Left.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWordsSet_Left.Name = "numWordsSet_Left";
            this.numWordsSet_Left.Size = new System.Drawing.Size(82, 24);
            this.numWordsSet_Left.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "字符前面距离";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(225, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "像素";
            // 
            // numWordsSet_Top
            // 
            this.numWordsSet_Top.Location = new System.Drawing.Point(137, 82);
            this.numWordsSet_Top.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWordsSet_Top.Name = "numWordsSet_Top";
            this.numWordsSet_Top.Size = new System.Drawing.Size(82, 24);
            this.numWordsSet_Top.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "字符顶部距离";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "像素";
            // 
            // numQRSet_Left
            // 
            this.numQRSet_Left.Location = new System.Drawing.Point(137, 52);
            this.numQRSet_Left.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQRSet_Left.Name = "numQRSet_Left";
            this.numQRSet_Left.Size = new System.Drawing.Size(82, 24);
            this.numQRSet_Left.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "二维码前面距离";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "像素";
            // 
            // numQRSet_Top
            // 
            this.numQRSet_Top.Location = new System.Drawing.Point(137, 22);
            this.numQRSet_Top.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQRSet_Top.Name = "numQRSet_Top";
            this.numQRSet_Top.Size = new System.Drawing.Size(82, 24);
            this.numQRSet_Top.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "二维码顶部距离";
            // 
            // frmPrinterSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 357);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkAutoPrint);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.comQyPrinters);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrinterSetting";
            this.Text = "打印设置";
            this.Load += new System.EventHandler(this.frmPrinterSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQRSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWordsSet_Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWordsSet_Top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQRSet_Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQRSet_Top)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comQyPrinters;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.CheckBox chkAutoPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numQRSet_Top;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numQRSet_Left;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numWordsSet_Left;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numWordsSet_Top;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numFontSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numQRSize;
        private System.Windows.Forms.Label label11;
    }
}