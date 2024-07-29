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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select * from product", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
           

            while (dr1.Read())
            {
                listBox2.Items.Add(dr1["product_Id"].ToString() + " - " + dr1["product_name"].ToString());
                comboBox4.Items.Add(dr1["product_name"].ToString());
                comboBox5.Items.Add(dr1["product_name"].ToString());
                comboBox2.Items.Add(dr1["product_Id"].ToString());
                comboBox3.Items.Add(dr1["product_Id"].ToString());
            }

            


        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(str);
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from rayons", con);
            SqlDataReader dr = cmd.ExecuteReader();

            listBox1.Items.Add("no - reyon");
            while (dr.Read())
            {
                listBox1.Items.Add(dr["rayon id"].ToString() + " - " + dr["rayon name"].ToString());
                comboBox1.Items.Add(dr["rayon id"].ToString());

            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into product(rayon_id,selling_price,product_name,stock,buying_price) values(@p1,@p2,@p3,@p4,@p5)", con);
            cmd.Parameters.AddWithValue("@p1", Convert.ToInt32( comboBox1.Text));
            cmd.Parameters.AddWithValue("@p2", Convert.ToDecimal( textBox3.Text));
            cmd.Parameters.AddWithValue("@p3", textBox1.Text);
            cmd.Parameters.AddWithValue("@p4", Convert.ToInt32(textBox2.Text));
            cmd.Parameters.AddWithValue("@p5", Convert.ToDecimal(textBox4.Text));

            cmd.ExecuteNonQuery();

            MessageBox.Show("Kayıt olusturuldu");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 geri = new Form3();
            geri.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
           
            SqlCommand cmd = new SqlCommand("Update product set stock=stock+@p1 where product_Id=@p3 ",con);
            cmd.Parameters.AddWithValue("@p1", textBox5.Text);
            cmd.Parameters.AddWithValue("@p2", comboBox4.Text);
            cmd.Parameters.AddWithValue("@p3", Convert.ToInt32(comboBox2.Text));
           
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("Update product set selling_price =@p4 where product_Id=@p5  ", con);
            cmd1.Parameters.AddWithValue("@p4", Convert.ToDecimal(textBox6.Text));
            cmd1.Parameters.AddWithValue("@p5", Convert.ToInt32(comboBox2.Text));
            cmd1.ExecuteNonQuery();
            

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("silmek istediğinizden emin misiniz","",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            { 
                string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
                SqlConnection con = new SqlConnection(str);
                con.Open();


                SqlCommand cmd = new SqlCommand("delete from product where product_Id=@p2 ", con);
                cmd.Parameters.AddWithValue("@p1", comboBox5.Text);
                cmd.Parameters.AddWithValue("@p2", comboBox3.Text);


                cmd.ExecuteNonQuery();
            }
            else if (result == DialogResult.Yes)
            {
                MessageBox.Show("vazgeçildi");
            }
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select * from product", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;
        }
    }
}
