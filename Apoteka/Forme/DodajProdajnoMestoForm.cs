using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Apoteka.Forme
{
    public partial class DodajProdajnoMestoForm : Form
    {
        public DodajProdajnoMestoForm()
        {
            InitializeComponent();
        }

        private void DodajProdajnoMestoForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void btnDodajProdajnoMesto_Click(object sender, EventArgs e)
        {
            ProdajnoMestoBasic prodajnomesto = new ProdajnoMestoBasic();
            prodajnomesto.JedinstveniBroj = textBox2.Text;
            prodajnomesto.Naziv = textBox1.Text;
            prodajnomesto.Adresa = textBox3.Text;
            prodajnomesto.Mesto = textBox4.Text;

            DTOManager.dodajProdajnoMesto(prodajnomesto);

            MessageBox.Show("Uspešno ste dodali novo prodajno mesto");
            this.Close();
        }

        private void button6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button6.ClientRectangle,
       SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
       SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
       SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
       SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }
    }
}
