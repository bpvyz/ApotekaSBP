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
    public partial class SveBolestiForm : Form
    {
        public SveBolestiForm()
        {
            InitializeComponent();
        }

        private void btnDodajBolest_Click(object sender, EventArgs e)
        {
            DodajBolestForm forma = new DodajBolestForm();
            forma.ShowDialog();
            popuniPodacima();
        }

        private void btnIzmeniBolest_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite lek koje želite da izmenite!");
                return;
            }

            int idBolesti = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            BolestBasic bolest = DTOManager.vratiBolest(idBolesti);
            IzmeniBolestForm forma = new IzmeniBolestForm(bolest);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void btnObrisiBolest_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite bolest koju želite da obrišete!");
                return;
            }

            int idBolesti = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            string poruka = "Da li želite da obrišete izabranu bolest?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiBolest(idBolesti);
                MessageBox.Show("Brisanje bolesti je uspešno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }

        private void SveBolestiForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<BolestPregled> podaci = DTOManager.vratiSveBolesti();
            dataGridView1.DataSource = podaci;
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

        private void button5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button5.ClientRectangle,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
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
    }
}
