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
        string userName;
        Weapon currWeapon;
        public frmLevel(string name, Weapon w)
        {
            InitializeComponent();
            currWeapon = w;
            userName = name;
        }

        private void btnLevel1_Click(object sender, EventArgs e)
        {
            Level currLevel = new Level(1, 1, 1, 1);
            frmMain.userLevel = currLevel;
            frmGame newLevel = new frmGame(userName, currWeapon, currLevel);
            newLevel.Show();
            this.Close();
        }
    }
}
