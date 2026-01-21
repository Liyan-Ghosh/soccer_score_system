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
    public partial class Group_Name : Form
    {
        private static readonly string ConnectionString = Program.DbAppName;

        public Group_Name()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void create_matches()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                var teamsByGroup = new Dictionary<string, List<int>>();
                string fetchSql = "SELECT id, group_name FROM Teams";

                using (SqlCommand fetchCmd = new SqlCommand(fetchSql, con))
                using (SqlDataReader reader = fetchCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string grp = reader["group_name"].ToString();
                        int id = Convert.ToInt32(reader["id"]);

                        if (!teamsByGroup.ContainsKey(grp))
                            teamsByGroup[grp] = new List<int>();

                        teamsByGroup[grp].Add(id);
                    }
                }

                using (SqlTransaction trans = con.BeginTransaction())
                {
                    try
                    {
                        string insertSql = @"INSERT INTO Matches (team_a, team_b, a_score, b_score, type, status) 
                                     VALUES (@a, @b, 0, 0, 'GS', 0)";

                        foreach (var group in teamsByGroup)
                        {
                            List<int> ids = group.Value;

                            for (int i = 0; i < ids.Count; i++)
                            {
                                for (int j = i + 1; j < ids.Count; j++)
                                {
                                    using (SqlCommand cmd = new SqlCommand(insertSql, con, trans))
                                    {
                                        cmd.Parameters.AddWithValue("@a", ids[i]);
                                        cmd.Parameters.AddWithValue("@b", ids[j]);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        trans.Commit();
                        MessageBox.Show("Tournament has been started!");
                        Update_Tournament update_Tournament = new Update_Tournament("admin");
                        this.Hide();
                        update_Tournament.Show();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Error creating matches: " + ex.Message);
                    }
                }
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var teamEntries = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(comboBox1.Text, "A"), new KeyValuePair<string, string>(comboBox2.Text, "A"),
                new KeyValuePair<string, string>(comboBox3.Text, "A"), new KeyValuePair<string, string>(comboBox4.Text, "A"),
                new KeyValuePair<string, string>(comboBox5.Text, "B"), new KeyValuePair<string, string>(comboBox6.Text, "B"),
                new KeyValuePair<string, string>(comboBox7.Text, "B"), new KeyValuePair<string, string>(comboBox8.Text, "B"),
                new KeyValuePair<string, string>(comboBox9.Text, "C"), new KeyValuePair<string, string>(comboBox10.Text, "C"),
                new KeyValuePair<string, string>(comboBox11.Text, "C"), new KeyValuePair<string, string>(comboBox12.Text, "C"),
                new KeyValuePair<string, string>(comboBox13.Text, "D"), new KeyValuePair<string, string>(comboBox14.Text, "D"),
                new KeyValuePair<string, string>(comboBox15.Text, "D"), new KeyValuePair<string, string>(comboBox16.Text, "D")
            };
            if (teamEntries.Any(x => string.IsNullOrWhiteSpace(x.Key)))
            {
                MessageBox.Show("All 16 team names must be filled in!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var duplicates = teamEntries
                .GroupBy(x => x.Key)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicates.Any())
            {
                string duplicateNames = string.Join(", ", duplicates);
                MessageBox.Show($"Duplicate team names found: {duplicateNames}. Each team must be unique.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlTransaction trans = con.BeginTransaction())
                {
                    try
                    {
                        string sql = @"INSERT INTO Teams (name, group_name, points, match_count, win, lose, draw) 
                               VALUES (@name, @group, 0, 0, 0, 0, 0)";

                        foreach (var team in teamEntries)
                        {
                            if (string.IsNullOrWhiteSpace(team.Key)) continue;

                            using (SqlCommand cmd = new SqlCommand(sql, con, trans))
                            {
                                cmd.Parameters.AddWithValue("@name", team.Key);
                                cmd.Parameters.AddWithValue("@group", team.Value);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Error inserting teams: " + ex.Message);
                    }
                }
                con.Close();
            }

            create_matches();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Group_A group_A = new Group_A();
            this.Hide();
            group_A.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Group_B group_B = new Group_B();
            this.Hide();
            group_B.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Group_C group_C = new Group_C();
            this.Hide();
            group_C.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Group_D group_D = new Group_D();
            this.Hide(); group_D.Show();
        }

        private void Group_Name_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Group_Name_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string[] teams = new string[comboBox1.Items.Count];

            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                teams[i] = comboBox1.Items[i].ToString();
            }

            if (teams.Length < 16)
            {
                MessageBox.Show("You need at least 16 teams to perform a random select.");
                return;
            }

            Random rng = new Random();
            for (int i = teams.Length - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                string temp = teams[i];
                teams[i] = teams[j];
                teams[j] = temp;
            }

            ComboBox[] targetBoxes = {
                comboBox1, comboBox2, comboBox3, comboBox4,
                comboBox5, comboBox6, comboBox7, comboBox8,
                comboBox9, comboBox10, comboBox11, comboBox12,
                comboBox13, comboBox14, comboBox15, comboBox16
            };

            for (int i = 0; i < targetBoxes.Length; i++)
            {
                targetBoxes[i].Text = teams[i];
            }
        }
    }
}
