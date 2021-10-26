namespace BasicData.BOM
{
    partial class frmChildAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.comChildClass = new System.Windows.Forms.ComboBox();
            this.labNowPan = new System.Windows.Forms.Label();
            this.comChildSpec = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.tbUnitName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labErr = new System.Windows.Forms.Label();
            this.btTrue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "子件类型";
            // 
            // comChildClass
            // 
            this.comChildClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comChildClass.FormattingEnabled = true;
            this.comChildClass.Location = new System.Drawing.Point(84, 57);
            this.comChildClass.Name = "comChildClass";
            this.comChildClass.Size = new System.Drawing.Size(119, 23);
            this.comChildClass.TabIndex = 1;
            this.comChildClass.SelectedIndexChanged += new System.EventHandler(this.comChildClass_SelectedIndexChanged);
            // 
            // labNowPan
            // 
            this.labNowPan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(88)))), ((int)(((byte)(136)))));
            this.labNowPan.Dock = System.Windows.Forms.DockStyle.Top;
            this.labNowPan.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labNowPan.ForeColor = System.Drawing.Color.White;
            this.labNowPan.Location = new System.Drawing.Point(0, 0);
            this.labNowPan.Margin = new System.Windows.Forms.Padding(0);
            this.labNowPan.Name = "labNowPan";
            this.labNowPan.Size = new System.Drawing.Size(609, 37);
            this.labNowPan.TabIndex = 3;
            this.labNowPan.Text = "添加子件";
            this.labNowPan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comChildSpec
            // 
            this.comChildSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comChildSpec.FormattingEnabled = true;
            this.comChildSpec.Location = new System.Drawing.Point(282, 57);
            this.comChildSpec.Name = "comChildSpec";
            this.comChildSpec.Size = new System.Drawing.Size(315, 23);
            this.comChildSpec.TabIndex = 5;
            this.comChildSpec.SelectedValueChanged += new System.EventHandler(this.comChildSpec_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "型号规格";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "添加数量";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(86, 97);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(117, 24);
            this.tbQuantity.TabIndex = 7;
            // 
            // tbUnitName
            // 
            this.tbUnitName.Location = new System.Drawing.Point(282, 97);
            this.tbUnitName.Name = "tbUnitName";
            this.tbUnitName.ReadOnly = true;
            this.tbUnitName.Size = new System.Drawing.Size(117, 24);
            this.tbUnitName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "计量单位";
            // 
            // labErr
            // 
            this.labErr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labErr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labErr.ForeColor = System.Drawing.Color.Red;
            this.labErr.Location = new System.Drawing.Point(0, 182);
            this.labErr.Name = "labErr";
            this.labErr.Size = new System.Drawing.Size(609, 26);
            this.labErr.TabIndex = 12;
            this.labErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btTrue
            // 
            this.btTrue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btTrue.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btTrue.Location = new System.Drawing.Point(234, 138);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(121, 36);
            this.btTrue.TabIndex = 11;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // frmChildAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 208);
            this.Controls.Add(this.labErr);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbUnitName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comChildSpec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labNowPan);
            this.Controls.Add(this.comChildClass);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChildAdd";
            this.Text = "添加子件";
            this.Load += new System.EventHandler(this.frmChildAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comChildClass;
        private System.Windows.Forms.Label labNowPan;
        private System.Windows.Forms.ComboBox comChildSpec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.TextBox tbUnitName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labErr;
        private System.Windows.Forms.Button btTrue;
    }
}