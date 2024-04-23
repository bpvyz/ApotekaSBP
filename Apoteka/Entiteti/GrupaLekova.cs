using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Entiteti
{
    public class GrupaLekova
    {
        public virtual int Id { get; protected set; }
        public string Naziv { get; set; }
        public GrupaLekova()
        {

        }
    }
}
