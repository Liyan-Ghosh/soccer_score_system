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
    public partial class Moderator_Dashboard : Form
    {
        public Moderator_Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update_Tournament update_Tournament = new Update_Tournament();
            this.Hide();
            update_Tournament.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Score_Board_ad_Mod score_Board_Ad_Mod = new Score_Board_ad_Mod();

            this.Hide();
            score_Board_Ad_Mod.Show();

        }

        private void Moderator_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}
