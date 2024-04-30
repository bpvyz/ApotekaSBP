using Apoteka.Entiteti;
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
    public partial class FarmaceutForm : Form
    {
        ProdajnoMestoBasic prodajnomesto;
        public FarmaceutForm()
        {
            InitializeComponent();
        }

        public FarmaceutForm(ProdajnoMestoBasic p)
        {
            InitializeComponent();
            prodajnomesto = p;
        }

        private void btnObrisiFarmaceuta_Click(object sender, EventArgs e)
        {
            // TODO: Obrisi farmaceuta
        }

        private void btnIzdajRecept_Click(object sender, EventArgs e)
        {
            IzdajReceptForm forma = new IzdajReceptForm();
            forma.ShowDialog();
        }

        private void btnIzdatiRecepti_Click(object sender, EventArgs e)
        {
            IzdatiReceptiForm forma = new IzdatiReceptiForm();
            forma.ShowDialog();
        }

        private void FarmaceutForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<FarmaceutPregled> podaci = DTOManager.vratiFarmaceuteProdajnogMesta(prodajnomesto.JedinstveniBroj);
            dataGridView1.DataSource = podaci;
        }
    }
}
