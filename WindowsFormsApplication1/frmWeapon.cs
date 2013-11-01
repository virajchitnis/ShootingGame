using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ShootingGame
{
    public partial class frmWeapon : Form
    {
        Player user;
        Weapon currWeapon;
        Level currLevel;
        public frmWeapon(Player name)
        {
            InitializeComponent();
            user = name;
            currLevel = new Level(1, 1, 1, 1);
        }

        public frmWeapon()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("game_save.txt");
            string line = sr.ReadLine();
            string[] entries = line.Split(',');
            user = new Player(entries[0], Convert.ToInt32(entries[2]));
            currLevel = new Level(Convert.ToInt32(entries[1]), Convert.ToInt32(entries[1]), Convert.ToInt32(entries[1]), Convert.ToInt32(entries[1]));
        }

        private void picHandgun_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("handgun");
            frmGame newGame = new frmGame(user, currWeapon, currLevel);
            newGame.Show();
            this.Close();
        }

        private void picRifle_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("rifle");
            frmGame newGame = new frmGame(user, currWeapon, currLevel);
            newGame.Show();
            this.Close();
        }

        private void picShotgun_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("shotgun");
            frmGame newGame = new frmGame(user, currWeapon, currLevel);
            newGame.Show();
            this.Close();
        }
    }
}
