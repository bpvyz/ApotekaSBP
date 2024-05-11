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
            DodajIndikacijuForm forma = new DodajIndikacijuForm(lek);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void btnObrisiIndikaciju_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite indikaciju koju želite da obrišete!");
                return;
            }

            BolestBasic indikacija = DTOManager.vratiBolest((int)dataGridView1.SelectedRows[0].Cells["Id"].Value);
            string poruka = "Da li želite da obrišete izabranu indikaciju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiIndikaciju(lek, indikacija);
                MessageBox.Show("Brisanje indikacije je uspešno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }

        private void IndikacijeForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<BolestPregled> podaci = DTOManager.vratiIndikacijeZaLek(lek.KomercijalniNaziv);

            dataGridView1.Columns.Clear();

            dataGridView1.DataSource = podaci;
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

        private void button9_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button9.ClientRectangle,
       SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
       SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
       SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
       SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }
    }
}
