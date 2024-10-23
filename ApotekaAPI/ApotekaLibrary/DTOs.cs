using System;
using ApotekaLibrary.Entiteti;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApotekaLibrary
{
    #region Bolest
    public class BolestBasic
    {
        public int BolestId { get; set; }
        public string Naziv { get; set; }

        public IList<LekLeciBasic> LekLeci { get; set; }
        public IList<LekKontraindikacijaBasic> LekKontraindikacija { get; set; }

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
        public int Id { get; set; }
        public string Naziv { get; set; }

        public BolestPregled()
        {
        }

        public BolestPregled(int Id, string Naziv)
        {
            this.Id = Id;
            this.Naziv = Naziv;
        }

    }

    #endregion

    #region Farmaceut

    public class FarmaceutBasic : ZaposleniBasic
    {
        public DateTime DatumDiplomiranja { get; set; }

        public DateTime DatumObnoveLicence { get; set; }

        public IList<ReceptBasic> Recepti { get; set; }

     
        public FarmaceutBasic()
        {
            Recepti = new List<ReceptBasic>();
      
        }

        public FarmaceutBasic(string JedinstveniBroj, string Ime, string Prezime, DateTime DatumRodjenja, string Adresa, string BrojTelefona,
            DateTime datumDiplomiranja, DateTime datumObnoveLicence) : 
            base(JedinstveniBroj, Ime, Prezime, DatumRodjenja, Adresa, BrojTelefona)

        {

            this.DatumDiplomiranja = datumDiplomiranja;
            this.DatumObnoveLicence = datumObnoveLicence;
        }

    }
    public class FarmaceutPregled : ZaposleniPregled
    {
         public DateTime DatumDiplomiranja { get; set; }

        public DateTime DatumObnoveLicence { get; set; }

        public FarmaceutPregled()
        {

        }

        public FarmaceutPregled(string JedinstveniBroj, string Ime, string Prezime, DateTime DatumRodjenja, string Adresa, string BrojTelefona,
            DateTime datumDiplomiranja, DateTime datumObnoveLicence) : 
            base(JedinstveniBroj, Ime, Prezime, DatumRodjenja, Adresa, BrojTelefona)

        {

            this.DatumDiplomiranja = datumDiplomiranja;
            this.DatumObnoveLicence = datumObnoveLicence;
        }



    }
    #endregion

    #region GrupaLekova

    public class GrupaLekovaBasic
    {
        public int Id { get; protected set; }
        public string Naziv { get; set; }

        public IList<LekBasic> Lekovi { get; set; }


        public GrupaLekovaBasic()
        {
            Lekovi = new List<LekBasic>();
        }

        public GrupaLekovaBasic(int id, string naziv)
        {
            this.Id = id;
            this.Naziv = naziv;
        }



    }

    public class GrupaLekovaPregled
    {
        public int Id { get; protected set; }
        public string Naziv { get; set; }



        public GrupaLekovaPregled()
        {

        }

        public GrupaLekovaPregled(int id, string naziv)
        {
            this.Id = id;
            this.Naziv = naziv;
        }

    }
    #endregion

    #region Lek

    public class LekBasic
    {
        public string KomercijalniNaziv { get; set; }
        public string HemijskiNaziv { get; set; }
        public string NacinDoziranjaOdrasli { get; set; }
        public string NacinDoziranjaDeca { get; set; }
        public string NacinDoziranjaTrudnice { get; set; }
        public bool IzdajeSeNaRecept { get; set; }
        public float ProcenatParticipacije { get; set; }
        public float Cena { get; set; }
        public IList<PakovanjaBasic> Pakovanja { get; set; }
        public IList<LekLeciBasic> Leci { get; set; }
        public IList<LekKontraindikacijaBasic> Kontraindikacije { get; set; }
        public ProdajnoMestoBasic ProdajnoMesto { get; set; }
        public GrupaLekovaBasic GrupaLekova { get; set; }
        public IList<ReceptBasic> Recepti { get; set; }


        public LekBasic()
        {
            Pakovanja = new List<PakovanjaBasic>();
            Leci = new List<LekLeciBasic>();
            Kontraindikacije = new List<LekKontraindikacijaBasic>();
            GrupaLekova = new GrupaLekovaBasic();
            Recepti = new List<ReceptBasic>();
            ProdajnoMesto = new ProdajnoMestoBasic();
        }

        public LekBasic(string kom, string hem, string odrasli, string deca, string trudnice, bool naRecept, float participacija, float cena)
        {
            this.KomercijalniNaziv = kom;
            this.HemijskiNaziv = hem;
            this.NacinDoziranjaOdrasli = odrasli;
            this.NacinDoziranjaDeca = deca;
            this.NacinDoziranjaTrudnice = trudnice;
            this.IzdajeSeNaRecept = naRecept;
            this.ProcenatParticipacije = participacija;
            this.Cena = cena;
        }



    }
    public class LekPregled
    {
        public string KomercijalniNaziv { get; set; }
        public string HemijskiNaziv { get; set; }
        public string NacinDoziranjaOdrasli { get; set; }
        public string NacinDoziranjaDeca { get; set; }
        public string NacinDoziranjaTrudnice { get; set; }
        public bool IzdajeSeNaRecept { get; set; }
        public float ProcenatParticipacije { get; set; }
        public float Cena { get; set; }


        public LekPregled()
        {

        }
        public LekPregled(string kom, string hem, string odrasli, string deca, string trudnice, bool naRecept, float participacija, float cena)
        {
            this.KomercijalniNaziv = kom;
            this.HemijskiNaziv = hem;
            this.NacinDoziranjaOdrasli = odrasli;
            this.NacinDoziranjaDeca = deca;
            this.NacinDoziranjaTrudnice = trudnice;
            this.IzdajeSeNaRecept = naRecept;
            this.ProcenatParticipacije = participacija;
            this.Cena = cena;
        }
    }
    #endregion




    #region LekKontradikcija
    public class LekKontraindikacijaBasic
    {
        public LekKontraindikacijaId Id { get; set; }
        public LekBasic Lek { get; protected set; }
        public BolestBasic Bolest { get; protected set; }

        public LekKontraindikacijaBasic()
        { }

        public LekKontraindikacijaBasic(LekKontraindikacijaId id, LekBasic lek, BolestBasic bolest)
        {
            this.Id = id;
            this.Lek = lek;
            this.Bolest = bolest;
        }

    }
    public class LekKontraindikacijaPregled
    {
        public LekKontraindikacijaId Id { get; set; }
        public Lek Lek { get; protected set; }
        public Bolest Bolest { get; protected set; }

        public LekKontraindikacijaPregled()
        { 
            
        }

        public LekKontraindikacijaPregled(LekKontraindikacijaId id, Lek lek, Bolest bolest)
        {
            this.Id = id;
            this.Lek = lek;
            this.Bolest = bolest;
        }
    }

    #endregion

    #region LekLeci

    public class LekLeciBasic
    {
        public LekLeciId Id;
        public LekBasic Lek { get; protected set; }
        public BolestBasic Bolest { get; protected set; }

        public LekLeciBasic() 
        {
            this.Lek = new LekBasic();
            this.Bolest = new BolestBasic();
        }

        public LekLeciBasic(LekLeciId id)
        {
            this.Id = id;
        }

    }
    public class LekLeciPregled
    {
        public LekLeciId Id;
        public Lek Lek { get; protected set; }
        public Bolest Bolest { get; protected set; }

        public LekLeciPregled() { }

        public LekLeciPregled(LekLeciId id, Lek lek, Bolest bolest)
        {
            Id = id;
            Lek = lek;
            Bolest = bolest;
        }
    }
    #endregion

    #region Pakovanje

    public class PakovanjaBasic
    {
        public int Id { get; set; }
        public string Oblik { get; set; }
        public int Kolicina { get; set; }
        public string Sastav { get; set; }
        public LekBasic Lek { get; set; }

        public PakovanjaBasic()
        {
            Lek = new LekBasic();
        }

        public PakovanjaBasic(int id, string oblik, int kolicina, string sastav, LekBasic lek)
        {
            this.Id = id;
            this.Oblik = oblik;
            this.Sastav = sastav;
            this.Kolicina = kolicina;
            this.Lek = lek;
        }

    }
    public class PakovanjaPregled
    {
        public int Id { get; protected set; }
        public string Oblik { get; set; }
        public int Kolicina { get; set; }
        public string Sastav { get; set; }

        public PakovanjaPregled()
        {
        }

        public PakovanjaPregled(int id, string oblik, int kolicina, string sastav)
        {
            this.Id = id;
            this.Oblik = oblik;
            this.Sastav = sastav;
            this.Kolicina = kolicina;
        }

        public override string ToString()
        {
            return $"{Oblik} - {Sastav}";
        }
    }
    #endregion

    #region ProdajnoMesto
    public class ProdajnoMestoBasic
    {
        public string JedinstveniBroj { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Mesto { get; set; }
        public IList<ZaposleniBasic> Zaposleni { get; set; }
        public IList<ReceptBasic> Recepti { get; set; }

        public ProdajnoMestoBasic()
        {
            Zaposleni = new List<ZaposleniBasic>();
            Recepti = new List<ReceptBasic>();
        }

        public ProdajnoMestoBasic(string jbroj, string naziv, string adresa, string mesto)
        {
            this.JedinstveniBroj = jbroj;
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.Mesto = mesto;
        }
    }
    public class ProdajnoMestoPregled
    {
        public string JedinstveniBroj { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Mesto { get; set; }


        public ProdajnoMestoPregled()
        {

        }

        public ProdajnoMestoPregled(string jbroj, string naziv, string adresa, string mesto)
        {
            this.JedinstveniBroj = jbroj;
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.Mesto = mesto;
        }
    }

    #endregion

    #region Recept
    public class ReceptBasic
    {
        public int SerijskiBroj { get; set; }
        public string SifraLekara { get; set; }
        public string Tip { get; set; }
        public PakovanjaBasic OblikPakovanja { get; set; }
        public int Kolicina { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public DateTime? DatumRealizacije { get; set; }
        public ProdajnoMestoBasic ProdajnoMesto { get; set; }
        public FarmaceutBasic Farmaceut { get; set; }
        public LekBasic Lek { get; set; }
        public ReceptBasic()
        {
            DatumIzdavanja = DateTime.Now;
            DatumRealizacije = DateTime.Now;
            ProdajnoMesto = new ProdajnoMestoBasic(); // da se proveri
            Farmaceut = new FarmaceutBasic(); //da se proveri
            Lek = new LekBasic(); //da se proveri
            OblikPakovanja = new PakovanjaBasic();
        }

        public ReceptBasic(int sbroj, string sifra, string tip, PakovanjaBasic oblik,
            int kolicina, DateTime izdavanje, DateTime? realizacija, ProdajnoMestoBasic pmesto, FarmaceutBasic farmaceut,
            LekBasic lek)
        {
            this.SerijskiBroj = sbroj;
            this.SifraLekara = sifra;
            this.Tip = tip;
            this.OblikPakovanja = oblik;
            this.Kolicina = kolicina;
            this.DatumIzdavanja = izdavanje;
            this.DatumRealizacije = realizacija;
            this.ProdajnoMesto = pmesto;
            this.Farmaceut = farmaceut;
            this.Lek = lek;
        }

    }


    public class ReceptPregled
    {
        public int SerijskiBroj { get; set; }
        public string SifraLekara { get; set; }
        public string Tip { get; set; }
        public int Kolicina { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public DateTime? DatumRealizacije { get; set; }
        public PakovanjaBasic OblikPakovanja { get; set; }
        public ProdajnoMestoBasic ProdajnoMesto { get; set; }
        public FarmaceutBasic Farmaceut { get; set; }
        public LekBasic Lek { get; set; }


        public ReceptPregled()
        {

        }


        public ReceptPregled(int sbroj, string sifra, string tip, PakovanjaBasic pakovanje,
            int kolicina, DateTime izdavanje, DateTime? realizacija, ProdajnoMestoBasic pm, FarmaceutBasic f, LekBasic lek)
        {
            this.SerijskiBroj = sbroj;
            this.SifraLekara = sifra;
            this.Tip = tip;
            this.OblikPakovanja = pakovanje;
            this.Kolicina = kolicina;
            this.DatumIzdavanja = izdavanje;
            this.DatumRealizacije = realizacija;
            this.ProdajnoMesto = pm;
            this.Farmaceut = f;
            this.Lek = lek;

        }
    }
    #endregion

    #region Zaposleni
    public class ZaposleniBasic
    {
        public string JedinstveniBroj { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public ProdajnoMestoBasic ProdajnoMesto { get; set; }

        public ZaposleniBasic()
        {
            ProdajnoMesto = new ProdajnoMestoBasic();
        }


        public ZaposleniBasic(string jedinstveniBroj, string ime, string prezime, DateTime datum, string adresa, string brojTelefona)
        {
            this.JedinstveniBroj = jedinstveniBroj;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datum;
            this.Adresa = adresa;
            this.BrojTelefona = brojTelefona;
        }
    }
    public class ZaposleniPregled
    {
        public string JedinstveniBroj { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }

        public ZaposleniPregled()
        {

        }


        public ZaposleniPregled(string jedinstveniBroj, string ime, string prezime, DateTime datum, string adresa, string brojTelefona)
        {
            this.JedinstveniBroj = jedinstveniBroj;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datum;
            this.Adresa = adresa;
            this.BrojTelefona = brojTelefona;

        }
    }
    #endregion

}