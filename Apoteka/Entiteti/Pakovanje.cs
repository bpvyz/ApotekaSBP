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
        public virtual string Oblik { get; set; }
        public virtual int Kolicina { get; set; }
        public virtual string Sastav { get; set; }
        public virtual Lek Lek { get; set; }
        public Pakovanje()
        {
            Lek = new Lek();
        }
    }
}
