namespace LuoLiuDianHan.Communication
{
    partial class frmDebug4Pf
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
            this.button1 = new System.Windows.Forms.Button();
            this.numBc = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.numReadDoing = new System.Windows.Forms.NumericUpDown();
            this.numPIndex = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.numLCnt = new System.Windows.Forms.NumericUpDown();
            this.numRCnt = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numBc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReadDoing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRCnt)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "补偿赋值";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numBc
            // 
            this.numBc.Location = new System.Drawing.Point(70, 74);
            this.numBc.Name = "numBc";
            this.numBc.Size = new System.Drawing.Size(120, 21);
            this.numBc.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(415, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "写入ReadDoing";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numReadDoing
            // 
            this.numReadDoing.Location = new System.Drawing.Point(70, 31);
            this.numReadDoing.Name = "numReadDoing";
            this.numReadDoing.Size = new System.Drawing.Size(92, 21);
            this.numReadDoing.TabIndex = 3;
            // 
            // numPIndex
            // 
            this.numPIndex.Location = new System.Drawing.Point(70, 118);
            this.numPIndex.Maximum = new decimal(new int[] {
            9000000,
            0,
            0,
            0});
            this.numPIndex.Minimum = new decimal(new int[] {
            9000000,
            0,
            0,
            -2147483648});
            this.numPIndex.Name = "numPIndex";
            this.numPIndex.Size = new System.Drawing.Size(120, 21);
            this.numPIndex.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(212, 118);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "PIndex";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // numLCnt
            // 
            this.numLCnt.Location = new System.Drawing.Point(179, 31);
            this.numLCnt.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLCnt.Name = "numLCnt";
            this.numLCnt.Size = new System.Drawing.Size(92, 21);
            this.numLCnt.TabIndex = 6;
            this.numLCnt.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // numRCnt
            // 
            this.numRCnt.Location = new System.Drawing.Point(291, 31);
            this.numRCnt.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRCnt.Name = "numRCnt";
            this.numRCnt.Size = new System.Drawing.Size(92, 21);
            this.numRCnt.TabIndex = 7;
            this.numRCnt.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(581, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "读取";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(325, 118);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "读取";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // frmDebug4Pf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 404);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.numRCnt);
            this.Controls.Add(this.numLCnt);
            this.Controls.Add(this.numPIndex);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.numReadDoing);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.numBc);
            this.Controls.Add(this.button1);
            this.Name = "frmDebug4Pf";
            this.Text = "frmDebug4Pf";
            ((System.ComponentModel.ISupportInitialize)(this.numBc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReadDoing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRCnt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numBc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numReadDoing;
        private System.Windows.Forms.NumericUpDown numPIndex;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numLCnt;
        private System.Windows.Forms.NumericUpDown numRCnt;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}