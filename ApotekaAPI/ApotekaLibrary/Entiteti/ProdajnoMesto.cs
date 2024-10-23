using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApotekaLibrary.Entiteti
{
    public class ProdajnoMesto
    {
        public virtual string JedinstveniBroj { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string Mesto { get; set; }
        public virtual IList<Zaposleni> Zaposleni { get; set; }
        public virtual IList<Recept> Recepti { get; set; }
        internal ProdajnoMesto()
        {
            Zaposleni = new List<Zaposleni>();
            Recepti = new List<Recept>();
        }
    }
}
