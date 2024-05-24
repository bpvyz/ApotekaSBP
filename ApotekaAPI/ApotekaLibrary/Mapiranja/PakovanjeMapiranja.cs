﻿using ApotekaLibrary.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApotekaLibrary.Mapiranja
{
    public class PakovanjeMapiranja : ClassMap<Pakovanje>
    {
        public PakovanjeMapiranja()
        {
            Table("PAKOVANJE");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.Oblik).Column("OBLIK").Not.Nullable();
            Map(x => x.Kolicina).Column("KOLICINA").Not.Nullable();
            Map(x => x.Sastav).Column("SASTAV");
            References(x => x.Lek).Column("LEK_ID").Not.Nullable();
        }
    }
}
