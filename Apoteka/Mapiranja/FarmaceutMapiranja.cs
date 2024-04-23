using Apoteka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Mapiranja
{
    public class FarmaceutMapiranja : ClassMap<Farmaceut>
    {
        public FarmaceutMapiranja()
        {
            Table("FARMACEUT");

            Id(x => x.ZaposleniId).Column("ZAPOSLENI_ID").GeneratedBy.Assigned();
            Map(x => x.DatumDiplomiranja).Column("DATUM_DIPLOMIRANJA").Not.Nullable();
            Map(x => x.DatumObnoveLicence).Column("DATUM_OBNOVE_LICENCE").Not.Nullable();
            References(x => x.Zaposleni).Column("ZAPOSLENI_ID").Not.Nullable().Unique();
            HasMany(x => x.Recepti).KeyColumn("FARMACEUT_ID").Cascade.All();
        }
    }
}
