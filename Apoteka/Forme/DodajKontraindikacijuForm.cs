﻿using System;
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
    public partial class DodajKontraindikacijuForm : Form
    {
        LekBasic lek;
        public DodajKontraindikacijuForm()
        {
            InitializeComponent();
        }

        public DodajKontraindikacijuForm(LekBasic lek)
        {
            InitializeComponent();
            this.lek = lek;
        }

        private void DodajKontraindikacijuForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            List<BolestPregled> bolesti = DTOManager.vratiSveBolesti();
            comboBox2.DisplayMember = "Naziv";
            foreach (BolestPregled bolest in bolesti)
            {
                comboBox2.Items.Add(bolest);
            }
        }

        private void btnDodajKontraindikaciju_Click(object sender, EventArgs e)
        {
            BolestBasic bp = DTOManager.vratiBolest(((BolestPregled)comboBox2.SelectedItem).Id);

            DTOManager.dodajKontraindikaciju(this.lek, bp);

            MessageBox.Show("Uspešno ste dodali novu kontraindikaciju!");
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
