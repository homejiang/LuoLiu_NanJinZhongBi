namespace Common.UserControls
{
    partial class ucMaterialItem
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comSupplier = new System.Windows.Forms.ComboBox();
            this.comSpec = new System.Windows.Forms.ComboBox();
            this.tbMaterialName = new System.Windows.Forms.TextBox();
            this.tbBatchNum = new System.Windows.Forms.TextBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.tbUnitName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.Controls.Add(this.comSupplier, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comSpec, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbMaterialName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbBatchNum, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbQuantity, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbUnitName, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 25);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comSupplier
            // 
            this.comSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSupplier.FormattingEnabled = true;
            this.comSupplier.Location = new System.Drawing.Point(287, 3);
            this.comSupplier.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.comSupplier.Name = "comSupplier";
            this.comSupplier.Size = new System.Drawing.Size(158, 20);
            this.comSupplier.TabIndex = 5;
            // 
            // comSpec
            // 
            this.comSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSpec.FormattingEnabled = true;
            this.comSpec.Location = new System.Drawing.Point(119, 3);
            this.comSpec.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.comSpec.Name = "comSpec";
            this.comSpec.Size = new System.Drawing.Size(158, 20);
            this.comSpec.TabIndex = 4;
            // 
            // tbMaterialName
            // 
            this.tbMaterialName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMaterialName.Location = new System.Drawing.Point(3, 3);
            this.tbMaterialName.Name = "tbMaterialName";
            this.tbMaterialName.ReadOnly = true;
            this.tbMaterialName.Size = new System.Drawing.Size(108, 21);
            this.tbMaterialName.TabIndex = 3;
            this.tbMaterialName.Text = "螺丝";
            this.tbMaterialName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbBatchNum
            // 
            this.tbBatchNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBatchNum.Location = new System.Drawing.Point(453, 3);
            this.tbBatchNum.Name = "tbBatchNum";
            this.tbBatchNum.Size = new System.Drawing.Size(146, 21);
            this.tbBatchNum.TabIndex = 9;
            // 
            // tbQuantity
            // 
            this.tbQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbQuantity.Location = new System.Drawing.Point(607, 3);
            this.tbQuantity.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(52, 21);
            this.tbQuantity.TabIndex = 10;
            // 
            // tbUnitName
            // 
            this.tbUnitName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUnitName.Location = new System.Drawing.Point(669, 3);
            this.tbUnitName.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tbUnitName.Name = "tbUnitName";
            this.tbUnitName.Size = new System.Drawing.Size(58, 21);
            this.tbUnitName.TabIndex = 11;
            // 
            // ucMaterialItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucMaterialItem";
            this.Size = new System.Drawing.Size(732, 25);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbMaterialName;
        private System.Windows.Forms.ComboBox comSupplier;
        private System.Windows.Forms.ComboBox comSpec;
        private System.Windows.Forms.TextBox tbBatchNum;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.TextBox tbUnitName;
    }
}
