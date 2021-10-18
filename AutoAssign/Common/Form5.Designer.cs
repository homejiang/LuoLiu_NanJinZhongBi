namespace Common
{
    partial class Form5
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
            this.tbEnd1 = new System.Windows.Forms.TextBox();
            this.tbStart1 = new System.Windows.Forms.TextBox();
            this.tbEnd = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.tbEnd1);
            this.panel1.Controls.Add(this.tbStart1);
            this.panel1.Controls.Add(this.tbEnd);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tbStart);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 100);
            this.panel1.TabIndex = 0;
            // 
            // tbEnd1
            // 
            this.tbEnd1.Location = new System.Drawing.Point(823, 39);
            this.tbEnd1.Name = "tbEnd1";
            this.tbEnd1.Size = new System.Drawing.Size(71, 21);
            this.tbEnd1.TabIndex = 5;
            this.tbEnd1.Text = "1";
            // 
            // tbStart1
            // 
            this.tbStart1.Location = new System.Drawing.Point(697, 40);
            this.tbStart1.Name = "tbStart1";
            this.tbStart1.Size = new System.Drawing.Size(71, 21);
            this.tbStart1.TabIndex = 4;
            this.tbStart1.Text = "1";
            // 
            // tbEnd
            // 
            this.tbEnd.Location = new System.Drawing.Point(823, 12);
            this.tbEnd.Name = "tbEnd";
            this.tbEnd.Size = new System.Drawing.Size(71, 21);
            this.tbEnd.TabIndex = 3;
            this.tbEnd.Text = "1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(757, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbStart
            // 
            this.tbStart.Location = new System.Drawing.Point(697, 13);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(71, 21);
            this.tbStart.TabIndex = 1;
            this.tbStart.Text = "1";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(666, 100);
            this.textBox1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 100);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(974, 753);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(900, 39);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "还有我";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 853);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.TextBox tbEnd;
        private System.Windows.Forms.TextBox tbEnd1;
        private System.Windows.Forms.TextBox tbStart1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}