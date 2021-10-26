namespace BasicData.Material
{
    partial class frmMaterialspec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaterialspec));
            this.label1 = new System.Windows.Forms.Label();
            this.tbSpec = new MyControl.MyTextBox();
            this.cbTerminated = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbRemark = new MyControl.MyTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDiameter1 = new MyControl.NumericBox();
            this.tbDiameter2 = new MyControl.NumericBox();
            this.tbDiameter3 = new MyControl.NumericBox();
            this.tbDTypeView = new MyControl.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "规格描述";
            // 
            // tbSpec
            // 
            this.tbSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSpec.FilterQuanJiao = true;
            this.tbSpec.IsUpper = false;
            this.tbSpec.Location = new System.Drawing.Point(99, 12);
            this.tbSpec.Margin = new System.Windows.Forms.Padding(4);
            this.tbSpec.Name = "tbSpec";
            this.tbSpec.Size = new System.Drawing.Size(269, 24);
            this.tbSpec.TabIndex = 1;
            this.tbSpec.TextSplitWorld = "、";
            this.tbSpec.ValueSplitWorld = "|";
            // 
            // cbTerminated
            // 
            this.cbTerminated.AutoSize = true;
            this.cbTerminated.Location = new System.Drawing.Point(99, 168);
            this.cbTerminated.Margin = new System.Windows.Forms.Padding(4);
            this.cbTerminated.Name = "cbTerminated";
            this.cbTerminated.Size = new System.Drawing.Size(56, 19);
            this.cbTerminated.TabIndex = 7;
            this.cbTerminated.Text = "停用";
            this.cbTerminated.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "备　注";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 166);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 10;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbRemark
            // 
            this.tbRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemark.FilterQuanJiao = true;
            this.tbRemark.IsUpper = false;
            this.tbRemark.Location = new System.Drawing.Point(99, 90);
            this.tbRemark.Margin = new System.Windows.Forms.Padding(4);
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(269, 64);
            this.tbRemark.TabIndex = 14;
            this.tbRemark.TextSplitWorld = "、";
            this.tbRemark.ValueSplitWorld = "|";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "尺寸描述";
            // 
            // tbDiameter1
            // 
            this.tbDiameter1.BindValue = ((object)(resources.GetObject("tbDiameter1.BindValue")));
            this.tbDiameter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDiameter1.FilterQuanJiao = false;
            this.tbDiameter1.Formart = null;
            this.tbDiameter1.IsHundred = false;
            this.tbDiameter1.IsPercent = false;
            this.tbDiameter1.Location = new System.Drawing.Point(99, 64);
            this.tbDiameter1.Margin = new System.Windows.Forms.Padding(4);
            this.tbDiameter1.Name = "tbDiameter1";
            this.tbDiameter1.Size = new System.Drawing.Size(75, 24);
            this.tbDiameter1.TabIndex = 16;
            // 
            // tbDiameter2
            // 
            this.tbDiameter2.BindValue = ((object)(resources.GetObject("tbDiameter2.BindValue")));
            this.tbDiameter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDiameter2.FilterQuanJiao = false;
            this.tbDiameter2.Formart = null;
            this.tbDiameter2.IsHundred = false;
            this.tbDiameter2.IsPercent = false;
            this.tbDiameter2.Location = new System.Drawing.Point(187, 64);
            this.tbDiameter2.Margin = new System.Windows.Forms.Padding(4);
            this.tbDiameter2.Name = "tbDiameter2";
            this.tbDiameter2.Size = new System.Drawing.Size(84, 24);
            this.tbDiameter2.TabIndex = 19;
            // 
            // tbDiameter3
            // 
            this.tbDiameter3.BindValue = ((object)(resources.GetObject("tbDiameter3.BindValue")));
            this.tbDiameter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDiameter3.FilterQuanJiao = false;
            this.tbDiameter3.Formart = null;
            this.tbDiameter3.IsHundred = false;
            this.tbDiameter3.IsPercent = false;
            this.tbDiameter3.Location = new System.Drawing.Point(284, 64);
            this.tbDiameter3.Margin = new System.Windows.Forms.Padding(4);
            this.tbDiameter3.Name = "tbDiameter3";
            this.tbDiameter3.Size = new System.Drawing.Size(84, 24);
            this.tbDiameter3.TabIndex = 21;
            // 
            // tbDTypeView
            // 
            this.tbDTypeView.FilterQuanJiao = true;
            this.tbDTypeView.IsUpper = false;
            this.tbDTypeView.Location = new System.Drawing.Point(99, 38);
            this.tbDTypeView.Margin = new System.Windows.Forms.Padding(4);
            this.tbDTypeView.Name = "tbDTypeView";
            this.tbDTypeView.ReadOnly = true;
            this.tbDTypeView.Size = new System.Drawing.Size(269, 24);
            this.tbDTypeView.TabIndex = 22;
            this.tbDTypeView.TextSplitWorld = "、";
            this.tbDTypeView.ValueSplitWorld = "|";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "尺寸值";
            // 
            // frmMaterialspec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 229);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDTypeView);
            this.Controls.Add(this.tbDiameter3);
            this.Controls.Add(this.tbDiameter2);
            this.Controls.Add(this.tbDiameter1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbRemark);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTerminated);
            this.Controls.Add(this.tbSpec);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMaterialspec";
            this.ShowIcon = false;
            this.Text = "原材料规格编辑";
            this.Load += new System.EventHandler(this.frmMaterialspec_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private MyControl.MyTextBox tbSpec;
        private System.Windows.Forms.CheckBox cbTerminated;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private MyControl.MyTextBox tbRemark;
        private System.Windows.Forms.Label label6;
        private MyControl.NumericBox tbDiameter1;
        private MyControl.NumericBox tbDiameter2;
        private MyControl.NumericBox tbDiameter3;
        private MyControl.MyTextBox tbDTypeView;
        private System.Windows.Forms.Label label4;
    }
}