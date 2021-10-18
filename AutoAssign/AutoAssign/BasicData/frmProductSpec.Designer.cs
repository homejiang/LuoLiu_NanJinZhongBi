namespace AutoAssign.BasicData
{
    partial class frmProductSpec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbOn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOff = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.dgvList = new MyControl.MyDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbClassAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbClassEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbClassDel = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(621, 585);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.toolStripDropDownButton1,
            this.tsbDel,
            this.tsbRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(621, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::AutoAssign.Properties.Resources.create;
            this.tsbAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Margin = new System.Windows.Forms.Padding(9, 1, 0, 2);
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(100, 23);
            this.tsbAdd.Text = "添加电芯规格";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOn,
            this.tsbOff});
            this.toolStripDropDownButton1.Image = global::AutoAssign.Properties.Resources.edit;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(60, 23);
            this.toolStripDropDownButton1.Text = "状态";
            // 
            // tsbOn
            // 
            this.tsbOn.Name = "tsbOn";
            this.tsbOn.Size = new System.Drawing.Size(124, 22);
            this.tsbOn.Text = "设为启用";
            this.tsbOn.Click += new System.EventHandler(this.tsbOn_Click);
            // 
            // tsbOff
            // 
            this.tsbOff.Name = "tsbOff";
            this.tsbOff.Size = new System.Drawing.Size(124, 22);
            this.tsbOff.Text = "设为停用";
            this.tsbOff.Click += new System.EventHandler(this.tsbOff_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = global::AutoAssign.Properties.Resources.del;
            this.tsbDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(52, 23);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = global::AutoAssign.Properties.Resources.refresh_18;
            this.tsbRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(50, 23);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 27);
            this.dgvList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.ShowLineNo = true;
            this.dgvList.Size = new System.Drawing.Size(621, 558);
            this.dgvList.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Spec";
            this.Column1.HeaderText = "电芯规格";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 280;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TerminatedView";
            this.Column2.HeaderText = "状态";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(808, 585);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.treeView1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(183, 585);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClassAdd,
            this.tsbClassEdit,
            this.tsbClassDel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(183, 26);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbClassAdd
            // 
            this.tsbClassAdd.Image = global::AutoAssign.Properties.Resources.create;
            this.tsbClassAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClassAdd.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbClassAdd.Name = "tsbClassAdd";
            this.tsbClassAdd.Size = new System.Drawing.Size(52, 23);
            this.tsbClassAdd.Text = "添加";
            this.tsbClassAdd.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tsbClassEdit
            // 
            this.tsbClassEdit.Image = global::AutoAssign.Properties.Resources.edit;
            this.tsbClassEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClassEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClassEdit.Name = "tsbClassEdit";
            this.tsbClassEdit.Size = new System.Drawing.Size(51, 23);
            this.tsbClassEdit.Text = "编辑";
            this.tsbClassEdit.Click += new System.EventHandler(this.tsbClassEdit_Click);
            // 
            // tsbClassDel
            // 
            this.tsbClassDel.Image = global::AutoAssign.Properties.Resources.del;
            this.tsbClassDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClassDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClassDel.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.tsbClassDel.Name = "tsbClassDel";
            this.tsbClassDel.Size = new System.Drawing.Size(52, 21);
            this.tsbClassDel.Text = "删除";
            this.tsbClassDel.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 29);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(177, 553);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // frmProductSpec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 585);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductSpec";
            this.Text = "电芯规格管理";
            this.Load += new System.EventHandler(this.frmProcessCode_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private MyControl.MyDataGridView dgvList;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tsbOn;
        private System.Windows.Forms.ToolStripMenuItem tsbOff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbClassDel;
        private System.Windows.Forms.ToolStripButton tsbClassAdd;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbClassEdit;
    }
}