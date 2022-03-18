using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MongoDB_Repository
{
    public partial class CDostignuca : UserControl
    {
        public CDostignuca()
        {
            InitializeComponent();
            cbIzlozbaPopuni();
            dataGridView1.Hide();
            //dataGridView1.Width = 1200;
        }

        public void Napravi()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            int br = 1;
            int n;
            DataProvider d = new DataProvider();
            foreach (Dostignuce i in d.Uporedi(VratiSelI(),VratiSelK()))
            {
                Pas p = d.vratiPsa1(i.pas.Id.AsObjectId);
                Image img = Image.FromFile("C:\\Users\\Nadja\\Downloads\\Mongo\\Mongo\\MongoDB_Repository(3)\\MongoDB_Repository\\MongoDB_Repository\\MongoDB_Repository\\bin\\Debug" + p.slika);

                n = dataGridView1.Rows.Add();
              // n= dataGridView1.RowCount = 3;
                dataGridView1.Rows[n].Height = 150;
                dataGridView1.Rows[n].Cells[0].Value = Convert.ToString(i.titula);
                dataGridView1.Rows[n].Cells[1].Value = img;
                dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(p.ime);
                dataGridView1.Rows[n].Cells[3].Value = Convert.ToString(p.rasa);
                
            }

        }
        public void cbIzlozbaPopuni()
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
                cbIzlozba.Items.Add(s);
            }
        }
        public string VratiSelI()
        {
            return cbIzlozba.SelectedItem.ToString();
        }

        public string VratiSelK()
        {
            return cbKategorija.SelectedItem.ToString();
        }

        public void cbKategorijaPopuni(string i)
        {
            DataProvider d1 = new DataProvider();
            List<String> d = new List<string>();

            foreach (Dostignuce p in d1.vratiDostignucaI(i))
            {
               

                    d.Add(p.kategorija);
                
            }


            List<string> filter = d.Distinct().ToList();
          

            foreach (string s in filter)
            {
                cbKategorija.Items.Add(s);
            }
        }

        private void cbIzlozba_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKategorija.Items.Clear();
            cbKategorijaPopuni(cbIzlozba.Text);
        }

        private void cbKategorija_SelectedIndexChanged(object sender, EventArgs e)
        {
            Napravi();
            dataGridView1.Show();
        }
    }
}
