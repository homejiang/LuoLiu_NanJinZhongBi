namespace AutoAssign.Login
{
    partial class frmModifyPwd
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbUserCode = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbDeptName = new System.Windows.Forms.TextBox();
            this.tbOrgPad = new MyControl.MyTextBox();
            this.tbNewPwd1 = new MyControl.MyTextBox();
            this.tbNewPwd2 = new MyControl.MyTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "所在班组";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "原始密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "新密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "确认新密码";
            // 
            // tbUserCode
            // 
            this.tbUserCode.BackColor = System.Drawing.Color.White;
            this.tbUserCode.Location = new System.Drawing.Point(58, 6);
            this.tbUserCode.Name = "tbUserCode";
            this.tbUserCode.ReadOnly = true;
            this.tbUserCode.Size = new System.Drawing.Size(77, 21);
            this.tbUserCode.TabIndex = 6;
            // 
            // tbUserName
            // 
            this.tbUserName.BackColor = System.Drawing.Color.White;
            this.tbUserName.Location = new System.Drawing.Point(173, 7);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.ReadOnly = true;
            this.tbUserName.Size = new System.Drawing.Size(97, 21);
            this.tbUserName.TabIndex = 7;
            // 
            // tbDeptName
            // 
            this.tbDeptName.BackColor = System.Drawing.Color.White;
            this.tbDeptName.Location = new System.Drawing.Point(87, 30);
            this.tbDeptName.Name = "tbDeptName";
            this.tbDeptName.ReadOnly = true;
            this.tbDeptName.Size = new System.Drawing.Size(183, 21);
            this.tbDeptName.TabIndex = 8;
            // 
            // tbOrgPad
            // 
            this.tbOrgPad.FilterQuanJiao = true;
            this.tbOrgPad.IsUpper = false;
            this.tbOrgPad.Location = new System.Drawing.Point(87, 66);
            this.tbOrgPad.Name = "tbOrgPad";
            this.tbOrgPad.PasswordChar = '*';
            this.tbOrgPad.Size = new System.Drawing.Size(183, 21);
            this.tbOrgPad.TabIndex = 9;
            // 
            // tbNewPwd1
            // 
            this.tbNewPwd1.FilterQuanJiao = true;
            this.tbNewPwd1.IsUpper = false;
            this.tbNewPwd1.Location = new System.Drawing.Point(87, 90);
            this.tbNewPwd1.Name = "tbNewPwd1";
            this.tbNewPwd1.PasswordChar = '*';
            this.tbNewPwd1.Size = new System.Drawing.Size(183, 21);
            this.tbNewPwd1.TabIndex = 10;
            // 
            // tbNewPwd2
            // 
            this.tbNewPwd2.FilterQuanJiao = true;
            this.tbNewPwd2.IsUpper = false;
            this.tbNewPwd2.Location = new System.Drawing.Point(87, 114);
            this.tbNewPwd2.Name = "tbNewPwd2";
            this.tbNewPwd2.PasswordChar = '*';
            this.tbNewPwd2.Size = new System.Drawing.Size(183, 21);
            this.tbNewPwd2.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 33);
            this.button1.TabIndex = 12;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmModifyPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 195);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbNewPwd2);
            this.Controls.Add(this.tbNewPwd1);
            this.Controls.Add(this.tbOrgPad);
            this.Controls.Add(this.tbDeptName);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.tbUserCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModifyPwd";
            this.ShowIcon = false;
            this.Text = "登陆密码修改";
            this.Load += new System.EventHandler(this.frmModifyPwd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbUserCode;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbDeptName;
        private MyControl.MyTextBox tbOrgPad;
        private MyControl.MyTextBox tbNewPwd1;
        private MyControl.MyTextBox tbNewPwd2;
        private System.Windows.Forms.Button button1;
    }
}