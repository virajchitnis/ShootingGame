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
    public partial class frmLevel : Form
    {
        public frmLevel()
        {
            InitializeComponent();
        }

        private void btnLevel1_Click(object sender, EventArgs e)
        {
            frmMain.userLevel = new Level(1, 1, 1, 1);
            frmPlay newLevel = new frmPlay();
            newLevel.Show();
            this.Close();
        }
    }
}
