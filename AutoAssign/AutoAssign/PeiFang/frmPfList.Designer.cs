namespace AutoAssign.PeiFang
{
    partial class frmPfList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPfList));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslTitle = new System.Windows.Forms.ToolStripDropDownButton();
            this.tscValue = new System.Windows.Forms.ToolStripComboBox();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.tscProcessCode = new System.Windows.Forms.ToolStripComboBox();
            this.tscGongYi = new System.Windows.Forms.ToolStripComboBox();
            this.tscModeView = new System.Windows.Forms.ToolStripComboBox();
            this.dgvList = new MyControl.MyDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(833, 519);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDel,
            this.toolStripSeparator1,
            this.tslTitle,
            this.tscValue,
            this.tsbSearch,
            this.tscProcessCode,
            this.tscGongYi,
            this.tscModeView});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(833, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::AutoAssign.Properties.Resources.new25;
            this.tsbAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(79, 29);
            this.tsbAdd.Text = "新增配方";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = global::AutoAssign.Properties.Resources.edit25;
            this.tsbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(80, 29);
            this.tsbEdit.Text = "编辑配方";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = global::AutoAssign.Properties.Resources.Del25;
            this.tsbDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(55, 29);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // tslTitle
            // 
            this.tslTitle.Name = "tslTitle";
            this.tslTitle.Size = new System.Drawing.Size(69, 29);
            this.tslTitle.Text = "配方名称";
            // 
            // tscValue
            // 
            this.tscValue.Name = "tscValue";
            this.tscValue.Size = new System.Drawing.Size(150, 32);
            this.tscValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstValue_KeyDown);
            // 
            // tsbSearch
            // 
            this.tsbSearch.Image = global::AutoAssign.Properties.Resources.search25;
            this.tsbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(57, 29);
            this.tsbSearch.Text = "搜索";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // tscProcessCode
            // 
            this.tscProcessCode.BackColor = System.Drawing.Color.White;
            this.tscProcessCode.Name = "tscProcessCode";
            this.tscProcessCode.Size = new System.Drawing.Size(95, 32);
            this.tscProcessCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tscProcessCode_KeyDown);
            // 
            // tscGongYi
            // 
            this.tscGongYi.BackColor = System.Drawing.Color.White;
            this.tscGongYi.Name = "tscGongYi";
            this.tscGongYi.Size = new System.Drawing.Size(75, 32);
            this.tscGongYi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tscGongYi_KeyDown);
            // 
            // tscModeView
            // 
            this.tscModeView.BackColor = System.Drawing.Color.White;
            this.tscModeView.Name = "tscModeView";
            this.tscModeView.Size = new System.Drawing.Size(120, 32);
            this.tscModeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tscModeView_KeyDown);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column10,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 33);
            this.dgvList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidth = 37;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.ShowLineNo = true;
            this.dgvList.Size = new System.Drawing.Size(833, 486);
            this.dgvList.TabIndex = 1;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridView1_CellContentClick);
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridView1_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PeiFangName";
            this.Column1.HeaderText = "配方名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 190;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CreaterName";
            this.Column2.HeaderText = "创建人";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 68;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CreateTime";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "创建时间";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ModeView";
            this.Column4.HeaderText = "测试模式";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "ProductClassName";
            this.Column10.HeaderText = "电芯规格分类";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Spec";
            this.Column5.HeaderText = "电芯规格";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 88;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "ProcessCode";
            this.Column6.HeaderText = "所属工序";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 78;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "GongYiTypeName";
            this.Column7.HeaderText = "工艺类型";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 78;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "TerminatedView";
            this.Column8.HeaderText = "状态";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 68;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "";
            this.Column9.MinimumWidth = 2;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 2;
            // 
            // frmPfList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 519);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPfList";
            this.ShowIcon = false;
            this.Text = "配方列表";
            this.Load += new System.EventHandler(this.frmPfList_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private MyControl.MyDataGridView dgvList;
        private System.Windows.Forms.ToolStripComboBox tscGongYi;
        private System.Windows.Forms.ToolStripComboBox tscModeView;
        private System.Windows.Forms.ToolStripComboBox tscProcessCode;
        private System.Windows.Forms.ToolStripDropDownButton tslTitle;
        private System.Windows.Forms.ToolStripComboBox tscValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}