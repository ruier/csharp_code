namespace romBitGen
{
    partial class MainWindow
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_source_file = new System.Windows.Forms.Button();
            this.l_source_file_name = new System.Windows.Forms.Label();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.btn_ungen = new System.Windows.Forms.Button();
            this.btn_gen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_source_file
            // 
            this.btn_source_file.Location = new System.Drawing.Point(383, 12);
            this.btn_source_file.Name = "btn_source_file";
            this.btn_source_file.Size = new System.Drawing.Size(75, 23);
            this.btn_source_file.TabIndex = 0;
            this.btn_source_file.Text = "打开";
            this.btn_source_file.UseVisualStyleBackColor = true;
            this.btn_source_file.Click += new System.EventHandler(this.btn_source_file_Click);
            // 
            // l_source_file_name
            // 
            this.l_source_file_name.AutoSize = true;
            this.l_source_file_name.Location = new System.Drawing.Point(13, 12);
            this.l_source_file_name.Name = "l_source_file_name";
            this.l_source_file_name.Size = new System.Drawing.Size(77, 12);
            this.l_source_file_name.TabIndex = 1;
            this.l_source_file_name.Text = "请选择源文件";
            this.l_source_file_name.Click += new System.EventHandler(this.l_source_file_name_Click);
            // 
            // cb_type
            // 
            this.cb_type.DisplayMember = "1";
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Items.AddRange(new object[] {
            "firmware",
            "sfware"});
            this.cb_type.Location = new System.Drawing.Point(15, 27);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(75, 20);
            this.cb_type.TabIndex = 4;
            // 
            // btn_ungen
            // 
            this.btn_ungen.Location = new System.Drawing.Point(383, 51);
            this.btn_ungen.Name = "btn_ungen";
            this.btn_ungen.Size = new System.Drawing.Size(75, 23);
            this.btn_ungen.TabIndex = 5;
            this.btn_ungen.Text = "解码";
            this.btn_ungen.UseVisualStyleBackColor = true;
            // 
            // btn_gen
            // 
            this.btn_gen.Location = new System.Drawing.Point(267, 51);
            this.btn_gen.Name = "btn_gen";
            this.btn_gen.Size = new System.Drawing.Size(75, 23);
            this.btn_gen.TabIndex = 6;
            this.btn_gen.Text = "生成";
            this.btn_gen.UseVisualStyleBackColor = true;
            this.btn_gen.Click += new System.EventHandler(this.btn_gen_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 138);
            this.Controls.Add(this.btn_gen);
            this.Controls.Add(this.btn_ungen);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.l_source_file_name);
            this.Controls.Add(this.btn_source_file);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Name = "MainWindow";
            this.Text = "romBitGenerator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_source_file;
        private System.Windows.Forms.Label l_source_file_name;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Button btn_ungen;
        private System.Windows.Forms.Button btn_gen;
    }
}

