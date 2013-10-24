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
    public partial class frmGame : Form
    {
        int currTime;

        List<Target> smallTargets = new List<Target>();
        List<Target> mediumTargets = new List<Target>();
        List<Target> bigTargets = new List<Target>();
        List<Button> smallBtns = new List<Button>();
        List<Button> mediumBtns = new List<Button>();
        List<Button> bigBtns = new List<Button>();

        public frmGame()
        {
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            this.Text = "Level " + frmMain.userLevel.getLevel();
            int currScore = frmMain.userLevel.getScore();
            currTime = 30;
            lblScore.Text = "Score: " + currScore;
            lblTime.Text = "Time: " + currTime;
        }

        private void frmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmSplash.mainForm.Show();
        }

        private void makeTargets()
        {
            for (int i = 0; i < frmMain.userLevel.getSmallTargets(); i++)
            {
                smallTargets.Add(new Target("bird"));
            }

            for (int i = 0; i < frmMain.userLevel.getMediumTargets(); i++)
            {
                mediumTargets.Add(new Target("deer"));
            }

            for (int i = 0; i < frmMain.userLevel.getBigTargets(); i++)
            {
                bigTargets.Add(new Target("buffalo"));
            }
        }
    }
}
