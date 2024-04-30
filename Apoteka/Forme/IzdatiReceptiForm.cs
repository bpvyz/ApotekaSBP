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
        ProdajnoMestoBasic prodajnomesto;
        public IzdatiReceptiForm()
        {
            InitializeComponent();
        }

        public IzdatiReceptiForm(ProdajnoMestoBasic p)
        {
            InitializeComponent();
            prodajnomesto = p;
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
            List<ReceptPregled> podaci = DTOManager.vratiRecepteProdajnogMesta(prodajnomesto.JedinstveniBroj);
            dataGridView1.DataSource = podaci;
        }
    }
}
