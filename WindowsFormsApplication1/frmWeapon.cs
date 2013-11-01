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
        Player user;
        Weapon currWeapon;
        public frmWeapon(Player name)
        {
            InitializeComponent();
            user = name;
        }

        private void picHandgun_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("handgun");
            Level currLevel = new Level(1, 1, 1, 1);
            frmGame newLevel = new frmGame(user, currWeapon, currLevel);
            newLevel.Show();
            this.Close();

        }

        private void picRifle_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("rifle");
            Level currLevel = new Level(1, 1, 1, 1);
            frmGame newLevel = new frmGame(user, currWeapon, currLevel);
            newLevel.Show();
            this.Close();

        }

        private void picShotgun_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("shotgun");
            Level currLevel = new Level(1, 1, 1, 1);
            frmGame newLevel = new frmGame(user, currWeapon, currLevel);
            newLevel.Show();
            this.Close();

        }
    }
}
