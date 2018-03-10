using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace romBitGen
{
    class romBitGen
    {
        private byte[] ware_ver_magic = new byte[] { 0xa6, 0xf7, 0x66, 0x77 };
        private byte[] firmware_magic = new byte[] { 0xd8, 0xfb, 0x12, 0xaa };
        private byte[] sfware_3k_magic = new byte[] { 0xd8, 0xfb, 0x12, 0xbb };
        private byte[] sfware_9k_magic = new byte[] { 0xd8, 0xfb, 0x12, 0xcc };

        private String source_file;

        public void setSourceFile(String sf)
        {
            source_file = sf;
        }
    }

    class winDirCtr
    {
        public static String getSourceFile()
        {
            String fn = "";
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult res = dlg.ShowDialog();

            if (res == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dlg.FileName))
                {
                    fn = dlg.FileName; ;
                }
            }
            else
                fn = "";

            return fn;
        }

        public static void bz2compress(String source, String target)
        {
            Process bz2Process = new Process();

            try
            {
                bz2Process.StartInfo.UseShellExecute = true;
                bz2Process.StartInfo.FileName = "minibz2.exe";
                bz2Process.StartInfo.CreateNoWindow = true;
                bz2Process.StartInfo.Arguments = " -1 " + source + " " + target;
                bz2Process.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            bz2Process.WaitForExit();
        }
    }
}
