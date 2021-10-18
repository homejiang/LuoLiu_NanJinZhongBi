namespace AutoAssign.PeiFang
{
    partial class frmSelectPf
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectPf));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btTrue = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comProcessCode = new System.Windows.Forms.ComboBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.comProductSpec = new System.Windows.Forms.ComboBox();
            this.comGongYiType = new System.Windows.Forms.ComboBox();
            this.comModeIsScaner = new System.Windows.Forms.ComboBox();
            this.comModeIsNeter = new System.Windows.Forms.ComboBox();
            this.tbPeifangName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvList = new MyControl.MyDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGrooves = new MyControl.MyDataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrooves)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 569F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(793, 646);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btTrue);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 605);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 38);
            this.panel2.TabIndex = 5;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(684, 2);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(84, 32);
            this.btTrue.TabIndex = 0;
            this.btTrue.Text = "选 中";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comProcessCode);
            this.panel1.Controls.Add(this.btSearch);
            this.panel1.Controls.Add(this.comProductSpec);
            this.panel1.Controls.Add(this.comGongYiType);
            this.panel1.Controls.Add(this.comModeIsScaner);
            this.panel1.Controls.Add(this.comModeIsNeter);
            this.panel1.Controls.Add(this.tbPeifangName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 33);
            this.panel1.TabIndex = 6;
            // 
            // comProcessCode
            // 
            this.comProcessCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comProcessCode.FormattingEnabled = true;
            this.comProcessCode.Location = new System.Drawing.Point(626, 7);
            this.comProcessCode.Name = "comProcessCode";
            this.comProcessCode.Size = new System.Drawing.Size(77, 20);
            this.comProcessCode.TabIndex = 7;
            this.comProcessCode.SelectedIndexChanged += new System.EventHandler(this.comProcessCode_SelectedIndexChanged);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(714, 5);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(67, 23);
            this.btSearch.TabIndex = 6;
            this.btSearch.Text = "搜索";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // comProductSpec
            // 
            this.comProductSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comProductSpec.FormattingEnabled = true;
            this.comProductSpec.Location = new System.Drawing.Point(498, 7);
            this.comProductSpec.Name = "comProductSpec";
            this.comProductSpec.Size = new System.Drawing.Size(122, 20);
            this.comProductSpec.TabIndex = 5;
            this.comProductSpec.SelectedIndexChanged += new System.EventHandler(this.comProductSpec_SelectedIndexChanged);
            // 
            // comGongYiType
            // 
            this.comGongYiType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comGongYiType.FormattingEnabled = true;
            this.comGongYiType.Location = new System.Drawing.Point(401, 7);
            this.comGongYiType.Name = "comGongYiType";
            this.comGongYiType.Size = new System.Drawing.Size(91, 20);
            this.comGongYiType.TabIndex = 4;
            this.comGongYiType.SelectedIndexChanged += new System.EventHandler(this.comGongYiType_SelectedIndexChanged);
            // 
            // comModeIsScaner
            // 
            this.comModeIsScaner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comModeIsScaner.FormattingEnabled = true;
            this.comModeIsScaner.Location = new System.Drawing.Point(324, 7);
            this.comModeIsScaner.Name = "comModeIsScaner";
            this.comModeIsScaner.Size = new System.Drawing.Size(72, 20);
            this.comModeIsScaner.TabIndex = 3;
            this.comModeIsScaner.SelectedIndexChanged += new System.EventHandler(this.comModeIsScaner_SelectedIndexChanged);
            // 
            // comModeIsNeter
            // 
            this.comModeIsNeter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comModeIsNeter.FormattingEnabled = true;
            this.comModeIsNeter.Location = new System.Drawing.Point(252, 7);
            this.comModeIsNeter.Name = "comModeIsNeter";
            this.comModeIsNeter.Size = new System.Drawing.Size(66, 20);
            this.comModeIsNeter.TabIndex = 2;
            this.comModeIsNeter.SelectedIndexChanged += new System.EventHandler(this.comModeIsNeter_SelectedIndexChanged);
            // 
            // tbPeifangName
            // 
            this.tbPeifangName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPeifangName.Location = new System.Drawing.Point(71, 6);
            this.tbPeifangName.Name = "tbPeifangName";
            this.tbPeifangName.Size = new System.Drawing.Size(176, 21);
            this.tbPeifangName.TabIndex = 1;
            this.tbPeifangName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPeifangName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "配方名称";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 33);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvGrooves);
            this.splitContainer1.Size = new System.Drawing.Size(793, 569);
            this.splitContainer1.SplitterDistance = 353;
            this.splitContainer1.TabIndex = 7;
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
            this.Column5,
            this.Column6});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidth = 35;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.ShowLineNo = true;
            this.dgvList.Size = new System.Drawing.Size(793, 353);
            this.dgvList.TabIndex = 1;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridView1_CellContentClick);
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridView1_CellDoubleClick);
            this.dgvList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvList_CellMouseClick);
            this.dgvList.SelectionChanged += new System.EventHandler(this.myDataGridView1_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PeiFangName";
            this.Column1.HeaderText = "配方名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 380;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ModeView";
            this.Column2.HeaderText = "测试模式";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 110;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "GongYiTypeName";
            this.Column3.HeaderText = "工艺";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 68;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Spec";
            this.Column4.HeaderText = "电芯规格";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ProcessCode";
            this.Column5.HeaderText = "工序";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 78;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.MinimumWidth = 2;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 2;
            // 
            // dgvGrooves
            // 
            this.dgvGrooves.AllowUserToAddRows = false;
            this.dgvGrooves.AllowUserToDeleteRows = false;
            this.dgvGrooves.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrooves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrooves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column9,
            this.Column8,
            this.Column10,
            this.Column11,
            this.Column13,
            this.Column12});
            this.dgvGrooves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrooves.Location = new System.Drawing.Point(0, 0);
            this.dgvGrooves.Name = "dgvGrooves";
            this.dgvGrooves.ReadOnly = true;
            this.dgvGrooves.RowHeadersVisible = false;
            this.dgvGrooves.RowTemplate.Height = 23;
            this.dgvGrooves.Size = new System.Drawing.Size(793, 212);
            this.dgvGrooves.TabIndex = 0;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "GrooveNo";
            this.Column7.HeaderText = "槽";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 38;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "DianZuRange";
            this.Column9.HeaderText = "电阻范围";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 120;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "VRange";
            this.Column8.HeaderText = "电压范围";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 120;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "QualityView";
            this.Column10.HeaderText = "品质";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 68;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "QualityDesc";
            this.Column11.HeaderText = "品质说明";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column11.Width = 300;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "TuoBtyCount";
            this.Column13.HeaderText = "每托电芯数";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 88;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "";
            this.Column12.MinimumWidth = 2;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmSelectPf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 646);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSelectPf";
            this.ShowIcon = false;
            this.Text = "配方选择";
            this.Load += new System.EventHandler(this.frmPfList_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrooves)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MyControl.MyDataGridView dgvList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbPeifangName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comModeIsScaner;
        private System.Windows.Forms.ComboBox comModeIsNeter;
        private System.Windows.Forms.ComboBox comGongYiType;
        private System.Windows.Forms.ComboBox comProductSpec;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.ComboBox comProcessCode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MyControl.MyDataGridView dgvGrooves;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
    }
}