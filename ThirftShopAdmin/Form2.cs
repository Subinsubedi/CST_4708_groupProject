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


namespace ThirftShopAdmin
{
    public partial class Form2 : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;



        public Form2()
        {
            
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Subin\Desktop\4708\CST_4708_groupProject\ThirftShopAdmin\Database1.mdf;Integrated Security=True");
            cn.Open();
            GetAllRecords();

        }

        private void GetAllRecords()
        {
            cmd = new SqlCommand("Select * from tblItems", cn);
            da = new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                SaveInfo();
            }
            else
            {
                MessageBox.Show("Id shouldnt be empty");

            }
            GetAllRecords();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        protected void SaveInfo()
        {
            String QUERY = " Insert into tblItems " + "(Id, Name, Qty, Condition) " + "Values (@Id,@Name,@Qty,@Condition)";
            SqlCommand CMD = new SqlCommand(QUERY, cn);
            CMD.Parameters.AddWithValue("@Id", textBox1.Text);
            CMD.Parameters.AddWithValue("@Name", textBox2.Text);
            CMD.Parameters.AddWithValue("@Qty", textBox3.Text);
            CMD.Parameters.AddWithValue("@Condition", textBox4.Text);
            CMD.ExecuteNonQuery();

        }


        protected void DeleteInfo()
        {
            String QUERY = " Delete from tblItems " + "where  Id = @Id";
            SqlCommand CMD = new SqlCommand(QUERY, cn);
            CMD.Parameters.AddWithValue("@Id", textBox1.Text);
            CMD.ExecuteNonQuery();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DeleteInfo();
            }
            else
            {
                MessageBox.Show("Id shouldnt be empty");

            }
            GetAllRecords();
        }

        
        private void btnFind_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select * From tblItems where Id = " + textBox5.Text, cn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
