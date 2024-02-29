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

namespace Hardware_Managment
{
    public partial class Costomer : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Costomer()
        {
            InitializeComponent();
        }

        private void Costomer_Load(object sender, EventArgs e)
        {
            LoadData();
            

        }

        private void LoadData()
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            string query = "Select * from Customer";
            sda = new SqlDataAdapter(query, con);
            sda.Fill(ds);
            GV_Customer.DataSource = ds.Tables[0];

        }

        public int id { get; set; }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();



            SqlParameter p1 = new SqlParameter("@Name", SqlDbType.VarChar);
            p1.Value = txt_Name.Text.ToUpper().Trim();


            SqlParameter p2 = new SqlParameter("@Gender", SqlDbType.VarChar);
            p2.Value = txt_gender.Text.ToUpper().Trim();


            SqlParameter p3 = new SqlParameter("@Phone", SqlDbType.VarChar);
            p3.Value = txt_phone.Text.ToUpper().Trim();

            SqlParameter p4 = new SqlParameter("@Pass", SqlDbType.VarChar);
            p4.Value = txtPass.Text.ToUpper().Trim();


            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);

            cmd.Connection = con;

            cmd.CommandText = "insert into Customer(Name,Gender,Phone,Password) values(@Name,@Gender,@Phone,@Pass)";

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Save");

            LoadData();

        }


        private void Exit_App_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void Btn_edit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();



            SqlParameter p1 = new SqlParameter("@Name", SqlDbType.VarChar);
            p1.Value = txt_Name.Text.ToUpper().Trim();


            SqlParameter p2 = new SqlParameter("@Gen", SqlDbType.VarChar);
            p2.Value = txt_gender.Text.Trim();

            SqlParameter p3 = new SqlParameter("@Phone", SqlDbType.VarChar);
            p3.Value = txt_phone.Text.ToUpper().Trim();

            SqlParameter p4 = new SqlParameter("@Pass", SqlDbType.VarChar);
            p4.Value = txtPass.Text.ToUpper().Trim();


            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);

            con.Open();


            cmd.Connection = con;

            cmd.CommandText = "update Customer set Name = @Name, Gender = @Gen, Phone = @Phone ,Password = @Pass where id =" + id.ToString();

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Update");
            LoadData();

        }



        private void Btn_delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " delete from Customer where id= " + id.ToString();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("delete data ");
            LoadData();

        }



        private void GV_Customer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(GV_Customer.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_Name.Text = GV_Customer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_gender.Text = GV_Customer.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_phone.Text = GV_Customer.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPass.Text = GV_Customer.Rows[e.RowIndex].Cells[3].Value.ToString();
            LoadData();
        }

        private void Lbl_Logout_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            ob.Show();
            this.Hide();
        }

        private void Lbl_Items_Click(object sender, EventArgs e)
        {
            Items ob = new Items();
            ob.Show();
            this.Hide();
        }

        private void Lbl_Bill_Click(object sender, EventArgs e)
        {
            bill ob = new bill();
            ob.Show();
            this.Hide();
        }

        private void Lbl_Cust_Click(object sender, EventArgs e)
        {
            Costomer ob = new Costomer();
            ob.Show();
            this.Hide();

        }

        private void Lbl_Category_Click(object sender, EventArgs e)
        {
            Categories ob = new Categories();
            ob.Show();
            this.Hide();
        }

        private void Lbl_Cust_Click_1(object sender, EventArgs e)
        {
            Costomer ob = new Costomer();
            ob.Show();
            this.Hide();
        }

        
        }
    }


