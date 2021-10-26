namespace LuoLiuMES.AutoExe
{
    partial class frmSysFormEditPower
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
            this.tbEnumNo = new System.Windows.Forms.TextBox();
            this.btTrue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbModuleInfo = new System.Windows.Forms.TextBox();
            this.chkCk = new System.Windows.Forms.CheckBox();
            this.chkXz = new System.Windows.Forms.CheckBox();
            this.chkBj = new System.Windows.Forms.CheckBox();
            this.chkSc = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbEnumNo
            // 
            this.tbEnumNo.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbEnumNo.Location = new System.Drawing.Point(85, 21);
            this.tbEnumNo.Name = "tbEnumNo";
            this.tbEnumNo.Size = new System.Drawing.Size(107, 27);
            this.tbEnumNo.TabIndex = 0;
            this.tbEnumNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbEnumNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEnumNo_KeyDown);
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(261, 271);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(140, 47);
            this.btTrue.TabIndex = 1;
            this.btTrue.Text = "确 定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "枚举值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "模块名";
            // 
            // tbModuleInfo
            // 
            this.tbModuleInfo.Location = new System.Drawing.Point(85, 59);
            this.tbModuleInfo.Multiline = true;
            this.tbModuleInfo.Name = "tbModuleInfo";
            this.tbModuleInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbModuleInfo.Size = new System.Drawing.Size(583, 131);
            this.tbModuleInfo.TabIndex = 3;
            // 
            // chkCk
            // 
            this.chkCk.AutoSize = true;
            this.chkCk.Location = new System.Drawing.Point(87, 212);
            this.chkCk.Name = "chkCk";
            this.chkCk.Size = new System.Drawing.Size(63, 22);
            this.chkCk.TabIndex = 5;
            this.chkCk.Text = "查看";
            this.chkCk.UseVisualStyleBackColor = true;
            // 
            // chkXz
            // 
            this.chkXz.AutoSize = true;
            this.chkXz.Location = new System.Drawing.Point(201, 212);
            this.chkXz.Name = "chkXz";
            this.chkXz.Size = new System.Drawing.Size(63, 22);
            this.chkXz.TabIndex = 6;
            this.chkXz.Text = "新增";
            this.chkXz.UseVisualStyleBackColor = true;
            // 
            // chkBj
            // 
            this.chkBj.AutoSize = true;
            this.chkBj.Location = new System.Drawing.Point(311, 212);
            this.chkBj.Name = "chkBj";
            this.chkBj.Size = new System.Drawing.Size(63, 22);
            this.chkBj.TabIndex = 7;
            this.chkBj.Text = "编辑";
            this.chkBj.UseVisualStyleBackColor = true;
            // 
            // chkSc
            // 
            this.chkSc.AutoSize = true;
            this.chkSc.Location = new System.Drawing.Point(425, 212);
            this.chkSc.Name = "chkSc";
            this.chkSc.Size = new System.Drawing.Size(63, 22);
            this.chkSc.TabIndex = 8;
            this.chkSc.Text = "删除";
            this.chkSc.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(202, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "回车可获取模块信息";
            // 
            // frmSysFormEditPower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 350);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkSc);
            this.Controls.Add(this.chkBj);
            this.Controls.Add(this.chkXz);
            this.Controls.Add(this.chkCk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbModuleInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbEnumNo);
            this.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysFormEditPower";
            this.ShowIcon = false;
            this.Text = "编辑参数";
            this.Load += new System.EventHandler(this.frmSysFormEditPower_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEnumNo;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbModuleInfo;
        private System.Windows.Forms.CheckBox chkCk;
        private System.Windows.Forms.CheckBox chkXz;
        private System.Windows.Forms.CheckBox chkBj;
        private System.Windows.Forms.CheckBox chkSc;
        private System.Windows.Forms.Label label3;
    }
}