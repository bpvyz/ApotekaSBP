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
    public partial class PakovanjaForm : Form
    {
        LekBasic lek;
        public PakovanjaForm()
        {
            InitializeComponent();
        }
        public PakovanjaForm(LekBasic lek)
        {
            InitializeComponent();
            this.lek = lek;
        }

        private void btnObrisiPakovanje_Click(object sender, EventArgs e)
        {

        }

        private void btnDodajPakovanje_Click(object sender, EventArgs e)
        {
            DodajPakovanjeForm forma = new DodajPakovanjeForm();
            forma.ShowDialog();
            //TODO: Resiti problem kako identifikovati koja zaliha grupa lekova pripada kojem prodajnom mestu
        }

        private void btnIzmeniPakovanje_Click(object sender, EventArgs e)
        {
            IzmeniPakovanjeForm forma = new IzmeniPakovanjeForm();
            forma.ShowDialog();
        }

        private void PakovanjaForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<PakovanjaPregled> podaci = DTOManager.vratiPakovanjaZaLek(lek.KomercijalniNaziv);
            dataGridView1.DataSource = podaci;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                this.button8.Text = "Smanji prozor <F1>";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.button8.Text = "Proširi prozor <F1>";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button5.ClientRectangle,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                button7.PerformClick();
            }

            if (keyData == (Keys.F1))
            {
                button8.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
