namespace LuoLiuMES.PactM
{
    partial class frmPact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPact));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.tbPackCode = new System.Windows.Forms.TextBox();
            this.comPackYear = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comPackType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.ComGcCode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TotalCnt = new MyControl.MyTextBox();
            this.linkClient = new System.Windows.Forms.LinkLabel();
            this.tbClientAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbClientName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.linkCompany = new System.Windows.Forms.LinkLabel();
            this.tbPactCode = new MyControl.MyTextBox();
            this.tbComAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbComName = new System.Windows.Forms.TextBox();
            this.tbPactStateView = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCreaterName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCreateTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbAudit = new System.Windows.Forms.ToolStripButton();
            this.tsbSpecialPro = new System.Windows.Forms.ToolStripDropDownButton();
            this.查看订单光纤ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.终止当前光纤生产订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销终止当前订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOutputExcel = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.dgvDetail = new MyControl.MyDataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbdAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbdCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbdEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbdRemove = new System.Windows.Forms.ToolStripButton();
            this.tsbdUp = new System.Windows.Forms.ToolStripButton();
            this.tsbdDown = new System.Windows.Forms.ToolStripButton();
            this.tsbdModifyData = new System.Windows.Forms.ToolStripDropDownButton();
            this.修改工艺数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改任务数量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.调整交货期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑备注ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.终止明细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbdGradeView = new System.Windows.Forms.ToolStripButton();
            this.dgvcState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCompeletedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvDetail, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(886, 629);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.tbPackCode);
            this.panel1.Controls.Add(this.comPackYear);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.comPackType);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tbRemark);
            this.panel1.Controls.Add(this.ComGcCode);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.TotalCnt);
            this.panel1.Controls.Add(this.linkClient);
            this.panel1.Controls.Add(this.tbClientAddress);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbClientName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.linkCompany);
            this.panel1.Controls.Add(this.tbPactCode);
            this.panel1.Controls.Add(this.tbComAddress);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbComName);
            this.panel1.Controls.Add(this.tbPactStateView);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbCreaterName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbCreateTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 219);
            this.panel1.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(453, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 73;
            this.label12.Text = "成品编码预览";
            // 
            // tbPackCode
            // 
            this.tbPackCode.BackColor = System.Drawing.Color.White;
            this.tbPackCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPackCode.Location = new System.Drawing.Point(534, 114);
            this.tbPackCode.Name = "tbPackCode";
            this.tbPackCode.ReadOnly = true;
            this.tbPackCode.Size = new System.Drawing.Size(349, 21);
            this.tbPackCode.TabIndex = 72;
            // 
            // comPackYear
            // 
            this.comPackYear.FormatString = "N0";
            this.comPackYear.FormattingEnabled = true;
            this.comPackYear.Location = new System.Drawing.Point(371, 113);
            this.comPackYear.Name = "comPackYear";
            this.comPackYear.Size = new System.Drawing.Size(72, 20);
            this.comPackYear.TabIndex = 71;
            this.comPackYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comPackYear_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(307, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 70;
            this.label11.Text = "电池组年限";
            // 
            // comPackType
            // 
            this.comPackType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPackType.FormattingEnabled = true;
            this.comPackType.Location = new System.Drawing.Point(228, 113);
            this.comPackType.Name = "comPackType";
            this.comPackType.Size = new System.Drawing.Size(73, 20);
            this.comPackType.TabIndex = 69;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(157, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 68;
            this.label10.Text = "电池组类型";
            // 
            // tbRemark
            // 
            this.tbRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemark.Location = new System.Drawing.Point(79, 139);
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRemark.Size = new System.Drawing.Size(804, 68);
            this.tbRemark.TabIndex = 57;
            // 
            // ComGcCode
            // 
            this.ComGcCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComGcCode.FormattingEnabled = true;
            this.ComGcCode.Location = new System.Drawing.Point(79, 113);
            this.ComGcCode.Name = "ComGcCode";
            this.ComGcCode.Size = new System.Drawing.Size(72, 20);
            this.ComGcCode.TabIndex = 67;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 66;
            this.label9.Text = "厂商代码";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(248, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 65;
            this.label8.Text = "总数(个)";
            // 
            // TotalCnt
            // 
            this.TotalCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TotalCnt.FilterQuanJiao = true;
            this.TotalCnt.IsUpper = false;
            this.TotalCnt.Location = new System.Drawing.Point(297, 179);
            this.TotalCnt.Name = "TotalCnt";
            this.TotalCnt.Size = new System.Drawing.Size(124, 21);
            this.TotalCnt.TabIndex = 64;
            this.TotalCnt.TextSplitWorld = "、";
            this.TotalCnt.ValueSplitWorld = "|";
            this.TotalCnt.Visible = false;
            // 
            // linkClient
            // 
            this.linkClient.AutoSize = true;
            this.linkClient.Location = new System.Drawing.Point(23, 94);
            this.linkClient.Name = "linkClient";
            this.linkClient.Size = new System.Drawing.Size(53, 12);
            this.linkClient.TabIndex = 63;
            this.linkClient.TabStop = true;
            this.linkClient.Text = "客户名称";
            this.linkClient.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClient_LinkClicked);
            // 
            // tbClientAddress
            // 
            this.tbClientAddress.BackColor = System.Drawing.Color.White;
            this.tbClientAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbClientAddress.Location = new System.Drawing.Point(534, 89);
            this.tbClientAddress.Name = "tbClientAddress";
            this.tbClientAddress.ReadOnly = true;
            this.tbClientAddress.Size = new System.Drawing.Size(349, 21);
            this.tbClientAddress.TabIndex = 62;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(475, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 61;
            this.label7.Text = "客户地址";
            // 
            // tbClientName
            // 
            this.tbClientName.BackColor = System.Drawing.Color.White;
            this.tbClientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbClientName.Location = new System.Drawing.Point(79, 90);
            this.tbClientName.Name = "tbClientName";
            this.tbClientName.ReadOnly = true;
            this.tbClientName.Size = new System.Drawing.Size(364, 21);
            this.tbClientName.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 56;
            this.label5.Text = "备注";
            // 
            // linkCompany
            // 
            this.linkCompany.AutoSize = true;
            this.linkCompany.Location = new System.Drawing.Point(17, 71);
            this.linkCompany.Name = "linkCompany";
            this.linkCompany.Size = new System.Drawing.Size(59, 12);
            this.linkCompany.TabIndex = 55;
            this.linkCompany.TabStop = true;
            this.linkCompany.Text = " 制造工厂";
            this.linkCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCompany_LinkClicked);
            // 
            // tbPactCode
            // 
            this.tbPactCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPactCode.FilterQuanJiao = true;
            this.tbPactCode.IsUpper = false;
            this.tbPactCode.Location = new System.Drawing.Point(79, 44);
            this.tbPactCode.Name = "tbPactCode";
            this.tbPactCode.Size = new System.Drawing.Size(202, 21);
            this.tbPactCode.TabIndex = 54;
            this.tbPactCode.TextSplitWorld = "、";
            this.tbPactCode.ValueSplitWorld = "|";
            // 
            // tbComAddress
            // 
            this.tbComAddress.BackColor = System.Drawing.Color.White;
            this.tbComAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbComAddress.Location = new System.Drawing.Point(534, 65);
            this.tbComAddress.Name = "tbComAddress";
            this.tbComAddress.ReadOnly = true;
            this.tbComAddress.Size = new System.Drawing.Size(349, 21);
            this.tbComAddress.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(474, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "公司地址";
            // 
            // tbComName
            // 
            this.tbComName.BackColor = System.Drawing.Color.White;
            this.tbComName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbComName.Location = new System.Drawing.Point(79, 67);
            this.tbComName.Name = "tbComName";
            this.tbComName.ReadOnly = true;
            this.tbComName.Size = new System.Drawing.Size(364, 21);
            this.tbComName.TabIndex = 39;
            // 
            // tbPactStateView
            // 
            this.tbPactStateView.BackColor = System.Drawing.Color.White;
            this.tbPactStateView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPactStateView.Location = new System.Drawing.Point(728, 41);
            this.tbPactStateView.Name = "tbPactStateView";
            this.tbPactStateView.ReadOnly = true;
            this.tbPactStateView.Size = new System.Drawing.Size(155, 21);
            this.tbPactStateView.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(661, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 37;
            this.label4.Text = "任务单状态";
            // 
            // tbCreaterName
            // 
            this.tbCreaterName.BackColor = System.Drawing.Color.White;
            this.tbCreaterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCreaterName.Location = new System.Drawing.Point(334, 44);
            this.tbCreaterName.Name = "tbCreaterName";
            this.tbCreaterName.ReadOnly = true;
            this.tbCreaterName.Size = new System.Drawing.Size(109, 21);
            this.tbCreaterName.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "创建人";
            // 
            // tbCreateTime
            // 
            this.tbCreateTime.BackColor = System.Drawing.Color.White;
            this.tbCreateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCreateTime.Location = new System.Drawing.Point(534, 41);
            this.tbCreateTime.Name = "tbCreateTime";
            this.tbCreateTime.ReadOnly = true;
            this.tbCreateTime.Size = new System.Drawing.Size(124, 21);
            this.tbCreateTime.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "创建时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "任务单号";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbNew,
            this.tsbCopy,
            this.tsbDel,
            this.tsbAudit,
            this.tsbSpecialPro,
            this.tsbOutputExcel,
            this.tsbClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(886, 34);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::LuoLiuMES.Properties.Resources.Save;
            this.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(56, 31);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::LuoLiuMES.Properties.Resources.new25;
            this.tsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(55, 31);
            this.tsbNew.Text = "新建";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbCopy
            // 
            this.tsbCopy.Image = global::LuoLiuMES.Properties.Resources.copy;
            this.tsbCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(55, 31);
            this.tsbCopy.Text = "复制";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = global::LuoLiuMES.Properties.Resources.Del25;
            this.tsbDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(55, 31);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tsbAudit
            // 
            this.tsbAudit.Image = global::LuoLiuMES.Properties.Resources.Audited;
            this.tsbAudit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAudit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAudit.Name = "tsbAudit";
            this.tsbAudit.Size = new System.Drawing.Size(73, 31);
            this.tsbAudit.Text = "送审核";
            this.tsbAudit.Click += new System.EventHandler(this.tsbAudit_Click);
            // 
            // tsbSpecialPro
            // 
            this.tsbSpecialPro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看订单光纤ToolStripMenuItem,
            this.终止当前光纤生产订单ToolStripMenuItem,
            this.撤销终止当前订单ToolStripMenuItem});
            this.tsbSpecialPro.Image = global::LuoLiuMES.Properties.Resources.Special;
            this.tsbSpecialPro.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSpecialPro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpecialPro.Name = "tsbSpecialPro";
            this.tsbSpecialPro.Size = new System.Drawing.Size(96, 31);
            this.tsbSpecialPro.Text = "扩展应用";
            // 
            // 查看订单光纤ToolStripMenuItem
            // 
            this.查看订单光纤ToolStripMenuItem.Name = "查看订单光纤ToolStripMenuItem";
            this.查看订单光纤ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.查看订单光纤ToolStripMenuItem.Text = "设置生产计划";
            this.查看订单光纤ToolStripMenuItem.Click += new System.EventHandler(this.查看订单光纤ToolStripMenuItem_Click);
            // 
            // 终止当前光纤生产订单ToolStripMenuItem
            // 
            this.终止当前光纤生产订单ToolStripMenuItem.Name = "终止当前光纤生产订单ToolStripMenuItem";
            this.终止当前光纤生产订单ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.终止当前光纤生产订单ToolStripMenuItem.Text = "终止当前生产订单";
            this.终止当前光纤生产订单ToolStripMenuItem.Click += new System.EventHandler(this.终止当前光纤生产订单ToolStripMenuItem_Click);
            // 
            // 撤销终止当前订单ToolStripMenuItem
            // 
            this.撤销终止当前订单ToolStripMenuItem.Name = "撤销终止当前订单ToolStripMenuItem";
            this.撤销终止当前订单ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.撤销终止当前订单ToolStripMenuItem.Text = "撤销终止当前订单";
            this.撤销终止当前订单ToolStripMenuItem.Click += new System.EventHandler(this.终止选中任务明细ToolStripMenuItem_Click);
            // 
            // tsbOutputExcel
            // 
            this.tsbOutputExcel.Image = global::LuoLiuMES.Properties.Resources.EXCEL;
            this.tsbOutputExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOutputExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOutputExcel.Name = "tsbOutputExcel";
            this.tsbOutputExcel.Size = new System.Drawing.Size(89, 31);
            this.tsbOutputExcel.Text = "导出Excel";
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::LuoLiuMES.Properties.Resources.exit25;
            this.tsbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(61, 31);
            this.tsbClose.Text = "关闭";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcState,
            this.dgvcCompeletedQty,
            this.Column18,
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column17,
            this.Column14});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 246);
            this.dgvDetail.Margin = new System.Windows.Forms.Padding(0);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersWidth = 35;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.ShowLineNo = true;
            this.dgvDetail.Size = new System.Drawing.Size(886, 383);
            this.dgvDetail.TabIndex = 3;
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbdAdd,
            this.tsbdCopy,
            this.tsbdEdit,
            this.tsbdRemove,
            this.tsbdUp,
            this.tsbdDown,
            this.tsbdModifyData,
            this.tsbdGradeView});
            this.toolStrip2.Location = new System.Drawing.Point(0, 219);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(886, 26);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbdAdd
            // 
            this.tsbdAdd.Image = global::LuoLiuMES.Properties.Resources.create;
            this.tsbdAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbdAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbdAdd.Name = "tsbdAdd";
            this.tsbdAdd.Size = new System.Drawing.Size(76, 23);
            this.tsbdAdd.Text = "添加明细";
            this.tsbdAdd.Click += new System.EventHandler(this.tsbdAdd_Click);
            // 
            // tsbdCopy
            // 
            this.tsbdCopy.Image = global::LuoLiuMES.Properties.Resources.create;
            this.tsbdCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbdCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbdCopy.Name = "tsbdCopy";
            this.tsbdCopy.Size = new System.Drawing.Size(76, 23);
            this.tsbdCopy.Text = "复制明细";
            this.tsbdCopy.Click += new System.EventHandler(this.tsbdCopy_Click);
            // 
            // tsbdEdit
            // 
            this.tsbdEdit.Image = global::LuoLiuMES.Properties.Resources.edit;
            this.tsbdEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbdEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbdEdit.Name = "tsbdEdit";
            this.tsbdEdit.Size = new System.Drawing.Size(75, 23);
            this.tsbdEdit.Text = "编辑明细";
            this.tsbdEdit.Click += new System.EventHandler(this.tsbdEdit_Click);
            // 
            // tsbdRemove
            // 
            this.tsbdRemove.Image = global::LuoLiuMES.Properties.Resources.del;
            this.tsbdRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbdRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbdRemove.Name = "tsbdRemove";
            this.tsbdRemove.Size = new System.Drawing.Size(76, 23);
            this.tsbdRemove.Text = "删除明细";
            this.tsbdRemove.Click += new System.EventHandler(this.tsbdRemove_Click);
            // 
            // tsbdUp
            // 
            this.tsbdUp.Image = global::LuoLiuMES.Properties.Resources.up;
            this.tsbdUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbdUp.Name = "tsbdUp";
            this.tsbdUp.Size = new System.Drawing.Size(52, 23);
            this.tsbdUp.Text = "上移";
            this.tsbdUp.Click += new System.EventHandler(this.tsbdUp_Click);
            // 
            // tsbdDown
            // 
            this.tsbdDown.Image = global::LuoLiuMES.Properties.Resources.down;
            this.tsbdDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbdDown.Name = "tsbdDown";
            this.tsbdDown.Size = new System.Drawing.Size(52, 23);
            this.tsbdDown.Text = "下移";
            this.tsbdDown.Click += new System.EventHandler(this.tsbdDown_Click);
            // 
            // tsbdModifyData
            // 
            this.tsbdModifyData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改工艺数据ToolStripMenuItem,
            this.修改任务数量ToolStripMenuItem,
            this.调整交货期ToolStripMenuItem,
            this.编辑备注ToolStripMenuItem,
            this.终止明细ToolStripMenuItem});
            this.tsbdModifyData.Image = global::LuoLiuMES.Properties.Resources.Special;
            this.tsbdModifyData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbdModifyData.Name = "tsbdModifyData";
            this.tsbdModifyData.Size = new System.Drawing.Size(85, 23);
            this.tsbdModifyData.Text = "更改数据";
            // 
            // 修改工艺数据ToolStripMenuItem
            // 
            this.修改工艺数据ToolStripMenuItem.Name = "修改工艺数据ToolStripMenuItem";
            this.修改工艺数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.修改工艺数据ToolStripMenuItem.Text = "修改工艺数据";
            this.修改工艺数据ToolStripMenuItem.Click += new System.EventHandler(this.修改工艺数据ToolStripMenuItem_Click);
            // 
            // 修改任务数量ToolStripMenuItem
            // 
            this.修改任务数量ToolStripMenuItem.Name = "修改任务数量ToolStripMenuItem";
            this.修改任务数量ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.修改任务数量ToolStripMenuItem.Text = "修改任务数量";
            this.修改任务数量ToolStripMenuItem.Click += new System.EventHandler(this.修改任务数量ToolStripMenuItem_Click);
            // 
            // 调整交货期ToolStripMenuItem
            // 
            this.调整交货期ToolStripMenuItem.Name = "调整交货期ToolStripMenuItem";
            this.调整交货期ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.调整交货期ToolStripMenuItem.Text = "调整交货期";
            this.调整交货期ToolStripMenuItem.Click += new System.EventHandler(this.调整交货期ToolStripMenuItem_Click);
            // 
            // 编辑备注ToolStripMenuItem
            // 
            this.编辑备注ToolStripMenuItem.Name = "编辑备注ToolStripMenuItem";
            this.编辑备注ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.编辑备注ToolStripMenuItem.Text = "编辑备注";
            this.编辑备注ToolStripMenuItem.Click += new System.EventHandler(this.编辑备注ToolStripMenuItem_Click);
            // 
            // 终止明细ToolStripMenuItem
            // 
            this.终止明细ToolStripMenuItem.Name = "终止明细ToolStripMenuItem";
            this.终止明细ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.终止明细ToolStripMenuItem.Text = "状态变更";
            this.终止明细ToolStripMenuItem.Click += new System.EventHandler(this.终止明细ToolStripMenuItem_Click);
            // 
            // tsbdGradeView
            // 
            this.tsbdGradeView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbdGradeView.Image = ((System.Drawing.Image)(resources.GetObject("tsbdGradeView.Image")));
            this.tsbdGradeView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbdGradeView.Name = "tsbdGradeView";
            this.tsbdGradeView.Size = new System.Drawing.Size(60, 23);
            this.tsbdGradeView.Text = "列表显示";
            // 
            // dgvcState
            // 
            this.dgvcState.DataPropertyName = "CompeletedStateView";
            this.dgvcState.HeaderText = "当前状态";
            this.dgvcState.Name = "dgvcState";
            this.dgvcState.ReadOnly = true;
            this.dgvcState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvcState.Width = 78;
            // 
            // dgvcCompeletedQty
            // 
            this.dgvcCompeletedQty.DataPropertyName = "CompeletedQty";
            this.dgvcCompeletedQty.HeaderText = "已完成数量";
            this.dgvcCompeletedQty.Name = "dgvcCompeletedQty";
            this.dgvcCompeletedQty.ReadOnly = true;
            this.dgvcCompeletedQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvcCompeletedQty.Width = 88;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "BomSpec";
            this.Column18.HeaderText = "BOM结构";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column18.Width = 180;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "VersionDesc";
            this.Column1.HeaderText = "版本号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "FenCodeName";
            this.Column3.HeaderText = "分选机收料盒比例";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 160;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Qty";
            this.Column2.HeaderText = "数量(个)";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "DeliveryDate";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd";
            this.Column17.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column17.HeaderText = "交货期";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column17.Width = 150;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "";
            this.Column14.MinimumWidth = 2;
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 2;
            // 
            // frmPact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 629);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPact";
            this.Text = "生产任务单";
            this.Load += new System.EventHandler(this.frmPact_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbAudit;
        private System.Windows.Forms.ToolStripDropDownButton tsbSpecialPro;
        private System.Windows.Forms.ToolStripButton tsbOutputExcel;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkCompany;
        private MyControl.MyTextBox tbPactCode;
        private System.Windows.Forms.TextBox tbComAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbComName;
        private System.Windows.Forms.TextBox tbPactStateView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCreaterName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCreateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkClient;
        private System.Windows.Forms.TextBox tbClientAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbClientName;
        private MyControl.MyDataGridView dgvDetail;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbdAdd;
        private System.Windows.Forms.ToolStripButton tsbdCopy;
        private System.Windows.Forms.ToolStripButton tsbdEdit;
        private System.Windows.Forms.ToolStripButton tsbdRemove;
        private System.Windows.Forms.ToolStripButton tsbdUp;
        private System.Windows.Forms.ToolStripButton tsbdDown;
        private System.Windows.Forms.ToolStripDropDownButton tsbdModifyData;
        private System.Windows.Forms.ToolStripMenuItem 修改工艺数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改任务数量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 调整交货期ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑备注ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbdGradeView;
        private System.Windows.Forms.ToolStripMenuItem 查看订单光纤ToolStripMenuItem;
        private MyControl.MyTextBox TotalCnt;
        private System.Windows.Forms.ToolStripMenuItem 终止当前光纤生产订单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 终止明细ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤销终止当前订单ToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ComGcCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comPackYear;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comPackType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbPackCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcState;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCompeletedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
    }
}