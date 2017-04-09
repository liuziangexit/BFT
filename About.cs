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
        public About()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://liuziangexit.com/");
            }
            catch (Exception) { }
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://liuziangexit.com/BFT");
            }
            catch (Exception) { }
        }

        private void SourceCodeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/liuziangexit/BFT");
            }
            catch (Exception) { }
        }
    }
}
