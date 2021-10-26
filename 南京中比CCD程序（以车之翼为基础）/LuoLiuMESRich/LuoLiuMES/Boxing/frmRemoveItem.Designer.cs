namespace LuoLiuMES.Boxing
{
    partial class frmRemoveItem
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
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBoxCode = new System.Windows.Forms.TextBox();
            this.tbItemCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btRemove = new System.Windows.Forms.Button();
            this.labMsg = new System.Windows.Forms.Label();
            this.chkGoon = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Maroon;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(379, 39);
            this.label6.TabIndex = 218;
            this.label6.Text = "从托盘中移除电池包";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 219;
            this.label1.Text = "当前托盘号";
            // 
            // tbBoxCode
            // 
            this.tbBoxCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBoxCode.Location = new System.Drawing.Point(95, 57);
            this.tbBoxCode.Name = "tbBoxCode";
            this.tbBoxCode.ReadOnly = true;
            this.tbBoxCode.Size = new System.Drawing.Size(272, 24);
            this.tbBoxCode.TabIndex = 220;
            // 
            // tbItemCode
            // 
            this.tbItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbItemCode.Location = new System.Drawing.Point(95, 91);
            this.tbItemCode.Name = "tbItemCode";
            this.tbItemCode.Size = new System.Drawing.Size(272, 24);
            this.tbItemCode.TabIndex = 222;
            this.tbItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbItemCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 221;
            this.label2.Text = "电池包编号";
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(145, 128);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(94, 40);
            this.btRemove.TabIndex = 223;
            this.btRemove.Text = "确认移除";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // labMsg
            // 
            this.labMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labMsg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labMsg.Location = new System.Drawing.Point(0, 168);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(379, 28);
            this.labMsg.TabIndex = 224;
            this.labMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkGoon
            // 
            this.chkGoon.AutoSize = true;
            this.chkGoon.Location = new System.Drawing.Point(267, 146);
            this.chkGoon.Name = "chkGoon";
            this.chkGoon.Size = new System.Drawing.Size(86, 19);
            this.chkGoon.TabIndex = 225;
            this.chkGoon.Text = "继续移除";
            this.chkGoon.UseVisualStyleBackColor = true;
            // 
            // frmRemoveItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 196);
            this.Controls.Add(this.chkGoon);
            this.Controls.Add(this.labMsg);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.tbItemCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbBoxCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRemoveItem";
            this.Text = "移除电池包";
            this.Load += new System.EventHandler(this.frmRemoveItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBoxCode;
        private System.Windows.Forms.TextBox tbItemCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Label labMsg;
        private System.Windows.Forms.CheckBox chkGoon;
    }
}