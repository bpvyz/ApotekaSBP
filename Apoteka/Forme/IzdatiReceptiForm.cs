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
    public partial class IzdatiReceptiForm : Form
    {
        public IzdatiReceptiForm()
        {
            InitializeComponent();
        }

        private void btnIzmeniRecept_Click(object sender, EventArgs e)
        {
            IzmeniReceptForm forma = new IzmeniReceptForm();
            forma.ShowDialog();
        }

        private void IzdatiReceptiForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
    }
}
