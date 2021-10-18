namespace AutoAssign.Login
{
    partial class frmLogin
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
            this.tbUserCode = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btLogin = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.tbDeptName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户编码";
            // 
            // tbUserCode
            // 
            this.tbUserCode.Location = new System.Drawing.Point(93, 14);
            this.tbUserCode.Name = "tbUserCode";
            this.tbUserCode.Size = new System.Drawing.Size(138, 21);
            this.tbUserCode.TabIndex = 1;
            this.tbUserCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUserCode_KeyDown);
            this.tbUserCode.Leave += new System.EventHandler(this.tbUserCode_Leave);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(93, 39);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.ReadOnly = true;
            this.tbUserName.Size = new System.Drawing.Size(138, 21);
            this.tbUserName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户姓名";
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(93, 91);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(138, 21);
            this.tbPwd.TabIndex = 5;
            this.tbPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPwd_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户密码";
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(60, 128);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(75, 23);
            this.btLogin.TabIndex = 6;
            this.btLogin.Text = "登 陆";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(146, 128);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 7;
            this.btClose.Text = "关 闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tbDeptName
            // 
            this.tbDeptName.Location = new System.Drawing.Point(93, 64);
            this.tbDeptName.Name = "tbDeptName";
            this.tbDeptName.ReadOnly = true;
            this.tbDeptName.Size = new System.Drawing.Size(138, 21);
            this.tbDeptName.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "账户类型";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(0, 168);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(89, 12);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "查找用户编码？";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(275, 181);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tbDeptName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbUserCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.Text = "用户登陆";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUserCode;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TextBox tbDeptName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}