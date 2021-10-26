namespace LuoLiuMES.AutoExe
{
    partial class frmSysFormEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.tbFormName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOpenedName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSortID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbClassName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbProjectName = new System.Windows.Forms.TextBox();
            this.chkIsMulti = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioLevel2 = new System.Windows.Forms.RadioButton();
            this.radioLevel1 = new System.Windows.Forms.RadioButton();
            this.radioLevel0 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioType2 = new System.Windows.Forms.RadioButton();
            this.radioType1 = new System.Windows.Forms.RadioButton();
            this.radioType0 = new System.Windows.Forms.RadioButton();
            this.listParameters = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listPowerList = new System.Windows.Forms.ListBox();
            this.chkCheckPower = new System.Windows.Forms.CheckBox();
            this.linkParaRemove = new System.Windows.Forms.LinkLabel();
            this.linkParaAdd = new System.Windows.Forms.LinkLabel();
            this.linkPowerAdd = new System.Windows.Forms.LinkLabel();
            this.linkPowerRemove = new System.Windows.Forms.LinkLabel();
            this.btSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.htmlRemark = new Common.HTMLTextBox.HtmlEditor();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkPowerEdit = new System.Windows.Forms.LinkLabel();
            this.linkParaEdit = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "窗口编码";
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(71, 6);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(105, 21);
            this.tbCode.TabIndex = 1;
            // 
            // tbFormName
            // 
            this.tbFormName.Location = new System.Drawing.Point(447, 6);
            this.tbFormName.Name = "tbFormName";
            this.tbFormName.Size = new System.Drawing.Size(176, 21);
            this.tbFormName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "窗口名称";
            // 
            // tbOpenedName
            // 
            this.tbOpenedName.Location = new System.Drawing.Point(164, 29);
            this.tbOpenedName.Name = "tbOpenedName";
            this.tbOpenedName.Size = new System.Drawing.Size(668, 21);
            this.tbOpenedName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "窗口打开后显示名称";
            // 
            // tbSortID
            // 
            this.tbSortID.Location = new System.Drawing.Point(704, 6);
            this.tbSortID.Name = "tbSortID";
            this.tbSortID.ReadOnly = true;
            this.tbSortID.Size = new System.Drawing.Size(128, 21);
            this.tbSortID.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(647, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "排序字段";
            // 
            // tbGroupName
            // 
            this.tbGroupName.Location = new System.Drawing.Point(221, 6);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.ReadOnly = true;
            this.tbGroupName.Size = new System.Drawing.Size(165, 21);
            this.tbGroupName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "所在组";
            // 
            // tbClassName
            // 
            this.tbClassName.Location = new System.Drawing.Point(164, 52);
            this.tbClassName.Name = "tbClassName";
            this.tbClassName.Size = new System.Drawing.Size(459, 21);
            this.tbClassName.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "详细类名（包含命名空间）";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(625, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "所在项目名称";
            // 
            // tbProjectName
            // 
            this.tbProjectName.Location = new System.Drawing.Point(704, 52);
            this.tbProjectName.Name = "tbProjectName";
            this.tbProjectName.Size = new System.Drawing.Size(128, 21);
            this.tbProjectName.TabIndex = 12;
            // 
            // chkIsMulti
            // 
            this.chkIsMulti.AutoSize = true;
            this.chkIsMulti.Location = new System.Drawing.Point(685, 82);
            this.chkIsMulti.Name = "chkIsMulti";
            this.chkIsMulti.Size = new System.Drawing.Size(120, 16);
            this.chkIsMulti.TabIndex = 14;
            this.chkIsMulti.Text = "允许打开多个窗体";
            this.chkIsMulti.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioLevel2);
            this.groupBox1.Controls.Add(this.radioLevel1);
            this.groupBox1.Controls.Add(this.radioLevel0);
            this.groupBox1.Location = new System.Drawing.Point(32, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 53);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户类型";
            // 
            // radioLevel2
            // 
            this.radioLevel2.AutoSize = true;
            this.radioLevel2.Location = new System.Drawing.Point(175, 21);
            this.radioLevel2.Name = "radioLevel2";
            this.radioLevel2.Size = new System.Drawing.Size(59, 16);
            this.radioLevel2.TabIndex = 2;
            this.radioLevel2.TabStop = true;
            this.radioLevel2.Text = "开发员";
            this.radioLevel2.UseVisualStyleBackColor = true;
            // 
            // radioLevel1
            // 
            this.radioLevel1.AutoSize = true;
            this.radioLevel1.Location = new System.Drawing.Point(92, 21);
            this.radioLevel1.Name = "radioLevel1";
            this.radioLevel1.Size = new System.Drawing.Size(59, 16);
            this.radioLevel1.TabIndex = 1;
            this.radioLevel1.TabStop = true;
            this.radioLevel1.Text = "管理员";
            this.radioLevel1.UseVisualStyleBackColor = true;
            // 
            // radioLevel0
            // 
            this.radioLevel0.AutoSize = true;
            this.radioLevel0.Location = new System.Drawing.Point(6, 21);
            this.radioLevel0.Name = "radioLevel0";
            this.radioLevel0.Size = new System.Drawing.Size(71, 16);
            this.radioLevel0.TabIndex = 0;
            this.radioLevel0.TabStop = true;
            this.radioLevel0.Text = "普通用户";
            this.radioLevel0.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioType2);
            this.groupBox2.Controls.Add(this.radioType1);
            this.groupBox2.Controls.Add(this.radioType0);
            this.groupBox2.Location = new System.Drawing.Point(312, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 53);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "打开方式";
            // 
            // radioType2
            // 
            this.radioType2.AutoSize = true;
            this.radioType2.Location = new System.Drawing.Point(227, 20);
            this.radioType2.Name = "radioType2";
            this.radioType2.Size = new System.Drawing.Size(83, 16);
            this.radioType2.TabIndex = 2;
            this.radioType2.TabStop = true;
            this.radioType2.Text = "模态对话框";
            this.radioType2.UseVisualStyleBackColor = true;
            // 
            // radioType1
            // 
            this.radioType1.AutoSize = true;
            this.radioType1.Location = new System.Drawing.Point(116, 21);
            this.radioType1.Name = "radioType1";
            this.radioType1.Size = new System.Drawing.Size(95, 16);
            this.radioType1.TabIndex = 1;
            this.radioType1.TabStop = true;
            this.radioType1.Text = "非模态对话框";
            this.radioType1.UseVisualStyleBackColor = true;
            // 
            // radioType0
            // 
            this.radioType0.AutoSize = true;
            this.radioType0.Location = new System.Drawing.Point(6, 21);
            this.radioType0.Name = "radioType0";
            this.radioType0.Size = new System.Drawing.Size(95, 16);
            this.radioType0.TabIndex = 0;
            this.radioType0.TabStop = true;
            this.radioType0.Text = "系统默认方式";
            this.radioType0.UseVisualStyleBackColor = true;
            // 
            // listParameters
            // 
            this.listParameters.FormattingEnabled = true;
            this.listParameters.ItemHeight = 12;
            this.listParameters.Location = new System.Drawing.Point(38, 148);
            this.listParameters.Name = "listParameters";
            this.listParameters.Size = new System.Drawing.Size(386, 76);
            this.listParameters.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "传入参数";
            // 
            // listPowerList
            // 
            this.listPowerList.FormattingEnabled = true;
            this.listPowerList.ItemHeight = 12;
            this.listPowerList.Location = new System.Drawing.Point(447, 148);
            this.listPowerList.Name = "listPowerList";
            this.listPowerList.Size = new System.Drawing.Size(385, 76);
            this.listPowerList.TabIndex = 20;
            // 
            // chkCheckPower
            // 
            this.chkCheckPower.AutoSize = true;
            this.chkCheckPower.Location = new System.Drawing.Point(448, 130);
            this.chkCheckPower.Name = "chkCheckPower";
            this.chkCheckPower.Size = new System.Drawing.Size(96, 16);
            this.chkCheckPower.TabIndex = 21;
            this.chkCheckPower.Text = "需要权限校验";
            this.chkCheckPower.UseVisualStyleBackColor = true;
            this.chkCheckPower.CheckedChanged += new System.EventHandler(this.chkCheckPower_CheckedChanged);
            // 
            // linkParaRemove
            // 
            this.linkParaRemove.AutoSize = true;
            this.linkParaRemove.Location = new System.Drawing.Point(391, 134);
            this.linkParaRemove.Name = "linkParaRemove";
            this.linkParaRemove.Size = new System.Drawing.Size(29, 12);
            this.linkParaRemove.TabIndex = 22;
            this.linkParaRemove.TabStop = true;
            this.linkParaRemove.Text = "移除";
            this.linkParaRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkParaRemove_LinkClicked);
            // 
            // linkParaAdd
            // 
            this.linkParaAdd.AutoSize = true;
            this.linkParaAdd.Location = new System.Drawing.Point(305, 134);
            this.linkParaAdd.Name = "linkParaAdd";
            this.linkParaAdd.Size = new System.Drawing.Size(29, 12);
            this.linkParaAdd.TabIndex = 23;
            this.linkParaAdd.TabStop = true;
            this.linkParaAdd.Text = "添加";
            this.linkParaAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkParaAdd_LinkClicked);
            // 
            // linkPowerAdd
            // 
            this.linkPowerAdd.AutoSize = true;
            this.linkPowerAdd.Location = new System.Drawing.Point(714, 134);
            this.linkPowerAdd.Name = "linkPowerAdd";
            this.linkPowerAdd.Size = new System.Drawing.Size(29, 12);
            this.linkPowerAdd.TabIndex = 25;
            this.linkPowerAdd.TabStop = true;
            this.linkPowerAdd.Text = "添加";
            this.linkPowerAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPowerAdd_LinkClicked);
            // 
            // linkPowerRemove
            // 
            this.linkPowerRemove.AutoSize = true;
            this.linkPowerRemove.Location = new System.Drawing.Point(798, 134);
            this.linkPowerRemove.Name = "linkPowerRemove";
            this.linkPowerRemove.Size = new System.Drawing.Size(29, 12);
            this.linkPowerRemove.TabIndex = 24;
            this.linkPowerRemove.TabStop = true;
            this.linkPowerRemove.Text = "移除";
            this.linkPowerRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPowerRemove_LinkClicked);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btSave.Location = new System.Drawing.Point(370, 591);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(100, 35);
            this.btSave.TabIndex = 26;
            this.btSave.Text = "保 存";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.htmlRemark, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btSave, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 227F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(841, 629);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // htmlRemark
            // 
            this.htmlRemark.BodyHTML = "";
            this.htmlRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlRemark.Location = new System.Drawing.Point(3, 230);
            this.htmlRemark.Name = "htmlRemark";
            this.htmlRemark.PublicUsers = "";
            this.htmlRemark.ShowPowerButton = false;
            this.htmlRemark.ShowSaveButton = false;
            this.htmlRemark.Size = new System.Drawing.Size(835, 355);
            this.htmlRemark.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkPowerEdit);
            this.panel1.Controls.Add(this.linkParaEdit);
            this.panel1.Controls.Add(this.listParameters);
            this.panel1.Controls.Add(this.linkPowerAdd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.linkPowerRemove);
            this.panel1.Controls.Add(this.tbCode);
            this.panel1.Controls.Add(this.linkParaAdd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.linkParaRemove);
            this.panel1.Controls.Add(this.tbFormName);
            this.panel1.Controls.Add(this.chkCheckPower);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.listPowerList);
            this.panel1.Controls.Add(this.tbOpenedName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbSortID);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.tbGroupName);
            this.panel1.Controls.Add(this.chkIsMulti);
            this.panel1.Controls.Add(this.tbClassName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbProjectName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 227);
            this.panel1.TabIndex = 27;
            // 
            // linkPowerEdit
            // 
            this.linkPowerEdit.AutoSize = true;
            this.linkPowerEdit.Location = new System.Drawing.Point(759, 134);
            this.linkPowerEdit.Name = "linkPowerEdit";
            this.linkPowerEdit.Size = new System.Drawing.Size(29, 12);
            this.linkPowerEdit.TabIndex = 27;
            this.linkPowerEdit.TabStop = true;
            this.linkPowerEdit.Text = "编辑";
            this.linkPowerEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPowerEdit_LinkClicked);
            // 
            // linkParaEdit
            // 
            this.linkParaEdit.AutoSize = true;
            this.linkParaEdit.Location = new System.Drawing.Point(349, 134);
            this.linkParaEdit.Name = "linkParaEdit";
            this.linkParaEdit.Size = new System.Drawing.Size(29, 12);
            this.linkParaEdit.TabIndex = 26;
            this.linkParaEdit.TabStop = true;
            this.linkParaEdit.Text = "编辑";
            this.linkParaEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkParaEdit_LinkClicked);
            // 
            // frmSysFormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 629);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSysFormEdit";
            this.Text = "系统窗体定义";
            this.Load += new System.EventHandler(this.frmSysFormEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.TextBox tbFormName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOpenedName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSortID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbClassName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbProjectName;
        private System.Windows.Forms.CheckBox chkIsMulti;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioLevel2;
        private System.Windows.Forms.RadioButton radioLevel1;
        private System.Windows.Forms.RadioButton radioLevel0;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioType2;
        private System.Windows.Forms.RadioButton radioType1;
        private System.Windows.Forms.RadioButton radioType0;
        private System.Windows.Forms.ListBox listParameters;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listPowerList;
        private System.Windows.Forms.CheckBox chkCheckPower;
        private System.Windows.Forms.LinkLabel linkParaRemove;
        private System.Windows.Forms.LinkLabel linkParaAdd;
        private System.Windows.Forms.LinkLabel linkPowerAdd;
        private System.Windows.Forms.LinkLabel linkPowerRemove;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Common.HTMLTextBox.HtmlEditor htmlRemark;
        private System.Windows.Forms.LinkLabel linkParaEdit;
        private System.Windows.Forms.LinkLabel linkPowerEdit;
    }
}