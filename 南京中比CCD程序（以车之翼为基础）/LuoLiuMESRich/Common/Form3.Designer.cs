namespace Common
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ucEditFile1 = new Common.UserControls.ucEditFile();
            this.ucFile1 = new Common.UserControls.ucFile();
            this.ucAutoSaveTimerShow1 = new Common.UserControls.ucAutoSaveTimerShow();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(39, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(629, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "临时处理配纤时仓库不正确，点击下面的执行按钮，直至它提醒成功！";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "执行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucEditFile1
            // 
            this.ucEditFile1.Location = new System.Drawing.Point(54, 87);
            this.ucEditFile1.Name = "ucEditFile1";
            this.ucEditFile1.ParentGuid = "";
            this.ucEditFile1.ReadOnly = false;
            this.ucEditFile1.Size = new System.Drawing.Size(662, 218);
            this.ucEditFile1.TabIndex = 2;
            this.ucEditFile1.Updated = false;
            // 
            // ucFile1
            // 
            this.ucFile1.BackColor = System.Drawing.Color.White;
            this.ucFile1.Creater = "";
            this.ucFile1.CreaterTitle = "创建人";
            this.ucFile1.CreateTime = "";
            this.ucFile1.CreateTimeTitle = "创建时间";
            this.ucFile1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucFile1.EntityGUID = "";
            this.ucFile1.FileExtension = "";
            this.ucFile1.FileName = "";
            this.ucFile1.FilesCount = 0;
            this.ucFile1.FileTypeCode = "";
            this.ucFile1.ICOPath = "";
            this.ucFile1.IsFocused = false;
            this.ucFile1.IsPower = false;
            this.ucFile1.IsShowCreateInfo = true;
            this.ucFile1.IsShowFilesCount = false;
            this.ucFile1.IsShowTitle = true;
            this.ucFile1.Location = new System.Drawing.Point(93, 110);
            this.ucFile1.Name = "ucFile1";
            this.ucFile1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ucFile1.ParentControl = null;
            this.ucFile1.PreViewFileGUID = "";
            this.ucFile1.PrimaryValue = null;
            this.ucFile1.Size = new System.Drawing.Size(131, 127);
            this.ucFile1.SortID = -1;
            this.ucFile1.TabIndex = 3;
            // 
            // ucAutoSaveTimerShow1
            // 
            this.ucAutoSaveTimerShow1.Location = new System.Drawing.Point(171, 13);
            this.ucAutoSaveTimerShow1.Name = "ucAutoSaveTimerShow1";
            this.ucAutoSaveTimerShow1.Size = new System.Drawing.Size(282, 23);
            this.ucAutoSaveTimerShow1.TabIndex = 4;
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(714, 266);
            this.Controls.Add(this.ucAutoSaveTimerShow1);
            this.Controls.Add(this.ucFile1);
            this.Controls.Add(this.ucEditFile1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private UserControls.ucEditFile ucEditFile1;
        private UserControls.ucFile ucFile1;
        private UserControls.ucAutoSaveTimerShow ucAutoSaveTimerShow1;
    }
}