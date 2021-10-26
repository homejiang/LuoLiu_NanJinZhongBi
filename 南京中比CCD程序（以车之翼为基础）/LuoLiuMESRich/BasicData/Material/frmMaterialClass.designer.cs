namespace BasicData.Material
{
    partial class frmMaterialClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaterialClass));
            this.label1 = new System.Windows.Forms.Label();
            this.tbCNName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbParentCode = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btSaveNew = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Remark = new System.Windows.Forms.TextBox();
            this.linkParentClass = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类别名称";
            // 
            // tbCNName
            // 
            this.tbCNName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCNName.Location = new System.Drawing.Point(93, 29);
            this.tbCNName.Name = "tbCNName";
            this.tbCNName.Size = new System.Drawing.Size(157, 21);
            this.tbCNName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(254, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "*";
            // 
            // tbParentCode
            // 
            this.tbParentCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbParentCode.Location = new System.Drawing.Point(93, 51);
            this.tbParentCode.Name = "tbParentCode";
            this.tbParentCode.ReadOnly = true;
            this.tbParentCode.Size = new System.Drawing.Size(157, 21);
            this.tbParentCode.TabIndex = 4;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(27, 128);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 25);
            this.btSave.TabIndex = 5;
            this.btSave.Text = "保 存";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btSaveNew
            // 
            this.btSaveNew.Location = new System.Drawing.Point(108, 128);
            this.btSaveNew.Name = "btSaveNew";
            this.btSaveNew.Size = new System.Drawing.Size(75, 25);
            this.btSaveNew.TabIndex = 6;
            this.btSaveNew.Text = "保存并新增";
            this.btSaveNew.UseVisualStyleBackColor = true;
            this.btSaveNew.Click += new System.EventHandler(this.btSaveNew_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(207, 128);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(63, 25);
            this.btClose.TabIndex = 7;
            this.btClose.Text = "关 闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "类别编码";
            // 
            // tbCode
            // 
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCode.Location = new System.Drawing.Point(93, 7);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(157, 21);
            this.tbCode.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "备  　 注";
            // 
            // Remark
            // 
            this.Remark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Remark.Location = new System.Drawing.Point(93, 74);
            this.Remark.Multiline = true;
            this.Remark.Name = "Remark";
            this.Remark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Remark.Size = new System.Drawing.Size(157, 47);
            this.Remark.TabIndex = 11;
            // 
            // linkParentClass
            // 
            this.linkParentClass.AutoSize = true;
            this.linkParentClass.Location = new System.Drawing.Point(37, 54);
            this.linkParentClass.Name = "linkParentClass";
            this.linkParentClass.Size = new System.Drawing.Size(53, 12);
            this.linkParentClass.TabIndex = 12;
            this.linkParentClass.TabStop = true;
            this.linkParentClass.Text = "上级类别";
            this.linkParentClass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkParentClass_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(254, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "*";
            // 
            // frmMaterialClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 165);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkParentClass);
            this.Controls.Add(this.Remark);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btSaveNew);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tbParentCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCNName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMaterialClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "物料类别";
            this.Load += new System.EventHandler(this.frmMaterialClass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCNName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbParentCode;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btSaveNew;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Remark;
        private System.Windows.Forms.LinkLabel linkParentClass;
        private System.Windows.Forms.Label label2;
    }
}