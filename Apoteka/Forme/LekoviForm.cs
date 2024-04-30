using Apoteka.Forme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apoteka
{
    public partial class LekoviForm : Form
    {
        public LekoviForm()
        {
            InitializeComponent();
        }

        private void btnDodajLek_Click(object sender, EventArgs e)
        {
            DodajLekForm forma = new DodajLekForm();
            forma.ShowDialog();
        }

        private void btnIzmeniLek_Click(object sender, EventArgs e)
        {
            IzmeniLekForm forma = new IzmeniLekForm();
            forma.ShowDialog();
        }

        private void btnIndikacije_Click(object sender, EventArgs e)
        {
            IndikacijeForm forma = new IndikacijeForm();
            forma.ShowDialog();
        }

        private void btnKontraindikacije_Click(object sender, EventArgs e)
        {
            KontraindikacijeForm forma = new KontraindikacijeForm();
            forma.ShowDialog();
        }

        private void btnPakovanja_Click(object sender, EventArgs e)
        {
            PakovanjaForm forma = new PakovanjaForm();
            forma.ShowDialog();
        }

        private void btnObrisiLek_Click(object sender, EventArgs e)
        {
            // TODO: Obrisi lek
        }

        private void LekoviForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
    }
}
