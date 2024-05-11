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

            Id(x => x.ZalihaGrupaLekovaId).Column("ZALIHA_GRUPA_LEKOVA_ID").GeneratedBy.TriggerIdentity();
            //zavrsi

            Map(x => x.Kolicina).Column("KOLICINA").Not.Nullable();
        }
    }
}
