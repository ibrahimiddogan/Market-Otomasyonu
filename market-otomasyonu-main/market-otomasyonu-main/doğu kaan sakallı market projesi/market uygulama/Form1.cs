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
namespace market_uygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
         
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Form5 anasayfa = new Form5();
            
            anasayfa.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doðu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from login where username= @p1 AND password=@pass ", con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", maskedTextBox1.Text);

            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                
                Form3 anasayfa = new Form3();
                this.Hide();
                anasayfa.Show();

            }
            else { MessageBox.Show("kullanýcý adý veya þifreniz yanlýþ"); }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}