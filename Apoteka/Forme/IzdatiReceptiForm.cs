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
    public partial class IzdatiReceptiForm : Form
    {
        FarmaceutBasic farmaceut;
        ProdajnoMestoBasic prodajnoMesto;
        public IzdatiReceptiForm()
        {
            InitializeComponent();
        }

        public IzdatiReceptiForm(FarmaceutBasic f)
        {
            InitializeComponent();
            farmaceut = f;
        }

        public IzdatiReceptiForm(ProdajnoMestoBasic pm)
        {
            InitializeComponent();
            prodajnoMesto = pm;
            groupBox1.Text = "Podaci o receptima prodajnog mesta";
        }

        private void btnIzmeniRecept_Click(object sender, EventArgs e)
        {
            IzmeniReceptForm forma = new IzmeniReceptForm();
            forma.ShowDialog();
        }

        private void IzdatiReceptiForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<ReceptPregled> podaci = DTOManager.vratiRecepteFarmaceuta(farmaceut);
            var modifiedPodaci = podaci.Select(r => new
            {
                r.SerijskiBroj,
                r.SifraLekara,
                r.Tip,
                r.OblikPakovanja,
                r.Kolicina,
                r.DatumIzdavanja,
                r.DatumRealizacije,
                ProdajnoMesto = r.ProdajnoMesto.JedinstveniBroj,
                Farmaceut = r.Farmaceut.JedinstveniBroj,
                Lek = r.Lek.KomercijalniNaziv
            }).ToList();

            dataGridView1.DataSource = modifiedPodaci;
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
    }
}
