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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void getLoginPage(object sender, EventArgs e)
        {
            var login = new Login();
            login.FormClosed += (s, args) => Close();

            Hide();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var scoreboard = new Scoreboard();
            scoreboard.FormClosed += (s, args) => Close();

            Hide();
            scoreboard.Show();
        }
    }
}
