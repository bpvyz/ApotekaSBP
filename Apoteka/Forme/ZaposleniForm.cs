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
    public partial class ZaposleniForm : Form
    {
        public ZaposleniForm()
        {
            InitializeComponent();
        }

        private void btnDodajZaposlenog_Click(object sender, EventArgs e)
        {
            DodajZaposlenogForm forma = new DodajZaposlenogForm();
            forma.ShowDialog();
        }

        private void btnIzmeniZaposlenog_Click(object sender, EventArgs e)
        {
            IzmeniZaposlenogForm forma = new IzmeniZaposlenogForm();
            forma.ShowDialog();
        }

        private void btnPregledFarmaceuta_Click(object sender, EventArgs e)
        {
            //TODO: Pregled farmaceuta
        }

        private void btnObrisiZaposlenog_Click(object sender, EventArgs e)
        {
            //TODO: Obrisi zaposlenog
        }
    }
}
