using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ecom.Models;

public class Writer : IdentityUser<int> //password policy, check if username exists, required fields
{
        [Display(Name = "Prezime")]
        [PersonalData]
        //[StringLength(20, MinimumLength = 2)]
        //[RegularExpression(@"^[A-ZČĆŽĐŠ]+[a-zA-ZšđčćžŠĐŽĆČ\-\. ]*$", ErrorMessage = "Ime mora početi velikim slovom. Samo slova i crtica (-) su podržani.")]
        public string? LastName { get; set; }

        [PersonalData]
        [Display(Name = "Ime")]
        //[StringLength(20, MinimumLength = 2)]
        //[RegularExpression(@"[A-ZŠĐČĆŽ]+[A-Za-zšđčćžŠĐČĆŽ\-\. ]*$",ErrorMessage="Ime mora početi velikim slovom. Samo slova i crtica (-) su podržani.")] 
        public string? FirstName { get; set; }

        //[Required]
        [PersonalData]
        [Display(Name = "Datum rođenja")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")] 
        public DateTime DOB { get; set; }

        [Display(Name = "Puno ime i prezime")]
        public string FullName { get { return FirstName + " " + LastName; } }

        //[Required]
        [Display(Name = "Saldo")]
        public double Balance { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsTopTrader { get; set; }
        public int RatingCount { get; set; }
        //[Required]
        [Display(Name = "Član od ")]
        public DateTime MemberSince { get; set; }
        public int RatingSum { get; set; }
        [Display(Name = "Ocjena")]
        public double AverageRating { 
            get 
            {
                if(RatingCount != 0)
                {
                    return Math.Round( (double)(RatingSum / RatingCount), 2, MidpointRounding.AwayFromZero);
                }
                else return 0.0;
            } 
        }
        public List<int>? FollowedProductIds { get; set; }
        private List<Product>? _products;// { get; set; } 
        public List<Product> Products { get{ return _products ?? (_products = new List<Product>()); } set{ _products = value;} }
}