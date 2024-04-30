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
    public partial class ZaliheLekovaForm : Form
    {
        ProdajnoMestoBasic prodajnomesto;
        public ZaliheLekovaForm()
        {
            InitializeComponent();
        }

        public ZaliheLekovaForm(ProdajnoMestoBasic p)
        {
            InitializeComponent();
            prodajnomesto = p;
        }

        private void ZaliheLekovaForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<ZalihaGrupaLekovaPregled> podaci = DTOManager.vratiZaliheGrupeLekova(prodajnomesto.JedinstveniBroj);
            dataGridView1.DataSource = podaci;
        }
    }
}
