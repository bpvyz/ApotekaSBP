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

namespace Apoteka.Forme
{
    public partial class IzmeniZaposlenogForm : Form
    {
        FarmaceutBasic farmaceut;
        ZaposleniBasic zaposleni;
        public IzmeniZaposlenogForm(FarmaceutBasic farmaceut)
        {
            InitializeComponent();
            this.farmaceut = farmaceut;
            label7.Show();
            label8.Show();
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            popuniPodacimaFarmaceut(this.farmaceut);
            button1.Click -= btnIzmeniZaposlenog_Click;
            button1.Click += btnIzmeniFarmaceuta_Click;
        }

        public IzmeniZaposlenogForm(ZaposleniBasic zaposleni)
        {
            InitializeComponent();
            this.zaposleni = zaposleni;
            popuniPodacimaZaposleni(this.zaposleni);
            button1.Click -= btnIzmeniFarmaceuta_Click;
            button1.Click += btnIzmeniZaposlenog_Click;
        }

        private void IzmeniZaposlenogForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            
        }
        private void btnIzmeniFarmaceuta_Click(object sender, EventArgs e)
        {
            farmaceut.Ime = textBox2.Text;
            farmaceut.Prezime = textBox3.Text;
            farmaceut.Adresa = textBox5.Text;
            farmaceut.BrojTelefona = textBox6.Text;
            farmaceut.DatumRodjenja = dateTimePicker3.Value.Date;
            farmaceut.DatumObnoveLicence = dateTimePicker2.Value.Date;
            farmaceut.DatumDiplomiranja = dateTimePicker1.Value.Date;
            DTOManager.izmeniFarmaceuta(farmaceut);
            this.Close();
        }

        private void btnIzmeniZaposlenog_Click(object sender, EventArgs e)
        {
            zaposleni.Ime = textBox2.Text;
            zaposleni.Prezime = textBox3.Text;
            zaposleni.Adresa = textBox5.Text;
            zaposleni.BrojTelefona = textBox6.Text;
            zaposleni.DatumRodjenja = dateTimePicker3.Value.Date;
            DTOManager.IzmeniZaposlenog(zaposleni);
            this.Close();
        }
        public void popuniPodacimaFarmaceut(FarmaceutBasic farmaceut)
        {
            textBox1.Text = farmaceut.JedinstveniBroj;
            textBox2.Text = farmaceut.Ime;
            textBox3.Text = farmaceut.Prezime;
            textBox5.Text = farmaceut.Adresa;
            textBox6.Text = farmaceut.BrojTelefona;
            dateTimePicker1.Value = farmaceut.DatumDiplomiranja;
            dateTimePicker2.Value = farmaceut.DatumObnoveLicence;
            dateTimePicker3.Value = farmaceut.DatumRodjenja;
        }
        public void popuniPodacimaZaposleni(ZaposleniBasic zaposleni)
        {
            textBox1.Text = zaposleni.JedinstveniBroj;
            textBox2.Text = zaposleni.Ime;
            textBox3.Text = zaposleni.Prezime;
            textBox5.Text = zaposleni.Adresa;
            textBox6.Text = zaposleni.BrojTelefona;
            dateTimePicker3.Value = zaposleni.DatumRodjenja;
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button1.ClientRectangle,
         SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
         SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
         SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
         SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);

        }
    }
}
