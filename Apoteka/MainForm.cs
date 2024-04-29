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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ProdajnaMestaButton_Click(object sender, EventArgs e)
        {
            ProdajnaMestaForm forma = new ProdajnaMestaForm();
            forma.ShowDialog();
        }

        private void SviZaposleniButton_Click(object sender, EventArgs e)
        {
            SviZaposleniForm forma = new SviZaposleniForm();
            forma.ShowDialog();
        }

        private void LekoviButton_Click(object sender, EventArgs e)
        {
            LekoviForm forma = new LekoviForm();
            forma.ShowDialog();
        }

        private void btnSveBolesti_Click(object sender, EventArgs e)
        {
            SveBolestiForm forma = new SveBolestiForm();
            forma.ShowDialog();
        }
    }
}
