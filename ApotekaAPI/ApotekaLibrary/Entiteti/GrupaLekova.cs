using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApotekaLibrary.Entiteti
{
    public class GrupaLekova
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual IList<Lek> Lekovi { get; set; }
        public GrupaLekova()
        {
            Lekovi = new List<Lek>();
        }
    }
}
