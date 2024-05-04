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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Apoteka.Forme
{
    public partial class IzmeniLekForm : Form
    {
        LekBasic lek;
        public IzmeniLekForm()
        {
            InitializeComponent();
        }

        public IzmeniLekForm(LekBasic lek)
        {
            InitializeComponent();
            this.lek = lek;  
        }

        private void IzmeniLekForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }

        private void btnIzmeniLek_Click(object sender, EventArgs e)
        {
            lek.Cena = (float)numericUpDown2.Value;
            lek.ProcenatParticipacije = (float)numericUpDown1.Value;
            lek.IzdajeSeNaRecept = checkBox1.Checked;
            lek.NacinDoziranjaDeca = textBox6.Text;
            lek.NacinDoziranjaOdrasli = textBox5.Text;
            lek.NacinDoziranjaTrudnice = textBox3.Text;
            lek.HemijskiNaziv = textBox2.Text;
            DTOManager.IzmeniLek(lek);
            MessageBox.Show("Uspešno ste izmenili lek!");
            this.Close();
        }

        public void popuniPodacima()
        {
            textBox2.Text = lek.HemijskiNaziv;
            numericUpDown1.Value = (decimal)lek.ProcenatParticipacije;
            numericUpDown2.Value = (decimal)lek.Cena;
            textBox3.Text = lek.NacinDoziranjaTrudnice;
            textBox5.Text = lek.NacinDoziranjaOdrasli;
            textBox6.Text = lek.NacinDoziranjaDeca;
            checkBox1.Checked = lek.IzdajeSeNaRecept;
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
