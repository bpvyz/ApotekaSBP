using Apoteka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Mapiranja
{
    public class ReceptMapiranja : ClassMap<Recept>
    {
        public ReceptMapiranja()
        {
            Table("RECEPT");

            Id(x => x.SerijskiBroj).Column("SERIJSKI_BROJ").GeneratedBy.Identity();
            Map(x => x.SifraLekara).Column("SIFRA_LEKARA").Not.Nullable();
            Map(x => x.Tip).Column("TIP").Not.Nullable();
            Map(x => x.OblikPakovanja).Column("OBLIK_PAKOVANJA").Not.Nullable();
            Map(x => x.Kolicina).Column("KOLICINA").Not.Nullable();
            Map(x => x.DatumIzdavanja).Column("DATUM_IZDAVANJA").Not.Nullable();
            Map(x => x.DatumRealizacije).Column("DATUM_REALIZACIJE");
            References(x => x.ProdajnoMesto).Column("PRODAJNO_MESTO_ID").Not.Nullable();
            References(x => x.Farmaceut).Column("FARMACEUT_ID").Not.Nullable();
            References(x => x.Lek).Column("LEK_ID").Not.Nullable();
        }
    }
}
