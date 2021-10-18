namespace AutoAssign.Setting
{
    partial class frmScannerSetting
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
            this.tbScanner1_IP = new System.Windows.Forms.TextBox();
            this.tbScanner1_Port = new System.Windows.Forms.TextBox();
            this.tbScanner2_Port = new System.Windows.Forms.TextBox();
            this.tbScanner2_IP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btTrue = new System.Windows.Forms.Button();
            this.labMsg = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkTerminated1 = new System.Windows.Forms.CheckBox();
            this.chkTerminated2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "扫描枪1";
            // 
            // tbScanner1_IP
            // 
            this.tbScanner1_IP.Location = new System.Drawing.Point(90, 43);
            this.tbScanner1_IP.Name = "tbScanner1_IP";
            this.tbScanner1_IP.Size = new System.Drawing.Size(166, 27);
            this.tbScanner1_IP.TabIndex = 1;
            // 
            // tbScanner1_Port
            // 
            this.tbScanner1_Port.Location = new System.Drawing.Point(267, 44);
            this.tbScanner1_Port.Name = "tbScanner1_Port";
            this.tbScanner1_Port.Size = new System.Drawing.Size(83, 27);
            this.tbScanner1_Port.TabIndex = 2;
            this.tbScanner1_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbScanner2_Port
            // 
            this.tbScanner2_Port.Location = new System.Drawing.Point(267, 87);
            this.tbScanner2_Port.Name = "tbScanner2_Port";
            this.tbScanner2_Port.Size = new System.Drawing.Size(83, 27);
            this.tbScanner2_Port.TabIndex = 5;
            this.tbScanner2_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbScanner2_IP
            // 
            this.tbScanner2_IP.Location = new System.Drawing.Point(90, 86);
            this.tbScanner2_IP.Name = "tbScanner2_IP";
            this.tbScanner2_IP.Size = new System.Drawing.Size(166, 27);
            this.tbScanner2_IP.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "扫描枪2";
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(168, 132);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(108, 36);
            this.btTrue.TabIndex = 6;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // labMsg
            // 
            this.labMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labMsg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMsg.ForeColor = System.Drawing.Color.Red;
            this.labMsg.Location = new System.Drawing.Point(0, 183);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(448, 21);
            this.labMsg.TabIndex = 7;
            this.labMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(448, 40);
            this.label3.TabIndex = 8;
            this.label3.Text = "扫描枪的顺序根据所扫电芯进入设备的先后顺序来定。";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkTerminated1
            // 
            this.chkTerminated1.AutoSize = true;
            this.chkTerminated1.Location = new System.Drawing.Point(364, 48);
            this.chkTerminated1.Name = "chkTerminated1";
            this.chkTerminated1.Size = new System.Drawing.Size(63, 22);
            this.chkTerminated1.TabIndex = 9;
            this.chkTerminated1.Text = "停用";
            this.chkTerminated1.UseVisualStyleBackColor = true;
            // 
            // chkTerminated2
            // 
            this.chkTerminated2.AutoSize = true;
            this.chkTerminated2.Location = new System.Drawing.Point(363, 91);
            this.chkTerminated2.Name = "chkTerminated2";
            this.chkTerminated2.Size = new System.Drawing.Size(63, 22);
            this.chkTerminated2.TabIndex = 10;
            this.chkTerminated2.Text = "停用";
            this.chkTerminated2.UseVisualStyleBackColor = true;
            // 
            // frmScannerSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 204);
            this.Controls.Add(this.chkTerminated2);
            this.Controls.Add(this.chkTerminated1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labMsg);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbScanner2_Port);
            this.Controls.Add(this.tbScanner2_IP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbScanner1_Port);
            this.Controls.Add(this.tbScanner1_IP);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScannerSetting";
            this.Text = "扫描枪通讯设置";
            this.Load += new System.EventHandler(this.frmScannerSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbScanner1_IP;
        private System.Windows.Forms.TextBox tbScanner1_Port;
        private System.Windows.Forms.TextBox tbScanner2_Port;
        private System.Windows.Forms.TextBox tbScanner2_IP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Label labMsg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkTerminated1;
        private System.Windows.Forms.CheckBox chkTerminated2;
    }
}