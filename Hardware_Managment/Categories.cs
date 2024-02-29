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
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();

        }


        public int Id { get; set; }
        private void Add_Btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();



            SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
            p1.Value = txt_name.Text.ToUpper().Trim();
            cmd.Parameters.Add(p1);

            cmd.Connection = con;

            cmd.CommandText = "insert into Category(ItName) values(@name)";

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Save");
            LoadData();

        }

        private void Categories_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            string query = "Select * from Category";
            sda = new SqlDataAdapter(query, con);
            sda.Fill(ds);
            GV_Category.DataSource = ds.Tables[0];

        }

        private void label12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Edit_Btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();



            SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
            p1.Value = txt_name.Text.ToUpper().Trim();

            cmd.Parameters.Add(p1);

            cmd.Connection = con;

            cmd.CommandText = "update Category set ItName=@name  where id=" + Id.ToString();

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Update");
            LoadData();
        }

        private void GV_Category_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(GV_Category.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_name.Text = GV_Category.Rows[e.RowIndex].Cells[1].Value.ToString();
            LoadData();
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

        private void Lbl_Logout_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            ob.Show();
            this.Hide();

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " delete from Category where id= " + Id.ToString();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("delete data ");
            LoadData();
        }

        private void Lbl_Category_Click(object sender, EventArgs e)
        {
            Categories ob = new Categories();
            ob.Show();
            this.Hide();
        }

    }
        }
    


