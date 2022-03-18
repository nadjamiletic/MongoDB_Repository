using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Driver;

namespace MongoDB_Repository
{
    public partial class CPsi : UserControl
    {
        DataGridViewComboBoxColumn cb = new DataGridViewComboBoxColumn();
        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        
        DataGridView dg2;
        public CPsi()
        {
            InitializeComponent();
            //Napravi();
            cbIzlozbaPopuni();
            cb.Visible = false;
            dg2 = new DataGridView();
            dataGridView1.Columns.Add(cb);
            dataGridView1.Columns.Add(btn);
            cb.Items.Add("6");
            cb.Items.Add("7");
            cb.Items.Add("8");
            cb.Items.Add("9");
            cb.Items.Add("10");
            dataGridView1.Hide();
        }
        public List<Pas> listica = new List<Pas>();
        public void Napravi()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            
            int n;
            DataProvider d = new DataProvider();
            foreach (Pas i in d.vratiPseKI(VratiSelK(), VratiSelI()))
            {
                //ovde treba promeniti string koji vodi do debug foldera na vasem racunaru
                Image img = Image.FromFile("C:\\Users\\Nadja\\Downloads\\Mongo\\Mongo\\MongoDB_Repository(3)\\MongoDB_Repository\\MongoDB_Repository\\MongoDB_Repository\\bin\\Debug" + i.slika);

                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Height = 150;
                dataGridView1.Rows[n].Cells[0].Value = img;
                dataGridView1.Rows[n].Cells[1].Value = Convert.ToString(i.ime);
                dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(i.pol);
                dataGridView1.Rows[n].Cells[3].Value = Convert.ToString(i.rasa);
                dataGridView1.Rows[n].Cells[4].Value = Convert.ToString(i.tezina);
                dataGridView1.Rows[n].Cells[5].Value = Convert.ToString(i.starost);
        

             
                cb.Visible = true;
                cb.Tag = "cb" + n;

                
               //
                
                btn.HeaderText = "Oceni psa";
                btn.Text = "Glasaj";
                btn.Name = "btn" + n;


                btn.UseColumnTextForButtonValue = true;
                //
                listica.Add(i);

                
                
                
            }
           
            dataGridView1.AutoGenerateColumns = false;
          
           
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

           foreach(Pas p in d1.vratiPseI(i))
            {
                 foreach (string k in p.kategorije)
                {
                    
                    d.Add(k);
                }
            }

           
            
            

            List<string> filter = d.Distinct().ToList();
            //List<string> filter = d.Distinct().ToList();

            foreach (string s in filter)
            {
                cbKategorija.Items.Add(s);
            }
        }




        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                DataGridViewRow r = dataGridView1.CurrentRow;
                if (r.ReadOnly == false)
                {
                    DataProvider dp = new DataProvider();
                    int red = e.RowIndex;// to je 
                    //MessageBox.Show(red.ToString());
                    int rPos = dataGridView1.CurrentCell.ColumnIndex;
                    int red1 = dataGridView1.CurrentCell.RowIndex;

                    int i1 = dataGridView1.CurrentRow.Index;
                    //DataGridViewRow r = dataGridView1.CurrentRow;


                    string sp = dataGridView1.Rows[red].Cells[1].Value.ToString();

                    Pas p = dp.vratiPsa(cbKategorija.SelectedItem.ToString(), cbIzlozba.SelectedItem.ToString(), sp);

                    //MessageBox.Show(dataGridView1.CurrentRow.ToString());

                    Izlozba i = dp.VratiIzlozbu(cbIzlozba.Text);

                    string ocena = dataGridView1.Rows[red].Cells[6].Value.ToString();

                    dp.UpdateDostignuca(p, i, cbKategorija.SelectedItem.ToString(), Int32.Parse(ocena));
                    // MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");

                    r.ReadOnly = true;
                    r.Cells[7].ReadOnly = true;
                }

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
