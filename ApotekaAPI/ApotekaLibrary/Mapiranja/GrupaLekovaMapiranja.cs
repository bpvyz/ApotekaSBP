using ApotekaLibrary.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApotekaLibraryLibrary.Mapiranja
{
    internal class GrupaLekovaMapiranja : ClassMap<GrupaLekova>
    {
        public GrupaLekovaMapiranja()
        {
            Table("GRUPA_LEKOVA");

            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.Naziv).Column("NAZIV").Not.Nullable();
            HasMany(x => x.Lekovi).KeyColumn("GRUPA_LEKOVA_ID").Cascade.All();
        }
    }
}
