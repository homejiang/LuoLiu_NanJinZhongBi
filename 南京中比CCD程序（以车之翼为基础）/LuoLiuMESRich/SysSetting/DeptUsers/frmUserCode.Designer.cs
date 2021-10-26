namespace SysSetting.DeptUsers
{
    partial class frmUserCode
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
            this.myTextBox1 = new MyControl.MyTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.linkFind = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入工号";
            // 
            // myTextBox1
            // 
            this.myTextBox1.FilterQuanJiao = true;
            this.myTextBox1.IsUpper = false;
            this.myTextBox1.Location = new System.Drawing.Point(85, 13);
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.Size = new System.Drawing.Size(135, 21);
            this.myTextBox1.TabIndex = 1;
            this.myTextBox1.TextSplitWorld = "、";
            this.myTextBox1.ValueSplitWorld = "|";
            this.myTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myTextBox1_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkFind
            // 
            this.linkFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkFind.AutoSize = true;
            this.linkFind.Location = new System.Drawing.Point(2, 84);
            this.linkFind.Name = "linkFind";
            this.linkFind.Size = new System.Drawing.Size(29, 12);
            this.linkFind.TabIndex = 3;
            this.linkFind.TabStop = true;
            this.linkFind.Text = "查找";
            this.linkFind.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFind_LinkClicked);
            // 
            // frmUserCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 102);
            this.Controls.Add(this.linkFind);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.myTextBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserCode";
            this.ShowIcon = false;
            this.Text = "修改用户";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private MyControl.MyTextBox myTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkFind;
    }
}