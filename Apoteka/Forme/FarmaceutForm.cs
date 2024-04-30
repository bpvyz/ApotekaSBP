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
        public FarmaceutForm()
        {
            InitializeComponent();
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
            IzdatiReceptiForm forma = new IzdatiReceptiForm();
            forma.ShowDialog();
        }

        private void FarmaceutForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
    }
}
