namespace LuoLiuMES.AutoExe
{
    partial class frmUserFormEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbFormCode = new System.Windows.Forms.TextBox();
            this.tbFormName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.linkGroup = new System.Windows.Forms.LinkLabel();
            this.chkUnderline = new System.Windows.Forms.CheckBox();
            this.chkFontBold = new System.Windows.Forms.CheckBox();
            this.linkForeColor = new System.Windows.Forms.LinkLabel();
            this.tbForeColor = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.chkForeColorNone = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "窗体代码";
            // 
            // tbFormCode
            // 
            this.tbFormCode.BackColor = System.Drawing.Color.White;
            this.tbFormCode.Location = new System.Drawing.Point(86, 18);
            this.tbFormCode.Name = "tbFormCode";
            this.tbFormCode.ReadOnly = true;
            this.tbFormCode.Size = new System.Drawing.Size(156, 23);
            this.tbFormCode.TabIndex = 1;
            // 
            // tbFormName
            // 
            this.tbFormName.Location = new System.Drawing.Point(86, 47);
            this.tbFormName.Name = "tbFormName";
            this.tbFormName.Size = new System.Drawing.Size(370, 23);
            this.tbFormName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "窗口名称";
            // 
            // tbGroupName
            // 
            this.tbGroupName.BackColor = System.Drawing.Color.White;
            this.tbGroupName.Location = new System.Drawing.Point(300, 18);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.ReadOnly = true;
            this.tbGroupName.Size = new System.Drawing.Size(156, 23);
            this.tbGroupName.TabIndex = 4;
            // 
            // linkGroup
            // 
            this.linkGroup.AutoSize = true;
            this.linkGroup.Location = new System.Drawing.Point(249, 23);
            this.linkGroup.Name = "linkGroup";
            this.linkGroup.Size = new System.Drawing.Size(49, 14);
            this.linkGroup.TabIndex = 5;
            this.linkGroup.TabStop = true;
            this.linkGroup.Text = "模块组";
            this.linkGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGroup_LinkClicked);
            // 
            // chkUnderline
            // 
            this.chkUnderline.AutoSize = true;
            this.chkUnderline.Location = new System.Drawing.Point(86, 88);
            this.chkUnderline.Name = "chkUnderline";
            this.chkUnderline.Size = new System.Drawing.Size(68, 18);
            this.chkUnderline.TabIndex = 7;
            this.chkUnderline.Text = "下划线";
            this.chkUnderline.UseVisualStyleBackColor = true;
            // 
            // chkFontBold
            // 
            this.chkFontBold.AutoSize = true;
            this.chkFontBold.Location = new System.Drawing.Point(187, 88);
            this.chkFontBold.Name = "chkFontBold";
            this.chkFontBold.Size = new System.Drawing.Size(54, 18);
            this.chkFontBold.TabIndex = 8;
            this.chkFontBold.Text = "粗体";
            this.chkFontBold.UseVisualStyleBackColor = true;
            // 
            // linkForeColor
            // 
            this.linkForeColor.AutoSize = true;
            this.linkForeColor.Location = new System.Drawing.Point(20, 119);
            this.linkForeColor.Name = "linkForeColor";
            this.linkForeColor.Size = new System.Drawing.Size(63, 14);
            this.linkForeColor.TabIndex = 9;
            this.linkForeColor.TabStop = true;
            this.linkForeColor.Text = "字体颜色";
            this.linkForeColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForeColor_LinkClicked);
            // 
            // tbForeColor
            // 
            this.tbForeColor.BackColor = System.Drawing.Color.White;
            this.tbForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbForeColor.Location = new System.Drawing.Point(86, 114);
            this.tbForeColor.Name = "tbForeColor";
            this.tbForeColor.ReadOnly = true;
            this.tbForeColor.Size = new System.Drawing.Size(310, 23);
            this.tbForeColor.TabIndex = 10;
            this.tbForeColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 36);
            this.button1.TabIndex = 11;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkForeColorNone
            // 
            this.chkForeColorNone.AutoSize = true;
            this.chkForeColorNone.Location = new System.Drawing.Point(402, 117);
            this.chkForeColorNone.Name = "chkForeColorNone";
            this.chkForeColorNone.Size = new System.Drawing.Size(54, 18);
            this.chkForeColorNone.TabIndex = 12;
            this.chkForeColorNone.Text = "默认";
            this.chkForeColorNone.UseVisualStyleBackColor = true;
            this.chkForeColorNone.CheckedChanged += new System.EventHandler(this.chkForeColorNone_CheckedChanged);
            // 
            // frmUserFormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 248);
            this.Controls.Add(this.chkForeColorNone);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbForeColor);
            this.Controls.Add(this.linkForeColor);
            this.Controls.Add(this.chkFontBold);
            this.Controls.Add(this.chkUnderline);
            this.Controls.Add(this.linkGroup);
            this.Controls.Add(this.tbGroupName);
            this.Controls.Add(this.tbFormName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFormCode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserFormEdit";
            this.ShowIcon = false;
            this.Text = "用户自定义窗体编辑";
            this.Load += new System.EventHandler(this.frmUserFormEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFormCode;
        private System.Windows.Forms.TextBox tbFormName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.LinkLabel linkGroup;
        private System.Windows.Forms.CheckBox chkUnderline;
        private System.Windows.Forms.CheckBox chkFontBold;
        private System.Windows.Forms.LinkLabel linkForeColor;
        private System.Windows.Forms.TextBox tbForeColor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox chkForeColorNone;
    }
}