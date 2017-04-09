namespace 战绩追踪_C_Sharp
{
    partial class 查询
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.武器 = new System.Windows.Forms.CheckBox();
            this.载具 = new System.Windows.Forms.CheckBox();
            this.详细 = new System.Windows.Forms.CheckBox();
            this.总览 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入ID:";
            // 
            // textBox1
            // 
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(57, 6);
            this.textBox1.MaxLength = 32;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(99, 21);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(87, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "好";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 武器
            // 
            this.武器.AutoSize = true;
            this.武器.Location = new System.Drawing.Point(108, 33);
            this.武器.Name = "武器";
            this.武器.Size = new System.Drawing.Size(48, 16);
            this.武器.TabIndex = 2;
            this.武器.TabStop = false;
            this.武器.Text = "武器";
            this.武器.UseVisualStyleBackColor = true;
            this.武器.CheckedChanged += new System.EventHandler(this.武器_CheckedChanged);
            // 
            // 载具
            // 
            this.载具.AutoSize = true;
            this.载具.Location = new System.Drawing.Point(108, 55);
            this.载具.Name = "载具";
            this.载具.Size = new System.Drawing.Size(48, 16);
            this.载具.TabIndex = 6;
            this.载具.TabStop = false;
            this.载具.Text = "载具";
            this.载具.UseVisualStyleBackColor = true;
            this.载具.CheckedChanged += new System.EventHandler(this.载具_CheckedChanged);
            // 
            // 详细
            // 
            this.详细.AutoSize = true;
            this.详细.Location = new System.Drawing.Point(13, 55);
            this.详细.Name = "详细";
            this.详细.Size = new System.Drawing.Size(48, 16);
            this.详细.TabIndex = 2;
            this.详细.TabStop = false;
            this.详细.Text = "详细";
            this.详细.UseVisualStyleBackColor = true;
            this.详细.CheckedChanged += new System.EventHandler(this.详细_CheckedChanged);
            // 
            // 总览
            // 
            this.总览.AutoSize = true;
            this.总览.Checked = true;
            this.总览.CheckState = System.Windows.Forms.CheckState.Checked;
            this.总览.Enabled = false;
            this.总览.Location = new System.Drawing.Point(13, 33);
            this.总览.Name = "总览";
            this.总览.Size = new System.Drawing.Size(48, 16);
            this.总览.TabIndex = 8;
            this.总览.TabStop = false;
            this.总览.Text = "总览";
            this.总览.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "全选";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 查询
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 107);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.总览);
            this.Controls.Add(this.详细);
            this.Controls.Add(this.载具);
            this.Controls.Add(this.武器);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "查询";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询";
            this.Load += new System.EventHandler(this.查询_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox 武器;
        private System.Windows.Forms.CheckBox 载具;
        private System.Windows.Forms.CheckBox 详细;
        private System.Windows.Forms.CheckBox 总览;
        private System.Windows.Forms.Button button2;
    }
}