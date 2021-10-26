namespace LuoLiuMESPrinter
{
    partial class frmPrintFaild
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
            this.labMsg = new System.Windows.Forms.Label();
            this.btPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(598, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "打印失败，请重新打印";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMsg
            // 
            this.labMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.labMsg.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMsg.Location = new System.Drawing.Point(0, 53);
            this.labMsg.Name = "labMsg";
            this.labMsg.Padding = new System.Windows.Forms.Padding(9, 10, 0, 0);
            this.labMsg.Size = new System.Drawing.Size(598, 96);
            this.labMsg.TabIndex = 1;
            this.labMsg.Text = "原因：";
            // 
            // btPrint
            // 
            this.btPrint.Location = new System.Drawing.Point(244, 163);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(92, 33);
            this.btPrint.TabIndex = 2;
            this.btPrint.Text = "重新打印";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // frmPrintFaild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 207);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.labMsg);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintFaild";
            this.Text = "重新打印";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labMsg;
        private System.Windows.Forms.Button btPrint;
    }
}