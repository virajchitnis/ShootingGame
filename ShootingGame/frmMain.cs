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
    public partial class frmMain : Form
    {
        SoundPlayer menuMusic;

        public frmMain(SoundPlayer music)
        {
            InitializeComponent();
            menuMusic = music;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult exitOrNot = MessageBox.Show("Are you sure you want to exit the game?", "Exit Game", MessageBoxButtons.YesNo);
            if (exitOrNot == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hunting Season v1.0.2\n\nThis game was created by Robin Notte & Viraj Chitnis as a project at Temple University. Contact us at robin.notte@gmail.com or chitnisviraj@gmail.com.\n\n\nCopyright \u00a9 2013", "About");
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Hunting Season!\n   1. Click new game to start.\n   2. Select a weapon.\n   3. Select a level.\n   4. Shoot all targets on screen before you run out of time.\n   5. Enjoy!!!", "How to Play");
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            if (File.Exists("high_scores.txt"))
            {
                frmHighScores formHighScores = new frmHighScores(menuMusic);
                formHighScores.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No high scores yet, play the game to earn an high score.", "No High Scores");
            }
        }

        private void btnStartNew_Click(object sender, EventArgs e)
        {
            frmUser formUser = new frmUser(menuMusic);
            formUser.Show();
            this.Close();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (File.Exists("game_save.txt"))
            {
                frmWeapon formWeapon = new frmWeapon(menuMusic);
                formWeapon.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No game saved, play the game to save your progress. You can then continue where you left off.", "No Game Saved");
            }
        }
    }
}
