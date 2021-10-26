namespace BasicData.ProcessMacs
{
    partial class frmProcessMacsEdit
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btTrue = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.chkTerminated = new System.Windows.Forms.CheckBox();
            this.tbAds = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMacCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMacName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ComProcess = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(174, 99);
            this.btTrue.Margin = new System.Windows.Forms.Padding(4);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(100, 45);
            this.btTrue.TabIndex = 5;
            this.btTrue.Text = "确 定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(334, 99);
            this.btClose.Margin = new System.Windows.Forms.Padding(4);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(100, 45);
            this.btClose.TabIndex = 6;
            this.btClose.Text = "关 闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // chkTerminated
            // 
            this.chkTerminated.AutoSize = true;
            this.chkTerminated.Location = new System.Drawing.Point(573, 99);
            this.chkTerminated.Margin = new System.Windows.Forms.Padding(4);
            this.chkTerminated.Name = "chkTerminated";
            this.chkTerminated.Size = new System.Drawing.Size(56, 19);
            this.chkTerminated.TabIndex = 4;
            this.chkTerminated.Text = "停用";
            this.chkTerminated.UseVisualStyleBackColor = true;
            // 
            // tbAds
            // 
            this.tbAds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAds.Location = new System.Drawing.Point(83, 41);
            this.tbAds.Margin = new System.Windows.Forms.Padding(4);
            this.tbAds.Name = "tbAds";
            this.tbAds.Size = new System.Drawing.Size(546, 24);
            this.tbAds.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(15, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "设备地址";
            // 
            // tbMacCode
            // 
            this.tbMacCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMacCode.Location = new System.Drawing.Point(83, 15);
            this.tbMacCode.Margin = new System.Windows.Forms.Padding(4);
            this.tbMacCode.Name = "tbMacCode";
            this.tbMacCode.Size = new System.Drawing.Size(106, 24);
            this.tbMacCode.TabIndex = 9;
            this.tbMacCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(15, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "设备编码";
            // 
            // tbMacName
            // 
            this.tbMacName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMacName.Location = new System.Drawing.Point(265, 15);
            this.tbMacName.Margin = new System.Windows.Forms.Padding(4);
            this.tbMacName.Name = "tbMacName";
            this.tbMacName.Size = new System.Drawing.Size(135, 24);
            this.tbMacName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(194, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "设备名称";
            // 
            // tbRemark
            // 
            this.tbRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemark.Location = new System.Drawing.Point(83, 67);
            this.tbRemark.Margin = new System.Windows.Forms.Padding(4);
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(546, 24);
            this.tbRemark.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(43, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "备注";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(408, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "所属工序";
            // 
            // ComProcess
            // 
            this.ComProcess.FormattingEnabled = true;
            this.ComProcess.Location = new System.Drawing.Point(482, 16);
            this.ComProcess.Name = "ComProcess";
            this.ComProcess.Size = new System.Drawing.Size(147, 23);
            this.ComProcess.TabIndex = 61;
            // 
            // frmProcessMacsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 160);
            this.Controls.Add(this.ComProcess);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbRemark);
            this.Controls.Add(this.tbAds);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMacCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMacName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkTerminated);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btTrue);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcessMacsEdit";
            this.Text = "设备编辑";
            this.Load += new System.EventHandler(this.frmUnitEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.CheckBox chkTerminated;
        private System.Windows.Forms.TextBox tbAds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMacCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMacName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComProcess;
    }
}