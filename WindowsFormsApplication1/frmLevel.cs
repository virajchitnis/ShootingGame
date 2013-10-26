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
    public partial class frmLevel : Form
    {
        Weapon currWeapon;
        public frmLevel(Weapon w)
        {
            InitializeComponent();
            currWeapon = w;
        }

        private void btnLevel1_Click(object sender, EventArgs e)
        {
            Level currLevel = new Level(1, 1, 1, 1);
            frmMain.userLevel = currLevel;
            frmGame newLevel = new frmGame(currWeapon, currLevel);
            newLevel.Show();
            this.Close();
        }
    }
}
