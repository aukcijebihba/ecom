using System;
using System.ComponentModel.DataAnnotations;
namespace ecom.Models;

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
    [Display(Name = "Kategorija")]
    [Required]
    public int CategoryId { get; set; }
    private Category? _category;
    public Category Category { get  { return _category ??= new Category();} set { _category = value;}}
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
    public bool IsActive 
    {
        get
        {
            if(AuctionStart < DateTime.Now && AuctionEnd > DateTime.Now) return true;
            else return false;
        }
    }
    [Required]
    public DateTime TimeCreated { get; set; }
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