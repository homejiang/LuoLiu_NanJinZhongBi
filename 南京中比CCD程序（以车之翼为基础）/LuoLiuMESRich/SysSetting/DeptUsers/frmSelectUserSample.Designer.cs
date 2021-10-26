namespace SysSetting.DeptUsers
{
    partial class frmSelectUserSample
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ucDeptsAndUsers1 = new SysSetting.DeptUsers.ucDeptsAndUsers();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btTrue = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btAllUnChecked = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.ucDeptsAndUsers1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ucDeptsAndUsers1
            // 
            this.ucDeptsAndUsers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDeptsAndUsers1.Location = new System.Drawing.Point(0, 0);
            this.ucDeptsAndUsers1.Margin = new System.Windows.Forms.Padding(0);
            this.ucDeptsAndUsers1.Name = "ucDeptsAndUsers1";
            this.ucDeptsAndUsers1.Size = new System.Drawing.Size(491, 416);
            this.ucDeptsAndUsers1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btAllUnChecked);
            this.panel1.Controls.Add(this.btTrue);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 416);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 34);
            this.panel1.TabIndex = 1;
            // 
            // btTrue
            // 
            this.btTrue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btTrue.Location = new System.Drawing.Point(309, 6);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(75, 23);
            this.btTrue.TabIndex = 1;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btClose.Location = new System.Drawing.Point(404, 6);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "关闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btAllUnChecked
            // 
            this.btAllUnChecked.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btAllUnChecked.Location = new System.Drawing.Point(30, 6);
            this.btAllUnChecked.Name = "btAllUnChecked";
            this.btAllUnChecked.Size = new System.Drawing.Size(109, 23);
            this.btAllUnChecked.TabIndex = 2;
            this.btAllUnChecked.Text = "去除所有选中";
            this.btAllUnChecked.UseVisualStyleBackColor = true;
            this.btAllUnChecked.Click += new System.EventHandler(this.btAllUnChecked_Click);
            // 
            // frmSelectUserSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSelectUserSample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择用户";
            this.Load += new System.EventHandler(this.frmSelectUserSample_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ucDeptsAndUsers ucDeptsAndUsers1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Button btAllUnChecked;

    }
}