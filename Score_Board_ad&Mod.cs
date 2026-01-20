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
    public partial class Score_Board_ad_Mod : Form
    {
        private string matchId;
        private static readonly string ConnectionString = Program.DbAppName;
        public Score_Board_ad_Mod()
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
                            t1.group_name,
                            m.id AS MatchId,
                            m.a_score,
                            m.b_score
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
                                labelTeam1.Text = reader["TeamAName"].ToString();
                                labelTeam2.Text = reader["TeamBName"].ToString();
                                labelGroup.Text = reader["group_name"].ToString();

                                // Assign scores from the database
                                labelScore1.Text = reader["a_score"].ToString();
                                labelScore2.Text = reader["b_score"].ToString();
                                this.matchId = reader["MatchId"].ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            AdminDashboard admindashboard = new AdminDashboard();
            this.Hide();
            admindashboard.Show();
        }

        private void DisplayMatchById(string targetId)
        {
            string sql = @"
        SELECT 
            t1.name AS TeamAName, 
            t2.name AS TeamBName,
            t1.group_name,
            m.id AS MatchId,
            m.a_score,
            m.b_score
        FROM Matches m
        JOIN Teams t1 ON m.team_a = t1.id
        JOIN Teams t2 ON m.team_b = t2.id
        WHERE m.id = @id"; // Look for the specific ID

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", targetId);
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                labelTeam1.Text = reader["TeamAName"].ToString();
                                labelTeam2.Text = reader["TeamBName"].ToString();
                                labelGroup.Text = reader["group_name"].ToString();
                                labelScore1.Text = reader["a_score"].ToString();
                                labelScore2.Text = reader["b_score"].ToString();
                                this.matchId = reader["MatchId"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Match not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void buttonNextMatch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(matchId)) return;

            int nextId = int.Parse(matchId) + 1;
            DisplayMatchById(nextId.ToString());
        }

        private void buttonPreviousMatch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(matchId)) return;

            int prevId = int.Parse(matchId) - 1;
            if (prevId < 1)
            {
                MessageBox.Show("This is the first match.");
                return;
            }
            DisplayMatchById(prevId.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Group_stage group_Stage = new Group_stage();
                this.Hide();
            group_Stage.Show();
        }
    }
}