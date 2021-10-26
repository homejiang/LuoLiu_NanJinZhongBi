namespace SysSetting.DeptUsers
{
    partial class frmDeptEdit
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
            this.btClose = new System.Windows.Forms.Button();
            this.btTrue = new System.Windows.Forms.Button();
            this.tbDeptName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btSaveAndNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescript = new System.Windows.Forms.TextBox();
            this.tbDeptCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbShortName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbParentDeptName = new System.Windows.Forms.TextBox();
            this.linkParentDeptName = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(212, 181);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 7;
            this.btClose.Text = "关 闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(32, 181);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(75, 23);
            this.btTrue.TabIndex = 5;
            this.btTrue.Text = "保  存";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // tbDeptName
            // 
            this.tbDeptName.Location = new System.Drawing.Point(82, 63);
            this.tbDeptName.Name = "tbDeptName";
            this.tbDeptName.Size = new System.Drawing.Size(190, 21);
            this.tbDeptName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(23, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "部门名称";
            // 
            // btSaveAndNew
            // 
            this.btSaveAndNew.Location = new System.Drawing.Point(112, 181);
            this.btSaveAndNew.Name = "btSaveAndNew";
            this.btSaveAndNew.Size = new System.Drawing.Size(85, 23);
            this.btSaveAndNew.TabIndex = 6;
            this.btSaveAndNew.Text = "保存并新增";
            this.btSaveAndNew.UseVisualStyleBackColor = true;
            this.btSaveAndNew.Click += new System.EventHandler(this.btSaveAndNew_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(23, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "部门描述";
            // 
            // tbDescript
            // 
            this.tbDescript.Location = new System.Drawing.Point(82, 117);
            this.tbDescript.Multiline = true;
            this.tbDescript.Name = "tbDescript";
            this.tbDescript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescript.Size = new System.Drawing.Size(190, 55);
            this.tbDescript.TabIndex = 4;
            // 
            // tbDeptCode
            // 
            this.tbDeptCode.Location = new System.Drawing.Point(82, 37);
            this.tbDeptCode.Name = "tbDeptCode";
            this.tbDeptCode.Size = new System.Drawing.Size(190, 21);
            this.tbDeptCode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(23, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "部门编码";
            // 
            // tbShortName
            // 
            this.tbShortName.Location = new System.Drawing.Point(82, 89);
            this.tbShortName.Name = "tbShortName";
            this.tbShortName.Size = new System.Drawing.Size(190, 21);
            this.tbShortName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(23, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "部门简称";
            // 
            // tbParentDeptName
            // 
            this.tbParentDeptName.BackColor = System.Drawing.Color.White;
            this.tbParentDeptName.Location = new System.Drawing.Point(82, 11);
            this.tbParentDeptName.Name = "tbParentDeptName";
            this.tbParentDeptName.ReadOnly = true;
            this.tbParentDeptName.Size = new System.Drawing.Size(190, 21);
            this.tbParentDeptName.TabIndex = 28;
            // 
            // linkParentDeptName
            // 
            this.linkParentDeptName.AutoSize = true;
            this.linkParentDeptName.Location = new System.Drawing.Point(24, 15);
            this.linkParentDeptName.Name = "linkParentDeptName";
            this.linkParentDeptName.Size = new System.Drawing.Size(53, 12);
            this.linkParentDeptName.TabIndex = 29;
            this.linkParentDeptName.TabStop = true;
            this.linkParentDeptName.Text = "上级部门";
            this.linkParentDeptName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkParentDeptName_LinkClicked);
            // 
            // frmDeptEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 218);
            this.Controls.Add(this.linkParentDeptName);
            this.Controls.Add(this.tbParentDeptName);
            this.Controls.Add(this.tbShortName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDeptCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDescript);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSaveAndNew);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbDeptName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeptEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "部门信息编辑";
            this.Load += new System.EventHandler(this.frmDeptEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.TextBox tbDeptName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSaveAndNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDescript;
        private System.Windows.Forms.TextBox tbDeptCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbShortName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbParentDeptName;
        private System.Windows.Forms.LinkLabel linkParentDeptName;

    }
}