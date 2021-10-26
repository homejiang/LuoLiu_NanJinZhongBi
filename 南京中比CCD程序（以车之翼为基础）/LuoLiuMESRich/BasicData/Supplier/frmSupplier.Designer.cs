namespace BasicData.Supplier
{
    partial class frmSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplier));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbFiles = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.dgvMaterials = new MyControl.MyDataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comSupplyType = new System.Windows.Forms.ComboBox();
            this.tbSupplierCode = new MyControl.MyTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTerminated = new System.Windows.Forms.CheckBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.comProvince = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbOperator = new System.Windows.Forms.TextBox();
            this.comContry = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPostal = new System.Windows.Forms.TextBox();
            this.tbENName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbFax = new System.Windows.Forms.TextBox();
            this.tbShortName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCNName = new System.Windows.Forms.TextBox();
            this.tbTels = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbMAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbMRemove = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvMaterials, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(837, 628);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbSave,
            this.tsbDel,
            this.tsbFiles,
            this.tsbClose});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(837, 30);
            this.toolStrip3.TabIndex = 27;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::BasicData.Properties.Resources.new25;
            this.tsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(55, 27);
            this.tsbNew.Text = "新增";
            this.tsbNew.Click += new System.EventHandler(this.nvbtNew_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::BasicData.Properties.Resources.Save;
            this.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(56, 27);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = global::BasicData.Properties.Resources.Del25;
            this.tsbDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(55, 27);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tsbFiles
            // 
            this.tsbFiles.Image = global::BasicData.Properties.Resources.edit;
            this.tsbFiles.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiles.Name = "tsbFiles";
            this.tsbFiles.Size = new System.Drawing.Size(75, 27);
            this.tsbFiles.Text = "相关文件";
            this.tsbFiles.Click += new System.EventHandler(this.btFiles_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::BasicData.Properties.Resources.exit25;
            this.tsbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(61, 27);
            this.tsbClose.Text = "关闭";
            this.tsbClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.AllowUserToAddRows = false;
            this.dgvMaterials.AllowUserToDeleteRows = false;
            this.dgvMaterials.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMaterials.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvMaterials.ColumnHeadersHeight = 25;
            this.dgvMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column1,
            this.Column5});
            this.dgvMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterials.Location = new System.Drawing.Point(3, 247);
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.ReadOnly = true;
            this.dgvMaterials.RowHeadersWidth = 30;
            this.dgvMaterials.RowTemplate.Height = 23;
            this.dgvMaterials.Size = new System.Drawing.Size(831, 378);
            this.dgvMaterials.TabIndex = 1;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ClassName";
            this.Column3.HeaderText = "所属类别";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MaterialCode";
            this.Column4.HeaderText = "原材料编码";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CNName";
            this.Column1.HeaderText = "原材料名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 220;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Unit";
            this.Column5.HeaderText = "计量单位";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 60;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbRemark);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comSupplyType);
            this.panel1.Controls.Add(this.tbSupplierCode);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkTerminated);
            this.panel1.Controls.Add(this.tbDate);
            this.panel1.Controls.Add(this.comProvince);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.tbOperator);
            this.panel1.Controls.Add(this.comContry);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbPostal);
            this.panel1.Controls.Add(this.tbENName);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbFax);
            this.panel1.Controls.Add(this.tbShortName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tbCNName);
            this.panel1.Controls.Add(this.tbTels);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tbAddress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 168);
            this.panel1.TabIndex = 28;
            // 
            // tbRemark
            // 
            this.tbRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemark.Location = new System.Drawing.Point(73, 117);
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRemark.Size = new System.Drawing.Size(692, 48);
            this.tbRemark.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "供应商编号";
            // 
            // comSupplyType
            // 
            this.comSupplyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSupplyType.FormattingEnabled = true;
            this.comSupplyType.Location = new System.Drawing.Point(579, 50);
            this.comSupplyType.Name = "comSupplyType";
            this.comSupplyType.Size = new System.Drawing.Size(103, 20);
            this.comSupplyType.TabIndex = 71;
            // 
            // tbSupplierCode
            // 
            this.tbSupplierCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSupplierCode.FilterQuanJiao = true;
            this.tbSupplierCode.IsUpper = false;
            this.tbSupplierCode.Location = new System.Drawing.Point(74, 5);
            this.tbSupplierCode.Name = "tbSupplierCode";
            this.tbSupplierCode.Size = new System.Drawing.Size(257, 21);
            this.tbSupplierCode.TabIndex = 38;
            this.tbSupplierCode.TextSplitWorld = "、";
            this.tbSupplierCode.ValueSplitWorld = "|";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(527, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 70;
            this.label11.Text = "供货类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(335, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "添加日期";
            // 
            // chkTerminated
            // 
            this.chkTerminated.AutoSize = true;
            this.chkTerminated.Location = new System.Drawing.Point(704, 12);
            this.chkTerminated.Name = "chkTerminated";
            this.chkTerminated.Size = new System.Drawing.Size(48, 16);
            this.chkTerminated.TabIndex = 67;
            this.chkTerminated.Text = "停用";
            this.chkTerminated.UseVisualStyleBackColor = true;
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(389, 5);
            this.tbDate.Name = "tbDate";
            this.tbDate.ReadOnly = true;
            this.tbDate.Size = new System.Drawing.Size(132, 21);
            this.tbDate.TabIndex = 40;
            // 
            // comProvince
            // 
            this.comProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comProvince.FormattingEnabled = true;
            this.comProvince.Location = new System.Drawing.Point(230, 73);
            this.comProvince.Name = "comProvince";
            this.comProvince.Size = new System.Drawing.Size(101, 20);
            this.comProvince.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(537, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "添加人";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(177, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 64;
            this.label15.Text = "所在省份";
            // 
            // tbOperator
            // 
            this.tbOperator.Location = new System.Drawing.Point(579, 5);
            this.tbOperator.Name = "tbOperator";
            this.tbOperator.ReadOnly = true;
            this.tbOperator.Size = new System.Drawing.Size(103, 21);
            this.tbOperator.TabIndex = 42;
            // 
            // comContry
            // 
            this.comContry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comContry.FormattingEnabled = true;
            this.comContry.Location = new System.Drawing.Point(73, 73);
            this.comContry.Name = "comContry";
            this.comContry.Size = new System.Drawing.Size(101, 20);
            this.comContry.TabIndex = 63;
            this.comContry.SelectedIndexChanged += new System.EventHandler(this.comContry_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(8, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 45;
            this.label5.Text = "供应商名称";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(6, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 62;
            this.label14.Text = "  所属国家";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(334, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 47;
            this.label6.Text = "英文名称";
            // 
            // tbPostal
            // 
            this.tbPostal.Location = new System.Drawing.Point(579, 72);
            this.tbPostal.Name = "tbPostal";
            this.tbPostal.Size = new System.Drawing.Size(186, 21);
            this.tbPostal.TabIndex = 61;
            // 
            // tbENName
            // 
            this.tbENName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbENName.Location = new System.Drawing.Point(389, 28);
            this.tbENName.Name = "tbENName";
            this.tbENName.Size = new System.Drawing.Size(376, 21);
            this.tbENName.TabIndex = 48;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(524, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 60;
            this.label13.Text = "    邮编";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(8, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 49;
            this.label7.Text = "供应商简称";
            // 
            // tbFax
            // 
            this.tbFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFax.Location = new System.Drawing.Point(389, 72);
            this.tbFax.Name = "tbFax";
            this.tbFax.Size = new System.Drawing.Size(132, 21);
            this.tbFax.TabIndex = 59;
            // 
            // tbShortName
            // 
            this.tbShortName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbShortName.Location = new System.Drawing.Point(74, 50);
            this.tbShortName.Name = "tbShortName";
            this.tbShortName.Size = new System.Drawing.Size(257, 21);
            this.tbShortName.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(333, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 58;
            this.label4.Text = "    传真";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(336, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 51;
            this.label8.Text = "联系电话";
            // 
            // tbCNName
            // 
            this.tbCNName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCNName.Location = new System.Drawing.Point(74, 28);
            this.tbCNName.Name = "tbCNName";
            this.tbCNName.Size = new System.Drawing.Size(256, 21);
            this.tbCNName.TabIndex = 57;
            // 
            // tbTels
            // 
            this.tbTels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTels.Location = new System.Drawing.Point(389, 50);
            this.tbTels.Name = "tbTels";
            this.tbTels.Size = new System.Drawing.Size(132, 21);
            this.tbTels.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(20, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 53;
            this.label9.Text = "详细地址";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(17, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 55;
            this.label10.Text = "备注说明";
            // 
            // tbAddress
            // 
            this.tbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAddress.Location = new System.Drawing.Point(73, 95);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(692, 21);
            this.tbAddress.TabIndex = 54;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(0, 198);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label12.Size = new System.Drawing.Size(837, 21);
            this.label12.TabIndex = 29;
            this.label12.Text = "供应原材料";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMAdd,
            this.tsbMRemove});
            this.toolStrip1.Location = new System.Drawing.Point(0, 219);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(837, 25);
            this.toolStrip1.TabIndex = 30;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbMAdd
            // 
            this.tsbMAdd.Image = global::BasicData.Properties.Resources.create;
            this.tsbMAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMAdd.Name = "tsbMAdd";
            this.tsbMAdd.Size = new System.Drawing.Size(88, 22);
            this.tsbMAdd.Text = "添加原材料";
            this.tsbMAdd.Click += new System.EventHandler(this.btSelectMaterial_Click);
            // 
            // tsbMRemove
            // 
            this.tsbMRemove.Image = global::BasicData.Properties.Resources.del;
            this.tsbMRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMRemove.Name = "tsbMRemove";
            this.tsbMRemove.Size = new System.Drawing.Size(52, 22);
            this.tsbMRemove.Text = "移除";
            this.tsbMRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // frmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 628);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSupplier";
            this.Text = "原材料供应商";
            this.Load += new System.EventHandler(this.frmSupplier_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbFiles;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private MyControl.MyDataGridView dgvMaterials;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comSupplyType;
        private MyControl.MyTextBox tbSupplierCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTerminated;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.ComboBox comProvince;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbOperator;
        private System.Windows.Forms.ComboBox comContry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPostal;
        private System.Windows.Forms.TextBox tbENName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbFax;
        private System.Windows.Forms.TextBox tbShortName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCNName;
        private System.Windows.Forms.TextBox tbTels;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbMAdd;
        private System.Windows.Forms.ToolStripButton tsbMRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}