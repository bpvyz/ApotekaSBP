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
        #region Zaposleni

        public static List<ZaposleniPregled> vratiSveZaposlene()
        {
            List<ZaposleniPregled> zaposleni = new List<ZaposleniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.Zaposleni> sviZaposleni = from o in s.Query<Apoteka.Entiteti.Zaposleni>()
                                                                       select o;

                foreach (Apoteka.Entiteti.Zaposleni z in sviZaposleni)
                {
                    zaposleni.Add(new ZaposleniPregled(z.JedinstveniBroj, z.Ime, z.Prezime, z.DatumRodjenja, z.Adresa, z.BrojTelefona));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return zaposleni;
        }
        #endregion
        #region Lekovi
        public static List<LekPregled> vratiSveLekove()
        {
            List<LekPregled> lekovi = new List<LekPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.Lek> sviLekovi = from o in s.Query<Apoteka.Entiteti.Lek>()
                                                              select o;

                foreach (Apoteka.Entiteti.Lek l in sviLekovi)
                {
                    lekovi.Add(new LekPregled(l.KomercijalniNaziv, l.HemijskiNaziv,
                        l.NacinDoziranjaOdrasli, l.NacinDoziranjaDeca, l.NacinDoziranjaTrudnice,
                        l.IzdajeSeNaRecept, l.ProcenatParticipacije, l.Cena));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return lekovi;
        }
        #endregion
        #region Bolest
        public static List<BolestPregled> vratiSveBolesti()
        {
            List<BolestPregled> bolesti = new List<BolestPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.Bolest> sveBolesti = from o in s.Query<Apoteka.Entiteti.Bolest>()
                                                                  select o;

                foreach (Apoteka.Entiteti.Bolest b in sveBolesti)
                {
                    bolesti.Add(new BolestPregled(b.Id, b.Naziv));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return bolesti;
            #endregion

        }
    }
}
