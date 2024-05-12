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
            // TODO: Obrisi farmaceuta
        }

        private void btnIzdajRecept_Click(object sender, EventArgs e)
        {
            IzdajReceptForm forma = new IzdajReceptForm();
            forma.ShowDialog();
        }

        private void btnIzdatiRecepti_Click(object sender, EventArgs e)
        {
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
