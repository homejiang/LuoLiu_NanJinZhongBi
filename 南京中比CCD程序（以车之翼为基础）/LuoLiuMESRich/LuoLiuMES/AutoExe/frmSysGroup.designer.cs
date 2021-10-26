namespace LuoLiuMES.AutoExe
{
    partial class frmSysGroup
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
            this.tbCode = new System.Windows.Forms.TextBox();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.btTrue = new System.Windows.Forms.Button();
            this.tbPGroup = new System.Windows.Forms.TextBox();
            this.linkPGroup = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "编码";
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(75, 17);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(125, 27);
            this.tbCode.TabIndex = 1;
            // 
            // tbGroupName
            // 
            this.tbGroupName.Location = new System.Drawing.Point(251, 18);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(258, 27);
            this.tbGroupName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "组名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "备注";
            // 
            // tbRemark
            // 
            this.tbRemark.Location = new System.Drawing.Point(75, 101);
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRemark.Size = new System.Drawing.Size(434, 62);
            this.tbRemark.TabIndex = 7;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(221, 187);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(114, 35);
            this.btTrue.TabIndex = 8;
            this.btTrue.Text = "确 定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // tbPGroup
            // 
            this.tbPGroup.Location = new System.Drawing.Point(75, 48);
            this.tbPGroup.Multiline = true;
            this.tbPGroup.Name = "tbPGroup";
            this.tbPGroup.ReadOnly = true;
            this.tbPGroup.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPGroup.Size = new System.Drawing.Size(434, 49);
            this.tbPGroup.TabIndex = 12;
            // 
            // linkPGroup
            // 
            this.linkPGroup.AutoSize = true;
            this.linkPGroup.Location = new System.Drawing.Point(12, 50);
            this.linkPGroup.Name = "linkPGroup";
            this.linkPGroup.Size = new System.Drawing.Size(62, 18);
            this.linkPGroup.TabIndex = 13;
            this.linkPGroup.TabStop = true;
            this.linkPGroup.Text = "父级组";
            this.linkPGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPGroup_LinkClicked);
            // 
            // frmSysGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 246);
            this.Controls.Add(this.linkPGroup);
            this.Controls.Add(this.tbPGroup);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbRemark);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbGroupName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysGroup";
            this.ShowIcon = false;
            this.Text = "模块组添加";
            this.Load += new System.EventHandler(this.frmSysGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.TextBox tbPGroup;
        private System.Windows.Forms.LinkLabel linkPGroup;
    }
}