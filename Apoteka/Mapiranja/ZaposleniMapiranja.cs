using Apoteka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Mapiranja
{
    public class ZaposleniMapiranja : ClassMap<Zaposleni>
    {
        public ZaposleniMapiranja()
        {
            Table("ZAPOSLENI");

            Id(x => x.JedinstveniBroj).Column("JEDINSTVENI_BROJ").GeneratedBy.Assigned();
            Map(x => x.Ime).Column("IME").Not.Nullable();
            Map(x => x.Prezime).Column("PREZIME").Not.Nullable();
            Map(x => x.DatumRodjenja).Column("DATUM_RODJENJA").Not.Nullable();
            Map(x => x.Adresa).Column("ADRESA").Not.Nullable();
            Map(x => x.BrojTelefona).Column("BROJ_TELEFONA");
            References(x => x.ProdajnoMesto).Column("PRODAJNO_MESTO").Not.Nullable();
        }
    }
}
