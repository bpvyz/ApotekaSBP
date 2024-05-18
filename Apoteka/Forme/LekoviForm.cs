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
            this.popuniPodacima();
        }

        private void btnIzmeniLek_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite lek koji želite da izmenite!");
                return;
            }
            string idLeka = (string)dataGridView1.SelectedRows[0].Cells["KomercijalniNaziv"].Value;
            LekBasic lek = DTOManager.vratiLek(idLeka);
            IzmeniLekForm forma = new IzmeniLekForm(lek);
            forma.ShowDialog();
            this.popuniPodacima();
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
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite lek koje želite da obrišete!");
                return;
            }

            string idLeka = (string)dataGridView1.SelectedRows[0].Cells["KomercijalniNaziv"].Value;
            string poruka = "Da li želite da obrišete izabrani lek?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiLek(idLeka);
                MessageBox.Show("Brisanje leka je uspešno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
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

        private void button6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button1.ClientRectangle,
       SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
       SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
       SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
       SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }
    }
}
