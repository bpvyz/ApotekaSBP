using Apoteka.Entiteti;
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
    public partial class IzmeniProdajnoMestoForm : Form
    {
        ProdajnoMestoBasic prodajnomesto;

        public IzmeniProdajnoMestoForm()
        {
            InitializeComponent();
        }

        public IzmeniProdajnoMestoForm(ProdajnoMestoBasic prodajnomesto)
        {
            InitializeComponent();
            this.prodajnomesto = prodajnomesto;
        }

        private void IzmeniProdajnoMestoForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }

        private void popuniPodacima()
        {
            textBox3.Text = prodajnomesto.Adresa;
            textBox1.Text = prodajnomesto.Naziv;
            textBox4.Text = prodajnomesto.Mesto;
        }

        private void btnIzmeniProdajnoMesto_Click(object sender, EventArgs e)
        {
            prodajnomesto.Adresa = textBox3.Text;
            prodajnomesto.Naziv = textBox1.Text;
            prodajnomesto.Mesto = textBox4.Text;
            DTOManager.izmeniProdajnoMesto(prodajnomesto);
            MessageBox.Show("Uspešno ste izmenili prodajno mesto!");
            this.Close();
        }
    }
}
