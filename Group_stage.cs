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
    public partial class Group_stage : Form
    {
        public Group_stage()
        {
            InitializeComponent();
        }

        private void Group_stage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Score_Board_ad_Mod score_Board_Ad_Mod = new Score_Board_ad_Mod();
            this.Hide();
            score_Board_Ad_Mod.Show();
        }
    }
}
