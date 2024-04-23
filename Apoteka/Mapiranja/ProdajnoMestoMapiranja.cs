using Apoteka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Mapiranja
{
    public class ProdajnoMestoMapiranja : ClassMap<ProdajnoMesto>
    {
        public ProdajnoMestoMapiranja()
        {
            Table("PRODAJNO_MESTO");

            Id(x => x.JedinstveniBroj).Column("JEDINSTVENI_BROJ").GeneratedBy.Assigned();
            Map(x => x.Naziv).Column("NAZIV").Not.Nullable();
            Map(x => x.Adresa).Column("ADRESA").Not.Nullable();
            Map(x => x.Mesto).Column("MESTO").Not.Nullable();
            HasMany(x => x.Zaposleni).KeyColumn("PRODAJNO_MESTO_ID").Cascade.All();
            HasMany(x => x.Recepti).KeyColumn("PRODAJNO_MESTO_ID").Cascade.All();
            HasMany(x => x.ZaliheGrupaLekova).KeyColumn("PRODAJNO_MESTO_ID").Inverse().Cascade.All();
        }
    }
}
