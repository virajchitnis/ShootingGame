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
    public partial class frmPlay : Form
    {
        public frmPlay()
        {
            InitializeComponent();
        }

        int score = 0;
        int timeCount;
        int soundTimer = 2;
        Random rand = new Random();

// These import sound FX
        System.Media.SoundPlayer noise = new System.Media.SoundPlayer(@"..\..\Resources\135472__kvgarlic__summeropenfielddusk.wav");
        System.Media.SoundPlayer gunshot = new System.Media.SoundPlayer(@"..\..\Resources\37236__shades__gun-pistol-one-shot.wav");
     
   ///////////////////////////////////////////////////////////////////////////////////////
      /// when START GAME is clicked
   //////////////////////////////////////////////////////////////////////////////////////////
        private void btnStart_Click(object sender, EventArgs e)
        {
            noise.Play();  //NEED TO LOOP THIS (plays the background noise)
            timer1.Enabled = true;
            timeCount = 30;

            btnStart.Enabled = false;
            btnStart.Visible = false;
            
            btnBig.Visible = true;
            btnSmall.Visible = true;
            btnMedium.Visible = true;
            picBird.Visible = true;

        }

        ////////////////////////////////////////////////////////////////////////////////////////
       //when TARGETS are Clicked
       ///////////////////////////////////////////////////////////////////////////////////

        private void isShot()                      
        {
            gunshot.Play();
            timer2.Enabled = true;



        }


        private void button1_Click(object sender, EventArgs e)
        {
            isShot();                                     
            score = score + 5;                            
            lblScore.Text = score.ToString();
            btnBig.Visible = false;        //VIRAJ could i put any of this (like visibility) in the method isShot?
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isShot();
            score = score + 10;
            lblScore.Text = Convert.ToString(score);
            btnMedium.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isShot();
            score = score + 20;
            lblScore.Text = Convert.ToString(score);
            btnSmall.Visible = false;
        }


        private void picBird_Click(object sender, EventArgs e)
        {
            isShot();
            score = score + 20;
            lblScore.Text = Convert.ToString(score);
            picBird.Visible = false;

        }


       

 /////////////////////////////////////////////////////////////////////////////////////////////////////////
        //FORM behavior
/// /////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {

            btnBig.Visible = false;
            btnSmall.Visible = false;
            btnMedium.Visible = false;
            picBird.Visible = false;

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            gunshot.Play();
            timer2.Enabled = true;

            if (timeCount == 0)
            {
                timer1.Stop();
                MessageBox.Show(" Your score: " + score);
                btnStart.Enabled = true;
                btnStart.Visible = true;
                timer1.Stop();

            }

        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////
        /// // TIMER 
        ///////////////////////////////////////////////////////////////////////////////////////////////
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimeCount.Text = (--timeCount).ToString();

            picBird.Left = picBird.Left + 100;
            btnSmall.Left = btnSmall.Left + 85;
            btnMedium.Left = btnMedium.Left - 65;
                btnBig.Left = btnBig.Left - 25;

            if (timeCount == 0)
            {
                MessageBox.Show(" Your score: " + score);
               btnStart.Enabled = true;
               btnStart.Visible = true;
                timer1.Stop();
                
            }
        }

        //Timer 2 makes the background noise start again automaticly, after the Gunshot noise. 
        //background noise would always stop after the gunshot noise played. This makes it start again.
        private void timer2_Tick(object sender, EventArgs e)
        {

            
            --soundTimer;
          if (soundTimer == 0)
          {
              noise.Play();
              timer2.Stop();
              soundTimer = 2;
          }

        }
      
       
      
       
    }

}
