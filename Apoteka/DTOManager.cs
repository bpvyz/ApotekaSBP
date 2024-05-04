using Apoteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Apoteka.Entiteti;

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
        public static ProdajnoMestoBasic vratiProdajnoMesto(string idProdajnogMesta)
        {
            ProdajnoMestoBasic pb = new ProdajnoMestoBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.ProdajnoMesto o = s.Load<Apoteka.Entiteti.ProdajnoMesto>(idProdajnogMesta);
                pb = new ProdajnoMestoBasic(o.JedinstveniBroj, o.Naziv, o.Adresa, o.Mesto);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return pb;
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
        public static List<ZaposleniPregled> vratiZaposleneProdajnogMesta(string id)
        {
            List<ZaposleniPregled> zaposleni = new List<ZaposleniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.Zaposleni> sviZaposleni = from o in s.Query<Apoteka.Entiteti.Zaposleni>()
                                                                       where o.ProdajnoMesto.JedinstveniBroj == id
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
                    bolesti.Add(new BolestPregled(b.Naziv));
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
        #region ZalihaGrupaLekova
        public static List<ZalihaGrupaLekovaPregled> vratiZaliheGrupeLekova(string id)
        {
            List<ZalihaGrupaLekovaPregled> zalihe = new List<ZalihaGrupaLekovaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.ZalihaGrupaLekova> sveZalihe = from o in s.Query<Apoteka.Entiteti.ZalihaGrupaLekova>()
                                                                       where o.ProdajnoMesto.JedinstveniBroj == id
                                                                       select o;

                foreach (Apoteka.Entiteti.ZalihaGrupaLekova z in sveZalihe)
                {
                   zalihe.Add(new ZalihaGrupaLekovaPregled(/*z.ProdajnoMesto, z.GrupaLekova, */z.Kolicina));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return zalihe;
        }
        #endregion
        #region Recept
        public static List<ReceptPregled> vratiRecepteProdajnogMesta(string id)
        {
            //TODO: Napraviti da vraca PRODAJNO_MESTO_ID, FARMACEUT_ID i LEK_ID
            List<ReceptPregled> recepti = new List<ReceptPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.Recept> sviRecepti = from o in s.Query<Apoteka.Entiteti.Recept>()
                                                                            where o.ProdajnoMesto.JedinstveniBroj == id
                                                                            select o;

                foreach (Apoteka.Entiteti.Recept r in sviRecepti)
                {
                    recepti.Add(new ReceptPregled(r.SerijskiBroj, r.SifraLekara, r.Tip, r.OblikPakovanja, r.Kolicina,
                        r.DatumIzdavanja, r.DatumRealizacije));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return recepti;
        }
        #endregion
        #region Farmaceut
        public static List<FarmaceutPregled> vratiFarmaceuteProdajnogMesta(string id)
        {
            List<FarmaceutPregled> farmaceuti = new List<FarmaceutPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.Farmaceut> sviFarmaceuti = from o in s.Query<Apoteka.Entiteti.Farmaceut>()
                                                                       where o.ProdajnoMesto.JedinstveniBroj == id
                                                                       select o;

                foreach (Apoteka.Entiteti.Farmaceut f in sviFarmaceuti)
                {
                    farmaceuti.Add(new FarmaceutPregled(f.JedinstveniBroj, f.Ime, f.Prezime, f.DatumRodjenja, f.Adresa,
                        f.BrojTelefona, f.DatumDiplomiranja, f.DatumObnoveLicence));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return farmaceuti;
        }
        #endregion

        #region Lek
        public static LekBasic vratiLek(string idLeka)
        {
            LekBasic l = new LekBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Lek o = s.Load<Apoteka.Entiteti.Lek>(idLeka);
                l = new LekBasic(o.KomercijalniNaziv, o.HemijskiNaziv, o.NacinDoziranjaOdrasli, o.NacinDoziranjaDeca, o.NacinDoziranjaTrudnice, o.IzdajeSeNaRecept, o.ProcenatParticipacije, o.Cena);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return l;
        }
        #endregion




        #region Indikacije
        public static List<BolestPregled> vratiIndikacijeZaLek(string id)
        {
            List<BolestPregled> indikacije = new List<BolestPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.LekLeci> sveIndikacije = from o in s.Query<Apoteka.Entiteti.LekLeci>()
                                                                                        where o.Id.LekLeci.KomercijalniNaziv == id
                                                                                        select o;

            

                foreach (Apoteka.Entiteti.LekLeci ll in sveIndikacije)
                {
                    indikacije.Add(new BolestPregled(ll.Id.LeciBolest.Naziv));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return indikacije;
        }
        #endregion


        #region Kontraindikacije
        public static List<BolestPregled> vratiKontraindikacijeZaLek(string id)
        {
            List<BolestPregled> kontraindikacije = new List<BolestPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.LekKontraindikacija> sveKontraindikacije = from o in s.Query<Apoteka.Entiteti.LekKontraindikacija>()
                                                                        where o.Id.LekIzaziva.KomercijalniNaziv == id
                                                                        select o; 

                foreach (Apoteka.Entiteti.LekKontraindikacija lk in sveKontraindikacije)
                {
                    kontraindikacije.Add(new BolestPregled(lk.Id.IzazivaBolest.Naziv));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return kontraindikacije;
        }
        #endregion


        #region Pakovanja
        public static List<PakovanjaPregled> vratiPakovanjaZaLek(string id)
        {
            List<PakovanjaPregled> pakovanja = new List<PakovanjaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.Pakovanje> svaPakovanja = from o in s.Query<Apoteka.Entiteti.Pakovanje>()
                                                                                        where o.Lek.KomercijalniNaziv == id
                                                                                        select o;

            

                foreach (Apoteka.Entiteti.Pakovanje pak in svaPakovanja)
                {
                    pakovanja.Add(new PakovanjaPregled(pak.Id, pak.Oblik,pak.Kolicina,pak.Sastav));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return pakovanja;
        }

        public static void dodajPakovanje(PakovanjaBasic pakovanje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Pakovanje p = new Apoteka.Entiteti.Pakovanje();
                p.Sastav = pakovanje.Sastav;
                p.Kolicina = pakovanje.Kolicina;
                p.Oblik = pakovanje.Oblik;
                Apoteka.Entiteti.Lek l = s.Load<Apoteka.Entiteti.Lek>(pakovanje.Lek.KomercijalniNaziv);
                p.Lek = l;


                s.Save(p);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static PakovanjaBasic vratiPakovanje(int idPakovanja)
        {
            PakovanjaBasic pb = new PakovanjaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Pakovanje p = s.Load<Apoteka.Entiteti.Pakovanje>(idPakovanja);
                pb = new PakovanjaBasic(p.Id, p.Oblik, p.Kolicina, p.Sastav);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return pb;
        }

        public static void dodajBolest(BolestBasic bolest)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Bolest b = new Apoteka.Entiteti.Bolest();
                b.Naziv = bolest.Naziv;

                s.Save(b);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static List<GrupaLekovaPregled> vratiSveGrupeLekova()
        {
            List<GrupaLekovaPregled> grupe = new List<GrupaLekovaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.GrupaLekova> sveGrupe = from o in s.Query<Apoteka.Entiteti.GrupaLekova>()
                                                                            select o;

                foreach (Apoteka.Entiteti.GrupaLekova g in sveGrupe)
                {
                    grupe.Add(new GrupaLekovaPregled(g.Id, g.Naziv));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return grupe;
        }

        public static void dodajLek(LekBasic lek, int grupalekova, string prodajnomesto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Lek l = new Apoteka.Entiteti.Lek();
                l.Cena = lek.Cena;
                l.ProcenatParticipacije = lek.ProcenatParticipacije;
                l.NacinDoziranjaTrudnice = lek.NacinDoziranjaTrudnice;
                l.NacinDoziranjaOdrasli = lek.NacinDoziranjaOdrasli;
                l.NacinDoziranjaDeca = lek.NacinDoziranjaDeca;
                l.HemijskiNaziv = lek.HemijskiNaziv;
                l.KomercijalniNaziv = lek.KomercijalniNaziv;
                l.IzdajeSeNaRecept = lek.IzdajeSeNaRecept;
                //TODO: Popraviti ovo
                Apoteka.Entiteti.GrupaLekova gl = s.Load<Apoteka.Entiteti.GrupaLekova>(grupalekova);
                Apoteka.Entiteti.ProdajnoMesto pm = s.Load<Apoteka.Entiteti.ProdajnoMesto>(prodajnomesto);
                l.GrupaLekova = gl;
                l.ProdajnoMesto = pm;


                s.Save(l);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniPakovanje(PakovanjaBasic pakovanje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Pakovanje p = s.Load<Pakovanje>(pakovanje.Id);

                p.Sastav = pakovanje.Sastav;
                p.Kolicina = pakovanje.Kolicina;
                p.Oblik = pakovanje.Oblik;



                s.SaveOrUpdate(p);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void IzmeniLek(LekBasic lek)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Lek l = s.Load<Lek>(lek.KomercijalniNaziv);

                l.HemijskiNaziv = lek.HemijskiNaziv;
                l.ProcenatParticipacije = lek.ProcenatParticipacije;
                l.Cena = lek.Cena;
                l.NacinDoziranjaDeca = lek.NacinDoziranjaDeca;
                l.NacinDoziranjaOdrasli = lek.NacinDoziranjaOdrasli;
                l.NacinDoziranjaTrudnice = lek.NacinDoziranjaTrudnice;
                l.IzdajeSeNaRecept = lek.IzdajeSeNaRecept;

                s.SaveOrUpdate(l);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void obrisiPakovanje(int idPakovanja)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pakovanje pakovanje = s.Load<Pakovanje>(idPakovanja);

                s.Delete(pakovanje);
                s.Flush();



                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void obrisiLek(string idLeka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Lek lek = s.Load<Lek>(idLeka);

                s.Delete(lek);
                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        #endregion



    }
}
