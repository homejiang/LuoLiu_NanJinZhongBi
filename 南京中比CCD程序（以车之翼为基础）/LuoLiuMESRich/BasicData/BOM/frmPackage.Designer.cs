namespace BasicData.BOM
{
    partial class frmPackage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPackage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbBOMExp = new System.Windows.Forms.ToolStripButton();
            this.tsbBOMParents = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvMaterial = new MyControl.MyDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMColSpec = new MyControl.DropDownListColumn();
            this.dgvMColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMColUnit = new MyControl.DropDownListColumn();
            this.dgvMcolSupplier = new MyControl.DropDownListColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.tsbProcessAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbProcessInsert = new System.Windows.Forms.ToolStripButton();
            this.tsbProcessDel = new System.Windows.Forms.ToolStripButton();
            this.listProcess = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbVirCode = new MyControl.MyTextBox();
            this.labVirCode = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.ucEditFile1 = new Common.UserControls.ucEditFile();
            this.ucBOMVersion1 = new BasicData.UserContorls.ucBOMVersion();
            this.numPerKg = new MyControl.NumericBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numDxCount = new MyControl.NumericBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numWidth = new MyControl.NumericBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numLength = new MyControl.NumericBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numHei = new MyControl.NumericBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbClaName = new MyControl.MyTextBox();
            this.chkTerminated = new System.Windows.Forms.CheckBox();
            this.tbModifyInfo = new MyControl.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCreateInfo = new MyControl.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUnit = new MyControl.MyTextBox();
            this.linkUnit = new System.Windows.Forms.LinkLabel();
            this.tbSpec = new MyControl.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSFG = new MyControl.MyDataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSColSpec = new MyControl.DropDownListColumn();
            this.dgvSColQuantity = new MyControl.NumericBoxColumn();
            this.dgvSColUnit = new MyControl.DropDownListColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbSFGAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbSFGRemove = new System.Windows.Forms.ToolStripButton();
            this.tsbSFGUp = new System.Windows.Forms.ToolStripButton();
            this.tsbSFGDown = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsbMAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbMRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSFG)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbNew,
            this.tsbCopy,
            this.tsbDel,
            this.tsbClose,
            this.tsbBOMExp,
            this.tsbBOMParents});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(841, 32);
            this.toolStrip1.TabIndex = 29;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(56, 29);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(55, 29);
            this.tsbNew.Text = "新建";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbCopy
            // 
            this.tsbCopy.Image = global::BasicData.Properties.Resources.copy;
            this.tsbCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(55, 29);
            this.tsbCopy.Text = "复制";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbDel.Image")));
            this.tsbDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(55, 29);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(61, 29);
            this.tsbClose.Text = "关闭";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbBOMExp
            // 
            this.tsbBOMExp.Image = ((System.Drawing.Image)(resources.GetObject("tsbBOMExp.Image")));
            this.tsbBOMExp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBOMExp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBOMExp.Name = "tsbBOMExp";
            this.tsbBOMExp.Size = new System.Drawing.Size(114, 29);
            this.tsbBOMExp.Text = "BOM展开信息";
            this.tsbBOMExp.Click += new System.EventHandler(this.tsbBOMExp_Click);
            // 
            // tsbBOMParents
            // 
            this.tsbBOMParents.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBOMParents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBOMParents.Name = "tsbBOMParents";
            this.tsbBOMParents.Size = new System.Drawing.Size(84, 29);
            this.tsbBOMParents.Text = "查找所有引用";
            this.tsbBOMParents.Click += new System.EventHandler(this.tsbBOMParents_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvMaterial);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 364);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(841, 138);
            this.panel3.TabIndex = 27;
            // 
            // dgvMaterial
            // 
            this.dgvMaterial.AllowUserToAddRows = false;
            this.dgvMaterial.AllowUserToDeleteRows = false;
            this.dgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn2,
            this.dgvMColSpec,
            this.dgvMColQuantity,
            this.dgvMColUnit,
            this.dgvMcolSupplier,
            this.Column2});
            this.dgvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterial.Location = new System.Drawing.Point(0, 0);
            this.dgvMaterial.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMaterial.Name = "dgvMaterial";
            this.dgvMaterial.ReadOnly = true;
            this.dgvMaterial.RowHeadersWidth = 35;
            this.dgvMaterial.RowTemplate.Height = 23;
            this.dgvMaterial.ShowLineNo = true;
            this.dgvMaterial.Size = new System.Drawing.Size(841, 138);
            this.dgvMaterial.TabIndex = 30;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ProcessName";
            this.Column1.HeaderText = "所属工序";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MaterialName";
            this.dataGridViewTextBoxColumn2.HeaderText = "源材料名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dgvMColSpec
            // 
            this.dgvMColSpec.ActiveRowSign = -1;
            this.dgvMColSpec.DataPropertyName = "Spec";
            this.dgvMColSpec.DisplayMember = "Spec";
            this.dgvMColSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dgvMColSpec.HeaderText = "规格";
            this.dgvMColSpec.Name = "dgvMColSpec";
            this.dgvMColSpec.ReadOnly = true;
            this.dgvMColSpec.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMColSpec.ValueMember = "SpecGuid";
            this.dgvMColSpec.Width = 150;
            // 
            // dgvMColQuantity
            // 
            this.dgvMColQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.Format = "#########0.###############";
            this.dgvMColQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMColQuantity.HeaderText = "单位使用量";
            this.dgvMColQuantity.Name = "dgvMColQuantity";
            this.dgvMColQuantity.ReadOnly = true;
            this.dgvMColQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMColQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvMColQuantity.Width = 90;
            // 
            // dgvMColUnit
            // 
            this.dgvMColUnit.ActiveRowSign = -1;
            this.dgvMColUnit.DataPropertyName = "UnitName";
            this.dgvMColUnit.DisplayMember = "UnitName";
            this.dgvMColUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dgvMColUnit.HeaderText = "计量单位";
            this.dgvMColUnit.Name = "dgvMColUnit";
            this.dgvMColUnit.ReadOnly = true;
            this.dgvMColUnit.ValueMember = "UnitCode";
            this.dgvMColUnit.Width = 80;
            // 
            // dgvMcolSupplier
            // 
            this.dgvMcolSupplier.ActiveRowSign = -1;
            this.dgvMcolSupplier.DataPropertyName = "SupplierName";
            this.dgvMcolSupplier.DisplayMember = "SupplierName";
            this.dgvMcolSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dgvMcolSupplier.HeaderText = "默认供应商";
            this.dgvMcolSupplier.Name = "dgvMcolSupplier";
            this.dgvMcolSupplier.ReadOnly = true;
            this.dgvMcolSupplier.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMcolSupplier.ValueMember = "SupplierCode";
            this.dgvMcolSupplier.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.MinimumWidth = 2;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(670, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "加工工序";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbProcessAdd,
            this.tsbProcessInsert,
            this.tsbProcessDel});
            this.toolStrip4.Location = new System.Drawing.Point(171, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(53, 167);
            this.toolStrip4.TabIndex = 3;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // tsbProcessAdd
            // 
            this.tsbProcessAdd.Image = global::BasicData.Properties.Resources.create;
            this.tsbProcessAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProcessAdd.Name = "tsbProcessAdd";
            this.tsbProcessAdd.Size = new System.Drawing.Size(50, 21);
            this.tsbProcessAdd.Text = "添加";
            this.tsbProcessAdd.Click += new System.EventHandler(this.tsbProcessAdd_Click);
            // 
            // tsbProcessInsert
            // 
            this.tsbProcessInsert.Image = global::BasicData.Properties.Resources.insert;
            this.tsbProcessInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProcessInsert.Name = "tsbProcessInsert";
            this.tsbProcessInsert.Size = new System.Drawing.Size(50, 21);
            this.tsbProcessInsert.Text = "插入";
            this.tsbProcessInsert.Click += new System.EventHandler(this.tsbProcessInsert_Click);
            // 
            // tsbProcessDel
            // 
            this.tsbProcessDel.Image = global::BasicData.Properties.Resources.del;
            this.tsbProcessDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProcessDel.Name = "tsbProcessDel";
            this.tsbProcessDel.Size = new System.Drawing.Size(50, 21);
            this.tsbProcessDel.Text = "移除";
            this.tsbProcessDel.Click += new System.EventHandler(this.tsbProcessDel_Click);
            // 
            // listProcess
            // 
            this.listProcess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listProcess.Dock = System.Windows.Forms.DockStyle.Left;
            this.listProcess.Font = new System.Drawing.Font("仿宋", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listProcess.FormattingEnabled = true;
            this.listProcess.ItemHeight = 15;
            this.listProcess.Items.AddRange(new object[] {
            "1、电芯入架",
            "2、安装镍片",
            "3、焊接",
            "4、CCD检测"});
            this.listProcess.Location = new System.Drawing.Point(0, 0);
            this.listProcess.Margin = new System.Windows.Forms.Padding(0);
            this.listProcess.Name = "listProcess";
            this.listProcess.Size = new System.Drawing.Size(169, 167);
            this.listProcess.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbVirCode);
            this.panel1.Controls.Add(this.labVirCode);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ucEditFile1);
            this.panel1.Controls.Add(this.ucBOMVersion1);
            this.panel1.Controls.Add(this.numPerKg);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.numDxCount);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbRemark);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numWidth);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.numLength);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.numHei);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbClaName);
            this.panel1.Controls.Add(this.chkTerminated);
            this.panel1.Controls.Add(this.tbModifyInfo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbCreateInfo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbUnit);
            this.panel1.Controls.Add(this.linkUnit);
            this.panel1.Controls.Add(this.tbSpec);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 300);
            this.panel1.TabIndex = 0;
            // 
            // tbVirCode
            // 
            this.tbVirCode.BackColor = System.Drawing.Color.Yellow;
            this.tbVirCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVirCode.FilterQuanJiao = true;
            this.tbVirCode.IsUpper = true;
            this.tbVirCode.Location = new System.Drawing.Point(766, 56);
            this.tbVirCode.Name = "tbVirCode";
            this.tbVirCode.Size = new System.Drawing.Size(72, 21);
            this.tbVirCode.TabIndex = 110;
            this.tbVirCode.TextSplitWorld = "、";
            this.tbVirCode.ValueSplitWorld = "|";
            // 
            // labVirCode
            // 
            this.labVirCode.AutoSize = true;
            this.labVirCode.Location = new System.Drawing.Point(709, 61);
            this.labVirCode.Name = "labVirCode";
            this.labVirCode.Size = new System.Drawing.Size(53, 12);
            this.labVirCode.TabIndex = 109;
            this.labVirCode.Text = "规格代码";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(362, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 107;
            this.label8.Text = "所属类别";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.toolStrip4);
            this.panel2.Controls.Add(this.listProcess);
            this.panel2.Location = new System.Drawing.Point(612, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 169);
            this.panel2.TabIndex = 106;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(22, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 108);
            this.label5.TabIndex = 105;
            this.label5.Text = "图\r\n片\r\n展\r\n示";
            // 
            // ucEditFile1
            // 
            this.ucEditFile1.Location = new System.Drawing.Point(65, 128);
            this.ucEditFile1.Name = "ucEditFile1";
            this.ucEditFile1.ParentGuid = "";
            this.ucEditFile1.ReadOnly = false;
            this.ucEditFile1.Size = new System.Drawing.Size(542, 169);
            this.ucEditFile1.TabIndex = 104;
            this.ucEditFile1.Updated = false;
            // 
            // ucBOMVersion1
            // 
            this.ucBOMVersion1.BackColor = System.Drawing.SystemColors.Control;
            this.ucBOMVersion1.Location = new System.Drawing.Point(9, 100);
            this.ucBOMVersion1.Name = "ucBOMVersion1";
            this.ucBOMVersion1.Size = new System.Drawing.Size(550, 25);
            this.ucBOMVersion1.TabIndex = 103;
            // 
            // numPerKg
            // 
            this.numPerKg.BindValue = ((object)(resources.GetObject("numPerKg.BindValue")));
            this.numPerKg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPerKg.FilterQuanJiao = false;
            this.numPerKg.Formart = "#,###,###,##0";
            this.numPerKg.IsHundred = false;
            this.numPerKg.IsPercent = false;
            this.numPerKg.Location = new System.Drawing.Point(766, 7);
            this.numPerKg.Name = "numPerKg";
            this.numPerKg.Size = new System.Drawing.Size(72, 21);
            this.numPerKg.TabIndex = 101;
            this.numPerKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(684, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 102;
            this.label10.Text = "单位净重(kg)";
            // 
            // numDxCount
            // 
            this.numDxCount.BindValue = ((object)(resources.GetObject("numDxCount.BindValue")));
            this.numDxCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDxCount.FilterQuanJiao = false;
            this.numDxCount.Formart = "#,###,###,##0";
            this.numDxCount.IsHundred = false;
            this.numDxCount.IsPercent = false;
            this.numDxCount.Location = new System.Drawing.Point(419, 31);
            this.numDxCount.Name = "numDxCount";
            this.numDxCount.Size = new System.Drawing.Size(60, 21);
            this.numDxCount.TabIndex = 11;
            this.numDxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(362, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 50;
            this.label6.Text = "总电芯数";
            // 
            // tbRemark
            // 
            this.tbRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemark.Location = new System.Drawing.Point(65, 55);
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRemark.Size = new System.Drawing.Size(615, 43);
            this.tbRemark.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 48;
            this.label4.Text = "备注";
            // 
            // numWidth
            // 
            this.numWidth.BindValue = ((object)(resources.GetObject("numWidth.BindValue")));
            this.numWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numWidth.FilterQuanJiao = true;
            this.numWidth.Formart = "#,###,###,##0.######";
            this.numWidth.IsHundred = false;
            this.numWidth.IsPercent = false;
            this.numWidth.Location = new System.Drawing.Point(178, 31);
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(67, 21);
            this.numWidth.TabIndex = 6;
            this.numWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(133, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 42;
            this.label12.Text = "宽(mm)";
            // 
            // numLength
            // 
            this.numLength.BindValue = ((object)(resources.GetObject("numLength.BindValue")));
            this.numLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numLength.FilterQuanJiao = true;
            this.numLength.Formart = "#,###,###,##0.######";
            this.numLength.IsHundred = false;
            this.numLength.IsPercent = false;
            this.numLength.Location = new System.Drawing.Point(65, 31);
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(61, 21);
            this.numLength.TabIndex = 5;
            this.numLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 40;
            this.label11.Text = "长(mm)";
            // 
            // numHei
            // 
            this.numHei.BindValue = ((object)(resources.GetObject("numHei.BindValue")));
            this.numHei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numHei.FilterQuanJiao = false;
            this.numHei.Formart = "#########0";
            this.numHei.IsHundred = false;
            this.numHei.IsPercent = false;
            this.numHei.Location = new System.Drawing.Point(295, 31);
            this.numHei.Name = "numHei";
            this.numHei.Size = new System.Drawing.Size(61, 21);
            this.numHei.TabIndex = 7;
            this.numHei.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "高(mm)";
            // 
            // tbClaName
            // 
            this.tbClaName.BackColor = System.Drawing.Color.White;
            this.tbClaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbClaName.FilterQuanJiao = true;
            this.tbClaName.IsUpper = false;
            this.tbClaName.Location = new System.Drawing.Point(419, 7);
            this.tbClaName.Name = "tbClaName";
            this.tbClaName.ReadOnly = true;
            this.tbClaName.Size = new System.Drawing.Size(140, 21);
            this.tbClaName.TabIndex = 100;
            this.tbClaName.TextSplitWorld = "、";
            this.tbClaName.ValueSplitWorld = "|";
            // 
            // chkTerminated
            // 
            this.chkTerminated.AutoSize = true;
            this.chkTerminated.Location = new System.Drawing.Point(568, 104);
            this.chkTerminated.Name = "chkTerminated";
            this.chkTerminated.Size = new System.Drawing.Size(48, 16);
            this.chkTerminated.TabIndex = 4;
            this.chkTerminated.Text = "停用";
            this.chkTerminated.UseVisualStyleBackColor = true;
            // 
            // tbModifyInfo
            // 
            this.tbModifyInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbModifyInfo.FilterQuanJiao = true;
            this.tbModifyInfo.IsUpper = false;
            this.tbModifyInfo.Location = new System.Drawing.Point(657, 31);
            this.tbModifyInfo.Name = "tbModifyInfo";
            this.tbModifyInfo.ReadOnly = true;
            this.tbModifyInfo.Size = new System.Drawing.Size(181, 21);
            this.tbModifyInfo.TabIndex = 100;
            this.tbModifyInfo.TextSplitWorld = "、";
            this.tbModifyInfo.ValueSplitWorld = "|";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(599, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "最后修改";
            // 
            // tbCreateInfo
            // 
            this.tbCreateInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCreateInfo.FilterQuanJiao = true;
            this.tbCreateInfo.IsUpper = false;
            this.tbCreateInfo.Location = new System.Drawing.Point(532, 31);
            this.tbCreateInfo.Name = "tbCreateInfo";
            this.tbCreateInfo.ReadOnly = true;
            this.tbCreateInfo.Size = new System.Drawing.Size(61, 21);
            this.tbCreateInfo.TabIndex = 100;
            this.tbCreateInfo.TextSplitWorld = "、";
            this.tbCreateInfo.ValueSplitWorld = "|";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "创建人";
            // 
            // tbUnit
            // 
            this.tbUnit.BackColor = System.Drawing.Color.White;
            this.tbUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUnit.FilterQuanJiao = true;
            this.tbUnit.IsUpper = false;
            this.tbUnit.Location = new System.Drawing.Point(620, 7);
            this.tbUnit.Name = "tbUnit";
            this.tbUnit.ReadOnly = true;
            this.tbUnit.Size = new System.Drawing.Size(60, 21);
            this.tbUnit.TabIndex = 100;
            this.tbUnit.TextSplitWorld = "、";
            this.tbUnit.ValueSplitWorld = "|";
            // 
            // linkUnit
            // 
            this.linkUnit.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkUnit.AutoSize = true;
            this.linkUnit.Location = new System.Drawing.Point(563, 10);
            this.linkUnit.Name = "linkUnit";
            this.linkUnit.Size = new System.Drawing.Size(53, 12);
            this.linkUnit.TabIndex = 3;
            this.linkUnit.TabStop = true;
            this.linkUnit.Text = "计量单位";
            this.linkUnit.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkUnit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUnit_LinkClicked);
            // 
            // tbSpec
            // 
            this.tbSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSpec.FilterQuanJiao = true;
            this.tbSpec.IsUpper = true;
            this.tbSpec.Location = new System.Drawing.Point(65, 7);
            this.tbSpec.Name = "tbSpec";
            this.tbSpec.Size = new System.Drawing.Size(291, 21);
            this.tbSpec.TabIndex = 1;
            this.tbSpec.TextSplitWorld = "、";
            this.tbSpec.ValueSplitWorld = "|";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "型号规格";
            // 
            // dgvSFG
            // 
            this.dgvSFG.AllowUserToAddRows = false;
            this.dgvSFG.AllowUserToDeleteRows = false;
            this.dgvSFG.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSFG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSFG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSFG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.dgvSColSpec,
            this.dgvSColQuantity,
            this.dgvSColUnit});
            this.dgvSFG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSFG.Location = new System.Drawing.Point(0, 529);
            this.dgvSFG.Margin = new System.Windows.Forms.Padding(0);
            this.dgvSFG.Name = "dgvSFG";
            this.dgvSFG.ReadOnly = true;
            this.dgvSFG.RowHeadersWidth = 35;
            this.dgvSFG.RowTemplate.Height = 23;
            this.dgvSFG.ShowLineNo = true;
            this.dgvSFG.Size = new System.Drawing.Size(841, 100);
            this.dgvSFG.TabIndex = 23;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ChildClassName";
            this.Column3.HeaderText = "子件分类";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // dgvSColSpec
            // 
            this.dgvSColSpec.ActiveRowSign = -1;
            this.dgvSColSpec.DataPropertyName = "ChildSpec";
            this.dgvSColSpec.DisplayMember = "ChildSpec";
            this.dgvSColSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dgvSColSpec.HeaderText = "子件规格";
            this.dgvSColSpec.Name = "dgvSColSpec";
            this.dgvSColSpec.ReadOnly = true;
            this.dgvSColSpec.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSColSpec.ValueMember = "SpecGuid";
            this.dgvSColSpec.Width = 320;
            // 
            // dgvSColQuantity
            // 
            this.dgvSColQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle6.Format = "#########0.######";
            this.dgvSColQuantity.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSColQuantity.FilterQuanJiao = false;
            this.dgvSColQuantity.HeaderText = "单位使用量";
            this.dgvSColQuantity.Name = "dgvSColQuantity";
            this.dgvSColQuantity.ReadOnly = true;
            this.dgvSColQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSColQuantity.Width = 80;
            // 
            // dgvSColUnit
            // 
            this.dgvSColUnit.ActiveRowSign = -1;
            this.dgvSColUnit.DataPropertyName = "UnitName";
            this.dgvSColUnit.DisplayMember = "UnitName";
            this.dgvSColUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dgvSColUnit.HeaderText = "计量单位";
            this.dgvSColUnit.Name = "dgvSColUnit";
            this.dgvSColUnit.ReadOnly = true;
            this.dgvSColUnit.ValueMember = "UnitCode";
            this.dgvSColUnit.Width = 80;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSFGAdd,
            this.tsbSFGRemove,
            this.tsbSFGUp,
            this.tsbSFGDown});
            this.toolStrip2.Location = new System.Drawing.Point(0, 502);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(841, 27);
            this.toolStrip2.TabIndex = 26;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbSFGAdd
            // 
            this.tsbSFGAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbSFGAdd.Image")));
            this.tsbSFGAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSFGAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSFGAdd.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbSFGAdd.Name = "tsbSFGAdd";
            this.tsbSFGAdd.Size = new System.Drawing.Size(76, 24);
            this.tsbSFGAdd.Text = "添加子件";
            this.tsbSFGAdd.Click += new System.EventHandler(this.tsbSFGAdd_Click);
            // 
            // tsbSFGRemove
            // 
            this.tsbSFGRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbSFGRemove.Image")));
            this.tsbSFGRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSFGRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSFGRemove.Name = "tsbSFGRemove";
            this.tsbSFGRemove.Size = new System.Drawing.Size(76, 24);
            this.tsbSFGRemove.Text = "移除子件";
            this.tsbSFGRemove.ToolTipText = "需要选中整行数据，请点击列表最左侧表头来选中";
            this.tsbSFGRemove.Click += new System.EventHandler(this.tsbSFGRemove_Click);
            // 
            // tsbSFGUp
            // 
            this.tsbSFGUp.Image = global::BasicData.Properties.Resources.up;
            this.tsbSFGUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSFGUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSFGUp.Name = "tsbSFGUp";
            this.tsbSFGUp.Size = new System.Drawing.Size(52, 24);
            this.tsbSFGUp.Text = "上移";
            // 
            // tsbSFGDown
            // 
            this.tsbSFGDown.Image = global::BasicData.Properties.Resources.down;
            this.tsbSFGDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSFGDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSFGDown.Name = "tsbSFGDown";
            this.tsbSFGDown.Size = new System.Drawing.Size(52, 24);
            this.tsbSFGDown.Text = "下移";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.dgvSFG, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(841, 629);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMAdd,
            this.tsbMRemove});
            this.toolStrip3.Location = new System.Drawing.Point(0, 332);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(841, 32);
            this.toolStrip3.TabIndex = 27;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsbMAdd
            // 
            this.tsbMAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbMAdd.Image")));
            this.tsbMAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMAdd.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbMAdd.Name = "tsbMAdd";
            this.tsbMAdd.Size = new System.Drawing.Size(88, 29);
            this.tsbMAdd.Text = "添加源材料";
            this.tsbMAdd.Click += new System.EventHandler(this.tsbMAdd_Click);
            // 
            // tsbMRemove
            // 
            this.tsbMRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbMRemove.Image")));
            this.tsbMRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMRemove.Name = "tsbMRemove";
            this.tsbMRemove.Size = new System.Drawing.Size(88, 29);
            this.tsbMRemove.Text = "移除源材料";
            this.tsbMRemove.ToolTipText = "需要选中整行数据，请点击列表最左侧表头来选中";
            this.tsbMRemove.Click += new System.EventHandler(this.tsbMRemove_Click);
            // 
            // frmPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 629);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "frmPackage";
            this.Text = "模组BOM设计";
            this.Load += new System.EventHandler(this.frmMuKuai_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSFG)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbBOMExp;
        private System.Windows.Forms.ToolStripButton tsbBOMParents;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private Common.UserControls.ucEditFile ucEditFile1;
        private UserContorls.ucBOMVersion ucBOMVersion1;
        private MyControl.NumericBox numPerKg;
        private System.Windows.Forms.Label label10;
        private MyControl.NumericBox numDxCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.Label label4;
        private MyControl.NumericBox numWidth;
        private System.Windows.Forms.Label label12;
        private MyControl.NumericBox numLength;
        private System.Windows.Forms.Label label11;
        private MyControl.NumericBox numHei;
        private System.Windows.Forms.Label label7;
        private MyControl.MyTextBox tbClaName;
        private System.Windows.Forms.CheckBox chkTerminated;
        private MyControl.MyTextBox tbModifyInfo;
        private System.Windows.Forms.Label label3;
        private MyControl.MyTextBox tbCreateInfo;
        private System.Windows.Forms.Label label2;
        private MyControl.MyTextBox tbUnit;
        private System.Windows.Forms.LinkLabel linkUnit;
        private MyControl.MyTextBox tbSpec;
        private System.Windows.Forms.Label label1;
        private MyControl.MyDataGridView dgvSFG;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbSFGAdd;
        private System.Windows.Forms.ToolStripButton tsbSFGRemove;
        private System.Windows.Forms.ToolStripButton tsbSFGUp;
        private System.Windows.Forms.ToolStripButton tsbSFGDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tsbProcessAdd;
        private System.Windows.Forms.ToolStripButton tsbProcessDel;
        private System.Windows.Forms.ListBox listProcess;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton tsbProcessInsert;
        private MyControl.MyDataGridView dgvMaterial;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsbMAdd;
        private System.Windows.Forms.ToolStripButton tsbMRemove;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private MyControl.DropDownListColumn dgvMColSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMColQuantity;
        private MyControl.DropDownListColumn dgvMColUnit;
        private MyControl.DropDownListColumn dgvMcolSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private MyControl.DropDownListColumn dgvSColSpec;
        private MyControl.NumericBoxColumn dgvSColQuantity;
        private MyControl.DropDownListColumn dgvSColUnit;
        private System.Windows.Forms.Label labVirCode;
        private MyControl.MyTextBox tbVirCode;
    }
}