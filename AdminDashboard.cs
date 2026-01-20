using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Football_Managment
{

    public partial class AdminDashboard : Form
    {
        private static readonly string ConnectionString = Program.DbAppName;
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageModerator manageModerator = new ManageModerator();
            this.Hide();
            manageModerator.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(ConnectionString))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"SELECT TOP 1 * FROM tournamnets ORDER BY id DESC;";

                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string tournamentName = reader["name"].ToString();
                            string winner = reader["winner"].ToString();
                            int id = Convert.ToInt32(reader["id"]);
                            if (winner == null || winner == "")
                            {
                                MessageBox.Show("A Tournament is already running, You can not create tournament multiple times!", "Tournament Creation Failed!");
                            }
                            else
                            {
                                CreateTournamnet createTournamnet = new CreateTournamnet();
                                this.Hide();
                                createTournamnet.Show();
                            }
                        }
                        else
                        {
                            CreateTournamnet createTournamnet = new CreateTournamnet();
                            this.Hide();
                            createTournamnet.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tournament Creation failed.\r\n" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update_Tournament update_Tournament = new Update_Tournament();
            this.Hide();
         update_Tournament.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Score_Board_ad_Mod score_Board_Ad_Mod = new Score_Board_ad_Mod();

        this.Hide();
            score_Board_Ad_Mod.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void AdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
