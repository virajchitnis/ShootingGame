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
                Button btnCurr = new Button();
                btnCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnCurr.Location = new System.Drawing.Point(100, 100);
                btnCurr.Size = new System.Drawing.Size(30, 30);
                btnCurr.UseVisualStyleBackColor = true;
                btnCurr.Text = i.ToString();
                btnCurr.Name = "btnSmlTar" + i;
                btnCurr.Click += new EventHandler(btnSml_Click);
                smallBtns.Add(btnCurr);
                smallTargets.Add(new Target("bird"));
                Controls.Add(smallBtns[i]);
            }

            for (int i = 0; i < frmMain.userLevel.getMediumTargets(); i++)
            {
                Button btnCurr = new Button();
                btnCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnCurr.Location = new System.Drawing.Point(200, 200);
                btnCurr.Size = new System.Drawing.Size(50, 50);
                btnCurr.UseVisualStyleBackColor = true;
                btnCurr.Text = i.ToString();
                btnCurr.Name = "btnMedTar" + i;
                btnCurr.Click += new EventHandler(btnMed_Click);
                mediumBtns.Add(btnCurr);
                mediumTargets.Add(new Target("deer"));
                Controls.Add(mediumBtns[i]);
            }

            for (int i = 0; i < frmMain.userLevel.getBigTargets(); i++)
            {
                Button btnCurr = new Button();
                btnCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnCurr.Location = new System.Drawing.Point(300, 300);
                btnCurr.Size = new System.Drawing.Size(100, 100);
                btnCurr.UseVisualStyleBackColor = true;
                btnCurr.Text = i.ToString();
                btnCurr.Name = "btnBigTar" + i;
                btnCurr.Click += new EventHandler(btnBig_Click);
                bigBtns.Add(btnCurr);
                bigTargets.Add(new Target("buffalo"));
                Controls.Add(bigBtns[i]);
            }
        }

        void btnBig_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            int clickNum = Convert.ToInt32(clickedBtn.Text);
            bigTargets[clickNum].Shot(frmMain.userWeapon.getDamage());

            if (!bigTargets[clickNum].isAlive())
            {
                clickedBtn.Visible = false;
                clickedBtn.Enabled = false;
                this.Controls.Remove(clickedBtn);
            }
        }

        void btnMed_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            int clickNum = Convert.ToInt32(clickedBtn.Text);
            mediumTargets[clickNum].Shot(frmMain.userWeapon.getDamage());

            if (!mediumTargets[clickNum].isAlive())
            {
                clickedBtn.Visible = false;
                clickedBtn.Enabled = false;
                this.Controls.Remove(clickedBtn);
            }
        }

        void btnSml_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            int clickNum = Convert.ToInt32(clickedBtn.Text);
            smallTargets[clickNum].Shot(frmMain.userWeapon.getDamage());

            if (!smallTargets[clickNum].isAlive())
            {
                clickedBtn.Visible = false;
                clickedBtn.Enabled = false;
                this.Controls.Remove(clickedBtn);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(btnStart);
            makeTargets();
        }
    }
}
