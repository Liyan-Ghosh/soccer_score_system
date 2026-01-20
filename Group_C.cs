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
    public partial class Group_C : Form
    {
        public Group_C()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Group_Name group_Name = new Group_Name();
            this.Hide();
            group_Name.Show();
        }

        private void Group_C_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
