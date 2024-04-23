using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Entiteti
{
    public class Pakovanje
    {
        public virtual int Id { get; protected set; }
        public string Oblik { get; set; }
        public virtual int KolicinaLeka { get; set; }
        public virtual string Sastav { get; set; }
        public Pakovanje()
        {

        }
    }
}
