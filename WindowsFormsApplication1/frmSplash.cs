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
        public static frmMain mainForm;
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_MouseClick(object sender, MouseEventArgs e)
        {
            mainForm = new frmMain(menuMusic);
            mainForm.Show();
            this.Hide();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            menuMusic = new SoundPlayer(@"..\..\Resources\songKalimba.wav");
            menuMusic.Play();
        }
    }
}
