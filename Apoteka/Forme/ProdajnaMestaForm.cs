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
    public partial class ProdajnaMestaForm : Form
    {
        public ProdajnaMestaForm()
        {
            InitializeComponent();
        }

        private void btnDodajProdajnoMesto_Click(object sender, EventArgs e)
        {
            DodajProdajnoMestoForm forma = new DodajProdajnoMestoForm();
            forma.ShowDialog();
        }

        private void btnIzmeniProdajnoMesto_Click(object sender, EventArgs e)
        {
            IzmeniProdajnoMestoForm forma = new IzmeniProdajnoMestoForm();
            forma.ShowDialog();
        }

        private void btnProdajnaMesta_Click(object sender, EventArgs e)
        {
            ZaposleniForm forma = new ZaposleniForm();
            forma.ShowDialog();
        }

        private void btnZaliheLekova_Click(object sender, EventArgs e)
        {
            ZaliheLekovaForm forma = new ZaliheLekovaForm();
            forma.ShowDialog();
        }

        private void btnIzdatiRecepti_Click(object sender, EventArgs e)
        {
            IzdatiReceptiForm forma = new IzdatiReceptiForm();
            forma.ShowDialog();
        }

        private void btnObrisiProdajnoMesto_Click(object sender, EventArgs e)
        {
            // TODO: Obrisi prodajno mesto
        }

        private void ProdajnaMestaForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); 
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            List<ProdajnoMestoPregled> podaci = DTOManager.vratiSvaProdajnaMesta();
            dataGridView1.DataSource = podaci;
        }
    }
}
