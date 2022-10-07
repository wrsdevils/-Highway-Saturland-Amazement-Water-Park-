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
    public partial class PaymentWTPKids : Form
    {
        public PaymentWTPKids()
        {
            InitializeComponent();
        }
        string imgLocation = "";

        private void PaymentWTPKids_Load(object sender, EventArgs e)
        {
            Label_KidsAmount.Text = GlobalPayment.First;
            Label_AdultsAmount.Text = GlobalPayment.Second;
            Label_Subtotall.Text = GlobalPayment.Third;
            Label_Discountt.Text = GlobalPayment.Fourth;
            Label_Totall.Text = GlobalPayment.Fifth;
            Label_Namee.Text = "K." + GlobalPayment.Sixth + " " + GlobalPayment.Seventh; ;
            
            label9.Text = GlobalPayment.Sixth;
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

        private void Button_CheckOut_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM kiddiecove WHERE Fname = '" + label9.Text + "' ", sqlconn);


            DataTable dt = new DataTable();
            da.Fill(dt);
            //int i = ds.Tables[0].Rows.Count;
            if (dt.Rows.Count == 1)
            {
                byte[] images = null;
                FileStream streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(streem);
                images = brs.ReadBytes((int)streem.Length);

                sqlconn.Open();
                //MySqlCommand command = new MySqlCommand("INSERT INTO `kidsfunny`(`imgPaid`) VALUES(@images)", sqlconn);
                string updateQuery = "UPDATE kiddiecove SET imgPaid = @images WHERE Fname = '" + label9.Text + "' ";


                //sqlconn.Open();
                try
                {
                    MySqlCommand command = new MySqlCommand(updateQuery, sqlconn);
                    command.Parameters.Add(new MySqlParameter("@images", images));
                    command.ExecuteNonQuery();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Successful Booked!");
                        this.Hide();
                        Main main = new Main();
                        main.Show();
                    }
                    else
                    {
                        MessageBox.Show("Data NOT UPDATED");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlconn.Close();

            }
            else
            {
                MessageBox.Show("Incorrect Data");
            }
        }
    }
}
