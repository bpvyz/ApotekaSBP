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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Apoteka.Forme
{
    public partial class DodajIndikacijuForm : Form
    {
        LekBasic lek;
        public DodajIndikacijuForm()
        {
            InitializeComponent();
        }

        public DodajIndikacijuForm(LekBasic lek)
        {
            InitializeComponent();
            this.lek = lek;
        }

        private void DodajIndikacijuForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            List<BolestPregled> bolesti = DTOManager.vratiSveBolesti();
            comboBox2.DisplayMember = "Naziv";
            foreach (BolestPregled bolest in bolesti)
            {
                comboBox2.Items.Add(bolest);
            }
        }

        private void btnDodajIndikaciju_Click(object sender, EventArgs e)
        {
            LekLeciBasic indikacija = new LekLeciBasic();
            indikacija.Id.LeciBolest = (Entiteti.Bolest)comboBox2.SelectedItem;
            //indikacija.Id.LekLeci = 
            //TODO: Zavrsi
            DTOManager.dodajIndikaciju(lek);

            MessageBox.Show("Uspešno ste dodali novu indikaciju!");
            this.Close();
        }
    }
}
