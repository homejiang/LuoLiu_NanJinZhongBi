namespace AutoAssign.RemoteMac
{
    partial class frmRemoteMacIP
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
            this.labMac1 = new System.Windows.Forms.Label();
            this.tbIP1 = new System.Windows.Forms.TextBox();
            this.tbIP2 = new System.Windows.Forms.TextBox();
            this.labMac2 = new System.Windows.Forms.Label();
            this.tbIP3 = new System.Windows.Forms.TextBox();
            this.labMac3 = new System.Windows.Forms.Label();
            this.btTrue = new System.Windows.Forms.Button();
            this.labErr = new System.Windows.Forms.Label();
            this.tbLocalIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labMac1
            // 
            this.labMac1.AutoSize = true;
            this.labMac1.Location = new System.Drawing.Point(27, 52);
            this.labMac1.Name = "labMac1";
            this.labMac1.Size = new System.Drawing.Size(53, 18);
            this.labMac1.TabIndex = 0;
            this.labMac1.Text = "设备?";
            // 
            // tbIP1
            // 
            this.tbIP1.Location = new System.Drawing.Point(85, 48);
            this.tbIP1.Name = "tbIP1";
            this.tbIP1.Size = new System.Drawing.Size(264, 27);
            this.tbIP1.TabIndex = 1;
            // 
            // tbIP2
            // 
            this.tbIP2.Location = new System.Drawing.Point(85, 90);
            this.tbIP2.Name = "tbIP2";
            this.tbIP2.Size = new System.Drawing.Size(264, 27);
            this.tbIP2.TabIndex = 3;
            // 
            // labMac2
            // 
            this.labMac2.AutoSize = true;
            this.labMac2.Location = new System.Drawing.Point(27, 94);
            this.labMac2.Name = "labMac2";
            this.labMac2.Size = new System.Drawing.Size(53, 18);
            this.labMac2.TabIndex = 2;
            this.labMac2.Text = "设备?";
            // 
            // tbIP3
            // 
            this.tbIP3.Location = new System.Drawing.Point(85, 132);
            this.tbIP3.Name = "tbIP3";
            this.tbIP3.Size = new System.Drawing.Size(264, 27);
            this.tbIP3.TabIndex = 5;
            // 
            // labMac3
            // 
            this.labMac3.AutoSize = true;
            this.labMac3.Location = new System.Drawing.Point(27, 136);
            this.labMac3.Name = "labMac3";
            this.labMac3.Size = new System.Drawing.Size(53, 18);
            this.labMac3.TabIndex = 4;
            this.labMac3.Text = "设备?";
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(143, 175);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(94, 36);
            this.btTrue.TabIndex = 6;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // labErr
            // 
            this.labErr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labErr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labErr.ForeColor = System.Drawing.Color.Red;
            this.labErr.Location = new System.Drawing.Point(0, 210);
            this.labErr.Name = "labErr";
            this.labErr.Size = new System.Drawing.Size(385, 27);
            this.labErr.TabIndex = 7;
            this.labErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbLocalIP
            // 
            this.tbLocalIP.Location = new System.Drawing.Point(85, 11);
            this.tbLocalIP.Name = "tbLocalIP";
            this.tbLocalIP.Size = new System.Drawing.Size(264, 27);
            this.tbLocalIP.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "本机IP";
            // 
            // frmRemoteMacIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 237);
            this.Controls.Add(this.tbLocalIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labErr);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbIP3);
            this.Controls.Add(this.labMac3);
            this.Controls.Add(this.tbIP2);
            this.Controls.Add(this.labMac2);
            this.Controls.Add(this.tbIP1);
            this.Controls.Add(this.labMac1);
            this.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRemoteMacIP";
            this.Text = "远程设备IP设置";
            this.Load += new System.EventHandler(this.frmRemoteMacIP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labMac1;
        private System.Windows.Forms.TextBox tbIP1;
        private System.Windows.Forms.TextBox tbIP2;
        private System.Windows.Forms.Label labMac2;
        private System.Windows.Forms.TextBox tbIP3;
        private System.Windows.Forms.Label labMac3;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Label labErr;
        private System.Windows.Forms.TextBox tbLocalIP;
        private System.Windows.Forms.Label label1;
    }
}