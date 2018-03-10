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
            this.nud_debug = new System.Windows.Forms.NumericUpDown();
            this.nud_main = new System.Windows.Forms.NumericUpDown();
            this.nud_sub = new System.Windows.Forms.NumericUpDown();
            this.verDebug = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_debug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sub)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_source_file
            // 
            this.btn_source_file.Location = new System.Drawing.Point(383, 13);
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
            this.l_source_file_name.Location = new System.Drawing.Point(13, 24);
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
            this.cb_type.Location = new System.Drawing.Point(15, 49);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(75, 20);
            this.cb_type.TabIndex = 4;
            // 
            // btn_ungen
            // 
            this.btn_ungen.Location = new System.Drawing.Point(383, 94);
            this.btn_ungen.Name = "btn_ungen";
            this.btn_ungen.Size = new System.Drawing.Size(75, 23);
            this.btn_ungen.TabIndex = 5;
            this.btn_ungen.Text = "解码";
            this.btn_ungen.UseVisualStyleBackColor = true;
            // 
            // btn_gen
            // 
            this.btn_gen.Location = new System.Drawing.Point(256, 94);
            this.btn_gen.Name = "btn_gen";
            this.btn_gen.Size = new System.Drawing.Size(75, 23);
            this.btn_gen.TabIndex = 6;
            this.btn_gen.Text = "生成";
            this.btn_gen.UseVisualStyleBackColor = true;
            this.btn_gen.Click += new System.EventHandler(this.btn_gen_Click);
            // 
            // nud_debug
            // 
            this.nud_debug.Location = new System.Drawing.Point(418, 48);
            this.nud_debug.Name = "nud_debug";
            this.nud_debug.Size = new System.Drawing.Size(40, 21);
            this.nud_debug.TabIndex = 7;
            // 
            // nud_main
            // 
            this.nud_main.Location = new System.Drawing.Point(169, 48);
            this.nud_main.Name = "nud_main";
            this.nud_main.Size = new System.Drawing.Size(40, 21);
            this.nud_main.TabIndex = 8;
            // 
            // nud_sub
            // 
            this.nud_sub.Location = new System.Drawing.Point(291, 49);
            this.nud_sub.Name = "nud_sub";
            this.nud_sub.Size = new System.Drawing.Size(40, 21);
            this.nud_sub.TabIndex = 9;
            // 
            // verDebug
            // 
            this.verDebug.AutoSize = true;
            this.verDebug.Location = new System.Drawing.Point(359, 52);
            this.verDebug.Name = "verDebug";
            this.verDebug.Size = new System.Drawing.Size(53, 12);
            this.verDebug.TabIndex = 10;
            this.verDebug.Text = "verDebug";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "verSub";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "verMain";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 129);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.verDebug);
            this.Controls.Add(this.nud_sub);
            this.Controls.Add(this.nud_main);
            this.Controls.Add(this.nud_debug);
            this.Controls.Add(this.btn_gen);
            this.Controls.Add(this.btn_ungen);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.l_source_file_name);
            this.Controls.Add(this.btn_source_file);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Name = "MainWindow";
            this.Text = "romBitGenerator";
            ((System.ComponentModel.ISupportInitialize)(this.nud_debug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sub)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_source_file;
        private System.Windows.Forms.Label l_source_file_name;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Button btn_ungen;
        private System.Windows.Forms.Button btn_gen;
        private System.Windows.Forms.NumericUpDown nud_debug;
        private System.Windows.Forms.NumericUpDown nud_main;
        private System.Windows.Forms.NumericUpDown nud_sub;
        private System.Windows.Forms.Label verDebug;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

