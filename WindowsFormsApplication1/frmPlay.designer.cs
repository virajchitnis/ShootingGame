namespace ShootingGame
{
    partial class frmPlay
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
            this.btnBig = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTimeCount = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSmall = new System.Windows.Forms.Button();
            this.picBird = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBird)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBig
            // 
            this.btnBig.BackColor = System.Drawing.Color.Transparent;
            this.btnBig.Location = new System.Drawing.Point(386, 313);
            this.btnBig.Name = "btnBig";
            this.btnBig.Size = new System.Drawing.Size(140, 78);
            this.btnBig.TabIndex = 0;
            this.btnBig.Text = "btnBig";
            this.btnBig.UseVisualStyleBackColor = false;
            this.btnBig.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.Location = new System.Drawing.Point(417, 236);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(89, 30);
            this.btnMedium.TabIndex = 1;
            this.btnMedium.Text = "btnMedium";
            this.btnMedium.UseVisualStyleBackColor = true;
            this.btnMedium.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Score:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(305, 7);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(152, 26);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "        0                  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(507, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Time:";
            // 
            // lblTimeCount
            // 
            this.lblTimeCount.AutoSize = true;
            this.lblTimeCount.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTimeCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTimeCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeCount.Location = new System.Drawing.Point(604, 7);
            this.lblTimeCount.Name = "lblTimeCount";
            this.lblTimeCount.Size = new System.Drawing.Size(97, 26);
            this.lblTimeCount.TabIndex = 6;
            this.lblTimeCount.Text = ":30            ";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(386, 446);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(143, 77);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start Game!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(866, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Viraj,  i would like these 3 text boxes to move (smallest should be the fastest, " +
                "largest, the slowest). Then i would like to change them into a picture. (a targe" +
                "t, beer can, or animal maybe)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTimeCount);
            this.panel1.Location = new System.Drawing.Point(0, 566);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 49);
            this.panel1.TabIndex = 9;
            // 
            // btnSmall
            // 
            this.btnSmall.BackColor = System.Drawing.Color.Transparent;
            this.btnSmall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSmall.ForeColor = System.Drawing.Color.Black;
            this.btnSmall.Location = new System.Drawing.Point(573, 172);
            this.btnSmall.Name = "btnSmall";
            this.btnSmall.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSmall.Size = new System.Drawing.Size(40, 33);
            this.btnSmall.TabIndex = 2;
            this.btnSmall.Text = "btnSmall";
            this.btnSmall.UseVisualStyleBackColor = false;
            this.btnSmall.Click += new System.EventHandler(this.button3_Click);
            // 
            // picBird
            // 
            this.picBird.Image = global::ShootingGame.Properties.Resources.bird6;
            this.picBird.Location = new System.Drawing.Point(350, 95);
            this.picBird.Name = "picBird";
            this.picBird.Size = new System.Drawing.Size(58, 44);
            this.picBird.TabIndex = 10;
            this.picBird.TabStop = false;
            this.picBird.Click += new System.EventHandler(this.picBird_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frmLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ShootingGame.Properties.Resources.Prairie_en_Meurthe_et_Moselle;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(677, 750);
            this.Controls.Add(this.picBird);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSmall);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnBig);
            this.Name = "frmLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Level";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBird)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBig;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnSmall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTimeCount;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picBird;
        private System.Windows.Forms.Timer timer2;
    }
}

