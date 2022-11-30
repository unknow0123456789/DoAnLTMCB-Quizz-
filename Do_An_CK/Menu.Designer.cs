namespace Do_An_CK
{
    partial class Menu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BXH_btn = new System.Windows.Forms.Button();
            this.timeleftLabel = new System.Windows.Forms.Label();
            this.PortserverLabel = new System.Windows.Forms.Label();
            this.IPserverLabel = new System.Windows.Forms.Label();
            this.DiemLabel = new System.Windows.Forms.Label();
            this.TenLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BXH_btn);
            this.panel1.Controls.Add(this.timeleftLabel);
            this.panel1.Controls.Add(this.PortserverLabel);
            this.panel1.Controls.Add(this.IPserverLabel);
            this.panel1.Controls.Add(this.DiemLabel);
            this.panel1.Controls.Add(this.TenLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 376);
            this.panel1.TabIndex = 0;
            // 
            // BXH_btn
            // 
            this.BXH_btn.Location = new System.Drawing.Point(188, 328);
            this.BXH_btn.Name = "BXH_btn";
            this.BXH_btn.Size = new System.Drawing.Size(157, 35);
            this.BXH_btn.TabIndex = 4;
            this.BXH_btn.Text = "BXH";
            this.BXH_btn.UseVisualStyleBackColor = true;
            // 
            // timeleftLabel
            // 
            this.timeleftLabel.AutoSize = true;
            this.timeleftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeleftLabel.Location = new System.Drawing.Point(70, 270);
            this.timeleftLabel.Name = "timeleftLabel";
            this.timeleftLabel.Size = new System.Drawing.Size(70, 25);
            this.timeleftLabel.TabIndex = 3;
            this.timeleftLabel.Text = "label2";
            // 
            // PortserverLabel
            // 
            this.PortserverLabel.AutoSize = true;
            this.PortserverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortserverLabel.Location = new System.Drawing.Point(70, 229);
            this.PortserverLabel.Name = "PortserverLabel";
            this.PortserverLabel.Size = new System.Drawing.Size(70, 25);
            this.PortserverLabel.TabIndex = 3;
            this.PortserverLabel.Text = "label2";
            // 
            // IPserverLabel
            // 
            this.IPserverLabel.AutoSize = true;
            this.IPserverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPserverLabel.Location = new System.Drawing.Point(70, 185);
            this.IPserverLabel.Name = "IPserverLabel";
            this.IPserverLabel.Size = new System.Drawing.Size(70, 25);
            this.IPserverLabel.TabIndex = 3;
            this.IPserverLabel.Text = "label2";
            // 
            // DiemLabel
            // 
            this.DiemLabel.AutoSize = true;
            this.DiemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiemLabel.Location = new System.Drawing.Point(70, 141);
            this.DiemLabel.Name = "DiemLabel";
            this.DiemLabel.Size = new System.Drawing.Size(70, 25);
            this.DiemLabel.TabIndex = 3;
            this.DiemLabel.Text = "label2";
            // 
            // TenLabel
            // 
            this.TenLabel.AutoSize = true;
            this.TenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenLabel.Location = new System.Drawing.Point(70, 91);
            this.TenLabel.Name = "TenLabel";
            this.TenLabel.Size = new System.Drawing.Size(70, 25);
            this.TenLabel.TabIndex = 3;
            this.TenLabel.Text = "label2";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Menu";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(16, 328);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(157, 35);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát Quizz";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 400);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Menu";
            this.Text = "Menu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeleftLabel;
        private System.Windows.Forms.Label PortserverLabel;
        private System.Windows.Forms.Label IPserverLabel;
        private System.Windows.Forms.Label DiemLabel;
        private System.Windows.Forms.Label TenLabel;
        public System.Windows.Forms.Button btnThoat;
        public System.Windows.Forms.Button BXH_btn;
    }
}