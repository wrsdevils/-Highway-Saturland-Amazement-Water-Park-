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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel_headerHome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main  = new Main();
            main.Show();
        }

        private void pictureBox_Amazement_Click(object sender, EventArgs e)
        {
            this.Hide();
            Amazementpark amz = new Amazementpark();
            amz.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox_Waterpark_Click(object sender, EventArgs e)
        {
            this.Hide();
            Waterpark wtp = new Waterpark(); 
            wtp.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin adminlogin = new AdminLogin();
            adminlogin.Show();
        }
    }
}
