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

            }
        }
    }
}
