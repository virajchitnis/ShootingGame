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
    public partial class frmMain : Form
    {
        public static Weapon userWeapon;
        public static Level userLevel;
        public static string userName;

        HighScores highScores;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This game was created by Robin Notte & Viraj Chitnis as a project at Temple University. Contact us at robin.notte@gmail.com or chitnisviraj@gmail.com.\n\n\nCopyright \u00a9 2013", "About");
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome 'Insert name here'!\n   1. Click new game to start.\n   2. Select a weapon.\n   3. Select a level.\n   4. Shoot as many targets as possible before you run out of time.\n   5. Enjoy!!!", "How to Play");
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            frmHighScores formHighScores = new frmHighScores(highScores);
            formHighScores.Show();
            this.Hide();
        }

        private void btnStartNew_Click(object sender, EventArgs e)
        {
            frmUser formUser = new frmUser();
            formUser.Show();
            this.Hide();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            highScores = new HighScores("high_scores.txt");
            if (highScores.Exist())
            {
                btnHighScores.Enabled = true;
            }
        }
    }
}
