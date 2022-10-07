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
    public partial class Waterpark : Form
    {
        public Waterpark()
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

        private void Waterpark_Load(object sender, EventArgs e)
        {
            pictureBox_Kiddie1.Show();
            pictureBox_Kiddie2.Hide();

            pictureBox_FamilyZone1.Show();
            pictureBox_FamilyZone2.Hide();

            pictureBox_Adults1.Show();
            pictureBox_Adults2.Hide();

            FlowLayoutPanel_KiddieCove.Show();
            FlowLayoutPanel_FamilyZone.Hide();
            FlowLayoutPanel_AdultsAqua.Hide();

        }

        private void pictureBox_FamilyZone1_Click(object sender, EventArgs e)
        {
            pictureBox_Kiddie2.Show();
            pictureBox_Kiddie1.Hide();

            pictureBox_FamilyZone1.Hide();
            pictureBox_FamilyZone2.Show();

            pictureBox_Adults2.Hide();
            pictureBox_Adults1.Show();

            FlowLayoutPanel_KiddieCove.Hide();
            FlowLayoutPanel_FamilyZone.Show();
            FlowLayoutPanel_AdultsAqua.Hide();
        }

        private void pictureBox_Adults1_Click(object sender, EventArgs e)
        {
            pictureBox_Kiddie2.Show();
            pictureBox_Kiddie1.Hide();

            pictureBox_FamilyZone2.Hide();
            pictureBox_FamilyZone1.Show();

            pictureBox_Adults1.Hide();
            pictureBox_Adults2.Show();

            //test2.Show();
            FlowLayoutPanel_KiddieCove.Hide();
            FlowLayoutPanel_FamilyZone.Hide();
            FlowLayoutPanel_AdultsAqua.Show();
        }

        private void pictureBox_Kiddie1_Click(object sender, EventArgs e)
        {
            pictureBox_Kiddie1.Show();
            pictureBox_Kiddie2.Hide();

            pictureBox_FamilyZone1.Show();
            pictureBox_FamilyZone2.Hide();

            pictureBox_Adults1.Show();
            pictureBox_Adults2.Hide();

            FlowLayoutPanel_KiddieCove.Show();
            FlowLayoutPanel_FamilyZone.Hide();
            FlowLayoutPanel_AdultsAqua.Hide();
        }

        private void pictureBox_Kiddie2_Click(object sender, EventArgs e)
        {
            pictureBox_Kiddie1.Show();
            pictureBox_Kiddie2.Hide();

            pictureBox_FamilyZone1.Show();
            pictureBox_FamilyZone2.Hide();

            pictureBox_Adults1.Show();
            pictureBox_Adults2.Hide();

            FlowLayoutPanel_KiddieCove.Show();
            FlowLayoutPanel_FamilyZone.Hide();
            FlowLayoutPanel_AdultsAqua.Hide();
        }

        private void pictureBox_BookKiddieCove_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookWTPKiddie bookwtpkiddie = new BookWTPKiddie();
            bookwtpkiddie.Show();
        }

        private void pictureBox_BookFamilyZone_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookWTPFamily bookwtpfamily = new BookWTPFamily();
            bookwtpfamily.Show();
        }

        private void pictureBox_BookAdultsAqua_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookWTPAdult bookwtpAdults = new BookWTPAdult();
            bookwtpAdults.Show();
        }
    }
}
