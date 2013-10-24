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
        Weapon currWeapon;
        public frmWeapon()
        {
            InitializeComponent();
        }

        private void btnHandGun_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("handgun");
            frmMain.userWeapon = currWeapon;
            frmLevel selLevel = new frmLevel();
            selLevel.Show();
            this.Close();
        }

        private void btnRifle_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("rifle");
            frmMain.userWeapon = currWeapon;
            frmLevel selLevel = new frmLevel();
            selLevel.Show();
            this.Close();
        }

        private void btnShotGun_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("shotgun");
            frmMain.userWeapon = currWeapon;
            frmLevel selLevel = new frmLevel();
            selLevel.Show();
            this.Close();
        }
    }
}
