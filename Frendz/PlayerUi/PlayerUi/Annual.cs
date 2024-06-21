using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUi
{
    public partial class Annual : Form
    {
        DataTable tabel;
        public Annual()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Annual_Load(object sender, EventArgs e)
        {
            tabel = new DataTable();
            tabel.Columns.Add("Titel", typeof(String));
            tabel.Columns.Add("Messages", typeof(String));

            dataGridView1.DataSource = tabel;

            dataGridView1.Columns["Messages"].Visible = false;
            dataGridView1.Columns["Titel"].Width = 214;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tabel.Rows.Add(txtTitle.Text, txtMessage.Text);

            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            if (index > -1)
            {
                txtTitle.Text = tabel.Rows[index].ItemArray[0].ToString();
                txtMessage.Text = tabel.Rows[index].ItemArray[1].ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            tabel.Rows[index].Delete();
        }
    }
}
