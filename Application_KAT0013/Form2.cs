using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_KAT0013
{
    public partial class Form2 : Form
    {
        Database.Database d = new Database.Database();
        Database.ZamestnanecTable zt = new Database.ZamestnanecTable();
        Database.KlientTable kt = new Database.KlientTable();
        Database.AutoTable at = new Database.AutoTable();
        Database.PronajemTable pt = new Database.PronajemTable();

        Database.Zamestnanec z = new Database.Zamestnanec();
        Database.Klient k = new Database.Klient();
        Database.Auto a = new Database.Auto();
        
        Database.Pronajem p = new Database.Pronajem();

        Collection<Database.Auto> auta;

        int cc = 0;

        public Form2()
        {
            InitializeComponent();

            p.Id_klient = new Database.Klient();
            p.Id_zamestnanec = new Database.Zamestnanec();
            p.SPZ = new Database.Auto();
            a.Typ_auta = new Database.Typ_auta();
            k.Adresa = new Database.Adresa();
            z.Id_adresa = new Database.Adresa();
            z.Id_oddeleni = new Database.Oddeleni();

            auta = at.SelectComplete('P');

            dtDo.MinDate = DateTime.Now; 
            dtDo.MaxDate = DateTime.Now.AddYears(1);
            dtOd.MinDate = DateTime.Now;
            dtOd.MaxDate = DateTime.Now.AddYears(1);
                      
            foreach (Database.Auto auto in auta)
            {
                Database.Typ_autaTable ta = new Database.Typ_autaTable();
                lbAuta.Items.Add(auto.Typ_auta.Znacka + " " + auto.Typ_auta.Model);
            }
            lbAuta.SetSelected(0, true);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tisknutelnáSestavaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Dispose();
        }

        private void lbAuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbAuta.SelectedIndex;
            a = auta.ElementAt(index);
            lblCapAuto.Text = a.Typ_auta.Znacka + " " + a.Typ_auta.Model;
            lblDenniSazba.Text = a.Denni_sazba.ToString();
            lblRokVyroby.Text = a.Rok_vyroby.ToString();
            lblSPZ.Text = a.SPZ;
            PrepoctiCenu();
        }

        private void dtDo_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = this.dtOd.Value.Date;
            DateTime to = this.dtDo.Value.Date;
            if (to < from)
            {
                MessageBox.Show("Datum do musí být větší nebo rovno datumu od", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtDo.Value = dtOd.Value;
                to = from;
            }
            lblPctDnu.Text = ((to - from).Days + 1).ToString();
            PrepoctiCenu();
        }

        private void PrepoctiCenu()
        {
            
            cc = a.Denni_sazba * Int32.Parse(lblPctDnu.Text);
            int x = Int32.Parse(tbZaloha.Text);
            if (x < 0)
            {
                MessageBox.Show("Zaloha nesmi byt zaporna", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbZaloha.Text = "0";
                lblCC.Text = cc.ToString();
                lblCCbZ.Text = "0";
            }
            if (x > cc)
            {
                MessageBox.Show("Zaloha nesmi byt vetsi nez celkova cena", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbZaloha.Text = "0";
                lblCC.Text = cc.ToString();
                lblCCbZ.Text = "0";
            }
            else
            {
                lblCC.Text = cc.ToString();
                lblCCbZ.Text = (cc - Int32.Parse(tbZaloha.Text)).ToString();
            }
        }

        private void btnPrepoctiCenu_Click(object sender, EventArgs e)
        {
            PrepoctiCenu();
        }

        private void btnNajdiK_Click(object sender, EventArgs e)
        {
            try
            {
                k = kt.Select(Int32.Parse(tbIDK.Text));
                if (k == null)
                {
                    MessageBox.Show("Klient s ID " + tbIDK.Text + " neexistuje", "Varovani", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Klient s ID " + tbIDK.Text + " existuje", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Zadejte spravne ID klienta", "Varovani", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnNajdiZ_Click(object sender, EventArgs e)
        {
            try
            {
                z = zt.Select(Int32.Parse(tbIDZ.Text));
                if (k == null)
                {
                    MessageBox.Show("Zamestnanec s ID " + tbIDZ.Text + " neexistuje", "Varovani", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Zamestnanec s ID " + tbIDZ.Text + " existuje", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Zadejte spravne ID zaměstnance", "Varovani", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnPronajat_Click(object sender, EventArgs e)
        {
            try
            {
                p.Cena = cc;
                p.Datum_do = dtDo.Value.Date;
                p.Datum_od = dtOd.Value.Date;

                p.Id_klient.Id_klient = Int32.Parse(tbIDK.Text);
                p.Id_zamestnanec.Id_zamestnanec = Int32.Parse(tbIDZ.Text);
                p.SPZ.SPZ = a.SPZ;

                p.Zaloha = Int32.Parse(tbZaloha.Text);
                p.Poznamka = tbPoznamka.Text;
                pt.Insert(p);
            }
            catch
            {
                MessageBox.Show("Nastala chyba, zkontrolujte si zadane udaje", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ZpravaTrideS(String str)
        {
            MessageBox.Show(""+str, "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tbZaloha_Leave(object sender, EventArgs e)
        {
            PrepoctiCenu();
        }

        private void btnNovyP_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Dispose();
            f.Show();
        }

        private void dtOd_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = this.dtOd.Value.Date;
            dtDo.MinDate = from;
            dtDo.MaxDate = from.AddYears(1);
            DateTime to = this.dtDo.Value.Date;
            if (to < from)
            {
                this.dtDo.Value = this.dtOd.Value;
            }
            
            lblPctDnu.Text = ((to - from).Days + 1).ToString();
            PrepoctiCenu();
        }

        private void btnVypis_Click(object sender, EventArgs e)
        {
            lbAuta.Items.Clear();
            foreach (Database.Zamestnanec z in zt.Select())
            {
                lbAuta.Items.Add(z.Jmeno + " " + z.Prijmeni);
            }
        }
    }
}
