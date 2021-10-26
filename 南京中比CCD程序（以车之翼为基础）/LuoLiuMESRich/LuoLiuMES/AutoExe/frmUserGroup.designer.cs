namespace LuoLiuMES.AutoExe
{
    partial class frmUserGroup
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
            this.tbGroup = new System.Windows.Forms.TextBox();
            this.btTrue = new System.Windows.Forms.Button();
            this.chkExpand = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbGroup
            // 
            this.tbGroup.Location = new System.Drawing.Point(30, 22);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(306, 27);
            this.tbGroup.TabIndex = 0;
            this.tbGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbGroup_KeyDown);
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(116, 118);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(116, 37);
            this.btTrue.TabIndex = 1;
            this.btTrue.Text = "确 定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // chkExpand
            // 
            this.chkExpand.AutoSize = true;
            this.chkExpand.Location = new System.Drawing.Point(32, 67);
            this.chkExpand.Name = "chkExpand";
            this.chkExpand.Size = new System.Drawing.Size(99, 22);
            this.chkExpand.TabIndex = 2;
            this.chkExpand.Text = "默认展开";
            this.chkExpand.UseVisualStyleBackColor = true;
            // 
            // frmUserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 180);
            this.Controls.Add(this.chkExpand);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbGroup);
            this.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserGroup";
            this.ShowIcon = false;
            this.Text = "模块组编辑";
            this.Load += new System.EventHandler(this.frmUserGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbGroup;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.CheckBox chkExpand;
    }
}