namespace AutoAssign.Scanner
{
    partial class frmScannerDebug
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btSend2 = new System.Windows.Forms.Button();
            this.btOpen2 = new System.Windows.Forms.Button();
            this.labScanner2Status = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSend1 = new System.Windows.Forms.Button();
            this.btOpen1 = new System.Windows.Forms.Button();
            this.labScanner1Status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.richTextBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(878, 500);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(439, 51);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(439, 449);
            this.richTextBox2.TabIndex = 3;
            this.richTextBox2.Text = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btSend2);
            this.panel2.Controls.Add(this.btOpen2);
            this.panel2.Controls.Add(this.labScanner2Status);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(442, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 45);
            this.panel2.TabIndex = 1;
            // 
            // btSend2
            // 
            this.btSend2.Location = new System.Drawing.Point(312, 10);
            this.btSend2.Name = "btSend2";
            this.btSend2.Size = new System.Drawing.Size(112, 29);
            this.btSend2.TabIndex = 6;
            this.btSend2.Text = "发送读取命令";
            this.btSend2.UseVisualStyleBackColor = true;
            this.btSend2.Click += new System.EventHandler(this.btSend2_Click);
            // 
            // btOpen2
            // 
            this.btOpen2.Location = new System.Drawing.Point(222, 10);
            this.btOpen2.Name = "btOpen2";
            this.btOpen2.Size = new System.Drawing.Size(75, 29);
            this.btOpen2.TabIndex = 5;
            this.btOpen2.Text = "打开";
            this.btOpen2.UseVisualStyleBackColor = true;
            this.btOpen2.Click += new System.EventHandler(this.btOpen2_Click);
            // 
            // labScanner2Status
            // 
            this.labScanner2Status.BackColor = System.Drawing.Color.White;
            this.labScanner2Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labScanner2Status.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labScanner2Status.Location = new System.Drawing.Point(98, 10);
            this.labScanner2Status.Name = "labScanner2Status";
            this.labScanner2Status.Size = new System.Drawing.Size(111, 28);
            this.labScanner2Status.TabIndex = 4;
            this.labScanner2Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "扫描枪2状态";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btSend1);
            this.panel1.Controls.Add(this.btOpen1);
            this.panel1.Controls.Add(this.labScanner1Status);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 45);
            this.panel1.TabIndex = 0;
            // 
            // btSend1
            // 
            this.btSend1.Location = new System.Drawing.Point(311, 10);
            this.btSend1.Name = "btSend1";
            this.btSend1.Size = new System.Drawing.Size(112, 29);
            this.btSend1.TabIndex = 3;
            this.btSend1.Text = "发送读取命令";
            this.btSend1.UseVisualStyleBackColor = true;
            this.btSend1.Click += new System.EventHandler(this.btSend1_Click);
            // 
            // btOpen1
            // 
            this.btOpen1.Location = new System.Drawing.Point(224, 9);
            this.btOpen1.Name = "btOpen1";
            this.btOpen1.Size = new System.Drawing.Size(75, 29);
            this.btOpen1.TabIndex = 2;
            this.btOpen1.Text = "打开";
            this.btOpen1.UseVisualStyleBackColor = true;
            this.btOpen1.Click += new System.EventHandler(this.btOpen1_Click);
            // 
            // labScanner1Status
            // 
            this.labScanner1Status.BackColor = System.Drawing.Color.White;
            this.labScanner1Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labScanner1Status.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labScanner1Status.Location = new System.Drawing.Point(100, 9);
            this.labScanner1Status.Name = "labScanner1Status";
            this.labScanner1Status.Size = new System.Drawing.Size(111, 28);
            this.labScanner1Status.TabIndex = 1;
            this.labScanner1Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "扫描枪1状态";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 51);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(439, 449);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmScannerDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 500);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmScannerDebug";
            this.Text = "扫描枪监控";
            this.Load += new System.EventHandler(this.frmScannerDebug_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labScanner1Status;
        private System.Windows.Forms.Button btOpen1;
        private System.Windows.Forms.Button btOpen2;
        private System.Windows.Forms.Label labScanner2Status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btSend2;
        private System.Windows.Forms.Button btSend1;
    }
}