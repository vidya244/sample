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

namespace sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Movie;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
       
            SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO mv_tkt(Customer_name, Movie_name, Show_time, Show_date,ID, Age_Group) VALUES('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Text + "','"+textBox3.Text+"','"+comboBox3.Text+"')", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("INSERTED SUCCESSFULLY");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT *FROM mv_tkt", con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlDataAdapter SDA = new SqlDataAdapter("UPDATE mv_tkt set Customer_name = '" + textBox1.Text + "', Movie_name = '" + comboBox1.Text + "', Show_time = '" + comboBox2.Text + "', Show_date = '" + dateTimePicker1.Text + "', Age_Group='"+comboBox3.Text+"' where ID='"+textBox3.Text+"' ", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("UPDATED SUCCESSFULLY");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlDataAdapter SDA = new SqlDataAdapter("DELETE FROM mv_tkt WHERE ID='" + textBox3.Text + "'  ", con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("DELETED SUCCESSFULLY");
        }

    }
}
