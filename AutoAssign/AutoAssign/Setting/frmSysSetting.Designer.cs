namespace AutoAssign.Setting
{
    partial class frmSysSetting
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
            this.tbMacCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numMacNo = new System.Windows.Forms.NumericUpDown();
            this.btTrue = new System.Windows.Forms.Button();
            this.labMsg = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMacNo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前设备序号";
            // 
            // tbMacCode
            // 
            this.tbMacCode.Location = new System.Drawing.Point(140, 56);
            this.tbMacCode.Name = "tbMacCode";
            this.tbMacCode.Size = new System.Drawing.Size(137, 24);
            this.tbMacCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "当前设备编码";
            // 
            // numMacNo
            // 
            this.numMacNo.Location = new System.Drawing.Point(141, 23);
            this.numMacNo.Name = "numMacNo";
            this.numMacNo.Size = new System.Drawing.Size(76, 24);
            this.numMacNo.TabIndex = 4;
            this.numMacNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(112, 132);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(95, 32);
            this.btTrue.TabIndex = 5;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // labMsg
            // 
            this.labMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labMsg.ForeColor = System.Drawing.Color.Red;
            this.labMsg.Location = new System.Drawing.Point(0, 167);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(336, 18);
            this.labMsg.TabIndex = 6;
            this.labMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "当前设备编码";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 89);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 24);
            this.textBox1.TabIndex = 7;
            // 
            // frmSysSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 185);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labMsg);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.numMacNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMacCode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(8);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysSetting";
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.frmSysSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMacNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMacCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMacNo;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Label labMsg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}