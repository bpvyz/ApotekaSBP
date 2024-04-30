using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Entiteti
{
    public class LekKontraindikacija
    {
        public virtual Lek Lek { get; protected set; }
        public virtual Bolest Bolest { get; protected set; }

        public override bool Equals(object obj)
        {
            var other = obj as LekKontraindikacija;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.Lek == other.Lek &&
                this.Bolest == other.Bolest;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ Lek.GetHashCode();
                hash = (hash * 31) ^ Bolest.GetHashCode();

                return hash;
            }
        }
    }


}
