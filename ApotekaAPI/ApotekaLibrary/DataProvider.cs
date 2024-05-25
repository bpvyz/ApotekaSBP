using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using NHibernate;
using ApotekaLibrary;
using ApotekaLibrary.Entiteti;

namespace ApotekaLibrary
{
    public class DataProvider
    {
        #region Prodajno Mesto
        public static Result<List<ProdajnoMestoPregled>, ErrorMessage> vratiSvaProdajnaMesta()
        {
            ISession? s = null;

            List<ProdajnoMestoPregled> prodajnamesta = new List<ProdajnoMestoPregled>();

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                IEnumerable<ApotekaLibrary.Entiteti.ProdajnoMesto> svaProdajnaMesta = from o in s.Query<ApotekaLibrary.Entiteti.ProdajnoMesto>()
                                                                                      select o;

                foreach (ApotekaLibrary.Entiteti.ProdajnoMesto p in svaProdajnaMesta)
                {
                    prodajnamesta.Add(new ProdajnoMestoPregled(p.JedinstveniBroj, p.Naziv, p.Adresa, p.Mesto));
                }

            }
            catch (Exception)
            {
                return "Nemoguće vratiti sva prodajna mesta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return prodajnamesta;
        }

        public async static Task<Result<ProdajnoMestoBasic, ErrorMessage>> vratiProdajnoMestoAsync(string idProdajnogMesta)
        {
            ISession? s = null;
            ProdajnoMestoBasic pb = new ProdajnoMestoBasic();
            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.ProdajnoMesto o = await s.LoadAsync<ApotekaLibrary.Entiteti.ProdajnoMesto>(idProdajnogMesta);
                pb = new ProdajnoMestoBasic(o.JedinstveniBroj, o.Naziv, o.Adresa, o.Mesto);

                
            }
            catch (Exception)
            {
                return "Nemoguće vratiti prodajno mesto sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return pb;
        }

        public async static Task<Result<bool, ErrorMessage>> dodajProdajnoMestoAsync(ProdajnoMestoBasic prodajnomesto)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.ProdajnoMesto pm = new ApotekaLibrary.Entiteti.ProdajnoMesto();
                pm.Adresa = prodajnomesto.Adresa;
                pm.Naziv = prodajnomesto.Naziv;
                pm.Mesto = prodajnomesto.Mesto;
                pm.JedinstveniBroj = prodajnomesto.JedinstveniBroj;


                await s.SaveOrUpdateAsync(pm);

                await s.FlushAsync();

                
            }
            catch (Exception)
            {
                return "Nemoguće dodati prodajno mesto.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
            
            return true;
        }

        public async static Task<Result<ProdajnoMestoBasic, ErrorMessage>> izmeniProdajnoMesto(ProdajnoMestoBasic prodajnomesto)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.ProdajnoMesto pm = await s.LoadAsync<ProdajnoMesto>(prodajnomesto.JedinstveniBroj);

                pm.Naziv = prodajnomesto.Naziv;
                pm.Mesto = prodajnomesto.Mesto;
                pm.Adresa = prodajnomesto.Adresa;

                await s.UpdateAsync(pm);

