namespace 战绩追踪_C_Sharp
{
    partial class Message
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
            this.MessageLab = new System.Windows.Forms.Label();
            this.accept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MessageLab
            // 
            this.MessageLab.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MessageLab.Location = new System.Drawing.Point(12, 9);
            this.MessageLab.Name = "MessageLab";
            this.MessageLab.Size = new System.Drawing.Size(299, 95);
            this.MessageLab.TabIndex = 0;
            this.MessageLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // accept
            // 
            this.accept.Location = new System.Drawing.Point(236, 107);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(75, 23);
            this.accept.TabIndex = 1;
            this.accept.Text = "好";
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // Message
            // 
            this.AcceptButton = this.accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 142);
            this.ControlBox = false;
            this.Controls.Add(this.accept);
            this.Controls.Add(this.MessageLab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Message";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MessageLab;
        private System.Windows.Forms.Button accept;
    }
}