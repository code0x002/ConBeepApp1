using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConBeepApp1
{
    public partial class Form1 : Form
    {
        private int secondsToWait = 11;
        private DateTime startTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start(); // start timer (you can do it on form load, if you need)
            startTime = DateTime.Now; // and remember start time
        }

        public void Beep()
        {
            //Console.Beep(5000, 500);

            System.IO.Stream stream = Properties.Resources.beep_07a;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(stream);
            //player.SoundLocation = @"beep-07a.wav";
            player.Play(); //or player.PlaySync();

            //stop
            //player.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
            int remainingSeconds = secondsToWait - elapsedSeconds;

            if (remainingSeconds <= 0)
            {
                toolStripStatusLabel.Text = String.Format("{0}", remainingSeconds);

                Beep();
                startTime = DateTime.Now; // and remember start time
            }
            else
            {
                toolStripStatusLabel.Text = String.Format("{0}", remainingSeconds);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            secondsToWait = trackBar1.Value;
            trackBarSecLabel.Text = trackBar1.Value.ToString() + " Sec";
        }
    }
}
