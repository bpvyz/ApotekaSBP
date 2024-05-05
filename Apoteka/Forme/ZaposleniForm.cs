using Apoteka.Entiteti;
using Apoteka.Forme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apoteka
{
    public partial class ZaposleniForm : Form
    {
        ProdajnoMestoBasic prodajnomesto;
        public ZaposleniForm()
        {
            InitializeComponent();
        }
        public ZaposleniForm(ProdajnoMestoBasic p)
        {
            InitializeComponent();
            prodajnomesto = p;
        }

        private void btnDodajZaposlenog_Click(object sender, EventArgs e)
        {
            DodajZaposlenogForm forma = new DodajZaposlenogForm(prodajnomesto);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void btnIzmeniZaposlenog_Click(object sender, EventArgs e)
        {
            string idZaposlenog = (string)dataGridView1.SelectedRows[0].Cells["JedinstveniBroj"].Value;
            try
            {
                FarmaceutBasic farmaceut = DTOManager.vratiFarmaceuta(idZaposlenog);
                IzmeniZaposlenogForm forma = new IzmeniZaposlenogForm(farmaceut);
                forma.ShowDialog();
            }
            catch (Exception ec)
            {
                ZaposleniBasic zaposleni = DTOManager.vratiZaposlenog(idZaposlenog);
                IzmeniZaposlenogForm forma = new IzmeniZaposlenogForm(zaposleni);
                forma.ShowDialog();
            }
            popuniPodacima();
        }

        

        private void btnObrisiZaposlenog_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite zaposlenog kojeg želite da obrišete!");
                return;
            }

            string idZaposlenog = (string)dataGridView1.SelectedRows[0].Cells["JedinstveniBroj"].Value;
            string poruka = "Da li želite da obrišete izabranog zaposlenog?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiZaposlenog(idZaposlenog);
                MessageBox.Show("Brisanje zaposlenog je uspešno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }

        private void ZaposleniForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            List<ZaposleniPregled> podaci = DTOManager.vratiZaposleneProdajnogMesta(prodajnomesto.JedinstveniBroj);
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

        private void button5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button5.ClientRectangle,
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
    }
}
