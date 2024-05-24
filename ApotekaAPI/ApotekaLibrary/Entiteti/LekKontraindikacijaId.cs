using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApotekaLibrary.Entiteti
{
    public class LekKontraindikacijaId
    {
        public virtual Lek LekIzaziva { get; set; }
        public virtual Bolest IzazivaBolest { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(LekKontraindikacijaId))
                return false;

            LekKontraindikacijaId receivedObject = (LekKontraindikacijaId)obj;

            if ((LekIzaziva.KomercijalniNaziv == receivedObject.LekIzaziva.KomercijalniNaziv) &&
               (IzazivaBolest.Id == receivedObject.IzazivaBolest.Id))
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
