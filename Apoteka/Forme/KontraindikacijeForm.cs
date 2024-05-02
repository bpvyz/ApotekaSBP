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
        LekBasic lek;
        public KontraindikacijeForm()
        {
            InitializeComponent();
        }
        public KontraindikacijeForm(LekBasic lek)
        {
            InitializeComponent();
            this.lek = lek;
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
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<BolestPregled> podaci = DTOManager.vratiKontraindikacijeZaLek(lek.KomercijalniNaziv);

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
