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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            sidePanel.Width = btnIzlozbe.Width;
            sidePanel.Left = btnIzlozbe.Left;

            button1.SetBounds(769, 2, 27, 24);
            this.Width = 805;
            cIzlozba1.Show();
            cDostignuca1.Hide();
            cPsi1.Hide();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Width = 805;
            sidePanel.Width = btnIzlozbe.Width;
            sidePanel.Left = btnIzlozbe.Left;

            button1.SetBounds(769, 2, 27, 24);
            cIzlozba1.Show();
            cDostignuca1.Hide();
            cPsi1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Width = 805;
            sidePanel.Width = btnSampioni.Width;
            sidePanel.Left = btnSampioni.Left;

            button1.SetBounds(769, 2, 27, 24);
            cIzlozba1.Hide();
            cPsi1.Hide();
            cDostignuca1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Width = 805;
            sidePanel.Width = button5.Width;
            sidePanel.Left = button5.Left;

            button1.SetBounds(769, 2, 27, 24);
            cIzlozba1.Hide();
            cDostignuca1.Hide();
            cPsi1.Hide();
            this.Hide();
            Registrovanjecs g = new Registrovanjecs();
            g.Show();
            //this.Hide();
            g.FormClosing += Form2_FormClosing;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            this.Width = 805;
            sidePanel.Width = btnPrijava.Width;
            sidePanel.Left = btnPrijava.Left;

            button1.SetBounds(769, 2, 27, 24);
            cIzlozba1.Hide();
            cDostignuca1.Hide();
            cPsi1.Hide();
            this.Hide();

            DodajVlasnika g = new DodajVlasnika();
            g.Show();
            //this.Hide();
            g.FormClosing += Form2_FormClosing;
        }

        private void btnGlasanje_Click(object sender, EventArgs e)
        {
            sidePanel.Width = btnGlasanje.Width;
            sidePanel.Left = btnGlasanje.Left;


            button1.SetBounds(1219,2,27,24);
            this.Width = 1255;
            cIzlozba1.Hide();
            cDostignuca1.Hide();
            cPsi1.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
