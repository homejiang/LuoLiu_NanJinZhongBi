namespace LuoLiuMES.TraceBack
{
    partial class frmTraceBack
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comSFGTypes = new System.Windows.Forms.ComboBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.tbSFGCode = new MyControl.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvSfg = new MyControl.MyDataGridView();
            this.dgvcolLink = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvcolLinkParent = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvcolBindDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtbDetail = new System.Windows.Forms.RichTextBox();
            this.tpgDxDetail = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSfg)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(923, 629);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comSFGTypes);
            this.panel1.Controls.Add(this.btSearch);
            this.panel1.Controls.Add(this.tbSFGCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 35);
            this.panel1.TabIndex = 1;
            // 
            // comSFGTypes
            // 
            this.comSFGTypes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.comSFGTypes.DropDownHeight = 306;
            this.comSFGTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSFGTypes.DropDownWidth = 243;
            this.comSFGTypes.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comSFGTypes.FormattingEnabled = true;
            this.comSFGTypes.IntegralHeight = false;
            this.comSFGTypes.Location = new System.Drawing.Point(91, 5);
            this.comSFGTypes.Name = "comSFGTypes";
            this.comSFGTypes.Size = new System.Drawing.Size(143, 25);
            this.comSFGTypes.TabIndex = 3;
            // 
            // btSearch
            // 
            this.btSearch.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSearch.Location = new System.Drawing.Point(569, 5);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(89, 28);
            this.btSearch.TabIndex = 2;
            this.btSearch.Text = "搜索";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // tbSFGCode
            // 
            this.tbSFGCode.FilterQuanJiao = true;
            this.tbSFGCode.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSFGCode.IsUpper = false;
            this.tbSFGCode.Location = new System.Drawing.Point(240, 5);
            this.tbSFGCode.Name = "tbSFGCode";
            this.tbSFGCode.Size = new System.Drawing.Size(323, 27);
            this.tbSFGCode.TabIndex = 1;
            this.tbSFGCode.TextSplitWorld = "、";
            this.tbSFGCode.ValueSplitWorld = "|";
            this.tbSFGCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSFGCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品类型";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.RoyalBlue;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 38);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvSfg);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(917, 588);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 17;
            // 
            // dgvSfg
            // 
            this.dgvSfg.AllowUserToAddRows = false;
            this.dgvSfg.AllowUserToDeleteRows = false;
            this.dgvSfg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSfg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcolLink,
            this.dgvcolLinkParent,
            this.dgvcolBindDetail});
            this.dgvSfg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSfg.Location = new System.Drawing.Point(0, 0);
            this.dgvSfg.Margin = new System.Windows.Forms.Padding(0);
            this.dgvSfg.MultiSelect = false;
            this.dgvSfg.Name = "dgvSfg";
            this.dgvSfg.ReadOnly = true;
            this.dgvSfg.RowHeadersWidth = 35;
            this.dgvSfg.RowTemplate.Height = 28;
            this.dgvSfg.ShowLineNo = true;
            this.dgvSfg.Size = new System.Drawing.Size(917, 170);
            this.dgvSfg.TabIndex = 15;
            this.dgvSfg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSfg_CellContentClick);
            // 
            // dgvcolLink
            // 
            this.dgvcolLink.HeaderText = "链接";
            this.dgvcolLink.Name = "dgvcolLink";
            this.dgvcolLink.ReadOnly = true;
            this.dgvcolLink.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcolLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcolLink.Text = "   查看子件   ";
            this.dgvcolLink.UseColumnTextForButtonValue = true;
            this.dgvcolLink.Width = 54;
            // 
            // dgvcolLinkParent
            // 
            this.dgvcolLinkParent.HeaderText = "链接";
            this.dgvcolLinkParent.Name = "dgvcolLinkParent";
            this.dgvcolLinkParent.ReadOnly = true;
            this.dgvcolLinkParent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcolLinkParent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcolLinkParent.Text = "   查看父级   ";
            this.dgvcolLinkParent.UseColumnTextForButtonValue = true;
            this.dgvcolLinkParent.Width = 54;
            // 
            // dgvcolBindDetail
            // 
            this.dgvcolBindDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvcolBindDetail.HeaderText = "查看";
            this.dgvcolBindDetail.Name = "dgvcolBindDetail";
            this.dgvcolBindDetail.ReadOnly = true;
            this.dgvcolBindDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcolBindDetail.Text = "  查看详细信息  ";
            this.dgvcolBindDetail.UseColumnTextForButtonValue = true;
            this.dgvcolBindDetail.Width = 35;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpgDxDetail);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(917, 414);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtbDetail);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(909, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "生产及检测详细信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtbDetail
            // 
            this.rtbDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDetail.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbDetail.Location = new System.Drawing.Point(3, 3);
            this.rtbDetail.Margin = new System.Windows.Forms.Padding(0);
            this.rtbDetail.Name = "rtbDetail";
            this.rtbDetail.Size = new System.Drawing.Size(903, 382);
            this.rtbDetail.TabIndex = 0;
            this.rtbDetail.Text = "";
            // 
            // tpgDxDetail
            // 
            this.tpgDxDetail.Location = new System.Drawing.Point(4, 22);
            this.tpgDxDetail.Margin = new System.Windows.Forms.Padding(0);
            this.tpgDxDetail.Name = "tpgDxDetail";
            this.tpgDxDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tpgDxDetail.Size = new System.Drawing.Size(909, 362);
            this.tpgDxDetail.TabIndex = 1;
            this.tpgDxDetail.Text = "电芯明细";
            this.tpgDxDetail.UseVisualStyleBackColor = true;
            // 
            // frmTraceBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 629);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmTraceBack";
            this.Text = "半成品及成品追溯";
            this.Load += new System.EventHandler(this.frmTraceBack_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSfg)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comSFGTypes;
        private System.Windows.Forms.Button btSearch;
        private MyControl.MyTextBox tbSFGCode;
        private System.Windows.Forms.Label label1;
        private MyControl.MyDataGridView dgvSfg;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rtbDetail;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewButtonColumn dgvcolLink;
        private System.Windows.Forms.DataGridViewButtonColumn dgvcolLinkParent;
        private System.Windows.Forms.DataGridViewButtonColumn dgvcolBindDetail;
        private System.Windows.Forms.TabPage tpgDxDetail;
    }
}