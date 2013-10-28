using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShootingGame
{
    public partial class frmWeapon : Form
    {
        string userName;
        Weapon currWeapon;
        public frmWeapon(string name)
        {
            InitializeComponent();
            userName = name;
        }

        private void picHandgun_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("handgun");
            frmMain.userWeapon = currWeapon;
            frmLevel selLevel = new frmLevel(userName, currWeapon);
            selLevel.Show();
            this.Close();

        }

        private void picRifle_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("rifle");
            frmMain.userWeapon = currWeapon;
            frmLevel selLevel = new frmLevel(userName, currWeapon);
            selLevel.Show();
            this.Close();

        }

        private void picShotgun_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("shotgun");
            frmMain.userWeapon = currWeapon;
            frmLevel selLevel = new frmLevel(userName, currWeapon);
            selLevel.Show();
            this.Close();

        }
    }
}
