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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private String FileName;
        private romBitGen box = new romBitGen();
        private BitGenerator b = new BitGenerator();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult res = dlg.ShowDialog();

            if (res == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dlg.FileName))
                {
                    label1.Text = dlg.FileName;
                    FileName = dlg.FileName;
                    b.setFileName(FileName);
                }
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            box.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (b.isInited() == 0)
            {
                MessageBox.Show("请选择需要转换的文件");
                return;
            }
            else if (b.isInited() == 1)
            {
                MessageBox.Show("请选择版本和类型");
                return;
            }
            else
            {
                b.compress();
                b.encode();

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            b.setVersion(comboBox1.Text, numericUpDown1.Value, numericUpDown2.Value, numericUpDown3.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            b.setVersion(comboBox1.Text, numericUpDown1.Value, numericUpDown2.Value, numericUpDown3.Value);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            b.setVersion(comboBox1.Text, numericUpDown1.Value, numericUpDown2.Value, numericUpDown3.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            b.setVersion(comboBox1.Text, numericUpDown1.Value, numericUpDown2.Value, numericUpDown3.Value);
        }
    }
}
