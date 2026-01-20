using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_Managment
{
    public partial class Login : Form
    {
        private static readonly string ConnectionString =
    ConfigurationManager.ConnectionStrings["Football_Managment.Properties.Settings.Soccer_Score_System"].ConnectionString;
        private bool _passwordVisible;
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            this.Hide();
            registration.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text, textBox2.Text);
            string email = textBox1.Text;
            string pass = textBox2.Text;

            SqlCommand cmd;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using(cmd = new SqlCommand("SELECT * FROM users"))
                {

                }
            }

                AdminDashboard adminDashboard = new AdminDashboard();
            this.Hide();
            adminDashboard.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            _passwordVisible = !_passwordVisible;

            textBox2.PasswordChar = _passwordVisible ? '\0' : '*';
            button4.Text = _passwordVisible ? "🙈" : "👁";
        }
    }
}
