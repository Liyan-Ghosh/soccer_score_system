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
    public partial class Update_Tournament : Form
    {
        private static readonly string ConnectionString = Program.DbAppName;
        public Update_Tournament()
        {
            InitializeComponent();
            LoadMatchData();
        }

        private void LoadMatchData()
        {
            string sql = @"
                            SELECT TOP 1 
                                t1.name AS TeamAName, 
                                t2.name AS TeamBName,
                                t1.group_name
                            FROM Matches m
                            JOIN Teams t1 ON m.team_a = t1.id
                            JOIN Teams t2 ON m.team_b = t2.id
                            WHERE m.status = 0
                            ORDER BY m.id ASC";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string teamA = reader["TeamAName"].ToString();
                                string teamB = reader["TeamBName"].ToString();
                                string groupName = reader["group_name"].ToString();

                                labelTeamA.Text = teamA;
                                labelTeamB.Text = teamB;
                                labelGroup.Text = "Group " + groupName;
                            }
                            else
                            {
                                MessageBox.Show("All matches have been completed!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminDashboard admindashboard = new AdminDashboard();
            this.Hide();
            admindashboard.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int sA) || !int.TryParse(textBox2.Text, out int sB))
            {
                MessageBox.Show("Please enter valid scores.");
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlTransaction trans = con.BeginTransaction())
                {
                    try
                    {
                        int matchId = 0, idA = 0, idB = 0;
                        string findMatchSql = "SELECT TOP 1 id, team_a, team_b FROM Matches WHERE status = 0 ORDER BY id ASC";

                        using (SqlCommand cmdFind = new SqlCommand(findMatchSql, con, trans))
                        using (SqlDataReader reader = cmdFind.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                matchId = (int)reader["id"];
                                idA = (int)reader["team_a"];
                                idB = (int)reader["team_b"];
                            }
                        }

                        if (matchId == 0) return;

                        // 2. Determine Stats
                        int winA = sA > sB ? 1 : 0;
                        int loseA = sA < sB ? 1 : 0;
                        int draw = sA == sB ? 1 : 0;
                        int ptsA = (winA * 3) + (draw * 1);

                        int winB = sB > sA ? 1 : 0;
                        int loseB = sB < sA ? 1 : 0;
                        int ptsB = (winB * 3) + (draw * 1);

                        // 3. Update Teams Table (Team A)
                        string updateTeamSql = @"UPDATE Teams SET 
                                        points = points + @pts, 
                                        match_count = match_count + 1, 
                                        win = win + @w, 
                                        lose = lose + @l, 
                                        draw = draw + @d 
                                        WHERE id = @tid";

                        using (SqlCommand cmdA = new SqlCommand(updateTeamSql, con, trans))
                        {
                            cmdA.Parameters.AddWithValue("@pts", ptsA);
                            cmdA.Parameters.AddWithValue("@w", winA);
                            cmdA.Parameters.AddWithValue("@l", loseA);
                            cmdA.Parameters.AddWithValue("@d", draw);
                            cmdA.Parameters.AddWithValue("@tid", idA);
                            cmdA.ExecuteNonQuery();
                        }

                        // 4. Update Teams Table (Team B)
                        using (SqlCommand cmdB = new SqlCommand(updateTeamSql, con, trans))
                        {
                            cmdB.Parameters.AddWithValue("@pts", ptsB);
                            cmdB.Parameters.AddWithValue("@w", winB);
                            cmdB.Parameters.AddWithValue("@l", loseB);
                            cmdB.Parameters.AddWithValue("@d", draw);
                            cmdB.Parameters.AddWithValue("@tid", idB);
                            cmdB.ExecuteNonQuery();
                        }

                        // 5. Update the Match itself
                        string updateMatchSql = "UPDATE Matches SET a_score = @s1, b_score = @s2, status = 1 WHERE id = @mid";
                        using (SqlCommand cmdM = new SqlCommand(updateMatchSql, con, trans))
                        {
                            cmdM.Parameters.AddWithValue("@s1", sA);
                            cmdM.Parameters.AddWithValue("@s2", sB);
                            cmdM.Parameters.AddWithValue("@mid", matchId);
                            cmdM.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show("Match Scores updated!");

                        textBox1.Clear();
                        textBox2.Clear();
                        LoadMatchData();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Score update Failed: " + ex.Message);
                    }
                }
            }
        }
    }
}
