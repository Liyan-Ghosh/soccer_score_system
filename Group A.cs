using Football_Managment;
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
    public partial class Group_A : Form
    {
        public Group_A()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Group_Name group_Name = new Group_Name();
            this.Hide();
            group_Name.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Group_Name group_Name = new Group_Name();
            this.Hide();
            group_Name.Show();
        }
    }
}
