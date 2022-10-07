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
    public partial class stdpayment : Form
    {
        public stdpayment()
        {
            InitializeComponent();
        }

        private void pictureBox_Leftback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }

        private void pictureBox_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
