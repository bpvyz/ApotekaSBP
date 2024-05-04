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
    public partial class DodajBolestForm : Form
    {
        public DodajBolestForm()
        {
            InitializeComponent();
        }

        private void DodajBolestForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void button6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button6.ClientRectangle,
   SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
   SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
   SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
   SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);

        }

        private void btnDodajBolest_Click(object sender, EventArgs e)
        {
            BolestBasic bolest = new BolestBasic();
            bolest.Naziv = textBox1.Text;

            DTOManager.dodajBolest(bolest);

            MessageBox.Show("Uspešno ste dodali novu bolest!");
            this.Close();
        }
    }
}
