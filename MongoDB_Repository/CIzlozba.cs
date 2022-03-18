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
    public partial class CIzlozba : UserControl
    {
        
        int j = 1;
        int k = 1;
        int f = 1;
        public CIzlozba()
        {

            InitializeComponent();
            //Napravi();
            SaGridom();
            
        }
        public void Napravi() //ovo je preko labela 
        {
            DataProvider d = new DataProvider();
            foreach (Izlozba i in d.vratiIzlozbe())
            {
                Label naziv = new Label();
                
               naziv.Top = j*50;
               naziv.Left = 0;
                
                this.Controls.Add(naziv);
                naziv.Text = "Naziv: "+ i.naziv.ToString();
               //


                Label grad = new Label();

                  grad.Top = j*50;
                  grad.Left = 200;
                  grad.Text = "Grad: " + i.grad.ToString();
                  this.Controls.Add(grad);
                 
                  Label datum = new Label();
                  datum.Top =j*50;
                  datum.Left = 400;
                  this.Controls.Add(datum);
                  datum.Text = "Datum: " + i.datum;
                j++;


                

            }

        }

        public void SaGridom()
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            int n;
            DataProvider d = new DataProvider();
            foreach (Izlozba i in d.vratiIzlozbe())
            {
                n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = Convert.ToString(i.naziv);

                dataGridView1.Rows[n].Cells[1].Value = Convert.ToString(i.grad);
                dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(i.datum);
            }
        }

        private void CIzlozba_Load(object sender, EventArgs e)
        {
          
        }
    }
}
