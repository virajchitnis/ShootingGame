namespace ShootingGame
{
    partial class frmWeapon
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
            this.lblFormName = new System.Windows.Forms.Label();
            this.picHandgun = new System.Windows.Forms.PictureBox();
            this.picRifle = new System.Windows.Forms.PictureBox();
            this.picShotgun = new System.Windows.Forms.PictureBox();
            this.lblHandgun = new System.Windows.Forms.Label();
            this.lblShotgun = new System.Windows.Forms.Label();
            this.lblRifle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picHandgun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRifle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShotgun)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormName
            // 
            this.lblFormName.AutoSize = true;
            this.lblFormName.BackColor = System.Drawing.Color.Transparent;
            this.lblFormName.Font = new System.Drawing.Font("Impact", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormName.Location = new System.Drawing.Point(143, 21);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(249, 37);
            this.lblFormName.TabIndex = 0;
            this.lblFormName.Text = "Choose a Weapon";
            // 
            // picHandgun
            // 
            this.picHandgun.BackColor = System.Drawing.Color.Transparent;
            this.picHandgun.BackgroundImage = global::ShootingGame.Properties.Resources.picHANDGUN__Transparent;
            this.picHandgun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHandgun.Location = new System.Drawing.Point(39, 84);
            this.picHandgun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picHandgun.Name = "picHandgun";
            this.picHandgun.Size = new System.Drawing.Size(140, 86);
            this.picHandgun.TabIndex = 2;
            this.picHandgun.TabStop = false;
            this.picHandgun.Click += new System.EventHandler(this.picHandgun_Click);
            // 
            // picRifle
            // 
            this.picRifle.BackColor = System.Drawing.Color.Transparent;
            this.picRifle.BackgroundImage = global::ShootingGame.Properties.Resources.picRifle__transparent;
            this.picRifle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picRifle.Location = new System.Drawing.Point(101, 174);
            this.picRifle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picRifle.Name = "picRifle";
            this.picRifle.Size = new System.Drawing.Size(328, 63);
            this.picRifle.TabIndex = 2;
            this.picRifle.TabStop = false;
            this.picRifle.Click += new System.EventHandler(this.picRifle_Click);
            // 
            // picShotgun
            // 
            this.picShotgun.BackColor = System.Drawing.Color.Transparent;
            this.picShotgun.BackgroundImage = global::ShootingGame.Properties.Resources.picShotgun__transparent___Copy;
            this.picShotgun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picShotgun.Location = new System.Drawing.Point(254, 92);
            this.picShotgun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picShotgun.Name = "picShotgun";
            this.picShotgun.Size = new System.Drawing.Size(241, 68);
            this.picShotgun.TabIndex = 2;
            this.picShotgun.TabStop = false;
            this.picShotgun.Click += new System.EventHandler(this.picShotgun_Click);
            // 
            // lblHandgun
            // 
            this.lblHandgun.AutoSize = true;
            this.lblHandgun.BackColor = System.Drawing.Color.Transparent;
            this.lblHandgun.Font = new System.Drawing.Font("Motorwerk", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHandgun.Location = new System.Drawing.Point(86, 142);
            this.lblHandgun.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHandgun.Name = "lblHandgun";
            this.lblHandgun.Size = new System.Drawing.Size(122, 18);
            this.lblHandgun.TabIndex = 3;
            this.lblHandgun.Text = "Hand Gun";
            // 
            // lblShotgun
            // 
            this.lblShotgun.AutoSize = true;
            this.lblShotgun.BackColor = System.Drawing.Color.Transparent;
            this.lblShotgun.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShotgun.Location = new System.Drawing.Point(343, 131);
            this.lblShotgun.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShotgun.Name = "lblShotgun";
            this.lblShotgun.Size = new System.Drawing.Size(100, 29);
            this.lblShotgun.TabIndex = 3;
            this.lblShotgun.Text = "Shot Gun";
            // 
            // lblRifle
            // 
            this.lblRifle.AutoSize = true;
            this.lblRifle.BackColor = System.Drawing.Color.Transparent;
            this.lblRifle.Font = new System.Drawing.Font("Gabriola", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRifle.Location = new System.Drawing.Point(274, 188);
            this.lblRifle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRifle.Name = "lblRifle";
            this.lblRifle.Size = new System.Drawing.Size(82, 65);
            this.lblRifle.TabIndex = 3;
            this.lblRifle.Text = "Rifle";
            // 
            // frmWeapon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ShootingGame.Properties.Resources.wooden_panels_030211;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(522, 252);
            this.ControlBox = false;
            this.Controls.Add(this.lblRifle);
            this.Controls.Add(this.lblShotgun);
            this.Controls.Add(this.lblHandgun);
            this.Controls.Add(this.picShotgun);
            this.Controls.Add(this.picRifle);
            this.Controls.Add(this.picHandgun);
            this.Controls.Add(this.lblFormName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmWeapon";
            this.Text = "Choose A Weapon";
            this.Load += new System.EventHandler(this.frmWeapon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHandgun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRifle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShotgun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.PictureBox picHandgun;
        private System.Windows.Forms.PictureBox picRifle;
        private System.Windows.Forms.PictureBox picShotgun;
        private System.Windows.Forms.Label lblHandgun;
        private System.Windows.Forms.Label lblShotgun;
        private System.Windows.Forms.Label lblRifle;
    }
}