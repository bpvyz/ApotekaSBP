using Apoteka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Mapiranja
{
    public class LekLeciMapiranja : ClassMap<LekLeci>
    {
        public LekLeciMapiranja()
        {
            Table("LEK_LECI");

            CompositeId()
            .KeyReference(x => x.Lek, "LEK_ID")
            .KeyReference(x => x.Bolest, "BOLEST_ID");
        }
    }
}
