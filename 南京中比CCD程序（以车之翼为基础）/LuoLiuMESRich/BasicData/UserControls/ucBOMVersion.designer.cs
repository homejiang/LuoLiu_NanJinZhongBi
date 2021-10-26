namespace BasicData.UserContorls
{
    partial class ucBOMVersion
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbNo = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkSelVersion = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(82, -14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = ".";
            // 
            // tbNo
            // 
            this.tbNo.BackColor = System.Drawing.Color.White;
            this.tbNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbNo.Location = new System.Drawing.Point(56, 2);
            this.tbNo.Name = "tbNo";
            this.tbNo.ReadOnly = true;
            this.tbNo.Size = new System.Drawing.Size(28, 21);
            this.tbNo.TabIndex = 2;
            this.tbNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDesc
            // 
            this.tbDesc.BackColor = System.Drawing.Color.White;
            this.tbDesc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDesc.Location = new System.Drawing.Point(99, 2);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.ReadOnly = true;
            this.tbDesc.Size = new System.Drawing.Size(68, 21);
            this.tbDesc.TabIndex = 3;
            this.tbDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbRemark, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 25);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tbRemark
            // 
            this.tbRemark.BackColor = System.Drawing.Color.White;
            this.tbRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRemark.Location = new System.Drawing.Point(180, 2);
            this.tbRemark.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.ReadOnly = true;
            this.tbRemark.Size = new System.Drawing.Size(345, 21);
            this.tbRemark.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkSelVersion);
            this.panel1.Controls.Add(this.tbDesc);
            this.panel1.Controls.Add(this.tbNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 25);
            this.panel1.TabIndex = 0;
            // 
            // linkSelVersion
            // 
            this.linkSelVersion.AutoSize = true;
            this.linkSelVersion.Location = new System.Drawing.Point(4, 6);
            this.linkSelVersion.Name = "linkSelVersion";
            this.linkSelVersion.Size = new System.Drawing.Size(47, 12);
            this.linkSelVersion.TabIndex = 0;
            this.linkSelVersion.TabStop = true;
            this.linkSelVersion.Text = "BOM版本";
            this.linkSelVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelVersion_LinkClicked);
            // 
            // ucBOMVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucBOMVersion";
            this.Size = new System.Drawing.Size(525, 25);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNo;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkSelVersion;
        private System.Windows.Forms.TextBox tbRemark;
    }
}
