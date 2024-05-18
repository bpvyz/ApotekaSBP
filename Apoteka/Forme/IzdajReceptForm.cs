using Apoteka.Entiteti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Apoteka.Forme
{
    public partial class IzdajReceptForm : Form
    {
        ProdajnoMestoBasic prodajnomesto;
        FarmaceutBasic farmaceut;
        public IzdajReceptForm()
        {
            InitializeComponent();
        }

        public IzdajReceptForm(ProdajnoMestoBasic prodajnomesto, FarmaceutBasic farmaceut)
        {
            InitializeComponent();
            this.prodajnomesto = prodajnomesto;
            this.farmaceut = farmaceut;
        }

        private void IzdajReceptForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            label7.Hide();
            dateTimePicker2.Hide();
            popuniPodacima();
        }

        private void popuniPodacima()
        {
            List<LekPregled> podaci = DTOManager.vratiLekoveZaProdajnoMesto(prodajnomesto);
            foreach(LekPregled l in podaci)
            {
                comboBox3.Items.Add(l);
                comboBox3.DisplayMember = "KomercijalniNaziv";
            }

            

        }

        private void btnDodajRecept_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ReceptBasic rec = new ReceptBasic();
                rec.SifraLekara = textBox4.Text;
                rec.Tip = (string)comboBox1.SelectedItem;
                rec.Kolicina = (int)numericUpDown1.Value;
                rec.DatumIzdavanja = dateTimePicker1.Value;
                rec.DatumRealizacije = dateTimePicker2.Value;
                PakovanjaBasic pakovanje = DTOManager.vratiPakovanje(((PakovanjaPregled)comboBox2.SelectedItem).Id);
                LekBasic lek = DTOManager.vratiLek(((LekPregled)comboBox3.SelectedItem).KomercijalniNaziv);
                DTOManager.dodajRecept(rec, farmaceut, prodajnomesto, lek, pakovanje);
                MessageBox.Show("Uspešno ste dodali novi recept!");
            }
            else
            {
                ReceptBasic rec = new ReceptBasic();
                rec.SifraLekara = textBox4.Text;
                rec.Tip = (string)comboBox1.SelectedItem;
                rec.Kolicina = (int)numericUpDown1.Value;
                rec.DatumIzdavanja = dateTimePicker1.Value;
                PakovanjaBasic pakovanje = DTOManager.vratiPakovanje(((PakovanjaPregled)comboBox2.SelectedItem).Id);
                LekBasic lek = DTOManager.vratiLek(((LekPregled)comboBox3.SelectedItem).KomercijalniNaziv);
                DTOManager.dodajRecept(rec, farmaceut, prodajnomesto, lek, pakovanje);
                MessageBox.Show("Uspešno ste dodali novi recept!");
            }

            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Visible)
            {
                label7.Hide();
                dateTimePicker2.Hide();
            }
            else
            {
                label7.Show();
                dateTimePicker2.Show();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            List<PakovanjaPregled> podaci1 = DTOManager.vratiPakovanjaZaLek(((LekPregled)comboBox3.SelectedItem).KomercijalniNaziv);
            foreach (PakovanjaPregled pak in podaci1)
            {
                comboBox2.Items.Add(pak);     
            }
        }

    }
}
