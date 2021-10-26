namespace LuoLiuMES.AutoExe
{
    partial class frmUserTongbu
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
            this.tbSourceDesign = new System.Windows.Forms.TextBox();
            this.btTrue = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDesignName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbSourceDesign
            // 
            this.tbSourceDesign.BackColor = System.Drawing.Color.White;
            this.tbSourceDesign.Location = new System.Drawing.Point(32, 89);
            this.tbSourceDesign.Name = "tbSourceDesign";
            this.tbSourceDesign.ReadOnly = true;
            this.tbSourceDesign.Size = new System.Drawing.Size(484, 27);
            this.tbSourceDesign.TabIndex = 0;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(218, 138);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(116, 37);
            this.btTrue.TabIndex = 1;
            this.btTrue.Text = "确 定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(29, 65);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(224, 18);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "选择需要同步的预定义方案";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "当前方案名称";
            // 
            // tbDesignName
            // 
            this.tbDesignName.BackColor = System.Drawing.Color.White;
            this.tbDesignName.Location = new System.Drawing.Point(148, 17);
            this.tbDesignName.Name = "tbDesignName";
            this.tbDesignName.Size = new System.Drawing.Size(368, 27);
            this.tbDesignName.TabIndex = 4;
            // 
            // frmUserTongbu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 194);
            this.Controls.Add(this.tbDesignName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbSourceDesign);
            this.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserTongbu";
            this.ShowIcon = false;
            this.Text = "同步预定义组";
            this.Load += new System.EventHandler(this.frmUserGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSourceDesign;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDesignName;
    }
}