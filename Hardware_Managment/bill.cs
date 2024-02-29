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
    public partial class bill : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public bill()
        {
            InitializeComponent();
        }

        private void Exit_bill_Click(object sender, EventArgs e)
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
        private void BillingTb_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            string query = "Select * from ItemsTb";
            sda = new SqlDataAdapter(query, con);
            sda.Fill(ds);
            GV_ITEMS.DataSource = ds.Tables[0];

        }
        public int id { get; set; }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_Items.Text == "")
            {
                MessageBox.Show("No Enught stocks");

            }
            else
            {
                Lbl_Total.Text = Convert.ToInt32(Convert.ToInt32(txt_quantity.Text) * Convert.ToInt32(txt_Price.Text)).ToString();




                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();



                SqlParameter p1 = new SqlParameter("@BillItems", SqlDbType.VarChar);
                p1.Value = txt_Items.Text.ToUpper().Trim();


                SqlParameter p2 = new SqlParameter("@BillCategory", SqlDbType.VarChar);
                p2.Value = Cmb_Category.SelectedItem.ToString();

                SqlParameter p3 = new SqlParameter("@BillQuantity", SqlDbType.Int);
                p3.Value = txt_quantity.Text.ToUpper().Trim();


                SqlParameter p4 = new SqlParameter("@BillPrice", SqlDbType.Int);
                p4.Value = txt_Price.Text.Trim();

                SqlParameter p5 = new SqlParameter("@BillTotal", SqlDbType.Int);
                p5.Value = Lbl_Total.Text.Trim();

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);

                cmd.Connection = con;

                cmd.CommandText = "insert into BillingTb (BillItems,BillCategory,BillQuantity,BillPrice,BillTotal) values (@BillItems,@BillCategory,@BillQuantity,@BillPrice,@BillTotal)";

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record Save");

                LoadBill();
            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " delete from BillingTb where id= " + id.ToString();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("delete data ");
            LoadData();
        }

        private void bill_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadBill();
            txt_Date.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();

        }

        private void GV_ITEMS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Items.Text = GV_ITEMS.Rows[e.RowIndex].Cells[1].Value.ToString();
            Cmb_Category.Text = GV_ITEMS.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Price.Text = GV_ITEMS.Rows[e.RowIndex].Cells[3].Value.ToString();
        }


        private void LoadBill()
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
            string query = "Select * from BillingTb";
            sda = new SqlDataAdapter(query, con);
            sda.Fill(ds);
            GV_Bils.DataSource = ds.Tables[0];

        }

        private void GV_Bils_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Items.Text = GV_Bils.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_quantity.Text = GV_Bils.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_Price.Text = GV_Bils.Rows[e.RowIndex].Cells[4].Value.ToString();
            Lbl_Total.Text = GV_Bils.Rows[e.RowIndex].Cells[5].Value.ToString();

            LoadData();
        }



        private void Lbl_Category_Click(object sender, EventArgs e)
        {
            Categories ob = new Categories();
            ob.Show();
            this.Hide();
        }

        private void Lbl_Bill_Click_1(object sender, EventArgs e)
        {
            bill ob = new bill();
            ob.Show();
            this.Hide();
        }

        private void btn_PrintBill_Click(object sender, EventArgs e)
        {

            Print l1 = new Print();
            l1.Show();
            this.Hide();


        }

        private void txt_Date_Click(object sender, EventArgs e)
        {
            {
                txt_Date.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
            }
        }

        private void txt_Price_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_Total_Click(object sender, EventArgs e)
        {

        }
    }
}