namespace BasicData.ProcessMacs
{
    partial class frmMBdownEdit
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
            this.btTrue = new System.Windows.Forms.Button();
            this.tbRemark = new MyControl.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOperator = new System.Windows.Forms.TextBox();
            this.linkProUsers = new System.Windows.Forms.LinkLabel();
            this.tbProUserNames = new System.Windows.Forms.TextBox();
            this.dgvDetail = new MyControl.MyDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbStartTime = new System.Windows.Forms.TextBox();
            this.tbEndTime = new System.Windows.Forms.TextBox();
            this.comMac = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.btCompleted = new System.Windows.Forms.Button();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.linkProcess = new System.Windows.Forms.LinkLabel();
            this.tbProcessName = new System.Windows.Forms.TextBox();
            this.linkTime = new System.Windows.Forms.LinkLabel();
            this.linkOperator = new System.Windows.Forms.LinkLabel();
            this.btDelete = new System.Windows.Forms.Button();
            this.labMacName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLog = new MyControl.MyTextBox();
            this.btSendLog = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labLogUserName = new System.Windows.Forms.Label();
            this.comMacTerminated = new System.Windows.Forms.ComboBox();
            this.btStart = new System.Windows.Forms.Button();
            this.tbStartTime1 = new System.Windows.Forms.TextBox();
            this.linkTstart = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btTrue
            // 
            this.btTrue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btTrue.Location = new System.Drawing.Point(323, 283);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(84, 32);
            this.btTrue.TabIndex = 5;
            this.btTrue.Text = "提交异常";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // tbRemark
            // 
            this.tbRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemark.FilterQuanJiao = true;
            this.tbRemark.IsUpper = false;
            this.tbRemark.Location = new System.Drawing.Point(47, 221);
            this.tbRemark.MaxLength = 400;
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRemark.Size = new System.Drawing.Size(756, 57);
            this.tbRemark.TabIndex = 21;
            this.tbRemark.TextSplitWorld = "、";
            this.tbRemark.ValueSplitWorld = "|";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "备注";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(433, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "至";
            // 
            // tbOperator
            // 
            this.tbOperator.BackColor = System.Drawing.Color.White;
            this.tbOperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOperator.Location = new System.Drawing.Point(634, 4);
            this.tbOperator.Name = "tbOperator";
            this.tbOperator.ReadOnly = true;
            this.tbOperator.Size = new System.Drawing.Size(96, 21);
            this.tbOperator.TabIndex = 32;
            // 
            // linkProUsers
            // 
            this.linkProUsers.AutoSize = true;
            this.linkProUsers.Location = new System.Drawing.Point(13, 33);
            this.linkProUsers.Name = "linkProUsers";
            this.linkProUsers.Size = new System.Drawing.Size(65, 12);
            this.linkProUsers.TabIndex = 33;
            this.linkProUsers.TabStop = true;
            this.linkProUsers.Text = "异常处理人";
            this.linkProUsers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProUsers_LinkClicked);
            // 
            // tbProUserNames
            // 
            this.tbProUserNames.BackColor = System.Drawing.Color.White;
            this.tbProUserNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbProUserNames.Location = new System.Drawing.Point(85, 31);
            this.tbProUserNames.Name = "tbProUserNames";
            this.tbProUserNames.ReadOnly = true;
            this.tbProUserNames.Size = new System.Drawing.Size(413, 21);
            this.tbProUserNames.TabIndex = 34;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvDetail.Location = new System.Drawing.Point(4, 110);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersWidth = 30;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(799, 105);
            this.dgvDetail.TabIndex = 35;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CaseCode";
            this.Column1.HeaderText = "异常编码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 78;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CaseDesc";
            this.Column2.HeaderText = "异常内容";
            this.Column2.Name = "Column2";
            this.Column2.Width = 480;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "LevelDesc";
            this.Column3.HeaderText = "异常等级";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ClassName";
            this.Column4.HeaderText = "异常类别";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "";
            this.Column5.Name = "Column5";
            this.Column5.Width = 10;
            // 
            // tbStartTime
            // 
            this.tbStartTime.BackColor = System.Drawing.Color.White;
            this.tbStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbStartTime.Location = new System.Drawing.Point(298, 4);
            this.tbStartTime.Name = "tbStartTime";
            this.tbStartTime.ReadOnly = true;
            this.tbStartTime.Size = new System.Drawing.Size(127, 21);
            this.tbStartTime.TabIndex = 36;
            // 
            // tbEndTime
            // 
            this.tbEndTime.BackColor = System.Drawing.Color.White;
            this.tbEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEndTime.Location = new System.Drawing.Point(456, 4);
            this.tbEndTime.Name = "tbEndTime";
            this.tbEndTime.ReadOnly = true;
            this.tbEndTime.Size = new System.Drawing.Size(127, 21);
            this.tbEndTime.TabIndex = 37;
            // 
            // comMac
            // 
            this.comMac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comMac.FormattingEnabled = true;
            this.comMac.Location = new System.Drawing.Point(276, 58);
            this.comMac.Name = "comMac";
            this.comMac.Size = new System.Drawing.Size(141, 20);
            this.comMac.TabIndex = 39;
            this.comMac.SelectedIndexChanged += new System.EventHandler(this.comMac_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(220, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "异常设备";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbRemove});
            this.toolStrip1.Location = new System.Drawing.Point(9, 83);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(208, 25);
            this.toolStrip1.TabIndex = 40;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::BasicData.Properties.Resources.create;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(100, 22);
            this.tsbAdd.Text = "添加异常内容";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbRemove
            // 
            this.tsbRemove.Image = global::BasicData.Properties.Resources.del;
            this.tsbRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemove.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Size = new System.Drawing.Size(100, 22);
            this.tsbRemove.Text = "移除异常内容";
            this.tsbRemove.Click += new System.EventHandler(this.tsbRemove_Click);
            // 
            // btCompleted
            // 
            this.btCompleted.BackColor = System.Drawing.Color.Blue;
            this.btCompleted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCompleted.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCompleted.ForeColor = System.Drawing.Color.White;
            this.btCompleted.Location = new System.Drawing.Point(702, 283);
            this.btCompleted.Name = "btCompleted";
            this.btCompleted.Size = new System.Drawing.Size(93, 32);
            this.btCompleted.TabIndex = 41;
            this.btCompleted.Text = "维修完成";
            this.btCompleted.UseVisualStyleBackColor = false;
            this.btCompleted.Click += new System.EventHandler(this.btCompleted_Click);
            // 
            // tbCode
            // 
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCode.Location = new System.Drawing.Point(85, 4);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(127, 21);
            this.tbCode.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(25, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 42;
            this.label7.Text = "异常单号";
            // 
            // linkProcess
            // 
            this.linkProcess.AutoSize = true;
            this.linkProcess.Location = new System.Drawing.Point(6, 61);
            this.linkProcess.Name = "linkProcess";
            this.linkProcess.Size = new System.Drawing.Size(77, 12);
            this.linkProcess.TabIndex = 44;
            this.linkProcess.TabStop = true;
            this.linkProcess.Text = "设备所属工序";
            this.linkProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProcess_LinkClicked);
            // 
            // tbProcessName
            // 
            this.tbProcessName.BackColor = System.Drawing.Color.White;
            this.tbProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbProcessName.Location = new System.Drawing.Point(85, 58);
            this.tbProcessName.Name = "tbProcessName";
            this.tbProcessName.ReadOnly = true;
            this.tbProcessName.Size = new System.Drawing.Size(127, 21);
            this.tbProcessName.TabIndex = 45;
            // 
            // linkTime
            // 
            this.linkTime.AutoSize = true;
            this.linkTime.Location = new System.Drawing.Point(219, 9);
            this.linkTime.Name = "linkTime";
            this.linkTime.Size = new System.Drawing.Size(77, 12);
            this.linkTime.TabIndex = 46;
            this.linkTime.TabStop = true;
            this.linkTime.Text = "异常发生时间";
            this.linkTime.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTime_LinkClicked);
            // 
            // linkOperator
            // 
            this.linkOperator.AutoSize = true;
            this.linkOperator.Location = new System.Drawing.Point(589, 9);
            this.linkOperator.Name = "linkOperator";
            this.linkOperator.Size = new System.Drawing.Size(41, 12);
            this.linkOperator.TabIndex = 47;
            this.linkOperator.TabStop = true;
            this.linkOperator.Text = "填写人";
            this.linkOperator.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOperator_LinkClicked);
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.Red;
            this.btDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDelete.ForeColor = System.Drawing.Color.White;
            this.btDelete.Location = new System.Drawing.Point(8, 291);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(73, 32);
            this.btDelete.TabIndex = 48;
            this.btDelete.Text = "删除";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // labMacName
            // 
            this.labMacName.AutoSize = true;
            this.labMacName.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMacName.ForeColor = System.Drawing.Color.Red;
            this.labMacName.Location = new System.Drawing.Point(434, 59);
            this.labMacName.Name = "labMacName";
            this.labMacName.Size = new System.Drawing.Size(97, 40);
            this.labMacName.TabIndex = 49;
            this.labMacName.Text = "机台";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 14);
            this.label2.TabIndex = 50;
            this.label2.Text = "维修过程登记";
            // 
            // tbLog
            // 
            this.tbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLog.FilterQuanJiao = true;
            this.tbLog.IsUpper = false;
            this.tbLog.Location = new System.Drawing.Point(27, 352);
            this.tbLog.MaxLength = 400;
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(756, 194);
            this.tbLog.TabIndex = 51;
            this.tbLog.TextSplitWorld = "、";
            this.tbLog.ValueSplitWorld = "|";
            // 
            // btSendLog
            // 
            this.btSendLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSendLog.Location = new System.Drawing.Point(323, 561);
            this.btSendLog.Name = "btSendLog";
            this.btSendLog.Size = new System.Drawing.Size(84, 32);
            this.btSendLog.TabIndex = 52;
            this.btSendLog.Text = "提交内容";
            this.btSendLog.UseVisualStyleBackColor = true;
            this.btSendLog.Click += new System.EventHandler(this.btSendLog_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(142, 571);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 12);
            this.label4.TabIndex = 53;
            this.label4.Text = "注：不要忘记选择\"异常处理人\"";
            // 
            // labLogUserName
            // 
            this.labLogUserName.AutoSize = true;
            this.labLogUserName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labLogUserName.Location = new System.Drawing.Point(124, 335);
            this.labLogUserName.Name = "labLogUserName";
            this.labLogUserName.Size = new System.Drawing.Size(0, 14);
            this.labLogUserName.TabIndex = 54;
            // 
            // comMacTerminated
            // 
            this.comMacTerminated.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comMacTerminated.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comMacTerminated.FormattingEnabled = true;
            this.comMacTerminated.Location = new System.Drawing.Point(276, 82);
            this.comMacTerminated.Name = "comMacTerminated";
            this.comMacTerminated.Size = new System.Drawing.Size(141, 25);
            this.comMacTerminated.TabIndex = 55;
            this.comMacTerminated.SelectedIndexChanged += new System.EventHandler(this.comMacTerminated_SelectedIndexChanged);
            // 
            // btStart
            // 
            this.btStart.BackColor = System.Drawing.Color.LimeGreen;
            this.btStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btStart.ForeColor = System.Drawing.Color.White;
            this.btStart.Location = new System.Drawing.Point(506, 283);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(93, 32);
            this.btStart.TabIndex = 41;
            this.btStart.Text = "开始维修";
            this.btStart.UseVisualStyleBackColor = false;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbStartTime1
            // 
            this.tbStartTime1.BackColor = System.Drawing.Color.White;
            this.tbStartTime1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbStartTime1.Location = new System.Drawing.Point(591, 30);
            this.tbStartTime1.Name = "tbStartTime1";
            this.tbStartTime1.ReadOnly = true;
            this.tbStartTime1.Size = new System.Drawing.Size(139, 21);
            this.tbStartTime1.TabIndex = 37;
            // 
            // linkTstart
            // 
            this.linkTstart.AutoSize = true;
            this.linkTstart.Location = new System.Drawing.Point(512, 34);
            this.linkTstart.Name = "linkTstart";
            this.linkTstart.Size = new System.Drawing.Size(77, 12);
            this.linkTstart.TabIndex = 46;
            this.linkTstart.TabStop = true;
            this.linkTstart.Text = "开始维修时间";
            this.linkTstart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTstart_LinkClicked);
            // 
            // frmMBdownEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 609);
            this.Controls.Add(this.comMacTerminated);
            this.Controls.Add(this.labLogUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btSendLog);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labMacName);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.linkOperator);
            this.Controls.Add(this.linkTstart);
            this.Controls.Add(this.linkTime);
            this.Controls.Add(this.tbProcessName);
            this.Controls.Add(this.linkProcess);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.btCompleted);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.comMac);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbStartTime1);
            this.Controls.Add(this.tbEndTime);
            this.Controls.Add(this.tbStartTime);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.tbProUserNames);
            this.Controls.Add(this.linkProUsers);
            this.Controls.Add(this.tbOperator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbRemark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btTrue);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMBdownEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设备异常内容编辑";
            this.Load += new System.EventHandler(this.frmUnitEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btTrue;
        private MyControl.MyTextBox tbRemark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOperator;
        private System.Windows.Forms.LinkLabel linkProUsers;
        private System.Windows.Forms.TextBox tbProUserNames;
        private MyControl.MyDataGridView dgvDetail;
        private System.Windows.Forms.TextBox tbStartTime;
        private System.Windows.Forms.TextBox tbEndTime;
        private System.Windows.Forms.ComboBox comMac;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.Button btCompleted;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkProcess;
        private System.Windows.Forms.TextBox tbProcessName;
        private System.Windows.Forms.LinkLabel linkTime;
        private System.Windows.Forms.LinkLabel linkOperator;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Label labMacName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label2;
        private MyControl.MyTextBox tbLog;
        private System.Windows.Forms.Button btSendLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labLogUserName;
        private System.Windows.Forms.ComboBox comMacTerminated;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TextBox tbStartTime1;
        private System.Windows.Forms.LinkLabel linkTstart;
    }
}