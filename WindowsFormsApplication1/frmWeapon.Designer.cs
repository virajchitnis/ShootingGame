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
            this.btnHandGun = new System.Windows.Forms.Button();
            this.btnRifle = new System.Windows.Forms.Button();
            this.btnShotGun = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormName
            // 
            this.lblFormName.AutoSize = true;
            this.lblFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormName.Location = new System.Drawing.Point(13, 13);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(141, 20);
            this.lblFormName.TabIndex = 0;
            this.lblFormName.Text = "Choose a Weapon";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShotGun);
            this.panel1.Controls.Add(this.btnRifle);
            this.panel1.Controls.Add(this.btnHandGun);
            this.panel1.Location = new System.Drawing.Point(13, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 138);
            this.panel1.TabIndex = 1;
            // 
            // btnHandGun
            // 
            this.btnHandGun.Location = new System.Drawing.Point(4, 4);
            this.btnHandGun.Name = "btnHandGun";
            this.btnHandGun.Size = new System.Drawing.Size(172, 131);
            this.btnHandGun.TabIndex = 0;
            this.btnHandGun.Text = "Hand Gun";
            this.btnHandGun.UseVisualStyleBackColor = true;
            // 
            // btnRifle
            // 
            this.btnRifle.Location = new System.Drawing.Point(182, 3);
            this.btnRifle.Name = "btnRifle";
            this.btnRifle.Size = new System.Drawing.Size(172, 131);
            this.btnRifle.TabIndex = 1;
            this.btnRifle.Text = "Rifle";
            this.btnRifle.UseVisualStyleBackColor = true;
            // 
            // btnShotGun
            // 
            this.btnShotGun.Location = new System.Drawing.Point(360, 3);
            this.btnShotGun.Name = "btnShotGun";
            this.btnShotGun.Size = new System.Drawing.Size(172, 131);
            this.btnShotGun.TabIndex = 2;
            this.btnShotGun.Text = "Shot Gun";
            this.btnShotGun.UseVisualStyleBackColor = true;
            // 
            // frmWeapon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 200);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFormName);
            this.Name = "frmWeapon";
            this.Text = "Choose A Weapon";
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