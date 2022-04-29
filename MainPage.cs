using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiectBD_MuraSanda
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2_Stations newForm = new Form2_Stations();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3_Rides newForm = new Form3_Rides();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4_Bookings newForm = new Form4_Bookings();
            newForm.Show();
        }
    }
}
