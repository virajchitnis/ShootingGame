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
        string userName;                    // Player's username
        int currTime;                       // Time tracker for the level
        Timer moveTargets;                  // Timer to move targets
        Timer levelTimer;                   // Timer to keep track of and update time in currTime
        bool isPaused;                      // Whether the game is paused or running
        Random rndbuttonLoc;

        /* These lists may need to be converted into arrays because in levels where there are
         * multiple targets of the same kind, everytime a target is destroyed, the index of most
         * other targets changes. This causes the program to throw an out of bounds error the next
         * time a target is clicked.
         */

        // List for controlling the wall bounce off for the targets
        List<bool> motionSmlFlipped;
        List<bool> motionMedFlipped;
        List<bool> motionBigFlipped;

        // Lists for buttons and their respective targets.
        List<Target> smallTargets;
        List<Target> mediumTargets;
        List<Target> bigTargets;
        List<Button> smallBtns;
        List<Button> mediumBtns;
        List<Button> bigBtns;

        System.Media.SoundPlayer bkgndSound = new System.Media.SoundPlayer(@"..\..\Resources\135472__kvgarlic__summeropenfielddusk.wav");
        System.Media.SoundPlayer gunshotSound = new System.Media.SoundPlayer(@"..\..\Resources\37236__shades__gun-pistol-one-shot.wav");

        public frmGame(string name, Weapon w, Level l)
        {
            InitializeComponent();
            userName = name;
            userWeapon = w;
            userLevel = l;
            rndbuttonLoc = new Random();
        }

        // On form load
        private void frmGame_Load(object sender, EventArgs e)
        {
            // Get info from level class and assign to appropriate variables.
            this.Text = "Level " + userLevel.getLevel();
            this.BackgroundImage = new Bitmap(Properties.Resources.prairie_background, new Size(this.Width, this.Height));
            int currScore = userLevel.getScore();
            currTime = 30;
            lblScore.Text = "Score: " + currScore;
            lblTime.Text = "Time: " + currTime;
            lblName.Text = "Player: " + userName;
            lblAmmo.Text = "Ammo: " + userWeapon.getInitialAmmo();
        }

        // On form close
        private void frmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
            // Show the main form.
            //frmSplash.mainForm.Show();
        }

        // Method to dynamically generate buttons (targets)
        private void makeTargets()
        {
            motionSmlFlipped = new List<bool>();
            motionMedFlipped = new List<bool>();
            motionBigFlipped = new List<bool>();
            smallTargets = new List<Target>();
            mediumTargets = new List<Target>();
            bigTargets = new List<Target>();
            smallBtns = new List<Button>();
            mediumBtns = new List<Button>();
            bigBtns = new List<Button>();

            // Loop to repeat process for number of targets of each size
            for (int i = 0; i < userLevel.getSmallTargets(); i++)
            {
                int locY = rndbuttonLoc.Next(40, 420);
                int locX = rndbuttonLoc.Next(-30, 694);
                // Make new button and set its attributes
                Button btnCurr = new Button();
                btnCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnCurr.Location = new System.Drawing.Point(locX, locY);
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
                int locY = rndbuttonLoc.Next(40, 400);
                int locX = rndbuttonLoc.Next(-50, 694);
                Button btnCurr = new Button();
                btnCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnCurr.Location = new System.Drawing.Point(locX, locY);
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
                int locY = rndbuttonLoc.Next(40, 380);
                int locX = rndbuttonLoc.Next(-70, 694);
                Button btnCurr = new Button();
                btnCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnCurr.Location = new System.Drawing.Point(locX, locY);
                btnCurr.Size = new System.Drawing.Size(70, 70);
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
            if (!userWeapon.inReload())
            {
                userWeapon.TakenShot();
                lblAmmo.Text = "Ammo: " + userWeapon.getAmmo();

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

                    for (int i = 0; i < bigBtns.Count; i++)
                    {
                        bigBtns[i].Text = i.ToString();
                    }

                    if ((smallBtns.Count == 0) && (mediumBtns.Count == 0) && (bigBtns.Count == 0))
                    {
                        endGame(true);
                    }
                }

                if (userWeapon.needReload())
                {
                    userWeapon.Reload();
                    lblAmmo.Text = "Reloading weapon...";
                    Timer tmrWeaponReload = new Timer();
                    tmrWeaponReload.Interval = userWeapon.getTimeReload() * 1000;
                    tmrWeaponReload.Enabled = true;
                    tmrWeaponReload.Tick += new EventHandler(tmrWeaponReload_Tick);
                }
                playGunShot();
            }
        }

        void btnMed_Click(object sender, EventArgs e)
        {
            if (!userWeapon.inReload())
            {
                userWeapon.TakenShot();
                lblAmmo.Text = "Ammo: " + userWeapon.getAmmo();

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

                    for (int i = 0; i < mediumBtns.Count; i++)
                    {
                        mediumBtns[i].Text = i.ToString();
                    }

                    if ((smallBtns.Count == 0) && (mediumBtns.Count == 0) && (bigBtns.Count == 0))
                    {
                        endGame(true);
                    }
                }

                if (userWeapon.needReload())
                {
                    userWeapon.Reload();
                    lblAmmo.Text = "Reloading weapon...";
                    Timer tmrWeaponReload = new Timer();
                    tmrWeaponReload.Interval = userWeapon.getTimeReload() * 1000;
                    tmrWeaponReload.Enabled = true;
                    tmrWeaponReload.Tick += new EventHandler(tmrWeaponReload_Tick);
                }
                playGunShot();
            }
        }

        void btnSml_Click(object sender, EventArgs e)
        {
            if (!userWeapon.inReload())
            {
                userWeapon.TakenShot();
                lblAmmo.Text = "Ammo: " + userWeapon.getAmmo();

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

                    for (int i = 0; i < smallBtns.Count; i++)
                    {
                        smallBtns[i].Text = i.ToString();
                    }

                    if ((smallBtns.Count == 0) && (mediumBtns.Count == 0) && (bigBtns.Count == 0))
                    {
                        endGame(true);
                    }
                }

                if (userWeapon.needReload())
                {
                    userWeapon.Reload();
                    lblAmmo.Text = "Reloading weapon...";
                    Timer tmrWeaponReload = new Timer();
                    tmrWeaponReload.Interval = userWeapon.getTimeReload() * 1000;
                    tmrWeaponReload.Enabled = true;
                    tmrWeaponReload.Tick += new EventHandler(tmrWeaponReload_Tick);
                }
                playGunShot();
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

                Label lblGamePaused = new Label();
                lblGamePaused.AutoSize = true;
                lblGamePaused.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblGamePaused.Location = new System.Drawing.Point(300, 150);
                lblGamePaused.BackColor = System.Drawing.Color.Transparent;
                lblGamePaused.Name = "lblGameOver";
                lblGamePaused.Text = "Game Paused";
                Controls.Add(lblGamePaused);

                Button btnPlayAgain = new Button();
                btnPlayAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnPlayAgain.Location = new System.Drawing.Point(288, 200);
                btnPlayAgain.AutoSize = true;
                btnPlayAgain.UseVisualStyleBackColor = true;
                btnPlayAgain.Text = "Restart Level";
                btnPlayAgain.Name = "btnPlayAgain";
                btnPlayAgain.Click += new EventHandler(btnPlayAgain_Click);
                Controls.Add(btnPlayAgain);

                Button btnToMenu = new Button();
                btnToMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnToMenu.Location = new System.Drawing.Point(277, 235);
                btnToMenu.AutoSize = true;
                btnToMenu.UseVisualStyleBackColor = true;
                btnToMenu.Text = "Go to Main Menu";
                btnToMenu.Name = "btnToMenu";
                btnToMenu.Click += new EventHandler(btnToMenu_Click);
                Controls.Add(btnToMenu);

                Button btnExit = new Button();
                btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnExit.Location = new System.Drawing.Point(309, 270);
                btnExit.AutoSize = true;
                btnExit.UseVisualStyleBackColor = true;
                btnExit.Text = "Exit";
                btnExit.Name = "btnExit";
                btnExit.Click += new EventHandler(btnExit_Click);
                Controls.Add(btnExit);
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

                Controls.RemoveAt(Controls.Count - 1);
                Controls.RemoveAt(Controls.Count - 1);
                Controls.RemoveAt(Controls.Count - 1);
                Controls.RemoveAt(Controls.Count - 1);
            }
        }

        void btnToMenu_Click(object sender, EventArgs e)
        {
            frmSplash.mainForm.Show();
            this.Close();
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // End the game
        private void endGame(bool win)
        {
            levelTimer.Stop();
            moveTargets.Stop();

            bkgndSound.Stop();
            btnPause.Enabled = false;
            btnPause.Visible = false;

            lblAmmo.Visible = false;

            this.Cursor = System.Windows.Forms.Cursors.Default;

            for (int i = 0; i < smallBtns.Count; i++)
            {
                Controls.Remove(smallBtns[i]);
                //smallBtns[i].Visible = false;
                //smallBtns[i].Enabled = false;
            }

            for (int i = 0; i < mediumBtns.Count; i++)
            {
                Controls.Remove(mediumBtns[i]);
                //mediumBtns[i].Visible = false;
                //mediumBtns[i].Enabled = false;
            }

            for (int i = 0; i < bigBtns.Count; i++)
            {
                Controls.Remove(bigBtns[i]);
                //bigBtns[i].Visible = false;
                //bigBtns[i].Enabled = false;
            }

            Label lblYouScored = new Label();
            lblYouScored.AutoSize = true;
            lblYouScored.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblYouScored.Location = new System.Drawing.Point(290, 175);
            lblYouScored.BackColor = System.Drawing.Color.Transparent;
            lblYouScored.Name = "lblYouScored";
            lblYouScored.Text = "You Scored: " + userLevel.getScore();
            Controls.Add(lblYouScored);

            if (win)
            {
                Label lblGameOver = new Label();
                lblGameOver.AutoSize = false;
                lblGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblGameOver.Location = new System.Drawing.Point(173, 150);
                lblGameOver.Size = new System.Drawing.Size(347, 20);
                lblGameOver.BackColor = System.Drawing.Color.Transparent;
                lblGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lblGameOver.Name = "lblGameOver";
                lblGameOver.Text = "Congratulations, you won!";
                Controls.Add(lblGameOver);

                Button btnPlayNext = new Button();
                btnPlayNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnPlayNext.Location = new System.Drawing.Point(300, 200);
                btnPlayNext.AutoSize = true;
                btnPlayNext.UseVisualStyleBackColor = true;
                btnPlayNext.Text = "Next Level";
                btnPlayNext.Name = "btnPlayNext";
                btnPlayNext.Click += new EventHandler(btnPlayNext_Click);
                Controls.Add(btnPlayNext);
            }
            else
            {
                Label lblGameOver = new Label();
                lblGameOver.AutoSize = false;
                lblGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblGameOver.Location = new System.Drawing.Point(173, 150);
                lblGameOver.Size = new System.Drawing.Size(347, 20);
                lblGameOver.BackColor = System.Drawing.Color.Transparent;
                lblGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lblGameOver.Name = "lblGameOver";
                lblGameOver.Text = "You lost, try again!";
                Controls.Add(lblGameOver);

                Button btnPlayAgain = new Button();
                btnPlayAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnPlayAgain.Location = new System.Drawing.Point(300, 200);
                btnPlayAgain.AutoSize = true;
                btnPlayAgain.UseVisualStyleBackColor = true;
                btnPlayAgain.Text = "Play Again";
                btnPlayAgain.Name = "btnPlayAgain";
                btnPlayAgain.Click += new EventHandler(btnPlayAgain_Click);
                Controls.Add(btnPlayAgain);
            }

            Button btnToMenu = new Button();
            btnToMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnToMenu.Location = new System.Drawing.Point(277, 235);
            btnToMenu.AutoSize = true;
            btnToMenu.UseVisualStyleBackColor = true;
            btnToMenu.Text = "Go to Main Menu";
            btnToMenu.Name = "btnToMenu";
            btnToMenu.Click += new EventHandler(btnToMenu_Click);
            Controls.Add(btnToMenu);

            Button btnExit = new Button();
            btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnExit.Location = new System.Drawing.Point(309, 270);
            btnExit.AutoSize = true;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Text = "Exit";
            btnExit.Name = "btnExit";
            btnExit.Click += new EventHandler(btnExit_Click);
            Controls.Add(btnExit);
        }

        void btnPlayAgain_Click(object sender, EventArgs e)
        {
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);

            btnStart.Enabled = true;
            btnStart.Visible = true;

            userWeapon.reset();
            lblAmmo.Text = "Ammo: " + userWeapon.getInitialAmmo();
            lblAmmo.Visible = true;

            int currLevel = userLevel.getLevel();
            int currSmlTarg = userLevel.getSmallTargets();
            int currMedTarg = userLevel.getMediumTargets();
            int currBigTarg = userLevel.getBigTargets();
            userLevel = new Level(currLevel, currSmlTarg, currMedTarg, currBigTarg);

            // Get info from level class and assign to appropriate variables.
            this.Text = "Level " + userLevel.getLevel();
            int currScore = userLevel.getScore();
            currTime = 30;
            lblScore.Text = "Score: " + currScore;
            lblTime.Text = "Time: " + currTime;
        }

        void btnPlayNext_Click(object sender, EventArgs e)
        {
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);

            btnStart.Enabled = true;
            btnStart.Visible = true;

            userWeapon.reset();
            lblAmmo.Text = "Ammo: " + userWeapon.getInitialAmmo();
            lblAmmo.Visible = true;

            int currLevel = userLevel.getLevel();
            userLevel = new Level(currLevel+1, currLevel * 2, currLevel * 2, currLevel * 2);

            // Get info from level class and assign to appropriate variables.
            this.Text = "Level " + userLevel.getLevel();
            int currScore = userLevel.getScore();
            currTime = 30;
            lblScore.Text = "Score: " + currScore;
            lblTime.Text = "Time: " + currTime;
        }

        // Start the game
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Remove this button from the form and generate the targets.
            //Controls.Remove(btnStart);
            btnStart.Enabled = false;
            btnStart.Visible = false;
            makeTargets();

            btnPause.Enabled = true;
            btnPause.Visible = true;

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
            if (currTime > 1)
            {
                currTime--;
                lblTime.Text = "Time: " + currTime;
            }
            else
            {
                lblTime.Text = "Time: " + 0;
                endGame(false);
            }
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

        private void frmGame_Click(object sender, EventArgs e)
        {
            if (!userWeapon.inReload())
            {
                userWeapon.TakenShot();
                lblAmmo.Text = "Ammo: " + userWeapon.getAmmo();
                if (userWeapon.needReload())
                {
                    userWeapon.Reload();
                    lblAmmo.Text = "Reloading weapon...";
                    Timer tmrWeaponReload = new Timer();
                    tmrWeaponReload.Interval = userWeapon.getTimeReload() * 1000;
                    tmrWeaponReload.Enabled = true;
                    tmrWeaponReload.Tick += new EventHandler(tmrWeaponReload_Tick);
                }
                playGunShot();
            }
        }

        void tmrWeaponReload_Tick(object sender, EventArgs e)
        {
            lblAmmo.Text = "Ammo: " + userWeapon.getInitialAmmo();
            Timer tmrWeaponReload = (Timer)sender;
            tmrWeaponReload.Stop();
        }

        void tmrGunShot_Tick(object sender, EventArgs e)
        {
            bkgndSound.Play();
            Timer tmrGunShot = (Timer)sender;
            tmrGunShot.Stop();
        }

        private void playGunShot()
        {
            Timer tmrGunShot = new Timer();
            tmrGunShot.Interval = 2000;
            tmrGunShot.Enabled = true;
            tmrGunShot.Tick += new EventHandler(tmrGunShot_Tick);
            bkgndSound.Stop();
            gunshotSound.Play();
        }
    }
}
