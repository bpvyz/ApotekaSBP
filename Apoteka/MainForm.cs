using Apoteka.Forme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apoteka
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ProdajnaMestaButton_Click(object sender, EventArgs e)
        {
            ProdajnaMestaForm forma = new ProdajnaMestaForm();
            forma.ShowDialog();
        }

        private void SviZaposleniButton_Click(object sender, EventArgs e)
        {
            SviZaposleniForm forma = new SviZaposleniForm();
            forma.ShowDialog();
        }

        private void LekoviButton_Click(object sender, EventArgs e)
        {
            LekoviForm forma = new LekoviForm();
            forma.ShowDialog();
        }

        private void btnSveBolesti_Click(object sender, EventArgs e)
        {
            SveBolestiForm forma = new SveBolestiForm();
            forma.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.Location = new Point(0, 0);
            toolTip1.OwnerDraw = true;
            toolTip2.OwnerDraw = true;
            toolTip3.OwnerDraw = true;
            toolTip4.OwnerDraw = true;
            toolTip1.SetToolTip(button5, "Informacije o prodajnim mestima,\n zaposlenima, \nzalihama lekova i izdatim receptima na datom\n prodajnom mestu sa mogućnošću izmena.");
            toolTip2.SetToolTip(button6, "Spisak svih zaposlenih sa mogućnošću brisanja.");
            toolTip3.SetToolTip(button7, "Spisak svih lekova,\nnjihovih indikacija, kontraindikacija i pakovanja,\nsa mogućnošću izmena.");
            toolTip4.SetToolTip(button8, "Spisak svih bolesti, sa mogućnošću izmena.");
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
        ControlPaint.DrawBorder(e.Graphics, button1.ClientRectangle,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
        SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button1.ClientRectangle,
            SystemColors.ControlLightLight, 0, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 0, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);


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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
 }

