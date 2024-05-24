using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApotekaLibrary.Entiteti
{
    public class Recept
    {
        public virtual int SerijskiBroj { get; set; }
        public virtual string SifraLekara { get; set; }
        public virtual string Tip { get; set; }
        public virtual int Kolicina { get; set; }
        public virtual DateTime DatumIzdavanja { get; set; }
        public virtual DateTime? DatumRealizacije { get; set; }
        public virtual ProdajnoMesto ProdajnoMesto { get; set; }
        public virtual Farmaceut Farmaceut { get; set; }
        public virtual Lek Lek { get; set; }
        public virtual Pakovanje OblikPakovanja { get; set; }
        public Recept()
        {
            DatumIzdavanja = DateTime.Now;
            DatumRealizacije = DateTime.Now;
            ProdajnoMesto = new ProdajnoMesto();
            Farmaceut = new Farmaceut();
            Lek = new Lek();
            OblikPakovanja = new Pakovanje();
        }

    }
}
