using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using ApotekaLibrary;
using ApotekaLibrary.Entiteti;

namespace ApotekaLibrary
{
    public class DataProvider
    {
        #region Prodajno Mesto
        public static List<ProdajnoMestoPregled> vratiSvaProdajnaMesta()
        {
            List<ProdajnoMestoPregled> prodajnamesta = new List<ProdajnoMestoPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ApotekaLibrary.Entiteti.ProdajnoMesto> svaProdajnaMesta = from o in s.Query<ApotekaLibrary.Entiteti.ProdajnoMesto>()
                                                                               select o;

                foreach (ApotekaLibrary.Entiteti.ProdajnoMesto p in svaProdajnaMesta)
                {
                    prodajnamesta.Add(new ProdajnoMestoPregled(p.JedinstveniBroj, p.Naziv, p.Adresa, p.Mesto));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return prodajnamesta;
        }

        public static ProdajnoMestoBasic vratiProdajnoMesto(string idProdajnogMesta)
        {
            ProdajnoMestoBasic pb = new ProdajnoMestoBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.ProdajnoMesto o = s.Load<ApotekaLibrary.Entiteti.ProdajnoMesto>(idProdajnogMesta);
                pb = new ProdajnoMestoBasic(o.JedinstveniBroj, o.Naziv, o.Adresa, o.Mesto);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return pb;
        }

        public static void dodajProdajnoMesto(ProdajnoMestoBasic prodajnomesto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.ProdajnoMesto pm = new ApotekaLibrary.Entiteti.ProdajnoMesto();
                pm.Adresa = prodajnomesto.Adresa;
                pm.Naziv = prodajnomesto.Naziv;
                pm.Mesto = prodajnomesto.Mesto;
                pm.JedinstveniBroj = prodajnomesto.JedinstveniBroj;


                s.Save(pm);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void izmeniProdajnoMesto(ProdajnoMestoBasic prodajnomesto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.ProdajnoMesto pm = s.Load<ProdajnoMesto>(prodajnomesto.JedinstveniBroj);

                pm.Naziv = prodajnomesto.Naziv;
                pm.Mesto = prodajnomesto.Mesto;
                pm.Adresa = prodajnomesto.Adresa;

                s.SaveOrUpdate(pm);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void obrisiProdajnoMesto(string idProdajnogMesta)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ProdajnoMesto prodajnomesto = s.Load<ProdajnoMesto>(idProdajnogMesta);

                s.Delete(prodajnomesto);
                s.Flush();

                s.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Zaposleni
        public static List<ZaposleniPregled> vratiSveZaposlene()
        {
            List<ZaposleniPregled> zaposleni = new List<ZaposleniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ApotekaLibrary.Entiteti.Zaposleni> sviZaposleni = from o in s.Query<ApotekaLibrary.Entiteti.Zaposleni>()
                                                                       select o;

                foreach (ApotekaLibrary.Entiteti.Zaposleni z in sviZaposleni)
                {
                    zaposleni.Add(new ZaposleniPregled(z.JedinstveniBroj, z.Ime, z.Prezime, z.DatumRodjenja, z.Adresa, z.BrojTelefona));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return zaposleni;
        }

        public static List<ZaposleniPregled> vratiZaposleneProdajnogMesta(string id)
        {
            List<ZaposleniPregled> zaposleni = new List<ZaposleniPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ApotekaLibrary.Entiteti.Zaposleni> sviZaposleni = from o in s.Query<ApotekaLibrary.Entiteti.Zaposleni>()
                                                                       where o.ProdajnoMesto.JedinstveniBroj == id
                                                                       select o;

                foreach (ApotekaLibrary.Entiteti.Zaposleni z in sviZaposleni)
                {
                    zaposleni.Add(new ZaposleniPregled(z.JedinstveniBroj, z.Ime, z.Prezime, z.DatumRodjenja, z.Adresa, z.BrojTelefona));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return zaposleni;
        }

        public static ZaposleniBasic vratiZaposlenog(string idZaposlenog)
        {
            ZaposleniBasic zb = new ZaposleniBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Zaposleni z = s.Load<ApotekaLibrary.Entiteti.Zaposleni>(idZaposlenog);
                zb = new ZaposleniBasic(z.JedinstveniBroj, z.Ime, z.Prezime, z.DatumRodjenja, z.Adresa, z.BrojTelefona);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return zb;
        }

        public static void dodajZaposlenog(ZaposleniBasic zaposleni, ProdajnoMestoBasic prodajnomesto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Zaposleni z = new ApotekaLibrary.Entiteti.Zaposleni();
                ApotekaLibrary.Entiteti.ProdajnoMesto pm = s.Load<ApotekaLibrary.Entiteti.ProdajnoMesto>(prodajnomesto.JedinstveniBroj);
                z.JedinstveniBroj = zaposleni.JedinstveniBroj;
                z.BrojTelefona = zaposleni.BrojTelefona;
                z.Ime = zaposleni.Ime;
                z.Prezime = zaposleni.Prezime;
                z.BrojTelefona = zaposleni.BrojTelefona;
                z.Adresa = zaposleni.Adresa;
                z.DatumRodjenja = zaposleni.DatumRodjenja.Date;
                z.ProdajnoMesto = pm;

                s.Save(z);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void izmeniZaposlenog(ZaposleniBasic zaposleni)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Zaposleni z = s.Load<Zaposleni>(zaposleni.JedinstveniBroj);

                z.Adresa = zaposleni.Adresa;
                z.BrojTelefona = zaposleni.BrojTelefona;
                z.Ime = zaposleni.Ime;
                z.Prezime = zaposleni.Prezime;
                z.DatumRodjenja = zaposleni.DatumRodjenja;

                s.SaveOrUpdate(z);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void obrisiZaposlenog(string idZaposlenog)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zaposleni zaposleni = s.Load<Zaposleni>(idZaposlenog);

                s.Delete(zaposleni);
                s.Flush();

                s.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Bolest
        public static BolestBasic vratiBolest(int idBolesti)
        {
            BolestBasic b = new BolestBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Bolest bb = s.Load<ApotekaLibrary.Entiteti.Bolest>(idBolesti);
                b = new BolestBasic(bb.Id, bb.Naziv);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return b;
        }

        public static List<BolestPregled> vratiSveBolesti()
        {
            List<BolestPregled> bolesti = new List<BolestPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ApotekaLibrary.Entiteti.Bolest> sveBolesti = from o in s.Query<ApotekaLibrary.Entiteti.Bolest>()
                                                                  select o;

                foreach (ApotekaLibrary.Entiteti.Bolest b in sveBolesti)
                {
                    bolesti.Add(new BolestPregled(b.Id, b.Naziv));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return bolesti;
        }

        public static void izmeniBolest(BolestBasic bolest)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Bolest b = s.Load<Bolest>(bolest.BolestId);

                b.Naziv = bolest.Naziv;

                s.SaveOrUpdate(b);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void obrisiBolest(int idBolesti)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Bolest bolest = s.Load<Bolest>(idBolesti);

                s.Delete(bolest);
                s.Flush();

                s.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void dodajBolest(BolestBasic bolest)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Bolest b = new ApotekaLibrary.Entiteti.Bolest();
                b.Naziv = bolest.Naziv;

                s.Save(b);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Recept
        public static List<ReceptPregled> vratiRecepteProdajnogMesta(ProdajnoMestoBasic prodajnomesto)
        {
            List<ReceptPregled> recepti = new List<ReceptPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ApotekaLibrary.Entiteti.Recept> sviRecepti = from o in s.Query<ApotekaLibrary.Entiteti.Recept>()
                                                                            where o.ProdajnoMesto.JedinstveniBroj == prodajnomesto.JedinstveniBroj
                                                                            select o;

                foreach (ApotekaLibrary.Entiteti.Recept r in sviRecepti)
                {
                    recepti.Add(new ReceptPregled(r.SerijskiBroj, r.SifraLekara, r.Tip, DataProvider.vratiPakovanje(r.OblikPakovanja.Id), r.Kolicina,
                        r.DatumIzdavanja, r.DatumRealizacije, DataProvider.vratiProdajnoMesto(r.ProdajnoMesto.JedinstveniBroj), 
                        DataProvider.vratiFarmaceuta(r.Farmaceut.JedinstveniBroj), DataProvider.vratiLek(r.Lek.KomercijalniNaziv)));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return recepti;
        }

        public static List<ReceptPregled> vratiRecepteFarmaceuta(FarmaceutBasic farmaceut)
        {
            List<ReceptPregled> recepti = new List<ReceptPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ApotekaLibrary.Entiteti.Recept> sviRecepti = from o in s.Query<ApotekaLibrary.Entiteti.Recept>()
                                                                  where o.Farmaceut.JedinstveniBroj == farmaceut.JedinstveniBroj
                                                                  select o;

                foreach (ApotekaLibrary.Entiteti.Recept r in sviRecepti)
                {
                    recepti.Add(new ReceptPregled(r.SerijskiBroj, r.SifraLekara, r.Tip, DataProvider.vratiPakovanje(r.OblikPakovanja.Id), r.Kolicina, r.DatumIzdavanja, r.DatumRealizacije,
                        DataProvider.vratiProdajnoMesto(r.ProdajnoMesto.JedinstveniBroj), DataProvider.vratiFarmaceuta(r.Farmaceut.JedinstveniBroj),
                        DataProvider.vratiLek(r.Lek.KomercijalniNaziv)));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return recepti;
        }

        public static void obrisiRecept(int idRecepta)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Recept recept = s.Load<Recept>(idRecepta);

                s.Delete(recept);
                s.Flush();

                s.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void dodajRecept(ReceptBasic rec, FarmaceutBasic farmaceut, ProdajnoMestoBasic prodajnomesto, LekBasic lek, PakovanjaBasic pak)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Recept r = new ApotekaLibrary.Entiteti.Recept();
                r.SifraLekara = rec.SifraLekara;
                r.DatumIzdavanja = rec.DatumIzdavanja.Date;
                r.DatumRealizacije = rec.DatumRealizacije?.Date;
                r.Kolicina = rec.Kolicina;
                r.Tip = rec.Tip;

                ApotekaLibrary.Entiteti.Lek l = s.Load<ApotekaLibrary.Entiteti.Lek>(lek.KomercijalniNaziv);
                r.Lek = l;

                ApotekaLibrary.Entiteti.Pakovanje p = s.Load<ApotekaLibrary.Entiteti.Pakovanje>(pak.Id);
                r.OblikPakovanja = p;

                ApotekaLibrary.Entiteti.ProdajnoMesto pm = s.Load<ApotekaLibrary.Entiteti.ProdajnoMesto>(prodajnomesto.JedinstveniBroj);
                r.ProdajnoMesto = pm;

                ApotekaLibrary.Entiteti.Farmaceut f = s.Load<ApotekaLibrary.Entiteti.Farmaceut>(farmaceut.JedinstveniBroj);
                r.Farmaceut = f;

                s.Save(r);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ReceptBasic vratiRecept(int idRecepta)
        {
            ReceptBasic rb = new ReceptBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Recept r = s.Load<ApotekaLibrary.Entiteti.Recept>(idRecepta);
                rb = new ReceptBasic(r.SerijskiBroj, r.SifraLekara, r.Tip, DataProvider.vratiPakovanje(r.OblikPakovanja.Id), r.Kolicina, r.DatumIzdavanja, r.DatumRealizacije,
                    DataProvider.vratiProdajnoMesto(r.ProdajnoMesto.JedinstveniBroj), DataProvider.vratiFarmaceuta(r.Farmaceut.JedinstveniBroj),
                    DataProvider.vratiLek(r.Lek.KomercijalniNaziv));

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return rb;
        }

        public static void IzmeniRecept(ReceptBasic recept)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Recept r = s.Load<Recept>(recept.SerijskiBroj);

                r.Kolicina = recept.Kolicina;
                r.SifraLekara = recept.SifraLekara;
                r.DatumIzdavanja = recept.DatumIzdavanja;
                r.DatumRealizacije = recept.DatumRealizacije;
                r.OblikPakovanja = s.Load<Pakovanje>(recept.OblikPakovanja.Id);
                r.Farmaceut = s.Load<Farmaceut>(recept.Farmaceut.JedinstveniBroj);
                r.Lek = s.Load<Lek>(recept.Lek.KomercijalniNaziv);

                s.SaveOrUpdate(r);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Farmaceut
        public static FarmaceutBasic vratiFarmaceuta(string idFarmaceuta)
        {
            FarmaceutBasic fb = new FarmaceutBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Farmaceut f = s.Load<ApotekaLibrary.Entiteti.Farmaceut>(idFarmaceuta);
                fb = new FarmaceutBasic(f.JedinstveniBroj, f.Ime, f.Prezime, f.DatumRodjenja, f.Adresa, f.BrojTelefona,
                    f.DatumDiplomiranja, f.DatumObnoveLicence);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return fb;
        }

        public static List<FarmaceutPregled> vratiFarmaceuteProdajnogMesta(string id)
        {
            List<FarmaceutPregled> farmaceuti = new List<FarmaceutPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ApotekaLibrary.Entiteti.Farmaceut> sviFarmaceuti = from o in s.Query<ApotekaLibrary.Entiteti.Farmaceut>()
                                                                       where o.ProdajnoMesto.JedinstveniBroj == id
                                                                       select o;

                foreach (ApotekaLibrary.Entiteti.Farmaceut f in sviFarmaceuti)
                {
                    farmaceuti.Add(new FarmaceutPregled(f.JedinstveniBroj, f.Ime, f.Prezime, f.DatumRodjenja, f.Adresa,
                        f.BrojTelefona, f.DatumDiplomiranja, f.DatumObnoveLicence));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return farmaceuti;
        }

        public static void dodajFarmaceuta(FarmaceutBasic farmaceut, ProdajnoMestoBasic prodajnomesto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Farmaceut f = new ApotekaLibrary.Entiteti.Farmaceut();
                f.JedinstveniBroj = farmaceut.JedinstveniBroj;
                f.BrojTelefona = farmaceut.BrojTelefona;
                f.Ime = farmaceut.Ime;
                f.Prezime = farmaceut.Prezime;
                f.BrojTelefona = farmaceut.BrojTelefona;
                f.Adresa = farmaceut.Adresa;
                f.DatumRodjenja = farmaceut.DatumRodjenja.Date;
                f.DatumDiplomiranja = farmaceut.DatumDiplomiranja.Date;
                f.DatumObnoveLicence = farmaceut.DatumObnoveLicence.Date;

                ApotekaLibrary.Entiteti.ProdajnoMesto pm = s.Load<ApotekaLibrary.Entiteti.ProdajnoMesto>(prodajnomesto.JedinstveniBroj);
                f.ProdajnoMesto = pm;


                s.Save(f);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void izmeniFarmaceuta(FarmaceutBasic farmaceut)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Farmaceut f = s.Load<Farmaceut>(farmaceut.JedinstveniBroj);

                f.Adresa = farmaceut.Adresa;
                f.BrojTelefona = farmaceut.BrojTelefona;
                f.Ime = farmaceut.Ime;
                f.Prezime = farmaceut.Prezime;
                f.DatumRodjenja = farmaceut.DatumRodjenja;
                f.DatumObnoveLicence = farmaceut.DatumObnoveLicence;
                f.DatumDiplomiranja = farmaceut.DatumDiplomiranja;

                s.SaveOrUpdate(f);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void obrisiFarmaceuta(string idFarmaceuta)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Farmaceut farmaceut = s.Load<Farmaceut>(idFarmaceuta);

                s.Delete(farmaceut);
                s.Flush();

                s.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Lek
        public static List<LekPregled> vratiSveLekove()
        {
            List<LekPregled> lekovi = new List<LekPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ApotekaLibrary.Entiteti.Lek> sviLekovi = from o in s.Query<ApotekaLibrary.Entiteti.Lek>()
                                                              select o;

                foreach (ApotekaLibrary.Entiteti.Lek l in sviLekovi)
                {
                    lekovi.Add(new LekPregled(l.KomercijalniNaziv, l.HemijskiNaziv,
                        l.NacinDoziranjaOdrasli, l.NacinDoziranjaDeca, l.NacinDoziranjaTrudnice,
                        l.IzdajeSeNaRecept, l.ProcenatParticipacije, l.Cena));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return lekovi;
        }

        public static List<LekPregled> vratiLekoveZaProdajnoMesto(ProdajnoMestoBasic pm)
        {
            List<LekPregled> lekovi = new List<LekPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ApotekaLibrary.Entiteti.Lek> sviLekovi = from o in s.Query<ApotekaLibrary.Entiteti.Lek>()
                                                              where o.ProdajnoMesto.JedinstveniBroj == pm.JedinstveniBroj
                                                              select o;

                foreach (ApotekaLibrary.Entiteti.Lek l in sviLekovi)
                {
                    lekovi.Add(new LekPregled(l.KomercijalniNaziv, l.HemijskiNaziv,
                        l.NacinDoziranjaOdrasli, l.NacinDoziranjaDeca, l.NacinDoziranjaTrudnice,
                        l.IzdajeSeNaRecept, l.ProcenatParticipacije, l.Cena));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return lekovi;
        }

        public static void dodajLek(LekBasic lek, GrupaLekovaBasic grupalekova, ProdajnoMestoBasic prodajnomesto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Lek l = new ApotekaLibrary.Entiteti.Lek();
                l.Cena = lek.Cena;
                l.ProcenatParticipacije = lek.ProcenatParticipacije;
                l.NacinDoziranjaTrudnice = lek.NacinDoziranjaTrudnice;
                l.NacinDoziranjaOdrasli = lek.NacinDoziranjaOdrasli;
                l.NacinDoziranjaDeca = lek.NacinDoziranjaDeca;
                l.HemijskiNaziv = lek.HemijskiNaziv;
                l.KomercijalniNaziv = lek.KomercijalniNaziv;
                l.IzdajeSeNaRecept = lek.IzdajeSeNaRecept;
                ApotekaLibrary.Entiteti.GrupaLekova gl = s.Load<ApotekaLibrary.Entiteti.GrupaLekova>(grupalekova.Id);
                ApotekaLibrary.Entiteti.ProdajnoMesto pm = s.Load<ApotekaLibrary.Entiteti.ProdajnoMesto>(prodajnomesto.JedinstveniBroj);
                l.GrupaLekova = gl;
                l.ProdajnoMesto = pm;


                s.Save(l);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static LekBasic vratiLek(string idLeka)
        {
            LekBasic l = new LekBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Lek o = s.Load<ApotekaLibrary.Entiteti.Lek>(idLeka);
                l = new LekBasic(o.KomercijalniNaziv, o.HemijskiNaziv, o.NacinDoziranjaOdrasli, o.NacinDoziranjaDeca, o.NacinDoziranjaTrudnice, o.IzdajeSeNaRecept, o.ProcenatParticipacije, o.Cena);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return l;
        }

        public static void IzmeniLek(LekBasic lek)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Lek l = s.Load<Lek>(lek.KomercijalniNaziv);

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
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region GrupaLekova
        public static List<GrupaLekovaPregled> vratiSveGrupeLekova()
        {
            List<GrupaLekovaPregled> grupe = new List<GrupaLekovaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ApotekaLibrary.Entiteti.GrupaLekova> sveGrupe = from o in s.Query<ApotekaLibrary.Entiteti.GrupaLekova>()
                                                                     select o;

                foreach (ApotekaLibrary.Entiteti.GrupaLekova g in sveGrupe)
                {
                    grupe.Add(new GrupaLekovaPregled(g.Id, g.Naziv));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return grupe;
        }
        public static GrupaLekovaBasic vratiGrupuLekova(int id)
        {
            GrupaLekovaBasic gl = new GrupaLekovaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.GrupaLekova g = s.Load<ApotekaLibrary.Entiteti.GrupaLekova>(id);
                gl = new GrupaLekovaBasic(g.Id, g.Naziv);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return gl;
        }
        #endregion

        #region Indikacije
        public static List<BolestPregled> vratiIndikacijeZaLek(string id)
        {
            List<BolestPregled> indikacije = new List<BolestPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ApotekaLibrary.Entiteti.LekLeci> sveIndikacije = from o in s.Query<ApotekaLibrary.Entiteti.LekLeci>()
                                                                                        where o.Id.LekLeci.KomercijalniNaziv == id
                                                                                        select o;

            

                foreach (ApotekaLibrary.Entiteti.LekLeci ll in sveIndikacije)
                {
                    indikacije.Add(new BolestPregled(ll.Id.LeciBolest.Id, ll.Id.LeciBolest.Naziv));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return indikacije;
        }

        public static void dodajIndikaciju(LekBasic lek, BolestBasic bp)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.LekLeci ll = new ApotekaLibrary.Entiteti.LekLeci();
                ApotekaLibrary.Entiteti.Lek l = s.Load<ApotekaLibrary.Entiteti.Lek>(lek.KomercijalniNaziv);
                ApotekaLibrary.Entiteti.Bolest b = s.Load<ApotekaLibrary.Entiteti.Bolest>(bp.BolestId);

                ll.Id.LekLeci = l;
                ll.Id.LeciBolest = b;


                s.Save(ll);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void obrisiIndikaciju(LekBasic lek, BolestBasic bolest)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Lek l = s.Load<ApotekaLibrary.Entiteti.Lek>(lek.KomercijalniNaziv);
                Bolest b = s.Load<ApotekaLibrary.Entiteti.Bolest>(bolest.BolestId);

                LekLeci indikacija = s.Load<LekLeci>(new LekLeciId { LekLeci = l, LeciBolest = b });

                s.Delete(indikacija);
                s.Flush();

                s.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Kontraindikacije
        public static List<BolestPregled> vratiKontraindikacijeZaLek(string id)
        {
            List<BolestPregled> kontraindikacije = new List<BolestPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ApotekaLibrary.Entiteti.LekKontraindikacija> sveKontraindikacije = from o in s.Query<ApotekaLibrary.Entiteti.LekKontraindikacija>()
                                                                        where o.Id.LekIzaziva.KomercijalniNaziv == id
                                                                        select o; 

                foreach (ApotekaLibrary.Entiteti.LekKontraindikacija lk in sveKontraindikacije)
                {
                    kontraindikacije.Add(new BolestPregled(lk.Id.IzazivaBolest.Id, lk.Id.IzazivaBolest.Naziv));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return kontraindikacije;
        }

        public static void obrisiKontrandikaciju(LekBasic lek, BolestBasic bolest)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Lek l = s.Load<ApotekaLibrary.Entiteti.Lek>(lek.KomercijalniNaziv);
                Bolest b = s.Load<ApotekaLibrary.Entiteti.Bolest>(bolest.BolestId);

                LekKontraindikacija kontraindikacija = s.Load<LekKontraindikacija>(new LekKontraindikacijaId { LekIzaziva = l, IzazivaBolest = b });

                s.Delete(kontraindikacija);
                s.Flush();

                s.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void dodajKontraindikaciju(LekBasic lek, BolestBasic bp)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.LekKontraindikacija lk = new ApotekaLibrary.Entiteti.LekKontraindikacija();
                ApotekaLibrary.Entiteti.Lek l = s.Load<ApotekaLibrary.Entiteti.Lek>(lek.KomercijalniNaziv);
                ApotekaLibrary.Entiteti.Bolest b = s.Load<ApotekaLibrary.Entiteti.Bolest>(bp.BolestId);

                lk.Id.LekIzaziva = l;
                lk.Id.IzazivaBolest = b;

                s.Save(lk);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Pakovanja
        public static List<PakovanjaPregled> vratiPakovanjaZaLek(string id)
        {
            List<PakovanjaPregled> pakovanja = new List<PakovanjaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ApotekaLibrary.Entiteti.Pakovanje> svaPakovanja = from o in s.Query<ApotekaLibrary.Entiteti.Pakovanje>()
                                                                                        where o.Lek.KomercijalniNaziv == id
                                                                                        select o;

            

                foreach (ApotekaLibrary.Entiteti.Pakovanje pak in svaPakovanja)
                {
                    pakovanja.Add(new PakovanjaPregled(pak.Id, pak.Oblik,pak.Kolicina,pak.Sastav));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return pakovanja;
        }

        public static void dodajPakovanje(PakovanjaBasic pakovanje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Pakovanje p = new ApotekaLibrary.Entiteti.Pakovanje();
                p.Sastav = pakovanje.Sastav;
                p.Kolicina = pakovanje.Kolicina;
                p.Oblik = pakovanje.Oblik;
                ApotekaLibrary.Entiteti.Lek l = s.Load<ApotekaLibrary.Entiteti.Lek>(pakovanje.Lek.KomercijalniNaziv);
                p.Lek = l;


                s.Save(p);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static PakovanjaBasic vratiPakovanje(int idPakovanja)
        {
            PakovanjaBasic pb = new PakovanjaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Pakovanje p = s.Load<ApotekaLibrary.Entiteti.Pakovanje>(idPakovanja);
                pb = new PakovanjaBasic(p.Id, p.Oblik, p.Kolicina, p.Sastav);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return pb;
        }

        public static void IzmeniPakovanje(PakovanjaBasic pakovanje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ApotekaLibrary.Entiteti.Pakovanje p = s.Load<Pakovanje>(pakovanje.Id);

                p.Sastav = pakovanje.Sastav;
                p.Kolicina = pakovanje.Kolicina;
                p.Oblik = pakovanje.Oblik;



                s.SaveOrUpdate(p);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
