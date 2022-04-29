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
    
    public partial class Form3_Rides : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sanda\source\repos\proiectBD_MuraSanda\bazaDeDate.mdf;Integrated Security=True");
        public Form3_Rides()
        {
            InitializeComponent();
        }

        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from Station", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update [Train rides] set [ID train] =  '" + int.Parse(textBox2.Text) + "',[ID destination station]= '" + int.Parse(textBox6.Text) + int.Parse(textBox7.Text) + "' where [ID ride]='" + int.Parse(textBox5.Text) + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
            BindData();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                if (MessageBox.Show("Are you sure to delete?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete [Train Rides] where [ID train ride]=  '" +int.Parse(textBox4.Text) + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully deleted");
                    BindData();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        // To display data
        public void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from [Trains]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from [Train rides] where [ID Ride]= '" + int.Parse(textBox3.Text) + "' ";
            // MessageBox.Show(cmd.CommandText);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            //textBox1.Text = "";
            //textBox2.Text = "";
            textBox3.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into [Train rides] ([ID Ride], [ID Train], [ID destination station], [Leaving time], [Arrival time], [Ticket price]) values('" + int.Parse(textBox1.Text) + "', '" + int.Parse(textBox2.Text) + "', '" + int.Parse(textBox6.Text) + "', '" + dateTimePicker1 + "' , '" + dateTimePicker2 + "' , '" + int.Parse(textBox7.Text) + "')", con);
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
           // dateTimePicker1 = null;
           // dateTimePicker2 = null;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage newForm = new MainPage();
            newForm.Show();
        }
    }
}
