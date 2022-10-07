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
    public partial class Amazementpark : Form
    {
        public Amazementpark()
        {
            InitializeComponent();
        }

        private void pictureBox_Leftback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void pictureBox_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void Amazementpark_Load(object sender, EventArgs e)
        {
            pictureBox_Kids1.Show();
            pictureBox_Kids2.Hide();

            pictureBox_Adult1.Show();
            pictureBox_Adult2.Hide();

            pictureBox_Adventure1.Show();
            pictureBox_Adventure2.Hide();

            FlowLayoutPanel_KidsFunny.Show();
            FlowLayoutPanel_AdultLand.Hide();
            FlowLayoutPanel_AdventureZone.Hide();

        }

        private void pictureBox_Kids1_Click(object sender, EventArgs e)
        {
            pictureBox_Kids1.Show();
            pictureBox_Kids2.Hide();

            pictureBox_Adult1.Show();
            pictureBox_Adult2.Hide();

            pictureBox_Adventure1.Show();
            pictureBox_Adventure2.Hide();

            FlowLayoutPanel_KidsFunny.Show();
            FlowLayoutPanel_AdultLand.Hide();
            FlowLayoutPanel_AdventureZone.Hide();
        }

        private void pictureBox_Kids2_Click(object sender, EventArgs e)
        {
       
        }

        private void pictureBox_Adult1_Click(object sender, EventArgs e)
        {
            pictureBox_Kids2.Show();
            pictureBox_Kids1.Hide();

            pictureBox_Adult2.Show();
            pictureBox_Adult1.Hide();

            pictureBox_Adventure1.Show();
            pictureBox_Adventure2.Hide();

            FlowLayoutPanel_AdultLand.Show();
            FlowLayoutPanel_KidsFunny.Hide();
            FlowLayoutPanel_AdventureZone.Hide();
        }

        private void pictureBox_Adult1_Click_1(object sender, EventArgs e)
        {
            pictureBox_Kids2.Show();
            pictureBox_Kids1.Hide();

            pictureBox_Adult2.Show();
            pictureBox_Adult1.Hide();

            pictureBox_Adventure1.Show();
            pictureBox_Adventure2.Hide();

            //test2.Show();
            FlowLayoutPanel_KidsFunny.Hide();
            FlowLayoutPanel_AdultLand.Show();
            FlowLayoutPanel_AdventureZone.Hide();
        }

        private void pictureBox_Kids2_Click_1(object sender, EventArgs e)
        {
            pictureBox_Kids1.Show();
            pictureBox_Kids2.Hide();

            pictureBox_Adult1.Show();
            pictureBox_Adult2.Hide();

            pictureBox_Adventure1.Show();
            pictureBox_Adventure2.Hide();

            FlowLayoutPanel_KidsFunny.Show();
            FlowLayoutPanel_AdultLand.Hide();
            FlowLayoutPanel_AdventureZone.Hide();
        }

        private void pictureBox_Adventure1_Click(object sender, EventArgs e)
        {
            pictureBox_Kids2.Show();
            pictureBox_Kids1.Hide();

            pictureBox_Adult1.Show();
            pictureBox_Adult2.Hide();

            pictureBox_Adventure2.Show();
            pictureBox_Adventure1.Hide();

            FlowLayoutPanel_KidsFunny.Hide();
            FlowLayoutPanel_AdultLand.Hide();
            FlowLayoutPanel_AdventureZone.Show();
        }

        private void pictureBox_BookKidsFunny_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookAMZKids bookamzkids = new BookAMZKids();
            bookamzkids.Show();
        }

        private void pictureBox_BookAdultLand_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookAMZAdults bookamzadults = new BookAMZAdults();
            bookamzadults.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookAMZAdventure bookamzadventure = new BookAMZAdventure();
            bookamzadventure.Show();
        }
    }
}
