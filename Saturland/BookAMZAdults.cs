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
    public partial class BookAMZAdults : Form
    {
        public BookAMZAdults()
        {
            InitializeComponent();
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            string sqlqueryengaddress = "SELECT DISTINCT province FROM engversionaddress ";
            MySqlCommand sqlcomm = new MySqlCommand(sqlqueryengaddress, sqlconn);
            sqlconn.Open();

            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();

            MySqlDataReader dr = sqlcomm.ExecuteReader();
            while (dr.Read())
            {
                ComboBox_Province1.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            sqlconn.Close();
        }

        private void pictureBox_Leftback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }

        private void pictureBox_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Numeric_Kids_ValueChanged(object sender, EventArgs e)
        {
            int numkids = Convert.ToInt32(Numeric_Kids.Value);
            int numadults = Convert.ToInt32(Numeric_Adults.Value);

            int kids_subtotal = (numkids * 390);
            int kids_discount = (numkids * (390 - 190));
            int kids_total = kids_subtotal - kids_discount;

            int adults_subtotal = (numadults * 1090);
            int adults_discount = (numadults * (1090 - 890));
            int adults_total = adults_subtotal - adults_discount;
            int all_total = kids_total + adults_total;

            Label_Subtotal.Text = (kids_subtotal + adults_subtotal).ToString();
            Label_Discount.Text = "-" + (kids_discount + adults_discount).ToString();

            Label_Total.ForeColor = Color.Khaki;
            Label_Total.Text = (all_total).ToString();
        }

        private void Numeric_Adults_ValueChanged(object sender, EventArgs e)
        {
            int numkids = Convert.ToInt32(Numeric_Kids.Value);
            int numadults = Convert.ToInt32(Numeric_Adults.Value);

            int kids_subtotal = (numkids * 390);
            int kids_discount = (numkids * (390 - 190));
            int kids_total = kids_subtotal - kids_discount;

            int adults_subtotal = (numadults * 1090);
            int adults_discount = (numadults * (1090 - 890));
            int adults_total = adults_subtotal - adults_discount;
            int all_total = kids_total + adults_total;

            Label_Subtotal.Text = (kids_subtotal + adults_subtotal).ToString();
            Label_Discount.Text = "-" + (kids_discount + adults_discount).ToString();

            Label_Total.ForeColor = Color.Khaki;
            Label_Total.Text = (all_total).ToString();

        }

        private void TextBox_Fname_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TextBox_Lname_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Button_Confirm_Click(object sender, EventArgs e)
        {
            if (TextBox_Fname.Text != "" && TextBox_Lname.Text != "" && dateTimePicker_Visit.Text != "" && ComboBox_Province1.Text != "" && TextBox_Email.Text != "" && TextBox_Telnum.Text != "")
            {

                string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

                if (Regex.IsMatch(TextBox_Email.Text, expression))
                {
                    Label_EmailCheck.ForeColor = Color.MediumTurquoise;
                    Label_EmailCheck.Text = "Correct E-mail";
                }
                else
                {
                    Label_EmailCheck.ForeColor = Color.Cornsilk;
                    Label_EmailCheck.Text = "Incorrect E-mail";
                }

                if (TextBox_Telnum.Text != "")
                {
                    if (TextBox_Telnum.Text.Length == 10)
                    {
                        if (TextBox_Telnum.Text.StartsWith("0"))
                        {
                            Label_TelnumCheck.ForeColor = Color.MediumTurquoise;
                            Label_TelnumCheck.Text = "Correct Tel. number";
                        }
                        else
                        {
                            Label_TelnumCheck.ForeColor = Color.Cornsilk;
                            Label_TelnumCheck.Text = "Incorrect Tel. number";
                        }

                    }
                    else
                    {
                        Label_TelnumCheck.ForeColor = Color.Cornsilk;
                        Label_TelnumCheck.Text = "Incorrect Tel. number";
                    }
                }
                else
                {
                    Label_TelnumCheck.ForeColor = Color.Cornsilk;
                    Label_TelnumCheck.Text = "Please fill Tel. number";
                }
            }
            else
            {
                MessageBox.Show("Please fill required fields");
            }
        }

        private void Button_Really_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "CONFIRMS", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
                MySqlConnection sqlconn = new MySqlConnection(mainconn);
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM adultsland WHERE Fname = '" + TextBox_Fname.Text + "' AND Lname = '" + TextBox_Lname.Text + "'", sqlconn);


                DataTable dt = new DataTable();
                da.Fill(dt);
                //int i = ds.Tables[0].Rows.Count;

                if (TextBox_IDsearch.Text == "")
                {
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Account : " + TextBox_Fname.Text + TextBox_Lname.Text + "  Already Exists"); // dateTimePicker_Birth.Value.ToString("dd-MMM-yyyy")  Numeric_Kids
                    }
                    else
                    {
                        sqlconn.Open();
                        MySqlCommand command = new MySqlCommand("INSERT INTO `adultsland`(`IDCard`,`Fname`, `Lname`, `Visacard`, `KidsTicket`, `ParentsTicket`, `Email`, `Tel`, `Province`, `Visitdate`, `Pricetotal`, `Bookdate`) VALUES('-','" + TextBox_Fname.Text + "','" + TextBox_Lname.Text + "','-','" + Numeric_Kids.Value + "','" + Numeric_Adults.Value + "','" + TextBox_Email.Text + "','" + TextBox_Telnum.Text + "','" + ComboBox_Province1.Text + "','" + dateTimePicker_Visit.Value.ToString("MMM dd, yyyy") + "','" + Label_Total.Text.ToString() + "','" + DateTime.Now.ToString(("MMM dd, yyyy | h:mm tt ")) + "')", sqlconn);
                        command.ExecuteNonQuery();
                        sqlconn.Close();
                        try
                        {
                            if (command.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Data Inserted Successfully");
                            }
                            else
                            {
                                MessageBox.Show("Data Not Inserted");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Data Inserted Successfully");

                            GlobalPayment.First = Numeric_Kids.Text;
                            GlobalPayment.Second = Numeric_Adults.Text;

                            GlobalPayment.Third = Label_Subtotal.Text;
                            GlobalPayment.Fourth = Label_Discount.Text;
                            GlobalPayment.Fifth = Label_Total.Text;
                            GlobalPayment.Sixth = TextBox_Fname.Text;
                            GlobalPayment.Seventh = TextBox_Lname.Text;

                            PaymentAMZAdults paymentAMZAdults = new PaymentAMZAdults();
                            paymentAMZAdults.Show();

                        }
                    }
                }
                else
                {
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Account : " + TextBox_Fname.Text + TextBox_Lname.Text + "  Already Exists"); // dateTimePicker_Birth.Value.ToString("dd-MMM-yyyy")  Numeric_Kids
                    }
                    else
                    {
                        sqlconn.Open();
                        MySqlCommand command = new MySqlCommand("INSERT INTO `adultsland`(`IDCard`,`Fname`, `Lname`, `Visacard`, `KidsTicket`, `ParentsTicket`, `Email`, `Tel`, `Province`, `Visitdate`, `Pricetotal`, `Bookdate`) VALUES('" + TextBox_IDsearch.Text + "','" + TextBox_Fname.Text + "','" + TextBox_Lname.Text + "','" + ComboBox_SeclectVisa.SelectedItem.ToString() + "', '" + Numeric_Kids.Value + "','" + Numeric_Adults.Value + "','" + TextBox_Email.Text + "','" + TextBox_Telnum.Text + "','" + ComboBox_Province1.Text + "','" + dateTimePicker_Visit.Value.ToString("MMM dd, yyyy") + "','" + Label_Total.Text.ToString() + "','" + DateTime.Now.ToString(("MMM dd, yyyy | h:mm tt ")) + "')", sqlconn);
                        command.ExecuteNonQuery();
                        sqlconn.Close();
                        try
                        {
                            if (command.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Data Inserted Successfully");
                            }
                            else
                            {
                                MessageBox.Show("Data Not Inserted");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Data Inserted Successfully");
                            GlobalPayment.First = Numeric_Kids.Text;
                            GlobalPayment.Second = Numeric_Adults.Text;

                            GlobalPayment.Third = Label_Subtotal.Text;
                            GlobalPayment.Fourth = Label_Discount.Text;
                            GlobalPayment.Fifth = Label_Total.Text;
                            GlobalPayment.Sixth = TextBox_Fname.Text;
                            GlobalPayment.Seventh = TextBox_Lname.Text;

                            PaymentAMZAdults paymentAMZAdults = new PaymentAMZAdults();
                            paymentAMZAdults.Show();

                        }
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                Main main = new Main();
                main.Show();
            }
        }

        private void ComboBox_SeclectVisa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button_View_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            sqlconn.Open();


            if (ComboBox_SeclectVisa.SelectedItem == null)
            {
                TextBox_IDsearch.Clear();
                MessageBox.Show("Please select your visa card");
                return;
            }

            if (ComboBox_SeclectVisa.SelectedItem.ToString() == "Highway Visa Card")
            {
                MySqlCommand command = new MySqlCommand("SELECT Fname,Lname,Province,Email,Tel FROM highwayregis WHERE IDCard = '" + TextBox_IDsearch.Text + "'", sqlconn);
                command.Parameters.AddWithValue("IDCard", TextBox_Fname.Text);
                MySqlDataReader da = command.ExecuteReader();
                if (da.Read())
                {
                    TextBox_Fname.Text = da.GetValue(0).ToString();
                    TextBox_Lname.Text = da.GetValue(1).ToString();
                    ComboBox_Province1.Text = da.GetValue(2).ToString();
                    TextBox_Email.Text = da.GetValue(3).ToString();
                    TextBox_Telnum.Text = da.GetValue(4).ToString();

                    int numkids = Convert.ToInt32(Numeric_Kids.Value);
                    int numadults = Convert.ToInt32(Numeric_Adults.Value);

                    double kids_subtotal = (numkids * 390);
                    double kids_discount = (numkids * (390 - 190));
                    double kids_total = kids_subtotal - kids_discount;

                    double adults_subtotal = (numadults * 1090);
                    double adults_discount = (numadults * (1090 - 890));
                    double parents_total = adults_subtotal - adults_discount;

                    double all_total = (kids_total + parents_total);
                    double all_net = all_total * 0.9;
                    double member_discount = all_total * 0.1;

                    Label_Subtotal.Text = (kids_subtotal + adults_subtotal).ToString();
                    Label_Discount.Text = "-" + (kids_discount + adults_discount + member_discount).ToString();

                    Label_Total.ForeColor = Color.Khaki;
                    Label_Total.Text = (all_net).ToString();
                }
                else
                {
                    int numkids = Convert.ToInt32(Numeric_Kids.Value);
                    int numadults = Convert.ToInt32(Numeric_Adults.Value);

                    double kids_subtotal = (numkids * 390);
                    double kids_discount = (numkids * (390- 190));
                    double kids_total = kids_subtotal - kids_discount;

                    double adults_subtotal = (numadults * 1090);
                    double adults_discount = (numadults * (1090 - 890));
                    double adults_total = adults_subtotal - adults_discount;

                    double all_total = (kids_total + adults_total);

                    Label_Subtotal.Text = (kids_subtotal + adults_subtotal).ToString();
                    Label_Discount.Text = "-" + (kids_discount + adults_discount).ToString();

                    Label_Total.ForeColor = Color.Khaki;
                    Label_Total.Text = (all_total).ToString();
                    ComboBox_SeclectVisa.Text = "";
                    TextBox_IDsearch.Clear();
                    TextBox_Fname.Text = "";
                    TextBox_Lname.Text = "";
                    ComboBox_Province1.Text = "";
                    TextBox_Email.Text = "";
                    TextBox_Telnum.Text = "";
                    ComboBox_Province1.SelectedIndex = -1;
                    MessageBox.Show("Incorrect ID Card");
                }


                sqlconn.Close();
            }
            else if (ComboBox_SeclectVisa.SelectedItem.ToString() == "Saturland Visa Card")
            {
                MySqlCommand command = new MySqlCommand("SELECT Fname,Lname,Province,Email,Tel FROM saturlandregis WHERE IDCard = '" + TextBox_IDsearch.Text + "'", sqlconn);
                command.Parameters.AddWithValue("IDCard", TextBox_Fname.Text);
                MySqlDataReader da = command.ExecuteReader();
                if (da.Read())
                {
                    TextBox_Fname.Text = da.GetValue(0).ToString();
                    TextBox_Lname.Text = da.GetValue(1).ToString();
                    ComboBox_Province1.Text = da.GetValue(2).ToString();
                    TextBox_Email.Text = da.GetValue(3).ToString();
                    TextBox_Telnum.Text = da.GetValue(4).ToString();

                    int numkids = Convert.ToInt32(Numeric_Kids.Value);
                    int numadults = Convert.ToInt32(Numeric_Adults.Value);

                    double kids_subtotal = (numkids * 390);
                    double kids_discount = (numkids * (390- 190));
                    double kids_total = kids_subtotal - kids_discount;

                    double adults_subtotal = (numadults * 1090);
                    double adults_discount = (numadults * (1090 - 890));
                    double parents_total = adults_subtotal - adults_discount;

                    double all_total = (kids_total + parents_total);
                    double all_net = all_total * 0.8;
                    double member_discount = all_total * 0.2;

                    Label_Subtotal.Text = (kids_subtotal + adults_subtotal).ToString();
                    Label_Discount.Text = "-" + (kids_discount + adults_discount + member_discount).ToString();

                    Label_Total.ForeColor = Color.Khaki;
                    Label_Total.Text = (all_net).ToString();
                }
                else
                {
                    int numkids = Convert.ToInt32(Numeric_Kids.Value);
                    int numadults = Convert.ToInt32(Numeric_Adults.Value);

                    double kids_subtotal = (numkids * 390);
                    double kids_discount = (numkids * (390- 190));
                    double kids_total = kids_subtotal - kids_discount;

                    double adults_subtotal = (numadults * 1090);
                    double adults_discount = (numadults * (1090 - 890));
                    double adults_total = adults_subtotal - adults_discount;

                    double all_total = (kids_total + adults_total);

                    Label_Subtotal.Text = (kids_subtotal + adults_subtotal).ToString();
                    Label_Discount.Text = "-" + (kids_discount + adults_discount).ToString();

                    Label_Total.ForeColor = Color.Khaki;
                    Label_Total.Text = (all_total).ToString();
                    ComboBox_SeclectVisa.Text = "";
                    TextBox_IDsearch.Clear();
                    TextBox_Fname.Text = "";
                    TextBox_Lname.Text = "";
                    ComboBox_Province1.Text = "";
                    TextBox_Email.Text = "";
                    TextBox_Telnum.Text = "";
                    ComboBox_Province1.SelectedIndex = -1;
                    MessageBox.Show("Incorrect ID Card");

                }

                sqlconn.Close();
            }


        }

        private void ComboBox_Province1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BookAMZAdults_Load(object sender, EventArgs e)
        {

        }
    }
}
