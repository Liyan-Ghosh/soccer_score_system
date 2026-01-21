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
    public partial class Group_stage : Form
    {
        string role;
        private static readonly string ConnectionString = Program.DbAppName;
        public Group_stage()
        {
            InitializeComponent();
        }

        public Group_stage(string role)
        {
            InitializeComponent();
            this.role = role;
        }

        private void Group_stage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.role == "user")
            {
                Scoreboard scoreboard = new Scoreboard();
                this.Hide();
                scoreboard.Show();
            }
            else
            {
                Score_Board_ad_Mod score_Board_Ad_Mod = new Score_Board_ad_Mod(this.role);
                this.Hide();
                score_Board_Ad_Mod.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(ConnectionString))
                {
                    string sql = @"
                                SELECT name, points, win, draw, lose, match_count 
                                FROM Teams 
                                WHERE group_name = @group 
                                ORDER BY points DESC, win DESC";

                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@group", comboBoxGroup.Text);

                        var dt = new DataTable();
                        var da = new SqlDataAdapter(cmd);

                        con.Open();
                        da.Fill(dt);

                        dataGridView.AutoGenerateColumns = false;
                        dataGridView.Columns.Clear();

                        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "name",
                            Name = "Team",
                            HeaderText = "Team",
                            Width = 120,
                            ReadOnly = true
                        });

                        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "points",
                            Name = "Points",
                            HeaderText = "Points",
                            ReadOnly = true
                        });

                        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "win",
                            Name = "Win",
                            HeaderText = "W",
                            ReadOnly = true
                        });

                        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "draw",
                            Name = "Draw",
                            HeaderText = "D",
                            ReadOnly = true
                        });

                        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "lose",
                            Name = "Lose",
                            HeaderText = "L",
                            ReadOnly = true
                        });

                        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "match_count",
                            Name = "Match_Count",
                            HeaderText = "MP",
                            ReadOnly = true
                        });

                        dataGridView.DataSource = dt;
                        dataGridView.RowTemplate.Height = 40;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load failed.\r\n" + ex.Message);
            }
        }
    }
}
