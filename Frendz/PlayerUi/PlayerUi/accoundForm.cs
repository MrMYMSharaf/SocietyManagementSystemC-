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
    public partial class accoundForm : Form
    {
        public accoundForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=dbAccounts;Integrated Security=True");
        public int Id;
        private void accoundForm_Load(object sender, EventArgs e)
        {
            GetAccoundRecourd();
        }

        private void GetAccoundRecourd()
        {
           
            SqlCommand cmd = new SqlCommand("Select * from Accounts", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView.DataSource = dt;

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Accounts VALUES(@SID,@NAME,@EMAIL,@DETAIL,@DATE)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@SID", txtId.Text);
                cmd.Parameters.AddWithValue("@NAME", txtName.Text);
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                cmd.Parameters.AddWithValue("@DETAIL", txtDetail.Text);
                cmd.Parameters.Add(new SqlParameter("@DATE", dateTimePicker.Value.Date));
                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New ACCOUND is Save succesfully saved in the database","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);

                GetAccoundRecourd();
                ResetFormControls();
            }
        }

        private bool isValid()
        {
           if(txtId.Text== string.Empty)
            {
                MessageBox.Show("SId is requried", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void ResetFormControls()
        {
            Id = 0;
            txtDetail.Clear();
            txtEmail.Clear();
            txtId.Clear();
            txtName.Clear();
            dateTimePicker.ResetText();

            txtId.Focus();    
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
            txtId.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtName.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
            txtDetail.Text = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
            dateTimePicker.Value = Convert.ToDateTime(dataGridView.SelectedRows[0].Cells[5].Value);
           



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Accounts SET SID=@SID,NAME=@NAME,EMAIL=@EMAIL,DETAIL=@DETAIL,DATE=@DATE WHERE ID=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@SID", txtId.Text);
                cmd.Parameters.AddWithValue("@NAME", txtName.Text);
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                cmd.Parameters.AddWithValue("@DETAIL", txtDetail.Text);
                cmd.Parameters.Add(new SqlParameter("@DATE", dateTimePicker.Value.Date));
                cmd.Parameters.AddWithValue("@ID", this.Id);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Accound Information is updated successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetAccoundRecourd();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select an Accound to updated his information", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Accounts WHERE ID=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.Id);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Accound is deleted from the system", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetAccoundRecourd();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select an Accound to Delete", "Delete?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
