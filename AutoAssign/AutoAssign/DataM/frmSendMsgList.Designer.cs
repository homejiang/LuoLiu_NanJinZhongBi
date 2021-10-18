namespace AutoAssign.DataM
{
    partial class frmSendMsgList
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
            this.ucRecordPage1 = new AutoAssign.RecordPagesManager.ucRecordPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbTestCode = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tbTuoCode = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tbSnCode = new System.Windows.Forms.ToolStripTextBox();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.dgvList = new MyControl.MyDataGridView();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tscState = new System.Windows.Forms.ToolStripComboBox();
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
            this.tableLayoutPanel1.Controls.Add(this.ucRecordPage1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 661);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ucRecordPage1
            // 
            this.ucRecordPage1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucRecordPage1.Location = new System.Drawing.Point(3, 629);
            this.ucRecordPage1.Name = "ucRecordPage1";
            this.ucRecordPage1.Size = new System.Drawing.Size(978, 29);
            this.ucRecordPage1.TabIndex = 0;
            this.ucRecordPage1.GoToPage_Going += new AutoAssign.RecordPagesManager.ucRecordPage.GoToPage(this.ucRecordPage1_GoToPage_Going);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tbTestCode,
            this.toolStripLabel2,
            this.tbTuoCode,
            this.toolStripLabel3,
            this.tbSnCode,
            this.toolStripLabel4,
            this.tscState,
            this.tsbSearch,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip1_KeyDown);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 29);
            this.toolStripLabel1.Text = "订单编号";
            // 
            // tbTestCode
            // 
            this.tbTestCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTestCode.Name = "tbTestCode";
            this.tbTestCode.Size = new System.Drawing.Size(100, 32);
            this.tbTestCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTestCode_KeyDown);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 29);
            this.toolStripLabel2.Text = "托盘编号";
            // 
            // tbTuoCode
            // 
            this.tbTuoCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTuoCode.Name = "tbTuoCode";
            this.tbTuoCode.Size = new System.Drawing.Size(100, 32);
            this.tbTuoCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTuoCode_KeyDown);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(56, 29);
            this.toolStripLabel3.Text = "电芯条码";
            // 
            // tbSnCode
            // 
            this.tbSnCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSnCode.Name = "tbSnCode";
            this.tbSnCode.Size = new System.Drawing.Size(140, 32);
            this.tbSnCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSnCode_KeyDown);
            // 
            // tsbSearch
            // 
            this.tsbSearch.Image = global::AutoAssign.Properties.Resources.search25;
            this.tsbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(57, 29);
            this.tsbSearch.Text = "查询";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::AutoAssign.Properties.Resources.EXCEL;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(89, 29);
            this.toolStripButton2.Text = "导出Excel";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::AutoAssign.Properties.Resources.exit25;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(61, 29);
            this.toolStripButton3.Text = "关闭";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 34);
            this.dgvList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.ShowLineNo = true;
            this.dgvList.Size = new System.Drawing.Size(984, 592);
            this.dgvList.TabIndex = 2;
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(32, 29);
            this.toolStripLabel4.Text = "状态";
            // 
            // tscState
            // 
            this.tscState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscState.Name = "tscState";
            this.tscState.Size = new System.Drawing.Size(100, 32);
            // 
            // frmSendMsgList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSendMsgList";
            this.Text = "已上传MES数据";
            this.Load += new System.EventHandler(this.frmSendMsgList_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RecordPagesManager.ucRecordPage ucRecordPage1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbTestCode;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tbTuoCode;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox tbSnCode;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private MyControl.MyDataGridView dgvList;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox tscState;
    }
}