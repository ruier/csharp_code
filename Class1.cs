using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    class BitGenerator
    {
        private byte[] ware_ver_magic = new byte[] {0xa6, 0xf7, 0x66, 0x77};
        private byte[] firmware_magic = new byte[] { 0xd8, 0xfb, 0x12, 0xaa };
        private byte[] sfware_3k_magic = new byte[] { 0xd8, 0xfb, 0x12, 0xbb };
        private byte[] sfware_9k_magic = new byte[] { 0xd8, 0xfb, 0x12, 0xcc };

        private String FileName;
        private String targetFilePath;
        private String targetFileName = "test.txt";
        private String destFileName = "test.txt";

        private int init_st = 0;
        private decimal main_ver;
        private decimal sub_ver;
        private decimal debug_ver;
        private String type_ver;

        private Process zipProcess;
        private long targetFileLen;
        private long destFileLen;

        public BitGenerator()
        {
            init_st = 0;
        }

        public int isInited()
        {
            return init_st;
        }

        public void setFileName(String name)
        {
            FileName = name;
            targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "gen");
            targetFileName = Path.Combine(targetFilePath, Path.GetFileNameWithoutExtension(FileName));
            targetFileName += ".zip";

            destFileName = Path.Combine(targetFilePath, "sfware");

            if (!Directory.Exists(targetFilePath))
                Directory.CreateDirectory(targetFilePath);

            FileInfo fileInfo = null;
            try
            {
                fileInfo = new System.IO.FileInfo(FileName);
                targetFileLen = fileInfo.Length;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // 其他处理异常的代码
            }


            if (targetFileLen < 0x490)
            {
                MessageBox.Show("文件太小，请检查文件");
                init_st = 0;
                return;
            }

            if (init_st != 2)
                init_st = 1;

        }

        public void setVersion(String type, decimal main, decimal sub, decimal debug)
        {
            type_ver = type;
            main_ver = main;
            sub_ver = sub;
            debug_ver = debug;

            
            init_st = 2;
        }

        public void compress()
        {


            zipProcess = new Process();

            try
            {
                zipProcess.StartInfo.UseShellExecute = true;
                zipProcess.StartInfo.FileName = "minibz2.exe";
                zipProcess.StartInfo.CreateNoWindow = true;
                zipProcess.StartInfo.Arguments = " -1 " + FileName + " " + targetFileName;
                zipProcess.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
  
        }

        public void encode()
        {

            zipProcess.WaitForExit();

            destFileName = Path.Combine(targetFilePath, type_ver + main_ver + "-" + sub_ver + "-" + debug_ver);

            FileInfo fileInfo = null;
            try
            {
                fileInfo = new System.IO.FileInfo(targetFileName);
                destFileLen = fileInfo.Length;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // 其他处理异常的代码
            }

            FileStream streamRead = new FileStream(targetFileName, FileMode.Open);
            FileStream streamWrite = new FileStream(destFileName, FileMode.Create);

            byte[] data = new byte[destFileLen];

            int length = streamRead.Read(data, 0, data.Length);


            for(int i = 0; i < 0x490; i++)
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
            byte[] flen = BitConverter.GetBytes(Convert.ToInt32(destFileLen + 1024));

            for (int i = 3; i > -1; i--)
                streamWrite.WriteByte(flen[i]);       

            if(type_ver == ("firmware"))
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
