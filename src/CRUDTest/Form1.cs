using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUDTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(Constants.db);
        private void button1_Click(object sender, EventArgs e)
        {
            


            con.Open();
            SqlCommand command = new SqlCommand("Insert into "+ Constants.table + " Values('" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "', GetDate())", con);

            command.ExecuteNonQuery();
            MessageBox.Show("Test Successfully Inserted");
            con.Close();
            BindData();

        }

        void BindData()
        {
            SqlCommand command = new SqlCommand("Select * from "+ Constants.table + "", con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            System.Data.DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string strUpdate = "Update " + Constants.table + " Set ItemName = '" + textBox2.Text + "' WHERE ProductId = '" + int.Parse(textBox1.Text) + "' ";
            SqlCommand cmd = new SqlCommand(strUpdate, con);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("SuccessFully Update");
            BindData();
        }
    }
}
