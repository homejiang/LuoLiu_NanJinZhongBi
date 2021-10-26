namespace LuoLiuMES.StoreM
{
    partial class frmRemove
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemove));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCompeleted = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbInput = new System.Windows.Forms.ToolStripButton();
            this.tsbFiles = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tbRemark = new MyControl.MyTextBox();
            this.QuXiangDesc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTaker = new System.Windows.Forms.TextBox();
            this.linktaker = new System.Windows.Forms.LinkLabel();
            this.tbCreateTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCreater = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCode = new MyControl.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labAddSFG = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkOuputType = new System.Windows.Forms.LinkLabel();
            this.btWenBen = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.tbSFGCode = new System.Windows.Forms.TextBox();
            this.dgvList = new MyControl.MyDataGridView();
            this.tbBaoFei = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labAddSFG, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(841, 629);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.Color.Red;
            this.richTextBox1.Location = new System.Drawing.Point(3, 582);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(835, 44);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbCompeleted,
            this.tsbDelete,
            this.tsbPrint,
            this.tsbInput,
            this.tsbFiles,
            this.tsbClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(841, 32);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::LuoLiuMES.Properties.Resources.Save;
            this.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(56, 29);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbCompeleted
            // 
            this.tsbCompeleted.Image = global::LuoLiuMES.Properties.Resources.completed;
            this.tsbCompeleted.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCompeleted.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCompeleted.Name = "tsbCompeleted";
            this.tsbCompeleted.Size = new System.Drawing.Size(85, 29);
            this.tsbCompeleted.Text = "结束报废";
            this.tsbCompeleted.Click += new System.EventHandler(this.tsbCompeleted_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::LuoLiuMES.Properties.Resources.Del25;
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(91, 29);
            this.tsbDelete.Text = "删除报废单";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.Image = global::LuoLiuMES.Properties.Resources.print16;
            this.tsbPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(54, 29);
            this.tsbPrint.Text = "打印";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbInput
            // 
            this.tsbInput.Image = global::LuoLiuMES.Properties.Resources.EXCEL;
            this.tsbInput.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInput.Name = "tsbInput";
            this.tsbInput.Size = new System.Drawing.Size(60, 29);
            this.tsbInput.Text = "导出";
            this.tsbInput.Click += new System.EventHandler(this.tsbInput_Click);
            // 
            // tsbFiles
            // 
            this.tsbFiles.Image = ((System.Drawing.Image)(resources.GetObject("tsbFiles.Image")));
            this.tsbFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiles.Name = "tsbFiles";
            this.tsbFiles.Size = new System.Drawing.Size(76, 29);
            this.tsbFiles.Text = "相关文件";
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::LuoLiuMES.Properties.Resources.del;
            this.tsbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(52, 29);
            this.tsbClose.Text = "关闭";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbBaoFei);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.tbRemark);
            this.panel1.Controls.Add(this.QuXiangDesc);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbTaker);
            this.panel1.Controls.Add(this.linktaker);
            this.panel1.Controls.Add(this.tbCreateTime);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbCreater);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 58);
            this.panel1.TabIndex = 7;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(187, 33);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "报废原因";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tbRemark
            // 
            this.tbRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemark.FilterQuanJiao = true;
            this.tbRemark.IsUpper = false;
            this.tbRemark.Location = new System.Drawing.Point(551, 28);
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRemark.Size = new System.Drawing.Size(277, 22);
            this.tbRemark.TabIndex = 11;
            this.tbRemark.TextSplitWorld = "、";
            this.tbRemark.ValueSplitWorld = "|";
            // 
            // QuXiangDesc
            // 
            this.QuXiangDesc.FormattingEnabled = true;
            this.QuXiangDesc.Location = new System.Drawing.Point(551, 6);
            this.QuXiangDesc.Name = "QuXiangDesc";
            this.QuXiangDesc.Size = new System.Drawing.Size(277, 20);
            this.QuXiangDesc.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(519, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "去向";
            // 
            // tbTaker
            // 
            this.tbTaker.BackColor = System.Drawing.Color.White;
            this.tbTaker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTaker.Location = new System.Drawing.Point(72, 29);
            this.tbTaker.Name = "tbTaker";
            this.tbTaker.ReadOnly = true;
            this.tbTaker.Size = new System.Drawing.Size(112, 21);
            this.tbTaker.TabIndex = 7;
            // 
            // linktaker
            // 
            this.linktaker.AutoSize = true;
            this.linktaker.Location = new System.Drawing.Point(16, 32);
            this.linktaker.Name = "linktaker";
            this.linktaker.Size = new System.Drawing.Size(53, 12);
            this.linktaker.TabIndex = 6;
            this.linktaker.TabStop = true;
            this.linktaker.Text = "报废人员";
            this.linktaker.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linktaker_LinkClicked);
            // 
            // tbCreateTime
            // 
            this.tbCreateTime.BackColor = System.Drawing.Color.White;
            this.tbCreateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCreateTime.Location = new System.Drawing.Point(402, 5);
            this.tbCreateTime.Name = "tbCreateTime";
            this.tbCreateTime.ReadOnly = true;
            this.tbCreateTime.Size = new System.Drawing.Size(114, 21);
            this.tbCreateTime.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "创建时间";
            // 
            // tbCreater
            // 
            this.tbCreater.BackColor = System.Drawing.Color.White;
            this.tbCreater.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCreater.Location = new System.Drawing.Point(243, 6);
            this.tbCreater.Name = "tbCreater";
            this.tbCreater.ReadOnly = true;
            this.tbCreater.Size = new System.Drawing.Size(100, 21);
            this.tbCreater.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "创建人";
            // 
            // tbCode
            // 
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCode.FilterQuanJiao = true;
            this.tbCode.IsUpper = false;
            this.tbCode.Location = new System.Drawing.Point(72, 5);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(112, 21);
            this.tbCode.TabIndex = 1;
            this.tbCode.TextSplitWorld = "、";
            this.tbCode.ValueSplitWorld = "|";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "报废单编号";
            // 
            // labAddSFG
            // 
            this.labAddSFG.AutoSize = true;
            this.labAddSFG.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labAddSFG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labAddSFG.ForeColor = System.Drawing.Color.White;
            this.labAddSFG.Location = new System.Drawing.Point(0, 90);
            this.labAddSFG.Margin = new System.Windows.Forms.Padding(0);
            this.labAddSFG.Name = "labAddSFG";
            this.labAddSFG.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labAddSFG.Size = new System.Drawing.Size(841, 19);
            this.labAddSFG.TabIndex = 8;
            this.labAddSFG.Text = "添加报废的产品";
            this.labAddSFG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.linkOuputType);
            this.panel2.Controls.Add(this.btWenBen);
            this.panel2.Controls.Add(this.btRemove);
            this.panel2.Controls.Add(this.btAdd);
            this.panel2.Controls.Add(this.tbSFGCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(0, 109);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(841, 43);
            this.panel2.TabIndex = 9;
            // 
            // linkOuputType
            // 
            this.linkOuputType.Location = new System.Drawing.Point(3, 8);
            this.linkOuputType.Name = "linkOuputType";
            this.linkOuputType.Size = new System.Drawing.Size(108, 30);
            this.linkOuputType.TabIndex = 8;
            this.linkOuputType.TabStop = true;
            this.linkOuputType.Text = "电池包编号";
            this.linkOuputType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkOuputType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOuputType_LinkClicked);
            // 
            // btWenBen
            // 
            this.btWenBen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btWenBen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btWenBen.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btWenBen.Location = new System.Drawing.Point(665, 7);
            this.btWenBen.Name = "btWenBen";
            this.btWenBen.Size = new System.Drawing.Size(95, 32);
            this.btWenBen.TabIndex = 7;
            this.btWenBen.Text = "文本导入";
            this.btWenBen.UseVisualStyleBackColor = true;
            this.btWenBen.Click += new System.EventHandler(this.btWenBen_Click);
            // 
            // btRemove
            // 
            this.btRemove.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRemove.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRemove.Location = new System.Drawing.Point(766, 7);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(62, 32);
            this.btRemove.TabIndex = 3;
            this.btRemove.Text = "移除";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(424, 7);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(88, 30);
            this.btAdd.TabIndex = 2;
            this.btAdd.Text = "添 加";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // tbSFGCode
            // 
            this.tbSFGCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSFGCode.Location = new System.Drawing.Point(118, 10);
            this.tbSFGCode.Name = "tbSFGCode";
            this.tbSFGCode.Size = new System.Drawing.Size(300, 27);
            this.tbSFGCode.TabIndex = 1;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 152);
            this.dgvList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidth = 35;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.ShowLineNo = true;
            this.dgvList.Size = new System.Drawing.Size(841, 427);
            this.dgvList.TabIndex = 14;
            // 
            // tbBaoFei
            // 
            this.tbBaoFei.BackColor = System.Drawing.Color.White;
            this.tbBaoFei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBaoFei.Location = new System.Drawing.Point(243, 29);
            this.tbBaoFei.Name = "tbBaoFei";
            this.tbBaoFei.ReadOnly = true;
            this.tbBaoFei.Size = new System.Drawing.Size(273, 21);
            this.tbBaoFei.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(519, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "备注";
            // 
            // frmRemove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 629);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmRemove";
            this.Text = "产品报废";
            this.Load += new System.EventHandler(this.frmInput_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCompeleted;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbInput;
        private System.Windows.Forms.ToolStripButton tsbFiles;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.Panel panel1;
        private MyControl.MyTextBox tbRemark;
        private System.Windows.Forms.ComboBox QuXiangDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTaker;
        private System.Windows.Forms.LinkLabel linktaker;
        private System.Windows.Forms.TextBox tbCreateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCreater;
        private System.Windows.Forms.Label label2;
        private MyControl.MyTextBox tbCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labAddSFG;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btWenBen;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox tbSFGCode;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private MyControl.MyDataGridView dgvList;
        private System.Windows.Forms.LinkLabel linkOuputType;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbBaoFei;
    }
}