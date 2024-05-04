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
            foreach(GrupaLekovaPregled grupa in grupe)
            {
                comboBox1.Items.Add(grupa.Id);
            }
            foreach (ProdajnoMestoPregled prodajnomesto in prodajnamesta)
            {
                comboBox2.Items.Add(prodajnomesto.JedinstveniBroj);
            }
            toolTip1.OwnerDraw = true;
            toolTip1.SetToolTip(comboBox1, "1 - Antibiotici\n2 - Analgetici\n3 - Antipiretici\n4 - Diuretici");
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
            int gl = (int)comboBox1.SelectedItem;
            string pm = comboBox2.SelectedItem.ToString();

            DTOManager.dodajLek(lek, gl, pm);

            MessageBox.Show("Uspešno ste dodali novi lek!");
        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();

            e.Graphics.FillRectangle(Brushes.DarkGreen, e.Bounds);

            e.DrawBorder();

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
                sf.FormatFlags = StringFormatFlags.NoWrap;
                using (Font f = new Font("Tahoma", 9))
                {
                    e.Graphics.DrawString(e.ToolTipText, f,
                        Brushes.White, e.Bounds, sf);
                }
            }
        }
    }
}
