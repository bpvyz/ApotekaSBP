using ApotekaLibrary.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApotekaLibrary.Mapiranja
{
    public class LekLeciMapiranja : ClassMap<LekLeci>
    {
        public LekLeciMapiranja()
        {
            Table("LEK_LECI");

            CompositeId(x => x.Id)
                .KeyReference(x => x.LekLeci, "LEK_ID")
                .KeyReference(x => x.LeciBolest, "BOLEST_ID");

        }
    }


}
