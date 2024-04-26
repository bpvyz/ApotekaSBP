using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Entiteti
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
            //inicijalizacija za prodajno mesto???
        }
    }
}
