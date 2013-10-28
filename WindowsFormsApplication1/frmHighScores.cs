using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ShootingGame
{
    public partial class frmHighScores : Form
    {
        string scoreFile = Properties.Resources.HighScores;
        public frmHighScores()
        {
            InitializeComponent();
        }

        private void frmHighScores_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmSplash.mainForm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmSplash.mainForm.Show();
            this.Hide();
        }

        private void frmHighScores_Load(object sender, EventArgs e)
        {
            string fileData;
            List<string[]> fileEntries = new List<string[]>();
            fileData = scoreFile;

            string[] fileLines = fileData.Split('\n');

            foreach (string line in fileLines)
            {
                string tempLine = line.TrimEnd('\r');
                string[] tempEntries = tempLine.Split(',');
                fileEntries.Add(tempEntries);
            }

            for (int i = (fileEntries.Count - 1), j = 0; i >= (fileEntries.Count - 6); i--, j++)
            {
                if (i == (fileEntries.Count - 1))
                {
                    lblScore1.Text = fileEntries[i][0] + " " + fileEntries[i][1];
                }
                if (i == (fileEntries.Count - 2))
                {
                    lblScore2.Text = fileEntries[i][0] + " " + fileEntries[i][1];
                }
                if (i == (fileEntries.Count - 3))
                {
                    lblScore3.Text = fileEntries[i][0] + " " + fileEntries[i][1];
                }
                if (i == (fileEntries.Count - 4))
                {
                    lblScore4.Text = fileEntries[i][0] + " " + fileEntries[i][1];
                }
                if (i == (fileEntries.Count - 5))
                {
                    lblScore5.Text = fileEntries[i][0] + " " + fileEntries[i][1];
                }
            }
        }
    }
}
