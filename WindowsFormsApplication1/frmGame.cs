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
        Weapon userWeapon;                  // Weapon chosen by player
        Level userLevel;                    // Level chosen by player
        int currTime;                       // Time tracker for the level
        Timer moveTargets;                  // Timer to move targets
        Timer levelTimer;                   // Timer to keep track of and update time in currTime
        bool isPaused;                      // Whether the game is paused or running

        // List for controlling the wall bounce off for the targets
        List<bool> motionSmlFlipped = new List<bool>();
        List<bool> motionMedFlipped = new List<bool>();
        List<bool> motionBigFlipped = new List<bool>();

        // Lists for buttons and their respective targets.
        List<Target> smallTargets = new List<Target>();
        List<Target> mediumTargets = new List<Target>();
        List<Target> bigTargets = new List<Target>();
        List<Button> smallBtns = new List<Button>();
        List<Button> mediumBtns = new List<Button>();
        List<Button> bigBtns = new List<Button>();

        System.Media.SoundPlayer bkgndSound = new System.Media.SoundPlayer(@"..\..\Resources\135472__kvgarlic__summeropenfielddusk.wav");
        System.Media.SoundPlayer gunshotSound = new System.Media.SoundPlayer(@"..\..\Resources\37236__shades__gun-pistol-one-shot.wav");

        public frmGame(Weapon w, Level l)
        {
            InitializeComponent();
            userWeapon = w;
            userLevel = l;
        }

        // On form load
        private void frmGame_Load(object sender, EventArgs e)
        {
            // Get info from level class and assign to appropriate variables.
            this.Text = "Level " + userLevel.getLevel();
            int currScore = userLevel.getScore();
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
            for (int i = 0; i < userLevel.getSmallTargets(); i++)
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
                // Add motion control boolean for each button
                motionSmlFlipped.Add(false);
                // Add button to the form
                Controls.Add(smallBtns[i]);
            }

            for (int i = 0; i < userLevel.getMediumTargets(); i++)
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
                motionMedFlipped.Add(false);
                Controls.Add(mediumBtns[i]);
            }

            for (int i = 0; i < userLevel.getBigTargets(); i++)
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
                motionBigFlipped.Add(false);
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
            bigTargets[clickNum].Shot(userWeapon.getDamage());

            // If the target is dead, remove the button from the form.
            if (!bigTargets[clickNum].isAlive())
            {
                userLevel.updateScore(bigTargets[clickNum].getScore());
                lblScore.Text = "Score: " + userLevel.getScore();
                bigBtns.RemoveAt(clickNum);
                bigTargets.RemoveAt(clickNum);
                motionBigFlipped.RemoveAt(clickNum);
                Controls.Remove(clickedBtn);
            }
        }

        void btnMed_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            int clickNum = Convert.ToInt32(clickedBtn.Text);
            mediumTargets[clickNum].Shot(userWeapon.getDamage());

            if (!mediumTargets[clickNum].isAlive())
            {
                userLevel.updateScore(mediumTargets[clickNum].getScore());
                lblScore.Text = "Score: " + userLevel.getScore();
                mediumBtns.RemoveAt(clickNum);
                mediumTargets.RemoveAt(clickNum);
                motionMedFlipped.RemoveAt(clickNum);
                Controls.Remove(clickedBtn);
            }
        }

        void btnSml_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            int clickNum = Convert.ToInt32(clickedBtn.Text);
            smallTargets[clickNum].Shot(userWeapon.getDamage());

            if (!smallTargets[clickNum].isAlive())
            {
                userLevel.updateScore(smallTargets[clickNum].getScore());
                lblScore.Text = "Score: " + userLevel.getScore();
                smallBtns.RemoveAt(clickNum);
                smallTargets.RemoveAt(clickNum);
                motionSmlFlipped.RemoveAt(clickNum);
                Controls.Remove(clickedBtn);
            }
        }

        // Pause the game
        private void pauseGame()
        {
            if (isPaused == false)
            {
                isPaused = true;
                btnPause.Text = "Play";
                levelTimer.Stop();
                moveTargets.Stop();

                this.Cursor = System.Windows.Forms.Cursors.Default;

                for (int i = 0; i < smallBtns.Count; i++)
                {
                    smallBtns[i].Visible = false;
                    smallBtns[i].Enabled = false;
                }

                for (int i = 0; i < mediumBtns.Count; i++)
                {
                    mediumBtns[i].Visible = false;
                    mediumBtns[i].Enabled = false;
                }

                for (int i = 0; i < bigBtns.Count; i++)
                {
                    bigBtns[i].Visible = false;
                    bigBtns[i].Enabled = false;
                }
            }
            else if (isPaused == true)
            {
                isPaused = false;
                btnPause.Text = "Pause";
                levelTimer.Start();
                moveTargets.Start();

                this.Cursor = System.Windows.Forms.Cursors.Cross;

                for (int i = 0; i < smallBtns.Count; i++)
                {
                    smallBtns[i].Visible = true;
                    smallBtns[i].Enabled = true;
                }

                for (int i = 0; i < mediumBtns.Count; i++)
                {
                    mediumBtns[i].Visible = true;
                    mediumBtns[i].Enabled = true;
                }

                for (int i = 0; i < bigBtns.Count; i++)
                {
                    bigBtns[i].Visible = true;
                    bigBtns[i].Enabled = true;
                }
            }
        }

        // Start the game
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Remove this button from the form and generate the targets.
            Controls.Remove(btnStart);
            makeTargets();

            bkgndSound.Play();

            // Change cursor to a target
            this.Cursor = System.Windows.Forms.Cursors.Cross;

            // Initialize timer and set all its necessary attributes
            moveTargets = new Timer();
            moveTargets.Interval = 10;
            moveTargets.Enabled = true;
            moveTargets.Tick += new EventHandler(moveTargets_Tick);

            levelTimer = new Timer();
            levelTimer.Interval = 1000;
            levelTimer.Enabled = true;
            levelTimer.Tick += new EventHandler(levelTimer_Tick);

            isPaused = false;
        }

        // Timer event method to keep track of level time
        void levelTimer_Tick(object sender, EventArgs e)
        {
            currTime--;
            lblTime.Text = "Time: " + currTime;
        }

        // Timer event method to move objects
        void moveTargets_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < smallBtns.Count; i++)
            {
                if (motionSmlFlipped[i] == false)
                {
                    smallBtns[i].Left += 1;
                    if (smallBtns[i].Right >= 694)
                    {
                        motionSmlFlipped[i] = true;
                    }
                }
                else if (motionSmlFlipped[i] == true)
                {
                    smallBtns[i].Left -= 1;
                    if (smallBtns[i].Left <= 0)
                    {
                        motionSmlFlipped[i] = false;
                    }
                }
            }

            for (int i = 0; i < mediumBtns.Count; i++)
            {
                if (motionMedFlipped[i] == false)
                {
                    mediumBtns[i].Left += 1;
                    if (mediumBtns[i].Right >= 694)
                    {
                        motionMedFlipped[i] = true;
                    }
                }
                else if (motionMedFlipped[i] == true)
                {
                    mediumBtns[i].Left -= 1;
                    if (mediumBtns[i].Left <= 0)
                    {
                        motionMedFlipped[i] = false;
                    }
                }
            }

            for (int i = 0; i < bigBtns.Count; i++)
            {
                if (motionBigFlipped[i] == false)
                {
                    bigBtns[i].Left += 1;
                    if (bigBtns[i].Right >= 694)
                    {
                        motionBigFlipped[i] = true;
                    }
                }
                else if (motionBigFlipped[i] == true)
                {
                    bigBtns[i].Left -= 1;
                    if (bigBtns[i].Left <= 0)
                    {
                        motionBigFlipped[i] = false;
                    }
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            pauseGame();
        }
    }
}
