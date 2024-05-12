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
        FarmaceutBasic farmaceut;
        ProdajnoMestoBasic prodajnomesto;
        public IzdatiReceptiForm()
        {
            InitializeComponent();
        }

        public IzdatiReceptiForm(FarmaceutBasic f)
        {
            InitializeComponent();
            farmaceut = f;
            button6.Click += btnObrisiReceptFarmaceuta_Click;
            popuniPodacimaFarmaceut();
        }

        public IzdatiReceptiForm(ProdajnoMestoBasic pm)
        {
            InitializeComponent();
            prodajnomesto = pm;
            groupBox1.Text = "Podaci o receptima prodajnog mesta";
            button6.Click += btnObrisiReceptProdajnogMesta_Click;
            popuniPodacimaProdajnoMesto();
        }

        private void btnIzmeniRecept_Click(object sender, EventArgs e)
        {
            IzmeniReceptForm forma = new IzmeniReceptForm();
            forma.ShowDialog();
        }

        private void IzdatiReceptiForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void btnObrisiReceptProdajnogMesta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite recept koji želite da obrišete!");
                return;
            }

            int idRecepta = (int)dataGridView1.SelectedRows[0].Cells["SerijskiBroj"].Value;
            string poruka = "Da li želite da obrišete izabrani recept?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiRecept(idRecepta);
                MessageBox.Show("Brisanje recepta je uspešno obavljeno!");
                this.popuniPodacimaProdajnoMesto();
            }
            else
            {

            }
        }

        private void btnObrisiReceptFarmaceuta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite recept koji želite da obrišete!");
                return;
            }

            int idRecepta = (int)dataGridView1.SelectedRows[0].Cells["SerijskiBroj"].Value;
            string poruka = "Da li želite da obrišete izabrani recept?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiRecept(idRecepta);
                MessageBox.Show("Brisanje recepta je uspešno obavljeno!");
                this.popuniPodacimaFarmaceut();
            }
            else
            {

            }
        }

        public void popuniPodacimaFarmaceut()
        {
            List<ReceptPregled> podaci = DTOManager.vratiRecepteFarmaceuta(farmaceut);
            var modifiedPodaci = podaci.Select(r => new
            {
                r.SerijskiBroj,
                r.SifraLekara,
                r.Tip,
                OblikPakovanja = r.OblikPakovanja.Oblik + " " + r.OblikPakovanja.Sastav,
                r.Kolicina,
                r.DatumIzdavanja,
                r.DatumRealizacije,
                ProdajnoMesto = r.ProdajnoMesto.JedinstveniBroj,
                Farmaceut = r.Farmaceut.JedinstveniBroj,
                Lek = r.Lek.KomercijalniNaziv
            }).ToList();

            dataGridView1.DataSource = modifiedPodaci;
        }

        public void popuniPodacimaProdajnoMesto()
        {
            List<ReceptPregled> podaci = DTOManager.vratiRecepteProdajnogMesta(prodajnomesto);
            var modifiedPodaci = podaci.Select(r => new
            {
                r.SerijskiBroj,
                r.SifraLekara,
                r.Tip,
                OblikPakovanja = r.OblikPakovanja.Oblik + " " + r.OblikPakovanja.Sastav,
                r.Kolicina,
                r.DatumIzdavanja,
                r.DatumRealizacije,
                ProdajnoMesto = r.ProdajnoMesto.JedinstveniBroj,
                Farmaceut = r.Farmaceut.JedinstveniBroj,
                Lek = r.Lek.KomercijalniNaziv
            }).ToList();

            dataGridView1.DataSource = modifiedPodaci;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                button7.PerformClick();
            }

            if (keyData == (Keys.F1))
            {
                button8.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                this.button8.Text = "Smanji prozor <F1>";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.button8.Text = "Proširi prozor <F1>";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button5.ClientRectangle,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }
    }
}
