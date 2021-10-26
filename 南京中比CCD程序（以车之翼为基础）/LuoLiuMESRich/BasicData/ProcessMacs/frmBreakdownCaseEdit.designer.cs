namespace BasicData.ProcessMacs
{
    partial class frmBreakdownCaseEdit
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
            this.picLevelAdd = new System.Windows.Forms.PictureBox();
            this.comLevel = new System.Windows.Forms.ComboBox();
            this.tbRemark = new MyControl.MyTextBox();
            this.comProcess = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCode = new MyControl.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIsSys = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comClass = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLevelAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(116, 170);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(75, 23);
            this.btTrue.TabIndex = 5;
            this.btTrue.Text = "确 定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(213, 170);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 6;
            this.btClose.Text = "关 闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // chkTerminated
            // 
            this.chkTerminated.AutoSize = true;
            this.chkTerminated.Location = new System.Drawing.Point(45, 64);
            this.chkTerminated.Name = "chkTerminated";
            this.chkTerminated.Size = new System.Drawing.Size(48, 16);
            this.chkTerminated.TabIndex = 4;
            this.chkTerminated.Text = "停用";
            this.chkTerminated.UseVisualStyleBackColor = true;
            // 
            // picLevelAdd
            // 
            this.picLevelAdd.BackColor = System.Drawing.Color.Transparent;
            this.picLevelAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picLevelAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLevelAdd.Image = global::BasicData.Properties.Resources.create;
            this.picLevelAdd.Location = new System.Drawing.Point(361, 9);
            this.picLevelAdd.Name = "picLevelAdd";
            this.picLevelAdd.Size = new System.Drawing.Size(16, 16);
            this.picLevelAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLevelAdd.TabIndex = 23;
            this.picLevelAdd.TabStop = false;
            this.picLevelAdd.Click += new System.EventHandler(this.picLevelAdd_Click);
            // 
            // comLevel
            // 
            this.comLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comLevel.FormattingEnabled = true;
            this.comLevel.Location = new System.Drawing.Point(235, 8);
            this.comLevel.Name = "comLevel";
            this.comLevel.Size = new System.Drawing.Size(121, 20);
            this.comLevel.TabIndex = 22;
            // 
            // tbRemark
            // 
            this.tbRemark.FilterQuanJiao = true;
            this.tbRemark.IsUpper = false;
            this.tbRemark.Location = new System.Drawing.Point(71, 83);
            this.tbRemark.MaxLength = 400;
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRemark.Size = new System.Drawing.Size(317, 68);
            this.tbRemark.TabIndex = 21;
            // 
            // comProcess
            // 
            this.comProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comProcess.FormattingEnabled = true;
            this.comProcess.Location = new System.Drawing.Point(71, 34);
            this.comProcess.Name = "comProcess";
            this.comProcess.Size = new System.Drawing.Size(100, 20);
            this.comProcess.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "设备工序";
            // 
            // tbCode
            // 
            this.tbCode.FilterQuanJiao = true;
            this.tbCode.IsUpper = false;
            this.tbCode.Location = new System.Drawing.Point(71, 7);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(100, 21);
            this.tbCode.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(178, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "异常等级";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(14, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "异常代码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "内容描述";
            // 
            // chkIsSys
            // 
            this.chkIsSys.AutoSize = true;
            this.chkIsSys.Location = new System.Drawing.Point(99, 64);
            this.chkIsSys.Name = "chkIsSys";
            this.chkIsSys.Size = new System.Drawing.Size(72, 16);
            this.chkIsSys.TabIndex = 24;
            this.chkIsSys.Text = "系统必须";
            this.chkIsSys.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::BasicData.Properties.Resources.create;
            this.pictureBox1.Location = new System.Drawing.Point(361, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comClass
            // 
            this.comClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comClass.FormattingEnabled = true;
            this.comClass.Location = new System.Drawing.Point(235, 34);
            this.comClass.Name = "comClass";
            this.comClass.Size = new System.Drawing.Size(121, 20);
            this.comClass.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(178, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "异常类别";
            // 
            // frmBreakdownCaseEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 205);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comClass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkIsSys);
            this.Controls.Add(this.picLevelAdd);
            this.Controls.Add(this.comLevel);
            this.Controls.Add(this.tbRemark);
            this.Controls.Add(this.comProcess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkTerminated);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btTrue);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBreakdownCaseEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设备异常内容编辑";
            this.Load += new System.EventHandler(this.frmUnitEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLevelAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.CheckBox chkTerminated;
        private System.Windows.Forms.PictureBox picLevelAdd;
        private System.Windows.Forms.ComboBox comLevel;
        private MyControl.MyTextBox tbRemark;
        private System.Windows.Forms.ComboBox comProcess;
        private System.Windows.Forms.Label label4;
        private MyControl.MyTextBox tbCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkIsSys;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comClass;
        private System.Windows.Forms.Label label5;
    }
}