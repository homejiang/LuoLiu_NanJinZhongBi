namespace BasicData.UserControls
{
    partial class ucMateiralItem
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
            this.label1 = new System.Windows.Forms.Label();
            this.comMaterial = new System.Windows.Forms.ComboBox();
            this.comSpec = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.tbUnitName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "物料名称";
            // 
            // comMaterial
            // 
            this.comMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comMaterial.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comMaterial.FormattingEnabled = true;
            this.comMaterial.Location = new System.Drawing.Point(78, 6);
            this.comMaterial.Name = "comMaterial";
            this.comMaterial.Size = new System.Drawing.Size(150, 23);
            this.comMaterial.TabIndex = 1;
            this.comMaterial.SelectedIndexChanged += new System.EventHandler(this.comMaterial_SelectedIndexChanged);
            // 
            // comSpec
            // 
            this.comSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSpec.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comSpec.FormattingEnabled = true;
            this.comSpec.Location = new System.Drawing.Point(299, 7);
            this.comSpec.Name = "comSpec";
            this.comSpec.Size = new System.Drawing.Size(187, 23);
            this.comSpec.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "物料规格";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "使用数量";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(558, 7);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(73, 23);
            this.tbQuantity.TabIndex = 5;
            this.tbQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbUnitName
            // 
            this.tbUnitName.Location = new System.Drawing.Point(675, 7);
            this.tbUnitName.Name = "tbUnitName";
            this.tbUnitName.ReadOnly = true;
            this.tbUnitName.Size = new System.Drawing.Size(51, 23);
            this.tbUnitName.TabIndex = 7;
            this.tbUnitName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "单位";
            // 
            // ucMateiralItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tbUnitName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comSpec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comMaterial);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ucMateiralItem";
            this.Size = new System.Drawing.Size(737, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comMaterial;
        private System.Windows.Forms.ComboBox comSpec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.TextBox tbUnitName;
        private System.Windows.Forms.Label label4;
    }
}
