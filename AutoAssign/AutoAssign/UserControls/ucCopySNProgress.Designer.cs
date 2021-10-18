namespace AutoAssign.UserControls
{
    partial class ucCopySNProgress
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labMac = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panContainer = new System.Windows.Forms.Panel();
            this.labProgress = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labStatus = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel1.Controls.Add(this.labMac, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 37);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labMac
            // 
            this.labMac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labMac.Location = new System.Drawing.Point(3, 0);
            this.labMac.Name = "labMac";
            this.labMac.Size = new System.Drawing.Size(48, 37);
            this.labMac.TabIndex = 0;
            this.labMac.Text = "设备？";
            this.labMac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panContainer, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(54, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(422, 37);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panContainer
            // 
            this.panContainer.BackColor = System.Drawing.Color.Maroon;
            this.panContainer.Controls.Add(this.labProgress);
            this.panContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContainer.Location = new System.Drawing.Point(0, 8);
            this.panContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(422, 20);
            this.panContainer.TabIndex = 0;
            // 
            // labProgress
            // 
            this.labProgress.BackColor = System.Drawing.Color.Lime;
            this.labProgress.Dock = System.Windows.Forms.DockStyle.Left;
            this.labProgress.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labProgress.Location = new System.Drawing.Point(0, 0);
            this.labProgress.Name = "labProgress";
            this.labProgress.Size = new System.Drawing.Size(28, 20);
            this.labProgress.TabIndex = 0;
            this.labProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labStatus);
            this.panel2.Controls.Add(this.button);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(476, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(147, 37);
            this.panel2.TabIndex = 2;
            // 
            // labStatus
            // 
            this.labStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.labStatus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labStatus.Location = new System.Drawing.Point(59, 0);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(88, 37);
            this.labStatus.TabIndex = 1;
            this.labStatus.Text = "拷贝中...";
            this.labStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labStatus.DoubleClick += new System.EventHandler(this.labStatus_DoubleClick);
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(8, 4);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(46, 28);
            this.button.TabIndex = 0;
            this.button.Text = "停止";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // ucCopySNProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucCopySNProgress";
            this.Size = new System.Drawing.Size(623, 37);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labMac;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panContainer;
        private System.Windows.Forms.Label labProgress;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label labStatus;
    }
}
