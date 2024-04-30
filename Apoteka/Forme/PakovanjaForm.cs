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
    public partial class PakovanjaForm : Form
    {
        public PakovanjaForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnDodajPakovanje_Click(object sender, EventArgs e)
        {
            DodajPakovanjeForm forma = new DodajPakovanjeForm();
            forma.ShowDialog();
            //TODO: Resiti problem kako identifikovati koja zaliha grupa lekova pripada kojem prodajnom mestu
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IzmeniPakovanjeForm forma = new IzmeniPakovanjeForm();
            forma.ShowDialog();
        }
    }
}
