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
    public partial class Items : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Items()
        {
            InitializeComponent();
        }

        public int ID { get; set; }

        private void Exit_item_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();



            SqlParameter p1 = new SqlParameter("@Item", SqlDbType.VarChar);
            p1.Value = txt_item.Text.ToUpper().Trim();

            SqlParameter p2 = new SqlParameter("@Category", SqlDbType.VarChar);
            p2.Value = Combo_Cat.Text.ToUpper().Trim();

            SqlParameter p3 = new SqlParameter("@Price", SqlDbType.Int);
            p3.Value = txt_price.Text.Trim();

            SqlParameter p4 = new SqlParameter("@Stock", SqlDbType.Int);
            p4.Value = txt_stock.Text.Trim();

            SqlParameter p5 = new SqlParameter("@Manufacture", SqlDbType.VarChar);
            p5.Value = txt_man.Text.ToUpper().Trim();




            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);

            cmd.Connection = con;
            con.Open();

            cmd.CommandText = "insert into ItemsTb (Item,Category,Price,Stock,Manufacture) values (@Item,@Category,@Price,@Stock,@Manufacture)";


            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Save");
            LoadData();
        }



        private void btn_edit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();



            SqlParameter p1 = new SqlParameter("@Item", SqlDbType.VarChar);
            p1.Value = txt_item.Text.ToUpper().Trim();

            SqlParameter p2 = new SqlParameter("@Category", SqlDbType.VarChar);
            p2.Value = Combo_Cat.SelectedItem.ToString();

            SqlParameter p3 = new SqlParameter("@Price", SqlDbType.Int);
            p3.Value = txt_price.Text.ToUpper().Trim();

            SqlParameter p4 = new SqlParameter("@Stock", SqlDbType.Int);
            p4.Value = txt_stock.Text.ToUpper().Trim();

            SqlParameter p5 = new SqlParameter("@Manufacture", SqlDbType.VarChar);
            p5.Value = txt_man.Text.ToUpper().Trim();

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);

            cmd.Connection = con;


            cmd.CommandText = "update ItemsTb set Item= @Item, Category=@Category, Price=@Price, Stock=@Stock, Manufacture=@Manufacture where id=" + ID.ToString();

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Update");
            LoadData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " delete from ItemsTb where id = " + ID.ToString();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("delete data ");
            LoadData();
        }

        private void GV_item_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(GV_item.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_item.Text = GV_item.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_price.Text = GV_item.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_stock.Text = GV_item.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_man.Text = GV_item.Rows[e.RowIndex].Cells[5].Value.ToString();

        }
        private void LoadData()
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            string query = "Select * from ItemsTb";
            sda = new SqlDataAdapter(query, con);
            sda.Fill(ds);
            GV_item.DataSource = ds.Tables[0];

        }
        private void ItemsTb_Load(object sender, EventArgs e)
        {
            LoadData();
            

        }



        private void Lbl_Category_Click(object sender, EventArgs e)
        {
            Categories ob = new Categories();
            ob.Show();
        }

        private void Lbl_Items_Click_1(object sender, EventArgs e)
        {
            Items ob = new Items();
            ob.Show();
            this.Hide();
        }

        private void Items_Load(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}



        
    
