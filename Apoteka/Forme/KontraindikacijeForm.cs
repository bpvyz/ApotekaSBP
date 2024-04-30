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
    public partial class KontraindikacijeForm : Form
    {
        public KontraindikacijeForm()
        {
            InitializeComponent();
        }

        private void btnDodajKontraindikaciju_Click(object sender, EventArgs e)
        {
            DodajKontraindikacijuForm forma = new DodajKontraindikacijuForm();
            forma.ShowDialog();
        }

        private void btnIzmeniKontraindikaciju_Click(object sender, EventArgs e)
        {
            IzmeniKontraindikacijuForm forma = new IzmeniKontraindikacijuForm();
            forma.ShowDialog();
        }

        private void btnObrisiKontraindikaciju_Click(object sender, EventArgs e)
        {
            // TODO: Obrisi kontraindikaciju
        }

        private void KontraindikacijeForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
    }
}
