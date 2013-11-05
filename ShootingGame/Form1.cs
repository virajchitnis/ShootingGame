using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int score = 0;
        int timeCount;
        Random rand = new Random();




        private void button1_Click(object sender, EventArgs e)
        {
            score = score + 5;
            lblScore.Text = score.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            score = score + 10;
            lblScore.Text = Convert.ToString(score);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            score = score + 20;
            lblScore.Text = Convert.ToString(score);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            do
            {
                Point pt = new Point(Convert.ToInt32(rand.Next(1, 200).ToString()), Convert.ToInt32(rand.Next(1, 100).ToString()));
                btnBig.Location = pt;

                //int month = rnd.Next(1, 13)
            }
            while (timeCount > 0);
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            btnStart.Enabled = false;
            timeCount = 30;
            lblTimeCount.Text = timeCount.ToString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimeCount.Text = (--timeCount).ToString();

            if (timeCount == 0)
            {
                MessageBox.Show(" Your score: " + score);
               btnStart.Enabled = true;
                timer1.Stop();
                
            }
        }


       
    }
}
