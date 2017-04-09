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
            Application.Run(new MainWindow());
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
