﻿using System;
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
        static private volatile int finishFlag = 0;
        static private string inputID;
        static private string[] DSresult = new string[40], KSresult = new string[7], WSresult = new string[1500], VSresult = new string[372];

        public MainWindow()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private string coutLineStatic(string title, int howmuch, string value)
        {
            string rv = title;
            for (int p = 0; p < howmuch; p++)
            {
                rv += "-";
            }
            rv += value;
            return rv;
        }

        private string coutLineNum(string title, int howmuch, string value)
        {
            howmuch -= value.Length;
            string rv = title;
            for (int p = 0; p < howmuch; p++)
            {
                rv += "-";
            }
            rv += value;
            return rv;
        }

        private string coutLineCh(string title, int howmuch, string value)
        {
            howmuch -= value.Length * 2;
            string rv = title;
            for (int p = 0; p < howmuch; p++)
            {
                rv += "-";
            }
            rv += value;
            return rv;
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
                RankLab.Text = result[0];
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

        private void RefreshPage2(string[] result, string[] KSresult)
        {
            try
            {
                if (treeView1.SelectedNode.Text == "多人模式")
                {
                    详细信息文字.Text = "多人模式\n";
                    详细信息文字.Text += coutLineNum("小队分数", 48, result[0]) + "\n";
                    详细信息文字.Text += coutLineNum("奖励分数", 48, result[1]) + "\n";
                    详细信息文字.Text += coutLineNum("加成分数", 48, result[2]) + "\n";
                    return;
                }
                if (treeView1.SelectedNode.Text == "一般")
                {
                    详细信息文字.Text = "一般\n";
                    详细信息文字.Text += coutLineNum("击杀比", 51, result[3]) + "\n";
                    详细信息文字.Text += coutLineNum("救星击杀数", 46, result[4]) + "\n";
                    详细信息文字.Text += coutLineNum("协助击杀数", 46, result[5]) + "\n";
                    详细信息文字.Text += coutLineNum("爆头数", 51, result[6]) + "\n";
                    详细信息文字.Text += coutLineNum("准度", 52, result[7]) + "\n";
                    详细信息文字.Text += coutLineNum("胜利", 53, result[8]) + "\n";
                    详细信息文字.Text += coutLineNum("战败", 53, result[9]) + "\n";
                    详细信息文字.Text += coutLineNum("技巧值", 51, Convert.ToString((int)double.Parse(result[10]))) + "\n";
                    详细信息文字.Text += coutLineNum("旗帜夺取数", 46, result[11]) + "\n";
                    详细信息文字.Text += coutLineNum("旗帜防卫数", 46, result[12]) + "\n";
                    详细信息文字.Text += coutLineNum("修复数", 51, result[13]) + "\n";
                    详细信息文字.Text += coutLineNum("急救数", 51, result[14]) + "\n";
                    详细信息文字.Text += coutLineNum("已游玩回合数", 44, result[15]) + "\n";
                    详细信息文字.Text += coutLineCh("最喜爱的地图", 49, result[16]) + "\n";
                    详细信息文字.Text += coutLineNum("最专精的职业", 43, result[17]) + "\n";
                    详细信息文字.Text += coutLineNum("最长爆头距离", 44, result[18]) + "\n";
                    详细信息文字.Text += coutLineNum("击杀最多的载具", 39, result[19]) + "\n";
                    详细信息文字.Text += coutLineNum("最高连续击杀数", 42, result[20]) + "\n";
                    return;
                }
                if (treeView1.SelectedNode.Text == "兵种")
                {
                    详细信息文字.Text = "兵种\n";

                    详细信息文字.Text += coutLineNum("突击兵等级", 45, KSresult[0]) + "\n";
                    详细信息文字.Text += coutLineNum("突击兵分数", 43, result[21]) + "\n";
                    详细信息文字.Text += coutLineNum("突击兵击杀数", 42, result[22]) + "\n";
                    详细信息文字.Text += coutLineNum("医疗兵等级", 45, KSresult[1]) + "\n";
                    详细信息文字.Text += coutLineNum("医疗兵分数", 43, result[23]) + "\n";
                    详细信息文字.Text += coutLineNum("医疗兵击杀数", 42, result[24]) + "\n";
                    详细信息文字.Text += coutLineNum("支援兵等级", 45, KSresult[2]) + "\n";
                    详细信息文字.Text += coutLineNum("支援兵分数", 43, result[25]) + "\n";
                    详细信息文字.Text += coutLineNum("支援兵击杀数", 42, result[26]) + "\n";
                    详细信息文字.Text += coutLineNum("侦察兵等级", 45, KSresult[3]) + "\n";
                    详细信息文字.Text += coutLineNum("侦察兵分数", 43, result[27]) + "\n";
                    详细信息文字.Text += coutLineNum("侦察兵击杀数", 42, result[28]) + "\n";
                    详细信息文字.Text += coutLineNum("坦克手分数", 43, result[29]) + "\n";
                    详细信息文字.Text += coutLineNum("坦克手击杀数", 43, result[30]) + "\n";
                    详细信息文字.Text += coutLineNum("骑兵分数", 46, result[31]) + "\n";
                    详细信息文字.Text += coutLineNum("骑兵击杀数", 45, result[32]) + "\n";
                    详细信息文字.Text += coutLineNum("飞行员分数", 44, result[33]) + "\n";
                    详细信息文字.Text += coutLineNum("飞行员击杀数", 43, result[34]) + "\n";
                    return;
                }
                if (treeView1.SelectedNode.Text == "载具击杀数")
                {
                    详细信息文字.Text = "载具击杀数\n";
                    详细信息文字.Text += coutLineNum("空中载具", 48, result[35]) + "\n";
                    详细信息文字.Text += coutLineNum("固定式武器", 46, result[36]) + "\n";
                    详细信息文字.Text += coutLineNum("陆上装甲载具", 44, result[37]) + "\n";
                    详细信息文字.Text += coutLineNum("陆上运兵载具", 44, result[38]) + "\n";
                    详细信息文字.Text += coutLineNum("战马", 53, result[39]) + "\n";
                    return;
                }
                详细信息文字.Text = "";
            }
            catch (Exception)
            {
                详细信息文字.Text = "";
                return;
            }
        }

        private void ClearWeapons()
        {
            武器名.Text = "";
            武器图片.CancelAsync();
            武器图片.Image = null;
            武器描述.Text = "";
            武器统计.Text = "";
        }

        private void ClearVehicles()
        {
            载具名.Text = "";
            载具图片.CancelAsync();
            载具图片.Image = null;
            载具描述.Text = "";
            载具统计.Text = "";
        }

        private void RefreshPage3(string[] result)
        {
            try
            {
                ClearWeapons();
                for (int i = 0; i < result.Length && result[i] != null; i += 8)
                {
                    if (treeView2.SelectedNode != null)
                    {
                        if (result[i] == treeView2.SelectedNode.Text)
                        {
                            武器名.Text = result[i++];
                            武器图片.LoadAsync(result[i++]);
                            武器描述.Text = result[i++];
                            武器统计.Text += coutLineNum("击杀数", 60, result[i++]) + "\n";
                            武器统计.Text += coutLineNum("爆头数", 61, result[i++]) + "\n";
                            武器统计.Text += coutLineNum("准度", 63, result[i++]) + "\n";
                            武器统计.Text += coutLineNum("使用时间", 57, result[i++] + "小时\n");
                            武器统计.Text += coutLineNum("每分钟击杀数", 54, result[i] + "\n");
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                ClearWeapons();
            }
        }

        private void MakePage3(string[] result)
        {
            try
            {
                for (int i = 0; i < result.Length && result[i] != null; i += 8)
                {
                    treeView2.Invoke(new Action(() =>
                    {
                        treeView2.Nodes.Add(new TreeNode(result[i]));
                    }));                    
                }
            }
            catch (Exception ex) {
            }
        }

        private void RefreshPage4(string[] result)
        {
            try
            {
                ClearVehicles();
                for (int i = 0; i < result.Length && result[i] != null; i += 6)
                {
                    if (treeView3.SelectedNode != null)
                    {
                        if (result[i] == treeView3.SelectedNode.Text)
                        {
                            载具名.Text = result[i++];
                            载具图片.LoadAsync(result[i++]);
                            载具描述.Text = result[i++];
                            载具统计.Text += coutLineNum("击杀数", 60, result[i++]) + "\n";
                            载具统计.Text += coutLineNum("使用时间", 57, result[i++] + "小时\n");
                            载具统计.Text += coutLineNum("每分钟击杀数", 54, result[i] + "\n");
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                ClearVehicles();
            }
        }

        private void MakePage4(string[] result)
        {
            try
            {
                for (int i = 0; i < result.Length && result[i] != null; i += 6)
                {
                    treeView3.Invoke(new Action(() =>
                    {
                        treeView3.Nodes.Add(new TreeNode(result[i]));
                    }));
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void QueryBS()
        {
            RefreshPage1(BFT.GetBasicStats(inputID));
            finishFlag--;
            if (finishFlag <= 0) { statusBar.Visible = false; finishFlag = 0; }
        }

        private void QueryDT()
        {
            RefreshDogtag(BFT.GetDogTagImg(inputID));
            finishFlag--;
            if (finishFlag <= 0) { statusBar.Visible = false; finishFlag = 0; }
        }

        private void QueryDS()
        {
            DSresult = BFT.GetDetailedStats(inputID);
            RefreshPage2(DSresult, KSresult);
            finishFlag--;
            if (finishFlag <= 0) { statusBar.Visible = false; finishFlag = 0; }
        }

        private void QueryKS()
        {
            KSresult = BFT.GetKitRanks(inputID);
            RefreshPage2(DSresult, KSresult);
            finishFlag--;
            if (finishFlag <= 0) { statusBar.Visible = false; finishFlag = 0; }
        }

        private void QueryWS()
        {
            WSresult = BFT.GetWeaponsStats(inputID);
            treeView2.Nodes.Clear();
            ClearWeapons();
            MakePage3(WSresult);
            RefreshPage3(WSresult);

            finishFlag--;
            if (finishFlag <= 0) { statusBar.Visible = false; finishFlag = 0; }
        }

        private void QueryVS()
        {
            VSresult = BFT.GetVehiclesStats(inputID);
            treeView3.Nodes.Clear();
            ClearVehicles();
            MakePage4(VSresult);
            RefreshPage4(VSresult);

            finishFlag--;
            if (finishFlag <= 0) { statusBar.Visible = false; finishFlag = 0; }
        }

        private void ClearArray(ref string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = null;
            }
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (finishFlag != 0) return;
            Program.GetLastID();
            var Box = new 查询(Program.lastid);
            if (Box.ShowDialog() == DialogResult.OK)
            {
                Program.SaveLastID(Box.inputid);
            }
            else return;

            inputID = Box.inputid;

            Thread BSt, Dogtagt, DSt, KSt, WSt, VSt;

            BSt = new Thread(new ThreadStart(QueryBS));
            Dogtagt = new Thread(new ThreadStart(QueryDT));
            DSt = new Thread(new ThreadStart(QueryDS));
            KSt = new Thread(new ThreadStart(QueryKS));
            WSt = new Thread(new ThreadStart(QueryWS));
            VSt = new Thread(new ThreadStart(QueryVS));

            BSt.IsBackground = true;
            Dogtagt.IsBackground = true;
            DSt.IsBackground = true;
            KSt.IsBackground = true;
            WSt.IsBackground = true;
            VSt.IsBackground = true;

            statusBar.Visible = true;
            ClearArray(ref DSresult);
            ClearArray(ref KSresult);
            ClearArray(ref WSresult);
            ClearArray(ref VSresult);

            try
            {
                BSt.Start();
                Dogtagt.Start();
                finishFlag = 2;
                if (Box.Deatiled) { DSt.Start(); KSt.Start(); finishFlag += 2; }
                if (Box.Weapons) { WSt.Start(); finishFlag++; }
                if (Box.Vehicles) { VSt.Start(); finishFlag++; }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Box = new About();
            Box.ShowDialog();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://liuziangexit.com/BFT/help");
            }
            catch (Exception) { }
        }

        private void 软件更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshPage2(DSresult, KSresult);
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshPage3(WSresult);
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshPage4(VSresult);
        }
    }
}
