using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApotekaLibrary.Entiteti
{
    public class LekKontraindikacija
    {
        public virtual LekKontraindikacijaId Id { get; set; }
        public virtual Lek Lek { get; protected set; }
        public virtual Bolest Bolest { get; protected set; }

        internal LekKontraindikacija()
        {
            Id = new LekKontraindikacijaId();
        }
    }


}
