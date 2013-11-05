using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;

namespace ShootingGame
{
    public partial class frmUser : Form
    {
        SoundPlayer menuMusic;
        Player user;
        string userName;
        public frmUser(SoundPlayer music)
        {
            InitializeComponent();
            userName = "";
            menuMusic = music;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            userName = txtName.Text;
            if (userName == "")
            {
                MessageBox.Show("Please enter a name!", "Invalid Name");
            }
            else
            {
                user = new Player(userName);
                frmWeapon weapons = new frmWeapon(menuMusic, user);
                weapons.Show();
                this.Close();
            }
        }
    }
}
