using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Entiteti
{
    public class Farmaceut : Zaposleni
    {
        public virtual string ZaposleniId { get; set; }
        public virtual DateTime DatumDiplomiranja { get; set; }
        public virtual DateTime DatumObnoveLicence { get; set; }
        public virtual IList<Recept> Recepti { get; set; }
        public virtual Zaposleni Zaposleni { get; set; }
        public Farmaceut()
        {
            Recepti = new List<Recept>();
            Zaposleni = new Zaposleni();
        }
    }
}
