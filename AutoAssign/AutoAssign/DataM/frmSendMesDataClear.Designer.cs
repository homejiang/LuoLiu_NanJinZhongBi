namespace AutoAssign.DataM
{
    partial class frmSendMesDataClear
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
            this.tbD = new System.Windows.Forms.TextBox();
            this.btClearUnSend = new System.Windows.Forms.Button();
            this.btClearSent = new System.Windows.Forms.Button();
            this.tbY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "待上传到MES系统数据";
            // 
            // tbD
            // 
            this.tbD.BackColor = System.Drawing.Color.White;
            this.tbD.ForeColor = System.Drawing.Color.Black;
            this.tbD.Location = new System.Drawing.Point(186, 20);
            this.tbD.Name = "tbD";
            this.tbD.ReadOnly = true;
            this.tbD.Size = new System.Drawing.Size(100, 24);
            this.tbD.TabIndex = 1;
            // 
            // btClearUnSend
            // 
            this.btClearUnSend.Location = new System.Drawing.Point(318, 12);
            this.btClearUnSend.Name = "btClearUnSend";
            this.btClearUnSend.Size = new System.Drawing.Size(75, 41);
            this.btClearUnSend.TabIndex = 2;
            this.btClearUnSend.Text = "全部清除";
            this.btClearUnSend.UseVisualStyleBackColor = true;
            this.btClearUnSend.Click += new System.EventHandler(this.btClearUnSend_Click);
            // 
            // btClearSent
            // 
            this.btClearSent.Location = new System.Drawing.Point(318, 67);
            this.btClearSent.Name = "btClearSent";
            this.btClearSent.Size = new System.Drawing.Size(75, 41);
            this.btClearSent.TabIndex = 5;
            this.btClearSent.Text = "全部清除";
            this.btClearSent.UseVisualStyleBackColor = true;
            this.btClearSent.Click += new System.EventHandler(this.btClearSent_Click);
            // 
            // tbY
            // 
            this.tbY.BackColor = System.Drawing.Color.White;
            this.tbY.ForeColor = System.Drawing.Color.Black;
            this.tbY.Location = new System.Drawing.Point(186, 75);
            this.tbY.Name = "tbY";
            this.tbY.ReadOnly = true;
            this.tbY.Size = new System.Drawing.Size(100, 24);
            this.tbY.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "已上传到MES系统数据";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(401, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "谨慎操作";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(0, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(481, 34);
            this.label4.TabIndex = 7;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSendMesDataClear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 154);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btClearSent);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btClearUnSend);
            this.Controls.Add(this.tbD);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSendMesDataClear";
            this.Text = "清除上传MES数据";
            this.Load += new System.EventHandler(this.frmSendMesDataClear_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.Button btClearUnSend;
        private System.Windows.Forms.Button btClearSent;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}