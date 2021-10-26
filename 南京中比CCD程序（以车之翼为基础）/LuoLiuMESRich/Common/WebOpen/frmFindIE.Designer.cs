namespace Common.WebOpen
{
    partial class frmFindIE
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
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btTrue = new System.Windows.Forms.Button();
            this.linkSelPath = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前IP";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(132, 32);
            this.tbIP.Margin = new System.Windows.Forms.Padding(4);
            this.tbIP.Name = "tbIP";
            this.tbIP.ReadOnly = true;
            this.tbIP.Size = new System.Drawing.Size(423, 26);
            this.tbIP.TabIndex = 1;
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(132, 71);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(423, 26);
            this.tbPath.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(129, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(344, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "注：如果不指定路径，系统将会读取默认路径。";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(223, 152);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(120, 37);
            this.btTrue.TabIndex = 5;
            this.btTrue.Text = "提 交";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // linkSelPath
            // 
            this.linkSelPath.AutoSize = true;
            this.linkSelPath.Location = new System.Drawing.Point(12, 76);
            this.linkSelPath.Name = "linkSelPath";
            this.linkSelPath.Size = new System.Drawing.Size(120, 16);
            this.linkSelPath.TabIndex = 6;
            this.linkSelPath.TabStop = true;
            this.linkSelPath.Text = "浏览器所在路径";
            this.linkSelPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelPath_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmFindIE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 212);
            this.Controls.Add(this.linkSelPath);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindIE";
            this.ShowIcon = false;
            this.Text = "设置IE浏览器路径";
            this.Load += new System.EventHandler(this.frmFindIE_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.LinkLabel linkSelPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}