namespace Common
{
    partial class Form6
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
            this.tbByte1 = new System.Windows.Forms.TextBox();
            this.tbByte2 = new System.Windows.Forms.TextBox();
            this.tbByte4 = new System.Windows.Forms.TextBox();
            this.tbByte3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbByte1
            // 
            this.tbByte1.Location = new System.Drawing.Point(39, 34);
            this.tbByte1.Name = "tbByte1";
            this.tbByte1.Size = new System.Drawing.Size(100, 21);
            this.tbByte1.TabIndex = 0;
            // 
            // tbByte2
            // 
            this.tbByte2.Location = new System.Drawing.Point(39, 74);
            this.tbByte2.Name = "tbByte2";
            this.tbByte2.Size = new System.Drawing.Size(100, 21);
            this.tbByte2.TabIndex = 1;
            // 
            // tbByte4
            // 
            this.tbByte4.Location = new System.Drawing.Point(39, 154);
            this.tbByte4.Name = "tbByte4";
            this.tbByte4.Size = new System.Drawing.Size(100, 21);
            this.tbByte4.TabIndex = 3;
            // 
            // tbByte3
            // 
            this.tbByte3.Location = new System.Drawing.Point(39, 114);
            this.tbByte3.Name = "tbByte3";
            this.tbByte3.Size = new System.Drawing.Size(100, 21);
            this.tbByte3.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(216, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 21);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(216, 86);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(159, 21);
            this.textBox2.TabIndex = 6;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 263);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tbByte4);
            this.Controls.Add(this.tbByte3);
            this.Controls.Add(this.tbByte2);
            this.Controls.Add(this.tbByte1);
            this.Name = "Form6";
            this.Text = "Form6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbByte1;
        private System.Windows.Forms.TextBox tbByte2;
        private System.Windows.Forms.TextBox tbByte4;
        private System.Windows.Forms.TextBox tbByte3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
    }
}