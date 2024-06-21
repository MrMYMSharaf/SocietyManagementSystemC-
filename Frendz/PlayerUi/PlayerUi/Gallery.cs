using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PlayerUi
{
    public partial class Gallery : Form
    {
        string fileName;
        List<MyPicture>list;
        public Gallery()
        {
            InitializeComponent();
        }
        
        Image ConvertBinaryToImage(byte[] data)
        {
            using(MemoryStream ms=new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.FocusedItem != null)
            {
                pictureBox.Image = ConvertBinaryToImage(list[listView.FocusedItem.Index].Data);
                lblFilename.Text= listView.FocusedItem.SubItems[0].Text;
            }
        }
        
        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter= "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    lblFilename.Text = fileName;
                    pictureBox.Image = Image.FromFile(fileName);
                }
            }
        }

        byte[] ConvertImageToBinary(Image img)
        {
            using(MemoryStream ms=new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            using (PicEntities db = new PicEntities())
            {
                MyPicture pic = new MyPicture() { FileName = fileName, Data = ConvertImageToBinary(pictureBox.Image) };
                db.MyPictures.Add(pic);
                await db.SaveChangesAsync();
                MessageBox.Show("You have been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
            using (PicEntities db = new PicEntities())
            {
                list = db.MyPictures.ToList();
                foreach (MyPicture pic in list)
                {
                    ListViewItem item = new ListViewItem(pic.FileName);
                    listView.Items.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
