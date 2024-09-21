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

namespace CrudForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CrudForm;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into cuud_form values(@id,@name,@age)", conn);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox3.Text);
            cmd.Parameters.AddWithValue("@age", double.Parse(textBox2.Text));
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Successfully Saved");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CrudForm;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update cuud_form set name=@name , age=@age where id =@id", conn);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox3.Text);
            cmd.Parameters.AddWithValue("@age", double.Parse(textBox2.Text));
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Successfully Update");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CrudForm;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete cuud_form where id=@id" , conn);
            cmd.Parameters.AddWithValue("@id" , int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Successfully Delete");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CrudForm;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from cuud_form", conn);
            SqlDataAdapter datasource = new SqlDataAdapter(cmd);
            DataTable datatable = new DataTable();
            datasource.Fill(datatable);
            dataGridView1.DataSource = datatable;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
