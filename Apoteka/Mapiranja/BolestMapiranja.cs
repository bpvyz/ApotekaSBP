using Apoteka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Mapiranja
{
    public class BolestMapiranja : ClassMap<Bolest>
    {
        public BolestMapiranja()
        {
            Table("BOLEST");

            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.Naziv).Column("NAZIV").Not.Nullable().Not.LazyLoad();
            HasMany(x => x.LekLeci).KeyColumn("BOLEST_ID").Inverse().Cascade.All().Not.LazyLoad();
            HasMany(x => x.LekKontraindikacija).KeyColumn("BOLEST_ID").Inverse().Cascade.All().Not.LazyLoad();
        }
    }
}
