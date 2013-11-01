using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace ShootingGame
{
    public partial class frmWeapon : Form
    {
        SoundPlayer menuMusic;
        Player user;
        Weapon currWeapon;
        Level currLevel;
        public frmWeapon(SoundPlayer music, Player name)
        {
            InitializeComponent();
            user = name;
            currLevel = new Level(1, 1, 1, 1);
            menuMusic = music;
        }

        public frmWeapon(SoundPlayer music)
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("game_save.txt");
            string line = sr.ReadLine();
            string[] entries = line.Split(',');
            user = new Player(entries[0], Convert.ToInt32(entries[2]));
            currLevel = new Level(Convert.ToInt32(entries[1]), Convert.ToInt32(entries[1]), Convert.ToInt32(entries[1]), Convert.ToInt32(entries[1]));
            menuMusic = music;
        }

        private void picHandgun_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("handgun");
            frmGame newGame = new frmGame(menuMusic, user, currWeapon, currLevel);
            newGame.Show();
            this.Close();
        }

        private void picRifle_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("rifle");
            frmGame newGame = new frmGame(menuMusic, user, currWeapon, currLevel);
            newGame.Show();
            this.Close();
        }

        private void picShotgun_Click(object sender, EventArgs e)
        {
            currWeapon = new Weapon("shotgun");
            frmGame newGame = new frmGame(menuMusic, user, currWeapon, currLevel);
            newGame.Show();
            this.Close();
        }

        private void frmWeapon_Load(object sender, EventArgs e)
        {
            ToolTip tltHandgun = new ToolTip();
            tltHandgun.SetToolTip(picHandgun, "Handgun:\n  Ammo: 10\n  Damage: 1");

            ToolTip tltRifle = new ToolTip();
            tltRifle.SetToolTip(picRifle, "Rifle:\n  Ammo: 6\n  Damage: 2");

            ToolTip tltShotgun = new ToolTip();
            tltShotgun.SetToolTip(picShotgun, "Shotgun:\n  Ammo: 2\n  Damage: 4");
        }
    }
}
