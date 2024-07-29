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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("update kasalar set kasa_mik=kasa_mik+@p1 where kasa_id=1", con);
            cmd.Parameters.AddWithValue("@p1", Convert.ToDecimal(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select kasa_mik from kasalar", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            string para = " ";
            while (dr.Read())
            {
                para = dr["kasa_mik"].ToString();
            }

            label2.Text = para;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string st = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(st);
            con.Open();
            SqlCommand cmd = new SqlCommand("select kasa_mik from kasalar", con);
            SqlDataReader dr = cmd.ExecuteReader();
            string para =" ";
            while(dr.Read())
            {
                para = dr["kasa_mik"].ToString();
            }

            label2.Text = para;





        }

        private void button2_Click(object sender, EventArgs e)
        {

            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("update kasalar set kasa_mik=kasa_mik-@p1 where kasa_id=1", con);
            cmd.Parameters.AddWithValue("@p1", Convert.ToDecimal(textBox2.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select kasa_mik from kasalar", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            string para = " ";
            while (dr.Read())
            {
                para = dr["kasa_mik"].ToString();
            }

            label2.Text = para;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 geri = new Form3();
            geri.Show();
            this.Close();
        }
    }
}
