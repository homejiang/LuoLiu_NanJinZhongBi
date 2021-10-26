namespace BasicData.FactoryCode
{
    partial class frmFactoryCodeEdit
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
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCodeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAnotherName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(106, 145);
            this.btTrue.Margin = new System.Windows.Forms.Padding(4);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(90, 30);
            this.btTrue.TabIndex = 5;
            this.btTrue.Text = "确 定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(224, 145);
            this.btClose.Margin = new System.Windows.Forms.Padding(4);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(90, 30);
            this.btClose.TabIndex = 6;
            this.btClose.Text = "关 闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // chkTerminated
            // 
            this.chkTerminated.AutoSize = true;
            this.chkTerminated.Location = new System.Drawing.Point(338, 15);
            this.chkTerminated.Margin = new System.Windows.Forms.Padding(4);
            this.chkTerminated.Name = "chkTerminated";
            this.chkTerminated.Size = new System.Drawing.Size(56, 19);
            this.chkTerminated.TabIndex = 4;
            this.chkTerminated.Text = "停用";
            this.chkTerminated.UseVisualStyleBackColor = true;
            // 
            // tbRemark
            // 
            this.tbRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemark.Location = new System.Drawing.Point(83, 69);
            this.tbRemark.Margin = new System.Windows.Forms.Padding(4);
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRemark.Size = new System.Drawing.Size(320, 62);
            this.tbRemark.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(35, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "备注";
            // 
            // tbCode
            // 
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCode.Location = new System.Drawing.Point(83, 14);
            this.tbCode.Margin = new System.Windows.Forms.Padding(4);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(132, 24);
            this.tbCode.TabIndex = 9;
            this.tbCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.label3.Text = "系统编号";
            // 
            // tbCodeName
            // 
            this.tbCodeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodeName.Location = new System.Drawing.Point(83, 42);
            this.tbCodeName.Margin = new System.Windows.Forms.Padding(4);
            this.tbCodeName.Name = "tbCodeName";
            this.tbCodeName.Size = new System.Drawing.Size(132, 24);
            this.tbCodeName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "厂商代码";
            // 
            // tbAnotherName
            // 
            this.tbAnotherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAnotherName.Location = new System.Drawing.Point(262, 43);
            this.tbAnotherName.Margin = new System.Windows.Forms.Padding(4);
            this.tbAnotherName.Name = "tbAnotherName";
            this.tbAnotherName.Size = new System.Drawing.Size(132, 24);
            this.tbAnotherName.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(221, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "别名";
            // 
            // frmFactoryCodeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 189);
            this.Controls.Add(this.tbAnotherName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbRemark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCodeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkTerminated);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btTrue);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFactoryCodeEdit";
            this.Text = "厂商代号设置";
            this.Load += new System.EventHandler(this.frmUnitEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.CheckBox chkTerminated;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCodeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAnotherName;
        private System.Windows.Forms.Label label4;
    }
}