namespace UpdateERP
{
    partial class frmUpdateVersion
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
            this.dgvNewP = new MyControl.MyDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myDataGridView1 = new MyControl.MyDataGridView();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btRemovePdb = new System.Windows.Forms.Button();
            this.btCurrentRemark = new System.Windows.Forms.Button();
            this.btRemark = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btUpdateExe = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvNewP, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.myDataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(909, 574);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvNewP
            // 
            this.dgvNewP.AllowUserToAddRows = false;
            this.dgvNewP.AllowUserToDeleteRows = false;
            this.dgvNewP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column1,
            this.dataGridViewTextBoxColumn7});
            this.dgvNewP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNewP.Location = new System.Drawing.Point(0, 417);
            this.dgvNewP.Margin = new System.Windows.Forms.Padding(0);
            this.dgvNewP.Name = "dgvNewP";
            this.dgvNewP.RowTemplate.Height = 23;
            this.dgvNewP.ShowLineNo = true;
            this.dgvNewP.Size = new System.Drawing.Size(909, 107);
            this.dgvNewP.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProjectName";
            this.dataGridViewTextBoxColumn1.HeaderText = "项目名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProjectVersion";
            this.dataGridViewTextBoxColumn2.HeaderText = "当前版本号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ProjectGuid";
            this.dataGridViewTextBoxColumn3.HeaderText = "唯一识别码";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ForProjectName";
            this.Column1.HeaderText = "关联应用程序";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 6;
            // 
            // myDataGridView1
            // 
            this.myDataGridView1.AllowUserToAddRows = false;
            this.myDataGridView1.AllowUserToDeleteRows = false;
            this.myDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckBox,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column8});
            this.myDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridView1.Location = new System.Drawing.Point(0, 35);
            this.myDataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.myDataGridView1.Name = "myDataGridView1";
            this.myDataGridView1.RowTemplate.Height = 23;
            this.myDataGridView1.ShowLineNo = true;
            this.myDataGridView1.Size = new System.Drawing.Size(909, 363);
            this.myDataGridView1.TabIndex = 1;
            // 
            // colCheckBox
            // 
            this.colCheckBox.HeaderText = "";
            this.colCheckBox.Name = "colCheckBox";
            this.colCheckBox.Width = 40;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ProjectName";
            this.Column2.HeaderText = "项目名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ProjectVersion";
            this.Column3.HeaderText = "当前版本号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Guid";
            this.Column5.HeaderText = "唯一识别码";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "FilesName";
            this.Column4.HeaderText = "包含文件";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 160;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "DataBaseVersion";
            this.Column6.HeaderText = "已更新版本";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "DataBaseFilesName";
            this.Column7.HeaderText = "已更新文件";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 140;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "";
            this.Column8.Name = "Column8";
            this.Column8.Width = 6;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button1.Location = new System.Drawing.Point(391, 527);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "保 存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btUpdateExe);
            this.panel1.Controls.Add(this.btRemovePdb);
            this.panel1.Controls.Add(this.btCurrentRemark);
            this.panel1.Controls.Add(this.btRemark);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 35);
            this.panel1.TabIndex = 2;
            // 
            // btRemovePdb
            // 
            this.btRemovePdb.Location = new System.Drawing.Point(792, 4);
            this.btRemovePdb.Name = "btRemovePdb";
            this.btRemovePdb.Size = new System.Drawing.Size(114, 29);
            this.btRemovePdb.TabIndex = 2;
            this.btRemovePdb.Text = "移除pdb文件";
            this.btRemovePdb.UseVisualStyleBackColor = true;
            this.btRemovePdb.Click += new System.EventHandler(this.btRemovePdb_Click);
            // 
            // btCurrentRemark
            // 
            this.btCurrentRemark.Location = new System.Drawing.Point(114, 4);
            this.btCurrentRemark.Name = "btCurrentRemark";
            this.btCurrentRemark.Size = new System.Drawing.Size(118, 29);
            this.btCurrentRemark.TabIndex = 1;
            this.btCurrentRemark.Text = "当前版本备注";
            this.btCurrentRemark.UseVisualStyleBackColor = true;
            this.btCurrentRemark.Click += new System.EventHandler(this.btCurrentRemark_Click);
            // 
            // btRemark
            // 
            this.btRemark.Location = new System.Drawing.Point(12, 3);
            this.btRemark.Name = "btRemark";
            this.btRemark.Size = new System.Drawing.Size(85, 29);
            this.btRemark.TabIndex = 0;
            this.btRemark.Text = "历史备注";
            this.btRemark.UseVisualStyleBackColor = true;
            this.btRemark.Click += new System.EventHandler(this.btRemark_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 398);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(909, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "新增加的模块";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btUpdateExe
            // 
            this.btUpdateExe.Location = new System.Drawing.Point(638, 4);
            this.btUpdateExe.Name = "btUpdateExe";
            this.btUpdateExe.Size = new System.Drawing.Size(124, 29);
            this.btUpdateExe.TabIndex = 3;
            this.btUpdateExe.Text = "关于Update.exe";
            this.btUpdateExe.UseVisualStyleBackColor = true;
            this.btUpdateExe.Click += new System.EventHandler(this.btUpdateExe_Click);
            // 
            // frmUpdateVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 574);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmUpdateVersion";
            this.Text = "存储项目最新版本";
            this.Load += new System.EventHandler(this.frmUpdateVersion_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private MyControl.MyDataGridView myDataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCurrentRemark;
        private System.Windows.Forms.Button btRemark;
        private System.Windows.Forms.Button btRemovePdb;
        private System.Windows.Forms.Label label1;
        private MyControl.MyDataGridView dgvNewP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Button btUpdateExe;
    }
}