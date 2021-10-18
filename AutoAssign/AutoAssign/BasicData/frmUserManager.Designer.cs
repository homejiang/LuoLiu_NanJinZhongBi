namespace AutoAssign.BasicData
{
    partial class frmUserManager
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkSelect = new System.Windows.Forms.LinkLabel();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comDeptCode = new System.Windows.Forms.ComboBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btAdd = new System.Windows.Forms.Button();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbOn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOff = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbResetPwd = new System.Windows.Forms.ToolStripButton();
            this.dgvList = new MyControl.MyDataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(513, 454);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkSelect);
            this.panel1.Controls.Add(this.tbPwd);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comDeptCode);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btAdd);
            this.panel1.Controls.Add(this.tbCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 81);
            this.panel1.TabIndex = 0;
            // 
            // linkSelect
            // 
            this.linkSelect.AutoSize = true;
            this.linkSelect.Location = new System.Drawing.Point(11, 17);
            this.linkSelect.Name = "linkSelect";
            this.linkSelect.Size = new System.Drawing.Size(63, 14);
            this.linkSelect.TabIndex = 9;
            this.linkSelect.TabStop = true;
            this.linkSelect.Text = "选择用户";
            this.linkSelect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelect_LinkClicked);
            // 
            // tbPwd
            // 
            this.tbPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPwd.Location = new System.Drawing.Point(232, 43);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.Size = new System.Drawing.Size(107, 23);
            this.tbPwd.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "账号类型";
            // 
            // comDeptCode
            // 
            this.comDeptCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comDeptCode.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comDeptCode.FormattingEnabled = true;
            this.comDeptCode.Location = new System.Drawing.Point(78, 42);
            this.comDeptCode.Name = "comDeptCode";
            this.comDeptCode.Size = new System.Drawing.Size(107, 23);
            this.comDeptCode.TabIndex = 5;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.White;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Location = new System.Drawing.Point(232, 14);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(107, 23);
            this.tbName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "姓名";
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(357, 18);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(76, 47);
            this.btAdd.TabIndex = 2;
            this.btAdd.Text = "添加用户";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // tbCode
            // 
            this.tbCode.BackColor = System.Drawing.Color.White;
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCode.Location = new System.Drawing.Point(78, 13);
            this.tbCode.Name = "tbCode";
            this.tbCode.ReadOnly = true;
            this.tbCode.Size = new System.Drawing.Size(107, 23);
            this.tbCode.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDel,
            this.toolStripDropDownButton1,
            this.tsbRefresh,
            this.tsbResetPwd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 87);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(513, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbDel
            // 
            this.tsbDel.Image = global::AutoAssign.Properties.Resources.del;
            this.tsbDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Margin = new System.Windows.Forms.Padding(9, 1, 0, 2);
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(76, 28);
            this.tsbDel.Text = "删除用户";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
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
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(60, 28);
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
            // tsbRefresh
            // 
            this.tsbRefresh.Image = global::AutoAssign.Properties.Resources.refresh_18;
            this.tsbRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(50, 28);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbResetPwd
            // 
            this.tsbResetPwd.Image = global::AutoAssign.Properties.Resources.onMouse;
            this.tsbResetPwd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbResetPwd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbResetPwd.Name = "tsbResetPwd";
            this.tsbResetPwd.Size = new System.Drawing.Size(92, 28);
            this.tsbResetPwd.Text = "重置密码";
            this.tsbResetPwd.Click += new System.EventHandler(this.tsbResetPwd_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 118);
            this.dgvList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.ShowLineNo = true;
            this.dgvList.Size = new System.Drawing.Size(513, 336);
            this.dgvList.TabIndex = 2;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TerminatedView";
            this.Column2.HeaderText = "状态";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "UserCode";
            this.Column1.HeaderText = "用户代码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "UserName";
            this.Column3.HeaderText = "姓名";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DeptName";
            this.Column4.HeaderText = "账户类型";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 120;
            // 
            // frmUserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 454);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserManager";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.frmProcessCode_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private MyControl.MyDataGridView dgvList;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tsbOn;
        private System.Windows.Forms.ToolStripMenuItem tsbOff;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comDeptCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ToolStripButton tsbResetPwd;
        private System.Windows.Forms.LinkLabel linkSelect;
    }
}