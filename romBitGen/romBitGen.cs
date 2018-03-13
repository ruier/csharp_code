using ICSharpCode.SharpZipLib.BZip2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        private String source_file = "";
        private String target_file = "";
        private String zip_file = "";

        public void setSourceFile(String sf)
        {
            source_file = sf;
        }

        public void setTargetFile(String type, decimal main, decimal sub, decimal debug)
        {
            target_file = Path.Combine(Path.Combine(Application.StartupPath, "gen"), type + main + "-" + sub + "#" + debug);
            MessageBox.Show("target" + target_file);
        }

        public void setZipFile(String t)
        {
            String zip_path = Path.Combine(Application.StartupPath, "gen");
            String zip_name = Path.GetFileNameWithoutExtension(t) + ".zip";
            zip_file = Path.Combine(zip_path, zip_name);
            MessageBox.Show(zip_file);
      
        }

        public void initGen(String fn)
        {
            String targetDir;
            targetDir = Path.Combine(Application.StartupPath, "gen");

            if (!Directory.Exists(targetDir))
                Directory.CreateDirectory(targetDir);

            setSourceFile(fn);
        }

        public void bitZip(String s)
        {
            setZipFile(s);
            //winDirCtr.bz2compress(s, zip_file);
            winDirCtr.BZipFile(s, zip_file);
        }

        public void bitGen(String type_ver, decimal main_ver, decimal sub_ver, decimal debug_ver)
        {

            long zip_file_len = 0;
            FileInfo fileInfo = null;

            setTargetFile(type_ver, main_ver, sub_ver, debug_ver);

            try
            {
                fileInfo = new System.IO.FileInfo(zip_file);
                zip_file_len = fileInfo.Length;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // 其他处理异常的代码
            }

            FileStream streamRead = new FileStream(zip_file, FileMode.Open);
            FileStream streamWrite = new FileStream(target_file, FileMode.Create);

            byte[] data = new byte[zip_file_len];

            int length = streamRead.Read(data, 0, data.Length);

            if (zip_file_len < 0x490)
            {
                MessageBox.Show("文件太小，请检查文件正确性");
                return;
            }

            for (int i = 0; i < 0x490; i++)
                streamWrite.WriteByte(Convert.ToByte((Convert.ToChar(data[i]) + 0x88) % 0x100));
            streamWrite.Seek(512, SeekOrigin.Begin);

            for (int i = 0; i < 16; i++)
                streamWrite.WriteByte(Convert.ToByte((Convert.ToChar(data[i]) + 0x80) % 0x100));

            streamWrite.Seek(256, SeekOrigin.Current);
            for (int i = 16; i < (16 + 128); i++)
                streamWrite.WriteByte(data[i]);

            streamWrite.Seek(256, SeekOrigin.Current);

            for (int i = (16 + 128); i < data.Length; i++)
                streamWrite.WriteByte(data[i]);

            streamWrite.Seek(0, SeekOrigin.Begin);
            byte[] flen = BitConverter.GetBytes(Convert.ToInt32(zip_file_len + 1024));

            for (int i = 3; i > -1; i--)
                streamWrite.WriteByte(flen[i]);

            if (type_ver == ("firmware"))
                streamWrite.Write(firmware_magic, 0, firmware_magic.Length);
            else
                streamWrite.Write(sfware_9k_magic, 0, sfware_9k_magic.Length);

            streamWrite.Write(ware_ver_magic, 0, ware_ver_magic.Length);

            byte[] v_m = BitConverter.GetBytes(Convert.ToInt32(main_ver));

            for (int i = 3; i > -1; i--)
                streamWrite.WriteByte(v_m[i]);

            byte[] v_s = BitConverter.GetBytes(Convert.ToInt32(sub_ver));

            for (int i = 3; i > -1; i--)
                streamWrite.WriteByte(v_s[i]);

            byte[] v_d = BitConverter.GetBytes(Convert.ToInt32(debug_ver));

            for (int i = 3; i > -1; i--)
                streamWrite.WriteByte(v_d[i]);

            streamWrite.Flush();
            streamWrite.Close();
            streamRead.Close();
        }
    }
}

class winDirCtr
{
    public static String getSourceFile()
    {
        String fn = "";
        OpenFileDialog dlg = new OpenFileDialog();
        dlg.InitialDirectory = Application.StartupPath;
        dlg.RestoreDirectory = true;

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            if (!string.IsNullOrEmpty(dlg.FileName))
            {
                fn = dlg.FileName;
                Directory.SetCurrentDirectory(Application.StartupPath);
            }
        }
        else
            fn = "";
        
        return fn;
    }

    public static void preGenEnv(String dir)
    {
        String targetDir;
        targetDir = Path.Combine(Directory.GetCurrentDirectory(), "gen");

        if (!Directory.Exists(targetDir))
            Directory.CreateDirectory(targetDir);
    }

    public static void bz2compress(String source, String target)
    {
        if (!File.Exists("minibz2.exe"))
        {
            MessageBox.Show("没有找到 minibz2.exe，请检查文件夹完整性");
            return;
        }

        Process bz2Process = new Process();

        try
        {
            bz2Process.StartInfo.UseShellExecute = false;
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

    public static bool BZipFile(string sourcefilename, string zipfilename)
    {
        bool blResult;//表示压缩是否成功的返回结果
                      //为源文件创建文件流实例，作为压缩方法的输入流参数
        FileStream srcFile = File.OpenRead(sourcefilename);
        //为压缩文件创建文件流实例，作为压缩方法的输出流参数
        FileStream zipFile = File.Open(zipfilename, FileMode.Create);
        try
        {
            //以4096字节作为一个块的方式压缩文件
            BZip2.Compress(srcFile, zipFile, true, 1);
            blResult = true;
        }
        catch (Exception ee)
        {
            Console.WriteLine(ee.Message);
            blResult = false;
        }
        srcFile.Close();//关闭源文件流
        zipFile.Close();//关闭压缩文件流
        return blResult;
    }
}


