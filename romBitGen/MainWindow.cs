using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace romBitGen
{
    public partial class MainWindow : Form
    {
        private romBitGen rom = new romBitGen();
        public MainWindow()
        {
            InitializeComponent();          
        }

        private void l_source_file_name_Click(object sender, EventArgs e)
        {
            l_source_file_name.Text = winDirCtr.getSourceFile();
            if (l_source_file_name.Text != "")
            {
                if (Path.HasExtension(l_source_file_name.Text))
                    cb_type.SelectedIndex = 1;
                else
                    cb_type.SelectedIndex = 0;

                rom.initGen(l_source_file_name.Text);
            }
        }

        private void btn_source_file_Click(object sender, EventArgs e)
        {
            l_source_file_name.Text = winDirCtr.getSourceFile();
            if (l_source_file_name.Text != "")
            {
                if(Path.HasExtension(l_source_file_name.Text))
                    cb_type.SelectedIndex = 1;
                else
                    cb_type.SelectedIndex = 0;

                rom.initGen(l_source_file_name.Text);
            }
           
        }

        private void btn_gen_Click(object sender, EventArgs e)
        {
            if (!File.Exists(l_source_file_name.Text))
            {
                MessageBox.Show("没有选择源文件，请先点击打开按钮选择源文件");
                return;
            }

            if (rom.bitZip(l_source_file_name.Text))
                rom.bitGen(cb_type.Text, nud_main.Value, nud_sub.Value, nud_debug.Value);
            else
                MessageBox.Show("创建失败，请重试。");
        }

        private void btn_ungen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂不支持");
        }
    }
}
