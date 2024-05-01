using Apoteka.Entiteti;
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
    public partial class PakovanjaForm : Form
    {
        LekBasic lek;
        public PakovanjaForm()
        {
            InitializeComponent();
        }
        public PakovanjaForm(LekBasic lek)
        {
        this.lek = lek;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnDodajPakovanje_Click(object sender, EventArgs e)
        {
            DodajPakovanjeForm forma = new DodajPakovanjeForm();
            forma.ShowDialog();
            //TODO: Resiti problem kako identifikovati koja zaliha grupa lekova pripada kojem prodajnom mestu
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IzmeniPakovanjeForm forma = new IzmeniPakovanjeForm();
            forma.ShowDialog();
        }

        private void PakovanjaForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<PakovanjaPregled> podaci = DTOManager.vratiPakovanjaZaLek(lek.KomercijalniNaziv);
            dataGridView1.DataSource = podaci;
        }
    }
}
