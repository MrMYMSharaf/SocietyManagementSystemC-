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

namespace PlayerUi
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {

            InitializeComponent();
            txtLogin.PasswordChar = '*';
            txtLogin.MaxLength = 5;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtLogin.Text == "123")
            {
                this.Hide();
                Form1 ss = new Form1();
                ss.Show();

            }
            
           else
            {
                MessageBox.Show("not vallid");
            }
        }
    }
    
}
