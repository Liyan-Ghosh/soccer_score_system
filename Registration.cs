using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Football_Managment
{
    public partial class Registration : Form
    {
        private static readonly string ConnectionString = Program.DbAppName;
        public Registration()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {  
            var name = (textBox1.Text ?? string.Empty).Trim();
            var email = textBox2.Text ?? string.Empty.Trim();
            var phone = (textBox3.Text ?? string.Empty).Trim();
            var password = (textBox4.Text ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }
        

            if (!email.Contains("@") || !email.EndsWith(".com"))
            {
                MessageBox.Show("Invalid Email! Must contain '@' and end with '.com'.");
                textBox2.Focus();
                return;
            }

            if (phone.Length != 11 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Mobile number should be 11 digit.");
                textBox3.Focus();
                return;
            }
            try
            {
                using (var con = new SqlConnection(ConnectionString))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"
INSERT INTO Users (Name, Email,Phone, Password,Type)
VALUES (@Names, @Email, @Contact, @Password,@type);";

                    cmd.Parameters.AddWithValue("@Names", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Contact",phone);
                    cmd.Parameters.AddWithValue("@Password", password);

                    cmd.Parameters.AddWithValue("@type", "MOD");
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Moderator Registration successful. Please login now.");
                var login = new Login();
                login.FormClosed += (s, args) => Close();

                Hide();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration failed.\r\n" + ex.Message);
            }
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
