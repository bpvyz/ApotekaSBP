using Apoteka.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Mapiranja
{
    public class FarmaceutMapiranja : SubclassMap<Farmaceut>
    {
        public FarmaceutMapiranja()
        {
            //proveriti za svaki slucaj
            Table("FARMACEUT");

            KeyColumn("ZAPOSLENI_ID");

            Map(x => x.DatumDiplomiranja).Column("DATUM_DIPLOMIRANJA").Not.Nullable();
            Map(x => x.DatumObnoveLicence).Column("DATUM_OBNOVE_LICENCE").Not.Nullable();
            HasMany(x => x.Recepti).KeyColumn("FARMACEUT_ID").Cascade.All();
        }
    }
}
