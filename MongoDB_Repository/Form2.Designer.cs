namespace MongoDB_Repository
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.btnPrijava = new System.Windows.Forms.Button();
            this.btnGlasanje = new System.Windows.Forms.Button();
            this.btnSampioni = new System.Windows.Forms.Button();
            this.btnIzlozbe = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cPsi1 = new MongoDB_Repository.CPsi();
            this.cDostignuca1 = new MongoDB_Repository.CDostignuca();
            this.cIzlozba1 = new MongoDB_Repository.CIzlozba();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.sidePanel);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btnPrijava);
            this.panel1.Controls.Add(this.btnGlasanje);
            this.panel1.Controls.Add(this.btnSampioni);
            this.panel1.Controls.Add(this.btnIzlozbe);
            this.panel1.Location = new System.Drawing.Point(-5, -14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1272, 119);
            this.panel1.TabIndex = 0;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.CadetBlue;
            this.sidePanel.Location = new System.Drawing.Point(14, 45);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(153, 16);
            this.sidePanel.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.button5.Location = new System.Drawing.Point(645, 56);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(153, 45);
            this.button5.TabIndex = 4;
            this.button5.Text = "Registruj se";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnPrijava
            // 
            this.btnPrijava.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrijava.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrijava.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnPrijava.Location = new System.Drawing.Point(486, 56);
            this.btnPrijava.Name = "btnPrijava";
            this.btnPrijava.Size = new System.Drawing.Size(153, 45);
            this.btnPrijava.TabIndex = 3;
            this.btnPrijava.Text = "Prijavi se";
            this.btnPrijava.UseVisualStyleBackColor = true;
            this.btnPrijava.Click += new System.EventHandler(this.btnPrijava_Click);
            // 
            // btnGlasanje
            // 
            this.btnGlasanje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGlasanje.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGlasanje.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnGlasanje.Location = new System.Drawing.Point(327, 56);
            this.btnGlasanje.Name = "btnGlasanje";
            this.btnGlasanje.Size = new System.Drawing.Size(153, 45);
            this.btnGlasanje.TabIndex = 2;
            this.btnGlasanje.Text = "Glasanje";
            this.btnGlasanje.UseVisualStyleBackColor = true;
            this.btnGlasanje.Click += new System.EventHandler(this.btnGlasanje_Click);
            // 
            // btnSampioni
            // 
            this.btnSampioni.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSampioni.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSampioni.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnSampioni.Location = new System.Drawing.Point(168, 56);
            this.btnSampioni.Name = "btnSampioni";
            this.btnSampioni.Size = new System.Drawing.Size(153, 45);
            this.btnSampioni.TabIndex = 1;
            this.btnSampioni.Text = "Psi sampioni";
            this.btnSampioni.UseVisualStyleBackColor = true;
            this.btnSampioni.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnIzlozbe
            // 
            this.btnIzlozbe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIzlozbe.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzlozbe.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnIzlozbe.Location = new System.Drawing.Point(14, 56);
            this.btnIzlozbe.Name = "btnIzlozbe";
            this.btnIzlozbe.Size = new System.Drawing.Size(153, 45);
            this.btnIzlozbe.TabIndex = 0;
            this.btnIzlozbe.Text = "Izlozbe";
            this.btnIzlozbe.UseCompatibleTextRendering = true;
            this.btnIzlozbe.UseVisualStyleBackColor = false;
            this.btnIzlozbe.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.button1.Location = new System.Drawing.Point(769, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 24);
            this.button1.TabIndex = 5;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cPsi1
            // 
            this.cPsi1.Location = new System.Drawing.Point(9, 111);
            this.cPsi1.Name = "cPsi1";
            this.cPsi1.Size = new System.Drawing.Size(1258, 389);
            this.cPsi1.TabIndex = 3;
            // 
            // cDostignuca1
            // 
            this.cDostignuca1.BackColor = System.Drawing.SystemColors.Control;
            this.cDostignuca1.Location = new System.Drawing.Point(35, 111);
            this.cDostignuca1.Name = "cDostignuca1";
            this.cDostignuca1.Size = new System.Drawing.Size(714, 457);
            this.cDostignuca1.TabIndex = 2;
            // 
            // cIzlozba1
            // 
            this.cIzlozba1.Location = new System.Drawing.Point(131, 111);
            this.cIzlozba1.Name = "cIzlozba1";
            this.cIzlozba1.Size = new System.Drawing.Size(515, 574);
            this.cIzlozba1.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 453);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cPsi1);
            this.Controls.Add(this.cDostignuca1);
            this.Controls.Add(this.cIzlozba1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnPrijava;
        private System.Windows.Forms.Button btnGlasanje;
        private System.Windows.Forms.Button btnSampioni;
        private System.Windows.Forms.Button btnIzlozbe;
       // private UPsi uPsi1;
        private CIzlozba cIzlozba1;
        private CDostignuca cDostignuca1;
        private CPsi cPsi1;
        private System.Windows.Forms.Button button1;
        //private UPsi uPsi1;
    }
}