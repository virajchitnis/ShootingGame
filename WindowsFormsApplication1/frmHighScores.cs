﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShootingGame
{
    public partial class frmHighScores : Form
    {
        public frmHighScores()
        {
            InitializeComponent();
        }

        private void frmHighScores_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmSplash.mainForm.Show();
        }
    }
}
