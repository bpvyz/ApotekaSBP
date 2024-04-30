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

        private void btnFarmaceut_Click(object sender, EventArgs e)
        {
            FarmaceutForm forma = new FarmaceutForm();
            forma.ShowDialog();
        }

        private void btnObrisiZaposlenog_Click(object sender, EventArgs e)
        {
            //TODO: Obrisi zaposlenog
        }

        private void ZaposleniForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
    }
}
