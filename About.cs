using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 战绩追踪_C_Sharp
{
    public partial class About : Form
    {
        private bool isMouseDown = false;
        private Point mouseOff;

        public About()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var box = new ShowText();
            box.ShowDialog();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            logoPictureBox.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/liuziangexit/BFT");
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://liuziangexit.com/BFT");
            }
            catch (Exception) { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://liuziangexit.com");
            }
            catch (Exception) { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("liuziang@liuziangexit.com");
            var box = new Message();
            box.SetButtonText("好");
            box.SetMessage("开发者邮箱地址已经复制到剪贴板。");
            box.SetTitle(" ");
            box.ShowDialog();
        }
    }
}
