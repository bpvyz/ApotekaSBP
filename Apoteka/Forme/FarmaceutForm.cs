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
    public partial class FarmaceutForm : Form
    {
        ProdajnoMestoBasic prodajnomesto;
        public FarmaceutForm()
        {
            InitializeComponent();
        }

        public FarmaceutForm(ProdajnoMestoBasic p)
        {
            InitializeComponent();
            prodajnomesto = p;
        }

        private void btnObrisiFarmaceuta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite farmaceuta kojeg želite da obrišete!");
                return;
            }

            string idFarmaceuta = (string)dataGridView1.SelectedRows[0].Cells["JedinstveniBroj"].Value;
            string poruka = "Da li želite da obrišete izabranog farmaceuta?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiFarmaceuta(idFarmaceuta);
                MessageBox.Show("Brisanje farmaceuta je uspešno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }

        private void btnIzdajRecept_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite farmaceuta za kojeg želite da izdate recept!");
                return;
            }
            FarmaceutBasic farmaceut = DTOManager.vratiFarmaceuta((string)dataGridView1.SelectedRows[0].Cells["JedinstveniBroj"].Value);
            IzdajReceptForm forma = new IzdajReceptForm(prodajnomesto, farmaceut);
            forma.ShowDialog();
        }

        private void btnIzdatiRecepti_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite farmaceuta za kojeg želite da vidite izdate recepte!");
                return;
            }
            string idFarmaceuta = (string)dataGridView1.SelectedRows[0].Cells["JedinstveniBroj"].Value;
            FarmaceutBasic farmaceut = DTOManager.vratiFarmaceuta(idFarmaceuta);
            IzdatiReceptiForm forma = new IzdatiReceptiForm(farmaceut);
            forma.ShowDialog();
        }

        private void FarmaceutForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<FarmaceutPregled> podaci = DTOManager.vratiFarmaceuteProdajnogMesta(prodajnomesto.JedinstveniBroj);
            dataGridView1.DataSource = podaci;
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
    }
}
