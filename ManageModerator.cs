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

namespace Football_Managment
{
    public partial class ManageModerator : Form
    {
        private static readonly string ConnectionString = Program.DbAppName;
        public ManageModerator()
        {
            InitializeComponent();
            LoadUsers();
        }
        private void LoadUsers()
        {
            try
            {
                using (var con = new SqlConnection(ConnectionString))
                using (var cmd = con.CreateCommand())
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandText = @"
SELECT Id,Name, Phone, Email
FROM Users WHERE type = 'MOD'
ORDER BY Id DESC;";

                    var dt = new DataTable();
                    con.Open();
                    da.Fill(dt);

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Id",
                        Name = "Id",
                        HeaderText = "Id",
                        Width = 60,
                        ReadOnly = true
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Name",
                        Name = "Name",
                        HeaderText = "Name",
                        ReadOnly = true
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Phone",
                        Name = "Phone",
                        HeaderText = "Phone",
                        ReadOnly = true
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Email",
                        Name = "Email",
                        HeaderText = "Email",
                        ReadOnly = true
                    });

                    dataGridView1.DataSource = dt;
                    dataGridView1.RowTemplate.Height = 60;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load failed.\r\n" + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           AdminDashboard admindashboard = new AdminDashboard();
            this.Hide();
            admindashboard.Show();
        }

        private void ClearInputs()
        {
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var rowView = dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView == null)
            {
                return;
            }

            var row = rowView.Row;

            textBox3.Text = Convert.ToString(row["Id"]);
            textBox1.Text = Convert.ToString(row["Name"]);
            textBox2.Text = Convert.ToString(row["Phone"]);
            textBox4.Text = Convert.ToString(row["Email"]);
            return;
  
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse((textBox3.Text ?? string.Empty).Trim(), out id))
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            var name = (textBox1.Text ?? string.Empty).Trim();
           
            var phone = (textBox2.Text ?? string.Empty).Trim();
            var email = (textBox4.Text ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (phone.Length != 11 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Mobile number should be 11 digit.");
                textBox2.Focus();
                return;
            }

            try
            {
                using (var con = new SqlConnection(ConnectionString))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"
                                        UPDATE Users
                                        SET Name = @Name,
    
                                            Phone = @Phone,
                                            Email = @Email
                                        WHERE Id = @Id;";

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Email", email);

                    con.Open();
                    var affected = cmd.ExecuteNonQuery();

                    if (affected == 0)
                    {
                        MessageBox.Show("Update failed: row not found.");
                        return;
                    }
                }

                LoadUsers();
                MessageBox.Show("User updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed.\r\n" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse((textBox3.Text ?? string.Empty).Trim(), out id))
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (var con = new SqlConnection(ConnectionString))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Users WHERE Id = @Id;";

                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    var affected = cmd.ExecuteNonQuery();

                    if (affected == 0)
                    {
                        MessageBox.Show("Delete failed: row not found.");
                        return;
                    }
                }

                LoadUsers();
                ClearInputs();
                MessageBox.Show("User deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed.\r\n" + ex.Message);
            }
        }
    }
}
