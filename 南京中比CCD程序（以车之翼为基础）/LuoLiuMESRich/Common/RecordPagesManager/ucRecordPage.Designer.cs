namespace Common.RecordPagesManager
{
    partial class ucRecordPage
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkGoPage = new System.Windows.Forms.LinkLabel();
            this.tbPageIndex = new System.Windows.Forms.TextBox();
            this.linkNextPage = new System.Windows.Forms.LinkLabel();
            this.linkPerPage = new System.Windows.Forms.LinkLabel();
            this.tbPageRowCount = new System.Windows.Forms.TextBox();
            this.linkPageCount = new System.Windows.Forms.LinkLabel();
            this.labTotal = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 530F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(985, 28);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labTotal);
            this.panel1.Controls.Add(this.linkGoPage);
            this.panel1.Controls.Add(this.tbPageIndex);
            this.panel1.Controls.Add(this.linkNextPage);
            this.panel1.Controls.Add(this.linkPerPage);
            this.panel1.Controls.Add(this.tbPageRowCount);
            this.panel1.Controls.Add(this.linkPageCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(227, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 28);
            this.panel1.TabIndex = 15;
            // 
            // linkGoPage
            // 
            this.linkGoPage.AutoSize = true;
            this.linkGoPage.Location = new System.Drawing.Point(476, 7);
            this.linkGoPage.Name = "linkGoPage";
            this.linkGoPage.Size = new System.Drawing.Size(49, 14);
            this.linkGoPage.TabIndex = 5;
            this.linkGoPage.TabStop = true;
            this.linkGoPage.Text = "跳转至";
            this.linkGoPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGoPage_LinkClicked);
            // 
            // tbPageIndex
            // 
            this.tbPageIndex.BackColor = System.Drawing.Color.White;
            this.tbPageIndex.Location = new System.Drawing.Point(329, 2);
            this.tbPageIndex.Name = "tbPageIndex";
            this.tbPageIndex.ReadOnly = true;
            this.tbPageIndex.Size = new System.Drawing.Size(74, 23);
            this.tbPageIndex.TabIndex = 4;
            this.tbPageIndex.Text = "12/100";
            this.tbPageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // linkNextPage
            // 
            this.linkNextPage.AutoSize = true;
            this.linkNextPage.Location = new System.Drawing.Point(406, 7);
            this.linkNextPage.Name = "linkNextPage";
            this.linkNextPage.Size = new System.Drawing.Size(49, 14);
            this.linkNextPage.TabIndex = 3;
            this.linkNextPage.TabStop = true;
            this.linkNextPage.Text = "下一页";
            this.linkNextPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNextPage_LinkClicked);
            // 
            // linkPerPage
            // 
            this.linkPerPage.AutoSize = true;
            this.linkPerPage.Location = new System.Drawing.Point(277, 6);
            this.linkPerPage.Name = "linkPerPage";
            this.linkPerPage.Size = new System.Drawing.Size(49, 14);
            this.linkPerPage.TabIndex = 2;
            this.linkPerPage.TabStop = true;
            this.linkPerPage.Text = "上一页";
            this.linkPerPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPerPage_LinkClicked);
            // 
            // tbPageRowCount
            // 
            this.tbPageRowCount.BackColor = System.Drawing.Color.White;
            this.tbPageRowCount.Location = new System.Drawing.Point(217, 3);
            this.tbPageRowCount.Name = "tbPageRowCount";
            this.tbPageRowCount.ReadOnly = true;
            this.tbPageRowCount.Size = new System.Drawing.Size(52, 23);
            this.tbPageRowCount.TabIndex = 1;
            this.tbPageRowCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // linkPageCount
            // 
            this.linkPageCount.AutoSize = true;
            this.linkPageCount.Location = new System.Drawing.Point(122, 7);
            this.linkPageCount.Name = "linkPageCount";
            this.linkPageCount.Size = new System.Drawing.Size(91, 14);
            this.linkPageCount.TabIndex = 0;
            this.linkPageCount.TabStop = true;
            this.linkPageCount.Text = "每页显示行数";
            this.linkPageCount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPageCount_LinkClicked);
            // 
            // labTotal
            // 
            this.labTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.labTotal.Location = new System.Drawing.Point(0, 0);
            this.labTotal.Name = "labTotal";
            this.labTotal.Size = new System.Drawing.Size(116, 28);
            this.labTotal.TabIndex = 6;
            this.labTotal.Text = " 总数:0";
            this.labTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucRecordPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "ucRecordPage";
            this.Size = new System.Drawing.Size(985, 28);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkGoPage;
        private System.Windows.Forms.TextBox tbPageIndex;
        private System.Windows.Forms.LinkLabel linkNextPage;
        private System.Windows.Forms.LinkLabel linkPerPage;
        private System.Windows.Forms.TextBox tbPageRowCount;
        private System.Windows.Forms.LinkLabel linkPageCount;
        private System.Windows.Forms.Label labTotal;
    }
}
