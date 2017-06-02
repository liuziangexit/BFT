using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 战绩追踪_C_Sharp
{
    public partial class TitleBarNoMax : UserControl
    {
        public delegate void ClickHandler(object sender, TitleClickArgs e);
        public event ClickHandler OnClickExitButton;

        public TitleBarNoMax()
        {
            InitializeComponent();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = global::战绩追踪_C_Sharp.Properties.Resources.CloseWhite;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = global::战绩追踪_C_Sharp.Properties.Resources.Close;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FocusLabel.Focus();
            OnClickExitButton(this, new 战绩追踪_C_Sharp.TitleClickArgs() { which = 1 });
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackgroundImage = global::战绩追踪_C_Sharp.Properties.Resources.MinimizeWhite;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackgroundImage = global::战绩追踪_C_Sharp.Properties.Resources.Minimize;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FocusLabel.Focus();
            OnClickExitButton(this, new 战绩追踪_C_Sharp.TitleClickArgs() { which = 3 });
        }
    }

    public class TitleClickArgs : EventArgs
    {
        public int which = 0;//1close,2maximize,3minimize
    }
}
