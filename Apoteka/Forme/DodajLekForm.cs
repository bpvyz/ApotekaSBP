using FluentNHibernate.Automapping;
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
    public partial class DodajLekForm : Form
    {
        public DodajLekForm()
        {
            InitializeComponent();
        }

        private void DodajLekForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            List<GrupaLekovaPregled> grupe = DTOManager.vratiSveGrupeLekova();
            List<ProdajnoMestoPregled> prodajnamesta = DTOManager.vratiSvaProdajnaMesta();
            comboBox1.DisplayMember = "Naziv";
            comboBox2.DisplayMember = "JedinstveniBroj";
            foreach(GrupaLekovaPregled grupa in grupe)
            {
                comboBox1.Items.Add(grupa);
            }
            foreach (ProdajnoMestoPregled prodajnomesto in prodajnamesta)
            {
                comboBox2.Items.Add(prodajnomesto);
            }
        }

        private void btnDodajLek_Click(object sender, EventArgs e)
        {
            LekBasic lek = new LekBasic();
            lek.KomercijalniNaziv = textBox1.Text;
            lek.HemijskiNaziv = textBox2.Text;
            lek.IzdajeSeNaRecept = checkBox1.Checked;
            lek.Cena = (float)numericUpDown2.Value;
            lek.ProcenatParticipacije = (float)numericUpDown1.Value;
            lek.NacinDoziranjaTrudnice = textBox3.Text;
            lek.NacinDoziranjaOdrasli = textBox5.Text;
            lek.NacinDoziranjaDeca = textBox6.Text;
            GrupaLekovaPregled gl = (GrupaLekovaPregled)comboBox1.SelectedItem;
            ProdajnoMestoPregled pm = (ProdajnoMestoPregled)comboBox2.SelectedItem;

            DTOManager.dodajLek(lek, gl, pm);

            MessageBox.Show("Uspešno ste dodali novi lek!");
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
