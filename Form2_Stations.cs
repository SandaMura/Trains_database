using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proiectBD_MuraSanda
{
    public partial class Form2_Stations : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sanda\source\repos\proiectBD_MuraSanda\bazaDeDate.mdf;Integrated Security=True");
        public Form2_Stations()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
            con.Open();
        
            SqlCommand cmd = new SqlCommand("insert into [Stations] ([ID Station], Name, City) values('" + int.Parse(textBox1.Text) + "', '" + textBox2.Text + "', '" + textBox6.Text + "')", con);
            //MessageBox.Show(command.CommandText);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException exx)
            {
                MessageBox.Show(exx.ToString());
                con.Close();
                return;
            }
            //command.ExecuteNonQuery();
            MessageBox.Show("Success insert");
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage newForm = new MainPage();
            newForm.Show();
        }
    }
}
