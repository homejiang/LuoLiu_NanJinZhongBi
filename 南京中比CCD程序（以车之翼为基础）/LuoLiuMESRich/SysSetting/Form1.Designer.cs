namespace SysSetting
{
    partial class Form1
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
            this.ucDeptsAndUsers1 = new SysSetting.DeptUsers.ucDeptsAndUsers();
            this.SuspendLayout();
            // 
            // ucDeptsAndUsers1
            // 
            this.ucDeptsAndUsers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDeptsAndUsers1.Location = new System.Drawing.Point(0, 0);
            this.ucDeptsAndUsers1.Name = "ucDeptsAndUsers1";
            this.ucDeptsAndUsers1.Size = new System.Drawing.Size(544, 350);
            this.ucDeptsAndUsers1.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(544, 350);
            this.Controls.Add(this.ucDeptsAndUsers1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SysSetting.DeptUsers.ucDeptsAndUsers ucDeptsAndUsers1;
    }
}

