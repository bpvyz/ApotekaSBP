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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Apoteka.Forme
{
    public partial class IzmeniBolestForm : Form
    {
        BolestBasic bolest;
        public IzmeniBolestForm()
        {
            InitializeComponent();
        }

        public IzmeniBolestForm(BolestBasic bolest)
        {
            InitializeComponent();
            this.bolest = bolest;
        }

        private void IzmeniBolestForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            popuniPodacima();
        }

        private void button6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button6.ClientRectangle,
   SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
   SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
   SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
   SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }
        public void popuniPodacima()
        {
            textBox1.Text = bolest.Naziv;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bolest.Naziv = textBox1.Text;
            
            DTOManager.IzmeniBolest(bolest);
            MessageBox.Show("Uspešno ste izmenili bolest!");
            this.Close();
        }
    }
}
