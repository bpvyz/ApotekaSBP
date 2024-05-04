using Apoteka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Mapiranja
{
    public class LekMapiranja : ClassMap<Lek>
    {
        public LekMapiranja()
        {
            Table("LEK");

            Id(x => x.KomercijalniNaziv).Column("KOMERCIJALNI_NAZIV").GeneratedBy.Assigned();
            Map(x => x.HemijskiNaziv).Column("HEMIJSKI_NAZIV").Not.Nullable();
            Map(x => x.NacinDoziranjaOdrasli).Column("NACIN_DOZIRANJA_ODRASLI");
            Map(x => x.NacinDoziranjaDeca).Column("NACIN_DOZIRANJA_DECA");
            Map(x => x.NacinDoziranjaTrudnice).Column("NACIN_DOZIRANJA_TRUDNICE");
            Map(x => x.IzdajeSeNaRecept).Column("IZDAJE_SE_NA_RECEPT").Not.Nullable();
            Map(x => x.ProcenatParticipacije).Column("PROCENAT_PARTICIPACIJE").Not.Nullable();
            Map(x => x.Cena).Column("CENA").Not.Nullable();
            References(x => x.GrupaLekova).Column("GRUPA_LEKOVA_ID").Not.Nullable();
            References(x => x.ProdajnoMesto).Column("PRODAJNO_MESTO_ID").Not.Nullable();
            HasMany(x => x.Pakovanja).KeyColumn("LEK_ID").Cascade.AllDeleteOrphan().Inverse();
            HasMany(x => x.Recepti).KeyColumn("LEK_ID").Cascade.All();
            HasMany(x => x.Leci).KeyColumn("LEK_ID").Inverse().Cascade.All();
            HasMany(x => x.Kontraindikacije).KeyColumn("LEK_ID").Inverse().Cascade.All();
        }
    }
}
