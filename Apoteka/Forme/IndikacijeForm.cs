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
    public partial class IndikacijeForm : Form
    {
        public IndikacijeForm()
        {
            InitializeComponent();
        }

        private void btnDodajIndikaciju_Click(object sender, EventArgs e)
        {
            DodajIndikacijuForm forma = new DodajIndikacijuForm();
            forma.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnObrisiIndikaciju_Click(object sender, EventArgs e)
        {
            // TODO: Obrisi indikaciju
        }

        private void btnIzmeniIndikaciju_Click(object sender, EventArgs e)
        {
            IzmeniIndikacijuForm forma = new IzmeniIndikacijuForm();
            forma.ShowDialog();
        }
    }
}
