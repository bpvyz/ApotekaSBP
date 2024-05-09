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
        public virtual ZalihaGrupaLekovaId Id { get; set; }
        public virtual ProdajnoMesto ProdajnoMesto { get; protected set; }
        public virtual GrupaLekova GrupaLekova { get; protected set; }
        public virtual int Kolicina { get; set; }
        
        public ZalihaGrupaLekova() 
        {
            this.Id = new ZalihaGrupaLekovaId();
        }
    }
}
