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

    public class FarmaceutBasic : ZaposleniBasic
    {
        public DateTime DatumDiplomiranja { get; set; }

        public DateTime DatumObnoveLicence { get; set; }

        public virtual IList<ReceptBasic> Recepti { get; set; }

     
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
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }

        public virtual IList<LekBasic> Lekovi { get; set; }

        public virtual IList<ZalihaGrupaLekovaBasic> ZaliheGrupaLekova { get; set; }

        public GrupaLekovaBasic()
        {
            Lekovi = new List<LekBasic>();
            ZaliheGrupaLekova = new List<ZalihaGrupaLekovaBasic>();
        }

        public GrupaLekovaBasic(int id, string naziv)
        {
            this.Id = id;
            this.Naziv = naziv;
        }



    }

    public class GrupaLekovaPregled
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }



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
        public virtual string KomercijalniNaziv { get; set; }
        public virtual string HemijskiNaziv { get; set; }
        public virtual string NacinDoziranjaOdrasli { get; set; }
        public virtual string NacinDoziranjaDeca { get; set; }
        public virtual string NacinDoziranjaTrudnice { get; set; }
        public virtual bool IzdajeSeNaRecept { get; set; }
        public virtual float ProcenatParticipacije { get; set; }
        public virtual float Cena { get; set; }
        public virtual IList<PakovanjeBasic> Pakovanja { get; set; }
        public virtual IList<LekLeciBasic> Leci { get; set; }
        public virtual IList<LekKontraindikacijaBasic> Kontraindikacije { get; set; }
        public virtual GrupaLekovaBasic GrupaLekova { get; set; }
        public virtual IList<ReceptBasic> Recepti { get; set; }


        public LekBasic()
        {
            Pakovanja = new List<PakovanjeBasic>();
            Leci = new List<LekLeciBasic>();
            Kontraindikacije = new List<LekKontraindikacijaBasic>();
            GrupaLekova = new GrupaLekovaBasic(); //da se proveri
            Recepti = new List<ReceptBasic>();
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
        public virtual string KomercijalniNaziv { get; set; }
        public virtual string HemijskiNaziv { get; set; }
        public virtual string NacinDoziranjaOdrasli { get; set; }
        public virtual string NacinDoziranjaDeca { get; set; }
        public virtual string NacinDoziranjaTrudnice { get; set; }
        public virtual bool IzdajeSeNaRecept { get; set; }
        public virtual float ProcenatParticipacije { get; set; }
        public virtual float Cena { get; set; }
        public virtual GrupaLekovaPregled GrupaLekova { get; set; }


        public LekPregled()
        {

        }
        public LekPregled(string kom, string hem, string odrasli, string deca, string trudnice, bool naRecept, float participacija, float cena, GrupaLekovaPregled glp)
        {
            this.KomercijalniNaziv = kom;
            this.HemijskiNaziv = hem;
            this.NacinDoziranjaOdrasli = odrasli;
            this.NacinDoziranjaDeca = deca;
            this.NacinDoziranjaTrudnice = trudnice;
            this.IzdajeSeNaRecept = naRecept;
            this.ProcenatParticipacije = participacija;
            this.Cena = cena;
            this.GrupaLekova = glp;
        }
    }
    #endregion

    #region LekKontradikcija
    public class LekKontraindikacijaBasic
    {
        public virtual LekBasic Lek { get; protected set; }
        public virtual BolestBasic Bolest { get; protected set; }

        public LekKontraindikacijaBasic()
        { }

        public LekKontraindikacijaBasic(LekBasic lek, BolestBasic bolest)
        {
            this.Lek = lek;
            this.Bolest = bolest;
        }

    }
    public class LekKontradikcijaPregled
    {
        public virtual LekPregled Lek { get; protected set; }
        public virtual BolestPregled Bolest { get; protected set; }

        public LekKontradikcijaPregled()
        { }

        public LekKontradikcijaPregled(LekPregled lek, BolestPregled bolest)
        {
            this.Lek = lek;
            this.Bolest = bolest;
        }
    }

    #endregion

    #region LekLeci

    public class LekLeciBasic
    {
        public virtual LekBasic Lek { get; protected set; }
        public virtual BolestBasic Bolest { get; protected set; }

        public LekLeciBasic() { }

        public LekLeciBasic(LekBasic lekBasic, BolestBasic bolest)
        {
            this.Lek = lekBasic;
            this.Bolest = bolest;
        }
    }
    public class LekLeciPregled
    {
        public virtual LekPregled Lek { get; protected set; }
        public virtual BolestPregled Bolest { get; protected set; }

        public LekLeciPregled() { }

        public LekLeciPregled(LekPregled lek, BolestPregled bolest)
        {
            this.Lek = lek;
            this.Bolest = bolest;
        }

    }
    #endregion

    #region Pakovanje

    public class PakovanjeBasic
    {
        public virtual int Id { get; protected set; }
        public virtual string Oblik { get; set; }
        public virtual int Kolicina { get; set; }
        public virtual string Sastav { get; set; }
        public virtual LekBasic Lek { get; set; }

        public PakovanjeBasic()
        {
            Lek = new LekBasic(); //da se proveri
        }

        public PakovanjeBasic(int id, string oblik, int kolicina, string sastav, LekBasic lek)
        {
            this.Id = id;
            this.Oblik = oblik;
            this.Lek = lek;
            this.Sastav = sastav;
            this.Kolicina = kolicina;
        }
    }
    public class PakovanjePregled
    {
        public virtual int Id { get; protected set; }
        public virtual string Oblik { get; set; }
        public virtual int Kolicina { get; set; }
        public virtual string Sastav { get; set; }
        public virtual LekPregled Lek { get; set; }

        public PakovanjePregled()
        {
            Lek = new LekPregled(); // da se proveri
        }

        public PakovanjePregled(int id, string oblik, int kolicina, string sastav, LekPregled lek)
        {
            this.Id = id;
            this.Oblik = oblik;
            this.Lek = lek;
            this.Sastav = sastav;
            this.Kolicina = kolicina;
        }
    }
    #endregion

    #region ProdajnoMesto
    public class ProdajnoMestoBasic
    {
        public virtual string JedinstveniBroj { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string Mesto { get; set; }
        public virtual IList<ZaposleniBasic> Zaposleni { get; set; }
        public virtual IList<ReceptBasic> Recepti { get; set; }
        public virtual IList<ZalihaGrupaLekovaBasic> ZaliheGrupaLekova { get; set; }

        public ProdajnoMestoBasic()
        {
            Zaposleni = new List<ZaposleniBasic>();
            ZaliheGrupaLekova = new List<ZalihaGrupaLekovaBasic>();
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
        public virtual string JedinstveniBroj { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string Mesto { get; set; }


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
        public virtual string SerijskiBroj { get; set; }
        public virtual string SifraLekara { get; set; }
        public virtual string Tip { get; set; }
        public virtual string OblikPakovanja { get; set; }
        public virtual int Kolicina { get; set; }
        public virtual DateTime DatumIzdavanja { get; set; }
        public virtual DateTime? DatumRealizacije { get; set; }
        public virtual ProdajnoMestoBasic ProdajnoMesto { get; set; }
        public virtual FarmaceutBasic Farmaceut { get; set; }
        public virtual LekBasic Lek { get; set; }
        public ReceptBasic()
        {
            DatumIzdavanja = DateTime.Now;
            DatumRealizacije = DateTime.Now;
            ProdajnoMesto = new ProdajnoMestoBasic(); // da se proveri
            Farmaceut = new FarmaceutBasic(); //da se proveri
            Lek = new LekBasic(); //da se proveri
        }

        public ReceptBasic(string sbroj, string sifra, string tip, string oblik,
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
        public virtual string SerijskiBroj { get; set; }
        public virtual string SifraLekara { get; set; }
        public virtual string Tip { get; set; }
        public virtual string OblikPakovanja { get; set; }
        public virtual int Kolicina { get; set; }
        public virtual DateTime DatumIzdavanja { get; set; }
        public virtual DateTime? DatumRealizacije { get; set; }
        public virtual ProdajnoMestoPregled ProdajnoMesto { get; set; }
        public virtual FarmaceutPregled Farmaceut { get; set; }
        public virtual LekPregled Lek { get; set; }


        public ReceptPregled()
        {

        }


        public ReceptPregled(string sbroj, string sifra, string tip, string oblik,
            int kolicina, DateTime izdavanje, DateTime? realizacija)
        {
            this.SerijskiBroj = sbroj;
            this.SifraLekara = sifra;
            this.Tip = tip;
            this.OblikPakovanja = oblik;
            this.Kolicina = kolicina;
            this.DatumIzdavanja = izdavanje;
            this.DatumRealizacije = realizacija;

        }
    }
    #endregion

    #region ZalihaGrupaLekova
    public class ZalihaGrupaLekovaBasic
    {
        public virtual ProdajnoMestoBasic ProdajnoMesto { get; protected set; }
        public virtual GrupaLekovaBasic GrupaLekova { get; protected set; }
        public virtual int Kolicina { get; set; }

        public ZalihaGrupaLekovaBasic()
        {

        }

        public ZalihaGrupaLekovaBasic (ProdajnoMestoBasic prodajno, GrupaLekovaBasic grupa,int kolicina)
        {
            this.ProdajnoMesto = prodajno;
            this.GrupaLekova = grupa;
            this.Kolicina= kolicina;
        }
    }

    public class ZalihaGrupaLekovaPregled
    {
        public virtual ProdajnoMestoPregled ProdajnoMesto { get; protected set; }
        public virtual GrupaLekovaPregled GrupaLekova { get; protected set; }
        public virtual int Kolicina { get; set; }

        public ZalihaGrupaLekovaPregled()
        {

        }

        public ZalihaGrupaLekovaPregled(ProdajnoMestoPregled prodajno, GrupaLekovaPregled grupa, int kolicina)
        {
            this.ProdajnoMesto = prodajno;
            this.GrupaLekova = grupa;
            this.Kolicina = kolicina;
        }
    }
    #endregion

    #region Zaposleni
    public class ZaposleniBasic
    {
        public virtual string JedinstveniBroj { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string BrojTelefona { get; set; }
        public virtual ProdajnoMestoBasic ProdajnoMesto { get; set; }

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
        public virtual string JedinstveniBroj { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string BrojTelefona { get; set; }

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