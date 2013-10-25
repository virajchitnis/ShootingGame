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
        Timer moveTargets;

        // Lists for buttons and their respective targets.
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

        // On form load
        private void frmGame_Load(object sender, EventArgs e)
        {
            // Get info from level class and assign to appropriate variables.
            this.Text = "Level " + frmMain.userLevel.getLevel();
            int currScore = frmMain.userLevel.getScore();
            currTime = 30;
            lblScore.Text = "Score: " + currScore;
            lblTime.Text = "Time: " + currTime;
        }

        // On form close
        private void frmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Show the main form.
            frmSplash.mainForm.Show();
        }

        // Method to dynamically generate buttons (targets)
        private void makeTargets()
        {
            // Loop to repeat process for number of targets of each size
            for (int i = 0; i < frmMain.userLevel.getSmallTargets(); i++)
            {
                // Make new button and set its attributes
                Button btnCurr = new Button();
                btnCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnCurr.Location = new System.Drawing.Point(100, 100);
                btnCurr.Size = new System.Drawing.Size(30, 30);
                btnCurr.UseVisualStyleBackColor = true;
                btnCurr.Text = i.ToString();
                btnCurr.Name = "btnSmlTar" + i;
                btnCurr.Click += new EventHandler(btnSml_Click);
                // Add button to the list
                smallBtns.Add(btnCurr);
                // Add target to the list
                smallTargets.Add(new Target("bird"));
                // Add button to the form
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

        // Button click event
        void btnBig_Click(object sender, EventArgs e)
        {
            // Detect the clicked button
            Button clickedBtn = (Button)sender;
            int clickNum = Convert.ToInt32(clickedBtn.Text);
            // Shoot the appropriate target
            bigTargets[clickNum].Shot(frmMain.userWeapon.getDamage());

            // If the target is dead, remove the button from the form.
            if (!bigTargets[clickNum].isAlive())
            {
                bigBtns.RemoveAt(clickNum);
                bigTargets.RemoveAt(clickNum);
                Controls.Remove(clickedBtn);
            }
        }

        void btnMed_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            int clickNum = Convert.ToInt32(clickedBtn.Text);
            mediumTargets[clickNum].Shot(frmMain.userWeapon.getDamage());

            if (!mediumTargets[clickNum].isAlive())
            {
                mediumBtns.RemoveAt(clickNum);
                mediumTargets.RemoveAt(clickNum);
                Controls.Remove(clickedBtn);
            }
        }

        void btnSml_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            int clickNum = Convert.ToInt32(clickedBtn.Text);
            smallTargets[clickNum].Shot(frmMain.userWeapon.getDamage());

            if (!smallTargets[clickNum].isAlive())
            {
                smallBtns.RemoveAt(clickNum);
                smallTargets.RemoveAt(clickNum);
                Controls.Remove(clickedBtn);
            }
        }

        // Start the game
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Remove this button from the form and generate the targets.
            Controls.Remove(btnStart);
            makeTargets();

            // Initialize timer and set all its necessary attributes
            moveTargets = new Timer();
            moveTargets.Interval = 10;
            moveTargets.Enabled = true;
            moveTargets.Tick += new EventHandler(moveTargets_Tick);
        }

        // Timer event method
        void moveTargets_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < smallBtns.Count; i++)
            {
                smallBtns[i].Left += 1;
            }

            for (int i = 0; i < mediumBtns.Count; i++)
            {
                mediumBtns[i].Left += 1;
            }

            for (int i = 0; i < smallBtns.Count; i++)
            {
                bigBtns[i].Left += 1;
            }
        }
    }
}
