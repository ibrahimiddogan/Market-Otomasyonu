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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from admin where admin_parola=@p1", con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);


            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                
                Form6 anasayfa = new Form6();
                this.Close();
                anasayfa.Show();

            }
            else { MessageBox.Show("şifreniz yanlış"); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
