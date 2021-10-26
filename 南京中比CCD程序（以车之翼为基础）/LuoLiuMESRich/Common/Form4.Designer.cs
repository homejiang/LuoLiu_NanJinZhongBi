namespace Common
{
    partial class Form4
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切换用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改登录密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看当前登录信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.接收消息设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.消息列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.已删除消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.联系管理员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.意见反馈ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统版本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucFile1 = new Common.UserControls.ucFile();
            this.ucTitle1 = new Common.UserControls.ucTitle();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(221, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 180);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(350, 21);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(331, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(428, 112);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "SPEEK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Common.Properties.Resources.unkown;
            this.pictureBox1.Location = new System.Drawing.Point(25, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.用户ToolStripMenuItem,
            this.系统消息ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(857, 25);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "MenuStrip";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新系统ToolStripMenuItem,
            this.退出程序ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 更新系统ToolStripMenuItem
            // 
            this.更新系统ToolStripMenuItem.Name = "更新系统ToolStripMenuItem";
            this.更新系统ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.更新系统ToolStripMenuItem.Text = "更新";
            // 
            // 退出程序ToolStripMenuItem
            // 
            this.退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem";
            this.退出程序ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出程序ToolStripMenuItem.Text = "退出程序";
            // 
            // 用户ToolStripMenuItem
            // 
            this.用户ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.切换用户ToolStripMenuItem,
            this.注销ToolStripMenuItem,
            this.修改登录密码ToolStripMenuItem,
            this.查看当前登录信息ToolStripMenuItem});
            this.用户ToolStripMenuItem.Name = "用户ToolStripMenuItem";
            this.用户ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.用户ToolStripMenuItem.Text = "用户";
            // 
            // 切换用户ToolStripMenuItem
            // 
            this.切换用户ToolStripMenuItem.Name = "切换用户ToolStripMenuItem";
            this.切换用户ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.切换用户ToolStripMenuItem.Text = "切换用户";
            // 
            // 注销ToolStripMenuItem
            // 
            this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
            this.注销ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.注销ToolStripMenuItem.Text = "注销当前登录";
            // 
            // 修改登录密码ToolStripMenuItem
            // 
            this.修改登录密码ToolStripMenuItem.Name = "修改登录密码ToolStripMenuItem";
            this.修改登录密码ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.修改登录密码ToolStripMenuItem.Text = "修改登录密码";
            // 
            // 查看当前登录信息ToolStripMenuItem
            // 
            this.查看当前登录信息ToolStripMenuItem.Name = "查看当前登录信息ToolStripMenuItem";
            this.查看当前登录信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.查看当前登录信息ToolStripMenuItem.Text = "查看登录信息";
            // 
            // 系统消息ToolStripMenuItem
            // 
            this.系统消息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.接收消息设置ToolStripMenuItem,
            this.自定义信息ToolStripMenuItem,
            this.消息列表ToolStripMenuItem,
            this.已删除消息ToolStripMenuItem});
            this.系统消息ToolStripMenuItem.Name = "系统消息ToolStripMenuItem";
            this.系统消息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统消息ToolStripMenuItem.Text = "系统消息";
            // 
            // 接收消息设置ToolStripMenuItem
            // 
            this.接收消息设置ToolStripMenuItem.Name = "接收消息设置ToolStripMenuItem";
            this.接收消息设置ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.接收消息设置ToolStripMenuItem.Text = "选择接收消息";
            // 
            // 自定义信息ToolStripMenuItem
            // 
            this.自定义信息ToolStripMenuItem.Name = "自定义信息ToolStripMenuItem";
            this.自定义信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.自定义信息ToolStripMenuItem.Text = "自定义信息";
            // 
            // 消息列表ToolStripMenuItem
            // 
            this.消息列表ToolStripMenuItem.Name = "消息列表ToolStripMenuItem";
            this.消息列表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.消息列表ToolStripMenuItem.Text = "消息列表";
            // 
            // 已删除消息ToolStripMenuItem
            // 
            this.已删除消息ToolStripMenuItem.Name = "已删除消息ToolStripMenuItem";
            this.已删除消息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.已删除消息ToolStripMenuItem.Text = "已删除消息";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.联系管理员ToolStripMenuItem,
            this.意见反馈ToolStripMenuItem,
            this.系统版本ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 联系管理员ToolStripMenuItem
            // 
            this.联系管理员ToolStripMenuItem.Name = "联系管理员ToolStripMenuItem";
            this.联系管理员ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.联系管理员ToolStripMenuItem.Text = "联系管理员";
            // 
            // 意见反馈ToolStripMenuItem
            // 
            this.意见反馈ToolStripMenuItem.Name = "意见反馈ToolStripMenuItem";
            this.意见反馈ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.意见反馈ToolStripMenuItem.Text = "意见反馈";
            // 
            // 系统版本ToolStripMenuItem
            // 
            this.系统版本ToolStripMenuItem.Name = "系统版本ToolStripMenuItem";
            this.系统版本ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.系统版本ToolStripMenuItem.Text = "系统版本";
            // 
            // ucFile1
            // 
            this.ucFile1.BackColor = System.Drawing.Color.White;
            this.ucFile1.Creater = "";
            this.ucFile1.CreaterTitle = "创建人";
            this.ucFile1.CreateTime = "";
            this.ucFile1.CreateTimeTitle = "创建时间";
            this.ucFile1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucFile1.EntityGUID = "";
            this.ucFile1.FileExtension = "";
            this.ucFile1.FileName = "";
            this.ucFile1.FilesCount = 0;
            this.ucFile1.FileTypeCode = "";
            this.ucFile1.ICOPath = "";
            this.ucFile1.IsFocused = false;
            this.ucFile1.IsPower = false;
            this.ucFile1.IsShowCreateInfo = true;
            this.ucFile1.IsShowFilesCount = false;
            this.ucFile1.IsShowTitle = true;
            this.ucFile1.Location = new System.Drawing.Point(107, 230);
            this.ucFile1.Name = "ucFile1";
            this.ucFile1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ucFile1.ParentControl = null;
            this.ucFile1.PreViewFileGUID = "";
            this.ucFile1.PrimaryValue = null;
            this.ucFile1.Size = new System.Drawing.Size(131, 127);
            this.ucFile1.SortID = -1;
            this.ucFile1.TabIndex = 5;
            // 
            // ucTitle1
            // 
            this.ucTitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ucTitle1.Location = new System.Drawing.Point(0, 28);
            this.ucTitle1.Name = "ucTitle1";
            this.ucTitle1.Size = new System.Drawing.Size(850, 30);
            this.ucTitle1.TabIndex = 10;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 785);
            this.Controls.Add(this.ucTitle1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.ucFile1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private UserControls.ucFile ucFile1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出程序ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 切换用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改登录密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看当前登录信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统消息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 接收消息设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自定义信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 消息列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 已删除消息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 联系管理员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 意见反馈ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统版本ToolStripMenuItem;
        private UserControls.ucTitle ucTitle1;
    }
}