                await s.FlushAsync();

                
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti prodajno mesto.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return prodajnomesto;
        }

        public async static Task<Result<bool, ErrorMessage>> obrisiProdajnoMestoAsync(string idProdajnogMesta)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ProdajnoMesto prodajnomesto = await s.LoadAsync<ProdajnoMesto>(idProdajnogMesta);

                await s.DeleteAsync(prodajnomesto);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće obrisati prodajno mesto.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        #endregion

        #region Zaposleni
        public async static Task<Result<List<ZaposleniPregled>, ErrorMessage>> vratiSveZaposleneAsync()
        {
            ISession? s = null;

            List<ZaposleniPregled> zaposleni = new List<ZaposleniPregled>();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                IEnumerable<ApotekaLibrary.Entiteti.Zaposleni> sviZaposleni = from o in await s.QueryOver<ApotekaLibrary.Entiteti.Zaposleni>().ListAsync()
                                                                       select o;

                foreach (ApotekaLibrary.Entiteti.Zaposleni z in sviZaposleni)
                {
                    zaposleni.Add(new ZaposleniPregled(z.JedinstveniBroj, z.Ime, z.Prezime, z.DatumRodjenja, z.Adresa, z.BrojTelefona));
                }    
            }
            catch (Exception)
            {
                return "Nemoguće vratiti sve zaposlene.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return zaposleni;
        }

        public static Result<List<ZaposleniPregled>, ErrorMessage> vratiZaposleneProdajnogMesta(string id)
        {
            ISession? s = null;

            List<ZaposleniPregled> zaposleni = new List<ZaposleniPregled>();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                IEnumerable<ApotekaLibrary.Entiteti.Zaposleni> sviZaposleni = from o in s.Query<ApotekaLibrary.Entiteti.Zaposleni>()
                                                                       where o.ProdajnoMesto.JedinstveniBroj == id
                                                                       select o;

                foreach (ApotekaLibrary.Entiteti.Zaposleni z in sviZaposleni)
                {
                    zaposleni.Add(new ZaposleniPregled(z.JedinstveniBroj, z.Ime, z.Prezime, z.DatumRodjenja, z.Adresa, z.BrojTelefona));
                }

                
            }
            catch (Exception)
            {
                return "Nemoguće vratiti sve zaposlene koji rade u prodajnom mesto sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return zaposleni;
        }

        public async static Task<Result<ZaposleniBasic, ErrorMessage>> vratiZaposlenogAsync(string idZaposlenog)
        {
            ISession? s = null;

            ZaposleniBasic zb = new ZaposleniBasic();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.Zaposleni z = await s.LoadAsync<ApotekaLibrary.Entiteti.Zaposleni>(idZaposlenog);
                zb = new ZaposleniBasic(z.JedinstveniBroj, z.Ime, z.Prezime, z.DatumRodjenja, z.Adresa, z.BrojTelefona);

                
            }
            catch (Exception)
            {
                return "Nemoguće vratiti zaposlenog sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return zb;
        }

        public async static Task<Result<bool, ErrorMessage>> dodajZaposlenogAsync(ZaposleniBasic zaposleni, ProdajnoMestoBasic prodajnomesto)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

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

                await s.SaveOrUpdateAsync(z);

                await s.FlushAsync();

                
            }
            catch (Exception)
            {
                return "Nemoguće dodati zaposlenog.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public static Result<ZaposleniBasic, ErrorMessage> izmeniZaposlenog(ZaposleniBasic zaposleni)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.Zaposleni z = s.Load<Zaposleni>(zaposleni.JedinstveniBroj);

                z.Adresa = zaposleni.Adresa;
                z.BrojTelefona = zaposleni.BrojTelefona;
                z.Ime = zaposleni.Ime;
                z.Prezime = zaposleni.Prezime;
                z.DatumRodjenja = zaposleni.DatumRodjenja;

                s.SaveOrUpdate(z);

                s.Flush();

                
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti zaposlenog.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }
            return zaposleni;
        }

        public async static Task<Result<bool, ErrorMessage>> obrisiZaposlenogAsync(string idZaposlenog)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                Zaposleni zaposleni = await s.LoadAsync<Zaposleni>(idZaposlenog);

                await s.DeleteAsync(zaposleni);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće obrisati zaposlenog.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        #endregion

        #region Bolest
        public async static Task<Result<BolestBasic, ErrorMessage>> vratiBolestAsync(int idBolesti)
        {
            ISession? s = null;

            BolestBasic b = new BolestBasic();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.Bolest bb = await s.LoadAsync<ApotekaLibrary.Entiteti.Bolest>(idBolesti);
                b = new BolestBasic(bb.Id, bb.Naziv);

                
            }
            catch (Exception)
            {
                return "Nemoguće vratiti bolest sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return b;
        }

        public async static Task<Result<List<BolestPregled>, ErrorMessage>> vratiSveBolestiAsync()
        {
            ISession? s = null;

            List<BolestPregled> bolesti = new List<BolestPregled>();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                IEnumerable<ApotekaLibrary.Entiteti.Bolest> sveBolesti = from o in await s.QueryOver<ApotekaLibrary.Entiteti.Bolest>().ListAsync()
                                                                  select o;

                foreach (ApotekaLibrary.Entiteti.Bolest b in sveBolesti)
                {
                    bolesti.Add(new BolestPregled(b.Id, b.Naziv));
                }

                
            }
            catch (Exception)
            {
                return "Nemoguće vratiti sve bolesti.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return bolesti;
        }

        public static Result<BolestBasic, ErrorMessage> izmeniBolest(BolestBasic bolest)
        {
            ISession? s = null;
            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.Bolest b = s.Load<Bolest>(bolest.BolestId);

                b.Naziv = bolest.Naziv;

                s.SaveOrUpdate(b);
                s.Flush();      
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti bolest.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return bolest;
        }

        public async static Task<Result<bool, ErrorMessage>> obrisiBolestAsync(int idBolesti)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                Bolest bolest = await s.LoadAsync<Bolest>(idBolesti);

                await s.DeleteAsync(bolest);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće obrisati bolest sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public static Result<bool, ErrorMessage> dodajBolest(BolestBasic bolest)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.Bolest b = new ApotekaLibrary.Entiteti.Bolest();
                b.Naziv = bolest.Naziv;

                s.SaveOrUpdate(b);
                s.Flush();
            }
            catch (Exception)
            {
                return "Nemoguće dodati bolest.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        #endregion

        #region Recept
        public async static Task<Result<List<ReceptPregled>, ErrorMessage>> vratiRecepteProdajnogMestaAsync(ProdajnoMestoBasic prodajnomesto)
        {
            ISession? s = null;
            List<ReceptPregled> recepti = new List<ReceptPregled>();

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                IEnumerable<ApotekaLibrary.Entiteti.Recept> sviRecepti = from o in s.Query<ApotekaLibrary.Entiteti.Recept>()
                                                                         where o.ProdajnoMesto.JedinstveniBroj == prodajnomesto.JedinstveniBroj
                                                                         select o;

                foreach (ApotekaLibrary.Entiteti.Recept r in sviRecepti)
                {
                    var oblikPakovanjaResult = await DataProvider.vratiPakovanjeAsync(r.OblikPakovanja.Id);
                    var prodajnoMestoResult = await DataProvider.vratiProdajnoMestoAsync(r.ProdajnoMesto.JedinstveniBroj);
                    var farmaceutResult = await DataProvider.vratiFarmaceutaAsync(r.Farmaceut.JedinstveniBroj);
                    var lekResult = await DataProvider.vratiLekAsync(r.Lek.KomercijalniNaziv);

                    if (oblikPakovanjaResult.IsError || prodajnoMestoResult.IsError || farmaceutResult.IsError || lekResult.IsError)
                    {
                        return oblikPakovanjaResult.Error;
                    }

                    recepti.Add(new ReceptPregled(
                        r.SerijskiBroj, 
                        r.SifraLekara, 
                        r.Tip, 
                        oblikPakovanjaResult.Data, 
                        r.Kolicina,
                        r.DatumIzdavanja, 
                        r.DatumRealizacije, 
                        prodajnoMestoResult.Data, 
                        farmaceutResult.Data, 
                        lekResult.Data));
                }

            }
            catch (Exception)
            {
                return "Nemoguće vratiti recepte prodajnog mesta.".ToError(400);
            }
            finally
            {
                if (s?.IsOpen ?? false)
                {
                    s.Close();
                }
                s?.Dispose();
            }

            return recepti;
        }


        public static async Task<Result<List<ReceptPregled>, ErrorMessage>> vratiRecepteFarmaceutaAsync(FarmaceutBasic farmaceut)
        {
            ISession? s = null;
            List<ReceptPregled> recepti = new List<ReceptPregled>();

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                IEnumerable<ApotekaLibrary.Entiteti.Recept> sviRecepti = from o in s.Query<ApotekaLibrary.Entiteti.Recept>()
                                                                        where o.Farmaceut.JedinstveniBroj == farmaceut.JedinstveniBroj
                                                                        select o;

                foreach (ApotekaLibrary.Entiteti.Recept r in sviRecepti)
                {
                    var oblikPakovanjaResult = await DataProvider.vratiPakovanjeAsync(r.OblikPakovanja.Id).ConfigureAwait(false);
                    var prodajnoMestoResult = await DataProvider.vratiProdajnoMestoAsync(r.ProdajnoMesto.JedinstveniBroj).ConfigureAwait(false);
                    var farmaceutResult = await DataProvider.vratiFarmaceutaAsync(r.Farmaceut.JedinstveniBroj).ConfigureAwait(false);
                    var lekResult = await DataProvider.vratiLekAsync(r.Lek.KomercijalniNaziv).ConfigureAwait(false);

                    if (oblikPakovanjaResult.IsError || prodajnoMestoResult.IsError || farmaceutResult.IsError || lekResult.IsError)
                    {
                        return oblikPakovanjaResult.Error;
                    }

                    recepti.Add(new ReceptPregled(
                        r.SerijskiBroj,
                        r.SifraLekara,
                        r.Tip,
                        oblikPakovanjaResult.Data,
                        r.Kolicina,
                        r.DatumIzdavanja,
                        r.DatumRealizacije,
                        prodajnoMestoResult.Data,
                        farmaceutResult.Data,
                        lekResult.Data));
                }
            }
            catch (Exception)
            {
                return "Nemoguće vratiti recepte farmaceuta.".ToError(400);
            }
            finally
            {
                if (s?.IsOpen ?? false)
                {
                    s.Close();
                }
                s?.Dispose();
            }

            return recepti;
        }



        public async static Task<Result<bool, ErrorMessage>> obrisiRecept(int idRecepta)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                Recept recept = await s.LoadAsync<Recept>(idRecepta);

                await s.DeleteAsync(recept);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće obrisati recept sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, ErrorMessage>> dodajReceptAsync(ReceptBasic rec, FarmaceutBasic farmaceut, ProdajnoMestoBasic prodajnomesto, LekBasic lek, PakovanjaBasic pak)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.Recept r = new ApotekaLibrary.Entiteti.Recept();

                r.SifraLekara = rec.SifraLekara;
                r.DatumIzdavanja = rec.DatumIzdavanja.Date;
                r.DatumRealizacije = rec.DatumRealizacije?.Date;
                r.Kolicina = rec.Kolicina;
                r.Tip = rec.Tip;

                ApotekaLibrary.Entiteti.Lek l = await s.LoadAsync<ApotekaLibrary.Entiteti.Lek>(lek.KomercijalniNaziv);
                r.Lek = l;

                ApotekaLibrary.Entiteti.Pakovanje p = await s.LoadAsync<ApotekaLibrary.Entiteti.Pakovanje>(pak.Id);
                r.OblikPakovanja = p;

                ApotekaLibrary.Entiteti.ProdajnoMesto pm = await s.LoadAsync<ApotekaLibrary.Entiteti.ProdajnoMesto>(prodajnomesto.JedinstveniBroj);
                r.ProdajnoMesto = pm;

                ApotekaLibrary.Entiteti.Farmaceut f = await s.LoadAsync<ApotekaLibrary.Entiteti.Farmaceut>(farmaceut.JedinstveniBroj);
                r.Farmaceut = f;

                await s.SaveOrUpdateAsync(r);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati recept.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public static async Task<Result<ReceptBasic, ErrorMessage>> vratiReceptAsync(int idRecepta)
        {
            ISession? s = null;
            ReceptBasic rb = new ReceptBasic();

            try
            {
                s = DataLayer.GetSession();

                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.Recept r = await s.LoadAsync<ApotekaLibrary.Entiteti.Recept>(idRecepta).ConfigureAwait(false);
                var oblikPakovanjaResult = await DataProvider.vratiPakovanjeAsync(r.OblikPakovanja.Id).ConfigureAwait(false);
                var prodajnoMestoResult = await DataProvider.vratiProdajnoMestoAsync(r.ProdajnoMesto.JedinstveniBroj).ConfigureAwait(false);
                var farmaceutResult = await DataProvider.vratiFarmaceutaAsync(r.Farmaceut.JedinstveniBroj).ConfigureAwait(false);
                var lekResult = await DataProvider.vratiLekAsync(r.Lek.KomercijalniNaziv).ConfigureAwait(false);

                if (oblikPakovanjaResult.IsError || prodajnoMestoResult.IsError || farmaceutResult.IsError || lekResult.IsError)
                {
                    return oblikPakovanjaResult.Error;
                }

                rb = new ReceptBasic(
                    r.SerijskiBroj,
                    r.SifraLekara,
                    r.Tip,
                    oblikPakovanjaResult.Data,
                    r.Kolicina,
                    r.DatumIzdavanja,
                    r.DatumRealizacije,
                    prodajnoMestoResult.Data,
                    farmaceutResult.Data,
                    lekResult.Data);
            }
            catch (Exception)
            {
                return "Nemoguće vratiti recept sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                if (s?.IsOpen ?? false) // Check if session is open before closing
                {
                    s.Close();
                }
                s?.Dispose();
            }

            return rb;
        }

        public static Result<ReceptBasic, ErrorMessage> IzmeniRecept(ReceptBasic recept)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

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
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti recept.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return recept;
        }

        #endregion

        #region Farmaceut
        public async static Task<Result<FarmaceutBasic, ErrorMessage>> vratiFarmaceutaAsync(string idFarmaceuta)
        {
            ISession? s = null;

            FarmaceutBasic fb = new FarmaceutBasic();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.Farmaceut f = await s.LoadAsync<ApotekaLibrary.Entiteti.Farmaceut>(idFarmaceuta);
                fb = new FarmaceutBasic(f.JedinstveniBroj, f.Ime, f.Prezime, f.DatumRodjenja, f.Adresa, f.BrojTelefona,
                    f.DatumDiplomiranja, f.DatumObnoveLicence);

                
            }
            catch (Exception)
            {
                return "Nemoguće vratiti farmaceuta sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return fb;
        }

        public static Result<List<FarmaceutPregled>, ErrorMessage> vratiFarmaceuteProdajnogMesta(string id)
        {
            ISession? s = null;

            List<FarmaceutPregled> farmaceuti = new List<FarmaceutPregled>();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                IEnumerable<ApotekaLibrary.Entiteti.Farmaceut> sviFarmaceuti = from o in s.Query<ApotekaLibrary.Entiteti.Farmaceut>()
                                                                       where o.ProdajnoMesto.JedinstveniBroj == id
                                                                       select o;

                foreach (ApotekaLibrary.Entiteti.Farmaceut f in sviFarmaceuti)
                {
                    farmaceuti.Add(new FarmaceutPregled(f.JedinstveniBroj, f.Ime, f.Prezime, f.DatumRodjenja, f.Adresa,
                        f.BrojTelefona, f.DatumDiplomiranja, f.DatumObnoveLicence));
                }

                
            }
            catch (Exception)
            {
                return "Nemoguće vratiti farmaceute prodajnog mesta sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return farmaceuti;
        }

        public async static Task<Result<bool, ErrorMessage>> dodajFarmaceutaAsync(FarmaceutBasic farmaceut, ProdajnoMestoBasic prodajnomesto)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

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

                ApotekaLibrary.Entiteti.ProdajnoMesto pm = await s.LoadAsync<ApotekaLibrary.Entiteti.ProdajnoMesto>(prodajnomesto.JedinstveniBroj);
                f.ProdajnoMesto = pm;

                await s.SaveOrUpdateAsync(f);
                await s.FlushAsync();    
            }
            catch (Exception)
            {
                return "Nemoguće dodati farmaceuta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public static Result<FarmaceutBasic, ErrorMessage> izmeniFarmaceuta(FarmaceutBasic farmaceut)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

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
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti farmaceuta.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return farmaceut;
        }

        public async static Task<Result<bool, ErrorMessage>> obrisiFarmaceuta(string idFarmaceuta)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                Farmaceut farmaceut = await s.LoadAsync<Farmaceut>(idFarmaceuta);

                await s.DeleteAsync(farmaceut);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće obrisati farmaceuta sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        #endregion

        #region Lek
        public async static Task<Result<List<LekPregled>, ErrorMessage>> vratiSveLekove()
        {
            ISession? s = null;

            List<LekPregled> lekovi = new List<LekPregled>();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                IEnumerable<ApotekaLibrary.Entiteti.Lek> sviLekovi = from o in await s.QueryOver<ApotekaLibrary.Entiteti.Lek>().ListAsync()
                                                              select o;

                foreach (ApotekaLibrary.Entiteti.Lek l in sviLekovi)
                {
                    lekovi.Add(new LekPregled(l.KomercijalniNaziv, l.HemijskiNaziv,
                        l.NacinDoziranjaOdrasli, l.NacinDoziranjaDeca, l.NacinDoziranjaTrudnice,
                        l.IzdajeSeNaRecept, l.ProcenatParticipacije, l.Cena));
                }                
            }
            catch (Exception)
            {
                return "Nemoguće vratiti sve lekove.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return lekovi;
        }

        public static Result<List<LekPregled>, ErrorMessage> vratiLekoveZaProdajnoMesto(ProdajnoMestoBasic pm)
        {
            ISession? s = null;

            List<LekPregled> lekovi = new List<LekPregled>();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                IEnumerable<ApotekaLibrary.Entiteti.Lek> sviLekovi = from o in s.Query<ApotekaLibrary.Entiteti.Lek>()
                                                              where o.ProdajnoMesto.JedinstveniBroj == pm.JedinstveniBroj
                                                              select o;

                foreach (ApotekaLibrary.Entiteti.Lek l in sviLekovi)
                {
                    lekovi.Add(new LekPregled(l.KomercijalniNaziv, l.HemijskiNaziv,
                        l.NacinDoziranjaOdrasli, l.NacinDoziranjaDeca, l.NacinDoziranjaTrudnice,
                        l.IzdajeSeNaRecept, l.ProcenatParticipacije, l.Cena));
                }    
            }
            catch (Exception)
            {
                return "Nemoguće vratiti lekove za prodajno mesto.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return lekovi;
        }

        public async static Task<Result<bool, ErrorMessage>> dodajLekAsync(LekBasic lek, GrupaLekovaBasic grupalekova, ProdajnoMestoBasic prodajnomesto)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

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

                await s.SaveOrUpdateAsync(l);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati lek.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<LekBasic, ErrorMessage>> vratiLekAsync(string idLeka)
        {
            ISession? s = null;

            LekBasic l = new LekBasic();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.Lek o = await s.LoadAsync<ApotekaLibrary.Entiteti.Lek>(idLeka);
                l = new LekBasic(o.KomercijalniNaziv, o.HemijskiNaziv, o.NacinDoziranjaOdrasli, o.NacinDoziranjaDeca, o.NacinDoziranjaTrudnice, o.IzdajeSeNaRecept, o.ProcenatParticipacije, o.Cena);
            }
            catch (Exception)
            {
                return "Nemoguće vratiti lek sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return l;
        }

        public static Result<LekBasic, ErrorMessage> IzmeniLek(LekBasic lek)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

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
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti lek.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return lek;
        }

        public async static Task<Result<bool, ErrorMessage>> obrisiLekAsync(string idLeka)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                Lek lek = await s.LoadAsync<Lek>(idLeka);

                await s.DeleteAsync(lek);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće obrisati lek sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        #endregion

        #region GrupaLekova
        public async static Task<Result<List<GrupaLekovaPregled>, ErrorMessage>> vratiSveGrupeLekovaAsync()
        {
            ISession? s = null;

            List<GrupaLekovaPregled> grupe = new List<GrupaLekovaPregled>();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                IEnumerable<ApotekaLibrary.Entiteti.GrupaLekova> sveGrupe = from o in await s.QueryOver<ApotekaLibrary.Entiteti.GrupaLekova>().ListAsync()
                                                                     select o;

                foreach (ApotekaLibrary.Entiteti.GrupaLekova g in sveGrupe)
                {
                    grupe.Add(new GrupaLekovaPregled(g.Id, g.Naziv));
                }
                
            }
            catch (Exception)
            {
                return "Nemoguće vratiti sve grupe lekova.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return grupe;
        }
        public async static Task<Result<GrupaLekovaBasic, ErrorMessage>> vratiGrupuLekovaAsync(int id)
        {
            ISession? s = null;

            GrupaLekovaBasic gl = new GrupaLekovaBasic();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.GrupaLekova g = await s.LoadAsync<ApotekaLibrary.Entiteti.GrupaLekova>(id);
                gl = new GrupaLekovaBasic(g.Id, g.Naziv);
            }
            catch (Exception)
            {
                return "Nemoguće vratiti grupu lekova sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return gl;
        }
        #endregion

        #region Indikacije
        public static Result<List<BolestPregled>, ErrorMessage> vratiIndikacijeZaLek(string id)
        {
            ISession? s = null;

            List<BolestPregled> indikacije = new List<BolestPregled>();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                IEnumerable<ApotekaLibrary.Entiteti.LekLeci> sveIndikacije = from o in s.Query<ApotekaLibrary.Entiteti.LekLeci>()
                                                                                        where o.Id.LekLeci.KomercijalniNaziv == id
                                                                                        select o;

                foreach (ApotekaLibrary.Entiteti.LekLeci ll in sveIndikacije)
                {
                    indikacije.Add(new BolestPregled(ll.Id.LeciBolest.Id, ll.Id.LeciBolest.Naziv));
                }         
            }
            catch (Exception)
            {
                return "Nemoguće vratiti indikacije za lek sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return indikacije;
        }

        public async static Task<Result<bool, ErrorMessage>> dodajIndikacijuAsync(LekBasic lek, BolestBasic bp)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.LekLeci ll = new ApotekaLibrary.Entiteti.LekLeci();

                ApotekaLibrary.Entiteti.Lek l = await s.LoadAsync<ApotekaLibrary.Entiteti.Lek>(lek.KomercijalniNaziv);
                ApotekaLibrary.Entiteti.Bolest b = await s.LoadAsync<ApotekaLibrary.Entiteti.Bolest>(bp.BolestId);

                ll.Id.LekLeci = l;
                ll.Id.LeciBolest = b;

                await s.SaveOrUpdateAsync(ll);
                await s.FlushAsync();      
            }
            catch (Exception)
            {
                return "Nemoguće dodati indikaciju za lek.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, ErrorMessage>> obrisiIndikacijuAsync(LekBasic lek, BolestBasic bolest)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                Lek l = await s.LoadAsync<ApotekaLibrary.Entiteti.Lek>(lek.KomercijalniNaziv);
                Bolest b = await s.LoadAsync<ApotekaLibrary.Entiteti.Bolest>(bolest.BolestId);
                LekLeci indikacija = await s.LoadAsync<LekLeci>(new LekLeciId { LekLeci = l, LeciBolest = b });

                await s.DeleteAsync(indikacija);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće obrisati indikaciju za lek".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        #endregion

        #region Kontraindikacije
        public static Result<List<BolestPregled>, ErrorMessage> vratiKontraindikacijeZaLek(string id)
        {
            ISession? s = null;

            List<BolestPregled> kontraindikacije = new List<BolestPregled>();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                IEnumerable<ApotekaLibrary.Entiteti.LekKontraindikacija> sveKontraindikacije = from o in s.Query<ApotekaLibrary.Entiteti.LekKontraindikacija>()
                                                                        where o.Id.LekIzaziva.KomercijalniNaziv == id
                                                                        select o; 

                foreach (ApotekaLibrary.Entiteti.LekKontraindikacija lk in sveKontraindikacije)
                {
                    kontraindikacije.Add(new BolestPregled(lk.Id.IzazivaBolest.Id, lk.Id.IzazivaBolest.Naziv));
                } 
            }
            catch (Exception)
            {
                return "Nemoguće vratiti kontraindikacije za lek sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return kontraindikacije;
        }

        public async static Task<Result<bool, ErrorMessage>> obrisiKontrandikacijuAsync(LekBasic lek, BolestBasic bolest)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                Lek l = await s.LoadAsync<ApotekaLibrary.Entiteti.Lek>(lek.KomercijalniNaziv);
                Bolest b = await s.LoadAsync<ApotekaLibrary.Entiteti.Bolest>(bolest.BolestId);
                LekKontraindikacija kontraindikacija = s.Load<LekKontraindikacija>(new LekKontraindikacijaId { LekIzaziva = l, IzazivaBolest = b });

                await s.DeleteAsync(kontraindikacija);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće obrisati kontraindikaciju za lek.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<bool, ErrorMessage>> dodajKontraindikacijuAsync(LekBasic lek, BolestBasic bp)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.LekKontraindikacija lk = new ApotekaLibrary.Entiteti.LekKontraindikacija();

                ApotekaLibrary.Entiteti.Lek l = await s.LoadAsync<ApotekaLibrary.Entiteti.Lek>(lek.KomercijalniNaziv);
                ApotekaLibrary.Entiteti.Bolest b = await s.LoadAsync<ApotekaLibrary.Entiteti.Bolest>(bp.BolestId);

                lk.Id.LekIzaziva = l;
                lk.Id.IzazivaBolest = b;

                await s.SaveOrUpdateAsync(lk);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati kontraindikaciju za lek.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        #endregion

        #region Pakovanja
        public static Result<List<PakovanjaPregled>, ErrorMessage> vratiPakovanjaZaLek(string id)
        {
            ISession? s = null;

            List<PakovanjaPregled> pakovanja = new List<PakovanjaPregled>();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                IEnumerable<ApotekaLibrary.Entiteti.Pakovanje> svaPakovanja = from o in s.Query<ApotekaLibrary.Entiteti.Pakovanje>()
                                                                                        where o.Lek.KomercijalniNaziv == id
                                                                                        select o;

                foreach (ApotekaLibrary.Entiteti.Pakovanje pak in svaPakovanja)
                {
                    pakovanja.Add(new PakovanjaPregled(pak.Id, pak.Oblik,pak.Kolicina,pak.Sastav));
                }                
            }
            catch (Exception)
            {
                return "Nemoguće vratiti pakovanja za lek sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return pakovanja;
        }

        public async static Task<Result<bool, ErrorMessage>> dodajPakovanje(PakovanjaBasic pakovanje)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.Pakovanje p = new ApotekaLibrary.Entiteti.Pakovanje();

                p.Sastav = pakovanje.Sastav;
                p.Kolicina = pakovanje.Kolicina;
                p.Oblik = pakovanje.Oblik;
                
                ApotekaLibrary.Entiteti.Lek l = await s.LoadAsync<ApotekaLibrary.Entiteti.Lek>(pakovanje.Lek.KomercijalniNaziv);

                p.Lek = l;

                await s.SaveOrUpdateAsync(p);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće dodati pakovanje.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        public async static Task<Result<PakovanjaBasic, ErrorMessage>> vratiPakovanjeAsync(int idPakovanja)
        {
            ISession? s = null;

            PakovanjaBasic pb = new PakovanjaBasic();

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.Pakovanje p = await s.LoadAsync<ApotekaLibrary.Entiteti.Pakovanje>(idPakovanja);
                pb = new PakovanjaBasic(p.Id, p.Oblik, p.Kolicina, p.Sastav);
            }
            catch (Exception)
            {
                return "Nemoguće vratiti pakovanje sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return pb;
        }

        public static Result<PakovanjaBasic, ErrorMessage> IzmeniPakovanje(PakovanjaBasic pakovanje)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                ApotekaLibrary.Entiteti.Pakovanje p = s.Load<Pakovanje>(pakovanje.Id);

                p.Sastav = pakovanje.Sastav;
                p.Kolicina = pakovanje.Kolicina;
                p.Oblik = pakovanje.Oblik;

                s.SaveOrUpdate(p);
                s.Flush();
            }
            catch (Exception)
            {
                return "Nemoguće izmeniti pakovanje.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return pakovanje;
        }

        public async static Task<Result<bool, ErrorMessage>> obrisiPakovanjeAsync(int idPakovanja)
        {
            ISession? s = null;

            try
            {
                s = DataLayer.GetSession();
                
                if (!(s?.IsConnected ?? false))
                {
                    return "Nemoguće otvoriti sesiju.".ToError(403);
                }

                Pakovanje pakovanje = await s.LoadAsync<Pakovanje>(idPakovanja);

                await s.DeleteAsync(pakovanje);
                await s.FlushAsync();
            }
            catch (Exception)
            {
                return "Nemoguće obrisati pakovanje sa zadatim ID-jem.".ToError(400);
            }
            finally
            {
                s?.Close();
                s?.Dispose();
            }

            return true;
        }

        #endregion

    }
}
