namespace BasicData.BOM
{
    partial class frmMaterialAdd
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
            this.labNowPan = new System.Windows.Forms.Label();
            this.uc1 = new BasicData.UserControls.ucMateiralItem();
            this.label1 = new System.Windows.Forms.Label();
            this.comProcess = new System.Windows.Forms.ComboBox();
            this.uc3 = new BasicData.UserControls.ucMateiralItem();
            this.label2 = new System.Windows.Forms.Label();
            this.btTrue = new System.Windows.Forms.Button();
            this.labErr = new System.Windows.Forms.Label();
            this.uc2 = new BasicData.UserControls.ucMateiralItem();
            this.SuspendLayout();
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
            this.labNowPan.Size = new System.Drawing.Size(751, 37);
            this.labNowPan.TabIndex = 2;
            this.labNowPan.Text = "添加指定工序的原材料";
            this.labNowPan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uc1
            // 
            this.uc1.BackColor = System.Drawing.Color.White;
            this.uc1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uc1.Location = new System.Drawing.Point(8, 85);
            this.uc1.Name = "uc1";
            this.uc1.Size = new System.Drawing.Size(737, 35);
            this.uc1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "本次添加原材料的工序";
            // 
            // comProcess
            // 
            this.comProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comProcess.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comProcess.FormattingEnabled = true;
            this.comProcess.Location = new System.Drawing.Point(170, 47);
            this.comProcess.Name = "comProcess";
            this.comProcess.Size = new System.Drawing.Size(185, 23);
            this.comProcess.TabIndex = 5;
            // 
            // uc3
            // 
            this.uc3.BackColor = System.Drawing.Color.White;
            this.uc3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uc3.Location = new System.Drawing.Point(7, 183);
            this.uc3.Name = "uc3";
            this.uc3.Size = new System.Drawing.Size(737, 35);
            this.uc3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(377, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "一次最多添加3个原材料";
            // 
            // btTrue
            // 
            this.btTrue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btTrue.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btTrue.Location = new System.Drawing.Point(289, 236);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(121, 43);
            this.btTrue.TabIndex = 9;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // labErr
            // 
            this.labErr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labErr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labErr.ForeColor = System.Drawing.Color.Red;
            this.labErr.Location = new System.Drawing.Point(0, 288);
            this.labErr.Name = "labErr";
            this.labErr.Size = new System.Drawing.Size(751, 26);
            this.labErr.TabIndex = 10;
            this.labErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uc2
            // 
            this.uc2.BackColor = System.Drawing.Color.White;
            this.uc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uc2.Location = new System.Drawing.Point(7, 134);
            this.uc2.Name = "uc2";
            this.uc2.Size = new System.Drawing.Size(737, 35);
            this.uc2.TabIndex = 12;
            // 
            // frmMaterialAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(751, 314);
            this.Controls.Add(this.uc3);
            this.Controls.Add(this.uc2);
            this.Controls.Add(this.labErr);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comProcess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uc1);
            this.Controls.Add(this.labNowPan);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMaterialAdd";
            this.Text = "添加原材料";
            this.Load += new System.EventHandler(this.frmMaterialAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labNowPan;
        private UserControls.ucMateiralItem uc1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comProcess;
        private UserControls.ucMateiralItem uc3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Label labErr;
        private UserControls.ucMateiralItem uc2;
    }
}