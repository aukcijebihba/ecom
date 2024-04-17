using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models;

public class Category
{
    public int Id { get; set; }
    [Display(Name = "Naziv")]
    public string? Name { get; set; }
    public string? Keywords { get; set; }
    [Display(Name = "Napomene")]
    public string? Note { get; set; }
    [Display(Name = "Kategorija")]
    public string? DisplayName { get; set;}
}