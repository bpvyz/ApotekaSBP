using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApotekaLibrary.Entiteti
{
    public class Lek
    {
        public virtual string KomercijalniNaziv { get; set; }
        public virtual string HemijskiNaziv { get; set; }
        public virtual string NacinDoziranjaOdrasli { get; set; }
        public virtual string NacinDoziranjaDeca { get; set; }
        public virtual string NacinDoziranjaTrudnice { get; set; }
        public virtual bool IzdajeSeNaRecept { get; set; }
        public virtual float ProcenatParticipacije { get; set; }
        public virtual float Cena { get; set; }
        public virtual IList<Pakovanje> Pakovanja { get; set; }
        public virtual IList<LekLeci> Leci { get; set; }
        public virtual IList<LekKontraindikacija> Kontraindikacije { get; set; }
        public virtual GrupaLekova GrupaLekova { get; set; }
        public virtual ProdajnoMesto ProdajnoMesto { get; set; }
        public virtual IList<Recept> Recepti { get; set; }
        public Lek() 
        {
            Pakovanja = new List<Pakovanje>();
            Leci = new List<LekLeci>();
            Kontraindikacije = new List<LekKontraindikacija>();
            GrupaLekova = new GrupaLekova();
            ProdajnoMesto = new ProdajnoMesto();
            Recepti = new List<Recept>();
        }

        public override string ToString()
        {
            return $"{KomercijalniNaziv}";
        }
    }
}
