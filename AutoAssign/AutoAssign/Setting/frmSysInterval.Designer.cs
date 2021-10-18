namespace AutoAssign.Setting
{
    partial class frmSysInterval
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
            this.tbScaner_TimeoutMiilSeconds = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDelayerMillScdsAfterBatDataWriteIntoOPC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDelayerMillScdsAfterResultSaved = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTesteStatusReaderInterval = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRefreshStatisticData = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbRefreshSendMes = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.labMsg = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "扫描枪超时设定";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbScaner_TimeoutMiilSeconds
            // 
            this.tbScaner_TimeoutMiilSeconds.Location = new System.Drawing.Point(170, 40);
            this.tbScaner_TimeoutMiilSeconds.Name = "tbScaner_TimeoutMiilSeconds";
            this.tbScaner_TimeoutMiilSeconds.Size = new System.Drawing.Size(100, 21);
            this.tbScaner_TimeoutMiilSeconds.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "毫秒";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "毫秒";
            // 
            // tbDelayerMillScdsAfterBatDataWriteIntoOPC
            // 
            this.tbDelayerMillScdsAfterBatDataWriteIntoOPC.Location = new System.Drawing.Point(170, 72);
            this.tbDelayerMillScdsAfterBatDataWriteIntoOPC.Name = "tbDelayerMillScdsAfterBatDataWriteIntoOPC";
            this.tbDelayerMillScdsAfterBatDataWriteIntoOPC.Size = new System.Drawing.Size(100, 21);
            this.tbDelayerMillScdsAfterBatDataWriteIntoOPC.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "电芯数据写入OPC后延时";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "毫秒";
            // 
            // tbDelayerMillScdsAfterResultSaved
            // 
            this.tbDelayerMillScdsAfterResultSaved.Location = new System.Drawing.Point(170, 104);
            this.tbDelayerMillScdsAfterResultSaved.Name = "tbDelayerMillScdsAfterResultSaved";
            this.tbDelayerMillScdsAfterResultSaved.Size = new System.Drawing.Size(100, 21);
            this.tbDelayerMillScdsAfterResultSaved.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "检测结果从OPC读取后延时";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "毫秒";
            // 
            // tbTesteStatusReaderInterval
            // 
            this.tbTesteStatusReaderInterval.Location = new System.Drawing.Point(170, 136);
            this.tbTesteStatusReaderInterval.Name = "tbTesteStatusReaderInterval";
            this.tbTesteStatusReaderInterval.Size = new System.Drawing.Size(100, 21);
            this.tbTesteStatusReaderInterval.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "主界面设备状态刷新频率";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(276, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "毫秒";
            // 
            // tbRefreshStatisticData
            // 
            this.tbRefreshStatisticData.Location = new System.Drawing.Point(170, 172);
            this.tbRefreshStatisticData.Name = "tbRefreshStatisticData";
            this.tbRefreshStatisticData.Size = new System.Drawing.Size(100, 21);
            this.tbRefreshStatisticData.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "主界面统计结果刷新频率";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(276, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "毫秒";
            // 
            // tbRefreshSendMes
            // 
            this.tbRefreshSendMes.Location = new System.Drawing.Point(170, 209);
            this.tbRefreshSendMes.Name = "tbRefreshSendMes";
            this.tbRefreshSendMes.Size = new System.Drawing.Size(100, 21);
            this.tbRefreshSendMes.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 12);
            this.label12.TabIndex = 15;
            this.label12.Text = "主界面上传MES刷新频率";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(132, 244);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(88, 31);
            this.btSave.TabIndex = 18;
            this.btSave.Text = "保 存";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // labMsg
            // 
            this.labMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labMsg.ForeColor = System.Drawing.Color.Red;
            this.labMsg.Location = new System.Drawing.Point(0, 288);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(349, 18);
            this.labMsg.TabIndex = 19;
            this.labMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Maroon;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(349, 30);
            this.label13.TabIndex = 20;
            this.label13.Text = "此为系统关键参数，请谨慎修改。";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSysInterval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 306);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.labMsg);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbRefreshSendMes);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbRefreshStatisticData);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbTesteStatusReaderInterval);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDelayerMillScdsAfterResultSaved);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDelayerMillScdsAfterBatDataWriteIntoOPC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbScaner_TimeoutMiilSeconds);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysInterval";
            this.Text = "系统系统先关频率设定";
            this.Load += new System.EventHandler(this.frmSysInterval_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbScaner_TimeoutMiilSeconds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDelayerMillScdsAfterBatDataWriteIntoOPC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDelayerMillScdsAfterResultSaved;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTesteStatusReaderInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbRefreshStatisticData;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbRefreshSendMes;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label labMsg;
        private System.Windows.Forms.Label label13;
    }
}