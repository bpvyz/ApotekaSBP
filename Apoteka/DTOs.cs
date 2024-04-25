using System;
using Apoteka.Entiteti;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka
{
    #region Bolest
    public class BolestBasic
    {
        public int BolestId { get; set; }
        public string Naziv { get; set; }

        public virtual IList<LekLeciBasic> LekLeci { get; set; }
        public virtual IList<LekKontraindikacijaBasic> LekKontraindikacija { get; set; }

        public BolestBasic(int bolId, string Naziv)
        {
            this.BolestId = bolId;
            this.Naziv = Naziv;

        }

        public BolestBasic()
        {
            LekLeci = new List<LekLeciBasic>();
            LekKontraindikacija = new List<LekKontraindikacijaBasic>();
        }
    }

    public class BolestPregled
    {
        public int BolestId { get; set; }
        public string Naziv { get; set; }

        public BolestPregled()
        {
        }

        public BolestPregled(int bolId, string Naziv)
        {
            this.BolestId = bolId;
            this.Naziv = Naziv;
        }

    }

    #endregion

    #region Farmaceut

    public class FarmaceutBasic
    {
        public virtual string 



    }
}