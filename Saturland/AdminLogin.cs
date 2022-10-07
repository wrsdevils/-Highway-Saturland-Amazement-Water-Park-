using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using BarcodeLib;
using System.IO;
using System.Text.RegularExpressions;

namespace Saturland
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox_Password.PasswordChar = '•';
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (TextBox_Username.Text == "admin" && TextBox_Password.Text == "admin")
            {
                new Admin().Show();
                this.Hide();
            }
            else if (TextBox_Username.Text == "warisa" && TextBox_Password.Text == "admin")
            {
                new Admin().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password, Please try again");
                TextBox_Username.Clear();
                TextBox_Password.Clear();
                TextBox_Username.Focus();
            }
        }

        private void TextBox_Username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 122)
               || (int)e.KeyChar == 8
               || (int)e.KeyChar == 13
               || (int)e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
