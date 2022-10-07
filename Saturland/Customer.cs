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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            sqlconn.Open();

            ////////////////////
            /////////////////////

            if (ComboBox_SeclectCard.SelectedItem == null)
            {
                TextBox_Search.Clear();
                MessageBox.Show("Please select your visa card");
                return;
            }

            ////////////////////////

            if (ComboBox_SeclectCard.SelectedItem.ToString() == "  Highway Visa Card")
            {
                TextBox_Search.Clear();
                MySqlCommand command = new MySqlCommand("SELECT `IDCard`,`Fname`,`Lname`,`Birth`,`Email`,`Tel`,`Province`,`Date`,`Date of Expiry` FROM `highwayregis` ", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "IDCard";
                DataGrid.Columns[1].DataPropertyName = "Fname" ;
                DataGrid.Columns[2].DataPropertyName = "Lname";
                DataGrid.Columns[3].DataPropertyName = "Birth";
                DataGrid.Columns[4].DataPropertyName = "Email";
                DataGrid.Columns[5].DataPropertyName = "Tel";
                DataGrid.Columns[6].DataPropertyName = "Province";
                DataGrid.Columns[7].DataPropertyName = "Date";
                DataGrid.Columns[8].DataPropertyName = "Date of Expiry";
                DataGrid.DataSource = dt;
                ///-///
                sqlconn.Close();
                decimal membershipcount = -1, membershipsum = -1000;
                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    membershipcount += 1;
                    membershipsum += 1000;
                }
                Date.Text = ("All");
                Membership.Text = (membershipcount.ToString() + "  members");
                Membersum.Text = (membershipsum.ToString() + "  Baht");


            }
            else if (ComboBox_SeclectCard.SelectedItem.ToString() == "  Saturland Visa Card")
            {
                TextBox_Search.Clear();
                MySqlCommand command = new MySqlCommand("SELECT `IDCard`,`Fname`,`Lname`,`Birth`,`Email`,`Tel`,`Province`,`Date`,`Date of Expiry` FROM `saturlandregis` ", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "IDCard";
                DataGrid.Columns[1].DataPropertyName = "Fname";
                DataGrid.Columns[2].DataPropertyName = "Lname";
                DataGrid.Columns[3].DataPropertyName = "Birth";
                DataGrid.Columns[4].DataPropertyName = "Email";
                DataGrid.Columns[5].DataPropertyName = "Tel";
                DataGrid.Columns[6].DataPropertyName = "Province";
                DataGrid.Columns[7].DataPropertyName = "Date";
                DataGrid.Columns[8].DataPropertyName = "Date of Expiry";
                DataGrid.DataSource = dt;
                ///-///
                sqlconn.Close();
                decimal membershipcount = -1, membershipsum = -2000;
                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    membershipcount += 1;
                    membershipsum += 2000;
                }
                Date.Text = ("All");
                Membership.Text = (membershipcount.ToString() + "  members");
                Membersum.Text = (membershipsum.ToString() + "  Baht");
            }

            else if (ComboBox_SeclectCard.SelectedItem.ToString() == "  Annual Adventure Visa Card")
            {
                TextBox_Search.Clear();
                MySqlCommand command = new MySqlCommand("SELECT `IDCard`,`Fname`,`Lname`,`Birth`,`Email`,`Tel`,`Province`,`Date`,`Date of Expiry` FROM `annualadventureregis` ", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "IDCard";
                DataGrid.Columns[1].DataPropertyName = "Fname";
                DataGrid.Columns[2].DataPropertyName = "Lname";
                DataGrid.Columns[3].DataPropertyName = "Birth";
                DataGrid.Columns[4].DataPropertyName = "Email";
                DataGrid.Columns[5].DataPropertyName = "Tel";
                DataGrid.Columns[6].DataPropertyName = "Province";
                DataGrid.Columns[7].DataPropertyName = "Date";
                DataGrid.Columns[8].DataPropertyName = "Date of Expiry";
                DataGrid.DataSource = dt;
                ///-///
                sqlconn.Close();
                decimal membershipcount = -1, membershipsum = -6999;
                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    membershipcount += 1;
                    membershipsum += 6999;
                }
                Date.Text = ("All");
                Membership.Text = (membershipcount.ToString() + "  members");
                Membersum.Text = (membershipsum.ToString() + "  Baht");
            }

            ////////////////////////////////////////////////

            else
            {
                MessageBox.Show("Please Try Again");
            }
        }

        private void TextBox_Search_TextChanged(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            sqlconn.Open();
            if (ComboBox_SeclectCard.SelectedItem == null)
            {
                
                MessageBox.Show("Please select the Visa Card");
                TextBox_Search.Clear();
                return;
            }
            if (ComboBox_SeclectCard.SelectedItem.ToString() == "  Highway Visa Card")
            {
                MySqlCommand command = new MySqlCommand("SELECT `IDCard`,`Fname`,`Lname`,`Birth`,`Email`,`Tel`,`Province`,`Date`,`Date of Expiry` FROM `highwayregis` WHERE Fname like '" + TextBox_Search.Text + "%'", sqlconn);

                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "IDCard";
                DataGrid.Columns[1].DataPropertyName = "Fname";
                DataGrid.Columns[2].DataPropertyName = "Lname";
                DataGrid.Columns[3].DataPropertyName = "Birth";
                DataGrid.Columns[4].DataPropertyName = "Email";
                DataGrid.Columns[5].DataPropertyName = "Tel";
                DataGrid.Columns[6].DataPropertyName = "Province";
                DataGrid.Columns[7].DataPropertyName = "Date";
                DataGrid.Columns[8].DataPropertyName = "Date of Expiry";
                DataGrid.DataSource = dt;

                DataGrid.DataSource = dt;
                sqlconn.Close();
            }
            else if (ComboBox_SeclectCard.SelectedItem.ToString() == "  Saturland Visa Card")
            {
                MySqlCommand command = new MySqlCommand("SELECT `IDCard`,`Fname`,`Lname`,`Birth`,`Email`,`Tel`,`Province`,`Date`,`Date of Expiry` FROM `saturlandregis` WHERE Fname like '" + TextBox_Search.Text + "%'", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "IDCard";
                DataGrid.Columns[1].DataPropertyName = "Fname";
                DataGrid.Columns[2].DataPropertyName = "Lname";
                DataGrid.Columns[3].DataPropertyName = "Birth";
                DataGrid.Columns[4].DataPropertyName = "Email";
                DataGrid.Columns[5].DataPropertyName = "Tel";
                DataGrid.Columns[6].DataPropertyName = "Province";
                DataGrid.Columns[7].DataPropertyName = "Date";
                DataGrid.Columns[8].DataPropertyName = "Date of Expiry";
                DataGrid.DataSource = dt;

                DataGrid.DataSource = dt;
                sqlconn.Close();
            }

            else if (ComboBox_SeclectCard.SelectedItem.ToString() == "  Annual Adventure Visa Card")
            {
                MySqlCommand command = new MySqlCommand("SELECT `IDCard`,`Fname`,`Lname`,`Birth`,`Email`,`Tel`,`Province`,`Date`,`Date of Expiry` FROM `annualadventureregis` WHERE Fname like '" + TextBox_Search.Text + "%'", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "IDCard";
                DataGrid.Columns[1].DataPropertyName = "Fname";
                DataGrid.Columns[2].DataPropertyName = "Lname";
                DataGrid.Columns[3].DataPropertyName = "Birth";
                DataGrid.Columns[4].DataPropertyName = "Email";
                DataGrid.Columns[5].DataPropertyName = "Tel";
                DataGrid.Columns[6].DataPropertyName = "Province";
                DataGrid.Columns[7].DataPropertyName = "Date";
                DataGrid.Columns[8].DataPropertyName = "Date of Expiry";
                DataGrid.DataSource = dt;

                DataGrid.DataSource = dt;
                sqlconn.Close();
            }
            /////////////////////////////////////////////////////////////
            
            
            else
            {
                MessageBox.Show("Please Try Again");
            }
        }

        private void Button_Go_Click(object sender, EventArgs e)
        {

            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            sqlconn.Open();
            if (ComboBox_SeclectCard.SelectedItem == null)
            {

                MessageBox.Show("Please select your visa card");
                return;
            }
            else if (ComboBox_SeclectCard.SelectedItem.ToString() == "  Highway Visa Card")
            {
                if (dateTimePicker_In.Value <= dateTimePicker_Out.Value)
                {
                    MySqlCommand command = new MySqlCommand("SELECT `IDCard`,`Fname`,`Lname`,`Birth`,`Email`,`Tel`,`Province`,`Date`,`Date of Expiry` FROM `highwayregis` WHERE `Date of Expiry` BETWEEN  '" + dateTimePicker_In.Value.AddYears(1).ToString(("MMM dd, yyyy")) + "' AND '" + dateTimePicker_Out.Value.AddYears(1).ToString(("MMM dd, yyyy")) + "' ", sqlconn);  //AND  `Date of Expiry` <=  '" + dateTimePicker_Out.Value.AddYears(1).ToString(("MMM d, yyyy")) + "'

                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);


                    adapter.Fill(dt);
                    DataGrid.AutoGenerateColumns = false;
                    DataGrid.Columns[0].DataPropertyName = "IDCard";
                    DataGrid.Columns[1].DataPropertyName = "Fname";
                    DataGrid.Columns[2].DataPropertyName = "Lname";
                    DataGrid.Columns[3].DataPropertyName = "Birth";
                    DataGrid.Columns[4].DataPropertyName = "Email";
                    DataGrid.Columns[5].DataPropertyName = "Tel";
                    DataGrid.Columns[6].DataPropertyName = "Province";
                    DataGrid.Columns[7].DataPropertyName = "Date";
                    DataGrid.Columns[8].DataPropertyName = "Date of Expiry";
                    DataGrid.DataSource = dt;

                    // DataGrid.DataSource = dt;
                    sqlconn.Close();

                    decimal membershipcount = -1 , membershipsum= -1000 ;
                    for (int i = 0; i < DataGrid.Rows.Count; i++)
                    {
                        membershipcount += 1;
                        membershipsum += 1000;
                    }
                    Date.Text = (dateTimePicker_In.Value.ToString(("MMM dd, yyyy")) + " - " + dateTimePicker_Out.Value.ToString(("MMM dd, yyyy")));
                    Membership.Text = (membershipcount.ToString() + "  members");
                    Membersum.Text = (membershipsum.ToString() + "  Baht");

                }
                else
                {
                    MessageBox.Show("Oops, Please Choose The Correct Date!", "WARNING",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //MessageBox.Show("Oops, Please Choose The Correct Date!");
                }


            }
            else if (ComboBox_SeclectCard.SelectedItem.ToString() == "  Saturland Visa Card")
            {
                if (dateTimePicker_In.Value <= dateTimePicker_Out.Value)
                {
                    MySqlCommand command = new MySqlCommand("SELECT `IDCard`,`Fname`,`Lname`,`Birth`,`Email`,`Tel`,`Province`,`Date`,`Date of Expiry` FROM `saturlandregis` WHERE `Date of Expiry` BETWEEN  '" + dateTimePicker_In.Value.AddYears(1).ToString(("MMM dd, yyyy")) + "' AND '" + dateTimePicker_Out.Value.AddYears(1).ToString(("MMM dd, yyyy")) + "' ", sqlconn);  //AND  `Date of Expiry` <=  '" + dateTimePicker_Out.Value.AddYears(1).ToString(("MMM d, yyyy")) + "'

                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);


                    adapter.Fill(dt);
                    DataGrid.AutoGenerateColumns = false;
                    DataGrid.Columns[0].DataPropertyName = "IDCard";
                    DataGrid.Columns[1].DataPropertyName = "Fname";
                    DataGrid.Columns[2].DataPropertyName = "Lname";
                    DataGrid.Columns[3].DataPropertyName = "Birth";
                    DataGrid.Columns[4].DataPropertyName = "Email";
                    DataGrid.Columns[5].DataPropertyName = "Tel";
                    DataGrid.Columns[6].DataPropertyName = "Province";
                    DataGrid.Columns[7].DataPropertyName = "Date";
                    DataGrid.Columns[8].DataPropertyName = "Date of Expiry";
                    DataGrid.DataSource = dt;

                    // DataGrid.DataSource = dt;
                    sqlconn.Close();
                    decimal membershipcount = -1, membershipsum = -2000;
                    for (int i = 0; i < DataGrid.Rows.Count; i++)
                    {
                        membershipcount += 1;
                        membershipsum += 2000;
                    }
                    Date.Text = (dateTimePicker_In.Value.ToString(("MMM dd, yyyy")) + " - " + dateTimePicker_Out.Value.ToString(("MMM dd, yyyy")));
                    Membership.Text = (membershipcount.ToString() + "  members");
                    Membersum.Text = (membershipsum.ToString() + "  Baht");

                }
                else
                {
                    MessageBox.Show("Oops, Please Choose The Correct Date!", "WARNING",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //MessageBox.Show("Oops, Please Choose The Correct Date!");
                }
            }

            else if (ComboBox_SeclectCard.SelectedItem.ToString() == "  Annual Adventure Visa Card")
            {
                if (dateTimePicker_In.Value <= dateTimePicker_Out.Value)
                {
                    MySqlCommand command = new MySqlCommand("SELECT `IDCard`,`Fname`,`Lname`,`Birth`,`Email`,`Tel`,`Province`,`Date`,`Date of Expiry` FROM `annualadventureregis` WHERE `Date of Expiry` BETWEEN  '" + dateTimePicker_In.Value.AddYears(1).ToString(("MMM dd, yyyy")) + "' AND '" + dateTimePicker_Out.Value.AddYears(1).ToString(("MMM dd, yyyy")) + "' ", sqlconn);  //AND  `Date of Expiry` <=  '" + dateTimePicker_Out.Value.AddYears(1).ToString(("MMM d, yyyy")) + "'

                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);
                    DataGrid.AutoGenerateColumns = false;
                    DataGrid.Columns[0].DataPropertyName = "IDCard";
                    DataGrid.Columns[1].DataPropertyName = "Fname";
                    DataGrid.Columns[2].DataPropertyName = "Lname";
                    DataGrid.Columns[3].DataPropertyName = "Birth";
                    DataGrid.Columns[4].DataPropertyName = "Email";
                    DataGrid.Columns[5].DataPropertyName = "Tel";
                    DataGrid.Columns[6].DataPropertyName = "Province";
                    DataGrid.Columns[7].DataPropertyName = "Date";
                    DataGrid.Columns[8].DataPropertyName = "Date of Expiry";
                    DataGrid.DataSource = dt;

                    // DataGrid.DataSource = dt;
                    sqlconn.Close();
                    decimal membershipcount = -1, membershipsum = -6999;
                    for (int i = 0; i < DataGrid.Rows.Count; i++)
                    {
                        membershipcount += 1;
                        membershipsum += 6999;
                    }
                    Date.Text = (dateTimePicker_In.Value.ToString(("MMM dd, yyyy")) + " - " + dateTimePicker_Out.Value.ToString(("MMM dd, yyyy")));
                    Membership.Text = (membershipcount.ToString() + "  members");
                    Membersum.Text = (membershipsum.ToString() + "  Baht");

                }
                else
                {
                    MessageBox.Show("Oops, Please Choose The Correct Date!", "WARNING",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //MessageBox.Show("Oops, Please Choose The Correct Date!");
                }
            }
        
        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }
        private void check_all_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            sqlconn.Open();

            decimal count_highwayregis = 0 , count_saturlandregis = 0 , count_annualadventureregis = 0; //decimal count_all = 0;
            using (var command = new MySqlCommand ("SELECT COUNT(*) FROM highwayregis", sqlconn))
            {
                count_highwayregis = (Convert.ToInt32(command.ExecuteScalar()))*1000 ;
            }
            using (var command = new MySqlCommand("SELECT COUNT(*) FROM saturlandregis", sqlconn))
            {
                count_saturlandregis = (Convert.ToInt32(command.ExecuteScalar()))*2000  ;
            }
            using (var command = new MySqlCommand("SELECT COUNT(*) FROM annualadventureregis ", sqlconn))
            {
                count_annualadventureregis = (Convert.ToInt32(command.ExecuteScalar())) * 6999 ;
            }

            ////

            ////
            Alltotal.Text = ((count_highwayregis+ count_saturlandregis+count_annualadventureregis).ToString()+"  Baht") ;
            sqlconn.Close();
        }

        private void pictureBox_Leftback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin admin = new Admin();
            admin.Show();
        }

        private void pictureBox_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Home home = new Home();
            home.Show();
        }

        private void Alltotal_Click(object sender, EventArgs e)
        {

        }
    }
}
