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
    public partial class LekoviForm : Form
    {
        
        public LekoviForm()
        {
            InitializeComponent();
        }
        private void btnDodajLek_Click(object sender, EventArgs e)
        {
            DodajLekForm forma = new DodajLekForm();
            forma.ShowDialog();
        }

        private void btnIzmeniLek_Click(object sender, EventArgs e)
        {
            IzmeniLekForm forma = new IzmeniLekForm();
            forma.ShowDialog();
        }

        private void btnIndikacije_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite lek čije indikacije želite da vidite!");
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string idLeka = selectedRow.Cells[0].Value.ToString();

            LekBasic l = DTOManager.vratiLek(idLeka);
            IndikacijeForm forma = new IndikacijeForm(l);
            forma.ShowDialog();
        }

        private void btnKontraindikacije_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite lek čije kontraindikacije želite da vidite!");
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string idLeka = selectedRow.Cells[0].Value.ToString();

            LekBasic l = DTOManager.vratiLek(idLeka);
            KontraindikacijeForm forma = new KontraindikacijeForm(l);
            forma.ShowDialog();
        }

        private void btnPakovanja_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite lek čije pakovanja želite da vidite!");
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string idLeka = selectedRow.Cells[0].Value.ToString();

            LekBasic l = DTOManager.vratiLek(idLeka);
            PakovanjaForm forma = new PakovanjaForm(l);
            forma.ShowDialog();
        }

        private void btnObrisiLek_Click(object sender, EventArgs e)
        {
            // TODO: Obrisi lek
        }

        private void LekoviForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<LekPregled> podaci = DTOManager.vratiSveLekove();
            dataGridView1.DataSource = podaci;
        }
    }
}
