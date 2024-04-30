using Apoteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace Apoteka
{
    public class DTOManager
    {
        #region Prodavnica
        public static List<ProdajnoMestoPregled> vratiSvaProdajnaMesta()
        {
            List<ProdajnoMestoPregled> prodajnamesta = new List<ProdajnoMestoPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.ProdajnoMesto> svaProdajnaMesta = from o in s.Query<Apoteka.Entiteti.ProdajnoMesto>()
                                                                               select o;

                foreach (Apoteka.Entiteti.ProdajnoMesto p in svaProdajnaMesta)
                {
                    prodajnamesta.Add(new ProdajnoMestoPregled(p.JedinstveniBroj, p.Naziv, p.Adresa, p.Mesto));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return prodajnamesta;
        }
        #endregion
    }
}
