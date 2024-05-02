using NHibernate;
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
        LekBasic lek;
        public IndikacijeForm()
        {
            InitializeComponent();
        }
        public IndikacijeForm(LekBasic Lek)
        {
            InitializeComponent();
            this.lek = Lek;
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

        private void IndikacijeForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<BolestPregled> podaci = DTOManager.vratiIndikacijeZaLek(lek.KomercijalniNaziv);

            dataGridView1.Columns.Clear(); // Clear any existing columns


            // Create a column for the Bolest property
            DataGridViewTextBoxColumn bolestColumn = new DataGridViewTextBoxColumn();
            bolestColumn.DataPropertyName = "Naziv";
            bolestColumn.HeaderText = "Bolest";
            dataGridView1.Columns.Add(bolestColumn);

            dataGridView1.AutoGenerateColumns = false; // Disable automatic column generation
            dataGridView1.DataSource = podaci;
        }
    }
}
