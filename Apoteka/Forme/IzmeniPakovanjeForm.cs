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

namespace Apoteka.Forme
{
    public partial class IzmeniPakovanjeForm : Form
    {
        PakovanjaBasic pakovanje;
        public IzmeniPakovanjeForm()
        {
            InitializeComponent();
        }

        public IzmeniPakovanjeForm(PakovanjaBasic pak)
        {
            InitializeComponent();
            this.pakovanje = pak;
        }

        private void IzmeniPakovanjeForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            comboBox1.SelectedItem = pakovanje.Oblik;
            textBox2.Text = pakovanje.Sastav;
            numericUpDown1.Value = pakovanje.Kolicina;
        }

        private void btnIzmeniPakovanje_Click(object sender, EventArgs e)
        {
            pakovanje.Oblik = (string)comboBox1.SelectedItem;
            pakovanje.Kolicina = (int)numericUpDown1.Value;
            pakovanje.Sastav = textBox2.Text;
            DTOManager.IzmeniPakovanje(pakovanje);
            MessageBox.Show("Uspešno ste izmenili pakovanje!");
            this.Close();
        }

        private void btnIzmeniPakovanje_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button6.ClientRectangle,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }

    }
}
