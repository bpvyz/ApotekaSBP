using Apoteka.Entiteti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Apoteka.Forme
{
    public partial class IzmeniReceptForm : Form
    {
        ReceptBasic recept;
        public IzmeniReceptForm()
        {
            InitializeComponent();
        }
        public IzmeniReceptForm(ReceptBasic recept)
        {
            InitializeComponent();
            this.recept = recept;
        }

        private void IzmeniReceptForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            label7.Hide();
            dateTimePicker2.Hide();
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<LekPregled> podaci = DTOManager.vratiSveLekove();
            foreach (LekPregled l in podaci)
            {
                comboBox3.Items.Add(l);
                comboBox3.DisplayMember = "KomercijalniNaziv";
            }
            comboBox2.Items.Clear();
            List<PakovanjaPregled> podaci1 = DTOManager.vratiPakovanjaZaLek(recept.Lek.KomercijalniNaziv);
            foreach (PakovanjaPregled pak in podaci1)
            {
                comboBox2.Items.Add(pak);
            }
            textBox4.Text = recept.SifraLekara;
            numericUpDown1.Value = recept.Kolicina;
            dateTimePicker1.Value = recept.DatumIzdavanja;
            if (recept.DatumRealizacije != null)
            {
                checkBox1.Checked = true;
                dateTimePicker2.Value = (DateTime)recept.DatumRealizacije;
            }
            comboBox1.SelectedItem = recept.Tip;
            comboBox2.SelectedItem = recept.OblikPakovanja;
            comboBox3.SelectedItem = recept.Lek;
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

        private void btnIzmeniRecept_Click(object sender, EventArgs e)
        {
            recept.Tip = (string)comboBox1.SelectedItem;
            recept.OblikPakovanja = DTOManager.vratiPakovanje(((PakovanjaPregled)comboBox2.SelectedItem).Id);
            recept.Lek = DTOManager.vratiLek(((LekPregled)comboBox3.SelectedItem).KomercijalniNaziv);
            recept.DatumIzdavanja = dateTimePicker1.Value;
            if (checkBox1.Checked)
            {
                recept.DatumRealizacije = dateTimePicker2.Value;
            }
            recept.Kolicina = (int)numericUpDown1.Value;
            recept.SifraLekara = textBox4.Text;
            DTOManager.IzmeniRecept(recept);
            MessageBox.Show("Uspešno ste izmenili recept!");
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

        private void button6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button6.ClientRectangle,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }
    }
}
