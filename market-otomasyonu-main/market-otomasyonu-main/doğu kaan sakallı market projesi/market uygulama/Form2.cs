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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
                string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
                SqlConnection con = new SqlConnection(str);

                con.Open();
                SqlCommand cmd = new SqlCommand("select * from product where rayon_id= @p1 ", con);
                cmd.Parameters.AddWithValue("@p1", comboBox1.Text);
                SqlDataReader d = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(d);
                dataGridView1.DataSource = dt;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Doğu\source\repos\market uygulama\market uygulama\Database1.mdf'; Integrated Security = True";
            SqlConnection con = new SqlConnection(str);

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from product", con);

            SqlDataReader d = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(d);
            dataGridView1.DataSource = dt;
        }

        private void Form2_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 geri = new Form3();
            geri.Show();
            this.Hide();
        }
         private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string message =
        "çıkmak istediğinizden emin misiniz?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {

                e.Cancel = true;
            }
            else
            {
                this.Close();
            }
        }
    }
}
