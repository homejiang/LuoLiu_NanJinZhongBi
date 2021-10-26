namespace LuoLiuMES.AutoExe
{
    partial class frmSysForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysForms));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tvGroup = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.dgvForms = new MyControl.MyDataGridView();
            this.tstSearchValue = new System.Windows.Forms.ToolStripTextBox();
            this.tsb1Add = new System.Windows.Forms.ToolStripButton();
            this.tsb1Edit = new System.Windows.Forms.ToolStripButton();
            this.tsb1Remove = new System.Windows.Forms.ToolStripButton();
            this.tsb1Up = new System.Windows.Forms.ToolStripButton();
            this.tsb1Down = new System.Windows.Forms.ToolStripButton();
            this.tsb2Add = new System.Windows.Forms.ToolStripButton();
            this.tsb2Edit = new System.Windows.Forms.ToolStripButton();
            this.tsb2Remove = new System.Windows.Forms.ToolStripButton();
            this.tsb2Up = new System.Windows.Forms.ToolStripButton();
            this.tsb2Down = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.是否开启权限校验ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.是否允许打开多个窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.窗口代开类型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模块详细说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移至其他组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForms)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(841, 629);
            this.splitContainer1.SplitterDistance = 241;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tvGroup, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(241, 629);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb1Add,
            this.tsb1Edit,
            this.tsb1Remove,
            this.tsb1Up,
            this.tsb1Down});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(241, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tvGroup
            // 
            this.tvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvGroup.HideSelection = false;
            this.tvGroup.Location = new System.Drawing.Point(0, 25);
            this.tvGroup.Margin = new System.Windows.Forms.Padding(0);
            this.tvGroup.Name = "tvGroup";
            this.tvGroup.Size = new System.Drawing.Size(241, 604);
            this.tvGroup.TabIndex = 1;
            this.tvGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvGroup_AfterSelect);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvForms, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(596, 629);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb2Add,
            this.tsb2Edit,
            this.tsb2Remove,
            this.tsb2Up,
            this.tsb2Down,
            this.toolStripDropDownButton1,
            this.tstSearchValue,
            this.tsbSearch});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(596, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // dgvForms
            // 
            this.dgvForms.AllowUserToAddRows = false;
            this.dgvForms.AllowUserToDeleteRows = false;
            this.dgvForms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column9,
            this.Column11,
            this.Column10,
            this.Column7,
            this.Column8});
            this.dgvForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvForms.Location = new System.Drawing.Point(0, 25);
            this.dgvForms.Margin = new System.Windows.Forms.Padding(0);
            this.dgvForms.Name = "dgvForms";
            this.dgvForms.ReadOnly = true;
            this.dgvForms.RowHeadersWidth = 35;
            this.dgvForms.RowTemplate.Height = 23;
            this.dgvForms.ShowLineNo = true;
            this.dgvForms.Size = new System.Drawing.Size(596, 604);
            this.dgvForms.TabIndex = 1;
            this.dgvForms.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvForms_CellDoubleClick);
            // 
            // tstSearchValue
            // 
            this.tstSearchValue.Margin = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.tstSearchValue.Name = "tstSearchValue";
            this.tstSearchValue.Size = new System.Drawing.Size(100, 25);
            this.tstSearchValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstSearchValue_KeyDown);
            // 
            // tsb1Add
            // 
            this.tsb1Add.Image = global::LuoLiuMES.Properties.Resources.create;
            this.tsb1Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb1Add.Name = "tsb1Add";
            this.tsb1Add.Size = new System.Drawing.Size(49, 22);
            this.tsb1Add.Text = "添加";
            this.tsb1Add.Click += new System.EventHandler(this.tsb1Add_Click);
            // 
            // tsb1Edit
            // 
            this.tsb1Edit.Image = global::LuoLiuMES.Properties.Resources.edit;
            this.tsb1Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb1Edit.Name = "tsb1Edit";
            this.tsb1Edit.Size = new System.Drawing.Size(49, 22);
            this.tsb1Edit.Text = "编辑";
            this.tsb1Edit.Click += new System.EventHandler(this.tsb1Edit_Click);
            // 
            // tsb1Remove
            // 
            this.tsb1Remove.Image = global::LuoLiuMES.Properties.Resources.del;
            this.tsb1Remove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb1Remove.Name = "tsb1Remove";
            this.tsb1Remove.Size = new System.Drawing.Size(49, 22);
            this.tsb1Remove.Text = "移除";
            this.tsb1Remove.Click += new System.EventHandler(this.tsb1Remove_Click);
            // 
            // tsb1Up
            // 
            this.tsb1Up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb1Up.Image = global::LuoLiuMES.Properties.Resources.up;
            this.tsb1Up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb1Up.Name = "tsb1Up";
            this.tsb1Up.Size = new System.Drawing.Size(23, 22);
            this.tsb1Up.Text = "toolStripButton4";
            this.tsb1Up.Click += new System.EventHandler(this.tsb1Up_Click);
            // 
            // tsb1Down
            // 
            this.tsb1Down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb1Down.Image = global::LuoLiuMES.Properties.Resources.down;
            this.tsb1Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb1Down.Name = "tsb1Down";
            this.tsb1Down.Size = new System.Drawing.Size(23, 22);
            this.tsb1Down.Text = "toolStripButton5";
            this.tsb1Down.Click += new System.EventHandler(this.tsb1Down_Click);
            // 
            // tsb2Add
            // 
            this.tsb2Add.Image = global::LuoLiuMES.Properties.Resources.create;
            this.tsb2Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb2Add.Name = "tsb2Add";
            this.tsb2Add.Size = new System.Drawing.Size(49, 22);
            this.tsb2Add.Text = "添加";
            this.tsb2Add.Click += new System.EventHandler(this.tsb2Add_Click);
            // 
            // tsb2Edit
            // 
            this.tsb2Edit.Image = global::LuoLiuMES.Properties.Resources.edit;
            this.tsb2Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb2Edit.Name = "tsb2Edit";
            this.tsb2Edit.Size = new System.Drawing.Size(49, 22);
            this.tsb2Edit.Text = "编辑";
            this.tsb2Edit.Click += new System.EventHandler(this.tsb2Edit_Click);
            // 
            // tsb2Remove
            // 
            this.tsb2Remove.Image = global::LuoLiuMES.Properties.Resources.del;
            this.tsb2Remove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb2Remove.Name = "tsb2Remove";
            this.tsb2Remove.Size = new System.Drawing.Size(49, 22);
            this.tsb2Remove.Text = "移除";
            this.tsb2Remove.Click += new System.EventHandler(this.tsb2Remove_Click);
            // 
            // tsb2Up
            // 
            this.tsb2Up.Image = global::LuoLiuMES.Properties.Resources.up;
            this.tsb2Up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb2Up.Name = "tsb2Up";
            this.tsb2Up.Size = new System.Drawing.Size(49, 22);
            this.tsb2Up.Text = "上移";
            this.tsb2Up.Click += new System.EventHandler(this.tsb2Up_Click);
            // 
            // tsb2Down
            // 
            this.tsb2Down.Image = global::LuoLiuMES.Properties.Resources.down;
            this.tsb2Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb2Down.Name = "tsb2Down";
            this.tsb2Down.Size = new System.Drawing.Size(49, 22);
            this.tsb2Down.Text = "下移";
            this.tsb2Down.Click += new System.EventHandler(this.tsb2Down_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.是否开启权限校验ToolStripMenuItem,
            this.是否允许打开多个窗体ToolStripMenuItem,
            this.窗口代开类型ToolStripMenuItem,
            this.模块详细说明ToolStripMenuItem,
            this.移至其他组ToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(66, 22);
            this.toolStripDropDownButton1.Text = "其他设置";
            // 
            // 是否开启权限校验ToolStripMenuItem
            // 
            this.是否开启权限校验ToolStripMenuItem.Name = "是否开启权限校验ToolStripMenuItem";
            this.是否开启权限校验ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.是否开启权限校验ToolStripMenuItem.Text = "是否开启权限校验";
            // 
            // 是否允许打开多个窗体ToolStripMenuItem
            // 
            this.是否允许打开多个窗体ToolStripMenuItem.Name = "是否允许打开多个窗体ToolStripMenuItem";
            this.是否允许打开多个窗体ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.是否允许打开多个窗体ToolStripMenuItem.Text = "是否允许打开多个窗体";
            // 
            // 窗口代开类型ToolStripMenuItem
            // 
            this.窗口代开类型ToolStripMenuItem.Name = "窗口代开类型ToolStripMenuItem";
            this.窗口代开类型ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.窗口代开类型ToolStripMenuItem.Text = "窗口打开类型";
            // 
            // 模块详细说明ToolStripMenuItem
            // 
            this.模块详细说明ToolStripMenuItem.Name = "模块详细说明ToolStripMenuItem";
            this.模块详细说明ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.模块详细说明ToolStripMenuItem.Text = "模块详细说明";
            // 
            // 移至其他组ToolStripMenuItem
            // 
            this.移至其他组ToolStripMenuItem.Name = "移至其他组ToolStripMenuItem";
            this.移至其他组ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.移至其他组ToolStripMenuItem.Text = "移至其他组";
            this.移至其他组ToolStripMenuItem.Click += new System.EventHandler(this.移至其他组ToolStripMenuItem_Click);
            // 
            // tsbSearch
            // 
            this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSearch.Image = global::LuoLiuMES.Properties.Resources.search25;
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(23, 22);
            this.tsbSearch.Text = "toolStripButton1";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Code";
            this.Column1.HeaderText = "窗口代码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 78;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "FormName";
            this.Column2.HeaderText = "窗口名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 88;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "FullGroupName";
            this.Column3.HeaderText = "所在组";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ClassName";
            this.Column4.HeaderText = "详细类名";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 110;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ProjectName";
            this.Column5.HeaderText = "所在项目名称";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 108;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Parameters";
            this.Column9.HeaderText = "传入参数";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 110;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "UserLevelView";
            this.Column11.HeaderText = "用户级别";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 78;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Powers";
            this.Column10.HeaderText = "校验权限内容";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 108;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "IsMultiView";
            this.Column7.HeaderText = "打开多个窗口";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 108;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "DialogTypeView";
            this.Column8.HeaderText = "窗口打开方式";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 108;
            // 
            // frmSysForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 629);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmSysForms";
            this.Text = "系统模块设置";
            this.Load += new System.EventHandler(this.frmSysForms_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb1Add;
        private System.Windows.Forms.ToolStripButton tsb1Remove;
        private System.Windows.Forms.ToolStripButton tsb1Edit;
        private System.Windows.Forms.ToolStripButton tsb1Up;
        private System.Windows.Forms.ToolStripButton tsb1Down;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsb2Add;
        private System.Windows.Forms.ToolStripButton tsb2Edit;
        private System.Windows.Forms.ToolStripButton tsb2Remove;
        private System.Windows.Forms.ToolStripButton tsb2Up;
        private System.Windows.Forms.ToolStripButton tsb2Down;
        private MyControl.MyDataGridView dgvForms;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem 是否开启权限校验ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 是否允许打开多个窗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 窗口代开类型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模块详细说明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移至其他组ToolStripMenuItem;
        private System.Windows.Forms.TreeView tvGroup;
        private System.Windows.Forms.ToolStripTextBox tstSearchValue;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}