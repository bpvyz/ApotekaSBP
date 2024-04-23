using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Entiteti
{
    public class Lek
    {
        public string KomercijalniNaziv { get; set; }
        public string HemijskiNaziv { get; set; }
        public string NacinDoziranjaOdrasli { get; set; }
        public string NacinDoziranjaDeca { get; set; }
        public string NacinDoziranjaTrudnice { get; set; }
        public bool IzdajeSeNaRecept { get; set; }
        public float ProcenatParticipacije { get; set; }
        public float Cena { get; set; }
        public Lek() 
        {
      
        }
    }
}
