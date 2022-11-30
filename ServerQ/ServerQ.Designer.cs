
namespace ServerQ
{
    partial class ServerQ
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerQ));
            this.checkingView = new System.Windows.Forms.RichTextBox();
            this.browse = new System.Windows.Forms.Button();
            this.showQ = new System.Windows.Forms.Button();
            this.playercheckBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.EndBtn = new System.Windows.Forms.Button();
            this.infoView = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.clockBOX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.USERinfoANDinteract = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ten = new System.Windows.Forms.ToolStripMenuItem();
            this.Score = new System.Windows.Forms.ToolStripMenuItem();
            this.Kick = new System.Windows.Forms.ToolStripMenuItem();
            this.USERinfoANDinteract.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkingView
            // 
            this.checkingView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkingView.Location = new System.Drawing.Point(198, 12);
            this.checkingView.Name = "checkingView";
            this.checkingView.ReadOnly = true;
            this.checkingView.Size = new System.Drawing.Size(590, 203);
            this.checkingView.TabIndex = 0;
            this.checkingView.Text = "";
            // 
            // browse
            // 
            this.browse.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.browse.Location = new System.Drawing.Point(12, 12);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(180, 48);
            this.browse.TabIndex = 1;
            this.browse.Text = "Browse question from...";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // showQ
            // 
            this.showQ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.showQ.Enabled = false;
            this.showQ.Location = new System.Drawing.Point(12, 87);
            this.showQ.Name = "showQ";
            this.showQ.Size = new System.Drawing.Size(180, 48);
            this.showQ.TabIndex = 2;
            this.showQ.Text = "Show questions";
            this.showQ.UseVisualStyleBackColor = true;
            this.showQ.Click += new System.EventHandler(this.showQ_Click);
            // 
            // playercheckBtn
            // 
            this.playercheckBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.playercheckBtn.Location = new System.Drawing.Point(12, 167);
            this.playercheckBtn.Name = "playercheckBtn";
            this.playercheckBtn.Size = new System.Drawing.Size(180, 48);
            this.playercheckBtn.TabIndex = 3;
            this.playercheckBtn.Text = "PLayer check";
            this.playercheckBtn.UseVisualStyleBackColor = true;
            this.playercheckBtn.Click += new System.EventHandler(this.playercheckBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartBtn.Enabled = false;
            this.StartBtn.Location = new System.Drawing.Point(12, 241);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(180, 48);
            this.StartBtn.TabIndex = 3;
            this.StartBtn.Text = "Start Quizz";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // EndBtn
            // 
            this.EndBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EndBtn.Enabled = false;
            this.EndBtn.Location = new System.Drawing.Point(12, 316);
            this.EndBtn.Name = "EndBtn";
            this.EndBtn.Size = new System.Drawing.Size(180, 48);
            this.EndBtn.TabIndex = 3;
            this.EndBtn.Text = "ForceEnd Quizz(Manually)";
            this.EndBtn.UseVisualStyleBackColor = true;
            this.EndBtn.Click += new System.EventHandler(this.EndBtn_Click);
            // 
            // infoView
            // 
            this.infoView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoView.HideSelection = false;
            this.infoView.LargeImageList = this.imageList1;
            this.infoView.Location = new System.Drawing.Point(198, 221);
            this.infoView.Name = "infoView";
            this.infoView.Size = new System.Drawing.Size(590, 217);
            this.infoView.TabIndex = 4;
            this.infoView.UseCompatibleStateImageBehavior = false;
            this.infoView.Click += new System.EventHandler(this.infoView_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Person_icon_BLACK-01.svg.png");
            this.imageList1.Images.SetKeyName(1, "Person_icon_GREEN.png");
            // 
            // clockBOX
            // 
            this.clockBOX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clockBOX.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockBOX.Location = new System.Drawing.Point(12, 416);
            this.clockBOX.Name = "clockBOX";
            this.clockBOX.Size = new System.Drawing.Size(180, 22);
            this.clockBOX.TabIndex = 5;
            this.clockBOX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 34);
            this.label1.TabIndex = 6;
            this.label1.Text = "TIMER(set before start \r\nQuizz) ex: 10:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // USERinfoANDinteract
            // 
            this.USERinfoANDinteract.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.USERinfoANDinteract.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ten,
            this.Score,
            this.Kick});
            this.USERinfoANDinteract.Name = "USERinfoANDinteract";
            this.USERinfoANDinteract.Size = new System.Drawing.Size(222, 76);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.Color.Black;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.ForeColor = System.Drawing.Color.Lime;
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(221, 24);
            this.ten.Text = "toolStripMenuItem1";
            // 
            // Score
            // 
            this.Score.BackColor = System.Drawing.Color.Black;
            this.Score.Enabled = false;
            this.Score.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.ForeColor = System.Drawing.Color.Gold;
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(221, 24);
            this.Score.Text = "toolStripMenuItem1";
            // 
            // Kick
            // 
            this.Kick.Name = "Kick";
            this.Kick.Size = new System.Drawing.Size(221, 24);
            this.Kick.Text = "KICK";
            this.Kick.Click += new System.EventHandler(this.Kick_Click);
            // 
            // ServerQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clockBOX);
            this.Controls.Add(this.infoView);
            this.Controls.Add(this.EndBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.playercheckBtn);
            this.Controls.Add(this.showQ);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.checkingView);
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "ServerQ";
            this.Text = "ServerQ";
            this.USERinfoANDinteract.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox checkingView;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Button showQ;
        private System.Windows.Forms.Button playercheckBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button EndBtn;
        private System.Windows.Forms.ListView infoView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox clockBOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip USERinfoANDinteract;
        private System.Windows.Forms.ToolStripMenuItem ten;
        private System.Windows.Forms.ToolStripMenuItem Score;
        private System.Windows.Forms.ToolStripMenuItem Kick;
    }
}

