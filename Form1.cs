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

namespace proiectBD_MuraSanda
{
    public partial class Form1 : Form  //FPORMULAR PENTRU TABELUL [TRAINS]
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sanda\source\repos\proiectBD_MuraSanda\bazaDeDate.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           // try
           // {
                con.Open();
          //  }
           // catch (Exception ex)
          //  {
               // MessageBox.Show(ex.Message);
            //}
            SqlCommand command = new SqlCommand("Insert into Trains values ('"+int.Parse(textBox1.Text)+ "','" + textBox2.Text + "')", con);
            //MessageBox.Show(command.CommandText);

             try {
                 command.ExecuteNonQuery();
             }catch(System.Data.SqlClient.SqlException  exx)
             {
                 MessageBox.Show(exx.ToString());
                con.Close();
                 return;
             }
            //command.ExecuteNonQuery();
            MessageBox.Show("Success insert");
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaDeDateDataSet.Trains' table. You can move, or remove it, as needed.
            this.trainsTableAdapter.Fill(this.bazaDeDateDataSet.Trains);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from [Trains] where Name= '" + textBox3.Text + "' ";
           // MessageBox.Show(cmd.CommandText);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
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
        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from Trains", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                if (MessageBox.Show("Are you sure to delete?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd=new SqlCommand("Delete Trains where Name=  '" + textBox4.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully deleted");
                    BindData();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Trains set Name =  '" + textBox2.Text + "' where [ID Train]='" + int.Parse(textBox5.Text)+ "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
            BindData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage newForm = new MainPage();
            newForm.Show();
        }
    }
}
