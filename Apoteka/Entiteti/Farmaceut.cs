using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Entiteti
{
    public class Farmaceut : Zaposleni
    {
        public DateTime DatumDiplomiranja { get; set; }
        public DateTime DatumObnoveLicence { get; set; }
        public virtual IList<Recept> RealizovaoRecepte { get; set; }
        public Farmaceut()
        {

        }
    }
}
