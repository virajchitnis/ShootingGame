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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShotGun = new System.Windows.Forms.Button();
            this.btnRifle = new System.Windows.Forms.Button();
            this.btnHandGun = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormName
            // 
            this.lblFormName.AutoSize = true;
            this.lblFormName.BackColor = System.Drawing.Color.Transparent;
            this.lblFormName.Font = new System.Drawing.Font("Impact", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormName.Location = new System.Drawing.Point(215, 33);
            this.lblFormName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(357, 54);
            this.lblFormName.TabIndex = 0;
            this.lblFormName.Text = "Choose a Weapon";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnShotGun);
            this.panel1.Controls.Add(this.btnRifle);
            this.panel1.Controls.Add(this.btnHandGun);
            this.panel1.Location = new System.Drawing.Point(13, 92);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 292);
            this.panel1.TabIndex = 1;
            // 
            // btnShotGun
            // 
            this.btnShotGun.BackgroundImage = global::ShootingGame.Properties.Resources.picShotgun;
            this.btnShotGun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShotGun.Font = new System.Drawing.Font("Miramonte", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShotGun.Location = new System.Drawing.Point(257, 5);
            this.btnShotGun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShotGun.Name = "btnShotGun";
            this.btnShotGun.Size = new System.Drawing.Size(487, 142);
            this.btnShotGun.TabIndex = 2;
            this.btnShotGun.Text = "Shot Gun";
            this.btnShotGun.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnShotGun.UseVisualStyleBackColor = true;
            this.btnShotGun.Click += new System.EventHandler(this.btnShotGun_Click);
            // 
            // btnRifle
            // 
            this.btnRifle.BackgroundImage = global::ShootingGame.Properties.Resources.picRifle;
            this.btnRifle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRifle.Font = new System.Drawing.Font("Miramonte", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRifle.Location = new System.Drawing.Point(107, 145);
            this.btnRifle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRifle.Name = "btnRifle";
            this.btnRifle.Size = new System.Drawing.Size(545, 132);
            this.btnRifle.TabIndex = 1;
            this.btnRifle.Text = "Rifle";
            this.btnRifle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRifle.UseVisualStyleBackColor = true;
            this.btnRifle.Click += new System.EventHandler(this.btnRifle_Click);
            // 
            // btnHandGun
            // 
            this.btnHandGun.BackgroundImage = global::ShootingGame.Properties.Resources.picHANDGUN;
            this.btnHandGun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHandGun.Font = new System.Drawing.Font("Miramonte", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHandGun.Location = new System.Drawing.Point(6, 6);
            this.btnHandGun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHandGun.Name = "btnHandGun";
            this.btnHandGun.Size = new System.Drawing.Size(250, 142);
            this.btnHandGun.TabIndex = 0;
            this.btnHandGun.Text = "Hand Gun";
            this.btnHandGun.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnHandGun.UseVisualStyleBackColor = true;
            this.btnHandGun.Click += new System.EventHandler(this.btnHandGun_Click);
            // 
            // frmWeapon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ShootingGame.Properties.Resources.wooden_panels_030211;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(783, 429);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFormName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmWeapon";
            this.Text = "Choose A Weapon";
            this.Load += new System.EventHandler(this.frmWeapon_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHandGun;
        private System.Windows.Forms.Button btnShotGun;
        private System.Windows.Forms.Button btnRifle;
    }
}