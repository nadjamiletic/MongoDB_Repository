using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MongoDB_Repository
{
    public partial class DodajVlasnika : Form
    {
        public DodajVlasnika()
        {
            InitializeComponent();
            //btnDPsa.Visible = false;
            txtPassword.PasswordChar = '*';
            panel3.Height = txtIme.Height;
            panel3.Top = txtIme.Top;
        }

        private void btnDVlasnika_Click(object sender, EventArgs e)
        {
            DataProvider d = new DataProvider();
            List<MongoDBRef> m = new List<MongoDBRef>();
            
            d.DodajVlasnika(txtIme.Text, txtPrezime.Text, txtKontakt.Text,txtUsername.Text,txtPassword.Text,m);
            //btnDPsa.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIme_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Height = txtIme.Height;
            panel3.Top = txtIme.Top;
        }

        private void txtPrezime_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Height = txtPrezime.Height;
            panel3.Top = txtPrezime.Top;
        }

        private void txtKontakt_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Height = txtKontakt.Height;
            panel3.Top = txtKontakt.Top;
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Height = txtUsername.Height;
            panel3.Top = txtUsername.Top;
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Height = txtPassword.Height;
            panel3.Top = txtPassword.Top;
        }
    }
}
