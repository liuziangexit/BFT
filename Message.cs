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
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
        }

        public Message(string title, string messagetext)
        {
            InitializeComponent();
            SetTitle(title);
            SetMessage(messagetext);
        }

        public Message(string title, string messagetext,string buttontext)
        {
            InitializeComponent();
            SetTitle(title);
            SetMessage(messagetext);
            SetButtonText(buttontext);
        }

        public void SetTitle(string input)
        {
            Text = input;
        }

        public void SetMessage(string input)
        {
            MessageLab.Text = input;
        }

        public void SetButtonText(string input)
        {
            accept.Text = input;
        }

        private void accept_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
