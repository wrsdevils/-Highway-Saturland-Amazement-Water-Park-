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
    public partial class SaturlandRegis : Form
    {
        public SaturlandRegis()
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
                ComboBox_Province.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            sqlconn.Close();
        }

        string imgLocation = "";

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
            if (TextBox_IDcard.Text != "" && TextBox_Fname.Text != "" && TextBox_Lname.Text != "" && dateTimePicker_Birth.Text != "" && TextBox_Address.Text != "" && ComboBox_Province.Text != "" && ComboBox_District.Text != "" && ComboBox_SubDistrict.Text != "" && ComboBox_PostCode.Text != "" && TextBox_Email.Text != "" && TextBox_Telnum.Text != "")
            {
                if (TextBox_IDcard.Text.Length == 13)
                {
                    string pid = TextBox_IDcard.Text;
                    char[] numberChars = pid.ToCharArray();

                    int total = 0;
                    int mul = 13;
                    int mod = 0, mod2 = 0;
                    int nsub = 0;
                    int numberChars12 = 0;

                    for (int i = 0; i < numberChars.Length - 1; i++)
                    {
                        int num = 0;
                        int.TryParse(numberChars[i].ToString(), out num);

                        total = total + num * mul;
                        mul = mul - 1;
                    }

                    mod = total % 11;
                    nsub = 11 - mod;
                    mod2 = nsub % 10;

                    int.TryParse(numberChars[12].ToString(), out numberChars12);

                    if (mod2 != numberChars12)
                    {
                        Label_IDCardCheck.ForeColor = Color.Red;
                        Label_IDCardCheck.Text = "Incorrect ID card number";
                    }

                    else
                    {
                        Label_IDCardCheck.ForeColor = Color.Green;
                        Label_IDCardCheck.Text = "Correct ID card number";

                    }
                }
                else
                {
                    Label_IDCardCheck.ForeColor = Color.Red;
                    Label_IDCardCheck.Text = "Please fill the correct ID card number";
                }



                string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

                if (Regex.IsMatch(TextBox_Email.Text, expression))
                {
                    Label_EmailCheck.ForeColor = Color.Green;
                    Label_EmailCheck.Text = "Correct E-mail";
                }
                else
                {
                    Label_EmailCheck.ForeColor = Color.Red;
                    Label_EmailCheck.Text = "Incorrect E-mail";
                }

                if (TextBox_Telnum.Text != "")
                {
                    if (TextBox_Telnum.Text.Length == 10)
                    {
                        if (TextBox_Telnum.Text.StartsWith("0"))
                        {
                            Label_TelCheck.ForeColor = Color.Green;
                            Label_TelCheck.Text = "Correct Tel. number";
                        }
                        else
                        {
                            Label_TelCheck.ForeColor = Color.Red;
                            Label_TelCheck.Text = "Incorrect Tel. number";
                        }

                    }
                    else
                    {
                        Label_TelCheck.ForeColor = Color.Red;
                        Label_TelCheck.Text = "Incorrect Tel. number";
                    }
                }
                else
                {
                    Label_TelCheck.ForeColor = Color.Red;
                    Label_TelCheck.Text = "Please fill Tel. number";
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
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM saturlandregis WHERE IDCard = '" + TextBox_IDcard.Text + "'", sqlconn);


                DataTable dt = new DataTable();
                da.Fill(dt);
                //int i = ds.Tables[0].Rows.Count;
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("ID CARD : " + TextBox_IDcard.Text + "  Already Exists");
                }
                else
                {
                    byte[] images = null;
                    FileStream streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(streem);
                    images = brs.ReadBytes((int)streem.Length);


                    sqlconn.Open();
                    MySqlCommand command = new MySqlCommand("INSERT INTO `saturlandregis`(`IDCard`, `Fname`, `Lname`, `Birth`, `Email`, `Tel`,`Address`, `Province`, `District`, `SubDistrict`, `PostCode`, `imgPaid`, `date` , `Date of Expiry`) VALUES('" + TextBox_IDcard.Text + "','" + TextBox_Fname.Text + "','" + TextBox_Lname.Text + "','" + dateTimePicker_Birth.Value.ToString("MMM dd, yyyy ") + "','" + TextBox_Email.Text + "','" + TextBox_Telnum.Text + "','" + TextBox_Address.Text + "','" + ComboBox_Province.Text + "','" + ComboBox_District.Text + "','" + ComboBox_SubDistrict.Text + "','" + ComboBox_PostCode.Text + "',@images,'" + DateTime.Now.ToString(("MMM dd, yyyy | h:mm tt ")) + "','" + DateTime.Now.AddYears(1).ToString(("MMM dd, yyyy")) + "')", sqlconn);

                    command.Parameters.Add(new MySqlParameter("@images", images));
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
                        MessageBox.Show("Successful Registration !");
                        Main main = new Main();
                        main.Show();

                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void Button_UploadeFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png) | *.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
            }
        }

        private void ComboBox_District_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox_SubDistrict.Items.Clear();
            ComboBox_PostCode.Items.Clear();
            //ComboBox_District.Items.Add(ComboBox_Province.Text);
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            string sqlqueryengaddress = "SELECT DISTINCT subdistrict FROM engversionaddress where province='" + ComboBox_Province.Text + "' and district='" + ComboBox_District.Text + "'";
            MySqlCommand sqlcomm = new MySqlCommand(sqlqueryengaddress, sqlconn);
            sqlconn.Open();

            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();

            MySqlDataReader dr = sqlcomm.ExecuteReader();
            while (dr.Read())
            {
                ComboBox_SubDistrict.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            sqlconn.Close();
        }

        private void ComboBox_SubDistrict_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox_PostCode.Items.Clear();
            //ComboBox_District.Items.Add(ComboBox_Province.Text);
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            string sqlqueryengaddress = "SELECT DISTINCT postcode FROM engversionaddress where province='" + ComboBox_Province.Text + "' and district='" + ComboBox_District.Text + "'and subdistrict='" + ComboBox_SubDistrict.Text + " '";
            MySqlCommand sqlcomm = new MySqlCommand(sqlqueryengaddress, sqlconn);
            sqlconn.Open();

            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();

            MySqlDataReader dr = sqlcomm.ExecuteReader();
            while (dr.Read())
            {
                ComboBox_PostCode.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            sqlconn.Close();
        }

        private void ComboBox_PostCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox_Province_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox_District.Items.Clear();
            ComboBox_SubDistrict.Items.Clear();
            ComboBox_PostCode.Items.Clear();
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            string sqlqueryengaddress = "SELECT DISTINCT district FROM engversionaddress where province='" + ComboBox_Province.Text + "'";
            MySqlCommand sqlcomm = new MySqlCommand(sqlqueryengaddress, sqlconn);
            sqlconn.Open();

            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();

            MySqlDataReader dr = sqlcomm.ExecuteReader();
            while (dr.Read())
            {
                ComboBox_District.Items.Add(dr.GetValue(0).ToString());
                ComboBox_District.Visible = true;
                ComboBox_SubDistrict.Visible = true;
                ComboBox_PostCode.Visible = true;
            }

            dr.Close();
            sqlconn.Close();
        }
    }
}
