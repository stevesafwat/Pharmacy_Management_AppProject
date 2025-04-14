using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Management_System
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public String conString = "Data Source=KARIIMJR;Initial Catalog=pharmacy;Integrated Security=True;TrustServerCertificate=True;";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;

            // Check if username and password are provided
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a connection to the database
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    // Check if the username and password match a record in the database
                    string query = "SELECT COUNT(1) FROM pharmacy_table WHERE username = @username AND password = @password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        // Check the role of the user
                        query = "SELECT role FROM pharmacy_table WHERE username = @username";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@username", username);
                        string role = cmd.ExecuteScalar().ToString();

                        if (role == "Adminstrator")
                        {
                            // Login successful for administrator
                            MessageBox.Show("Login successful as Administrator!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Open the Administrator form
                            Adminstrator admin = new Adminstrator();
                            admin.Show();
                            this.Hide();
                        }
                        else if (role == "Pharmacist")
                        {
                            // Login successful for pharmacist
                            MessageBox.Show("Login successful as Pharmacist!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Open the Pharmacist form
                            Pharmacist1 pharmacist = new Pharmacist1();
                            pharmacist.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Unknown role
                            MessageBox.Show("Unknown role for user. Please contact your administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Invalid username or password
                        MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Clear the password field
                        txtpassword.Clear();
                    }
                }
            }
        }
    }
}
