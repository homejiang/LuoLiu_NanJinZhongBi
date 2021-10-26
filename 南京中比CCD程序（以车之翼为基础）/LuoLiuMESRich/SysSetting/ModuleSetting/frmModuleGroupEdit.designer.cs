namespace SysSetting.ModuleSetting
{
    partial class frmModuleGroupEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModuleGroupEdit));
            this.btClose = new System.Windows.Forms.Button();
            this.btTrue = new System.Windows.Forms.Button();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGroupCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btSaveAndNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numSortID = new MyControl.NumericBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(250, 113);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 17;
            this.btClose.Text = "关 闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(70, 113);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(75, 23);
            this.btTrue.TabIndex = 16;
            this.btTrue.Text = "保  存";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // tbGroupName
            // 
            this.tbGroupName.Location = new System.Drawing.Point(82, 38);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(100, 21);
            this.tbGroupName.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(27, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "模块组名";
            // 
            // tbGroupCode
            // 
            this.tbGroupCode.Location = new System.Drawing.Point(82, 13);
            this.tbGroupCode.Name = "tbGroupCode";
            this.tbGroupCode.Size = new System.Drawing.Size(100, 21);
            this.tbGroupCode.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(15, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "模块组编码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(184, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "*";
            // 
            // btSaveAndNew
            // 
            this.btSaveAndNew.Location = new System.Drawing.Point(153, 113);
            this.btSaveAndNew.Name = "btSaveAndNew";
            this.btSaveAndNew.Size = new System.Drawing.Size(85, 23);
            this.btSaveAndNew.TabIndex = 22;
            this.btSaveAndNew.Text = "保存并新增";
            this.btSaveAndNew.UseVisualStyleBackColor = true;
            this.btSaveAndNew.Click += new System.EventHandler(this.btSaveAndNew_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(185, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "排序字段";
            // 
            // numSortID
            // 
            this.numSortID.BindValue = ((object)(resources.GetObject("numSortID.BindValue")));
            this.numSortID.FilterQuanJiao = false;
            this.numSortID.Formart = "#####";
            this.numSortID.IsHundred = false;
            this.numSortID.IsPercent = false;
            this.numSortID.Location = new System.Drawing.Point(241, 40);
            this.numSortID.Name = "numSortID";
            this.numSortID.Size = new System.Drawing.Size(100, 21);
            this.numSortID.TabIndex = 24;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(82, 64);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(259, 39);
            this.tbDescription.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(47, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "备注";
            // 
            // frmModuleGroupEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 152);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numSortID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSaveAndNew);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbGroupCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbGroupName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModuleGroupEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "模块组名编辑";
            this.Load += new System.EventHandler(this.frmCountryEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbGroupCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btSaveAndNew;
        private System.Windows.Forms.Label label2;
        private MyControl.NumericBox numSortID;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label5;

    }
}