﻿using Apoteka.Entiteti;
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
    public partial class DodajZaposlenogForm : Form
    {
        ProdajnoMestoBasic prodajnomesto;
        public DodajZaposlenogForm()
        {
            InitializeComponent();
        }

        public DodajZaposlenogForm(ProdajnoMestoBasic prodajnomesto)
        {
            InitializeComponent();
            this.prodajnomesto = prodajnomesto;
        }

        private void DodajZaposlenogForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            label7.Hide();
            label8.Hide();
        }

        private void btnDodajZaposlenog_Click(object sender, EventArgs e)
        {
                     
            if(checkBox1.Checked)
            {
                FarmaceutBasic far = new FarmaceutBasic();
                far.BrojTelefona = textBox6.Text;
                far.Adresa = textBox5.Text;
                far.JedinstveniBroj = textBox1.Text;
                far.Ime = textBox2.Text;
                far.Prezime = textBox3.Text;
                far.DatumRodjenja = dateTimePicker3.Value;
                far.DatumObnoveLicence = dateTimePicker2.Value;
                far.DatumDiplomiranja = dateTimePicker1.Value;
                DTOManager.dodajFarmaceuta(far, prodajnomesto);
                MessageBox.Show("Uspešno ste dodali novog farmaceuta!");
            }
            else
            {
                ZaposleniBasic zap = new ZaposleniBasic();
                zap.BrojTelefona = textBox6.Text;
                zap.Adresa = textBox5.Text;
                zap.JedinstveniBroj = textBox1.Text;
                zap.Ime = textBox2.Text;
                zap.Prezime = textBox3.Text;
                zap.DatumRodjenja = dateTimePicker3.Value;
                DTOManager.dodajZaposlenog(zap, prodajnomesto);
                MessageBox.Show("Uspešno ste dodali novog zaposlenog!");
            }

            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(dateTimePicker1.Visible)
            {
                label7.Hide();
                label8.Hide();
                dateTimePicker1.Hide();
                dateTimePicker2.Hide();
            }
            else 
            {
                label7.Show();
                label8.Show();
                dateTimePicker1.Show();
                dateTimePicker2.Show();
            }       
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
