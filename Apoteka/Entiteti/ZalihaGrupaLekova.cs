using NHibernate.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Entiteti
{
    public class ZalihaGrupaLekova
    {
        public virtual ProdajnoMesto ProdajnoMesto { get; protected set; }
        public virtual GrupaLekova GrupaLekova { get; protected set; }
        public virtual int Kolicina { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as ZalihaGrupaLekova;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.ProdajnoMesto == other.ProdajnoMesto &&
                this.GrupaLekova == other.GrupaLekova;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ ProdajnoMesto.GetHashCode();
                hash = (hash * 31) ^ GrupaLekova.GetHashCode();

                return hash;
            }
        }
    }
}
