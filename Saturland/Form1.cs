using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saturland
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            timer_mainpic.Start();
            timer_maindot.Start();
        }

        private void timer_mainpic_Tick(object sender, EventArgs e)
        {
            if (pictureBox_Studentdaypass.Visible == true)
            {

                pictureBox_Studentdaypass.Visible = false;
                pictureBox_Highwayvisacard.Visible = true;
            }
            else if (pictureBox_Highwayvisacard.Visible == true)
            {
                pictureBox_Highwayvisacard.Visible = false;
                pictureBox_Saturlandvisacard.Visible = true;
            }
            else if (pictureBox_Saturlandvisacard.Visible == true)
            {
                pictureBox_Saturlandvisacard.Visible = false;
                pictureBox_Annualadventure.Visible = true;
            }
            else if (pictureBox_Annualadventure.Visible == true)
            {
                pictureBox_Annualadventure.Visible = false;
                pictureBox_Studentdaypass.Visible = true;
            }

        }

        private void timer_maindot_Tick(object sender, EventArgs e)
        {
            if (pictureBox_1stdot.Visible == true)
            {
                pictureBox_1stdot.Visible = false;
                pictureBox_2nddot.Visible = true;
            }
            else if (pictureBox_2nddot.Visible == true)
            {
                pictureBox_2nddot.Visible = false;
                pictureBox_3rddot.Visible = true;
            }
            else if (pictureBox_3rddot.Visible == true)
            {
                pictureBox_3rddot.Visible = false;
                pictureBox_4thdot.Visible = true;
            }
            else if (pictureBox_4thdot.Visible == true)
            {
                pictureBox_4thdot.Visible = false;
                pictureBox_1stdot.Visible = true;
            }
        }

        private void pictureBox_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_ToHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void pictureBox_Studentdaypass_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentDayPass stddp = new StudentDayPass();
            stddp.Show();
        }

        private void pictureBox_Highwayvisacard_Click(object sender, EventArgs e)
        {
            this.Hide();
            HighwayRegis hwrg = new HighwayRegis();
            hwrg.Show();
        }

        private void pictureBox_Saturlandvisacard_Click(object sender, EventArgs e)
        {
            this.Hide();
            SaturlandRegis stlrg = new SaturlandRegis();
            stlrg.Show();
        }

        private void pictureBox_Annualadventure_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnnualAdventureRegis anavtrg = new AnnualAdventureRegis();
            anavtrg.Show();
        }
    }
}
