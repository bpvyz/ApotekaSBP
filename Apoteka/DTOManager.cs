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
        #region Prodajno Mesto
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
        public static List<ReceptPregled> vratiRecepteProdajnogMesta(ProdajnoMestoBasic prodajnomesto)
        {
            List<ReceptPregled> recepti = new List<ReceptPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.Recept> sviRecepti = from o in s.Query<Apoteka.Entiteti.Recept>()
                                                                            where o.ProdajnoMesto.JedinstveniBroj == prodajnomesto.JedinstveniBroj
                                                                            select o;

                foreach (Apoteka.Entiteti.Recept r in sviRecepti)
                {
                    recepti.Add(new ReceptPregled(r.SerijskiBroj, r.SifraLekara, r.Tip, DTOManager.vratiPakovanje(r.OblikPakovanja.Id), r.Kolicina,
                        r.DatumIzdavanja, r.DatumRealizacije, DTOManager.vratiProdajnoMesto(r.ProdajnoMesto.JedinstveniBroj), 
                        DTOManager.vratiFarmaceuta(r.Farmaceut.JedinstveniBroj), DTOManager.vratiLek(r.Lek.KomercijalniNaziv)));
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
                    indikacije.Add(new BolestPregled(ll.Id.LeciBolest.Id, ll.Id.LeciBolest.Naziv));
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
                    kontraindikacije.Add(new BolestPregled(lk.Id.IzazivaBolest.Id, lk.Id.IzazivaBolest.Naziv));
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

        public static void dodajLek(LekBasic lek, GrupaLekovaPregled grupalekova, ProdajnoMestoPregled prodajnomesto)
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
                Apoteka.Entiteti.GrupaLekova gl = s.Load<Apoteka.Entiteti.GrupaLekova>(grupalekova.Id);
                Apoteka.Entiteti.ProdajnoMesto pm = s.Load<Apoteka.Entiteti.ProdajnoMesto>(prodajnomesto.JedinstveniBroj);
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

        public static BolestBasic vratiBolest(int idBolesti)
        {
            BolestBasic b = new BolestBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Bolest bb = s.Load<Apoteka.Entiteti.Bolest>(idBolesti);
                b = new BolestBasic(bb.Id, bb.Naziv);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return b;
        }

        public static void izmeniBolest(BolestBasic bolest)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Bolest b = s.Load<Bolest>(bolest.BolestId);

                b.Naziv = bolest.Naziv;

                s.SaveOrUpdate(b);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
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
            catch (Exception ec)
            {
                //handle exceptions
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
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void dodajFarmaceuta(FarmaceutBasic farmaceut, ProdajnoMestoBasic prodajnomesto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Farmaceut f = new Apoteka.Entiteti.Farmaceut();
                f.JedinstveniBroj = farmaceut.JedinstveniBroj;
                f.BrojTelefona = farmaceut.BrojTelefona;
                f.Ime = farmaceut.Ime;
                f.Prezime = farmaceut.Prezime;
                f.BrojTelefona = farmaceut.BrojTelefona;
                f.Adresa = farmaceut.Adresa;
                f.DatumRodjenja = farmaceut.DatumRodjenja.Date;
                f.DatumDiplomiranja = farmaceut.DatumDiplomiranja.Date;
                f.DatumObnoveLicence = farmaceut.DatumObnoveLicence.Date;

                Apoteka.Entiteti.ProdajnoMesto pm = s.Load<Apoteka.Entiteti.ProdajnoMesto>(prodajnomesto.JedinstveniBroj);
                f.ProdajnoMesto = pm;


                s.Save(f);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void dodajZaposlenog(ZaposleniBasic zaposleni, ProdajnoMestoBasic prodajnomesto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Zaposleni z = new Apoteka.Entiteti.Zaposleni();
                z.JedinstveniBroj = zaposleni.JedinstveniBroj;
                z.BrojTelefona = zaposleni.BrojTelefona;
                z.Ime = zaposleni.Ime;
                z.Prezime = zaposleni.Prezime;
                z.BrojTelefona = zaposleni.BrojTelefona;
                z.Adresa = zaposleni.Adresa;
                z.DatumRodjenja = zaposleni.DatumRodjenja.Date;
                
                Apoteka.Entiteti.ProdajnoMesto pm = s.Load<Apoteka.Entiteti.ProdajnoMesto>(prodajnomesto.JedinstveniBroj);
                z.ProdajnoMesto = pm;


                s.Save(z);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static ZaposleniBasic vratiZaposlenog(string idZaposlenog)
        {
            ZaposleniBasic zb = new ZaposleniBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Zaposleni z = s.Load<Apoteka.Entiteti.Zaposleni>(idZaposlenog);
                zb = new ZaposleniBasic(z.JedinstveniBroj, z.Ime, z.Prezime, z.DatumRodjenja, z.Adresa, z.BrojTelefona);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return zb;
        }

        public static FarmaceutBasic vratiFarmaceuta(string idFarmaceuta)
        {
            FarmaceutBasic fb = new FarmaceutBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Farmaceut f = s.Load<Apoteka.Entiteti.Farmaceut>(idFarmaceuta);
                fb = new FarmaceutBasic(f.JedinstveniBroj, f.Ime, f.Prezime, f.DatumRodjenja, f.Adresa, f.BrojTelefona,
                    f.DatumDiplomiranja, f.DatumObnoveLicence);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return fb;
        }

        public static void izmeniZaposlenog(ZaposleniBasic zaposleni)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Zaposleni z = s.Load<Zaposleni>(zaposleni.JedinstveniBroj);

                z.Adresa = zaposleni.Adresa;
                z.BrojTelefona = zaposleni.BrojTelefona;
                z.Ime = zaposleni.Ime;
                z.Prezime = zaposleni.Prezime;
                z.DatumRodjenja = zaposleni.DatumRodjenja;

                s.SaveOrUpdate(z);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void izmeniFarmaceuta(FarmaceutBasic farmaceut)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Farmaceut f = s.Load<Farmaceut>(farmaceut.JedinstveniBroj);

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
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void dodajProdajnoMesto(ProdajnoMestoBasic prodajnomesto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.ProdajnoMesto pm = new Apoteka.Entiteti.ProdajnoMesto();
                pm.Adresa = prodajnomesto.Adresa;
                pm.Naziv = prodajnomesto.Naziv;
                pm.Mesto = prodajnomesto.Mesto;
                pm.JedinstveniBroj = prodajnomesto.JedinstveniBroj;


                s.Save(pm);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void izmeniProdajnoMesto(ProdajnoMestoBasic prodajnomesto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.ProdajnoMesto pm = s.Load<ProdajnoMesto>(prodajnomesto.JedinstveniBroj);

                pm.Naziv = prodajnomesto.Naziv;
                pm.Mesto = prodajnomesto.Mesto;
                pm.Adresa = prodajnomesto.Adresa;

                s.SaveOrUpdate(pm);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
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
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void dodajIndikaciju(LekBasic lek, BolestPregled bp)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.LekLeci ll = new Apoteka.Entiteti.LekLeci();
                Apoteka.Entiteti.Lek l = s.Load<Apoteka.Entiteti.Lek>(lek.KomercijalniNaziv);
                Apoteka.Entiteti.Bolest b = s.Load<Apoteka.Entiteti.Bolest>(bp.Id);

                ll.Id.LekLeci = l;
                ll.Id.LeciBolest = b;


                s.Save(ll);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void obrisiIndikaciju(LekBasic lek, BolestBasic bolest)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Lek l = s.Load<Apoteka.Entiteti.Lek>(lek.KomercijalniNaziv);
                Bolest b = s.Load<Apoteka.Entiteti.Bolest>(bolest.BolestId);

                LekLeci indikacija = s.Load<LekLeci>(new LekLeciId { LekLeci = l, LeciBolest = b});

                s.Delete(indikacija);
                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        internal static void obrisiKontrandikaciju(LekBasic lek, BolestBasic bolest)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Lek l = s.Load<Apoteka.Entiteti.Lek>(lek.KomercijalniNaziv);
                Bolest b = s.Load<Apoteka.Entiteti.Bolest>(bolest.BolestId);

                LekKontraindikacija kontraindikacija = s.Load<LekKontraindikacija>(new LekKontraindikacijaId { LekIzaziva = l, IzazivaBolest = b });

                s.Delete(kontraindikacija);
                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void dodajKontraindikaciju(LekBasic lek, BolestPregled bp)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.LekKontraindikacija lk = new Apoteka.Entiteti.LekKontraindikacija();
                Apoteka.Entiteti.Lek l = s.Load<Apoteka.Entiteti.Lek>(lek.KomercijalniNaziv);
                Apoteka.Entiteti.Bolest b = s.Load<Apoteka.Entiteti.Bolest>(bp.Id);

                lk.Id.LekIzaziva = l;
                lk.Id.IzazivaBolest = b;

                s.Save(lk);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static List<ReceptPregled> vratiRecepteFarmaceuta(FarmaceutBasic farmaceut)
        {
            List<ReceptPregled> recepti = new List<ReceptPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Apoteka.Entiteti.Recept> sviRecepti = from o in s.Query<Apoteka.Entiteti.Recept>()
                                                                  where o.Farmaceut.JedinstveniBroj == farmaceut.JedinstveniBroj
                                                                  select o;

                foreach (Apoteka.Entiteti.Recept r in sviRecepti)
                {
                    recepti.Add(new ReceptPregled(r.SerijskiBroj, r.SifraLekara, r.Tip, DTOManager.vratiPakovanje(r.OblikPakovanja.Id), r.Kolicina, r.DatumIzdavanja, r.DatumRealizacije, 
                        DTOManager.vratiProdajnoMesto(r.ProdajnoMesto.JedinstveniBroj), DTOManager.vratiFarmaceuta(r.Farmaceut.JedinstveniBroj),
                        DTOManager.vratiLek(r.Lek.KomercijalniNaziv)));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return recepti;
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
            catch (Exception ec)
            {
                //handle exceptions
            }
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
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void dodajRecept(ReceptBasic rec, FarmaceutBasic farmaceut, ProdajnoMestoBasic prodajnomesto, LekPregled lek, PakovanjaPregled pak)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Apoteka.Entiteti.Recept r = new Apoteka.Entiteti.Recept();
                r.SifraLekara = rec.SifraLekara;
                r.DatumIzdavanja = rec.DatumIzdavanja.Date;
                r.DatumRealizacije = rec.DatumRealizacije?.Date;
                r.Kolicina = rec.Kolicina;
                r.Tip = rec.Tip;

                Apoteka.Entiteti.Lek l = s.Load<Apoteka.Entiteti.Lek>(lek.KomercijalniNaziv);
                r.Lek = l;

                Apoteka.Entiteti.Pakovanje p = s.Load<Apoteka.Entiteti.Pakovanje>(pak.Id);
                r.OblikPakovanja = p;

                Apoteka.Entiteti.ProdajnoMesto pm = s.Load<Apoteka.Entiteti.ProdajnoMesto>(prodajnomesto.JedinstveniBroj);
                r.ProdajnoMesto = pm;

                Apoteka.Entiteti.Farmaceut f = s.Load<Apoteka.Entiteti.Farmaceut>(farmaceut.JedinstveniBroj);
                r.Farmaceut = f;

                s.Save(r);

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
