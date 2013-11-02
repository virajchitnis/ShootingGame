using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace ShootingGame
{
    public partial class frmHighScores : Form
    {
        SoundPlayer menuMusic;
        public static Label[] lblScores;

        public frmHighScores(SoundPlayer music)
        {
            InitializeComponent();
            menuMusic = music;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain mainForm = new frmMain(menuMusic);
            mainForm.Show();
            this.Close();
        }

        private void frmHighScores_Load(object sender, EventArgs e)
        {
            lblScores = new Label[5];

            for (int i = 0; i < lblScores.Length; i++)
            {
                lblScores[i] = new Label();
            }

            lblScores[0].BackColor = System.Drawing.Color.Transparent;
            lblScores[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblScores[0].Location = new System.Drawing.Point(124, 77);
            lblScores[0].Name = "lblScore1";
            lblScores[0].Size = new System.Drawing.Size(120, 30);
            lblScores[0].TabIndex = 2;
            lblScores[0].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Controls.Add(lblScores[0]);

            lblScores[1].BackColor = System.Drawing.Color.Transparent;
            lblScores[1].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblScores[1].Location = new System.Drawing.Point(124, 133);
            lblScores[1].Name = "lblScore2";
            lblScores[1].Size = new System.Drawing.Size(120, 30);
            lblScores[1].TabIndex = 3;
            lblScores[1].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Controls.Add(lblScores[1]);

            lblScores[2].BackColor = System.Drawing.Color.Transparent;
            lblScores[2].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblScores[2].Location = new System.Drawing.Point(124, 186);
            lblScores[2].Name = "lblScore3";
            lblScores[2].Size = new System.Drawing.Size(120, 30);
            lblScores[2].TabIndex = 4;
            lblScores[2].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Controls.Add(lblScores[2]);

            lblScores[3].BackColor = System.Drawing.Color.Transparent;
            lblScores[3].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblScores[3].Location = new System.Drawing.Point(124, 238);
            lblScores[3].Name = "lblScore4";
            lblScores[3].Size = new System.Drawing.Size(120, 30);
            lblScores[3].TabIndex = 5;
            lblScores[3].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Controls.Add(lblScores[3]);

            lblScores[4].BackColor = System.Drawing.Color.Transparent;
            lblScores[4].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblScores[4].Location = new System.Drawing.Point(124, 291);
            lblScores[4].Name = "lblScore5";
            lblScores[4].Size = new System.Drawing.Size(120, 30);
            lblScores[4].TabIndex = 6;
            lblScores[4].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Controls.Add(lblScores[4]);

            string line;
            int counter = 0;
            StreamReader sr = new StreamReader("high_scores.txt");
            while ((line = sr.ReadLine()) != null)
            {
                if (counter < 5)
                {
                    string[] entries = line.Split(',');
                    lblScores[counter].Text = entries[0] + " " + entries[1];
                    counter++;
                }
            }
        }
    }
}
