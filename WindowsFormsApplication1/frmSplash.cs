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
    public partial class frmSplash : Form
    {
        public static frmMain mainForm;
        public frmSplash()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            mainForm = new frmMain();
            mainForm.Show();
            this.Hide();
        }
    }
}
