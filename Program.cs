using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 战绩追踪_C_Sharp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ClearFiles();
            if(!CheckFiles())
            {
                var Box = new Message("无法启动", "战绩追踪无法启动，因为文件丢失。", "修复");
                Box.ShowDialog();
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine("start BFT_M.exe");
                p.StandardInput.AutoFlush = true;
                p.StandardInput.WriteLine("exit");
                p.WaitForExit();
                p.Close();
                System.Environment.Exit(0);
            }
            Application.Run(new MainWindow());
        }

        static bool CheckFiles() {
            if (File.Exists(Application.StartupPath + "\\BFT-CPP-DLL.dll") && File.Exists(Application.StartupPath + "\\cpprest140_2_9.dll")) return true;
            return false;
        }

        static void ClearFiles()
        {
            if (File.Exists(Application.StartupPath + "\\Update.bat")) File.Delete(Application.StartupPath + "\\Update.bat");
        }

        static public void GetLastID()
        {
            if (File.Exists(Application.StartupPath + "\\lastid"))
            {
                var reader = new System.IO.StreamReader("lastid");
                try
                {                    
                    lastid = reader.ReadLine();
                    reader.Close();
                }
                catch (Exception ex)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch (Exception) { }
                }
            }
        }

        static public void SaveLastID(string input)
        {
            var writer = new System.IO.StreamWriter("lastid");
            try
            {
                writer.WriteLine(input);
                writer.Close();
            }
            catch (Exception ex)
            {
                try
                {
                    writer.Close();
                }
                catch (Exception) { }
            }
        }

        static public string lastid;
    }
}
