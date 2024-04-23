using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Entiteti
{
    public class Recept
    {
        public virtual string SerijskiBroj { get; set; }
        public virtual string SifraLekara { get; set; }
        public virtual string Tip { get; set; }
        public virtual string OblikPakovanja { get; set; }
        public virtual int KolicinaLeka { get; set; }
        public virtual DateTime DatumIzdavanja { get; set; }
        public virtual DateTime DatumRealizacije { get; set; }
        public virtual ProdajnoMesto RealizovanNa { get; set; }
        public virtual Farmaceut RealizovaoFarmaceut { get; set; }
        public virtual Lek IzdatZaLek { get; set; }
        public Recept()
        {

        }

    }
}
