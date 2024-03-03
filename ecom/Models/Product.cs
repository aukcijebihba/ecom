using System;
using System.ComponentModel.DataAnnotations;
namespace ecom.Models;

/* public enum SubCategories
{   //Kolekcionarstvo
    Militarija, Filatelija, Filumenija, Razglednice, Privjesci, Suveniri, Figurice, Ulaznice, TelKarte, Slicice, Pehari, Tablice, Salvete, Zastave, Maketarstvo, Autici, Ostalo,
    Kovanice, Novcanice, Lotovi, OstaloNumizmatika, //Numizmatika
    KeramikaPorculanStaklo, StNamjestaj, GramofoniPloce, StUredaji, StPriborOprema, StOdjecaObuca, StNakitSatovi, StKnjigeDokumenti, OstaliAntikviteti, //antikv
    Slike, Fotografije, Ikone, Skulpture, OstalaUmjetnost, //Umjetnost
    Knjizevnost, ZnanostEnciklopedije, MagaziniCasopisi, Stripovi, AtlasiZemljovidi, ZaDjecu, OstaloTisak, //Knjige
    CDKazeteVinil, Instrumenti, OstaloGlazba, DVD, BluRay, VhsOstalo, //Glazba i film
    TV, RadioTelefon, LinijeKazetofoni, ZvucniciPojacala, FotoAparatiKamere, Dronovi, KucnoKinoDVDPlayeri, mp3walkmanipod, ostaloAV, //audio video
    Racunala, Laptopi, Tableti, Mobiteli, Crypto, OpremaPunjaci, //racunala i mobiteli
    Konzole, VideoIgrice, OpremaDodaci, //Konzole i igrice
    Kozmetika, Nakit, Satovi, Torbice, Naocale, DragoKamenje, BroseviBedzevi, OstaloLjepota, //ljepota 
    Odjeca, Obuca, SportOprema, OdjecaZaDjecu, //odjeca i moda
    DresoviMajice, Posteri, SportskiDodaci, // Sport
    Namjestaj, BijelaTehnika, AlatiPribor, Zdravlje, KLjubimci, Vozila, OstaloDom, //dom i vrt
    AkcFigurice, NaBaterije, Plisanci, LegoSlaganje, DrustveneIgre, // igre i igracke
    Skola, PosaoUred // skola i posao
} */

public class Product
{
    public int Id { get; set; } 
    [Display(Name = "Naziv")]
    [Required]
    public required string Name { get; set; }
    [Required]
    [Display(Name = "Početna cijena")]
    public decimal StartingPrice { get; set; }
    [Required]
    [Display(Name = "Trenutna cijena")]
    public decimal CurrentPrice { get; set; }
    [Required]
    [Display(Name = "Detaljno")]
    public required string Description { get; set; }
    [Required]
    [Display(Name = "Prodavač")]
    public int SellerId { get; set; }
    [Required]
    [Display(Name = "")]
    public int BuyerId { get; set; }
    [Required]
    public int OfferCount { get; set; }
    [Required]
    public DateTime AuctionStart { get; set; } // aktivni su svi predmeti gdje je trenutno vrijeme između auction start i end
    [Required]
    public DateTime AuctionEnd { get; set; }
    public required Category Category { get; set; }
    public required SubCategory SubCategory { get; set; }
    [Required]
    public required string ImagesUrl { get; set; }
    [Required]
    public bool IsSold { get; set; } 
    public bool HasEnded 
    { 
        get
        {
            if (AuctionEnd > DateTime.Now) return false;
            else return true;
        } 
    }
    [Required]
    public bool IsNew { get; set; } //novo / polovno
    [Required]
    public bool IsSeeded { get; set; } // = 0,00 KM (za početne korisnike, David/Nikola/etc.)
    [Required]
    public bool IsHighlighted { get; set; } //0,70 KM (pin na vrhu kategorije)
    [Required]
    public bool IsAdvertised { get; set; } //IsHighlighted + 1,50 KM = 2,20 KM? (pin na početnoj stranici plus eventualno slika na oglasu na FB/Google/...)
    [Required]
    public bool HasExtraPictures { get; set; } // (up to 10, first 6 free) 0,40 KM
    [Required]
    public bool IsStartTimeAdjusted { get; set; } // 0,20 KM
    [Required]
    public bool IsEndTimeAdjusted { get; set; } // 0,20 KM
    public int ViewCount { get; set; }
    public int FollowerCount { get; set; } // samo za čitanje
    public string? Tags { get; set; } // za lakšu pretragu
    //logika
    //rok dostave, osobno preuzimanje, način plaćanja, dostava unutar/van bih, troškovi dostave, vrijeme plaćanja, slični predmeti, 
    //uvjeti isporuke, komentari, rezervna cijena
}