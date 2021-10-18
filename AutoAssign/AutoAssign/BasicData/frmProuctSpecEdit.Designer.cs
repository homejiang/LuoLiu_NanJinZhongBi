namespace AutoAssign.BasicData
{
    partial class frmProuctSpecEdit
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
            this.tbSpec = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btTrue = new System.Windows.Forms.Button();
            this.labErr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbSpec
            // 
            this.tbSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSpec.Location = new System.Drawing.Point(100, 24);
            this.tbSpec.Name = "tbSpec";
            this.tbSpec.Size = new System.Drawing.Size(223, 26);
            this.tbSpec.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "电芯规格";
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(143, 72);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(97, 37);
            this.btTrue.TabIndex = 4;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // labErr
            // 
            this.labErr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labErr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labErr.ForeColor = System.Drawing.Color.Red;
            this.labErr.Location = new System.Drawing.Point(0, 123);
            this.labErr.Name = "labErr";
            this.labErr.Size = new System.Drawing.Size(383, 19);
            this.labErr.TabIndex = 5;
            this.labErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmProuctSpecEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 142);
            this.Controls.Add(this.labErr);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbSpec);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProuctSpecEdit";
            this.Text = "编辑电芯规格";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSpec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Label labErr;
    }
}