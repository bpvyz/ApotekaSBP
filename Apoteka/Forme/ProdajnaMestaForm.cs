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
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite prodajno mesto koje želite da izmenite!");
                return;
            }

            string idProdajnogMesta = (string)dataGridView1.SelectedRows[0].Cells["JedinstveniBroj"].Value;
            ProdajnoMestoBasic prodajnomesto = DTOManager.vratiProdajnoMesto(idProdajnogMesta);
            IzmeniProdajnoMestoForm forma = new IzmeniProdajnoMestoForm(prodajnomesto);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void btnZaposleni_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite prodajno mesto cije zaposlene zelite da vidite!");
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string idProdajnogMesta = selectedRow.Cells[0].Value.ToString();

            ProdajnoMestoBasic p = DTOManager.vratiProdajnoMesto(idProdajnogMesta);
            ZaposleniForm forma = new ZaposleniForm(p);
            forma.ShowDialog();
        }

        private void btnZaliheLekova_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite prodajno mesto cije zalihe zelite da vidite!");
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string idProdajnogMesta = selectedRow.Cells[0].Value.ToString();

            ProdajnoMestoBasic p = DTOManager.vratiProdajnoMesto(idProdajnogMesta);
            ZaliheLekovaForm forma = new ZaliheLekovaForm(p);
            forma.ShowDialog();
        }

        private void btnIzdatiRecepti_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite prodajno mesto cije recepte zelite da vidite!");
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string idProdajnogMesta = selectedRow.Cells[0].Value.ToString();

            ProdajnoMestoBasic p = DTOManager.vratiProdajnoMesto(idProdajnogMesta);
            IzdatiReceptiForm forma = new IzdatiReceptiForm(p);
            forma.ShowDialog();
        }

        private void btnObrisiProdajnoMesto_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite prodajno mesto koje želite da obrišete!");
                return;
            }

            string idProdajnoMesto = (string)dataGridView1.SelectedRows[0].Cells["JedinstveniBroj"].Value;
            string poruka = "Da li želite da obrišete izabrano prodajno mesto?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiProdajnoMesto(idProdajnoMesto);
                MessageBox.Show("Brisanje prodajnog mesta je uspešno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
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

        private void button1_Paint(object sender, PaintEventArgs e)
        {
        ControlPaint.DrawBorder(e.Graphics, button1.ClientRectangle,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(this.WindowState  == FormWindowState.Normal)
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

        private void btnFarmaceuti_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite prodajno mesto čije recepte želite da vidite!");
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string idProdajnogMesta = selectedRow.Cells[0].Value.ToString();

            ProdajnoMestoBasic p = DTOManager.vratiProdajnoMesto(idProdajnogMesta);
            FarmaceutForm forma = new FarmaceutForm(p);
            forma.ShowDialog();
        }
    }
}
