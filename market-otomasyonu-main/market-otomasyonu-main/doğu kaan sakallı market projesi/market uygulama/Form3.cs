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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            string st= @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(st);
            con.Open();
            SqlCommand cmd = new SqlCommand("select product_Id,product_name from product",con);
            SqlDataReader dr = cmd.ExecuteReader();
        
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["product_name"].ToString());
                comboBox2.Items.Add(dr["product_Id"].ToString());
               
              
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 ana = new Form2();
            ana.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 ekle = new Form4();
            ekle.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(str);

            con.Open();
            SqlCommand cmd = new SqlCommand("select product_id,product_name,stock,selling_price from product", con);

            SqlDataReader d = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(d);
            dataGridView1.DataSource = dt;
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
           /* string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(str);
            
            con.Open();
            if (textBox1.Text==""|| textBox1.Text==" ")
            { MessageBox.Show("adet giriniz"); }
            else
            {
                SqlCommand cmd = new SqlCommand("update product set stock= stock-@p2 where  product_id=@p3  ", con);
                

                cmd.Parameters.AddWithValue("@p2", textBox1.Text);
                cmd.Parameters.AddWithValue("@p3", textBox2.Text);
                cmd.ExecuteNonQuery();
                SqlCommand a = new SqlCommand("select product_id,product_name,stock,selling_price from product", con);

                SqlDataReader d = a.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(d);
                dataGridView1.DataSource = dt;}*/
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str= @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("update product set stock = stock+@p1 where product_id=@p2",con);
            cmd.Parameters.AddWithValue("@p1", textBox3.Text);
            cmd.Parameters.AddWithValue("@p2",comboBox2.Text);

            cmd.ExecuteNonQuery();
            SqlCommand a = new SqlCommand("select product_id,product_name,stock,selling_price from product", con);

            SqlDataReader d = a.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(d);
            dataGridView1.DataSource = dt;
            con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("select product_name, selling_price*@p1 as fiyat from product where product_Id=@p2 ", con);
            cm.Parameters.AddWithValue("@p1", textBox3.Text);
            cm.Parameters.AddWithValue("@p2", comboBox2.Text);
            SqlDataReader dr1 = cm.ExecuteReader();



            while (dr1.Read())
            {

                listBox1.Items.Add(dr1["product_name"].ToString() + " (x)" + textBox3.Text + " =");
                listBox4.Items.Add(dr1["fiyat"].ToString());
            }

            con.Close();
            double toplam = 0;
            for (int i = 0; i < listBox4.Items.Count; i++)
            {
                toplam += Convert.ToDouble(listBox4.Items[i]);
            }


            label11.Text = toplam.ToString();

            con.Open();
            SqlCommand cmd1 = new SqlCommand("update kasalar set kasa_mik = kasa_mik-@p1 where kasa_id=1", con);
            cmd1.Parameters.AddWithValue("@p1", label11.Text);            
            cmd1.ExecuteNonQuery();



        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string message =
         "çıkmak istediğinizden emin misiniz?";
            const string caption = "çıkış";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                
                e.Cancel = true;
            }
            else { Form1 kapat = new Form1();
                kapat.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cm = new SqlCommand("select product_name, selling_price*@p1 as fiyat from product where product_Id=@p2 ", con);
            cm.Parameters.AddWithValue("@p1", textBox1.Text);
            cm.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr1 = cm.ExecuteReader();
             

            
            while (dr1.Read())
            {

               listBox2.Items.Add(dr1["product_name"].ToString() + " (x)"+textBox1.Text + " =" );
                listBox3.Items.Add(dr1["fiyat"].ToString() );
            }
            
            con.Close();
            
            con.Open();
            SqlCommand cmd1 = new SqlCommand("update product set stock= stock-@p1 where  product_id=@p2  ", con);


            cmd1.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd1.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd1.ExecuteNonQuery();
            con.Close();
            con.Open();
            SqlCommand a = new SqlCommand("select product_id,product_name,stock,selling_price from product", con);

            SqlDataReader d = a.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(d);
            dataGridView1.DataSource = dt;
            con.Close();
           

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            textBox1.Text = " ";
            textBox2.Text = " ";
            label8.Text = "0";
            listBox2.Items.Clear();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            double toplam = 0;
            for (int i = 0; i < listBox3.Items.Count; i++)
            {
                toplam += Convert.ToDouble(listBox3.Items[i]);
            }

            
            label8.Text = toplam.ToString() ;

            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("update kasalar set kasa_mik=kasa_mik+@p1 where kasa_id=1",con);
            cmd.Parameters.AddWithValue("@p1",Convert.ToDecimal( label8.Text));
            cmd.ExecuteNonQuery();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form8 kasa = new Form8();
            kasa.Show();
            
        }
    }
}
