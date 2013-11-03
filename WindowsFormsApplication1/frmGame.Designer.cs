namespace ShootingGame
{
    partial class frmGame
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
            this.lblAmmo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblReload = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblAmmo);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 35);
            this.panel1.TabIndex = 0;
            // 
            // lblAmmo
            // 
            this.lblAmmo.Location = new System.Drawing.Point(95, 11);
            this.lblAmmo.Name = "lblAmmo";
            this.lblAmmo.Size = new System.Drawing.Size(177, 13);
            this.lblAmmo.TabIndex = 4;
            this.lblAmmo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(369, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(233, 13);
            this.lblName.TabIndex = 3;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(318, 7);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(45, 20);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(608, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(47, 17);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "Time: ";
            this.lblTime.DoubleClick += new System.EventHandler(this.lblTime_DoubleClick);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(12, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(53, 17);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score: ";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(271, 156);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(159, 135);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblReload
            // 
            this.lblReload.BackColor = System.Drawing.Color.Transparent;
            this.lblReload.Enabled = false;
            this.lblReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReload.Location = new System.Drawing.Point(12, 38);
            this.lblReload.Name = "lblReload";
            this.lblReload.Size = new System.Drawing.Size(666, 53);
            this.lblReload.TabIndex = 2;
            this.lblReload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReload.Visible = false;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(690, 468);
            this.ControlBox = false;
            this.Controls.Add(this.lblReload);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmGame";
            this.Text = "Level";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGame_FormClosing);
            this.Load += new System.EventHandler(this.frmGame_Load);
            this.Click += new System.EventHandler(this.frmGame_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAmmo;
        private System.Windows.Forms.Label lblReload;
    }
}