﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShootingGame
{
    public partial class frmUser : Form
    {
        Player user;
        string userName;
        public frmUser()
        {
            InitializeComponent();
            userName = "";
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
                frmWeapon weapons = new frmWeapon(user);
                weapons.Show();
                this.Close();
            }
        }
    }
}
