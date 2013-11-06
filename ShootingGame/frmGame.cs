﻿using System;
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
    public partial class frmGame : Form
    {
        SoundPlayer menuMusic;              // Music played throughout the menu
        Weapon userWeapon;                  // Weapon chosen by player
        Level userLevel;                    // Level chosen by player
        LevelBonusGH userBonusLevel;        // Bonus level
        Player user;                        // Player's username
        int currTime;                       // Time tracker for the level
        Timer tmrMoveTargets;                  // Timer to move targets
        Timer tmrLevelTime;                   // Timer to keep track of and update time in currTime
        Timer tmrWalker;                    // Timer to make animals walk/run
        bool isPaused;                      // Whether the game is paused or running
        bool isEnded;                       // Whether the game is running or over
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

        // Animal walking variables
        int bearWalkCounter;
        int deerWalkCounter;
        int duckWalkCounter;
        Bitmap[] bearPicsRight;
        Bitmap[] bearPicsLeft;
        Bitmap[] deerPicsRight;
        Bitmap[] deerPicsLeft;
        Bitmap[] duckPicsRight;
        Bitmap[] duckPicsLeft;

        // Arrays and variables for the bonus level
        PictureBox[] bonusBurrows;
        Timer tmrBonusGrndHog;
        Timer tmrBonusLevel;
        bool isBonusLevel;
        Bitmap[] groundHogPics;
        int oldNum;                         // To keep track of the last chosen box

        SoundPlayer bkgndSound = new SoundPlayer(Properties.Resources._135472__kvgarlic__summeropenfielddusk);
        SoundPlayer gunshotSound = new SoundPlayer(Properties.Resources._37236__shades__gun_pistol_one_shot);
        SoundPlayer gunReloadSound = new SoundPlayer(Properties.Resources.shotgunReload);

        public frmGame(SoundPlayer music, Player name, Weapon w, Level l)
        {
            InitializeComponent();
            user = name;
            userWeapon = w;
            userLevel = l;
            rndbuttonLoc = new Random();
            menuMusic = music;

            bearPicsRight = new Bitmap[4];
            bearPicsRight[0] = new Bitmap(Properties.Resources.Bear_Walking_1, new Size(70, 70));
            bearPicsRight[1] = new Bitmap(Properties.Resources.Bear_Walking_2, new Size(70, 70));
            bearPicsRight[2] = new Bitmap(Properties.Resources.Bear_Walking_3, new Size(70, 70));
            bearPicsRight[3] = new Bitmap(Properties.Resources.Bear_Walking_4, new Size(70, 70));

            bearPicsLeft = new Bitmap[4];
            bearPicsLeft[0] = new Bitmap(Properties.Resources.Bear_Walking_1_LEFT, new Size(70, 70));
            bearPicsLeft[1] = new Bitmap(Properties.Resources.Bear_Walking_2_LEFT, new Size(70, 70));
            bearPicsLeft[2] = new Bitmap(Properties.Resources.Bear_Walking_3_LEFT, new Size(70, 70));
            bearPicsLeft[3] = new Bitmap(Properties.Resources.Bear_Walking_4_LEFT, new Size(70, 70));

            duckPicsRight = new Bitmap[3];
            duckPicsRight[0] = new Bitmap(Properties.Resources.Duck_Flying_RIGHT, new Size(30, 30));
            duckPicsRight[1] = new Bitmap(Properties.Resources.Duck_Flying_2_RIGHT, new Size(30, 30));
            duckPicsRight[2] = new Bitmap(Properties.Resources.Duck_Flying_3_RIGHT, new Size(30, 30));

            duckPicsLeft = new Bitmap[3];
            duckPicsLeft[0] = new Bitmap(Properties.Resources.Duck_Flying_1, new Size(30, 30));
            duckPicsLeft[1] = new Bitmap(Properties.Resources.Duck_Flying_2, new Size(30, 30));
            duckPicsLeft[2] = new Bitmap(Properties.Resources.Duck_Flying_3, new Size(30, 30));

            deerPicsRight = new Bitmap[3];
            deerPicsRight[0] = new Bitmap(Properties.Resources.deer_walk_Right, new Size(50, 50));
            deerPicsRight[1] = new Bitmap(Properties.Resources.deer_walk_2_right, new Size(50, 50));
            deerPicsRight[2] = new Bitmap(Properties.Resources.deer_walk_3_right, new Size(50, 50));

            deerPicsLeft = new Bitmap[3];
            deerPicsLeft[0] = new Bitmap(Properties.Resources.deer_walk_LEFT, new Size(50, 50));
            deerPicsLeft[1] = new Bitmap(Properties.Resources.deer_walk_2_left, new Size(50, 50));
            deerPicsLeft[2] = new Bitmap(Properties.Resources.deer_walk_3_left, new Size(50, 50));

            groundHogPics = new Bitmap[2];
            groundHogPics[0] = new Bitmap(Properties.Resources.GHOG2_GH, new Size(86, 92));
            groundHogPics[1] = new Bitmap(Properties.Resources.GHOG2, new Size(86, 92));
        }

        // On form load
        private void frmGame_Load(object sender, EventArgs e)
        {
            menuMusic.Stop();
            // Get info from level class and assign to appropriate variables.
            this.Text = "Level " + userLevel.getLevel();
            //this.BackgroundImage = new Bitmap(Properties.Resources.background, new Size(this.Width, this.Height));
            int currScore = userLevel.getScore();
            currTime = 30;
            lblScore.Text = "Score: " + currScore;
            lblTime.Text = "Time: " + currTime;
            lblName.Text = "Player: " + user.getName();
            lblAmmo.Text = "Ammo: " + userWeapon.getInitialAmmo();
        }

        // On form close
        private void frmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            bkgndSound.Stop();
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

            bearWalkCounter = 0;
            duckWalkCounter = 0;
            deerWalkCounter = 0;

            // Loop to repeat process for number of targets of each size
            for (int i = 0; i < userLevel.getSmallTargets(); i++)
            {
                int locY = rndbuttonLoc.Next(40, 420);
                int locX = rndbuttonLoc.Next(-30, 694);
                // Make new button and set its attributes
                Button btnCurr = new Button();
                btnCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 0.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnCurr.Location = new System.Drawing.Point(locX, locY);
                btnCurr.Size = new System.Drawing.Size(30, 30);
                btnCurr.UseVisualStyleBackColor = true;
                btnCurr.BackgroundImage = duckPicsRight[0];
                btnCurr.BackColor = System.Drawing.Color.Transparent;
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
                btnCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 0.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnCurr.Location = new System.Drawing.Point(locX, locY);
                btnCurr.Size = new System.Drawing.Size(50, 50);
                btnCurr.UseVisualStyleBackColor = true;
                btnCurr.BackgroundImage = deerPicsRight[0];
                btnCurr.BackColor = System.Drawing.Color.Transparent;
                btnCurr.Text = i.ToString();
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
                btnCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 0.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnCurr.Location = new System.Drawing.Point(locX, locY);
                btnCurr.Size = new System.Drawing.Size(70, 70);
                btnCurr.UseVisualStyleBackColor = true;
                btnCurr.BackgroundImage = bearPicsRight[0];
                btnCurr.BackColor = System.Drawing.Color.Transparent;
                btnCurr.Text = i.ToString();
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
                int clickNum = bigBtns.IndexOf(clickedBtn);
                // Shoot the appropriate target
                bigTargets[clickNum].Shot(userWeapon.getDamage());

                // If the target is dead, remove the button from the form.
                if (!bigTargets[clickNum].isAlive())
                {
                    userLevel.updateScore(bigTargets[clickNum].getScore());
                    lblScore.Text = "Score: " + userLevel.getScore();
                    //bigBtns.RemoveAt(clickNum);
                    bigBtns.Remove(clickedBtn);
                    bigTargets.RemoveAt(clickNum);
                    motionBigFlipped.RemoveAt(clickNum);
                    Controls.Remove(clickedBtn);

                    if ((smallBtns.Count == 0) && (mediumBtns.Count == 0) && (bigBtns.Count == 0))
                    {
                        endGame(true);
                    }
                }

                if ((userWeapon.needReload()) && (!isEnded))
                {
                    reloadWeapon();
                }
                else
                {
                    playGunShot();
                }
            }
        }

        void btnMed_Click(object sender, EventArgs e)
        {
            if (!userWeapon.inReload())
            {
                userWeapon.TakenShot();
                lblAmmo.Text = "Ammo: " + userWeapon.getAmmo();

                Button clickedBtn = (Button)sender;
                int clickNum = mediumBtns.IndexOf(clickedBtn);
                mediumTargets[clickNum].Shot(userWeapon.getDamage());

                if (!mediumTargets[clickNum].isAlive())
                {
                    userLevel.updateScore(mediumTargets[clickNum].getScore());
                    lblScore.Text = "Score: " + userLevel.getScore();
                    mediumBtns.Remove(clickedBtn);
                    mediumTargets.RemoveAt(clickNum);
                    motionMedFlipped.RemoveAt(clickNum);
                    Controls.Remove(clickedBtn);

                    if ((smallBtns.Count == 0) && (mediumBtns.Count == 0) && (bigBtns.Count == 0))
                    {
                        endGame(true);
                    }
                }

                if ((userWeapon.needReload()) && (!isEnded))
                {
                    reloadWeapon();
                }
                else
                {
                    playGunShot();
                }
            }
        }

        void btnSml_Click(object sender, EventArgs e)
        {
            if (!userWeapon.inReload())
            {
                userWeapon.TakenShot();
                lblAmmo.Text = "Ammo: " + userWeapon.getAmmo();

                Button clickedBtn = (Button)sender;
                int clickNum = smallBtns.IndexOf(clickedBtn);
                smallTargets[clickNum].Shot(userWeapon.getDamage());

                if (!smallTargets[clickNum].isAlive())
                {
                    userLevel.updateScore(smallTargets[clickNum].getScore());
                    lblScore.Text = "Score: " + userLevel.getScore();
                    smallBtns.Remove(clickedBtn);
                    smallTargets.RemoveAt(clickNum);
                    motionSmlFlipped.RemoveAt(clickNum);
                    Controls.Remove(clickedBtn);

                    if ((smallBtns.Count == 0) && (mediumBtns.Count == 0) && (bigBtns.Count == 0))
                    {
                        endGame(true);
                    }
                }

                if ((userWeapon.needReload()) && (!isEnded))
                {
                    reloadWeapon();
                }
                else
                {
                    playGunShot();
                }
            }
        }

        // Pause the game
        private void pauseGame()
        {
            if (!isPaused)
            {
                isPaused = true;
                btnPause.Text = "Play";
                tmrLevelTime.Stop();
                tmrMoveTargets.Stop();

                lblAmmo.Visible = false;
                lblReload.Visible = false;

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
            else
            {
                isPaused = false;
                btnPause.Text = "Pause";
                tmrLevelTime.Start();
                tmrMoveTargets.Start();

                lblAmmo.Visible = true;
                lblReload.Visible = true;

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
            DialogResult closeOrNot = MessageBox.Show("Are you sure you want to go to the main menu?", "Go to main menu", MessageBoxButtons.YesNo);
            if (closeOrNot == DialogResult.Yes)
            {
                frmMain mainForm = new frmMain(menuMusic);
                mainForm.Show();
                this.Close();
            }
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult exitOrNot = MessageBox.Show("Are you sure you want to exit the game?", "Exit Game", MessageBoxButtons.YesNo);
            if (exitOrNot == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // End the game
        private void endGame(bool win)
        {
            if (isBonusLevel)
            {
                isEnded = true;

                tmrBonusLevel.Stop();
                tmrBonusGrndHog.Stop();

                for (int i = 0; i < bonusBurrows.Length; i++)
                {
                    Controls.Remove(bonusBurrows[i]);
                }

                if (win)
                {
                    userBonusLevel.updateScore(50);
                    user.updateTotalScore(userBonusLevel.getScore());

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

                    saveAllFiles();
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
                    lblGameOver.Text = "You lost, better luck next time!";
                    Controls.Add(lblGameOver);
                }

                Button btnPlayNext = new Button();
                btnPlayNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnPlayNext.Location = new System.Drawing.Point(300, 200);
                btnPlayNext.AutoSize = true;
                btnPlayNext.UseVisualStyleBackColor = true;
                btnPlayNext.Text = "Next Level";
                btnPlayNext.Name = "btnPlayNext";
                btnPlayNext.Click += new EventHandler(btnPlayNext_Click);
                Controls.Add(btnPlayNext);

                Button btnToMenu = new Button();
                btnToMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnToMenu.Location = new System.Drawing.Point(277, 270);
                btnToMenu.AutoSize = true;
                btnToMenu.UseVisualStyleBackColor = true;
                btnToMenu.Text = "Go to Main Menu";
                btnToMenu.Name = "btnToMenu";
                btnToMenu.Click += new EventHandler(btnToMenu_Click);
                Controls.Add(btnToMenu);

                Button btnExit = new Button();
                btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnExit.Location = new System.Drawing.Point(309, 305);
                btnExit.AutoSize = true;
                btnExit.UseVisualStyleBackColor = true;
                btnExit.Text = "Exit";
                btnExit.Name = "btnExit";
                btnExit.Click += new EventHandler(btnExit_Click);
                Controls.Add(btnExit);
            }
            else
            {
                isEnded = true;
                tmrLevelTime.Stop();
                tmrMoveTargets.Stop();
                tmrWalker.Stop();

                bkgndSound.Stop();
                btnPause.Enabled = false;
                btnPause.Visible = false;

                lblAmmo.Visible = false;
                lblReload.Visible = false;

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

                    user.updateTotalScore(userLevel.getScore());

                    saveAllFiles();

                    if (((userLevel.getLevel() + 1) % 3) == 0)
                    {
                        Label lblBonusGame = new Label();
                        lblBonusGame.AutoSize = false;
                        lblBonusGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        lblBonusGame.Location = new System.Drawing.Point(173, 400);
                        lblBonusGame.Size = new System.Drawing.Size(347, 20);
                        lblBonusGame.BackColor = System.Drawing.Color.Transparent;
                        lblBonusGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        lblBonusGame.Name = "lblBonusGame";
                        lblBonusGame.Text = "Bonus Level Unlocked!";
                        Controls.Add(lblBonusGame);

                        Button btnPlayBonus = new Button();
                        btnPlayBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btnPlayBonus.Location = new System.Drawing.Point(275, 425);
                        btnPlayBonus.AutoSize = true;
                        btnPlayBonus.UseVisualStyleBackColor = true;
                        btnPlayBonus.Text = "Play Bonus Level";
                        btnPlayBonus.Name = "btnPlayBonus";
                        btnPlayBonus.Click += new EventHandler(btnPlayBonus_Click);
                        Controls.Add(btnPlayBonus);
                    }
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

                    string gameProgress = user.getName() + "," + userLevel.getLevel() + "," + user.getTotalScore();
                    UpdateFile saveGame = new UpdateFile("game_save.txt");
                    saveGame.putNextRecord(gameProgress);
                    saveGame.closeFile();
                }

                Button btnChgWeapon = new Button();
                btnChgWeapon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnChgWeapon.Location = new System.Drawing.Point(277, 235);
                btnChgWeapon.AutoSize = true;
                btnChgWeapon.UseVisualStyleBackColor = true;
                btnChgWeapon.Text = "Change Weapon";
                btnChgWeapon.Name = "btnChgWeapon";
                btnChgWeapon.Click += new EventHandler(btnChgWeapon_Click);
                Controls.Add(btnChgWeapon);

                Button btnToMenu = new Button();
                btnToMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnToMenu.Location = new System.Drawing.Point(277, 270);
                btnToMenu.AutoSize = true;
                btnToMenu.UseVisualStyleBackColor = true;
                btnToMenu.Text = "Go to Main Menu";
                btnToMenu.Name = "btnToMenu";
                btnToMenu.Click += new EventHandler(btnToMenu_Click);
                Controls.Add(btnToMenu);

                Button btnExit = new Button();
                btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnExit.Location = new System.Drawing.Point(309, 305);
                btnExit.AutoSize = true;
                btnExit.UseVisualStyleBackColor = true;
                btnExit.Text = "Exit";
                btnExit.Name = "btnExit";
                btnExit.Click += new EventHandler(btnExit_Click);
                Controls.Add(btnExit);
            }
        }

        void btnPlayBonus_Click(object sender, EventArgs e)
        {
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);

            // Make label telling user about the bonus level
            Label lblBonusInfo = new Label();
            lblBonusInfo.BackColor = System.Drawing.Color.Transparent;
            lblBonusInfo.Enabled = false;
            lblBonusInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblBonusInfo.Location = new System.Drawing.Point(12, 38);
            lblBonusInfo.Name = "lblBonusInfo";
            lblBonusInfo.Size = new System.Drawing.Size(666, 100);
            lblBonusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblBonusInfo.Text = "This bonus level is a version of whack-a-mole. \nJust click on the Ground Hog to win and earn 50 points.";
            Controls.Add(lblBonusInfo);

            // Make button to start bonus level which calls makeBonusLevel()
            Button btnStartBonus = new Button();
            btnStartBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnStartBonus.Location = new System.Drawing.Point(271, 156);
            btnStartBonus.Name = "btnStartBonus";
            btnStartBonus.Size = new System.Drawing.Size(159, 135);
            btnStartBonus.Text = "Start";
            btnStartBonus.UseVisualStyleBackColor = true;
            btnStartBonus.Click += new EventHandler(btnStartBonus_Click);
            Controls.Add(btnStartBonus);

            int grndHogSpeed = (userLevel.getLevel() + 1) / 3;
            userBonusLevel = new LevelBonusGH(grndHogSpeed);
            oldNum = 50;

            this.Text = "Bonus Level";
            lblScore.Text = "Score: " + userBonusLevel.getScore();
            currTime = 15;
            lblTime.Text = "Time: " + currTime;

            isBonusLevel = true;
            lblScore.Visible = false;
        }

        void btnStartBonus_Click(object sender, EventArgs e)
        {
            Controls.RemoveAt(Controls.Count - 1);
            Controls.RemoveAt(Controls.Count - 1);

            makeBonusLevel();

            // Change cursor to a target
            this.Cursor = System.Windows.Forms.Cursors.Cross;

            tmrBonusGrndHog = new Timer();
            tmrBonusGrndHog.Interval = 500 / userBonusLevel.getSpeed();
            tmrBonusGrndHog.Enabled = true;
            tmrBonusGrndHog.Tick += new EventHandler(tmrBonusGrndHog_Tick);

            tmrBonusLevel = new Timer();
            tmrBonusLevel.Interval = 1000;
            tmrBonusLevel.Enabled = true;
            tmrBonusLevel.Tick += new EventHandler(tmrBonusLevel_Tick);

            isPaused = false;
            isEnded = false;
        }

        void tmrBonusLevel_Tick(object sender, EventArgs e)
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

        void tmrBonusGrndHog_Tick(object sender, EventArgs e)
        {
            int num = rndbuttonLoc.Next(1, 40);

            if (num != oldNum)
            {
                bonusBurrows[num].Image = groundHogPics[0];
                bonusBurrows[num].Click += new EventHandler(bonusBurrows_Click);

                if ((oldNum < 40) && (oldNum >= 0))
                {
                    bonusBurrows[oldNum].Image = groundHogPics[1];
                    bonusBurrows[oldNum].Click -= bonusBurrows_Click;
                }
                oldNum = num;
            }
        }

        private void bonusBurrows_Click(object sender, EventArgs e)
        {
            endGame(true);
        }

        void btnChgWeapon_Click(object sender, EventArgs e)
        {
            frmWeapon formWeapon = new frmWeapon(menuMusic);
            formWeapon.Show();
            this.Close();
        }

        void btnPlayAgain_Click(object sender, EventArgs e)
        {
            Controls.RemoveAt(Controls.Count - 1);
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
            if (isBonusLevel)
            {
                Controls.RemoveAt(Controls.Count - 1);
                Controls.RemoveAt(Controls.Count - 1);
                Controls.RemoveAt(Controls.Count - 1);
                Controls.RemoveAt(Controls.Count - 1);
                lblScore.Visible = true;
                isBonusLevel = false;
            }
            else
            {
                Controls.RemoveAt(Controls.Count - 1);
                Controls.RemoveAt(Controls.Count - 1);
                Controls.RemoveAt(Controls.Count - 1);
                Controls.RemoveAt(Controls.Count - 1);
                Controls.RemoveAt(Controls.Count - 1);
                Controls.RemoveAt(Controls.Count - 1);
                if (((userLevel.getLevel() + 1) % 3) == 0)
                {
                    Controls.RemoveAt(Controls.Count - 1);
                    Controls.RemoveAt(Controls.Count - 1);
                }
            }

            btnStart.Enabled = true;
            btnStart.Visible = true;

            userWeapon.reset();
            lblAmmo.Text = "Ammo: " + userWeapon.getInitialAmmo();
            lblAmmo.Visible = true;

            int currLevel = userLevel.getLevel();
            userLevel = new Level(currLevel+1, currLevel+1, currLevel+1, currLevel+1);

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
            btnStart.Enabled = false;
            btnStart.Visible = false;
            makeTargets();

            btnPause.Enabled = true;
            btnPause.Visible = true;

            bkgndSound.Play();

            // Change cursor to a target
            this.Cursor = System.Windows.Forms.Cursors.Cross;

            // Initialize timer and set all its necessary attributes
            tmrMoveTargets = new Timer();
            tmrMoveTargets.Interval = 33;
            tmrMoveTargets.Enabled = true;
            tmrMoveTargets.Tick += new EventHandler(tmrMoveTargets_Tick);

            tmrLevelTime = new Timer();
            tmrLevelTime.Interval = 1000;
            tmrLevelTime.Enabled = true;
            tmrLevelTime.Tick += new EventHandler(tmrLevelTime_Tick);

            tmrWalker = new Timer();
            tmrWalker.Interval = 150;
            tmrWalker.Enabled = true;
            tmrWalker.Tick += new EventHandler(tmrWalker_Tick);

            isPaused = false;
            isEnded = false;
        }

        void tmrWalker_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < smallBtns.Count; i++)
            {
                if (!motionSmlFlipped[i])
                {
                    if (duckWalkCounter >= 2)
                    {
                        duckWalkCounter = 0;
                    }
                    else
                    {
                        duckWalkCounter++;
                    }
                    smallBtns[i].BackgroundImage = duckPicsRight[duckWalkCounter];
                }
                else
                {
                    if (duckWalkCounter >= 2)
                    {
                        duckWalkCounter = 0;
                    }
                    else
                    {
                        duckWalkCounter++;
                    }
                    smallBtns[i].BackgroundImage = duckPicsLeft[duckWalkCounter];
                }
            }

            for (int i = 0; i < mediumBtns.Count; i++)
            {
                if (!motionMedFlipped[i])
                {
                    if (deerWalkCounter >= 2)
                    {
                        deerWalkCounter = 0;
                    }
                    else
                    {
                        deerWalkCounter++;
                    }
                    mediumBtns[i].BackgroundImage = deerPicsRight[deerWalkCounter];
                }
                else
                {
                    if (deerWalkCounter >= 2)
                    {
                        deerWalkCounter = 0;
                    }
                    else
                    {
                        deerWalkCounter++;
                    }
                    mediumBtns[i].BackgroundImage = deerPicsLeft[deerWalkCounter];
                }
            }

            for (int i = 0; i < bigBtns.Count; i++)
            {
                if (!motionBigFlipped[i])
                {
                    if (bearWalkCounter >= 3)
                    {
                        bearWalkCounter = 0;
                    }
                    else
                    {
                        bearWalkCounter++;
                    }
                    bigBtns[i].BackgroundImage = bearPicsRight[bearWalkCounter];
                }
                else
                {
                    if (bearWalkCounter >= 3)
                    {
                        bearWalkCounter = 0;
                    }
                    else
                    {
                        bearWalkCounter++;
                    }
                    bigBtns[i].BackgroundImage = bearPicsLeft[bearWalkCounter];
                }
            }
        }

        // Timer event method to keep track of level time
        void tmrLevelTime_Tick(object sender, EventArgs e)
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
        void tmrMoveTargets_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < smallBtns.Count; i++)
            {
                if (!motionSmlFlipped[i])
                {
                    smallBtns[i].Left += 8;
                    if (smallBtns[i].Right >= 694)
                    {
                        motionSmlFlipped[i] = true;
                    }
                }
                else
                {
                    smallBtns[i].Left -= 8;
                    if (smallBtns[i].Left <= 0)
                    {
                        motionSmlFlipped[i] = false;
                    }
                }
            }

            for (int i = 0; i < mediumBtns.Count; i++)
            {
                if (!motionMedFlipped[i])
                {
                    mediumBtns[i].Left += 6;
                    if (mediumBtns[i].Right >= 694)
                    {
                        motionMedFlipped[i] = true;
                    }
                }
                else
                {
                    mediumBtns[i].Left -= 6;
                    if (mediumBtns[i].Left <= 0)
                    {
                        motionMedFlipped[i] = false;
                    }
                }
            }

            for (int i = 0; i < bigBtns.Count; i++)
            {
                if (!motionBigFlipped[i])
                {
                    bigBtns[i].Left += 3;
                    if (bigBtns[i].Right >= 694)
                    {
                        motionBigFlipped[i] = true;
                    }
                }
                else
                {
                    bigBtns[i].Left -= 3;
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
            if ((!isEnded)&&(!isPaused))
            {
                if (!userWeapon.inReload())
                {
                    userWeapon.TakenShot();
                    lblAmmo.Text = "Ammo: " + userWeapon.getAmmo();
                    if (userWeapon.needReload())
                    {
                        reloadWeapon();
                    }
                    else
                    {
                        playGunShot();
                    }
                }
            }
        }

        private void reloadWeapon()
        {
            userWeapon.Reload();
            lblAmmo.Text = "Reloading weapon...";
            lblReload.Text = "Reloading weapon...";
            lblReload.Enabled = true;
            lblReload.Visible = true;
            Timer tmrWeaponReload = new Timer();
            tmrWeaponReload.Interval = userWeapon.getTimeReload() * 1000;
            tmrWeaponReload.Enabled = true;
            tmrWeaponReload.Tick += new EventHandler(tmrWeaponReload_Tick);
            bkgndSound.Stop();
            gunReloadSound.Play();
        }

        void tmrWeaponReload_Tick(object sender, EventArgs e)
        {
            lblAmmo.Text = "Ammo: " + userWeapon.getInitialAmmo();
            lblReload.Enabled = false;
            lblReload.Visible = false;
            gunReloadSound.Stop();
            bkgndSound.Play();
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

        private void makeBonusLevel()
        {
            // Make the grid of picture boxes necessary for the whack-a-mole level
            // Grid of 8x5
            bonusBurrows = new PictureBox[40];

            int x = 0;
            int y = 35;
            for (int i = 0; i < bonusBurrows.Length; i++)
            {
                bonusBurrows[i] = new PictureBox();
                bonusBurrows[i].Location = new System.Drawing.Point(x, y);
                bonusBurrows[i].Size = new System.Drawing.Size(86, 92);
                bonusBurrows[i].Image = groundHogPics[1];
                Controls.Add(bonusBurrows[i]);

                x += 86;
                if ((i != 0) && (((i + 1) % 8) == 0))
                {
                    y += 92;
                    x = 0;
                }
            }
        }

        private void saveAllFiles()
        {
            if (File.Exists("high_scores.txt"))
            {
                HighScores fileScores = new HighScores("high_scores.txt");
                fileScores.chkHighScore(user.getName(), user.getTotalScore());
                fileScores.closeFile();

                UpdateFile saveScore = new UpdateFile("high_scores.txt");
                saveScore.putNextRecord(fileScores.ToString());
                saveScore.closeFile();
            }
            else
            {
                string highScore = user.getName() + "," + user.getTotalScore();
                UpdateFile saveScore = new UpdateFile("high_scores.txt");
                saveScore.putNextRecord(highScore);
                saveScore.closeFile();
            }

            string gameProgress = user.getName() + "," + (userLevel.getLevel() + 1) + "," + user.getTotalScore();
            UpdateFile saveGame = new UpdateFile("game_save.txt");
            saveGame.putNextRecord(gameProgress);
            saveGame.closeFile();
        }

        private void lblTime_DoubleClick(object sender, EventArgs e)
        {
            currTime += 30;
            lblTime.Text = "Time: " + currTime;
        }
    }
}