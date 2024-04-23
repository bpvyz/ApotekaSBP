using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.Entiteti
{
    public class Bolest
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual IList<LekLeci> LekLeci { get; set; }
        public virtual IList<LekKontraindikacija> LekKontraindikacija { get; set; }
        public Bolest() 
        { 
            LekLeci = new List<LekLeci>();
            LekKontraindikacija = new List<LekKontraindikacija>();
        }
    }
}
