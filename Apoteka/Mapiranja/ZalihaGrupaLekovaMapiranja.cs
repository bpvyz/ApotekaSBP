using Apoteka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Mapiranja
{
    public class ZalihaGrupaLekovaMapiranja : ClassMap<ZalihaGrupaLekova>
    {
        public ZalihaGrupaLekovaMapiranja()
        {
            Table("ZALIHA_GRUPA_LEKOVA");

            CompositeId(x => x.Id)
            .KeyReference(x => x.PripadaProdavnici, "PRODAJNO_MESTO_ID")
            .KeyReference(x => x.ZalihaPripada, "GRUPA_LEKOVA_ID");

            Map(x => x.Kolicina).Column("KOLICINA").Not.Nullable();
        }
    }
}
