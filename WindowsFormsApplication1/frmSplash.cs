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
    public partial class frmSplash : Form
    {
        SoundPlayer menuMusic;

        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_MouseClick(object sender, MouseEventArgs e)
        {
            startGame();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            ToolTip playGame = new ToolTip();
            playGame.SetToolTip(this, "Click anywhere to play");
            menuMusic = new SoundPlayer(@"..\..\Resources\songKalimba.wav");
            menuMusic.Play();
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void startGame()
        {
            frmMain mainForm = new frmMain(menuMusic);
            mainForm.Show();
            this.Hide();
        }
    }
}
