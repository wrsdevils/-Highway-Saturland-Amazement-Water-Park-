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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void ComboBox_SeclectPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            sqlconn.Open();

            ////////////////////
            /////////////////////

            if (ComboBox_SeclectPart.SelectedItem == null)
            {
                TextBox_Search.Clear();
                MessageBox.Show("Please select your visa card");
                return;
            }

            ////////////////////////
            decimal highwaycount1 = 0, saturlandcount1 = 0, regularcount1 = -1, kidscount1 = 0, parentscount1 = 0, Total1 = 0;
            decimal highwaycount2 = 0, saturlandcount2 = 0, regularcount2 = -1, kidscount2 = 0, parentscount2 = 0, Total2 = 0;
            decimal highwaycount3 = 0, saturlandcount3 = 0, regularcount3 = -1, kidscount3 = 0, parentscount3 = 0, Total3 = 0;
            decimal highwaycount4 = 0, saturlandcount4 = 0, regularcount4 = -1, kidscount4 = 0, parentscount4 = 0, Total4 = 0;
            decimal highwaycount5 = 0, saturlandcount5 = 0, regularcount5 = -1, kidscount5 = 0, parentscount5 = 0, Total5 = 0;
            decimal highwaycount6 = 0, saturlandcount6 = 0, regularcount6 = -1, kidscount6 = 0, parentscount6 = 0, Total6 = 0;
            ///////////////////////
            if (ComboBox_SeclectPart.SelectedItem.ToString() == "Water Park - Kiddie Cove")
            {
                TextBox_Search.Clear();
                MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate` FROM `kiddiecove`", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "Fname";
                DataGrid.Columns[1].DataPropertyName = "Lname";
                DataGrid.Columns[2].DataPropertyName = "Visacard";
                DataGrid.Columns[3].DataPropertyName = "KidsTicket";
                DataGrid.Columns[4].DataPropertyName = "ParentsTicket";
                DataGrid.Columns[5].DataPropertyName = "Pricetotal";
                DataGrid.Columns[6].DataPropertyName = "Visitdate";
                DataGrid.DataSource = dt;


                ///-///

                Kindpark.Text = "Water Park";
                Kindzone.Text = "Kiddie Cove";

                
                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                    {
                        highwaycount1 += 1 ;
                    }
                    else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                    {
                        saturlandcount1 += 1 ;
                    }
                    else
                    {
                        regularcount1 += 1;
                    }
 
                }
                vi_Highway.Text = (highwaycount1.ToString() + "  members");
                vi_Saturland.Text = (saturlandcount1.ToString() + "  members");
                vi_Regular.Text = (regularcount1.ToString() + "  members");

                
                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    kidscount1 += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                    parentscount1 += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                    Total1 += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                }
                visit_kids.Text = (kidscount1.ToString() + "  person");
                visit_parents.Text = (parentscount1.ToString() + "  person");
                visit_all.Text = ((kidscount1+parentscount1).ToString() + "  person") ;
                Totalsales.Text = (Total1.ToString() + "  Baht");


                ///-///



                sqlconn.Close();

                
              
            }
            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Water Park - Adults Aqua")
            {
                TextBox_Search.Clear();
                MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate` FROM `adultaqau`", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "Fname";
                DataGrid.Columns[1].DataPropertyName = "Lname";
                DataGrid.Columns[2].DataPropertyName = "Visacard";
                DataGrid.Columns[3].DataPropertyName = "KidsTicket";
                DataGrid.Columns[4].DataPropertyName = "ParentsTicket";
                DataGrid.Columns[5].DataPropertyName = "Pricetotal";
                DataGrid.Columns[6].DataPropertyName = "Visitdate";
                DataGrid.DataSource = dt;


                ///-///

                Kindpark.Text = "Water Park";
                Kindzone.Text = "Adult  Aqua";

                
                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                    {
                        highwaycount2 += 1;
                    }
                    else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                    {
                        saturlandcount2 += 1;
                    }
                    else
                    {
                        regularcount2 += 1;
                    }

                }
                vi_Highway.Text = (highwaycount2.ToString() + "  members");
                vi_Saturland.Text = (saturlandcount2.ToString() + "  members");
                vi_Regular.Text = (regularcount2.ToString() + "  members");

                
                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    kidscount2 += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                    parentscount2 += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                    Total2 += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                }
                visit_kids.Text = (kidscount2.ToString() + "  person");
                visit_parents.Text = (parentscount2.ToString() + "  person");
                visit_all.Text = ((kidscount2 + parentscount2).ToString() + "  person");
                Totalsales.Text = (Total2.ToString() + "  Baht");


                ///-///


                sqlconn.Close();
            }

            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Water Park - Family Zone")
            {
                TextBox_Search.Clear();
                MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate` FROM `familyzone` ", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
               


                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "Fname";
                DataGrid.Columns[1].DataPropertyName = "Lname";
                DataGrid.Columns[2].DataPropertyName = "Visacard";
                DataGrid.Columns[3].DataPropertyName = "KidsTicket";
                DataGrid.Columns[4].DataPropertyName = "ParentsTicket";
                DataGrid.Columns[5].DataPropertyName = "Pricetotal";
                DataGrid.Columns[6].DataPropertyName = "Visitdate";
                
                DataGrid.DataSource = dt;


                ///-///

                Kindpark.Text = "Water Park";
                Kindzone.Text = "Family Zone";

                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                    {
                        highwaycount3 += 1;
                    }
                    else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                    {
                        saturlandcount3 += 1;
                    }
                    else
                    {
                        regularcount3 += 1;
                    }

                }
                vi_Highway.Text = (highwaycount3.ToString() + "  members");
                vi_Saturland.Text = (saturlandcount3.ToString() + "  members");
                vi_Regular.Text = (regularcount3.ToString() + "  members");

                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    kidscount3 += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                    parentscount3 += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                    Total3 += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                }
                visit_kids.Text = (kidscount3.ToString() + "  person");
                visit_parents.Text = (parentscount3.ToString() + "  person");
                visit_all.Text = ((kidscount3 + parentscount3).ToString() + "  person");
                Totalsales.Text = (Total3.ToString() + "  Baht");

                ///-///


                sqlconn.Close();
            }

            ////////////////////////////////////////////////

            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Amazement Park - Kids Funny")
            {
                TextBox_Search.Clear();
                MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate` FROM `kidsfunny`", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                
                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "Fname";
                DataGrid.Columns[1].DataPropertyName = "Lname";
                DataGrid.Columns[2].DataPropertyName = "Visacard";
                DataGrid.Columns[3].DataPropertyName = "KidsTicket";
                DataGrid.Columns[4].DataPropertyName = "ParentsTicket";
                DataGrid.Columns[5].DataPropertyName = "Pricetotal";
                DataGrid.Columns[6].DataPropertyName = "Visitdate";

                DataGrid.DataSource = dt;


                ///-///

                Kindpark.Text = "Amazement Park";
                Kindzone.Text = "Kids Funny";

                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                    {
                        highwaycount4 += 1;
                    }
                    else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                    {
                        saturlandcount4 += 1;
                    }
                    else
                    {
                        regularcount4 += 1;
                    }

                }
                vi_Highway.Text = (highwaycount4.ToString() + "  members");
                vi_Saturland.Text = (saturlandcount4.ToString() + "  members");
                vi_Regular.Text = (regularcount4.ToString() + "  members");

                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    kidscount4 += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                    parentscount4 += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                    Total4 += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                }
                visit_kids.Text = (kidscount4.ToString() + "  person");
                visit_parents.Text = (parentscount4.ToString() + "  person");
                visit_all.Text = ((kidscount4 + parentscount4).ToString() + "  person");
                Totalsales.Text = (Total4.ToString() + "  Baht");


                ///-///


                sqlconn.Close();
            }

            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Amazement Park - Adults Land")
            {
                TextBox_Search.Clear();
                MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate` FROM `adultsland`", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "Fname";
                DataGrid.Columns[1].DataPropertyName = "Lname";
                DataGrid.Columns[2].DataPropertyName = "Visacard";
                DataGrid.Columns[3].DataPropertyName = "KidsTicket";
                DataGrid.Columns[4].DataPropertyName = "ParentsTicket";
                DataGrid.Columns[5].DataPropertyName = "Pricetotal";
                DataGrid.Columns[6].DataPropertyName = "Visitdate";
                DataGrid.DataSource = dt;


                ///-///

                Kindpark.Text = "Amazement Park";
                Kindzone.Text = "Adults Land";

                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                    {
                        highwaycount5 += 1;
                    }
                    else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                    {
                        saturlandcount5 += 1;
                    }
                    else
                    {
                        regularcount5 += 1;
                    }

                }
                vi_Highway.Text = (highwaycount5.ToString() + "  members");
                vi_Saturland.Text = (saturlandcount5.ToString() + "  members");
                vi_Regular.Text = (regularcount5.ToString() + "  members");

                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    kidscount5 += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                    parentscount5 += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                    Total5 += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                }
                visit_kids.Text = (kidscount5.ToString() + "  person");
                visit_parents.Text = (parentscount5.ToString() + "  person");
                visit_all.Text = ((kidscount5 + parentscount5).ToString() + "  person");
                Totalsales.Text = (Total5.ToString() + "  Baht");


                ///-///


                sqlconn.Close();
            }

            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Amazement Park - Adventure Zone")
            {
                TextBox_Search.Clear();
                MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate` FROM `adventurezone`", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();


                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "Fname";
                DataGrid.Columns[1].DataPropertyName = "Lname";
                DataGrid.Columns[2].DataPropertyName = "Visacard";
                DataGrid.Columns[3].DataPropertyName = "KidsTicket";
                DataGrid.Columns[4].DataPropertyName = "ParentsTicket";
                DataGrid.Columns[5].DataPropertyName = "Pricetotal";
                DataGrid.Columns[6].DataPropertyName = "Visitdate";
                DataGrid.DataSource = dt;


                ///-///

                Kindpark.Text = "Amazement Park";
                Kindzone.Text = "Adventure Zone";

                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                    {
                        highwaycount6 += 1;
                    }
                    else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                    {
                        saturlandcount6 += 1;
                    }
                    else
                    {
                        regularcount6 += 1;
                    }

                }
                vi_Highway.Text = (highwaycount6.ToString() + "  members");
                vi_Saturland.Text = (saturlandcount6.ToString() + "  members");
                vi_Regular.Text = (regularcount6.ToString() + "  members");

                for (int i = 0; i < DataGrid.Rows.Count; i++)
                {
                    kidscount6 += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                    parentscount6 += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                    Total6 += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                }
                visit_kids.Text = (kidscount6.ToString() + "  person");
                visit_parents.Text = (parentscount6.ToString() + "  person");
                visit_all.Text = ((kidscount6 + parentscount6).ToString() + "  person");
                Totalsales.Text = (Total6.ToString() + "  Baht");
                

                ///-///


                sqlconn.Close();
            }
            else
            {
                MessageBox.Show("Please Try Again");
            }

            ///
            sqlconn.Open();

            decimal count_highwayregis = 0, count_saturlandregis = 0, count_annualadventureregis = 0, countall = 0; ;  //decimal count_all = 0;
            
            using (var command = new MySqlCommand("SELECT COUNT(*) FROM highwayregis", sqlconn))
            {
                count_highwayregis = (Convert.ToInt32(command.ExecuteScalar())) * 1000 ;
            }
            using (var command = new MySqlCommand("SELECT COUNT(*) FROM saturlandregis", sqlconn))
            {
                count_saturlandregis = (Convert.ToInt32(command.ExecuteScalar())) * 2000;
            }
            using (var command = new MySqlCommand("SELECT COUNT(*) FROM annualadventureregis ", sqlconn))
            {
                count_annualadventureregis = (Convert.ToInt32(command.ExecuteScalar())) * 6999;
            }

            countall = count_highwayregis + count_saturlandregis + count_annualadventureregis;

            //Membershipsum.Text = (( Total1 + Total2 + Total3 + Total4 + Total5 + Total6 + countall).ToString() +  "  Baht");

            decimal sum_kidsfunny = 0, sum_kiddiecove = 0, sum_adultaqau = 0, sum_adultsland = 0, sum_familyzone = 0, sum_adventurezone = 0 , countsum = 0 ;
            using (var command = new MySqlCommand("SELECT SUM(Pricetotal) FROM kidsfunny", sqlconn))
            {
                sum_kidsfunny = (Convert.ToInt32(command.ExecuteScalar()));
            }

            using (var command = new MySqlCommand("SELECT SUM(Pricetotal) FROM kiddiecove", sqlconn))
            {
                sum_kiddiecove = (Convert.ToInt32(command.ExecuteScalar()));
            }

            using (var command = new MySqlCommand("SELECT SUM(Pricetotal) FROM adultaqau", sqlconn))
            {
                sum_adultaqau = (Convert.ToInt32(command.ExecuteScalar()));
            }

            using (var command = new MySqlCommand("SELECT SUM(Pricetotal) FROM adultsland", sqlconn))
            {
                sum_adultsland = (Convert.ToInt32(command.ExecuteScalar()));
            }

            using (var command = new MySqlCommand("SELECT SUM(Pricetotal) FROM familyzone", sqlconn))
            {
                sum_familyzone = (Convert.ToInt32(command.ExecuteScalar()));
            }

            using (var command = new MySqlCommand("SELECT SUM(Pricetotal) FROM adventurezone", sqlconn))
            {
                sum_adventurezone = (Convert.ToInt32(command.ExecuteScalar()));
            }

            countsum = sum_kidsfunny + sum_kiddiecove + sum_adultaqau + sum_adultsland + sum_familyzone + sum_adventurezone;


            sumtotal.Text = (countsum.ToString() + "  Baht");
            Membershipsum.Text = (countall.ToString() + "  Baht");

            Alltotal.Text = ((countall + countsum).ToString() + "  Baht");
            sqlconn.Close();
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
         
        private void TextBox_Search_TextChanged(object sender, EventArgs e) //Search
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            sqlconn.Open();
            if (ComboBox_SeclectPart.SelectedItem == null)
            {

                MessageBox.Show("Please select your visa card");
                return;
            }
            if (ComboBox_SeclectPart.SelectedItem.ToString() == "Water Park - Kiddie Cove")
            {
                //MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate`,`imgPaid` FROM `kiddiecove` WHERE Fname = '" + TextBox_Search.Text + "'", sqlconn);
                MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate`,`imgPaid` FROM `kiddiecove` WHERE Fname like '"+TextBox_Search.Text+"%'", sqlconn);

                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "Fname";
                DataGrid.Columns[1].DataPropertyName = "Lname";
                DataGrid.Columns[2].DataPropertyName = "Visacard";
                DataGrid.Columns[3].DataPropertyName = "KidsTicket";
                DataGrid.Columns[4].DataPropertyName = "ParentsTicket";
                DataGrid.Columns[5].DataPropertyName = "Pricetotal";
                DataGrid.Columns[6].DataPropertyName = "Visitdate";

                DataGrid.DataSource = dt;
                sqlconn.Close();
            }
            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Water Park - Adults Aqua")
            {
                MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate`,`imgPaid` FROM `adultaqau` WHERE Fname like '" + TextBox_Search.Text + "%'", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "Fname";
                DataGrid.Columns[1].DataPropertyName = "Lname";
                DataGrid.Columns[2].DataPropertyName = "Visacard";
                DataGrid.Columns[3].DataPropertyName = "KidsTicket";
                DataGrid.Columns[4].DataPropertyName = "ParentsTicket";
                DataGrid.Columns[5].DataPropertyName = "Pricetotal";
                DataGrid.Columns[6].DataPropertyName = "Visitdate";

                DataGrid.DataSource = dt;
                sqlconn.Close();
            }

            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Water Park - Family Zone")
            {
                MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate`,`imgPaid` FROM `familyzone` WHERE Fname like '" + TextBox_Search.Text + "%'", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "Fname";
                DataGrid.Columns[1].DataPropertyName = "Lname";
                DataGrid.Columns[2].DataPropertyName = "Visacard";
                DataGrid.Columns[3].DataPropertyName = "KidsTicket";
                DataGrid.Columns[4].DataPropertyName = "ParentsTicket";
                DataGrid.Columns[5].DataPropertyName = "Pricetotal";
                DataGrid.Columns[6].DataPropertyName = "Visitdate";

                DataGrid.DataSource = dt;
                sqlconn.Close();
            }
            /////////////////////////////////////////////////////////////
            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Amazement Park - Kids Funny")
            {
                MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate`,`imgPaid` FROM `kidsfunny` WHERE Fname like '" + TextBox_Search.Text + "%'", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "Fname";
                DataGrid.Columns[1].DataPropertyName = "Lname";
                DataGrid.Columns[2].DataPropertyName = "Visacard";
                DataGrid.Columns[3].DataPropertyName = "KidsTicket";
                DataGrid.Columns[4].DataPropertyName = "ParentsTicket";
                DataGrid.Columns[5].DataPropertyName = "Pricetotal";
                DataGrid.Columns[6].DataPropertyName = "Visitdate";
                //DataGrid.Columns[7].DataPropertyName = "imgPaid";

                DataGrid.DataSource = dt;
                sqlconn.Close();
            }

            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Amazement Park - Adults Land")
            {
                MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate`,`imgPaid` FROM `adultsland` WHERE Fname like '" + TextBox_Search.Text + "%'", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "Fname";
                DataGrid.Columns[1].DataPropertyName = "Lname";
                DataGrid.Columns[2].DataPropertyName = "Visacard";
                DataGrid.Columns[3].DataPropertyName = "KidsTicket";
                DataGrid.Columns[4].DataPropertyName = "ParentsTicket";
                DataGrid.Columns[5].DataPropertyName = "Pricetotal";
                DataGrid.Columns[6].DataPropertyName = "Visitdate";
                //DataGrid.Columns[7].DataPropertyName = "imgPaid";

                DataGrid.DataSource = dt;
                sqlconn.Close();
            }

            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Amazement Park - Adventure Zone")
            {
                MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate`,`imgPaid` FROM `adventurezone` WHERE Fname like '" + TextBox_Search.Text + "%'", sqlconn);
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dt);
                DataGrid.AutoGenerateColumns = false;
                DataGrid.Columns[0].DataPropertyName = "Fname";
                DataGrid.Columns[1].DataPropertyName = "Lname";
                DataGrid.Columns[2].DataPropertyName = "Visacard";
                DataGrid.Columns[3].DataPropertyName = "KidsTicket";
                DataGrid.Columns[4].DataPropertyName = "ParentsTicket";
                DataGrid.Columns[5].DataPropertyName = "Pricetotal";
                DataGrid.Columns[6].DataPropertyName = "Visitdate";
                //DataGrid.Columns[7].DataPropertyName = "imgPaid";

                DataGrid.DataSource = dt;
                sqlconn.Close();
            }
            else
            {
                MessageBox.Show("Please Try Again");
            }


        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TextBox_Search_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            int selectedRow = DataGrid.CurrentCell.RowIndex ;

            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            sqlconn.Open();


            if (ComboBox_SeclectPart.SelectedItem == null)
            {
                TextBox_Search.Clear();
                MessageBox.Show("Please select your visa card");
                return;
            }

            if (ComboBox_SeclectPart.SelectedItem.ToString() == "Water Park - Kiddie Cove")
            {
                TextBox_Search.Clear();

                DialogResult dialogResult = MessageBox.Show("Do you want to DELETE this member?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = DataGrid.CurrentCell.RowIndex;
                    string ffname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[0].Value);
                    DataGrid.Rows.RemoveAt(rowIndex);

                    string Sql = "DELETE FROM kiddiecove WHERE Fname = '" + ffname + "'";

                    MySqlCommand cmd = new MySqlCommand(Sql, sqlconn);
                    int rows = cmd.ExecuteNonQuery();

                    sqlconn.Close();
                    if (rows > 0)
                    {
                        Kindpark.Text = "Water Park";
                        Kindzone.Text = "Kiddie Cove";

                        decimal highwaycount = 0, saturlandcount = 0, regularcount = -1;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                            {
                                highwaycount += 1;
                            }
                            else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                            {
                                saturlandcount += 1;
                            }
                            else
                            {
                                regularcount += 1;
                            }

                        }
                        vi_Highway.Text = (highwaycount.ToString() + "  members");
                        vi_Saturland.Text = (saturlandcount.ToString() + "  members");
                        vi_Regular.Text = (regularcount.ToString() + "  members");

                        decimal kidscount = 0, parentscount = 0, Total = 0;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            kidscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                            parentscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                            Total += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                        }
                        visit_kids.Text = (kidscount.ToString() + "  person");
                        visit_parents.Text = (parentscount.ToString() + "  person");
                        visit_all.Text = ((kidscount + parentscount).ToString() + "  person");
                        Totalsales.Text = (Total.ToString() + "  Baht");

                        MessageBox.Show("Succesfully Delete");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                }


            }
            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Water Park - Adults Aqua")
            {
                TextBox_Search.Clear();

                DialogResult dialogResult = MessageBox.Show("Do you want to DELETE this member?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = DataGrid.CurrentCell.RowIndex;
                    string ffname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[0].Value);
                    DataGrid.Rows.RemoveAt(rowIndex);
                    string Sql = "DELETE FROM adultaqau WHERE Fname = '" + ffname + "'";

                    MySqlCommand cmd = new MySqlCommand(Sql, sqlconn);
                    int rows = cmd.ExecuteNonQuery();

                    sqlconn.Close();
                    if (rows > 0)
                    {
                        Kindpark.Text = "Water Park";
                        Kindzone.Text = "Adults Aqua";

                        decimal highwaycount = 0, saturlandcount = 0, regularcount = -1;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                            {
                                highwaycount += 1;
                            }
                            else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                            {
                                saturlandcount += 1;
                            }
                            else
                            {
                                regularcount += 1;
                            }

                        }
                        vi_Highway.Text = (highwaycount.ToString() + "  members");
                        vi_Saturland.Text = (saturlandcount.ToString() + "  members");
                        vi_Regular.Text = (regularcount.ToString() + "  members");

                        decimal kidscount = 0, parentscount = 0, Total = 0;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            kidscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                            parentscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                            Total += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                        }
                        visit_kids.Text = (kidscount.ToString() + "  person");
                        visit_parents.Text = (parentscount.ToString() + "  person");
                        visit_all.Text = ((kidscount + parentscount).ToString() + "  person");
                        Totalsales.Text = (Total.ToString() + "  Baht");
                        MessageBox.Show("Succesfully Delete");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                }


            }
            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Water Park - Family Zone")
            {
                TextBox_Search.Clear();

                DialogResult dialogResult = MessageBox.Show("Do you want to DELETE this member?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = DataGrid.CurrentCell.RowIndex;
                    string ffname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[0].Value);
                    DataGrid.Rows.RemoveAt(rowIndex);
                    string Sql = "DELETE FROM familyzone WHERE Fname = '" + ffname + "'";

                    MySqlCommand cmd = new MySqlCommand(Sql, sqlconn);
                    int rows = cmd.ExecuteNonQuery();

                    sqlconn.Close();
                    if (rows > 0)
                    {
                        Kindpark.Text = "Water Park";
                        Kindzone.Text = "Family Zone";

                        decimal highwaycount = 0, saturlandcount = 0, regularcount = -1;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                            {
                                highwaycount += 1;
                            }
                            else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                            {
                                saturlandcount += 1;
                            }
                            else
                            {
                                regularcount += 1;
                            }

                        }
                        vi_Highway.Text = (highwaycount.ToString() + "  members");
                        vi_Saturland.Text = (saturlandcount.ToString() + "  members");
                        vi_Regular.Text = (regularcount.ToString() + "  members");

                        decimal kidscount = 0, parentscount = 0, Total = 0;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            kidscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                            parentscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                            Total += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                        }
                        visit_kids.Text = (kidscount.ToString() + "  person");
                        visit_parents.Text = (parentscount.ToString() + "  person");
                        Totalsales.Text = (Total.ToString() + "  Baht");
                        visit_all.Text = ((kidscount + parentscount).ToString() + "  person");
                        MessageBox.Show("Succesfully Delete");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                }


            }
            ////////////////////////////////////////////////
            ///

            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Amazement Park - Kids Funny")
            {
                TextBox_Search.Clear();

                DialogResult dialogResult = MessageBox.Show("Do you want to DELETE this member?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = DataGrid.CurrentCell.RowIndex;
                    string ffname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[0].Value);
                    DataGrid.Rows.RemoveAt(rowIndex);
                    string Sql = "DELETE FROM kidsfunny WHERE Fname = '" + ffname + "'";

                    MySqlCommand cmd = new MySqlCommand(Sql, sqlconn);
                    int rows = cmd.ExecuteNonQuery();

                    sqlconn.Close();
                    if (rows > 0)
                    {
                        Kindpark.Text = "Amazement Park";
                        Kindzone.Text = "Kids Funny";

                        decimal highwaycount = 0, saturlandcount = 0, regularcount = -1;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                            {
                                highwaycount += 1;
                            }
                            else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                            {
                                saturlandcount += 1;
                            }
                            else
                            {
                                regularcount += 1;
                            }

                        }
                        vi_Highway.Text = (highwaycount.ToString() + "  members");
                        vi_Saturland.Text = (saturlandcount.ToString() + "  members");
                        vi_Regular.Text = (regularcount.ToString() + "  members");

                        decimal kidscount = 0, parentscount = 0, Total = 0;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            kidscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                            parentscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                            Total += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                        }
                        visit_kids.Text = (kidscount.ToString() + "  person");
                        visit_parents.Text = (parentscount.ToString() + "  person");
                        visit_all.Text = ((kidscount + parentscount).ToString() + "  person");
                        Totalsales.Text = (Total.ToString() + "  Baht");
                        MessageBox.Show("Succesfully Delete");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                }


            }
            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Amazement Park - Adults Land")
            {
                TextBox_Search.Clear();

                DialogResult dialogResult = MessageBox.Show("Do you want to DELETE this member?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = DataGrid.CurrentCell.RowIndex;
                    string ffname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[0].Value);
                    DataGrid.Rows.RemoveAt(rowIndex);
                    string Sql = "DELETE FROM adultsland WHERE Fname = '" + ffname + "'";

                    MySqlCommand cmd = new MySqlCommand(Sql, sqlconn);
                    int rows = cmd.ExecuteNonQuery();

                    sqlconn.Close();
                    if (rows > 0)
                    {
                        Kindpark.Text = "Amazement Park";
                        Kindzone.Text = "Adults Land";

                        decimal highwaycount = 0, saturlandcount = 0, regularcount = -1;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                            {
                                highwaycount += 1;
                            }
                            else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                            {
                                saturlandcount += 1;
                            }
                            else
                            {
                                regularcount += 1;
                            }

                        }
                        vi_Highway.Text = (highwaycount.ToString() + "  members");
                        vi_Saturland.Text = (saturlandcount.ToString() + "  members");
                        vi_Regular.Text = (regularcount.ToString() + "  members");

                        decimal kidscount = 0, parentscount = 0, Total = 0;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            kidscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                            parentscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                            Total += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                        }
                        visit_kids.Text = (kidscount.ToString() + "  person");
                        visit_parents.Text = (parentscount.ToString() + "  person");
                        visit_all.Text = ((kidscount + parentscount).ToString() + "  person");
                        Totalsales.Text = (Total.ToString() + "  Baht");
                        MessageBox.Show("Succesfully Delete");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                }


            }
            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Amazement Park - Adventure Zone")
            {
                TextBox_Search.Clear();

                DialogResult dialogResult = MessageBox.Show("Do you want to DELETE this member?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = DataGrid.CurrentCell.RowIndex;
                    string ffname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[0].Value);
                    DataGrid.Rows.RemoveAt(rowIndex);
                    string Sql = "DELETE FROM adventurezone WHERE Fname = '" + ffname + "'";

                    MySqlCommand cmd = new MySqlCommand(Sql, sqlconn);
                    int rows = cmd.ExecuteNonQuery();

                    sqlconn.Close();
                    if (rows > 0)
                    {
                        Kindpark.Text = "Amazement Park";
                        Kindzone.Text = "Adventure Zone";

                        decimal highwaycount = 0, saturlandcount = 0, regularcount = -1;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                            {
                                highwaycount += 1;
                            }
                            else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                            {
                                saturlandcount += 1;
                            }
                            else
                            {
                                regularcount += 1;
                            }

                        }
                        vi_Highway.Text = (highwaycount.ToString() + "  members");
                        vi_Saturland.Text = (saturlandcount.ToString() + "  members");
                        vi_Regular.Text = (regularcount.ToString() + "  members");

                        decimal kidscount = 0, parentscount = 0, Total = 0;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            kidscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                            parentscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                            Total += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                        }
                        visit_kids.Text = (kidscount.ToString() + "  person");
                        visit_parents.Text = (parentscount.ToString() + "  person");
                        visit_all.Text = ((kidscount + parentscount).ToString() + "  person");
                        Totalsales.Text = (Total.ToString() + "  Baht");
                        MessageBox.Show("Succesfully Delete");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                }


            }

        }

        private void Button_Update_Click(object sender, EventArgs e)
        {
            int selectedRow = DataGrid.CurrentCell.RowIndex;

            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            sqlconn.Open();


            if (ComboBox_SeclectPart.SelectedItem == null)
            {
                TextBox_Search.Clear();
                MessageBox.Show("Please select your visa card");
                return;
            }

            if (ComboBox_SeclectPart.SelectedItem.ToString() == "Water Park - Kiddie Cove")
            {
                TextBox_Search.Clear();

                DialogResult dialogResult = MessageBox.Show("Do you want to UPDATE this member?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = DataGrid.CurrentCell.RowIndex;
                    string ffname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[0].Value);
                    string llname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[1].Value);
                    string vvisa = Convert.ToString(DataGrid.Rows[selectedRow].Cells[2].Value);
                    string kkids = Convert.ToString(DataGrid.Rows[selectedRow].Cells[3].Value);
                    string pparents = Convert.ToString(DataGrid.Rows[selectedRow].Cells[4].Value);
                    string pprice = Convert.ToString(DataGrid.Rows[selectedRow].Cells[5].Value);
                    string vvisit = Convert.ToString(DataGrid.Rows[selectedRow].Cells[6].Value);
                    //string iimage = Convert.ToString(DataGrid.Rows[selectedRow].Cells[7].Value);
                    //DataGrid.Rows.RemoveAt(rowIndex);
                    string Sql = "UPDATE kiddiecove SET Fname ='" + ffname + "',Lname ='" + llname + "',Visacard ='" + vvisa + "',KidsTicket ='" + kkids + "',ParentsTicket ='" + pparents + "',Pricetotal ='" + pprice + "',Visitdate ='" + vvisit + "' WHERE Fname = '" + ffname + "'";

                    MySqlCommand cmd = new MySqlCommand(Sql, sqlconn);
                    int rows = cmd.ExecuteNonQuery();

                    sqlconn.Close();
                    if (rows > 0)      
                    {
                        Kindpark.Text = "Water Park";
                        Kindzone.Text = "Kiddie Cove";

                        decimal highwaycount = 0, saturlandcount = 0, regularcount = -1;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                            {
                                highwaycount += 1;
                            }
                            else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                            {
                                saturlandcount += 1;
                            }
                            else
                            {
                                regularcount += 1;
                            }

                        }
                        vi_Highway.Text = (highwaycount.ToString() + "  members");
                        vi_Saturland.Text = (saturlandcount.ToString() + "  members");
                        vi_Regular.Text = (regularcount.ToString() + "  members");

                        decimal kidscount = 0, parentscount = 0, Total = 0;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            kidscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                            parentscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                            Total += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                        }
                        visit_kids.Text = (kidscount.ToString() + "  person");
                        visit_parents.Text = (parentscount.ToString() + "  person");
                        visit_all.Text = ((kidscount + parentscount).ToString() + "  person");
                        Totalsales.Text = (Total.ToString() + "  Baht");
                        MessageBox.Show("Succesfully Update");
                    }
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                }

            }

            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Water Park - Adults Aqua")
            {
                TextBox_Search.Clear();

                DialogResult dialogResult = MessageBox.Show("Do you want to UPDATE this member?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = DataGrid.CurrentCell.RowIndex;
                    string ffname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[0].Value);
                    string llname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[1].Value);
                    string vvisa = Convert.ToString(DataGrid.Rows[selectedRow].Cells[2].Value);
                    string kkids = Convert.ToString(DataGrid.Rows[selectedRow].Cells[3].Value);
                    string pparents = Convert.ToString(DataGrid.Rows[selectedRow].Cells[4].Value);
                    string pprice = Convert.ToString(DataGrid.Rows[selectedRow].Cells[5].Value);
                    string vvisit = Convert.ToString(DataGrid.Rows[selectedRow].Cells[6].Value);
                    
                    //DataGrid.Rows.RemoveAt(rowIndex);
                    string Sql = "UPDATE adultaqau SET Fname ='" + ffname + "',Lname ='" + llname + "',Visacard ='" + vvisa + "',KidsTicket ='" + kkids + "',ParentsTicket ='" + pparents + "',Pricetotal ='" + pprice + "',Visitdate ='" + vvisit + "' WHERE Fname = '" + ffname + "'";

                    MySqlCommand cmd = new MySqlCommand(Sql, sqlconn);
                    int rows = cmd.ExecuteNonQuery();

                    sqlconn.Close();
                    if (rows > 0)
                    {
                        Kindpark.Text = "Water Park";
                        Kindzone.Text = "Adult Aqua";

                        decimal highwaycount = 0, saturlandcount = 0, regularcount = -1;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                            {
                                highwaycount += 1;
                            }
                            else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                            {
                                saturlandcount += 1;
                            }
                            else
                            {
                                regularcount += 1;
                            }

                        }
                        vi_Highway.Text = (highwaycount.ToString() + "  members");
                        vi_Saturland.Text = (saturlandcount.ToString() + "  members");
                        vi_Regular.Text = (regularcount.ToString() + "  members");

                        decimal kidscount = 0, parentscount = 0, Total = 0;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            kidscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                            parentscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                            Total += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                        }
                        visit_kids.Text = (kidscount.ToString() + "  person");
                        visit_parents.Text = (parentscount.ToString() + "  person");
                        visit_all.Text = ((kidscount + parentscount).ToString() + "  person");
                        Totalsales.Text = (Total.ToString() + "  Baht");
                        MessageBox.Show("Succesfully Update");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                }

            }

            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Water Park - Family Zone")
            {
                TextBox_Search.Clear();

                DialogResult dialogResult = MessageBox.Show("Do you want to UPDATE this member?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = DataGrid.CurrentCell.RowIndex;
                    string ffname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[0].Value);
                    string llname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[1].Value);
                    string vvisa = Convert.ToString(DataGrid.Rows[selectedRow].Cells[2].Value);
                    string kkids = Convert.ToString(DataGrid.Rows[selectedRow].Cells[3].Value);
                    string pparents = Convert.ToString(DataGrid.Rows[selectedRow].Cells[4].Value);
                    string pprice = Convert.ToString(DataGrid.Rows[selectedRow].Cells[5].Value);
                    string vvisit = Convert.ToString(DataGrid.Rows[selectedRow].Cells[6].Value);
                    //DataGrid.Rows.RemoveAt(rowIndex);
                    string Sql = "UPDATE familyzone SET Fname ='" + ffname + "',Lname ='" + llname + "',Visacard ='" + vvisa + "',KidsTicket ='" + kkids + "',ParentsTicket ='" + pparents + "',Pricetotal ='" + pprice + "',Visitdate ='" + vvisit +"' WHERE Fname = '" + ffname + "'";

                    MySqlCommand cmd = new MySqlCommand(Sql, sqlconn);
                    int rows = cmd.ExecuteNonQuery();

                    sqlconn.Close();
                    if (rows > 0)
                    {
                        Kindpark.Text = "Water Park";
                        Kindzone.Text = "Family Zone";

                        decimal highwaycount = 0, saturlandcount = 0, regularcount = -1;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                            {
                                highwaycount += 1;
                            }
                            else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                            {
                                saturlandcount += 1;
                            }
                            else
                            {
                                regularcount += 1;
                            }

                        }
                        vi_Highway.Text = (highwaycount.ToString() + "  members");
                        vi_Saturland.Text = (saturlandcount.ToString() + "  members");
                        vi_Regular.Text = (regularcount.ToString() + "  members");

                        decimal kidscount = 0, parentscount = 0, Total = 0;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            kidscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                            parentscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                            Total += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                        }
                        visit_kids.Text = (kidscount.ToString() + "  person");
                        visit_parents.Text = (parentscount.ToString() + "  person");
                        visit_all.Text = ((kidscount + parentscount).ToString() + "  person");
                        Totalsales.Text = (Total.ToString() + "  Baht");
                        MessageBox.Show("Succesfully Update");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                }

            }
            //////////////////////////////////////////////
            ///
            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Amazement Park - Kids Funny")
            {
                TextBox_Search.Clear();

                DialogResult dialogResult = MessageBox.Show("Do you want to UPDATE this member?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = DataGrid.CurrentCell.RowIndex;
                    string ffname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[0].Value);
                    string llname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[1].Value);
                    string vvisa = Convert.ToString(DataGrid.Rows[selectedRow].Cells[2].Value);
                    string kkids = Convert.ToString(DataGrid.Rows[selectedRow].Cells[3].Value);
                    string pparents = Convert.ToString(DataGrid.Rows[selectedRow].Cells[4].Value);
                    string pprice = Convert.ToString(DataGrid.Rows[selectedRow].Cells[5].Value);
                    string vvisit = Convert.ToString(DataGrid.Rows[selectedRow].Cells[6].Value);
                    //string iimage = Convert.ToString(DataGrid.Rows[selectedRow].Cells[7].Value);
                    //DataGrid.Rows.RemoveAt(rowIndex);
                    string Sql = "UPDATE kidsfunny SET Fname ='" + ffname + "',Lname ='" + llname + "',Visacard ='" + vvisa + "',KidsTicket ='" + kkids + "',ParentsTicket ='" + pparents + "',Pricetotal ='" + pprice + "',Visitdate ='" + vvisit + "' WHERE Fname = '" + ffname + "'";

                    MySqlCommand cmd = new MySqlCommand(Sql, sqlconn);
                    int rows = cmd.ExecuteNonQuery();

                    sqlconn.Close();
                    if (rows > 0)
                    {
                        Kindpark.Text = "Amazement Park";
                        Kindzone.Text = "Kids Funny";

                        decimal highwaycount = 0, saturlandcount = 0, regularcount = -1;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                            {
                                highwaycount += 1;
                            }
                            else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                            {
                                saturlandcount += 1;
                            }
                            else
                            {
                                regularcount += 1;
                            }

                        }
                        vi_Highway.Text = (highwaycount.ToString() + "  members");
                        vi_Saturland.Text = (saturlandcount.ToString() + "  members");
                        vi_Regular.Text = (regularcount.ToString() + "  members");

                        decimal kidscount = 0, parentscount = 0, Total = 0;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            kidscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                            parentscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                            Total += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                        }
                        visit_kids.Text = (kidscount.ToString() + "  person");
                        visit_parents.Text = (parentscount.ToString() + "  person");
                        visit_all.Text = ((kidscount + parentscount).ToString() + "  person");
                        Totalsales.Text = (Total.ToString() + "  Baht");
                        MessageBox.Show("Succesfully Update");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                }

            }

            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Amazement Park - Adults Land")
            {
                TextBox_Search.Clear();

                DialogResult dialogResult = MessageBox.Show("Do you want to UPDATE this member?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = DataGrid.CurrentCell.RowIndex;
                    string ffname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[0].Value);
                    string llname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[1].Value);
                    string vvisa = Convert.ToString(DataGrid.Rows[selectedRow].Cells[2].Value);
                    string kkids = Convert.ToString(DataGrid.Rows[selectedRow].Cells[3].Value);
                    string pparents = Convert.ToString(DataGrid.Rows[selectedRow].Cells[4].Value);
                    string pprice = Convert.ToString(DataGrid.Rows[selectedRow].Cells[5].Value);
                    string vvisit = Convert.ToString(DataGrid.Rows[selectedRow].Cells[6].Value);
                    //string iimage = Convert.ToString(DataGrid.Rows[selectedRow].Cells[7].Value);
                    //DataGrid.Rows.RemoveAt(rowIndex);
                    string Sql = "UPDATE adultsland SET Fname ='" + ffname + "',Lname ='" + llname + "',Visacard ='" + vvisa + "',KidsTicket ='" + kkids + "',ParentsTicket ='" + pparents + "',Pricetotal ='" + pprice + "',Visitdate ='" + vvisit + "' WHERE Fname = '" + ffname + "'";

                    MySqlCommand cmd = new MySqlCommand(Sql, sqlconn);
                    int rows = cmd.ExecuteNonQuery();

                    sqlconn.Close();
                    if (rows > 0)
                    {
                        Kindpark.Text = "Amazement Park";
                        Kindzone.Text = "Adults Land";

                        decimal highwaycount = 0, saturlandcount = 0, regularcount = -1;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                            {
                                highwaycount += 1;
                            }
                            else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                            {
                                saturlandcount += 1;
                            }
                            else
                            {
                                regularcount += 1;
                            }

                        }
                        vi_Highway.Text = (highwaycount.ToString() + "  members");
                        vi_Saturland.Text = (saturlandcount.ToString() + "  members");
                        vi_Regular.Text = (regularcount.ToString() + "  members");

                        decimal kidscount = 0, parentscount = 0, Total = 0;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            kidscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                            parentscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                            Total += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                        }
                        visit_kids.Text = (kidscount.ToString() + "  person");
                        visit_parents.Text = (parentscount.ToString() + "  person");
                        visit_all.Text = ((kidscount + parentscount).ToString() + "  person");
                        Totalsales.Text = (Total.ToString() + "  Baht");
                        MessageBox.Show("Succesfully Update");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                }

            }
            else if (ComboBox_SeclectPart.SelectedItem.ToString() == "Amazement Park - Adventure Zone")
            {
                TextBox_Search.Clear();

                DialogResult dialogResult = MessageBox.Show("Do you want to UPDATE this member?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rowIndex = DataGrid.CurrentCell.RowIndex;
                    string ffname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[0].Value);
                    string llname = Convert.ToString(DataGrid.Rows[selectedRow].Cells[1].Value);
                    string vvisa = Convert.ToString(DataGrid.Rows[selectedRow].Cells[2].Value);
                    string kkids = Convert.ToString(DataGrid.Rows[selectedRow].Cells[3].Value);
                    string pparents = Convert.ToString(DataGrid.Rows[selectedRow].Cells[4].Value);
                    string pprice = Convert.ToString(DataGrid.Rows[selectedRow].Cells[5].Value);
                    string vvisit = Convert.ToString(DataGrid.Rows[selectedRow].Cells[6].Value);
                    //string iimage = Convert.ToString(DataGrid.Rows[selectedRow].Cells[7].Value);
                    //DataGrid.Rows.RemoveAt(rowIndex);
                    string Sql = "UPDATE adventurezone SET Fname ='" + ffname + "',Lname ='" + llname + "',Visacard ='" + vvisa + "',KidsTicket ='" + kkids + "',ParentsTicket ='" + pparents + "',Pricetotal ='" + pprice + "',Visitdate ='" + vvisit + "' WHERE Fname = '" + ffname + "'";

                    MySqlCommand cmd = new MySqlCommand(Sql, sqlconn);
                    int rows = cmd.ExecuteNonQuery();

                    sqlconn.Close();
                    if (rows > 0)
                    {
                        Kindpark.Text = "Amazement Park";
                        Kindzone.Text = "Adventure Zone";

                        decimal highwaycount = 0, saturlandcount = 0, regularcount = -1;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Highway Visa Card")
                            {
                                highwaycount += 1;
                            }
                            else if (Convert.ToString(DataGrid.Rows[i].Cells[2].Value) == "Saturland Visa Card")
                            {
                                saturlandcount += 1;
                            }
                            else
                            {
                                regularcount += 1;
                            }

                        }
                        vi_Highway.Text = (highwaycount.ToString() + "  members");
                        vi_Saturland.Text = (saturlandcount.ToString() + "  members");
                        vi_Regular.Text = (regularcount.ToString() + "  members");

                        decimal kidscount = 0, parentscount = 0, Total = 0;
                        for (int i = 0; i < DataGrid.Rows.Count; i++)
                        {
                            kidscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[3].Value);
                            parentscount += Convert.ToDecimal(DataGrid.Rows[i].Cells[4].Value);
                            Total += Convert.ToDecimal(DataGrid.Rows[i].Cells[5].Value);
                        }
                        visit_kids.Text = (kidscount.ToString() + "  person");
                        visit_parents.Text = (parentscount.ToString() + "  person");
                        visit_all.Text = ((kidscount + parentscount).ToString() + "  person");
                        Totalsales.Text = (Total.ToString() + "  Baht");
                        MessageBox.Show("Succesfully Update");
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                }

            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            
            /*
            MySqlCommand command = new MySqlCommand("SELECT `Fname`,`Lname`,`Visacard`,`KidsTicket`,`ParentsTicket`,`Pricetotal`,`Visitdate` FROM `kiddiecove`", sqlconn);
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            */


        }

        private void pictureBox_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Home home = new Home();
            home.Show();
        }

        private void vi_Highway_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_righttback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customer = new Customer();
            customer.Show();
        }
    }
}
