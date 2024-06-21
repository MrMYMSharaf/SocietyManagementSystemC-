using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace PlayerUi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            
            CustomizerDesing();
            t.Abort();

        }
        #region Submenu
        public void SplashStart()
        {
            Application.Run(new Splash());
        }
         private void CustomizerDesing()
        {
            panelMediaSubmenu.Visible = false;
            panelPlaylistSubmenu.Visible = false;
            panelToolsSubmenu.Visible = false;
            //..
        }

        private void hideSubMenu()
        {
            if (panelMediaSubmenu.Visible == true)
                panelMediaSubmenu.Visible = false;
            if (panelPlaylistSubmenu.Visible == true)
                panelPlaylistSubmenu.Visible = false;
            if (panelToolsSubmenu.Visible == true)
                panelToolsSubmenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
#endregion
        private void btnMedia_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMediaSubmenu);
        }
        #region Information
        private void button2_Click(object sender, EventArgs e)
        {
            //openChildform(new Form2());
            openChildform(new Form3());
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
#endregion
        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPlaylistSubmenu);
        }
        #region Report
        private void button9_Click(object sender, EventArgs e)
        {
            openChildform(new Form2());
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
             openChildform(new SpecialReport());
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildform(new Annual());
            hideSubMenu();
        }

      
#endregion
        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            openChildform(new accoundForm());
            hideSubMenu();
        }
        #region Gallery
        private void btnTools_Click(object sender, EventArgs e)
        {
            showSubMenu(panelToolsSubmenu);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            openChildform(new Gallery());
            hideSubMenu();
        }
#endregion

        private void btnHelp_Click(object sender, EventArgs e)
        {
            openChildform(new Help());
            hideSubMenu();
        }
        #region childForm_hide
        private Form activeform = null;
        private void openChildform(Form childform)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childform);
            panelChildForm.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }
#endregion
        #region Digital_Clock
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm") ;
            lblSecound.Text = DateTime.Now.ToString("ss");
            lblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
            lblSecound.Location = new Point(lblTime.Location.X + lblTime.Width-5, lblSecound.Location.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        #endregion

       

      
    }
}
