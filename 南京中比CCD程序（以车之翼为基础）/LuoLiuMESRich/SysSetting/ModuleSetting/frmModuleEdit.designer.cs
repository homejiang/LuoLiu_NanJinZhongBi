namespace SysSetting.ModuleSetting
{
    partial class frmModuleEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModuleEdit));
            this.btTrue = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numModuleSign = new MyControl.NumericBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkIsAutoCode = new System.Windows.Forms.CheckBox();
            this.chkNeedAudit = new System.Windows.Forms.CheckBox();
            this.chkCanDelete = new System.Windows.Forms.CheckBox();
            this.chkCanEdit = new System.Windows.Forms.CheckBox();
            this.chkCanNew = new System.Windows.Forms.CheckBox();
            this.numSortID = new MyControl.NumericBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbModuleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comGroup = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(102, 129);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(75, 23);
            this.btTrue.TabIndex = 8;
            this.btTrue.Text = "确 定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(205, 129);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 9;
            this.btClose.Text = "关 闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(377, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "*";
            // 
            // numModuleSign
            // 
            this.numModuleSign.BindValue = ((object)(resources.GetObject("numModuleSign.BindValue")));
            this.numModuleSign.FilterQuanJiao = false;
            this.numModuleSign.Formart = "#######0";
            this.numModuleSign.IsHundred = false;
            this.numModuleSign.IsPercent = false;
            this.numModuleSign.Location = new System.Drawing.Point(336, 17);
            this.numModuleSign.Name = "numModuleSign";
            this.numModuleSign.Size = new System.Drawing.Size(38, 21);
            this.numModuleSign.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(291, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "标识码";
            // 
            // chkIsAutoCode
            // 
            this.chkIsAutoCode.AutoSize = true;
            this.chkIsAutoCode.BackColor = System.Drawing.Color.Transparent;
            this.chkIsAutoCode.Location = new System.Drawing.Point(153, 98);
            this.chkIsAutoCode.Name = "chkIsAutoCode";
            this.chkIsAutoCode.Size = new System.Drawing.Size(72, 16);
            this.chkIsAutoCode.TabIndex = 30;
            this.chkIsAutoCode.Text = "自动编码";
            this.chkIsAutoCode.UseVisualStyleBackColor = false;
            // 
            // chkNeedAudit
            // 
            this.chkNeedAudit.AutoSize = true;
            this.chkNeedAudit.BackColor = System.Drawing.Color.Transparent;
            this.chkNeedAudit.Location = new System.Drawing.Point(31, 98);
            this.chkNeedAudit.Name = "chkNeedAudit";
            this.chkNeedAudit.Size = new System.Drawing.Size(72, 16);
            this.chkNeedAudit.TabIndex = 29;
            this.chkNeedAudit.Text = "需要审批";
            this.chkNeedAudit.UseVisualStyleBackColor = false;
            // 
            // chkCanDelete
            // 
            this.chkCanDelete.AutoSize = true;
            this.chkCanDelete.BackColor = System.Drawing.Color.Transparent;
            this.chkCanDelete.Location = new System.Drawing.Point(260, 76);
            this.chkCanDelete.Name = "chkCanDelete";
            this.chkCanDelete.Size = new System.Drawing.Size(72, 16);
            this.chkCanDelete.TabIndex = 28;
            this.chkCanDelete.Text = "可以删除";
            this.chkCanDelete.UseVisualStyleBackColor = false;
            // 
            // chkCanEdit
            // 
            this.chkCanEdit.AutoSize = true;
            this.chkCanEdit.BackColor = System.Drawing.Color.Transparent;
            this.chkCanEdit.Location = new System.Drawing.Point(153, 76);
            this.chkCanEdit.Name = "chkCanEdit";
            this.chkCanEdit.Size = new System.Drawing.Size(72, 16);
            this.chkCanEdit.TabIndex = 27;
            this.chkCanEdit.Text = "可以编辑";
            this.chkCanEdit.UseVisualStyleBackColor = false;
            // 
            // chkCanNew
            // 
            this.chkCanNew.AutoSize = true;
            this.chkCanNew.BackColor = System.Drawing.Color.Transparent;
            this.chkCanNew.Location = new System.Drawing.Point(31, 76);
            this.chkCanNew.Name = "chkCanNew";
            this.chkCanNew.Size = new System.Drawing.Size(72, 16);
            this.chkCanNew.TabIndex = 26;
            this.chkCanNew.Text = "可以创建";
            this.chkCanNew.UseVisualStyleBackColor = false;
            // 
            // numSortID
            // 
            this.numSortID.BindValue = ((object)(resources.GetObject("numSortID.BindValue")));
            this.numSortID.FilterQuanJiao = false;
            this.numSortID.Formart = "#######0";
            this.numSortID.IsHundred = false;
            this.numSortID.IsPercent = false;
            this.numSortID.Location = new System.Drawing.Point(336, 43);
            this.numSortID.Name = "numSortID";
            this.numSortID.Size = new System.Drawing.Size(38, 21);
            this.numSortID.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(137, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(276, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "*";
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(59, 16);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(76, 21);
            this.tbCode.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(4, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "模块编码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(281, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "排序字段";
            // 
            // tbModuleName
            // 
            this.tbModuleName.Location = new System.Drawing.Point(195, 17);
            this.tbModuleName.Name = "tbModuleName";
            this.tbModuleName.Size = new System.Drawing.Size(76, 21);
            this.tbModuleName.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(151, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "模块名";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(16, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 34;
            this.label8.Text = "模块组";
            // 
            // comGroup
            // 
            this.comGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comGroup.FormattingEnabled = true;
            this.comGroup.Location = new System.Drawing.Point(59, 43);
            this.comGroup.Name = "comGroup";
            this.comGroup.Size = new System.Drawing.Size(212, 20);
            this.comGroup.TabIndex = 35;
            // 
            // frmModuleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 172);
            this.Controls.Add(this.comGroup);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numModuleSign);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkIsAutoCode);
            this.Controls.Add(this.chkNeedAudit);
            this.Controls.Add(this.chkCanDelete);
            this.Controls.Add(this.chkCanEdit);
            this.Controls.Add(this.chkCanNew);
            this.Controls.Add(this.numSortID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbModuleName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btTrue);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModuleEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "模块编辑";
            this.Load += new System.EventHandler(this.frmModuleEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label7;
        private MyControl.NumericBox numModuleSign;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkIsAutoCode;
        private System.Windows.Forms.CheckBox chkNeedAudit;
        private System.Windows.Forms.CheckBox chkCanDelete;
        private System.Windows.Forms.CheckBox chkCanEdit;
        private System.Windows.Forms.CheckBox chkCanNew;
        private MyControl.NumericBox numSortID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbModuleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comGroup;
    }
}