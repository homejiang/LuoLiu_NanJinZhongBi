using System.Windows.Forms;
namespace AutoAssign.AutoCode
{
    partial class frmAutoCode
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btdd = new System.Windows.Forms.Button();
            this.btmm = new System.Windows.Forms.Button();
            this.btyy = new System.Windows.Forms.Button();
            this.btyyyy = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btSave = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1052, 538);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btClear);
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Controls.Add(this.btdd);
            this.panel1.Controls.Add(this.btmm);
            this.panel1.Controls.Add(this.btyy);
            this.panel1.Controls.Add(this.btyyyy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1052, 37);
            this.panel1.TabIndex = 0;
            // 
            // btdd
            // 
            this.btdd.Location = new System.Drawing.Point(272, 7);
            this.btdd.Name = "btdd";
            this.btdd.Size = new System.Drawing.Size(75, 23);
            this.btdd.TabIndex = 3;
            this.btdd.Text = "+日(2位)";
            this.btdd.UseVisualStyleBackColor = true;
            this.btdd.Click += new System.EventHandler(this.btdd_Click);
            // 
            // btmm
            // 
            this.btmm.Location = new System.Drawing.Point(189, 7);
            this.btmm.Name = "btmm";
            this.btmm.Size = new System.Drawing.Size(75, 23);
            this.btmm.TabIndex = 2;
            this.btmm.Text = "+月(2位)";
            this.btmm.UseVisualStyleBackColor = true;
            this.btmm.Click += new System.EventHandler(this.btmm_Click);
            // 
            // btyy
            // 
            this.btyy.Location = new System.Drawing.Point(103, 7);
            this.btyy.Name = "btyy";
            this.btyy.Size = new System.Drawing.Size(75, 23);
            this.btyy.TabIndex = 1;
            this.btyy.Text = "+年(2位)";
            this.btyy.UseVisualStyleBackColor = true;
            this.btyy.Click += new System.EventHandler(this.btyy_Click);
            // 
            // btyyyy
            // 
            this.btyyyy.Location = new System.Drawing.Point(15, 7);
            this.btyyyy.Name = "btyyyy";
            this.btyyyy.Size = new System.Drawing.Size(75, 23);
            this.btyyyy.TabIndex = 0;
            this.btyyyy.Text = "+年(4位)";
            this.btyyyy.UseVisualStyleBackColor = true;
            this.btyyyy.Click += new System.EventHandler(this.btyyyy_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 40);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersWidth = 25;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1046, 495);
            this.dgvList.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ModuleName";
            this.Column1.HeaderText = "模块名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CodeRule";
            this.Column2.HeaderText = "编码规则";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SerialLen";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "#######0";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "流水号长度";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(401, 7);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 27);
            this.btSave.TabIndex = 6;
            this.btSave.Text = "提 交";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(507, 7);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 27);
            this.btClear.TabIndex = 7;
            this.btClear.Text = "清 除";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // frmAutoCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 538);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmAutoCode";
            this.Text = "自动编码设置";
            this.Load += new System.EventHandler(this.frmAutoCode_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btdd;
        private System.Windows.Forms.Button btmm;
        private System.Windows.Forms.Button btyy;
        private System.Windows.Forms.Button btyyyy;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Button btClear;
        private Button btSave;

    }
}