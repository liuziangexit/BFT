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
    public partial class TitleBarOnlyClose : UserControl
    {
        public delegate void ClickHandler(object sender, TitleClickArgs e);
        public event ClickHandler OnClickExitButton;

        public TitleBarOnlyClose()
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
    }
}
