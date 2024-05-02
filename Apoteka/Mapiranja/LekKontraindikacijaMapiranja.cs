using Apoteka.Entiteti;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Mapiranja
{
    public class LekKontraindikacijaMapiranja : ClassMap<LekKontraindikacija>
    {
        public LekKontraindikacijaMapiranja()
        {
            Table("LEK_KONTRAINDIKACIJA");

            CompositeId(x => x.Id)
            .KeyReference(x => x.LekIzaziva, "LEK_ID")
            .KeyReference(x => x.IzazivaBolest, "BOLEST_ID");
        }
    }
}
