using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 战绩追踪_C_Sharp
{
    public partial class MainWindow : Form
    {
        static private string inputID;

        public MainWindow()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void ShowErrorBox(string[] result)
        {
            if (result[0] != null)
                MessageBox.Show(result[0], "查询失败");
            else MessageBox.Show("未知的原因", "查询失败");
        }

        private void RefreshPage1(string[] result)
        {
            try
            {
                statusBar.Visible = false;
                if (!BFT.JudgeSuccessful(result))
                {
                    ShowErrorBox(result);
                    return;
                }

                label1.Text = "每分钟得分";
                label4.Text = "每分钟击杀数";
                label5.Text = "游戏时间";
                label6.Text = "胜率";
                label11.Text = "死亡数";
                label12.Text = "击杀数";
                try
                {
                    RankPic.Image = null;
                    RankPic.LoadAsync(result[8]);
                }
                catch (Exception)
                { }
                IDLab.Text = inputID;
                SPMLab.Text = result[1];
                WinsLab.Text= ((int)(((double)int.Parse(result[9]) / (double)(int.Parse(result[9]) + int.Parse(result[10]))) * 100)).ToString() + "%";
                KillsLab.Text = result[5];
                KPMLab.Text = result[4];
                TimeLab.Text = result[3] + "小时";
                DeathLab.Text = result[6];
            }
            catch (Exception)
            { }
        }

        private void RefreshDogtag(string[] result)
        {
            try
            {
                DogtagPic.Image = null;
                DogtagPic.LoadAsync(result[0]);
            }
            catch (Exception)
            { }

            try
            {
                DogtagbackPic.Image = null;
                DogtagbackPic.LoadAsync(result[1]);
            }
            catch (Exception)
            { }
        }

        private void QueryBS()
        {
            RefreshPage1(BFT.GetBasicStats(inputID));
        }

        private void QueryDT()
        {
            RefreshDogtag(BFT.GetDogTagImg(inputID));
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.GetLastID();
            var Box = new 查询(Program.lastid);
            if (Box.ShowDialog() == DialogResult.OK)
            {
                Program.SaveLastID(Box.inputid);
            }
            else return;

            inputID = Box.inputid;

            Thread BSt, Dogtagt;
            BSt = new Thread(new ThreadStart(QueryBS));
            Dogtagt = new Thread(new ThreadStart(QueryDT));
            BSt.IsBackground = true;
            Dogtagt.IsBackground = true;

            statusBar.Visible = true;

            try
            {                
                Dogtagt.Start();
                BSt.Start();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
