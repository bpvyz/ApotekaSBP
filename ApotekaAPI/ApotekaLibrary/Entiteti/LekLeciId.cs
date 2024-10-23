using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApotekaLibrary.Entiteti
{
    public class LekLeciId
    {
        public virtual Lek LekLeci { get; set; }
        public virtual Bolest LeciBolest { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(LekLeciId))
                return false;

            LekLeciId receivedObject = (LekLeciId)obj;

            if((LekLeci.KomercijalniNaziv == receivedObject.LekLeci.KomercijalniNaziv) &&
               (LeciBolest.Id == receivedObject.LeciBolest.Id))
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
