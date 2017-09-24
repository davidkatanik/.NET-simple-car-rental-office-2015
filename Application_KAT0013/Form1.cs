using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_KAT0013
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            tbKlient.Clear();
            int k = 0;
            string s;
            Database.KlientTable kt = new Database.KlientTable();
            Database.Klient klient;
            if (rbtnIDK.Checked)
            {
                try
                {
                    k = Int32.Parse(tbID.Text);
                    klient = kt.SelectComplete(k);
                    if (klient != null)
                    {
                        lblJaP.Text = klient.Jmeno + " " + klient.Prijmeni;
                        lblRC.Text = klient.RC;
                        lblEmail.Text = klient.Email;
                        lblTel.Text = klient.Telefon;
                        lblAdr.Text = klient.Adresa.Mesto + " " + klient.Adresa.Ulice + " " + klient.Adresa.PSC;

                        String[] se = kt.TiskKlienta(klient.Id_klient).Split(';');
                        foreach (string x in se)
                        {
                            tbKlient.AppendText(x + '\n');
                        }
                    }
                    else
                    {
                        MessageBox.Show("Klient s ID: " + k.ToString() + " nebyl nalezen", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch                    
                {
                    MessageBox.Show("Zadejte platne ID klienta", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else if (rbtnRC.Checked)
            {
                try
                {
                    s = tbRC.Text;
                    if (s.Length == 0)
                    {
                        throw new ApplicationException();
                    }
                    klient = kt.SelectRCComplete(s);
                    if (klient != null)
                    {
                        lblJaP.Text = klient.Jmeno + " " + klient.Prijmeni;
                        lblRC.Text = klient.RC;
                        lblEmail.Text = klient.Email;
                        lblTel.Text = klient.Telefon;
                        lblAdr.Text = klient.Adresa.Mesto + " " + klient.Adresa.Ulice + " " + klient.Adresa.PSC;

                        String[] se = kt.TiskKlienta(klient.Id_klient).Split(';');
                        foreach (string x in se)
                        {
                            tbKlient.AppendText(x + '\n');
                        }
                    }
                    else
                    {
                        MessageBox.Show("Klient s RC: " + s + " nebyl nalezen", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Zadejte platne RC klienta", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nastala chyba", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void vytvoritPronajemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Dispose();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
