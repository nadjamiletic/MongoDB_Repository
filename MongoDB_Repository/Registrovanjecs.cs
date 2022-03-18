using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MongoDB_Repository
{
    public partial class Registrovanjecs : Form
    {
        public string path;
        public string ipath;
        
        public Vlasnik v = new Vlasnik();
        public Registrovanjecs()
        {
            InitializeComponent();
            panel1.Visible = false;
            txtPass.PasswordChar = '*';
            cbIzlozbapopuni();

            panel2.Height = txtUsername.Height;
            panel2.Top = txtUsername.Top;
            panel3.Height = txtIme.Height;
            panel3.Top = txtIme.Top;
            
        }

        public void cbIzlozbapopuni()
        {
            DataProvider d1 = new DataProvider();
            List<String> d = new List<string>();
            

            List<Izlozba> izlozbe = d1.vratiIzlozbe();

            foreach (Izlozba s in izlozbe)
            {
                d.Add(s.naziv);
                

            }

            List<string> filter = d.Distinct().ToList();

            foreach (string s in filter)
            {
                
                cmbIzlozba.Items.Add(s);
            }
        }
        public string VratiSel()
        {
            return cmbIzlozba.SelectedItem.ToString();
        }



        private void btnReg_Click(object sender, EventArgs e)
        {
            DataProvider d = new DataProvider();
            panel1.Visible = true;
            
             v = d.VratiVlasnikaU(txtUsername.Text,txtPass.Text);
        }

        private void btnDSliku_Click(object sender, EventArgs e)
        {
            
            String imageLocation = "";
            try
            {
                DataProvider d = new DataProvider();
                OpenFileDialog opFile = new OpenFileDialog();
                opFile.Filter = "jpg files(*.jpg)| PNG files(*.png)| All files(*.*)|*.*";
                path = Path.GetDirectoryName(Application.ExecutablePath) + @"\ProImages\"; // <---
                ipath = @"\ProImages\";
                if (Directory.Exists(path) == false)                                              // <---
                {                                                                                    // <---
                    Directory.CreateDirectory(path);                                              // <---
                }                                                                                    // <---

                if (opFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string iName = opFile.SafeFileName;   // <---
                        string filepath = opFile.FileName;    // <---
                        File.Copy(filepath, path + iName); // <---
                        ipath += iName;
                       
                        d.setPath(ipath);
                        image.Image = new Bitmap(opFile.OpenFile());
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Unable to open file " + exp.Message);
                    }
                }
                else
                {
                    opFile.Dispose();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            DataProvider d = new DataProvider();

            List<string> lista = new List<string>();
            if (cbxLepota.Checked)
            {
                lista.Add(cbxLepota.Text);
            }
           if (cbxRasa.Checked)
            {
                lista.Add(cbxRasa.Text);
            }
            if (cbxStarost.Checked)
            {
                lista.Add(cbxStarost.Text);
            }
            
            Izlozba i = d.VratiIzlozbu(VratiSel());
            d.DodajPsa(txtIme.Text, txtPol.Text, txtRasa.Text, float.Parse(txtTezina.Text), v, lista, ipath, Int32.Parse(txtStarost.Text),i);
/*
            image.Hide();
            txtIme.Clear();
            txtRasa.Clear();
            txtStarost.Clear();
            txtTezina.Clear();
            txtPol.Clear();
            cbxLepota.Checked = false;
            cbxRasa.Checked = false;
            cbxStarost.Checked = false;
            cmbIzlozba.SelectedItem = null;*/
        }

        private void Registrovanjecs_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Height = txtUsername.Height;
            panel2.Top = txtUsername.Top;
        }

        private void txtPass_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Height = txtPass.Height;
            panel2.Top = txtPass.Top;
        }

        private void txtIme_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Height = txtIme.Height;
            panel3.Top = txtIme.Top;
        }

        private void txtRasa_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Height = txtRasa.Height;
            panel3.Top = txtRasa.Top;
        }

        private void txtPol_DoubleClick(object sender, EventArgs e)
        {
            panel3.Height = txtPol.Height;
            panel3.Top = txtPol.Top;
        }

        private void txtTezina_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Height = txtTezina.Height;
            panel3.Top = txtTezina.Top;
        }

        private void txtStarost_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Height = txtStarost.Height;
            panel3.Top = txtStarost.Top;
        }

        private void txtPol_Click(object sender, EventArgs e)
        {
            panel3.Height = txtPol.Height;
            panel3.Top = txtPol.Top;
        }
    }
}
