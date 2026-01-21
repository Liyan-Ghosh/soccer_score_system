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
        private static readonly string ConnectionString = Program.DbAppName;
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
            string email = textBox1.Text;
            string pass = textBox2.Text;
            try
            {
                SqlCommand cmd;
                SqlDataReader data;
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (cmd = new SqlCommand("SELECT * FROM Users ORDER BY id"))
                    {
                        cmd.Connection = conn;
                        data = cmd.ExecuteReader();
                        while (data.Read())
                        {
                            if (Convert.ToString(data.GetValue(2)) == email && Convert.ToString(data.GetValue(4)) == pass)
                            {
                                //this.name = Convert.ToString(data.GetValue(2));
                                //this.balance = Convert.ToDouble(data.GetValue(9));
                                //AgentDashboard agent = new AgentDashboard(user, pass, name, balance);
                                //agent.Show();
                                //isLogin = true;
                                string name = Convert.ToString(data.GetValue(1));
                                string role = Convert.ToString(data.GetValue(5));
                                if (role == "ADMIN")
                                {
                                    AdminDashboard adminDashboard = new AdminDashboard();
                                    adminDashboard.Show();
                                } else if(role == "MOD")
                                {
                                    Moderator_Dashboard moderator_Dashboard = new Moderator_Dashboard();
                                    moderator_Dashboard.Show();
                                }
                                this.Hide();

                                cmd.Dispose();
                                data.Close();
                                conn.Close();
                            }
                        }
                        MessageBox.Show("Email or Password Incorrect!");
                        data.Close();
                    }
                }
            }
           
            catch (SystemException error)
            {
                //
            } 
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

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
