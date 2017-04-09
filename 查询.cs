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
    public partial class 查询 : Form
    {
        public 查询(String lastid)
        {
            InitializeComponent();
            textBox1.Text = lastid;
            game = "BF1";
        }

        public string inputid = "", game = "";
        public bool Deatiled = false, Vehicles = false, Weapons = false;

        private void AllSet()
        {
            详细.CheckState = CheckState.Checked;
            武器.CheckState = CheckState.Checked;
            载具.CheckState = CheckState.Checked;
        }

        private void AllReset()
        {
            详细.CheckState = CheckState.Unchecked;
            武器.CheckState = CheckState.Unchecked;
            载具.CheckState = CheckState.Unchecked;
        }

        private bool CheckSet()
        {
            if (详细.CheckState == CheckState.Checked && 武器.CheckState == CheckState.Checked && 载具.CheckState == CheckState.Checked) return true;
            return false;
        }

        private void ChangeName()
        {
            if (CheckSet())
            {
                button2.Text = "重设";
            }
            else
            {
                button2.Text = "全选";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckSet())
            {
                button2.Text = "全选";
                AllReset();
            }
            else
            {
                button2.Text = "重设";
                AllSet();
            }
        }

        private void 武器_CheckedChanged(object sender, EventArgs e)
        {
            ChangeName();
            if (武器.CheckState == CheckState.Checked)
            {
                Weapons = true;
                return;
            }
            if (武器.CheckState == CheckState.Unchecked)
            {
                Weapons = false;
                return;
            }
        }

        private void 载具_CheckedChanged(object sender, EventArgs e)
        {
            ChangeName();
            if (载具.CheckState == CheckState.Checked)
            {
                Vehicles = true;
                return;
            }
            if (载具.CheckState == CheckState.Unchecked)
            {
                Vehicles = false;
                return;
            }
        }

        private void 详细_CheckedChanged(object sender, EventArgs e)
        {
            ChangeName();
            if (详细.CheckState == CheckState.Checked)
            {
                Deatiled = true;
                return;
            }
            if (详细.CheckState == CheckState.Unchecked)
            {
                Deatiled = false;
                return;
            }
        }

        private void 查询_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            inputid = textBox1.Text;
            this.Close();
        }
    }
}
