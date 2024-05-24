using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApotekaLibrary.Entiteti
{
    public class Zaposleni
    {
        public virtual string JedinstveniBroj { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string BrojTelefona { get; set; }
        public virtual ProdajnoMesto ProdajnoMesto { get; set; }

        public Zaposleni() 
        { 
            ProdajnoMesto = new ProdajnoMesto();
        }

        public class ZaposleniBasic
        {
            public string JedinstveniBroj { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public string Adresa { get; set; }
            public string BrojTelefona { get; set; }
        }
    }
}
