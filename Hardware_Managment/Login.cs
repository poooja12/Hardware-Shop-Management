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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");

        public Login()
        {
            InitializeComponent();


        }


        private void Exit_add_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            Admin ob = new Admin();
            ob.Show();
            this.Hide();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            con.Open();
            string UserName = txtname.Text.ToString().Trim();
            string Password = txtpassword.Text.ToString().Trim();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from  loginTb where UserName = '" + UserName + "' and Password ='" +Password + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int value = dt.Rows.Count;
            if (value >0)

            {
                Categories ob = new Categories();
                ob.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Wrong id and Password");

            }
            con.Close();



        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            ob.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
} 
