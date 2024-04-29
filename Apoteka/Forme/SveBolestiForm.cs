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
    public partial class SveBolestiForm : Form
    {
        public SveBolestiForm()
        {
            InitializeComponent();
        }

        private void btnDodajBolest_Click(object sender, EventArgs e)
        {
            DodajBolestForm forma = new DodajBolestForm();
            forma.ShowDialog();
        }

        private void btnIzmeniBolest_Click(object sender, EventArgs e)
        {
            IzmeniBolestForm forma = new IzmeniBolestForm();
            forma.ShowDialog();
        }

        private void btnObrisiBolest_Click(object sender, EventArgs e)
        {
            //TODO: Obrisi bolest iz svih
        }
    }
}
