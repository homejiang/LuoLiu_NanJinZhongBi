namespace Common.Login
{
    partial class frmLogin1
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
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btLogin = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.picServerConfig = new System.Windows.Forms.PictureBox();
            this.comUsers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDeptName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picServerConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(92, 72);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(154, 21);
            this.tbPwd.TabIndex = 2;
            this.tbPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPwd_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户密码";
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(59, 113);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(75, 37);
            this.btLogin.TabIndex = 3;
            this.btLogin.Text = "登 陆";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(155, 113);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 37);
            this.btClose.TabIndex = 4;
            this.btClose.Text = "关 闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // picServerConfig
            // 
            this.picServerConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picServerConfig.Location = new System.Drawing.Point(246, 131);
            this.picServerConfig.Margin = new System.Windows.Forms.Padding(0);
            this.picServerConfig.Name = "picServerConfig";
            this.picServerConfig.Size = new System.Drawing.Size(29, 30);
            this.picServerConfig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picServerConfig.TabIndex = 8;
            this.picServerConfig.TabStop = false;
            this.picServerConfig.Click += new System.EventHandler(this.picServerConfig_Click);
            // 
            // comUsers
            // 
            this.comUsers.DropDownHeight = 206;
            this.comUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comUsers.FormattingEnabled = true;
            this.comUsers.IntegralHeight = false;
            this.comUsers.Location = new System.Drawing.Point(92, 21);
            this.comUsers.Name = "comUsers";
            this.comUsers.Size = new System.Drawing.Size(154, 20);
            this.comUsers.TabIndex = 1;
            this.comUsers.SelectedIndexChanged += new System.EventHandler(this.comUsers_SelectedIndexChanged);
            this.comUsers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comUsers_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "用户选择";
            // 
            // tbDeptName
            // 
            this.tbDeptName.Location = new System.Drawing.Point(92, 46);
            this.tbDeptName.Name = "tbDeptName";
            this.tbDeptName.ReadOnly = true;
            this.tbDeptName.Size = new System.Drawing.Size(154, 21);
            this.tbDeptName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "所在部门";
            // 
            // frmLogin1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(275, 162);
            this.Controls.Add(this.tbDeptName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comUsers);
            this.Controls.Add(this.picServerConfig);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin1";
            this.Text = "用户登录";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picServerConfig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.PictureBox picServerConfig;
        private System.Windows.Forms.ComboBox comUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDeptName;
        private System.Windows.Forms.Label label2;
    }
}