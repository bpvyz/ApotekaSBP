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
    public partial class DodajPakovanjeForm : Form
    {
        LekBasic Lek;
        public DodajPakovanjeForm()
        {
            InitializeComponent();
        }

        public DodajPakovanjeForm(LekBasic lek)
        {
            this.Lek = lek;
            InitializeComponent();
        }

        private void DodajPakovanjeForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void btnDodajPakovanje_Click(object sender, EventArgs e)
        {
            PakovanjaBasic pakovanje = new PakovanjaBasic();
            pakovanje.Oblik = (string)comboBox1.SelectedItem;
            pakovanje.Kolicina = (int)numericUpDown1.Value;
            pakovanje.Sastav = textBox2.Text;
            pakovanje.Lek = this.Lek;

            DTOManager.dodajPakovanje(pakovanje);

            MessageBox.Show("Uspesno ste dodali novo pakovanje!");
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
