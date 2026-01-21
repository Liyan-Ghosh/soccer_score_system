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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Football_Managment
{
    public partial class CreateTournamnet : Form
    {
        private static readonly string ConnectionString = Program.DbAppName;
        public CreateTournamnet()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminDashboard admindashboard = new AdminDashboard();
            this.Hide();
            admindashboard.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = (textBox1.Text ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Tournament name should not be empty!");
                return;
            }

            try
            {
                using (var con = new SqlConnection(ConnectionString))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Tournamnets (Name) VALUES (@Names);";

                    cmd.Parameters.AddWithValue("@Names", name);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Tournament Created successfully. Please select group teams.");
                Group_Name group_Name = new Group_Name();
                this.Hide();
                group_Name.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tournament Creation failed.\r\n" + ex.Message);
            }
        }

        private void CreateTournamnet_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
