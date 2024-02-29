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
    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HardWareDb;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Admin()
        {
            InitializeComponent();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
           if (Txt_Pass.Text == "Omsairam")
            {
                bill ob = new bill();
                ob.Show();
                this.Hide();

            }
     else
            {
                MessageBox.Show("plese enter password");
            }
        }

       

        private void Exit_add_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_cancle_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            ob.Show();
            ob.Hide();

        }
    }
}
