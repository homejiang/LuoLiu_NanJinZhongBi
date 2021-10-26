namespace LuoLiuMESPrinter.MySetting
{
    partial class frmAutoComposing
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
            this.numAutoDelayScd = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAutoComposing = new System.Windows.Forms.CheckBox();
            this.btTrue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoDelayScd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "清空数据延时";
            // 
            // numAutoDelayScd
            // 
            this.numAutoDelayScd.Location = new System.Drawing.Point(141, 62);
            this.numAutoDelayScd.Name = "numAutoDelayScd";
            this.numAutoDelayScd.Size = new System.Drawing.Size(95, 24);
            this.numAutoDelayScd.TabIndex = 1;
            this.numAutoDelayScd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "秒";
            // 
            // chkAutoComposing
            // 
            this.chkAutoComposing.AutoSize = true;
            this.chkAutoComposing.Location = new System.Drawing.Point(54, 25);
            this.chkAutoComposing.Name = "chkAutoComposing";
            this.chkAutoComposing.Size = new System.Drawing.Size(191, 19);
            this.chkAutoComposing.TabIndex = 3;
            this.chkAutoComposing.Text = "信息录入后自动完成绑定";
            this.chkAutoComposing.UseVisualStyleBackColor = true;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(109, 104);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(85, 31);
            this.btTrue.TabIndex = 4;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // frmAutoComposing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 155);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.chkAutoComposing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numAutoDelayScd);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAutoComposing";
            this.Text = "自动完成绑定设置";
            this.Load += new System.EventHandler(this.frmAutoComposing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAutoDelayScd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numAutoDelayScd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAutoComposing;
        private System.Windows.Forms.Button btTrue;
    }
}