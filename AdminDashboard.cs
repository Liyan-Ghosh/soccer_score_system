using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_Managment
{
    public partial class AdminDashboard : Form
    {
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
            CreateTournamnet createTournamnet = new CreateTournamnet();
            this.Hide();
            createTournamnet.Show();
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

        }
    }
}
